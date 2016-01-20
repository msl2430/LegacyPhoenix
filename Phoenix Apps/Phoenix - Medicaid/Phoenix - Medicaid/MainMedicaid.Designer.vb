<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMedicaid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMedicaid))
        Me.txt_Info = New System.Windows.Forms.RichTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btn_Start = New System.Windows.Forms.Button
        Me.btn_Stop = New System.Windows.Forms.Button
        Me.txt_NumCases = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.menu_Main = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.menu_Print = New System.Windows.Forms.ToolStripMenuItem
        Me.menu_CoverSheet = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.menu_PrintAll = New System.Windows.Forms.ToolStripMenuItem
        Me.menu_PrintSuccess = New System.Windows.Forms.ToolStripMenuItem
        Me.menu_PrintDrop = New System.Windows.Forms.ToolStripMenuItem
        Me.menu_Redet = New System.Windows.Forms.ToolStripMenuItem
        Me.menu_Options = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.menu_Exit = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.menu_About = New System.Windows.Forms.ToolStripMenuItem
        Me.BGW_MediScanDirectory = New System.ComponentModel.BackgroundWorker
        Me.BGW_CheckServer = New System.ComponentModel.BackgroundWorker
        Me.BGW_RetryServer = New System.ComponentModel.BackgroundWorker
        Me.BGW_NumCases = New System.ComponentModel.BackgroundWorker
        Me.BGW_PrintReport = New System.ComponentModel.BackgroundWorker
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menu_Main.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_Info
        '
        Me.txt_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Info.Location = New System.Drawing.Point(3, 26)
        Me.txt_Info.Name = "txt_Info"
        Me.txt_Info.ReadOnly = True
        Me.txt_Info.Size = New System.Drawing.Size(513, 220)
        Me.txt_Info.TabIndex = 0
        Me.txt_Info.TabStop = False
        Me.txt_Info.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_Start)
        Me.GroupBox1.Controls.Add(Me.btn_Stop)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 252)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 53)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Main Controls"
        '
        'btn_Start
        '
        Me.btn_Start.BackColor = System.Drawing.Color.Green
        Me.btn_Start.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Start.Location = New System.Drawing.Point(9, 19)
        Me.btn_Start.Name = "btn_Start"
        Me.btn_Start.Size = New System.Drawing.Size(92, 28)
        Me.btn_Start.TabIndex = 0
        Me.btn_Start.Text = "Start"
        Me.btn_Start.UseVisualStyleBackColor = False
        '
        'btn_Stop
        '
        Me.btn_Stop.BackColor = System.Drawing.Color.Red
        Me.btn_Stop.Enabled = False
        Me.btn_Stop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Stop.Location = New System.Drawing.Point(107, 20)
        Me.btn_Stop.Name = "btn_Stop"
        Me.btn_Stop.Size = New System.Drawing.Size(92, 27)
        Me.btn_Stop.TabIndex = 1
        Me.btn_Stop.Text = "Stop"
        Me.btn_Stop.UseVisualStyleBackColor = False
        '
        'txt_NumCases
        '
        Me.txt_NumCases.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NumCases.Location = New System.Drawing.Point(281, 274)
        Me.txt_NumCases.Name = "txt_NumCases"
        Me.txt_NumCases.ReadOnly = True
        Me.txt_NumCases.Size = New System.Drawing.Size(45, 21)
        Me.txt_NumCases.TabIndex = 2
        Me.txt_NumCases.TabStop = False
        Me.txt_NumCases.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Phoenix___Medicaid.My.Resources.Resources.RedBirdLogo
        Me.PictureBox1.Location = New System.Drawing.Point(416, 252)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(223, 267)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Number Of Cases"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'menu_Main
        '
        Me.menu_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.menu_Main.Location = New System.Drawing.Point(0, 0)
        Me.menu_Main.Name = "menu_Main"
        Me.menu_Main.Size = New System.Drawing.Size(522, 24)
        Me.menu_Main.TabIndex = 5
        Me.menu_Main.Text = "Main Menu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_Print, Me.menu_Options, Me.ToolStripSeparator1, Me.menu_Exit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'menu_Print
        '
        Me.menu_Print.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_CoverSheet, Me.ToolStripSeparator2, Me.menu_PrintAll, Me.menu_PrintSuccess, Me.menu_PrintDrop, Me.menu_Redet})
        Me.menu_Print.Name = "menu_Print"
        Me.menu_Print.Size = New System.Drawing.Size(132, 22)
        Me.menu_Print.Text = "Print Cases"
        '
        'menu_CoverSheet
        '
        Me.menu_CoverSheet.Name = "menu_CoverSheet"
        Me.menu_CoverSheet.Size = New System.Drawing.Size(156, 22)
        Me.menu_CoverSheet.Text = "Cover Sheets"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(153, 6)
        '
        'menu_PrintAll
        '
        Me.menu_PrintAll.Name = "menu_PrintAll"
        Me.menu_PrintAll.Size = New System.Drawing.Size(156, 22)
        Me.menu_PrintAll.Text = "All"
        '
        'menu_PrintSuccess
        '
        Me.menu_PrintSuccess.Name = "menu_PrintSuccess"
        Me.menu_PrintSuccess.Size = New System.Drawing.Size(156, 22)
        Me.menu_PrintSuccess.Text = "Success"
        '
        'menu_PrintDrop
        '
        Me.menu_PrintDrop.Name = "menu_PrintDrop"
        Me.menu_PrintDrop.Size = New System.Drawing.Size(156, 22)
        Me.menu_PrintDrop.Text = "Dropped"
        '
        'menu_Redet
        '
        Me.menu_Redet.Name = "menu_Redet"
        Me.menu_Redet.Size = New System.Drawing.Size(156, 22)
        Me.menu_Redet.Text = "Redet Deletions"
        '
        'menu_Options
        '
        Me.menu_Options.Name = "menu_Options"
        Me.menu_Options.Size = New System.Drawing.Size(132, 22)
        Me.menu_Options.Text = "Options"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(129, 6)
        '
        'menu_Exit
        '
        Me.menu_Exit.Name = "menu_Exit"
        Me.menu_Exit.Size = New System.Drawing.Size(132, 22)
        Me.menu_Exit.Text = "Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_About})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'menu_About
        '
        Me.menu_About.Name = "menu_About"
        Me.menu_About.Size = New System.Drawing.Size(273, 22)
        Me.menu_About.Text = "About Phoenix Medicaid Processing..."
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
        'BGW_NumCases
        '
        Me.BGW_NumCases.WorkerReportsProgress = True
        '
        'BGW_PrintReport
        '
        Me.BGW_PrintReport.WorkerReportsProgress = True
        Me.BGW_PrintReport.WorkerSupportsCancellation = True
        '
        'MainMedicaid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Phoenix___Medicaid.My.Resources.Resources.RedBG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(522, 308)
        Me.Controls.Add(Me.txt_NumCases)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_Info)
        Me.Controls.Add(Me.menu_Main)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menu_Main
        Me.MaximizeBox = False
        Me.Name = "MainMedicaid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Phoenix - Medicaid Processing"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menu_Main.ResumeLayout(False)
        Me.menu_Main.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Info As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_Start As System.Windows.Forms.Button
    Friend WithEvents btn_Stop As System.Windows.Forms.Button
    Friend WithEvents txt_NumCases As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents menu_Main As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BGW_MediScanDirectory As System.ComponentModel.BackgroundWorker
    Friend WithEvents BGW_CheckServer As System.ComponentModel.BackgroundWorker
    Friend WithEvents BGW_RetryServer As System.ComponentModel.BackgroundWorker
    Friend WithEvents BGW_NumCases As System.ComponentModel.BackgroundWorker
    Friend WithEvents menu_Options As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menu_Print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_PrintAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_PrintSuccess As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_PrintDrop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BGW_PrintReport As System.ComponentModel.BackgroundWorker
    Friend WithEvents menu_Redet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_CoverSheet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator

End Class
