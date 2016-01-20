Module Users

    Private UserList(100), UserStatus(100), UserCases(100), UserVersion(100), UserTime(100) As String

    Public Sub FillUserTable()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim Reader As SqlDataReader
        Dim Total As Integer
        Dim i As Integer = 0
        SQLComm.Connection = SQLConn
        ParentControlScreen.grid_Users.Rows.Clear()
        Try
            SQLConn.Open()
            SQLComm.CommandText = "SELECT * FROM OnlineUsers"
            Reader = SQLComm.ExecuteReader
            While Reader.Read
                If Reader.HasRows Then
                    If DateDiff(DateInterval.Minute, Reader.GetDateTime(2), Date.Now) < 30 Then
                        UserList(i) = Reader.GetString(0)
                        UserStatus(i) = Reader.GetString(1)
                        UserTime(i) = Reader.GetDateTime(2)
                        UserCases(i) = Reader.GetInt32(3)
                        UserVersion(i) = Reader.GetString(4)
                    ElseIf Reader.GetString(1) <> "Offline   " Then
                        UserList(i) = Reader.GetString(0)
                        UserStatus(i) = "Timed Out"
                        UserTime(i) = Reader.GetDateTime(2)
                        UserCases(i) = Reader.GetInt32(3)
                        UserVersion(i) = Reader.GetString(4)
                    Else
                        UserList(i) = Reader.GetString(0)
                        UserStatus(i) = Reader.GetString(1)
                        UserTime(i) = Reader.GetDateTime(2)
                        UserCases(i) = Reader.GetInt32(3)
                        UserVersion(i) = Reader.GetString(4)
                    End If
                    i += 1
                End If
            End While
            Total = i
            Reader.Close()
            If Total > 0 Then
                For i = 0 To Total - 1
                    SQLComm.CommandText = "SELECT Name FROM OperatorID WHERE OperatorNumber = '" & UserList(i) & "'"
                    Reader = SQLComm.ExecuteReader
                    Reader.Read()
                    If Reader.HasRows Then UserList(i) = Reader.GetString(0)
                    Reader.Close()
                Next
                ParentControlScreen.grid_Users.Rows.Add(Total)
                For i = 0 To Total - 1
                    ParentControlScreen.grid_Users.Item(0, i).Value = UserList(i)
                    ParentControlScreen.grid_Users.Item(1, i).Value = UserStatus(i)
                    ParentControlScreen.grid_Users.Item(2, i).Value = UserCases(i)
                    ParentControlScreen.grid_Users.Item(3, i).Value = UserTime(i)
                    ParentControlScreen.grid_Users.Item(4, i).Value = UserVersion(i)
                    If UserStatus(i) = "Online    " Then
                        ParentControlScreen.grid_Users.Rows(i).Cells(1).Style.BackColor = Color.Green
                    ElseIf UserStatus(i) = "Offline   " Then
                        ParentControlScreen.grid_Users.Rows(i).Cells(1).Style.BackColor = Color.OrangeRed
                    Else
                        ParentControlScreen.grid_Users.Rows(i).Cells(1).Style.BackColor = Color.Red
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Location: FillUserTable" & vbCrLf & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Public Sub ResetCaseTotal()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText = "UPDATE OnlineUsers SET CasesDone = 0"
            SQLComm.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Location: ResetCaseTotal" & vbCrLf & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub
End Module
