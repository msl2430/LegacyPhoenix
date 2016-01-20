Module Reports
    Public PrintChoice, ReportApp As String
    Public ParentControl As ControlScreen
    Public ReportDate As Date
    Private ReportTitle, ReportHeadline As String
    Private File_Writer As StreamWriter
    Private CaseNumber, BatchNumber, ErrorMessage1, ErrorMessage2, ErrorMessage3, ErrorMessage4, ErrorMessage5 As String

    Public Sub PrintReport()
        Dim SQLConn As New SqlConnection(My.Settings.phxSQLConn)
        Dim SQLComm As New SqlCommand
        Dim Reader As SqlDataReader
        Dim ErrorMsg, tempErrorMsg1, tempErrorMsg2 As String
        SQLComm.Connection = SQLConn
        Select Case ReportApp
            Case "Medicaid"
                ReportTitle = "Phoenix - Medicaid Processing"
                ReportHeadline = "               MEDICAID CASE PROCESSING RESULTS                      "
                CreateDoc()
                Try
                    SQLConn.Open()
                    File_Writer.WriteLine("   Case Number  Per #  OPS  WORKER  RESULT   Reason" & vbCrLf)
                    Select Case PrintChoice
                        Case "All" : SQLComm.CommandText = "SELECT DISTINCT CaseNumber, TextFile, DateEntered, Operator, Ops, PersonNumber, Result, Reason FROM TRANSACTIONLOG WHERE DATEENTERED = '" & ReportDate.Month & "/" & ReportDate.Day & "/" & ReportDate.Year & "' ORDER BY Operator, CaseNumber, PersonNumber, Result"
                        Case "Success" : SQLComm.CommandText = "SELECT DISTINCT CaseNumber, TextFile, DateEntered, Operator, Ops, PersonNumber, Result, Reason FROM TRANSACTIONLOG WHERE DATEENTERED = '" & ReportDate.Month & "/" & ReportDate.Day & "/" & ReportDate.Year & "' AND Result = 'SUCCESS' ORDER BY Operator, CaseNumber, PersonNumber, Result"
                        Case "Dropped" : SQLComm.CommandText = "SELECT DISTINCT CaseNumber, TextFile, DateEntered, Operator, Ops, PersonNumber, Result, Reason FROM TRANSACTIONLOG WHERE DATEENTERED = '" & ReportDate.Month & "/" & ReportDate.Day & "/" & ReportDate.Year & "' AND Result = 'FAILED' ORDER BY Operator, CaseNumber, PersonNumber, Result"
                        Case "Redet Deleted" : SQLComm.CommandText = "SELECT DISTINCT TRANSACTIONLOG.CaseNumber, TRANSACTIONLOG.TextFile, TRANSACTIONLOG.DateEntered, TRANSACTIONLOG.Operator, TRANSACTIONLOG.Ops, TRANSACTIONLOG.PersonNumber, TRANSACTIONLOG.Result, TRANSACTIONLOG.Reason FROM TRANSACTIONLOG, OPS66 WHERE TRANSACTIONLOG.CASENUMBER = OPS66.CASENUMBER AND TRANSACTIONLOG.PERSONNUMBER = OPS66.PERSONNUMBER AND OPS66.ACTIONCODE = 'D' AND TRANSACTIONLOG.OPS = '61' AND TRANSACTIONLOG.DATEENTERED = '" & ReportDate.Month & "/" & ReportDate.Day & "/" & ReportDate.Year & "' AND TRANSACTIONLOG.RESULT = 'SUCCESS'"
                    End Select
                    Reader = SQLComm.ExecuteReader
                    While Reader.Read()
                        tempErrorMsg1 = Reader.GetString(7).Substring(0, 35)
                        tempErrorMsg2 = Reader.GetString(7).Substring(36, 35)
                        If tempErrorMsg2.Substring(0, 10) <> "          " Then
                            ErrorMsg = tempErrorMsg1 & vbCrLf & tempErrorMsg2.PadLeft(79, " ")
                        Else
                            ErrorMsg = tempErrorMsg1
                        End If
                        If ErrorMsg.Substring(0, 6) <> " Perso" And ErrorMsg.Substring(0, 6) <> "Person" And ErrorMsg.Substring(0, 6) <> " Child" Then
                            WriteReport(Reader.GetString(0), Reader.GetString(5).Substring(0, 2), Reader.GetString(4).Substring(0, 2), Reader.GetString(3).Substring(0, 6), Reader.GetString(6).Substring(0, 7), ErrorMsg)
                        End If
                    End While
                Catch ex As Exception
                    MessageBox.Show("Location: PrintReport" & vbCrLf & ex.Message.ToString)
                Finally
                    File_Writer.Close()
                    SQLConn.Close()
                    'Print()
                End Try
            Case "IMPS"
                Try
                    ReportTitle = "Phoenix - IMPs Processing"
                    ReportHeadline = "               IMPs CASE PROCESSING RESULTS                      "
                    CreateDoc()
                    SQLConn.Open()
                    File_Writer.WriteLine(vbCrLf & "--CASES DROPPED TODAY--" & vbCrLf)

                    SQLComm.CommandText = "SELECT CASENUMBER, REASON, REASON2, REASON3, REASON4, REASON5 FROM IMPSInformation WHERE Dropped = 'True' and dateentered = '" & ReportDate.Month & "/" & ReportDate.Day & "/" & ReportDate.Year & "'"
                    Reader = SQLComm.ExecuteReader
                    If Reader.HasRows = True Then
                        While Reader.Read
                            If Reader.IsDBNull(0) = False Then CaseNumber = Reader.GetString(0)
                            If Reader.IsDBNull(1) = False Then ErrorMessage1 = Reader.GetString(1)
                            If Reader.IsDBNull(2) = False Then ErrorMessage2 = Reader.GetString(2)
                            If Reader.IsDBNull(3) = False Then ErrorMessage3 = Reader.GetString(3)
                            If Reader.IsDBNull(4) = False Then ErrorMessage4 = Reader.GetString(4)
                            If Reader.IsDBNull(5) = False Then ErrorMessage5 = Reader.GetString(5)
                            WriteDropSheet()
                        End While
                    Else
                        File_Writer.WriteLine("*****No Dropped Cases*****")
                    End If
                    Reader.Close()
                    File_Writer.WriteLine(vbCrLf & vbCrLf & "--CASES COMPLETED TODAY--" & vbCrLf)

                    SQLComm.CommandText = "SELECT CASENUMBER, BATCHNUMBER FROM IMPSInformation WHERE Dropped = 'False' and DateEntered = '" & ReportDate.Month & "/" & ReportDate.Day & "/" & ReportDate.Year & "'"
                    Reader = SQLComm.ExecuteReader
                    If Reader.HasRows = True Then
                        While Reader.Read
                            If Reader.IsDBNull(0) = False Then CaseNumber = Reader.GetString(0)
                            If Reader.IsDBNull(1) = False Then BatchNumber = Reader.GetString(1)
                            WriteSuccessSheet()
                        End While
                    Else
                        File_Writer.WriteLine("*****No Completed Cases Today*****")
                    End If
                    Reader.Close()
                Catch ex As Exception
                    MessageBox.Show("Location: PrintReport" & vbCrLf & ex.Message.ToString)
                Finally
                    File_Writer.Close()
                    SQLConn.Close()
                    ' Print()
                End Try
            Case "FAMIS"
                ReportTitle = "Phoenix - FAMIS Processing"
                ReportHeadline = "               FAMIS CASE PROCESSING RESULTS                      "
                CreateDoc()
                Try
                    SQLConn.Open()
                    File_Writer.WriteLine(vbCrLf & vbCrLf & "Case Number           Operator          Batch Number" & vbCrLf)
                    SQLComm.CommandText = "SELECT CaseNumber, Operator, BatchNumber FROM FAMISCaseInformation WHERE DateEntered = '" & ReportDate.Month & "/" & ReportDate.Day & "/" & ReportDate.Year & "' ORDER BY Operator, BatchNumber"
                    Reader = SQLComm.ExecuteReader
                    While Reader.Read
                        If Reader.HasRows = True Then
                            File_Writer.WriteLine(Reader.GetString(0) & "            " & Reader.GetString(1) & "            " & Reader.GetString(2))
                        End If
                    End While
                Catch ex As Exception
                    MessageBox.Show("Location: PrintReport" & vbCrLf & ex.Message.ToString)
                Finally
                    File_Writer.Close()
                    SQLConn.Close()
                    'Print()
                End Try
        End Select

    End Sub

    'Public Sub Print()
    '    Dim ReportType As String = "(" & PrintChoice & ")"
    '    Dim oWord As Word.Application
    '    Dim FootNote As String = Microsoft.VisualBasic.Mid(ReportTitle, 1)
    '    oWord = New Word.ApplicationClass
    '    oWord.Documents.Add(My.Application.Info.DirectoryPath & "\StatSheet.doc")
    '    oWord.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
    '    oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter
    '    oWord.Selection.TypeText(ReportTitle & " " & ReportType.PadRight(85, " "))
    '    oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader
    '    oWord.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
    '    oWord.Selection.TypeText("Page: ")
    '    oWord.Selection.Fields.Add(oWord.Selection.Range, Word.WdFieldType.wdFieldPage)
    '    'oWord.PrintOut(False)
    '    'oWord.Quit(0)
    '    'oWord = Nothing
    '    oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument
    '    oWord.Visible = True
    'End Sub

    Private Sub CreateDoc()
        If File.Exists(My.Application.Info.DirectoryPath & "\StatSheet.doc") Then File.Delete(My.Application.Info.DirectoryPath & "\StatSheet.doc")
        File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "\StatSheet.doc", True)
        File_Writer.WriteLine(ReportHeadline & ReportDate.Month & "/" & ReportDate.Day & "/" & ReportDate.Year & vbCrLf)
    End Sub
    Private Sub WriteReport(ByVal CaseNumber As String, ByVal PerNum As String, ByVal OPTs As String, ByVal Worker As String, ByVal Result As String, ByVal Reason As String)
        File_Writer.WriteLine("   " & CaseNumber & "   " & PerNum & "     " & OPTs & "   " & Worker & "  " & Result & "  " & Reason)
    End Sub
    Private Sub WriteDropSheet()
        File_Writer.WriteLine("Case Number: " & CaseNumber) ' & CrLf & "        Error Reason: " & ERRORMESSAGE1 & CrLf & "        Error Reason: " & ERRORMESSAGE2 & CrLf & "        Error Reason: " & ERRORMESSAGE3 & CrLf & "        Error Reason: " & ERRORMESSAGE4 & CrLf & "        Error Reason: " & ERRORMESSAGE5 & CrLf)
        If ErrorMessage1.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ErrorMessage1)
        End If
        If ErrorMessage2.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ErrorMessage2)
        End If
        If ErrorMessage3.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ErrorMessage3)
        End If
        If ErrorMessage4.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ErrorMessage4)
        End If
        If ErrorMessage5.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ErrorMessage5)
        End If
    End Sub
    Private Sub WriteSuccessSheet()
        File_Writer.WriteLine("Case Number: " & CaseNumber & "    Batch Number: " & BatchNumber)
    End Sub
End Module
