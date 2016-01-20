'Imports clsFAMIS
'Imports clsGLink
'Imports clsPhoenix
'Imports Glink
'Imports System.IO
'Imports System.Threading
'Imports System.Xml

'Public Class TestFAMIS
'    Private FilePath As String = "C:\TestCases\"
'    Private FileName As String = "16A247VRP9608134844.txt"
'    Private TEXT_CaseInformation, TEXT_ApplicationInformation, TEXT_IndividualsInformation, TEXT_MedicaidInformation, TEXT_AFDCInformation, TEXT_IncomeInformation, TEXT_FoodStampInformation, TEXT_IandAInformation, TEXT_VRPInformation(35), TEXT_CaseChild(35) As String
'    Public FAMISCaseInformation As CaseInformation
'    Public FAMISApplicationInformation As ApplicationInformation
'    Public FAMISIndividualsInformation As IndividualsInformation
'    Public FAMISMedicaidInformation As MedicaidInformation
'    Public FAMISTANFInformation As TANFInformation
'    Public FAMISIncomeInformation As IncomeInformation
'    Public FAMISFoodStampInformation As FoodStampInformation
'    Public FAMISIandAInformation As IandAInformation
'    Public FAMISVRPInformation(35) As VRPInformation
'    Public FAMISCaseChild(35) As CaseChild

'    Public numChildren, numVRP As Integer

'    Private Const FAMIS_CONTROLFIELD As Integer = 4

'    Public glapiTP8 As New connGLinkTP8()

'    Private Sub TestFAMIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Me.BackColor = My.Settings.tBackColor
'        Read_TextFile()
'        setBlockData_Regular()
'        setBlockData_Child()
'        setBlockData_VRP()

'        '--TEMP To get case through--
'        FAMISFoodStampInformation.ND.SetData(" ")

'        GLink_Start()
'        Submit_Page1()
'        glapiTP8.TransmitPage()
'        PageErrorCheck("01", "02")

'        Submit_Page2()
'        glapiTP8.TransmitPage()
'        PageErrorCheck("02", "03")

'        Submit_Page3()
'        glapiTP8.TransmitPage()
'        PageErrorCheck("03", "04")

'        Submit_Page4()
'        glapiTP8.TransmitPage()
'        PageErrorCheck("04", "05")

'        Submit_Page5()
'        glapiTP8.TransmitPage()
'        PageErrorCheck("05", "06")

'        Submit_Page6()

'        If numChildren > 0 Then
'            glapiTP8.TransmitPage()
'            PageErrorCheck("06", "07")
'            Submit_Child()
'        End If
'        If numVRP > 0 Then
'            glapiTP8.SendCommand("09")
'            glapiTP8.TransmitPage()
'            If numChildren < 0 Then         '--Did we enter child information or are here from page 6--
'                PageErrorCheck("06", "09")
'            Else
'                PageErrorCheck("07", "09")
'            End If
'            Submit_Page9()
'            glapiTP8.TransmitPage()
'            PageErrorCheck("09", "10")
'        End If
'        If numChildren = 0 And numVRP = 0 Then '--If there is no children or VRP then just proceed to Page 10--
'            glapiTP8.SendCommand("10")
'            glapiTP8.TransmitPage()
'        End If

'        Submit_Page10()

'        glapiTP8.SendCommand("ENDCASE")
'        glapiTP8.TransmitPage()
'        PageErrorCheck("10", "11")

'        ListBox1.Items.Add("|" & FAMISCaseInformation.AB.GetData & "|")
'        ListBox1.Items.Add("|" & FAMISCaseInformation.AC.GetData & "|")
'        ListBox1.Items.Add("|" & FAMISCaseInformation.AK.GetData & "|")
'        ListBox1.Items.Add("|" & FAMISCaseInformation.AD.GetData & "|")
'        ListBox1.Items.Add("|" & FAMISMedicaidInformation.WC.GetData & "|")
'        ListBox1.Items.Add("|" & FAMISFoodStampInformation.LC.GetData & "|")
'        ListBox1.Items.Add("|" & FAMISMedicaidInformation.HC.GetData & "|")
'        ListBox1.Items.Add("|" & FAMISTANFInformation.IF1.GetData & "|")
'    End Sub

'    Private Sub getBlockData(ByRef BLOCK As FAMISBlock)
'        Select Case BLOCK.FileTable
'            Case "FAMISAFDCInformation"
'                BLOCK.SetData(TEXT_AFDCInformation.Substring(BLOCK.StartIndex, BLOCK.Length))
'            Case "FAMISApplicantInformation"
'                BLOCK.SetData(TEXT_ApplicationInformation.Substring(BLOCK.StartIndex, BLOCK.Length))
'            Case "FAMISCaseInformation"
'                BLOCK.SetData(TEXT_CaseInformation.Substring(BLOCK.StartIndex, BLOCK.Length))
'            Case "FAMISFoodStampInformation"
'                BLOCK.SetData(TEXT_FoodStampInformation.Substring(BLOCK.StartIndex, BLOCK.Length))
'            Case "FAMISIandAInformation"
'                BLOCK.SetData(TEXT_IandAInformation.Substring(BLOCK.StartIndex, BLOCK.Length))
'            Case "FAMISIncomeInformation"
'                BLOCK.SetData(TEXT_IncomeInformation.Substring(BLOCK.StartIndex, BLOCK.Length))
'            Case "FAMISIndividualsInformation"
'                BLOCK.SetData(TEXT_IndividualsInformation.Substring(BLOCK.StartIndex, BLOCK.Length))
'            Case "FAMISMedicaidInformation"
'                BLOCK.SetData(TEXT_MedicaidInformation.Substring(BLOCK.StartIndex, BLOCK.Length))
'        End Select
'    End Sub
'    Private Sub getBlockData(ByRef BLOCK As FAMISBlock, ByVal ArrayNum As Integer)
'        Select Case BLOCK.FileTable
'            Case "FAMISCaseChild"
'                BLOCK.SetData(TEXT_CaseChild(ArrayNum).Substring(BLOCK.StartIndex, BLOCK.Length))
'            Case "FAMISCaseVRPInformation"
'                BLOCK.SetData(TEXT_VRPInformation(ArrayNum).Substring(BLOCK.StartIndex, BLOCK.Length))
'        End Select
'    End Sub
'    Sub setBlockData_Regular()
'        FAMISCaseInformation = New CaseInformation
'        FAMISMedicaidInformation = New MedicaidInformation
'        FAMISFoodStampInformation = New FoodStampInformation
'        FAMISApplicationInformation = New ApplicationInformation
'        FAMISTANFInformation = New TANFInformation
'        FAMISIandAInformation = New IandAInformation
'        FAMISIndividualsInformation = New IndividualsInformation
'        FAMISIncomeInformation = New IncomeInformation

'        getBlockData(FAMISCaseInformation.AA)
'        getBlockData(FAMISCaseInformation.AB)
'        getBlockData(FAMISCaseInformation.AC)
'        getBlockData(FAMISCaseInformation.AD)
'        getBlockData(FAMISCaseInformation.AE)
'        getBlockData(FAMISCaseInformation.AF)
'        getBlockData(FAMISCaseInformation.AG)
'        getBlockData(FAMISCaseInformation.AH)
'        getBlockData(FAMISCaseInformation.AI)
'        getBlockData(FAMISCaseInformation.AJ)
'        getBlockData(FAMISCaseInformation.AK)
'        getBlockData(FAMISCaseInformation.AL)
'        getBlockData(FAMISCaseInformation.AM)
'        getBlockData(FAMISCaseInformation.AN)

'        getBlockData(FAMISApplicationInformation.BA)
'        getBlockData(FAMISApplicationInformation.BB)
'        getBlockData(FAMISApplicationInformation.BC)
'        getBlockData(FAMISApplicationInformation.BD)
'        getBlockData(FAMISApplicationInformation.BE)
'        getBlockData(FAMISApplicationInformation.BF)
'        getBlockData(FAMISApplicationInformation.BG)
'        getBlockData(FAMISApplicationInformation.BH)
'        getBlockData(FAMISApplicationInformation.BI)
'        getBlockData(FAMISApplicationInformation.BJ)
'        getBlockData(FAMISApplicationInformation.BK)
'        getBlockData(FAMISApplicationInformation.BL)
'        getBlockData(FAMISApplicationInformation.BM)
'        getBlockData(FAMISApplicationInformation.BN)
'        getBlockData(FAMISApplicationInformation.BO)
'        getBlockData(FAMISApplicationInformation.BP)
'        getBlockData(FAMISApplicationInformation.BQ)
'        getBlockData(FAMISApplicationInformation.BR)
'        getBlockData(FAMISApplicationInformation.BS)
'        getBlockData(FAMISApplicationInformation.BT)
'        getBlockData(FAMISApplicationInformation.BU)
'        getBlockData(FAMISApplicationInformation.BV)
'        getBlockData(FAMISApplicationInformation.BW)
'        getBlockData(FAMISApplicationInformation.BX)
'        getBlockData(FAMISApplicationInformation.BY)
'        getBlockData(FAMISApplicationInformation.BZ)

