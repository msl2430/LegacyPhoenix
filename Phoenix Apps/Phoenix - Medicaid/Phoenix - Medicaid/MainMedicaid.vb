Imports Microsoft.Office.Interop
Imports Microsoft.Office


Public Class MainMedicaid

    Public isServerConnected As Boolean                            '--Tracks if the server is found and connected--
    Public ErrorMessage As String                                  '--Error to report--

    Private PrintChoice As String                                  '--Which printing options was chosen--

    Private Sub MainMedicaid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password"
        My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password"
        InitializeSettings()
        BGW_CheckServer.RunWorkerAsync()
        BGW_NumCases.RunWorkerAsync()
        txt_NumCases.BackColor = Color.White
        SetInfo("Waiting For Start Command...", False)
    End Sub
    Private Sub MainMedicaid_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If BGW_MediScanDirectory.IsBusy Then
            e.Cancel = True
            SetInfo("Stop Processing Before Closing!", True)
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub InitializeSettings()
        Dim KeyValue As String = "Software\\Phoenix\\Medicaid\\"
        Dim RegReader As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
        KeyValue = "Software\\Phoenix\\Medicaid\\"
        RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
        If Not RegReader Is Nothing Then
            My.Settings.MediDirectory = RegReader.GetValue("Directory")
            My.Settings.MediHoldDirectory = RegReader.GetValue("HoldDirectory")
            My.Settings.MediOperator = RegReader.GetValue("Operator")
            My.Settings.MediPassword = RegReader.GetValue("Password")
            If My.Settings.MediPassword <> "PHOENIX8" Then My.Settings.MediPassword = "PHOENIX8"
            My.Settings.MediFamilyDirectory = RegReader.GetValue("FamilyDirectory")
        End If
        RegReader.Close()
    End Sub

    Private Sub BGW_MediScanDirectory_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_MediScanDirectory.DoWork
        Dim Directory As New DirectoryInfo(My.Settings.MediDirectory)
        Dim FileList() As FileInfo
        Dim i, x, max As Integer
        Try
            While Not BGW_MediScanDirectory.CancellationPending
                x = 0
                CasesToPrint.Clear()
                FileList = Directory.GetFiles("*.txt")
                If FileList.Length > 0 Then
                    BGW_MediScanDirectory.ReportProgress(1)
                    If FileList.Length < 100 Then max = FileList.Length Else max = 100
                    For i = 0 To max - 1
                        If FileList(i).Name.Substring(0, 2) = "61" Or FileList(i).Name.Substring(0, 2) = "66" Or FileList(i).Name.Substring(0, 2) = "64" Then
                            If BGW_MediScanDirectory.CancellationPending Then Exit While
                            Thread.Sleep(500)
                            If My.Settings.MediDirectory.Substring(My.Settings.MediDirectory.Length - 1, 1) = "\" Then
                                MedicaidFileList(x) = New MedicaidFile(My.Settings.MediDirectory & FileList(i).Name)
                            Else
                                MedicaidFileList(x) = New MedicaidFile(My.Settings.MediDirectory & "\" & FileList(i).Name)
                            End If
                            Thread.Sleep(250)
                            x += 1
                        End If
                    Next
                    MaxMedi = x
                    BGW_MediScanDirectory.ReportProgress(10)
                    ParentMainMedicaid = Me
                    ProcessMedicaid()
                    BGW_MediScanDirectory.ReportProgress(25)
                End If
                Thread.Sleep(3684)
            End While
        Catch ex As Exception
            MessageBox.Show("Location: BGW_MediScanDirectory" & vbCrLf & ex.Message)
            LogFile("Location: BGW_MediScanDirectory" & vbCrLf & ex.Message)
            'ErrorDump(MediFile & vbCrLf & OPTChoice & vbCrLf & MediCaseNumber & vbCrLf & MediPersonNumber & vbCrLf & isErrorMedi & vbCrLf & ErrorMessage1Medi & vbCrLf & ErrorLocation)
        End Try
    End Sub
    Private Sub BGW_MediScanDirectory_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_MediScanDirectory.ProgressChanged
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
                'SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " will be manually entered.", False)
            Case 6  '--Report case being held--
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " is being held.", False)
            Case 10 '--Report total cases being processed--
                'SetInfo("Processing " & MaxMedi & " Cases...", False)
            Case 11 '--Unenabled form--
                Me.Enabled = False
                Me.WindowState = FormWindowState.Minimized
            Case 12 '--Reenable form--
                Me.Enabled = True
                Me.WindowState = FormWindowState.Normal
            Case 20
                SetInfo("Processing all persons in " & MediCaseNumber & " as a group.", False)
            Case 21
                SetInfo("Restarting grouped cases.", False)
            Case 25 '--Printing report--
                SetInfo("Printing Case Processing Results...", False)
                PrintOneTime()
                Thread.Sleep(2345)
                SetInfo("Pending Cases Completed.", False)
            Case 50
                'ErrorDump("Error trying to close GLink." & vbCrLf & MediFile & vbCrLf & MediCaseNumber & vbCrLf & MediPersonNumber & ErrorLocation)
                SetInfo(ErrorMessage, True)
            Case 51
                SetInfo(ErrorMessage, True)
                btn_Stop_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub BGW_MediScanDirectory_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_MediScanDirectory.RunWorkerCompleted
        SetInfo("Medicaid Process Stopped.", False)
        '--Because of the delay when stopping the run button was being enabled when the server was down--
        If isServerConnected Then btn_Start.Enabled = True
        menu_Exit.Enabled = True
        menu_Options.Enabled = True
    End Sub

    Private Sub GetNumOfCases()
        Dim Directory As New DirectoryInfo(My.Settings.MediDirectory)
        Dim FileList() As FileInfo
        If Directory.Exists Then
            Directory.Refresh()
            FileList = Directory.GetFiles("*.txt")
            txt_NumCases.Text = FileList.Length
            txt_NumCases.BackColor = Color.Green
        Else
            txt_NumCases.Text = "-DNE-"
            txt_NumCases.BackColor = Color.Red
        End If
    End Sub
    Private Sub BGW_NumCases_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_NumCases.DoWork
        While Not BGW_NumCases.CancellationPending
            If isServerConnected Then BGW_NumCases.ReportProgress(0) Else BGW_NumCases.ReportProgress(1)
            Thread.Sleep(1500)
        End While
    End Sub
    Private Sub BGW_NumCases_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_NumCases.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0
                GetNumOfCases()
            Case 1
                txt_NumCases.Text = "---"
                txt_NumCases.BackColor = Color.Orange
        End Select
    End Sub

    Private Sub LogFile(ByVal LineToWrite As String)
        Dim File_Writer As StreamWriter
        Dim LogTime As String = Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year
        File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "\Medicaid Logs\LogFile (" & LogTime & ").doc", True)
        File_Writer.WriteLine(LogTime & " " & Date.Now.Hour.ToString & ":" & Date.Now.Minute.ToString & ":" & Date.Now.Second.ToString & " >> " & LineToWrite)
        File_Writer.Close()
    End Sub
    Private Sub SetInfo(ByVal StringToWrite As String, ByVal isErrorMsg As Boolean)
        If isErrorMsg Then
            txt_Info.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> ERROR: " & StringToWrite & vbCrLf & txt_Info.Text
            LogFile("Error: " & StringToWrite)
        Else
            txt_Info.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> " & StringToWrite & vbCrLf & txt_Info.Text
            LogFile(StringToWrite)
        End If
        txt_Info.Focus()
    End Sub
    Private Sub ErrorDump(ByVal LineToWrite As String)
        Dim File_Writer As New StreamWriter(My.Settings.MediHoldDirectory & "\ErrorDump (" & Date.Now.Month.ToString & "_" & Date.Now.Day.ToString & "_" & Date.Now.Year.ToString & "_" & Date.Now.Hour.ToString & Date.Now.Minute.ToString & ").doc", True)
        Dim LogTime As String = Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year
        File_Writer.WriteLine(LineToWrite)
        File_Writer.Close()
    End Sub

