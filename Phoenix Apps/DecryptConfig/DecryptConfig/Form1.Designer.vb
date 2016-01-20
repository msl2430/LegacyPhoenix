<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DecryptForm
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
        Me.btn_Decrypt = New System.Windows.Forms.Button
        Me.DialogFile = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'btn_Decrypt
        '
        Me.btn_Decrypt.Location = New System.Drawing.Point(12, 12)
        Me.btn_Decrypt.Name = "btn_Decrypt"
        Me.btn_Decrypt.Size = New System.Drawing.Size(133, 23)
        Me.btn_Decrypt.TabIndex = 0
        Me.btn_Decrypt.Text = "Decrypt"
        Me.btn_Decrypt.UseVisualStyleBackColor = True
        '
        'DialogFile
        '
        Me.DialogFile.FileName = "phxConfig.dat"
        Me.DialogFile.InitialDirectory = "C:\Program Files\Phoenix\"
        '
        'DecryptForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(157, 50)
        Me.Controls.Add(Me.btn_Decrypt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DecryptForm"
        Me.Text = "Decrypt Config"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Decrypt As System.Windows.Forms.Button
    Friend WithEvents DialogFile As System.Windows.Forms.OpenFileDialog

End Class