'        getBlockData(FAMISApplicationInformation.CA)
'        'getBlockData(FAMISApplicationInformation.CB)
'        If FAMISApplicationInformation.CA.GetData.Substring(0, 1) = "-" Then FAMISApplicationInformation.CB.SetData("-")
'        getBlockData(FAMISApplicationInformation.CC)
'        getBlockData(FAMISApplicationInformation.CD1)
'        getBlockData(FAMISApplicationInformation.CD2)
'        getBlockData(FAMISApplicationInformation.CE)
'        getBlockData(FAMISApplicationInformation.CF)
'        getBlockData(FAMISApplicationInformation.CG)

'        getBlockData(FAMISApplicationInformation.DA1)
'        getBlockData(FAMISApplicationInformation.DA2)
'        getBlockData(FAMISApplicationInformation.DA3)
'        getBlockData(FAMISApplicationInformation.DB)
'        getBlockData(FAMISApplicationInformation.DC)
'        getBlockData(FAMISApplicationInformation.DD1)
'        getBlockData(FAMISApplicationInformation.DD2)
'        getBlockData(FAMISApplicationInformation.DE)
'        getBlockData(FAMISApplicationInformation.DF)

'        getBlockData(FAMISApplicationInformation.EA)
'        getBlockData(FAMISApplicationInformation.EB)
'        getBlockData(FAMISApplicationInformation.EC)
'        getBlockData(FAMISApplicationInformation.ED1)
'        getBlockData(FAMISApplicationInformation.ED2)
'        getBlockData(FAMISApplicationInformation.EE)
'        getBlockData(FAMISApplicationInformation.EF)
'        getBlockData(FAMISApplicationInformation.EG)
'        getBlockData(FAMISApplicationInformation.EH)
'        getBlockData(FAMISApplicationInformation.EI)
'        getBlockData(FAMISApplicationInformation.EJ)
'        getBlockData(FAMISApplicationInformation.EK)
'        getBlockData(FAMISApplicationInformation.EL)
'        getBlockData(FAMISApplicationInformation.EM)
'        getBlockData(FAMISApplicationInformation.EN)


'        getBlockData(FAMISApplicationInformation.XA)
'        getBlockData(FAMISApplicationInformation.XB)
'        getBlockData(FAMISApplicationInformation.XC)
'        getBlockData(FAMISApplicationInformation.XD)
'        getBlockData(FAMISApplicationInformation.XE)
'        getBlockData(FAMISApplicationInformation.XF)
'        getBlockData(FAMISApplicationInformation.XG)
'        getBlockData(FAMISApplicationInformation.XH)
'        getBlockData(FAMISApplicationInformation.XI)
'        getBlockData(FAMISApplicationInformation.XJ)
'        getBlockData(FAMISApplicationInformation.XK)
'        getBlockData(FAMISApplicationInformation.XL)
'        getBlockData(FAMISApplicationInformation.XM)
'        getBlockData(FAMISApplicationInformation.XN)

'        getBlockData(FAMISIndividualsInformation.FA)
'        getBlockData(FAMISIndividualsInformation.FB)
'        getBlockData(FAMISIndividualsInformation.FC)
'        getBlockData(FAMISIndividualsInformation.FD)
'        getBlockData(FAMISIndividualsInformation.FD2)
'        getBlockData(FAMISIndividualsInformation.FE1)
'        getBlockData(FAMISIndividualsInformation.FE2)
'        getBlockData(FAMISIndividualsInformation.FF)
'        getBlockData(FAMISIndividualsInformation.FG1)
'        getBlockData(FAMISIndividualsInformation.FG2)
'        getBlockData(FAMISIndividualsInformation.FG3)
'        getBlockData(FAMISIndividualsInformation.FH)
'        getBlockData(FAMISIndividualsInformation.FI)
'        getBlockData(FAMISIndividualsInformation.FK)
'        getBlockData(FAMISIndividualsInformation.FJ)
'        getBlockData(FAMISIndividualsInformation.FL)
'        getBlockData(FAMISIndividualsInformation.FL2)
'        getBlockData(FAMISIndividualsInformation.FM1)
'        getBlockData(FAMISIndividualsInformation.FM2)
'        getBlockData(FAMISIndividualsInformation.FN)
'        getBlockData(FAMISIndividualsInformation.FO)
'        getBlockData(FAMISIndividualsInformation.FP1)
'        getBlockData(FAMISIndividualsInformation.FP2)
'        getBlockData(FAMISIndividualsInformation.FP3)

'        getBlockData(FAMISIndividualsInformation.GA)
'        getBlockData(FAMISIndividualsInformation.GB)
'        getBlockData(FAMISIndividualsInformation.GC)
'        getBlockData(FAMISIndividualsInformation.GD)
'        getBlockData(FAMISIndividualsInformation.GE)
'        getBlockData(FAMISIndividualsInformation.GF)
'        getBlockData(FAMISIndividualsInformation.GG)
'        getBlockData(FAMISIndividualsInformation.GH)
'        getBlockData(FAMISIndividualsInformation.GI)
'        getBlockData(FAMISIndividualsInformation.GJ)
'        getBlockData(FAMISIndividualsInformation.GK)
'        getBlockData(FAMISIndividualsInformation.GL)

'        getBlockData(FAMISMedicaidInformation.HA)
'        getBlockData(FAMISMedicaidInformation.HB)
'        getBlockData(FAMISMedicaidInformation.HC)
'        getBlockData(FAMISMedicaidInformation.HD)
'        getBlockData(FAMISMedicaidInformation.HE)
'        getBlockData(FAMISMedicaidInformation.HF)
'        getBlockData(FAMISMedicaidInformation.HG)
'        getBlockData(FAMISMedicaidInformation.HH)
'        getBlockData(FAMISMedicaidInformation.HI)
'        getBlockData(FAMISMedicaidInformation.HJ)
'        getBlockData(FAMISMedicaidInformation.HK)
'        getBlockData(FAMISMedicaidInformation.HL)
'        getBlockData(FAMISMedicaidInformation.HM)
'        getBlockData(FAMISMedicaidInformation.HN)
'        getBlockData(FAMISMedicaidInformation.HO)
'        getBlockData(FAMISMedicaidInformation.HP)
'        getBlockData(FAMISMedicaidInformation.HQ)
'        getBlockData(FAMISMedicaidInformation.HR)
'        getBlockData(FAMISMedicaidInformation.HS)
'        getBlockData(FAMISMedicaidInformation.HT)

'        getBlockData(FAMISMedicaidInformation.WA)
'        getBlockData(FAMISMedicaidInformation.WB)
'        getBlockData(FAMISMedicaidInformation.WC)
'        getBlockData(FAMISMedicaidInformation.WD)
'        getBlockData(FAMISMedicaidInformation.WE)
'        getBlockData(FAMISMedicaidInformation.WF)
'        getBlockData(FAMISMedicaidInformation.WG)
'        getBlockData(FAMISMedicaidInformation.WH)
'        getBlockData(FAMISMedicaidInformation.WI)
'        getBlockData(FAMISMedicaidInformation.WK)
'        getBlockData(FAMISMedicaidInformation.WL)
'        getBlockData(FAMISMedicaidInformation.WM)
'        getBlockData(FAMISMedicaidInformation.WN)
'        getBlockData(FAMISMedicaidInformation.WO)
'        getBlockData(FAMISMedicaidInformation.WP)
'        getBlockData(FAMISMedicaidInformation.WQ)
'        getBlockData(FAMISMedicaidInformation.WR)
'        getBlockData(FAMISMedicaidInformation.WS)
'        getBlockData(FAMISMedicaidInformation.WT)
'        getBlockData(FAMISMedicaidInformation.WU)
'        getBlockData(FAMISMedicaidInformation.WV)
'        getBlockData(FAMISMedicaidInformation.WW)

'        getBlockData(FAMISIncomeInformation.JA)
'        getBlockData(FAMISIncomeInformation.JB)
'        getBlockData(FAMISIncomeInformation.JC)
'        getBlockData(FAMISIncomeInformation.JD)
'        getBlockData(FAMISIncomeInformation.JE)
'        getBlockData(FAMISIncomeInformation.JF)
'        getBlockData(FAMISIncomeInformation.JG)
'        getBlockData(FAMISIncomeInformation.JH)
'        getBlockData(FAMISIncomeInformation.JI)
'        getBlockData(FAMISIncomeInformation.JJ)
'        getBlockData(FAMISIncomeInformation.JK)
'        getBlockData(FAMISIncomeInformation.JL)
'        getBlockData(FAMISIncomeInformation.JM)
'        getBlockData(FAMISIncomeInformation.JN)
'        getBlockData(FAMISIncomeInformation.JO)
'        getBlockData(FAMISIncomeInformation.JP)
'        getBlockData(FAMISIncomeInformation.JQ)
'        getBlockData(FAMISIncomeInformation.JR)
'        getBlockData(FAMISIncomeInformation.JS)
'        getBlockData(FAMISIncomeInformation.JT)
'        getBlockData(FAMISIncomeInformation.JU)
'        '  getBlockData(FAMISIncomeInformation.JV)
'        getBlockData(FAMISIncomeInformation.JW)
'        getBlockData(FAMISIncomeInformation.JX)

