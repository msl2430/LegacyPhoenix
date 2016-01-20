Imports Glink
Imports System.IO
Imports System.Threading
Imports System.Xml

Public Class Form2

    Private WithEvents glapi As Glink.Auto

    Private GLAPIEvent As String
    Private glapi2, glapi3 As Glink.Auto
    Private Const TRANSMIT As String = "^[i"
    Private Const ONTURNRECEIVED As String = "OnTurnReceived"

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GLAPIEvent = Nothing
            glapi = New Glink.Auto
            glapi = GetObject("", "GLink.Auto")
            glapi.LoadConfig("C:\GLPro\BullProd.cfg")
            glapi.ProcessLine = True
            glapi.Connect(Nothing)
            glapi.Visible = True
            glapi.SendKeys("LOGON")
            TransmitPage()
            glapi.SendKeys("16A247VIST0AUAPSUP")
            'glapi.Screen.Field(4).FieldText = "16A247"
            'glapi.Screen.Field(6).FieldText = "VIST0A"
            'glapi.Screen.Field(8).FieldText = "UAPSUP"
            TransmitPage()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TransmitPage()
        glapi.SendKeys(TRANSMIT)
        Thread.Sleep(500)
        While Not GLAPIEvent = ONTURNRECEIVED
            Thread.Sleep(500)
        End While
    End Sub

    Private Sub GLAPI_OnTurn(ByVal OnTurn As Boolean) Handles glapi.OnTurn
        'GLAPIEvent = ONTURNRECEIVED
    End Sub
    Private Sub GLAPI_OnData() Handles glapi.OnData
        'MessageBox.Show("ONDATA")
    End Sub
End Class