Imports clsglink
Imports Glink
Imports System.IO
Imports clsFAMIS
Imports clsPhoenix
Imports System.Threading
Imports System.Xml

Public Class Form1
    Dim glapiTP8 As connGLinkTP8
    Dim WithEvents glapi As Glink.GlinkApi
    Dim isErrorThrown As Boolean
    'Dim Page1 As FAMISPage1
    Dim FAMISCaseInformation As CaseInformation
    Dim FAMISMedicaidInformation As MedicaidInformation
    Dim FAMISFoodStampInformation As FoodStampInformation
    Dim FAMISApplicationInformation As ApplicationInformation
    Dim FAMISTANFInformation As TANFInformation
    Dim FAMISIandAInformation As IandAInformation

    Dim GLAPIEvent As Integer
    Private Const START As Integer = 1
    Private Const STOPPED As Integer = 2
    Private Const CONNECTED As Integer = 3
    Private Const DISCONNECTED As Integer = 4
    Private Const TURN_RECEIVED As Integer = 5
    Private Const TURN_LOST As Integer = 6
    Private Const STRING_RECEIVED As Integer = 7
    Private Const GLINK_ERROR As Integer = 99


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Logger As New stdLog("C:\")
        'Logger.logMessage("Worked Successfully!", False)
        'Logger.logMessage("TEST", True)
        'Try
        '    glapiTP8 = New connGLinkTP8
        '    '       Page1 = New FAMISPage1
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        'ListBox1.Items.Add(FAMISCaseInformation.aB.Length.ToString & " - |" & FAMISCaseInformation.aB.GetData & "|")
        'ListBox1.Items.Add(FAMISCaseInformation.aK.Length.ToString & " - |" & FAMISCaseInformation.aK.GetData & "|")
        'ListBox1.Items.Add(FAMISCaseInformation.aC.Length.ToString & " - |" & FAMISCaseInformation.aC.GetData & "|")

        'ThreadPool.QueueUserWorkItem(AddressOf checkserver)
        'Try
        '    Dim testSQL As New PhoenixSQL("172.16.8.15", "PhoenixUser")
        '    Dim reader As SqlClient.SqlDataReader = Nothing
        '    reader = testSQL.Query("SELECT * FROM TEXT_CaseInformation")
        '    reader.Read()
        '    'MessageBox.Show(reader.GetString(0))
        'Catch ex As Exception
        '    MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message.ToString)
        'End Try
        'glapiTP8 = New connGLinkTP8
        'glapiTP8.bool_Visible = True
        'glapiTP8.Connect()

        'glapiTP8.SendKeysTransmit("HSA")
        'glapiTP8.SendKeysTransmit("LOGON")
        'glapiTP8.SubmitField(4, "16A215")
        'glapiTP8.SubmitField(6, "MIKE1A")
        'glapiTP8.SubmitField(8, "UAPSUP")
        'glapiTP8.TransmitPage()
        'glapiTP8.TransmitPage()
        ''  Threading.Thread.Sleep(500)
        'glapiTP8.SendKeysTransmit("BTCH,CONT,U999302")


        'FAMISCaseInformation.aB.SetData("C  ")
        'FAMISCaseInformation.aC.SetData("LEVINE      ")
        'famistanfinformation.iF1.SetData("-          ")
        'FAMISMedicaidInformation.WW.SetData("NPA")
        'FAMISMedicaidInformation.HC.SetData("06/2006   ")
        'FAMISIandAInformation.PK.SetData("X")
        'FAMISCaseInformation.aN.SetData("100.00")
        ''--PAGE 1--
        'glapiTP8.SubmitField(FAMISCaseInformation.aB.FieldNumber, FAMISCaseInformation.aB.GetData)
        'glapiTP8.SubmitField(FAMISCaseInformation.aC.FieldNumber, FAMISCaseInformation.aC.GetData)
        'glapiTP8.SubmitField(FAMISTANFInformation.IF1.FieldNumber, FAMISTANFInformation.IF1.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.WW.FieldNumber, FAMISMedicaidInformation.WW.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.HC.FieldNumber, FAMISMedicaidInformation.HC.GetData)
        'glapiTP8.SubmitField(FAMISIandAInformation.PK.FieldNumber, FAMISIandAInformation.PK.GetData)
        'glapiTP8.SubmitField(FAMISCaseInformation.aN.FieldNumber, FAMISCaseInformation.aN.GetData)

        'ListBox1.Items.Clear()
        'ListBox1.Items.Add("|" & FAMISCaseInformation.aB.GetData & "|")
        'ListBox1.Items.Add("|" & FAMISCaseInformation.aC.GetData & "|")
        glapi = New Glink.GlinkApi
        glapi.SessionName("C:\glpro\bullprod.cfg") 'PhoenixMedi.02") '
        glapi.setVisible(True)
        glapi.start()
        glapi.SendKeys("LOGON")
        glapi.sendCommandKey(Glink.GlinkKeyEnum.GlinkKey_ENTER)
        'glapi.SubmitField(4, "16A215")
        'glapi.SubmitField(6, "MIKE1A")
        'glapi.SubmitField(8, "UAPSUP")
        'glapi.sendCommandKey(Glink.GlinkKeyEnum.GlinkKey_ENTER)
        'glapi.sendCommandKey(Glink.GlinkKeyEnum.GlinkKey_ENTER)
        Threading.Thread.Sleep(500)
        'glapiTP8.SendKeysTransmit("BTCH,CONT,U999301")
        'glapi.sendCommandKey(Glink.GlinkKeyEnum.GlinkKey_ENTER)
        'glapi.SessionName("TEST!")
        'MessageBox.Show(glapi.getSessionName)

    End Sub

    Sub checkserver(ByVal state As Object)
        Dim PingTest As New System.Net.NetworkInformation.Ping
        Dim PingReply As System.Net.NetworkInformation.PingReply

        While True
            PingReply = PingTest.Send("172.16.8.15")
            If PingReply.Status <> Net.NetworkInformation.IPStatus.Success Then
                MessageBox.Show("Server Bombed" & vbCrLf & PingReply.Status.ToString)
            End If
            Thread.Sleep(1000)
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FIELDs As Glink.GlinkFields
        Dim FIELD As Glink.GlinkField
        Dim temp As String = Nothing

        'FIELDs = glapiTP8.GLAPI.getFields
        FIELDs = glapi.getFields
        If TypeOf FIELDs Is Glink.GlinkFields Then
            MessageBox.Show(FIELDs.getCount)
        End If
        Dim i As Integer
        For i = 0 To FIELDs.getCount - 1
            FIELD = FIELDs.item(i + 1)
            If FIELD.getAttribute = "-536861665" Then
                MessageBox.Show(temp & " is blinking.")
            End If

            If FIELD.isProtected = True Then temp = FIELD.getString
            If FIELD.isProtected = False Then
                ListBox1.Items.Add(temp & " = " & FIELDs.getFieldIndex(FIELD) & " (" & FIELD.getLength & ")" & "     -|" & FIELD.getAttribute & vbCrLf) 'FIELDs.getFieldIndex(FIELD) & " = " & FIELD.getString & "-| " & FIELD.getString.Length)
            End If
            '-536862689     NOT BLINKING
            '-536861665     BLINKING
        Next
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim FIELDS As Glink.GlinkFields
        Dim FIELD As Glink.GlinkField
        Dim i As Integer
        Dim Result As String = Nothing
        Dim tempField As String
        FIELDS = glapi.getFields
        For i = 0 To FIELDS.getCount - 1
            FIELD = FIELDS.item(i + 1)
            If FIELD.getAttribute = "-1073741700" Then
                tempField = FIELDS.item(i).getString.Replace("(", "")
                tempField = tempField.Replace(")", "")
                tempField = tempField.Replace(".", "")
                tempField = tempField.Replace(" ", "")
                Result += vbCrLf & tempField & FIELD.getString
            End If
        Next
        MessageBox.Show(Result)
    End Sub

    Private Sub GLAPI_onGlinkEvent(ByVal GLEvent As Glink.GlinkEvent) Handles glapi.onGlinkEvent
        '--Fired off of GLINK events--
        Dim EventCode As Integer = GLEvent.getEventCode

        Select Case EventCode
            Case 1
                GLAPIEvent = START
                '   MessageBox.Show("START")
            Case 2
                GLAPIEvent = STOPPED
                'MessageBox.Show("STOP")
            Case 3
                GLAPIEvent = CONNECTED
                '  MessageBox.Show("CONNECTED")
            Case 4
                GLAPIEvent = DISCONNECTED
                '  MessageBox.Show("DISCONNECTED")
            Case 5
                GLAPIEvent = TURN_RECEIVED
                '  MessageBox.Show("TURN RECEIVED")
            Case 6
                GLAPIEvent = TURN_LOST
                '  MessageBox.Show("TURN LOST")
            Case 7
                GLAPIEvent = STRING_RECEIVED
                'MessageBox.Show("STRING RECEIVED")
            Case 99
                GLAPIEvent = GLINK_ERROR
                '  MessageBox.Show("UNKNOWN")
            Case Else
                '--A code we're unsure of the meaning was called. Do nothing--
                GLAPIEvent = Nothing
        End Select
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim FIELDS As Glink.GlinkFields
        FIELDS = glapi.getFields
        FIELDS.item(TextBox1.Text).setString("TEST")
    End Sub

End Class
