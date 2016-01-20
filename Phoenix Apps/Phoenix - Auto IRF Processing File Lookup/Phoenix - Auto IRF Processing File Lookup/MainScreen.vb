Public Class MainScreen

    Private CaseList As New List(Of String)
    Private LastCheckHour, LastCheckMin As Integer
    Private CaseNumber As String

    Private Sub MainScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Settings.phxSQLConn = "User ID=PhoenixUser;Data Source=" & My.Settings.SQLAddress & "\Phoenix;;FailOver Partner=192.168.204.3\Phoenix;Password=password;Initial Catalog=PhoenixData;" & _
                        "Connect Timeout=3;Integrated Security=False;Persist Security Info=False;"
        txtFileDirectory.Text = My.Settings.IRFDirectory
        btnStop.Enabled = True
        btnStart.Enabled = False
        txtStatus.Text = "Running"
        txtStatus.BackColor = Color.Green
        LastCheckHour = Date.Now.Hour
        LastCheckMin = Date.Now.Minute
        txtFileDirectory.Enabled = False
        btnSubmit.Enabled = False
        UpdateInfo("Process started.")
        BGW_FileFindProcess.RunWorkerAsync()
    End Sub

    Private Sub UpdateInfo(ByVal StringToWrite As String)
        Dim TimeOf As String = Date.Now.Hour.ToString.PadLeft(2, "0") & ":" & Date.Now.Minute.ToString.PadLeft(2, "0") & ":"
        If Date.Now.Second.ToString.Length > 2 Then TimeOf &= Date.Now.Second.ToString.Substring(0, 2) Else TimeOf &= Date.Now.Second.ToString.PadLeft(2, "0")
        If txtInfo.Text.Length > 30000 Then txtInfo.Text = Nothing
        txtInfo.Text = TimeOf & ">> " & StringToWrite & vbCrLf & txtInfo.Text
    End Sub

    Private Sub CheckDirectory()
        Dim DirectoryLoc As New DirectoryInfo(My.Settings.IRFDirectory)
        Dim FileList() As FileInfo
        FileList = DirectoryLoc.GetFiles()
        For i As Integer = 0 To FileList.Length - 1
            If FileList(i).Name = "IRF_NoChanges.xml" Then
                BGW_FileFindProcess.ReportProgress(5)
                Thread.Sleep(500)
                CreateCaseList(FileList(i).FullName)
                If CaseList.Count > 0 Then BGW_FileFindProcess.ReportProgress(6, CaseList.Count) Else BGW_FileFindProcess.ReportProgress(7)
                Exit For
            End If
        Next
    End Sub
    Private Sub CreateCaseList(ByVal FileName As String)
        Dim XMLDoc As XmlDocument = New XmlDocument
        Dim XMLReader As XmlNodeReader
        Dim XMLNode As XmlNode
        Dim XMLNodeGrp As XmlNodeList
        Dim tempLastCheckHour As Integer = LastCheckHour
        Dim tempLastCheckMin As Integer = LastCheckMin
        Try
            XMLDoc.Load(FileName)
            LastCheckHour = Date.Now.Hour.ToString.PadLeft(2, "0").Substring(0, 2)
            LastCheckMin = Date.Now.Minute.ToString.PadLeft(2, "0").Substring(0, 2)
            XMLNodeGrp = XMLDoc.DocumentElement.SelectNodes("SCAN")
            For i As Integer = 0 To XMLNodeGrp.Count - 1
                XMLNode = XMLNodeGrp(i)
                XMLReader = New XmlNodeReader(XMLNode)
                While XMLReader.Read
                    If XMLReader.NodeType = XmlNodeType.Element Then
                        If XMLReader.Name = "SCAN" Then
                            While XMLReader.Read
                                If XMLReader.Name = "CaseNumberC" Or XMLReader.Name = "CaseNumberS" Then
                                    CaseNumber = XMLReader.ReadString
                                    CaseNumber = CaseNumber.Substring(0, 1) & CaseNumber.Substring(1).Replace("O", "0").Replace("Z", "2").Replace("S", "5")
                                End If
                                If XMLReader.Name = "QTIME" Then
                                    Dim tempTime As New String(XMLReader.ReadString)
                                    Dim tempHour, tempMin As Integer
                                    If tempTime.Contains("AM") Then
                                        tempTime = tempTime.Replace(" AM", "").Replace(" PM", "")
                                        tempHour = tempTime.Substring(0, 2).Replace(":", "")
                                    ElseIf tempTime.Contains("PM") Then
                                        tempTime = tempTime.Replace(" AM", "").Replace(" PM", "")
                                        tempHour = tempTime.Substring(0, 2).Replace(":", "")
                                        If tempHour <> 12 Then tempHour += 12
                                    End If
                                    tempMin = tempTime.Substring(tempTime.IndexOf(":") + 1, 2).Replace(":", "")
                                    If tempHour > tempLastCheckHour Or (tempHour = tempLastCheckHour And tempMin >= tempLastCheckMin) Then
                                        If LastCheckMin <> tempMin Then
                                            CaseList.Add(CaseNumber)
                                        End If
                                    End If
                                    Exit While
                                    'If tempTime.Substring(0, 2).Replace(":", "") > LastCheckHour Or (tempTime.Substring(0, 2).Replace(":", "") = LastCheckHour And tempTime.Substring(tempTime.IndexOf(":") + 1, 2).Replace(":", "") >= LastCheckMin) Then
                                    '    CaseList.Add(CaseNumber)
                                    '    Exit While
                                    'Else
                                    '    Exit While
                                    'End If
                                End If
                            End While
                        End If
                    End If
                End While
            Next
        Catch ex As Exception
            MessageBox.Show("Location: CreateCaseList:" & vbCrLf & ex.Message)
        Finally
            If CaseList.Count > 0 Then
                Dim SQLConn As New SqlConnection("User ID=PhoenixUser;Data Source=172.16.8.15\Phoenix;FailOver Partner=192.168.204.3;Password=password;Initial Catalog=PhoenixData;Connect Timeout=3;Integrated Security=False;Persist Security Info=True;") 'My.Settings.phxSQLConn)
                Dim SQLComm As New SqlCommand
                Try
                    SQLComm.Connection = SQLConn
                    SQLConn.Open()
                    For i As Integer = 0 To CaseList.Count - 1
                        SQLComm.CommandText = "SELECT CaseNumber FROM IRFCaseQueue WHERE CaseNumber = '" & CaseNumber & "'"
                        Dim temp As SqlDataReader = SQLComm.ExecuteReader
                        temp.Read()
                        If Not temp.HasRows Then
                            SQLComm.CommandText = "INSERT INTO IRFCaseQueue VALUES ('" & CaseList(i) & "', '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "', '" & Date.Now.Hour.ToString.PadLeft(2, "0") & ":" & Date.Now.Minute.ToString.PadLeft(2, "0") & ":" & Date.Now.Second.ToString.PadLeft(2, "0") & ":" & Date.Now.Millisecond.ToString.PadLeft(2, "0") & "')"
                            SQLComm.ExecuteNonQuery() '
                        End If
                        temp.Close()
                    Next
                Catch ex As Exception
                    MessageBox.Show("Location: StoreCaseList" & vbCrLf & ex.Message)
                Finally

                    SQLConn.Close()
                End Try
            End If
        End Try
    End Sub

    Private Sub BGW_FileFindProcess_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_FileFindProcess.DoWork
        Static Dim isCheckDirectory As Boolean = True
        While Not BGW_FileFindProcess.CancellationPending
            If (Date.Now.Hour < 18 And Date.Now.Hour > 6) Then
                If Date.Now.Minute Mod 10 = 0 Then
                    If isCheckDirectory = True Then
                        isCheckDirectory = False
                        CheckDirectory()
                    End If
                Else
                    isCheckDirectory = True
                End If
            ElseIf Date.Now.Hour = 20 And Date.Now.Minute < 10 Then
                '--Delete file at 8:00pm and reset last check time to 6:00am--
                If File.Exists(My.Settings.IRFDirectory & "IRF_NoChanges.xml") Then
                    File.Delete(My.Settings.IRFDirectory & "IRF_NoChanges.xml")

                    LastCheckHour = 6
                    LastCheckMin = 0
                End If
            End If
        End While
    End Sub
    Private Sub BGW_FileFindProcess_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_FileFindProcess.ProgressChanged
        Select Case e.ProgressPercentage
            Case 5
                UpdateInfo("XML file found. Adding cases to queue...")
            Case 6
                UpdateInfo("Added " & e.UserState & " cases to queue.")
                CaseList.Clear()
            Case 7
                UpdateInfo("No cases added to queue.")
        End Select
    End Sub
    Private Sub BGW_FileFindProcess_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_FileFindProcess.RunWorkerCompleted

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If Not BGW_FileFindProcess.IsBusy Then
            UpdateInfo("Process started.")
            btnStart.Enabled = False
            btnStop.Enabled = True
            txtStatus.Text = "Running"
            txtStatus.BackColor = Color.Green
            txtFileDirectory.Enabled = False
            btnSubmit.Enabled = False
            BGW_FileFindProcess.RunWorkerAsync()
        End If
    End Sub
    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        If BGW_FileFindProcess.IsBusy Then BGW_FileFindProcess.CancelAsync()
        UpdateInfo("Process stopped.")
        btnStart.Enabled = True
        btnStop.Enabled = False
        txtStatus.Text = "Stopped"
        txtStatus.BackColor = Color.Red
        txtFileDirectory.Enabled = True
        btnSubmit.Enabled = True
    End Sub

    Private Sub btnForce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForce.Click
        LastCheckHour = dtpTime.Value.Hour
        LastCheckMin = dtpTime.Value.Minute
        CheckDirectory()
    End Sub
End Class
