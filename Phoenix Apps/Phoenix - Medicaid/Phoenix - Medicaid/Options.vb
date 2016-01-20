Public Class Options

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddEvents(Me)
        btn_Ok.Enabled = False
    End Sub

    Private Sub AddEvents(ByVal ctrlparent As Control)
        '--Adds events to pad a textbox with spaces when user-- 
        '--exits, provides a tooltip with block information, and tracks--
        '--which blocks the user has changed the data--
        Dim ctrl As Control
        For Each ctrl In ctrlparent.Controls
            If TypeOf ctrl Is TextBox Then
                AddHandler ctrl.TextChanged, AddressOf InfoChanged
            End If
            If ctrl.HasChildren Then
                AddEvents(ctrl)
            End If
        Next
    End Sub
    Private Sub InfoChanged(ByVal sender As Object, ByVal e As EventArgs)
        btn_Ok.Enabled = True
    End Sub

    Private Sub SetData()
        Dim tempDirectory As String = My.Settings.MediDirectory
        Dim RegReader As Microsoft.Win32.RegistryKey
        Dim KeyValue As String = "Software\\Phoenix\\Medicaid\\"
        Dim Directory As DirectoryInfo

        My.Settings.ServerAddress = txt_MediServer.Text
        My.Settings.MediDirectory = txt_MediDirectory.Text
        My.Settings.MediHoldDirectory = txt_MediDrop.Text
        My.Settings.MediOperator = txt_MediOperator.Text
        My.Settings.MediPassword = txt_MediPassword.Text

        RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
        If Not RegReader Is Nothing Then
            Directory = New DirectoryInfo(My.Settings.MediDirectory)
            If Not Directory.Exists Then
                My.Settings.MediDirectory = RegReader.GetValue("DropDirectory")
                txt_MediDirectory.Text = My.Settings.MediDirectory
                MessageBox.Show("Directory Does Not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                RegReader.SetValue("Directory", My.Settings.MediDirectory)
            End If
            Directory = New DirectoryInfo(My.Settings.MediHoldDirectory)
            If Not Directory.Exists Then
                My.Settings.MediHoldDirectory = RegReader.GetValue("HoldDirectory")
                txt_MediDrop.Text = My.Settings.MediHoldDirectory
                MessageBox.Show("Directory Does Not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                RegReader.SetValue("HoldDirectory", My.Settings.MediHoldDirectory)
            End If
            Directory = New DirectoryInfo(My.Settings.MediFamilyDirectory)
            If Not Directory.Exists Then
                My.Settings.MediFamilyDirectory = RegReader.GetValue("FamilyDirectory")
                txt_FamilyHold.Text = My.Settings.MediFamilyDirectory
                MessageBox.Show("Directory Does Not Exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                RegReader.SetValue("FamilyDirectory", My.Settings.MediFamilyDirectory)
            End If
            RegReader.SetValue("Operator", My.Settings.MediOperator)
            RegReader.SetValue("Password", My.Settings.MediPassword)
            RegReader.SetValue("ServerAddress", My.Settings.ServerAddress)
        End If
        RegReader.Close()
        'My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password"
        My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password"
    End Sub

    Private Sub btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click
        btn_Ok.Enabled = False
        SetData()
        Me.Close()
    End Sub
    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.Close()
    End Sub
End Class