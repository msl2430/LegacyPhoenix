Public Class ChangePassword

    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        If txt_ConfirmPW.Text = txt_NewPW.Text Then
            My.Settings.FAMISPassword = txt_NewPW.Text
            Me.Close()
        Else
            MessageBox.Show("Passwords must match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class