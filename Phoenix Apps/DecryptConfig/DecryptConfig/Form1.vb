Public Class DecryptForm

    Private Sub btn_Decrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Decrypt.Click
        Dim File_Decrypt As String
        If DialogFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            File_Decrypt = DialogFile.FileName
            DecryptFile(File_Decrypt, "C:\temp.txt", "PhOeNiX9")
            Dim ReadFile As New StreamReader("C:\temp.txt")
            MessageBox.Show(ReadFile.ReadToEnd)
            ReadFile.Close()
            File.Delete("C:\temp.txt")
        End If
    End Sub
End Class
