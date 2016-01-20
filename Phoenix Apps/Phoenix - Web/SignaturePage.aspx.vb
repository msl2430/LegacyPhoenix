Imports System.Data.SqlClient

Partial Class SignaturePage
    Inherits System.Web.UI.Page

    Private CaseNumber, FirstName, LastName, SSN, AppType, AppSup, AppWorker, AppCode, AppAmount As String
    Private AppDate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Phoenix - 30 Day Pending FAMIS Cases"
        WriteInfo("<style type='text/css'>body{font-size: small;margin: 0px;}.reporttable td{font-size: smaller;text-align: center;width: 50;padding: 0px 7px 0px 7px;}</style>")
        WriteInfo("<div style='float: left; font-size: medium;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;30 Day Pending FAMIS Cases</div><div style='margin-left: 500px;' id='Print'><a href='#' onclick='window.print();'>Print Report</a></div>" & vbCrLf)
        WriteInfo("<br /><table class='reporttable'>")
        WriteInfo("<tr><td>CASE NUMBER</td><td>APP DATE</td><td>FIRST NAME</td><td>LAST NAME</td><td>SSN</td><td>APP TYPE</td><td>APP SUP</td><td>APP WORKER</td><td>APP CODE</td><td>APP AMOUNT</td></tr>")
        GetInfo()
        WriteInfo("</table>")
    End Sub

    Protected Sub GetInfo()
        Dim SQLConn As New SqlConnection("Data Source=172.16.8.15\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password")
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        SQLComm.Connection = SQLConn
        SQLConn.Open()

        SQLComm.CommandText = "SELECT * FROM SignatureReport WHERE APPDATE < '" & Date.Now.AddMonths(-1).Month & "/" & Date.Now.AddMonths(-1).Day & "/" & Date.Now.AddMonths(-1).Year & "' ORDER BY AppSup, AppWorker, AppDate"
        SQLReader = SQLComm.ExecuteReader
        If SQLReader.HasRows = True Then
            While SQLReader.Read
                CaseNumber = SQLReader.GetString(0)
                AppDate = SQLReader.GetDateTime(1)
                FirstName = SQLReader.GetString(2)
                LastName = SQLReader.GetString(3)
                SSN = SQLReader.GetString(4)
                AppType = SQLReader.GetString(5)
                AppSup = SQLReader.GetString(6)
                AppWorker = SQLReader.GetString(7)
                AppCode = SQLReader.GetString(8)
                AppAmount = SQLReader.GetString(9)
                WriteCase()
            End While
        Else
            WriteInfo("<tr><td colspan='10' align='center'><br />...NO CASES...</td></tr>")
        End If
    End Sub
    Protected Sub WriteCase()
        Dim tempAmount As String = AppAmount
        If AppAmount = "0000" Then tempAmount = "    "
        If AppAmount.Substring(0, 1) = "0" Then
            If AppAmount.Substring(0, 2) = "00" Then
                If AppAmount.Substring(0, 3) = "000" Then
                    tempAmount = "   " & AppAmount.Substring(3, 1)
                Else
                    tempAmount = "  " & AppAmount.Substring(2, 2)
                End If
            Else
                tempAmount = " " & AppAmount.Substring(1, 3)
            End If
        End If
        WriteInfo("<tr><td>" & CaseNumber & "</td><td>" & AppDate.Month.ToString.PadLeft(2, " ") & "/" & AppDate.Day.ToString & "/" & AppDate.Year.ToString.Substring(2, 2) & "</td><td>" & FirstName & "</td><td>" & LastName & "</td><td>" & SSN & "</td><td>" & AppType & "</td><td>" & AppSup & "</td><td>" & AppWorker & "</td><td>" & AppCode & "</td><td>" & tempAmount & "</td></tr>")
    End Sub

    Protected Sub WriteInfo(ByVal StringToSend As String)
        Response.Write(StringToSend)
    End Sub
End Class
