Imports System.Data.SqlClient

Partial Class LookupTest
    Inherits System.Web.UI.Page

    Protected Sub btn_Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Submit.Click
        Page.Validate()
        If Not Page.IsValid Then
            lbl_Error.Text = "* Social Security, First Name, and Last Name are required."
            lbl_CaseSubmitted.Visible = False
            If txt_SSN.Text = Nothing Then txt_SSN.BackColor = Drawing.Color.Tomato Else txt_SSN.BackColor = Drawing.Color.White
            If txt_FirstName.Text = Nothing Then txt_FirstName.BackColor = Drawing.Color.Tomato Else txt_FirstName.BackColor = Drawing.Color.White
            If txt_LastName.Text = Nothing Then txt_LastName.BackColor = Drawing.Color.Tomato Else txt_LastName.BackColor = Drawing.Color.White
            'If txt_DateOfBirth.Text = Nothing Then txt_DateOfBirth.BackColor = Drawing.Color.Tomato Else txt_DateOfBirth.BackColor = Drawing.Color.White
            'If txt_Address1.Text = Nothing Then txt_Address1.BackColor = Drawing.Color.Tomato : txt_Address2.BackColor = Drawing.Color.Tomato Else txt_Address1.BackColor = Drawing.Color.White : txt_Address2.BackColor = Drawing.Color.White
            'If txt_City.Text = Nothing Then txt_City.BackColor = Drawing.Color.Tomato Else txt_City.BackColor = Drawing.Color.White
            'If txt_State.Text = Nothing Then txt_State.BackColor = Drawing.Color.Tomato Else txt_State.BackColor = Drawing.Color.White
            'If txt_ZipCode.Text = Nothing Then txt_ZipCode.BackColor = Drawing.Color.Tomato Else txt_ZipCode.BackColor = Drawing.Color.White
        Else
            If isSubmitCase() Then
                lbl_CaseSubmitted.Text = "* Case submitted successfully."
                lbl_CaseSubmitted.Visible = True
                lbl_Error.Visible = False
                txt_SSN.BackColor = Drawing.Color.White
                txt_FirstName.BackColor = Drawing.Color.White
                txt_LastName.BackColor = Drawing.Color.White
                txt_DateOfBirth.BackColor = Drawing.Color.White
                txt_Address1.BackColor = Drawing.Color.White
                txt_Address2.BackColor = Drawing.Color.White
                txt_City.BackColor = Drawing.Color.White
                txt_State.BackColor = Drawing.Color.White
                txt_ZipCode.BackColor = Drawing.Color.White
                txt_SSN.Text = Nothing
                txt_FirstName.Text = Nothing
                txt_LastName.Text = Nothing
                txt_DateOfBirth.Text = Nothing
                txt_Address1.Text = Nothing
                txt_Address2.Text = Nothing
                txt_City.Text = Nothing
                txt_State.Text = Nothing
                txt_ZipCode.Text = Nothing
                drop_Sex.SelectedIndex() = 0
            End If
        End If
    End Sub

    Private Function isSubmitCase() As Boolean
        Dim SQLConn As New SqlConnection("User ID=PhoenixUser;Data Source=172.16.8.15\Phoenix;FailOver Partner=192.168.204.3;Password=password;Initial Catalog=PhoenixData;" & _
                      "Connect Timeout=3;Integrated Security=False;Persist Security Info=True;")
        Dim SQLComm As New SqlCommand
        SQLComm.Connection = SQLConn
        If txt_FirstName.Text = Nothing Or txt_FirstName.Text = "" Then txt_FirstName.Text = " "
        If txt_LastName.Text = Nothing Or txt_LastName.Text = "" Then txt_LastName.Text = " "
        If txt_DateOfBirth.Text = Nothing Or txt_DateOfBirth.Text = "" Then txt_DateOfBirth.Text = " "
        If txt_Address1.Text = Nothing Or txt_DateOfBirth.Text = "" Then txt_DateOfBirth.Text = " "
        If txt_Address2.Text = Nothing Or txt_Address2.Text = "" Then txt_Address2.Text = " "
        If txt_City.Text = Nothing Or txt_City.Text = "" Then txt_City.Text = " "
        If txt_State.Text = Nothing Or txt_State.Text = "" Then txt_State.Text = " "
        If txt_ZipCode.Text = Nothing Or txt_ZipCode.Text = "" Then txt_ZipCode.Text = " "
        Try
            SQLConn.Open()
            SQLComm.CommandText = "INSERT INTO CRLNewCase VALUES ('" & txt_SSN.Text.ToUpper & "', '" & txt_FirstName.Text.ToUpper & "', '" & txt_LastName.Text.ToUpper & "', '" & drop_Sex.SelectedValue.ToUpper & "', '" & txt_DateOfBirth.Text.Replace("/", "").ToUpper & "', '" & txt_Address1.Text.ToUpper & "', '" & txt_Address2.Text.ToUpper & "', '" & txt_City.Text.ToUpper & "', '" & txt_State.Text.ToUpper & "', '" & txt_ZipCode.Text & "')"
            SQLComm.ExecuteNonQuery()
        Catch ex As Exception
            Response.Write(ex.Message)
            Return False
        Finally
            SQLConn.Close()
        End Try
        Return True
    End Function
End Class
