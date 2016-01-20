'--Designed by: Michael Levine 9/2007--
Public Class ControlScreen

#Region "Declarations"
    Public MediCaseProcess, MediCaseSuccess, MediCaseDrop, MediCaseHold As Integer
    Public IMPSCaseProcess, IMPSCaseDrop As Integer
    Public SelectedApp As String                                    '--Holds the application that is selected in the menu--
    Public isClientRunning As Boolean                               '--Tracks if client data look up is running--

    Private isChangeMade As Boolean                                 '--Tracks whether a change was made in the options menu--
    Private isServerConnected As Boolean                            '--Tracks if the server is found and connected--
    Private isCheckServer As Boolean                                '--Tell whether we are in the Options menu and should not check the server connection--    
    Private isMedicaidError, isIMPSError As Boolean                     '--Booleans to track if an error occurred in the thread--
    Private ErrorString As String                                   '--Error message--
    Private isForceGump As Boolean                                  '--Manual run of GUMP update--
    Private isStarting As Boolean                                   '--Determine if any app is starting up--
    Private ClientCaseNum As Integer                                '--Number of client cases processed--
    Private wasMedicaidRunning, wasIMPSRunning As Boolean

    Private IMPSNode, MedicaidNode, FAMISNode, GUMPNode, ClientNode As TreeNode           '--IMPS, Medicaid, FAMIS tree nodes--
    Private Const RunIcon As Integer = 1                            '--Run icon value--
    Private Const StopIcon As Integer = 2                           '--Stop icon value--
    Private Const StoppingIcon As Integer = 0                       '--Stopping Icon value--
#End Region

    Private Sub ControlScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password"
        My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Failover Partner=Phoenix_Mirror\PhoenixMirror;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password"
        lbl_Server.Text = "--Connecting...---"
        lbl_Server.BackColor = Color.CadetBlue
        isCheckServer = True
        isPause = False
        wasMedicaidRunning = False
        wasIMPSRunning = False
        lbl_VersionNumber.Text = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Revision.ToString
        If Not BGW_CheckServer.IsBusy Then BGW_CheckServer.RunWorkerAsync()
        'BGW_Update.RunWorkerAsync()
        IMPSNode = treeMenu.Nodes(0).Nodes(0)
        MedicaidNode = treeMenu.Nodes(0).Nodes(1)
        FAMISNode = treeMenu.Nodes(0).Nodes(3)
        GUMPNode = treeMenu.Nodes(0).Nodes(2)
        ClientNode = treeMenu.Nodes(0).Nodes(4)

        InitializePanels()
        InitializeSettings()
        ChangeNodeIcon(IMPSNode, StopIcon)
        ChangeNodeIcon(MedicaidNode, StopIcon)
        ChangeNodeIcon(GUMPNode, StopIcon)

        SelectedApp = "IMPS"
        tool_Run_Click(Nothing, Nothing)
        SelectedApp = "Medicaid"
        tool_Run_Click(Nothing, Nothing)
        SelectedApp = "GUMP"
        tool_Run_Click(Nothing, Nothing)
        treeMenu.Nodes(0).ExpandAll()
    End Sub

#Region "Case Totals"
    Private Sub IncrementTotals(ByVal App As String, ByVal Result As String)
        Select Case App
            Case "IMPS"
                My.Settings.IMPTotal += 1
                txt_IMPSTotal.Text = My.Settings.IMPTotal
                If Result = "SUCCESS" Then
                    My.Settings.IMPSuccess += 1
                    txt_IMPSSuccess.Text = My.Settings.IMPSuccess
                ElseIf Result = "DROP" Then
                    My.Settings.IMPDrop += 1
                    txt_IMPSFailed.Text = My.Settings.IMPDrop
                End If
            Case "Medicaid"
                My.Settings.MediTotal += 1
                txt_MedicaidTotal.Text = My.Settings.MediTotal
                If Result = "SUCCESS" Then
                    My.Settings.MediSuccess += 1
                    txt_MedicaidSuccess.Text = My.Settings.MediSuccess
                ElseIf Result = "DROP" Then
                    My.Settings.MediDrop += 1
                    txt_MedicaidFailed.Text = My.Settings.MediDrop
                ElseIf Result = "HOLD" Then
                    My.Settings.MediHold += 1
                    txt_MedicaidHold.Text = My.Settings.MediHold
                End If
        End Select
    End Sub
    Private Sub ResetTotals()
        My.Settings.IMPTotal = 0
        My.Settings.IMPSuccess = 0
        My.Settings.IMPDrop = 0
        My.Settings.MediTotal = 0
        My.Settings.MediSuccess = 0
        My.Settings.MediDrop = 0
        My.Settings.MediHold = 0
        txt_IMPSTotal.Text = My.Settings.IMPTotal
        txt_IMPSSuccess.Text = My.Settings.IMPSuccess
        txt_IMPSFailed.Text = My.Settings.IMPDrop
        txt_MedicaidTotal.Text = My.Settings.MediTotal
        txt_MedicaidSuccess.Text = My.Settings.MediSuccess
        txt_MedicaidFailed.Text = My.Settings.MediDrop
        txt_MedicaidHold.Text = My.Settings.MediHold
        ResetCaseTotal()
    End Sub
    Private Sub CheckTotalDate()
        If My.Settings.TotalDate <> Date.Today Then
            ResetTotals()
            My.Settings.TotalDate = Date.Today
        End If
    End Sub
#End Region

#Region "Server Checking Functions"
    Private Function isServerError()
        Dim CheckConn As New SqlConnection(My.Settings.phxSQLConn)
        Try
            If My.Computer.Network.Ping(My.Settings.ServerAddress, 1500) = True Then
                CheckConn.Open()
                CheckConn.Close()
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function
    Private Sub BGW_CheckServer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_CheckServer.DoWork
        Dim CheckConn As New SqlConnection(My.Settings.phxSQLConn)
        While Not BGW_CheckServer.CancellationPending
            If isCheckServer Then
                If isServerError() Then
                    BGW_CheckServer.ReportProgress(1)
                Else
                    BGW_CheckServer.ReportProgress(0)
                End If
            End If
            Thread.Sleep(2500)
        End While
    End Sub
    Private Sub BGW_CheckServer_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_CheckServer.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0
                lbl_Server.Text = "--Server Connected--"
                lbl_Server.BackColor = Color.Green
                isServerConnected = True
            Case 1
                lbl_Server.Text = "--Server Not Responding--"
                lbl_Server.BackColor = Color.Red
                isServerConnected = False
                If BGW_IMPSScanDirectory.IsBusy Then
                    SelectedApp = "IMPS"
                    isIMPSError = False
                    tool_Stop_Click(Nothing, Nothing)
                    SetInfo("Server not responding.", Nothing, True)
                End If
                If BGW_MediScanDirectory.IsBusy Then
                    SelectedApp = "Medicaid"
                    isMedicaidError = False
                    tool_Stop_Click(Nothing, Nothing)
                    SetInfo("Server not responding.", Nothing, True)
                End If
                ResetPanels()
                panel_Main.Visible = True
                treeMenu.SelectedNode = treeMenu.Nodes(0)
                treeMenu.Enabled = False
                BGW_CheckServer.CancelAsync()
                If Not BGW_RetryServer.IsBusy Then
                    BGW_RetryServer.RunWorkerAsync()
                Else
                    MessageBox.Show("Trouble! BGW_RetryServer" & vbCrLf & "The thread was still running.")
                End If
        End Select
    End Sub
    Private Sub BGW_RetryServer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_RetryServer.DoWork
        Dim CheckConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim isRetry As Boolean = True
        Dim x As Integer = 0
        While isRetry
            If Not BGW_CheckServer.IsBusy Then
                BGW_RetryServer.ReportProgress(x)
                If Not isServerError() Then
                    BGW_RetryServer.ReportProgress(20)
                    isRetry = False
                End If
                If x + 1 > 5 Then x = 0 Else x += 1
            End If
            Thread.Sleep(2500)
        End While
    End Sub
    Private Sub BGW_RetryServer_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_RetryServer.RunWorkerCompleted
        If Not BGW_CheckServer.IsBusy Then
            BGW_CheckServer.RunWorkerAsync()
        Else
            MessageBox.Show("Trouble! BGW_CheckServer_Completed" & vbCrLf & "The thread was still running.")
        End If
    End Sub
    Private Sub BGW_RetryServer_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_RetryServer.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0 : lbl_Server.Text = "Server Not Found. Retrying."
            Case 1 : lbl_Server.Text = "Server Not Found. Retrying.."
            Case 2 : lbl_Server.Text = "Server Not Found. Retrying..."
            Case 3 : lbl_Server.Text = "Server Not Found. Retrying...."
            Case 4 : lbl_Server.Text = "Server Not Found. Retrying....."
            Case 20
                lbl_Server.Text = "--Server Connected--"
                lbl_Server.BackColor = Color.Green
                SqlClient.SqlConnection.ClearAllPools()
                treeMenu.Enabled = True
                If Not BGW_IMPSScanDirectory.IsBusy Then SelectedApp = "IMPS" : tool_Run_Click(Nothing, Nothing)
                If Not BGW_MediScanDirectory.IsBusy Then SelectedApp = "Medicaid" : tool_Run_Click(Nothing, Nothing)
        End Select
    End Sub
