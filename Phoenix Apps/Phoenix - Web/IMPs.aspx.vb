
Partial Class IMPs
    Inherits System.Web.UI.Page

    Public FrameSRC As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            drop_Month.Items.Add("January")
            drop_Month.Items.Add("February")
            drop_Month.Items.Add("March")
            drop_Month.Items.Add("April")
            drop_Month.Items.Add("May")
            drop_Month.Items.Add("June")
            drop_Month.Items.Add("July")
            drop_Month.Items.Add("August")
            drop_Month.Items.Add("September")
            drop_Month.Items.Add("October")
            drop_Month.Items.Add("November")
            drop_Month.Items.Add("December")

            drop_Year.Items.Add("2009")
            drop_Year.Items.Add("2008")

            drop_Month.SelectedIndex = Date.Now.Month - 1
            SetDays()
            drop_Day.SelectedValue = Date.Now.Day.ToString
            drop_Year.SelectedValue = Date.Now.Year.ToString
        Else
            drop_Month_SelectedIndexChanged(Nothing, Nothing)
        End If

        FrameSRC = "IMPsForm.aspx?Date=" & drop_Month.SelectedIndex + 1 & "/" & drop_Day.SelectedValue.ToString & "/" & drop_Year.SelectedItem.ToString
    End Sub

    Private Sub SetDays()
        drop_Day.Items.Clear()
        Select Case drop_Month.SelectedItem.ToString
            Case "January", "March", "May", "July", "August", "October", "December"
                For i As Integer = 1 To 31
                    drop_Day.Items.Add(i)
                Next
            Case "April", "June", "September", "November"
                For i As Integer = 1 To 30
                    drop_Day.Items.Add(i)
                Next
            Case "February"
                For i As Integer = 1 To 28
                    drop_Day.Items.Add(i)
                Next
        End Select
    End Sub

    Protected Sub drop_Month_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drop_Month.SelectedIndexChanged
        Dim tempDay As String = drop_Day.SelectedItem.ToString
        SetDays()
        If drop_Day.Items.Count < tempDay Then
            drop_Day.SelectedValue = "1"
        Else
            drop_Day.SelectedValue = tempDay
        End If

    End Sub
    Protected Sub drop_Day_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drop_Day.SelectedIndexChanged
        'FrameSRC = "IMPsForm.aspx?Date=" & drop_Month.SelectedItem.ToString & "/" & drop_Day.SelectedItem.ToString & "/" & drop_Year.SelectedItem.ToString
    End Sub
End Class
