' ============================================================================
' EDrawingsSectionInvoker.vb
' 用途：eDrawings 的 IEModelViewControl 接口没有暴露“左侧面板（模型树/标注树）
'       折叠/收纳”的方法，所以本模块负责把左侧面板收起。
'
' 实现策略：点击面板左侧边缘的折叠手柄（精确点见下），模拟鼠标点击。
'
' 关键事实（2026-08-30 用户实测确认）：
'   折叠手柄在面板“左侧边缘”约 15px 宽的可点击带，且“展开/收纳”点同一个位置。
'   实测有效的精确点击点：X = 左缘 +{10,20}，Y = 距底部 {50,100}（4 个组合均有效）。
'
' 关于“改用 UI 自动化(UIA)”的尝试（2026-08-30，已验证不可行，代码已移除）：
'   曾尝试用 System.Windows.Automation 在面板内查找折叠/展开按钮并 Invoke，
'   但实测确认本机 eDrawings **未向 UI 自动化暴露该控件**：
'     - 全量子树遍历时：左视图找不到任何可 Invoke/可折叠元素；右视图虽能 Invoke 到元素，
'       但点的是无关控件（没收起面板，且有误触风险）。
'     - 改为“限深搜索 + 按实测手柄位置(100px 内)过滤”后：全程 0 次命中。
'   结论：此路不通，保留模拟鼠标方案（已实测稳定）。若将来换 eDrawings 版本想再试，
'   重新引入 UIAutomationClient / UIAutomationTypes / WindowsBase 三个引用即可。
' ============================================================================

Imports System
Imports System.Runtime.InteropServices
Imports System.Text

