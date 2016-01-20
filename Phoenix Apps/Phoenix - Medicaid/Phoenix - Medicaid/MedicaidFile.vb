'--Developed by Michael Levine 10/2007--
Public Class MedicaidFile
    '--Medicaid file information to help execute the processing in proper order--
    Public FilePath As String       '--Full path of file--
    Public FileName As String       '--File name--
    Public CaseNumber As String     '--Case number--
    Public PersonNumber As String   '--Person Number--
    Public OptScreen As String      '--Opt number--
    Public isDone As Boolean        '--Track whether the file has been processed or not--
    Public isChecked As Boolean

    Public Sub New(ByVal Path As String)
        FilePath = Path
        FileName = Path.Substring(Path.LastIndexOf("\") + 1) 'Path.Substring(My.Settings.MediDirectory.Length + 1)
        OptScreen = FileName.Substring(0, 2)
        isDone = False
        isChecked = False
        CaseNumber = "          "
        PersonNumber = "  "
        SetCaseNumber()
    End Sub

    Private Sub SetCaseNumber()
        '--Extract the case number by reading it in from the file--
        Dim infile As New StreamReader(FilePath, System.Text.Encoding.Default)
        Dim Record As String
        Try
            While infile.Peek <> -1
                Record = infile.ReadLine
                If Record <> Nothing Then
                    CaseNumber = Record.Substring(35, 10)
                    PersonNumber = Record.Substring(48, 2)
                End If
            End While
        Catch ex As Exception
            Console.Write(ex.Message.ToString)
        Finally
            infile.Close()
        End Try
    End Sub
End Class
