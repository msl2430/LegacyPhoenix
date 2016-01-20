Public Class Options

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_Server.Text = ServerAddress
        txt_Directory.Text = FileDirectory
        txt_DropDirectory.Text = DropDirectory
        txt_MediUser.Text = MediUser
        txt_MediPassword.Text = MediPassword
    End Sub

    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        ServerAddress = txt_Server.Text
        ConnectionString = "Data Source=" & ServerAddress & "\PHOENIX;Failover Partner=Phoenix_Mirror\PhoenixMirror;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password"
        FileDirectory = txt_Directory.Text
        DropDirectory = txt_DropDirectory.Text
        MediUser = txt_MediUser.Text
        MediPassword = txt_MediPassword.Text
        MainScreen.SetConfig()
        Me.Close 
    End Sub
End Class