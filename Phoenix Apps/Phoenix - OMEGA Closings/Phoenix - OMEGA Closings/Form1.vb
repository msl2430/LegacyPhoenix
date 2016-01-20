Public Class Form1

    Private CaseManager, LastName, FirstName, Middle, CaseNumber, SEG, WFNJ, TANF As String
    Private CaseCount As Integer
    Private CaseList As New List(Of String)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Settings.phxSQLConn = "User ID=PhoenixUser;Data Source=" & My.Settings.SQLAddress & "\Phoenix;;FailOver Partner=192.168.204.3\Phoenix;Password=password;Initial Catalog=PhoenixData;" & _
                      "Connect Timeout=3;Integrated Security=False;Persist Security Info=False;"
        ReadReport()
        MessageBox.Show("DONE")
    End Sub

    Private Sub ReadReport()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim Report As New StreamReader("C:\APR1_TANF.txt")
        Dim Record As String
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn
            SQLComm.CommandText = "DELETE FROM OMEGAReportCases"
            SQLComm.ExecuteNonQuery()
            While Report.Peek <> -1
                Record = Report.ReadLine
                If Record <> Nothing Then
                    If Record.Length > 4 Then
                        If Record.Substring(1, 4) = "LAST" Then
                            Report.ReadLine()
                            Record = Report.ReadLine
                            While Record.Substring(0, 3) <> "16A"
                                LastName = Record.Substring(1, 12)
                                FirstName = Record.Substring(14, 10)
                                Middle = Record.Substring(24, 1)
                                CaseNumber = Record.Substring(27, 7)
                                SEG = Record.Substring(36, 3)
                                WFNJ = Record.Substring(41, 3)
                                CaseManager = Record.Substring(49, 4)
                                TANF = Record.Substring(104, 1)
                                If (CaseManager.Substring(0, 2) = "CB" Or CaseManager.Substring(0, 2) = "PL") And CaseManager.Substring(2, 2) <> "52" Then
                                    If TANF = "G" Or TANF = "S" Or TANF = "A" Or TANF = "C" Then
                                        CompareMonths()
                                    End If
                                End If
                                Record = Report.ReadLine
                                CaseList.Add(CaseNumber)
                                CaseCount += 1
                                Label1.Text = CaseCount.ToString
                            End While
                        End If
                    End If
                End If
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub StorePrimaryMonth()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText = "SELECT CaseNumber FROM OMEGAPrimaryMonth WHERE CaseNumber = '" & CaseNumber & "'"
            SQLReader = SQLComm.ExecuteReader
            If SQLReader.Read And Not SQLReader.HasRows Then
                SQLReader.Close()
                SQLComm.CommandText = "INSERT INTO OMEGAPrimaryMonth VALUES ('" & CaseManager & "', '" & CaseNumber & "', '" & FirstName & "', '" & LastName & "', '" & Middle & "', '" & SEG & "', '" & WFNJ & "', '" & TANF & "')"
                SQLComm.ExecuteNonQuery()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub

    Private Sub CompareMonths()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        SQLComm.Connection = SQLConn
        Try
            If CaseList.IndexOf(CaseNumber) = -1 Then
                SQLConn.Open()
                SQLComm.CommandText = "SELECT CaseNumber, TANF FROM OMEGAHoldOver WHERE CaseNumber = '" & CaseNumber & "'"
                SQLReader = SQLComm.ExecuteReader
                SQLReader.Read()
                If SQLReader.HasRows Then
                    If TANF = "C" And SQLReader.GetString(1) = "C" Then
                        '--If case is in the Hold Over area and is still 'C' then move case to Reporting Table--
                        SQLReader.Close()
                        SQLComm.CommandText = "DELETE FROM OMEGAHoldOver WHERE CaseNumber = '" & CaseNumber & "'"
                        SQLComm.ExecuteNonQuery()
                        SQLComm.CommandText = "INSERT INTO OMEGAReportCases VALUES ('" & CaseManager & "', '" & CaseNumber & "', '" & FirstName & "', '" & LastName & "', '" & Middle & "', '" & SEG & "', '" & WFNJ & "', '" & TANF & "')"
                        SQLComm.ExecuteNonQuery()
                    Else
                        '--Case is in Hold Over area but has been reissued so remove from Hold Over area--
                        SQLReader.Close()
                        SQLComm.CommandText = "DELETE FROM OMEGAHoldOver WHERE CaseNumber = '" & CaseNumber & "'"
                        SQLComm.ExecuteNonQuery()
                    End If
                Else
                    '--Case not in Hold Over area--
                    '--Check to see if it's new since last month or has been closed since last month--
                    SQLReader.Close()
                    SQLComm.CommandText = "SELECT CaseNumber, TANF FROM OMEGAPrimaryMonth WHERE CaseNumber = '" & CaseNumber & "'"
                    SQLReader = SQLComm.ExecuteReader
                    SQLReader.Read()
                    If SQLReader.HasRows Then
                        '--Case on from past month--
                        If SQLReader.GetString(1) <> TANF And TANF = "C" Then
                            '--Case is has been close since last month move to Hold Over area--
                            SQLReader.Close()
                            SQLComm.CommandText = "INSERT INTO OMEGAHoldOver VALUES ('" & CaseManager & "', '" & CaseNumber & "', '" & FirstName & "', '" & LastName & "', '" & Middle & "', '" & SEG & "', '" & WFNJ & "', '" & TANF & "')"
                            SQLComm.ExecuteNonQuery()
                        End If
                    Else
                        '--Case not on from past month add to Primary Month List--
                        If TANF <> "C" Then
                            SQLReader.Close()
                            SQLComm.CommandText = "SELECT CaseNumber FROM OMEGAPrimaryMonth WHERE CaseNumber = '" & CaseNumber & "'"
                            SQLReader = SQLComm.ExecuteReader
                            SQLReader.Read()
                            If Not SQLReader.HasRows Then
                                SQLReader.Close()
                                SQLComm.CommandText = "INSERT INTO OMEGAPrimaryMonth VALUES ('" & CaseManager & "', '" & CaseNumber & "', '" & FirstName & "', '" & LastName & "', '" & Middle & "', '" & SEG & "', '" & WFNJ & "', '" & TANF & "')"
                                SQLComm.ExecuteNonQuery()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub
End Class
