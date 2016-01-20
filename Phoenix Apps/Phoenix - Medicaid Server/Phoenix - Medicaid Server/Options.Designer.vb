<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.btn_Submit = New System.Windows.Forms.Button()
        Me.txt_Directory = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_MediPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_MediUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Server = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_DropDirectory = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_Submit
        '
        Me.btn_Submit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Submit.Location = New System.Drawing.Point(216, 159)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(75, 23)
        Me.btn_Submit.TabIndex = 21
        Me.btn_Submit.Text = "&Submit"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'txt_Directory
        '
        Me.txt_Directory.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_Directory.Location = New System.Drawing.Point(131, 103)
        Me.txt_Directory.MaxLength = 255
        Me.txt_Directory.Name = "txt_Directory"
        Me.txt_Directory.Size = New System.Drawing.Size(160, 22)
        Me.txt_Directory.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(44, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "File Directory:"
        '
        'txt_MediPassword
        '
        Me.txt_MediPassword.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_MediPassword.Location = New System.Drawing.Point(131, 67)
        Me.txt_MediPassword.MaxLength = 8
        Me.txt_MediPassword.Name = "txt_MediPassword"
        Me.txt_MediPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_MediPassword.Size = New System.Drawing.Size(78, 22)
        Me.txt_MediPassword.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(6, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Medicaid Password:"
        '
        'txt_MediUser
        '
        Me.txt_MediUser.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_MediUser.Location = New System.Drawing.Point(131, 41)
        Me.txt_MediUser.MaxLength = 7
        Me.txt_MediUser.Name = "txt_MediUser"
        Me.txt_MediUser.Size = New System.Drawing.Size(78, 22)
        Me.txt_MediUser.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(37, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Medicaid User:"
        '
        'txt_Server
        '
        Me.txt_Server.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_Server.Location = New System.Drawing.Point(131, 7)
        Me.txt_Server.MaxLength = 15
        Me.txt_Server.Name = "txt_Server"
        Me.txt_Server.Size = New System.Drawing.Size(91, 22)
        Me.txt_Server.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(29, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Server Address:"
        '
        'txt_DropDirectory
        '
        Me.txt_DropDirectory.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_DropDirectory.Location = New System.Drawing.Point(131, 131)
        Me.txt_DropDirectory.MaxLength = 255
        Me.txt_DropDirectory.Name = "txt_DropDirectory"
        Me.txt_DropDirectory.Size = New System.Drawing.Size(160, 22)
        Me.txt_DropDirectory.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(36, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 15)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Drop Directory:"
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(301, 191)
        Me.Controls.Add(Me.txt_DropDirectory)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.txt_Directory)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_MediPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_MediUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_Server)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Submit As System.Windows.Forms.Button
    Friend WithEvents txt_Directory As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_MediPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_MediUser As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_Server As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_DropDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
