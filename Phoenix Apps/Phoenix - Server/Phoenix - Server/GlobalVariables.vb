'--Developed by: Michael Levine 1/2008'
Module GlobalVariables
    '--Public global variables--
    Public FirstName(2), LastName(2) As String                     '--Name of client--
    Public FirstNameList, LastNameList As List(Of String)        '--Name of client list--
    Public SocialSecurity(2) As String                            '--Social security number of client--
    Public SocialSecurityList As List(Of String)                 '--Social security number list--
    Public DateOfBirth(2), Sex(2) As String                        '--DOB, Sex of client--
    Public DateOfBirthList, SexList As List(Of String)           '--DOB, Sex of client list--
    Public Address(2), Address2(2) As String                       '--Address of client--
    Public City(2), State(2), ZipCode(2) As String                  '--City, State, ZipCode of client--
    Public ClientDataCaseNumber(2) As String                      '--Case number found on system--
    Public CasePriority, P05, P03, P09 As String         '--Case priority and P-values--
    Public RecertDate, CashRedetDate, MedRedetDate As Date '--CRL Dates--
    ' Public DCN As New List(Of String)                          '--List of DCN numbers for the client--
    Public isCaseExists As Boolean                               '--Tracks if case is on server--

    Public isLaborExists As Boolean                       '--Tracks if labor information exists--
    Public LaborErrorMessage As String                    '--Error message generated by labor--
    Public isDisabilityExists As Boolean                  '--Tracks if disability information exists--
    Public DisabilityErrorMessage As String               '--Error message generated by disability--
    Public isWagesExists As Boolean                       '--Tracks if wages information exists--
    Public WagesErrorMessage As String                    '--Error message generated by wages--
    Public isFindExists As Boolean                        '--Tracks if find information exists--
    Public FindErrorMessage As String                     '--Error message generated by find--
    Public isChildSupportExists As Boolean                '--Tracks if child support exists--
    Public ChildSupportErrorMessage As String             '--Error message generated by child support--
    Public isSSIExists As Boolean                         '--Tracks if SSI information exists--
    Public SSIErrorMessage As String                      '--Error message genereated by SSI--
    Public isQuarterExists As Boolean                     '--Tracks if quarter information exists--
    Public QuarterErrorMessage As String                  '--Error message generated by quarters--

    Public CSCaseNumber As String                         '--Child support specific case numbers--

End Module