#Region "Server Checking Functions"
    Private Function isServerError()
        Dim CheckConn As New SqlConnection(My.Settings.phxSQLConn)
        Try
            If My.Computer.Network.Ping(My.Settings.ServerAddress, 1500) = True Then
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
    Private Sub BGW_CheckServer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_CheckServer.DoWork
        Dim CheckConn As New SqlConnection(My.Settings.phxSQLConn)
        While Not BGW_CheckServer.CancellationPending
            If isServerError() Then
                BGW_CheckServer.ReportProgress(1)
            Else
                BGW_CheckServer.ReportProgress(0)
            End If
            Thread.Sleep(2500)
        End While
    End Sub
    Private Sub BGW_CheckServer_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_CheckServer.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0
                isServerConnected = True
            Case 1
                isServerConnected = False
                SetInfo("Server not responding.", True)
                If BGW_MediScanDirectory.IsBusy Then btn_Stop.PerformClick()
                btn_Start.Enabled = False
                BGW_CheckServer.CancelAsync()
                BGW_RetryServer.RunWorkerAsync()
        End Select
    End Sub
    Private Sub BGW_RetryServer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_RetryServer.DoWork
        Dim CheckConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim isRetry As Boolean = True
        BGW_RetryServer.ReportProgress(1)
        While isRetry
            If Date.Now.Second Mod 30 = 0 Then BGW_RetryServer.ReportProgress(1)
            If Not isServerError() Then
                BGW_RetryServer.ReportProgress(20)
                isRetry = False
            End If
        End While
    End Sub
    Private Sub BGW_RetryServer_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_RetryServer.RunWorkerCompleted
        BGW_CheckServer.RunWorkerAsync()
    End Sub
    Private Sub BGW_RetryServer_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_RetryServer.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1
                SetInfo("Retrying Server...", False)
            Case 20
                'lbl_Server.Text = "--Server Connected--"
                'lbl_Server.BackColor = Color.Green
                'treeMenu.Enabled = True
                'If isIMPSRunning Then SelectedApp = "IMPS" : tool_Run_Click(Nothing, Nothing)
                'If isMedicaidRunning Then SelectedApp = "Medicaid" : tool_Run_Click(Nothing, Nothing)
                btn_Start.Enabled = True
                SetInfo("Server Connected!", False)
        End Select
    End Sub
