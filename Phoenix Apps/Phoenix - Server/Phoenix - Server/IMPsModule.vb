'--Developed by Michael Levine 10/2007--
Imports Microsoft.Win32
Imports clsIMPS

Module IMPsModule
    '--Process IMPS files through GLink--

#Region "Declarations"
    Public IMPSFileName As String                       '--IMPS file name--
    Public IMPSBatchNumber As String                    '--Batch number--
    Public Old_IMPSBatchNumber As String                '--Old batch number--
    Public IMPSResult As String                         '--Result of IMPS case processing--
    Public ErrorMessage1 As String
    Public isSQLError, isLogonError As Boolean
    Public isInvalidPassword As Boolean                 '--Tracks if the password was invalid--

    Private IMPSInformation As IMPSData                 '--IMPS data blocks--
    Private glapiIMPS As connGLinkTP8                   '--GLink connection for IMPS--
    Private ErrorMessage2, ErrorMessage3, ErrorMessage4, ErrorMessage5 As String
#End Region

    Public Sub ProcessIMPS()
        Dim isLoop As Boolean = True
        Dim RetryCounter As Integer = 0
        While isLoop And RetryCounter < 4
            isSQLError = False
            readIMPSFile()
            GLinkStartIMPS()
            If isLogonError = False Then
                Thread.Sleep(750)
                CreateBatchIMPS()
                Thread.Sleep(750)
                SubmitIMPS()
                Thread.Sleep(500)
                If glapiIMPS.GetString(30, 2, 51, 2) = "BATCH BALANCING SCREEN" Then
                    CloseBatchIMPS()
                    glapiIMPS.Disconnect()
                    Old_IMPSBatchNumber = IMPSBatchNumber
                    SetBatchIMPS()
                    IMPSResult = "SUCCESS"
                    StoreSQLIMPS()
                    isLoop = False
                ElseIf glapiIMPS.GetString(1, 2, 13, 2) = "CASE IN BATCH" Then
                    ErrorMessage1 = glapiIMPS.GetString(1, 2, 21, 2)
                    ErrorMessage2 = "                    "
                    ErrorMessage3 = "                    "
                    ErrorMessage4 = "                    "
                    ErrorMessage5 = "                    "
                    DropCaseIMPS(ErrorMessage1, ErrorMessage2, ErrorMessage3, ErrorMessage4, ErrorMessage5)
                    DeleteBatchIMPS()
                    IMPSResult = "DROP"
                    isLoop = False
                ElseIf isSQLError Then
                    ErrorMessage1 = "SQL Error. Case Deleted."
                    ErrorMessage2 = "                    "
                    ErrorMessage3 = "                    "
                    ErrorMessage4 = "                    "
                    ErrorMessage5 = "                    "
                    DeleteBatchIMPS()
                    IMPSResult = "DROP"
                    isLoop = False
                Else
                    ErrorMessage1 = glapiIMPS.GetString(1, 19, 40, 19)
                    ErrorMessage2 = glapiIMPS.GetString(1, 20, 40, 20)
                    ErrorMessage3 = glapiIMPS.GetString(1, 21, 40, 21)
                    ErrorMessage4 = glapiIMPS.GetString(1, 22, 40, 22)
                    ErrorMessage5 = glapiIMPS.GetString(1, 23, 40, 23)
                    If ErrorMessage1.Substring(0, 10) <> "          " Then
                        DropCaseIMPS(ErrorMessage1, ErrorMessage2, ErrorMessage3, ErrorMessage4, ErrorMessage5)
                        DeleteBatchIMPS()
                        IMPSResult = "DROP"
                        isLoop = False
                    Else
                        isLoop = True
                        RetryCounter += 1
                        KillGLink()
                    End If
                End If
            Else
                '--GLink connection error--
                glapiIMPS.Disconnect()
                KillGLink()
                IMPSResult = "LOGONERROR"
                ErrorMessage1 = "Could not connect to FAMIS."
            End If
        End While
        If RetryCounter > 4 Then IMPSResult = "UNKNOWN" : KillGLink() : DeleteBatchIMPS()
    End Sub
    Private Sub KillGLink()
        Dim GLProcess() As Process
        Dim i As Integer
        GLProcess = Process.GetProcessesByName("gl")
        For i = 0 To GLProcess.Length - 1
            GLProcess(i).Kill()
        Next
    End Sub

    Private Sub readIMPSFile()
        Dim infile As New StreamReader(IMPSFileName, System.Text.Encoding.Default)
        Dim Record As String
        Try
            While infile.Peek <> -1
                Record = infile.ReadLine
                IMPSInformation = New IMPSData
                If Record <> Nothing Then
                    With IMPSInformation
                        setBlockDataIMPS(.CaseNumber, Record)
                        setBlockDataIMPS(.ISSType, Record)
                        setBlockDataIMPS(.INDCode, Record)
                        setBlockDataIMPS(.PayTypeCode, Record)
                        setBlockDataIMPS(.WarrantNumber, Record)
                        setBlockDataIMPS(.ISSDate, Record)
                        .ISSDate.SetData(.ISSDate.GetData.Insert(4, "20"))
                        setBlockDataIMPS(.CheckAmt, Record)
                        setBlockDataIMPS(.LastName, Record)
                        setBlockDataIMPS(.FirstName, Record)
                        setBlockDataIMPS(.INT1, Record)
                        setBlockDataIMPS(.PaymentToCase, Record)
                        setBlockDataIMPS(.VendorName, Record)
                        setBlockDataIMPS(.ExtraName, Record)
                        setBlockDataIMPS(.Street, Record)
                        setBlockDataIMPS(.CityState, Record)
                        setBlockDataIMPS(.ZipCode, Record)
                        setBlockDataIMPS(.ProvCode, Record)
                        setBlockDataIMPS(.SSNFedID, Record)
                        setBlockDataIMPS(.EAInd, Record)
                        setBlockDataIMPS(.SSNFedIDName, Record)
                        setBlockDataIMPS(.SUPVR, Record)
                        setBlockDataIMPS(.WorkerNumber, Record)
                        setBlockDataIMPS(.MunicipalityCode, Record)
                        setBlockDataIMPS(.VoucherNumber, Record)
                    End With
                End If
            End While
        Catch ex As Exception
            MessageBox.Show("Location: ReadIMPSFile" & vbCrLf & ex.Message.ToString)
        Finally
            infile.Close()
        End Try
    End Sub
    Private Sub setBlockDataIMPS(ByRef BLOCK As IMPSBlock, ByVal Record As String)
        BLOCK.SetData(Record.Substring(BLOCK.StartIndex, BLOCK.Length))
    End Sub
    Private Sub SetBatchIMPS()
        Dim KeyValue As String = "Software\\Phoenix\\IMPS\\"
        Dim RegReader As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)

        'IMPSBatchNumber = IMPSBatchNumber.Substring(4, 3)
        If My.Settings.IMPSBatchNumber = "999" Then
            My.Settings.IMPSBatchNumber = "001"
        Else
            My.Settings.IMPSBatchNumber += 1
            If My.Settings.IMPSBatchNumber < 100 Then
                If My.Settings.IMPSBatchNumber < 10 Then
                    My.Settings.IMPSBatchNumber = "00" & My.Settings.IMPSBatchNumber
                Else
                    My.Settings.IMPSBatchNumber = "0" & My.Settings.IMPSBatchNumber
                End If
            End If
        End If
        RegReader.SetValue("BatchNumber", My.Settings.IMPSBatchNumber)
    End Sub

    Private Sub StoreSQLIMPS()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim reader As SqlDataReader
        Dim DateEntered As String = Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText() = "SELECT CASENUMBER FROM IMPSInformation WHERE CASENUMBER = '" + IMPSInformation.CaseNumber.GetData + "' AND DateEntered <> '" & DateEntered & "'"
            reader = SQLComm.ExecuteReader                  'IMPSINFORMATION
            reader.Read()
            If reader.HasRows = False Then
                'new case on server
                reader.Close()
                SQLComm.CommandText() = "INSERT INTO IMPSInformation (CASENUMBER, DateEntered, IssType, IndCode, PayTypeCode, WarrantNumber, IssDate, CheckAmt, LastName, FirstName, Int1, PaymentToCase, VendorName, ExtraName, Street, CityState, ZipCode, ProvCode, SSNFedID, EAInd, SSNFedIDName, Supvr, WorkerNumber, MunicipalityCode, VoucherNumber, Dropped, BatchNumber) VALUES ('" + IMPSInformation.CaseNumber.GetData + "', '" + DateEntered + "', '" + IMPSInformation.ISSType.GetData + "', '" + IMPSInformation.INDCode.GetData + "', '" + IMPSInformation.PayTypeCode.GetData + "', '" + IMPSInformation.WarrantNumber.GetData + "', '" + IMPSInformation.ISSDate.GetData + "', '" + IMPSInformation.CheckAmt.GetData + "', '" + IMPSInformation.LastName.GetData + "', '" + IMPSInformation.FirstName.GetData + "', '" + IMPSInformation.INT1.GetData + "', '" + IMPSInformation.PaymentToCase.GetData + "', '" + IMPSInformation.VendorName.GetData + "', '" + IMPSInformation.ExtraName.GetData + "', '" + IMPSInformation.Street.GetData + "', '" + IMPSInformation.CityState.GetData + "', '" + IMPSInformation.ZipCode.GetData + "', '" + IMPSInformation.ProvCode.GetData + "', '" + IMPSInformation.SSNFedID.GetData + "', '" + IMPSInformation.EAInd.GetData + "', '" + IMPSInformation.SSNFedIDName.GetData + "', '" + IMPSInformation.SUPVR.GetData + "', '" + IMPSInformation.WorkerNumber.GetData + "', '" + IMPSInformation.MunicipalityCode.GetData + "', '" + IMPSInformation.VoucherNumber.GetData + "', 'False', '" + IMPSBatchNumber + "')"
                SQLComm.ExecuteNonQuery()                  'IMPSINFORMATION                                                                                                                                                                                                                                                                                                                                                             '--TAKE THIS OUT-- .Replace("/", "")
            Else
                'case exists on server
                reader.Close()
                SQLComm.CommandText() = "UPDATE IMPSInformation SET DateEntered = '" + DateEntered + "', IssType = '" + IMPSInformation.ISSType.GetData + "', indcode = '" + IMPSInformation.INDCode.GetData + "', paytypecode = '" + IMPSInformation.PayTypeCode.GetData + "', warrantnumber = '" + IMPSInformation.WarrantNumber.GetData + "', issdate = '" + IMPSInformation.ISSDate.GetData + "', checkamt = '" + IMPSInformation.CheckAmt.GetData + "', lastname = '" + IMPSInformation.LastName.GetData + "', firstname = '" + IMPSInformation.FirstName.GetData + "',  int1 = '" + IMPSInformation.INT1.GetData + "', paymenttocase = '" + IMPSInformation.PaymentToCase.GetData + "', vendorname = '" + IMPSInformation.VendorName.GetData + "', extraname = '" + IMPSInformation.ExtraName.GetData + "', street = '" + IMPSInformation.Street.GetData + "', citystate = '" + IMPSInformation.CityState.GetData + "', zipcode = '" + IMPSInformation.ZipCode.GetData + "', provcode = '" + IMPSInformation.ProvCode.GetData + "', ssnfedid = '" + IMPSInformation.SSNFedID.GetData + "', eaind = '" + IMPSInformation.EAInd.GetData + "', ssnfedidname = '" + IMPSInformation.SSNFedIDName.GetData + "', supvr = '" + IMPSInformation.SUPVR.GetData + "', workernumber = '" + IMPSInformation.WorkerNumber.GetData + "', municipalitycode = '" + IMPSInformation.MunicipalityCode.GetData + "', vouchernumber = '" + IMPSInformation.VoucherNumber.GetData + "', Dropped = 'False', BatchNumber = '" + IMPSBatchNumber + "' WHERE CaseNumber = '" + IMPSInformation.CaseNumber.GetData + "'"
                SQLComm.ExecuteNonQuery()                  'IMPSINFORMATION        DateEntered.Replace("/", "")'--TAKE THIS OUT--
            End If
        Catch e As Exception
            isSQLError = True
            MessageBox.Show("Location: StoreSQLIMPS" & vbCrLf & e.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub dropCaseSQLIMPS(ByVal ErrorMessage1 As String, ByVal ErrorMessage2 As String, ByVal ErrorMessage3 As String, ByVal ErrorMessage4 As String, ByVal ErrorMessage5 As String)
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn) '"Data Source=" & My.Settings.ServerAddress & "\Phoenix;Initial Catalog=PhoenixCaseData;Integrated Security=True;Persist Security Info=True;User ID=IMPSUser;Password=password")
        Dim SQLComm As New SqlCommand
        Dim reader As SqlDataReader
        Dim DateEntered As String = Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year
        SQLComm.Connection = SQLConn
        If SQLConn.State <> ConnectionState.Closed Then SQLConn.Close()
        Try
            SQLConn.Open()
            SQLComm.CommandText() = "SELECT CASENUMBER FROM IMPSInformation WHERE CASENUMBER = '" + IMPSInformation.CaseNumber.GetData + "'"
            reader = SQLComm.ExecuteReader                  'IMPSINFORMATION
            reader.Read()
            If reader.HasRows = False Then
                'new case on server
                reader.Close()
                SQLComm.CommandText() = "INSERT INTO IMPSInformation (CASENUMBER, DateEntered, IssType, IndCode, PayTypeCode, WarrantNumber, IssDate, CheckAmt, LastName, FirstName, Int1, PaymentToCase, VendorName, ExtraName, Street, CityState, ZipCode, ProvCode, SSNFedID, EAInd, SSNFedIDName, Supvr, WorkerNumber, MunicipalityCode, VoucherNumber, Dropped, Reason, Reason2, Reason3, Reason4, Reason5, BatchNumber) VALUES ('" + IMPSInformation.CaseNumber.GetData + "', '" + DateEntered + "', '" + IMPSInformation.ISSType.GetData + "', '" + IMPSInformation.INDCode.GetData + "', '" + IMPSInformation.PayTypeCode.GetData + "', '" + IMPSInformation.WarrantNumber.GetData + "', '" + IMPSInformation.ISSDate.GetData + "', '" + IMPSInformation.CheckAmt.GetData + "', '" + IMPSInformation.LastName.GetData + "', '" + IMPSInformation.FirstName.GetData + "', '" + IMPSInformation.INT1.GetData + "', '" + IMPSInformation.PaymentToCase.GetData + "', '" + IMPSInformation.VendorName.GetData + "', '" + IMPSInformation.ExtraName.GetData + "', '" + IMPSInformation.Street.GetData + "', '" + IMPSInformation.CityState.GetData + "', '" + IMPSInformation.ZipCode.GetData + "', '" + IMPSInformation.ProvCode.GetData + "', '" + IMPSInformation.SSNFedID.GetData + "', '" + IMPSInformation.EAInd.GetData + "', '" + IMPSInformation.SSNFedIDName.GetData + "', '" + IMPSInformation.SUPVR.GetData + "', '" + IMPSInformation.WorkerNumber.GetData + "', '" + IMPSInformation.MunicipalityCode.GetData + "', '" + IMPSInformation.VoucherNumber.GetData + "', 'True','" + ErrorMessage1 + "', '" + ErrorMessage2 + "', '" + ErrorMessage3 + "', '" + ErrorMessage4 + "', '" + ErrorMessage5 + "', '" + IMPSBatchNumber + "')"
                SQLComm.ExecuteNonQuery()                  'IMPSINFORMATION                                                                                                                                                                                                                                                                                                                                                                         
            Else
                'case exists on server
                reader.Close()
                SQLComm.CommandText() = "UPDATE IMPSInformation SET DateEntered = '" + DateEntered + "', IssType = '" + IMPSInformation.ISSType.GetData + "', indcode = '" + IMPSInformation.INDCode.GetData + "', paytypecode = '" + IMPSInformation.PayTypeCode.GetData + "', warrantnumber = '" + IMPSInformation.WarrantNumber.GetData + "', issdate = '" + IMPSInformation.ISSDate.GetData + "', checkamt = '" + IMPSInformation.CheckAmt.GetData + "', lastname = '" + IMPSInformation.LastName.GetData + "', firstname = '" + IMPSInformation.FirstName.GetData + "',  int1 = '" + IMPSInformation.INT1.GetData + "', paymenttocase = '" + IMPSInformation.PaymentToCase.GetData + "', vendorname = '" + IMPSInformation.VendorName.GetData + "', extraname = '" + IMPSInformation.ExtraName.GetData + "', street = '" + IMPSInformation.Street.GetData + "', citystate = '" + IMPSInformation.CityState.GetData + "', zipcode = '" + IMPSInformation.ZipCode.GetData + "', provcode = '" + IMPSInformation.ProvCode.GetData + "', ssnfedid = '" + IMPSInformation.SSNFedID.GetData + "', eaind = '" + IMPSInformation.EAInd.GetData + "', ssnfedidname = '" + IMPSInformation.SSNFedIDName.GetData + "', supvr = '" + IMPSInformation.SUPVR.GetData + "', workernumber = '" + IMPSInformation.WorkerNumber.GetData + "', municipalitycode = '" + IMPSInformation.MunicipalityCode.GetData + "', vouchernumber = '" + IMPSInformation.VoucherNumber.GetData + "', Dropped = 'True', BatchNumber = '" + IMPSBatchNumber + "', Reason = '" + ErrorMessage1 + "', Reason2 = '" + ErrorMessage2 + "', Reason3 = '" + ErrorMessage3 + "', Reason4 = '" + ErrorMessage4 + "', Reason5 = '" + ErrorMessage5 + "' WHERE CaseNumber = '" + IMPSInformation.CaseNumber.GetData + "'"
                SQLComm.ExecuteNonQuery()                  'IMPSINFORMATION             
            End If
        Catch e As Exception
            isSQLError = True
            MessageBox.Show("Location: dropSQLIMPS" & vbCrLf & e.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub

    Private Sub GLinkStartIMPS()
        Dim Message As String = "          "
        Dim RetryCounter As Integer = 0
        Dim counter = 0
        Dim isError As Boolean = False
        isLogonError = False
        Dim isPasswordError As Boolean = False
        While RetryCounter < 3
            glapiIMPS = New connGLinkTP8("C:\GLPro\BullProd.cfg")
            glapiIMPS.bool_Visible = True
            glapiIMPS.Connect()
            'glapiIMPS.SendKeysTransmit("HSA")
            'While glapiIMPS.GetString(4, 7, 25, 7) <> "0100 YOU ARE CONNECTED" And counter < 30
            '    counter += 1
            '    Thread.Sleep(500)
            '    If counter = 30 Then
            '        isError = True
            '        isLogonError = False
            '    End If
            'End While
            counter = 0
            If glapiIMPS.GetString(4, 9, 28, 9) = "0200 YOU ARE DISCONNECTED" Then
                isError = True
                isLogonError = False
            End If
            If Not isError Then
                glapiIMPS.SendKeysTransmit("LOGON")
                While glapiIMPS.GetString(4, 21, 11, 21) <> "OPERATOR" And counter < 30
                    counter += 1
                    Thread.Sleep(500)
                    If counter = 30 Then
                        isError = True
                        isLogonError = False
                    End If
                End While
                counter = 0
                If Not isError Then
                    glapiIMPS.SubmitField(4, My.Settings.IMPSOperator)
                    glapiIMPS.SubmitField(6, My.Settings.IMPSPassword)
                    glapiIMPS.SubmitField(8, "UAPCCS")
                    glapiIMPS.TransmitPage()
                    Message = glapiIMPS.GetString(10, 22, 40, 22)
                End If
            End If
            If glapiIMPS.GetString(30, 4, 37, 4) = "PASSWORD" Then
                '--"Password is out of date. Please update it."
                glapiIMPS.SetVisible(True)
                isPasswordError = True
                '--Wait until user hits retry or cancel--
                If MessageBox.Show("Please update IMPS password" & vbCrLf & "then click retry?", "Phoenix", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    RetryCounter = 3
                    isError = False  '--Changed 1/2/2008 so that it will cancel and we can change the password--
                    isLogonError = True
                Else
                    isError = True
                    isLogonError = False
                End If
                glapiIMPS.SetVisible(False)
            ElseIf Message.Substring(0, 5) = "     " Then
                '--No message provided by GLink--
                RetryCounter += 1
                isError = True
                isLogonError = False
                Message = "Unknown GLink error. Please restart."
            ElseIf Message.Substring(0, 7) = "INVALID" Then
                '--Invalid password--
                RetryCounter = 3
                isInvalidPassword = True
                isLogonError = True
            ElseIf Message.Substring(0, 8) = "OPERATOR" Then
                '--Operator already logged on--
                RetryCounter = 3
                isError = True
                isLogonError = True
                '--"Operator already logged on"'--
            ElseIf Message.Substring(0, 5) <> "LOGON" Then
                '--Double check that there is a message from GLink--
                RetryCounter += 1
                isError = True
                isLogonError = True
                '--(Message)--
            Else
                RetryCounter = 3
                isError = False
                isLogonError = False
            End If
            If isPasswordError = True Then
                isPasswordError = False
            ElseIf isError = True And isLogonError = False Then
                If RetryCounter < 3 Then
                    '--Retry 3 times--
                    glapiIMPS.Disconnect()
                    KillGLink()
                Else
                    '--Too many retries exit with error--
                    glapiIMPS.Disconnect()
                    KillGLink()
                    isLogonError = True
                End If
            ElseIf isError = True And isLogonError = True Then
                RetryCounter = 3
            End If
            If isError = False Then glapiIMPS.TransmitPage()
            Thread.Sleep(500)
        End While
    End Sub
    Private Sub CreateBatchIMPS()
        Dim isDuplicate As Boolean
        '--"Creating Batch")--
        Thread.Sleep(750)
        glapiIMPS.SendKeysTransmit("BTCH")
        Thread.Sleep(500)
        Do
            glapiIMPS.SubmitField(6, IMPSBatchNumber)
            glapiIMPS.SubmitField(14, "99999999")
            glapiIMPS.SubmitField(16, "01")
            glapiIMPS.SubmitField(18, IMPSInformation.CheckAmt.GetData.Substring(0, 4))
            glapiIMPS.TransmitPage()
            If glapiIMPS.GetString(1, 2, 3, 2) = "DUP" Then
                glapiIMPS.SendCommand("DELE")
                glapiIMPS.TransmitPage()
                isDuplicate = True
            Else
                isDuplicate = False
            End If
        Loop Until isDuplicate = False
    End Sub
    Private Sub SubmitIMPS()
        With IMPSInformation
            glapiIMPS.SubmitField(6, IMPSBatchNumber)
            glapiIMPS.SubmitField(8, .CaseNumber.GetData)
            glapiIMPS.SubmitField(.ISSType.FieldNumber, .ISSType.GetData)
            glapiIMPS.SubmitField(.INDCode.FieldNumber, .INDCode.GetData)
            glapiIMPS.SubmitField(.PayTypeCode.FieldNumber, .PayTypeCode.GetData)
            glapiIMPS.SubmitField(.WarrantNumber.FieldNumber, .WarrantNumber.GetData)
            glapiIMPS.SubmitField(.ISSDate.FieldNumber, .ISSDate.GetData)
            glapiIMPS.SubmitField(.CheckAmt.FieldNumber, .CheckAmt.GetData)
            glapiIMPS.SubmitField(.CheckAmt.FieldNumber + 2, .CheckAmt.GetData.Substring(4))
            glapiIMPS.SubmitField(.LastName.FieldNumber, .LastName.GetData)
            glapiIMPS.SubmitField(.FirstName.FieldNumber, .FirstName.GetData)
            glapiIMPS.SubmitField(.INT1.FieldNumber, .INT1.GetData)
            glapiIMPS.SubmitField(.PaymentToCase.FieldNumber, .PaymentToCase.GetData)
            If .PaymentToCase.GetData <> "X" Then
                glapiIMPS.SubmitField(.VendorName.FieldNumber, .VendorName.GetData)
                glapiIMPS.SubmitField(.ExtraName.FieldNumber, .ExtraName.GetData)
                glapiIMPS.SubmitField(.Street.FieldNumber, .Street.GetData)
                glapiIMPS.SubmitField(.CityState.FieldNumber, .CityState.GetData)
                glapiIMPS.SubmitField(.ZipCode.FieldNumber, .ZipCode.GetData)
                glapiIMPS.SubmitField(.ProvCode.FieldNumber, .ProvCode.GetData)
                glapiIMPS.SubmitField(.SSNFedID.FieldNumber, .SSNFedID.GetData)
                glapiIMPS.SubmitField(.EAInd.FieldNumber, .EAInd.GetData)
                glapiIMPS.SubmitField(.SSNFedIDName.FieldNumber, .SSNFedIDName.GetData)
                glapiIMPS.SubmitField(.SUPVR.FieldNumber, .SUPVR.GetData)
                glapiIMPS.SubmitField(.WorkerNumber.FieldNumber, .WorkerNumber.GetData)
                glapiIMPS.SubmitField(.MunicipalityCode.FieldNumber, .MunicipalityCode.GetData)
                glapiIMPS.SubmitField(.VoucherNumber.FieldNumber, .VoucherNumber.GetData)
            End If
        End With
        glapiIMPS.TransmitPage()
    End Sub
    Private Sub CloseBatchIMPS()
        Dim counter As Integer = 0
        Dim isLoop As Boolean = True
        If glapiIMPS.GetString(30, 2, 51, 2) = "BATCH BALANCING SCREEN" Then
            Dim CheckBalance As String
            Dim ATPAmount As String = glapiIMPS.GetString(45, 11, 55, 11)
            Dim CheckAmount As String = glapiIMPS.GetString(45, 10, 55, 10)
            Thread.Sleep(250)
            With IMPSInformation
                Do
                    glapiIMPS.SubmitField(26, "00" & .CaseNumber.GetData.Substring(1, 6))
                    glapiIMPS.SubmitField(38, CheckAmount)
                    glapiIMPS.SubmitField(44, ATPAmount)
                    glapiIMPS.SendCommand("CHANGE")
                    glapiIMPS.TransmitPage()
                    Thread.Sleep(250)
                    CheckBalance = glapiIMPS.GetString(27, 5, 34, 5)
                    If CheckBalance = "BALANCED" Then
                        isLoop = False
                        glapiIMPS.SendCommand("ENDBATCH")
                        glapiIMPS.TransmitPage()
                        Thread.Sleep(500)
                        glapiIMPS.SendCommand("HOLD")
                        glapiIMPS.SubmitField(6, IMPSBatchNumber)
                        glapiIMPS.TransmitPage()
                        Thread.Sleep(500)
                        glapiIMPS.SendCommand("RELE")
                        glapiIMPS.SubmitField(6, IMPSBatchNumber)
                        glapiIMPS.TransmitPage()
                    Else
                        isLoop = True
                        counter += 1
                        If counter > 3 Then
                            glapiIMPS.SendCommand("OVER")
                            glapiIMPS.TransmitPage()
                            Thread.Sleep(500)
                            glapiIMPS.SendCommand("HOLD")
                            glapiIMPS.SubmitField(6, IMPSBatchNumber)
                            glapiIMPS.TransmitPage()
                            Thread.Sleep(500)
                            glapiIMPS.SendCommand("RELE")
                            glapiIMPS.SubmitField(6, IMPSBatchNumber)
                            glapiIMPS.TransmitPage()
                        End If
                    End If
                Loop Until Not isLoop
            End With
        End If
    End Sub
    Private Sub DeleteBatchIMPS()
        GLinkStartIMPS()
        glapiIMPS.SendKeysTransmit("BTCH,DELE," & IMPSBatchNumber)
        glapiIMPS.Disconnect()
    End Sub
    Private Sub DropCaseIMPS(ByVal ErrorMessage1 As String, ByVal ErrorMessage2 As String, ByVal ErrorMessage3 As String, ByVal ErrorMessage4 As String, ByVal ErrorMessage5 As String)
        Dim TEMPError As String
        glapiIMPS.Disconnect()
        If ErrorMessage1 = "                                        " Then
            If ErrorMessage2 = "                                        " Then
                If ErrorMessage3 = "                                        " Then
                    If ErrorMessage4 = "                                        " Then
                        If ErrorMessage5 = "                                        " Then
                            TEMPError = "Unknown Error!"
                        Else
                            TEMPError = ErrorMessage5
                        End If
                    Else
                        TEMPError = ErrorMessage4
                    End If
                Else
                    TEMPError = ErrorMessage3
                End If
            Else
                TEMPError = ErrorMessage2
            End If
        Else
            'TEMPError = ErrorMessage1
        End If
        dropCaseSQLIMPS(ErrorMessage1, ErrorMessage2, ErrorMessage3, ErrorMessage4, ErrorMessage5)
    End Sub
End Module