Public Module EDrawingsSectionInvoker

    ' ----------------------- Win32 常量 -----------------------
    Private Const MOUSEEVENTF_LEFTDOWN As Integer = &H2
    Private Const MOUSEEVENTF_LEFTUP As Integer = &H4
    ' 直接给窗口发鼠标消息（兜底：当合成鼠标事件未被 eDrawings 处理时）
    Private Const WM_LBUTTONDOWN As UInteger = &H201UI
    Private Const WM_LBUTTONUP As UInteger = &H202UI
    Private Const MK_LBUTTON As Integer = &H1

    ' 判定左侧面板是否处于“收纳”状态的宽度阈值（像素）。收起时面板是很窄的一条。
    Private Const LEFT_PANEL_COLLAPSED_WIDTH As Integer = 100

    ' ----------------------- P/Invoke -----------------------
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Function FindWindowEx(hWndParent As IntPtr,
                                  hWndChildAfter As IntPtr,
                                  lpszClass As String,
                                  lpszWindow As String) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Function GetClassName(hWnd As IntPtr,
                                  lpClassName As StringBuilder,
                                  nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Private Function GetWindowRect(hWnd As IntPtr,
                                   ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Function SetCursorPos(X As Integer, Y As Integer) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Function mouse_event(dwFlags As Integer, dx As Integer, dy As Integer,
                                 dwData As Integer, dwExtraInfo As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Function GetCursorPos(ByRef lpPoint As POINT) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Function WindowFromPoint(pt As POINT) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Function ScreenToClient(hWnd As IntPtr, ByRef pt As POINT) As Boolean
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Private Structure POINT
        Public X As Integer
        Public Y As Integer
    End Structure

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Function SendMessage(hWnd As IntPtr, Msg As UInteger,
                                 wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    ' ----------------------- 公开 API -----------------------

    ''' <summary>
    ''' 在 root 下找 eDrawings 左侧面板。其窗口类固定为 "eModel Pane"；
    ''' 选其中贴在最左（Left 最小）且占满大部分高度的那个。
    ''' </summary>
    Public Function FindEDrawingsLeftPanel(root As IntPtr) As IntPtr
        If root = IntPtr.Zero Then Return IntPtr.Zero
        Dim rootRc As RECT
        If Not GetWindowRect(root, rootRc) Then Return IntPtr.Zero
        Dim best As IntPtr = IntPtr.Zero
        Dim bestLeft As Integer = Integer.MaxValue
        Dim rootH As Integer = rootRc.Bottom - rootRc.Top
        CollectPanes(root, rootH, best, bestLeft)
        Return best
    End Function

    Private Sub CollectPanes(hWnd As IntPtr, rootH As Integer,
                             ByRef best As IntPtr, ByRef bestLeft As Integer)
        Dim child As IntPtr = FindWindowEx(hWnd, IntPtr.Zero, Nothing, Nothing)
        While child <> IntPtr.Zero
            Dim cls As String = GetClassNameSafe(child)
            If cls.IndexOf("eModel Pane", StringComparison.OrdinalIgnoreCase) >= 0 Then
                Dim rc As RECT
                If GetWindowRect(child, rc) Then
                    Dim h As Integer = rc.Bottom - rc.Top
                    If h >= CInt(rootH * 0.6) AndAlso rc.Left < bestLeft Then
                        bestLeft = rc.Left
                        best = child
                    End If
                End If
            End If
            CollectPanes(child, rootH, best, bestLeft)
            child = FindWindowEx(hWnd, child, Nothing, Nothing)
        End While
    End Sub

    ''' <summary>
    ''' 确保左侧面板处于收纳状态：在用户实测有效的精确点击点
    ''' （X = 左缘 +{10,20}，Y = 距底部 {50,100}）点按。一次调用只尝试一个点（由定时器分拍调用），
    ''' 避免一次性狂点导致界面卡顿 / 鼠标乱跳。命中（宽度变小）后下一拍会判定“已收纳”并停止。
    ''' 返回状态字符串（供诊断日志）：
    '''   "未找到面板"        - 面板尚未出现（文档仍在加载），不消耗尝试次数；
    '''   "已收纳"            - 已是收起态，无需操作；
    '''   "已点击收纳@L+N"    - 已对左缘 +N 像素、Y=Bottom-M 处发起点按，待下一拍校验。
    ''' </summary>
    Public Function EnsureLeftPanelCollapsed(root As IntPtr) As String
        Dim panel As IntPtr = FindEDrawingsLeftPanel(root)
        If panel = IntPtr.Zero Then Return "未找到面板"
        Dim w As Integer = GetPaneWidth(panel)
        If w <= LEFT_PANEL_COLLAPSED_WIDTH Then
            Return "已收纳"
        End If
        Dim idx As Integer = Math.Min(_mouseIdx, CollapseX.Length - 1)
        _mouseIdx += 1
        Dim rc As RECT
        GetWindowRect(panel, rc)
        ' 用户实测可用的精确点击点
        Dim x As Integer = rc.Left + CollapseX(idx)
        Dim y As Integer = rc.Bottom - CollapseY(idx)
        ClickAt(x, y)
        Return "已点击收纳@L" & CollapseX(idx) & " Y=Bottom-" & CollapseY(idx)
    End Function

    ''' <summary>开始一轮自动收纳会话：重置候选点游标（每次切换模型/图纸时调用）。</summary>
    Public Sub BeginCollapseSession()
        _mouseIdx = 0
    End Sub

    ' 自动收纳时按序尝试的精确点击点（用户实测有效）：
    '   CollapseX = 相对 rc.Left 的像素偏移（左侧边缘可点击带）
    '   CollapseY = 距面板底部往上的像素数（Y 坐标）
    Private ReadOnly CollapseX As Integer() = {15, 15, 15, 15}
    Private ReadOnly CollapseY As Integer() = {50, 50, 50, 50}
    ' 当前尝试到第几个点（模块级；左/右两个视图共用同一游标，二者几何一致，安全）
    Private _mouseIdx As Integer = 0

    Private Sub ClickAt(x As Integer, y As Integer)
        Dim orig As POINT
        GetCursorPos(orig)
        SetCursorPos(x, y)
        ' 短暂停留，让目标窗口处理“鼠标移动”消息（折叠箭头/分割条命中依赖 hover），提高点中率
        System.Threading.Thread.Sleep(30)
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero)
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero)
        ' 点击后把鼠标还原到原来的位置，避免“跑位”
        SetCursorPos(orig.X, orig.Y)
    End Sub

    ' 直接给“该屏幕点所在窗口”发 WM_LBUTTONDOWN/UP（不移动真实鼠标），
    ' 作为合成鼠标点击的兜底——某些控件只响应投递到自身窗口过程的鼠标消息。
    Private Function ClickViaMessage(x As Integer, y As Integer) As Boolean
        Dim pt As POINT
        pt.X = x : pt.Y = y
        Dim hwnd As IntPtr = WindowFromPoint(pt)
        If hwnd = IntPtr.Zero Then Return False
        If ScreenToClient(hwnd, pt) Then
            Dim lParam As Integer = (pt.Y << 16) Or (pt.X And &HFFFF)
            SendMessage(hwnd, WM_LBUTTONDOWN, New IntPtr(MK_LBUTTON), New IntPtr(lParam))
            SendMessage(hwnd, WM_LBUTTONUP, IntPtr.Zero, New IntPtr(lParam))
            Return True
        End If
        Return False
    End Function

    Private Sub DoubleClickAt(x As Integer, y As Integer)
        Dim orig As POINT
        GetCursorPos(orig)
        SetCursorPos(x, y)
        System.Threading.Thread.Sleep(30)
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero)
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero)
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero)
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero)
        SetCursorPos(orig.X, orig.Y)
    End Sub

    Private Function GetPaneWidth(hWnd As IntPtr) As Integer
        Dim rc As RECT
        If GetWindowRect(hWnd, rc) Then Return rc.Right - rc.Left
        Return -1
    End Function

    ''' <summary>
    ''' 诊断：聚焦“左侧边缘 15px 可点击带”扫描（用户实测该带点击即可在收纳/展开间切换）。
    ''' 逐项真实点击、对比点击前后宽度，找出命中带。每个点依次尝试：
    '''   ① 合成鼠标(单) ② 合成鼠标(双) ③ 直接发消息到该点所在窗口；
    ''' 命中会再点一次还原。需在面板已展开(w≈250)时运行。
    ''' </summary>
    Public Function ProbeCollapseHandle(root As IntPtr) As String
        Dim panel As IntPtr = FindEDrawingsLeftPanel(root)
        If panel = IntPtr.Zero Then Return "未找到左侧面板（class=eModel Pane）"
        Dim rc As RECT
        GetWindowRect(panel, rc)
        Dim w0 As Integer = rc.Right - rc.Left
        If w0 <= LEFT_PANEL_COLLAPSED_WIDTH Then
            Return String.Format("面板当前是收起态(w={0})，请先手动展开后再扫描。", w0)
        End If
        Dim sb As New StringBuilder()
        sb.AppendFormat("面板 hwnd=0x{0:X} rect=({1},{2})-({3},{4}) w={5}{6}",
                        panel.ToInt64(), rc.Left, rc.Top, rc.Right, rc.Bottom, w0,
                        Environment.NewLine)
        sb.AppendLine("逐项点击测试（xoff 为相对面板左缘 rc.Left 的像素偏移；命中行即自动收纳该用的点）：")

        ' Y 坐标：用户实测有效的精确点 = 距底部 50 / 100px；X：左缘偏移 10 / 20（其余对照点已移除，扫描更快）
        Dim yRows() As Integer = {rc.Bottom - 50, rc.Bottom - 100}
        Dim leftOffs() As Integer = {10, 20}

        ' 处理单点：依次尝试三种点击方式，命中即记录并同样方式还原
        Dim testPoint As Action(Of Integer, Integer) =
            Sub(x As Integer, y As Integer)
                Dim before As Integer = GetPaneWidth(panel)
                ClickAt(x, y)
                System.Threading.Thread.Sleep(120)
                Dim after As Integer = GetPaneWidth(panel)
                Dim method As String = "鼠标单点"
                If before = after Then
                    DoubleClickAt(x, y)
                    System.Threading.Thread.Sleep(120)
                    after = GetPaneWidth(panel)
                    method = "鼠标双击"
                End If
                If before = after Then
                    If ClickViaMessage(x, y) Then
                        System.Threading.Thread.Sleep(120)
                        after = GetPaneWidth(panel)
                        method = "消息直发"
                    End If
                End If
                If before <> after Then
                    Dim dir As String = If(after < before, "收起", "展开")
                    sb.AppendFormat("  [命中] 左缘 xoff={0,+3} y={1} 宽 {2}->{3} [{4}] ({5}){6}",
                                    x - rc.Left, y, before, after, dir, method, Environment.NewLine)
                    ' 还原：用与“命中方式”完全一致的方式再点一次。
                    ' 注意：三种方式必须互斥、各只点一次，不能叠加（否则双点会再次切换回去，状态错乱）。
                    If method = "鼠标双击" Then
                        DoubleClickAt(x, y)
                    ElseIf method = "消息直发" Then
                        ClickViaMessage(x, y)
                    Else
                        ClickAt(x, y)
                    End If
                    System.Threading.Thread.Sleep(120)
                    sb.AppendFormat("          还原后宽={0}{1}", GetPaneWidth(panel), Environment.NewLine)
                End If
            End Sub

        For Each y As Integer In yRows
            For Each off As Integer In leftOffs
                testPoint(rc.Left + off, y)
            Next
        Next
        sb.AppendLine(">>> 把带[命中]且方向为收起的行贴回，那就是自动收纳该用的点击点（xoff 即相对 rc.Left 的偏移）。")
        Return sb.ToString()
    End Function

    Private Function GetClassNameSafe(hWnd As IntPtr) As String
        Dim sb As New StringBuilder(256)
        GetClassName(hWnd, sb, sb.Capacity)
        Return sb.ToString()
    End Function

End Module
