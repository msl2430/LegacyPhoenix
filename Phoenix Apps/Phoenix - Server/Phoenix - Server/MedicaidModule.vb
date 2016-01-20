'--Developed by Michael Levine 10/2007--
Module MedicaidModule
    '--Process Medicaid files through GLink--

    Public MediFile As String                                   '--Medicaid file being processed--
    Public MediCaseNumber As String                             '--Medicaid case number--
    Public MediPersonNumber As String                           '--Medicaid person number--
    Public isErrorMedi As Boolean = False                       '--Track if there is an error--
    Public MaxMedi As Integer                                   '--Max files to process--
    Public MedicaidFileList(100) As MedicaidFile
    Public ParentControlScreen As ControlScreen
    Public OPTChoice As String                                  '--OPTS type--
    Public ErrorMessage1Medi, ErrorMessage2Medi As String       '--Error messages--

    Private ProcessFileOrder As List(Of MedicaidFile)
    Private OPTS61Information As OPTS61Data                     '--OPTS61 data blocks--
    Private OPTS64Information As OPTS64Data                     '--OPTS64 data blocks--
    Private OPTS66Information As OPTS66Data                     '--OPTS66 data blocks--
    Private glapiMedicaid As connGLinkTP8                       '--GLink connection for IMPS--
    Private Const OPTScreen As Integer = 19                     '--Screen OPT field number--
    Private Const PerNumberScreen As Integer = 13               '--Screen person number field--
    Private Const CaseNumberScreen As Integer = 10              '--Screen case number field--

    Public Sub ProcessMedicaid()
        Dim i, j As Integer
        Dim isOperatorOK As Boolean   '--Decides if the worker number is valid and if we should process the case--
        Dim isGroupOPT As Boolean     '--Tracks whether the opt 61 has a opt 66 to go with it--
        Dim isHoldChildren As Boolean '--Tracks whether we should hold the opt because the children are not on HMO--
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        SQLComm.Connection = SQLConn
        ProcessFileOrder = New List(Of MedicaidFile)
        '--Make process list--
        For i = 0 To MaxMedi - 1
            If Not MedicaidFileList(i).isChecked Then
                If MedicaidFileList(i).OptScreen = "61" And (MedicaidFileList(i).PersonNumber = "01" Or MedicaidFileList(i).PersonNumber = "02" Or MedicaidFileList(i).PersonNumber = "05") Then
                    ProcessFileOrder.Add(MedicaidFileList(i))
                    MedicaidFileList(i).isChecked = True
                    For j = i + 1 To MaxMedi - 1
                        '--Compare every case with 'i' file and see if theres and OP 64 or 66 to go with it--
                        If Not MedicaidFileList(j).isChecked And MedicaidFileList(j).CaseNumber = MedicaidFileList(i).CaseNumber And MedicaidFileList(j).PersonNumber = MedicaidFileList(i).PersonNumber Then
                            ProcessFileOrder.Add(MedicaidFileList(j))
                            MedicaidFileList(j).isChecked = True
                        End If
                    Next
                End If
            End If
        Next
        For i = 0 To MaxMedi - 1
            If Not MedicaidFileList(i).isChecked Then
                ProcessFileOrder.Add(MedicaidFileList(i))
                MedicaidFileList(i).isChecked = True
            End If
        Next
        For i = 0 To MaxMedi - 1
            MedicaidFileList(i) = ProcessFileOrder(i)
        Next
        '------------------------
        For i = 0 To MaxMedi - 1
            If ParentControlScreen.BGW_MediScanDirectory.CancellationPending Then Exit For
            '--TEMP-- Until all units are on system--
            '--Tests if the worker number is in the list of cases to process--
            Try
                SQLConn.Open()
                SQLComm.CommandText = "SELECT OperatorNumber FROM MedicaidOperator WHERE OperatorNumber = '" & MedicaidFileList(i).Worker & "'"
                SQLReader = SQLComm.ExecuteReader
                If SQLReader.HasRows Then
                    isOperatorOK = True
                Else
                    isOperatorOK = False
                    File.Delete(MedicaidFileList(i).FilePath)
                    MediCaseNumber = MedicaidFileList(i).Worker
                    MediFile = MedicaidFileList(i).FileName
                    ParentControlScreen.BGW_MediScanDirectory.ReportProgress(7)
                    Thread.Sleep(1578)
                End If
            Catch ex As Exception
                isOperatorOK = True
                MessageBox.Show("Location: TestOperatorOnly" & vbCrLf & ex.Message)
            Finally
                SQLConn.Close()
            End Try
            '--TEMP-- ^^
            isGroupOPT = False
            If Not MedicaidFileList(i).isDone And isOperatorOK Then
                isErrorMedi = False
                MediFile = MedicaidFileList(i).FilePath
                OPTChoice = MedicaidFileList(i).OptScreen
                MediCaseNumber = MedicaidFileList(i).CaseNumber
                MediPersonNumber = MedicaidFileList(i).PersonNumber
                ParentControlScreen.BGW_MediScanDirectory.ReportProgress(2)
                GLinkStartMedi()
                If Not isErrorMedi Then
                    Read_TextFile()
                    Thread.Sleep(750)
                    Select Case OPTChoice
                        Case "61"
                            If OPTS61Information.AddressAction.GetData = "A" And (OPTS61Information.PersonNumber.GetData = "01" Or OPTS61Information.PersonNumber.GetData = "02" Or OPTS61Information.PersonNumber.GetData = "05") Then
                                AddFamily(i)
                            Else
                                If OPTS61Information.AlienType.GetData = "4" And DateDiff(DateInterval.Month, OPTS61Information.EntryDate, Date.Now) <= 59 Then
                                    If isAlienHold() Then
                                        isHoldChildren = True
                                        ErrorMessage1Medi = " Children not on HMO. Holding case."
                                        StoreErrorOpt(i)
                                    Else
                                        isHoldChildren = False
                                    End If
                                Else
                                    isHoldChildren = False
                                End If
                                If Not isHoldChildren Then
                                    glapiMedicaid.SendKeysTransmit("061")
                                    If OPTS61Information.PersonAction.GetData = "A" Then
                                        '--Process new person with OPT 66 that goes with it--
                                        glapiMedicaid.SubmitField(CaseNumberScreen, OPTS61Information.CaseNumber.GetData)
                                        glapiMedicaid.SubmitField(PerNumberScreen, OPTS61Information.PersonNumber.GetData)
                                        glapiMedicaid.TransmitPage()
                                        If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                            StoreErrorOpt(i)
                                            For j = i + 1 To MaxMedi - 1
                                                If MedicaidFileList(j).CaseNumber = MediCaseNumber And MedicaidFileList(j).PersonNumber = MediPersonNumber Then
                                                    MediFile = MedicaidFileList(j).FilePath
                                                    OPTChoice = MedicaidFileList(j).OptScreen
                                                    MediCaseNumber = MedicaidFileList(j).CaseNumber
                                                    MediPersonNumber = MedicaidFileList(j).PersonNumber
                                                    If File.Exists(My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName) Then File.Delete(My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName)
                                                    File.Move(MedicaidFileList(j).FilePath, My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName)
                                                    ParentControlScreen.BGW_MediScanDirectory.ReportProgress(5)
                                                    MedicaidFileList(j).isDone = True
                                                End If
                                            Next
                                        Else
                                            SubmitPage61()
                                            glapiMedicaid.TransmitPage()
                                            If glapiMedicaid.GetString(2, 42, 6, 42) = "DEATH" Then glapiMedicaid.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F9)
                                            If isOPTError() Then
                                                '--Prior to temp addition what used to be here--
                                                'StoreErrorOpt(i)
                                                'For j = i + 1 To MaxMedi - 1
                                                '    If MedicaidFileList(j).CaseNumber = MediCaseNumber And MedicaidFileList(j).PersonNumber = MediPersonNumber Then
                                                '        MediFile = MedicaidFileList(j).FilePath
                                                '        OPTChoice = MedicaidFileList(j).OptScreen
                                                '        MediCaseNumber = MedicaidFileList(j).CaseNumber
                                                '        MediPersonNumber = MedicaidFileList(j).PersonNumber
                                                '        If File.Exists(My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName) Then File.Delete(My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName)
                                                '        File.Move(MedicaidFileList(j).FilePath, My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName)
                                                '        ParentControlScreen.BGW_MediScanDirectory.ReportProgress(5)
                                                '        MedicaidFileList(j).isDone = True
                                                '    End If
                                                'Next
                                                '------------------TEMP------------------------
                                                '--Redundant processing to help along the addition of Supervisor numbers--
                                                If (ErrorMessage1Medi.Substring(0, 10) = "SUPERVISOR" Or ErrorMessage1Medi.Substring(1, 10) = "SUPERVISOR") And OPTS61Information.Supervisor.GetData <> "  " Then
                                                    glapiMedicaid.SubmitField(OPTS61Information.Supervisor.FieldNumber, OPTS61Information.Supervisor.GetData)
                                                    glapiMedicaid.SubmitField(OPTS61Information.Worker61.FieldNumber, OPTS61Information.Worker61.GetData)
                                                    glapiMedicaid.SubmitField(OPTS61Information.PersonAction.FieldNumber, "C")
                                                    glapiMedicaid.TransmitPage()
                                                    If isOPTError() Then
                                                        '--Error in case--
                                                        StoreErrorOpt(i)
                                                        For j = i + 1 To MaxMedi - 1
                                                            If MedicaidFileList(j).CaseNumber = MediCaseNumber And MedicaidFileList(j).PersonNumber = MediPersonNumber Then
                                                                MediFile = MedicaidFileList(j).FilePath
                                                                OPTChoice = MedicaidFileList(j).OptScreen
                                                                MediCaseNumber = MedicaidFileList(j).CaseNumber
                                                                MediPersonNumber = MedicaidFileList(j).PersonNumber
                                                                If File.Exists(My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName) Then File.Delete(My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName)
                                                                File.Move(MedicaidFileList(j).FilePath, My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName)
                                                                ParentControlScreen.BGW_MediScanDirectory.ReportProgress(5)
                                                                MedicaidFileList(j).isDone = True
                                                            End If
                                                        Next
                                                    Else
                                                        '--Case completed--
                                                        StoreOpt(i)
                                                        Thread.Sleep(500)
                                                        If i + 1 <= MaxMedi - 1 Then
                                                            For j = i + 1 To MaxMedi - 1
                                                                If MedicaidFileList(j).CaseNumber = MediCaseNumber And MedicaidFileList(j).PersonNumber = MediPersonNumber Then
                                                                    isGroupOPT = True
                                                                    isErrorMedi = False
                                                                    MediFile = MedicaidFileList(j).FilePath
                                                                    OPTChoice = MedicaidFileList(j).OptScreen
                                                                    MediCaseNumber = MedicaidFileList(j).CaseNumber
                                                                    MediPersonNumber = MedicaidFileList(j).PersonNumber
                                                                    Read_TextFile()
                                                                    ParentControlScreen.BGW_MediScanDirectory.ReportProgress(2)
                                                                    Select Case OPTChoice
                                                                        Case "64"
                                                                            glapiMedicaid.SubmitField(CaseNumberScreen, OPTS66Information.CaseNumber.GetData)
                                                                            glapiMedicaid.SubmitField(PerNumberScreen, OPTS66Information.PersonNumber.GetData)
                                                                            glapiMedicaid.SubmitField(OPTScreen, "064")
                                                                            glapiMedicaid.TransmitPage()
                                                                            If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                                                                StoreErrorOpt(j)
                                                                            Else
                                                                                SubmitPage64()
                                                                                glapiMedicaid.TransmitPage()
                                                                                If isOPTError() Then
                                                                                    '--Error in case--
                                                                                    StoreErrorOpt(j)
                                                                                Else
                                                                                    '--Case completed--
                                                                                    StoreOpt(j)
                                                                                End If
                                                                            End If
                                                                        Case "66"
                                                                            glapiMedicaid.SubmitField(CaseNumberScreen, OPTS66Information.CaseNumber.GetData)
                                                                            glapiMedicaid.SubmitField(PerNumberScreen, OPTS66Information.PersonNumber.GetData)
                                                                            glapiMedicaid.SubmitField(OPTScreen, "066")
                                                                            glapiMedicaid.TransmitPage()
                                                                            If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                                                                StoreErrorOpt(i)
                                                                            Else
                                                                                SubmitPage66()
                                                                                glapiMedicaid.TransmitPage()
                                                                                If isOPTError() Then
                                                                                    '--Error in case--
                                                                                    If glapiMedicaid.GetString(2, 42, 9, 42) = "REDETERM" And OPTS66Information.ActionCode66.GetData = "A" Then
                                                                                        glapiMedicaid.SubmitField(OPTS66Information.ActionCode66.FieldNumber, "C")
                                                                                        glapiMedicaid.TransmitPage()
                                                                                        If isOPTError() Then
                                                                                            StoreErrorOpt(i)
                                                                                        Else
                                                                                            StoreOpt(j)
                                                                                        End If
                                                                                    Else
                                                                                        StoreErrorOpt(j)
                                                                                    End If
                                                                                Else
                                                                                    '--Case completed--
                                                                                    StoreOpt(j)
                                                                                End If
                                                                            End If
                                                                    End Select
                                                                    MedicaidFileList(j).isDone = True
                                                                End If
                                                            Next
                                                        End If
                                                        '-------------END TEMP--
                                                    End If
                                                Else
                                                    '--Error in case--
                                                    StoreErrorOpt(i)
                                                    For j = i + 1 To MaxMedi - 1
                                                        If MedicaidFileList(j).CaseNumber = MediCaseNumber And MedicaidFileList(j).PersonNumber = MediPersonNumber Then
                                                            MediFile = MedicaidFileList(j).FilePath
                                                            OPTChoice = MedicaidFileList(j).OptScreen
                                                            MediCaseNumber = MedicaidFileList(j).CaseNumber
                                                            MediPersonNumber = MedicaidFileList(j).PersonNumber
                                                            If File.Exists(My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName) Then File.Delete(My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName)
                                                            File.Move(MedicaidFileList(j).FilePath, My.Settings.MediDropDirectory & "\" & MedicaidFileList(j).FileName)
                                                            ParentControlScreen.BGW_MediScanDirectory.ReportProgress(5)
                                                            MedicaidFileList(j).isDone = True
                                                        End If
                                                    Next
                                                End If
                                            Else
                                                '--Case completed--
                                                StoreOpt(i)
                                                Thread.Sleep(500)
                                                If i + 1 <= MaxMedi - 1 Then
                                                    For j = i + 1 To MaxMedi - 1
                                                        If MedicaidFileList(j).CaseNumber = MediCaseNumber And MedicaidFileList(j).PersonNumber = MediPersonNumber Then
                                                            isGroupOPT = True
                                                            isErrorMedi = False
                                                            MediFile = MedicaidFileList(j).FilePath
                                                            OPTChoice = MedicaidFileList(j).OptScreen
                                                            MediCaseNumber = MedicaidFileList(j).CaseNumber
                                                            MediPersonNumber = MedicaidFileList(j).PersonNumber
                                                            Read_TextFile()
                                                            ParentControlScreen.BGW_MediScanDirectory.ReportProgress(2)
                                                            Select Case OPTChoice
                                                                Case "64"
                                                                    glapiMedicaid.SubmitField(CaseNumberScreen, OPTS64Information.CaseNumber.GetData)
                                                                    glapiMedicaid.SubmitField(PerNumberScreen, OPTS64Information.PersonNumber.GetData)
                                                                    glapiMedicaid.SubmitField(OPTScreen, "064")
                                                                    glapiMedicaid.TransmitPage()
                                                                    If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                                                        StoreErrorOpt(j)
                                                                    Else
                                                                        SubmitPage64()
                                                                        glapiMedicaid.TransmitPage()
                                                                        If isOPTError() Then
                                                                            '--Error in case--
                                                                            StoreErrorOpt(j)
                                                                        Else
                                                                            '--Case completed--
                                                                            StoreOpt(j)
                                                                        End If
                                                                    End If
                                                                Case "66"
                                                                    glapiMedicaid.SubmitField(CaseNumberScreen, OPTS66Information.CaseNumber.GetData)
                                                                    glapiMedicaid.SubmitField(PerNumberScreen, OPTS66Information.PersonNumber.GetData)
                                                                    glapiMedicaid.SubmitField(OPTScreen, "066")
                                                                    glapiMedicaid.TransmitPage()
                                                                    If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                                                        StoreErrorOpt(i)
                                                                    Else
                                                                        SubmitPage66()
                                                                        glapiMedicaid.TransmitPage()
                                                                        If isOPTError() Then
                                                                            '--Error in case--
                                                                            If glapiMedicaid.GetString(2, 42, 9, 42) = "REDETERM" And OPTS66Information.ActionCode66.GetData = "A" Then
                                                                                glapiMedicaid.SubmitField(OPTS66Information.ActionCode66.FieldNumber, "C")
                                                                                glapiMedicaid.TransmitPage()
                                                                                If isOPTError() Then
                                                                                    StoreErrorOpt(i)
                                                                                Else
                                                                                    StoreOpt(j)
                                                                                End If
                                                                            Else
                                                                                StoreErrorOpt(j)
                                                                            End If
                                                                        Else
                                                                            '--Case completed--
                                                                            StoreOpt(j)
                                                                        End If
                                                                    End If
                                                            End Select
                                                            MedicaidFileList(j).isDone = True
                                                        End If
                                                    Next
                                                End If
                                            End If
                                        End If
                                    Else
                                        '--Just process the 61--
                                        glapiMedicaid.SubmitField(CaseNumberScreen, OPTS61Information.CaseNumber.GetData)
                                        glapiMedicaid.SubmitField(PerNumberScreen, OPTS61Information.PersonNumber.GetData)
                                        glapiMedicaid.TransmitPage()
                                        If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                            StoreErrorOpt(i)
                                        Else
                                            SubmitPage61()
                                            glapiMedicaid.TransmitPage()
                                            If isOPTError() Then
                                                '--Prior to temp what used to be here--
                                                'StoreErrorOpt(i)
                                                '---------------TEMP-------------
                                                If (ErrorMessage1Medi.Substring(0, 10) = "SUPERVISOR" Or ErrorMessage1Medi.Substring(1, 10) = "SUPERVISOR") And OPTS61Information.Supervisor.GetData <> "  " Then
                                                    glapiMedicaid.SubmitField(OPTS61Information.Supervisor.FieldNumber, OPTS61Information.Supervisor.GetData)
                                                    glapiMedicaid.SubmitField(OPTS61Information.Worker61.FieldNumber, OPTS61Information.Worker61.GetData)
                                                    glapiMedicaid.SubmitField(OPTS61Information.PersonAction.FieldNumber, "C")
                                                    glapiMedicaid.TransmitPage()
                                                    If isOPTError() Then
                                                        '--Error in case--
                                                        StoreErrorOpt(i)
                                                    Else
                                                        '--Case completed--
                                                        StoreOpt(i)
                                                    End If
                                                Else
                                                    StoreErrorOpt(i)
                                                End If
                                                '-----------END TEMP------------
                                            Else
                                                '--Case completed--
                                                StoreOpt(i)
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Case "64"
                            glapiMedicaid.SendKeysTransmit("064")
                            glapiMedicaid.SubmitField(CaseNumberScreen, OPTS64Information.CaseNumber.GetData)
                            glapiMedicaid.SubmitField(PerNumberScreen, OPTS64Information.PersonNumber.GetData)
                            glapiMedicaid.TransmitPage()
                            If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                StoreErrorOpt(i)
                            Else
                                SubmitPage64()
                                glapiMedicaid.TransmitPage()
                                If isOPTError() Then
                                    '--Error in case--
                                    StoreErrorOpt(i)
                                Else
                                    '--Case completed--
                                    StoreOpt(i)
                                End If
                            End If
                        Case "66"
                            glapiMedicaid.SendKeysTransmit("066")
                            glapiMedicaid.SubmitField(CaseNumberScreen, OPTS66Information.CaseNumber.GetData)
                            glapiMedicaid.SubmitField(PerNumberScreen, OPTS66Information.PersonNumber.GetData)
                            glapiMedicaid.TransmitPage()
                            If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                StoreErrorOpt(i)
                            Else
                                SubmitPage66()
                                glapiMedicaid.TransmitPage()
                                If isOPTError() Then
                                    '--Error in case--
                                    If glapiMedicaid.GetString(2, 42, 9, 42) = "REDETERM" And OPTS66Information.ActionCode66.GetData = "A" Then
                                        If OPTS66Information.ActionCode66.GetData = "A" Then
                                            glapiMedicaid.SubmitField(OPTS66Information.ActionCode66.FieldNumber, "C")
                                            glapiMedicaid.TransmitPage()
                                            If isOPTError() And glapiMedicaid.GetString(2, 23, 2, 23) <> " " Then
                                                StoreErrorOpt(i)
                                            Else
                                                ErrorMessage1Medi = "          "
                                                ErrorMessage2Medi = ""
                                                StoreOpt(i)
                                            End If
                                        ElseIf OPTS66Information.ActionCode66.GetData = "C" Then
                                            glapiMedicaid.SubmitField(OPTS66Information.ActionCode66.FieldNumber, "A")
                                            glapiMedicaid.TransmitPage()
                                            If isOPTError() And glapiMedicaid.GetString(2, 23, 2, 23) <> " " Then
                                                StoreErrorOpt(i)
                                            Else
                                                ErrorMessage1Medi = "          "
                                                ErrorMessage2Medi = ""
                                                StoreOpt(i)
                                            End If
                                        End If
                                    Else
                                        StoreErrorOpt(i)
                                    End If
                                Else
                                    '--Case completed--
                                    StoreOpt(i)
                                End If
                            End If
                    End Select
                    MedicaidFileList(i).isDone = True
                Else
                    '--GLink error--
                    ErrorMessage2Medi = ""
                    ParentControlScreen.BGW_MediScanDirectory.ReportProgress(8)
                    Exit For
                End If
                Try
                    glapiMedicaid.Disconnect()
                Catch ex As Exception

                End Try
            End If
            Thread.Sleep(1500)
        Next
    End Sub
    Private Sub AddFamily(ByVal FileIndex As Integer)
        Dim FamilyList As New List(Of MedicaidFile)
        Dim ResultList(100) As String
        Dim i, j, k As Integer
        Dim isLoop As Boolean = True
        Dim isFirstRun As Boolean = True
        Dim isHoldChildren As Boolean
        Dim HoldDirectory As New DirectoryInfo(My.Settings.MediDirectory & "\FamilyHolds\")
        Dim FileList() As FileInfo
        Dim tempFile As MedicaidFile
        FamilyList.Add(MedicaidFileList(FileIndex))
        ParentControlScreen.BGW_MediScanDirectory.ReportProgress(20)
        For i = 0 To MaxMedi - 1
            If MedicaidFileList(i).CaseNumber = MedicaidFileList(FileIndex).CaseNumber And i <> FileIndex Then
                FamilyList.Add(MedicaidFileList(i))
            End If
        Next
        FileList = HoldDirectory.GetFiles("*.txt")
        If FileList.Length > 0 Then
            For i = 0 To FileList.Length - 1
                tempFile = New MedicaidFile(My.Settings.MediDirectory & "\FamilyHolds\" & FileList(i).Name)
                If tempFile.CaseNumber = MedicaidFileList(FileIndex).CaseNumber Then
                    If File.Exists(My.Settings.MediDirectory & "\" & FileList(i).Name) Then
                        File.Delete(My.Settings.MediDirectory & "\FamilyHolds\" & FileList(i).Name)
                    Else
                        File.Move(My.Settings.MediDirectory & "\FamilyHolds\" & FileList(i).Name, My.Settings.MediDirectory & "\" & FileList(i).Name)
                        MedicaidFileList(MaxMedi) = New MedicaidFile(My.Settings.MediDirectory & "\" & FileList(i).Name)
                        FamilyList.Add(MedicaidFileList(MaxMedi))
                        MaxMedi += 1
                    End If
                End If
            Next
        End If

        MakeFamilyProcessOrder(FamilyList)

        For i = 0 To FamilyList.Count - 1
            If Not FamilyList(i).isDone Then
                isErrorMedi = False
                MediFile = FamilyList(i).FilePath
                OPTChoice = FamilyList(i).OptScreen
                MediCaseNumber = FamilyList(i).CaseNumber
                MediPersonNumber = FamilyList(i).PersonNumber
                If Not isFirstRun Then ParentControlScreen.BGW_MediScanDirectory.ReportProgress(2)
                If Not isErrorMedi Then
                    Read_TextFile()
                    Thread.Sleep(750)
                    Select Case OPTChoice
                        Case "61"
                            If OPTS61Information.AlienType.GetData = "4" And DateDiff(DateInterval.Month, OPTS61Information.EntryDate, Date.Now) <= 59 Then
                                'If isAlienHold() Then
                                '    isHoldChildren = True
                                '    ResultList(i) = "FAILED"
                                'Else
                                isHoldChildren = False
                                'End If
                            Else
                                isHoldChildren = False
                            End If
                            If Not isHoldChildren Then
                                If isFirstRun Then glapiMedicaid.SendKeysTransmit("061") : isFirstRun = False
                                If OPTS61Information.PersonAction.GetData = "A" Then
                                    '--Process new person with OPT 66 that goes with it--
                                    glapiMedicaid.SubmitField(CaseNumberScreen, OPTS61Information.CaseNumber.GetData)
                                    glapiMedicaid.SubmitField(PerNumberScreen, OPTS61Information.PersonNumber.GetData)
                                    glapiMedicaid.SubmitField(OPTScreen, "061")
                                    glapiMedicaid.TransmitPage()
                                    If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                        '--Error in case--
                                        ResultList(i) = "FAILED"
                                    Else
                                        SubmitPage61()
                                        glapiMedicaid.TransmitPage()
                                        If isOPTError() Then
                                            '--Prior to temp addition what used to be here--
                                            '--Error in case--
                                            'ResultList(i) = "FAILED"
                                            '------------------TEMP------------------------
                                            '--Redundant processing to help along the addition of Supervisor numbers--
                                            If (ErrorMessage1Medi.Substring(0, 10) = "SUPERVISOR" Or ErrorMessage1Medi.Substring(1, 10) = "SUPERVISOR") And OPTS61Information.Supervisor.GetData <> "  " Then
                                                glapiMedicaid.SubmitField(OPTS61Information.Supervisor.FieldNumber, OPTS61Information.Supervisor.GetData)
                                                glapiMedicaid.SubmitField(OPTS61Information.Worker61.FieldNumber, OPTS61Information.Worker61.GetData)
                                                glapiMedicaid.SubmitField(OPTS61Information.PersonAction.FieldNumber, "C")
                                                glapiMedicaid.TransmitPage()
                                                If isOPTError() Then
                                                    '--Error in case--
                                                    ResultList(i) = "FAILED"
                                                Else
                                                    '--Case completed--
                                                    ResultList(i) = "SUCCESS"
                                                    Thread.Sleep(500)
                                                    If i + 1 <= FamilyList.Count - 1 Then
                                                        For j = i + 1 To FamilyList.Count - 1
                                                            If FamilyList(j).CaseNumber = MediCaseNumber And FamilyList(j).PersonNumber = MediPersonNumber Then
                                                                isErrorMedi = False
                                                                MediFile = FamilyList(j).FilePath
                                                                OPTChoice = FamilyList(j).OptScreen
                                                                MediCaseNumber = FamilyList(j).CaseNumber
                                                                MediPersonNumber = FamilyList(j).PersonNumber
                                                                Read_TextFile()
                                                                ParentControlScreen.BGW_MediScanDirectory.ReportProgress(2)
                                                                Select Case OPTChoice
                                                                    Case "64"
                                                                        glapiMedicaid.SubmitField(CaseNumberScreen, OPTS66Information.CaseNumber.GetData)
                                                                        glapiMedicaid.SubmitField(PerNumberScreen, OPTS66Information.PersonNumber.GetData)
                                                                        glapiMedicaid.SubmitField(OPTScreen, "064")
                                                                        glapiMedicaid.TransmitPage()
                                                                        If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                                                            '--Error in case--
                                                                            ResultList(j) = "FAILED"
                                                                        Else
                                                                            SubmitPage64()
                                                                            glapiMedicaid.TransmitPage()
                                                                            If isOPTError() Then
                                                                                '--Error in case--
                                                                                ResultList(j) = "FAILED"
                                                                            Else
                                                                                '--Case completed--
                                                                                ResultList(j) = "SUCCESS"
                                                                            End If
                                                                        End If
                                                                    Case "66"
                                                                        glapiMedicaid.SubmitField(CaseNumberScreen, OPTS66Information.CaseNumber.GetData)
                                                                        glapiMedicaid.SubmitField(PerNumberScreen, OPTS66Information.PersonNumber.GetData)
                                                                        glapiMedicaid.SubmitField(OPTScreen, "066")
                                                                        glapiMedicaid.TransmitPage()
                                                                        If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                                                            '--Error in case--
                                                                            ResultList(j) = "FAILED"
                                                                        Else
                                                                            SubmitPage66()
                                                                            glapiMedicaid.TransmitPage()
                                                                            If isOPTError() Then
                                                                                '--Error in case--
                                                                                If glapiMedicaid.GetString(2, 42, 9, 42) = "REDETERM" And OPTS66Information.ActionCode66.GetData = "A" Then
                                                                                    glapiMedicaid.SubmitField(OPTS66Information.ActionCode66.FieldNumber, "C")
                                                                                    glapiMedicaid.TransmitPage()
                                                                                    If isOPTError() Then
                                                                                        '--Error in case--
                                                                                        ResultList(j) = "FAILED"
                                                                                    Else
                                                                                        ResultList(j) = "SUCCESS"
                                                                                    End If
                                                                                Else
                                                                                    ResultList(j) = "SUCCESS"
                                                                                End If
                                                                            Else
                                                                                '--Case completed--
                                                                                ResultList(j) = "SUCCESS"
                                                                            End If
                                                                        End If
                                                                End Select
                                                                If ResultList(j) = "FAILED" Then ResultList(i) = "FAILED"
                                                                FamilyList(j).isDone = True
                                                            End If
                                                        Next
                                                    End If
                                                    '-----------------END TEMP-------------------------------------------
                                                End If
                                            Else
                                                ResultList(i) = "FAILED"
                                            End If
                                        Else
                                            '--Case completed--
                                            ResultList(i) = "SUCCESS"
                                            Thread.Sleep(500)
                                            If i + 1 <= FamilyList.Count - 1 Then
                                                For j = i + 1 To FamilyList.Count - 1
                                                    If FamilyList(j).CaseNumber = MediCaseNumber And FamilyList(j).PersonNumber = MediPersonNumber Then
                                                        isErrorMedi = False
                                                        MediFile = FamilyList(j).FilePath
                                                        OPTChoice = FamilyList(j).OptScreen
                                                        MediCaseNumber = FamilyList(j).CaseNumber
                                                        MediPersonNumber = FamilyList(j).PersonNumber
                                                        Read_TextFile()
                                                        ParentControlScreen.BGW_MediScanDirectory.ReportProgress(2)
                                                        Select Case OPTChoice
                                                            Case "64"
                                                                glapiMedicaid.SubmitField(CaseNumberScreen, OPTS64Information.CaseNumber.GetData)
                                                                glapiMedicaid.SubmitField(PerNumberScreen, OPTS64Information.PersonNumber.GetData)
                                                                glapiMedicaid.SubmitField(OPTScreen, "064")
                                                                glapiMedicaid.TransmitPage()
                                                                If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                                                    '--Error in case--
                                                                    ResultList(j) = "FAILED"
                                                                Else
                                                                    SubmitPage64()
                                                                    glapiMedicaid.TransmitPage()
                                                                    If isOPTError() Then
                                                                        '--Error in case--
                                                                        ResultList(j) = "FAILED"
                                                                    Else
                                                                        '--Case completed--
                                                                        ResultList(j) = "SUCCESS"
                                                                    End If
                                                                End If
                                                            Case "66"
                                                                glapiMedicaid.SubmitField(CaseNumberScreen, OPTS66Information.CaseNumber.GetData)
                                                                glapiMedicaid.SubmitField(PerNumberScreen, OPTS66Information.PersonNumber.GetData)
                                                                glapiMedicaid.SubmitField(OPTScreen, "066")
                                                                glapiMedicaid.TransmitPage()
                                                                If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                                                    '--Error in case--
                                                                    ResultList(j) = "FAILED"
                                                                Else
                                                                    SubmitPage66()
                                                                    glapiMedicaid.TransmitPage()
                                                                    If isOPTError() Then
                                                                        '--Error in case--
                                                                        If glapiMedicaid.GetString(2, 42, 9, 42) = "REDETERM" And OPTS66Information.ActionCode66.GetData = "A" Then
                                                                            glapiMedicaid.SubmitField(OPTS66Information.ActionCode66.FieldNumber, "C")
                                                                            glapiMedicaid.TransmitPage()
                                                                            If isOPTError() Then
                                                                                '--Error in case--
                                                                                ResultList(j) = "FAILED"
                                                                            Else
                                                                                ResultList(j) = "SUCCESS"
                                                                            End If
                                                                        Else
                                                                            ResultList(j) = "SUCCESS"
                                                                        End If
                                                                    Else
                                                                        '--Case completed--
                                                                        ResultList(j) = "SUCCESS"
                                                                    End If
                                                                End If
                                                        End Select
                                                        If ResultList(j) = "FAILED" Then ResultList(i) = "FAILED"
                                                        FamilyList(j).isDone = True
                                                    End If
                                                Next
                                            End If
                                        End If
                                    End If
                                Else
                                    '--Just process the 61--
                                    glapiMedicaid.SubmitField(CaseNumberScreen, OPTS61Information.CaseNumber.GetData)
                                    glapiMedicaid.SubmitField(PerNumberScreen, OPTS61Information.PersonNumber.GetData)
                                    glapiMedicaid.SubmitField(OPTScreen, "061")
                                    glapiMedicaid.TransmitPage()
                                    If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                        '--Error in case--
                                        If (ErrorMessage1Medi.Substring(0, 10) = "SUPERVISOR" Or ErrorMessage1Medi.Substring(1, 10) = "SUPERVISOR") And OPTS61Information.Supervisor.GetData <> "  " Then
                                            glapiMedicaid.SubmitField(OPTS61Information.Supervisor.FieldNumber, OPTS61Information.Supervisor.GetData)
                                            glapiMedicaid.SubmitField(OPTS61Information.Worker61.FieldNumber, OPTS61Information.Worker61.GetData)
                                            glapiMedicaid.SubmitField(OPTS61Information.PersonAction.FieldNumber, "C")
                                            glapiMedicaid.TransmitPage()
                                            If isOPTError() Then
                                                ResultList(i) = "FAILED"
                                            Else
                                                ResultList(i) = "SUCCESS"
                                            End If
                                        Else
                                            ResultList(i) = "FAILED"
                                        End If
                                    Else
                                        SubmitPage61()
                                        glapiMedicaid.TransmitPage()
                                        If isOPTError() Then
                                            '--Error in case--
                                            ResultList(i) = "FAILED"
                                        Else
                                            '--Case completed--
                                            ResultList(i) = "SUCCESS"
                                        End If
                                    End If
                                End If
                            End If
                        Case "64"
                            glapiMedicaid.SubmitField(CaseNumberScreen, OPTS64Information.CaseNumber.GetData)
                            glapiMedicaid.SubmitField(PerNumberScreen, OPTS64Information.PersonNumber.GetData)
                            glapiMedicaid.SubmitField(OPTScreen, "064")
                            glapiMedicaid.TransmitPage()
                            If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                StoreErrorOpt(i)
                            Else
                                SubmitPage64()
                                glapiMedicaid.TransmitPage()
                                If isOPTError() Then
                                    '--Error in case--
                                    ResultList(i) = "FAILED"
                                Else
                                    '--Case completed--
                                    ResultList(i) = "SUCCESS"
                                End If
                            End If
                        Case "66"
                            glapiMedicaid.SubmitField(CaseNumberScreen, OPTS66Information.CaseNumber.GetData)
                            glapiMedicaid.SubmitField(PerNumberScreen, OPTS66Information.PersonNumber.GetData)
                            glapiMedicaid.SubmitField(OPTScreen, "066")
                            glapiMedicaid.TransmitPage()
                            If isOPTError() And (ErrorMessage1Medi.Substring(0, 10) = " HIGHLIGHT" Or ErrorMessage1Medi.Substring(0, 10) = "HIGHLIGHT ") Then
                                StoreErrorOpt(i)
                            Else
                                SubmitPage66()
                                glapiMedicaid.TransmitPage()
                                If isOPTError() Then
                                    '--Error in case--
                                    If glapiMedicaid.GetString(2, 42, 9, 42) = "REDETERM" And OPTS66Information.ActionCode66.GetData = "A" Then
                                        If OPTS66Information.ActionCode66.GetData = "A" Then
                                            glapiMedicaid.SubmitField(OPTS66Information.ActionCode66.FieldNumber, "C")
                                            glapiMedicaid.TransmitPage()
                                            If isOPTError() And glapiMedicaid.GetString(2, 23, 2, 23) <> " " Then
                                                ResultList(i) = "FAILED"
                                            Else
                                                ErrorMessage1Medi = "          "
                                                ErrorMessage2Medi = ""
                                                ResultList(i) = "SUCCESS"
                                            End If
                                        ElseIf OPTS66Information.ActionCode66.GetData = "C" Then
                                            glapiMedicaid.SubmitField(OPTS66Information.ActionCode66.FieldNumber, "A")
                                            glapiMedicaid.TransmitPage()
                                            If isOPTError() And glapiMedicaid.GetString(2, 23, 2, 23) <> " " Then
                                                ResultList(i) = "FAILED"
                                            Else
                                                ErrorMessage1Medi = "          "
                                                ErrorMessage2Medi = ""
                                                ResultList(i) = "SUCCESS"
                                            End If
                                        End If
                                    Else
                                        ResultList(i) = "FAILED"
                                    End If
                                Else
                                    '--Case completed--
                                    ResultList(i) = "SUCCESS"
                                End If
                            End If
                    End Select
                    If ResultList(i) = "FAILED" Then
                        If isHoldChildren Then ErrorMessage1Medi = " Children not on HMO. Holding case."
                        FamilyList(i).isDone = True
                        OPTChoice = FamilyList(i).OptScreen
                        MediFile = FamilyList(i).FilePath
                        MediCaseNumber = FamilyList(i).CaseNumber
                        MediPersonNumber = FamilyList(i).PersonNumber
                        Read_TextFile()
                        For k = 0 To MaxMedi - 1
                            If FamilyList(i).CaseNumber = MedicaidFileList(k).CaseNumber And FamilyList(i).PersonNumber = MedicaidFileList(k).PersonNumber And FamilyList(i).OptScreen = MedicaidFileList(k).OptScreen Then
                                StoreErrorOpt(k)
                                Thread.Sleep(1000)
                                Exit For
                            End If
                        Next
                        FamilyList(i).isDone = True
                        For j = 0 To FamilyList.Count - 1
                            If j <> i Then
                                ResultList(j) = "FAILED"
                                ErrorMessage1Medi = " Dropped with Family Members."
                                ErrorMessage2Medi = ""
                                FamilyList(j).isDone = True
                                OPTChoice = FamilyList(j).OptScreen
                                MediFile = FamilyList(j).FilePath
                                MediCaseNumber = FamilyList(j).CaseNumber
                                MediPersonNumber = FamilyList(j).PersonNumber
                                Read_TextFile()
                                For k = 0 To MaxMedi - 1
                                    If FamilyList(j).CaseNumber = MedicaidFileList(k).CaseNumber And FamilyList(j).PersonNumber = MedicaidFileList(k).PersonNumber And FamilyList(j).OptScreen = MedicaidFileList(k).OptScreen Then
                                        StoreErrorOpt(k)
                                        Thread.Sleep(1000)
                                        Exit For
                                    End If
                                Next
                            End If
                        Next
                        Exit Sub
                    Else
                        FamilyList(i).isDone = True
                    End If
                End If
            End If
        Next
        Try
            glapiMedicaid.Disconnect()
        Catch ex As Exception

        End Try
        For i = 0 To FamilyList.Count - 1
            If ResultList(i) = "SUCCESS" Then
                FamilyList(i).isDone = True
                OPTChoice = FamilyList(i).OptScreen
                MediFile = FamilyList(i).FilePath
                MediCaseNumber = FamilyList(i).CaseNumber
                MediPersonNumber = FamilyList(i).PersonNumber
                Read_TextFile()
                For j = 0 To MaxMedi - 1
                    If FamilyList(i).CaseNumber = MedicaidFileList(j).CaseNumber And FamilyList(i).PersonNumber = MedicaidFileList(j).PersonNumber And FamilyList(i).OptScreen = MedicaidFileList(j).OptScreen Then
                        StoreOpt(j)
                        Thread.Sleep(1000)
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub MakeProcessOrder()
        Dim i, j As Integer
        ProcessFileOrder.Clear()
        For i = 0 To MaxMedi - 1
            If Not MedicaidFileList(i).isChecked Then
                If MedicaidFileList(i).OptScreen = "61" And (MedicaidFileList(i).PersonNumber = "01" Or MedicaidFileList(i).PersonNumber = "02" Or MedicaidFileList(i).PersonNumber = "05") Then
                    ProcessFileOrder.Add(MedicaidFileList(i))
                    MedicaidFileList(i).isChecked = True
                    For j = i + 1 To MaxMedi - 1
                        '--Compare every case with 'i' file and see if theres and OP 64 or 66 to go with it--
                        If Not MedicaidFileList(j).isChecked And MedicaidFileList(j).CaseNumber = MedicaidFileList(i).CaseNumber And MedicaidFileList(j).PersonNumber = MedicaidFileList(i).PersonNumber Then
                            ProcessFileOrder.Add(MedicaidFileList(j))
                            MedicaidFileList(j).isChecked = True
                        End If
                    Next
                End If
            End If
        Next
        For i = 0 To MaxMedi - 1
            If Not MedicaidFileList(i).isChecked Then
                ProcessFileOrder.Add(MedicaidFileList(i))
                MedicaidFileList(i).isChecked = True
            End If
        Next
        For i = 0 To MaxMedi - 1
            MedicaidFileList(i) = ProcessFileOrder(i)
        Next
    End Sub
    Private Sub MakeFamilyProcessOrder(ByVal FamilyList As List(Of MedicaidFile))
        Dim i, j As Integer
        ProcessFileOrder.Clear()
        For i = 0 To FamilyList.Count - 1
            FamilyList(i).isChecked = False
        Next
        For i = 0 To FamilyList.Count - 1
            If Not FamilyList(i).isChecked Then
                If FamilyList(i).OptScreen = "61" And (FamilyList(i).PersonNumber = "01" Or FamilyList(i).PersonNumber = "02" Or FamilyList(i).PersonNumber = "05") Then
                    ProcessFileOrder.Add(FamilyList(i))
                    FamilyList(i).isChecked = True
                    For j = i + 1 To FamilyList.Count - 1
                        '--Compare every case with 'i' file and see if theres and OP 64 or 66 to go with it--
                        If Not FamilyList(j).isChecked And FamilyList(j).CaseNumber = FamilyList(i).CaseNumber And FamilyList(j).PersonNumber = FamilyList(i).PersonNumber Then
                            ProcessFileOrder.Add(FamilyList(j))
                            FamilyList(j).isChecked = True
                        End If
                    Next
                End If
            End If
        Next
        For i = 0 To FamilyList.Count - 1
            If Not FamilyList(i).isChecked And FamilyList(i).OptScreen = "61" Then
                ProcessFileOrder.Add(FamilyList(i))
                FamilyList(i).isChecked = True
                For j = i + 1 To FamilyList.Count - 1
                    '--Compare every case with 'i' file and see if theres and OP 64 or 66 to go with it--
                    If Not FamilyList(j).isChecked And FamilyList(j).CaseNumber = FamilyList(i).CaseNumber And FamilyList(j).PersonNumber = FamilyList(i).PersonNumber Then
                        ProcessFileOrder.Add(FamilyList(j))
                        FamilyList(j).isChecked = True
                    End If
                Next
            End If
        Next
        For i = 0 To FamilyList.Count - 1
            If Not FamilyList(i).isChecked Then
                ProcessFileOrder.Add(FamilyList(i))
                FamilyList(i).isChecked = True
            End If
        Next
        For i = 0 To FamilyList.Count - 1
            FamilyList(i) = ProcessFileOrder(i)
        Next
    End Sub

    Private Sub StoreErrorOpt(ByVal index As Integer)
        ParentControlScreen.BGW_MediScanDirectory.ReportProgress(3)
        If OPTChoice = "66" And (ErrorMessage1Medi = " CANNOT ADD REDETRMIN WITHOUT PERS " Or ErrorMessage2Medi = " CANNOT ADD REDETRMIN WITHOUT PERS " Or ErrorMessage1Medi = " PERSON NUMBER NOT FOUND           ") Then
            If DateDiff(DateInterval.Day, File.GetLastWriteTime(MediFile), Date.Today, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 4 Then
                If File.Exists(My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName) Then File.Delete(My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName)
                File.Move(MediFile, My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName)
                ErrorMessage1Medi = "Person not on server. Holding case."
                ErrorMessage2Medi = ""
                ParentControlScreen.BGW_MediScanDirectory.ReportProgress(6)
            Else
                If File.Exists(My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName) Then File.Delete(My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName)
                File.Move(MediFile, My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName)
                ParentControlScreen.BGW_MediScanDirectory.ReportProgress(5)
            End If
        ElseIf OPTChoice = "61" And ErrorMessage1Medi = " Children not on HMO. Holding case." Then
            ErrorMessage2Medi = ""
            If File.Exists(My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName) Then File.Delete(My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName)
            File.Move(MediFile, My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName)
            ParentControlScreen.BGW_MediScanDirectory.ReportProgress(6)
        ElseIf OPTChoice = "64" And ErrorMessage1Medi = " CANNOT ADD SPEC PGM WITHOUT PERS  " Then
            If DateDiff(DateInterval.Day, File.GetLastWriteTime(MediFile), Date.Today, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1) < 4 Then
                If File.Exists(My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName) Then File.Delete(My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName)
                File.Move(MediFile, My.Settings.MediDirectory & "\Holds\" & MedicaidFileList(index).FileName)
                ErrorMessage1Medi = "Person not on server. Holding case."
                ErrorMessage2Medi = ""
                ParentControlScreen.BGW_MediScanDirectory.ReportProgress(6)
            Else
                If File.Exists(My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName) Then File.Delete(My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName)
                File.Move(MediFile, My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName)
                ParentControlScreen.BGW_MediScanDirectory.ReportProgress(5)
            End If
        Else
            If File.Exists(My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName) Then File.Delete(My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName)
            File.Move(MediFile, My.Settings.MediDropDirectory & "\" & MedicaidFileList(index).FileName)
            ParentControlScreen.BGW_MediScanDirectory.ReportProgress(5)
        End If
        If OPTChoice = "61" Then StoreSQL61()
        If OPTChoice = "64" Then StoreSQL64()
        If OPTChoice = "66" Then StoreSQL66()
        Thread.Sleep(500)
        StoreResult("FAILED")
    End Sub
    Private Sub StoreOpt(ByVal index As Integer)
        Dim DatePath As String = Date.Now.Month & "_" & Date.Now.Day & "_" & Date.Now.Year
        If Not Directory.Exists(My.Application.Info.DirectoryPath & "\Medicaid Files\" & DatePath & "\") Then Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\Medicaid Files\" & DatePath & "\")
        If File.Exists(My.Application.Info.DirectoryPath & "\Medicaid Files\" & DatePath & "\" & MedicaidFileList(index).FileName) Then File.Delete(My.Application.Info.DirectoryPath & "\Medicaid Files\" & DatePath & "\" & MedicaidFileList(index).FileName)
        File.Move(MediFile, My.Application.Info.DirectoryPath & "\Medicaid Files\" & DatePath & "\" & MedicaidFileList(index).FileName)
        If OPTChoice = "61" Then StoreSQL61()
        If OPTChoice = "64" Then StoreSQL64()
        If OPTChoice = "66" Then StoreSQL66()
        Thread.Sleep(500)
        StoreResult("SUCCESS")
        ParentControlScreen.BGW_MediScanDirectory.ReportProgress(4)
    End Sub
    Private Function isAlienHold()
        Dim PersonNum As Integer = "20"
        Dim isHold As Boolean = True
        glapiMedicaid.SendKeysTransmit("078")
        glapiMedicaid.SubmitField(CaseNumberScreen, OPTS61Information.CaseNumber.GetData)
        glapiMedicaid.SubmitField(PerNumberScreen - 1, PersonNum)
        glapiMedicaid.TransmitPage()
        If glapiMedicaid.GetString(2, 42, 24, 42) = "PERSON NUMBER NOT FOUND" Or glapiMedicaid.GetString(2, 42, 24, 42) = "MHC DATA NOT FOUND     " Then
            isHold = False
            PersonNum += 1
            glapiMedicaid.SubmitField(CaseNumberScreen, OPTS61Information.CaseNumber.GetData)
            glapiMedicaid.SubmitField(PerNumberScreen - 1, PersonNum)
            glapiMedicaid.TransmitPage()
        ElseIf glapiMedicaid.GetString(2, 42, 24, 42) = "CASE NUMBER NOT FOUND  " Then
            isHold = False
            glapiMedicaid.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F2)
            Return isHold
        End If
        While glapiMedicaid.GetString(2, 42, 24, 42) <> "PERSON NUMBER NOT FOUND"
            If glapiMedicaid.GetString(3, 28, 5, 28) <> "   " Then
                If glapiMedicaid.GetString(16, 28, 23, 28) = "        " Then
                    isHold = False
                    Exit While
                Else
                    isHold = True
                End If
            Else
                isHold = True
            End If
            PersonNum += 1
            glapiMedicaid.SubmitField(CaseNumberScreen, OPTS61Information.CaseNumber.GetData)
            glapiMedicaid.SubmitField(PerNumberScreen - 1, PersonNum)
            glapiMedicaid.TransmitPage()
        End While
        glapiMedicaid.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F3)
        PersonNum = 49
        glapiMedicaid.SubmitField(CaseNumberScreen, OPTS61Information.CaseNumber.GetData)
        glapiMedicaid.SubmitField(PerNumberScreen - 1, PersonNum)
        glapiMedicaid.TransmitPage()
        If glapiMedicaid.GetString(2, 42, 24, 42) <> "PERSON NUMBER NOT FOUND" Then
            If glapiMedicaid.GetString(3, 28, 5, 28) <> "   " Then
                If glapiMedicaid.GetString(16, 28, 23, 28) = "        " Then
                    isHold = False
                Else
                    isHold = True
                End If
            Else
                isHold = True
            End If
        End If
        glapiMedicaid.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F2)
        Return isHold
    End Function

    Private Sub Read_TextFile()
        Try
            Dim infile As New StreamReader(MediFile, System.Text.Encoding.Default)
            Dim Records As String
            While infile.Peek <> -1
                Records = infile.ReadLine()
                If Records <> Nothing Then
                    If OPTChoice = "61" Then setOPT61Block(Records)
                    If OPTChoice = "64" Then setOPT64Block(Records)
                    If OPTChoice = "66" Then setOPT66Block(Records)
                End If
            End While
            infile.Close()
        Catch ex As Exception
            MessageBox.Show("Location: ReadTextFile Medicaid" & vbCrLf & ex.Message.ToString)
        End Try
    End Sub
    Private Sub setOPT61Block(ByVal Records As String)
        Dim i As Integer
        Dim temp As String
        OPTS61Information = New OPTS61Data
        With OPTS61Information
            setBlockDataMedi(.CaseNumber, Records)
            setBlockDataMedi(.PersonNumber, Records)
            setBlockDataMedi(.BatchNumber, Records)
            setBlockDataMedi(.ActionCode, Records)
            setBlockDataMedi(.Office, Records)
            .Office.SetData("5163")
            setBlockDataMedi(.ProviderWarning, Records)
            setBlockDataMedi(.CaseName, Records)
            setBlockDataMedi(.Address, Records)
            setBlockDataMedi(.City, Records)
            setBlockDataMedi(.State, Records)
            setBlockDataMedi(.Zip, Records)
            setBlockDataMedi(.LastName, Records)
            setBlockDataMedi(.FirstName, Records)
            setBlockDataMedi(.Middle, Records)
            setBlockDataMedi(.DateOfBirth, Records)
            setBlockDataMedi(.SocSec, Records)
            setBlockDataMedi(.Sex, Records)
            setBlockDataMedi(.MaritalStat, Records)
            setBlockDataMedi(.Race, Records)
            setBlockDataMedi(.PriorCase, Records)
            setBlockDataMedi(.PriorPerNumber, Records)
            If .PriorPerNumber.GetData = "pt" Then .PriorPerNumber.SetData("  ")
            setBlockDataMedi(.AlienType, Records)
            setBlockDataMedi(.tempDate, Records)
            If .tempDate.GetData <> "        " Then
                temp = .tempDate.GetData.Insert(2, "/")
                temp = temp.Insert(5, "/")
                .EntryDate = temp
            End If
            setBlockDataMedi(.EligSeg, Records)
            For i = 0 To 5
                setBlockDataMedi61(.EffDate(i), Records, i)
                setBlockDataMedi61(.TermDate(i), Records, i)
                setBlockDataMedi61(.AddCode(i), Records, i)
                setBlockDataMedi61(.TRMCode(i), Records, i)
                setBlockDataMedi61(.PGM(i), Records, i)
                setBlockDataMedi61(.SUPV(i), Records, i)
                setBlockDataMedi61(.RES(i), Records, i)
                setBlockDataMedi61(.ExtType(i), Records, i)
                setBlockDataMedi61(.PregDueDate(i), Records, i)
            Next
            setBlockDataMedi(.AddressAction, Records)
            setBlockDataMedi(.PersonAction, Records)
            setBlockDataMedi(.Address2, Records)
            .Address3.SetData("                      ")
            .Address4.SetData("                      ")
            setBlockDataMedi(.Supervisor, Records) '--Added 4/14/08 by State--
            setBlockDataMedi(.Worker61, Records) '--Added 4/14/08 by State--
        End With
    End Sub
    Private Sub setOPT64Block(ByVal Records As String)
        Dim i As Integer
        OPTS64Information = New OPTS64Data
        With OPTS64Information
            setBlockDataMedi(.ActionCode64, Records)
            setBlockDataMedi(.CaseNumber, Records)
            setBlockDataMedi(.PersonNumber, Records)
            For i = 0 To 5
                setBlockDataMedi64(.PGMNum(i), Records, i)
                setBlockDataMedi64(.EffDate64(i), Records, i)
                setBlockDataMedi64(.TermDate64(i), Records, i)
            Next
        End With
    End Sub
    Private Sub setOPT66Block(ByVal Records As String)
        OPTS66Information = New OPTS66Data
        With OPTS66Information
            setBlockDataMedi(.CaseNumber, Records)
            setBlockDataMedi(.PersonNumber, Records)
            setBlockDataMedi(.SUPV66, Records)
            setBlockDataMedi(.Worker, Records)
            setBlockDataMedi(.ProgramStatus, Records)
            setBlockDataMedi(.CaseRedetDate, Records)
            .CaseRedetDate.SetData(.CaseRedetDate.GetData.Remove(2, 2))
            setBlockDataMedi(.DisabilityRedetDate, Records)
            .DisabilityRedetDate.SetData(.DisabilityRedetDate.GetData.Remove(2, 2))
            setBlockDataMedi(.ActionCode66, Records)
        End With
    End Sub
    Private Sub setBlockDataMedi(ByRef BLOCK As MedicaidBlock, ByVal Record As String)
        BLOCK.SetData(Record.Substring(BLOCK.StartIndex, BLOCK.Length))
    End Sub
    Private Sub setBlockDataMedi61(ByRef BLOCK As MedicaidBlock, ByVal Record As String, ByVal Index As Integer)
        BLOCK.SetData(Record.Substring(BLOCK.StartIndex + (64 * Index), BLOCK.Length))
        BLOCK.FieldNumber += 16 * Index
    End Sub
    Private Sub setBlockDataMedi64(ByRef BLOCK As MedicaidBlock, ByVal Record As String, ByVal Index As Integer)
        BLOCK.SetData(Record.Substring(BLOCK.StartIndex + (27 * Index), BLOCK.Length))
        BLOCK.FieldNumber += 6 * Index
    End Sub

    Private Sub StoreSQL61()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Try
            SQLConn.Open()
            With OPTS61Information
                SQLComm.Connection = SQLConn
                SQLComm.CommandText = "DELETE FROM OPS61 WHERE CASENUMBER = '" & .CaseNumber.GetData & "' AND PERSONNUMBER = '" & .PersonNumber.GetData & "'"
                SQLComm.ExecuteNonQuery()

                SQLComm.CommandText = "INSERT INTO OPS61 VALUES ('" & .CaseNumber.GetData & "', '" & .PersonNumber.GetData & "', '" & .BatchNumber.GetData & "', '" & .ActionCode.GetData & "', '" & .Office.GetData & "', '" & .ProviderWarning.GetData & "', '" & .CaseName.GetData & "', '" & .Address.GetData & "', '" & .City.GetData & "', '" & .State.GetData & "', '" & .Zip.GetData & "', '" & .LastName.GetData & "', '" & .FirstName.GetData & "', '" & .Middle.GetData & "', '" & .DateOfBirth.GetData & "', '" & .SocSec.GetData & "', '" & .Sex.GetData & "', '" & .MaritalStat.GetData & "', '" & .Race.GetData & "', '" & .PriorCase.GetData & "', '" & .PriorPerNumber.GetData & "', '" & .AlienType.GetData & "', '" & .tempDate.GetData & "', '" & .EligSeg.GetData & "', '" & .EffDate(0).GetData & "', '" & .TermDate(0).GetData & "', '" & .AddCode(0).GetData & "', '" & .TRMCode(0).GetData & "', '" & .PGM(0).GetData & "', '" & .SUPV(0).GetData & "', '" & .RES(0).GetData & "', '" & .ExtType(0).GetData & "', '" & .PregDueDate(0).GetData & "', '" & .EffDate(1).GetData & "', '" & .TermDate(1).GetData & "', '" & .AddCode(1).GetData & "', '" & .TRMCode(1).GetData & "', '" & .PGM(1).GetData & "', '" & .SUPV(1).GetData & "', '" & .RES(1).GetData & "', '" & .ExtType(1).GetData & "', '" & .PregDueDate(1).GetData & "', '" & .EffDate(2).GetData & "', '" & .TermDate(2).GetData & "', '" & .AddCode(2).GetData & "', '" & .TRMCode(2).GetData & "', '" & .PGM(2).GetData & "', '" & .SUPV(2).GetData & "', '" & .RES(2).GetData & "', '" & .ExtType(2).GetData & "', '" & .PregDueDate(2).GetData & "', '" & .EffDate(3).GetData & "', '" & .TermDate(3).GetData & "', '" & .AddCode(3).GetData & "', '" & .TRMCode(3).GetData & "', '" & .PGM(3).GetData & "', '" & .SUPV(3).GetData & "', '" & .RES(3).GetData & "', '" & .ExtType(3).GetData & "', '" & .PregDueDate(3).GetData & "', '" & .EffDate(4).GetData & "', '" & .TermDate(4).GetData & "', '" & .AddCode(4).GetData & "', '" & .TRMCode(4).GetData & "', '" & .PGM(4).GetData & "', '" & .SUPV(4).GetData & "', '" & .RES(4).GetData & "', '" & .ExtType(4).GetData & "', '" & .PregDueDate(4).GetData & "', '" & .EffDate(5).GetData & "', '" & .TermDate(5).GetData & "', '" & .AddCode(5).GetData & "', '" & .TRMCode(5).GetData & "', '" & .PGM(5).GetData & "', '" & .SUPV(5).GetData & "', '" & .RES(5).GetData & "', '" & .ExtType(5).GetData & "', '" & .PregDueDate(5).GetData & "', '" & .AddressAction.GetData & "', '" & .PersonAction.GetData & "', '" & .Supervisor.GetData & "', '" & .Worker61.GetData & "')"
                SQLComm.ExecuteNonQuery()
            End With
        Catch ex As Exception
            MessageBox.Show("Location: StoreSQL61" & vbCrLf & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub StoreSQL64()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Try
            With OPTS64Information
                SQLConn.Open()
                SQLComm.Connection = SQLConn
                SQLComm.CommandText = "DELETE FROM OPS64 WHERE CASENUMBER = '" & .CaseNumber.GetData & "' AND PERSONNUMBER = '" & .PersonNumber.GetData & "'"
                SQLComm.ExecuteNonQuery()

                SQLComm.CommandText = "INSERT INTO OPS64 VALUES ('" & .CaseNumber.GetData & "', '" & .PersonNumber.GetData & "', '" & .ActionCode64.GetData & "', '" & .PGMNum(0).GetData & "', '" & .EffDate64(0).GetData & "', '" & .TermDate64(0).GetData & "', '" & .PGMNum(1).GetData & "', '" & .EffDate64(1).GetData & "', '" & .TermDate64(1).GetData & "', '" & .PGMNum(2).GetData & "', '" & .EffDate64(2).GetData & "', '" & .TermDate64(2).GetData & "', '" & .PGMNum(3).GetData & "', '" & .EffDate64(3).GetData & "', '" & .TermDate64(3).GetData & "', '" & .PGMNum(4).GetData & "', '" & .EffDate64(4).GetData & "', '" & .TermDate64(4).GetData & "', '" & .PGMNum(5).GetData & "', '" & .EffDate64(5).GetData & "', '" & .TermDate64(5).GetData & "')"
                SQLComm.ExecuteNonQuery()
            End With
        Catch ex As Exception
            MessageBox.Show("Location: StoreSQL64" & vbCrLf & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub StoreSQL66()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Try
            With OPTS66Information
                SQLConn.Open()
                SQLComm.Connection = SQLConn
                SQLComm.CommandText = "DELETE FROM OPS66 WHERE CASENUMBER = '" & .CaseNumber.GetData & "' AND PERSONNUMBER = '" & .PersonNumber.GetData & "'"
                SQLComm.ExecuteNonQuery()

                SQLComm.CommandText = "INSERT INTO OPS66 VALUES ('" & .CaseNumber.GetData & "', '" & .PersonNumber.GetData & "', '    ', '" & .LastName.GetData & "', '" & .FirstName.GetData & "', '" & .DateOfBirth.GetData & "', '" & .ActionCode66.GetData & "', '" & .SUPV66.GetData & "', '" & .Worker.GetData & "', '" & .ProgramStatus.GetData & "', '" & .CaseRedetDate.GetData & "', '" & .DisabilityRedetDate.GetData & "')"
                SQLComm.ExecuteNonQuery()
            End With
        Catch ex As Exception
            MessageBox.Show("Location: StoreSQL66" & vbCrLf & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub
    Private Sub StoreResult(ByVal Result As String)
        Dim Worker As String = MediFile.Substring(MediFile.LastIndexOf("\") + 1).Substring(20, 6) 'MediFile.Substring(My.Settings.MediDirectory.Length + 1).Substring(20, 6)
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim isReported As Boolean
        Dim DateEntered As String = Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year
        Worker = Worker.Replace(".", "").Replace("T", "").Replace("t", "")
        Worker = Worker.Replace("x", "")
        Worker = Worker.Replace("X", "")
        If Result = "SUCCESS" Then isReported = False Else If Result = "FAILED" Then isReported = True
        Try
            SQLConn.Open()
            SQLComm.Connection = SQLConn
            SQLComm.CommandText = "DELETE FROM TransactionLog WHERE CaseNumber = '" & MediCaseNumber & "' AND DateEntered = '" & DateEntered & "' AND PersonNumber = '" & MediPersonNumber & "' and OPS = '" & OPTChoice & "'"
            SQLComm.ExecuteNonQuery()
            SQLComm.CommandText = "INSERT INTO TransactionLog VALUES ('" & MediCaseNumber & "', '" & MediFile.Substring(My.Settings.MediDirectory.Length + 1) & "', '" & DateEntered & "', '" & Worker & "', '" & OPTChoice & "', '" & MediPersonNumber & "',  '" & Result & "', '" & ErrorMessage1Medi & ErrorMessage2Medi & "', 'SERVER', '" & isReported & "')"
            SQLComm.ExecuteNonQuery()                                                               '.Substring(My.Settings.MediDirectory.Length + 1)
        Catch ex As Exception
            MessageBox.Show("Location: StoreResult" & vbCrLf & ex.Message.ToString)
        Finally
            SQLConn.Close()
        End Try
    End Sub

    Private Function isOPTError() As Boolean
        If glapiMedicaid.GetString(1, 42, 10, 42) <> "          " And glapiMedicaid.GetString(1, 42, 10, 42) <> " NO RDET D" And glapiMedicaid.GetString(2, 42, 8, 42) <> "DEPRESS" And glapiMedicaid.GetString(2, 42, 8, 42) <> "MORE DA" And glapiMedicaid.GetString(1, 42, 10, 42) <> " NO SPEC P" And glapiMedicaid.GetString(2, 42, 6, 42) <> "DEATH" Then
            ErrorMessage1Medi = glapiMedicaid.GetString(1, 42, 35, 42)
            ErrorMessage2Medi = glapiMedicaid.GetString(36, 42, 69, 42)
            If ErrorMessage2Medi.Substring(10, 20) = "                    " Then ErrorMessage2Medi = Nothing
            Return True
        ElseIf glapiMedicaid.GetString(1, 41, 10, 41) <> "          " And (glapiMedicaid.GetString(1, 41, 3, 41) <> "PF3" And glapiMedicaid.GetString(2, 41, 4, 41) <> "PF3") Then
            ErrorMessage1Medi = glapiMedicaid.GetString(1, 41, 35, 41)
            ErrorMessage2Medi = glapiMedicaid.GetString(36, 41, 69, 41)
            If ErrorMessage2Medi.Substring(10, 20) = "                    " Then ErrorMessage2Medi = Nothing
            Return True
        Else
            ErrorMessage1Medi = "          "
            ErrorMessage2Medi = ""
            Return False
        End If
    End Function

    Private Sub GLinkStartMedi()
        Dim isLoop As Boolean = True
        Dim RetryCounter As Integer = 0
        Dim Timeout As Integer = 0
        While isLoop
            glapiMedicaid = New connGLinkTP8("C:\GlPro\PhoenixMedi.02")
            glapiMedicaid.bool_Visible = True
            If glapiMedicaid.isConnect() Then
                glapiMedicaid.SendKeysTransmit("LABCICSZ")
                While glapiMedicaid.GetString(7, 12, 13, 12) <> "LOGONID"
                    Thread.Sleep(750)
                End While
                Thread.Sleep(500)
                glapiMedicaid.SubmitField(16, My.Settings.MediOperator)
                glapiMedicaid.SubmitField(19, My.Settings.MediPassword)
                glapiMedicaid.TransmitPage()
                If glapiMedicaid.GetString(1, 20, 3, 20) = "ACF" Then
                    ErrorMessage1Medi = glapiMedicaid.GetString(10, 20, 65, 20)
                    If ErrorMessage1Medi.Substring(0, 3) = "R94" Then ErrorMessage1Medi = glapiMedicaid.GetString(10, 21, 65, 21)
                    isErrorMedi = True
                End If
                If Not isErrorMedi Then
                    While glapiMedicaid.GetString(1, 4, 3, 4) <> "ACF"
                        Thread.Sleep(500)
                        Timeout += 1
                        If Timeout = 30 Then isErrorMedi = True : Exit While
                    End While
                    If Not isErrorMedi Then
                        glapiMedicaid.SendKeysTransmit("ELIG")
                        Thread.Sleep(500)
                        glapiMedicaid.SendKeysTransmit("05")
                        isLoop = False
                    End If
                End If
            Else
                RetryCounter += 1
                isLoop = True
                KillGLink()
                If RetryCounter > 30 Then
                    isErrorMedi = True
                    isLoop = False
                    'MessageBox.Show("Location: GLinkStart" & vbCrLf & "Cannot connect to Medicaid!" & vbCrLf & "Please close all Medicaid Screens and try again.", "Phoenix - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    KillGLink() '--Changed 1/2/2008 Removed above line and kill all GLink windows--
                    '--Potential to destroy IMPS GLink session--
                End If
            End If
            If isErrorMedi Then
                isLoop = False
                KillGLink()
            End If
        End While
    End Sub
    Private Sub KillGLink()
        Dim GLProcess() As Process
        Dim ProcessToKill As Process
        Dim i As Integer
        GLProcess = Process.GetProcessesByName("gl")
        If GLProcess.Length > 0 Then
            ProcessToKill = GLProcess(0)
            For i = 0 To GLProcess.Length - 1
                If GLProcess(i).StartTime > ProcessToKill.StartTime Then ProcessToKill = GLProcess(i)
            Next
            ProcessToKill.Kill()
        End If
    End Sub
    Private Sub SubmitPage61()
        Dim i, x As Integer
        Dim LineToEnter1, LineToEnter2 As Integer   '--Represents what line in GLink to enter the data to--
        Dim SegIndex(2) As Integer
        Thread.Sleep(500)
        With OPTS61Information
            If .ActionCode.GetData <> " " Then
                glapiMedicaid.SubmitField(.ActionCode.FieldNumber, .ActionCode.GetData)
                glapiMedicaid.SubmitField(.Office.FieldNumber, "5163")
            End If
            If .AddressAction.GetData <> " " Then
                glapiMedicaid.SubmitField(.AddressAction.FieldNumber, .AddressAction.GetData)
                glapiMedicaid.SubmitField(.CaseName.FieldNumber, .CaseName.GetData)
                If .Address2.GetData = "                    " Then
                    glapiMedicaid.SubmitField(.Address2.FieldNumber, .Address.GetData)
                    glapiMedicaid.SubmitField(.Address.FieldNumber, .Address2.GetData)
                Else
                    glapiMedicaid.SubmitField(.Address2.FieldNumber, .Address2.GetData)
                    glapiMedicaid.SubmitField(.Address.FieldNumber, .Address.GetData)
                End If
                glapiMedicaid.SubmitField(.Address3.FieldNumber, .Address3.GetData)
                glapiMedicaid.SubmitField(.Address4.FieldNumber, .Address4.GetData)
                glapiMedicaid.SubmitField(.City.FieldNumber, .City.GetData)
                glapiMedicaid.SubmitField(.State.FieldNumber, .State.GetData)
                glapiMedicaid.SubmitField(.Zip.FieldNumber, .Zip.GetData)
            End If
            If .PersonAction.GetData <> " " Then
                glapiMedicaid.SubmitField(.PersonAction.FieldNumber, .PersonAction.GetData)
                glapiMedicaid.SubmitField(.LastName.FieldNumber, .LastName.GetData)
                glapiMedicaid.SubmitField(.FirstName.FieldNumber, .FirstName.GetData)
                glapiMedicaid.SubmitField(.Middle.FieldNumber, .Middle.GetData)
                glapiMedicaid.SubmitField(.DateOfBirth.FieldNumber, .DateOfBirth.GetData)
                glapiMedicaid.SubmitField(.SocSec.FieldNumber, .SocSec.GetData)
                glapiMedicaid.SubmitField(.Sex.FieldNumber, .Sex.GetData)
                glapiMedicaid.SubmitField(.MaritalStat.FieldNumber, .MaritalStat.GetData)
                glapiMedicaid.SubmitField(.Race.FieldNumber, .Race.GetData)
                glapiMedicaid.SubmitField(.PriorCase.FieldNumber, .PriorCase.GetData)
                glapiMedicaid.SubmitField(.PriorPerNumber.FieldNumber, .PriorPerNumber.GetData)
                glapiMedicaid.SubmitField(.AlienType.FieldNumber, .AlienType.GetData)
                glapiMedicaid.SubmitField(.tempDate.FieldNumber, .tempDate.GetData)
                glapiMedicaid.SubmitField(.Supervisor.FieldNumber, .Supervisor.GetData) '--Added 4/14/08 by State--
                glapiMedicaid.SubmitField(.Worker61.FieldNumber, .Worker61.GetData) '--Added 4/14/08 by State--
            End If
            If .EligSeg.GetData <> " " Then
                glapiMedicaid.SubmitField(.EligSeg.FieldNumber, .EligSeg.GetData)
                For i = 0 To 5
                    If .EffDate(5 - i).GetData <> "        " Then
                        If 5 - i > 0 Then
                            LineToEnter1 = 5 - i - 1
                            LineToEnter2 = 5 - i
                        Else
                            LineToEnter1 = 0
                            LineToEnter2 = 0
                        End If
                        Exit For
                    End If
                Next
                Dim tempTermDate1, tempTermDate2 As Date
                If .TermDate(LineToEnter1).GetData <> "        " Then tempTermDate1 = .TermDate(LineToEnter1).GetData.Insert(2, "/").Insert(5, "/")
                If .TermDate(LineToEnter2).GetData <> "        " Then tempTermDate2 = .TermDate(LineToEnter2).GetData.Insert(2, "/").Insert(5, "/")
                If glapiMedicaid.GetString(3, 26, 10, 26) <> "        " And LineToEnter2 > 0 Then
                    '--Entering more then one line--
                    If LineToEnter1 > 0 Then
                        x = 0
                        For i = 0 To LineToEnter2
                            If glapiMedicaid.GetString(3, 26, 10, 26) = .EffDate(i).GetData Then
                            ElseIf glapiMedicaid.GetString(3, 27, 10, 27) = .EffDate(i).GetData Then
                            ElseIf glapiMedicaid.GetString(3, 28, 10, 28) = .EffDate(i).GetData Then
                            ElseIf glapiMedicaid.GetString(3, 29, 10, 29) = .EffDate(i).GetData Then
                            ElseIf glapiMedicaid.GetString(3, 30, 10, 30) = .EffDate(i).GetData Then
                            ElseIf glapiMedicaid.GetString(3, 31, 10, 31) = .EffDate(i).GetData Then
                            Else
                                SegIndex(x) = i
                                x += 1
                                If x > 1 Then Exit For
                            End If
                        Next
                        If SegIndex(1) <> Nothing Then
                            If .TermDate(SegIndex(0)).GetData = "        " Then
                                SubmitEligSeg(0, SegIndex(0), False)
                                SubmitEligSeg(1, SegIndex(1), False)
                            Else
                                SubmitEligSeg(0, SegIndex(1), False)
                                SubmitEligSeg(1, SegIndex(0), False)
                            End If
                        ElseIf SegIndex(0) <> Nothing Then
                            SubmitEligSeg(1, SegIndex(0), False)
                        Else
                            If glapiMedicaid.GetString(12, 26, 19, 26) = "        " And .TermDate(0).GetData <> "        " Then
                                '--Term date in GUMP file at top--
                                SubmitEligSeg(2, 0, True)
                            Else
                                '--Term date in GUMP file at bottom--
                                SubmitEligSeg(2, LineToEnter2, True)
                            End If
                        End If
                    ElseIf .EffDate(LineToEnter2).GetData = glapiMedicaid.GetString(3, 26, 10, 26) Then
                        '--If the botton line is the same on Medicaid enter both lines--
                        '--(Two Lines)--
                        If .TermDate(LineToEnter2).GetData = "        " Then
                            SubmitEligSeg(1, LineToEnter2, False)
                            SubmitEligSeg(2, LineToEnter1, False)
                        ElseIf .TermDate(LineToEnter2).GetData = glapiMedicaid.GetString(12, 26, 19, 26) Then
                            '--Same information on second line--
                            '--Just add top line (new eligibility)--
                            SubmitEligSeg(1, LineToEnter1, False)
                        Else
                            '--Just add termdate--
                            SubmitEligSeg(2, LineToEnter2, True)
                        End If
                    ElseIf .EffDate(LineToEnter1).GetData = glapiMedicaid.GetString(3, 26, 10, 26) Then
                        If .TermDate(LineToEnter1).GetData = glapiMedicaid.GetString(12, 26, 19, 26) Then
                            SubmitEligSeg(1, LineToEnter2, False)
                        Else
                            '--If the top line is the same as the top line in Medicaid just add termination--
                            '--(One Line)--
                            SubmitEligSeg(1, LineToEnter2, False)
                            SubmitEligSeg(2, LineToEnter1, True)
                        End If
                    Else
                        '--Just enter both lines--
                        '--(Two Lines)--
                        If .TermDate(LineToEnter2).GetData = "        " Or tempTermDate1 < tempTermDate2 And tempTermDate1 <> Nothing Then
                            SubmitEligSeg(0, LineToEnter2, False)
                            SubmitEligSeg(1, LineToEnter1, False)
                        Else
                            SubmitEligSeg(0, LineToEnter1, False)
                            SubmitEligSeg(1, LineToEnter2, False)
                        End If
                    End If
                ElseIf LineToEnter2 > 0 And .EligSeg.GetData = "A" Then
                    '--Nothing there and we have 2 lines--
                    '--Add both--
                    If .TermDate(LineToEnter2).GetData = "        " Or tempTermDate1 < tempTermDate2 And tempTermDate1 <> Nothing Then
                        SubmitEligSeg(0, LineToEnter2, False)
                        SubmitEligSeg(1, LineToEnter1, False)
                    Else
                        SubmitEligSeg(0, LineToEnter1, False)
                        SubmitEligSeg(1, LineToEnter2, False)
                    End If
                Else
                    '--Enter 1 line--
                    '--Except if nothing is in eligibilty segment area--
                    If glapiMedicaid.GetString(12, 26, 19, 26) = "        " And .EligSeg.GetData <> "A" And glapiMedicaid.GetString(3, 26, 10, 26) <> "        " Then
                        SubmitEligSeg(2, LineToEnter2, True)
                    ElseIf glapiMedicaid.GetString(3, 26, 10, 26) = .EffDate(LineToEnter2).GetData Then
                        SubmitEligSeg(2, LineToEnter2, False)
                    Else
                        SubmitEligSeg(1, LineToEnter2, False)
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub SubmitEligSeg(ByVal FieldIndex As Integer, ByVal LineIndex As Integer, ByVal isSkipEffDate As Boolean)
        With OPTS61Information
            If Not isSkipEffDate Then glapiMedicaid.SubmitField(.EffDate(FieldIndex).FieldNumber, .EffDate(LineIndex).GetData)
            glapiMedicaid.SubmitField(.TermDate(FieldIndex).FieldNumber, .TermDate(LineIndex).GetData)
            glapiMedicaid.SubmitField(.AddCode(FieldIndex).FieldNumber, .AddCode(LineIndex).GetData)
            glapiMedicaid.SubmitField(.TRMCode(FieldIndex).FieldNumber, .TRMCode(LineIndex).GetData)
            glapiMedicaid.SubmitField(.PGM(FieldIndex).FieldNumber, .PGM(LineIndex).GetData)
            glapiMedicaid.SubmitField(.SUPV(FieldIndex).FieldNumber, .SUPV(LineIndex).GetData)
            glapiMedicaid.SubmitField(.RES(FieldIndex).FieldNumber, .RES(LineIndex).GetData)
            glapiMedicaid.SubmitField(.ExtType(FieldIndex).FieldNumber, .ExtType(LineIndex).GetData)
            glapiMedicaid.SubmitField(.PregDueDate(FieldIndex).FieldNumber, .PregDueDate(LineIndex).GetData)
        End With
    End Sub
    Private Sub SubmitPage64()
        Dim i As Integer
        With OPTS64Information
            glapiMedicaid.SubmitField(.ActionCode64.FieldNumber, .ActionCode64.GetData)
            For i = 0 To 5
                If .PGMNum(i).GetData <> "  " Then
                    If glapiMedicaid.GetString(19, 26, 20, 26) = "  " Then
                        glapiMedicaid.SubmitField(.PGMNum(i).FieldNumber, .PGMNum(i).GetData)
                        glapiMedicaid.SubmitField(.EffDate64(i).FieldNumber, .EffDate64(i).GetData)
                        glapiMedicaid.SubmitField(.TermDate64(i).FieldNumber, .TermDate64(i).GetData)
                    Else
                        glapiMedicaid.SubmitField(.PGMNum(i + 1).FieldNumber, .PGMNum(i).GetData)
                        glapiMedicaid.SubmitField(.EffDate64(i + 1).FieldNumber, .EffDate64(i).GetData)
                        glapiMedicaid.SubmitField(.TermDate64(i + 1).FieldNumber, .TermDate64(i).GetData)
                    End If
                Else
                    Exit For
                End If
            Next
        End With
    End Sub
    Private Sub SubmitPage66()
        With OPTS66Information
            glapiMedicaid.SubmitField(.ActionCode66.FieldNumber, .ActionCode66.GetData)
            If .ActionCode66.GetData = "D" Then
                glapiMedicaid.TransmitPage()
                If glapiMedicaid.GetString(2, 42, 8, 42) = "DEPRESS" Then glapiMedicaid.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F9)
            Else
                glapiMedicaid.SubmitField(.SUPV66.FieldNumber, .SUPV66.GetData)
                glapiMedicaid.SubmitField(.Worker.FieldNumber, .Worker.GetData)
                glapiMedicaid.SubmitField(.ProgramStatus.FieldNumber, .ProgramStatus.GetData)
                If .CaseRedetDate.GetData <> "000000" Then glapiMedicaid.SubmitField(.CaseRedetDate.FieldNumber, .CaseRedetDate.GetData)
                If .DisabilityRedetDate.GetData <> "000000" Then glapiMedicaid.SubmitField(.DisabilityRedetDate.FieldNumber, .CaseRedetDate.GetData)
            End If
        End With
    End Sub
End Module
