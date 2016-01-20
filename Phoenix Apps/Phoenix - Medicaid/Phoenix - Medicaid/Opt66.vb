Public Class Opt66
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
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents txt_DisabilityRedeterDate As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txt_CaseRedeterDate As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents txt_SUPV As System.Windows.Forms.TextBox
    Friend WithEvents txt_ProgramStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents txt_Worker As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btn_Drop As System.Windows.Forms.Button
    Friend WithEvents btn_Continue As System.Windows.Forms.Button
    Friend WithEvents txt_ErrorMessage As System.Windows.Forms.TextBox
    Friend WithEvents txt_CaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents txt_FirstName As System.Windows.Forms.TextBox
    Friend WithEvents txt_LastName As System.Windows.Forms.TextBox
    Friend WithEvents btn_GLink As System.Windows.Forms.Button
    Friend WithEvents txt_ActionCode As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Opt66))
        Me.txt_CaseNumber = New System.Windows.Forms.TextBox
        Me.Label65 = New System.Windows.Forms.Label
        Me.txt_DisabilityRedeterDate = New System.Windows.Forms.TextBox
        Me.Label64 = New System.Windows.Forms.Label
        Me.txt_CaseRedeterDate = New System.Windows.Forms.TextBox
        Me.Label63 = New System.Windows.Forms.Label
        Me.txt_SUPV = New System.Windows.Forms.TextBox
        Me.txt_ProgramStatus = New System.Windows.Forms.TextBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.txt_Worker = New System.Windows.Forms.TextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.txt_ActionCode = New System.Windows.Forms.TextBox
        Me.txt_FirstName = New System.Windows.Forms.TextBox
        Me.txt_LastName = New System.Windows.Forms.TextBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btn_Drop = New System.Windows.Forms.Button
        Me.btn_Continue = New System.Windows.Forms.Button
        Me.txt_ErrorMessage = New System.Windows.Forms.TextBox
        Me.btn_GLink = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txt_CaseNumber
        '
        Me.txt_CaseNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CaseNumber.Location = New System.Drawing.Point(96, 16)
        Me.txt_CaseNumber.MaxLength = 10
        Me.txt_CaseNumber.Name = "txt_CaseNumber"
        Me.txt_CaseNumber.ReadOnly = True
        Me.txt_CaseNumber.Size = New System.Drawing.Size(94, 20)
        Me.txt_CaseNumber.TabIndex = 207
        Me.txt_CaseNumber.TabStop = False
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.BackColor = System.Drawing.Color.Transparent
        Me.Label65.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label65.Location = New System.Drawing.Point(0, 18)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(87, 15)
        Me.Label65.TabIndex = 205
        Me.Label65.Text = "Case Number:"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_DisabilityRedeterDate
        '
        Me.txt_DisabilityRedeterDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DisabilityRedeterDate.Location = New System.Drawing.Point(347, 160)
        Me.txt_DisabilityRedeterDate.MaxLength = 6
        Me.txt_DisabilityRedeterDate.Name = "txt_DisabilityRedeterDate"
        Me.txt_DisabilityRedeterDate.Size = New System.Drawing.Size(72, 20)
        Me.txt_DisabilityRedeterDate.TabIndex = 5
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.BackColor = System.Drawing.Color.Transparent
        Me.Label64.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label64.Location = New System.Drawing.Point(329, 142)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(123, 15)
        Me.Label64.TabIndex = 202
        Me.Label64.Text = "Disability Redet Date"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_CaseRedeterDate
        '
        Me.txt_CaseRedeterDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CaseRedeterDate.Location = New System.Drawing.Point(232, 160)
        Me.txt_CaseRedeterDate.MaxLength = 6
        Me.txt_CaseRedeterDate.Name = "txt_CaseRedeterDate"
        Me.txt_CaseRedeterDate.Size = New System.Drawing.Size(72, 20)
        Me.txt_CaseRedeterDate.TabIndex = 4
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.BackColor = System.Drawing.Color.Transparent
        Me.Label63.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label63.Location = New System.Drawing.Point(222, 142)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(101, 15)
        Me.Label63.TabIndex = 200
        Me.Label63.Text = "Case Redet Date"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_SUPV
        '
        Me.txt_SUPV.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SUPV.Location = New System.Drawing.Point(9, 160)
        Me.txt_SUPV.MaxLength = 2
        Me.txt_SUPV.Name = "txt_SUPV"
        Me.txt_SUPV.Size = New System.Drawing.Size(48, 20)
        Me.txt_SUPV.TabIndex = 1
        '
        'txt_ProgramStatus
        '
        Me.txt_ProgramStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ProgramStatus.Location = New System.Drawing.Point(134, 160)
        Me.txt_ProgramStatus.MaxLength = 3
        Me.txt_ProgramStatus.Name = "txt_ProgramStatus"
        Me.txt_ProgramStatus.Size = New System.Drawing.Size(56, 20)
        Me.txt_ProgramStatus.TabIndex = 3
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.BackColor = System.Drawing.Color.Transparent
        Me.Label57.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label57.Location = New System.Drawing.Point(12, 142)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(39, 15)
        Me.Label57.TabIndex = 196
        Me.Label57.Text = "SUPV"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.Color.Transparent
        Me.Label59.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label59.Location = New System.Drawing.Point(119, 142)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(97, 15)
        Me.Label59.TabIndex = 195
        Me.Label59.Text = "Program Status"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.BackColor = System.Drawing.Color.Transparent
        Me.Label60.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label60.Location = New System.Drawing.Point(67, 142)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(50, 15)
        Me.Label60.TabIndex = 194
        Me.Label60.Text = "Worker"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Worker
        '
        Me.txt_Worker.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Worker.Location = New System.Drawing.Point(73, 160)
        Me.txt_Worker.MaxLength = 2
        Me.txt_Worker.Name = "txt_Worker"
        Me.txt_Worker.Size = New System.Drawing.Size(32, 20)
        Me.txt_Worker.TabIndex = 2
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label51.Location = New System.Drawing.Point(38, 114)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(101, 15)
        Me.Label51.TabIndex = 193
        Me.Label51.Text = "Redetermination"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_ActionCode
        '
        Me.txt_ActionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ActionCode.Location = New System.Drawing.Point(8, 112)
        Me.txt_ActionCode.MaxLength = 1
        Me.txt_ActionCode.Name = "txt_ActionCode"
        Me.txt_ActionCode.Size = New System.Drawing.Size(24, 20)
        Me.txt_ActionCode.TabIndex = 0
        '
        'txt_FirstName
        '
        Me.txt_FirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FirstName.Location = New System.Drawing.Point(96, 80)
        Me.txt_FirstName.MaxLength = 9
        Me.txt_FirstName.Name = "txt_FirstName"
        Me.txt_FirstName.ReadOnly = True
        Me.txt_FirstName.Size = New System.Drawing.Size(94, 20)
        Me.txt_FirstName.TabIndex = 191
        Me.txt_FirstName.TabStop = False
        '
        'txt_LastName
        '
        Me.txt_LastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_LastName.Location = New System.Drawing.Point(96, 48)
        Me.txt_LastName.MaxLength = 12
        Me.txt_LastName.Name = "txt_LastName"
        Me.txt_LastName.ReadOnly = True
        Me.txt_LastName.Size = New System.Drawing.Size(94, 20)
        Me.txt_LastName.TabIndex = 190
        Me.txt_LastName.TabStop = False
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label55.Location = New System.Drawing.Point(19, 83)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(71, 15)
        Me.Label55.TabIndex = 189
        Me.Label55.Text = "First Name:"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label56.Location = New System.Drawing.Point(19, 50)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(71, 15)
        Me.Label56.TabIndex = 188
        Me.Label56.Text = "Last Name:"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label11.Location = New System.Drawing.Point(215, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 15)
        Me.Label11.TabIndex = 324
        Me.Label11.Text = "Error Message:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btn_Drop
        '
        Me.btn_Drop.BackColor = System.Drawing.Color.Red
        Me.btn_Drop.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Drop.Location = New System.Drawing.Point(384, 80)
        Me.btn_Drop.Name = "btn_Drop"
        Me.btn_Drop.Size = New System.Drawing.Size(64, 23)
        Me.btn_Drop.TabIndex = 322
        Me.btn_Drop.Text = "Drop"
        Me.btn_Drop.UseVisualStyleBackColor = False
        '
        'btn_Continue
        '
        Me.btn_Continue.BackColor = System.Drawing.Color.Green
        Me.btn_Continue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Continue.Location = New System.Drawing.Point(290, 80)
        Me.btn_Continue.Name = "btn_Continue"
        Me.btn_Continue.Size = New System.Drawing.Size(88, 23)
        Me.btn_Continue.TabIndex = 321
        Me.btn_Continue.Text = "Continue"
        Me.btn_Continue.UseVisualStyleBackColor = False
        '
        'txt_ErrorMessage
        '
        Me.txt_ErrorMessage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ErrorMessage.Location = New System.Drawing.Point(196, 16)
        Me.txt_ErrorMessage.MaxLength = 300
        Me.txt_ErrorMessage.Multiline = True
        Me.txt_ErrorMessage.Name = "txt_ErrorMessage"
        Me.txt_ErrorMessage.ReadOnly = True
        Me.txt_ErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_ErrorMessage.Size = New System.Drawing.Size(252, 56)
        Me.txt_ErrorMessage.TabIndex = 323
        Me.txt_ErrorMessage.TabStop = False
        '
        'btn_GLink
        '
        Me.btn_GLink.BackColor = System.Drawing.Color.CadetBlue
        Me.btn_GLink.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GLink.Location = New System.Drawing.Point(196, 80)
        Me.btn_GLink.Name = "btn_GLink"
        Me.btn_GLink.Size = New System.Drawing.Size(88, 23)
        Me.btn_GLink.TabIndex = 325
        Me.btn_GLink.Text = "Show Medi"
        Me.btn_GLink.UseVisualStyleBackColor = False
        '
        'Opt66
        '
        Me.AcceptButton = Me.btn_Continue
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BackgroundImage = Global.Phoenix___Medicaid.My.Resources.Resources.RedBG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(456, 190)
        Me.Controls.Add(Me.btn_GLink)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btn_Drop)
        Me.Controls.Add(Me.btn_Continue)
        Me.Controls.Add(Me.txt_ErrorMessage)
        Me.Controls.Add(Me.txt_CaseNumber)
        Me.Controls.Add(Me.Label65)
        Me.Controls.Add(Me.txt_DisabilityRedeterDate)
        Me.Controls.Add(Me.Label64)
        Me.Controls.Add(Me.txt_CaseRedeterDate)
        Me.Controls.Add(Me.Label63)
        Me.Controls.Add(Me.txt_SUPV)
        Me.Controls.Add(Me.txt_ProgramStatus)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.txt_Worker)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.txt_ActionCode)
        Me.Controls.Add(Me.txt_FirstName)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.txt_LastName)
        Me.Controls.Add(Me.Label56)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Opt66"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Phoenix - Opt 66"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Choice As String

    Private Sub Opt66_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Choice = Nothing
        AddEvents(Me)
        txt_ErrorMessage.Text = ErrorMessage1Medi & vbCrLf & ErrorMessage2Medi
        setPage66()
        RedFieldCheck()
    End Sub
    Private Sub Opt66_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Choice = "Cont" Then
            isDrop = False
        Else
            isDrop = True
        End If
        e.Cancel = False
    End Sub

    Sub setPage66()
        With OPTS66Information
            txt_CaseNumber.Text = .CaseNumber.GetData
            txt_LastName.Text = .LastName.GetData
            txt_FirstName.Text = .FirstName.GetData
            txt_ActionCode.Text = .ActionCode66.GetData
            txt_SUPV.Text = .SUPV66.GetData
            txt_Worker.Text = .Worker.GetData
            txt_ProgramStatus.Text = .ProgramStatus.GetData
            txt_CaseRedeterDate.Text = .CaseRedetDate.GetData
            txt_DisabilityRedeterDate.Text = .DisabilityRedetDate.GetData
        End With
    End Sub
    Sub transferPage66()
        With OPTS66Information
            .SUPV66.SetData(txt_SUPV.Text)
            .Worker.SetData(txt_Worker.Text)
            .ProgramStatus.SetData(txt_ProgramStatus.Text)
            .CaseRedetDate.SetData(txt_CaseRedeterDate.Text)
            .DisabilityRedetDate.SetData(txt_DisabilityRedeterDate.Text)
            .ActionCode66.SetData(txt_ActionCode.Text)
        End With
    End Sub

    Private Sub RedFieldCheck()
        Dim BlockArray(10), BlockName(10), BlockData(10) As String
        Dim i As Integer
        If glapiMedicaid.GetField_Red <> Nothing Then
            BlockArray = glapiMedicaid.GetField_Red.Split(vbCrLf)
            For i = 0 To BlockArray.Length - 1
                If BlockArray(i) <> Nothing Then
                    BlockName(i) = BlockArray(i).Substring(1, 2)
                    BlockData(i) = BlockArray(i).Substring(3)
                End If
            Next
            For i = 0 To BlockData.Length - 1
                If BlockName(i) <> Nothing Then HighlightTextbox66(BlockName(i))
            Next
        End If
    End Sub
    Private Sub HighlightTextbox66(ByVal FieldNumber As String)
        With OPTS66Information
            If FieldNumber = .ActionCode66.FieldNumber Then txt_ActionCode.BackColor = Color.Red
            If FieldNumber = .CaseNumber.FieldNumber Then txt_CaseNumber.BackColor = Color.Red

            If FieldNumber = .SUPV66.FieldNumber Then txt_SUPV.BackColor = Color.Red
            If FieldNumber = .Worker.FieldNumber Then txt_Worker.BackColor = Color.Red
            If FieldNumber = .ProgramStatus.FieldNumber Then txt_ProgramStatus.BackColor = Color.Red
            If FieldNumber = .CaseRedetDate.FieldNumber Then Me.txt_CaseRedeterDate.BackColor = Color.Red
            If FieldNumber = .DisabilityRedetDate.FieldNumber Then txt_DisabilityRedeterDate.BackColor = Color.Red
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
        transferPage66()
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
