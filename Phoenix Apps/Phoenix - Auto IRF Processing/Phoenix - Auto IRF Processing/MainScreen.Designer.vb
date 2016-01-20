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
        Me.BGW_ProcessCase = New System.ComponentModel.BackgroundWorker()
        Me.txt_Info = New System.Windows.Forms.RichTextBox()
        Me.btn_Start = New System.Windows.Forms.Button()
        Me.btn_Stop = New System.Windows.Forms.Button()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.txt_Status = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Start = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Stop = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Password = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BGW_ProcessCase
        '
        Me.BGW_ProcessCase.WorkerReportsProgress = True
        Me.BGW_ProcessCase.WorkerSupportsCancellation = True
        '
        'txt_Info
        '
        Me.txt_Info.BackColor = System.Drawing.SystemColors.Control
        Me.txt_Info.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_Info.Location = New System.Drawing.Point(12, 64)
        Me.txt_Info.Name = "txt_Info"
        Me.txt_Info.Size = New System.Drawing.Size(371, 290)
        Me.txt_Info.TabIndex = 0
        Me.txt_Info.Text = ""
        '
        'btn_Start
        '
        Me.btn_Start.BackColor = System.Drawing.Color.Green
        Me.btn_Start.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.btn_Start.Location = New System.Drawing.Point(12, 37)
        Me.btn_Start.Name = "btn_Start"
        Me.btn_Start.Size = New System.Drawing.Size(91, 23)
        Me.btn_Start.TabIndex = 1
        Me.btn_Start.Text = "&Start"
        Me.btn_Start.UseVisualStyleBackColor = False
        '
        'btn_Stop
        '
        Me.btn_Stop.BackColor = System.Drawing.Color.Red
        Me.btn_Stop.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.btn_Stop.Location = New System.Drawing.Point(109, 37)
        Me.btn_Stop.Name = "btn_Stop"
        Me.btn_Stop.Size = New System.Drawing.Size(91, 23)
        Me.btn_Stop.TabIndex = 2
        Me.btn_Stop.Text = "S&top"
        Me.btn_Stop.UseVisualStyleBackColor = False
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_Status.Location = New System.Drawing.Point(278, 25)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(42, 14)
        Me.lbl_Status.TabIndex = 8
        Me.lbl_Status.Text = "Status"
        '
        'txt_Status
        '
        Me.txt_Status.BackColor = System.Drawing.Color.SteelBlue
        Me.txt_Status.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Status.Location = New System.Drawing.Point(281, 39)
        Me.txt_Status.Name = "txt_Status"
        Me.txt_Status.ReadOnly = True
        Me.txt_Status.Size = New System.Drawing.Size(100, 20)
        Me.txt_Status.TabIndex = 7
        Me.txt_Status.TabStop = False
        Me.txt_Status.Text = "Waiting..."
        Me.txt_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(395, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_Start, Me.menu_Stop, Me.menu_Password, Me.ToolStripSeparator1, Me.menu_Exit})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'menu_Start
        '
        Me.menu_Start.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_Start.Name = "menu_Start"
        Me.menu_Start.Size = New System.Drawing.Size(176, 22)
        Me.menu_Start.Text = "&Start"
        '
        'menu_Stop
        '
        Me.menu_Stop.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_Stop.Name = "menu_Stop"
        Me.menu_Stop.Size = New System.Drawing.Size(176, 22)
        Me.menu_Stop.Text = "S&top"
        '
        'menu_Password
        '
        Me.menu_Password.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_Password.Name = "menu_Password"
        Me.menu_Password.Size = New System.Drawing.Size(176, 22)
        Me.menu_Password.Text = "Change &Password"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(173, 6)
        '
        'menu_Exit
        '
        Me.menu_Exit.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_Exit.Name = "menu_Exit"
        Me.menu_Exit.Size = New System.Drawing.Size(176, 22)
        Me.menu_Exit.Text = "&Exit"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_About})
        Me.AboutToolStripMenuItem.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'menu_About
        '
        Me.menu_About.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.menu_About.Name = "menu_About"
        Me.menu_About.Size = New System.Drawing.Size(228, 22)
        Me.menu_About.Text = "&About AutoIRF Processing..."
        '
        'PrintDoc
        '
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Phoenix___Auto_IRF_Processing.My.Resources.Resources.mainbg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(395, 365)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.txt_Status)
        Me.Controls.Add(Me.btn_Stop)
        Me.Controls.Add(Me.btn_Start)
        Me.Controls.Add(Me.txt_Info)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainScreen"
        Me.Text = "Phoenix - IRF"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BGW_ProcessCase As System.ComponentModel.BackgroundWorker
    Friend WithEvents txt_Info As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_Start As System.Windows.Forms.Button
    Friend WithEvents btn_Stop As System.Windows.Forms.Button
    Friend WithEvents lbl_Status As System.Windows.Forms.Label
    Friend WithEvents txt_Status As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Start As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Stop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Password As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument

End Class