#End Region

#Region "Initialize Functions"
    Private Sub InitializeSettings()
        Dim keyvalue As String = "Software\\Phoenix\\IMPS\\"
        Dim RegReader As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(keyvalue, True)
        If Not RegReader Is Nothing Then
            My.Settings.IMPSDirectory = RegReader.GetValue("Directory")
            My.Settings.IMPSOperator = RegReader.GetValue("Operator")
            My.Settings.IMPSPassword = RegReader.GetValue("Password")
            My.Settings.IMPSBatchPrefix = RegReader.GetValue("BatchPrefix")
            My.Settings.IMPSBatchNumber = RegReader.GetValue("BatchNumber")
            My.Settings.ServerAddress = RegReader.GetValue("ServerAddress")
        End If
        If isErrorSetPath("IMPS") Then
            '-- ReEnter Path Dialog--
            treeMenu.SelectedNode = IMPSNode.Nodes(4)
            txt_IMPSDirectory.Select()
            MessageBox.Show("IMPS Directory Does Not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        keyvalue = "Software\\Phoenix\\Medicaid\\"
        RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(keyvalue, True)
        If Not RegReader Is Nothing Then
            My.Settings.MediDirectory = RegReader.GetValue("Directory")
            My.Settings.MediDropDirectory = RegReader.GetValue("DropDirectory")
            My.Settings.MediOperator = RegReader.GetValue("Operator")
            My.Settings.MediPassword = RegReader.GetValue("Password")
        End If
        If isErrorSetPath("Medicaid") Then
            '-- ReEnter Path Dialog--
            treeMenu.SelectedNode = MedicaidNode.Nodes(4)
            txt_IMPSDirectory.Select()
            MessageBox.Show("Medicaid Directory Does Not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        keyvalue = "Software\\Phoenix\\GUMP\\"
        RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(keyvalue, True)
        If Not RegReader Is Nothing Then
            My.Settings.GUMPFileDirectory = RegReader.GetValue("GUMPDirectory")
        End If
        If isErrorSetPath("GUMP") Then
            '-- ReEnter Path Dialog--
            treeMenu.SelectedNode = GUMPNode.Nodes(0)
            txt_GUMPFileLocation.Select()
            MessageBox.Show("GUMP File Location Does Not Exist.", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation)
        End If
        RegReader.Close()

        'My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password"
        My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password"
        My.Settings.TotalDate = Date.Today
        DateChoice.Value = Date.Today
        If My.Settings.IMPTotal = Nothing Then
            My.Settings.IMPTotal = 0
            My.Settings.IMPSuccess = 0
            My.Settings.IMPDrop = 0
            My.Settings.MediTotal = 0
            My.Settings.MediSuccess = 0
            My.Settings.MediDrop = 0
            My.Settings.MediHold = 0
        End If
        txt_IMPSTotal.Text = My.Settings.IMPTotal
        txt_IMPSSuccess.Text = My.Settings.IMPSuccess
        txt_IMPSFailed.Text = My.Settings.IMPDrop
        txt_MedicaidTotal.Text = My.Settings.MediTotal
        txt_MedicaidSuccess.Text = My.Settings.MediSuccess
        txt_MedicaidFailed.Text = My.Settings.MediDrop
        txt_MedicaidHold.Text = My.Settings.MediHold
        txt_GUMPFileLocation.Text = My.Settings.GUMPFileDirectory
        AddEvents(panel_IMPSOptions)
        AddEvents(panel_MedicaidOptions)
        AddEvents(panel_GUMPUpdate)
    End Sub
    Private Sub InitializePanels()
        txt_IMPSInfo.Dock = DockStyle.Fill
        txt_IMPSLog.Dock = DockStyle.Fill
        txt_MedicaidInfo.Dock = DockStyle.Fill
        txt_MedicaidLog.Dock = DockStyle.Fill
        txt_ClientInfo.Dock = DockStyle.Fill

        grid_CaseView.Dock = DockStyle.Fill
        panel_IMPSOptions.Dock = DockStyle.Fill
        panel_MedicaidOptions.Dock = DockStyle.Fill
        panel_Main.Dock = DockStyle.Fill
        panel_Reports.Dock = DockStyle.Fill
        grid_Users.Dock = DockStyle.Fill
        panel_GUMPUpdate.Dock = DockStyle.Fill

        ResetPanels()
    End Sub
    Private Sub ResetPanels()
        txt_IMPSInfo.Visible = False
        txt_IMPSLog.Visible = False
        txt_MedicaidInfo.Visible = False
        txt_MedicaidLog.Visible = False
        txt_ClientInfo.Visible = False
        grid_CaseView.Visible = False
        grid_Users.Visible = False

        tool_Run.Enabled = False
        tool_Stop.Enabled = False
        tool_Print.Enabled = False
        tool_Submit.Enabled = False
        cmb_LogFiles.Enabled = False
        DateChoice.Enabled = False

        btn_All.Visible = False
        btn_Success.Visible = False
        btn_Drop.Visible = False
        btn_Redet.Visible = False

        panel_IMPSOptions.Visible = False
        panel_MedicaidOptions.Visible = False
        panel_Main.Visible = False
        panel_Reports.Visible = False
        panel_GUMPUpdate.Visible = False

        lbl_OptionError.Visible = False

        isCheckServer = True
    End Sub
    Private Function isErrorSetPath(ByVal App As String) As Boolean
        Dim xDirectory As DirectoryInfo
        If App = "IMPS" Then
            xDirectory = New DirectoryInfo(My.Settings.IMPSDirectory)
            Return Not xDirectory.Exists
        ElseIf App = "Medicaid" Then
            xDirectory = New DirectoryInfo(My.Settings.MediDirectory)
            Return Not xDirectory.Exists
        ElseIf App = "GUMP" Then
            xDirectory = New DirectoryInfo(My.Settings.GUMPFileDirectory)
            Return Not xDirectory.Exists
        Else
            MessageBox.Show("Location: isErrorSetPath" & vbCrLf & "Can't set Directory")
            Return False
        End If
    End Function
#End Region

#Region "Event Handling Functions"
    Private Sub AddEvents(ByVal ctrlparent As Control)
        '--Adds events to pad a textbox with spaces when user-- 
        '--exits, provides a tooltip with block information, and tracks--
        '--which blocks the user has changed the data--
        Dim ctrl As Control
        For Each ctrl In ctrlparent.Controls
            If TypeOf ctrl Is TextBox Then
                AddHandler ctrl.TextChanged, AddressOf InfoChanged
            End If
            If ctrl.HasChildren Then
                AddEvents(ctrl)
            End If
        Next
    End Sub
    Private Sub InfoChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Not BGW_BlinkSubmit.IsBusy Then BGW_BlinkSubmit.RunWorkerAsync()
        isChangeMade = True
        isCheckServer = False
    End Sub
    Private Sub BGW_BlinkSubmit_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_BlinkSubmit.DoWork
        While Not BGW_BlinkSubmit.CancellationPending
            BGW_BlinkSubmit.ReportProgress(1)
            Thread.Sleep(500)
            BGW_BlinkSubmit.ReportProgress(0)
            Thread.Sleep(500)
        End While
        BGW_BlinkSubmit.ReportProgress(0)
    End Sub
    Private Sub BGW_BlinkSumbit_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_BlinkSubmit.ProgressChanged
        If e.ProgressPercentage = 1 Then tool_Submit.BackColor = Color.Orange Else tool_Submit.BackColor = Nothing
    End Sub
    Private Sub FillCaseView()
        Dim i As Integer
        For i = 0 To grid_CaseView.Columns.Count - 1
            grid_CaseView.Columns.RemoveAt(0)
        Next
        Select Case SelectedApp
            Case "IMPS"
                grid_CaseView.Columns.Add("CaseNumber", "Case Number")
                grid_CaseView.Columns.Item(0).DataPropertyName = "CaseNumber"
                grid_CaseView.Columns.Add("BatchNumber", "Batch Number")
                grid_CaseView.Columns.Item(1).DataPropertyName = "BatchNumber"
                grid_CaseView.Columns.Add("Dropped", "Case Dropped")
                grid_CaseView.Columns.Item(2).DataPropertyName = "Dropped"
                grid_CaseView.Columns.Add("Reason", "Reason Dropped")
                grid_CaseView.Columns.Item(3).DataPropertyName = "Reason"
                grid_CaseView.DataSource = IMPSInformationBindingSource
                IMPSInformationTableAdapter.FillBy(PhoenixCaseDataDataSet.IMPSInformation, DateChoice.Value.Month & "/" & DateChoice.Value.Day & "/" & DateChoice.Value.Year)
            Case "Medicaid"
                grid_CaseView.Columns.Add("CaseNumber", "Case Number")
                grid_CaseView.Columns.Item(0).DataPropertyName = "CaseNumber"
                grid_CaseView.Columns.Add("PersonNumber", "Person Number")
                grid_CaseView.Columns.Item(1).DataPropertyName = "PersonNumber"
                grid_CaseView.Columns.Add("TextFile", "Text File")
                grid_CaseView.Columns.Item(2).DataPropertyName = "TextFile"
                grid_CaseView.Columns.Add("Operator", "Operator")
                grid_CaseView.Columns.Item(3).DataPropertyName = "Operator"
                grid_CaseView.Columns.Add("Ops", "OPT Screen")
                grid_CaseView.Columns.Item(4).DataPropertyName = "Ops"
                grid_CaseView.Columns.Add("Result", "Result")
                grid_CaseView.Columns.Item(5).DataPropertyName = "Result"
                grid_CaseView.Columns.Add("Reason", "Reason Dropped")
                grid_CaseView.Columns.Item(6).DataPropertyName = "Reason"
                grid_CaseView.DataSource = TransactionLogBindingSource
                TransactionLogTableAdapter.FillBy(PhoenixCaseDataDataSet.TransactionLog, DateChoice.Value.Month & "/" & DateChoice.Value.Day & "/" & DateChoice.Value.Year)
            Case "FAMIS"
                grid_CaseView.Columns.Add("CaseNumber", "Case Number")
                grid_CaseView.Columns.Item(0).DataPropertyName = "CaseNumber"
                grid_CaseView.Columns.Add("Operator", "Operator")
                grid_CaseView.Columns.Item(1).DataPropertyName = "Operator"
                grid_CaseView.Columns.Add("BatchNumber", "Batch Number")
                grid_CaseView.Columns.Item(2).DataPropertyName = "BatchNumber"
                grid_CaseView.DataSource = FAMISCaseInformationBindingSource
                FAMISCaseInformationTableAdapter.FillBy(PhoenixCaseDataDataSet.FAMISCaseInformation, DateChoice.Value.Month & "/" & DateChoice.Value.Day & "/" & DateChoice.Value.Year)
        End Select
    End Sub
    Private Sub DateChoice_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateChoice.ValueChanged
        FillCaseView()
    End Sub
    Private Sub treeMenu_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeMenu.AfterSelect
        '--Make sure we're not leaving the Options screen without saving changes--
        If isChangeMade Then
            If MessageBox.Show("Save Changes?", "Phoenix", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                tool_Submit_Click(Nothing, Nothing)
            Else
                If SelectedApp = "IMPS" Then
                    Dim RegReader As Microsoft.Win32.RegistryKey
                    Dim KeyValue As String = "Software\\Phoenix\\IMPS\\"
                    RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
                    If Not RegReader Is Nothing Then
                        My.Settings.IMPSDirectory = RegReader.GetValue("Directory")
                        My.Settings.IMPSOperator = RegReader.GetValue("Operator")
                        My.Settings.IMPSPassword = RegReader.GetValue("Password")
                        My.Settings.IMPSBatchPrefix = RegReader.GetValue("BatchPrefix")
                        My.Settings.IMPSBatchNumber = RegReader.GetValue("BatchNumber")
                        My.Settings.ServerAddress = RegReader.GetValue("ServerAddress")
                    End If
                    RegReader.Close()
                ElseIf SelectedApp = "Medicaid" Then
                    Dim RegReader As Microsoft.Win32.RegistryKey
                    Dim KeyValue As String = "Software\\Phoenix\\Medicaid\\"
                    RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
                    If Not RegReader Is Nothing Then
                        My.Settings.IMPSDirectory = RegReader.GetValue("Directory")
                        My.Settings.MediDropDirectory = RegReader.GetValue("DropDirectory")
                        My.Settings.IMPSOperator = RegReader.GetValue("Operator")
                        My.Settings.IMPSPassword = RegReader.GetValue("Password")
                        My.Settings.ServerAddress = RegReader.GetValue("ServerAddress")
                    End If
                    RegReader.Close()
                ElseIf SelectedApp = "GUMP" Then
                    Dim RegReader As Microsoft.Win32.RegistryKey
                    Dim KeyValue As String = "Software\\Phoenix\\GUMP\\"
                    RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
                    If Not RegReader Is Nothing Then
                        My.Settings.GUMPFileDirectory = RegReader.GetValue("GUMPDirectory")
                    End If
                End If
            End If
            If BGW_BlinkSubmit.IsBusy Then BGW_BlinkSubmit.CancelAsync()
            isChangeMade = False
        End If
        '--Reset the panels and enabled only those needed--
        ResetPanels()
        If isServerConnected Then
            '--Make sure the server is connected before managing the tree menu--
            Select Case e.Node.Name
                Case "PhoenixRoot"
                    panel_Main.Visible = True
                Case "IMPSRoot"
                    txt_IMPSInfo.Visible = True
                Case "IMPSApplication"
                    txt_IMPSInfo.Visible = True
                    If BGW_IMPSScanDirectory.IsBusy Then tool_Stop.Enabled = True Else tool_Run.Enabled = True
                    SelectedApp = "IMPS"
                Case "IMPSLog"
                    txt_IMPSLog.Visible = True
                    cmb_LogFiles.Enabled = True
                    tool_Print.Enabled = True
                    SelectedApp = "IMPS"
                    SetLogFile()
                    cmb_LogFiles.SelectedIndex() = 0
                Case "IMPSCases"
                    grid_CaseView.Visible = True
                    DateChoice.Enabled = True
                    SelectedApp = "IMPS"
                    FillCaseView()
                Case "IMPSReports"
                    SelectedApp = "IMPS"
                    panel_Reports.Visible = True
                    btn_All.Visible = True
                    DateChoice.Enabled = True
                Case "IMPSOptions"
                    panel_IMPSOptions.Visible = True
                    If panel_IMPSOptions.Enabled Then tool_Submit.Enabled = True Else tool_Submit.Enabled = False
                    SelectedApp = "IMPS"
                    If panel_IMPSOptions.Enabled Then lbl_OptionError.Visible = False Else lbl_OptionError.Visible = True
                Case "MedicaidRoot"
                    txt_MedicaidInfo.Visible = True
                Case "MedicaidApplication"
                    txt_MedicaidInfo.Visible = True
                    If BGW_MediScanDirectory.IsBusy Then tool_Stop.Enabled = True Else tool_Run.Enabled = True
                    SelectedApp = "Medicaid"
                Case "MedicaidLog"
                    txt_MedicaidLog.Visible = True
                    cmb_LogFiles.Enabled = True
                    tool_Print.Enabled = True
                    SelectedApp = "Medicaid"
                    SetLogFile()
                    cmb_LogFiles.SelectedIndex() = 0
                Case "MedicaidCases"
                    grid_CaseView.Visible = True
                    DateChoice.Enabled = True
                    SelectedApp = "Medicaid"
                    FillCaseView()
                Case "MedicaidReports"
                    SelectedApp = "Medicaid"
                    panel_Reports.Visible = True
                    btn_All.Visible = True
                    btn_Success.Visible = True
                    btn_Drop.Visible = True
                    btn_Redet.Visible = True
                    DateChoice.Enabled = True
                Case "MedicaidOptions"
                    If panel_MedicaidOptions.Enabled Then tool_Submit.Enabled = True Else tool_Submit.Enabled = False
                    panel_MedicaidOptions.Visible = True
                    SelectedApp = "Medicaid"
                    If panel_MedicaidOptions.Enabled Then lbl_OptionError.Visible = False Else lbl_OptionError.Visible = True
                Case "FAMISRoot"
                    panel_Main.Visible = True
                Case "FAMISCases"
                    grid_CaseView.Visible = True
                    DateChoice.Enabled = True
                    SelectedApp = "FAMIS"
                    FillCaseView()
                Case "FAMISUsers"
                    SelectedApp = "FAMIS"
                    grid_Users.Visible = True
                    ParentControlScreen = Me
                    FillUserTable()
                Case "FAMISReports"
                    SelectedApp = "FAMIS"
                    btn_All.Visible = True
                    panel_Reports.Visible = True
                    DateChoice.Enabled = True
                Case "GUMPRoot"
                    panel_Main.Visible = True
                Case "GUMPSettings"
                    SelectedApp = "GUMP"
                    panel_GUMPUpdate.Visible = True
                    If BGW_GUMPUpdate.IsBusy Then tool_Stop.Enabled = True Else tool_Run.Enabled = True
                    tool_Submit.Enabled = True
                Case "ClientRoot"
                    SelectedApp = "Client"
                    txt_ClientInfo.Visible = True
            End Select
        Else
            If e.Node.Name = "IMPSOptions" Then
                panel_IMPSOptions.Visible = True
                If panel_IMPSOptions.Enabled Then tool_Submit.Enabled = True Else tool_Submit.Enabled = False
                SelectedApp = "IMPS"
                If panel_IMPSOptions.Enabled Then lbl_OptionError.Visible = False Else lbl_OptionError.Visible = True
            ElseIf e.Node.Name = "MedicaidOptions" Then
                If panel_MedicaidOptions.Enabled Then tool_Submit.Enabled = True Else tool_Submit.Enabled = False
                panel_MedicaidOptions.Visible = True
                SelectedApp = "Medicaid"
                If panel_MedicaidOptions.Enabled Then lbl_OptionError.Visible = False Else lbl_OptionError.Visible = True
            Else
                panel_Main.Visible = True
            End If
        End If
    End Sub
    Private Sub ChangeNodeIcon(ByRef xNode As TreeNode, ByVal Index As Integer)
        xNode.ImageIndex = Index
        xNode.SelectedImageIndex = Index
    End Sub
#End Region

#Region "Menu Functions"
    Private Sub tool_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_Stop.Click
        Select Case SelectedApp
            Case "IMPS"
                ChangeNodeIcon(IMPSNode, StoppingIcon)
                BGW_IMPSScanDirectory.CancelAsync()
                IMPSNode.Text &= " (Stopping...)"
            Case "Medicaid"
                ChangeNodeIcon(MedicaidNode, StoppingIcon)
                BGW_MediScanDirectory.CancelAsync()
                MedicaidNode.Text &= " (Stopping...)"
            Case "FAMIS"

            Case "GUMP"
                ChangeNodeIcon(GUMPNode, StopIcon)
                BGW_GUMPUpdate.CancelAsync()
            Case Else
                MessageBox.Show("Don't Touch Me There!", "Phoenix", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Select
        tool_Stop.Enabled = False
        treeMenu.Enabled = False
    End Sub
    Private Sub tool_Run_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_Run.Click
        isStarting = True
        Select Case SelectedApp
            Case "IMPS"
                ChangeNodeIcon(IMPSNode, RunIcon)
                SetInfo("IMPS Process Started.", "IMPS", False)
                If Not BGW_IMPSScanDirectory.IsBusy Then
                    BGW_IMPSScanDirectory.RunWorkerAsync()
                Else
                    MessageBox.Show("Trouble! BGW_IMPSScane" & vbCrLf & "The thread was still running.")
                End If
                panel_IMPSOptions.Enabled = False
                isIMPSError = False
            Case "Medicaid"
                ChangeNodeIcon(MedicaidNode, RunIcon)
                SetInfo("Medicaid Process Started.", "Medicaid", False)
                If Not BGW_MediScanDirectory.IsBusy Then
                    BGW_MediScanDirectory.RunWorkerAsync()
                Else
                    MessageBox.Show("Trouble! BGW_MediScan" & vbCrLf & "The thread was still running.")
                End If
                panel_MedicaidOptions.Enabled = False
                isMedicaidError = False
            Case "FAMIS"

            Case "GUMP"
                ChangeNodeIcon(GUMPNode, RunIcon)
                If Not BGW_GUMPUpdate.IsBusy Then
                    BGW_GUMPUpdate.RunWorkerAsync()
                Else
                    MessageBox.Show("BGW_GUMP - The thread was still running.")
                End If
            Case Else
                MessageBox.Show("Don't Touch Me There!", "Phoenix", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Select
        If txt_IMPSInfo.Visible = True Or txt_MedicaidInfo.Visible = True Or panel_GUMPUpdate.Visible = True Then
            tool_Stop.Enabled = True
            tool_Run.Enabled = False
        End If
        isStarting = False
    End Sub
    Private Sub tool_Submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_Submit.Click
        Dim tempDirectory As String = My.Settings.IMPSDirectory
        Dim RegReader As Microsoft.Win32.RegistryKey
        Dim KeyValue As String = "Software\\Phoenix\\IMPS\\"
        Dim Directory As DirectoryInfo

        My.Settings.IMPSDirectory = txt_IMPSDirectory.Text
        My.Settings.IMPSOperator = txt_IMPSOperator.Text
        My.Settings.IMPSPassword = txt_IMPSPassword.Text
        My.Settings.IMPSBatchPrefix = txt_IMPSBatchPrefix.Text
        My.Settings.IMPSBatchNumber = txt_IMPSBatchNumber.Text
        My.Settings.ServerAddress = txt_IMPSServer.Text
        My.Settings.MediDirectory = txt_MediDirectory.Text
        My.Settings.MediDropDirectory = txt_MediDrop.Text
        My.Settings.MediOperator = txt_MediOperator.Text
        My.Settings.MediPassword = txt_MediPassword.Text

        RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
        If Not RegReader Is Nothing Then
            If isErrorSetPath("IMPS") Then
                MessageBox.Show("Directory Does Not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                My.Settings.IMPSDirectory = RegReader.GetValue("Directory")
                txt_IMPSDirectory.Text = My.Settings.IMPSDirectory
            End If
            RegReader.SetValue("Directory", My.Settings.IMPSDirectory)
            RegReader.SetValue("Operator", My.Settings.IMPSOperator)
            RegReader.SetValue("Password", My.Settings.IMPSPassword)
            RegReader.SetValue("BatchNumber", My.Settings.IMPSBatchNumber)
            RegReader.SetValue("BatchPrefix", My.Settings.IMPSBatchPrefix)
            RegReader.SetValue("ServerAddress", My.Settings.ServerAddress)
        End If
        KeyValue = "Software\\Phoenix\\Medicaid\\"
        RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
        If Not RegReader Is Nothing Then
            If isErrorSetPath("Medicaid") Then
                MessageBox.Show("Directory Does Not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                My.Settings.MediDirectory = RegReader.GetValue("Directory")
                txt_IMPSDirectory.Text = My.Settings.IMPSDirectory
            End If
            RegReader.SetValue("Directory", My.Settings.MediDirectory)
            Directory = New DirectoryInfo(My.Settings.MediDropDirectory)
            If Not Directory.Exists Then
                My.Settings.MediDropDirectory = RegReader.GetValue("DropDirectory")
                txt_MediDrop.Text = My.Settings.MediDropDirectory
            End If
            RegReader.SetValue("DropDirectory", My.Settings.MediDropDirectory)
            RegReader.SetValue("Operator", My.Settings.MediOperator)
            RegReader.SetValue("Password", My.Settings.MediPassword)
            RegReader.SetValue("ServerAddress", My.Settings.ServerAddress)
        End If
        KeyValue = "Software\\Phoenix\\GUMP\\"
        RegReader = My.Computer.Registry.LocalMachine.OpenSubKey(KeyValue, True)
        If Not RegReader Is Nothing Then
            If isErrorSetPath("GUMP") Then
                MessageBox.Show("Directory Does Not Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                My.Settings.GUMPFileDirectory = RegReader.GetValue("GUMPDirectory")
                txt_GUMPFileLocation.Text = My.Settings.GUMPFileDirectory
            End If
            RegReader.SetValue("GUMPDirectory", My.Settings.GUMPFileDirectory)
        End If
        RegReader.Close()
        tool_Submit.BackColor = Nothing
        isChangeMade = False
        If BGW_BlinkSubmit.IsBusy Then BGW_BlinkSubmit.CancelAsync()
        'My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password"
        My.Settings.phxSQLConn = "Data Source=" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password"
        isCheckServer = True
    End Sub
    'Private Sub tool_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tool_Print.Click
    '    Dim oWord As New Word.Application
    '    Dim isLoop As Boolean = True
    '    Select Case SelectedApp
    '        Case "IMPS"
    '            If txt_IMPSLog.Visible Then
    '                oWord.Documents.Add(My.Application.Info.DirectoryPath & "\IMPS Logs\" & cmb_LogFiles.SelectedItem & ".doc")
    '                oWord.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
    '                oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader
    '                oWord.Selection.TypeText(cmb_LogFiles.SelectedItem.ToString)
    '                oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter
    '                oWord.Selection.TypeText("Phoenix - IMPS Log File                                                                                           Page: ")
    '                oWord.Selection.Fields.Add(oWord.Selection.Range, Word.WdFieldType.wdFieldPage)
    '                oWord.PrintOut(False)
    '                oWord.Quit(0)
    '                oWord = Nothing
    '            End If
    '        Case "Medicaid"
    '            If txt_MedicaidLog.Visible Then
    '                oWord.Documents.Add(My.Application.Info.DirectoryPath & "\Medicaid Logs\" & cmb_LogFiles.SelectedItem & ".doc")
    '                oWord.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
    '                oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader
    '                oWord.Selection.TypeText(cmb_LogFiles.SelectedItem.ToString)
    '                oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter
    '                oWord.Selection.TypeText("Phoenix - Medicaid Log File                                                                                       Page: ")
    '                oWord.Selection.Fields.Add(oWord.Selection.Range, Word.WdFieldType.wdFieldPage)
    '                oWord.PrintOut(False)
    '                oWord.Quit(0)
    '                oWord = Nothing
    '            End If
    '    End Select
    'End Sub
    Private Sub btn_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_All.Click
        PrintChoice = "All"
        ReportDate = DateChoice.Value
        ReportApp = SelectedApp
        PrintReport()
    End Sub
    Private Sub btn_Success_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Success.Click
        PrintChoice = "Success"
        ReportDate = DateChoice.Value
        ReportApp = SelectedApp
        PrintReport()
    End Sub
    Private Sub btn_Drop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Drop.Click
        PrintChoice = "Dropped"
        ReportDate = DateChoice.Value
        ReportApp = SelectedApp
        PrintReport()
    End Sub
    Private Sub btn_Redet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Redet.Click
        PrintChoice = "Redet Deleted"
        ReportDate = DateChoice.Value
        ReportApp = SelectedApp
        PrintReport()
    End Sub
    Private Sub btn_ForceGUMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ForceGUMP.Click
        If MessageBox.Show("Force creation of GUMP Update files?", "Create files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            isForceGump = True
        End If
    End Sub
    Private Sub btn_ClientData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ClientData.Click
        Dim Result As DialogResult
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        If btn_ClientData.Text = "Run Client Look Up" Then
            '    Try
            '        SQLComm.Connection = SQLConn
            '        SQLConn.Open()
            '        SQLComm.CommandText = "SELECT * FROM CRLCaseList"
            '        SQLReader = SQLComm.ExecuteReader
            '        SQLReader.Read()
            '        If SQLReader.HasRows Then
            '            SQLReader.Close()
            '            Result = MessageBox.Show("Continue Previous CRL Processing?", "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            '            If Result = Windows.Forms.DialogResult.Yes Then
            '                isContinue = True
            '                SetInfo("Continuing client look up...", "Client", False)
            '                btn_ClientData.Enabled = False
            '                BGW_ClientData.RunWorkerAsync()
            '            ElseIf Result = Windows.Forms.DialogResult.No Then
            '                SQLComm.CommandText = "DELETE FROM CRLCaseList"
            '                SQLComm.ExecuteNonQuery()
            '                SQLComm.CommandText = "DELETE FROM MONTH_ClientDataMaster"
            '                SQLComm.ExecuteNonQuery()
            '                isContinue = False
            If CRLFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CRLFile = CRLFileDialog.FileName
            End If
            SetInfo("Starting client look up...", "Client", False)
            btn_ClientData.Enabled = False
            BGW_ClientData.RunWorkerAsync()
            '            ElseIf Result = Windows.Forms.DialogResult.Cancel Then

            '            End If
            '        Else
            '            isContinue = False
            '            If CRLFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '                SQLReader.Close()
            '                SQLComm.CommandText = "DELETE FROM MONTH_ClientDataMaster"
            '                SQLComm.ExecuteNonQuery()
            '                CRLFile = CRLFileDialog.FileName
            '                btn_ClientData.Enabled = False
            '                BGW_ClientData.RunWorkerAsync()
            '            End If
            '        End If
            '    Catch ex As Exception
            '        MessageBox.Show("Location: StartCRL" & vbCrLf & ex.Message)
            '    Finally
            '        SQLConn.Close()
            '    End Try
            'ElseIf btn_ClientData.Text = "Cancel Look Up" Then
            '    Result = MessageBox.Show("Cancel Client Look Up", "Cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            '    If Result = Windows.Forms.DialogResult.Yes Then
            '        BGW_ClientData.CancelAsync()
            '        btn_ClientData.Enabled = False
            '        btn_ClientData.Text = "Canceling..."
            '        SetInfo("Canceling client look up...", "Client", False)
            '    End If
        End If
    End Sub
#End Region

#Region "Thread Functions"
    Private Sub BGW_IMPSScanDirectory_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_IMPSScanDirectory.DoWork
        Dim Directory As New DirectoryInfo(My.Settings.IMPSDirectory)
        Dim FileDirectory As DirectoryInfo
        Dim FileList() As FileInfo
        Dim i As Integer
        Try
            While Not BGW_IMPSScanDirectory.CancellationPending
                If isServerConnected Then
                    BGW_IMPSScanDirectory.ReportProgress(15)
                    FileDirectory = New DirectoryInfo(My.Application.Info.DirectoryPath & "\IMPS Files\" & Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year & "\")
                    If Not FileDirectory.Exists Then FileDirectory.Create()
                    FileList = Directory.GetFiles("*.txt")
                    If FileList.Length > 0 Then
                        For i = 0 To FileList.Length - 1
                            'If FileList(i).Name.Substring(0, 2) = "04" Or FileList(i).Name.Substring(0, 2) = "05" Or FileList(i).Name.Substring(0, 2) = "06" Or FileList(i).Name.Substring(0, 2) = "07" Then
                            isPause = True
                            IMPSFileName = My.Settings.IMPSDirectory & "\" & FileList(i).Name
                            IMPSBatchNumber = My.Settings.IMPSBatchPrefix & My.Settings.IMPSBatchNumber
                            Thread.Sleep(1000)
                            BGW_IMPSScanDirectory.ReportProgress(1)
                            ProcessIMPS()
                            Select Case IMPSResult
                                Case "SUCCESS"
                                    BGW_IMPSScanDirectory.ReportProgress(100)
                                Case "DROP"
                                    BGW_IMPSScanDirectory.ReportProgress(99)
                                Case "LOGONERROR"
                                    BGW_IMPSScanDirectory.ReportProgress(97)
                                Case "UNKNOWN"
                                    BGW_IMPSScanDirectory.ReportProgress(98)
                            End Select
                            If IMPSResult <> "LOGONERROR" Then
                                If File.Exists(My.Application.Info.DirectoryPath & "\IMPS Files\" & Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year & "\" & IMPSFileName.Substring(My.Settings.IMPSDirectory.Length + 1)) Then File.Delete((My.Application.Info.DirectoryPath & "\IMPS Files\" & Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year & "\" & IMPSFileName.Substring(My.Settings.IMPSDirectory.Length + 1)))
                                File.Move(IMPSFileName, My.Application.Info.DirectoryPath & "\IMPS Files\" & Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year & "\" & IMPSFileName.Substring(My.Settings.IMPSDirectory.Length + 1))
                            End If
                            'End If
                            If BGW_IMPSScanDirectory.CancellationPending Then Exit While
                        Next
                        isPause = False
                    End If
                End If
                Thread.Sleep(3245)
            End While
        Catch ex As System.IO.IOException
            ErrorString = "Location IMPSScanDirectory: " & ex.Message.ToString
            BGW_IMPSScanDirectory.ReportProgress(9)
        Catch ex As Exception
            ErrorString = "Location IMPSScanDirectory: " & ex.Message.ToString
            BGW_IMPSScanDirectory.ReportProgress(9)
            isIMPSError = True
        End Try
    End Sub
    Private Sub BGW_IMPSScanDirectory_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_IMPSScanDirectory.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1  '--Start case processing--
                SetInfo("Processing IMPS File: " & IMPSFileName.Substring(My.Settings.IMPSDirectory.Length + 1), "IMPS", False)
            Case 9  '--Error reporting--           OLD '--Directory does not exist--
                SetInfo(ErrorString, "IMPS", True)
                'SetInfo("Directory Does Not Exist.", "IMPS", True)
            Case 15
                CheckTotalDate()
            Case 97 '--Case had a logon error--
                SetInfo("IMPS File: " & IMPSFileName.Substring(My.Settings.IMPSDirectory.Length + 1) & " was not processed." & vbCrLf & "     Reason: " & ErrorMessage1, "IMPS", False)
                Thread.Sleep(1723)
                SetInfo("Retrying...", "IMPS", False)
                'SelectedApp = "IMPS"
                'tool_Stop_Click(Nothing, Nothing)
            Case 98 '--Case had an unknown error--
                SetInfo("IMPS File: " & IMPSFileName.Substring(My.Settings.IMPSDirectory.Length + 1) & " had an unknown error." & vbCrLf & "     Reason: Unknown Error", "IMPS", False)
                IncrementTotals("IMPS", "DROP")
            Case 99 '--Case was dropped--
                SetInfo("IMPS File: " & IMPSFileName.Substring(My.Settings.IMPSDirectory.Length + 1) & " was Dropped." & vbCrLf & "     Reason: " & ErrorMessage1, "IMPS", False)
                IncrementTotals("IMPS", "DROP")
            Case 100 '--Case finished processing--
                IncrementTotals("IMPS", "SUCCESS")
                SetInfo("Completed IMPS File: " & IMPSFileName.Substring(My.Settings.IMPSDirectory.Length + 1) & vbCrLf & "     Batch Number: " & Old_IMPSBatchNumber, "IMPS", False)
                Me.txt_IMPSBatchNumber.Text = My.Settings.IMPSBatchNumber
                BGW_BlinkSubmit.CancelAsync()
                isChangeMade = False
        End Select
    End Sub
    Private Sub BGW_IMPSScanDirectory_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_IMPSScanDirectory.RunWorkerCompleted
        SetInfo("IMPS Process Stopped.", "IMPS", False)
        panel_IMPSOptions.Enabled = True
        ChangeNodeIcon(IMPSNode, StopIcon)
        tool_Stop.Enabled = False
        '--Because of the delay when stopping the run button was being enabled when the server was down--
        If isServerConnected Then tool_Run.Enabled = True
        treeMenu.Enabled = True
        IMPSNode.Text = "IMPS"
        If Not BGW_MediScanDirectory.IsBusy Then BGW_CheckServer.CancelAsync()
        If isIMPSError Then
            '--Error encountered let's just restart the processing--
            SetInfo("Restarting IMPS...", "IMPS", False)
            Thread.Sleep(1734)
            SelectedApp = "IMPS"
            tool_Run_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub BGW_MediScanDirectory_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_MediScanDirectory.DoWork
        Dim Directory As New DirectoryInfo(My.Settings.MediDirectory)
        Dim HoldDirectory As New DirectoryInfo(My.Settings.MediDirectory & "\Holds")
        Dim FileList() As FileInfo
        Dim i, x, max As Integer
        Try
            While Not BGW_MediScanDirectory.CancellationPending
                If isServerConnected Then
                    BGW_MediScanDirectory.ReportProgress(15)
                    If Date.Now.Minute = 50 Then
                        If Date.Now.Hour = 8 Then
                            FileList = HoldDirectory.GetFiles("*.txt")
                            If FileList.Length > 0 Then
                                For i = 0 To FileList.Length - 1
                                    If File.Exists(My.Settings.MediDirectory & "\" & FileList(i).Name) Then File.Delete(My.Settings.MediDirectory & "\" & FileList(i).Name)
                                    File.Move(My.Settings.MediDirectory & "\Holds\" & FileList(i).Name, My.Settings.MediDirectory & "\" & FileList(i).Name)
                                Next
                            End If
                        End If
                        x = 0
                        FileList = Directory.GetFiles("*.txt")
                        If FileList.Length > 0 Then
                            isPause = True
                            BGW_MediScanDirectory.ReportProgress(12)
                            While BGW_IMPSScanDirectory.IsBusy
                                Application.DoEvents()
                                Thread.Sleep(1000)
                            End While
                            BGW_MediScanDirectory.ReportProgress(1)
                            If FileList.Length < 100 Then max = FileList.Length Else max = 100
                            For i = 0 To max - 1
                                If FileList(i).Name.Substring(0, 2) = "61" Or FileList(i).Name.Substring(0, 2) = "66" Or FileList(i).Name.Substring(0, 2) = "64" Then
                                    If BGW_MediScanDirectory.CancellationPending Then Exit While
                                    Thread.Sleep(500)
                                    MedicaidFileList(x) = New MedicaidFile(My.Settings.MediDirectory & "\" & FileList(i).Name)
                                    Thread.Sleep(250)
                                    x += 1
                                Else
                                    File.Delete(FileList(i).FullName)
                                End If
                            Next
                            MaxMedi = x
                            BGW_MediScanDirectory.ReportProgress(10)
                            ParentControlScreen = Me
                            ProcessMedicaid()
                            Thread.Sleep(5000)
                            BGW_MediScanDirectory.ReportProgress(11)
                            BGW_MediScanDirectory.ReportProgress(13)
                            isPause = False
                            Thread.Sleep(55000)
                        End If
                    End If
                End If
                Thread.Sleep(5684)
            End While
        Catch ex As Exception
            '--TODO: REMOVE--    'MessageBox.Show("Location: BGW_MediScanDirectory" & vbCrLf & ex.Message)
            ErrorString = "Location BGW_MediScanDirectory: " & ex.Message.ToString
            BGW_MediScanDirectory.ReportProgress(99)
            isMedicaidError = True
            '--TODO: REMOVE--   'ErrorDump(MediFile & vbCrLf & OPTChoice & vbCrLf & MediCaseNumber & vbCrLf & MediPersonNumber & vbCrLf & isErrorMedi & vbCrLf & ErrorMessage1Medi)
        End Try
    End Sub
    Private Sub BGW_MediScanDirectory_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_MediScanDirectory.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1  '--Report making of file list--
                SetInfo("Creating File List...", "Medicaid", False)
            Case 2  '--Report case processing start--
                SetInfo("Processing Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber, "Medicaid", False)
            Case 3  '--Report case errors--
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " >> " & ErrorMessage1Medi & " " & ErrorMessage2Medi, "Medicaid", True)
            Case 4  '--Report case success--
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " Successfully Processed.", "Medicaid", False)
                IncrementTotals("Medicaid", "SUCCESS")
            Case 5  '--Report case being manually entered--
                IncrementTotals("Medicaid", "DROP")
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " will be manually entered.", "Medicaid", False)
            Case 6  '--Report case being held--
                IncrementTotals("Medicaid", "HOLD")
                SetInfo("Case: " & MediCaseNumber & " OPT: " & OPTChoice & " Per#: " & MediPersonNumber & " is being held.", "Medicaid", False)
            Case 7 '--Operator not on list--
                SetInfo("Worker: " & MediCaseNumber & " not on list to be processed. File: " & MediFile & " deleted...", "Medicaid", True)
            Case 8 '--Report GLink error--
                SetInfo("GLink Error: " & ErrorMessage1Medi, "Medicaid", True)
                SelectedApp = "Medicaid"
                tool_Stop_Click(Nothing, Nothing)
            Case 10 '--Report total cases being processed--
                SetInfo("Processing " & MaxMedi & " Cases...", "Medicaid", False)
            Case 11 '--Report cases done--
                SetInfo("File list complete.", "Medicaid", False)
            Case 12 '--Stop IMPS--
                If BGW_IMPSScanDirectory.IsBusy Then
                    wasIMPSRunning = True
                    SetInfo("Stopping IMPS Processing...", "Medicaid", False)
                    SelectedApp = "IMPS"
                    tool_Stop_Click(Nothing, Nothing)
                End If
            Case 13 '--Start IMPS--
                If wasIMPSRunning Then
                    wasIMPSRunning = False
                    SetInfo("Starting IMPS Processing...", "Medicaid", False)
                    While isStarting
                        Application.DoEvents()
                        Thread.Sleep(1000)
                    End While
                    SelectedApp = "IMPS"
                    tool_Run_Click(Nothing, Nothing)
                End If
            Case 15
                CheckTotalDate()
            Case 20
                SetInfo("Processing all persons in " & MediCaseNumber & " as a group.", "Medicaid", False)
            Case 99 '--Error reporting--
                SetInfo(ErrorString, "Medicaid", True)
        End Select
    End Sub
    Private Sub BGW_MediScanDirectory_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_MediScanDirectory.RunWorkerCompleted
        SetInfo("Medicaid Process Stopped.", "Medicaid", False)
        panel_MedicaidOptions.Enabled = True
        ChangeNodeIcon(MedicaidNode, StopIcon)
        tool_Stop.Enabled = False
        '--Because of the delay when stopping the run button was being enabled when the server was down--
        If isServerConnected Then tool_Run.Enabled = True
        treeMenu.Enabled = True
        MedicaidNode.Text = "Medicaid"
        If Not BGW_IMPSScanDirectory.IsBusy Then BGW_CheckServer.CancelAsync()
        If isMedicaidError Then
            '--Error encountered let's just restart the processing--
            SetInfo("Restarting Medicaid...", "Medicaid", False)
            Thread.Sleep(1734)
            SelectedApp = "Medicaid"
            tool_Run_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub BGW_GUMPUpdate_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_GUMPUpdate.DoWork
        Try
            While Not BGW_GUMPUpdate.CancellationPending
                If Date.Now.Hour = 20 And Date.Now.Minute = 30 Or isForceGump Then
                    isForceGump = False
                    Update_ParentControlScreen = Me
                    BGW_GUMPUpdate.ReportProgress(0)
                    While BGW_IMPSScanDirectory.IsBusy Or BGW_MediScanDirectory.IsBusy
                        Application.DoEvents()
                        Thread.Sleep(1000)
                    End While
                    MakeFile()
                    Thread.Sleep(250)
                    BGW_GUMPUpdate.ReportProgress(3)
                    Thread.Sleep(45000)
                    BGW_GUMPUpdate.ReportProgress(5)
                End If
                Thread.Sleep(5000)
            End While
        Catch ex As Exception
            MessageBox.Show("Location: GUMPUpdate" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub BGW_GUMPUpdate_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_GUMPUpdate.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0 '--Stop IMPS and Medicaid--
                If BGW_IMPSScanDirectory.IsBusy Then
                    wasIMPSRunning = True
                    SelectedApp = "IMPS"
                    tool_Stop_Click(Nothing, Nothing)
                End If
                If BGW_MediScanDirectory.IsBusy Then
                    wasMedicaidRunning = True
                    SelectedApp = "Medicaid"
                    tool_Stop_Click(Nothing, Nothing)
                End If
                btn_ForceGUMP.Enabled = False
                btn_ClientData.Enabled = False
            Case 1
                UpdateProgress.Maximum = CaseCount * 4
                panel_Main.Visible = True
                treeMenu.SelectedNode = treeMenu.Nodes(0)
                treeMenu.Enabled = False
            Case 2
                If UpdateProgress.Value + 1 < UpdateProgress.Maximum Then UpdateProgress.Value += 1
            Case 3
                Try
                    UpdateProgress.Value = 0
                    treeMenu.Enabled = True
                    txt_UpdateCases.Text = CaseCount
                    txt_UpdateTime.Text = Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & " " & Date.Now.Hour.ToString.PadLeft(2, "0") & ":" & Date.Now.Minute.ToString.PadLeft(2, "0")
                    If wasIMPSRunning Then
                        wasIMPSRunning = False
                        SelectedApp = "IMPS"
                        tool_Run_Click(Nothing, Nothing)
                        Thread.Sleep(2500)
                        While isStarting
                            Application.DoEvents()
                            Thread.Sleep(1000)
                        End While
                    End If
                    If wasMedicaidRunning Then
                        wasMedicaidRunning = False
                        SelectedApp = "Medicaid"
                        tool_Run_Click(Nothing, Nothing)
                        btn_ClientData.Enabled = True
                    End If
                Catch ex As Exception
                    MessageBox.Show("Location: Progress" & vbCrLf & ex.Message)
                End Try
            Case 5
                btn_ForceGUMP.Enabled = True
        End Select
    End Sub
    Private Sub BGW_GUMPUpdate_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_GUMPUpdate.RunWorkerCompleted
        tool_Stop.Enabled = False
        '--Because of the delay when stopping the run button was being enabled when the server was down--
        If isServerConnected Then tool_Run.Enabled = True
        treeMenu.Enabled = True
        If Not BGW_MediScanDirectory.IsBusy And Not BGW_IMPSScanDirectory.IsBusy Then BGW_CheckServer.CancelAsync()
    End Sub
    Private Sub BGW_ClientData_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_ClientData.DoWork
        Dim isClientLoop As Boolean = False
        Do
            Try
                BGW_ClientData.ReportProgress(2)
                Client_ParentControlScreen = Me
                'BGW_Test.RunWorkerAsync()
                GetClientData(isClientLoop)
                isClientLoop = False
            Catch ex As Exception
                'MessageBox.Show("Location: ClientData" & vbCrLf & ex.Message)
                ClientErrorMessage = "Location: ClientData > " & ex.Message
                isClientLoop = True
                BGW_ClientData.ReportProgress(99)
            End Try
        Loop Until Not isClientLoop
    End Sub
    Private Sub BGW_ClientData_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW_ClientData.ProgressChanged
        Select Case e.ProgressPercentage
            Case 0
                btn_ClientData.Enabled = True
                ClientProgress.Maximum = CRLCaseList.Count
                ClientProgress.Value = 0
                ClientCaseNum = 0
                btn_ClientData.Text = "Cancel Look Up"
                treeMenu.SelectedNode = ClientNode
                SetInfo("Looking up " & CRLCaseList.Count & " cases.", "Client", False)
                ChangeNodeIcon(ClientNode, RunIcon)
            Case 1
                If ClientProgress.Value + 1 < ClientProgress.Maximum Then ClientProgress.Value += 1
                ClientCaseNum += 1
                txt_ClientCases.Text = ClientCaseNum
            Case 2

            Case 3
                SetInfo("Processing client: " & FirstName(0) & " " & LastName(0) & " Case: " & ClientDataCaseNumber(0), "Client", False)
            Case 4
                SetInfo("Processing client: " & FirstName(1) & " " & LastName(1) & " Case: " & ClientDataCaseNumber(1), "Client", False)
            Case 10
                SetInfo("Pausing processing...", "Client", False)
                btn_ClientData.Enabled = False
                btn_ClientData.Text = "Processing Paused"
                ChangeNodeIcon(ClientNode, StoppingIcon)
            Case 11
                SetInfo("Restarting processing.", "Client", False)
                btn_ClientData.Enabled = True
                btn_ClientData.Text = "Cancel Look Up"
                ChangeNodeIcon(ClientNode, RunIcon)
            Case 98
                SetInfo("Case: " & ClientCaseNum & " not found.", "Client", True)
            Case 99
                SetInfo(ClientErrorMessage, "Client", True)
        End Select
    End Sub
    Private Sub BGW_ClientData_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW_ClientData.RunWorkerCompleted
        btn_ClientData.Text = "Run Client Look Up"
        btn_ClientData.Enabled = True
        SetInfo("Client look up completed.", "Client", False)
        txt_ClientTime.Text = Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & " " & Date.Now.Hour.ToString.PadLeft(2, "0") & ":" & Date.Now.Hour.ToString.PadLeft(2, "0")
        treeMenu.SelectedNode = treeMenu.Nodes(0)
        ChangeNodeIcon(ClientNode, 3) '3 = red bird
    End Sub
#End Region

#Region "Log Functions"
    Private Sub cmb_LogFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_LogFiles.SelectedIndexChanged
        Dim IMPSDirectory As New DirectoryInfo(My.Application.Info.DirectoryPath & "\IMPS Logs\")
        Dim MediDirectory As New DirectoryInfo(My.Application.Info.DirectoryPath & "\Medicaid Logs\")
        Dim ClientDirectory As New DirectoryInfo(My.Application.Info.DirectoryPath & "\Client Logs\")
        Dim infile As StreamReader
        txt_IMPSLog.Text = Nothing
        txt_MedicaidLog.Text = Nothing
        txt_ClientInfo.Text = Nothing
        Select Case SelectedApp
            Case "IMPS"
                infile = New StreamReader(IMPSDirectory.FullName & cmb_LogFiles.SelectedItem.ToString & ".doc")
                While infile.Peek <> -1
                    txt_IMPSLog.Text = txt_IMPSLog.Text & vbCrLf & infile.ReadLine
                End While
                infile.Close()
            Case "Medicaid"
                infile = New StreamReader(MediDirectory.FullName & cmb_LogFiles.SelectedItem.ToString & ".doc")
                While infile.Peek <> -1
                    txt_MedicaidLog.Text = txt_MedicaidLog.Text & vbCrLf & infile.ReadLine
                End While
                infile.Close()
            Case "Client"
                infile = New StreamReader(ClientDirectory.FullName & cmb_LogFiles.SelectedItem.ToString & ".doc")
                While infile.Peek <> -1
                    txt_ClientInfo.Text = txt_ClientInfo.Text & vbCrLf & infile.ReadLine
                End While
                infile.Close()
        End Select
    End Sub
    Private Sub LogFile(ByVal LineToWrite As String, ByVal App As String)
        Dim File_Writer As StreamWriter
        Dim LogTime As String = Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year
        Select Case App
            Case "IMPS"
                File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "\IMPS Logs\LogFile (" & LogTime & ").doc", True)
            Case "Medicaid"
                File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "\Medicaid Logs\LogFile (" & LogTime & ").doc", True)
            Case "Client"
                File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "\Client Logs\LogFile (" & LogTime & ").doc", True)
            Case Else
                File_Writer = Nothing
        End Select
        File_Writer.WriteLine(LogTime & " " & Date.Now.Hour.ToString & ":" & Date.Now.Minute.ToString & ":" & Date.Now.Second.ToString & " >> " & LineToWrite)
        File_Writer.Close()
    End Sub
    Private Sub SetLogFile()
        Dim IMPSDirectory As New DirectoryInfo(My.Application.Info.DirectoryPath & "\IMPS Logs\")
        Dim MediDirectory As New DirectoryInfo(My.Application.Info.DirectoryPath & "\Medicaid Logs\")
        Dim FileList() As FileInfo
        Dim i As Integer
        cmb_LogFiles.Items.Clear()
        Select Case SelectedApp
            Case "IMPS"
                IMPSDirectory.Refresh()
                If IMPSDirectory.Exists = True Then
                    FileList = IMPSDirectory.GetFiles("*.doc")
                    Array.Reverse(FileList)
                    If FileList.Length <> 0 Then
                        For i = 0 To FileList.Length - 1
                            cmb_LogFiles.Items.Add(FileList(i).Name.Replace(".doc", ""))
                        Next
                    Else
                        cmb_LogFiles.Items.Clear()
                        cmb_LogFiles.Text = "No Log Files"
                        cmb_LogFiles.Enabled = False
                    End If
                End If
            Case "Medicaid"
                MediDirectory.Refresh()
                If MediDirectory.Exists = True Then
                    FileList = MediDirectory.GetFiles("*.doc")
                    Array.Reverse(FileList)
                    If FileList.Length <> 0 Then
                        For i = 0 To FileList.Length - 1
                            cmb_LogFiles.Items.Add(FileList(i).Name.Replace(".doc", ""))
                        Next
                    Else
                        cmb_LogFiles.Items.Clear()
                        cmb_LogFiles.Text = "No Log Files"
                        cmb_LogFiles.Enabled = False
                    End If
                End If
        End Select
    End Sub
    Private Sub SetInfo(ByVal StringToWrite As String, ByVal App As String, ByVal isErrMsg As Boolean)
        If isErrMsg Then
            Select Case App
                Case "IMPS" : txt_IMPSInfo.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> ERROR: " & StringToWrite & vbCrLf & txt_IMPSInfo.Text : LogFile("Error: " & StringToWrite, "IMPS")
                Case "Medicaid" : txt_MedicaidInfo.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> ERROR: " & StringToWrite & vbCrLf & txt_MedicaidInfo.Text : LogFile("Error: " & StringToWrite, "Medicaid")
                Case "Client" : txt_ClientInfo.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> ERROR: " & StringToWrite & vbCrLf & txt_ClientInfo.Text : LogFile("Error: " & StringToWrite, "Client")
            End Select
        Else
            Select Case App
                Case "IMPS" : txt_IMPSInfo.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> " & StringToWrite & vbCrLf & txt_IMPSInfo.Text : LogFile(StringToWrite, "IMPS")
                Case "Medicaid" : txt_MedicaidInfo.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> " & StringToWrite & vbCrLf & txt_MedicaidInfo.Text : LogFile(StringToWrite, "Medicaid")
                Case "Client" : txt_ClientInfo.Text = Date.Now.Hour & ":" & Date.Now.Minute & ":" & Date.Now.Second & " >> " & StringToWrite & vbCrLf & txt_ClientInfo.Text : LogFile(StringToWrite, "Client")
            End Select
        End If
    End Sub
    Private Sub ErrorDump(ByVal LineToWrite As String)
        Dim File_Writer As New StreamWriter("C:\ErrorDump (" & Date.Now.Month.ToString & "_" & Date.Now.Day.ToString & "_" & Date.Now.Year.ToString & "_" & Date.Now.Hour.ToString & Date.Now.Minute.ToString & ").doc", True)
        Dim LogTime As String = Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year
        File_Writer.WriteLine(LineToWrite)
        File_Writer.Close()
    End Sub
#End Region

    'Private Sub FTP_SendFiles()
    '    Dim Client As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    '    Dim EndPt As New System.Net.IPEndPoint(System.Net.Dns.GetHostEntry("passaic").AddressList(0), 21)
    '    Try
    '        Client.Connect(EndPt)
    '        MessageBox.Show(FTP_GetLine(Client))
    '        FTP_SendLine("USER gump", Client)
    '        MessageBox.Show(FTP_GetLine(Client))
    '        FTP_SendLine("PASS rich", Client)
    '        MessageBox.Show(FTP_GetLine(Client))
    '        FTP_SendLine("cwd /u/home/gump", Client)
    '        MessageBox.Show(FTP_GetLine(Client))
    '        Client.SendFile("C:\test.txt")
    '        'FTP_SendLine("lcd c:\testcases\", Client)
    '        MessageBox.Show(FTP_GetLine(Client))
    '        'FTP_SendLine("mput P105*.dat", Client)
    '        'MessageBox.Show(FTP_GetLine(Client))
    '        FTP_SendLine("quit", Client)
    '        MessageBox.Show(FTP_GetLine(Client))
    '    Catch ex As Exception
    '        MessageBox.Show("Location: FTP" & vbCrLf & ex.Message)
    '    Finally
    '        Client.Disconnect(False)
    '    End Try
    'End Sub
    'Private Function FTP_GetLine(ByRef ClientSocket As Socket) As String
    '    Dim ResponseBuffer(512) As Byte
    '    Dim Response As String
    '    ClientSocket.Receive(ResponseBuffer, ResponseBuffer.Length, SocketFlags.None)
    '    Response = System.Text.ASCIIEncoding.ASCII.GetString(ResponseBuffer, 0, ResponseBuffer.Length)
    '    Return Response
    'End Function
    'Private Sub FTP_SendLine(ByVal LineToSend As String, ByRef ClientSocket As Socket)
    '    Dim cmdBytes() As Byte
    '    cmdBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(LineToSend & Environment.NewLine)
    '    ClientSocket.Send(cmdBytes, cmdBytes.Length, SocketFlags.None)
    'End Sub

    Private Sub BGW_Test_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW_Test.DoWork
        Thread.Sleep(5000)
        GetClientData2(Nothing)
    End Sub
End Class