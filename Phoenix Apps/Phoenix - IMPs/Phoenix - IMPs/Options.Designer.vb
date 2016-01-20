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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Server = New System.Windows.Forms.TextBox()
        Me.txt_FAMISUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_FAMISPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_BatchNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_Directory = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_Submit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Address:"
        '
        'txt_Server
        '
        Me.txt_Server.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_Server.Location = New System.Drawing.Point(117, 7)
        Me.txt_Server.MaxLength = 15
        Me.txt_Server.Name = "txt_Server"
        Me.txt_Server.Size = New System.Drawing.Size(91, 22)
        Me.txt_Server.TabIndex = 1
        '
        'txt_FAMISUser
        '
        Me.txt_FAMISUser.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_FAMISUser.Location = New System.Drawing.Point(117, 41)
        Me.txt_FAMISUser.MaxLength = 6
        Me.txt_FAMISUser.Name = "txt_FAMISUser"
        Me.txt_FAMISUser.Size = New System.Drawing.Size(66, 22)
        Me.txt_FAMISUser.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(37, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FAMIS User:"
        '
        'txt_FAMISPassword
        '
        Me.txt_FAMISPassword.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_FAMISPassword.Location = New System.Drawing.Point(117, 67)
        Me.txt_FAMISPassword.MaxLength = 6
        Me.txt_FAMISPassword.Name = "txt_FAMISPassword"
        Me.txt_FAMISPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_FAMISPassword.Size = New System.Drawing.Size(66, 22)
        Me.txt_FAMISPassword.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(6, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "FAMIS Password:"
        '
        'txt_BatchNumber
        '
        Me.txt_BatchNumber.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_BatchNumber.Location = New System.Drawing.Point(117, 102)
        Me.txt_BatchNumber.MaxLength = 7
        Me.txt_BatchNumber.Name = "txt_BatchNumber"
        Me.txt_BatchNumber.Size = New System.Drawing.Size(66, 22)
        Me.txt_BatchNumber.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(20, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Batch Number:"
        '
        'txt_Directory
        '
        Me.txt_Directory.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_Directory.Location = New System.Drawing.Point(117, 135)
        Me.txt_Directory.MaxLength = 255
        Me.txt_Directory.Name = "txt_Directory"
        Me.txt_Directory.Size = New System.Drawing.Size(160, 22)
        Me.txt_Directory.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(18, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "IMPs Directory:"
        '
        'btn_Submit
        '
        Me.btn_Submit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Submit.Location = New System.Drawing.Point(202, 173)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(75, 23)
        Me.btn_Submit.TabIndex = 10
        Me.btn_Submit.Text = "&Submit"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(285, 200)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.txt_Directory)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_BatchNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_FAMISPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_FAMISUser)
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Server As System.Windows.Forms.TextBox
    Friend WithEvents txt_FAMISUser As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_FAMISPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_BatchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_Directory As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_Submit As System.Windows.Forms.Button
End Class
