Imports System.Data.SqlClient

Partial Class IMPsForm
    Inherits System.Web.UI.Page

    Private CaseNumber, ERRORMESSAGE1, ERRORMESSAGE2, ERRORMESSAGE3, ERRORMESSAGE4, ERRORMESSAGE5, BATCHNUMBER As String
    Private SelectDate As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Phoenix - IMP / TRE Results"
        Response.Write("<div style='float: left;'>Phoenix - IMP / TRE Results</div><div style='margin-left: 500px;' id='Print'><a href='#' onclick='window.print();'>Print Report</a></div>")
        SelectDate = Request.QueryString("Date")
        WriteInfo("<br />" & SelectDate)
        GetInfo()
    End Sub

    Protected Sub GetInfo()
        Dim SQLConn As New SqlConnection("Data Source=172.16.8.15\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password")
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        SQLComm.Connection = SQLConn
        SQLConn.Open()

        WriteInfo("<br />" & "--CASES DROPPED--" & "<br />")

        SQLComm.CommandText = "SELECT CASENUMBER, REASON, REASON2, REASON3, REASON4, REASON5 FROM IMPSInformation WHERE Dropped = 'True' and dateentered = '" & SelectDate & "'"
        SQLReader = SQLComm.ExecuteReader
        If SQLReader.HasRows = True Then
            While SQLReader.Read
                If SQLReader.IsDBNull(0) = False Then CaseNumber = SQLReader.GetString(0)
                If SQLReader.IsDBNull(1) = False Then ERRORMESSAGE1 = SQLReader.GetString(1)
                If SQLReader.IsDBNull(2) = False Then ERRORMESSAGE2 = SQLReader.GetString(2)
                If SQLReader.IsDBNull(3) = False Then ERRORMESSAGE3 = SQLReader.GetString(3)
                If SQLReader.IsDBNull(4) = False Then ERRORMESSAGE4 = SQLReader.GetString(4)
                If SQLReader.IsDBNull(5) = False Then ERRORMESSAGE5 = SQLReader.GetString(5)
                WriteDropSheet()
            End While
            SQLReader.Close()
            SQLConn.Close()
        Else
            SQLConn.Close()
            WriteInfo("*****No Dropped Cases*****")
        End If
        WriteInfo("<br />" & "<br />" & "--CASES COMPLETED--" & "<br />")

        SQLConn.Open()
        SQLComm.CommandText = "SELECT CASENUMBER, BATCHNUMBER FROM IMPSInformation WHERE Dropped = 'False' and DateEntered = '" & SelectDate & "' ORDER BY BatchNumber"
        SQLReader = SQLComm.ExecuteReader
        If SQLReader.HasRows = True Then
            While SQLReader.Read
                If SQLReader.IsDBNull(0) = False Then CaseNumber = SQLReader.GetString(0)
                If SQLReader.IsDBNull(1) = False Then BATCHNUMBER = SQLReader.GetString(1)
                WriteSuccessSheet()
            End While
            SQLReader.Close()
            SQLConn.Close()
        Else
            SQLConn.Close()
            WriteInfo("*****No Completed Cases*****")
        End If
    End Sub
    Protected Sub WriteDropSheet()

        WriteInfo("Case Number: " & CaseNumber)
        If ERRORMESSAGE1.Substring(0, 10) <> "          " Then
            WriteInfo("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Error Reason:&nbsp;" & ERRORMESSAGE1)
        End If
        If ERRORMESSAGE2.Substring(0, 10) <> "          " Then
            WriteInfo("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Error Reason:&nbsp;" & ERRORMESSAGE2)
        End If
        If ERRORMESSAGE3.Substring(0, 10) <> "          " Then
            WriteInfo("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Error Reason:&nbsp;" & ERRORMESSAGE3)
        End If
        If ERRORMESSAGE4.Substring(0, 10) <> "          " Then
            WriteInfo("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Error Reason:&nbsp;" & ERRORMESSAGE4)
        End If
        If ERRORMESSAGE5.Substring(0, 10) <> "          " Then
            WriteInfo("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Error Reason:&nbsp;" & ERRORMESSAGE5)
        End If
    End Sub
    Protected Sub WriteSuccessSheet()
        WriteInfo("Case Number:&nbsp;" & CaseNumber & "&nbsp;&nbsp;&nbsp;&nbsp;Batch Number:&nbsp;" & BATCHNUMBER)
    End Sub

    Protected Sub WriteInfo(ByVal StringToSend As String)
        Response.Write(StringToSend & "</br>")
    End Sub
End Class
