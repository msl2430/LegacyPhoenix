Public Class Opt64
    Private Choice As String

    Private Sub Opt66_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Choice = Nothing
        AddEvents(Me)
        txt_ErrorMessage.Text = ErrorMessage1Medi & vbCrLf & ErrorMessage2Medi
        setPage64()
    End Sub
    Private Sub Opt64_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Choice = "Cont" Then
            isDrop = False
        Else
            isDrop = True
        End If
        e.Cancel = False
    End Sub

    Private Sub setPage64()
        With OPTS64Information
            txt_ActionCode.Text = .ActionCode64.GetData
            txt_CaseNumber.Text = .CaseNumber.GetData
            txt_PersonNumber.Text = .PersonNumber.GetData

            txt_PGMNum1.Text = .PGMNum(0).GetData
            txt_EffDate1.Text = .EffDate64(0).GetData
            txt_TermDate1.Text = .TermDate64(0).GetData

            txt_PGMNum2.Text = .PGMNum(1).GetData
            txt_EffDate2.Text = .EffDate64(1).GetData
            txt_TermDate2.Text = .TermDate64(1).GetData

            txt_PGMNum3.Text = .PGMNum(2).GetData
            txt_EffDate3.Text = .EffDate64(2).GetData
            txt_TermDate3.Text = .TermDate64(2).GetData

            txt_PGMNum4.Text = .PGMNum(3).GetData
            txt_EffDate4.Text = .EffDate64(3).GetData
            txt_TermDate4.Text = .TermDate64(3).GetData

            txt_PGMNum5.Text = .PGMNum(4).GetData
            txt_EffDate5.Text = .EffDate64(4).GetData
            txt_TermDate5.Text = .TermDate64(4).GetData

            txt_PGMNum6.Text = .PGMNum(5).GetData
            txt_EffDate6.Text = .EffDate64(5).GetData
            txt_TermDate6.Text = .TermDate64(5).GetData
        End With
    End Sub
    Private Sub transferPage64()
        With OPTS64Information
            .ActionCode64.SetData(txt_ActionCode.Text)

            .PGMNum(0).SetData(txt_PGMNum1.Text)
            .EffDate64(0).SetData(txt_EffDate1.Text)
            .TermDate64(0).SetData(txt_TermDate1.Text)

            .PGMNum(1).SetData(txt_PGMNum2.Text)
            .EffDate64(1).SetData(txt_EffDate2.Text)
            .TermDate64(1).SetData(txt_TermDate2.Text)

            .PGMNum(2).SetData(txt_PGMNum3.Text)
            .EffDate64(2).SetData(txt_EffDate3.Text)
            .TermDate64(2).SetData(txt_TermDate3.Text)

            .PGMNum(3).SetData(txt_PGMNum4.Text)
            .EffDate64(3).SetData(txt_EffDate4.Text)
            .TermDate64(3).SetData(txt_TermDate4.Text)

            .PGMNum(4).SetData(txt_PGMNum5.Text)
            .EffDate64(4).SetData(txt_EffDate5.Text)
            .TermDate64(4).SetData(txt_TermDate5.Text)

            .PGMNum(5).SetData(txt_PGMNum6.Text)
            .EffDate64(5).SetData(txt_EffDate6.Text)
            .TermDate64(5).SetData(txt_TermDate6.Text)
        End With
    End Sub

    Private Sub AddEvents(ByVal ctrlparent As Control)
        Dim ctrl As Control
        For Each ctrl In ctrlparent.Controls
            If TypeOf ctrl Is TextBox Then
                AddHandler ctrl.Leave, AddressOf LoseFocus
                AddHandler ctrl.TextChanged, AddressOf AutoTab
            End If
            If ctrl.HasChildren Then
                AddEvents(ctrl)
            End If
        Next
    End Sub
    Sub AutoTab(ByVal sender As Object, ByVal e As EventArgs)
        If DirectCast(sender, TextBox).Text.Length = DirectCast(sender, TextBox).MaxLength Then Me.SelectNextControl(sender, True, True, True, True)
    End Sub
    Sub LoseFocus(ByVal sender As Object, ByVal e As EventArgs)
        DirectCast(sender, TextBox).Text = DirectCast(sender, TextBox).Text.PadRight(DirectCast(sender, TextBox).MaxLength).ToUpper
    End Sub

    Private Sub btn_Continue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Continue.Click
        Choice = "Cont"
        transferPage64()
        Me.Close()
    End Sub
    Private Sub btn_Drop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Drop.Click
        Choice = "Drop"
        Me.Close()
    End Sub
    Private Sub btn_GLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GLink.Click
        If glapiMedicaid.bool_Visible Then
            glapiMedicaid.SetVisible(False)
            btn_GLink.Text = "Show Medi"
        Else
            glapiMedicaid.SetVisible(True)
            btn_GLink.Text = "Hide Medi"
        End If
    End Sub
End Class