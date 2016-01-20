Public Class Options

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_Server.Text = ServerAddress
        txt_BatchNumber.Text = BatchNumber
        txt_Directory.Text = FileDirectory
        txt_FAMISUser.Text = FAMISUser
        txt_FAMISPassword.Text = FAMISPassword
    End Sub

    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        ServerAddress = txt_Server.Text
        ConnectionString = "Data Source=" & ServerAddress & "\PHOENIX;Failover Partner=Phoenix_Mirror\PhoenixMirror;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password"
        BatchNumber = txt_BatchNumber.Text
        FileDirectory = txt_Directory.Text
        FAMISUser = txt_FAMISUser.Text
        FAMISPassword = txt_FAMISPassword.Text
        MainScreen.SetConfig()
        Me.Close()
    End Sub
End Class