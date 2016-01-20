Public Class DeleteCase

    Private Sub btn_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        Dim CaseNumber As String
        Dim SQLConn As New SqlConnection("Data Source=172.16.8.15\PHOENIX;Failover Partner=Phoenix_Mirror\PhoenixMirror;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password")
        Dim SQLComm As New SqlCommand
        SQLComm.Connection = SQLConn
        If txt_CaseNumber.Text.Length = 7 Or txt_CaseNumber.Text.Length = 10 Then
            Try
                If txt_CaseNumber.Text.Length = 7 Then txt_CaseNumber.Text = txt_CaseNumber.Text & "016"
                CaseNumber = txt_CaseNumber.Text.ToUpper
                SQLConn.Open()
                SQLComm.CommandText = "DELETE FROM FAMISCaseChild WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = "DELETE FROM famisCASEINFORMATION WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = "DELETE FROM famisAFDCINFORMATION  WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = "DELETE FROM famisAPPLICANTINFORMATION WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = " DELETE FROM famisFOODSTAMPINFORMATION WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = "DELETE FROM famisIANDAINFORMATION WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = "DELETE FROM famisINCOMEINFORMATION WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = "DELETE FROM famisINDIVIDUALSINFORMATION WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = "DELETE FROM famisMEDICAIDINFORMATION  WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                SQLComm.CommandText = "DELETE FROM famisVRPINFORMATION WHERE CaseNumber = '" & CaseNumber & "'"
                SQLComm.ExecuteNonQuery()
                MessageBox.Show("Case removed from server.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error!" & vbCrLf & "'" & ex.Message & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Invalid case number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
