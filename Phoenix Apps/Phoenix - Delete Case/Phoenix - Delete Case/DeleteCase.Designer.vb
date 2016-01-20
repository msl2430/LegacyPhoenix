<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeleteCase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeleteCase))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_CaseNumber = New System.Windows.Forms.TextBox()
        Me.btn_Submit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Helvetica Neue", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Case Number:"
        '
        'txt_CaseNumber
        '
        Me.txt_CaseNumber.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.txt_CaseNumber.Location = New System.Drawing.Point(108, 7)
        Me.txt_CaseNumber.MaxLength = 10
        Me.txt_CaseNumber.Name = "txt_CaseNumber"
        Me.txt_CaseNumber.Size = New System.Drawing.Size(98, 22)
        Me.txt_CaseNumber.TabIndex = 1
        Me.txt_CaseNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_Submit
        '
        Me.btn_Submit.Font = New System.Drawing.Font("Helvetica Neue", 9.0!)
        Me.btn_Submit.Location = New System.Drawing.Point(125, 35)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(81, 23)
        Me.btn_Submit.TabIndex = 2
        Me.btn_Submit.Text = "&Submit"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'DeleteCase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Phoenix___Delete_Case.My.Resources.Resources.mainbg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(215, 62)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.txt_CaseNumber)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DeleteCase"
        Me.Text = "Phoenix - Delete Case"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_CaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents btn_Submit As System.Windows.Forms.Button

End Class
