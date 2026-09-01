Option Explicit On
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms


Public Class eDrawingsChecker
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' 构建“面板收纳”诊断 UI（不改动设计器生成的布局代码）
        InitDiagUI()

        ' 构建文件列表窗口（运行时创建，不改动设计器生成的布局代码）
        InitFileListUI()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AxEModelViewControl2 As AxEModelView.AxEModelViewControl
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btn_back As Button
    Friend WithEvents btn_file As Button
    Friend WithEvents btn_bottom As Button
    Friend WithEvents btn_front As Button
    Friend WithEvents btn_right As Button
    Friend WithEvents btn_top As Button
    Friend WithEvents btn_left As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Btn_filelist_previous As Button
    Friend WithEvents lblPosition As Label
    Friend WithEvents Btn_filelist_next As Button
    Friend WithEvents btn_Home As Button
    Friend WithEvents Btn_Open_File As Button
    Friend WithEvents AxEModelViewControl1 As AxEModelView.AxEModelViewControl
    Friend WithEvents btn_measure As Button
    Friend WithEvents btn_filelist As Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(eDrawingsChecker))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btn_left = New System.Windows.Forms.Button()
        Me.btn_top = New System.Windows.Forms.Button()
        Me.btn_right = New System.Windows.Forms.Button()
        Me.btn_front = New System.Windows.Forms.Button()
        Me.btn_bottom = New System.Windows.Forms.Button()
        Me.btn_back = New System.Windows.Forms.Button()
        Me.btn_Home = New System.Windows.Forms.Button()
        Me.btn_measure = New System.Windows.Forms.Button()
        Me.btn_filelist = New System.Windows.Forms.Button()
        Me.btn_file = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_filelist_next = New System.Windows.Forms.Button()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.Btn_filelist_previous = New System.Windows.Forms.Button()
        Me.Btn_Open_File = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.AxEModelViewControl2 = New AxEModelView.AxEModelViewControl()
        Me.AxEModelViewControl1 = New AxEModelView.AxEModelViewControl()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.AxEModelViewControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxEModelViewControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "SolidWorks模型文件(*.sldprt;*.sldasm)|*.sldprt;*.sldasm"
        '
        'btn_left
        '
        Me.btn_left.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_left.Enabled = False
        Me.btn_left.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_left.Location = New System.Drawing.Point(187, 3)
        Me.btn_left.Name = "btn_left"
        Me.btn_left.Size = New System.Drawing.Size(86, 28)
        Me.btn_left.TabIndex = 26
        Me.btn_left.Text = "Left"
        '
        'btn_top
        '
        Me.btn_top.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_top.Enabled = False
        Me.btn_top.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_top.Location = New System.Drawing.Point(279, 3)
        Me.btn_top.Name = "btn_top"
        Me.btn_top.Size = New System.Drawing.Size(86, 28)
        Me.btn_top.TabIndex = 27
        Me.btn_top.Text = "Top"
        '
        'btn_right
        '
        Me.btn_right.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_right.Enabled = False
        Me.btn_right.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_right.Location = New System.Drawing.Point(371, 3)
        Me.btn_right.Name = "btn_right"
        Me.btn_right.Size = New System.Drawing.Size(86, 28)
        Me.btn_right.TabIndex = 24
        Me.btn_right.Text = "Right"
        '
        'btn_front
        '
        Me.btn_front.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_front.Enabled = False
        Me.btn_front.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_front.Location = New System.Drawing.Point(95, 3)
        Me.btn_front.Name = "btn_front"
        Me.btn_front.Size = New System.Drawing.Size(86, 28)
        Me.btn_front.TabIndex = 25
        Me.btn_front.Text = "Front"
        '
        'btn_bottom
        '
        Me.btn_bottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_bottom.Enabled = False
        Me.btn_bottom.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_bottom.Location = New System.Drawing.Point(463, 3)
        Me.btn_bottom.Name = "btn_bottom"
        Me.btn_bottom.Size = New System.Drawing.Size(86, 28)
        Me.btn_bottom.TabIndex = 29
        Me.btn_bottom.Text = "Bottom"
        '
        'btn_back
        '
        Me.btn_back.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_back.Enabled = False
        Me.btn_back.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_back.Location = New System.Drawing.Point(555, 3)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(86, 28)
        Me.btn_back.TabIndex = 28
        Me.btn_back.Text = "Back"
        '
        'btn_Home
        '
        Me.btn_Home.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Home.Enabled = False
        Me.btn_Home.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_Home.Location = New System.Drawing.Point(647, 3)
        Me.btn_Home.Name = "btn_Home"
        Me.btn_Home.Size = New System.Drawing.Size(86, 28)
        Me.btn_Home.TabIndex = 28
        Me.btn_Home.Text = "Home"
        '
        'btn_measure
        '
        Me.btn_measure.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_measure.Enabled = False
        Me.btn_measure.BackColor = System.Drawing.Color.FromArgb(192, 255, 192)
        Me.btn_measure.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_measure.ForeColor = System.Drawing.Color.FromArgb(0, 96, 0)
        Me.btn_measure.Location = New System.Drawing.Point(463, 3)
        Me.btn_measure.Name = "btn_measure"
        Me.btn_measure.Size = New System.Drawing.Size(86, 28)
        Me.btn_measure.TabIndex = 30
        Me.btn_measure.Text = "Measure"
        '
        'btn_filelist
        '
        Me.btn_filelist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_filelist.Enabled = False
        Me.btn_filelist.BackColor = System.Drawing.Color.FromArgb(255, 224, 192)
        Me.btn_filelist.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_filelist.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0)
        Me.btn_filelist.Location = New System.Drawing.Point(371, 3)
        Me.btn_filelist.Name = "btn_filelist"
        Me.btn_filelist.Size = New System.Drawing.Size(86, 28)
        Me.btn_filelist.TabIndex = 31
        Me.btn_filelist.Text = "File List"
        '
        'btn_file
        '
        Me.btn_file.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_file.BackColor = System.Drawing.Color.Transparent
        Me.btn_file.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btn_file.ForeColor = System.Drawing.Color.Red
        Me.btn_file.Location = New System.Drawing.Point(3, 3)
        Me.btn_file.Name = "btn_file"
        Me.btn_file.Size = New System.Drawing.Size(86, 28)
        Me.btn_file.TabIndex = 9
        Me.btn_file.Text = "Open"
        Me.btn_file.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel3.Controls.Add(Me.btn_file, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_front, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_left, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_top, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_right, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_bottom, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_back, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_Home, 7, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(736, 34)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 1, 0)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1484, 40)
        Me.TableLayoutPanel2.TabIndex = 59
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_filelist_next, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPosition, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_filelist_previous, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_measure, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btn_filelist, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_Open_File, 5, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(745, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(736, 34)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Btn_filelist_next
        '
        Me.Btn_filelist_next.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_filelist_next.Enabled = False
        Me.Btn_filelist_next.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_filelist_next.Location = New System.Drawing.Point(279, 3)
        Me.Btn_filelist_next.Name = "Btn_filelist_next"
        Me.Btn_filelist_next.Size = New System.Drawing.Size(86, 28)
        Me.Btn_filelist_next.TabIndex = 28
        Me.Btn_filelist_next.Text = "Next"
        '
        'lblPosition
        '
        Me.lblPosition.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPosition.Font = New System.Drawing.Font("楷体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblPosition.Location = New System.Drawing.Point(3, 0)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(178, 34)
        Me.lblPosition.TabIndex = 0
        Me.lblPosition.Text = "00/00"
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Btn_filelist_previous
        '
        Me.Btn_filelist_previous.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_filelist_previous.Enabled = False
        Me.Btn_filelist_previous.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_filelist_previous.Location = New System.Drawing.Point(187, 3)
        Me.Btn_filelist_previous.Name = "Btn_filelist_previous"
        Me.Btn_filelist_previous.Size = New System.Drawing.Size(86, 28)
        Me.Btn_filelist_previous.TabIndex = 28
        Me.Btn_filelist_previous.Text = "Previous"
        '
        'Btn_Open_File
        '
        Me.Btn_Open_File.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Open_File.Enabled = False
        Me.Btn_Open_File.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Btn_Open_File.Location = New System.Drawing.Point(555, 3)
        Me.Btn_Open_File.Name = "Btn_Open_File"
        Me.Btn_Open_File.Size = New System.Drawing.Size(86, 28)
        Me.Btn_Open_File.TabIndex = 28
        Me.Btn_Open_File.Text = "Open File"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.AxEModelViewControl2)
        Me.SplitContainer1.Panel1MinSize = 50
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.AxEModelViewControl1)
        Me.SplitContainer1.Panel2MinSize = 50
        Me.SplitContainer1.Size = New System.Drawing.Size(1484, 960)
        Me.SplitContainer1.SplitterDistance = 740
        Me.SplitContainer1.TabIndex = 60
        '
        'AxEModelViewControl2
        '
        Me.AxEModelViewControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxEModelViewControl2.CausesValidation = False
        Me.AxEModelViewControl2.Enabled = True
        Me.AxEModelViewControl2.Location = New System.Drawing.Point(0, 0)
        Me.AxEModelViewControl2.Margin = New System.Windows.Forms.Padding(0)
        Me.AxEModelViewControl2.Name = "AxEModelViewControl2"
        Me.AxEModelViewControl2.OcxState = CType(resources.GetObject("AxEModelViewControl2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxEModelViewControl2.Size = New System.Drawing.Size(743, 962)
        Me.AxEModelViewControl2.TabIndex = 58
        '
        'AxEModelViewControl1
        '
        Me.AxEModelViewControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxEModelViewControl1.CausesValidation = False
        Me.AxEModelViewControl1.Enabled = True
        Me.AxEModelViewControl1.Location = New System.Drawing.Point(0, 0)
        Me.AxEModelViewControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.AxEModelViewControl1.Name = "AxEModelViewControl1"
        Me.AxEModelViewControl1.OcxState = CType(resources.GetObject("AxEModelViewControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxEModelViewControl1.Size = New System.Drawing.Size(742, 961)
        Me.AxEModelViewControl1.TabIndex = 57
        '
        'eDrawingsChecker
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1484, 961)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1500, 1000)
        Me.Name = "eDrawingsChecker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "eDrawings Checker"
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.AxEModelViewControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxEModelViewControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region " 面板收纳诊断 UI（运行时创建，不改动设计器代码） "

    ' 诊断输出窗口（无模式窗体）及其上的文本框 / 扫描按钮
    Private diagForm As System.Windows.Forms.Form = Nothing
    Private txtDiag As System.Windows.Forms.TextBox = Nothing
    Private btnDiagScan As System.Windows.Forms.Button = Nothing

    ''' <summary>
    ''' 构建“面板收纳”诊断输出窗口与“扫描面板收纳点”按钮（不改动设计器生成的布局代码）。
    ''' </summary>
    Private Sub InitDiagUI()
        ' ---- 诊断输出窗口 ----
        diagForm = New System.Windows.Forms.Form()
        diagForm.Text = "面板收纳诊断输出"
        diagForm.Size = New System.Drawing.Size(760, 400)
        diagForm.StartPosition = FormStartPosition.CenterScreen
        diagForm.TopMost = True
        diagForm.FormBorderStyle = FormBorderStyle.Sizable

        txtDiag = New System.Windows.Forms.TextBox()
        txtDiag.Dock = DockStyle.Fill
        txtDiag.Multiline = True
        txtDiag.ScrollBars = ScrollBars.Vertical
        txtDiag.ReadOnly = True
        txtDiag.Font = New System.Drawing.Font("Consolas", 9.0!)
        txtDiag.BackColor = System.Drawing.Color.White
        txtDiag.ForeColor = System.Drawing.Color.Black
        diagForm.Controls.Add(txtDiag)

        ' ---- 底部按钮区（扫描面板收纳点） ----
        Dim diagBottom As New System.Windows.Forms.Panel()
        diagBottom.Dock = DockStyle.Bottom
        diagBottom.Height = 34
        diagForm.Controls.Add(diagBottom)

        btnDiagScan = New System.Windows.Forms.Button()
        btnDiagScan.Dock = DockStyle.Fill
        btnDiagScan.Text = "扫描面板收纳点"
        btnDiagScan.Font = New System.Drawing.Font("宋体", 9.0!, FontStyle.Bold)
        AddHandler btnDiagScan.Click, AddressOf btnDiagScan_Click
        diagBottom.Controls.Add(btnDiagScan)

    End Sub

    ''' <summary>实时把一行写进诊断窗口，并立即刷新（点按钮时逐行可见）。</summary>
    Private Sub AppendDiag(line As String)
        If txtDiag Is Nothing Then Return
        txtDiag.AppendText(line & Environment.NewLine)
        txtDiag.SelectionStart = txtDiag.TextLength
        txtDiag.ScrollToCaret()
        Application.DoEvents() ' 让界面在枚举过程中实时刷新
    End Sub

    ''' <summary>
    ''' 诊断窗口里的“扫描面板收纳点”按钮：在面板展开状态下，沿左缘/右缘扫描一排候选点击点，
    ''' 找出真正能把展开面板收起的那个点。扫描期间临时收起诊断窗体以免遮挡点击，结束后恢复。
    ''' </summary>
    Private Sub btnDiagScan_Click(sender As Object, e As EventArgs)
        If diagForm Is Nothing Then InitDiagUI()
        Dim wasVisible As Boolean = (diagForm IsNot Nothing AndAlso diagForm.Visible)
        If wasVisible Then diagForm.Hide()
        Application.DoEvents()
        AppendDiag("")
        AppendDiag("========== 扫描左侧面板收起点击点 ==========")
        Dim report As String = EDrawingsSectionInvoker.ProbeCollapseHandle(AxEModelViewControl2.Handle)
        If wasVisible Then diagForm.Show()
        ' 报告含多行，逐行写进诊断窗口
        Dim lines() As String = report.Split(New String() {Environment.NewLine, vbCrLf, vbLf},
                                             StringSplitOptions.RemoveEmptyEntries)
        For Each ln As String In lines
            AppendDiag(ln)
        Next
        LogHook("[ProbeCollapse] " & report.Replace(Environment.NewLine, " | "))
    End Sub

#End Region


#Region " 文件列表窗口（运行时创建，不改动设计器代码） "

    ' 文件列表窗口及其 ListView / 排除按钮
    Private fileListForm As System.Windows.Forms.Form = Nothing
    Private fileListLv As System.Windows.Forms.ListView = Nothing
    Private btnExclude As System.Windows.Forms.Button = Nothing
    ' 列表窗口最近一次因失去焦点而隐藏的时刻（用于区分“点按钮触发的失焦”与“点主窗口触发的失焦”）
    Private _fileListLastHideTick As Integer = 0
    ' 被排除条目的下标集合（fileList 中的索引）；被排除项既不显示在清单里，Previous/Next 也会跳过
    Private excludedIndices As New HashSet(Of Integer)()

    ''' <summary>构建文件列表窗口（列：序号/名称/类型/模型/工程图），运行时创建不改动设计器代码。</summary>
    Private Sub InitFileListUI()
        fileListForm = New System.Windows.Forms.Form()
        fileListForm.Text = "File List"
        ' 客户区宽度 = 列宽合计(430) + 垂直滚动条(17) + 余量(1)，刚好显示所有列且无水平滚动条
        fileListForm.ClientSize = New System.Drawing.Size(448, 386)
        fileListForm.StartPosition = FormStartPosition.Manual
        ' 不允许缩放到过小（外框最小宽度对应客户区 448）
        fileListForm.MinimumSize = New System.Drawing.Size(464, 260)
        fileListForm.FormBorderStyle = FormBorderStyle.Sizable
        fileListForm.ShowInTaskbar = False
        fileListForm.MinimizeBox = False
        fileListForm.MaximizeBox = False

        ' ListView：序号 / 名称 / 类型 / 模型 / 工程图（模型、工程图用实心圆圈标识存在性）
        fileListLv = New System.Windows.Forms.ListView()
        fileListLv.Dock = DockStyle.Fill
        fileListLv.BorderStyle = BorderStyle.None
        fileListLv.View = View.Details
        fileListLv.FullRowSelect = True
        fileListLv.MultiSelect = True
        fileListLv.GridLines = True
        fileListLv.Font = New System.Drawing.Font("宋体", 9.0!)
        ' 使用系统默认选中样式（不开启 OwnerDraw）
        AddHandler fileListLv.MouseDoubleClick, AddressOf FileListLv_DoubleClick
        ' 列：序号(中) / 名称(左) / 类型(中) / 模型(中) / 工程图(中)
        fileListLv.Columns.Add("序号", 50, HorizontalAlignment.Center)
        fileListLv.Columns.Add("名称", 200, HorizontalAlignment.Left)
        fileListLv.Columns.Add("类型", 70, HorizontalAlignment.Center)
        fileListLv.Columns.Add("模型", 50, HorizontalAlignment.Center)
        fileListLv.Columns.Add("工程图", 60, HorizontalAlignment.Center)
        ' 先加入 ListView（Fill），再加入底部按钮条（Bottom），保证按钮条始终在 ListView 上方可见
        fileListForm.Controls.Add(fileListLv)

        ' 底部按钮条：中间“Exclude Selected”按钮
        Dim bottomPanel As New System.Windows.Forms.Panel()
        bottomPanel.Dock = DockStyle.Bottom
        bottomPanel.Height = 34
        bottomPanel.BackColor = SystemColors.Control
        fileListForm.Controls.Add(bottomPanel)

        btnExclude = New System.Windows.Forms.Button()
        btnExclude.Text = "Exclude Selected"
        btnExclude.Size = New System.Drawing.Size(120, 26)
        btnExclude.Anchor = AnchorStyles.None
        btnExclude.Font = New System.Drawing.Font("宋体", 9.0!)
        AddHandler btnExclude.Click, AddressOf btnExclude_Click
        bottomPanel.Controls.Add(btnExclude)
        ' 居中布局：用 Layout 事件保证初次显示与缩放都居中
        AddHandler bottomPanel.Layout, Sub() btnExclude.Location = New Point((bottomPanel.Width - btnExclude.Width) \ 2, (bottomPanel.Height - btnExclude.Height) \ 2)
        ' 立即定位一次（Layout 在首次显示前可能未触发）
        btnExclude.Location = New Point((bottomPanel.Width - btnExclude.Width) \ 2, (bottomPanel.Height - btnExclude.Height) \ 2)

        ' 重建窗口后重新填充内容
        PopulateFileList()
    End Sub

    ''' <summary>把 fileList 填入 ListView（清空后重建）；被排除的条目不显示，序号连续重排。</summary>
    Private Sub PopulateFileList()
        If fileListLv Is Nothing Then Return
        excludedIndices.Clear()
        RebuildFileListItems()
    End Sub

    ''' <summary>按 excludedIndices 重建清单：被排除项不显示，序号从 1 连续编号（仅显示用）。</summary>
    Private Sub RebuildFileListItems()
        If fileListLv Is Nothing Then Return
        fileListLv.BeginUpdate()
        fileListLv.Items.Clear()
        Dim seq As Integer = 1
        For i As Integer = 0 To fileList.Count - 1
            If excludedIndices.Contains(i) Then Continue For
            fileListLv.Items.Add(BuildFileListItem(i, seq))
            seq += 1
        Next
        fileListLv.EndUpdate()
    End Sub

    ''' <summary>为 fileList 中的下标构建一行 ListView 项：序号(显示序号)/名称/类型/模型存在/工程图存在。</summary>
    Private Function BuildFileListItem(fileIdx As Integer, displaySeq As Integer) As ListViewItem
        Dim modelPath As String = fileList(fileIdx)
        Dim nameOnly As String = Path.GetFileNameWithoutExtension(modelPath)
        Dim ext As String = Path.GetExtension(modelPath)
        Dim typeStr As String = If(ext IsNot Nothing, ext.TrimStart("."c).ToUpper(), "")
        Dim drawingPath As String = Check_Slddrw_File(modelPath)
        Dim hasModel As Boolean = Not String.IsNullOrEmpty(modelPath)
        Dim hasDrawing As Boolean = Not String.IsNullOrEmpty(drawingPath)
        ' ● 表示存在，空字符串表示无
        Dim modelMark As String = If(hasModel, "●", "")
        Dim drawingMark As String = If(hasDrawing, "●", "")

        ' 第 0 列文本由 ListViewItem 构造参数提供
        Dim lvi As New ListViewItem(displaySeq.ToString())
        lvi.UseItemStyleForSubItems = False
        lvi.SubItems.Add(nameOnly)
        lvi.SubItems.Add(typeStr)
        Dim modelSub As New ListViewItem.ListViewSubItem(lvi, modelMark)
        modelSub.ForeColor = If(hasModel, Color.Green, Color.Gray)
        modelSub.Font = New System.Drawing.Font("宋体", 10.0!, FontStyle.Bold)
        Dim drawSub As New ListViewItem.ListViewSubItem(lvi, drawingMark)
        drawSub.ForeColor = If(hasDrawing, Color.Green, Color.Gray)
        drawSub.Font = New System.Drawing.Font("宋体", 10.0!, FontStyle.Bold)
        lvi.SubItems.Add(modelSub)
        lvi.SubItems.Add(drawSub)
        lvi.Tag = fileIdx   ' 保存 fileList 中的下标，供双击载入使用
        Return lvi
    End Function

    ''' <summary>File List 按钮：显示/隐藏文件列表窗口。</summary>
    Private Sub btn_filelist_Click(sender As Object, e As EventArgs) Handles btn_filelist.Click
        ' 窗体可能已被释放（例如被主窗口 Dispose 带动），此时重建
        If fileListForm Is Nothing OrElse fileListForm.IsDisposed Then InitFileListUI()
        If fileListForm.Visible Then
            fileListForm.Hide()
        Else
            ' 若刚刚因失去焦点而隐藏（点本按钮会先触发列表窗口 Deactivate），
            ' 本次点击视为“隐藏”，不重新弹出，保证按钮点击为标准的开关切换
            If Environment.TickCount - _fileListLastHideTick < 300 Then Return
            PositionFileListForm()
            fileListForm.Show(Me)
            ' 选中并滚动到当前条目（按 Tag 匹配 fileList 中的 currentIndex）
            SelectCurrentRow()
        End If
    End Sub

    ''' <summary>选中并滚动到当前条目（按 Tag = currentIndex 匹配，排除后行顺序会变）。</summary>
    Private Sub SelectCurrentRow()
        If fileListLv Is Nothing OrElse fileListLv.Items.Count = 0 Then Return
        fileListLv.SelectedItems.Clear()
        For Each lvi As ListViewItem In fileListLv.Items
            If CInt(lvi.Tag) = currentIndex Then
                lvi.Selected = True
                lvi.EnsureVisible()
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' 把文件列表窗口定位到主窗口 File List 按钮下方；右不超过主窗口右边缘，下不超过主窗口下边缘。
    ''' 高度也根据主窗口剩余空间自适应，避免超出下边缘。
    ''' </summary>
    Private Sub PositionFileListForm()
        If fileListForm Is Nothing Then Return
        Dim btnRect As Rectangle = btn_filelist.RectangleToScreen(btn_filelist.ClientRectangle)
        Dim mainRect As Rectangle = Me.RectangleToScreen(Me.ClientRectangle)

        Dim x As Integer = btnRect.Left
        Dim y As Integer = btnRect.Bottom + 2

        ' 右不超过主窗口右边缘
        Dim maxRight As Integer = mainRect.Right - 4
        If x + fileListForm.Width > maxRight Then x = maxRight - fileListForm.Width
        If x < mainRect.Left Then x = mainRect.Left

        ' 下不超过主窗口下边缘：若默认高度超出，则压缩高度到下边缘
        Dim maxBottom As Integer = mainRect.Bottom - 4
        Dim w As Integer = fileListForm.Width
        Dim h As Integer = fileListForm.Height
        If y + h > maxBottom Then
            h = maxBottom - y
            If h < fileListForm.MinimumSize.Height Then
                h = fileListForm.MinimumSize.Height
                ' 高度回弹到最小后，y 上移使下边缘不越界
                y = maxBottom - h
            End If
        End If
        If y < mainRect.Top Then y = mainRect.Top

        fileListForm.Location = New System.Drawing.Point(x, y)
        fileListForm.Size = New System.Drawing.Size(w, h)
    End Sub

    ''' <summary>列表窗口失去焦点（点击主窗口等）时自动隐藏。</summary>
    Private Sub FileListForm_Deactivate(sender As Object, e As EventArgs)
        If fileListForm IsNot Nothing AndAlso fileListForm.Visible Then
            fileListForm.Hide()
            _fileListLastHideTick = Environment.TickCount
        End If
    End Sub

    ''' <summary>点 X 仅隐藏而非销毁，便于反复打开。</summary>
    Private Sub FileListForm_FormClosing(sender As Object, e As FormClosingEventArgs)
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            fileListForm.Hide()
            _fileListLastHideTick = Environment.TickCount
        End If
    End Sub

    ''' <summary>双击条目：载入对应的模型和工程图，并隐藏列表窗口。</summary>
    Private Sub FileListLv_DoubleClick(sender As Object, e As MouseEventArgs)
        If fileListLv Is Nothing Then Return
        Dim hi As ListViewHitTestInfo = fileListLv.HitTest(e.Location)
        If hi Is Nothing OrElse hi.Item Is Nothing Then Return
        Dim idx As Integer = CInt(hi.Item.Tag)
        If idx < 0 OrElse idx >= fileList.Count Then Return
        BeginLoad(idx)
        UpdatePositionLabel()
        fileListForm.Hide()
    End Sub

    ''' <summary>“排除”按钮：把当前选中的条目从清单移除（不显示），Previous/Next 也会跳过。</summary>
    Private Sub btnExclude_Click(sender As Object, e As EventArgs)
        If fileListLv Is Nothing OrElse fileListLv.SelectedItems.Count = 0 Then Return
        ' 收集被排除条目的 fileList 下标（按 Tag）
        For Each lvi As ListViewItem In fileListLv.SelectedItems
            excludedIndices.Add(CInt(lvi.Tag))
        Next
        ' 重建清单（被排除项不再显示，序号连续重排）
        RebuildFileListItems()
        UpdatePositionLabel()
        ' 排除后清空选中状态：避免某行处于“已选中”时，用户首次点击被系统当作双击序列的第二次点击而误触发载入
        fileListLv.SelectedItems.Clear()
    End Sub

    ''' <summary>从 fromIndex 出发按 direction(+1/-1) 找下一个未被排除的下标；全部被排除返回 -1。</summary>
    Private Function NextNonExcludedIndex(fromIndex As Integer, direction As Integer) As Integer
        If fileList.Count = 0 Then Return -1
        Dim n As Integer = fileList.Count
        For k As Integer = 1 To n
            Dim cand As Integer = ((fromIndex + direction * k) Mod n + n) Mod n
            If Not excludedIndices.Contains(cand) Then Return cand
        Next
        Return -1
    End Function

    ''' <summary>fileList 下标在“未排除清单”中的位置（0 基）；被排除返回 -1。</summary>
    Private Function ActivePositionOf(fileIdx As Integer) As Integer
        If fileIdx < 0 OrElse fileIdx >= fileList.Count Then Return -1
        If excludedIndices.Contains(fileIdx) Then Return -1
        Dim pos As Integer = 0
        For i As Integer = 0 To fileIdx - 1
            If Not excludedIndices.Contains(i) Then pos += 1
        Next
        Return pos
    End Function

    ''' <summary>未排除条目总数。</summary>
    Private Function ActiveCount() As Integer
        Return fileList.Count - excludedIndices.Count
    End Function

#End Region


    '''Change to a standard Right view.
    Private Sub btn_right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_right.Click
        AxEModelViewControl2.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationRight
    End Sub
    '''Change to a standard Front view.
    Private Sub btn_front_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_front.Click
        AxEModelViewControl2.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationFront
    End Sub
    '''Change to a standard Left view.
    Private Sub btn_left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_left.Click
        AxEModelViewControl2.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationLeft
    End Sub
    '''Change to a standard Top view.
    Private Sub btn_top_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_top.Click
        AxEModelViewControl2.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationTop
    End Sub
    '''Change to a standard Bottom view.
    Private Sub btn_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.Click
        AxEModelViewControl2.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationBack
    End Sub
    '''Change to a standard Bottom view.
    Private Sub btn_bottom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bottom.Click
        AxEModelViewControl2.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationBottom
    End Sub
    Private Sub btn_Home_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Home.Click
        AxEModelViewControl2.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationHome
    End Sub

    Private Sub btn_file_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_file.Click
        Me.OpenFileDialog1.ShowDialog()
        Dim sFilename As String
        sFilename = Me.OpenFileDialog1.FileName

        If sFilename <> "" Then
            Me.btn_back.Enabled = True
            Me.btn_front.Enabled = True
            Me.btn_top.Enabled = True
            Me.btn_left.Enabled = True
            Me.btn_right.Enabled = True
            Me.btn_bottom.Enabled = True
            Me.btn_Home.Enabled = True
            Me.btn_measure.Enabled = True
            Me.Btn_filelist_previous.Enabled = True
            Me.Btn_filelist_next.Enabled = True
            Me.Btn_Open_File.Enabled = True
            Me.btn_filelist.Enabled = True
            ProcessSelectedFile(sFilename)
        End If
    End Sub

    ' 上一文件按钮：仅更新“目标下标”，真正加载由 BeginLoad/加载完成回调合并处理
    Private Sub Btn_filelist_previous_Click(sender As Object, e As EventArgs) Handles Btn_filelist_previous.Click
        Navigate(-1)
    End Sub

    ' 下一文件按钮
    Private Sub Btn_filelist_next_Click(sender As Object, e As EventArgs) Handles Btn_filelist_next.Click
        Navigate(1)
    End Sub

    Private Sub Btn_file_open_sw(sender As Object, e As EventArgs) Handles Btn_Open_File.Click
        If currentIndex < 0 OrElse currentIndex >= fileList.Count Then Return

        Try
            Dim currentFile As String = fileList(currentIndex)

            ' 使用系统默认程序打开文件
            Process.Start(currentFile)

        Catch ex As Exception
            MessageBox.Show($"无法用 SolidWorks 打开文件: {ex.Message}")

        End Try

    End Sub

    Private fileList As New List(Of String)()
    Private currentIndex As Integer = -1
    ' 加载合并（防连点逐帧全加载）：
    '   _targetIndex = 用户最近一次“想看”的模型下标；_isLoading = 当前是否正在加载。
    '   连点时只更新 _targetIndex；当前加载完成后若 _targetIndex 与已加载的不同，
    '   自动跳到最终目标，避免把中间每个模型都加载一遍。
    Private _targetIndex As Integer = -1
    Private _isLoading As Boolean = False

    ' 文档加载完成后，延迟一小段时间再收纳左侧面板的定时器。
    ' 不能在 LoadCurrentFile 里“立刻”收，因为 OpenDoc 是异步的：
    ' 加载完成前面板还停留在上一文件的收起态，提前判断会误判为“已收起”而漏点；
    ' 真正加载完后 eDrawings 会把面板重新展开，那时再收才准确。
    Private collapseTimer As System.Windows.Forms.Timer = Nothing
    ' 自动收纳左侧面板的“时间窗口”：在 LoadCurrentFile（切换文件）或文档加载完成事件触发后，
    ' 启动一个轮询定时器，在窗口期内反复检测并收纳面板，直到面板收纳或窗口超时。
    ' 这样既不依赖 eDrawings 是否在“切换文档”时触发 OnFinishedLoadingDocument（某些版本不触发），
    ' 也不会在“上一文档仍是收起态”的瞬间误判为已收纳而漏点。
    Private collapseDeadline As DateTime = DateTime.MinValue

    ' 跟踪左右两个视图是否已“加载完成”：收纳点击必须等两者都加载完，
    ' 避免在模型/图纸尚在加载中就被点击（点得太快时会出错/点错位置）。
    Private _leftLoaded As Boolean = False
    Private _rightLoaded As Boolean = False
    Private _currentDrawingFile As String = ""
    ' 加载等待看门狗：最多等 LOAD_WAIT_SECONDS 秒；超时也强制启动收纳（兜底，防事件不发）
    Private _loadWaitDeadline As DateTime = DateTime.MinValue
    Private loadWatchdog As System.Windows.Forms.Timer = Nothing
    Private Const LOAD_WAIT_SECONDS As Integer = 4

    ' 与左侧模型视图 / 右侧工程图视图关联的 Markup 控件，用于激活测量功能
    Private m_emv As EModelViewMarkup.IEModelMarkupControl
    Private m_emvDraw As EModelViewMarkup.IEModelMarkupControl

    ' GDI 句柄泄漏自我保护：eDrawings ActiveX 在每次 OpenDoc/CloseActiveDoc 都会泄漏 GDI 句柄，
    ' 攒到接近系统配额（约 10000）时任意 GDI+ 调用都会抛“内存不足”。
    ' 这里在阈值（留余量）提前重启进程（进程退出即释放全部 GDI 句柄）；超过上限次数则不再自动重启以防死循环。
    Private Const GDI_RESTART_THRESHOLD As Integer = 8000
    Private Const GDI_MAX_RESTARTS As Integer = 5
    Private _restartFilePath As String = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "eDrawingsChecker_restart.txt")

    Private Sub ProcessSelectedFile(selectedFile As String)

        ' 扫描目录并加载文件
        Try
            ' 获取目录路径
            Dim dirPath As String = Path.GetDirectoryName(selectedFile)

            ' ✅ 正确写法：使用 Directory.GetFiles
            Dim prtFiles As String() = Directory.GetFiles(dirPath, "*.sldprt").Where(Function(f) IsValidFile(f)).ToArray()
            Dim asmFiles As String() = Directory.GetFiles(dirPath, "*.sldasm").Where(Function(f) IsValidFile(f)).ToArray()

            ' 合并并排序文件列表
            fileList.Clear()
            fileList.AddRange(prtFiles)
            fileList.AddRange(asmFiles)
            fileList.Sort() ' 按文件名排序

            ' 定位当前文件索引
            currentIndex = fileList.IndexOf(selectedFile)
            If currentIndex = -1 Then currentIndex = 0 ' 如果文件不在列表中，从第一个开始

            BeginLoad(currentIndex)
            UpdatePositionLabel()
            PopulateFileList()

        Catch ex As Exception
            MessageBox.Show($"操作失败: {ex.Message}")
        End Try
    End Sub

    Private Function IsValidFile(filePath As String) As Boolean
        Try
            ' 排除临时文件（SolidWorks临时文件通常以~$开头）
            If Path.GetFileName(filePath).StartsWith("~$") Then
                Return False
            End If

            ' 排除隐藏文件
            If (File.GetAttributes(filePath) And FileAttributes.Hidden) = FileAttributes.Hidden Then
                Return False
            End If

            Return True
        Catch
            ' 如果无法访问文件属性，视为无效文件
            Return False
        End Try
    End Function


    Private Sub LoadCurrentFile()
        If currentIndex < 0 OrElse currentIndex >= fileList.Count Then Return
        _isLoading = True
        Try
            ' 自我保护：eDrawings 每次开/关文档都会泄漏 GDI 句柄，攒到接近系统配额时
            ' 任意 GDI+ 调用都会抛“内存不足”。动手前先检测，过高则记住当前位置并重启进程
            '（进程退出会释放全部 GDI 句柄，这是应对 ActiveX GDI 泄漏最可靠的手段）。
            Dim gdi As Integer = GdiObjectCount()
            LogHook("切换前 GDI 句柄=" & gdi)
            If gdi > GDI_RESTART_THRESHOLD Then
                Dim restarts As Integer = ReadRestartCount()
                If restarts < GDI_MAX_RESTARTS Then
                    LogHook("GDI 句柄过高(" & gdi & ")，触发自我保护重启（第" & (restarts + 1) & "次）")
                    SaveRestartContext(restarts + 1)
                    Application.Restart()
                    Return
                Else
                    LogHook("GDI 句柄过高但已达重启上限，跳过自动重启")
                End If
            End If

            AxEModelViewControl2.CloseActiveDoc("")
            AxEModelViewControl1.CloseActiveDoc("")
            ' 关键：eDrawings 是非托管 ActiveX，模型/图纸数据占用的是【非托管内存】，
            ' 而 .NET 只持有极小的 RCW 包装对象 → GC 感知不到压力、不会自动回收。
            ' 若不在这里强制回收，连续切换模型会把历史模型的内存一路累积，最终“内存不足”。
            ReleaseEDrawingsMemory()
            Me.Text = "eDrawings Checker"

            ' 打开模型/图纸时同步显示两个视图控件（与启动时的同步隐藏对应）
            AxEModelViewControl2.Visible = True
            AxEModelViewControl1.Visible = True

            ' 新一轮切换：停止上一轮可能仍在运行的收纳轮询，避免加载中误点（“点得太快”出错）
            If collapseTimer IsNot Nothing Then collapseTimer.Stop()

            Dim currentFile As String = fileList(currentIndex)
            Dim drawingFile As String = Check_Slddrw_File(currentFile)
            _currentDrawingFile = drawingFile
            ' 重置“已加载”状态：右侧若无图纸文件，则视为已就绪（无需等待）
            _leftLoaded = False
            _rightLoaded = String.IsNullOrEmpty(drawingFile)
            AxEModelViewControl2.OpenDoc(currentFile, 0, 0, 1, "")
            If Not String.IsNullOrEmpty(drawingFile) Then
                AxEModelViewControl1.OpenDoc(drawingFile, 0, 0, 1, "")
            End If

            ' 等左、右两个视图都加载完成后再收纳：由各自的 OnFinishedLoadingDocument 触发，
            ' 并以看门狗超时兜底（防止个别 eDrawings 版本不触发该事件时永远不收纳）。
            StartLoadWatchdog()
        Catch ex As Exception
            _isLoading = False
            MessageBox.Show($"无法打开文件: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' 释放 eDrawings 关闭文档后遗留的非托管内存。
    ''' 背景：eDrawings 以 ActiveX 方式承载模型/图纸，其数据全部在非托管堆上；.NET 侧只有很小的
    ''' RCW（Runtime Callable Wrapper），因此 GC 感受不到内存压力、不会主动回收，
    ''' 结果是每切换一个模型就把上一个模型的内存继续攒着，最终抛 OutOfMemoryException。
    ''' 在 CloseActiveDoc 之后强制执行一次完整回收，才能真正释放上一个模型的内存。
    ''' </summary>
    Private Sub ReleaseEDrawingsMemory()
        Try
            Dim before As Long = 0
            Dim after As Long = 0
            ' 用 Using 包住，避免 Process 对象自身泄漏句柄
            Using p As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
                before = p.WorkingSet64
            End Using

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()

            Using p As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
                after = p.WorkingSet64
            End Using
            LogHook(String.Format("内存回收：{0}MB → {1}MB，GDI 句柄={2}",
                                  before \ 1048576L, after \ 1048576L, GdiObjectCount()))
        Catch
            ' 回收失败不应影响打开文档的主流程
        End Try
    End Sub

    ''' <summary>获取当前进程的 GDI 对象（句柄）数；用于检测 eDrawings ActiveX 的 GDI 泄漏。</summary>
    Private Function GdiObjectCount() As Integer
        Try
            Using p As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
                Return CInt(GetGuiResources(p.Handle, 0UI))
            End Using
        Catch
            Return 0
        End Try
    End Function

    ''' <summary>读取上次自我保护重启时已累计的重启次数（用于防止对单个大文件反复重启死循环）。</summary>
    Private Function ReadRestartCount() As Integer
        Try
            If Not System.IO.File.Exists(_restartFilePath) Then Return 0
            Dim lines() As String = System.IO.File.ReadAllLines(_restartFilePath)
            If lines.Length >= 2 Then
                Dim n As Integer
                If Integer.TryParse(lines(1).Trim(), n) Then Return n
            End If
        Catch
        End Try
        Return 0
    End Function

    ''' <summary>把当前打开的文件路径与累计重启次数写入标记文件，供重启后自动恢复到原位置。</summary>
    Private Sub SaveRestartContext(count As Integer)
        Try
            Dim path As String = If(currentIndex >= 0 AndAlso currentIndex < fileList.Count,
                                   fileList(currentIndex), String.Empty)
            System.IO.File.WriteAllText(_restartFilePath, path & vbNewLine & count.ToString())
        Catch
        End Try
    End Sub

    ''' <summary>若上次因 GDI 句柄过高而自我保护重启，这里自动恢复到原文件位置（读取后即删除标记文件）。</summary>
    Private Sub TryRestoreFromRestartFile()
        Try
            If Not System.IO.File.Exists(_restartFilePath) Then Return
            Dim lines() As String = System.IO.File.ReadAllLines(_restartFilePath)
            System.IO.File.Delete(_restartFilePath)
            If lines.Length < 1 Then Return
            Dim path As String = lines(0).Trim()
            If String.IsNullOrEmpty(path) OrElse Not System.IO.File.Exists(path) Then Return
            ProcessSelectedFile(path)
        Catch
        End Try
    End Sub

    Private Sub UpdatePositionLabel(Optional ByVal idx As Integer = -1)
        Dim show As Integer = If(idx >= 0, idx, currentIndex)
        ' 显示值基于“未排除清单”：位置=在未排除清单中的序号，总数=未排除条目数
        Dim pos As Integer = ActivePositionOf(show) + 1
        Dim total As Integer = ActiveCount()
        If pos <= 0 Then 
		lblPosition.Text = $"--/{total}"
	Else
        	lblPosition.Text = $"{pos}/{total}"
	End If

        ' 在标题栏中显示文件名
        If fileList.Count > 0 AndAlso show >= 0 AndAlso show < fileList.Count Then
            Me.Text = "eDrawings Checker ------ " & Path.GetFileName(fileList(show))
        End If
    End Sub

    ''' <summary>
    ''' 切换上/下一个模型（delta = -1 或 +1）。
    ''' 不立即加载每个点击：只把“目标下标”向前推进；若当前没有加载进行中，则立即加载该目标；
    ''' 若正在加载，则仅记录最新目标，等当前加载完成（OnLoadSettled）后再跳到最终目标，
    ''' 从而连点时不会把中间每个模型都加载一遍。
    ''' </summary>
    Private Sub Navigate(delta As Integer)
        If fileList.Count = 0 Then Return
        ' 正在加载时，相对“上次目标”继续推进；空闲时相对“当前已显示”推进
        Dim base As Integer = If(_isLoading, _targetIndex, currentIndex)
        ' 跳过被 File List 排除的下标；若全部被排除则不跳转
        Dim nxt As Integer = NextNonExcludedIndex(base, If(delta > 0, 1, -1))
        If nxt < 0 Then Return
        _targetIndex = nxt
        UpdatePositionLabel(_targetIndex)   ' 立即反馈“将要跳到哪”
        If Not _isLoading Then
            BeginLoad(_targetIndex)
        End If
    End Sub

    ''' <summary>真正发起一次加载：记录目标、标记加载中、调用 LoadCurrentFile。</summary>
    Private Sub BeginLoad(idx As Integer)
        If idx < 0 OrElse idx >= fileList.Count Then Return
        currentIndex = idx
        _targetIndex = idx
        LoadCurrentFile()
    End Sub

    ''' <summary>把任意整数下标按文件列表长度循环（支持 Previous/Next 到头/尾回卷）。</summary>
    Private Function WrapIndex(n As Integer) As Integer
        If fileList.Count = 0 Then Return -1
        Return ((n Mod fileList.Count) + fileList.Count) Mod fileList.Count
    End Function

    Public Function Check_Slddrw_File(ByVal sFilename As String) As String
        If String.IsNullOrEmpty(sFilename) Then
            Return String.Empty
        End If

        Try
            Dim fileDir As String = Path.GetDirectoryName(sFilename)
            ' 处理根目录（例如 sFilename 是 "C:\"）
            If String.IsNullOrEmpty(fileDir) Then
                fileDir = Path.GetPathRoot(sFilename)
                If Not Directory.Exists(fileDir) Then
                    Return String.Empty
                End If
            ElseIf Not Directory.Exists(fileDir) Then
                Return String.Empty
            End If

            Dim fileNameNoExt As String = Path.GetFileNameWithoutExtension(sFilename)
            Dim targetFileName As String = fileNameNoExt & ".SLDDRW"

            ' 使用 EnumerateFiles 更高效地遍历文件
            For Each zFilename As String In Directory.EnumerateFiles(fileDir)
                Dim currentFile As String = Path.GetFileName(zFilename)
                If String.Equals(currentFile, targetFileName, StringComparison.OrdinalIgnoreCase) Then
                    Return zFilename
                End If
            Next

            Return String.Empty
        Catch ex As Exception
            ' 可选：记录异常日志（例如 Debug.WriteLine(ex.Message)）
            Return String.Empty
        End Try
    End Function

    ' ===== 测量功能（左右两个窗口均有效）=====

    '''模型文档加载完成后：激活左侧模型窗口的鼠标选择方式，并触发自动收纳左侧面板
    Private Sub AxEModelViewControl2_OnFinishedLoadingDocument(sender As Object, e As AxEModelView._IEModelViewControlEvents_OnFinishedLoadingDocumentEvent) Handles AxEModelViewControl2.OnFinishedLoadingDocument
        ' eDrawings 在【后台线程】回调此事件（实测）。若直接在这里访问控件/句柄，
        ' 会抛 InvalidOperationException: IllegalCrossThreadCall（跨线程访问控件）。
        ' 因此先判断是否需要切回 UI 线程，需要则 BeginInvoke 回 UI 线程再执行。
        If Me.InvokeRequired Then
            Me.BeginInvoke(New Action(Of Object, AxEModelView._IEModelViewControlEvents_OnFinishedLoadingDocumentEvent)(
                AddressOf AxEModelViewControl2_OnFinishedLoadingDocument), sender, e)
            Return
        End If

        AxEModelViewControl2.ViewOperator = EModelView.EMVOperators.eMVOperatorSelect

        ' 左侧模型视图加载完成：标记就绪；若右侧也已就绪则立即开始收纳
        _leftLoaded = True
        MaybeStartCollapse()
    End Sub

    '''右侧工程图视图文档加载完成后：标记已就绪，若左侧也已就绪则立即开始收纳
    Private Sub AxEModelViewControl1_OnFinishedLoadingDocument(sender As Object, e As AxEModelView._IEModelViewControlEvents_OnFinishedLoadingDocumentEvent) Handles AxEModelViewControl1.OnFinishedLoadingDocument
        If Me.InvokeRequired Then
            Me.BeginInvoke(New Action(Of Object, AxEModelView._IEModelViewControlEvents_OnFinishedLoadingDocumentEvent)(
                AddressOf AxEModelViewControl1_OnFinishedLoadingDocument), sender, e)
            Return
        End If
        _rightLoaded = True
        MaybeStartCollapse()
    End Sub

    '''启动“自动收纳左侧面板”的轮询窗口：重置候选点游标、刷新时间窗口并启动定时器。
    ''' 由 LoadCurrentFile（切换文件）与 OnFinishedLoadingDocument（加载完成）两处调用，
    ''' 任一触发都有效，并会互相刷新窗口，确保最终面板被收纳。
    Private Sub ScheduleAutoCollapse()
        If collapseTimer Is Nothing Then Return
        ' 新一轮收纳：重置候选点游标（按用户实测精确点 {X=左缘+10/+20, Y=底-50/-100} 依次尝试）
        EDrawingsSectionInvoker.BeginCollapseSession()
        collapseDeadline = DateTime.Now.AddSeconds(2.5)
        collapseTimer.Stop()
        collapseTimer.Start()
        LogHook("[AutoCollapse] 启动轮询窗口（2.5s）")
    End Sub

    ''' <summary>
    ''' 一次加载“落定”时调用（两个视图都加载完，或看门狗超时兜底）。
    ''' 标记加载结束、停看门狗；若加载期间用户又点了别的模型（_targetIndex≠已加载下标），
    ''' 自动跳到最终目标（合并连点，不逐帧加载中间模型）；否则确认当前模型并收纳面板。
    ''' </summary>
    Private Sub OnLoadSettled()
        If Not _isLoading Then Return
        _isLoading = False
        If loadWatchdog IsNot Nothing Then loadWatchdog.Stop()
        ScheduleAutoCollapse()
        If _targetIndex >= 0 AndAlso _targetIndex <> currentIndex Then
            UpdatePositionLabel(_targetIndex)   ' 立即反馈：将跳到最终目标
            BeginLoad(_targetIndex)             ' 跳到最终目标，避免把中间模型都加载一遍
        Else
            UpdatePositionLabel()               ' 确认当前已加载的模型
        End If
    End Sub

    Private Sub MaybeStartCollapse()
        If _leftLoaded AndAlso _rightLoaded Then
            OnLoadSettled()
        End If
    End Sub

    ''' <summary>
    ''' 启动“等两个视图都加载完再收纳”的看门狗定时器。
    ''' 文档加载完成事件会提前触发收纳；这里设超时兜底，防止个别 eDrawings 版本
    ''' 不触发 OnFinishedLoadingDocument 时永远不收纳。
    ''' </summary>
    Private Sub StartLoadWatchdog()
        _loadWaitDeadline = DateTime.Now.AddSeconds(LOAD_WAIT_SECONDS)
        If loadWatchdog Is Nothing Then
            loadWatchdog = New System.Windows.Forms.Timer()
            loadWatchdog.Interval = 200
            AddHandler loadWatchdog.Tick, AddressOf LoadWatchdog_Tick
        End If
        loadWatchdog.Stop()
        loadWatchdog.Start()
    End Sub

    ''' <summary>看门狗每拍检查：左、右都加载完 → 立即收纳；超时也强制收纳（兜底）。</summary>
    Private Sub LoadWatchdog_Tick(sender As Object, e As EventArgs)
        If loadWatchdog Is Nothing Then Return
        If (_leftLoaded AndAlso _rightLoaded) OrElse DateTime.Now >= _loadWaitDeadline Then
            OnLoadSettled()
        End If
    End Sub

    '''定时器每拍（150ms）调用一次：检测并收纳【左侧模型视图】与【右侧工程图视图】两个面板。
    ''' 单次只点一个点，不阻塞 UI 线程；左、右都收起或窗口超时即停止轮询。
    Private Sub CollapseTimer_Tick(sender As Object, e As EventArgs)
        If collapseTimer Is Nothing Then Return
        Dim leftStatus As String = EDrawingsSectionInvoker.EnsureLeftPanelCollapsed(AxEModelViewControl2.Handle)
        Dim rightStatus As String = EDrawingsSectionInvoker.EnsureLeftPanelCollapsed(AxEModelViewControl1.Handle)
        LogHook("[AutoCollapse] 左=" & leftStatus & " 右=" & rightStatus)
        ' 左侧已收纳，且右侧已收纳（或右侧无面板可收）即视为完成
        Dim rightDone As Boolean = (rightStatus = "已收纳" OrElse rightStatus = "未找到面板")
        If leftStatus = "已收纳" AndAlso rightDone Then
            collapseTimer.Stop()
            LogHook("[AutoCollapse] 左右均已收纳，停止轮询")
        ElseIf DateTime.Now >= collapseDeadline Then
            collapseTimer.Stop()
            LogHook("[AutoCollapse] 窗口结束仍未收纳，停止轮询")
        End If
        ' 其余情况：定时器保持运行，150ms 后自动再试下一个候选点
    End Sub

    '''窗体加载：创建与左右两个视图关联的 Markup 控件（用于测量功能，需 eDrawings Professional 许可），并安装中键双击鼠标钩子
    Private Sub eDrawingsChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 创建“加载完成后轮询收纳左/右面板”的定时器（150ms 一拍，2.5s 窗口内反复检测/收纳）
        collapseTimer = New System.Windows.Forms.Timer()
        collapseTimer.Interval = 150
        AddHandler collapseTimer.Tick, AddressOf CollapseTimer_Tick

        m_emv = AxEModelViewControl2.CoCreateInstance("EModelViewMarkup.EModelMarkupControl")
        m_emvDraw = AxEModelViewControl1.CoCreateInstance("EModelViewMarkup.EModelMarkupControl")

        ' 启动时（未打开模型/图纸前）隐藏两个视图控件，二者同步操作
        AxEModelViewControl2.Visible = False
        AxEModelViewControl1.Visible = False

        ' 安装低级鼠标钩子（WH_MOUSE_LL），检测左右视图上的中键双击
        _mouseHookProc = New LowLevelMouseProc(AddressOf MouseHookProc)
        _mouseHook = SetWindowsHookEx(WH_MOUSE_LL, _mouseHookProc, GetModuleHandle(Nothing), 0)
        LogHook("hook installed ok=" & (_mouseHook <> IntPtr.Zero))

        ' 若上次因 GDI 句柄过高而自我保护重启，这里自动恢复到原文件位置（用户无感）
        TryRestoreFromRestartFile()
    End Sub

    Private Sub eDrawingsChecker_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        LogHook("hook removed")
        If _mouseHook <> IntPtr.Zero Then
            UnhookWindowsHookEx(_mouseHook)
            _mouseHook = IntPtr.Zero
        End If
    End Sub

    '''激活左右两个视图的测量模式（需 eDrawings Professional 许可，按 Esc 退出测量）
    Private Sub btn_measure_Click(sender As Object, e As EventArgs) Handles btn_measure.Click
        If m_emv Is Nothing Then
            m_emv = AxEModelViewControl2.CoCreateInstance("EModelViewMarkup.EModelMarkupControl")
        End If
        If m_emvDraw Is Nothing Then
            m_emvDraw = AxEModelViewControl1.CoCreateInstance("EModelViewMarkup.EModelMarkupControl")
        End If

        If (m_emv Is Nothing OrElse Not m_emv.IsMeasureEnabled) OrElse
           (m_emvDraw Is Nothing OrElse Not m_emvDraw.IsMeasureEnabled) Then
            MessageBox.Show("测量功能不可用：需要 eDrawings Professional 许可证。")
            Return
        End If

        m_emv.ViewOperator = EModelViewMarkup.EMVMarkupOperators.eMVOperatorMeasure
        m_emvDraw.ViewOperator = EModelViewMarkup.EMVMarkupOperators.eMVOperatorMeasure
    End Sub

    ' ===== 鼠标中键双击 → Zoom to Fit（同 SolidWorks，左右两个窗口均生效）=====

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function GetParent(hWnd As IntPtr) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function WindowFromPoint(Point As Point) As IntPtr
    End Function

    ' 获取进程当前 GDI 对象（句柄）数，用于检测 eDrawings ActiveX 的 GDI 泄漏（0 = GDI 对象）
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function GetGuiResources(hProcess As IntPtr, uiFlags As UInteger) As UInteger
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetFocus(hWnd As IntPtr) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SendInput(nInputs As UInteger, pInputs As INPUT(), cbSize As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)>
    Private Structure MOUSEINPUT
        Public dx As Integer
        Public dy As Integer
        Public mouseData As Integer
        Public dwFlags As UInteger
        Public time As UInteger
        Public dwExtraInfo As IntPtr
    End Structure

    ' INPUT 的联合体部分在 x64 下按 8 字节对齐，mi 位于偏移 8
    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)>
    Private Structure INPUT
        <System.Runtime.InteropServices.FieldOffset(0)> Public type As Integer
        <System.Runtime.InteropServices.FieldOffset(8)> Public mi As MOUSEINPUT
    End Structure

    Private Const INPUT_MOUSE As Integer = 0
    Private Const MOUSEEVENTF_WHEEL As UInteger = &H800UI

    Private Delegate Function LowLevelMouseProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr

    <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(idHook As Integer, lpfn As LowLevelMouseProc, hMod As IntPtr, dwThreadId As UInteger) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function UnhookWindowsHookEx(hhk As IntPtr) As Boolean
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function CallNextHookEx(hhk As IntPtr, nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet:=System.Runtime.InteropServices.CharSet.Unicode)>
    Private Shared Function GetModuleHandle(lpModuleName As String) As IntPtr
    End Function

    <System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)>
    Private Structure MSLLHOOKSTRUCT
        Public pt As Point
        Public mouseData As UInteger
        Public flags As UInteger
        Public time As UInteger
        Public dwExtraInfo As IntPtr
    End Structure

    Private Const WH_MOUSE_LL As Integer = 14
    Private Const WM_MBUTTONDOWN As Integer = &H207
    Private Const WM_MOUSEWHEEL As Integer = &H20A
    Private Const LLMHF_INJECTED As UInteger = 1

    Private _mouseHook As IntPtr
    Private _mouseHookProc As LowLevelMouseProc
    Private _lastDownTarget As AxEModelView.AxEModelViewControl
    Private _lastDownTick As Integer
    Private _lastDownPos As Point
    Private _pendingWheelDelta As Integer
    Private _wheelDeliverPending As Boolean
    Private _lastInjectTick As Integer

    ' 日志输出功能已移除：LogHook 现为空操作，所有调用点不再产生任何日志文件。
    Private Sub LogHook(msg As String)
    End Sub

    '''根据窗口句柄判断其属于左侧还是右侧 eDrawings 视图（沿父窗口链向上查找）
    Friend Function FindEModelViewByHandle(hwnd As IntPtr) As AxEModelView.AxEModelViewControl
        Dim h As IntPtr = hwnd
        While h <> IntPtr.Zero
            If h = AxEModelViewControl2.Handle Then Return AxEModelViewControl2
            If h = AxEModelViewControl1.Handle Then Return AxEModelViewControl1
            If h = Me.Handle Then Return Nothing
            h = GetParent(h)
        End While
        Return Nothing
    End Function

    '''低级鼠标钩子回调：检测左右视图区域内的中键双击，并将滚轮事件直接投递给 eDrawings 渲染子窗口
    Private Function MouseHookProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
        Try
            If nCode >= 0 Then
                Dim msg As Integer = wParam.ToInt32()
                If msg = WM_MBUTTONDOWN Then
                    Dim info As MSLLHOOKSTRUCT = System.Runtime.InteropServices.Marshal.PtrToStructure(lParam, GetType(MSLLHOOKSTRUCT))
                    If (info.flags And LLMHF_INJECTED) = 0 Then
                        Dim pos As New Point(info.pt.X, info.pt.Y)
                        Dim target As AxEModelView.AxEModelViewControl = FindEModelViewByHandle(WindowFromPoint(pos))
                        If target IsNot Nothing Then
                            Dim nowTick As Integer = Environment.TickCount
                            Dim isDbl As Boolean = target Is _lastDownTarget AndAlso
                                (nowTick - _lastDownTick) <= SystemInformation.DoubleClickTime AndAlso
                                Math.Abs(pos.X - _lastDownPos.X) <= SystemInformation.DoubleClickSize.Width AndAlso
                                Math.Abs(pos.Y - _lastDownPos.Y) <= SystemInformation.DoubleClickSize.Height
                            LogHook(String.Format("MBDOWN dbl={0} dt={1} dx={2} dy={3}", isDbl, nowTick - _lastDownTick, Math.Abs(pos.X - _lastDownPos.X), Math.Abs(pos.Y - _lastDownPos.Y)))
                            _lastDownTarget = target
                            _lastDownTick = nowTick
                            _lastDownPos = pos
                            If isDbl Then
                                _lastDownTarget = Nothing
                                LogHook("ZOOMTOFIT queued")
                                Me.BeginInvoke(New Action(Sub() ZoomToFit(target)))
                            End If
                        Else
                            _lastDownTarget = Nothing
                        End If
                    End If
                ElseIf msg = WM_MOUSEWHEEL Then
                    Dim info As MSLLHOOKSTRUCT = System.Runtime.InteropServices.Marshal.PtrToStructure(lParam, GetType(MSLLHOOKSTRUCT))
                    If (info.flags And LLMHF_INJECTED) = 0 Then
                        Dim pos As New Point(info.pt.X, info.pt.Y)
                        Dim hwndUnder As IntPtr = WindowFromPoint(pos)
                        If FindEModelViewByHandle(hwndUnder) IsNot Nothing Then
                            ' 注意：MSLLHOOKSTRUCT.mouseData 的滚轮增量在高 16 位（与 WM_MOUSEWHEEL wParam 的打包一致）；
                            ' 之前误从低 16 位取值恒为 0，导致所有滚轮事件 delta=0（表现为无反应/只缩小）
                            Dim wheelDelta As Integer = CShort((info.mouseData >> 16) And &HFFFFUI)
                            LogHook(String.Format("WHEEL delta={0} flags=0x{1}", wheelDelta, info.flags.ToString("X")))
                            ' 实测 PostMessage 重建的 WM_MOUSEWHEEL 无论增量编码如何，方向都被控件当作缩小；
                            ' 改为吞掉原始事件后用 SendInput 注入同方向滚轮（进入真实输入管线，方向正确）
                            ' 回声保护：注入后 20ms 内若再收到未标记 INJECTED 的滚轮，视为注入回声，吞掉且不再注入
                            If _lastInjectTick <> 0 AndAlso Environment.TickCount - _lastInjectTick < 20 Then
                                LogHook("WHEEL echo dropped")
                                Return CType(1, IntPtr)
                            End If
                            _pendingWheelDelta = wheelDelta
                            If Not _wheelDeliverPending Then
                                _wheelDeliverPending = True
                                Me.BeginInvoke(New Action(AddressOf DeliverWheelToView))
                            End If
                            Return CType(1, IntPtr) ' 吞掉原事件
                        End If
                    End If
                End If
            End If
        Catch
            ' 钩子回调内不得抛出异常
        End Try
        Return CallNextHookEx(_mouseHook, nCode, wParam, lParam)
    End Function

    '''把焦点设到光标下视图并注入同方向滚轮事件（进入真实输入管线，由 eDrawings 原生处理，缩放方向正确）
    Private Sub DeliverWheelToView()
        Dim delta As Integer = _pendingWheelDelta
        _pendingWheelDelta = 0
        _wheelDeliverPending = False
        If delta = 0 Then Return
        Try
            Dim hwndUnder As IntPtr = WindowFromPoint(Cursor.Position)
            Dim ctrl As AxEModelView.AxEModelViewControl = FindEModelViewByHandle(hwndUnder)
            If ctrl Is Nothing Then
                LogHook("DELIVER skip: cursor left view")
                Return ' 光标已移出视图，丢弃本次滚轮
            End If
            Dim focusOk As Boolean = SetFocus(hwndUnder) <> IntPtr.Zero
            If Not focusOk Then focusOk = SetFocus(ctrl.Handle) <> IntPtr.Zero
            Dim inp As New INPUT With {.type = INPUT_MOUSE}
            inp.mi = New MOUSEINPUT With {.mouseData = delta, .dwFlags = MOUSEEVENTF_WHEEL}
            _lastInjectTick = Environment.TickCount
            Dim sent As Integer = SendInput(1, New INPUT() {inp}, System.Runtime.InteropServices.Marshal.SizeOf(GetType(INPUT)))
            LogHook(String.Format("DELIVER hwnd=0x{0:X} focus={1} sent={2} delta={3}", hwndUnder.ToInt64(), focusOk, sent, delta))
        Catch ex As Exception
            LogHook("DELIVER ex: " & ex.Message)
        End Try
    End Sub

    '''中键双击整屏缩放（同 SolidWorks）：通过 eDrawings API 将视图缩放适应窗口（左右窗口均生效）
    Friend Sub ZoomToFit(target As AxEModelView.AxEModelViewControl)
        target.ViewOrientation = EModelView.EMVViewOrientation.eMVOrientationZoomToFit
    End Sub

End Class

