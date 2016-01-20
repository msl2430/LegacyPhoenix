'--Developed by Michael Levine-- 4/7/2008
Module ClientData

    Public Structure CRLCase
        Public CaseNumber As String
        Public FirstName As String
        Public LastName As String
        Public Supervisor As String
        Public Worker As String
        Public CasePriority As String
        Public P05 As String
        Public P03 As String
        Public P09 As String
        Public RecertDate As Date
        Public CashRedetDate As Date
        Public MedRedetDate As Date
    End Structure

    Public CRLFile As String                 '--File name and location--
    Public CRLCaseList As List(Of CRLCase)   '--List of cases--
    Public Client_ParentControlScreen As ControlScreen
    Public isPause As Boolean                '--Pause processing--
    Public isContinue As Boolean             '--Continue prior CRL list--
    Public ClientErrorMessage As String

    Private Supervisor, Worker As String

    Public Sub GetClientData(ByVal isRestart As Boolean)
        Dim i As Integer
        CRLCaseList = New List(Of CRLCase)
        CRLCaseList.Clear()
        '     If Not isContinue And Not isRestart Then ReadCRL()
        MakeCaseList()
        If Not isRestart Then Client_ParentControlScreen.BGW_ClientData.ReportProgress(0)
        'ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf GetClientData2))
        While CRLCaseList.Count > 0 And Not Client_ParentControlScreen.BGW_ClientData.CancellationPending
            Try
                While (Date.Now.Hour > 17 Or Date.Now.Hour < 7) Or (Date.Now.DayOfWeek = DayOfWeek.Saturday Or Date.Now.DayOfWeek = DayOfWeek.Sunday)
                    Thread.Sleep(600000) 'ten minutes
                End While
                PauseProcess()
                ClientDataCaseNumber(0) = CRLCaseList.Item(0).CaseNumber
                GetSQLData(0)
                If isCaseExists Then
                    For i = 0 To SocialSecurityList.Count - 1
                        If SocialSecurityList(i) <> "         " Then
                            SocialSecurity(0) = SocialSecurityList(i)
                            FirstName(0) = FirstNameList(i)
                            LastName(0) = LastNameList(i)
                            DateOfBirth(0) = DateOfBirthList(i)
                            Supervisor = CRLCaseList(0).Supervisor
                            Worker = CRLCaseList(0).Worker

                            CasePriority = CRLCaseList(0).CasePriority
                            P05 = CRLCaseList(0).P05
                            P03 = CRLCaseList(0).P03
                            P09 = CRLCaseList(0).P09
                            RecertDate = CRLCaseList(0).RecertDate
                            CashRedetDate = CRLCaseList(0).CashRedetDate
                            MedRedetDate = CRLCaseList(0).MedRedetDate
                            Sex(0) = SexList(i)

                            StoreMasterData(0, 0)
                            Client_ParentControlScreen.BGW_ClientData.ReportProgress(3)
                            'FindClientData(0)
                        Else
                            Client_ParentControlScreen.BGW_ClientData.ReportProgress(98)
                        End If
                        If Client_ParentControlScreen.BGW_ClientData.CancellationPending Then Exit For
                    Next
                End If
                CRLCaseList.RemoveAt(0)
                RemoveCaseList(ClientDataCaseNumber(0))
                Client_ParentControlScreen.BGW_ClientData.ReportProgress(1)
            Catch ex As Exception
                '--log error--
                KillGLink()
                ClientErrorMessage = ex.Message
                Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
            End Try
        End While
    End Sub
    Public Sub GetClientData2(ByVal State As Object)
        Dim i, EndIndex As Integer
        Thread.Sleep(5000)
        While CRLCaseList.Count > 0 And Not Client_ParentControlScreen.BGW_ClientData.CancellationPending
            Try
                While (Date.Now.Hour > 17 Or Date.Now.Hour < 7) Or (Date.Now.DayOfWeek = DayOfWeek.Saturday Or Date.Now.DayOfWeek = DayOfWeek.Sunday)
                    Thread.Sleep(600000) 'ten minutes
                End While
                PauseProcess()
                If CRLCaseList.Count > 5 Then
                    EndIndex = CRLCaseList.Count - 1
                    ClientDataCaseNumber(1) = CRLCaseList.Item(EndIndex).CaseNumber
                    GetSQLData(1)
                    If isCaseExists Then
                        For i = 0 To SocialSecurityList.Count - 1
                            If SocialSecurityList(i) <> "         " Then
                                SocialSecurity(1) = SocialSecurityList(i)
                                FirstName(1) = FirstNameList(i)
                                LastName(1) = LastNameList(i)
                                DateOfBirth(1) = DateOfBirthList(i)
                                'Supervisor(1) = CRLCaseList(EndIndex).Supervisor
                                'Worker(1) = CRLCaseList(EndIndex).Worker
                                'CasePriority(1) = CRLCaseList(EndIndex).CasePriority
                                'P05(1) = CRLCaseList(EndIndex).P05
                                'P03(1) = CRLCaseList(EndIndex).P03
                                'P09(1) = CRLCaseList(EndIndex).P09
                                'RecertDate(1) = CRLCaseList(EndIndex).RecertDate
                                'CashRedetDate(1) = CRLCaseList(EndIndex).CashRedetDate
                                'MedRedetDate(1) = CRLCaseList(EndIndex).MedRedetDate
                                Sex(1) = SexList(i)
                                StoreMasterData(1, EndIndex)
                                Client_ParentControlScreen.BGW_ClientData.ReportProgress(4)
                                FindClientData(1)
                            Else
                                Client_ParentControlScreen.BGW_ClientData.ReportProgress(98)
                            End If
                            If Client_ParentControlScreen.BGW_ClientData.CancellationPending Then Exit For
                        Next
                    End If
                    CRLCaseList.RemoveAt(EndIndex)
                    RemoveCaseList(ClientDataCaseNumber(1))
                    Client_ParentControlScreen.BGW_ClientData.ReportProgress(1)
                End If
            Catch ex As Exception
                '--log error--
                KillGLink()
                ClientErrorMessage = ex.Message
                Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
            End Try
        End While
    End Sub
    Private Sub KillGLink()
        Dim GLProcess() As Process
        Dim i As Integer
        GLProcess = Process.GetProcessesByName("gl")
        If GLProcess.Length > 0 Then
            For i = 0 To GLProcess.Length - 1
                GLProcess(i).Kill()
            Next
        End If
    End Sub

    Private Sub ReadCRL()
        Dim infile As New StreamReader(CRLFile, System.Text.Encoding.Default)
        Dim Records As String
        Try
            While infile.Peek <> -1
                Records = infile.ReadLine()
                If Records <> Nothing Then
                    If Records.Substring(4, 10) = "SUPERVISOR" Then Supervisor = Records.Substring(17, 2)
                    If Records.Substring(4, 6) = "WORKER" Then Worker = Records.Substring(17, 2)
                    If (Records.Substring(2, 1) = "C" And Records.Substring(3, 3) <> "ASE") Or Records.Substring(2, 1) = "S" Then
                        'If Supervisor = "AG" Or Supervisor = "AJ" Or Supervisor = "AM" Then ReadCases(Records, infile)
                        'If Supervisor = "AN" Then ReadCases(Records)
                        ReadCases(Records, infile)
                    End If
                End If
            End While
            infile.Close()
        Catch ex As Exception
            MessageBox.Show("Location: ReadTextFile CRL" & vbCrLf & ex.Message.ToString)
        End Try
    End Sub
    Private Sub ReadCases(ByVal Records As String, ByVal inFile As StreamReader)
        Dim CaseNumber, FirstName, LastName As String
        If Records.Substring(12, 2) = "02" Or Records.Substring(12, 2) = "31" Or Records.Substring(12, 2) = "32" Or Records.Substring(12, 2) = "01" Then
            CaseNumber = Records.Substring(2, 7) & "016"
            FirstName = Records.Substring(40, 9)
            LastName = Records.Substring(27, 12)
            CasePriority = Records.Substring(12, 2)

            Records = inFile.ReadLine
            P05 = Records.Substring(31, 1)
            P03 = Records.Substring(38, 1)
            If Records.Substring(75, 8) <> "00000000" And Records.Substring(75, 8) <> "        " Then RecertDate = Records.Substring(75, 2) & "/" & Records.Substring(77, 2) & "/" & Records.Substring(79, 4) Else RecertDate = Nothing

            Records = inFile.ReadLine
            If Records.Substring(75, 8) <> "00000000" And Records.Substring(75, 8) <> "        " Then CashRedetDate = Records.Substring(75, 2) & "/" & Records.Substring(77, 2) & "/" & Records.Substring(79, 4) Else RecertDate = Nothing

            Records = inFile.ReadLine
            P09 = Records.Substring(31, 1)
            If Records.Substring(75, 8) <> "00000000" And Records.Substring(75, 8) <> "        " Then MedRedetDate = Records.Substring(75, 2) & "/" & Records.Substring(77, 2) & "/" & Records.Substring(79, 4) Else RecertDate = Nothing

            'MessageBox.Show(P05 & vbCrLf & P03 & vbCrLf & RecertDate(Index) & vbCrLf & CashRedetDate & vbCrLf & P09 & vbCrLf & MedRedetDate)
            AddCaseList(CaseNumber, FirstName, LastName, Supervisor, Worker)
            'AddCaseList(Records.Substring(2, 7) & "016", Records.Substring(40, 9), Records.Substring(27, 12), Supervisor, Worker)
        End If
    End Sub
    Private Sub MakeCaseList()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        Dim NewCase As CRLCase
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText = "SELECT * FROM CRLCaseList2"
            SQLReader = SQLComm.ExecuteReader
            While SQLReader.Read
                NewCase.CaseNumber = SQLReader.GetString(0)
                NewCase.FirstName = SQLReader.GetString(1)
                NewCase.LastName = SQLReader.GetString(2)
                NewCase.Supervisor = SQLReader.GetString(3)
                NewCase.Worker = SQLReader.GetString(4)
                NewCase.CasePriority = SQLReader.GetString(5)
                NewCase.P05 = SQLReader.GetString(6)
                NewCase.P03 = SQLReader.GetString(7)
                NewCase.P09 = SQLReader.GetString(8)
                NewCase.RecertDate = SQLReader.GetDateTime(9)
                NewCase.CashRedetDate = SQLReader.GetDateTime(10)
                NewCase.MedRedetDate = SQLReader.GetDateTime(11)
                CRLCaseList.Add(NewCase)
            End While
        Catch ex As Exception
            MessageBox.Show("Location: MakeCaseList" & vbCrLf & ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub AddCaseList(ByVal CaseNumber As String, ByVal FirstName As String, ByVal LastName As String, ByVal Supervisor As String, ByVal Worker As String)
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim tempRecertDate, tempMedRedetDate, tempCashRedetDate As String
        If RecertDate <> Nothing Then tempRecertDate = RecertDate.Month & "/" & RecertDate.Day & "/" & RecertDate.Year Else tempRecertDate = "        "
        If MedRedetDate <> Nothing Then tempMedRedetDate = MedRedetDate.Month & "/" & MedRedetDate.Day & "/" & MedRedetDate.Year Else tempMedRedetDate = "        "
        If CashRedetDate <> Nothing Then tempCashRedetDate = CashRedetDate.Month & "/" & CashRedetDate.Day & "/" & CashRedetDate.Year Else tempCashRedetDate = "        "
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText = "INSERT INTO CRLCaseList2 VALUES ('" & CaseNumber & "', '" & FirstName & "', '" & LastName & "', '" & Supervisor & "', '" & Worker & "', '" & CasePriority & "', '" & P05 & "', '" & P03 & "', '" & P09 & "', '" & tempRecertDate & "', '" & tempCashRedetDate & "', '" & tempMedRedetDate & "')"
            SQLComm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Location AddCaseList" & vbCrLf & ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub RemoveCaseList(ByVal CaseNumber As String)
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText = "DELETE FROM CRLCaseList2 WHERE CaseNumber = '" & CaseNumber & "'"
            SQLComm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Location RemoveCaseList" & vbCrLf & ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub

    Public Sub FindClientData(ByVal Index As Integer)
        If isCaseExists Then
            GetQuarterData(Index)
            Thread.Sleep(1250)
            '--TODO: Add message reporting--  'if not isquarterexists then **MESSAGE**
            PauseProcess()
            GetLaborData(Index)
            Thread.Sleep(1250)
            '--TODO: Add message reporting--  'if not islaborexists then **MESSAGE**
            PauseProcess()
            GetWagesData(Index)
            Thread.Sleep(1250)
            '--TODO: Add message reporting--  'if not iswagesexists then **MESSAGE**
            PauseProcess()
            GetDisabilityData(Index)
            Thread.Sleep(1250)
            '--TODO: Add message reporting--  'if not isdisabilityexists then **MESSAGE**
            PauseProcess()
            GetFindData(Index)
            Thread.Sleep(1250)
            '--TODO: Add message reporting--  'if not isfindexists then **MESSAGE**
            PauseProcess()
            GetSSIData(Index)
            Thread.Sleep(1250)
            '--TODO: Add message reporting--  'if not isSSIexists then **MESSAGE**
            PauseProcess()
            GetCSPData(Index)
            Thread.Sleep(1250)
            '--TODO: Add message reporting--  'if not iscspexists then **MESSAGE**
        Else
            '--No case on server--
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(98)
        End If
    End Sub
    Private Sub PauseProcess()
        Dim wasPaused As Boolean = False
        Thread.Sleep(200)
        While isPause
            Thread.Sleep(5000)
            If Not wasPaused Then Client_ParentControlScreen.BGW_ClientData.ReportProgress(10)
            wasPaused = True
        End While
        If wasPaused Then Client_ParentControlScreen.BGW_ClientData.ReportProgress(11)
    End Sub

    Private Sub StoreMasterData(ByVal Index As Integer, ByVal CaseListIndex As Integer)
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            'SQLComm.CommandText = "DELETE FROM MONTH_ClientDataMaster WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND Supervisor = '" & CRLCaseList(CaseListIndex).Supervisor & "' AND Worker = '" & CRLCaseList(CaseListIndex).Worker & "' AND CaseNumber = '" & ClientDataCaseNumber(Index) & "'"
            SQLComm.CommandText = "DELETE FROM MONTH_ClientDataMaster WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND CaseNumber = '" & ClientDataCaseNumber(Index) & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "INSERT INTO MONTH_ClientDataMaster VALUES ('" & SocialSecurity(Index) & "', '" & CRLCaseList(CaseListIndex).Supervisor & "', '" & CRLCaseList(CaseListIndex).Worker & "', '" & ClientDataCaseNumber(Index) & "', '" & FirstName(Index) & "', '" & LastName(Index) & "', '" & Address(Index) & "', '" & Address2(Index) & "', '" & City(Index) & "', '" & State(Index) & "', '" & ZipCode(Index) & "', '" & DateOfBirth(Index) & "', '" & Sex(Index) & "', '" & CRLCaseList(CaseListIndex).CasePriority & "', '" & CRLCaseList(CaseListIndex).P05 & "', '" & CRLCaseList(CaseListIndex).P03 & "', '" & CRLCaseList(CaseListIndex).P09 & "', '" & CRLCaseList(CaseListIndex).RecertDate.Month & "/" & CRLCaseList(CaseListIndex).RecertDate.Day & "/" & CRLCaseList(CaseListIndex).RecertDate.Year & "', '" & CRLCaseList(CaseListIndex).CashRedetDate.Month & "/" & CRLCaseList(CaseListIndex).CashRedetDate.Day & "/" & CRLCaseList(CaseListIndex).CashRedetDate.Year & "', '" & CRLCaseList(CaseListIndex).MedRedetDate.Month & "/" & CRLCaseList(CaseListIndex).MedRedetDate.Day & "/" & CRLCaseList(CaseListIndex).MedRedetDate.Year & "')"
            SQLComm.ExecuteNonQuery()
            'SQLComm.CommandText = "DELETE FROM ClientDataMaster WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND Supervisor = '" & CRLCaseList(CaseListIndex).Supervisor & "' AND Worker = '" & CRLCaseList(CaseListIndex).Worker & "' AND CaseNumber = '" & ClientDataCaseNumber(Index) & "'"
            SQLComm.CommandText = "DELETE FROM ClientDataMaster WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND CaseNumber = '" & ClientDataCaseNumber(Index) & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "INSERT INTO ClientDataMaster VALUES ('" & SocialSecurity(Index) & "', '" & CRLCaseList(CaseListIndex).Supervisor & "', '" & CRLCaseList(CaseListIndex).Worker & "', '" & ClientDataCaseNumber(Index) & "', '" & FirstName(Index) & "', '" & LastName(Index) & "', '" & Address(Index) & "', '" & Address2(Index) & "', '" & City(Index) & "', '" & State(Index) & "', '" & ZipCode(Index) & "', '" & DateOfBirth(Index) & "', '" & Sex(Index) & "', '" & CRLCaseList(CaseListIndex).CasePriority & "', '" & CRLCaseList(CaseListIndex).P05 & "', '" & CRLCaseList(CaseListIndex).P03 & "', '" & CRLCaseList(CaseListIndex).P09 & "', '" & CRLCaseList(CaseListIndex).RecertDate.Month & "/" & CRLCaseList(CaseListIndex).RecertDate.Day & "/" & CRLCaseList(CaseListIndex).RecertDate.Year & "', '" & CRLCaseList(CaseListIndex).CashRedetDate.Month & "/" & CRLCaseList(CaseListIndex).CashRedetDate.Day & "/" & CRLCaseList(CaseListIndex).CashRedetDate.Year & "', '" & CRLCaseList(CaseListIndex).MedRedetDate.Month & "/" & CRLCaseList(CaseListIndex).MedRedetDate.Day & "/" & CRLCaseList(CaseListIndex).MedRedetDate.Year & "')"
            SQLComm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Location: StoreMasterData" & vbCrLf & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Public Sub GetSQLData(ByVal Index As Integer)
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLNameConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLNameComm As New SqlCommand
        Dim SQLComm As New SqlCommand
        Dim SQLReader, SQLNameReader As SqlDataReader
        LastNameList = New List(Of String)
        FirstNameList = New List(Of String)
        SocialSecurityList = New List(Of String)
        DateOfBirthList = New List(Of String)
        SexList = New List(Of String)
        Try
            SQLConn.Open()
            SQLNameConn.Open()
            SQLNameComm.Connection = SQLNameConn
            SQLComm.Connection = SQLConn

            SQLComm.CommandText = "SELECT BA, BB, BJ, BK, CA, CC, CD1, CD2, CE FROM FAMISApplicantInformation WHERE CaseNumber = '" & ClientDataCaseNumber(Index) & "'"
            SQLReader = SQLComm.ExecuteReader
            If SQLReader.HasRows Then
                SQLReader.Read()
                isCaseExists = True
                Address2(Index) = SQLReader.GetString(4)
                Address(Index) = SQLReader.GetString(5)
                City(Index) = SQLReader.GetString(6)
                State(Index) = SQLReader.GetString(7)
                ZipCode(Index) = SQLReader.GetString(8)
                If Not SQLReader.GetString(0) = "            " Then
                    LastNameList.Add(SQLReader.GetString(0))
                    FirstNameList.Add(SQLReader.GetString(1))
                    SQLNameComm.CommandText = "SELECT FC, FB FROM FAMISIndividualsInformation WHERE CaseNumber = '" & ClientDataCaseNumber(Index) & "'"
                    SQLNameReader = SQLNameComm.ExecuteReader
                    SQLNameReader.Read()
                    If SQLNameReader.HasRows Then
                        SocialSecurityList.Add(SQLNameReader.GetString(0))
                        DateOfBirthList.Add(ConvertDate(SQLNameReader.GetDateTime(1)))
                        SexList.Add("F")
                    End If
                    SQLNameReader.Close()
                End If
                If Not SQLReader.GetString(2) = "            " Then
                    LastNameList.Add(SQLReader.GetString(2))
                    FirstNameList.Add(SQLReader.GetString(3))
                    SQLNameComm.CommandText = "SELECT FK, FJ FROM FAMISIndividualsInformation WHERE CaseNumber = '" & ClientDataCaseNumber(Index) & "'"
                    SQLNameReader = SQLNameComm.ExecuteReader
                    SQLNameReader.Read()
                    If SQLNameReader.HasRows Then
                        SocialSecurityList.Add(SQLNameReader.GetString(0))
                        DateOfBirthList.Add(ConvertDate(SQLNameReader.GetDateTime(1)))
                        SexList.Add("M")
                    End If
                    SQLNameReader.Close()
                End If
            Else
                isCaseExists = False
            End If
            SQLReader.Close()
        Catch ex As Exception
            KillGLink()
            ClientErrorMessage = "Location: GetSQLData > " & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Finally
            SQLConn.Close()
            SQLNameConn.Close()
        End Try
    End Sub
    Private Function ConvertDate(ByVal tempDate As Date) As String
        If tempDate = "1/1/1900" Then
            Return "        "
        Else
            Return tempDate.Month.ToString.PadLeft(2, "0") & tempDate.Day.ToString.PadLeft(2, "0") & tempDate.Year.ToString
        End If
        Return -1
    End Function
End Module
