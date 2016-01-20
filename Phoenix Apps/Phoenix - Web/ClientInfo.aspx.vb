Imports System.Data.SqlClient

Partial Class ClientInfo
    Inherits System.Web.UI.Page

    Private SocialSecurity, Supervisor, Worker, CaseNumber, FirstName, LastName, Address1, Address2, City, State, ZipCode, DateOfBirth, Sex As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SocialSecurity = Request.QueryString("SSN")
        FirstName = Request.QueryString("FN")
        LastName = Request.QueryString("LN")
        Page.Header.Title = FirstName & " " & LastName
        Response.Write("<pre>")
        CreateReport()
        Response.Write("</pre>")
    End Sub

    Public Sub CreateReport()
        Dim tempDate, tempDate2 As String
        Dim SQLConn As New SqlConnection("Data Source=172.16.8.15\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password") '" & My.Settings.ServerAddress & "\PHOENIX;Initial Catalog=PhoenixCaseData;Persist Security Info=True;User ID=FAMISUser;Password=password")
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        SQLComm.Connection = SQLConn
        SQLConn.Open()

        SQLComm.CommandText = "SELECT CaseNumber, Supervisor, Worker, Address1, Address2, City, State, Zip, Sex, DateOfBirth FROM ClientDataMaster WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
        SQLReader = SQLComm.ExecuteReader
        If SQLReader.Read Then
            CaseNumber = SQLReader.GetString(0)
            Supervisor = SQLReader.GetString(1)
            Worker = SQLReader.GetString(2)
            Address1 = SQLReader.GetString(3)
            Address2 = SQLReader.GetString(4)
            City = SQLReader.GetString(5)
            State = SQLReader.GetString(6)
            ZipCode = SQLReader.GetString(7)
            Sex = SQLReader.GetString(8)
            DateOfBirth = SQLReader.GetString(9)
            SQLReader.Close()

            '--Header information--
            If Address2 = "                    " Or Address2.Substring(0, 1) = "-" Then
                WriteInfo("Social Security: " & SocialSecurity.Insert(3, "-").Insert(6, "-") & "    " & "Address: ".PadLeft(28, " ") & Address1)
                WriteInfo("Last Name: " & LastName.PadRight(12, " ") & "   First Name: " & FirstName.PadRight(22, " ") & City.Replace(" ", "") & " ," & State & " " & ZipCode)
                If DateOfBirth <> " " Then WriteInfo("Date of Birth: " & DateOfBirth.Insert(2, "/").Insert(5, "/").PadRight(43, " "))
            Else
                WriteInfo("Social Security: " & SocialSecurity.Insert(3, "-").Insert(6, "-") & "    " & "Address: ".PadLeft(28, " ") & Address2)
                WriteInfo("Last Name: " & LastName.PadRight(12, " ") & "   First Name: " & FirstName.PadRight(22, " ") & Address1) 'City.Replace(" ", "") & " ," & State & " " & ZipCode)
                If DateOfBirth <> " " Then WriteInfo("Date of Birth: " & DateOfBirth.Insert(2, "/").Insert(5, "/").PadRight(45, " ") & City.Replace(" ", "") & ", " & State & " " & ZipCode)
            End If
            WriteInfo("Sex: " & Sex)
            WriteInfo("Supervisor: " & Supervisor & " Worker: " & Worker)
            WriteInfo(vbCrLf & "FAMIS INFORATION----------------------------------------------------------------" & vbCrLf)

            '--Find Information--
            SQLComm.CommandText = "SELECT * FROM FAMISFindInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            WriteInfo("-------CASE NAME------- -CO- -CaseNumber- -PC- -SEG- -PI- -IST- -FST-")
            While SQLReader.Read
                WriteInfo(SQLReader.GetString(2).Replace(" ", "").PadLeft(11, " ") & " " & SQLReader.GetString(1).Replace(" ", "").PadRight(12, " ") & " " & SQLReader.GetString(3) & "   " & SQLReader.GetString(4) & "   " & SQLReader.GetString(5) & "   " & SQLReader.GetString(10) & "   " & SQLReader.GetString(11) & "   " & SQLReader.GetString(12) & "    " & SQLReader.GetString(13))
            End While
            If SQLReader.HasRows Then
                WriteInfo(vbCrLf & "                        (No Other Cases Exists With SSN)")
            Else
                WriteInfo(vbCrLf & "                        (No Cases Exists With SSN)")
            End If
            SQLReader.Close()

            '--Wages Information--
            WriteInfo(vbCrLf & "WAGES INFORMATION---------------------------------------------------------------" & vbCrLf)
            SQLComm.CommandText = "SELECT * FROM WAGESQuarterInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            If SQLReader.HasRows Then
                WriteInfo(" QUARTER  QUARTER   BASE")
                WriteInfo("--YEAR-- --WAGES-- -WEEKS-")
            End If
            While SQLReader.Read
                WriteInfo(" " & SQLReader.GetString(1) & "   " & SQLReader.GetString(2) & "  " & SQLReader.GetString(3))
            End While
            WriteInfo(vbCrLf)
            SQLReader.Close()
            SQLComm.CommandText = "SELECT * FROM LOOPSEmployerInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            If SQLReader.HasRows Then
                WriteInfo("---------------EMPLOYER-------------- ---BASE YEAR--- -BASE WEEKS- -TOTAL WAGES-")
            End If
            While SQLReader.Read
                WriteInfo(" " & SQLReader.GetString(1) & "  " & SQLReader.GetString(2) & "      " & SQLReader.GetString(3).Replace(" ", "").PadLeft(2, " ") & "        " & SQLReader.GetString(4).Replace(" ", "").PadLeft(8, " "))
            End While
            If SQLReader.HasRows Then
                WriteInfo(vbCrLf & "                        (No Other Employers To Display)")
            Else
                WriteInfo(vbCrLf & "                        (No Employers To Display)")
            End If
            SQLReader.Close()

            '--UIB Information--
            WriteInfo(vbCrLf & "UIB INFORMATION-----------------------------------------------------------------" & vbCrLf)
            SQLComm.CommandText = "SELECT * FROM LOOPSBasicInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            SQLReader.Read()
            If SQLReader.HasRows Then
                WriteInfo("            WBR: " & SQLReader.GetString(1).Replace(" ", "").PadLeft(9, " ") & "                   BYE DATE: " & SQLReader.GetString(5).Replace(" ", "").PadLeft(8, " "))
                WriteInfo("            MBA: " & SQLReader.GetString(2).Replace(" ", "").PadLeft(9, " ") & "              DISQ END DATE: " & SQLReader.GetString(11).Replace(" ", "").PadLeft(8, " "))
                WriteInfo("LAST DAY WORKED:  " & SQLReader.GetString(6).Replace(" ", "").PadLeft(8, " ") & "          FIRST REPORT DATE: " & SQLReader.GetString(7).Replace(" ", "").PadLeft(8, " "))
                WriteInfo("     UI BALANCE: " & SQLReader.GetString(3).Replace(" ", "").PadLeft(9, " "))
            End If
            SQLReader.Close()
            SQLComm.CommandText = "SELECT * FROM LOOPSPaymentInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            If SQLReader.HasRows Then
                WriteInfo("                            M S                                   ")
                WriteInfo("             DATE    V TRAN T E                            TAX        AMOUNT")
                WriteInfo("---CWE--- ----PD---- C -UI- H A EARN -PEN- AWBA REFND GARN WTH -ADJ- --PAID--")
                While SQLReader.Read()
                    tempDate = SQLReader.GetDateTime(2).Month.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(2).Day.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(2).Year
                    If tempDate = "01/01/1900" Then tempDate = "          "
                    WriteInfo(SQLReader.GetString(1) & "  " & tempDate & " " & SQLReader.GetString(3) & " " & SQLReader.GetString(4) & " " & SQLReader.GetString(5) & " " & SQLReader.GetString(6) & " " & SQLReader.GetString(7).Replace(" ", "").PadLeft(4, " ") & "  " & SQLReader.GetString(8).Replace(" ", "").PadLeft(4, " ") & "  " & SQLReader.GetString(9).Replace(" ", "").PadLeft(3, " ") & " " & SQLReader.GetString(10).Replace(" ", "").PadLeft(4, " ") & "  " & SQLReader.GetString(11).Replace(" ", "").PadLeft(4, " ") & " " & SQLReader.GetString(12).Replace(" ", "").PadLeft(3, " ") & "  " & SQLReader.GetString(13).Replace(" ", "").PadLeft(4, " ") & " " & SQLReader.GetString(14).Replace(" ", "").PadLeft(8, " "))
                End While
            End If
            If SQLReader.HasRows Then
                WriteInfo(vbCrLf & "                        (No More Current Claims To Display)")
            Else
                WriteInfo(vbCrLf & "                        (No Current Claims To Display)")
            End If
            SQLReader.Close()

            '--Disability Information--
            WriteInfo(vbCrLf & "DABS INFORAMATION---------------------------------------------------------------" & vbCrLf)
            SQLComm.CommandText = "SELECT * FROM DISABILITYClaimSummaryInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            SQLReader.Read()
            If SQLReader.HasRows Then
                tempDate = SQLReader.GetDateTime(2).Month.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(2).Day.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(2).Year
                If tempDate = "01/01/1900" Then tempDate = "          "
                WriteInfo("    CASE STATUS: " & SQLReader.GetString(1).Replace(" ", "").PadLeft(8, " ") & "            DISABILITY DATE: " & tempDate)
                tempDate = SQLReader.GetDateTime(3).Month.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(3).Day.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(3).Year
                If tempDate = "01/01/1900" Then tempDate = "          "
                WriteInfo("            WBR: " & SQLReader.GetString(5).Replace(" ", "").PadLeft(8, " ") & "                 CLAIM DATE: " & tempDate)
                tempDate = SQLReader.GetDateTime(4).Month.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(4).Day.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(4).Year
                If tempDate = "01/01/1900" Then tempDate = "          "
                WriteInfo("            MBA: " & SQLReader.GetString(6).Replace(" ", "").PadLeft(8, " ") & "      END OF DIABILITY DATE: " & tempDate)
                WriteInfo("  CLAIM BALANCE: " & SQLReader.GetString(11).Replace(" ", "").PadLeft(8, " "))
            End If
            SQLReader.Close()
            SQLComm.CommandText = "SELECT * FROM DISABILITYPaymentInqInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            If SQLReader.HasRows Then
                WriteInfo("                                                DAYS PMT  ADJ  VOID  ")
                WriteInfo("--CHK DATE-- --PE DATE-- -CHECK NUM- -NET PAID- PAID CODE CODE CODE -GROSS CUR-")
                While SQLReader.Read()
                    tempDate = SQLReader.GetDateTime(1).Month.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(1).Day.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(1).Year
                    If tempDate = "01/01/1900" Then tempDate = "          "
                    tempDate2 = SQLReader.GetDateTime(2).Month.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(2).Day.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(2).Year
                    If tempDate2 = "01/01/1900" Then tempDate = "          "
                    WriteInfo(" " & tempDate & "  " & tempDate2 & "   " & SQLReader.GetString(3).Replace(" ", "").PadLeft(8, " ") & "   " & SQLReader.GetString(4).Replace(" ", "").PadLeft(8, " ") & "    " & SQLReader.GetString(5).Replace(" ", "").PadLeft(2, " ") & "   " & SQLReader.GetString(6).Replace(" ", "").PadLeft(2, " ") & "   " & SQLReader.GetString(7).Replace(" ", "").PadLeft(3, " ") & "  " & SQLReader.GetString(8) & "    " & SQLReader.GetString(9).Replace(" ", "").PadLeft(8, " "))
                End While
            End If
            If SQLReader.HasRows Then
                WriteInfo(vbCrLf & "                        (No More Current Claims To Display)")
            Else
                WriteInfo(vbCrLf & "                        (No Current Claims To Display)")
            End If
            SQLReader.Close()

            '--RSDI Information--
            'WriteInfo(vbCrLf & "RSDI INFORAMATION---------------------------------------------------------------" & vbCrLf)
            'WriteInfo(vbCrLf & "                        (No Current Claim To Display)")

            '--SSI Information--
            WriteInfo(vbCrLf & "SSI INFORMATION-----------------------------------------------------------------" & vbCrLf)
            SQLComm.CommandText = "SELECT * FROM SSIInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            SQLReader.Read()
            If SQLReader.HasRows Then
                tempDate = SQLReader.GetDateTime(1).Month.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(1).Day.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(1).Year
                If tempDate = "01/01/1900" Then tempDate = "          "
                WriteInfo("  RECIPIENT SSN: " & SQLReader.GetString(2).Replace(" ", "").PadRight(11, " ") & "            APPLICATION DATE: " & tempDate)
                WriteInfo("  CLAIM  NUMBER: " & SQLReader.GetString(3).Replace(" ", "").PadRight(11, " ") & "                  START DATE: " & SQLReader.GetString(19).Replace(" ", "").PadLeft(10, " "))
                WriteInfo(" RECIPIENT TYPE: " & SQLReader.GetString(9).Replace(" ", "").PadRight(11, " ") & "        SSI GROSS PAY AMOUNT: " & SQLReader.GetString(16).Replace(" ", "").PadLeft(10, " "))
                WriteInfo(" MARITAL STATUS: " & SQLReader.GetString(13).Replace(" ", "").PadRight(11, " ") & "    ST SUPP GROSS PAY AMOUNT: " & SQLReader.GetString(17).Replace(" ", "").PadLeft(10, " "))
                tempDate = SQLReader.GetDateTime(15).Month.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(15).Day.ToString.PadLeft(2, "0") & "/" & SQLReader.GetDateTime(15).Year
                If tempDate = "01/01/1900" Then tempDate = "          "
                WriteInfo("  MED EFF. DATE: " & tempDate & "         EARNED INCOME AMOUNT: " & SQLReader.GetString(18).Replace(" ", "").PadLeft(10, " "))
            Else
                WriteInfo(vbCrLf & "                        (No Current Claims To Display)")
            End If
            SQLReader.Close()

            '--Child Support Information--
            WriteInfo(vbCrLf & "CHILD SUPPORT INFORMATION-------------------------------------------------------" & vbCrLf)
            SQLComm.CommandText = "SELECT * FROM CSPInformation WHERE SocialSecurity = '" & SocialSecurity & "' AND FirstName = '" & FirstName & "' AND LastName = '" & LastName & "'"
            SQLReader = SQLComm.ExecuteReader
            If SQLReader.HasRows Then
                WriteInfo("TYPE --DCN--- --LAST NAME-- -FIRST NAME- M S ---DOB---- -LOAD- P ST --CASE ID--")
                While SQLReader.Read()
                    WriteInfo(SQLReader.GetString(2) & "  " & SQLReader.GetString(3) & " " & SQLReader.GetString(4).Substring(0, 13) & " " & SQLReader.GetString(5) & " " & SQLReader.GetString(6) & " " & SQLReader.GetString(7) & " " & SQLReader.GetString(8).Insert(2, "/").Insert(5, "/") & " " & SQLReader.GetString(9) & " " & SQLReader.GetString(10) & " " & SQLReader.GetString(11) & " " & SQLReader.GetString(1))
                End While
            End If
            If SQLReader.HasRows Then
                WriteInfo(vbCrLf & "                        (No More Child Support Claims To Display)")
            Else
                WriteInfo(vbCrLf & "                        (No Child Support Claims To Display)")
            End If
            SQLReader.Close()
        Else
            '--No Case On Server--
            Response.Write("<meta http-equiv='refresh' content='5;URL=Default.aspx'><h2><b>Case Not Found!</h2></b></br><p>Redirecting back...</p>")
        End If
    End Sub
    Private Sub WriteInfo(ByVal StringToSend As String)
        Response.Write(StringToSend & "</br>")
    End Sub
End Class