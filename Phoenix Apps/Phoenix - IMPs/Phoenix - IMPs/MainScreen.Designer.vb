<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        Me.btn_Start = New System.Windows.Forms.Button()
        Me.btn_Stop = New System.Windows.Forms.Button()
        Me.txt_Info = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Status = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Start = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Stop = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menu_Options = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.bgw_ScanDirectory = New System.ComponentModel.BackgroundWorker()
        Me.bgw_CheckServer = New System.ComponentModel.BackgroundWorker()
        Me.bgw_RetryServer = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Start
        '
        Me.btn_Start.BackColor = System.Drawing.Color.Green
        Me.btn_Start.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Start.Location = New System.Drawing.Point(12, 36)
        Me.btn_Start.Name = "btn_Start"
        Me.btn_Start.Size = New System.Drawing.Size(75, 23)
        Me.btn_Start.TabIndex = 0
        Me.btn_Start.Text = "&Start"
        Me.btn_Start.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Start.UseVisualStyleBackColor = False
        '
        'btn_Stop
        '
        Me.btn_Stop.BackColor = System.Drawing.Color.Red
        Me.btn_Stop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Stop.Location = New System.Drawing.Point(93, 36)
        Me.btn_Stop.Name = "btn_Stop"
        Me.btn_Stop.Size = New System.Drawing.Size(75, 23)
        Me.btn_Stop.TabIndex = 1
        Me.btn_Stop.Text = "S&top"
        Me.btn_Stop.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Stop.UseVisualStyleBackColor = False
        '
        'txt_Info
        '
        Me.txt_Info.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_Info.Location = New System.Drawing.Point(12, 65)
        Me.txt_Info.Name = "txt_Info"
        Me.txt_Info.Size = New System.Drawing.Size(360, 309)
        Me.txt_Info.TabIndex = 2
        Me.txt_Info.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(266, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Status"
        '
        'txt_Status
        '
        Me.txt_Status.BackColor = System.Drawing.Color.SteelBlue
        Me.txt_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Status.Location = New System.Drawing.Point(269, 39)
        Me.txt_Status.Name = "txt_Status"
        Me.txt_Status.ReadOnly = True
        Me.txt_Status.Size = New System.Drawing.Size(100, 20)
        Me.txt_Status.TabIndex = 4
        Me.txt_Status.Text = "Waiting..."
        Me.txt_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.menu_About})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(384, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_Start, Me.menu_Stop, Me.ToolStripSeparator1, Me.menu_Options, Me.ToolStripSeparator2, Me.menu_Exit})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'menu_Start
        '
        Me.menu_Start.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_Start.Name = "menu_Start"
        Me.menu_Start.Size = New System.Drawing.Size(152, 22)
        Me.menu_Start.Text = "&Start"
        '
        'menu_Stop
        '
        Me.menu_Stop.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_Stop.Name = "menu_Stop"
        Me.menu_Stop.Size = New System.Drawing.Size(152, 22)
        Me.menu_Stop.Text = "S&top"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'menu_Options
        '
        Me.menu_Options.Name = "menu_Options"
        Me.menu_Options.Size = New System.Drawing.Size(152, 22)
        Me.menu_Options.Text = "&Options"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'menu_Exit
        '
        Me.menu_Exit.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_Exit.Name = "menu_Exit"
        Me.menu_Exit.Size = New System.Drawing.Size(152, 22)
        Me.menu_Exit.Text = "E&xit"
        '
        'menu_About
        '
        Me.menu_About.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_About.Name = "menu_About"
        Me.menu_About.Size = New System.Drawing.Size(52, 20)
        Me.menu_About.Text = "&About"
        '
        'bgw_ScanDirectory
        '
        Me.bgw_ScanDirectory.WorkerReportsProgress = True
        Me.bgw_ScanDirectory.WorkerSupportsCancellation = True
        '
        'bgw_CheckServer
        '
        Me.bgw_CheckServer.WorkerReportsProgress = True
        Me.bgw_CheckServer.WorkerSupportsCancellation = True
        '
        'bgw_RetryServer
        '
        Me.bgw_RetryServer.WorkerReportsProgress = True
        Me.bgw_RetryServer.WorkerSupportsCancellation = True
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(384, 384)
        Me.Controls.Add(Me.txt_Status)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Info)
        Me.Controls.Add(Me.btn_Stop)
        Me.Controls.Add(Me.btn_Start)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainScreen"
        Me.Text = "Phoenix - IMPs"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Start As System.Windows.Forms.Button
    Friend WithEvents btn_Stop As System.Windows.Forms.Button
    Friend WithEvents txt_Info As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Status As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Start As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Stop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menu_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bgw_ScanDirectory As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgw_CheckServer As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgw_RetryServer As System.ComponentModel.BackgroundWorker
    Friend WithEvents menu_Options As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator

End Class
