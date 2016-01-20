'--Developed by: Michael Levine 11/2007--
Module ChildSupportModule
    '--Automated child support module--

    Private glapiChildSupport As connGLinkTP8

    Private Const IPAYMax As Integer = 21
    Private Const ChildMax As Integer = 24
    Private Const FIELD_Command As Integer = 2

    Private PaymentCount As Integer
    Private isError As Boolean
    Private APNameXREF, ClientNameXREF, CRTORDDate, EffectiveDate, Control, TotalArrears As String
    Private ClientCheckDate, Amount, Interest As String
    Private DueDate(IPAYMax), Charge(IPAYMax), TransDate(IPAYMax), PayAdjAmount(IPAYMax), ADJ(IPAYMax), SC(IPAYMax), PC(IPAYMax), ARRSOver(IPAYMax) As String
    Private APLastName, APFirstName, ChildLastName(ChildMax), ChildFirstName(ChildMax), COIND(ChildMax), ChildRace(ChildMax), ChildDOB(ChildMax), CLTREL(ChildMax) As String
    Private APAddress1, APAddress2, Race, Ethnic, Sex, DOB, SSN, EmployerName, EmployerAddress1, EmployerAddress2 As String

    Public Sub GetChildSupportData()
        glinkStart_ChildSupport()

        If Not isError Then
            glapiChildSupport.SendKeysTransmit("IOBL" & CSCaseNumber)
            If glapiChildSupport.GetString(15, 4, 25, 4) <> "           " Then
                '--Case exists--
                isChildSupportExists = True
                GetObligation()

                glapiChildSupport.SubmitField(FIELD_Command, "IPAY")
                glapiChildSupport.TransmitPage()
                GetPaymentHistory()

                glapiChildSupport.SubmitField(FIELD_Command, "ICHD")
                glapiChildSupport.TransmitPage()
                GetChildData()

                glapiChildSupport.SubmitField(FIELD_Command, "IAP1")
                glapiChildSupport.TransmitPage()
                GetAPData()

                StoreSQL_ChildSupport()
            Else
                '--Case doesn't exist--
                isChildSupportExists = False
            End If
        End If
        glapiChildSupport.Disconnect()
    End Sub

    Private Sub StoreSQL_ChildSupport()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim i As Integer
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn

            SQLComm.CommandText = "DELETE FROM CSAPinformation WHERE CSCaseNumber = '" & CSCaseNumber & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "DELETE FROM CSChildInformation WHERE CSCaseNumber = '" & CSCaseNumber & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "DELETE FROM CSObligationInformation WHERE CSCaseNumber = '" & CSCaseNumber & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "DELETE FROM CSPaymentInformation WHERE CSCaseNumber = '" & CSCaseNumber & "'"
            SQLComm.ExecuteNonQuery()

            SQLComm.CommandText = "INSERT INTO CSAPInformation VALUES ('" & CSCaseNumber & "', '" & APAddress1 & "', '" & APAddress2 & "', '" & Race & "', '" & Ethnic & "', '" & Sex & "', '" & DOB & "', '" & SSN.Replace("-", "") & "', '" & EmployerName & "', '" & EmployerAddress1 & "', '" & EmployerAddress2 & "')"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "INSERT INTO CSObligationInformation VALUES ('" & CSCaseNumber & "', '" & APNameXREF & "', '" & ClientNameXREF & "', '" & CRTORDDate & "', '" & EffectiveDate & "', '" & Control & "', '" & TotalArrears.Replace(" ", "") & "')"
            SQLComm.ExecuteNonQuery()

            For i = 0 To PaymentCount - 1
                If DueDate(i) <> "     " And DueDate(i) <> Nothing Then
                    SQLComm.CommandText = "INSERT INTO CSPaymentInformation VALUES ('" & CSCaseNumber & "', '" & ClientCheckDate & "', '" & Amount.Replace(" ", "") & "', '" & Interest.Replace(" ", "") & "', '" & DueDate(i) & "', '" & Charge(i).Replace(" ", "") & "', '" & TransDate(i) & "', '" & PayAdjAmount(i).Replace(" ", "") & "', '" & ADJ(i) & "', '" & SC(i) & "', '" & PC(i) & "', '" & ARRSOver(i).Replace(" ", "") & "')"
                    SQLComm.ExecuteNonQuery()
                Else
                    Exit For
                End If
            Next

            For i = 0 To ChildMax
                If ChildLastName(i) <> "                  " And ChildLastName(i) <> Nothing Then
                    SQLComm.CommandText = "INSERT INTO CSChildInformation VALUES ('" & CSCaseNumber & "', '" & APLastName & "', '" & APFirstName & "', '" & ChildLastName(i) & "', '" & ChildFirstName(i) & "', '" & COIND(i) & "', '" & ChildRace(i) & "', '" & ChildDOB(i) & "', '" & CLTREL(i) & "')"
                    SQLComm.ExecuteNonQuery()
                Else
                    Exit For
                End If
            Next
        Catch ex As Exception
            ' MessageBox.Show("Location: StoreSQL_ChildSupport" & vbCrLf & ex.Message.ToString)
            KillGLink()
            ClientErrorMessage = "Location: StoreChildSupport >" & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub glinkStart_ChildSupport()
        Dim Message As String = "          "
        Dim RetryCounter As Integer = 0
        Dim counter As Integer = 0
        Dim isLogonError As Boolean = False
        Dim isPasswordError As Boolean = False
        isError = False
        glapiChildSupport = New connGLinkTP8("C:\GLPro\BullProd.cfg")
        While RetryCounter < 3
            glapiChildSupport.bool_Visible = True
            glapiChildSupport.Connect()
            'glapiChildSupport.SendKeysTransmit("HSA")
            'While glapiChildSupport.GetString(4, 7, 25, 7) <> "0100 YOU ARE CONNECTED" And counter < 30
            '    counter += 1
            '    Thread.Sleep(500)
            '    If counter = 30 Then
            '        isError = True
            '        isLogonError = False
            '    End If
            'End While
            counter = 0
            If glapiChildSupport.GetString(4, 9, 28, 9) = "0200 YOU ARE DISCONNECTED" Then
                isError = True
                isLogonError = False
            End If
            If Not isError Then
                glapiChildSupport.SendKeysTransmit("LOGON")
                While glapiChildSupport.GetString(4, 21, 11, 21) <> "OPERATOR" And counter < 30
                    counter += 1
                    Thread.Sleep(500)
                    If counter = 30 Then
                        isError = True
                        isLogonError = False
                    End If
                End While
                counter = 0
                If Not isError Then
                    glapiChildSupport.SubmitField(4, My.Settings.IMPSOperator)
                    glapiChildSupport.SubmitField(6, My.Settings.IMPSPassword)
                    glapiChildSupport.SubmitField(8, My.Settings.FAMISKeyword)
                    glapiChildSupport.TransmitPage()
                    Message = glapiChildSupport.GetString(10, 22, 40, 22)
                End If
            End If
            If glapiChildSupport.GetString(30, 4, 37, 4) = "PASSWORD" Then
                glapiChildSupport.SetVisible(True)
                isPasswordError = True
            ElseIf Message.Substring(0, 5) = "     " Then
                '--No message provided by GLink--
                RetryCounter += 1
                isError = True
                isLogonError = False
                Message = "Unknown GLink error. Please restart."
            ElseIf Message.Substring(0, 7) = "INVALID" Then
                '--Invalid password--
                RetryCounter = 3
                isError = True
                isLogonError = True
            ElseIf Message.Substring(0, 8) = "OPERATOR" Then
                '--Operator already logged on--
                RetryCounter = 3
                isError = True
                isLogonError = True
            ElseIf Message.Substring(0, 5) <> "LOGON" Then
                '--Double check that there is a message from GLink--
                RetryCounter += 1
                isError = True
                isLogonError = True
            Else
                RetryCounter = 3
                isError = False
                isLogonError = False
            End If
            If isPasswordError = True Then '--eliminate at some point--
                isPasswordError = False
                isError = False
                isLogonError = False
            ElseIf isError = True And isLogonError = False Then
                If RetryCounter < 3 Then
                    glapiChildSupport.Disconnect()
                End If
            ElseIf isError = True And isLogonError = True Then
                RetryCounter = 3
            End If
            If isError = False Then glapiChildSupport.TransmitPage()
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
    Private Sub GetObligation()
        APNameXREF = glapiChildSupport.GetString(44, 4, 48, 4)
        ClientNameXREF = glapiChildSupport.GetString(72, 4, 76, 4)
        CRTORDDate = glapiChildSupport.GetString(21, 6, 28, 6)
        EffectiveDate = glapiChildSupport.GetString(33, 6, 40, 6)
        Control = glapiChildSupport.GetString(46, 6, 50, 6)
        TotalArrears = glapiChildSupport.GetString(52, 20, 60, 20)
    End Sub
    Private Sub GetPaymentHistory()
        Dim i As Integer = 0
        PaymentCount = 0
        ClientCheckDate = glapiChildSupport.GetString(32, 13, 39, 13)
        Amount = glapiChildSupport.GetString(48, 13, 57, 13)
        Interest = glapiChildSupport.GetString(70, 13, 79, 13)
        For i = 0 To 7
            If glapiChildSupport.GetString(3, 16 + i, 7, 16 + i) <> "     " Then
                DueDate(PaymentCount) = glapiChildSupport.GetString(3, 16 + i, 7, 16 + i)
                Charge(PaymentCount) = glapiChildSupport.GetString(14, 16 + i, 23, 16 + i)
                TransDate(PaymentCount) = glapiChildSupport.GetString(27, 16 + i, 34, 16 + i)
                PayAdjAmount(PaymentCount) = glapiChildSupport.GetString(38, 16 + i, 48, 16 + i)
                ADJ(PaymentCount) = glapiChildSupport.GetString(52, 16 + i, 54, 16 + i)
                SC(PaymentCount) = glapiChildSupport.GetString(59, 16 + i, 59, 16 + i)
                PC(PaymentCount) = glapiChildSupport.GetString(64, 16 + i, 64, 16 + i)
                ARRSOver(PaymentCount) = glapiChildSupport.GetString(68, 16 + i, 78, 16 + i)
                PaymentCount += 1
            End If
        Next
        If glapiChildSupport.GetString(3, 24, 11, 24) = "MORE DATA" Then
            glapiChildSupport.TransmitPage()
            For i = 0 To 13
                If glapiChildSupport.GetString(3, 8 + i, 7, 8 + i) <> "     " Then
                    DueDate(PaymentCount) = glapiChildSupport.GetString(3, 8 + i, 7, 8 + i)
                    Charge(PaymentCount) = glapiChildSupport.GetString(14, 8 + i, 23, 8 + i)
                    TransDate(PaymentCount) = glapiChildSupport.GetString(27, 8 + i, 34, 8 + i)
                    PayAdjAmount(PaymentCount) = glapiChildSupport.GetString(38, 8 + i, 48, 8 + i)
                    ADJ(PaymentCount) = glapiChildSupport.GetString(52, 8 + i, 54, 8 + i)
                    SC(PaymentCount) = glapiChildSupport.GetString(59, 8 + i, 59, 8 + i)
                    PC(PaymentCount) = glapiChildSupport.GetString(64, 8 + i, 64, 8 + i)
                    ARRSOver(PaymentCount) = glapiChildSupport.GetString(68, 8 + i, 78, 8 + i)
                    PaymentCount += 1
                End If
            Next
        End If
    End Sub
    Private Sub GetChildData()
        Dim i As Integer = 0
        Dim isFirstRun As Boolean = True
        APLastName = glapiChildSupport.GetString(22, 8, 39, 8)
        APFirstName = glapiChildSupport.GetString(49, 8, 60, 8)
        Do
            If isFirstRun = True Then isFirstRun = False Else glapiChildSupport.TransmitPage()
            ChildLastName(i) = glapiChildSupport.GetString(16, 12, 33, 12)
            ChildFirstName(i) = glapiChildSupport.GetString(43, 12, 54, 12)
            COIND(i) = glapiChildSupport.GetString(31, 13, 31, 13)
            ChildRace(i) = glapiChildSupport.GetString(44, 13, 44, 13)
            ChildDOB(i) = glapiChildSupport.GetString(67, 13, 76, 13)
            CLTREL(i) = glapiChildSupport.GetString(39, 14, 39, 14)
            i += 1
            ChildLastName(i) = glapiChildSupport.GetString(17, 18, 34, 18)
            ChildFirstName(i) = glapiChildSupport.GetString(44, 18, 55, 18)
            COIND(i) = glapiChildSupport.GetString(31, 19, 31, 19)
            ChildRace(i) = glapiChildSupport.GetString(44, 19, 44, 19)
            ChildDOB(i) = glapiChildSupport.GetString(67, 19, 76, 19)
            CLTREL(i) = glapiChildSupport.GetString(39, 20, 39, 20)
            i += 1
        Loop Until glapiChildSupport.GetString(2, 24, 14, 24) <> "MORE CHILDREN"
    End Sub
    Private Sub GetAPData()
        APAddress1 = glapiChildSupport.GetString(22, 8, 44, 8)
        APAddress2 = glapiChildSupport.GetString(22, 9, 44, 9)
        Race = glapiChildSupport.GetString(10, 12, 10, 12)
        Ethnic = glapiChildSupport.GetString(21, 12, 21, 12)
        Sex = glapiChildSupport.GetString(29, 12, 29, 12)
        DOB = glapiChildSupport.GetString(37, 12, 46, 12)
        SSN = glapiChildSupport.GetString(67, 12, 77, 12)
        EmployerName = glapiChildSupport.GetString(19, 17, 48, 17)
        EmployerAddress1 = glapiChildSupport.GetString(23, 18, 45, 18)
        EmployerAddress2 = glapiChildSupport.GetString(23, 19, 45, 19)
    End Sub
    Private Sub GetCheckInq()

    End Sub
End Module
