Public Class MainScreen
    Private isServerConnected As Boolean
    Private ErrorString As String
    Private isRetryFromError As Boolean

    Private Sub MainScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetConfig()
        btn_Start.Enabled = True
        menu_Start.Enabled = True
        btn_Stop.Enabled = False
        menu_Stop.Enabled = False
        bgw_CheckServer.RunWorkerAsync()
    End Sub

    Private Sub GetConfig()
        Dim theFile As New StreamReader(My.Application.Info.DirectoryPath & "\phxConfig.dat", System.Text.Encoding.Default)
        Dim Reader As String
        While theFile.Peek <> -1
            Reader = theFile.ReadLine
            Select Case Reader.Substring(0, Reader.IndexOf(" "))
                Case "ServerAddress" : ServerAddress = Reader.Substring(Reader.IndexOf("=") + 2)
                Case "ConnectionString" : ConnectionString = Reader.Substring(Reader.IndexOf("=") + 2)
                Case "FAMISUser" : MediUser = Reader.Substring(Reader.IndexOf("=") + 2)
                Case "FAMISPassword" : MediPassword = Reader.Substring(Reader.IndexOf("=") + 2)
                Case "FileDirectory" : FileDirectory = Reader.Substring(Reader.IndexOf("=") + 2)
                Case "DropDirectory" : DropDirectory = Reader.Substring(Reader.IndexOf("=") + 2)
            End Select
        End While
        theFile.Close()
    End Sub
    Public Sub SetConfig()
        Dim theFile As New StreamWriter(My.Application.Info.DirectoryPath & "\phxConfig.dat", False)
        theFile.WriteLine("ServerAddress = " & ServerAddress)
        theFile.WriteLine("ConnectionString = " & ConnectionString)
        theFile.WriteLine("FAMISUser = " & MediUser)
        theFile.WriteLine("FAMISPassword = " & MediPassword)
        theFile.WriteLine("FileDirectory = " & FileDirectory)
        theFile.WriteLine("DropDirectory = " & DropDirectory)
        theFile.Close()
    End Sub

    Private Function isServerError()
        Dim CheckConn As New SqlConnection(ConnectionString)
        Try
            If My.Computer.Network.Ping(ServerAddress, 1500) = True Then
                CheckConn.Open()
                CheckConn.Close()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function
    Private Sub BGW_CheckServer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw_CheckServer.DoWork
        Dim CheckConn As New SqlConnection(ConnectionString)
        While Not bgw_CheckServer.CancellationPending
            If Date.Now.Hour > 6 And Date.Now.Hour < 18 And Date.Now.DayOfWeek <> DayOfWeek.Saturday And Date.Now.DayOfWeek <> DayOfWeek.Sunday Then
                If isServerError() Then
                    bgw_CheckServer.ReportProgress(1)
                Else
                    bgw_CheckServer.ReportProgress(0)
                End If
                Thread.Sleep(2500)
            End If
        End While
    End Sub
    Private Sub BGW_CheckServer_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw_CheckServer.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0
                isServerConnected = True
            Case 1
                txt_Status.Text = "No Server"
                txt_Status.BackColor = Color.Red
                isServerConnected = False
                If bgw_ScanDirectory.IsBusy Then
                    btn_Stop_Click(Nothing, Nothing)
                    SetInfo("Server not responding.", True)
                End If
                bgw_CheckServer.CancelAsync()
                If Not BGW_RetryServer.IsBusy Then
                    BGW_RetryServer.RunWorkerAsync()
                Else
                    MessageBox.Show("Trouble! BGW_RetryServer" & vbCrLf & "The thread was still running.")
                End If
        End Select
    End Sub
    Private Sub BGW_RetryServer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw_RetryServer.DoWork
        Dim CheckConn As New SqlConnection(ConnectionString)
        Dim isRetry As Boolean = True
        Dim x As Integer = 0
        While isRetry
            If Not BGW_CheckServer.IsBusy Then
                BGW_RetryServer.ReportProgress(x)
                If Not isServerError() Then
                    BGW_RetryServer.ReportProgress(20)
                    isRetry = False
                End If
                If x + 1 > 5 Then x = 0 Else x += 1
            End If
            Thread.Sleep(2500)
        End While
    End Sub
    Private Sub BGW_RetryServer_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_RetryServer.RunWorkerCompleted
        If Not BGW_CheckServer.IsBusy Then
            BGW_CheckServer.RunWorkerAsync()
        Else
            MessageBox.Show("Trouble! BGW_CheckServer_Completed" & vbCrLf & "The thread was still running.")
        End If
    End Sub
    Private Sub BGW_RetryServer_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw_RetryServer.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0 : txt_Status.Text = "Server Not Found. Retrying."
            Case 1 : txt_Status.Text = "Server Not Found. Retrying.."
            Case 2 : txt_Status.Text = "Server Not Found. Retrying..."
            Case 3 : txt_Status.Text = "Server Not Found. Retrying...."
            Case 4 : txt_Status.Text = "Server Not Found. Retrying....."
            Case 20
                txt_Status.Text = "Running"
                txt_Status.BackColor = Color.Green
                SqlClient.SqlConnection.ClearAllPools()
                If Not bgw_ScanDirectory.IsBusy Then btn_Start_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub bgw_ScanDirectory_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw_ScanDirectory.DoWork
        Dim Directory As New DirectoryInfo(FileDirectory)
        Dim HoldDirectory As New DirectoryInfo(FileDirectory & "\Holds")
        Dim FileList() As FileInfo
        Dim i, x, max As Integer
        While isRetryFromError
            Try
                While Not bgw_ScanDirectory.CancellationPending
                    If Date.Now.Hour > 6 And Date.Now.Hour < 18 And Date.Now.DayOfWeek <> DayOfWeek.Saturday And Date.Now.DayOfWeek <> DayOfWeek.Sunday Then
                        If isServerConnected Then
                            bgw_ScanDirectory.ReportProgress(15)
                            If Date.Now.Minute = 50 Then
                                If Date.Now.Hour = 8 Then
                                    FileList = HoldDirectory.GetFiles("*.txt")
                                    If FileList.Length > 0 Then
                                        For i = 0 To FileList.Length - 1
                                            If File.Exists(FileDirectory & "\" & FileList(i).Name) Then File.Delete(FileDirectory & "\" & FileList(i).Name)
                                            File.Move(FileDirectory & "\Holds\" & FileList(i).Name, FileDirectory & "\" & FileList(i).Name)
                                        Next
                                    End If
                                End If
                                x = 0
                                FileList = Directory.GetFiles("*.txt")
                                If FileList.Length > 0 Then
                                    bgw_ScanDirectory.ReportProgress(1)
                                    If FileList.Length < 100 Then max = FileList.Length Else max = 100
                                    For i = 0 To max - 1
                                        If FileList(i).Name.Substring(0, 2) = "61" Or FileList(i).Name.Substring(0, 2) = "66" Or FileList(i).Name.Substring(0, 2) = "64" Then
                                            If bgw_ScanDirectory.CancellationPending Then Exit While
                                            Thread.Sleep(500)
                                            MedicaidFileList(x) = New MedicaidFile(FileDirectory & "\" & FileList(i).Name)
                                            Thread.Sleep(250)
                                            x += 1
                                        Else
                                            File.Delete(FileList(i).FullName)
                                        End If
                                    Next
                                    MaxMedi = x
                                    bgw_ScanDirectory.ReportProgress(10)
                                    ParentControlScreen = Me
                                    ProcessMedicaid()
                                    Thread.Sleep(5000)
                                    bgw_ScanDirectory.ReportProgress(11)
                                    Thread.Sleep(55000)
                                End If
                            End If
                        End If
                        Thread.Sleep(5684)
                    End If
                End While
                Exit While
            Catch ex As Exception
                ErrorString = "Location bgw_ScanDirectory: " & ex.Message.ToString
                bgw_ScanDirectory.ReportProgress(99)
            End Try
        End While
    End Sub
    Private Sub bgw_ScanDirectory_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw_ScanDirectory.ProgressChanged
        Static Dim retryCount As Integer = 0
        Select Case e.ProgressPercentage
            Case 1  '--Report making of file list--
                SetInfo("Creating File List...", False)
            Case 2  '--Report case processing start--
                SetInfo("Processing Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber, False)
            Case 3  '--Report case errors--
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " >> " & ErrorMessage1Medi & " " & ErrorMessage2Medi, True)
            Case 4  '--Report case success--
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " Successfully Processed.", False)
            Case 5  '--Report case being manually entered--
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " will be manually entered.", False)
            Case 6  '--Report case being held--
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " is being held.", False)
            Case 7 '--Operator not on list--
                SetInfo("Worker: " & MediCaseNumber & " not on list to be processed. File: " & MediFile & " deleted...", True)
            Case 8 '--Report GLink error--
                SetInfo("GLink Error: " & ErrorMessage1Medi, True)
                btn_Stop_Click(Nothing, Nothing)
            Case 10 '--Report total cases being processed--
                SetInfo("Processing " & MaxMedi & " Cases...", False)
            Case 11 '--Report cases done--
                SetInfo("File list complete.", False)
            Case 20
                SetInfo("Processing all persons in " & MediCaseNumber & " as a group.", False)
            Case 99 '--Error reporting--
                SetInfo(ErrorString, True)
                Thread.Sleep(5000)
                If retryCount < 3 Then
                    SetInfo("Restarting process...", False)
                    retryCount += 1
                    isRetryFromError = True
                Else
                    retryCount = 0
                    isRetryFromError = False
                End If
        End Select
    End Sub
    Private Sub bgw_ScanDirectory_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_ScanDirectory.RunWorkerCompleted
        SetInfo("Medicaid Process Stopped.", False)
        txt_Status.Text = "Stopped"
        txt_Status.BackColor = Color.Red
        btn_Stop.Enabled = False
        menu_Stop.Enabled = False
        menu_Options.Enabled = True
        '--Because of the delay when stopping the run button was being enabled when the server was down--
        If isServerConnected Then btn_Start.Enabled = True : menu_Start.Enabled = True
    End Sub

    Private Sub SetInfo(ByVal StringToWrite As String, ByVal isErrMsg As Boolean)
        If isErrMsg Then
            txt_Info.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> ERROR: " & StringToWrite & vbCrLf & txt_Info.Text : LogFile("Error: " & StringToWrite)
        Else
            txt_Info.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> " & StringToWrite & vbCrLf & txt_Info.Text : LogFile(StringToWrite)
        End If
    End Sub
    Private Sub LogFile(ByVal LineToWrite As String)
        Dim File_Writer As StreamWriter
        Dim LogTime As String = Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year
        File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "\Medicaid Logs\LogFile (" & LogTime & ").doc", True)
        File_Writer.WriteLine(LogTime & " " & Date.Now.Hour.ToString & ":" & Date.Now.Minute.ToString & ":" & Date.Now.Second.ToString & " >> " & LineToWrite)
        File_Writer.Close()
    End Sub

    Private Sub btn_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Start.Click, menu_Start.Click
        SetInfo("Medicaid Process Started.", False)
        If Not bgw_ScanDirectory.IsBusy Then
            isRetryFromError = True
            bgw_ScanDirectory.RunWorkerAsync()
        Else
            MessageBox.Show("Trouble! BGW_ScanDirectory" & vbCrLf & "The thread was still running.")
        End If
        btn_Start.Enabled = False
        menu_Start.Enabled = False
        btn_Stop.Enabled = True
        menu_Stop.Enabled = True
        menu_Options.Enabled = False
        txt_Status.BackColor = Color.Green
        txt_Status.Text = "Running"
    End Sub
    Private Sub btn_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Stop.Click, menu_Stop.Click
        bgw_ScanDirectory.CancelAsync()
        txt_Status.BackColor = Color.OrangeRed
        txt_Status.Text = "Stopping..."
    End Sub

    Private Sub menu_Options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Options.Click
        Dim form As New Options
        Me.Enabled = False
        form.ShowDialog()
        Me.Enabled = True
    End Sub
End Class
