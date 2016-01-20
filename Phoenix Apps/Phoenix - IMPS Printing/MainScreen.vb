Imports System.IO
Imports Microsoft.Win32
Imports Microsoft.VisualBasic.ControlChars
Imports System.Threading

Public Class MainScreen
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PhoenixConnection As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbCommand1 As System.Data.OleDb.OleDbCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.Label1 = New System.Windows.Forms.Label
        Me.PhoenixConnection = New System.Data.OleDb.OleDbConnection
        Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Printing..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PhoenixConnection
        '
        Me.PhoenixConnection.ConnectionString = resources.GetString("PhoenixConnection.ConnectionString")
        '
        'OleDbCommand1
        '
        Me.OleDbCommand1.Connection = Me.PhoenixConnection
        '
        'MainScreen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(152, 46)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainScreen"
        Me.Text = "Phoenix - IMPS Printing"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim MyReader
    Dim File_Reader As StreamReader
    Dim CASENUMBER, BATCHNUMBER, ERRORMESSAGE1, ERRORMESSAGE2, ERRORMESSAGE3, ERRORMESSAGE4, ERRORMESSAGE5 As String

    Private Sub MainScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If File.Exists(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc") = False Then
            Dim File_Writer As StreamWriter
            File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc", True)
            File_Writer.WriteLine("Phoenix - IMPS Cases" & CrLf & CrLf & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year) ' & CrLf & CrLf)
            File_Writer.Close()
        End If
        GetInfo()
        PrintStats()
        If File.Exists(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc") Then File.Delete(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc")
        Me.Close()
    End Sub

    Sub GetInfo()
        Dim Reader As OleDb.OleDbDataReader
        Dim File_Writer As StreamWriter
        Try
            PhoenixConnection.Open()

            File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc", True)
            File_Writer.WriteLine(CrLf & "--CASES DROPPED TODAY--" & CrLf)
            File_Writer.Close()

            OleDbCommand1.CommandText = "SELECT CASENUMBER, REASON, REASON2, REASON3, REASON4, REASON5 FROM IMPSInformation WHERE Dropped = 'True' and dateentered = '" & Date.Today.Month & "/" & Date.Today.Day & "/" & Date.Today.Year & "'"
            Reader = OleDbCommand1.ExecuteReader
            If Reader.HasRows = True Then
                While Reader.Read
                    If Reader.IsDBNull(0) = False Then CASENUMBER = Reader.GetString(0)
                    If Reader.IsDBNull(1) = False Then ERRORMESSAGE1 = Reader.GetString(1)
                    If Reader.IsDBNull(2) = False Then ERRORMESSAGE2 = Reader.GetString(2)
                    If Reader.IsDBNull(3) = False Then ERRORMESSAGE3 = Reader.GetString(3)
                    If Reader.IsDBNull(4) = False Then ERRORMESSAGE4 = Reader.GetString(4)
                    If Reader.IsDBNull(5) = False Then ERRORMESSAGE5 = Reader.GetString(5)
                    WriteDropSheet()
                End While
                Reader.Close()
                PhoenixConnection.Close()
            Else
                PhoenixConnection.Close()

                File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc", True)
                File_Writer.WriteLine("*****No Dropped Cases*****")
                File_Writer.Close()
            End If

            File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc", True)
            File_Writer.WriteLine(CrLf & CrLf & "--CASES COMPLETED TODAY--" & CrLf)
            File_Writer.Close()

            PhoenixConnection.Open()
            OleDbCommand1.CommandText = "SELECT CASENUMBER, BATCHNUMBER FROM IMPSInformation WHERE Dropped = 'False' and DateEntered = '" & Date.Now.Month & "/" & Date.Now.Day & "/" & Date.Now.Year & "' ORDER BY BatchNumber"
            Reader = OleDbCommand1.ExecuteReader
            If Reader.HasRows = True Then
                While Reader.Read
                    If Reader.IsDBNull(0) = False Then CASENUMBER = Reader.GetString(0)
                    If Reader.IsDBNull(1) = False Then BATCHNUMBER = Reader.GetString(1)
                    WriteSuccessSheet()
                End While
                Reader.Close()
                PhoenixConnection.Close()
            Else
                PhoenixConnection.Close()

                File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc", True)
                File_Writer.WriteLine("*****No Completed Cases Today*****")
                File_Writer.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Sub WriteDropSheet()
        Dim File_Writer As StreamWriter

        File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc", True)
        File_Writer.WriteLine("Case Number: " & CASENUMBER) ' & CrLf & "        Error Reason: " & ERRORMESSAGE1 & CrLf & "        Error Reason: " & ERRORMESSAGE2 & CrLf & "        Error Reason: " & ERRORMESSAGE3 & CrLf & "        Error Reason: " & ERRORMESSAGE4 & CrLf & "        Error Reason: " & ERRORMESSAGE5 & CrLf)
        If ERRORMESSAGE1.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ERRORMESSAGE1)
        End If
        If ERRORMESSAGE2.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ERRORMESSAGE2)
        End If
        If ERRORMESSAGE3.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ERRORMESSAGE3)
        End If
        If ERRORMESSAGE4.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ERRORMESSAGE4)
        End If
        If ERRORMESSAGE5.Substring(0, 10) <> "          " Then
            File_Writer.WriteLine("        Error Reason: " & ERRORMESSAGE5)
        End If
        File_Writer.Close()
    End Sub
    Sub WriteSuccessSheet()
        Dim File_Writer As StreamWriter

        File_Writer = New StreamWriter(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc", True)
        File_Writer.WriteLine("Case Number: " & CASENUMBER & "    Batch Number: " & BATCHNUMBER) '& CrLf)
        File_Writer.Close()
    End Sub
    Sub PrintStats()
        Dim oWord As Word.Application
        Dim FootNote As String
        oWord = New Word.ApplicationClass
        oWord.Documents.Add(My.Application.Info.DirectoryPath & "Phoenix - IMPS Drops.doc")
        oWord.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView
        oWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter
        oWord.Selection.TypeText("Phoenix - IMPS Processing " & Date.Today & "                                                                            Page: ")
        oWord.Selection.Fields.Add(oWord.Selection.Range, Word.WdFieldType.wdFieldPage)

        oWord.PrintOut(False)
        oWord.Quit(0)
        oWord = Nothing
    End Sub
End Class
