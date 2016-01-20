'--Designed by: Michael Levine 11/2007--
Public Class EmployerWages
    '--Information for an Employer in the Wage system--

    Public EmployerName, BaseYear, BaseWeeks, TotalWages As String
    Public Quarter(4), QuarterWeeks(4), QuarterWages(4) As String

    Private glapiWages As connGLinkMedi

    Public Sub New(ByRef glapi As connGLinkMedi)
        glapiWages = glapi
    End Sub

    Public Sub GetEmployer(ByVal index As Integer)
        If glapiWages.GetString(4, 12 + index, 35, 12 + index) <> "                                " Then
            EmployerName = glapiWages.GetString(4, 12 + index, 35, 12 + index).Substring(0, 32)
            BaseYear = glapiWages.GetString(37, 12 + index, 49, 12 + index)
            BaseWeeks = glapiWages.GetString(59, 12 + index, 60, 12 + index)
            TotalWages = glapiWages.GetString(72, 12 + index, 79, 12 + index)
        Else
            EmployerName = "Nothing"
        End If
    End Sub
    Public Sub GetQuarter()
        Dim i As Integer
        For i = 0 To 4
            If glapiWages.GetString(13, 10 + (i * 3), 16, 10 + (i * 3)) <> "    " Then
                Quarter(i) = glapiWages.GetString(27, 10 + (i * 3), 39, 10 + (i * 3))
                QuarterWeeks(i) = glapiWages.GetString(49, 10 + (i * 3), 50, 10 + (i * 3))
                QuarterWages(i) = glapiWages.GetString(61, 10 + (i * 3), 68, 10 + (i * 3))
            Else
                Quarter(i) = "Nothing"
            End If
        Next
    End Sub

End Class