'        getBlockData(FAMISIncomeInformation.KA)
'        getBlockData(FAMISIncomeInformation.KB)
'        getBlockData(FAMISIncomeInformation.KC)
'        getBlockData(FAMISIncomeInformation.KD)
'        getBlockData(FAMISIncomeInformation.KE)
'        getBlockData(FAMISIncomeInformation.KF)
'        getBlockData(FAMISIncomeInformation.KG)
'        getBlockData(FAMISIncomeInformation.KH)
'        getBlockData(FAMISIncomeInformation.KI)
'        getBlockData(FAMISIncomeInformation.KJ)
'        getBlockData(FAMISIncomeInformation.KK)
'        getBlockData(FAMISIncomeInformation.KL)
'        getBlockData(FAMISIncomeInformation.KM)
'        getBlockData(FAMISIncomeInformation.KN)
'        getBlockData(FAMISIncomeInformation.KO)
'        getBlockData(FAMISIncomeInformation.KP)
'        getBlockData(FAMISIncomeInformation.KQ)
'        getBlockData(FAMISIncomeInformation.KR)
'        getBlockData(FAMISIncomeInformation.KS)
'        'getBlockData(FAMISIncomeInformation.KT)
'        getBlockData(FAMISIncomeInformation.KU)
'        getBlockData(FAMISIncomeInformation.KV)

'        getBlockData(FAMISFoodStampInformation.LA)
'        getBlockData(FAMISFoodStampInformation.LB)
'        getBlockData(FAMISFoodStampInformation.LC)
'        getBlockData(FAMISFoodStampInformation.LD)
'        getBlockData(FAMISFoodStampInformation.LE)
'        getBlockData(FAMISFoodStampInformation.LF)
'        getBlockData(FAMISFoodStampInformation.LG)
'        getBlockData(FAMISFoodStampInformation.LH)
'        getBlockData(FAMISFoodStampInformation.LI)
'        getBlockData(FAMISFoodStampInformation.LJ)
'        getBlockData(FAMISFoodStampInformation.LK)
'        getBlockData(FAMISFoodStampInformation.LL)
'        getBlockData(FAMISFoodStampInformation.LM)
'        getBlockData(FAMISFoodStampInformation.LN)
'        getBlockData(FAMISFoodStampInformation.LO)
'        getBlockData(FAMISFoodStampInformation.LP)
'        getBlockData(FAMISFoodStampInformation.LQ)
'        getBlockData(FAMISFoodStampInformation.LR)
'        getBlockData(FAMISFoodStampInformation.LS)
'        getBlockData(FAMISFoodStampInformation.LT)

'        getBlockData(FAMISFoodStampInformation.MA)
'        getBlockData(FAMISFoodStampInformation.MB)
'        getBlockData(FAMISFoodStampInformation.MC)
'        getBlockData(FAMISFoodStampInformation.MD)
'        getBlockData(FAMISFoodStampInformation.ME1)
'        getBlockData(FAMISFoodStampInformation.MF)
'        getBlockData(FAMISFoodStampInformation.MG)
'        getBlockData(FAMISFoodStampInformation.MH)
'        getBlockData(FAMISFoodStampInformation.MI)
'        getBlockData(FAMISFoodStampInformation.MJ)
'        getBlockData(FAMISFoodStampInformation.MK)
'        getBlockData(FAMISFoodStampInformation.ML)
'        getBlockData(FAMISFoodStampInformation.MM)
'        getBlockData(FAMISFoodStampInformation.MN)
'        getBlockData(FAMISFoodStampInformation.MO)
'        getBlockData(FAMISFoodStampInformation.MP)
'        getBlockData(FAMISFoodStampInformation.MQ)
'        getBlockData(FAMISFoodStampInformation.MR)
'        getBlockData(FAMISFoodStampInformation.MS)
'        getBlockData(FAMISFoodStampInformation.MT)

'        getBlockData(FAMISFoodStampInformation.NA)
'        getBlockData(FAMISFoodStampInformation.NB)
'        getBlockData(FAMISFoodStampInformation.NC)
'        getBlockData(FAMISFoodStampInformation.ND)
'        getBlockData(FAMISFoodStampInformation.NE)
'        getBlockData(FAMISFoodStampInformation.NF)
'        getBlockData(FAMISFoodStampInformation.NG)
'        getBlockData(FAMISFoodStampInformation.NH)
'        getBlockData(FAMISFoodStampInformation.NI)
'        getBlockData(FAMISFoodStampInformation.NJ)
'        getBlockData(FAMISFoodStampInformation.NK)
'        getBlockData(FAMISFoodStampInformation.NL)
'        getBlockData(FAMISFoodStampInformation.NM)
'        getBlockData(FAMISFoodStampInformation.NN)
'        getBlockData(FAMISFoodStampInformation.NO)
'        getBlockData(FAMISFoodStampInformation.NP)

'        getBlockData(FAMISFoodStampInformation.OA)
'        getBlockData(FAMISFoodStampInformation.OB)
'        getBlockData(FAMISFoodStampInformation.OC)
'        getBlockData(FAMISFoodStampInformation.OD)
'        getBlockData(FAMISFoodStampInformation.OE)
'        getBlockData(FAMISFoodStampInformation.OF1)
'        getBlockData(FAMISFoodStampInformation.OG)
'        getBlockData(FAMISFoodStampInformation.OH)
'        getBlockData(FAMISFoodStampInformation.OI)
'        getBlockData(FAMISFoodStampInformation.OJ)
'        getBlockData(FAMISFoodStampInformation.OK)
'        getBlockData(FAMISFoodStampInformation.OL)
'        getBlockData(FAMISFoodStampInformation.OM)
'        getBlockData(FAMISFoodStampInformation.ON1)
'        getBlockData(FAMISFoodStampInformation.OO)
'        'getBlockData(FAMISFoodStampInformation.OP) --Not in XML or Text File--

'        getBlockData(FAMISFoodStampInformation.WX)
'        getBlockData(FAMISFoodStampInformation.WY)

'        getBlockData(FAMISIandAInformation.PA)
'        getBlockData(FAMISIandAInformation.PB)
'        getBlockData(FAMISIandAInformation.PC)
'        getBlockData(FAMISIandAInformation.PD)
'        getBlockData(FAMISIandAInformation.PE)
'        getBlockData(FAMISIandAInformation.PF)
'        getBlockData(FAMISIandAInformation.PG)
'        getBlockData(FAMISIandAInformation.PH)
'        getBlockData(FAMISIandAInformation.PI)
'        getBlockData(FAMISIandAInformation.PJ)
'        getBlockData(FAMISIandAInformation.PK)
'        getBlockData(FAMISIandAInformation.PL)
'        getBlockData(FAMISIandAInformation.PM)
'        getBlockData(FAMISIandAInformation.PN)
'        getBlockData(FAMISIandAInformation.PO)
'        getBlockData(FAMISIandAInformation.PP)

'        getBlockData(FAMISTANFInformation.IA)
'        getBlockData(FAMISTANFInformation.IB)
'        getBlockData(FAMISTANFInformation.IC)
'        getBlockData(FAMISTANFInformation.ID)
'        getBlockData(FAMISTANFInformation.IE)
'        getBlockData(FAMISTANFInformation.IF1)
'        getBlockData(FAMISTANFInformation.IG)
'        getBlockData(FAMISTANFInformation.IH)
'        getBlockData(FAMISTANFInformation.II)
'        getBlockData(FAMISTANFInformation.IJ)
'        getBlockData(FAMISTANFInformation.IK)
'        getBlockData(FAMISTANFInformation.IL)
'        getBlockData(FAMISTANFInformation.IM)
'        getBlockData(FAMISTANFInformation.IN1)
'        getBlockData(FAMISTANFInformation.IO)
'        getBlockData(FAMISTANFInformation.IP)
'    End Sub
'    Sub setBlockData_Child()
'        Dim i As Integer
'        For i = 0 To numChildren - 1
'            FAMISCaseChild(i) = New CaseChild

'            getBlockData(FAMISCaseChild(i).QA, i)
'            getBlockData(FAMISCaseChild(i).QB, i)
'            getBlockData(FAMISCaseChild(i).QC, i)
'            getBlockData(FAMISCaseChild(i).QD, i)
'            getBlockData(FAMISCaseChild(i).QE1, i)
'            getBlockData(FAMISCaseChild(i).QE2, i)
'            getBlockData(FAMISCaseChild(i).QF, i)
'            getBlockData(FAMISCaseChild(i).QG, i)
'            getBlockData(FAMISCaseChild(i).QH, i)
'            getBlockData(FAMISCaseChild(i).QI1, i)
'            getBlockData(FAMISCaseChild(i).QI2, i)
'            getBlockData(FAMISCaseChild(i).QK, i)
'            getBlockData(FAMISCaseChild(i).QL, i)
'            getBlockData(FAMISCaseChild(i).QM, i)
'            getBlockData(FAMISCaseChild(i).QN, i)
'            getBlockData(FAMISCaseChild(i).QO, i)

