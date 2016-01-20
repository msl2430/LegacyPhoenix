Imports System.Net.Mail

Public Class MainScreen

    Private FileName As String
    Private isFileDone As Boolean
    Private LastCheckHour, LastCheckMin As Integer
    Private CaseList As New List(Of String)
    Private PageNumber As Integer
    Private File_Reader As StreamReader

    Private Sub MainScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Settings.phxSQLConn = "User ID=PhoenixUser;Data Source=" & My.Settings.SQLAddress & "\Phoenix;;FailOver Partner=192.168.204.3\Phoenix;Password=password;Initial Catalog=PhoenixData;" & _
                        "Connect Timeout=3;Integrated Security=False;Persist Security Info=False;"
        GetConfig()
        BatchNumber = "U999" & My.Settings.BatchNumber
        LastCheckHour = Date.Now.Hour.ToString.PadLeft(2, "0").Substring(0, 2)
        LastCheckMin = Date.Now.AddMinutes(-1).Minute.ToString.PadLeft(2, "0").Substring(0, 2)
        btn_Stop.Enabled = False
        menu_Stop.Enabled = False
    End Sub

    Private Sub GetConfig()
        Dim theFile As New StreamReader(My.Application.Info.DirectoryPath & "\phxConfig.dat", System.Text.Encoding.Default)
        Dim Reader As String
        While theFile.Peek <> -1
            Reader = theFile.ReadLine
            Select Case Reader.Substring(0, Reader.IndexOf(" "))
                Case "BatchNumber" : My.Settings.BatchNumber = Reader.Substring(Reader.IndexOf("=") + 2)
                Case "Password" : My.Settings.FAMISPassword = Reader.Substring(Reader.IndexOf("=") + 2)
            End Select
        End While
        theFile.Close()
    End Sub
    Public Sub SetConfig()
        Dim theFile As New StreamWriter(My.Application.Info.DirectoryPath & "\phxConfig.dat", False)
        theFile.WriteLine("BatchNumber = " & My.Settings.BatchNumber.PadLeft(3, "0"))
        theFile.WriteLine("Password = " & My.Settings.FAMISPassword.PadLeft(3, "0"))
        theFile.Close()
    End Sub

    Private Sub BlankOutMedicaidFields()
        BlankOutField(FAMISApplicationInformation.BH)
        BlankOutField(FAMISApplicationInformation.BQ)
        BlankOutField(FAMISApplicationInformation.EK)
        BlankOutField(FAMISApplicationInformation.EL)
        BlankOutField(FAMISApplicationInformation.EM)
        BlankOutField(FAMISApplicationInformation.EN)

        BlankOutField(FAMISIndividualsInformation.GB)
        BlankOutField(FAMISIndividualsInformation.GH)

        BlankOutField(FAMISMedicaidInformation.HD)
        BlankOutField(FAMISMedicaidInformation.HE)
        BlankOutField(FAMISMedicaidInformation.HI)
        BlankOutField(FAMISMedicaidInformation.HJ)
        BlankOutField(FAMISMedicaidInformation.HM)
        BlankOutField(FAMISMedicaidInformation.HQ)
        BlankOutField(FAMISMedicaidInformation.HR)
        BlankOutField(FAMISMedicaidInformation.WA)
        BlankOutField(FAMISMedicaidInformation.WB)
        BlankOutField(FAMISMedicaidInformation.WC)
        BlankOutField(FAMISMedicaidInformation.WD)
        BlankOutField(FAMISMedicaidInformation.WE)
        BlankOutField(FAMISMedicaidInformation.WF)
        BlankOutField(FAMISMedicaidInformation.WG)
        BlankOutField(FAMISMedicaidInformation.WH)
        BlankOutField(FAMISMedicaidInformation.WI)
        BlankOutField(FAMISMedicaidInformation.WL)
        BlankOutField(FAMISMedicaidInformation.WW)

        BlankOutField(FAMISIncomeInformation.JS)
    End Sub
    Private Sub BlankOutField(ByRef Block As FAMISBlock)
        Dim length As Integer = Block.Length
        Block.SetData(" ".PadRight(length))
    End Sub
    Private Sub BlankOutField(ByRef Block As FAMISBlock_Date)
        Dim length As Integer = Block.Length
        Block.SetData(" ".PadRight(length))
    End Sub

    Private Sub SendEmailMsg(ByVal errorMessage As String)
        Try
            Dim Message As New MailMessage
            Dim smtpHost As New SmtpClient("mail.pcbss.org")
            Message.To.Add("mikepcbss@gmail.com")
            Message.From = New MailAddress("mlevine@pcbss.org")
            Message.Subject = "IRF Processing had an error"
            Message.Body = "The Error received was: " & vbCrLf & errorMessage
            smtpHost.Send(Message)
        Catch ex As Exception
            MessageBox.Show("Location: SendEmailMsg:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub UpdateInfo(ByVal StringToWrite As String)
        Dim TimeOf As String = Date.Now.Hour.ToString.PadLeft(2, "0") & ":" & Date.Now.Minute.ToString.PadLeft(2, "0") & ":"
        If Date.Now.Second.ToString.Length > 2 Then TimeOf &= Date.Now.Second.ToString.Substring(0, 2) Else TimeOf &= Date.Now.Second.ToString.PadLeft(2, "0")
        If txt_Info.Text.Length > 30000 Then txt_Info.Text = Nothing
        txt_Info.Text = TimeOf & ">> " & StringToWrite & vbCrLf & txt_Info.Text
    End Sub

    Private Sub ProcessCase()
        Dim isOverride As Boolean = False
        isContinue = True
        isError = False
        CaseMessage = " ".PadRight(30, " ")

        BGW_ProcessCase.ReportProgress(0)
        SetCaseInfo()

        GLink_Start()
        If Not BGW_ProcessCase.CancellationPending And Not isError Then
            CheckCaseStatus()
            BlankOutMedicaidFields()
            If isContinue Then CreateBatch()
            Thread.Sleep(500)
            If isContinue And Not BGW_ProcessCase.CancellationPending Then
                Dim isClockAlert As Boolean = True  '--The clock warning on Page 1 of FAMIS requires an extra transmit to go through--
                Submit_Page1()
                glapiTP8.TransmitPage()
                While isClockAlert
                    If glapiTP8.GetString(1, 2, 6, 2) = "A-ADLT" Or glapiTP8.GetString(1, 2, 6, 2) = "B-ADLT" Or glapiTP8.GetString(1, 2, 5, 2) = "AADLT" Or glapiTP8.GetString(1, 2, 6, 2) = "BSANC=" Or glapiTP8.GetString(1, 2, 6, 2) = "ASANC=" Then
                        glapiTP8.TransmitPage()
                        Thread.Sleep(1000)
                    Else
                        isClockAlert = False
                    End If
                End While
                If glapiTP8.GetString(1, 2, 13, 2) = "CASE IN BATCH" Then
                    CaseMessage = "Case in Batch " & glapiTP8.GetString(15, 2, 22, 2)
                End If
                GLink_PageErrorCheck("01", "02", True)
            Else
                isContinue = False
            End If
            Thread.Sleep(125)
            If isContinue And Not BGW_ProcessCase.CancellationPending Then
                Submit_Page2()
                glapiTP8.TransmitPage()
                GLink_PageErrorCheck("02", "03", True)
            Else
                isContinue = False
            End If
            Thread.Sleep(125)
            If isContinue And Not BGW_ProcessCase.CancellationPending Then
                CloseCase()
                If glapiTP8.GetString(77, 1, 78, 1) = "11" Then
                    For i = 5 To 20
                        If glapiTP8.GetString(2, i, 2, i) = "-" Then
                            If glapiTP8.GetString(3, i, 3, i) <> "W" And glapiTP8.GetString(3, i, 5, i) <> "M52" And glapiTP8.GetString(3, i, 5, i) <> "C52" And glapiTP8.GetString(3, i, 5, i) <> "C58" And glapiTP8.GetString(3, i, 5, i) <> "M58" Then
                                CaseMessage = "Error in case"
                                BGW_ProcessCase.ReportProgress(98)
                                isContinue = True
                                isSuccessful = False
                                KillAllGLink()
                                GLink_Start()
                                Thread.Sleep(250)
                                CaseMessage = DeleteBatch()
                                Thread.Sleep(500)
                                BGW_ProcessCase.ReportProgress(99)
                                Try
                                    glapiTP8.Disconnect()
                                Catch ex As Exception
                                End Try
                                KillAllGLink()
                                LastBatchNumber = BatchNumber
                                Exit Sub
                            ElseIf glapiTP8.GetString(3, i, 5, i) = "M52" Or glapiTP8.GetString(3, i, 5, i) = "C52" Or glapiTP8.GetString(3, i, 5, i) = "C58" Or glapiTP8.GetString(3, i, 5, i) = "M58" Then
                                isOverride = False
                                CorrectIVD()
                                Exit For
                            Else
                                isOverride = True
                            End If
                        End If
                    Next
                    If isOverride Then
                        glapiTP8.SendKeysTransmit("OVER")
                        If glapiTP8.GetString(30, 2, 51, 2) = "BATCH BALANCING SCREEN" Then
                            Thread.Sleep(125)
                            CloseBatch()
                        End If
                    End If
                Else
                    Thread.Sleep(125)
                    CloseBatch()
                End If
            Else
                isContinue = False
            End If
        Else
            isContinue = False
        End If
        Try
            glapiTP8.Disconnect()
        Catch ex As Exception
        End Try
        KillAllGLink()
        LastBatchNumber = BatchNumber
        If isContinue Then
            isSuccessful = True
            StoreCase(isSuccessful, " ")
            BGW_ProcessCase.ReportProgress(100)
        Else
            isSuccessful = False
            If CaseMessage = Nothing Then CaseMessage = "User Cancelled"
            StoreCase(isSuccessful, CaseMessage)
            LogCase(False)
            BGW_ProcessCase.ReportProgress(98)
            KillAllGLink()
            GLink_Start()
            Thread.Sleep(250)
            CaseMessage = DeleteBatch()
            Thread.Sleep(500)
            BGW_ProcessCase.ReportProgress(99)
            Try
                glapiTP8.Disconnect()
            Catch ex As Exception
            End Try
            KillAllGLink()
        End If
    End Sub
    Private Sub CorrectIVD()
        '--IVD Fix--
        glapiTP8.SendCommand("02")
        glapiTP8.TransmitPage()
        glapiTP8.SubmitField(FAMISApplicationInformation.BH.FieldNumber, FAMISApplicationInformation.BH.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BQ.FieldNumber, FAMISApplicationInformation.BQ.GetData)
        glapiTP8.TransmitPage()
        If CaseChildCount > 0 Then
            For j As Integer = 0 To CaseChildCount - 1
                Select Case j
                    Case 0
                        glapiTP8.SendCommand("C")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "C")
                    Case 1
                        glapiTP8.SendCommand("D")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "D")
                    Case 2
                        glapiTP8.SendCommand("E")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "E")
                    Case 3
                        glapiTP8.SendCommand("F")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "F")
                    Case 4
                        glapiTP8.SendCommand("G")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "G")
                    Case 5
                        glapiTP8.SendCommand("H")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "H")
                    Case 6
                        glapiTP8.SendCommand("I")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "I")
                    Case 7
                        glapiTP8.SendCommand("J")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "J")
                    Case 8
                        glapiTP8.SendCommand("K")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "K")
                    Case 9
                        glapiTP8.SendCommand("L")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "L")
                    Case 10
                        glapiTP8.SendCommand("M")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "M")
                    Case 11
                        glapiTP8.SendCommand("N")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "N")
                    Case 12
                        glapiTP8.SendCommand("O")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "O")
                    Case 13
                        glapiTP8.SendCommand("P")
                        glapiTP8.TransmitPage()
                        glapiTP8.SubmitField(FAMISCaseChild(j).QA.FieldNumber, "P")
                End Select
                glapiTP8.TransmitPage()
                glapiTP8.SubmitField(FAMISCaseChild(j).TD.FieldNumber, FAMISCaseChild(j).TD.GetData)
            Next
            glapiTP8.SendCommand("ENDCASE")
            glapiTP8.TransmitPage()
            Thread.Sleep(150)
            If glapiTP8.GetString(30, 2, 51, 2) <> "BATCH BALANCING SCREEN" Then glapiTP8.SendKeysTransmit("OVER")
            CloseBatch()
        End If
    End Sub
    Private Sub GetCases(ByVal StartIndex As Integer)
        Dim theFile As New StreamReader(FileName, System.Text.Encoding.Default)
        Dim Record As String
        Dim CaseList As New List(Of String)
        Dim Index As Integer = 0
        Try
            While theFile.Peek <> -1 And Not BGW_ProcessCase.CancellationPending
                Record = theFile.ReadLine
                If Record <> Nothing And Record <> "" Then
                    CaseList.Add(Record.Replace("""", "").Replace(",", ""))
                End If
            End While
            For Index = StartIndex To CaseList.Count - 1
                CaseNumber = CaseList(Index)
                If CaseNumber.Length = 7 Then CaseNumber &= "016"
                ProcessCase()
                LogCase(isSuccessful)
                If isSuccessful Then
                    My.Settings.BatchNumber += 1
                    If My.Settings.BatchNumber > 999 Then My.Settings.BatchNumber = "001"
                    BatchNumber = "U999" & My.Settings.BatchNumber.PadLeft(3, "0")
                    SetConfig()
                End If
            Next

            If theFile.Peek = -1 Then isFileDone = True
            theFile.Close()
        Catch ex As Exception
            'MessageBox.Show(CaseNumber & " " & BatchNumber & vbCrLf & ex.Message)
            BGW_ProcessCase.ReportProgress(10, ex.Message)
            GetCases(Index)
        End Try
    End Sub
    Private Sub StoreCase(ByVal Result As Boolean, ByVal Reason As String)
        Dim SQLConn As New SqlConnection("User ID=PhoenixUser;Data Source=172.16.8.15\Phoenix;FailOver Partner=192.168.204.3;Password=password;Initial Catalog=PhoenixData;Connect Timeout=3;Integrated Security=False;Persist Security Info=True;") 'My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim tempResult As String
        If Result Then tempResult = "SUCCESS" Else tempResult = "FAILED"
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText = "INSERT INTO IRFCaseLog VALUES ('" & CaseNumber & "', '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "', '" & Date.Now.Hour.ToString.PadLeft(2, "0") & ":" & Date.Now.Minute.ToString.PadLeft(2, "0") & ":" & Date.Now.Second.ToString.PadLeft(2, "0") & ":" & Date.Now.Millisecond.ToString.PadLeft(2, "0") & "', '" & tempResult & "', '" & Reason & "')"
            SQLComm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Location: StoreCase" & vbCrLf & ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub LogCase(ByVal isCompleted As Boolean)
        Dim TimeOf As String = Date.Now.Hour.ToString.PadLeft(2, "0") & ":" & Date.Now.Minute.ToString.PadLeft(2, "0") & ":"
        If Date.Now.Second.ToString.Length > 2 Then TimeOf &= Date.Now.Second.ToString.Substring(0, 2) Else TimeOf &= Date.Now.Second.ToString.PadLeft(2, "0")
        Try
            Dim LogFile As New StreamWriter(My.Application.Info.DirectoryPath & "\IRFLog_" & Date.Now.Month.ToString & "_" & Date.Now.Day.ToString & "_" & Date.Now.Year.ToString & ".txt", True)
            If isCompleted Then
                LogFile.WriteLine(TimeOf & ">> Case: " & CaseNumber & " Batch Number: " & BatchNumber)
                LogFile.Close()
            Else
                LogFile.WriteLine(TimeOf & ">> Case: " & CaseNumber & " not completed. (" & CaseMessage & ")")
                LogFile.Close()
            End If
        Catch ex As Exception
            'MessageBox.Show(CaseNumber & " " & BatchNumber & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ProcessCaseList()
        Dim SQLConn As New SqlConnection("User ID=PhoenixUser;Data Source=172.16.8.15\Phoenix;FailOver Partner=192.168.204.3;Password=password;Initial Catalog=PhoenixData;Connect Timeout=3;Integrated Security=False;Persist Security Info=True;") 'My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        Dim tempDate As String
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText = "SELECT CaseNumber, Date, Time FROM IRFCaseQueue ORDER BY Date, Time"
            SQLReader = SQLComm.ExecuteReader
            If SQLReader.Read Then
                CaseNumber = SQLReader.GetString(0).Replace(" ", "")
                tempDate = SQLReader.GetDateTime(1).Month.ToString & "/" & SQLReader.GetDateTime(1).Day.ToString & "/" & SQLReader.GetDateTime(1).Year.ToString
                SQLReader.Close()
                SQLComm.CommandText = "DELETE FROM IRFCaseQueue WHERE CaseNumber = '" & CaseNumber & "' AND Date = '" & tempDate & "'"
                SQLComm.ExecuteNonQuery()
                If CaseNumber.Length = 7 Then CaseNumber &= "016"
                ProcessCase()
                LogCase(isSuccessful)
                If isSuccessful Then
                    My.Settings.BatchNumber += 1
                    If My.Settings.BatchNumber > 999 Then My.Settings.BatchNumber = "001"
                    BatchNumber = "U999" & My.Settings.BatchNumber.PadLeft(3, "0")
                    SetConfig()
                Else
                    If CaseMessage.Length >= 7 Then
                        If CaseMessage.Substring(0, 7) = "Case in" Or CaseMessage.Substring(0, 7) = "Case Nu" Then
                            For i As Integer = 0 To 2
                                KillAllGLink()
                                ProcessCase()
                                LogCase(isSuccessful)
                                If isSuccessful Then
                                    My.Settings.BatchNumber += 1
                                    If My.Settings.BatchNumber > 999 Then My.Settings.BatchNumber = "001"
                                    BatchNumber = "U999" & My.Settings.BatchNumber.PadLeft(3, "0")
                                    SetConfig()
                                    Exit For
                                End If
                            Next
                        Else
                            '--Code for error printing--
                        End If
                    Else
                        '--Code for error printing--
                    End If
                End If
            End If
        Catch ex As Exception
            Static Dim retryCount As Integer = 0
            While retryCount < 3
                ProcessCase()
                LogCase(isSuccessful)
                If isSuccessful Then
                    My.Settings.BatchNumber += 1
                    If My.Settings.BatchNumber > 999 Then My.Settings.BatchNumber = "001"
                    BatchNumber = "U999" & My.Settings.BatchNumber.PadLeft(3, "0")
                    SetConfig()
                    retryCount = 0
                    Exit Sub
                End If
                retryCount += 1
            End While
            retryCount = 0
            BGW_ProcessCase.ReportProgress(90, ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub CheckDirectory()
        Dim DirectoryLoc As New DirectoryInfo(FileDirectory)
        Dim FileList() As FileInfo
        FileList = DirectoryLoc.GetFiles()
        For i As Integer = 0 To FileList.Length - 1
            If FileList(i).Name = "IRF_NoChanges.xml" Then
                BGW_ProcessCase.ReportProgress(5)
                Thread.Sleep(500)
                CreateCaseList(FileList(i).FullName)
                If CaseList.Count > 0 Then BGW_ProcessCase.ReportProgress(6, CaseList.Count) Else BGW_ProcessCase.ReportProgress(7)
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
                        SQLComm.CommandText = "INSERT INTO IRFCaseQueue VALUES ('" & CaseList(i) & "', '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "', '" & Date.Now.Hour.ToString.PadLeft(2, "0") & ":" & Date.Now.Minute.ToString.PadLeft(2, "0") & ":" & Date.Now.Second.ToString.PadLeft(2, "0") & ":" & Date.Now.Millisecond.ToString.PadLeft(2, "0") & "')"
                        SQLComm.ExecuteNonQuery()
                    Next
                Catch ex As Exception
                    MessageBox.Show("Location: StoreCaseList" & vbCrLf & ex.Message)
                Finally
                    SQLConn.Close()
                End Try
            End If
        End Try

    End Sub

    Private Sub CreateReport()
        Dim SQLConn As New SqlConnection("User ID=PhoenixUser;Data Source=172.16.8.15\Phoenix;FailOver Partner=192.168.204.3;Password=password;Initial Catalog=PhoenixData;Connect Timeout=3;Integrated Security=False;Persist Security Info=True;") 'My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        Dim tempDate As String = Date.Today.Month & "/" & Date.Today.Day & "/" & Date.Today.Year
        SQLComm.Connection = SQLConn
        Try
            If File.Exists(My.Application.Info.DirectoryPath & "\IRFReport.txt") Then File.Delete(My.Application.Info.DirectoryPath & "\IRFReport.txt")
            Dim file_Writer As New StreamWriter(My.Application.Info.DirectoryPath & "\IRFReport.txt", True)
            file_Writer.WriteLine("                    IRF PROCESSING RESULTS                           " & tempDate)
            file_Writer.WriteLine(vbCrLf & "   Case Number  Result         Reason" & vbCrLf)

            SQLConn.Open()
            SQLComm.CommandText = "SELECT CaseNumber, Result, Reason FROM IRFCaseLog WHERE Date = '" & tempDate & "' ORDER BY Time"
            SQLReader = SQLComm.ExecuteReader
            While SQLReader.Read
                file_Writer.WriteLine("   " & SQLReader.GetString(0) & "     " & SQLReader.GetString(1) & "   " & SQLReader.GetString(2))
            End While
            file_Writer.Close()
            File_Reader = New StreamReader(My.Application.Info.DirectoryPath & "\IRFReport.txt", True)
            PageNumber = 1
            PrintDoc.Print()
            File_Reader.Close()
        Catch ex As Exception
            MessageBox.Show("Location: CreateReport" & vbCrLf & ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim linesPerPage As Single = 0
        Dim yPosition As Single = e.MarginBounds.Top / 2
        Dim count As Integer = 1
        Dim leftMargin As Single = e.MarginBounds.Left / 2
        Dim topMargin As Single = e.MarginBounds.Top / 2
        Dim line As String = Nothing
        Dim myBrush As New SolidBrush(Color.Black)
        Dim printFont As Font = btn_Start.Font
        linesPerPage = (e.MarginBounds.Height + topMargin) / printFont.GetHeight(e.Graphics)
        If PageNumber > 1 Then
            '--Add header to multiple pages--
            e.Graphics.DrawString("Page: " & PageNumber.ToString, printFont, myBrush, leftMargin, yPosition, New StringFormat)
            yPosition = topMargin + (count * printFont.GetHeight(e.Graphics))
            count += 1
            e.Graphics.DrawString(" ", printFont, myBrush, leftMargin, yPosition, New StringFormat)
            yPosition = topMargin + (count * printFont.GetHeight(e.Graphics))
            count += 1
        End If
        While count < linesPerPage
            line = File_Reader.ReadLine
            e.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, New StringFormat)
            yPosition = topMargin + (count * printFont.GetHeight(e.Graphics))
            count += 1
        End While
        If File_Reader.Peek <> -1 Then
            PageNumber += 1
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            myBrush.Dispose()
        End If
    End Sub

    Private Sub BGW_ProcessCase_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_ProcessCase.DoWork
        Static Dim isCheckDirectory As Boolean = True
        Dim isReportedPrinted As Boolean = False
        While Not BGW_ProcessCase.CancellationPending
            If (Date.Now.Hour < 18 And Date.Now.Hour > 6) Then
                'If Date.Now.Minute Mod 10 = 0 Then
                '    If isCheckDirectory = True Then
                '        isCheckDirectory = False
                '        CheckDirectory()
                '    End If
                'Else
                '    isCheckDirectory = True
                'End If
                ProcessCaseList()
                Thread.Sleep(5000)
            ElseIf Date.Now.Hour = 20 And Date.Now.Minute < 10 Then
                '    '--Delete file at 8:00pm and reset last check time to 6:00am--
                '    If File.Exists(FileDirectory & "IRF_NoChanges.xml") Then
                '        File.Delete(FileDirectory & "IRF_NoChanges.xml")
                '        LastCheckHour = 6
                '        LastCheckMin = 0
                isReportedPrinted = False
                '    End If
            End If
            If Date.Now.Hour = 20 And Date.Now.Minute = 0 And Not isReportedPrinted Then
                '--Print report 8:00--
                isReportedPrinted = True
                CreateReport()
            End If
        End While
    End Sub
    Private Sub BGW_ProcessCase_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_ProcessCase.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0
                UpdateInfo("Processing " & CaseNumber)
            Case 5
                UpdateInfo("XML file found. Adding cases to queue...")
            Case 6
                UpdateInfo("Added " & e.UserState & " cases to queue.")
                CaseList.Clear()
            Case 7
                UpdateInfo("No cases added to queue.")
            Case 10
                UpdateInfo(e.UserState)
            Case 90
                UpdateInfo("Case number: " & CaseNumber & " failed for reason - " & e.UserState)
            Case 98 '--Cancel Batch--
                UpdateInfo("Cancelling case " & CaseNumber & vbCrLf & "Reason - " & CaseMessage)
            Case 99 '--Batch Deleted--
                UpdateInfo(CaseMessage & " (" & LastBatchNumber & ")")
            Case 100 '--Case Processed--
                UpdateInfo(CaseNumber & " successfully processed. (" & LastBatchNumber & ")")
        End Select
    End Sub
    Private Sub BGW_ProcessCase_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_ProcessCase.RunWorkerCompleted
        'SendEmailMsg("IRF Processing was stopped for unknown reason.")
        txt_Status.Text = "Stopped"
        txt_Status.BackColor = Color.Red
        btn_Start.Enabled = True
        btn_Stop.Enabled = False
        UpdateInfo("Processing stopped.")
    End Sub

    Private Sub menu_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Exit.Click
        Me.Close()
    End Sub
    Private Sub btn_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Start.Click
        BGW_ProcessCase.RunWorkerAsync()
        txt_Status.Text = "Running"
        txt_Status.BackColor = Color.Green
        btn_Start.Enabled = False
        menu_Start.Enabled = False
        btn_Stop.Enabled = True
        menu_Stop.Enabled = False
        UpdateInfo("Processing started.")
    End Sub
    Private Sub menu_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Start.Click
        BGW_ProcessCase.RunWorkerAsync()
        txt_Status.Text = "Running"
        txt_Status.BackColor = Color.Green
        btn_Start.Enabled = False
        menu_Start.Enabled = False
        btn_Stop.Enabled = True
        menu_Stop.Enabled = True
        UpdateInfo("Processing started.")
    End Sub
    Private Sub btn_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Stop.Click
        BGW_ProcessCase.CancelAsync()
        txt_Status.Text = "Stopping..."
        txt_Status.BackColor = Color.OrangeRed
        btn_Stop.Enabled = False
        menu_Stop.Enabled = False
        btn_Start.Enabled = True
        menu_Start.Enabled = True
        UpdateInfo("Stopping processing...")
    End Sub
    Private Sub menu_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Stop.Click
        BGW_ProcessCase.CancelAsync()
        txt_Status.Text = "Stopping..."
        txt_Status.BackColor = Color.OrangeRed
        btn_Stop.Enabled = False
        menu_Stop.Enabled = False
        btn_Start.Enabled = True
        menu_Start.Enabled = True
        UpdateInfo("Stopping processing...")
    End Sub
    Private Sub menu_Password_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Password.Click
        Dim form As New ChangePassword
        Me.Enabled = False
        form.ShowDialog()
        SetConfig()
        GetConfig()
        Me.Enabled = True
    End Sub
    Private Sub menu_About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_About.Click
        MessageBox.Show("Phoenix - Auto IRF Processing" & vbCrLf & "Version: 1.0" & vbCrLf & "Developer: Michael Levine" & vbCrLf & "April 2010", "About", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub MainScreen_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SetConfig()
    End Sub


End Class
