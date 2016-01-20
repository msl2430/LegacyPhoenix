Imports System.Data.SqlClient

Partial Class IRFManifest
    Inherits System.Web.UI.Page

    'Protected FocusControl As Control

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TestLoad()
        Else
            'ViewState("Focus") = FocusControl
        End If
    End Sub

    Protected Sub ChkChanged_Received(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim chkbox_Received As CheckBox = sender
        'Dim grdRow As GridViewRow = chkbox_Received.NamingContainer
        'Dim chkbox_YesChange As CheckBox = grid_Manifest.Rows(grdRow.RowIndex).FindControl("chk_YesChange")
        'Dim chkbox_NoChange As CheckBox = grid_Manifest.Rows(grdRow.RowIndex).FindControl("chk_NoChange")
        'If Not chkbox_NoChange.Checked And Not chkbox_YesChange.Checked Then
        '    grdRow.BackColor = Drawing.Color.Tan
        'Else
        '    If chkbox_Received.Checked = True Then
        '        'grdRow.BackColor = Drawing.Color.FromArgb(255, 43, 134, 53)
        '    Else

        '    End If
        'End If
    End Sub
    Protected Sub ChkChanged_Change(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim chkBox As CheckBox = sender
        'Dim grdRow As GridViewRow = chkBox.NamingContainer
        'If chkBox.Checked = True Then
        '    grdRow.BackColor = Drawing.Color.FromArgb(255, 7, 135, 22)
        'Else
        '    Response.Write(grdRow.Cells(0).Text & " - Changed to not received")
        'End If
    End Sub
    Protected Sub Submit(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim button_Submit As Button = sender
        Dim grdRow As GridViewRow = button_Submit.NamingContainer
        Dim chkbox_YesChange As CheckBox = grid_Manifest.Rows(grdRow.RowIndex).FindControl("chk_YesChange")
        Dim chkbox_NoChange As CheckBox = grid_Manifest.Rows(grdRow.RowIndex).FindControl("chk_NoChange")
        Dim chkbox_Received As CheckBox = grid_Manifest.Rows(grdRow.RowIndex).FindControl("chk_Received")
        If Not chkbox_NoChange.Checked And Not chkbox_YesChange.Checked Then
            grdRow.Cells(4).BackColor = Drawing.Color.Red
        Else
            grdRow.Cells(4).BackColor = grdRow.Cells(1).BackColor
            grdRow.BackColor = Drawing.Color.FromArgb(255, 32, 101, 40)
            chkbox_NoChange.Enabled = False
            chkbox_Received.Enabled = False
            chkbox_YesChange.Enabled = False
            button_Submit.Visible = False
        End If
        'FocusControl = grdRow
        UpdatePanel1.Update()
    End Sub

    Protected Sub TestLoad()
        Dim SQLConn As New SqlConnection("Data Source=172.16.8.15\PHOENIX;Initial Catalog=PhoenixData;Persist Security Info=True;User ID=PhoenixUser;Password=password")
        Dim SQLComm As New SqlCommand
        Dim SQLReader As SqlDataReader
        Dim i As Integer = 0
        SQLComm.Connection = SQLConn
        Try
            SQLConn.Open()
            SQLComm.CommandText = "SELECT CaseNumber, LastName, FirstName, Received, Change FROM MasterIRF ORDER BY CaseNumber"
            SQLReader = SQLComm.ExecuteReader
            While SQLReader.Read
                Dim label_CaseNumber As Label = grid_Manifest.Rows(i).FindControl("lbl_CaseNumber")
                Dim label_LastName As Label = grid_Manifest.Rows(i).FindControl("lbl_LastName")
                Dim label_FirstName As Label = grid_Manifest.Rows(i).FindControl("lbl_FirstName")
                Dim chkbox_Received As CheckBox = grid_Manifest.Rows(i).FindControl("chk_Received")
                Dim chkbox_YesChange As CheckBox = grid_Manifest.Rows(i).FindControl("chk_YesChange")
                Dim chkbox_NoChange As CheckBox = grid_Manifest.Rows(i).FindControl("chk_NoChange")
                Dim button_Submit As Button = grid_Manifest.Rows(i).FindControl("btn_Submit")
                Dim grdRow As GridViewRow = grid_Manifest.Rows(i)

                label_CaseNumber.Text = SQLReader.GetString(0)
                label_LastName.Text = SQLReader.GetString(1)
                label_FirstName.Text = SQLReader.GetString(2)
                If SQLReader.GetString(3) = "TRUE      " Then
                    chkbox_Received.Checked = True
                    grdRow.BackColor = Drawing.Color.FromArgb(255, 32, 101, 40)
                    chkbox_NoChange.Enabled = False
                    chkbox_Received.Enabled = False
                    chkbox_YesChange.Enabled = False
                    button_Submit.Visible = False
                Else
                    chkbox_Received.Checked = False
                End If
                If SQLReader.GetString(4) = "TRUE      " Then
                    chkbox_YesChange.Checked = True
                    chkbox_NoChange.Checked = False
                ElseIf SQLReader.GetString(4) = "FALSE     " Then
                    chkbox_YesChange.Checked = False
                    chkbox_NoChange.Checked = True
                Else
                    chkbox_YesChange.Checked = False
                    chkbox_NoChange.Checked = False
                End If
                i += 1
            End While
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            SQLConn.Close()
        End Try
    End Sub
End Class