'            getBlockData(FAMISCaseChild(i).RA, i)
'            getBlockData(FAMISCaseChild(i).RB, i)
'            getBlockData(FAMISCaseChild(i).RC, i)
'            getBlockData(FAMISCaseChild(i).RD, i)
'            getBlockData(FAMISCaseChild(i).RE, i)
'            getBlockData(FAMISCaseChild(i).RF, i)
'            getBlockData(FAMISCaseChild(i).RG, i)
'            getBlockData(FAMISCaseChild(i).RH, i)
'            getBlockData(FAMISCaseChild(i).RI, i)
'            getBlockData(FAMISCaseChild(i).RJ1, i)
'            getBlockData(FAMISCaseChild(i).RJ2, i)
'            getBlockData(FAMISCaseChild(i).RK, i)
'            getBlockData(FAMISCaseChild(i).RL, i)
'            getBlockData(FAMISCaseChild(i).RM, i)
'            getBlockData(FAMISCaseChild(i).RN, i)
'            getBlockData(FAMISCaseChild(i).RO, i)
'            getBlockData(FAMISCaseChild(i).RP, i)
'            getBlockData(FAMISCaseChild(i).RQ, i)
'            getBlockData(FAMISCaseChild(i).RR, i)

'            getBlockData(FAMISCaseChild(i).SA, i)
'            getBlockData(FAMISCaseChild(i).SB, i)
'            getBlockData(FAMISCaseChild(i).SC, i)
'            getBlockData(FAMISCaseChild(i).SD, i)
'            getBlockData(FAMISCaseChild(i).SE, i)
'            getBlockData(FAMISCaseChild(i).SF, i)
'            getBlockData(FAMISCaseChild(i).SG, i)
'            getBlockData(FAMISCaseChild(i).SH, i)
'            getBlockData(FAMISCaseChild(i).SI, i)
'            getBlockData(FAMISCaseChild(i).SJ, i)
'            getBlockData(FAMISCaseChild(i).SK, i)
'            getBlockData(FAMISCaseChild(i).SL, i)
'            getBlockData(FAMISCaseChild(i).SM, i)
'            getBlockData(FAMISCaseChild(i).SN, i)
'            getBlockData(FAMISCaseChild(i).SO, i)
'            getBlockData(FAMISCaseChild(i).SP, i)
'            getBlockData(FAMISCaseChild(i).SQ, i)
'            getBlockData(FAMISCaseChild(i).SR, i)
'            getBlockData(FAMISCaseChild(i).SS, i)
'            getBlockData(FAMISCaseChild(i).ST, i)

'            getBlockData(FAMISCaseChild(i).TA, i)
'            getBlockData(FAMISCaseChild(i).TB, i)
'            getBlockData(FAMISCaseChild(i).TC, i)
'            getBlockData(FAMISCaseChild(i).TD, i)
'            getBlockData(FAMISCaseChild(i).TE, i)
'            getBlockData(FAMISCaseChild(i).TF, i)
'            getBlockData(FAMISCaseChild(i).TG, i)
'            getBlockData(FAMISCaseChild(i).TH, i)
'            getBlockData(FAMISCaseChild(i).TI1, i)
'            getBlockData(FAMISCaseChild(i).TI2, i)
'            getBlockData(FAMISCaseChild(i).TI3, i)
'            getBlockData(FAMISCaseChild(i).TJ, i)
'            getBlockData(FAMISCaseChild(i).TK, i)
'            getBlockData(FAMISCaseChild(i).TL, i)
'            getBlockData(FAMISCaseChild(i).TM, i)
'            getBlockData(FAMISCaseChild(i).TN, i)
'            getBlockData(FAMISCaseChild(i).TO1, i)
'            getBlockData(FAMISCaseChild(i).TP, i)
'            getBlockData(FAMISCaseChild(i).TQ, i)
'            getBlockData(FAMISCaseChild(i).TR, i)
'            getBlockData(FAMISCaseChild(i).TS, i)

'            getBlockData(FAMISCaseChild(i).UA, i)
'            getBlockData(FAMISCaseChild(i).UB, i)
'            getBlockData(FAMISCaseChild(i).UC, i)
'            getBlockData(FAMISCaseChild(i).UD, i)
'            getBlockData(FAMISCaseChild(i).UE, i)
'            getBlockData(FAMISCaseChild(i).UF, i)
'            If FAMISCaseChild(i).UF.GetData = "ap" Then FAMISCaseChild(i).UF.SetData("  ")
'            getBlockData(FAMISCaseChild(i).UG, i)
'            getBlockData(FAMISCaseChild(i).UH, i)
'            getBlockData(FAMISCaseChild(i).UI, i)
'            getBlockData(FAMISCaseChild(i).UJ, i)
'            getBlockData(FAMISCaseChild(i).UK, i)
'            getBlockData(FAMISCaseChild(i).UL, i)

'            ' getBlockData(FAMISCaseChild(i).YA) --Not in XML or Text File--
'        Next
'    End Sub
'    Sub setBlockData_VRP()
'        Dim i As Integer
'        For i = 0 To numVRP - 1
'            FAMISVRPInformation(i) = New VRPInformation(i)

'            getBlockData(FAMISVRPInformation(i).VE, i)
'            getBlockData(FAMISVRPInformation(i).VG, i)
'            getBlockData(FAMISVRPInformation(i).VI, i)
'            getBlockData(FAMISVRPInformation(i).VK, i)
'            getBlockData(FAMISVRPInformation(i).VM, i)
'            getBlockData(FAMISVRPInformation(i).VO, i)
'        Next
'    End Sub

'    Sub GLink_Start()
'        glapiTP8.bool_Visible = True
'        glapiTP8.Connect()

'        glapiTP8.SendKeysTransmit("HSA")
'        glapiTP8.SendKeysTransmit("LOGON")
'        glapiTP8.SubmitField(4, My.Settings.OperatorID)
'        glapiTP8.SubmitField(6, My.Settings.Password)
'        glapiTP8.SubmitField(8, My.Settings.UAPKeyword)
'        glapiTP8.TransmitPage()
'        glapiTP8.TransmitPage()
'        Threading.Thread.Sleep(1500)
'        glapiTP8.SendKeysTransmit("BTCH,CONT,U999301")
'        If glapiTP8.GetString(3, 2, 9, 2) = "INVALID" Then glapiTP8.SendKeysTransmit("BTCH,CONT,U999301")
'    End Sub
'    Sub PageErrorCheck(ByVal fromPageNumber As String, ByVal toPageNumber As String)
'        Dim isLoop As Boolean = True
'        Dim BlockArray(10), BlockName(10), BlockData(10) As String
'        Dim i As Integer
'        While isLoop
'            If glapiTP8.isPageError(toPageNumber) Then
'                '--TEMP Gets the block names and block data that are blinking--
'                If glapiTP8.GetField_Blinking <> Nothing Then BlockArray = glapiTP8.GetField_Blinking.Split(vbCrLf)
'                For i = 0 To BlockArray.Length - 1
'                    If BlockArray(i) <> Nothing Then
'                        BlockName(i) = BlockArray(i).Substring(1, 2)
'                        BlockData(i) = BlockArray(i).Substring(3)
'                        ListBox1.Items.Add(BlockName(i) & ": " & BlockData(i))
'                    End If
'                Next
'                '--END TEMP--
'                '--INSERT ERROR HANDLING 105 FORM CODE HERE--
'                isLoop = False
'            Else
'                isLoop = False
'            End If
'        End While
'    End Sub
'    Private Sub Submit_Page1()
'        glapiTP8.SubmitField(FAMISCaseInformation.AA.FieldNumber, FAMISCaseInformation.AA.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AB.FieldNumber, FAMISCaseInformation.AB.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AC.FieldNumber, FAMISCaseInformation.AC.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AD.FieldNumber, FAMISCaseInformation.AD.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AE.FieldNumber, FAMISCaseInformation.AE.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AH.FieldNumber, FAMISCaseInformation.AH.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AI.FieldNumber, FAMISCaseInformation.AI.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AJ.FieldNumber, FAMISCaseInformation.AJ.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AK.FieldNumber, FAMISCaseInformation.AK.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AL.FieldNumber, FAMISCaseInformation.AL.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AM.FieldNumber, FAMISCaseInformation.AM.GetData)
'        glapiTP8.SubmitField(FAMISCaseInformation.AN.FieldNumber, FAMISCaseInformation.AN.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HC.FieldNumber, FAMISMedicaidInformation.HC.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IA.FieldNumber, FAMISTANFInformation.IA.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IB.FieldNumber, FAMISTANFInformation.IB.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IC.FieldNumber, FAMISTANFInformation.IC.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.ID.FieldNumber, FAMISTANFInformation.ID.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IE.FieldNumber, FAMISTANFInformation.IE.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IF1.FieldNumber, FAMISTANFInformation.IF1.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IG.FieldNumber, FAMISTANFInformation.IG.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LA.FieldNumber, FAMISFoodStampInformation.LA.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LB.FieldNumber, FAMISFoodStampInformation.LB.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LC.FieldNumber, FAMISFoodStampInformation.LC.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LD.FieldNumber, FAMISFoodStampInformation.LD.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LE.FieldNumber, FAMISFoodStampInformation.LE.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LF.FieldNumber, FAMISFoodStampInformation.LF.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.ND.FieldNumber, FAMISFoodStampInformation.ND.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PK.FieldNumber, FAMISIandAInformation.PK.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PC.FieldNumber, FAMISIandAInformation.PC.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WA.FieldNumber, FAMISMedicaidInformation.WA.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WB.FieldNumber, FAMISMedicaidInformation.WB.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WC.FieldNumber, FAMISMedicaidInformation.WC.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WD.FieldNumber, FAMISMedicaidInformation.WD.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WE.FieldNumber, FAMISMedicaidInformation.WE.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WF.FieldNumber, FAMISMedicaidInformation.WF.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WG.FieldNumber, FAMISMedicaidInformation.WG.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WL.FieldNumber, FAMISMedicaidInformation.WL.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WW.FieldNumber, FAMISMedicaidInformation.WW.GetData)
'    End Sub
'    Private Sub Submit_Page2()
'        glapiTP8.SubmitField(FAMISApplicationInformation.BA.FieldNumber, FAMISApplicationInformation.BA.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BB.FieldNumber, FAMISApplicationInformation.BB.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BC.FieldNumber, FAMISApplicationInformation.BC.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BD.FieldNumber, FAMISApplicationInformation.BD.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BE.FieldNumber, FAMISApplicationInformation.BE.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BF.FieldNumber, FAMISApplicationInformation.BF.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BG.FieldNumber, FAMISApplicationInformation.BG.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BH.FieldNumber, FAMISApplicationInformation.BH.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BI.FieldNumber, FAMISApplicationInformation.BI.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BS.FieldNumber, FAMISApplicationInformation.BS.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BT.FieldNumber, FAMISApplicationInformation.BT.GetData)
'        'glapiTP8.SubmitField(FAMISApplicationInformation.BU.FieldNumber, FAMISApplicationInformation.BU.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISApplicationInformation.BV.FieldNumber, FAMISApplicationInformation.BV.GetData)

