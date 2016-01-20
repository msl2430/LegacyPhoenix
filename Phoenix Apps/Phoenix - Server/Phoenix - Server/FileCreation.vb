Module FileCreation

    Private Const _105A1 As String = "P105A1.DAT"
    Private Const _105A2 As String = "P105A2.DAT"
    Private Const _105B1 As String = "P105B1.DAT"
    Private Const _105B2 As String = "P105B2.DAT"

    Private DOLC As String
    Private CaseList As New List(Of String)
    Public CaseCount As Integer
    Public Update_ParentControlScreen As ControlScreen

    Public Sub MakeFile()
        Try
            DOLC = Date.Now.Month.ToString.PadLeft(2, "0") & Date.Now.Day.ToString.PadLeft(2, "0") & Date.Now.Year.ToString
            If Date.Now.DayOfWeek <> DayOfWeek.Sunday And Date.Now.DayOfWeek <> DayOfWeek.Saturday Then
                CaseList.Clear()
                GetCaseList()
                If CaseCount > 0 Then
                    Update_ParentControlScreen.BGW_GUMPUpdate.ReportProgress(1)
                    If File.Exists(My.Settings.GUMPFileDirectory & _105A1) Then File.Delete(My.Settings.GUMPFileDirectory & _105A1)
                    If File.Exists(My.Settings.GUMPFileDirectory & _105A2) Then File.Delete(My.Settings.GUMPFileDirectory & _105A2)
                    If File.Exists(My.Settings.GUMPFileDirectory & _105B1) Then File.Delete(My.Settings.GUMPFileDirectory & _105B1)
                    If File.Exists(My.Settings.GUMPFileDirectory & _105B2) Then File.Delete(My.Settings.GUMPFileDirectory & _105B2)
                    Write105A1()
                    Thread.Sleep(250)
                    Write105A2()
                    Thread.Sleep(250)
                    Write105B1()
                    Thread.Sleep(250)
                    Write105B2()
                    Thread.Sleep(250)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Location: MakeFile" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub WriteData(ByVal toFile As String, ByVal Data As String)
        Try
            Dim inFile As New StreamWriter(My.Settings.GUMPFileDirectory & toFile, True)
            inFile.Write(Data)
            inFile.Close()
        Catch ex As Exception
            MessageBox.Show("Location: WriteData" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub GetCaseList()
        Dim SQLCaseConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLCaseComm As New SqlCommand
        Dim SQLCaseReader As SqlDataReader
        CaseCount = 0
        Try
            SQLCaseConn.Open()
            SQLCaseComm.Connection = SQLCaseConn
            SQLCaseComm.CommandText = "SELECT CaseNumber FROM FAMISCaseInformation WHERE DATEENTERED = '" & DOLC.Substring(0, 2) & "/" & DOLC.Substring(2, 2) & "/" & DOLC.Substring(4, 4) & "'"
            SQLCaseReader = SQLCaseComm.ExecuteReader
            While SQLCaseReader.Read
                CaseList.Add(SQLCaseReader.GetString(0))
                CaseCount += 1
            End While
        Catch ex As Exception
            MessageBox.Show("Location: GetCaseList" & vbCrLf & ex.Message)
        Finally
            SQLCaseConn.Close()
        End Try
    End Sub

    Private Function convertDate(ByVal tempDate As String) As String
        Dim convDate As Date = tempDate
        If convDate = "1/1/1900" Then
            Return "        "
        Else
            Return convDate.Month.ToString.PadLeft(2, "0") & convDate.Day.ToString.PadLeft(2, "0") & convDate.Year.ToString
        End If
    End Function

    Private Sub Write105A1()
        Dim i As Integer
        Dim SQLCaseConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLCaseComm As New SqlCommand
        Dim SQLCaseReader As SqlDataReader
        SQLCaseConn = New SqlConnection(My.Settings.phxSQLConn)
        Try
            SQLCaseConn.Open()
            SQLCaseComm.Connection = SQLCaseConn
            For i = 0 To CaseList.Count - 1
                SQLCaseComm.CommandText = "SELECT * FROM FAMISCaseInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(5) & "," & SQLCaseReader.GetString(6) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & DOLC & "  ," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(22))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT * FROM FAMISApplicantInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, "," & SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(5) & "," & SQLCaseReader.GetString(6) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(16) & "," & SQLCaseReader.GetString(17) & "," & SQLCaseReader.GetString(18) & "," & SQLCaseReader.GetString(19) & "," & SQLCaseReader.GetString(20) & "," & SQLCaseReader.GetString(21) & "," & SQLCaseReader.GetString(22) & "," & SQLCaseReader.GetString(23) & "," & SQLCaseReader.GetString(24) & "," & SQLCaseReader.GetString(25) & "," & SQLCaseReader.GetString(26) & "," & SQLCaseReader.GetString(27) & "," & SQLCaseReader.GetString(28) & "," & SQLCaseReader.GetString(29) & "," & SQLCaseReader.GetString(30) & "," & SQLCaseReader.GetString(31) & "," & SQLCaseReader.GetString(32) & "," & SQLCaseReader.GetString(33) & "," & SQLCaseReader.GetString(34) & "," & SQLCaseReader.GetString(36) & "," & SQLCaseReader.GetString(37) & "," & SQLCaseReader.GetString(38) & "," & SQLCaseReader.GetString(39) & "," & SQLCaseReader.GetString(40) & "," & SQLCaseReader.GetString(41) & "," & SQLCaseReader.GetString(42) & "," & SQLCaseReader.GetString(43) & "," & SQLCaseReader.GetString(44) & "," & SQLCaseReader.GetString(45) & "," & SQLCaseReader.GetString(46) & "," & SQLCaseReader.GetString(47) & "," & SQLCaseReader.GetString(48) & "," & SQLCaseReader.GetString(49) & "," & SQLCaseReader.GetString(50) & "," & SQLCaseReader.GetString(51) & "," & SQLCaseReader.GetString(52) & "," & SQLCaseReader.GetString(53)) ' & "," & sqlcasereader.GetString(54) & "," & sqlcasereader.GetString(55) & "," & sqlcasereader.GetString(56) & "," & sqlcasereader.GetString(57) & "," & sqlcasereader.GetString(58) & "," & sqlcasereader.GetString(59) & "," & sqlcasereader.GetString(60) & "," & sqlcasereader.GetString(61) & "," & sqlcasereader.GetString(62) & "," & sqlcasereader.GetString(63) & "," & sqlcasereader.GetString(64) & "," & sqlcasereader.GetString(65) & "," & sqlcasereader.GetString(66) & "," & sqlcasereader.GetString(67) & "," & sqlcasereader.GetString(68) & "," & sqlcasereader.GetString(69))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT * FROM FAMISIndividualsInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, "," & SQLCaseReader.GetString(4) & "," & convertDate(SQLCaseReader.GetDateTime(5).ToString) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(17) & "," & SQLCaseReader.GetString(18) & "," & convertDate(SQLCaseReader.GetDateTime(19).ToString) & "," & SQLCaseReader.GetString(20) & "," & SQLCaseReader.GetString(21) & "," & SQLCaseReader.GetString(22) & "," & SQLCaseReader.GetString(23) & "," & SQLCaseReader.GetString(24) & "," & SQLCaseReader.GetString(25) & "," & SQLCaseReader.GetString(26) & "," & SQLCaseReader.GetString(27) & "," & convertDate(SQLCaseReader.GetDateTime(28).ToString) & "," & SQLCaseReader.GetString(29) & "," & SQLCaseReader.GetString(30) & "," & SQLCaseReader.GetString(31) & "," & convertDate(SQLCaseReader.GetDateTime(32).ToString) & "," & SQLCaseReader.GetString(33) & "," & convertDate(SQLCaseReader.GetDateTime(34).ToString) & "," & SQLCaseReader.GetString(35) & "," & SQLCaseReader.GetString(36) & "," & SQLCaseReader.GetString(37) & "," & convertDate(SQLCaseReader.GetDateTime(38).ToString) & "," & SQLCaseReader.GetString(39) & "," & SQLCaseReader.GetString(40)) ' & "," & SQLCaseReader.GetString(41) & "," & SQLCaseReader.GetString(42) & "," & SQLCaseReader.GetString(43) & "," & SQLCaseReader.GetString(44))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT HA FROM FAMISAFDCInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, "," & SQLCaseReader.GetString(0))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT HB, HC, HD, HE, HF, HG, HH, HI, HJ, HK, HL, HM, HN, HO, HP, HQ, HR, HS, HT FROM FAMISMedicaidInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, "," & SQLCaseReader.GetString(0) & "," & SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(5) & "," & SQLCaseReader.GetString(6) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(16) & "," & SQLCaseReader.GetString(17) & "," & SQLCaseReader.GetString(18))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT * FROM FAMISAFDCInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & convertDate(SQLCaseReader.GetDateTime(4).ToString) & "," & convertDate(SQLCaseReader.GetDateTime(5).ToString) & "," & SQLCaseReader.GetString(6) & "," & convertDate(SQLCaseReader.GetDateTime(7).ToString) & "," & convertDate(SQLCaseReader.GetDateTime(8).ToString) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(16) & "," & SQLCaseReader.GetString(17) & "," & SQLCaseReader.GetString(18))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT * FROM FAMISIncomeInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(16) & "," & SQLCaseReader.GetString(17) & "," & SQLCaseReader.GetString(44) & "," & SQLCaseReader.GetString(18) & "," & SQLCaseReader.GetString(19) & "," & SQLCaseReader.GetString(20) & "," & SQLCaseReader.GetString(21) & "," & SQLCaseReader.GetString(22) & "," & SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(23) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(24) & "," & SQLCaseReader.GetString(25) & "," & SQLCaseReader.GetString(26) & "," & SQLCaseReader.GetString(27) & "," & SQLCaseReader.GetString(28) & "," & SQLCaseReader.GetString(29) & "," & SQLCaseReader.GetString(30) & "," & SQLCaseReader.GetString(31) & "," & SQLCaseReader.GetString(32) & "," & SQLCaseReader.GetString(33) & "," & SQLCaseReader.GetString(34) & "," & SQLCaseReader.GetString(35) & "," & SQLCaseReader.GetString(36) & "," & SQLCaseReader.GetString(37) & "," & SQLCaseReader.GetString(38) & "," & SQLCaseReader.GetString(39) & "," & SQLCaseReader.GetString(40) & "," & SQLCaseReader.GetString(41) & "," & SQLCaseReader.GetString(42) & "," & SQLCaseReader.GetString(43))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT LA, LB, LC, LD, LE, LF, LG, LH, LI, LJ, LK, LL, LM, LN, LO, LP, LQ, LR, LS, LT, MA, MB, MC, MD, ME1, MF, MG, MH, MI, MJ, MK, ML, MM, MN, MO, MP, MQ, MR, NA, NB, NC, ND, NE, NF, NG, NH, NI, NJ, NK, NL, NM, [NO], NP, OA, OB, OC, OD, OE, OF1, OG, OH, OI, OJ, OK, OL, ON1, OO FROM FAMISFoodStampInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, "," & SQLCaseReader.GetString(0) & "," & SQLCaseReader.GetString(1) & "," & convertDate(SQLCaseReader.GetDateTime(2).ToString) & "," & convertDate(SQLCaseReader.GetDateTime(3).ToString) & "," & convertDate(SQLCaseReader.GetDateTime(4).ToString) & "," & SQLCaseReader.GetString(5) & "," & SQLCaseReader.GetString(6) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(16) & "," & SQLCaseReader.GetString(17) & "," & SQLCaseReader.GetString(18) & "," & convertDate(SQLCaseReader.GetDateTime(19).ToString) & "," & SQLCaseReader.GetString(20) & "," & SQLCaseReader.GetString(21) & "," & SQLCaseReader.GetString(22) & "," & SQLCaseReader.GetString(23) & "," & SQLCaseReader.GetString(24) & "," & SQLCaseReader.GetString(25) & "," & SQLCaseReader.GetString(26) & "," & SQLCaseReader.GetString(27) & "," & SQLCaseReader.GetString(28) & "," & SQLCaseReader.GetString(29) & "," & SQLCaseReader.GetString(30) & "," & SQLCaseReader.GetString(31) & "," & SQLCaseReader.GetString(32) & "," & SQLCaseReader.GetString(33) & "," & SQLCaseReader.GetString(34) & "," & SQLCaseReader.GetString(35) & "," & SQLCaseReader.GetString(36) & "," & SQLCaseReader.GetString(37) & "," & SQLCaseReader.GetString(38) & "," & SQLCaseReader.GetString(39) & "," & convertDate(SQLCaseReader.GetDateTime(40).ToString) & "," & SQLCaseReader.GetString(41) & "," & SQLCaseReader.GetString(42) & "," & SQLCaseReader.GetString(43) & "," & convertDate(SQLCaseReader.GetDateTime(44).ToString) & "," & SQLCaseReader.GetString(45) & "," & SQLCaseReader.GetString(46) & "," & SQLCaseReader.GetString(47) & "," & SQLCaseReader.GetString(48) & "," & SQLCaseReader.GetString(49) & "," & SQLCaseReader.GetString(50) & "," & SQLCaseReader.GetString(51) & "," & SQLCaseReader.GetString(52) & "," & SQLCaseReader.GetString(53) & "," & SQLCaseReader.GetString(54) & "," & SQLCaseReader.GetString(55) & "," & SQLCaseReader.GetString(56) & "," & SQLCaseReader.GetString(57) & "," & SQLCaseReader.GetString(58) & "," & SQLCaseReader.GetString(59) & "," & SQLCaseReader.GetString(60) & "," & SQLCaseReader.GetString(61) & ",  ," & SQLCaseReader.GetString(63) & "," & SQLCaseReader.GetString(64) & "," & SQLCaseReader.GetString(65) & "," & SQLCaseReader.GetString(66)) ' & "," & SQLCaseReader.GetString(67)) '& "," & SQLCaseReader.GetString(68)) ' & "," & SQLCaseReader.GetString(69) & "," & SQLCaseReader.GetString(70))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT * FROM FAMISIandAInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A1, "," & convertDate(SQLCaseReader.GetDateTime(1).ToString) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(5) & "," & SQLCaseReader.GetString(6) & "," & convertDate(SQLCaseReader.GetDateTime(13).ToString) & "," & convertDate(SQLCaseReader.GetDateTime(7).ToString) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(16) & "," & DOLC)
                End If
                SQLCaseReader.Close()

                WriteData(_105A1, vbCrLf)
                SQLCaseReader.Close()
                Update_ParentControlScreen.BGW_GUMPUpdate.ReportProgress(2)
            Next
        Catch ex As Exception
            File.Delete(My.Application.Info.DirectoryPath & "\105A1.dat")
            MessageBox.Show("Location: Write105A1" & vbCrLf & SQLCaseComm.CommandText & vbCrLf & ex.Message)
        Finally
            SQLCaseConn.Close()
        End Try
    End Sub
    Private Sub Write105A2()
        Dim i As Integer
        Dim SQLCaseConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLCaseComm As New SqlCommand
        Dim SQLCaseReader As SqlDataReader
        SQLCaseConn = New SqlConnection(My.Settings.phxSQLConn)
        Try
            SQLCaseConn.Open()
            SQLCaseComm.Connection = SQLCaseConn
            For i = 0 To CaseList.Count - 1
                WriteData(_105A2, CaseList(i))

                SQLCaseComm.CommandText = "SELECT BS, BT, BU, BV, BW, BX, BY1, BZ FROM FAMISIndividualsInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A2, "," & SQLCaseReader.GetString(0) & "," & SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(5) & "," & SQLCaseReader.GetString(6) & "," & SQLCaseReader.GetString(7))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT JW, JX, KU, KV FROM FAMISIncomeInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A2, "," & SQLCaseReader.GetString(0) & "," & SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT XA, XB, XC, XD, XE, XF, XM, XG, XH, XI, XJ, XK, XL, XN FROM FAMISApplicantInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A2, "," & convertDate(SQLCaseReader.GetDateTime(0).ToString) & "," & SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(5) & "," & SQLCaseReader.GetString(6) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13))
                End If
                SQLCaseReader.Close()

                SQLCaseComm.CommandText = "SELECT WA, WB, WC, WD, WE, WF, WG, WH, WI, WK, WL, WM, WR, WS, WT, WU, WV FROM FAMISMedicaidInformation WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                SQLCaseReader.Read()
                If SQLCaseReader.HasRows Then
                    WriteData(_105A2, "," & SQLCaseReader.GetString(0) & "," & SQLCaseReader.GetString(1) & "," & convertDate(SQLCaseReader.GetDateTime(2).ToString) & "," & convertDate(SQLCaseReader.GetDateTime(3).ToString) & "," & SQLCaseReader.GetString(4) & "," & convertDate(SQLCaseReader.GetDateTime(5).ToString) & "," & convertDate(SQLCaseReader.GetDateTime(6).ToString) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(16) & "," & DOLC)
                End If
                WriteData(_105A2, vbCrLf)
                SQLCaseReader.Close()
                Update_ParentControlScreen.BGW_GUMPUpdate.ReportProgress(2)
            Next
        Catch ex As Exception
            MessageBox.Show("Location: Write105A2" & vbCrLf & ex.Message)
        Finally
            SQLCaseConn.Close()
        End Try
    End Sub
    Private Sub Write105B1()
        Dim i As Integer
        Dim SQLCaseConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLCaseComm As New SqlCommand
        Dim SQLCaseReader As SqlDataReader
        SQLCaseConn = New SqlConnection(My.Settings.phxSQLConn)
        Try
            SQLCaseConn.Open()
            SQLCaseComm.Connection = SQLCaseConn
            For i = 0 To CaseList.Count - 1
                SQLCaseComm.CommandText = "SELECT QA, QB, QC, QD, QE, QF, QG, QH, QI, QJ, QK, QL, QM, QN, QO, RA, RB, RC,RD, RE, RF, RG, RH, RH2, RI, RJ1, RJ2, RK, RL, RM, RN, RO, RP, RQ, RR, SA, SB, SC, SD, SE, SF, SG, SH, SI, SJ, SK, SL, SM, SN, SO, SP, SQ, SR, TA, TB, TC, TD, TE, TF, TG, TH, TI, TJ, TK, TL, TM FROM FAMISCaseChild WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                While SQLCaseReader.Read
                    WriteData(_105B1, CaseList(i) & "," & SQLCaseReader.GetString(0) & "," & SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(5) & "," & convertDate(SQLCaseReader.GetDateTime(6).ToString) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & convertDate(SQLCaseReader.GetDateTime(10).ToString) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(16) & "," & SQLCaseReader.GetString(17) & "," & SQLCaseReader.GetString(18) & "," & SQLCaseReader.GetString(19) & "," & SQLCaseReader.GetString(20) & "," & SQLCaseReader.GetString(21) & "," & SQLCaseReader.GetString(22) & "," & SQLCaseReader.GetString(23) & "," & SQLCaseReader.GetString(24) & "," & SQLCaseReader.GetString(25) & "," & SQLCaseReader.GetString(26) & "," & SQLCaseReader.GetString(27) & "," & SQLCaseReader.GetString(28) & "," & SQLCaseReader.GetString(29) & "," & SQLCaseReader.GetString(30) & "," & SQLCaseReader.GetString(31) & "," & SQLCaseReader.GetString(32) & "," & SQLCaseReader.GetString(33) & "," & SQLCaseReader.GetString(34) & "," & SQLCaseReader.GetString(35) & "," & SQLCaseReader.GetString(36) & "," & SQLCaseReader.GetString(37) & "," & SQLCaseReader.GetString(38) & "," & SQLCaseReader.GetString(39) & "," & SQLCaseReader.GetString(40) & "," & SQLCaseReader.GetString(41) & "," & SQLCaseReader.GetString(42) & "," & SQLCaseReader.GetString(43) & "," & SQLCaseReader.GetString(44) & "," & SQLCaseReader.GetString(45) & "," & SQLCaseReader.GetString(46) & "," & SQLCaseReader.GetString(47) & "," & convertDate(SQLCaseReader.GetDateTime(48).ToString) & "," & SQLCaseReader.GetString(49) & "," & SQLCaseReader.GetString(50) & "," & SQLCaseReader.GetString(51) & "," & SQLCaseReader.GetString(52) & "," & SQLCaseReader.GetString(53) & "," & SQLCaseReader.GetString(54) & "," & SQLCaseReader.GetString(55) & "," & SQLCaseReader.GetString(56) & "," & convertDate(SQLCaseReader.GetDateTime(57).ToString) & "," & SQLCaseReader.GetString(58) & "," & SQLCaseReader.GetString(59) & "," & SQLCaseReader.GetString(60) & "," & SQLCaseReader.GetString(61) & "," & SQLCaseReader.GetString(62) & "," & SQLCaseReader.GetString(63) & "," & convertDate(SQLCaseReader.GetDateTime(64).ToString) & "," & SQLCaseReader.GetString(65) & "," & DOLC & vbCrLf)
                End While
                SQLCaseReader.Close()
                Update_ParentControlScreen.BGW_GUMPUpdate.ReportProgress(2)
            Next
        Catch ex As Exception
            MessageBox.Show("Location: Write105B1" & vbCrLf & ex.Message)
        Finally
            SQLCaseConn.Close()
        End Try
    End Sub
    Private Sub Write105B2()
        Dim i As Integer
        Dim SQLCaseConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLCaseComm As New SqlCommand
        Dim SQLCaseReader As SqlDataReader
        SQLCaseConn = New SqlConnection(My.Settings.phxSQLConn)
        Try
            SQLCaseConn.Open()
            SQLCaseComm.Connection = SQLCaseConn
            For i = 0 To CaseList.Count - 1
                SQLCaseComm.CommandText = "SELECT SS, TO1, TP, TQ, TR, TS, UA, UB, UC, UD, UE, UF, UG, UH, UI, UK, UL, QA FROM FAMISCaseChild WHERE CaseNumber = '" & CaseList(i) & "'"
                SQLCaseReader = SQLCaseComm.ExecuteReader
                While SQLCaseReader.Read
                    WriteData(_105B2, CaseList(i) & "," & SQLCaseReader.GetString(17) & "," & SQLCaseReader.GetString(0) & "," & SQLCaseReader.GetString(1) & "," & SQLCaseReader.GetString(2) & "," & SQLCaseReader.GetString(3) & "," & SQLCaseReader.GetString(4) & "," & SQLCaseReader.GetString(5) & "," & SQLCaseReader.GetString(6) & "," & SQLCaseReader.GetString(7) & "," & SQLCaseReader.GetString(8) & "," & SQLCaseReader.GetString(9) & "," & SQLCaseReader.GetString(10) & "," & SQLCaseReader.GetString(11) & "," & SQLCaseReader.GetString(12) & "," & SQLCaseReader.GetString(13) & "," & SQLCaseReader.GetString(14) & "," & SQLCaseReader.GetString(15) & "," & SQLCaseReader.GetString(16) & "," & DOLC & vbCrLf)
                End While
                SQLCaseReader.Close()
                Update_ParentControlScreen.BGW_GUMPUpdate.ReportProgress(2)
            Next
        Catch ex As Exception
            MessageBox.Show("Location: Write105B2" & vbCrLf & ex.Message)
        Finally
            SQLCaseConn.Close()
        End Try
    End Sub
End Module