#End Region

#Region "Menu Functions"
    Private Sub btn_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Start.Click
        SetInfo("Medicaid Case Processing Started.", False)
        BGW_MediScanDirectory.RunWorkerAsync()
        btn_Start.Enabled = False
        btn_Stop.Enabled = True
        menu_Exit.Enabled = False
        menu_Options.Enabled = False
    End Sub
    Private Sub btn_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Stop.Click
        SetInfo("Stopping...", False)
        BGW_MediScanDirectory.CancelAsync()
        btn_Stop.Enabled = False
    End Sub
    Private Sub menu_About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_About.Click
        Dim Form As New Splash
        Form.isSplash = False
        Me.Enabled = False
        Form.Show()
        Me.Enabled = True
    End Sub
    Private Sub menu_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Exit.Click
        Me.Close()
    End Sub
    Private Sub menu_Options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Options.Click
        Dim Form As New Options
        Me.Enabled = False
        Me.WindowState = FormWindowState.Minimized
        Form.TopMost = True
        Form.ShowDialog()
        Form.TopMost = False
        Me.Enabled = True
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub menu_PrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_PrintAll.Click
        PrintChoice = "All"
        BGW_PrintReport.RunWorkerAsync()
    End Sub
    Private Sub menu_PrintSuccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_PrintSuccess.Click
        PrintChoice = "Success"
        BGW_PrintReport.RunWorkerAsync()
    End Sub
    Private Sub menu_PrintDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_PrintDrop.Click
        PrintChoice = "Dropped"
        BGW_PrintReport.RunWorkerAsync()
    End Sub
    Private Sub menu_Redet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Redet.Click
        PrintChoice = "Redet Deleted"
        BGW_PrintReport.RunWorkerAsync()
    End Sub
    Private Sub menu_CoverSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_CoverSheet.Click
        menu_Print.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        PrintChoice = "CoverSheet"
        BGW_PrintReport.RunWorkerAsync()
    End Sub