'        glapiTP8.SubmitField(FAMISApplicationInformation.BJ.FieldNumber, FAMISApplicationInformation.BJ.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BK.FieldNumber, FAMISApplicationInformation.BK.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BL.FieldNumber, FAMISApplicationInformation.BL.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BM.FieldNumber, FAMISApplicationInformation.BM.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BN.FieldNumber, FAMISApplicationInformation.BN.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BO.FieldNumber, FAMISApplicationInformation.BO.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BP.FieldNumber, " ")
'        glapiTP8.SubmitField(FAMISApplicationInformation.BQ.FieldNumber, FAMISApplicationInformation.BQ.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BR.FieldNumber, FAMISApplicationInformation.BR.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BW.FieldNumber, FAMISApplicationInformation.BW.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.BX.FieldNumber, FAMISApplicationInformation.BX.GetData)
'        'glapiTP8.SubmitField(FAMISApplicationInformation.BY.FieldNumber, FAMISApplicationInformation.BY.GetData) --Protected
'        glapiTP8.SubmitField(FAMISApplicationInformation.BZ.FieldNumber, FAMISApplicationInformation.BZ.GetData)

'        glapiTP8.SubmitField(FAMISApplicationInformation.CA.FieldNumber, FAMISApplicationInformation.CA.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.CB.FieldNumber, FAMISApplicationInformation.CB.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.CC.FieldNumber, FAMISApplicationInformation.CC.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.CD1.FieldNumber, FAMISApplicationInformation.CD1.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.CD2.FieldNumber, FAMISApplicationInformation.CD2.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.CE.FieldNumber, FAMISApplicationInformation.CE.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.CF.FieldNumber, FAMISApplicationInformation.CF.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.CG.FieldNumber, FAMISApplicationInformation.CG.GetData)

'        glapiTP8.SubmitField(FAMISApplicationInformation.DA1.FieldNumber, FAMISApplicationInformation.DA1.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.DA2.FieldNumber, FAMISApplicationInformation.DA2.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.DA3.FieldNumber, FAMISApplicationInformation.DA3.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.DB.FieldNumber, FAMISApplicationInformation.DB.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.DC.FieldNumber, FAMISApplicationInformation.DC.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.DD1.FieldNumber, FAMISApplicationInformation.DD1.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.DD2.FieldNumber, FAMISApplicationInformation.DD2.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.DE.FieldNumber, FAMISApplicationInformation.DE.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.DF.FieldNumber, FAMISApplicationInformation.DF.GetData)

'        glapiTP8.SubmitField(FAMISApplicationInformation.EA.FieldNumber, FAMISApplicationInformation.EA.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EB.FieldNumber, FAMISApplicationInformation.EB.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EC.FieldNumber, FAMISApplicationInformation.EC.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.ED1.FieldNumber, FAMISApplicationInformation.ED1.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.ED2.FieldNumber, FAMISApplicationInformation.ED2.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EE.FieldNumber, FAMISApplicationInformation.EE.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EF.FieldNumber, FAMISApplicationInformation.EF.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EG.FieldNumber, FAMISApplicationInformation.EG.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EH.FieldNumber, FAMISApplicationInformation.EH.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EI.FieldNumber, FAMISApplicationInformation.EI.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EJ.FieldNumber, FAMISApplicationInformation.EJ.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EK.FieldNumber, FAMISApplicationInformation.EK.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EL.FieldNumber, FAMISApplicationInformation.EL.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EM.FieldNumber, FAMISApplicationInformation.EM.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.EN.FieldNumber, FAMISApplicationInformation.EN.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XM.FieldNumber, FAMISApplicationInformation.XM.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XN.FieldNumber, FAMISApplicationInformation.XN.GetData)

'        glapiTP8.SubmitField(FAMISApplicationInformation.XA.FieldNumber, FAMISApplicationInformation.XA.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XB.FieldNumber, FAMISApplicationInformation.XB.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XC.FieldNumber, FAMISApplicationInformation.XC.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XD.FieldNumber, FAMISApplicationInformation.XD.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XE.FieldNumber, FAMISApplicationInformation.XE.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XF.FieldNumber, FAMISApplicationInformation.XF.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XG.FieldNumber, FAMISApplicationInformation.XG.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XH.FieldNumber, FAMISApplicationInformation.XH.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XI.FieldNumber, FAMISApplicationInformation.XI.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XJ.FieldNumber, FAMISApplicationInformation.XJ.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XK.FieldNumber, FAMISApplicationInformation.XK.GetData)
'        glapiTP8.SubmitField(FAMISApplicationInformation.XL.FieldNumber, FAMISApplicationInformation.XL.GetData)
'    End Sub
'    Private Sub Submit_Page3()
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FA.FieldNumber, FAMISIndividualsInformation.FA.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FB.FieldNumber, FAMISIndividualsInformation.FB.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FC.FieldNumber, FAMISIndividualsInformation.FC.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FD.FieldNumber, FAMISIndividualsInformation.FD.GetData)
'        'glapiTP8.SubmitField(FAMISIndividualsInformation.FD2.FieldNumber, FAMISIndividualsInformation.FA.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FE1.FieldNumber, FAMISIndividualsInformation.FE1.GetData & FAMISIndividualsInformation.FE2.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FF.FieldNumber, FAMISIndividualsInformation.FF.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FG1.FieldNumber, FAMISIndividualsInformation.FG1.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FG2.FieldNumber, FAMISIndividualsInformation.FG2.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FG3.FieldNumber, FAMISIndividualsInformation.FG3.GetData)
'        'glapiTP8.SubmitField(FAMISIndividualsInformation.FH.FieldNumber, FAMISIndividualsInformation.FH.GetData) --Protected--

'        glapiTP8.SubmitField(FAMISIndividualsInformation.FI.FieldNumber, FAMISIndividualsInformation.FI.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FJ.FieldNumber, FAMISIndividualsInformation.FJ.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FK.FieldNumber, FAMISIndividualsInformation.FK.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FL.FieldNumber, FAMISIndividualsInformation.FL.GetData)
'        'glapiTP8.SubmitField(FAMISIndividualsInformation.FL2.FieldNumber, FAMISIndividualsInformation.FL2.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FM1.FieldNumber, FAMISIndividualsInformation.FM1.GetData & FAMISIndividualsInformation.FM2.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FN.FieldNumber, FAMISIndividualsInformation.FN.GetData)
'        'glapiTP8.SubmitField(FAMISIndividualsInformation.FO.FieldNumber, FAMISIndividualsInformation.FO.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FP1.FieldNumber, FAMISIndividualsInformation.FP1.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FP2.FieldNumber, FAMISIndividualsInformation.FP2.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.FP3.FieldNumber, FAMISIndividualsInformation.FP3.GetData)

