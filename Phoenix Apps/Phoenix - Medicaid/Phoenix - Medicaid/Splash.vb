Public NotInheritable Class Splash

    Public isSplash As Boolean
    Public isClosing As Boolean
    Public isUpdating As Boolean

    Private Sub Splash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isUpdating = False
        Version.Text = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Revision.ToString 'System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        If isSplash Then
            Dim RegReader As Microsoft.Win32.RegistryKey
            Dim KeyValue As String = "Software\\Phoenix\\Medicaid"
            RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
            If Not RegReader Is Nothing Then My.Settings.ServerAddress = RegReader.GetValue("serveraddress")
            CheckVersion()
            isUpdating = False
        End If
    End Sub

    Private Sub CheckVersion()
        If My.Settings.ServerAddress <> "" Or My.Settings.ServerAddress <> Nothing Then
            If My.Computer.Network.Ping(My.Settings.ServerAddress) Then
                If File.Exists("\\" & My.Settings.ServerAddress & "\Medicaid Update\UpdateInfo.txt") Then
                    Dim fileVersion As New StreamReader("\\" & My.Settings.ServerAddress & "\Medicaid Update\UpdateInfo.txt")
                    If My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Revision.ToString <> fileVersion.ReadLine.Substring(8, 5) Then
                        isUpdating = True
                        If MessageBox.Show("You are using an older version." & vbCrLf & "Would you like to update?", "Phoenix - Update", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                            Try
                                Thread.Sleep(500)
                                Process.Start(My.Application.Info.DirectoryPath & "\Phoenix - MediUpdate.exe")
                                Me.Close()
                            Catch ex As Exception
                                MessageBox.Show(ex.Message.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Try
                        End If
                    End If
                Else
                    MessageBox.Show("Update directory not found!" & vbCrLf & "Cannot check for updates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Server not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub Splash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        If Not isSplash Then Me.Close()
    End Sub
End Class
