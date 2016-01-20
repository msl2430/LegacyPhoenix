Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports AjaxControlToolkit
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
Public Class SupervisorWorkerList
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function SetSupervisor(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim SQLConn As New SqlConnection("Data Source=172.16.8.15\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password") '" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password")
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        Dim SupValues As New List(Of CascadingDropDownNameValue)()

        SQLComm.Connection = SQLConn
        SQLConn.Open()

        SQLComm.CommandText = "SELECT DISTINCT Supervisor FROM ClientDataMaster ORDER BY Supervisor"
        SQLReader = SQLComm.ExecuteReader
        While SQLReader.Read
            SupValues.Add(New CascadingDropDownNameValue(SQLReader.GetString(0), SQLReader.GetString(0)))
        End While

        SQLConn.Close()

        Return SupValues.ToArray()
    End Function

    <WebMethod()> _
    Public Function SetWorker(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim SQLConn As New SqlConnection("Data Source=172.16.8.15\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password") '" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password")
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        Dim KnownValue As StringDictionary
        Dim SupID As String
        Dim Workervalues As New List(Of CascadingDropDownNameValue)()
        KnownValue = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
        SupID = KnownValue("Supervisor")

        SQLComm.Connection = SQLConn
        SQLConn.Open()

        SQLComm.CommandText = "SELECT DISTINCT Worker FROM ClientDataMaster WHERE Supervisor = '" & SupID & "' ORDER BY Worker"
        SQLReader = SQLComm.ExecuteReader
        While SQLReader.Read
            Workervalues.Add(New CascadingDropDownNameValue(SQLReader.GetString(0), SQLReader.GetString(0)))
        End While

        SQLConn.Close()

        Return Workervalues.ToArray()
    End Function

End Class