'        glapiTP8.SubmitField(FAMISIndividualsInformation.GA.FieldNumber, FAMISIndividualsInformation.GA.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GB.FieldNumber, FAMISIndividualsInformation.GB.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GC.FieldNumber, FAMISIndividualsInformation.GC.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GD.FieldNumber, FAMISIndividualsInformation.GD.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GE.FieldNumber, FAMISIndividualsInformation.GE.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GF.FieldNumber, FAMISIndividualsInformation.GF.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GG.FieldNumber, FAMISIndividualsInformation.GG.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GH.FieldNumber, FAMISIndividualsInformation.GH.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GI.FieldNumber, FAMISIndividualsInformation.GI.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GJ.FieldNumber, FAMISIndividualsInformation.GJ.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GK.FieldNumber, FAMISIndividualsInformation.GK.GetData)
'        glapiTP8.SubmitField(FAMISIndividualsInformation.GL.FieldNumber, FAMISIndividualsInformation.GL.GetData)

'        glapiTP8.SubmitField(FAMISMedicaidInformation.HA.FieldNumber, FAMISMedicaidInformation.HA.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HB.FieldNumber, FAMISMedicaidInformation.HB.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HC.FieldNumber, FAMISMedicaidInformation.HC.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HD.FieldNumber, FAMISMedicaidInformation.HD.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HE.FieldNumber, FAMISMedicaidInformation.HE.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HF.FieldNumber, FAMISMedicaidInformation.HF.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HG.FieldNumber, FAMISMedicaidInformation.HG.GetData)
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.HH.FieldNumber, FAMISMedicaidInformation.HH.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HI.FieldNumber, FAMISMedicaidInformation.HI.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HJ.FieldNumber, FAMISMedicaidInformation.HJ.GetData)
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.HK.FieldNumber, FAMISMedicaidInformation.HK.GetData) --Protected--
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.HL.FieldNumber, FAMISMedicaidInformation.HL.GetData) --Protected--

'        glapiTP8.SubmitField(FAMISMedicaidInformation.HM.FieldNumber, FAMISMedicaidInformation.HM.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HN.FieldNumber, FAMISMedicaidInformation.HN.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HO.FieldNumber, FAMISMedicaidInformation.HO.GetData)
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.HP.FieldNumber, FAMISMedicaidInformation.HP.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HQ.FieldNumber, FAMISMedicaidInformation.HQ.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.HR.FieldNumber, FAMISMedicaidInformation.HR.GetData)
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.HS.FieldNumber, FAMISMedicaidInformation.HS.GetData) --Protected--
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.HT.FieldNumber, FAMISMedicaidInformation.HT.GetData) --Protected--

'    End Sub
'    Private Sub Submit_Page4()
'        glapiTP8.SubmitField(FAMISTANFInformation.IH.FieldNumber, FAMISTANFInformation.IH.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.II.FieldNumber, FAMISTANFInformation.II.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IJ.FieldNumber, FAMISTANFInformation.IJ.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IK.FieldNumber, FAMISTANFInformation.IK.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IL.FieldNumber, FAMISTANFInformation.IL.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IM.FieldNumber, FAMISTANFInformation.IM.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IN1.FieldNumber, FAMISTANFInformation.IN1.GetData)
'        glapiTP8.SubmitField(FAMISTANFInformation.IO.FieldNumber, FAMISTANFInformation.IO.GetData)
'        'glapiTP8.SubmitField(FAMISTANFInformation.IP.FieldNumber, FAMISTANFInformation.Ip.GetData) --Protected--

'        glapiTP8.SubmitField(FAMISIncomeInformation.JA.FieldNumber, FAMISIncomeInformation.JA.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JB.FieldNumber, FAMISIncomeInformation.JB.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JC.FieldNumber, FAMISIncomeInformation.JC.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JD.FieldNumber, FAMISIncomeInformation.JD.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JE.FieldNumber, FAMISIncomeInformation.JE.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JF.FieldNumber, FAMISIncomeInformation.JF.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JG.FieldNumber, FAMISIncomeInformation.JG.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JH.FieldNumber, FAMISIncomeInformation.JH.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JI.FieldNumber, FAMISIncomeInformation.JI.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JJ.FieldNumber, FAMISIncomeInformation.JJ.GetData)
'        'glapiTP8.SubmitField(FAMISIncomeInformation.JK.FieldNumber, FAMISIncomeInformation.JK.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIncomeInformation.JL.FieldNumber, FAMISIncomeInformation.JL.GetData)
'        'glapiTP8.SubmitField(FAMISIncomeInformation.JM.FieldNumber, FAMISIncomeInformation.JM.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIncomeInformation.JN.FieldNumber, FAMISIncomeInformation.JN.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JO.FieldNumber, FAMISIncomeInformation.JO.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JP.FieldNumber, FAMISIncomeInformation.JP.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JQ.FieldNumber, FAMISIncomeInformation.JQ.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JR.FieldNumber, FAMISIncomeInformation.JR.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JS.FieldNumber, FAMISIncomeInformation.JS.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JT.FieldNumber, FAMISIncomeInformation.JT.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JU.FieldNumber, FAMISIncomeInformation.JU.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JV.FieldNumber, " ")
'        glapiTP8.SubmitField(FAMISIncomeInformation.JW.FieldNumber, FAMISIncomeInformation.JW.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.JX.FieldNumber, FAMISIncomeInformation.JX.GetData)

'        glapiTP8.SubmitField(FAMISIncomeInformation.KA.FieldNumber, FAMISIncomeInformation.KA.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KB.FieldNumber, FAMISIncomeInformation.KB.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KC.FieldNumber, FAMISIncomeInformation.KC.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KD.FieldNumber, FAMISIncomeInformation.KD.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KE.FieldNumber, FAMISIncomeInformation.KE.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KF.FieldNumber, FAMISIncomeInformation.KF.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KG.FieldNumber, FAMISIncomeInformation.KG.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KH.FieldNumber, FAMISIncomeInformation.KH.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KI.FieldNumber, FAMISIncomeInformation.KI.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KJ.FieldNumber, FAMISIncomeInformation.KJ.GetData)
'        'glapiTP8.SubmitField(FAMISIncomeInformation.KK.FieldNumber, FAMISIncomeInformation.KK.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIncomeInformation.KL.FieldNumber, FAMISIncomeInformation.KL.GetData)
'        'glapiTP8.SubmitField(FAMISIncomeInformation.KM.FieldNumber, FAMISIncomeInformation.KM.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIncomeInformation.KN.FieldNumber, FAMISIncomeInformation.KN.GetData)
'        'glapiTP8.SubmitField(FAMISIncomeInformation.KO.FieldNumber, FAMISIncomeInformation.KO.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIncomeInformation.KP.FieldNumber, "       ")
'        'glapiTP8.SubmitField(FAMISIncomeInformation.KQ.FieldNumber, FAMISIncomeInformation.KQ.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISIncomeInformation.KR.FieldNumber, FAMISIncomeInformation.KR.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KS.FieldNumber, FAMISIncomeInformation.KS.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KT.FieldNumber, " ")
'        glapiTP8.SubmitField(FAMISIncomeInformation.KU.FieldNumber, FAMISIncomeInformation.KU.GetData)
'        glapiTP8.SubmitField(FAMISIncomeInformation.KV.FieldNumber, FAMISIncomeInformation.KV.GetData)

'        glapiTP8.SubmitField(FAMISFoodStampInformation.WX.FieldNumber, FAMISFoodStampInformation.WX.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.WY.FieldNumber, FAMISFoodStampInformation.WY.GetData)
'    End Sub
'    Private Sub Submit_Page5()
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LG.FieldNumber, FAMISFoodStampInformation.LG.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LH.FieldNumber, FAMISFoodStampInformation.LH.GetData)
'        'glapiTP8.SubmitField(FAMISFoodStampInformation.LI.FieldNumber, FAMISFoodStampInformation.LI.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LJ.FieldNumber, FAMISFoodStampInformation.LJ.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LK.FieldNumber, FAMISFoodStampInformation.LK.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LL.FieldNumber, FAMISFoodStampInformation.LL.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LM.FieldNumber, FAMISFoodStampInformation.LM.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LN.FieldNumber, FAMISFoodStampInformation.LN.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LO.FieldNumber, FAMISFoodStampInformation.LO.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LP.FieldNumber, FAMISFoodStampInformation.LP.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LQ.FieldNumber, FAMISFoodStampInformation.LQ.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LR.FieldNumber, FAMISFoodStampInformation.LR.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LS.FieldNumber, FAMISFoodStampInformation.LS.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.LT.FieldNumber, FAMISFoodStampInformation.LT.GetData)

'        glapiTP8.SubmitField(FAMISFoodStampInformation.MA.FieldNumber, FAMISFoodStampInformation.MA.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MB.FieldNumber, FAMISFoodStampInformation.MB.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MC.FieldNumber, FAMISFoodStampInformation.MC.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MD.FieldNumber, FAMISFoodStampInformation.MD.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.ME1.FieldNumber, FAMISFoodStampInformation.ME1.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MF.FieldNumber, FAMISFoodStampInformation.MF.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MG.FieldNumber, FAMISFoodStampInformation.MG.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MH.FieldNumber, FAMISFoodStampInformation.MH.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MI.FieldNumber, FAMISFoodStampInformation.MI.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MJ.FieldNumber, FAMISFoodStampInformation.MJ.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MK.FieldNumber, FAMISFoodStampInformation.MK.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.ML.FieldNumber, FAMISFoodStampInformation.ML.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MM.FieldNumber, FAMISFoodStampInformation.MM.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MN.FieldNumber, FAMISFoodStampInformation.MN.GetData)
'        'glapiTP8.SubmitField(FAMISFoodStampInformation.MO.FieldNumber, FAMISFoodStampInformation.MO.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MP.FieldNumber, FAMISFoodStampInformation.MP.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MQ.FieldNumber, FAMISFoodStampInformation.MQ.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.MR.FieldNumber, FAMISFoodStampInformation.MR.GetData)

