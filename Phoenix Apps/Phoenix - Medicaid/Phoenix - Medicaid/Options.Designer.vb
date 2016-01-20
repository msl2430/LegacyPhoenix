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
        Me.btn_Ok = New System.Windows.Forms.Button
        Me.btn_Cancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_FamilyHold = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label19.Location = New System.Drawing.Point(10, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(169, 13)
        Me.Label19.TabIndex = 75
        Me.Label19.Text = "Case Hold Directory"
        '
        'txt_MediDrop
        '
        Me.txt_MediDrop.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Medicaid.My.MySettings.Default, "MediHoldDirectory", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediDrop.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediDrop.Location = New System.Drawing.Point(10, 64)
        Me.txt_MediDrop.MaxLength = 40
        Me.txt_MediDrop.Name = "txt_MediDrop"
        Me.txt_MediDrop.Size = New System.Drawing.Size(246, 20)
        Me.txt_MediDrop.TabIndex = 1
        Me.txt_MediDrop.Text = Global.Phoenix___Medicaid.My.MySettings.Default.MediHoldDirectory
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label13.Location = New System.Drawing.Point(98, 183)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(160, 56)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "Operator ID and Password are case sensitive."
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label14.Location = New System.Drawing.Point(10, 207)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 13)
        Me.Label14.TabIndex = 71
        Me.Label14.Text = "Password"
        '
        'txt_MediPassword
        '
        Me.txt_MediPassword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Medicaid.My.MySettings.Default, "MediPassword", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediPassword.Location = New System.Drawing.Point(10, 223)
        Me.txt_MediPassword.MaxLength = 9
        Me.txt_MediPassword.Name = "txt_MediPassword"
        Me.txt_MediPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_MediPassword.Size = New System.Drawing.Size(72, 20)
        Me.txt_MediPassword.TabIndex = 4
        Me.txt_MediPassword.Text = Global.Phoenix___Medicaid.My.MySettings.Default.MediPassword
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label15.Location = New System.Drawing.Point(10, 167)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Operator ID"
        '
        'txt_MediOperator
        '
        Me.txt_MediOperator.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Medicaid.My.MySettings.Default, "MediOperator", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediOperator.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediOperator.Location = New System.Drawing.Point(10, 183)
        Me.txt_MediOperator.MaxLength = 7
        Me.txt_MediOperator.Name = "txt_MediOperator"
        Me.txt_MediOperator.Size = New System.Drawing.Size(72, 20)
        Me.txt_MediOperator.TabIndex = 3
        Me.txt_MediOperator.Text = Global.Phoenix___Medicaid.My.MySettings.Default.MediOperator
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label11.Location = New System.Drawing.Point(10, 126)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 16)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Server Path"
        '
        'txt_MediServer
        '
        Me.txt_MediServer.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Medicaid.My.MySettings.Default, "ServerAddress", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediServer.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediServer.Location = New System.Drawing.Point(10, 142)
        Me.txt_MediServer.MaxLength = 20
        Me.txt_MediServer.Name = "txt_MediServer"
        Me.txt_MediServer.Size = New System.Drawing.Size(130, 20)
        Me.txt_MediServer.TabIndex = 2
        Me.txt_MediServer.Text = Global.Phoenix___Medicaid.My.MySettings.Default.ServerAddress
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label10.Location = New System.Drawing.Point(10, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 16)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Text File Directory"
        '
        'txt_MediDirectory
        '
        Me.txt_MediDirectory.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Medicaid.My.MySettings.Default, "MediDirectory", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_MediDirectory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MediDirectory.Location = New System.Drawing.Point(10, 25)
        Me.txt_MediDirectory.MaxLength = 40
        Me.txt_MediDirectory.Name = "txt_MediDirectory"
        Me.txt_MediDirectory.Size = New System.Drawing.Size(246, 20)
        Me.txt_MediDirectory.TabIndex = 0
        Me.txt_MediDirectory.Text = Global.Phoenix___Medicaid.My.MySettings.Default.MediDirectory
        '
        'btn_Ok
        '
        Me.btn_Ok.Location = New System.Drawing.Point(100, 258)
        Me.btn_Ok.Name = "btn_Ok"
        Me.btn_Ok.Size = New System.Drawing.Size(75, 23)
        Me.btn_Ok.TabIndex = 5
        Me.btn_Ok.Text = "OK"
        Me.btn_Ok.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Location = New System.Drawing.Point(181, 258)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancel.TabIndex = 6
        Me.btn_Cancel.Text = "Cancel"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label1.Location = New System.Drawing.Point(10, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Family Hold Directory"
        '
        'txt_FamilyHold
        '
        Me.txt_FamilyHold.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.Phoenix___Medicaid.My.MySettings.Default, "MediFamilyDirectory", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txt_FamilyHold.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FamilyHold.Location = New System.Drawing.Point(10, 105)
        Me.txt_FamilyHold.MaxLength = 40
        Me.txt_FamilyHold.Name = "txt_FamilyHold"
        Me.txt_FamilyHold.Size = New System.Drawing.Size(246, 20)
        Me.txt_FamilyHold.TabIndex = 76
        Me.txt_FamilyHold.Text = Global.Phoenix___Medicaid.My.MySettings.Default.MediFamilyDirectory
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Phoenix___Medicaid.My.Resources.Resources.RedBG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(263, 284)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_FamilyHold)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Ok)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_MediDrop)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_MediPassword)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txt_MediOperator)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_MediServer)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_MediDirectory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Phoenix - Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_MediDrop As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_MediPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_MediOperator As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_MediServer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_MediDirectory As System.Windows.Forms.TextBox
    Friend WithEvents btn_Ok As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_FamilyHold As System.Windows.Forms.TextBox
End Class
