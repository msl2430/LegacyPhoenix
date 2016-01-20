'--Designed by: Michael Levine 10/2007--
Module LaborModule
    '--Automated labor screens module--

    Private glapiLabor As connGLinkMedi
    Private IsErrorLabor As Boolean

    Private Const ClaimMax As Integer = 12
    Private Const FIELD_A200Menu As Integer = 26
    Private Const FIELD_SSNLabor As Integer = 14
    Private Const FIELD_PC As Integer = 17
    Private Const FIELD_DOC As Integer = 20
    Private Const FIELD_SelectionCode As Integer = 23
    Private Const FIELD_SequenceNum As Integer = 22

    Private ClaimTotal, PaymentTotal, RemarksTotal As Integer
    Private ClaimDate(ClaimMax) As String
    Private ClaimName As String
    Private WBR_Labor, MBA_Labor, UI_Balance, WeeksPaid, BYEDate, LastWorkDay, FirstReportDay, ReturnToWork, FraudStart, FraudEnd, DisqualEnd As String
    Private CWE(ClaimMax), DatePaid(ClaimMax), VC(ClaimMax), TranUI(ClaimMax), MTH(ClaimMax), SEA(ClaimMax), Earn(ClaimMax), PEN(ClaimMax), AWBA(ClaimMax), Refund(ClaimMax), GARN(ClaimMax), TaxWTH(ClaimMax), ADJ(ClaimMax), AmountPaid(ClaimMax) As String
    Private Title(ClaimMax), SEQ(ClaimMax), Remark1(ClaimMax), Remark2(ClaimMax), Remark3(ClaimMax), Remark4(ClaimMax), Remark5(ClaimMax) As String
    Private Index As Integer

    Public Sub GetLaborData(ByVal ThreadIndex As Integer)
        Index = ThreadIndex
        ClaimTotal = 0
        PaymentTotal = 0
        RemarksTotal = 0
        glinkStart_Labor()
        If IsErrorLabor Then
            isLaborExists = False
        Else
            A200Screen()

            If isLaborExists Then
                glapiLabor.SubmitField(FIELD_SelectionCode, "01")
                glapiLabor.TransmitPage()
                GetBasic1()

                glapiLabor.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F1)
                glapiLabor.SubmitField(FIELD_SelectionCode, "11")
                glapiLabor.TransmitPage()
                GetPaymentListing()

                glapiLabor.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F1)
                glapiLabor.SubmitField(FIELD_SelectionCode, "14")
                glapiLabor.TransmitPage()
                GetRemarks()

                glapiLabor.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F1)

                StoreSQL_Labor()
            End If
        End If
        glapiLabor.Disconnect()
    End Sub

    Private Sub StoreSQL_Labor()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim i As Integer
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn

            SQLComm.CommandText = "DELETE FROM LOOPSClaimInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            For i = 0 To ClaimTotal - 1
                SQLComm.CommandText = "INSERT INTO LOOPSClaimInformation VALUES ('" & SocialSecurity(Index) & "', '" & ClaimName & "', '" & ClaimDate(i) & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
                SQLComm.ExecuteNonQuery()
            Next

            SQLComm.CommandText = "DELETE FROM LOOPSPaymentInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            For i = 0 To PaymentTotal - 1
                SQLComm.CommandText = "INSERT INTO LOOPSPaymentInformation VALUES ('" & SocialSecurity(Index) & "', '" & CWE(i) & "', '" & DatePaid(i) & "', '" & VC(i) & "', '" & TranUI(i) & "', '" & MTH(i).Replace(" ", "") & "', '" & SEA(i) & "', '" & Earn(i) & "', '" & PEN(i).Replace(" ", "") & "', '" & AWBA(i) & "', '" & Refund(i).Replace(" ", "") & "', '" & GARN(i).Replace(" ", "") & "', '" & TaxWTH(i).Replace(" ", "") & "', '" & ADJ(i).Replace(" ", "") & "', '" & AmountPaid(i).Replace(" ", "") & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
                SQLComm.ExecuteNonQuery()
            Next

            SQLComm.CommandText = "DELETE FROM LOOPSBasicInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "INSERT INTO LOOPSBasicInformation VALUES ('" & SocialSecurity(Index) & "', '" & WBR_Labor.Replace(" ", "") & "', '" & MBA_Labor.Replace(" ", "") & "', '" & UI_Balance & "', '" & WeeksPaid & "', '" & BYEDate & "', '" & LastWorkDay & "', '" & FirstReportDay & "', '" & ReturnToWork & "', '" & FraudStart & "', '" & FraudEnd & "', '" & DisqualEnd & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
            SQLComm.ExecuteNonQuery()

            SQLComm.CommandText = "DELETE FROM LOOPSRemarkInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            For i = 0 To RemarksTotal - 1
                SQLComm.CommandText = "INSERT INTO LOOPSRemarkInformation VALUES ('" & SocialSecurity(Index) & "', '" & SEQ(i) & "', '" & Title(i).Replace("'", "") & "', '" & Remark1(i).Replace("'", "") & "', '" & Remark2(i).Replace("'", "") & "', '" & Remark3(i).Replace("'", "") & "', '" & Remark4(i).Replace("'", "") & "', '" & Remark5(i).Replace("'", "") & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
                SQLComm.ExecuteNonQuery()
            Next
        Catch ex As Exception
            KillGLink()
            ClientErrorMessage = "Location: StoreSQLLoops >" & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
            'MessageBox.Show("Location: StoreSQL_LOOPS" & vbCrLf & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub

    Private Sub glinkStart_Labor()
        Dim isLoop As Boolean = True
        Dim RetryCounter As Integer = 0
        Dim Counter As Integer = 0
        Dim Timeout As Integer = 0
        While isLoop
            glapiLabor = New connGLinkMedi("C:\GlPro\PhoenixMedi.02")
            glapiLabor.bool_Visible = True
            If glapiLabor.isConnect() Then
                glapiLabor.SendKeysTransmit("LABPRD")
                While glapiLabor.GetString(7, 12, 13, 12) <> "LOGONID"
                    Thread.Sleep(750)
                    Counter += 1
                    If Counter > 15 Then
                        KillGLink()
                        ClientErrorMessage = "Location: GLinkStart_Labor > Cannot start GLink."
                        Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
                    End If
                End While
                Thread.Sleep(500)
                glapiLabor.SubmitField(16, My.Settings.LOOPSOperator)
                glapiLabor.SubmitField(19, My.Settings.LOOPSPassword)
                glapiLabor.TransmitPage()
                If glapiLabor.GetString(1, 20, 3, 20) = "ACF" Then
                    LaborErrorMessage = glapiLabor.GetString(10, 20, 65, 20)
                    If LaborErrorMessage.Substring(0, 3) = "R94" Then LaborErrorMessage = glapiLabor.GetString(10, 21, 65, 21)
                    IsErrorLabor = True
                End If
                While glapiLabor.GetString(1, 4, 3, 4) <> "ACF"
                    Thread.Sleep(500)
                    Timeout += 1
                    If Timeout = 30 Then IsErrorLabor = True : Exit While
                End While
                If Not IsErrorLabor Then
                    glapiLabor.SendKeysTransmit("IEVS")
                    Thread.Sleep(500)
                    glapiLabor.SendKeysTransmit("4")
                    glapiLabor.TransmitPage()
                End If
                isLoop = False
            Else
                RetryCounter += 1
                isLoop = True
                KillGLink()
                If RetryCounter > 30 Then
                    IsErrorLabor = True
                    isLoop = False
                    KillGLink()
                    ClientErrorMessage = "Location: GLinkStart_Labor > Cannot start GLink."
                    Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
                    'LaborErrorMessage = "Location: GLinkStart" & vbCrLf & "Cannot connect to LOOPS!"
                    'MessageBox.Show("Location: GLinkStart" & vbCrLf & "Cannot connect to LOOPS!", "Phoenix - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub A200Screen()
        Dim i As Integer
        Dim DateCheck As Date
        glapiLabor.SubmitField(FIELD_A200Menu, "S")
        glapiLabor.TransmitPage()

        glapiLabor.SubmitField(FIELD_SSNLabor, SocialSecurity(Index))
        glapiLabor.SubmitField(FIELD_PC, "10")
        glapiLabor.SubmitField(FIELD_SelectionCode, "12")
        glapiLabor.TransmitPage()
        isLaborExists = False
        If glapiLabor.GetString(6, 22, 13, 22) <> "NO CLAIM" Then
            isLaborExists = True
            For i = 0 To ClaimMax
                If glapiLabor.GetString(18, 8 + i, 25, 8 + i) <> "        " Then
                    ClaimDate(ClaimTotal) = glapiLabor.GetString(18, 8 + i, 25, 8 + i)
                    DateCheck = ClaimDate(ClaimTotal)
                    If DateDiff(DateInterval.Month, DateCheck, Date.Today, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 24 Then
                        If glapiLabor.GetString(66, 8 + i, 66, 8 + i) <> "0" Then
                            glapiLabor.SubmitField(17 + (i * 6), "S")
                            ClaimTotal += 1
                            glapiLabor.TransmitPage()
                            isLaborExists = True
                            Exit For
                        End If
                    Else
                        isLaborExists = False
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub GetBasic1()
        WBR_Labor = glapiLabor.GetString(14, 8, 22, 8)
        If WBR_Labor = "      .00" Then WBR_Labor = "         "
        MBA_Labor = glapiLabor.GetString(14, 9, 22, 9)
        If MBA_Labor = "      .00" Then MBA_Labor = "         "
        UI_Balance = glapiLabor.GetString(14, 10, 22, 10)
        If UI_Balance = "      .00" Then UI_Balance = "         "
        WeeksPaid = glapiLabor.GetString(21, 11, 22, 11)

        BYEDate = glapiLabor.GetString(44, 12, 51, 12)
        LastWorkDay = glapiLabor.GetString(44, 14, 51, 14)

        FirstReportDay = glapiLabor.GetString(72, 8, 79, 8)
        ReturnToWork = glapiLabor.GetString(72, 12, 79, 12)

        FraudStart = glapiLabor.GetString(44, 21, 51, 21)
        FraudEnd = glapiLabor.GetString(72, 21, 79, 21)

        DisqualEnd = glapiLabor.GetString(72, 11, 79, 11)
    End Sub
    Private Sub GetPaymentListing()
        Dim i As Integer
        For i = 0 To ClaimMax - 1
            If glapiLabor.GetString(2, 10 + i, 9, 10 + i) <> "        " Then
                CWE(i) = glapiLabor.GetString(2, 10 + i, 9, 10 + i)
                DatePaid(i) = glapiLabor.GetString(11, 10 + i, 18, 10 + i)
                VC(i) = glapiLabor.GetString(20, 10 + i, 20, 10 + i)
                TranUI(i) = glapiLabor.GetString(22, 10 + i, 25, 10 + i)
                MTH(i) = glapiLabor.GetString(27, 10 + i, 27, 10 + i)
                SEA(i) = glapiLabor.GetString(29, 10 + i, 29, 10 + i)
                Earn(i) = glapiLabor.GetString(31, 10 + i, 34, 10 + i)
                PEN(i) = glapiLabor.GetString(37, 10 + i, 40, 10 + i)
                AWBA(i) = glapiLabor.GetString(44, 10 + i, 46, 10 + i)
                Refund(i) = glapiLabor.GetString(49, 10 + i, 52, 10 + i)
                GARN(i) = glapiLabor.GetString(55, 10 + i, 58, 10 + i)
                TaxWTH(i) = glapiLabor.GetString(62, 10 + i, 64, 10 + i)
                ADJ(i) = glapiLabor.GetString(66, 10 + i, 69, 10 + i)
                AmountPaid(i) = glapiLabor.GetString(72, 10 + i, 79, 10 + i)
                If AmountPaid(i) = "     .00" Then AmountPaid(i) = "        "
                PaymentTotal += 1
            End If
        Next
    End Sub
    Private Sub GetRemarks()
        Dim i As Integer
        For i = 0 To ClaimMax - 1
            If glapiLabor.GetString(6, 10 + i, 8, 10 + i) <> "   " Then
                SEQ(RemarksTotal) = glapiLabor.GetString(6, 10 + i, 8, 10 + i)
                glapiLabor.SubmitField(FIELD_SequenceNum, SEQ(RemarksTotal))
                glapiLabor.TransmitPage()
                Title(RemarksTotal) = glapiLabor.GetString(19, 14, 68, 14)
                Remark1(RemarksTotal) = glapiLabor.GetString(19, 16, 68, 16)
                Remark2(RemarksTotal) = glapiLabor.GetString(19, 17, 68, 17)
                Remark3(RemarksTotal) = glapiLabor.GetString(19, 18, 68, 18)
                Remark4(RemarksTotal) = glapiLabor.GetString(19, 19, 68, 19)
                Remark5(RemarksTotal) = glapiLabor.GetString(19, 20, 68, 20)
                RemarksTotal += 1
                glapiLabor.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F7)
            End If
        Next
        glapiLabor.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F7)
    End Sub

End Module