'        glapiTP8.SubmitField(FAMISFoodStampInformation.NA.FieldNumber, FAMISFoodStampInformation.NA.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NB.FieldNumber, FAMISFoodStampInformation.NB.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NC.FieldNumber, FAMISFoodStampInformation.NC.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.ND.FieldNumber, FAMISFoodStampInformation.ND.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NE.FieldNumber, FAMISFoodStampInformation.NE.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NF.FieldNumber, FAMISFoodStampInformation.NF.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NG.FieldNumber, FAMISFoodStampInformation.NG.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NH.FieldNumber, FAMISFoodStampInformation.NH.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NI.FieldNumber, FAMISFoodStampInformation.NI.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NJ.FieldNumber, FAMISFoodStampInformation.NJ.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NK.FieldNumber, FAMISFoodStampInformation.NK.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NL.FieldNumber, FAMISFoodStampInformation.NL.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NM.FieldNumber, FAMISFoodStampInformation.NM.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NN.FieldNumber, FAMISFoodStampInformation.NN.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.NO.FieldNumber, FAMISFoodStampInformation.NO.GetData)
'        'glapiTP8.SubmitField(FAMISFoodStampInformation.NP.FieldNumber, FAMISFoodStampInformation.NP.GetData) --Protected--
'    End Sub
'    Private Sub Submit_Page6()
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OA.FieldNumber, FAMISFoodStampInformation.OA.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OB.FieldNumber, FAMISFoodStampInformation.OB.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OC.FieldNumber, FAMISFoodStampInformation.OC.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OD.FieldNumber, FAMISFoodStampInformation.OD.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OE.FieldNumber, FAMISFoodStampInformation.OE.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OF1.FieldNumber, FAMISFoodStampInformation.OF1.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OG.FieldNumber, FAMISFoodStampInformation.OG.GetData)
'        'glapiTP8.SubmitField(FAMISFoodStampInformation.OH.FieldNumber, FAMISFoodStampInformation.OH.GetData) --Protected--
'        'glapiTP8.SubmitField(FAMISFoodStampInformation.OI.FieldNumber, FAMISFoodStampInformation.OI.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OJ.FieldNumber, FAMISFoodStampInformation.OJ.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OK.FieldNumber, FAMISFoodStampInformation.OK.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OM.FieldNumber, FAMISFoodStampInformation.OM.GetData)
'        glapiTP8.SubmitField(FAMISFoodStampInformation.ON1.FieldNumber, FAMISFoodStampInformation.ON1.GetData)
'        'glapiTP8.SubmitField(FAMISFoodStampInformation.OO.FieldNumber, FAMISFoodStampInformation.OO.GetData) --Protected--
'        'glapiTP8.SubmitField(FAMISFoodStampInformation.OP.FieldNumber, FAMISFoodStampInformation.OP.GetData) --Protected--

'        glapiTP8.SubmitField(FAMISIandAInformation.PA.FieldNumber, FAMISIandAInformation.PA.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PB.FieldNumber, FAMISIandAInformation.PB.GetData)
'        'glapiTP8.SubmitField(FAMISIandAInformation.PC.FieldNumber, FAMISIandAInformation.PC.GetData) --Not Used--
'        glapiTP8.SubmitField(FAMISIandAInformation.PD.FieldNumber, FAMISIandAInformation.PD.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PE.FieldNumber, FAMISIandAInformation.PE.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PF.FieldNumber, FAMISIandAInformation.PF.GetData)
'        'glapiTP8.SubmitField(FAMISIandAInformation.PG.FieldNumber, FAMISIandAInformation.PG.GetData) --Protected--
'        'glapiTP8.SubmitField(FAMISIandAInformation.PH.FieldNumber, FAMISIandAInformation.PH.GetData) --Protected--

'        glapiTP8.SubmitField(FAMISIandAInformation.PI.FieldNumber, FAMISIandAInformation.PI.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PJ.FieldNumber, FAMISIandAInformation.PJ.GetData)
'        'glapiTP8.SubmitField(FAMISIandAInformation.PK.FieldNumber, FAMISIandAInformation.PK.GetData) --Not Used--
'        glapiTP8.SubmitField(FAMISIandAInformation.PL.FieldNumber, FAMISIandAInformation.PL.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PM.FieldNumber, FAMISIandAInformation.PM.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PN.FieldNumber, FAMISIandAInformation.PN.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PP.FieldNumber, FAMISIandAInformation.PP.GetData)
'    End Sub
'    Private Sub Submit_Child()
'        Dim i As Integer
'        Dim QAEntered As String = Nothing
'        For i = 0 To numChildren - 1
'            QAEntered = FAMISCaseChild(i).QA.GetData
'            glapiTP8.SendCommand(FAMISCaseChild(i).QA.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QA.FieldNumber, FAMISCaseChild(i).QA.GetData)
'            glapiTP8.TransmitPage()
'            If glapiTP8.GetString(1, 2, 22, 2) = "PERSON CODE NOT ON OTF" Then
'                glapiTP8.SubmitField(FAMISCaseChild(i).QA.FieldNumber, "+")
'                glapiTP8.SendCommand("    ")
'            ElseIf glapiTP8.GetField(FAMISCaseChild(i).QA.FieldNumber) <> "+" Then
'                glapiTP8.SubmitField(FAMISCaseChild(i).QA.FieldNumber, FAMISCaseChild(i).QA.GetData)
'                glapiTP8.SendCommand(FAMISCaseChild(i).QA.GetData)
'                glapiTP8.SubmitField(FAMISCaseChild(i).QB.FieldNumber, FAMISCaseChild(i).QB.GetData)
'                glapiTP8.TransmitPage()
'            End If
'            glapiTP8.SubmitField(FAMISCaseChild(i).QB.FieldNumber, FAMISCaseChild(i).QB.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QC.FieldNumber, FAMISCaseChild(i).QC.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QD.FieldNumber, FAMISCaseChild(i).QD.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QE1.FieldNumber, FAMISCaseChild(i).QE1.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QF.FieldNumber, FAMISCaseChild(i).QF.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QG.FieldNumber, FAMISCaseChild(i).QG.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QH.FieldNumber, FAMISCaseChild(i).QH.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QI1.FieldNumber, FAMISCaseChild(i).QI1.GetData & FAMISCaseChild(i).QI2.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QJ.FieldNumber, FAMISCaseChild(i).QJ.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QK.FieldNumber, FAMISCaseChild(i).QK.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QL.FieldNumber, FAMISCaseChild(i).QL.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QM.FieldNumber, FAMISCaseChild(i).QM.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QN.FieldNumber, FAMISCaseChild(i).QN.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).QO.FieldNumber, FAMISCaseChild(i).QO.GetData)

'            glapiTP8.SubmitField(FAMISCaseChild(i).RA.FieldNumber, FAMISCaseChild(i).RA.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RB.FieldNumber, FAMISCaseChild(i).RB.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RC.FieldNumber, FAMISCaseChild(i).RC.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RD.FieldNumber, FAMISCaseChild(i).RD.GetData)
'            'glapiTP8.SubmitField(FAMISCaseChild(i).RE.FieldNumber, FAMISCaseChild(i).RE.GetData) --Protected--
'            'glapiTP8.SubmitField(FAMISCaseChild(i).RF.FieldNumber, FAMISCaseChild(i).RF.GetData) --Protected--
'            glapiTP8.SubmitField(FAMISCaseChild(i).RG.FieldNumber, FAMISCaseChild(i).RG.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RH.FieldNumber, FAMISCaseChild(i).RH.GetData)
'            'glapiTP8.SubmitField(FAMISCaseChild(i).RH2.FieldNumber, FAMISCaseChild(i).RH2.GetData) --Protected--
'            glapiTP8.SubmitField(FAMISCaseChild(i).RI.FieldNumber, FAMISCaseChild(i).RI.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RJ1.FieldNumber, FAMISCaseChild(i).RJ1.GetData & FAMISCaseChild(i).RJ2.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RK.FieldNumber, FAMISCaseChild(i).RK.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RL.FieldNumber, FAMISCaseChild(i).RL.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RM.FieldNumber, FAMISCaseChild(i).RM.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RN.FieldNumber, FAMISCaseChild(i).RN.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RO.FieldNumber, FAMISCaseChild(i).RO.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RP.FieldNumber, FAMISCaseChild(i).RP.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RQ.FieldNumber, FAMISCaseChild(i).RQ.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).RR.FieldNumber, FAMISCaseChild(i).RR.GetData)

