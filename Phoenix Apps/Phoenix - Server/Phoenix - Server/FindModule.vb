'--Designed by: Michael Levine 10/2007--
Module FindModule
    '--Autotmated find module--

    Private glapiFind As connGLinkTP8

    Private Const CaseMax As Integer = 10
    Private Const FIELD_Segment As Integer = 8
    Private Const FIELD_LastName As Integer = 10
    Private Const FIELD_FirstName As Integer = 12
    Private Const FIELD_SocialSecurity As Integer = 30

    Private isFindError As Boolean = False
    Private LastNameFind, FirstNameFind, County, FINDCaseNumber, PC, Sex, Race, DOB, SUP, Seg, PI, IST, FST As List(Of String)
    Private Index As Integer

    Public Sub GetFindData(ByVal ThreadIndex As Integer)
        Index = ThreadIndex
        glinkStart_Find()

        If Not isFindError Then
            glapiFind.SendKeysTransmit("FIND")
            FindScreen()
            GetCaseData()
            StoreSQL_Find()
        Else
            '--Error reporting--
            isFindExists = False
        End If

        glapiFind.Disconnect()
    End Sub

    Private Sub StoreSQL_Find()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim i As Integer
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn

            SQLComm.CommandText = "DELETE FROM FAMISFindInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()

            For i = 0 To LastNameFind.Count - 1
                SQLComm.CommandText = "INSERT INTO FAMISFindInformation VALUES ('" & SocialSecurity(Index) & "', '" & LastNameFind(i) & "', '" & FirstNameFind(i) & "', '" & County(i) & "', '" & FINDCaseNumber(i) & "', '" & PC(i) & "', '" & Sex(i) & "', '" & Race(i) & "', '" & DOB(i) & "', '" & SUP(i) & "', '" & Seg(i) & "', '" & PI(i) & "', '" & IST(i) & "', '" & FST(i) & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
                SQLComm.ExecuteNonQuery()
            Next
        Catch ex As Exception
            'MessageBox.Show("Location: StoreSQL_Find" & vbCrLf & ex.Message.ToString)
            KillGLink()
            ClientErrorMessage = "Location: StoreSQL_Find > " & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub glinkStart_Find()
        Dim Message As String = "          "
        Dim RetryCounter As Integer = 0
        Dim counter As Integer = 0
        Dim isLogonError As Boolean = False
        Dim isPasswordError As Boolean = False
        isFindError = False
        glapiFind = New connGLinkTP8("C:\GLPro\BullProd.cfg")
        While RetryCounter < 3
            glapiFind.bool_Visible = True
            glapiFind.Connect()
            glapiFind.SendKeysTransmit("HSA")
            'While glapiFind.GetString(4, 7, 25, 7) <> "0100 YOU ARE CONNECTED" And counter < 30
            '    counter += 1
            '    Thread.Sleep(500)
            '    If counter = 30 Then
            '        isFindError = True
            '        isLogonError = False
            '    End If
            'End While
            counter = 0
            If glapiFind.GetString(4, 9, 28, 9) = "0200 YOU ARE DISCONNECTED" Then
                isFindError = True
                isLogonError = False
            End If
            If Not isFindError Then
                glapiFind.SendKeysTransmit("LOGON")
                While glapiFind.GetString(4, 21, 11, 21) <> "OPERATOR" And counter < 30
                    counter += 1
                    Thread.Sleep(500)
                    If counter = 30 Then
                        isFindError = True
                        isLogonError = False
                    End If
                End While
                counter = 0
                If Not isFindError Then
                    glapiFind.SubmitField(4, My.Settings.IMPSOperator)
                    glapiFind.SubmitField(6, My.Settings.IMPSPassword)
                    glapiFind.SubmitField(8, My.Settings.FAMISKeyword)
                    glapiFind.TransmitPage()
                    Message = glapiFind.GetString(10, 22, 40, 22)
                End If
            End If
            If glapiFind.GetString(30, 4, 37, 4) = "PASSWORD" Then
                glapiFind.SetVisible(True)
                isPasswordError = True
                ' AbortProcessing()
            ElseIf Message.Substring(0, 5) = "     " Then
                '--No message provided by GLink--
                RetryCounter += 1
                isFindError = True
                isLogonError = False
                Message = "Unknown GLink error. Please restart."
            ElseIf Message.Substring(0, 7) = "INVALID" Then
                '--Invalid password--
                RetryCounter = 3
                isFindError = True
                isLogonError = True
                ' If Message.Substring(0, 15) = "INVALID KEYWORD" Then ParentForm_Put105.LoginErrorMsg = "Invalid keyword"
                '  If Message.Substring(0, 16) = "INVALID PASSWORD" Then ParentForm_Put105.LoginErrorMsg = "Invalid password"
            ElseIf Message.Substring(0, 8) = "OPERATOR" Then
                '--Operator already logged on--
                RetryCounter = 3
                isFindError = True
                isLogonError = True
                'ParentForm_Put105.LoginErrorMsg = "Operator already logged on"
            ElseIf Message.Substring(0, 5) <> "LOGON" Then
                '--Double check that there is a message from GLink--
                RetryCounter += 1
                isFindError = True
                isLogonError = True
                'ParentForm_Put105.LoginErrorMsg = Message
            Else
                RetryCounter = 3
                isFindError = False
                isLogonError = False
            End If
            If isPasswordError = True Then '--eliminate at some point--
                isPasswordError = False
                isFindError = False
                isLogonError = False
                '  setStatusLabel("Retrying...")
            ElseIf isFindError = True And isLogonError = False Then
                If RetryCounter < 3 Then
                    glapiFind.Disconnect()
                    ' setStatusLabel("GLink Error. Retrying... (Attempt " & RetryCounter + 1 & " of 3)")
                Else
                    'setStatusLabel(Message)
                    '         AbortProcessing()
                End If
            ElseIf isFindError = True And isLogonError = True Then
                RetryCounter = 3
                ' setStatusLabel(Message)
                '  AbortProcessing()
            End If
            If isFindError = False Then glapiFind.TransmitPage()
            Thread.Sleep(500)
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

    Private Sub FindScreen()
        glapiFind.SubmitField(FIELD_Segment, "ALL")
        glapiFind.SubmitField(FIELD_LastName, LastName(Index))
        glapiFind.SubmitField(FIELD_FirstName, FirstName(Index))
        glapiFind.SubmitField(FIELD_SocialSecurity, SocialSecurity(Index))
        glapiFind.TransmitPage()
    End Sub
    Private Sub GetCaseData()
        Dim i As Integer
        LastNameFind = New List(Of String)
        FirstNameFind = New List(Of String)
        County = New List(Of String)
        FINDCaseNumber = New List(Of String)
        PC = New List(Of String)
        Sex = New List(Of String)
        Race = New List(Of String)
        DOB = New List(Of String)
        SUP = New List(Of String)
        Seg = New List(Of String)
        PI = New List(Of String)
        IST = New List(Of String)
        FST = New List(Of String)
        For i = 0 To CaseMax - 1
            If glapiFind.GetString(58, 4 + i, 66, 4 + i) = SocialSecurity(Index) And glapiFind.GetString(30, 4 + i, 31, 4 + i) = "16" Then
                isFindExists = True
                LastNameFind.Add(glapiFind.GetString(5, 4 + i, 16, 4 + i))
                FirstNameFind.Add(glapiFind.GetString(18, 4 + i, 28, 4 + i))
                County.Add(glapiFind.GetString(30, 4 + i, 31, 4 + i))
                FINDCaseNumber.Add(glapiFind.GetString(33, 4 + i, 39, 4 + i) & "016")
                PC.Add(glapiFind.GetString(44, 4 + i, 45, 4 + i))
                Sex.Add(glapiFind.GetString(47, 4 + i, 47, 4 + i))
                Race.Add(glapiFind.GetString(49, 4 + i, 49, 4 + i))
                DOB.Add(glapiFind.GetString(51, 4 + i, 56, 4 + i))
                SUP.Add(glapiFind.GetString(68, 4 + i, 69, 4 + i))
                Seg.Add(glapiFind.GetString(71, 4 + i, 73, 4 + i))
                PI.Add(glapiFind.GetString(75, 4 + i, 75, 4 + i))
                IST.Add(glapiFind.GetString(77, 4 + i, 77, 4 + i))
                FST.Add(glapiFind.GetString(79, 4 + i, 79, 4 + i))
            End If
        Next
    End Sub
End Module
