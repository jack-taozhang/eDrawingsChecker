Option Explicit On
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Linq


Public Class eDrawingsChecker
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
        Me.TableLayoutPanel3.Controls.Add(Me.btn_back, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_bottom, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_front, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_right, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_top, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_left, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_file, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btn_Home, 7, 0)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
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
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_filelist_next, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPosition, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_filelist_previous, 1, 0)
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
        Me.lblPosition.AutoSize = True
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
        Me.AxEModelViewControl2.Size = New System.Drawing.Size(740, 960)
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
        Me.Name = "eDrawings Checker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "eDrawings Checker"
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.AxEModelViewControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxEModelViewControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

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
            Me.Btn_filelist_previous.Enabled = True
            Me.Btn_filelist_next.Enabled = True
            Me.Btn_Open_File.Enabled = True
            ProcessSelectedFile(sFilename)
        End If
    End Sub

    ' 上一文件按钮
    Private Sub Btn_filelist_previous_Click(sender As Object, e As EventArgs) Handles Btn_filelist_previous.Click
        If fileList.Count = 0 Then Return

        currentIndex = If(currentIndex > 0, currentIndex - 1, fileList.Count - 1)
        LoadCurrentFile()
        UpdatePositionLabel()
    End Sub

    ' 下一文件按钮
    Private Sub Btn_filelist_next_Click(sender As Object, e As EventArgs) Handles Btn_filelist_next.Click
        If fileList.Count = 0 Then Return

        currentIndex = If(currentIndex < fileList.Count - 1, currentIndex + 1, 0)
        LoadCurrentFile()
        UpdatePositionLabel()
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

    ''Save as a supported file type (jpeg, tiff, exe, html, zip)
    Private Sub btn_SaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AxEModelViewControl1.Save("", True, "")
    End Sub

    Private fileList As New List(Of String)()
    Private currentIndex As Integer = -1

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

            LoadCurrentFile()
            UpdatePositionLabel()

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
        Try
            AxEModelViewControl2.CloseActiveDoc("")
            AxEModelViewControl1.CloseActiveDoc("")
            Me.Text = "eDrawings Checker"

            Dim currentFile As String = fileList(currentIndex)
            AxEModelViewControl2.OpenDoc(currentFile, 0, 0, 1, "")
            Dim drawingFile As String = Check_Slddrw_File(currentFile)
            If Not String.IsNullOrEmpty(drawingFile) Then
                AxEModelViewControl1.OpenDoc(drawingFile, 0, 0, 1, "")
            End If
        Catch ex As Exception
            MessageBox.Show($"无法打开文件: {ex.Message}")
        End Try
    End Sub

    Private Sub UpdatePositionLabel()
        lblPosition.Text = $"{currentIndex + 1}/{fileList.Count}"

        ' 在标题栏中显示文件名
        If fileList.Count > 0 Then
            Me.Text = "eDrawings Checker ------ " & Path.GetFileName(fileList(currentIndex))
        End If
    End Sub

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
        End
    End Function

End Class