'            glapiTP8.SubmitField(FAMISCaseChild(i).SA.FieldNumber, FAMISCaseChild(i).SA.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SB.FieldNumber, FAMISCaseChild(i).SB.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SC.FieldNumber, FAMISCaseChild(i).SC.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SD.FieldNumber, FAMISCaseChild(i).SD.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SE.FieldNumber, FAMISCaseChild(i).SE.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SF.FieldNumber, FAMISCaseChild(i).SF.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SG.FieldNumber, FAMISCaseChild(i).SG.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SH.FieldNumber, FAMISCaseChild(i).SH.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SI.FieldNumber, FAMISCaseChild(i).SI.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SJ.FieldNumber, FAMISCaseChild(i).SJ.GetData)
'            'glapiTP8.SubmitField(FAMISCaseChild(i).SK.FieldNumber, FAMISCaseChild(i).SK.GetData) --Protected--
'            glapiTP8.SubmitField(FAMISCaseChild(i).SL.FieldNumber, FAMISCaseChild(i).SL.GetData)
'            'glapiTP8.SubmitField(FAMISCaseChild(i).SM.FieldNumber, FAMISCaseChild(i).SM.GetData) --Protected--
'            glapiTP8.SubmitField(FAMISCaseChild(i).SN.FieldNumber, FAMISCaseChild(i).SN.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SO.FieldNumber, FAMISCaseChild(i).SO.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SP.FieldNumber, FAMISCaseChild(i).SP.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SQ.FieldNumber, FAMISCaseChild(i).SQ.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).SR.FieldNumber, FAMISCaseChild(i).SR.GetData & " ")
'            glapiTP8.SubmitField(FAMISCaseChild(i).SS.FieldNumber, FAMISCaseChild(i).SS.GetData)
'            'glapiTP8.SubmitField(FAMISCaseChild(i).ST.FieldNumber, FAMISCaseChild(i).ST.GetData) --Protected--

'            glapiTP8.TransmitPage()
'            PageErrorCheck("07", "08")

'            glapiTP8.SubmitField(FAMISCaseChild(i).TA.FieldNumber, FAMISCaseChild(i).TA.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TB.FieldNumber, FAMISCaseChild(i).TB.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TC.FieldNumber, "       ")
'            glapiTP8.SubmitField(FAMISCaseChild(i).TD.FieldNumber, FAMISCaseChild(i).TD.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TE.FieldNumber, FAMISCaseChild(i).TE.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TF.FieldNumber, " ")
'            glapiTP8.SubmitField(FAMISCaseChild(i).TG.FieldNumber, FAMISCaseChild(i).TG.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TH.FieldNumber, FAMISCaseChild(i).TH.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TI1.FieldNumber, FAMISCaseChild(i).TI1.GetData & FAMISCaseChild(i).TI2.GetData & FAMISCaseChild(i).TI3.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TJ.FieldNumber, FAMISCaseChild(i).TJ.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TK.FieldNumber, FAMISCaseChild(i).TK.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TL.FieldNumber, FAMISCaseChild(i).TL.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TM.FieldNumber, FAMISCaseChild(i).TM.GetData)
'            'glapiTP8.SubmitField(FAMISCaseChild(i).TN.FieldNumber, FAMISCaseChild(i).TN.GetData) --Not Used--
'            glapiTP8.SubmitField(FAMISCaseChild(i).TO1.FieldNumber, FAMISCaseChild(i).TO1.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TP.FieldNumber, FAMISCaseChild(i).TP.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TQ.FieldNumber, FAMISCaseChild(i).TQ.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TR.FieldNumber, FAMISCaseChild(i).TR.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).TS.FieldNumber, FAMISCaseChild(i).TS.GetData)

'            glapiTP8.SubmitField(FAMISCaseChild(i).UA.FieldNumber, FAMISCaseChild(i).UA.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).UB.FieldNumber, FAMISCaseChild(i).UB.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).UC.FieldNumber, FAMISCaseChild(i).UC.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).UD.FieldNumber, FAMISCaseChild(i).UD.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).UE.FieldNumber, FAMISCaseChild(i).UE.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).UF.FieldNumber, FAMISCaseChild(i).UF.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).UG.FieldNumber, FAMISCaseChild(i).UG.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).UH.FieldNumber, FAMISCaseChild(i).UH.GetData)
'            glapiTP8.SubmitField(FAMISCaseChild(i).UI.FieldNumber, FAMISCaseChild(i).UI.GetData)

'            glapiTP8.TransmitPage()
'            PageErrorCheck("08", "07")
'        Next
'        glapiTP8.SendCommand(QAEntered)
'        glapiTP8.SubmitField(FAMISCaseChild(0).QA.FieldNumber, QAEntered)
'        glapiTP8.TransmitPage()
'    End Sub
'    Private Sub Submit_Page9()
'        Dim i As Integer
'        glapiTP8.SubmitField(FAMISFoodStampInformation.OL.FieldNumber, FAMISFoodStampInformation.OL.GetData)
'        glapiTP8.SubmitField(FAMISIandAInformation.PO.FieldNumber, FAMISIandAInformation.PO.GetData)
'        For i = 0 To numVRP - 1
'            glapiTP8.SubmitField(FAMISVRPInformation(i).VE.FieldNumber, FAMISVRPInformation(i).VE.GetData)
'            glapiTP8.SubmitField(FAMISVRPInformation(i).VG.FieldNumber, FAMISVRPInformation(i).VG.GetData)
'            glapiTP8.SubmitField(FAMISVRPInformation(i).VI.FieldNumber, FAMISVRPInformation(i).VI.GetData)
'            glapiTP8.SubmitField(FAMISVRPInformation(i).VK.FieldNumber, FAMISVRPInformation(i).VK.GetData)
'            glapiTP8.SubmitField(FAMISVRPInformation(i).VM.FieldNumber, FAMISVRPInformation(i).VM.GetData)
'            glapiTP8.SubmitField(FAMISVRPInformation(i).VO.FieldNumber, FAMISVRPInformation(i).VO.GetData)
'            'glapiTP8.SubmitField(FAMISVRPInformation(i).VQ.FieldNumber, FAMISVRPInformation(i).VQ.GetData) --Not Used--
'        Next
'    End Sub
'    Private Sub Submit_Page10()
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WH.FieldNumber, FAMISMedicaidInformation.WH.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WI.FieldNumber, FAMISMedicaidInformation.WI.GetData)
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.WK.FieldNumber, FAMISMedicaidInformation.WK.GetData) --Protected--
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.WM.FieldNumber, FAMISMedicaidInformation.WM.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WN.FieldNumber, FAMISMedicaidInformation.WN.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WO.FieldNumber, FAMISMedicaidInformation.WO.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WP.FieldNumber, FAMISMedicaidInformation.WP.GetData)
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WQ.FieldNumber, FAMISMedicaidInformation.WQ.GetData)
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.WR.FieldNumber, FAMISMedicaidInformation.WR.GetData) --Protected--
'        glapiTP8.SubmitField(FAMISMedicaidInformation.WS.FieldNumber, FAMISMedicaidInformation.WS.GetData)
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.WT.FieldNumber, FAMISMedicaidInformation.WT.GetData) --Protected--
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.WU.FieldNumber, FAMISMedicaidInformation.WU.GetData) --Protected--
'        'glapiTP8.SubmitField(FAMISMedicaidInformation.WV.FieldNumber, FAMISMedicaidInformation.WV.GetData) --Protected--
'    End Sub

'    Sub Read_TextFile()
'        Try
'            Dim infile As New StreamReader(FilePath & FileName, System.Text.Encoding.Default)
'            Dim Record As String
'            numChildren = 0
'            numVRP = 0

'            While infile.Peek <> -1
'                Record = infile.ReadLine()
'                If Record <> Nothing Then
'                    Select Case Record.Substring(44, 40)
'                        Case "FAMISAFDCInformation                    "
'                            TEXT_AFDCInformation = Record
'                        Case "FAMISApplicantInformation               "
'                            TEXT_ApplicationInformation = Record
'                        Case "FAMISCaseChild                          "
'                            TEXT_CaseChild(numChildren) = Record
'                            numChildren += 1
'                        Case "FAMISCaseInformation                    "
'                            TEXT_CaseInformation = Record
'                        Case "FAMISFoodStampInformation               "
'                            TEXT_FoodStampInformation = Record
'                        Case "FAMISIndividualsInformation             "
'                            TEXT_IndividualsInformation = Record
'                        Case "FAMISIandAInformation                   "
'                            TEXT_IandAInformation = Record
'                        Case "FAMISIncomeInformation                  "
'                            TEXT_IncomeInformation = Record
'                        Case "FAMISIndividualsInformation             "
'                            TEXT_IndividualsInformation = Record
'                        Case "FAMISMedicaidInformation                "
'                            TEXT_MedicaidInformation = Record
'                        Case "FAMISCaseVRPInformation                 "
'                            TEXT_VRPInformation(numVRP) = Record
'                            numVRP += 1
'                    End Select
'                End If
'            End While
'            infile.Close()
'        Catch ex As Exception
'            MessageBox.Show(ex.Message.ToString)
'        End Try
'    End Sub

'    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
'        ColorDialog1.ShowDialog()
'        My.Settings.tBackColor = ColorDialog1.Color
'        Me.BackColor = ColorDialog1.Color
'    End Sub
'End Class