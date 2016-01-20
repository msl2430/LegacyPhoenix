'--Designed by: Michael Levine 1/2008--
Module SSIModule
    '--Automated SSI module--
    Private glapiSSI As connGLinkTP8

    Private Const FIELD_SSN As Integer = 6
    Private Const FIELD_Page As Integer = 8

    Private isSSIError As Boolean = False
    Private ApplicationDate, RecipientSSN, ClaimNumber, Address1, Address2, Address3, CitySSI, StateSSI, RecipientTypeCode, LastNameSSI, FirstNameSSI, DOB, MaritalStatus, SSIMonthAmount, MedEffDate As String
    Private SSIGrossPayAmt, STSuppGrossPayAmt, EarnedIncomeAmt, StartDate As String
    Private Index As Integer

    Public Sub GetSSIData(ByVal ThreadIndex As Integer)
        Index = ThreadIndex
        glinkStart_SSI()
        If Not isSSIError Then
            glapiSSI.SendKeysTransmit("SDXI")
            SSIScreen()
            Thread.Sleep(500)
            GetPage1Data()
            Thread.Sleep(500)
            If isSSIExists Then
                glapiSSI.SubmitField(FIELD_Page, "03")
                glapiSSI.TransmitPage()
                GetPage3Data()
                If isSSIExists = True Then StoreSQL_SSI()
            End If
        Else
            '--Error reporting--
            isSSIError = True
        End If
        glapiSSI.Disconnect()
    End Sub

    Private Sub StoreSQL_SSI()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn

            SQLComm.CommandText = "DELETE FROM SSIInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "INSERT INTO SSIInformation VALUES ('" & SocialSecurity(Index) & "', '" & ApplicationDate & "', '" & RecipientSSN & "', '" & ClaimNumber & "', '" & Address1.Replace("'", "") & "', '" & Address2.Replace("'", "") & "', '" & Address3.Replace("'", "") & "', '" & CitySSI & "', '" & StateSSI & "', '" & RecipientTypeCode & "', '" & LastNameSSI & "', '" & FirstNameSSI & "', '" & DOB & "', '" & MaritalStatus & "', '" & SSIMonthAmount & "', '" & MedEffDate & "', '" & SSIGrossPayAmt & "', '" & STSuppGrossPayAmt & "', '" & EarnedIncomeAmt & "', '" & StartDate & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
            SQLComm.ExecuteNonQuery()
        Catch ex As Exception
            'MessageBox.Show("Location: StoreSQL_SSI" & vbCrLf & ex.Message.ToString)
            KillGLink()
            ClientErrorMessage = "Location: StoreSQL_SSI > " & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub glinkStart_SSI()
        Dim Message As String = "          "
        Dim RetryCounter As Integer = 0
        Dim counter As Integer = 0
        Dim isLogonError As Boolean = False
        Dim isPasswordError As Boolean = False
        isSSIError = False
        glapiSSI = New connGLinkTP8("C:\GLPro\BullProd.cfg")
        While RetryCounter < 3
            glapiSSI.bool_Visible = True
            glapiSSI.Connect()
            'glapiSSI.SendKeysTransmit("HSA")
            'While glapiSSI.GetString(4, 7, 25, 7) <> "0100 YOU ARE CONNECTED" And counter < 30
            '    counter += 1
            '    Thread.Sleep(500)
            '    If counter = 30 Then
            '        isSSIError = True
            '        isLogonError = False
            '    End If
            'End While
            counter = 0
            If glapiSSI.GetString(4, 9, 28, 9) = "0200 YOU ARE DISCONNECTED" Then
                isSSIError = True
                isLogonError = False
            End If
            If Not isSSIError Then
                glapiSSI.SendKeysTransmit("LOGON")
                While glapiSSI.GetString(4, 21, 11, 21) <> "OPERATOR" And counter < 30
                    counter += 1
                    Thread.Sleep(500)
                    If counter = 30 Then
                        isSSIError = True
                        isLogonError = False
                    End If
                End While
                counter = 0
                If Not isSSIError Then
                    glapiSSI.SubmitField(4, My.Settings.IMPSOperator)
                    glapiSSI.SubmitField(6, My.Settings.IMPSPassword)
                    glapiSSI.SubmitField(8, My.Settings.FAMISKeyword)
                    glapiSSI.TransmitPage()
                    Message = glapiSSI.GetString(10, 22, 40, 22)
                End If
            End If
            If glapiSSI.GetString(30, 4, 37, 4) = "PASSWORD" Then
                glapiSSI.SetVisible(True)
                isPasswordError = True
                ' AbortProcessing()
            ElseIf Message.Substring(0, 5) = "     " Then
                '--No message provided by GLink--
                RetryCounter += 1
                isSSIError = True
                isLogonError = False
                Message = "Unknown GLink error. Please restart."
            ElseIf Message.Substring(0, 7) = "INVALID" Then
                '--Invalid password--
                RetryCounter = 3
                isSSIError = True
                isLogonError = True
                ' If Message.Substring(0, 15) = "INVALID KEYWORD" Then ParentForm_Put105.LoginErrorMsg = "Invalid keyword"
                '  If Message.Substring(0, 16) = "INVALID PASSWORD" Then ParentForm_Put105.LoginErrorMsg = "Invalid password"
            ElseIf Message.Substring(0, 8) = "OPERATOR" Then
                '--Operator already logged on--
                RetryCounter = 3
                isSSIError = True
                isLogonError = True
                'ParentForm_Put105.LoginErrorMsg = "Operator already logged on"
            ElseIf Message.Substring(0, 5) <> "LOGON" Then
                '--Double check that there is a message from GLink--
                RetryCounter += 1
                isSSIError = True
                isLogonError = True
                'ParentForm_Put105.LoginErrorMsg = Message
            Else
                RetryCounter = 3
                isSSIError = False
                isLogonError = False
            End If
            If isPasswordError = True Then '--eliminate at some point--
                isPasswordError = False
                isSSIError = False
                isLogonError = False
                '  setStatusLabel("Retrying...")
            ElseIf isSSIError = True And isLogonError = False Then
                If RetryCounter < 3 Then
                    glapiSSI.Disconnect()
                    ' setStatusLabel("GLink Error. Retrying... (Attempt " & RetryCounter + 1 & " of 3)")
                Else
                    'setStatusLabel(Message)
                    '         AbortProcessing()
                End If
            ElseIf isSSIError = True And isLogonError = True Then
                RetryCounter = 3
                ' setStatusLabel(Message)
                '  AbortProcessing()
            End If
            If isSSIError = False Then glapiSSI.TransmitPage()
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
    Private Sub SSIScreen()
        glapiSSI.SubmitField(FIELD_SSN, SocialSecurity(Index))
        glapiSSI.SubmitField(FIELD_Page, "01")
        glapiSSI.TransmitPage()
    End Sub
    Private Sub GetPage1Data()
        If glapiSSI.GetString(1, 3, 18, 3) <> "SSN DOES NOT EXIST" Then
            isSSIExists = True
            ApplicationDate = glapiSSI.GetString(71, 4, 80, 4)
            RecipientSSN = glapiSSI.GetString(15, 7, 25, 7)
            ClaimNumber = glapiSSI.GetString(15, 8, 24, 8)
            Address1 = glapiSSI.GetString(35, 7, 54, 7).Replace(" ", "")
            Address2 = glapiSSI.GetString(35, 8, 54, 8).Replace(" ", "")
            Address3 = glapiSSI.GetString(35, 9, 54, 9).Replace(" ", "")
            CitySSI = glapiSSI.GetString(35, 10, 54, 10).Replace(" ", "")
            StateSSI = glapiSSI.GetString(55, 10, 56, 10)
            RecipientTypeCode = glapiSSI.GetString(15, 9, 16, 9)
            LastNameSSI = glapiSSI.GetString(15, 10, 22, 10).Replace(" ", "")
            FirstNameSSI = glapiSSI.GetString(15, 11, 22, 11).Replace(" ", "")
            DOB = glapiSSI.GetString(15, 15, 24, 15)
            MaritalStatus = glapiSSI.GetString(15, 16, 15, 16)
            SSIMonthAmount = glapiSSI.GetString(47, 22, 54, 22).Replace(" ", "")
            MedEffDate = glapiSSI.GetString(71, 16, 80, 16)
            If MedEffDate = "00/00/0000" Then MedEffDate = Nothing
        Else
            isSSIExists = False
        End If
    End Sub
    Private Sub GetPage3Data()
        SSIGrossPayAmt = glapiSSI.GetString(24, 11, 30, 11)
        STSuppGrossPayAmt = glapiSSI.GetString(73, 15, 79, 15)
        EarnedIncomeAmt = glapiSSI.GetString(44, 16, 50, 16)
        StartDate = glapiSSI.GetString(36, 7, 42, 7)
    End Sub
End Module
