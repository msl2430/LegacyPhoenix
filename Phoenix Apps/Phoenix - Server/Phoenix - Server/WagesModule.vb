'--Designed by: Michael Levine 10/2007--
Module WagesModule
    '--Automated wages module--

    Private glapiWages As connGLinkMedi

    Private Const EmployerMax As Integer = 50
    Private Const FIELD_C200Menu As Integer = 38
    Private Const FIELD_SSNWages As Integer = 14
    Private Const FIELD_Name As Integer = 17
    Private FIELD_Employer As Integer() = {38, 45, 52, 59}

    Private isErrorWages As Boolean
    Private EmployerTotal As Integer
    Private Employer(EmployerMax) As EmployerWages
    Private WBR_Wages, MBA_Wages, CurrentClaimExists As String
    Private Index As Integer

    Public Sub GetWagesData(ByVal ThreadIndex As Integer)
        Index = ThreadIndex
        ReDim Employer(EmployerMax)
        EmployerTotal = 0
        glinkStart_Wages()
        If isErrorWages Then
            isWagesExists = False
            KillGLink()
            ClientErrorMessage = "Cannot connect to wages."
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Else
            C200Screen()
            GetWages()
            StoreSQL_Wages()
        End If
        glapiWages.Disconnect()
    End Sub

    Private Sub StoreSQL_Wages()
        Dim SQLConn As New SqlConnection(my.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim i, j As Integer
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn

            SQLComm.CommandText = "DELETE FROM LOOPSEmployerInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            'SQLComm.CommandText = "DELETE FROM LOOPSQuarterInformation WHERE SocialSecurity = '" & SocialSecurity & "'"
            'SQLComm.ExecuteNonQuery()
            For i = 0 To EmployerTotal - 1
                SQLComm.CommandText = "INSERT INTO LOOPSEmployerInformation VALUES ('" & SocialSecurity(Index) & "', '" & Employer(i).EmployerName.Replace("'", "") & "', '" & Employer(i).BaseYear & "', '" & Employer(i).BaseWeeks.Replace(" ", "") & "', '" & Employer(i).TotalWages.Replace(" ", "") & "', '" & WBR_Wages.Replace(" ", "") & "', '" & MBA_Wages.Replace(" ", "") & "', '" & CurrentClaimExists & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
                SQLComm.ExecuteNonQuery()
                'For j = 0 To 4
                '    If Employer(i).Quarter(j) <> "Nothing" Then
                '        SQLComm.CommandText = "INSERT INTO LOOPSQuarterInformation VALUES ('" & SocialSecurity & "', '" & Employer(i).EmployerName.Replace("'", "") & "', '" & Employer(i).Quarter(j) & "', '" & Employer(i).QuarterWeeks(j) & "', '" & Employer(i).QuarterWages(j).Replace(" ", "") & "')"
                '        SQLComm.ExecuteNonQuery()
                '    End If
                'Next
            Next
        Catch ex As Exception
            'MessageBox.Show("Location: StoreSQL_Wages" & vbCrLf & ex.Message.ToString)
            KillGLink()
            ClientErrorMessage = "Location: StoreSQL_Quarter > " & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Finally
            SQLConn.Close()
        End Try
    End Sub

    Private Sub glinkStart_Wages()
        Dim isLoop As Boolean = True
        Dim RetryCounter As Integer = 0
        Dim Counter As Integer = 0
        Dim Timeout As Integer = 0
        While isLoop
            glapiWages = New connGLinkMedi("C:\GlPro\PhoenixMedi.02")
            glapiWages.bool_Visible = True
            If glapiWages.isConnect() Then
                glapiWages.SendKeysTransmit("LABPRD")
                While glapiWages.GetString(7, 12, 13, 12) <> "LOGONID"
                    Thread.Sleep(750)
                    Counter += 1
                    If Counter > 15 Then
                        KillGLink()
                        ClientErrorMessage = "Location: GLinkStart_Wages > Cannot start GLink."
                        Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
                    End If
                End While
                Thread.Sleep(500)
                glapiWages.SubmitField(16, My.Settings.LOOPSOperator)
                glapiWages.SubmitField(19, My.Settings.LOOPSPassword)
                glapiWages.TransmitPage()
                If glapiWages.GetString(1, 20, 3, 20) = "ACF" Then
                    WagesErrorMessage = glapiWages.GetString(10, 20, 65, 20)
                    If WagesErrorMessage.Substring(0, 3) = "R94" Then WagesErrorMessage = glapiWages.GetString(10, 21, 65, 21)
                    isErrorWages = True
                End If
                While glapiWages.GetString(1, 4, 3, 4) <> "ACF"
                    Thread.Sleep(500)
                    Timeout += 1
                    If Timeout = 30 Then isErrorWages = True : Exit While
                End While
                If Not isErrorWages Then
                    glapiWages.SendKeysTransmit("IEVS")
                    Thread.Sleep(500)
                    glapiWages.SendKeysTransmit("4")
                    glapiWages.TransmitPage()
                End If
                isLoop = False
            Else
                RetryCounter += 1
                isLoop = True
                KillGLink()
                If RetryCounter > 30 Then
                    isErrorWages = True
                    isLoop = False
                    KillGLink()
                    ClientErrorMessage = "Location: GLinkStart_Wages > Cannot start GLink."
                    Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
                    ' WagesErrorMessage = "Location: GLinkStart" & vbCrLf & "Cannot connect to Wages!"
                    'MessageBox.Show("Location: GLinkStart" & vbCrLf & "Cannot connect to Wages!", "Phoenix - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub C200Screen()
        glapiWages.SubmitField(FIELD_C200Menu, "S")
        glapiWages.TransmitPage()

        glapiWages.SubmitField(FIELD_SSNWages, SocialSecurity(Index))
        glapiWages.SubmitField(FIELD_Name, LastName(Index).Substring(0, 4))
        glapiWages.TransmitPage()
    End Sub

    Private Sub GetWages()
        Dim isLoop As Boolean = True
        Dim i, ScreenNum As Integer
        ScreenNum = 1
        WBR_Wages = glapiWages.GetString(16, 7, 21, 7)
        MBA_Wages = glapiWages.GetString(16, 8, 21, 8)
        CurrentClaimExists = glapiWages.GetString(4, 18, 23, 18)
        For i = 0 To 4
            If glapiWages.GetString(4, 12 + i, 35, 12 + i) <> "                               " Then
                Employer(EmployerTotal) = New EmployerWages(glapiWages)
                Employer(EmployerTotal).GetEmployer(i)
                If Employer(EmployerTotal).EmployerName <> "Nothing" Then
                    'glapiWages.SubmitField(FIELD_Employer(i), "S")
                    'glapiWages.TransmitPage()
                    'Employer(EmployerTotal).GetQuarter()
                    'For j = 0 To ScreenNum - 1
                    '    glapiWages.TransmitPage()
                    'Next
                    EmployerTotal += 1
                Else
                    Exit For
                End If
            End If
            If i = 3 And glapiWages.GetString(45, 19, 69, 19) = "MORE EMPLOYERS TO DISPLAY" And glapiWages.GetString(4, 19, 26, 19) <> "ALL EMPLOYERS DISPLAYED" Then
                i = -1
                ScreenNum += 1
                glapiWages.TransmitPage()
            End If
        Next
    End Sub
End Module
