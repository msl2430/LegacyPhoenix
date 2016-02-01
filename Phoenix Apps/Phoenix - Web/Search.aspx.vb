Imports System.Threading
Imports System.Data.SqlClient

Partial Class Search
    Inherits System.Web.UI.Page

    Private SSN, FirstName, LastName, Supervisor, Worker As String

    Protected Sub btn_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Search.Click
        Dim SQLConn As New SqlConnection("Data Source=172.16.8.15\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password") '" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password")
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        Dim CommandText As String = "SELECT DISTINCT SocialSecurity, FirstName, LastName FROM ClientDataMaster "
        Dim isWhereSet As Boolean = False
        Dim SSN, FirstName, LastName, CaseSelected As String
        list_Results.Items.Clear()

        If txt_SSN.Text.Length = 9 Then
            CommandText &= "WHERE SocialSecurity = '" & txt_SSN.Text & "' "
            isWhereSet = True
        End If
        If txt_FirstName.Text.Length > 0 Then
            If isWhereSet Then CommandText &= "AND FirstName LIKE '" & txt_FirstName.Text.ToUpper & "%' " Else CommandText &= "WHERE FirstName LIKE '" & txt_FirstName.Text.ToUpper & "%' "
            isWhereSet = True
        End If
        If txt_LastName.Text.Length > 0 Then
            If isWhereSet Then CommandText &= "AND LastName LIKE '" & txt_LastName.Text.ToUpper & "%' " Else CommandText &= "WHERE LastName LIKE '" & txt_LastName.Text.ToUpper & "%' "
            isWhereSet = True
        End If
        If drop_Supervisor.SelectedItem.ToString <> "" Then
            If isWhereSet Then CommandText &= "AND Supervisor = '" & drop_Supervisor.SelectedItem.ToString.ToUpper & "' " Else CommandText &= "WHERE Supervisor = '" & drop_Supervisor.SelectedItem.ToString.ToUpper & "' "
            isWhereSet = True
        End If
        If drop_Worker.SelectedItem.ToString <> "" Then
            If isWhereSet Then CommandText &= "AND Worker = '" & drop_Worker.SelectedItem.ToString.ToUpper & "' " Else CommandText &= "WHERE Worker = '" & drop_Worker.SelectedItem.ToString.ToUpper & "' "
            isWhereSet = True
        End If

        CommandText &= "ORDER BY LastName"

        SQLComm.Connection = SQLConn
        SQLConn.Open()
        SQLComm.CommandText = CommandText
        SQLReader = SQLComm.ExecuteReader
        While SQLReader.Read
            If list_Results.Items.Count = 0 Then
                list_Results.Items.Add(SQLReader.GetString(0) & " " & SQLReader.GetString(2).Replace(" ", "") & ", " & SQLReader.GetString(1).Replace(" ", ""))
            Else
                For i As Integer = 0 To list_Results.Items.Count - 1
                    If list_Results.Items(i).Text.Substring(0, 9) = txt_SSN.Text Then
                        If list_Results.Items(i).Text.Length < 13 And Not SQLReader.IsDBNull(2) Then
                            list_Results.Items.RemoveAt(i)
                            list_Results.Items.Add(SQLReader.GetString(0) & " " & SQLReader.GetString(2).Replace(" ", "") & ", " & SQLReader.GetString(1).Replace(" ", ""))
                        End If
                    End If
                Next
                list_Results.Items.Add(SQLReader.GetString(0) & " " & SQLReader.GetString(2).Replace(" ", "") & ", " & SQLReader.GetString(1).Replace(" ", ""))
            End If
        End While
        If list_Results.Items.Count = 1 Then
            list_Results.SelectedIndex = 0
            CaseSelected = list_Results.SelectedItem.ToString
            SSN = CaseSelected.Substring(0, CaseSelected.IndexOf(" "))
            LastName = CaseSelected.Substring(CaseSelected.IndexOf(" "), CaseSelected.IndexOf(",") - CaseSelected.IndexOf(" "))
            FirstName = CaseSelected.Substring(CaseSelected.LastIndexOf(",") + 1)
            Response.Redirect("ClientInfo.aspx?SSN=" & SSN.Replace(" ", "") & "&LN=" & LastName.Replace(" ", "") & "&FN=" & FirstName.Replace(" ", ""))
            btn_Submit.Enabled = False
            lbl_NoCase.Visible = False
        ElseIf list_Results.Items.Count = 0 Then
            btn_Submit.Enabled = False
            lbl_NoCase.Text = "No Cases Found."
            lbl_NoCase.Visible = True
        Else
            btn_Submit.Enabled = True
            lbl_NoCase.Visible = False
        End If
        SQLConn.Close()
    End Sub
    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim SSN, FirstName, LastName, CaseSelected As String
        If list_Results.SelectedIndex >= 0 Then
            CaseSelected = list_Results.SelectedItem.ToString
            SSN = CaseSelected.Substring(0, CaseSelected.IndexOf(" "))
            LastName = CaseSelected.Substring(CaseSelected.IndexOf(" "), CaseSelected.LastIndexOf(",") - CaseSelected.IndexOf(" "))
            FirstName = CaseSelected.Substring(CaseSelected.IndexOf(",") + 1)
            Response.Redirect("ClientInfo.aspx?SSN=" & SSN.Replace(" ", "") & "&LN=" & LastName.Replace(" ", "") & "&FN=" & FirstName.Replace(" ", ""))
        Else
            lbl_NoCase.Text = "Please Select A Case First."
            lbl_NoCase.Visible = True
        End If
    End Sub
End Class