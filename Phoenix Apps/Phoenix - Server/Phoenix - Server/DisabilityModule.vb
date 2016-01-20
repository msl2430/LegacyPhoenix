'--Designed by: Michael Levine 11/2007--
Module DisabilityModule
    '--Automated disability module--

    Private glapiDisability As connGLinkMedi

    Private Const PaymentMax As Integer = 12
    Private Const ClaimMax As Integer = 12
    Private Const FIELD_TI10Menu As Integer = 14
    Private Const FIELD_SSNDisability As Integer = 11
    Private Const FIELD_ClaimSummary As Integer = 142
    Private Const FIELD_PaymentInq As Integer = 161
    Private Const FIELD_ESMenu As Integer = 17
    Private Const FIELD_RSMenu As Integer = 29

    Private isErrorDisability As Boolean
    Private CaseStatus, D_Date, C_Date, EOD, WBR_Disability, MBA_Disability, BenPaidToDate, ClaimBalance, NumOfEmployers, GrossAmt, NetAmt As String
    Private ClaimTotal As Integer
    Private OtherClaimDate(ClaimMax) As String
    Private CheckDate(PaymentMax), PEDate(PaymentMax), CheckNum(PaymentMax), NetPaid(PaymentMax), DaysPaid(PaymentMax), PMTCode(PaymentMax), ADJCode(PaymentMax), VoidCode(PaymentMax), GrossCur(PaymentMax) As String
    Private EmployerName
    Private Index As Integer

    Public Sub GetDisabilityData(ByVal ThreadIndex As Integer)
        Index = ThreadIndex
        ClaimTotal = 0

        glinkStart_Disability()
        If isErrorDisability Then

        Else
            TI10Screen()
            If glapiDisability.GetString(6, 22, 13, 22) <> "NO CLAIM" Then
                isDisabilityExists = True
                GetClaimSummary()
                'GetOtherClaims()
                glapiDisability.SubmitField(FIELD_ClaimSummary, "py")
                glapiDisability.TransmitPage()
                GetPaymentInq()

                '--TODO: Possibly needed but held off for now--
                'glapiDisability.SubmitField(FIELD_PaymentInq, "22")
                'glapiDisability.TransmitPage()
                'glapiDisability.SubmitField(FIELD_ESMenu, "S")
                'glapiDisability.TransmitPage()
                'glapiDisability.SubmitField(FIELD_RSMenu, "S")
                'glapiDisability.TransmitPage()

                StoreSQL_Disability()
            Else
                isDisabilityExists = False
            End If
        End If
        glapiDisability.Disconnect()
    End Sub

    Private Sub StoreSQL_Disability()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim i As Integer
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn

            'SQLComm.CommandText = "DELETE FROM DISABILITYClaimDatesInformation WHERE SocialSecurity = '" & SocialSecurity & "'"
            'SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "DELETE FROM DISABILITYClaimSummaryInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "DELETE FROM DISABILITYPaymentInqInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()

            SQLComm.CommandText = "INSERT INTO DISABILITYClaimSummaryInformation VALUES ('" & SocialSecurity(Index) & "', '" & CaseStatus & "', '" & D_Date & "', '" & C_Date & "', '" & EOD & "', '" & WBR_Disability.Replace(" ", "") & "', '" & MBA_Disability.Replace(" ", "") & "', '" & BenPaidToDate.Replace(" ", "") & "', '" & NumOfEmployers.Replace(" ", "") & "', '" & NetAmt.Replace(" ", "") & "', '" & GrossAmt.Replace(" ", "") & "', '" & ClaimBalance.Replace(" ", "") & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
            SQLComm.ExecuteNonQuery()

            For i = 0 To PaymentMax - 1
                If CheckDate(i) <> "        " Then
                    SQLComm.CommandText = "INSERT INTO DISABILITYPaymentInqInformation VALUES ('" & SocialSecurity(Index) & "', '" & CheckDate(i) & "', '" & PEDate(i) & "', '" & CheckNum(i) & "', '" & NetPaid(i).Replace(" ", "") & "', '" & DaysPaid(i).Replace(" ", "") & "', '" & PMTCode(i) & "', '" & ADJCode(i) & "', '" & VoidCode(i) & "', '" & GrossCur(i).Replace(" ", "") & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
                    SQLComm.ExecuteNonQuery()
                End If
            Next

            'For i = 0 To ClaimTotal - 1
            '    SQLComm.CommandText = "INSERT INTO DISABILITYClaimdatesInformation VALUES ('" & SocialSecurity & "', '" & OtherClaimDate(i) & "')"
            '    SQLComm.ExecuteNonQuery()
            'Next
        Catch ex As Exception
            'MessageBox.Show("Location: StoreSQL_Disability" & vbCrLf & ex.Message.ToString)
            KillGLink()
            ClientErrorMessage = "Location: StoreSQL_Disability > " & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Finally
            SQLConn.Close()
        End Try
    End Sub

    Private Sub glinkStart_Disability()
        Dim isLoop As Boolean = True
        Dim RetryCounter As Integer = 0
        Dim Counter As Integer = 0
        Dim Timeout As Integer = 0
        While isLoop
            glapiDisability = New connGLinkMedi("C:\GlPro\PhoenixMedi.02")
            glapiDisability.bool_Visible = True
            If glapiDisability.isConnect() Then
                glapiDisability.SendKeysTransmit("LABPRD")
                While glapiDisability.GetString(7, 12, 13, 12) <> "LOGONID"
                    Thread.Sleep(750)
                    Counter += 1
                    If Counter > 15 Then
                        KillGLink()
                        ClientErrorMessage = "Location: GLinkStart_Disability > Cannot start GLink."
                        Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
                    End If
                End While
                Thread.Sleep(500)
                glapiDisability.SubmitField(16, My.Settings.LOOPSOperator)
                glapiDisability.SubmitField(19, My.Settings.LOOPSPassword)
                glapiDisability.TransmitPage()
                If glapiDisability.GetString(1, 20, 3, 20) = "ACF" Then
                    DisabilityErrorMessage = glapiDisability.GetString(10, 20, 65, 20)
                    If DisabilityErrorMessage.Substring(0, 3) = "R94" Then DisabilityErrorMessage = glapiDisability.GetString(10, 21, 65, 21)
                    isErrorDisability = True
                End If
                While glapiDisability.GetString(1, 4, 3, 4) <> "ACF"
                    Thread.Sleep(500)
                    Timeout += 1
                    If Timeout = 30 Then isErrorDisability = True : Exit While
                End While
                If Not isErrorDisability Then
                    glapiDisability.SendKeysTransmit("IEVS")
                    Thread.Sleep(500)
                    glapiDisability.SendKeysTransmit("5")
                    glapiDisability.TransmitPage()
                End If
                isLoop = False
            Else
                RetryCounter += 1
                isLoop = True
                KillGLink()
                If RetryCounter > 30 Then
                    isErrorDisability = True
                    isLoop = False
                    KillGLink()
                    ClientErrorMessage = "Location: GLinkStart_Disability > Cannot start GLink."
                    Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
                    'DisabilityErrorMessage = "Location: GLinkStart" & vbCrLf & "Cannot connect to Disability!"
                    'MessageBox.Show("Location: GLinkStart" & vbCrLf & "Cannot connect to Disability!", "Phoenix - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
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

    Private Sub TI10Screen()
        glapiDisability.SubmitField(FIELD_TI10Menu, "S")
        glapiDisability.TransmitPage()
        glapiDisability.SubmitField(FIELD_SSNDisability, SocialSecurity(Index))
        glapiDisability.TransmitPage()
    End Sub
    Private Sub GetClaimSummary()
        CaseStatus = glapiDisability.GetString(11, 7, 18, 7)
        D_Date = glapiDisability.GetString(11, 9, 18, 9)
        C_Date = glapiDisability.GetString(11, 10, 18, 10)
        EOD = glapiDisability.GetString(11, 12, 18, 12)

        WBR_Disability = glapiDisability.GetString(28, 10, 35, 10)
        MBA_Disability = glapiDisability.GetString(44, 10, 51, 10)
        BenPaidToDate = glapiDisability.GetString(44, 12, 51, 12)
        ClaimBalance = glapiDisability.GetString(44, 11, 51, 11)

        NumOfEmployers = glapiDisability.GetString(35, 14, 36, 14)

        NetAmt = glapiDisability.GetString(46, 15, 53, 15)
        GrossAmt = glapiDisability.GetString(46, 16, 53, 16)
    End Sub
    Private Sub GetOtherClaims()
        While glapiDisability.GetString(28, 23, 34, 23) <> "       "
            glapiDisability.SubmitField(FIELD_ClaimSummary, "20")
            glapiDisability.TransmitPage()
            OtherClaimDate(ClaimTotal) = glapiDisability.GetString(11, 9, 18, 9)
            ClaimTotal += 1
        End While
        glapiDisability.SubmitField(FIELD_ClaimSummary, "21")
        glapiDisability.TransmitPage()
    End Sub
    Private Sub GetPaymentInq()
        Dim i As Integer
        For i = 0 To PaymentMax - 1
            If glapiDisability.GetString(6, 9 + i, 13, 9 + i) <> "        " Then
                CheckDate(i) = glapiDisability.GetString(6, 9 + i, 13, 9 + i)
                PEDate(i) = glapiDisability.GetString(15, 9 + i, 22, 9 + i)
                CheckNum(i) = glapiDisability.GetString(24, 9 + i, 31, 9 + i)
                NetPaid(i) = glapiDisability.GetString(35, 9 + i, 42, 9 + i)
                DaysPaid(i) = glapiDisability.GetString(47, 9 + i, 48, 9 + i)
                PMTCode(i) = glapiDisability.GetString(52, 9 + i, 53, 9 + i)
                ADJCode(i) = glapiDisability.GetString(57, 9 + i, 59, 9 + i)
                VoidCode(i) = glapiDisability.GetString(63, 9 + i, 63, 9 + i)
                GrossCur(i) = glapiDisability.GetString(68, 9 + i, 75, 9 + i)
            Else
                CheckDate(i) = "        "
            End If
        Next
    End Sub
End Module
