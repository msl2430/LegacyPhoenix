<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePassword))
        Me.txt_NewPW = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_ConfirmPW = New System.Windows.Forms.TextBox()
        Me.btn_Submit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_NewPW
        '
        Me.txt_NewPW.Font = New System.Drawing.Font("Helvetica Neue", 8.249999!)
        Me.txt_NewPW.Location = New System.Drawing.Point(137, 8)
        Me.txt_NewPW.MaxLength = 6
        Me.txt_NewPW.Name = "txt_NewPW"
        Me.txt_NewPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_NewPW.Size = New System.Drawing.Size(100, 21)
        Me.txt_NewPW.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Helvetica Neue", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(31, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "New Password:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Helvetica Neue", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Confirm Password:"
        '
        'txt_ConfirmPW
        '
        Me.txt_ConfirmPW.Font = New System.Drawing.Font("Helvetica Neue", 8.249999!)
        Me.txt_ConfirmPW.Location = New System.Drawing.Point(137, 34)
        Me.txt_ConfirmPW.MaxLength = 6
        Me.txt_ConfirmPW.Name = "txt_ConfirmPW"
        Me.txt_ConfirmPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_ConfirmPW.Size = New System.Drawing.Size(100, 21)
        Me.txt_ConfirmPW.TabIndex = 2
        '
        'btn_Submit
        '
        Me.btn_Submit.Font = New System.Drawing.Font("Helvetica Neue", 9.75!)
        Me.btn_Submit.Location = New System.Drawing.Point(162, 65)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(75, 23)
        Me.btn_Submit.TabIndex = 4
        Me.btn_Submit.Text = "&Submit"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'ChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Phoenix___Auto_IRF_Processing.My.Resources.Resources.mainbg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(245, 99)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_ConfirmPW)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_NewPW)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_NewPW As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_ConfirmPW As System.Windows.Forms.TextBox
    Friend WithEvents btn_Submit As System.Windows.Forms.Button
End Class
