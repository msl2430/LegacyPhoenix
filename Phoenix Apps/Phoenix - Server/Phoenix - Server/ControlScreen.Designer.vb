<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Application", 7, 7)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Log", 6, 6)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cases", 8, 8)
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 5, 5)
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Options", 9, 9)
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("IMPS", 1, 1, New System.Windows.Forms.TreeNode() {TreeNode21, TreeNode22, TreeNode23, TreeNode24, TreeNode25})
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Application", 7, 7)
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Log", 6, 6)
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cases", 8, 8)
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 5, 5)
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Options", 9, 9)
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Medicaid", 1, 1, New System.Windows.Forms.TreeNode() {TreeNode27, TreeNode28, TreeNode29, TreeNode30, TreeNode31})
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Settings", 7, 7)
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("GUMP Update", 1, 1, New System.Windows.Forms.TreeNode() {TreeNode33})
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Users", 10, 10)
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cases", 8, 8)
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reports", 5, 5)
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("FAMIS", 3, 3, New System.Windows.Forms.TreeNode() {TreeNode35, TreeNode36, TreeNode37})
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Client Data", 3, 3)
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Phoenix", 4, 4, New System.Windows.Forms.TreeNode() {TreeNode26, TreeNode32, TreeNode34, TreeNode38, TreeNode39})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlScreen))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MainPanel = New System.Windows.Forms.SplitContainer
        Me.treeMenu = New System.Windows.Forms.TreeView
        Me.treeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ControlPanel = New System.Windows.Forms.SplitContainer
        Me.DateChoice = New System.Windows.Forms.DateTimePicker
        Me.stripMenu = New System.Windows.Forms.ToolStrip
        Me.tool_Run = New System.Windows.Forms.ToolStripButton
        Me.tool_Stop = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tool_Print = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tool_Submit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.cmb_LogFiles = New System.Windows.Forms.ToolStripComboBox
        Me.panel_Main = New System.Windows.Forms.Panel
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.txt_ClientTime = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txt_ClientCases = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.ClientProgress = New System.Windows.Forms.ProgressBar
        Me.btn_ClientData = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txt_UpdateTime = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_UpdateCases = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.UpdateProgress = New System.Windows.Forms.ProgressBar
        Me.lbl_VersionNumber = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.txt_MedicaidHold = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.lbl_Server = New System.Windows.Forms.Label
        Me.txt_MedicaidFailed = New System.Windows.Forms.TextBox
        Me.txt_MedicaidSuccess = New System.Windows.Forms.TextBox
        Me.txt_MedicaidTotal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.txt_IMPSFailed = New System.Windows.Forms.TextBox
        Me.txt_IMPSSuccess = New System.Windows.Forms.TextBox
        Me.txt_IMPSTotal = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_MedicaidInfo = New System.Windows.Forms.RichTextBox
        Me.txt_ClientInfo = New System.Windows.Forms.TextBox
        Me.lbl_OptionError = New System.Windows.Forms.Label
        Me.grid_Users = New System.Windows.Forms.DataGridView
        Me.User = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CasesDone = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckInTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txt_MedicaidLog = New System.Windows.Forms.RichTextBox
        Me.panel_Reports = New System.Windows.Forms.Panel
        Me.btn_Redet = New System.Windows.Forms.Button
        Me.btn_Drop = New System.Windows.Forms.Button
        Me.btn_Success = New System.Windows.Forms.Button
        Me.btn_All = New System.Windows.Forms.Button
        Me.txt_IMPSInfo = New System.Windows.Forms.RichTextBox
        Me.txt_IMPSLog = New System.Windows.Forms.RichTextBox
        Me.grid_CaseView = New System.Windows.Forms.DataGridView
        Me.CaseNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TextFile = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CaseNumberDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ABDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ACDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AFDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AGDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AHDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AIDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AJDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AKDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AMDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ANDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DATEENTEREDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.P03DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.P05DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OPERATORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.P09DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BATCHNUMBERDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.P10DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WWDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FAMISCaseInformationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PhoenixCaseDataDataSet = New Phoenix___Server.PhoenixCaseDataDataSet
        Me.panel_IMPSOptions = New System.Windows.Forms.Panel
        Me.Label12 = New System.Windows.Forms.Label
        Me.txt_IMPSServer = New System.Windows.Forms.TextBox
        Me.lbl_Note2 = New System.Windows.Forms.Label
        Me.lbl_Note1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_IMPSBatchNumber = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_IMPSBatchPrefix = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_IMPSPassword = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txt_IMPSOperator = New System.Windows.Forms.TextBox
        Me.txt_IMPSDirectory = New System.Windows.Forms.TextBox
        Me.panel_MedicaidOptions = New System.Windows.Forms.Panel
        Me.Label19 = New System.Windows.Forms.Label
        Me.txt_MediDrop = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_MediPassword = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_MediOperator = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt_MediServer = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_MediDirectory = New System.Windows.Forms.TextBox
        Me.panel_GUMPUpdate = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_ForceGUMP = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_GUMPFileLocation = New System.Windows.Forms.TextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.BGW_BlinkSubmit = New System.ComponentModel.BackgroundWorker
        Me.BGW_IMPSProcessing = New System.ComponentModel.BackgroundWorker
        Me.BGW_IMPSScanDirectory = New System.ComponentModel.BackgroundWorker
        Me.BGW_MediScanDirectory = New System.ComponentModel.BackgroundWorker
        Me.BGW_CheckServer = New System.ComponentModel.BackgroundWorker
        Me.BGW_RetryServer = New System.ComponentModel.BackgroundWorker
        Me.CaseNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PersonNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CaseNumberDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BATCHNUMBER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CaseNumberDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BGW_GUMPUpdate = New System.ComponentModel.BackgroundWorker
        Me.MedicaidDataSet = New Phoenix___Server.MedicaidDataSet
        Me.IMPSInformationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IMPSInformationTableAdapter = New Phoenix___Server.PhoenixCaseDataDataSetTableAdapters.IMPSInformationTableAdapter
        Me.TransactionLogTableAdapter = New Phoenix___Server.PhoenixCaseDataDataSetTableAdapters.TransactionLogTableAdapter
        Me.FAMISCaseInformationTableAdapter = New Phoenix___Server.PhoenixCaseDataDataSetTableAdapters.FAMISCaseInformationTableAdapter
        Me.TransactionLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BGW_ClientData = New System.ComponentModel.BackgroundWorker
        Me.CRLFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.BGW_Test = New System.ComponentModel.BackgroundWorker
        Me.MainPanel.Panel1.SuspendLayout()
        Me.MainPanel.Panel2.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.ControlPanel.Panel1.SuspendLayout()
        Me.ControlPanel.Panel2.SuspendLayout()
        Me.ControlPanel.SuspendLayout()
        Me.stripMenu.SuspendLayout()
        Me.panel_Main.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_Users, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_Reports.SuspendLayout()
        CType(Me.grid_CaseView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAMISCaseInformationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PhoenixCaseDataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_IMPSOptions.SuspendLayout()
        Me.panel_MedicaidOptions.SuspendLayout()
        Me.panel_GUMPUpdate.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.MedicaidDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMPSInformationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainPanel.Location = New System.Drawing.Point(5, 5)
        Me.MainPanel.Name = "MainPanel"
        '
        'MainPanel.Panel1
        '
        Me.MainPanel.Panel1.Controls.Add(Me.treeMenu)
        '
        'MainPanel.Panel2
        '
        Me.MainPanel.Panel2.Controls.Add(Me.ControlPanel)
        Me.MainPanel.Size = New System.Drawing.Size(804, 340)
        Me.MainPanel.SplitterDistance = 167
        Me.MainPanel.TabIndex = 0
        '
        'treeMenu
        '
        Me.treeMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeMenu.ImageKey = "black-server.ico"
        Me.treeMenu.ImageList = Me.treeImageList
        Me.treeMenu.Location = New System.Drawing.Point(0, 0)
        Me.treeMenu.Name = "treeMenu"
        TreeNode21.ImageIndex = 7
        TreeNode21.Name = "IMPSApplication"
        TreeNode21.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode21.SelectedImageIndex = 7
        TreeNode21.Text = "Application"
        TreeNode22.ImageIndex = 6
        TreeNode22.Name = "IMPSLog"
        TreeNode22.SelectedImageIndex = 6
        TreeNode22.Text = "Log"
        TreeNode23.ImageIndex = 8
        TreeNode23.Name = "IMPSCases"
        TreeNode23.SelectedImageIndex = 8
        TreeNode23.Text = "Cases"
        TreeNode24.ImageIndex = 5
        TreeNode24.Name = "IMPSReports"
        TreeNode24.SelectedImageIndex = 5
        TreeNode24.Text = "Reports"
        TreeNode25.ImageIndex = 9
        TreeNode25.Name = "IMPSOptions"
        TreeNode25.SelectedImageIndex = 9
        TreeNode25.Text = "Options"
        TreeNode26.ImageIndex = 1
        TreeNode26.Name = "IMPSRoot"
        TreeNode26.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode26.SelectedImageIndex = 1
        TreeNode26.Text = "IMPS"
        TreeNode27.ImageIndex = 7
        TreeNode27.Name = "MedicaidApplication"
        TreeNode27.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode27.SelectedImageIndex = 7
        TreeNode27.Text = "Application"
        TreeNode28.ImageIndex = 6
        TreeNode28.Name = "MedicaidLog"
        TreeNode28.SelectedImageIndex = 6
        TreeNode28.Text = "Log"
        TreeNode29.ImageIndex = 8
        TreeNode29.Name = "MedicaidCases"
        TreeNode29.SelectedImageIndex = 8
        TreeNode29.Text = "Cases"
        TreeNode30.ImageIndex = 5
        TreeNode30.Name = "MedicaidReports"
        TreeNode30.SelectedImageIndex = 5
        TreeNode30.Text = "Reports"
        TreeNode31.ImageIndex = 9
        TreeNode31.Name = "MedicaidOptions"
        TreeNode31.SelectedImageIndex = 9
        TreeNode31.Text = "Options"
        TreeNode32.ImageIndex = 1
        TreeNode32.Name = "MedicaidRoot"
        TreeNode32.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode32.SelectedImageIndex = 1
        TreeNode32.Text = "Medicaid"
        TreeNode33.ImageIndex = 7
        TreeNode33.Name = "GUMPSettings"
        TreeNode33.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode33.SelectedImageIndex = 7
        TreeNode33.Text = "Settings"
        TreeNode34.ImageIndex = 1
        TreeNode34.Name = "GUMPRoot"
        TreeNode34.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode34.SelectedImageIndex = 1
        TreeNode34.Text = "GUMP Update"
        TreeNode35.ImageIndex = 10
        TreeNode35.Name = "FAMISUsers"
        TreeNode35.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode35.SelectedImageIndex = 10
        TreeNode35.Text = "Users"
        TreeNode36.ImageIndex = 8
        TreeNode36.Name = "FAMISCases"
        TreeNode36.SelectedImageIndex = 8
        TreeNode36.Text = "Cases"
        TreeNode37.ImageIndex = 5
        TreeNode37.Name = "FAMISReports"
        TreeNode37.SelectedImageIndex = 5
        TreeNode37.Text = "Reports"
        TreeNode38.ImageIndex = 3
        TreeNode38.Name = "FAMISRoot"
        TreeNode38.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode38.SelectedImageIndex = 3
        TreeNode38.Text = "FAMIS"
        TreeNode39.ImageIndex = 3
        TreeNode39.Name = "ClientRoot"
        TreeNode39.NodeFont = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode39.SelectedImageIndex = 3
        TreeNode39.Text = "Client Data"
        TreeNode40.ImageIndex = 4
        TreeNode40.Name = "PhoenixRoot"
        TreeNode40.NodeFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TreeNode40.SelectedImageIndex = 4
        TreeNode40.Text = "Phoenix"
        Me.treeMenu.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode40})
        Me.treeMenu.SelectedImageIndex = 4
        Me.treeMenu.Size = New System.Drawing.Size(167, 340)
        Me.treeMenu.TabIndex = 0
        '
        'treeImageList
        '
        Me.treeImageList.ImageStream = CType(resources.GetObject("treeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.treeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.treeImageList.Images.SetKeyName(0, "")
        Me.treeImageList.Images.SetKeyName(1, "")
        Me.treeImageList.Images.SetKeyName(2, "")
        Me.treeImageList.Images.SetKeyName(3, "")
        Me.treeImageList.Images.SetKeyName(4, "")
        Me.treeImageList.Images.SetKeyName(5, "")
        Me.treeImageList.Images.SetKeyName(6, "")
        Me.treeImageList.Images.SetKeyName(7, "")
        Me.treeImageList.Images.SetKeyName(8, "")
        Me.treeImageList.Images.SetKeyName(9, "")
        Me.treeImageList.Images.SetKeyName(10, "")
        '
        'ControlPanel
        '
        Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlPanel.Location = New System.Drawing.Point(0, 0)
        Me.ControlPanel.Name = "ControlPanel"
        Me.ControlPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'ControlPanel.Panel1
        '
        Me.ControlPanel.Panel1.Controls.Add(Me.DateChoice)
        Me.ControlPanel.Panel1.Controls.Add(Me.stripMenu)
        '
        'ControlPanel.Panel2
        '
        Me.ControlPanel.Panel2.AutoScroll = True
        Me.ControlPanel.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.ControlPanel.Panel2.Controls.Add(Me.panel_Main)
        Me.ControlPanel.Panel2.Controls.Add(Me.txt_MedicaidInfo)
        Me.ControlPanel.Panel2.Controls.Add(Me.txt_ClientInfo)
        Me.ControlPanel.Panel2.Controls.Add(Me.lbl_OptionError)
        Me.ControlPanel.Panel2.Controls.Add(Me.grid_Users)
        Me.ControlPanel.Panel2.Controls.Add(Me.txt_MedicaidLog)
        Me.ControlPanel.Panel2.Controls.Add(Me.panel_Reports)
        Me.ControlPanel.Panel2.Controls.Add(Me.txt_IMPSInfo)
        Me.ControlPanel.Panel2.Controls.Add(Me.txt_IMPSLog)
        Me.ControlPanel.Panel2.Controls.Add(Me.grid_CaseView)
        Me.ControlPanel.Panel2.Controls.Add(Me.panel_IMPSOptions)
        Me.ControlPanel.Panel2.Controls.Add(Me.panel_MedicaidOptions)
        Me.ControlPanel.Panel2.Controls.Add(Me.panel_GUMPUpdate)
        Me.ControlPanel.Size = New System.Drawing.Size(633, 340)
        Me.ControlPanel.SplitterDistance = 25
        Me.ControlPanel.TabIndex = 0
        '
        'DateChoice
        '
        Me.DateChoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateChoice.Location = New System.Drawing.Point(240, 5)
        Me.DateChoice.Name = "DateChoice"
        Me.DateChoice.Size = New System.Drawing.Size(104, 20)
        Me.DateChoice.TabIndex = 6
        '
        'stripMenu
        '
        Me.stripMenu.Dock = System.Windows.Forms.DockStyle.None
        Me.stripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.stripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tool_Run, Me.tool_Stop, Me.ToolStripSeparator4, Me.tool_Print, Me.ToolStripSeparator5, Me.tool_Submit, Me.ToolStripSeparator6, Me.cmb_LogFiles})
        Me.stripMenu.Location = New System.Drawing.Point(0, 0)
        Me.stripMenu.Name = "stripMenu"
        Me.stripMenu.Size = New System.Drawing.Size(236, 25)
        Me.stripMenu.TabIndex = 5
        '
        'tool_Run
        '
        Me.tool_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_Run.Image = CType(resources.GetObject("tool_Run.Image"), System.Drawing.Image)
        Me.tool_Run.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_Run.Name = "tool_Run"
        Me.tool_Run.Size = New System.Drawing.Size(23, 22)
        Me.tool_Run.Text = "ToolStripButton1"
        '
        'tool_Stop
        '
        Me.tool_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_Stop.Image = CType(resources.GetObject("tool_Stop.Image"), System.Drawing.Image)
        Me.tool_Stop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_Stop.Name = "tool_Stop"
        Me.tool_Stop.Size = New System.Drawing.Size(23, 22)
        Me.tool_Stop.Text = "ToolStripButton2"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tool_Print
        '
        Me.tool_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_Print.Image = CType(resources.GetObject("tool_Print.Image"), System.Drawing.Image)
        Me.tool_Print.ImageTransparentColor = System.Drawing.Color.Black
        Me.tool_Print.Name = "tool_Print"
        Me.tool_Print.Size = New System.Drawing.Size(23, 22)
        Me.tool_Print.Text = "Print"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tool_Submit
        '
        Me.tool_Submit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tool_Submit.Image = CType(resources.GetObject("tool_Submit.Image"), System.Drawing.Image)
        Me.tool_Submit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tool_Submit.Name = "tool_Submit"
        Me.tool_Submit.Size = New System.Drawing.Size(23, 22)
        Me.tool_Submit.Text = "ToolStripButton3"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'cmb_LogFiles
        '
        Me.cmb_LogFiles.Name = "cmb_LogFiles"
        Me.cmb_LogFiles.Size = New System.Drawing.Size(121, 25)
        '
        'panel_Main
        '
        Me.panel_Main.AutoScroll = True
        Me.panel_Main.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.panel_Main.BackgroundImage = Global.Phoenix___Server.My.Resources.Resources.RedBG1
        Me.panel_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel_Main.Controls.Add(Me.PictureBox4)
        Me.panel_Main.Controls.Add(Me.txt_ClientTime)
        Me.panel_Main.Controls.Add(Me.Label25)
        Me.panel_Main.Controls.Add(Me.txt_ClientCases)
        Me.panel_Main.Controls.Add(Me.Label26)
        Me.panel_Main.Controls.Add(Me.ClientProgress)
        Me.panel_Main.Controls.Add(Me.btn_ClientData)
        Me.panel_Main.Controls.Add(Me.PictureBox1)
        Me.panel_Main.Controls.Add(Me.txt_UpdateTime)
        Me.panel_Main.Controls.Add(Me.Label23)
        Me.panel_Main.Controls.Add(Me.txt_UpdateCases)
        Me.panel_Main.Controls.Add(Me.Label22)
        Me.panel_Main.Controls.Add(Me.UpdateProgress)
        Me.panel_Main.Controls.Add(Me.lbl_VersionNumber)
        Me.panel_Main.Controls.Add(Me.Label21)
        Me.panel_Main.Controls.Add(Me.txt_MedicaidHold)
        Me.panel_Main.Controls.Add(Me.Label20)
        Me.panel_Main.Controls.Add(Me.PictureBox3)
        Me.panel_Main.Controls.Add(Me.lbl_Server)
        Me.panel_Main.Controls.Add(Me.txt_MedicaidFailed)
        Me.panel_Main.Controls.Add(Me.txt_MedicaidSuccess)
        Me.panel_Main.Controls.Add(Me.txt_MedicaidTotal)
        Me.panel_Main.Controls.Add(Me.Label1)
        Me.panel_Main.Controls.Add(Me.Label17)
        Me.panel_Main.Controls.Add(Me.Label18)
        Me.panel_Main.Controls.Add(Me.PictureBox2)
        Me.panel_Main.Controls.Add(Me.txt_IMPSFailed)
        Me.panel_Main.Controls.Add(Me.txt_IMPSSuccess)
        Me.panel_Main.Controls.Add(Me.txt_IMPSTotal)
        Me.panel_Main.Controls.Add(Me.Label16)
        Me.panel_Main.Controls.Add(Me.Label9)
        Me.panel_Main.Controls.Add(Me.Label8)
        Me.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_Main.Location = New System.Drawing.Point(0, 0)
        Me.panel_Main.Name = "panel_Main"
        Me.panel_Main.Size = New System.Drawing.Size(633, 311)
        Me.panel_Main.TabIndex = 7
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.Phoenix___Server.My.Resources.Resources.ClientData
        Me.PictureBox4.Location = New System.Drawing.Point(281, 120)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(242, 40)
        Me.PictureBox4.TabIndex = 34
        Me.PictureBox4.TabStop = False
        '
        'txt_ClientTime
        '
        Me.txt_ClientTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ClientTime.Location = New System.Drawing.Point(395, 239)
        Me.txt_ClientTime.Name = "txt_ClientTime"
        Me.txt_ClientTime.ReadOnly = True
        Me.txt_ClientTime.Size = New System.Drawing.Size(128, 22)
        Me.txt_ClientTime.TabIndex = 33
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label25.Location = New System.Drawing.Point(347, 242)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 16)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "Time:"
        '
        'txt_ClientCases
        '
        Me.txt_ClientCases.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ClientCases.Location = New System.Drawing.Point(468, 211)
        Me.txt_ClientCases.Name = "txt_ClientCases"
        Me.txt_ClientCases.ReadOnly = True
        Me.txt_ClientCases.Size = New System.Drawing.Size(55, 22)
        Me.txt_ClientCases.TabIndex = 31
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label26.Location = New System.Drawing.Point(347, 214)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(121, 16)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "Cases Looked Up:"
        '
        'ClientProgress
        '
        Me.ClientProgress.Location = New System.Drawing.Point(350, 160)
        Me.ClientProgress.Name = "ClientProgress"
        Me.ClientProgress.Size = New System.Drawing.Size(173, 20)
        Me.ClientProgress.TabIndex = 29
        '
        'btn_ClientData
        '
        Me.btn_ClientData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ClientData.Location = New System.Drawing.Point(395, 186)
        Me.btn_ClientData.Name = "btn_ClientData"
        Me.btn_ClientData.Size = New System.Drawing.Size(128, 23)
        Me.btn_ClientData.TabIndex = 28
        Me.btn_ClientData.Text = "Run Client Look Up"
        Me.btn_ClientData.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Phoenix___Server.My.Resources.Resources.GUMPBanner
        Me.PictureBox1.Location = New System.Drawing.Point(281, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(201, 40)
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'txt_UpdateTime
        '
        Me.txt_UpdateTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_UpdateTime.Location = New System.Drawing.Point(395, 96)
        Me.txt_UpdateTime.Name = "txt_UpdateTime"
        Me.txt_UpdateTime.ReadOnly = True
        Me.txt_UpdateTime.Size = New System.Drawing.Size(128, 22)
        Me.txt_UpdateTime.TabIndex = 25
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.Location = New System.Drawing.Point(347, 99)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(44, 16)
        Me.Label23.TabIndex = 24
        Me.Label23.Text = "Time:"
        '
        'txt_UpdateCases
        '
        Me.txt_UpdateCases.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_UpdateCases.Location = New System.Drawing.Point(468, 68)
        Me.txt_UpdateCases.Name = "txt_UpdateCases"
        Me.txt_UpdateCases.ReadOnly = True
        Me.txt_UpdateCases.Size = New System.Drawing.Size(55, 22)
        Me.txt_UpdateCases.TabIndex = 23
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.Location = New System.Drawing.Point(347, 71)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(118, 16)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Cases Processed:"
        '
        'UpdateProgress
        '
        Me.UpdateProgress.Location = New System.Drawing.Point(350, 44)
        Me.UpdateProgress.Name = "UpdateProgress"
        Me.UpdateProgress.Size = New System.Drawing.Size(173, 20)
        Me.UpdateProgress.TabIndex = 21
        '
        'lbl_VersionNumber
        '
        Me.lbl_VersionNumber.AutoSize = True
        Me.lbl_VersionNumber.BackColor = System.Drawing.Color.Transparent
        Me.lbl_VersionNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_VersionNumber.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_VersionNumber.Location = New System.Drawing.Point(588, 286)
        Me.lbl_VersionNumber.Name = "lbl_VersionNumber"
        Me.lbl_VersionNumber.Size = New System.Drawing.Size(32, 14)
        Me.lbl_VersionNumber.TabIndex = 20
        Me.lbl_VersionNumber.Text = "Num"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label21.Location = New System.Drawing.Point(536, 286)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 14)
        Me.Label21.TabIndex = 19
        Me.Label21.Text = "Version:"
        '
        'txt_MedicaidHold
        '
        Me.txt_MedicaidHold.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MedicaidHold.Location = New System.Drawing.Point(192, 230)
        Me.txt_MedicaidHold.Name = "txt_MedicaidHold"
        Me.txt_MedicaidHold.ReadOnly = True
        Me.txt_MedicaidHold.Size = New System.Drawing.Size(55, 22)
        Me.txt_MedicaidHold.TabIndex = 18
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label20.Location = New System.Drawing.Point(106, 233)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(82, 16)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Held Cases:"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.Phoenix___Server.My.Resources.Resources.IMPSBanner
        Me.PictureBox3.Location = New System.Drawing.Point(8, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(114, 40)
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        '
        'lbl_Server
        '
        Me.lbl_Server.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Server.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Server.Location = New System.Drawing.Point(16, 274)
        Me.lbl_Server.Name = "lbl_Server"
        Me.lbl_Server.Size = New System.Drawing.Size(220, 23)
        Me.lbl_Server.TabIndex = 15
        Me.lbl_Server.Text = "Server Not Found. Retrying......"
        Me.lbl_Server.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_MedicaidFailed
        '
        Me.txt_MedicaidFailed.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MedicaidFailed.Location = New System.Drawing.Point(192, 206)
        Me.txt_MedicaidFailed.Name = "txt_MedicaidFailed"
        Me.txt_MedicaidFailed.ReadOnly = True
        Me.txt_MedicaidFailed.Size = New System.Drawing.Size(55, 22)
        Me.txt_MedicaidFailed.TabIndex = 14
        '
        'txt_MedicaidSuccess
        '
        Me.txt_MedicaidSuccess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MedicaidSuccess.Location = New System.Drawing.Point(192, 182)
        Me.txt_MedicaidSuccess.Name = "txt_MedicaidSuccess"
        Me.txt_MedicaidSuccess.ReadOnly = True
        Me.txt_MedicaidSuccess.Size = New System.Drawing.Size(55, 22)
        Me.txt_MedicaidSuccess.TabIndex = 13
        '
        'txt_MedicaidTotal
        '
        Me.txt_MedicaidTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MedicaidTotal.Location = New System.Drawing.Point(192, 158)
        Me.txt_MedicaidTotal.Name = "txt_MedicaidTotal"
        Me.txt_MedicaidTotal.ReadOnly = True
        Me.txt_MedicaidTotal.Size = New System.Drawing.Size(55, 22)
        Me.txt_MedicaidTotal.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(95, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Failed Cases:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label17.Location = New System.Drawing.Point(66, 184)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 16)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "Successful Cases:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label18.Location = New System.Drawing.Point(71, 161)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 16)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Cases Processed:"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.Phoenix___Server.My.Resources.Resources.MedicaidBanner
        Me.PictureBox2.Location = New System.Drawing.Point(15, 116)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(171, 50)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'txt_IMPSFailed
        '
        Me.txt_IMPSFailed.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSFailed.Location = New System.Drawing.Point(192, 92)
        Me.txt_IMPSFailed.Name = "txt_IMPSFailed"
        Me.txt_IMPSFailed.ReadOnly = True
        Me.txt_IMPSFailed.Size = New System.Drawing.Size(55, 22)
        Me.txt_IMPSFailed.TabIndex = 6
        '
        'txt_IMPSSuccess
        '
        Me.txt_IMPSSuccess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSSuccess.Location = New System.Drawing.Point(192, 68)
        Me.txt_IMPSSuccess.Name = "txt_IMPSSuccess"
        Me.txt_IMPSSuccess.ReadOnly = True
        Me.txt_IMPSSuccess.Size = New System.Drawing.Size(55, 22)
        Me.txt_IMPSSuccess.TabIndex = 5
        '
        'txt_IMPSTotal
        '
        Me.txt_IMPSTotal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSTotal.Location = New System.Drawing.Point(192, 44)
        Me.txt_IMPSTotal.Name = "txt_IMPSTotal"
        Me.txt_IMPSTotal.ReadOnly = True
        Me.txt_IMPSTotal.Size = New System.Drawing.Size(55, 22)
        Me.txt_IMPSTotal.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label16.Location = New System.Drawing.Point(95, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 16)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Failed Cases:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Location = New System.Drawing.Point(68, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Successful Cases:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Location = New System.Drawing.Point(71, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 16)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Cases Processed:"
        '
        'txt_MedicaidInfo
        '
        Me.txt_MedicaidInfo.Location = New System.Drawing.Point(413, 78)
        Me.txt_MedicaidInfo.Name = "txt_MedicaidInfo"
        Me.txt_MedicaidInfo.Size = New System.Drawing.Size(87, 45)
        Me.txt_MedicaidInfo.TabIndex = 4
        Me.txt_MedicaidInfo.Text = ""
        '
        'txt_ClientInfo
        '
        Me.txt_ClientInfo.Location = New System.Drawing.Point(356, 53)
        Me.txt_ClientInfo.Multiline = True
        Me.txt_ClientInfo.Name = "txt_ClientInfo"
        Me.txt_ClientInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txt_ClientInfo.Size = New System.Drawing.Size(51, 52)
        Me.txt_ClientInfo.TabIndex = 0
        '
        'lbl_OptionError
        '
        Me.lbl_OptionError.BackColor = System.Drawing.SystemColors.Info
        Me.lbl_OptionError.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_OptionError.Location = New System.Drawing.Point(259, 6)
        Me.lbl_OptionError.Name = "lbl_OptionError"
        Me.lbl_OptionError.Size = New System.Drawing.Size(113, 44)
        Me.lbl_OptionError.TabIndex = 60
        Me.lbl_OptionError.Text = "Please Stop The Application Before Changing Options."
        Me.lbl_OptionError.Visible = False
        '
        'grid_Users
        '
        Me.grid_Users.AllowUserToAddRows = False
        Me.grid_Users.AllowUserToDeleteRows = False
        Me.grid_Users.AllowUserToOrderColumns = True
        Me.grid_Users.AllowUserToResizeRows = False
        Me.grid_Users.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid_Users.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grid_Users.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grid_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_Users.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.User, Me.Status, Me.CasesDone, Me.CheckInTime, Me.Version})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid_Users.DefaultCellStyle = DataGridViewCellStyle2
        Me.grid_Users.Location = New System.Drawing.Point(167, 120)
        Me.grid_Users.Name = "grid_Users"
        Me.grid_Users.RowHeadersVisible = False
        Me.grid_Users.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grid_Users.Size = New System.Drawing.Size(240, 150)
        Me.grid_Users.TabIndex = 64
        '
        'User
        '
        Me.User.HeaderText = "User"
        Me.User.Name = "User"
        Me.User.ReadOnly = True
        Me.User.Width = 54
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 62
        '
        'CasesDone
        '
        Me.CasesDone.HeaderText = "Cases Done Today"
        Me.CasesDone.Name = "CasesDone"
        Me.CasesDone.ReadOnly = True
        Me.CasesDone.Width = 113
        '
        'CheckInTime
        '
        Me.CheckInTime.HeaderText = "Last Check In"
        Me.CheckInTime.Name = "CheckInTime"
        Me.CheckInTime.ReadOnly = True
        Me.CheckInTime.Width = 82
        '
        'Version
        '
        Me.Version.HeaderText = "Version"
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        Me.Version.Width = 67
        '
        'txt_MedicaidLog
        '
        Me.txt_MedicaidLog.Location = New System.Drawing.Point(456, 188)
        Me.txt_MedicaidLog.Name = "txt_MedicaidLog"
        Me.txt_MedicaidLog.Size = New System.Drawing.Size(82, 48)
        Me.txt_MedicaidLog.TabIndex = 5
        Me.txt_MedicaidLog.Text = ""
        '
        'panel_Reports
        '
        Me.panel_Reports.BackgroundImage = Global.Phoenix___Server.My.Resources.Resources.RedBG1
        Me.panel_Reports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel_Reports.Controls.Add(Me.btn_Redet)
        Me.panel_Reports.Controls.Add(Me.btn_Drop)
        Me.panel_Reports.Controls.Add(Me.btn_Success)
        Me.panel_Reports.Controls.Add(Me.btn_All)
        Me.panel_Reports.Location = New System.Drawing.Point(6, 159)
        Me.panel_Reports.Name = "panel_Reports"
        Me.panel_Reports.Size = New System.Drawing.Size(104, 123)
        Me.panel_Reports.TabIndex = 62
        '
        'btn_Redet
        '
        Me.btn_Redet.BackColor = System.Drawing.Color.DarkGray
        Me.btn_Redet.BackgroundImage = CType(resources.GetObject("btn_Redet.BackgroundImage"), System.Drawing.Image)
        Me.btn_Redet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Redet.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Redet.ForeColor = System.Drawing.Color.Black
        Me.btn_Redet.Location = New System.Drawing.Point(295, 9)
        Me.btn_Redet.Name = "btn_Redet"
        Me.btn_Redet.Size = New System.Drawing.Size(99, 97)
        Me.btn_Redet.TabIndex = 3
        Me.btn_Redet.Text = "Redet Deleted Cases"
        Me.btn_Redet.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Redet.UseVisualStyleBackColor = False
        '
        'btn_Drop
        '
        Me.btn_Drop.BackColor = System.Drawing.Color.DarkGray
        Me.btn_Drop.BackgroundImage = CType(resources.GetObject("btn_Drop.BackgroundImage"), System.Drawing.Image)
        Me.btn_Drop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Drop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Drop.ForeColor = System.Drawing.Color.Black
        Me.btn_Drop.Location = New System.Drawing.Point(199, 9)
        Me.btn_Drop.Name = "btn_Drop"
        Me.btn_Drop.Size = New System.Drawing.Size(87, 97)
        Me.btn_Drop.TabIndex = 2
        Me.btn_Drop.Text = "Dropped Cases"
        Me.btn_Drop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Drop.UseVisualStyleBackColor = False
        '
        'btn_Success
        '
        Me.btn_Success.BackColor = System.Drawing.Color.DarkGray
        Me.btn_Success.BackgroundImage = CType(resources.GetObject("btn_Success.BackgroundImage"), System.Drawing.Image)
        Me.btn_Success.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_Success.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Success.ForeColor = System.Drawing.Color.Black
        Me.btn_Success.Location = New System.Drawing.Point(105, 8)
        Me.btn_Success.Name = "btn_Success"
        Me.btn_Success.Size = New System.Drawing.Size(86, 97)
        Me.btn_Success.TabIndex = 1
        Me.btn_Success.Text = "Successful Cases"
        Me.btn_Success.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Success.UseVisualStyleBackColor = False
        '
        'btn_All
        '
        Me.btn_All.BackColor = System.Drawing.Color.DarkGray
        Me.btn_All.BackgroundImage = CType(resources.GetObject("btn_All.BackgroundImage"), System.Drawing.Image)
        Me.btn_All.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_All.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_All.ForeColor = System.Drawing.Color.Black
        Me.btn_All.Location = New System.Drawing.Point(8, 8)
        Me.btn_All.Name = "btn_All"
        Me.btn_All.Size = New System.Drawing.Size(86, 97)
        Me.btn_All.TabIndex = 0
        Me.btn_All.Text = "All Cases"
        Me.btn_All.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_All.UseVisualStyleBackColor = False
        '
        'txt_IMPSInfo
        '
        Me.txt_IMPSInfo.Location = New System.Drawing.Point(12, 4)
        Me.txt_IMPSInfo.Name = "txt_IMPSInfo"
        Me.txt_IMPSInfo.Size = New System.Drawing.Size(98, 38)
        Me.txt_IMPSInfo.TabIndex = 0
        Me.txt_IMPSInfo.Text = ""
        '
        'txt_IMPSLog
        '
        Me.txt_IMPSLog.Location = New System.Drawing.Point(116, 4)
        Me.txt_IMPSLog.Name = "txt_IMPSLog"
        Me.txt_IMPSLog.Size = New System.Drawing.Size(100, 38)
        Me.txt_IMPSLog.TabIndex = 1
        Me.txt_IMPSLog.Text = ""
        '
        'grid_CaseView
        '
        Me.grid_CaseView.AllowUserToAddRows = False
        Me.grid_CaseView.AllowUserToDeleteRows = False
        Me.grid_CaseView.AllowUserToOrderColumns = True
        Me.grid_CaseView.AllowUserToResizeRows = False
        Me.grid_CaseView.AutoGenerateColumns = False
        Me.grid_CaseView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_CaseView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CaseNumber, Me.TextFile, Me.CaseNumberDataGridViewTextBoxColumn3, Me.AADataGridViewTextBoxColumn, Me.ABDataGridViewTextBoxColumn, Me.ACDataGridViewTextBoxColumn, Me.ADDataGridViewTextBoxColumn, Me.AEDataGridViewTextBoxColumn, Me.AFDataGridViewTextBoxColumn, Me.AGDataGridViewTextBoxColumn, Me.AHDataGridViewTextBoxColumn, Me.AIDataGridViewTextBoxColumn, Me.AJDataGridViewTextBoxColumn, Me.AKDataGridViewTextBoxColumn, Me.ALDataGridViewTextBoxColumn, Me.AMDataGridViewTextBoxColumn, Me.ANDataGridViewTextBoxColumn, Me.DATEENTEREDDataGridViewTextBoxColumn, Me.P03DataGridViewTextBoxColumn, Me.P05DataGridViewTextBoxColumn, Me.OPERATORDataGridViewTextBoxColumn, Me.P09DataGridViewTextBoxColumn, Me.BATCHNUMBERDataGridViewTextBoxColumn, Me.P10DataGridViewTextBoxColumn, Me.WWDataGridViewTextBoxColumn})
        Me.grid_CaseView.DataSource = Me.FAMISCaseInformationBindingSource
        Me.grid_CaseView.Location = New System.Drawing.Point(0, 0)
        Me.grid_CaseView.Name = "grid_CaseView"
        Me.grid_CaseView.ReadOnly = True
        Me.grid_CaseView.RowHeadersVisible = False
        Me.grid_CaseView.Size = New System.Drawing.Size(50, 50)
        Me.grid_CaseView.TabIndex = 2
        '
        'CaseNumber
        '
        Me.CaseNumber.DataPropertyName = "CaseNumber"
        Me.CaseNumber.HeaderText = "CaseNumber"
        Me.CaseNumber.Name = "CaseNumber"
        Me.CaseNumber.ReadOnly = True
        '
        'TextFile
        '
        Me.TextFile.DataPropertyName = "TextFile"
        Me.TextFile.HeaderText = "TextFile"
        Me.TextFile.Name = "TextFile"
        Me.TextFile.ReadOnly = True
        '
        'CaseNumberDataGridViewTextBoxColumn3
        '
        Me.CaseNumberDataGridViewTextBoxColumn3.DataPropertyName = "CaseNumber"
        Me.CaseNumberDataGridViewTextBoxColumn3.HeaderText = "CaseNumber"
        Me.CaseNumberDataGridViewTextBoxColumn3.Name = "CaseNumberDataGridViewTextBoxColumn3"
        Me.CaseNumberDataGridViewTextBoxColumn3.ReadOnly = True
        '
        'AADataGridViewTextBoxColumn
        '
        Me.AADataGridViewTextBoxColumn.DataPropertyName = "AA"
        Me.AADataGridViewTextBoxColumn.HeaderText = "AA"
        Me.AADataGridViewTextBoxColumn.Name = "AADataGridViewTextBoxColumn"
        Me.AADataGridViewTextBoxColumn.ReadOnly = True
        '
        'ABDataGridViewTextBoxColumn
        '
        Me.ABDataGridViewTextBoxColumn.DataPropertyName = "AB"
        Me.ABDataGridViewTextBoxColumn.HeaderText = "AB"
        Me.ABDataGridViewTextBoxColumn.Name = "ABDataGridViewTextBoxColumn"
        Me.ABDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ACDataGridViewTextBoxColumn
        '
        Me.ACDataGridViewTextBoxColumn.DataPropertyName = "AC"
        Me.ACDataGridViewTextBoxColumn.HeaderText = "AC"
        Me.ACDataGridViewTextBoxColumn.Name = "ACDataGridViewTextBoxColumn"
        Me.ACDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ADDataGridViewTextBoxColumn
        '
        Me.ADDataGridViewTextBoxColumn.DataPropertyName = "AD"
        Me.ADDataGridViewTextBoxColumn.HeaderText = "AD"
        Me.ADDataGridViewTextBoxColumn.Name = "ADDataGridViewTextBoxColumn"
        Me.ADDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AEDataGridViewTextBoxColumn
        '
        Me.AEDataGridViewTextBoxColumn.DataPropertyName = "AE"
        Me.AEDataGridViewTextBoxColumn.HeaderText = "AE"
        Me.AEDataGridViewTextBoxColumn.Name = "AEDataGridViewTextBoxColumn"
        Me.AEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AFDataGridViewTextBoxColumn
        '
        Me.AFDataGridViewTextBoxColumn.DataPropertyName = "AF"
        Me.AFDataGridViewTextBoxColumn.HeaderText = "AF"
        Me.AFDataGridViewTextBoxColumn.Name = "AFDataGridViewTextBoxColumn"
        Me.AFDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AGDataGridViewTextBoxColumn
        '
        Me.AGDataGridViewTextBoxColumn.DataPropertyName = "AG"
        Me.AGDataGridViewTextBoxColumn.HeaderText = "AG"
        Me.AGDataGridViewTextBoxColumn.Name = "AGDataGridViewTextBoxColumn"
        Me.AGDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AHDataGridViewTextBoxColumn
        '
        Me.AHDataGridViewTextBoxColumn.DataPropertyName = "AH"
        Me.AHDataGridViewTextBoxColumn.HeaderText = "AH"
        Me.AHDataGridViewTextBoxColumn.Name = "AHDataGridViewTextBoxColumn"
        Me.AHDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AIDataGridViewTextBoxColumn
        '
        Me.AIDataGridViewTextBoxColumn.DataPropertyName = "AI"
        Me.AIDataGridViewTextBoxColumn.HeaderText = "AI"
        Me.AIDataGridViewTextBoxColumn.Name = "AIDataGridViewTextBoxColumn"
        Me.AIDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AJDataGridViewTextBoxColumn
        '
        Me.AJDataGridViewTextBoxColumn.DataPropertyName = "AJ"
        Me.AJDataGridViewTextBoxColumn.HeaderText = "AJ"
        Me.AJDataGridViewTextBoxColumn.Name = "AJDataGridViewTextBoxColumn"
        Me.AJDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AKDataGridViewTextBoxColumn
        '
        Me.AKDataGridViewTextBoxColumn.DataPropertyName = "AK"
        Me.AKDataGridViewTextBoxColumn.HeaderText = "AK"
        Me.AKDataGridViewTextBoxColumn.Name = "AKDataGridViewTextBoxColumn"
        Me.AKDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ALDataGridViewTextBoxColumn
        '
        Me.ALDataGridViewTextBoxColumn.DataPropertyName = "AL"
        Me.ALDataGridViewTextBoxColumn.HeaderText = "AL"
        Me.ALDataGridViewTextBoxColumn.Name = "ALDataGridViewTextBoxColumn"
        Me.ALDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AMDataGridViewTextBoxColumn
        '
        Me.AMDataGridViewTextBoxColumn.DataPropertyName = "AM"
        Me.AMDataGridViewTextBoxColumn.HeaderText = "AM"
        Me.AMDataGridViewTextBoxColumn.Name = "AMDataGridViewTextBoxColumn"
        Me.AMDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ANDataGridViewTextBoxColumn
        '
        Me.ANDataGridViewTextBoxColumn.DataPropertyName = "AN"
        Me.ANDataGridViewTextBoxColumn.HeaderText = "AN"
        Me.ANDataGridViewTextBoxColumn.Name = "ANDataGridViewTextBoxColumn"
        Me.ANDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DATEENTEREDDataGridViewTextBoxColumn
        '
        Me.DATEENTEREDDataGridViewTextBoxColumn.DataPropertyName = "DATEENTERED"
        Me.DATEENTEREDDataGridViewTextBoxColumn.HeaderText = "DATEENTERED"
        Me.DATEENTEREDDataGridViewTextBoxColumn.Name = "DATEENTEREDDataGridViewTextBoxColumn"
        Me.DATEENTEREDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'P03DataGridViewTextBoxColumn
        '
        Me.P03DataGridViewTextBoxColumn.DataPropertyName = "P03"
        Me.P03DataGridViewTextBoxColumn.HeaderText = "P03"
        Me.P03DataGridViewTextBoxColumn.Name = "P03DataGridViewTextBoxColumn"
        Me.P03DataGridViewTextBoxColumn.ReadOnly = True
        '
        'P05DataGridViewTextBoxColumn
        '
        Me.P05DataGridViewTextBoxColumn.DataPropertyName = "P05"
        Me.P05DataGridViewTextBoxColumn.HeaderText = "P05"
        Me.P05DataGridViewTextBoxColumn.Name = "P05DataGridViewTextBoxColumn"
        Me.P05DataGridViewTextBoxColumn.ReadOnly = True
        '
        'OPERATORDataGridViewTextBoxColumn
        '
        Me.OPERATORDataGridViewTextBoxColumn.DataPropertyName = "OPERATOR"
        Me.OPERATORDataGridViewTextBoxColumn.HeaderText = "OPERATOR"
        Me.OPERATORDataGridViewTextBoxColumn.Name = "OPERATORDataGridViewTextBoxColumn"
        Me.OPERATORDataGridViewTextBoxColumn.ReadOnly = True
        '
        'P09DataGridViewTextBoxColumn
        '
        Me.P09DataGridViewTextBoxColumn.DataPropertyName = "P09"
        Me.P09DataGridViewTextBoxColumn.HeaderText = "P09"
        Me.P09DataGridViewTextBoxColumn.Name = "P09DataGridViewTextBoxColumn"
        Me.P09DataGridViewTextBoxColumn.ReadOnly = True
        '
        'BATCHNUMBERDataGridViewTextBoxColumn
        '
        Me.BATCHNUMBERDataGridViewTextBoxColumn.DataPropertyName = "BATCHNUMBER"
        Me.BATCHNUMBERDataGridViewTextBoxColumn.HeaderText = "BATCHNUMBER"
        Me.BATCHNUMBERDataGridViewTextBoxColumn.Name = "BATCHNUMBERDataGridViewTextBoxColumn"
        Me.BATCHNUMBERDataGridViewTextBoxColumn.ReadOnly = True
        '
        'P10DataGridViewTextBoxColumn
        '
        Me.P10DataGridViewTextBoxColumn.DataPropertyName = "P10"
        Me.P10DataGridViewTextBoxColumn.HeaderText = "P10"
        Me.P10DataGridViewTextBoxColumn.Name = "P10DataGridViewTextBoxColumn"
        Me.P10DataGridViewTextBoxColumn.ReadOnly = True
        '
        'WWDataGridViewTextBoxColumn
        '
        Me.WWDataGridViewTextBoxColumn.DataPropertyName = "WW"
        Me.WWDataGridViewTextBoxColumn.HeaderText = "WW"
        Me.WWDataGridViewTextBoxColumn.Name = "WWDataGridViewTextBoxColumn"
        Me.WWDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FAMISCaseInformationBindingSource
        '
        Me.FAMISCaseInformationBindingSource.DataMember = "FAMISCaseInformation"
        Me.FAMISCaseInformationBindingSource.DataSource = Me.PhoenixCaseDataDataSet
        '
        'PhoenixCaseDataDataSet
        '
        Me.PhoenixCaseDataDataSet.DataSetName = "PhoenixCaseDataDataSet"
        Me.PhoenixCaseDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'panel_IMPSOptions
        '
        Me.panel_IMPSOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel_IMPSOptions.Controls.Add(Me.Label12)
        Me.panel_IMPSOptions.Controls.Add(Me.txt_IMPSServer)
        Me.panel_IMPSOptions.Controls.Add(Me.lbl_Note2)
        Me.panel_IMPSOptions.Controls.Add(Me.lbl_Note1)
        Me.panel_IMPSOptions.Controls.Add(Me.Label5)
        Me.panel_IMPSOptions.Controls.Add(Me.txt_IMPSBatchNumber)
        Me.panel_IMPSOptions.Controls.Add(Me.Label4)
        Me.panel_IMPSOptions.Controls.Add(Me.txt_IMPSBatchPrefix)
        Me.panel_IMPSOptions.Controls.Add(Me.Label3)
        Me.panel_IMPSOptions.Controls.Add(Me.Label6)
        Me.panel_IMPSOptions.Controls.Add(Me.txt_IMPSPassword)
        Me.panel_IMPSOptions.Controls.Add(Me.Label7)
        Me.panel_IMPSOptions.Controls.Add(Me.txt_IMPSOperator)
        Me.panel_IMPSOptions.Controls.Add(Me.txt_IMPSDirectory)
        Me.panel_IMPSOptions.Location = New System.Drawing.Point(70, 69)
        Me.panel_IMPSOptions.Name = "panel_IMPSOptions"
        Me.panel_IMPSOptions.Size = New System.Drawing.Size(73, 69)
        Me.panel_IMPSOptions.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 16)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "Server Path"
        '
        'txt_IMPSServer
        '
        Me.txt_IMPSServer.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "ServerAddress", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_IMPSServer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSServer.Location = New System.Drawing.Point(7, 62)
        Me.txt_IMPSServer.MaxLength = 20
        Me.txt_IMPSServer.Name = "txt_IMPSServer"
        Me.txt_IMPSServer.Size = New System.Drawing.Size(130, 20)
        Me.txt_IMPSServer.TabIndex = 58
        Me.txt_IMPSServer.Text = Global.Phoenix___Server.My.MySettings.Default.ServerAddress
        '
        'lbl_Note2
        '
        Me.lbl_Note2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Note2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Note2.Location = New System.Drawing.Point(95, 191)
        Me.lbl_Note2.Name = "lbl_Note2"
        Me.lbl_Note2.Size = New System.Drawing.Size(160, 56)
        Me.lbl_Note2.TabIndex = 48
        Me.lbl_Note2.Text = "Operator ID and Password are case sensitive."
        '
        'lbl_Note1
        '
        Me.lbl_Note1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Note1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Note1.Location = New System.Drawing.Point(95, 87)
        Me.lbl_Note1.Name = "lbl_Note1"
        Me.lbl_Note1.Size = New System.Drawing.Size(160, 88)
        Me.lbl_Note1.TabIndex = 47
        Me.lbl_Note1.Text = "When entering in new batch numbers if the batch number exists on the system the n" & _
            "ew case will delete the existing one."
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Batch Number"
        '
        'txt_IMPSBatchNumber
        '
        Me.txt_IMPSBatchNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "IMPSBatchNumber", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_IMPSBatchNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSBatchNumber.Location = New System.Drawing.Point(7, 143)
        Me.txt_IMPSBatchNumber.MaxLength = 3
        Me.txt_IMPSBatchNumber.Name = "txt_IMPSBatchNumber"
        Me.txt_IMPSBatchNumber.Size = New System.Drawing.Size(72, 20)
        Me.txt_IMPSBatchNumber.TabIndex = 40
        Me.txt_IMPSBatchNumber.Text = Global.Phoenix___Server.My.MySettings.Default.IMPSBatchNumber
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Batch Prefix"
        '
        'txt_IMPSBatchPrefix
        '
        Me.txt_IMPSBatchPrefix.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "IMPSBatchPrefix", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_IMPSBatchPrefix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSBatchPrefix.Location = New System.Drawing.Point(7, 103)
        Me.txt_IMPSBatchPrefix.MaxLength = 4
        Me.txt_IMPSBatchPrefix.Name = "txt_IMPSBatchPrefix"
        Me.txt_IMPSBatchPrefix.Size = New System.Drawing.Size(72, 20)
        Me.txt_IMPSBatchPrefix.TabIndex = 38
        Me.txt_IMPSBatchPrefix.Text = Global.Phoenix___Server.My.MySettings.Default.IMPSBatchPrefix
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Text File Directory"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Password"
        '
        'txt_IMPSPassword
        '
        Me.txt_IMPSPassword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "IMPSPassword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_IMPSPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSPassword.Location = New System.Drawing.Point(7, 231)
        Me.txt_IMPSPassword.MaxLength = 9
        Me.txt_IMPSPassword.Name = "txt_IMPSPassword"
        Me.txt_IMPSPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_IMPSPassword.Size = New System.Drawing.Size(72, 20)
        Me.txt_IMPSPassword.TabIndex = 43
        Me.txt_IMPSPassword.Text = Global.Phoenix___Server.My.MySettings.Default.IMPSPassword
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 16)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Operator ID"
        '
        'txt_IMPSOperator
        '
        Me.txt_IMPSOperator.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "IMPSOperator", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_IMPSOperator.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSOperator.Location = New System.Drawing.Point(7, 191)
        Me.txt_IMPSOperator.MaxLength = 6
        Me.txt_IMPSOperator.Name = "txt_IMPSOperator"
        Me.txt_IMPSOperator.Size = New System.Drawing.Size(72, 20)
        Me.txt_IMPSOperator.TabIndex = 41
        Me.txt_IMPSOperator.Text = Global.Phoenix___Server.My.MySettings.Default.IMPSOperator
        '
        'txt_IMPSDirectory
        '
        Me.txt_IMPSDirectory.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "IMPSDirectory", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_IMPSDirectory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IMPSDirectory.Location = New System.Drawing.Point(7, 23)
        Me.txt_IMPSDirectory.MaxLength = 40
        Me.txt_IMPSDirectory.Name = "txt_IMPSDirectory"
        Me.txt_IMPSDirectory.Size = New System.Drawing.Size(248, 20)
        Me.txt_IMPSDirectory.TabIndex = 37
        Me.txt_IMPSDirectory.Text = Global.Phoenix___Server.My.MySettings.Default.IMPSDirectory
        '
        'panel_MedicaidOptions
        '
        Me.panel_MedicaidOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel_MedicaidOptions.Controls.Add(Me.Label19)
        Me.panel_MedicaidOptions.Controls.Add(Me.txt_MediDrop)
        Me.panel_MedicaidOptions.Controls.Add(Me.Label13)
        Me.panel_MedicaidOptions.Controls.Add(Me.Label14)
        Me.panel_MedicaidOptions.Controls.Add(Me.txt_MediPassword)
        Me.panel_MedicaidOptions.Controls.Add(Me.Label15)
        Me.panel_MedicaidOptions.Controls.Add(Me.txt_MediOperator)
        Me.panel_MedicaidOptions.Controls.Add(Me.Label11)
        Me.panel_MedicaidOptions.Controls.Add(Me.txt_MediServer)
        Me.panel_MedicaidOptions.Controls.Add(Me.Label10)
        Me.panel_MedicaidOptions.Controls.Add(Me.txt_MediDirectory)
        Me.panel_MedicaidOptions.Location = New System.Drawing.Point(3, 62)
        Me.panel_MedicaidOptions.Name = "panel_MedicaidOptions"
        Me.panel_MedicaidOptions.Size = New System.Drawing.Size(148, 96)
        Me.panel_MedicaidOptions.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(7, 44)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(169, 13)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "Drop Case Directory"
        '
        'txt_MediDrop
        '
        Me.txt_MediDrop.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "MediDropDirectory", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediDrop.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediDrop.Location = New System.Drawing.Point(7, 60)
        Me.txt_MediDrop.MaxLength = 40
        Me.txt_MediDrop.Name = "txt_MediDrop"
        Me.txt_MediDrop.Size = New System.Drawing.Size(246, 20)
        Me.txt_MediDrop.TabIndex = 63
        Me.txt_MediDrop.Text = Global.Phoenix___Server.My.MySettings.Default.MediDropDirectory
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(95, 140)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(160, 56)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Operator ID and Password are case sensitive."
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 164)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 13)
        Me.Label14.TabIndex = 60
        Me.Label14.Text = "Password"
        '
        'txt_MediPassword
        '
        Me.txt_MediPassword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "MediPassword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediPassword.Location = New System.Drawing.Point(7, 180)
        Me.txt_MediPassword.MaxLength = 9
        Me.txt_MediPassword.Name = "txt_MediPassword"
        Me.txt_MediPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_MediPassword.Size = New System.Drawing.Size(72, 20)
        Me.txt_MediPassword.TabIndex = 61
        Me.txt_MediPassword.Text = Global.Phoenix___Server.My.MySettings.Default.MediPassword
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 124)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "Operator ID"
        '
        'txt_MediOperator
        '
        Me.txt_MediOperator.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "MediOperator", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediOperator.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediOperator.Location = New System.Drawing.Point(7, 140)
        Me.txt_MediOperator.MaxLength = 7
        Me.txt_MediOperator.Name = "txt_MediOperator"
        Me.txt_MediOperator.Size = New System.Drawing.Size(72, 20)
        Me.txt_MediOperator.TabIndex = 59
        Me.txt_MediOperator.Text = Global.Phoenix___Server.My.MySettings.Default.MediOperator
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "Server Path"
        '
        'txt_MediServer
        '
        Me.txt_MediServer.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "ServerAddress", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediServer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediServer.Location = New System.Drawing.Point(7, 99)
        Me.txt_MediServer.MaxLength = 20
        Me.txt_MediServer.Name = "txt_MediServer"
        Me.txt_MediServer.Size = New System.Drawing.Size(130, 20)
        Me.txt_MediServer.TabIndex = 56
        Me.txt_MediServer.Text = Global.Phoenix___Server.My.MySettings.Default.ServerAddress
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 16)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Text File Directory"
        '
        'txt_MediDirectory
        '
        Me.txt_MediDirectory.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "MediDirectory", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediDirectory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediDirectory.Location = New System.Drawing.Point(7, 21)
        Me.txt_MediDirectory.MaxLength = 40
        Me.txt_MediDirectory.Name = "txt_MediDirectory"
        Me.txt_MediDirectory.Size = New System.Drawing.Size(246, 20)
        Me.txt_MediDirectory.TabIndex = 54
        Me.txt_MediDirectory.Text = Global.Phoenix___Server.My.MySettings.Default.MediDirectory
        '
        'panel_GUMPUpdate
        '
        Me.panel_GUMPUpdate.Controls.Add(Me.GroupBox1)
        Me.panel_GUMPUpdate.Controls.Add(Me.Label24)
        Me.panel_GUMPUpdate.Controls.Add(Me.txt_GUMPFileLocation)
        Me.panel_GUMPUpdate.Location = New System.Drawing.Point(468, 267)
        Me.panel_GUMPUpdate.Name = "panel_GUMPUpdate"
        Me.panel_GUMPUpdate.Size = New System.Drawing.Size(96, 33)
        Me.panel_GUMPUpdate.TabIndex = 28
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_ForceGUMP)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(137, 54)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Force File Creation"
        '
        'btn_ForceGUMP
        '
        Me.btn_ForceGUMP.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ForceGUMP.Location = New System.Drawing.Point(12, 19)
        Me.btn_ForceGUMP.Name = "btn_ForceGUMP"
        Me.btn_ForceGUMP.Size = New System.Drawing.Size(112, 23)
        Me.btn_ForceGUMP.TabIndex = 0
        Me.btn_ForceGUMP.Text = "Run GUMP Update"
        Me.btn_ForceGUMP.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(9, 7)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 16)
        Me.Label24.TabIndex = 57
        Me.Label24.Text = "Send File Location"
        '
        'txt_GUMPFileLocation
        '
        Me.txt_GUMPFileLocation.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Server.My.MySettings.Default, "GUMPFileDirectory", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_GUMPFileLocation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_GUMPFileLocation.Location = New System.Drawing.Point(12, 24)
        Me.txt_GUMPFileLocation.MaxLength = 40
        Me.txt_GUMPFileLocation.Name = "txt_GUMPFileLocation"
        Me.txt_GUMPFileLocation.Size = New System.Drawing.Size(246, 20)
        Me.txt_GUMPFileLocation.TabIndex = 56
        Me.txt_GUMPFileLocation.Text = Global.Phoenix___Server.My.MySettings.Default.GUMPFileDirectory
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(257, 10)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(213, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Status:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(94, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Stop"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Green
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(13, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Start"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox3
        '
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Location = New System.Drawing.Point(0, 0)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(369, 326)
        Me.TextBox3.TabIndex = 0
        '
        'BGW_BlinkSubmit
        '
        Me.BGW_BlinkSubmit.WorkerReportsProgress = True
        Me.BGW_BlinkSubmit.WorkerSupportsCancellation = True
        '
        'BGW_IMPSProcessing
        '
        Me.BGW_IMPSProcessing.WorkerReportsProgress = True
        Me.BGW_IMPSProcessing.WorkerSupportsCancellation = True
        '
        'BGW_IMPSScanDirectory
        '
        Me.BGW_IMPSScanDirectory.WorkerReportsProgress = True
        Me.BGW_IMPSScanDirectory.WorkerSupportsCancellation = True
        '
        'BGW_MediScanDirectory
        '
        Me.BGW_MediScanDirectory.WorkerReportsProgress = True
        Me.BGW_MediScanDirectory.WorkerSupportsCancellation = True
        '
        'BGW_CheckServer
        '
        Me.BGW_CheckServer.WorkerReportsProgress = True
        Me.BGW_CheckServer.WorkerSupportsCancellation = True
        '
        'BGW_RetryServer
        '
        Me.BGW_RetryServer.WorkerReportsProgress = True
        Me.BGW_RetryServer.WorkerSupportsCancellation = True
        '
        'CaseNumberDataGridViewTextBoxColumn
        '
        Me.CaseNumberDataGridViewTextBoxColumn.DataPropertyName = "CaseNumber"
        Me.CaseNumberDataGridViewTextBoxColumn.HeaderText = "Case Number"
        Me.CaseNumberDataGridViewTextBoxColumn.Name = "CaseNumberDataGridViewTextBoxColumn"
        '
        'PersonNumberDataGridViewTextBoxColumn
        '
        Me.PersonNumberDataGridViewTextBoxColumn.DataPropertyName = "PersonNumber"
        Me.PersonNumberDataGridViewTextBoxColumn.HeaderText = "Person Number"
        Me.PersonNumberDataGridViewTextBoxColumn.Name = "PersonNumberDataGridViewTextBoxColumn"
        '
        'CaseNumberDataGridViewTextBoxColumn1
        '
        Me.CaseNumberDataGridViewTextBoxColumn1.DataPropertyName = "CaseNumber"
        Me.CaseNumberDataGridViewTextBoxColumn1.HeaderText = "Case Number"
        Me.CaseNumberDataGridViewTextBoxColumn1.Name = "CaseNumberDataGridViewTextBoxColumn1"
        Me.CaseNumberDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'BATCHNUMBER
        '
        Me.BATCHNUMBER.DataPropertyName = "BATCHNUMBER"
        Me.BATCHNUMBER.HeaderText = "Batch Number"
        Me.BATCHNUMBER.Name = "BATCHNUMBER"
        Me.BATCHNUMBER.ReadOnly = True
        '
        'CaseNumberDataGridViewTextBoxColumn2
        '
        Me.CaseNumberDataGridViewTextBoxColumn2.DataPropertyName = "CaseNumber"
        Me.CaseNumberDataGridViewTextBoxColumn2.HeaderText = "CaseNumber"
        Me.CaseNumberDataGridViewTextBoxColumn2.Name = "CaseNumberDataGridViewTextBoxColumn2"
        '
        'BGW_GUMPUpdate
        '
        Me.BGW_GUMPUpdate.WorkerReportsProgress = True
        Me.BGW_GUMPUpdate.WorkerSupportsCancellation = True
        '
        'MedicaidDataSet
        '
        Me.MedicaidDataSet.DataSetName = "MedicaidDataSet"
        Me.MedicaidDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IMPSInformationBindingSource
        '
        Me.IMPSInformationBindingSource.DataMember = "IMPSInformation"
        Me.IMPSInformationBindingSource.DataSource = Me.PhoenixCaseDataDataSet
        '
        'IMPSInformationTableAdapter
        '
        Me.IMPSInformationTableAdapter.ClearBeforeFill = True
        '
        'TransactionLogTableAdapter
        '
        Me.TransactionLogTableAdapter.ClearBeforeFill = True
        '
        'FAMISCaseInformationTableAdapter
        '
        Me.FAMISCaseInformationTableAdapter.ClearBeforeFill = True
        '
        'TransactionLogBindingSource
        '
        Me.TransactionLogBindingSource.DataMember = "TransactionLog"
        Me.TransactionLogBindingSource.DataSource = Me.PhoenixCaseDataDataSet
        '
        'BGW_ClientData
        '
        Me.BGW_ClientData.WorkerReportsProgress = True
        Me.BGW_ClientData.WorkerSupportsCancellation = True
        '
        'CRLFileDialog
        '
        Me.CRLFileDialog.InitialDirectory = "C:\"
        Me.CRLFileDialog.Title = "CRL File Location"
        '
        'BGW_Test
        '
        '
        'ControlScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BackgroundImage = Global.Phoenix___Server.My.Resources.Resources.RedBG1
        Me.ClientSize = New System.Drawing.Size(814, 350)
        Me.Controls.Add(Me.MainPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ControlScreen"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Phoenix - Administration"
        Me.MainPanel.Panel1.ResumeLayout(False)
        Me.MainPanel.Panel2.ResumeLayout(False)
        Me.MainPanel.ResumeLayout(False)
        Me.ControlPanel.Panel1.ResumeLayout(False)
        Me.ControlPanel.Panel1.PerformLayout()
        Me.ControlPanel.Panel2.ResumeLayout(False)
        Me.ControlPanel.Panel2.PerformLayout()
        Me.ControlPanel.ResumeLayout(False)
        Me.stripMenu.ResumeLayout(False)
        Me.stripMenu.PerformLayout()
        Me.panel_Main.ResumeLayout(False)
        Me.panel_Main.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_Users, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_Reports.ResumeLayout(False)
        CType(Me.grid_CaseView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAMISCaseInformationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PhoenixCaseDataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_IMPSOptions.ResumeLayout(False)
        Me.panel_IMPSOptions.PerformLayout()
        Me.panel_MedicaidOptions.ResumeLayout(False)
        Me.panel_MedicaidOptions.PerformLayout()
        Me.panel_GUMPUpdate.ResumeLayout(False)
        Me.panel_GUMPUpdate.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.MedicaidDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMPSInformationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainPanel As System.Windows.Forms.SplitContainer
    Friend WithEvents treeMenu As System.Windows.Forms.TreeView
    Friend WithEvents treeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ControlPanel As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_IMPSInfo As System.Windows.Forms.RichTextBox
    Friend WithEvents grid_CaseView As System.Windows.Forms.DataGridView
    Friend WithEvents txt_MedicaidInfo As System.Windows.Forms.RichTextBox
    Friend WithEvents txt_IMPSLog As System.Windows.Forms.RichTextBox
    Friend WithEvents txt_MedicaidLog As System.Windows.Forms.RichTextBox
    Friend WithEvents stripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents panel_IMPSOptions As System.Windows.Forms.Panel
    Friend WithEvents lbl_Note2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Note1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_IMPSBatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_IMPSBatchPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_IMPSDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_IMPSPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_IMPSOperator As System.Windows.Forms.TextBox
    Friend WithEvents DateChoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents panel_MedicaidOptions As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_MediServer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_MediDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_IMPSServer As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_MediPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_MediOperator As System.Windows.Forms.TextBox
    Friend WithEvents panel_Main As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_IMPSFailed As System.Windows.Forms.TextBox
    Friend WithEvents txt_IMPSSuccess As System.Windows.Forms.TextBox
    Friend WithEvents txt_IMPSTotal As System.Windows.Forms.TextBox
    Friend WithEvents txt_MedicaidFailed As System.Windows.Forms.TextBox
    Friend WithEvents txt_MedicaidSuccess As System.Windows.Forms.TextBox
    Friend WithEvents txt_MedicaidTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_OptionError As System.Windows.Forms.Label
    Friend WithEvents BGW_BlinkSubmit As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_MediDrop As System.Windows.Forms.TextBox
    Friend WithEvents BGW_IMPSProcessing As System.ComponentModel.BackgroundWorker
    Friend WithEvents BGW_IMPSScanDirectory As System.ComponentModel.BackgroundWorker
    Friend WithEvents BGW_MediScanDirectory As System.ComponentModel.BackgroundWorker
    Friend WithEvents PhoenixCaseDataDataSet As Phoenix___Server.PhoenixCaseDataDataSet
    Friend WithEvents IMPSInformationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IMPSInformationTableAdapter As Phoenix___Server.PhoenixCaseDataDataSetTableAdapters.IMPSInformationTableAdapter
    Friend WithEvents BGW_CheckServer As System.ComponentModel.BackgroundWorker
    Friend WithEvents BGW_RetryServer As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbl_Server As System.Windows.Forms.Label
    Friend WithEvents MedicaidDataSet As Phoenix___Server.MedicaidDataSet
    Friend WithEvents CaseNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FAMISCaseInformationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CaseNumberDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BATCHNUMBER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseNumberDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextFile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaseNumberDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ABDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AFDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AGDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AHDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AIDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AJDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AKDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AMDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ANDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DATEENTEREDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents P03DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents P05DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPERATORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents P09DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BATCHNUMBERDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents P10DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WWDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents tool_Run As System.Windows.Forms.ToolStripButton
    Friend WithEvents tool_Stop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tool_Submit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmb_LogFiles As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tool_Print As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_MedicaidHold As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TransactionLogTableAdapter As Phoenix___Server.PhoenixCaseDataDataSetTableAdapters.TransactionLogTableAdapter
    Friend WithEvents FAMISCaseInformationTableAdapter As Phoenix___Server.PhoenixCaseDataDataSetTableAdapters.FAMISCaseInformationTableAdapter
    Friend WithEvents TransactionLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents panel_Reports As System.Windows.Forms.Panel
    Friend WithEvents btn_All As System.Windows.Forms.Button
    Friend WithEvents btn_Redet As System.Windows.Forms.Button
    Friend WithEvents btn_Drop As System.Windows.Forms.Button
    Friend WithEvents btn_Success As System.Windows.Forms.Button
    Friend WithEvents grid_Users As System.Windows.Forms.DataGridView
    Friend WithEvents User As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CasesDone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckInTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Version As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_VersionNumber As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents BGW_GUMPUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents txt_UpdateTime As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_UpdateCases As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents UpdateProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents panel_GUMPUpdate As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btn_ForceGUMP As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_GUMPFileLocation As System.Windows.Forms.TextBox
    Friend WithEvents BGW_ClientData As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_ClientData As System.Windows.Forms.Button
    Friend WithEvents ClientProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents txt_ClientInfo As System.Windows.Forms.TextBox
    Friend WithEvents CRLFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txt_ClientTime As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_ClientCases As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents BGW_Test As System.ComponentModel.BackgroundWorker
End Class
