Module ProcessFAMIS

    Public glapiTP8 As connGLinkTP8

    Friend isError As Boolean
    Friend isContinue As Boolean

    Private SQLConn As SqlConnection
    Private SQLComm As SqlCommand
    Private SQLReader As SqlDataReader

    Friend Sub SetCaseInfo()
        FAMISCaseInformation = New CaseInformation
        FAMISMedicaidInformation = New MedicaidInformation
        FAMISFoodStampInformation = New FoodStampInformation
        FAMISApplicationInformation = New ApplicationInformation
        FAMISTANFInformation = New TANFInformation
        FAMISIandAInformation = New IandAInformation
        FAMISIndividualsInformation = New IndividualsInformation
        FAMISIncomeInformation = New IncomeInformation
        CaseChildCount = 0

        FAMISApplicationInformation.EG.SetData("R")
    End Sub

    Friend Sub GLink_Start()
        Dim Message As String = "          "
        Dim RetryCounter As Integer = 0
        Dim counter As Integer = 0
        Dim isLogonError As Boolean = False
        Dim isPasswordError As Boolean = False
        While RetryCounter < 3
            glapiTP8 = New connGLinkTP8(My.Settings.GLinkDirectory & "BullProd.cfg")
            glapiTP8.bool_Visible = True
            '--Check to see if GLink actually started and connected--
            '--If not we will reintialize the GLink element and try again--
            While Not glapiTP8.isConnect()
                Thread.Sleep(500)
                KillAllGLink()
                glapiTP8 = New connGLinkTP8(My.Settings.GLinkDirectory & "BullProd.cfg")
                glapiTP8.bool_Visible = True
                counter += 1
                If counter > 5 Then
                    isError = True
                    isLogonError = True
                End If
            End While

            counter = 0
            If glapiTP8.GetString(4, 9, 28, 9) = "0200 YOU ARE DISCONNECTED" Then
                isError = True
            End If
            If Not isError Then
                glapiTP8.SendKeysTransmit("LOGON")
                While glapiTP8.GetString(4, 21, 11, 21) <> "OPERATOR" And counter < 30
                    counter += 1
                    Thread.Sleep(500)
                    If counter = 30 Then
                        isError = True
                    End If
                End While
                counter = 0
                If Not isError Then
                    glapiTP8.SubmitField(4, My.Settings.FAMISOperator)
                    glapiTP8.SubmitField(6, My.Settings.FAMISPassword)
                    glapiTP8.SubmitField(8, My.Settings.FAMISKeyword)
                    glapiTP8.TransmitPage()
                    Message = glapiTP8.GetString(10, 22, 40, 22)
                End If
            End If
            If glapiTP8.GetString(30, 4, 37, 4) = "PASSWORD" Then
                glapiTP8.SetVisible(True)
                isPasswordError = True
            ElseIf Message.Substring(0, 5) = "     " Then
                '--No message provided by GLink--
                RetryCounter += 1
                isError = True
                Message = "Unknown GLink error. Please restart."
            ElseIf Message.Substring(0, 7) = "INVALID" Then
                '--Invalid password--
                RetryCounter = 3
                isError = True
                isLogonError = True
            ElseIf Message.Substring(0, 8) = "OPERATOR" Then
                '--Operator already logged on--
                RetryCounter = 3
                isError = True
                isLogonError = True
            ElseIf Message.Substring(0, 5) <> "LOGON" Then
                '--Double check that there is a message from GLink--
                RetryCounter += 1
                isError = True
                isLogonError = True
            Else
                RetryCounter = 3
            End If
            If isPasswordError Then '--eliminate at some point--
                isPasswordError = False
                isError = False
                isLogonError = False
            ElseIf isError And Not isLogonError Then
                If RetryCounter <= 3 Then
                    glapiTP8.Disconnect()
                Else

                End If
            ElseIf isError And isLogonError Then
                RetryCounter = 3
            End If
            If isError = False Then glapiTP8.TransmitPage()
            Thread.Sleep(500)
        End While
    End Sub
    Friend Sub KillAllGLink()
        Dim GLProcess() As Process
        Dim i As Integer
        GLProcess = Process.GetProcessesByName("gl")
        If GLProcess.Length > 0 Then
            For i = 0 To GLProcess.Length - 1
                GLProcess(i).Kill()
            Next
        End If
    End Sub
    Friend Sub GLink_PageErrorCheck(ByVal fromPageNumber As String, ByVal toPageNumber As String, ByVal isSetLabel As Boolean)
        If glapiTP8.isPageError(toPageNumber) Then
            isContinue = False
            If CaseMessage = Nothing Then CaseMessage = "Case Dropped"
        End If
    End Sub

    Friend Function DeleteBatch() As String
        glapiTP8.SendKeysTransmit("BTCH,DELE," & BatchNumber)
        If glapiTP8.GetString(1, 1, 12, 1) = "SCRN ( BTCH)" Then
            Return "Batch deleted"
        ElseIf glapiTP8.GetString(3, 2, 28, 2) = "BATCH WAS DELETED FROM OTF" Then
            Return "Batch already deleted"
        ElseIf glapiTP8.GetString(3, 2, 24, 2) = "BATCH NOT FOUND ON OTF" Then
            Return "Batch not found"
        Else
            Return "Error"
        End If
    End Function

    Friend Sub CheckCaseStatus()
        Dim isGoToMedicaid As Boolean = False
        glapiTP8.SendKeysTransmit("105A,," & CaseNumber)
        Thread.Sleep(150)
        If glapiTP8.GetString(3, 2, 21, 2) = "INVALID CASE NUMBER" Or glapiTP8.GetString(3, 2, 19, 2) = "CASE NOT ON FAMIS" Then
            isContinue = False
            CaseMessage = "Case Number not on FAMIS"
        ElseIf glapiTP8.GetString(76, 3, 76, 3) = "S" Then
            isContinue = False
            CaseMessage = "Case Suspended."
        Else
            FAMISMedicaidInformation.WL.SetData(glapiTP8.GetString(73, 22, 80, 22))
            glapiTP8.SubmitField(8, "02")
            glapiTP8.TransmitPage()
            Thread.Sleep(250)
            If glapiTP8.GetString(3, 2, 19, 2) <> "CASE NOT ON FAMIS" Then
                FAMISCaseInformation.AA.SetData(CaseNumber)
                FAMISCaseInformation.AB.SetData(glapiTP8.GetString(42, 3, 44, 3))
                FAMISCaseInformation.AC.SetData(glapiTP8.GetString(15, 7, 26, 7))
                FAMISCaseInformation.AD.SetData(glapiTP8.GetString(45, 7, 53, 7))
                FAMISCaseInformation.AE.SetData(glapiTP8.GetString(78, 7, 78, 7))
                FAMISCaseInformation.AH.SetData(glapiTP8.GetString(29, 3, 30, 3))
                FAMISCaseInformation.AI.SetData(glapiTP8.GetString(32, 3, 33, 3))
                FAMISCaseInformation.AJ.SetData(" ")
                FAMISCaseInformation.AK.SetData(glapiTP8.GetString(46, 3, 53, 3))
                FAMISCaseInformation.AL.SetData(glapiTP8.GetString(55, 3, 58, 3) & ".00")
                FAMISCaseInformation.AM.SetData(glapiTP8.GetString(60, 3, 63, 3) & ".00")
                If glapiTP8.GetString(74, 3, 74, 3) <> " " Then
                    isGoToMedicaid = True
                    FAMISMedicaidInformation.WA.SetData("C")
                    FAMISMedicaidInformation.WB.SetData("FR")
                    FAMISMedicaidInformation.WC.SetData(Date.Now.AddMonths(1).Month.ToString.PadLeft(2, "0") & "/01/" & Date.Now.AddMonths(1).Year)
                Else
                    FAMISMedicaidInformation.WL.SetData(" ")
                End If
                If glapiTP8.GetString(76, 3, 76, 3) <> " " Then
                    FAMISFoodStampInformation.LA.SetData("C")
                    FAMISFoodStampInformation.LB.SetData("GI")
                    FAMISFoodStampInformation.LC.SetData(Date.Now.AddMonths(1).Month.ToString.PadLeft(2, "0") & "/01/" & Date.Now.AddMonths(1).Year)
                Else
                    FAMISCaseInformation.AM.SetData(" ")
                End If
                If glapiTP8.GetString(78, 3, 78, 3) <> " " Then
                    FAMISTANFInformation.IA.SetData("C")
                    FAMISTANFInformation.IB.SetData("GI")
                    FAMISTANFInformation.IC.SetData(Date.Now.AddMonths(1).Month.ToString.PadLeft(2, "0") & "/01/" & Date.Now.AddMonths(1).Year)
                Else
                    FAMISCaseInformation.AL.SetData(" ")
                End If
                'If isGoToMedicaid Then
                '    glapiTP8.SubmitField(8, "12")
                '    glapiTP8.TransmitPage()
                '    Thread.Sleep(250)
                '    FAMISMedicaidInformation.WG.SetData(glapiTP8.GetString(18, 7, 25, 7))
                'End If
                '--IVD Fix--
                Dim IVDValue As String
                If glapiTP8.GetString(78, 3, 78, 3) = "G" Then
                    IVDValue = "Y"
                    'ElseIf glapiTP8.GetString(76, 3, 76, 3) = "C" Or glapiTP8.GetString(76, 3, 76, 3) = " " Then
                Else
                    IVDValue = "N"
                End If
                glapiTP8.SubmitField(8, "13")
                glapiTP8.TransmitPage()
                Thread.Sleep(250)
                For i As Integer = 7 To 22
                    Select Case glapiTP8.GetString(3, i, 3, i)
                        Case "A"
                            FAMISApplicationInformation.BQ.SetData(IVDValue)
                        Case "B"
                            FAMISApplicationInformation.BH.SetData(IVDValue)
                        Case " "
                            If i >= 9 Then Exit For
                        Case Else
                            FAMISCaseChild(CaseChildCount) = New CaseChild
                            FAMISCaseChild(CaseChildCount).TD.SetData(IVDValue)
                            CaseChildCount += 1
                    End Select
                Next
                '--End IVD Fix--
            End If
                glapiTP8.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F1)
                Thread.Sleep(500)
            End If
    End Sub
    Friend Sub CreateBatch()
        Dim isDuplicate As Boolean
        Dim counter As Integer = 0
        'setStatusLabel("Creating Batch")        
        glapiTP8.SendKeysTransmit("BTCH")
        MainScreen.BGW_ProcessCase.ReportProgress(5)
        While glapiTP8.GetString(1, 1, 12, 1) <> "SCRN ( BTCH)"  '--Added 1/9/2008--
            Thread.Sleep(500)                                   '--Issue over BTCH screen not coming up after GLink sent a transfer method--
            counter += 1                                        '--Causing GLink to crash--
            If counter > 30 Then
                If counter > 60 Then
                    glapiTP8.SetVisible(True)
                    If MessageBox.Show("GLink Communication Error!" & vbCrLf & "Wait?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) = Windows.Forms.DialogResult.OK Then
                        counter = 0
                    Else
                        Exit While
                    End If
                Else
                    glapiTP8.SendCommandKey(Glink.GlinkKeyEnum.GlinkKey_F1)
                    Thread.Sleep(500)
                    glapiTP8.SendKeysTransmit("BTCH")
                End If
            End If
        End While
        Thread.Sleep(500)
        Do
            glapiTP8.SubmitField(6, BatchNumber)
            glapiTP8.SubmitField(14, "99999999")
            glapiTP8.SubmitField(16, "01")
            glapiTP8.TransmitPage()
            If glapiTP8.GetString(1, 2, 3, 2) = "DUP" Then
                glapiTP8.SendCommand("DELE")
                glapiTP8.TransmitPage()
                isDuplicate = True
            Else
                isDuplicate = False
            End If
        Loop Until isDuplicate = False
        MainScreen.BGW_ProcessCase.ReportProgress(5)
    End Sub
    Friend Sub Submit_Page1()
        glapiTP8.SubmitField(FAMISCaseInformation.AA.FieldNumber, FAMISCaseInformation.AA.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AB.FieldNumber, FAMISCaseInformation.AB.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AC.FieldNumber, FAMISCaseInformation.AC.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AD.FieldNumber, FAMISCaseInformation.AD.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AE.FieldNumber, FAMISCaseInformation.AE.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AH.FieldNumber, FAMISCaseInformation.AH.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AI.FieldNumber, FAMISCaseInformation.AI.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AJ.FieldNumber, FAMISCaseInformation.AJ.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AK.FieldNumber, FAMISCaseInformation.AK.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AL.FieldNumber, FAMISCaseInformation.AL.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AM.FieldNumber, FAMISCaseInformation.AM.GetData)
        glapiTP8.SubmitField(FAMISCaseInformation.AN.FieldNumber, FAMISCaseInformation.AN.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HC.FieldNumber, FAMISMedicaidInformation.HC.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IA.FieldNumber, FAMISTANFInformation.IA.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IB.FieldNumber, FAMISTANFInformation.IB.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IC.FieldNumber, FAMISTANFInformation.IC.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.ID.FieldNumber, FAMISTANFInformation.ID.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IE.FieldNumber, FAMISTANFInformation.IE.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IF1.FieldNumber, FAMISTANFInformation.IF1.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IG.FieldNumber, FAMISTANFInformation.IG.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LA.FieldNumber, FAMISFoodStampInformation.LA.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LB.FieldNumber, FAMISFoodStampInformation.LB.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LC.FieldNumber, FAMISFoodStampInformation.LC.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LD.FieldNumber, FAMISFoodStampInformation.LD.GetData)
        'If Not FAMISFoodStampInformation.LA.GetData = " " Then glapiTP8.SubmitField(FAMISFoodStampInformation.LE.FieldNumber, FAMISMedicaidInformation.WG.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LF.FieldNumber, FAMISFoodStampInformation.LF.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.ND.FieldNumber, FAMISFoodStampInformation.ND.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PK.FieldNumber, FAMISIandAInformation.PK.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PC.FieldNumber, FAMISIandAInformation.PC.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WA.FieldNumber, FAMISMedicaidInformation.WA.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WB.FieldNumber, FAMISMedicaidInformation.WB.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WC.FieldNumber, FAMISMedicaidInformation.WC.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WD.FieldNumber, FAMISMedicaidInformation.WD.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WE.FieldNumber, FAMISMedicaidInformation.WE.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WF.FieldNumber, FAMISMedicaidInformation.WF.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WG.FieldNumber, FAMISMedicaidInformation.WG.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WL.FieldNumber, FAMISMedicaidInformation.WL.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WW.FieldNumber, FAMISMedicaidInformation.WW.GetData)
        Thread.Sleep(500)
    End Sub
    Friend Sub Submit_Page2()
        glapiTP8.SubmitField(FAMISApplicationInformation.BA.FieldNumber, FAMISApplicationInformation.BA.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BB.FieldNumber, FAMISApplicationInformation.BB.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BC.FieldNumber, FAMISApplicationInformation.BC.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BD.FieldNumber, FAMISApplicationInformation.BD.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BE.FieldNumber, FAMISApplicationInformation.BE.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BF.FieldNumber, FAMISApplicationInformation.BF.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BG.FieldNumber, FAMISApplicationInformation.BG.GetData)
        ' glapiTP8.SubmitField(FAMISApplicationInformation.BH.FieldNumber, FAMISApplicationInformation.BH.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BI.FieldNumber, FAMISApplicationInformation.BI.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BS.FieldNumber, FAMISApplicationInformation.BS.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BT.FieldNumber, FAMISApplicationInformation.BT.GetData)
        'glapiTP8.SubmitField(FAMISApplicationInformation.BU.FieldNumber, FAMISApplicationInformation.BU.GetData) --Protected--
        glapiTP8.SubmitField(FAMISApplicationInformation.BV.FieldNumber, FAMISApplicationInformation.BV.GetData)

        glapiTP8.SubmitField(FAMISApplicationInformation.BJ.FieldNumber, FAMISApplicationInformation.BJ.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BK.FieldNumber, FAMISApplicationInformation.BK.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BL.FieldNumber, FAMISApplicationInformation.BL.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BM.FieldNumber, FAMISApplicationInformation.BM.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BN.FieldNumber, FAMISApplicationInformation.BN.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BO.FieldNumber, FAMISApplicationInformation.BO.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BP.FieldNumber, " ")
        'glapiTP8.SubmitField(FAMISApplicationInformation.BQ.FieldNumber, FAMISApplicationInformation.BQ.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BR.FieldNumber, FAMISApplicationInformation.BR.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BW.FieldNumber, FAMISApplicationInformation.BW.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.BX.FieldNumber, FAMISApplicationInformation.BX.GetData)
        'glapiTP8.SubmitField(FAMISApplicationInformation.BY.FieldNumber, FAMISApplicationInformation.BY.GetData) --Protected
        glapiTP8.SubmitField(FAMISApplicationInformation.BZ.FieldNumber, FAMISApplicationInformation.BZ.GetData)

        glapiTP8.SubmitField(FAMISApplicationInformation.CA.FieldNumber, FAMISApplicationInformation.CA.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.CB.FieldNumber, FAMISApplicationInformation.CB.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.CC.FieldNumber, FAMISApplicationInformation.CC.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.CD1.FieldNumber, FAMISApplicationInformation.CD1.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.CD2.FieldNumber, FAMISApplicationInformation.CD2.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.CE.FieldNumber, FAMISApplicationInformation.CE.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.CF.FieldNumber, FAMISApplicationInformation.CF.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.CG.FieldNumber, FAMISApplicationInformation.CG.GetData)

        glapiTP8.SubmitField(FAMISApplicationInformation.DA1.FieldNumber, FAMISApplicationInformation.DA1.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.DA2.FieldNumber, FAMISApplicationInformation.DA2.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.DA3.FieldNumber, FAMISApplicationInformation.DA3.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.DB.FieldNumber, FAMISApplicationInformation.DB.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.DC.FieldNumber, FAMISApplicationInformation.DC.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.DD1.FieldNumber, FAMISApplicationInformation.DD1.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.DD2.FieldNumber, FAMISApplicationInformation.DD2.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.DE.FieldNumber, FAMISApplicationInformation.DE.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.DF.FieldNumber, FAMISApplicationInformation.DF.GetData)

        glapiTP8.SubmitField(FAMISApplicationInformation.EA.FieldNumber, FAMISApplicationInformation.EA.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EB.FieldNumber, FAMISApplicationInformation.EB.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EC.FieldNumber, FAMISApplicationInformation.EC.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.ED1.FieldNumber, FAMISApplicationInformation.ED1.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.ED2.FieldNumber, FAMISApplicationInformation.ED2.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EE.FieldNumber, FAMISApplicationInformation.EE.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EF.FieldNumber, FAMISApplicationInformation.EF.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EG.FieldNumber, FAMISApplicationInformation.EG.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EH.FieldNumber, FAMISApplicationInformation.EH.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EI.FieldNumber, FAMISApplicationInformation.EI.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EJ.FieldNumber, FAMISApplicationInformation.EJ.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EK.FieldNumber, FAMISApplicationInformation.EK.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EL.FieldNumber, FAMISApplicationInformation.EL.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EM.FieldNumber, FAMISApplicationInformation.EM.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.EN.FieldNumber, FAMISApplicationInformation.EN.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XM.FieldNumber, FAMISApplicationInformation.XM.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XN.FieldNumber, FAMISApplicationInformation.XN.GetData)

        glapiTP8.SubmitField(FAMISApplicationInformation.XA.FieldNumber, FAMISApplicationInformation.XA.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XB.FieldNumber, FAMISApplicationInformation.XB.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XC.FieldNumber, FAMISApplicationInformation.XC.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XD.FieldNumber, FAMISApplicationInformation.XD.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XE.FieldNumber, FAMISApplicationInformation.XE.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XF.FieldNumber, FAMISApplicationInformation.XF.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XG.FieldNumber, FAMISApplicationInformation.XG.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XH.FieldNumber, FAMISApplicationInformation.XH.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XI.FieldNumber, FAMISApplicationInformation.XI.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XJ.FieldNumber, FAMISApplicationInformation.XJ.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XK.FieldNumber, FAMISApplicationInformation.XK.GetData)
        glapiTP8.SubmitField(FAMISApplicationInformation.XL.FieldNumber, FAMISApplicationInformation.XL.GetData)
        Thread.Sleep(100)
    End Sub
    Friend Sub Submit_Page3()
        glapiTP8.SubmitField(FAMISIndividualsInformation.FA.FieldNumber, FAMISIndividualsInformation.FA.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FB.FieldNumber, FAMISIndividualsInformation.FB.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FC.FieldNumber, FAMISIndividualsInformation.FC.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FD.FieldNumber, FAMISIndividualsInformation.FD.GetData)
        'glapiTP8.SubmitField(FAMISIndividualsInformation.FD2.FieldNumber, FAMISIndividualsInformation.FA.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIndividualsInformation.FE1.FieldNumber, FAMISIndividualsInformation.FE1.GetData & FAMISIndividualsInformation.FE2.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FF.FieldNumber, FAMISIndividualsInformation.FF.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FG.FieldNumber, FAMISIndividualsInformation.FG.GetData)
        'glapiTP8.SubmitField(FAMISIndividualsInformation.FH.FieldNumber, FAMISIndividualsInformation.FH.GetData) --Protected--

        glapiTP8.SubmitField(FAMISIndividualsInformation.FI.FieldNumber, FAMISIndividualsInformation.FI.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FJ.FieldNumber, FAMISIndividualsInformation.FJ.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FK.FieldNumber, FAMISIndividualsInformation.FK.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FL.FieldNumber, FAMISIndividualsInformation.FL.GetData)
        'glapiTP8.SubmitField(FAMISIndividualsInformation.FL2.FieldNumber, FAMISIndividualsInformation.FL2.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIndividualsInformation.FM1.FieldNumber, FAMISIndividualsInformation.FM1.GetData & FAMISIndividualsInformation.FM2.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.FN.FieldNumber, FAMISIndividualsInformation.FN.GetData)
        'glapiTP8.SubmitField(FAMISIndividualsInformation.FO.FieldNumber, FAMISIndividualsInformation.FO.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIndividualsInformation.FP.FieldNumber, FAMISIndividualsInformation.FP.GetData)

        glapiTP8.SubmitField(FAMISIndividualsInformation.GA.FieldNumber, FAMISIndividualsInformation.GA.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GB.FieldNumber, FAMISIndividualsInformation.GB.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GC.FieldNumber, FAMISIndividualsInformation.GC.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GD.FieldNumber, FAMISIndividualsInformation.GD.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GE.FieldNumber, FAMISIndividualsInformation.GE.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GF.FieldNumber, FAMISIndividualsInformation.GF.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GG.FieldNumber, FAMISIndividualsInformation.GG.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GH.FieldNumber, FAMISIndividualsInformation.GH.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GI.FieldNumber, FAMISIndividualsInformation.GI.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GJ.FieldNumber, FAMISIndividualsInformation.GJ.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GK.FieldNumber, FAMISIndividualsInformation.GK.GetData)
        glapiTP8.SubmitField(FAMISIndividualsInformation.GL.FieldNumber, FAMISIndividualsInformation.GL.GetData)

        glapiTP8.SubmitField(FAMISMedicaidInformation.HA.FieldNumber, FAMISMedicaidInformation.HA.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HB.FieldNumber, FAMISMedicaidInformation.HB.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HC.FieldNumber, FAMISMedicaidInformation.HC.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HD.FieldNumber, FAMISMedicaidInformation.HD.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HE.FieldNumber, FAMISMedicaidInformation.HE.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HF.FieldNumber, FAMISMedicaidInformation.HF.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HG.FieldNumber, FAMISMedicaidInformation.HG.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.HH.FieldNumber, FAMISMedicaidInformation.HH.GetData) --Protected--
        glapiTP8.SubmitField(FAMISMedicaidInformation.HI.FieldNumber, FAMISMedicaidInformation.HI.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HJ.FieldNumber, FAMISMedicaidInformation.HJ.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.HK.FieldNumber, FAMISMedicaidInformation.HK.GetData) --Protected--
        'glapiTP8.SubmitField(FAMISMedicaidInformation.HL.FieldNumber, FAMISMedicaidInformation.HL.GetData) --Protected--

        glapiTP8.SubmitField(FAMISMedicaidInformation.HM.FieldNumber, FAMISMedicaidInformation.HM.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HN.FieldNumber, FAMISMedicaidInformation.HN.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HO.FieldNumber, FAMISMedicaidInformation.HO.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.HP.FieldNumber, FAMISMedicaidInformation.HP.GetData) --Protected--
        glapiTP8.SubmitField(FAMISMedicaidInformation.HQ.FieldNumber, FAMISMedicaidInformation.HQ.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.HR.FieldNumber, FAMISMedicaidInformation.HR.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.HS.FieldNumber, FAMISMedicaidInformation.HS.GetData) --Protected--
        'glapiTP8.SubmitField(FAMISMedicaidInformation.HT.FieldNumber, FAMISMedicaidInformation.HT.GetData) --Protected--
        Thread.Sleep(100)
    End Sub
    Friend Sub Submit_Page4()
        glapiTP8.SubmitField(FAMISTANFInformation.IH.FieldNumber, FAMISTANFInformation.IH.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.II.FieldNumber, FAMISTANFInformation.II.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IJ.FieldNumber, FAMISTANFInformation.IJ.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IK.FieldNumber, FAMISTANFInformation.IK.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IL.FieldNumber, FAMISTANFInformation.IL.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IM.FieldNumber, FAMISTANFInformation.IM.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IN1.FieldNumber, FAMISTANFInformation.IN1.GetData)
        glapiTP8.SubmitField(FAMISTANFInformation.IO.FieldNumber, FAMISTANFInformation.IO.GetData)
        'glapiTP8.SubmitField(FAMISTANFInformation.IP.FieldNumber, FAMISTANFInformation.Ip.GetData) --Protected--

        glapiTP8.SubmitField(FAMISIncomeInformation.JA.FieldNumber, FAMISIncomeInformation.JA.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JB.FieldNumber, FAMISIncomeInformation.JB.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JC.FieldNumber, FAMISIncomeInformation.JC.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JD.FieldNumber, FAMISIncomeInformation.JD.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JE.FieldNumber, FAMISIncomeInformation.JE.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JF.FieldNumber, FAMISIncomeInformation.JF.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JG.FieldNumber, FAMISIncomeInformation.JG.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JH.FieldNumber, FAMISIncomeInformation.JH.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JI.FieldNumber, FAMISIncomeInformation.JI.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JJ.FieldNumber, FAMISIncomeInformation.JJ.GetData)
        'glapiTP8.SubmitField(FAMISIncomeInformation.JK.FieldNumber, FAMISIncomeInformation.JK.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIncomeInformation.JL.FieldNumber, FAMISIncomeInformation.JL.GetData)
        'glapiTP8.SubmitField(FAMISIncomeInformation.JM.FieldNumber, FAMISIncomeInformation.JM.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIncomeInformation.JN.FieldNumber, FAMISIncomeInformation.JN.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JO.FieldNumber, FAMISIncomeInformation.JO.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JP.FieldNumber, FAMISIncomeInformation.JP.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JQ.FieldNumber, FAMISIncomeInformation.JQ.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JR.FieldNumber, FAMISIncomeInformation.JR.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JS.FieldNumber, FAMISIncomeInformation.JS.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JT.FieldNumber, FAMISIncomeInformation.JT.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JU.FieldNumber, FAMISIncomeInformation.JU.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JV.FieldNumber, " ")
        glapiTP8.SubmitField(FAMISIncomeInformation.JW.FieldNumber, FAMISIncomeInformation.JW.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.JX.FieldNumber, FAMISIncomeInformation.JX.GetData)

        glapiTP8.SubmitField(FAMISIncomeInformation.KA.FieldNumber, FAMISIncomeInformation.KA.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KB.FieldNumber, FAMISIncomeInformation.KB.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KC.FieldNumber, FAMISIncomeInformation.KC.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KD.FieldNumber, FAMISIncomeInformation.KD.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KE.FieldNumber, FAMISIncomeInformation.KE.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KF.FieldNumber, FAMISIncomeInformation.KF.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KG.FieldNumber, FAMISIncomeInformation.KG.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KH.FieldNumber, FAMISIncomeInformation.KH.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KI.FieldNumber, FAMISIncomeInformation.KI.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KJ.FieldNumber, FAMISIncomeInformation.KJ.GetData)
        'glapiTP8.SubmitField(FAMISIncomeInformation.KK.FieldNumber, FAMISIncomeInformation.KK.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIncomeInformation.KL.FieldNumber, FAMISIncomeInformation.KL.GetData)
        'glapiTP8.SubmitField(FAMISIncomeInformation.KM.FieldNumber, FAMISIncomeInformation.KM.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIncomeInformation.KN.FieldNumber, FAMISIncomeInformation.KN.GetData)
        'glapiTP8.SubmitField(FAMISIncomeInformation.KO.FieldNumber, FAMISIncomeInformation.KO.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIncomeInformation.KP.FieldNumber, "       ")
        'glapiTP8.SubmitField(FAMISIncomeInformation.KQ.FieldNumber, FAMISIncomeInformation.KQ.GetData) --Protected--
        glapiTP8.SubmitField(FAMISIncomeInformation.KR.FieldNumber, FAMISIncomeInformation.KR.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KS.FieldNumber, FAMISIncomeInformation.KS.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KT.FieldNumber, " ")
        glapiTP8.SubmitField(FAMISIncomeInformation.KU.FieldNumber, FAMISIncomeInformation.KU.GetData)
        glapiTP8.SubmitField(FAMISIncomeInformation.KV.FieldNumber, FAMISIncomeInformation.KV.GetData)

        If FAMISApplicationInformation.CG.GetData <> " " Then glapiTP8.SubmitField(FAMISFoodStampInformation.WX.FieldNumber, FAMISFoodStampInformation.WX.GetData)
        If FAMISApplicationInformation.CG.GetData <> " " Then glapiTP8.SubmitField(FAMISFoodStampInformation.WY.FieldNumber, FAMISFoodStampInformation.WY.GetData)
        Thread.Sleep(100)
    End Sub
    Friend Sub Submit_Page5()
        glapiTP8.SubmitField(FAMISFoodStampInformation.LG.FieldNumber, FAMISFoodStampInformation.LG.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LH.FieldNumber, FAMISFoodStampInformation.LH.GetData)
        'glapiTP8.SubmitField(FAMISFoodStampInformation.LI.FieldNumber, FAMISFoodStampInformation.LI.GetData) --Protected--
        glapiTP8.SubmitField(FAMISFoodStampInformation.LJ.FieldNumber, FAMISFoodStampInformation.LJ.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LK.FieldNumber, FAMISFoodStampInformation.LK.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LL.FieldNumber, FAMISFoodStampInformation.LL.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LM.FieldNumber, FAMISFoodStampInformation.LM.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LN.FieldNumber, FAMISFoodStampInformation.LN.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LO.FieldNumber, FAMISFoodStampInformation.LO.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LP.FieldNumber, FAMISFoodStampInformation.LP.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LQ.FieldNumber, FAMISFoodStampInformation.LQ.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LR.FieldNumber, FAMISFoodStampInformation.LR.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LS.FieldNumber, FAMISFoodStampInformation.LS.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.LT.FieldNumber, FAMISFoodStampInformation.LT.GetData)

        glapiTP8.SubmitField(FAMISFoodStampInformation.MA.FieldNumber, FAMISFoodStampInformation.MA.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MB.FieldNumber, FAMISFoodStampInformation.MB.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MC.FieldNumber, FAMISFoodStampInformation.MC.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MD.FieldNumber, FAMISFoodStampInformation.MD.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.ME1.FieldNumber, FAMISFoodStampInformation.ME1.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MF.FieldNumber, FAMISFoodStampInformation.MF.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MG.FieldNumber, FAMISFoodStampInformation.MG.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MH.FieldNumber, FAMISFoodStampInformation.MH.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MI.FieldNumber, FAMISFoodStampInformation.MI.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MJ.FieldNumber, FAMISFoodStampInformation.MJ.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MK.FieldNumber, FAMISFoodStampInformation.MK.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.ML.FieldNumber, FAMISFoodStampInformation.ML.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MM.FieldNumber, FAMISFoodStampInformation.MM.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MN.FieldNumber, FAMISFoodStampInformation.MN.GetData)
        'glapiTP8.SubmitField(FAMISFoodStampInformation.MO.FieldNumber, FAMISFoodStampInformation.MO.GetData) --Protected--
        glapiTP8.SubmitField(FAMISFoodStampInformation.MP.FieldNumber, FAMISFoodStampInformation.MP.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MQ.FieldNumber, FAMISFoodStampInformation.MQ.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.MR.FieldNumber, FAMISFoodStampInformation.MR.GetData)

        glapiTP8.SubmitField(FAMISFoodStampInformation.NA.FieldNumber, FAMISFoodStampInformation.NA.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NB.FieldNumber, FAMISFoodStampInformation.NB.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NC.FieldNumber, FAMISFoodStampInformation.NC.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.ND.FieldNumber, FAMISFoodStampInformation.ND.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NE.FieldNumber, FAMISFoodStampInformation.NE.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NF.FieldNumber, FAMISFoodStampInformation.NF.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NG.FieldNumber, FAMISFoodStampInformation.NG.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NH.FieldNumber, FAMISFoodStampInformation.NH.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NI.FieldNumber, FAMISFoodStampInformation.NI.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NJ.FieldNumber, FAMISFoodStampInformation.NJ.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NK.FieldNumber, FAMISFoodStampInformation.NK.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NL.FieldNumber, FAMISFoodStampInformation.NL.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NM.FieldNumber, FAMISFoodStampInformation.NM.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NN.FieldNumber, FAMISFoodStampInformation.NN.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.NO.FieldNumber, FAMISFoodStampInformation.NO.GetData)
        'glapiTP8.SubmitField(FAMISFoodStampInformation.NP.FieldNumber, FAMISFoodStampInformation.NP.GetData) --Protected--
    End Sub
    Friend Sub Submit_Page6()
        glapiTP8.SubmitField(FAMISFoodStampInformation.OA.FieldNumber, FAMISFoodStampInformation.OA.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.OB.FieldNumber, FAMISFoodStampInformation.OB.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.OC.FieldNumber, FAMISFoodStampInformation.OC.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.OD.FieldNumber, FAMISFoodStampInformation.OD.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.OE.FieldNumber, FAMISFoodStampInformation.OE.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.OF1.FieldNumber, FAMISFoodStampInformation.OF1.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.OG.FieldNumber, FAMISFoodStampInformation.OG.GetData)
        'glapiTP8.SubmitField(FAMISFoodStampInformation.OH.FieldNumber, FAMISFoodStampInformation.OH.GetData) --Protected--
        'glapiTP8.SubmitField(FAMISFoodStampInformation.OI.FieldNumber, FAMISFoodStampInformation.OI.GetData) --Protected--
        glapiTP8.SubmitField(FAMISFoodStampInformation.OJ.FieldNumber, FAMISFoodStampInformation.OJ.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.OK.FieldNumber, FAMISFoodStampInformation.OK.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.OM.FieldNumber, FAMISFoodStampInformation.OM.GetData)
        glapiTP8.SubmitField(FAMISFoodStampInformation.ON1.FieldNumber, FAMISFoodStampInformation.ON1.GetData)
        'glapiTP8.SubmitField(FAMISFoodStampInformation.OO.FieldNumber, FAMISFoodStampInformation.OO.GetData) --Protected--
        'glapiTP8.SubmitField(FAMISFoodStampInformation.OP.FieldNumber, FAMISFoodStampInformation.OP.GetData) --Protected--

        glapiTP8.SubmitField(FAMISIandAInformation.PA.FieldNumber, FAMISIandAInformation.PA.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PB.FieldNumber, FAMISIandAInformation.PB.GetData)
        'glapiTP8.SubmitField(FAMISIandAInformation.PC.FieldNumber, FAMISIandAInformation.PC.GetData) --Not Used--
        glapiTP8.SubmitField(FAMISIandAInformation.PD.FieldNumber, FAMISIandAInformation.PD.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PE.FieldNumber, FAMISIandAInformation.PE.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PF.FieldNumber, FAMISIandAInformation.PF.GetData)
        'glapiTP8.SubmitField(FAMISIandAInformation.PG.FieldNumber, FAMISIandAInformation.PG.GetData) --Protected--
        'glapiTP8.SubmitField(FAMISIandAInformation.PH.FieldNumber, FAMISIandAInformation.PH.GetData) --Protected--

        glapiTP8.SubmitField(FAMISIandAInformation.PI.FieldNumber, FAMISIandAInformation.PI.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PJ.FieldNumber, FAMISIandAInformation.PJ.GetData)
        'glapiTP8.SubmitField(FAMISIandAInformation.PK.FieldNumber, FAMISIandAInformation.PK.GetData) --Not Used--
        glapiTP8.SubmitField(FAMISIandAInformation.PL.FieldNumber, FAMISIandAInformation.PL.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PM.FieldNumber, FAMISIandAInformation.PM.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PN.FieldNumber, FAMISIandAInformation.PN.GetData)
        glapiTP8.SubmitField(FAMISIandAInformation.PP.FieldNumber, FAMISIandAInformation.PP.GetData)
        Thread.Sleep(100)
    End Sub
    Friend Sub Submit_Page10()
        glapiTP8.SubmitField(FAMISMedicaidInformation.WH.FieldNumber, FAMISMedicaidInformation.WH.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WI.FieldNumber, FAMISMedicaidInformation.WI.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.WK.FieldNumber, FAMISMedicaidInformation.WK.GetData) --Protected--
        'glapiTP8.SubmitField(FAMISMedicaidInformation.WM.FieldNumber, FAMISMedicaidInformation.WM.GetData) --Protected--
        glapiTP8.SubmitField(FAMISMedicaidInformation.WN.FieldNumber, FAMISMedicaidInformation.WN.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WO.FieldNumber, FAMISMedicaidInformation.WO.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WP.FieldNumber, FAMISMedicaidInformation.WP.GetData)
        glapiTP8.SubmitField(FAMISMedicaidInformation.WQ.FieldNumber, FAMISMedicaidInformation.WQ.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.WR.FieldNumber, FAMISMedicaidInformation.WR.GetData) --Protected--
        glapiTP8.SubmitField(FAMISMedicaidInformation.WS.FieldNumber, FAMISMedicaidInformation.WS.GetData)
        'glapiTP8.SubmitField(FAMISMedicaidInformation.WT.FieldNumber, FAMISMedicaidInformation.WT.GetData) --Protected--
        'glapiTP8.SubmitField(FAMISMedicaidInformation.WU.FieldNumber, FAMISMedicaidInformation.WU.GetData) --Protected--
        'glapiTP8.SubmitField(FAMISMedicaidInformation.WV.FieldNumber, FAMISMedicaidInformation.WV.GetData) --Protected--
        Thread.Sleep(100)
    End Sub
    Friend Sub CloseCase()
        glapiTP8.SendCommand("ENDCASE")
        glapiTP8.TransmitPage()
        If glapiTP8.GetString(30, 2, 51, 2) <> "BATCH BALANCING SCREEN" Then
            GLink_PageErrorCheck("10", "11", False)
        End If
        MainScreen.BGW_ProcessCase.ReportProgress(85)
    End Sub
    Friend Sub CloseBatch()
        MainScreen.BGW_ProcessCase.ReportProgress(21)
        If glapiTP8.GetString(30, 2, 51, 2) = "BATCH BALANCING SCREEN" Then
            Dim CheckBalance As String
            Dim ATPAmount As String = glapiTP8.GetString(45, 11, 55, 11)
            Dim CheckAmount As String = glapiTP8.GetString(45, 10, 55, 10)
            Thread.Sleep(250)
            glapiTP8.SubmitField(26, "00" & CaseNumber.Substring(1, 6))
            glapiTP8.SubmitField(38, CheckAmount)
            glapiTP8.SubmitField(44, ATPAmount)
            glapiTP8.SendCommand("CHANGE")
            glapiTP8.TransmitPage()
            CheckBalance = glapiTP8.GetString(27, 5, 34, 5)
            If CheckBalance = "BALANCED" Then
                glapiTP8.SendCommand("ENDBATCH")
                glapiTP8.TransmitPage()
                Thread.Sleep(500)
                glapiTP8.SendCommand("HOLD")
                glapiTP8.SubmitField(6, BATCHNUMBER)
                glapiTP8.TransmitPage()
                Thread.Sleep(500)
                glapiTP8.SendCommand("RELE")
                glapiTP8.SubmitField(6, BATCHNUMBER)
                glapiTP8.TransmitPage()
            End If
        End If
    End Sub
End Module
