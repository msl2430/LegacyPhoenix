'--Designed by: Michael Levine 1/2008--
Module CSPModule
    '--Automated CSP module--
    Private glapiCSP As connGLinkTP8

    Private Const FIELD_Menu As Integer = 4
    Private Const FIELD_SSN As Integer = 10
    Private Const FIELD_DCN As Integer = 34

    Private isDCNError As Boolean = False
    Private MainDCN As String
    Private Type, DCN, LastNameCSP, FirstNameCSP, MiddleCSP, SexCSP, DOB, Load, P, ST, CaseID As List(Of String)
    Private Index As Integer

    Public Sub GetCSPData(ByVal ThreadIndex As Integer)
        Index = ThreadIndex
        Try
            glinkStart_CSP()
            If isDCNError = False Then
                glapiCSP.SendKeysTransmit("DCNM")
                DCNScreen()
                GetDCNData()
                StoreSQL_CSP()
            Else
                '--Error handling--
                KillGLink()
                isDCNError = True
                ClientErrorMessage = "Location: GetCSPData > Error connecting to Child Support"
                Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
            End If
            glapiCSP.Disconnect()
        Catch ex As Exception
            KillGLink()
            isDCNError = True
            ClientErrorMessage = "Location: GetCSPData > " & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        End Try
    End Sub

    Private Sub StoreSQL_CSP()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim i As Integer
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn

            SQLComm.CommandText = "DELETE FROM CSPInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            For i = 0 To Type.Count - 1
                SQLComm.CommandText = "INSERT INTO CSPInformation VALUES ('" & SocialSecurity(Index) & "', '" & CaseID(i) & "', '" & Type(i) & "', '" & DCN(i) & "', '" & LastNameCSP(i) & "', '" & FirstNameCSP(i) & "', '" & MiddleCSP(i) & "', '" & SexCSP(i) & "', '" & DOB(i) & "', '" & Load(i) & "', '" & P(i) & "', '" & ST(i) & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
                SQLComm.ExecuteNonQuery()
            Next
        Catch ex As Exception
            'MessageBox.Show("Location: StoreSQL_SSI" & vbCrLf & ex.Message.ToString)
            KillGLink()
            ClientErrorMessage = "Location: StoreSQL_CSP > " & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub glinkStart_CSP()
        Dim Message As String = "          "
        Dim RetryCounter As Integer = 0
        Dim counter As Integer = 0
        Dim isLogonError As Boolean = False
        Dim isPasswordError As Boolean = False
        isDCNError = False
        glapiCSP = New connGLinkTP8("C:\GLPro\BullProd.cfg")
        While RetryCounter < 3
            glapiCSP.bool_Visible = True
            glapiCSP.Connect()
            'glapiCSP.SendKeysTransmit("HSA")
            'While glapiCSP.GetString(4, 7, 25, 7) <> "0100 YOU ARE CONNECTED" And counter < 30
            '    counter += 1
            '    Thread.Sleep(500)
            '    If counter = 30 Then
            '        isDCNError = True
            '        isLogonError = False
            '    End If
            'End While
            counter = 0
            If glapiCSP.GetString(4, 9, 28, 9) = "0200 YOU ARE DISCONNECTED" Then
                isDCNError = True
                isLogonError = False
            End If
            If Not isDCNError Then
                glapiCSP.SendKeysTransmit("LOGON")
                While glapiCSP.GetString(4, 21, 11, 21) <> "OPERATOR" And counter < 30
                    counter += 1
                    Thread.Sleep(500)
                    If counter = 30 Then
                        isDCNError = True
                        isLogonError = False
                    End If
                End While
                counter = 0
                If Not isDCNError Then
                    glapiCSP.SubmitField(4, My.Settings.IMPSOperator)
                    glapiCSP.SubmitField(6, My.Settings.IMPSPassword)
                    glapiCSP.SubmitField(8, My.Settings.FAMISKeyword)
                    glapiCSP.TransmitPage()
                    Message = glapiCSP.GetString(10, 22, 40, 22)
                End If
            End If
            If glapiCSP.GetString(30, 4, 37, 4) = "PASSWORD" Then
                glapiCSP.SetVisible(True)
                isPasswordError = True
                ' AbortProcessing()
            ElseIf Message.Substring(0, 5) = "     " Then
                '--No message provided by GLink--
                RetryCounter += 1
                isDCNError = True
                isLogonError = False
                Message = "Unknown GLink error. Please restart."
            ElseIf Message.Substring(0, 7) = "INVALID" Then
                '--Invalid password--
                RetryCounter = 3
                isDCNError = True
                isLogonError = True
                ' If Message.Substring(0, 15) = "INVALID KEYWORD" Then ParentForm_Put105.LoginErrorMsg = "Invalid keyword"
                '  If Message.Substring(0, 16) = "INVALID PASSWORD" Then ParentForm_Put105.LoginErrorMsg = "Invalid password"
            ElseIf Message.Substring(0, 8) = "OPERATOR" Then
                '--Operator already logged on--
                RetryCounter = 3
                isDCNError = True
                isLogonError = True
                'ParentForm_Put105.LoginErrorMsg = "Operator already logged on"
            ElseIf Message.Substring(0, 5) <> "LOGON" Then
                '--Double check that there is a message from GLink--
                RetryCounter += 1
                isDCNError = True
                isLogonError = True
                'ParentForm_Put105.LoginErrorMsg = Message
            Else
                RetryCounter = 3
                isDCNError = False
                isLogonError = False
            End If
            If isPasswordError = True Then '--eliminate at some point--
                isPasswordError = False
                isDCNError = False
                isLogonError = False
                '  setStatusLabel("Retrying...")
            ElseIf isDCNError = True And isLogonError = False Then
                If RetryCounter < 3 Then
                    glapiCSP.Disconnect()
                    ' setStatusLabel("GLink Error. Retrying... (Attempt " & RetryCounter + 1 & " of 3)")
                Else
                    'setStatusLabel(Message)
                    '         AbortProcessing()
                End If
            ElseIf isDCNError = True And isLogonError = True Then
                RetryCounter = 3
                ' setStatusLabel(Message)
                '  AbortProcessing()
            End If
            If isDCNError = False Then glapiCSP.TransmitPage()
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
    Private Sub DCNScreen()
        glapiCSP.SubmitField(FIELD_Menu, "1")
        glapiCSP.SubmitField(FIELD_SSN, SocialSecurity(Index))
        Thread.Sleep(250)
        If glapiCSP.GetString(3, 3, 11, 3) = "         " Then
            glapiCSP.SubmitField(FIELD_SSN, "         ")
            glapiCSP.SubmitField(14, SocialSecurity(Index))
        End If
        glapiCSP.TransmitPage()
        Thread.Sleep(250)
        MainDCN = glapiCSP.GetString(8, 7, 15, 7)
        glapiCSP.SubmitField(FIELD_Menu, "4")
        glapiCSP.SubmitField(FIELD_DCN, MainDCN)
        Thread.Sleep(250)
        If glapiCSP.GetString(72, 5, 79, 5) = "        " Then
            glapiCSP.SubmitField(FIELD_DCN, "        ")
            glapiCSP.SubmitField(38, MainDCN)
        End If
        glapiCSP.TransmitPage()
    End Sub
    Private Sub GetDCNData()
        Dim i As Integer
        Dim tempCaseID As String
        Type = New List(Of String)
        DCN = New List(Of String)
        LastNameCSP = New List(Of String)
        FirstNameCSP = New List(Of String)
        MiddleCSP = New List(Of String)
        SexCSP = New List(Of String)
        DOB = New List(Of String)
        Load = New List(Of String)
        P = New List(Of String)
        ST = New List(Of String)
        CaseID = New List(Of String)
        If glapiCSP.GetString(68, 6, 78, 6) <> "           " Then
            tempCaseID = glapiCSP.GetString(68, 6, 78, 6)
            For i = 7 To 23
                If glapiCSP.GetString(2, i, 4, i) <> "   " Then
                    CaseID.Add(tempCaseID)
                    Type.Add(glapiCSP.GetString(2, i, 4, i))
                    DCN.Add(glapiCSP.GetString(7, i, 14, i))
                    LastNameCSP.Add(glapiCSP.GetString(16, i, 32, i))
                    FirstNameCSP.Add(glapiCSP.GetString(34, i, 45, i))
                    MiddleCSP.Add(glapiCSP.GetString(47, i, 47, i))
                    SexCSP.Add(glapiCSP.GetString(49, i, 49, i))
                    DOB.Add(glapiCSP.GetString(51, i, 58, i))
                    If glapiCSP.GetString(61, i, 64, i) <> "LOAD" And glapiCSP.GetString(61, i, 64, i) <> "    " Then
                        Load.Add(glapiCSP.GetString(60, i, 65, i))
                        P.Add(glapiCSP.GetString(67, i, 67, i))
                        ST.Add(glapiCSP.GetString(70, i, 71, i))
                    Else
                        Load.Add("      ")
                        P.Add(" ")
                        ST.Add("  ")
                    End If
                Else
                    If glapiCSP.GetString(68, i, 78, i) <> "           " Then
                        '--New case ID--
                        tempCaseID = glapiCSP.GetString(68, i, 78, i)
                    ElseIf glapiCSP.GetString(10, 24, 37, 24) = "PRESS TRANSMIT FOR MORE DATA" Then
                        '--More information on other page--
                        '--Reset for loop and continue--
                        glapiCSP.TransmitPage()
                        i = 7
                    Else
                        '--No more information left--
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub
End Module