#End Region

#Region "Report Functions"
    Private Sub PrintOneTime()
        Dim i As Integer
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sortList As New ListBox
        Dim ErrorMsg, tempErrorMsg1, tempErrorMsg2 As String
        SQLComm.Connection = SQLConn
        If File.Exists(My.Application.Info.DirectoryPath & "\MediStats.doc") Then File.Delete(My.Application.Info.DirectoryPath & "\MediStats.doc")
        Try
            SQLConn.Open()
            CreateDoc()
            For i = 0 To CasesToPrint.Count - 1
                SQLComm.CommandText = "SELECT DISTINCT CaseNumber, TextFile, DateEntered, Operator, Ops, PersonNumber, Result, Reason FROM TRANSACTIONLOG WHERE DATEENTERED = '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "' and CaseNumber = '" & CasesToPrint.Item(i).CaseNumber & "' and OPS = '" & CasesToPrint.Item(i).OptScreen & "' and PersonNumber = '" & CasesToPrint.Item(i).PersonNumber & "' ORDER BY CaseNumber, PersonNumber, Operator, Result" 'sortList.Items(i) & " ' ORDER BY CaseNumber, PersonNumber, Operator, Result"
                Reader = SQLComm.ExecuteReader
                While Reader.Read()
                    tempErrorMsg1 = Reader.GetString(7).Substring(0, 35)
                    tempErrorMsg2 = Reader.GetString(7).Substring(36, 35)
                    If tempErrorMsg2.Substring(0, 10) <> "          " Then
                        ErrorMsg = tempErrorMsg1 & vbCrLf & tempErrorMsg2.PadLeft(79, " ")
                    Else
                        ErrorMsg = tempErrorMsg1
                    End If
                    If ErrorMsg.Substring(0, 6) <> " Perso" And ErrorMsg.Substring(0, 6) <> "Person" Then
                        WriteReport(Reader.GetString(0), Reader.GetString(5).Substring(0, 2), Reader.GetString(4).Substring(0, 2), Reader.GetString(3).Substring(0, 6), Reader.GetString(6).Substring(0, 7), ErrorMsg)
                    End If
                End While
                Reader.Close()
            Next
            PrintReport()
            If File.Exists(My.Application.Info.DirectoryPath & "\MediStats.doc") Then File.Delete(My.Application.Info.DirectoryPath & "\MediStats.doc")
        Catch ex As Exception
            MessageBox.Show("Location: OneTimeReport" & vbCrLf & ex.Message.ToString)
            LogFile("ERROR: Location: OneTimeReport - " & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub PrintCoverSheet()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim SQLReportConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLReportComm As New SqlCommand
        Dim Reader As SqlDataReader
        Dim Supervisor As New List(Of String)
        Dim OperatorID As New List(Of String)
        Dim ReportType As String = "(" & PrintChoice & ")"
        Dim oWord As Word.Application
        Dim FootNote As String = Microsoft.VisualBasic.Mid("Phoenix - Medicaid Processing", 1)
        Dim i As Integer
        SQLComm.Connection = SQLConn
        SQLReportComm.Connection = SQLReportConn
        Try
            SQLConn.Open()
            SQLReportConn.Open()
            SQLComm.CommandText = "SELECT * FROM MedicaidOperator"
            Reader = SQLComm.ExecuteReader
            While Reader.Read
                OperatorID.Add(Reader.GetString(0))
                Supervisor.Add(Reader.GetString(1))
            End While
            Reader.Close()
            For i = 0 To OperatorID.Count - 1
                If File.Exists(My.Application.Info.DirectoryPath & "\CoverSheet.doc") Then File.Delete(My.Application.Info.DirectoryPath & "\CoverSheet.doc")
                Dim File_Writer As New StreamWriter(My.Application.Info.DirectoryPath & "\CoverSheet.doc", True)
                File_Writer.WriteLine("               MEDICAID CASE PROCESSING RESULTS                      " & Date.Today.Month & "/" & Date.Today.Day & "/" & Date.Today.Year & vbCrLf)
                File_Writer.WriteLine("                  Supervisor: " & Supervisor(i).Replace("  ", "") & " (" & OperatorID(i).Replace(" ", "") & ")")
                SQLComm.CommandText = "SELECT DISTINCT CaseNumber, PersonNumber, Ops FROM TRANSACTIONLOG WHERE Reported = 'False' AND Result = 'SUCCESS' AND Operator = '" & OperatorID(i) & "' ORDER BY CaseNumber, PersonNumber"
                Reader = SQLComm.ExecuteReader
                File_Writer.WriteLine(vbCrLf & "----Successful Cases----" & vbCrLf)
                Reader.Read()
                If Reader.HasRows Then
                    File_Writer.WriteLine("   Case Number  Per #  Opt")
                    Reader.Close()
                    Reader = SQLComm.ExecuteReader()
                    While Reader.Read
                        File_Writer.WriteLine("   " & Reader.GetString(0) & "   " & Reader.GetString(1).Substring(0, 2) & "     " & Reader.GetString(2))
                        SQLReportComm.CommandText = "UPDATE TRANSACTIONLOG SET Reported = 'True' WHERE CASENUMBER = '" & Reader.GetString(0) & "' AND PERSONNUMBER = '" & Reader.GetString(1).Substring(0, 2) & "' AND OPS = '" & Reader.GetString(2) & "'"
                        SQLReportComm.ExecuteNonQuery()
                    End While
                    Reader.Close()
                Else
                    File_Writer.WriteLine("   **No Cases**")
                    Reader.Close()
                End If
                SQLComm.CommandText = "SELECT DISTINCT CaseNumber, PersonNumber, Ops FROM TRANSACTIONLOG WHERE Reported = 'False' AND Result = 'FAILED' AND (Reason NOT LIKE '%Person%' AND Reason NOT LIKE '%Children%' AND Reason NOT LIKE '%Dropped%') AND Operator = '" & OperatorID(i) & "' ORDER BY CaseNumber, PersonNumber"
                Reader = SQLComm.ExecuteReader
                File_Writer.WriteLine(vbCrLf & "-----Dropped Cases-----" & vbCrLf)
                Reader.Read()
                If Reader.HasRows Then
                    File_Writer.WriteLine("   Case Number  Per #  Opt")
                    Reader.Close()
                    Reader = SQLComm.ExecuteReader
                    While Reader.Read
                        File_Writer.WriteLine("   " & Reader.GetString(0) & "   " & Reader.GetString(1).Substring(0, 2) & "     " & Reader.GetString(2))
                        SQLReportComm.CommandText = "UPDATE TRANSACTIONLOG SET Reported = 'True' WHERE CASENUMBER = '" & Reader.GetString(0) & "' AND PERSONNUMBER = '" & Reader.GetString(1).Substring(0, 2) & "' AND OPS = '" & Reader.GetString(2) & "'"
                        SQLReportComm.ExecuteNonQuery()
                    End While
                    Reader.Close()
                Else
                    File_Writer.WriteLine("   **No Cases**")
                    Reader.Close()
                End If
                SQLComm.CommandText = "SELECT DISTINCT CaseNumber, PersonNumber, Ops FROM TRANSACTIONLOG WHERE Reported = 'False' AND Result = 'FAILED' AND (Reason LIKE '%Person%' OR Reason LIKE '%Children%' OR Reason LIKE '%Dropped%') AND Operator = '" & OperatorID(i) & "' ORDER BY CaseNumber, PersonNumber"
                Reader = SQLComm.ExecuteReader
                File_Writer.WriteLine(vbCrLf & "------Held Cases-------" & vbCrLf)
                Reader.Read()
                If Reader.HasRows Then
                    File_Writer.WriteLine("   Case Number  Per #  Opt")
                    Reader.Close()
                    Reader = SQLComm.ExecuteReader
                    While Reader.Read
                        File_Writer.WriteLine("   " & Reader.GetString(0) & "   " & Reader.GetString(1).Substring(0, 2) & "     " & Reader.GetString(2))
                        'SQLReportComm.CommandText = "UPDATE TRANSACTIONLOG SET Reported = 'True' WHERE CASENUMBER = '" & Reader.GetString(0) & "' AND PERSONNUMBER = '" & Reader.GetString(1).Substring(0, 2) & "' AND OPS = '" & Reader.GetString(2) & "'"
                        'SQLReportComm.ExecuteNonQuery()
                    End While
                    Reader.Close()
                Else
                    File_Writer.WriteLine("   **No Cases**")
                    Reader.Close()
                End If
                File_Writer.Close()
                oWord = New Word.ApplicationClass
                oWord.Documents.Add(My.Application.Info.DirectoryPath & "\CoverSheet.doc")
                oWord.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
                oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter
                oWord.Selection.TypeText("Phoenix Medicaid Case Processing: " & Supervisor(i))
                oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader
                oWord.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
                oWord.Selection.TypeText("Page: ")
                oWord.Selection.Fields.Add(oWord.Selection.Range, Word.WdFieldType.wdFieldPage)
                oWord.PrintOut(False)
                oWord.Quit(0)
                oWord = Nothing
            Next
        Catch ex As Exception
            MessageBox.Show("Location: PrintCoverSheet" & vbCrLf & ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub CreateDoc()
        If File.Exists(My.Application.Info.DirectoryPath & "\MediStats.doc") Then File.Delete(My.Application.Info.DirectoryPath & "\MediStats.doc")
        Dim File_Writer As New StreamWriter(My.Application.Info.DirectoryPath & "\MediStats.doc", True)
        File_Writer.WriteLine("               MEDICAID CASE PROCESSING RESULTS                      " & Date.Today.Month & "/" & Date.Today.Day & "/" & Date.Today.Year & vbCrLf)
        File_Writer.WriteLine("   Case Number  Per #  OPS  WORKER  RESULT   Reason" & vbCrLf)
        File_Writer.Close()
    End Sub
    Private Sub WriteReport(ByVal CaseNumber As String, ByVal PerNum As String, ByVal OPTs As String, ByVal Worker As String, ByVal Result As String, ByVal Reason As String)
        Dim File_Writer As New StreamWriter(My.Application.Info.DirectoryPath & "\MediStats.doc", True)
        File_Writer.WriteLine("   " & CaseNumber & "   " & PerNum & "     " & OPTs & "   " & Worker & "  " & Result & "  " & Reason)
        File_Writer.Close()
    End Sub
    Private Sub PrintReport()
        Dim ReportType As String = "(" & PrintChoice & ")"
        Dim oWord As Word.Application
        Dim FootNote As String = Microsoft.VisualBasic.Mid("Phoenix - Medicaid Processing", 1)
        oWord = New Word.ApplicationClass
        oWord.Documents.Add(My.Application.Info.DirectoryPath & "\MediStats.doc")
        oWord.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
        oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter
        oWord.Selection.TypeText("Phoenix - Medicaid Processing " & ReportType.PadRight(85, " "))
        oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader
        oWord.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
        oWord.Selection.TypeText("Page: ")
        oWord.Selection.Fields.Add(oWord.Selection.Range, Word.WdFieldType.wdFieldPage)
        oWord.PrintOut(False)
        oWord.Quit(0)
        oWord = Nothing
    End Sub
    Private Sub BGW_PrintReport_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_PrintReport.DoWork
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim Reader As SqlDataReader
        Dim ErrorMsg, tempErrorMsg1, tempErrorMsg2 As String
        If Not PrintChoice = "CoverSheet" Then
            SQLComm.Connection = SQLConn
            BGW_PrintReport.ReportProgress(0)
            Try
                CreateDoc()
                SQLConn.Open()
                Select Case PrintChoice
                    Case "All" : SQLComm.CommandText = "SELECT DISTINCT CaseNumber, TextFile, DateEntered, Operator, Ops, PersonNumber, Result, Reason FROM TRANSACTIONLOG WHERE DATEENTERED = '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "' ORDER BY Operator, CaseNumber, PersonNumber, Result"
                    Case "Success" : SQLComm.CommandText = "SELECT DISTINCT CaseNumber, TextFile, DateEntered, Operator, Ops, PersonNumber, Result, Reason FROM TRANSACTIONLOG WHERE DATEENTERED = '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "' AND Result = 'SUCCESS' ORDER BY Operator, CaseNumber, PersonNumber, Result"
                    Case "Dropped" : SQLComm.CommandText = "SELECT DISTINCT CaseNumber, TextFile, DateEntered, Operator, Ops, PersonNumber, Result, Reason FROM TRANSACTIONLOG WHERE DATEENTERED = '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "' AND Result = 'FAILED' ORDER BY Operator, CaseNumber, PersonNumber, Result"
                    Case "Redet Deleted" : SQLComm.CommandText = "SELECT DISTINCT TRANSACTIONLOG.CaseNumber, TRANSACTIONLOG.TextFile, TRANSACTIONLOG.DateEntered, TRANSACTIONLOG.Operator, TRANSACTIONLOG.Ops, TRANSACTIONLOG.PersonNumber, TRANSACTIONLOG.Result, TRANSACTIONLOG.Reason FROM TRANSACTIONLOG, OPS66 WHERE TRANSACTIONLOG.CASENUMBER = OPS66.CASENUMBER AND TRANSACTIONLOG.PERSONNUMBER = OPS66.PERSONNUMBER AND OPS66.ACTIONCODE = 'D' AND TRANSACTIONLOG.OPS = '66' AND TRANSACTIONLOG.DATEENTERED = '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "' AND TRANSACTIONLOG.RESULT = 'SUCCESS'"
                End Select

                Reader = SQLComm.ExecuteReader
                While Reader.Read()
                    tempErrorMsg1 = Reader.GetString(7).Substring(0, 35)
                    tempErrorMsg2 = Reader.GetString(7).Substring(36, 35)
                    If tempErrorMsg2.Substring(0, 10) <> "          " Then
                        ErrorMsg = tempErrorMsg1 & vbCrLf & tempErrorMsg2.PadLeft(79, " ")
                    Else
                        ErrorMsg = tempErrorMsg1
                    End If
                    If ErrorMsg.Substring(0, 6) <> " Perso" And ErrorMsg.Substring(0, 6) <> "Person" And ErrorMsg.Substring(0, 6) <> " Child" Then
                        WriteReport(Reader.GetString(0), Reader.GetString(5).Substring(0, 2), Reader.GetString(4).Substring(0, 2), Reader.GetString(3).Substring(0, 6), Reader.GetString(6).Substring(0, 7), ErrorMsg)
                    End If
                End While
                PrintReport()
            Catch ex As Exception
                MessageBox.Show("Location: BGW_PrintReport" & vbCrLf & ex.Message.ToString)
            Finally
                SQLConn.Close()
            End Try
        Else
            PrintCoverSheet()
        End If
    End Sub
    Private Sub BGW_PrintReport_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_PrintReport.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0
                menu_Print.Enabled = False
        End Select
    End Sub
    Private Sub BGW_PrintReport_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_PrintReport.RunWorkerCompleted
        Dim isLoop As Boolean = True
        If PrintChoice = "CoverSheet" Then
            SetInfo("Cover sheets printed.", False)
            menu_Print.Enabled = True
            Me.Cursor = Cursors.Default
        Else
            While isLoop
                Try
                    If File.Exists(My.Application.Info.DirectoryPath & "\MediStats.doc") Then File.Delete(My.Application.Info.DirectoryPath & "\MediStats.doc")
                    isLoop = False
                Catch ex As Exception
                    isLoop = True
                End Try
            End While
            SetInfo("Printed " & PrintChoice & " Cases Report.", False)
            menu_Print.Enabled = True
        End If
    End Sub
#End Region

End Class
