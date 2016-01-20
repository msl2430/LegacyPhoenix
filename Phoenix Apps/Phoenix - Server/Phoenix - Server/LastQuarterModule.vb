'--Designed By: Michael Levine 1/29/2008--
Module LastQuarterModule
    '--Automated quarter information--

    Private glapiQuarter As connGLinkMedi

    Private Const FIELD_SSN As Integer = 14
    Private Const FIELD_Selection As Integer = 17
    Private Const FIELD_Menu As Integer = 133

    Private isErrorQuarter As Boolean
    Private QuarterYear As String
    Private QuarterWages, BaseWeeks As New List(Of String)
    Private Index As Integer

    Public Sub GetQuarterData(ByVal ThreadIndex As Integer)
        Index = ThreadIndex
        glinkStart_Quarter()
        If isErrorQuarter Then
            isQuarterExists = False
            KillGLink()
            ClientErrorMessage = "Cannot connect to wages."
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Else
            MenuScreen()
            If isQuarterExists Then
                GetQuarters()
                StoreSQL_Quarter()
            End If
        End If
        glapiQuarter.Disconnect()
    End Sub

    Private Sub StoreSQL_Quarter()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim i As Integer
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn

            SQLComm.CommandText = "DELETE FROM WAGESQuarterInformation WHERE SocialSecurity = '" & SocialSecurity(Index) & "' AND FirstName = '" & FirstName(Index) & "' AND LastName = '" & LastName(Index) & "'"
            SQLComm.ExecuteNonQuery()
            For i = 0 To QuarterWages.Count - 1
                SQLComm.CommandText = "INSERT INTO WAGESQuarterInformation VALUES ('" & SocialSecurity(Index) & "', '" & QuarterYear.Replace(" ", "") & "', '" & QuarterWages(i).Replace(" ", "") & "', '" & BaseWeeks(i).Replace(" ", "") & "', '" & FirstName(Index) & "', '" & LastName(Index) & "')"
                SQLComm.ExecuteNonQuery()
            Next
        Catch ex As Exception
            'MessageBox.Show("Location: StoreSQL_Quarter" & vbCrLf & ex.Message.ToString)
            KillGLink()
            ClientErrorMessage = "Location: StoreSQL_Quarter > " & ex.Message
            Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
        Finally
            SQLConn.Close()
        End Try
    End Sub

    Private Sub glinkStart_Quarter()
        Dim isLoop As Boolean = True
        Dim RetryCounter As Integer = 0
        Dim Counter As Integer = 0
        Dim Timeout As Integer = 0
        While isLoop
            glapiQuarter = New connGLinkMedi("C:\GlPro\PhoenixMedi.02")
            glapiQuarter.bool_Visible = True
            If glapiQuarter.isConnect() Then
                glapiQuarter.SendKeysTransmit("LABPRD")
                While glapiQuarter.GetString(7, 12, 13, 12) <> "LOGONID"
                    Thread.Sleep(750)
                    Counter += 1
                    If Counter > 15 Then
                        KillGLink()
                        ClientErrorMessage = "Location: GLinkStart_Quarter > Cannot start GLink."
                        Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
                    End If
                End While
                Thread.Sleep(500)
                glapiQuarter.SubmitField(16, My.Settings.LOOPSOperator)
                glapiQuarter.SubmitField(19, My.Settings.LOOPSPassword)
                glapiQuarter.TransmitPage()
                If glapiQuarter.GetString(1, 20, 3, 20) = "ACF" Then
                    WagesErrorMessage = glapiQuarter.GetString(10, 20, 65, 20)
                    If WagesErrorMessage.Substring(0, 3) = "R94" Then WagesErrorMessage = glapiQuarter.GetString(10, 21, 65, 21)
                    isErrorQuarter = True
                End If
                While glapiQuarter.GetString(1, 4, 3, 4) <> "ACF"
                    Thread.Sleep(500)
                    Timeout += 1
                    If Timeout = 30 Then isErrorQuarter = True : Exit While
                End While
                If Not isErrorQuarter Then
                    glapiQuarter.SendKeysTransmit("IEVS")
                    Thread.Sleep(500)
                    glapiQuarter.SendKeysTransmit("1")
                End If
                isLoop = False
            Else
                RetryCounter += 1
                isLoop = True
                KillGLink()
                If RetryCounter > 30 Then
                    isErrorQuarter = True
                    isLoop = False
                    KillGLink()
                    ClientErrorMessage = "Location: GLinkStart_Quarter > Cannot start GLink."
                    Client_ParentControlScreen.BGW_ClientData.ReportProgress(99)
                    'WagesErrorMessage = "Location: GLinkStart" & vbCrLf & "Cannot connect to Wages!"
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

    Private Sub MenuScreen()
        glapiQuarter.SubmitField(FIELD_SSN, SocialSecurity(Index))
        glapiQuarter.SubmitField(FIELD_Selection, "2")
        glapiQuarter.TransmitPage()
        If glapiQuarter.GetString(6, 22, 22, 22) = "SEGMENT NOT FOUND" Then isQuarterExists = False Else isQuarterExists = True
    End Sub
    Private Sub GetQuarters()
        Dim i As Integer
        Dim isLoop As Boolean = True
        QuarterWages = New List(Of String)
        BaseWeeks = New List(Of String)
        QuarterYear = glapiQuarter.GetString(47, 7, 52, 7)
        While isLoop
            For i = 11 To 21
                If glapiQuarter.GetString(46, i, 54, i) <> "         " Then
                    QuarterWages.Add(glapiQuarter.GetString(46, i, 54, i))
                    BaseWeeks.Add(glapiQuarter.GetString(61, i, 62, i))
                End If
            Next
            If glapiQuarter.GetString(15, 23, 21, 23) = "20-NEXT" Then
                glapiQuarter.SubmitField(FIELD_Menu, "20")
                glapiQuarter.TransmitPage()
                isLoop = True
            Else
                isLoop = False
            End If
        End While
    End Sub
End Module
