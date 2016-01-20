Public Class Opt61
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
    Friend WithEvents txt_Sex As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_ActionCode1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ZipCode As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txt_Address4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Address2 As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txt_Address5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Address3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Address1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_DateOfEntry As System.Windows.Forms.TextBox
    Friend WithEvents txt_AlienType As System.Windows.Forms.TextBox
    Friend WithEvents txt_LTC As System.Windows.Forms.TextBox
    Friend WithEvents txt_BuyInDate As System.Windows.Forms.TextBox
    Friend WithEvents txt_BuyInStatus As System.Windows.Forms.TextBox
    Friend WithEvents txt_PriorCaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents txt_Race As System.Windows.Forms.TextBox
    Friend WithEvents txt_MaritalStatus As System.Windows.Forms.TextBox
    Friend WithEvents txt_DOB As System.Windows.Forms.TextBox
    Friend WithEvents txt_MiddleIntial As System.Windows.Forms.TextBox
    Friend WithEvents txt_FirstName As System.Windows.Forms.TextBox
    Friend WithEvents txt_LastName As System.Windows.Forms.TextBox
    Friend WithEvents txt_PerNumber As System.Windows.Forms.TextBox
    Friend WithEvents txt_ProviderWarning As System.Windows.Forms.TextBox
    Friend WithEvents txt_CaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_SocialSecurity As System.Windows.Forms.TextBox
    Friend WithEvents txt_PregnancyDate2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExtTyp2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CtyRes2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CntySupvn2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PgmSta2 As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txt_TrmCode2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_AddCode2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TerminationDate2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_EffectiveDate2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PregnancyDate1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExtTyp1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CtyRes1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_AddCode6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CntySupvn1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PregnancyDate6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PgmSta1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TrmCode1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_AddCode1 As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txt_TerminationDate1 As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txt_EffectiveDate1 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PgmSta6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TrmCode6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CntySupvn6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExtTyp6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CtyRes6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TerminationDate6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_EffectiveDate6 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PregnancyDate5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExtTyp5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CtyRes5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CntySupvn5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PgmSta5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TrmCode5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_AddCode5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TerminationDate5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_EffectiveDate5 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PregnancyDate4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExtTyp4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CtyRes4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CntySupvn4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PgmSta4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TrmCode4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_AddCode4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TerminationDate4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_EffectiveDate4 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PregnancyDate3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_ExtTyp3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CtyRes3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_CntySupvn3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_PgmSta3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TrmCode3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_AddCode3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_TerminationDate3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_EffectiveDate3 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txt_State As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_City As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_EligSeg As System.Windows.Forms.TextBox
    Friend WithEvents txt_PersonAction As System.Windows.Forms.TextBox
    Friend WithEvents txt_AddressAction As System.Windows.Forms.TextBox
    Friend WithEvents txt_Office As System.Windows.Forms.TextBox
    Friend WithEvents txt_PriorPerNum As System.Windows.Forms.TextBox
    Friend WithEvents txt_ErrorMessage As System.Windows.Forms.TextBox
    Friend WithEvents btn_Continue As System.Windows.Forms.Button
    Friend WithEvents btn_Drop As System.Windows.Forms.Button
    Friend WithEvents btn_GLink As System.Windows.Forms.Button
    Friend WithEvents txt_Worker As System.Windows.Forms.TextBox
    Friend WithEvents txt_Supervisor As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Opt61))
        Me.txt_Sex = New System.Windows.Forms.TextBox
        Me.txt_Office = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txt_EligSeg = New System.Windows.Forms.TextBox
        Me.txt_PersonAction = New System.Windows.Forms.TextBox
        Me.txt_AddressAction = New System.Windows.Forms.TextBox
        Me.txt_ActionCode1 = New System.Windows.Forms.TextBox
        Me.txt_ZipCode = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.txt_Address4 = New System.Windows.Forms.TextBox
        Me.txt_Address2 = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.txt_Address5 = New System.Windows.Forms.TextBox
        Me.txt_Address3 = New System.Windows.Forms.TextBox
        Me.txt_Address1 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_DateOfEntry = New System.Windows.Forms.TextBox
        Me.txt_AlienType = New System.Windows.Forms.TextBox
        Me.txt_LTC = New System.Windows.Forms.TextBox
        Me.txt_BuyInDate = New System.Windows.Forms.TextBox
        Me.txt_BuyInStatus = New System.Windows.Forms.TextBox
        Me.txt_PriorCaseNumber = New System.Windows.Forms.TextBox
        Me.txt_Race = New System.Windows.Forms.TextBox
        Me.txt_MaritalStatus = New System.Windows.Forms.TextBox
        Me.txt_DOB = New System.Windows.Forms.TextBox
        Me.txt_MiddleIntial = New System.Windows.Forms.TextBox
        Me.txt_FirstName = New System.Windows.Forms.TextBox
        Me.txt_LastName = New System.Windows.Forms.TextBox
        Me.txt_PerNumber = New System.Windows.Forms.TextBox
        Me.txt_ProviderWarning = New System.Windows.Forms.TextBox
        Me.txt_CaseNumber = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txt_SocialSecurity = New System.Windows.Forms.TextBox
        Me.txt_PregnancyDate2 = New System.Windows.Forms.TextBox
        Me.txt_ExtTyp2 = New System.Windows.Forms.TextBox
        Me.txt_CtyRes2 = New System.Windows.Forms.TextBox
        Me.txt_CntySupvn2 = New System.Windows.Forms.TextBox
        Me.txt_PgmSta2 = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.txt_TrmCode2 = New System.Windows.Forms.TextBox
        Me.txt_AddCode2 = New System.Windows.Forms.TextBox
        Me.txt_TerminationDate2 = New System.Windows.Forms.TextBox
        Me.txt_EffectiveDate2 = New System.Windows.Forms.TextBox
        Me.txt_PregnancyDate1 = New System.Windows.Forms.TextBox
        Me.txt_ExtTyp1 = New System.Windows.Forms.TextBox
        Me.txt_CtyRes1 = New System.Windows.Forms.TextBox
        Me.txt_AddCode6 = New System.Windows.Forms.TextBox
        Me.txt_CntySupvn1 = New System.Windows.Forms.TextBox
        Me.txt_PregnancyDate6 = New System.Windows.Forms.TextBox
        Me.txt_PgmSta1 = New System.Windows.Forms.TextBox
        Me.txt_TrmCode1 = New System.Windows.Forms.TextBox
        Me.txt_AddCode1 = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.txt_TerminationDate1 = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.txt_EffectiveDate1 = New System.Windows.Forms.TextBox
        Me.txt_PgmSta6 = New System.Windows.Forms.TextBox
        Me.txt_TrmCode6 = New System.Windows.Forms.TextBox
        Me.txt_CntySupvn6 = New System.Windows.Forms.TextBox
        Me.txt_ExtTyp6 = New System.Windows.Forms.TextBox
        Me.txt_CtyRes6 = New System.Windows.Forms.TextBox
        Me.txt_TerminationDate6 = New System.Windows.Forms.TextBox
        Me.txt_EffectiveDate6 = New System.Windows.Forms.TextBox
        Me.txt_PregnancyDate5 = New System.Windows.Forms.TextBox
        Me.txt_ExtTyp5 = New System.Windows.Forms.TextBox
        Me.txt_CtyRes5 = New System.Windows.Forms.TextBox
        Me.txt_CntySupvn5 = New System.Windows.Forms.TextBox
        Me.txt_PgmSta5 = New System.Windows.Forms.TextBox
        Me.txt_TrmCode5 = New System.Windows.Forms.TextBox
        Me.txt_AddCode5 = New System.Windows.Forms.TextBox
        Me.txt_TerminationDate5 = New System.Windows.Forms.TextBox
        Me.txt_EffectiveDate5 = New System.Windows.Forms.TextBox
        Me.txt_PregnancyDate4 = New System.Windows.Forms.TextBox
        Me.txt_ExtTyp4 = New System.Windows.Forms.TextBox
        Me.txt_CtyRes4 = New System.Windows.Forms.TextBox
        Me.txt_CntySupvn4 = New System.Windows.Forms.TextBox
        Me.txt_PgmSta4 = New System.Windows.Forms.TextBox
        Me.txt_TrmCode4 = New System.Windows.Forms.TextBox
        Me.txt_AddCode4 = New System.Windows.Forms.TextBox
        Me.txt_TerminationDate4 = New System.Windows.Forms.TextBox
        Me.txt_EffectiveDate4 = New System.Windows.Forms.TextBox
        Me.txt_PregnancyDate3 = New System.Windows.Forms.TextBox
        Me.txt_ExtTyp3 = New System.Windows.Forms.TextBox
        Me.txt_CtyRes3 = New System.Windows.Forms.TextBox
        Me.txt_CntySupvn3 = New System.Windows.Forms.TextBox
        Me.txt_PgmSta3 = New System.Windows.Forms.TextBox
        Me.txt_TrmCode3 = New System.Windows.Forms.TextBox
        Me.txt_AddCode3 = New System.Windows.Forms.TextBox
        Me.txt_TerminationDate3 = New System.Windows.Forms.TextBox
        Me.txt_EffectiveDate3 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txt_City = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txt_State = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txt_PriorPerNum = New System.Windows.Forms.TextBox
        Me.txt_ErrorMessage = New System.Windows.Forms.TextBox
        Me.btn_Continue = New System.Windows.Forms.Button
        Me.btn_Drop = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.btn_GLink = New System.Windows.Forms.Button
        Me.txt_Worker = New System.Windows.Forms.TextBox
        Me.txt_Supervisor = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txt_Sex
        '
        Me.txt_Sex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Sex.Location = New System.Drawing.Point(280, 200)
        Me.txt_Sex.MaxLength = 1
        Me.txt_Sex.Name = "txt_Sex"
        Me.txt_Sex.Size = New System.Drawing.Size(24, 20)
        Me.txt_Sex.TabIndex = 22
        '
        'txt_Office
        '
        Me.txt_Office.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Office.Location = New System.Drawing.Point(258, 8)
        Me.txt_Office.MaxLength = 4
        Me.txt_Office.Name = "txt_Office"
        Me.txt_Office.Size = New System.Drawing.Size(48, 20)
        Me.txt_Office.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label10.Location = New System.Drawing.Point(214, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 15)
        Me.Label10.TabIndex = 245
        Me.Label10.Text = "Office:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_EligSeg
        '
        Me.txt_EligSeg.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EligSeg.Location = New System.Drawing.Point(8, 288)
        Me.txt_EligSeg.MaxLength = 1
        Me.txt_EligSeg.Name = "txt_EligSeg"
        Me.txt_EligSeg.Size = New System.Drawing.Size(24, 20)
        Me.txt_EligSeg.TabIndex = 31
        '
        'txt_PersonAction
        '
        Me.txt_PersonAction.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PersonAction.Location = New System.Drawing.Point(8, 168)
        Me.txt_PersonAction.MaxLength = 1
        Me.txt_PersonAction.Name = "txt_PersonAction"
        Me.txt_PersonAction.Size = New System.Drawing.Size(24, 20)
        Me.txt_PersonAction.TabIndex = 13
        '
        'txt_AddressAction
        '
        Me.txt_AddressAction.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AddressAction.Location = New System.Drawing.Point(8, 40)
        Me.txt_AddressAction.MaxLength = 1
        Me.txt_AddressAction.Name = "txt_AddressAction"
        Me.txt_AddressAction.Size = New System.Drawing.Size(24, 20)
        Me.txt_AddressAction.TabIndex = 4
        '
        'txt_ActionCode1
        '
        Me.txt_ActionCode1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ActionCode1.Location = New System.Drawing.Point(8, 8)
        Me.txt_ActionCode1.MaxLength = 1
        Me.txt_ActionCode1.Name = "txt_ActionCode1"
        Me.txt_ActionCode1.Size = New System.Drawing.Size(24, 20)
        Me.txt_ActionCode1.TabIndex = 0
        '
        'txt_ZipCode
        '
        Me.txt_ZipCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ZipCode.Location = New System.Drawing.Point(400, 136)
        Me.txt_ZipCode.MaxLength = 5
        Me.txt_ZipCode.Name = "txt_ZipCode"
        Me.txt_ZipCode.Size = New System.Drawing.Size(48, 20)
        Me.txt_ZipCode.TabIndex = 12
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label46.Location = New System.Drawing.Point(341, 138)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(59, 15)
        Me.Label46.TabIndex = 239
        Me.Label46.Text = "Zip Code:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_Address4
        '
        Me.txt_Address4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Address4.Location = New System.Drawing.Point(304, 72)
        Me.txt_Address4.MaxLength = 22
        Me.txt_Address4.Name = "txt_Address4"
        Me.txt_Address4.Size = New System.Drawing.Size(160, 20)
        Me.txt_Address4.TabIndex = 8
        '
        'txt_Address2
        '
        Me.txt_Address2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Address2.Location = New System.Drawing.Point(304, 40)
        Me.txt_Address2.MaxLength = 22
        Me.txt_Address2.Name = "txt_Address2"
        Me.txt_Address2.Size = New System.Drawing.Size(160, 20)
        Me.txt_Address2.TabIndex = 6
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label44.Location = New System.Drawing.Point(286, 74)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(18, 15)
        Me.Label44.TabIndex = 234
        Me.Label44.Text = "4)"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label45.Location = New System.Drawing.Point(286, 42)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(18, 15)
        Me.Label45.TabIndex = 233
        Me.Label45.Text = "2)"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_Address5
        '
        Me.txt_Address5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Address5.Location = New System.Drawing.Point(120, 104)
        Me.txt_Address5.MaxLength = 22
        Me.txt_Address5.Name = "txt_Address5"
        Me.txt_Address5.Size = New System.Drawing.Size(160, 20)
        Me.txt_Address5.TabIndex = 9
        '
        'txt_Address3
        '
        Me.txt_Address3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Address3.Location = New System.Drawing.Point(120, 72)
        Me.txt_Address3.MaxLength = 22
        Me.txt_Address3.Name = "txt_Address3"
        Me.txt_Address3.Size = New System.Drawing.Size(160, 20)
        Me.txt_Address3.TabIndex = 7
        '
        'txt_Address1
        '
        Me.txt_Address1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Address1.Location = New System.Drawing.Point(120, 40)
        Me.txt_Address1.MaxLength = 22
        Me.txt_Address1.Name = "txt_Address1"
        Me.txt_Address1.Size = New System.Drawing.Size(160, 20)
        Me.txt_Address1.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label8.Location = New System.Drawing.Point(104, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 15)
        Me.Label8.TabIndex = 229
        Me.Label8.Text = "5)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label7.Location = New System.Drawing.Point(104, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 15)
        Me.Label7.TabIndex = 228
        Me.Label7.Text = "3)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label6.Location = New System.Drawing.Point(104, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 15)
        Me.Label6.TabIndex = 227
        Me.Label6.Text = "1)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label5.Location = New System.Drawing.Point(45, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 226
        Me.Label5.Text = "Address:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_DateOfEntry
        '
        Me.txt_DateOfEntry.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DateOfEntry.Location = New System.Drawing.Point(632, 232)
        Me.txt_DateOfEntry.MaxLength = 8
        Me.txt_DateOfEntry.Name = "txt_DateOfEntry"
        Me.txt_DateOfEntry.Size = New System.Drawing.Size(64, 20)
        Me.txt_DateOfEntry.TabIndex = 28
        '
        'txt_AlienType
        '
        Me.txt_AlienType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AlienType.Location = New System.Drawing.Point(520, 232)
        Me.txt_AlienType.MaxLength = 2
        Me.txt_AlienType.Name = "txt_AlienType"
        Me.txt_AlienType.Size = New System.Drawing.Size(24, 20)
        Me.txt_AlienType.TabIndex = 27
        '
        'txt_LTC
        '
        Me.txt_LTC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_LTC.Location = New System.Drawing.Point(424, 232)
        Me.txt_LTC.MaxLength = 1
        Me.txt_LTC.Name = "txt_LTC"
        Me.txt_LTC.ReadOnly = True
        Me.txt_LTC.Size = New System.Drawing.Size(24, 20)
        Me.txt_LTC.TabIndex = 26
        '
        'txt_BuyInDate
        '
        Me.txt_BuyInDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_BuyInDate.Location = New System.Drawing.Point(288, 232)
        Me.txt_BuyInDate.MaxLength = 8
        Me.txt_BuyInDate.Name = "txt_BuyInDate"
        Me.txt_BuyInDate.ReadOnly = True
        Me.txt_BuyInDate.Size = New System.Drawing.Size(64, 20)
        Me.txt_BuyInDate.TabIndex = 25
        '
        'txt_BuyInStatus
        '
        Me.txt_BuyInStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_BuyInStatus.Location = New System.Drawing.Point(136, 232)
        Me.txt_BuyInStatus.MaxLength = 1
        Me.txt_BuyInStatus.Name = "txt_BuyInStatus"
        Me.txt_BuyInStatus.ReadOnly = True
        Me.txt_BuyInStatus.Size = New System.Drawing.Size(24, 20)
        Me.txt_BuyInStatus.TabIndex = 24
        '
        'txt_PriorCaseNumber
        '
        Me.txt_PriorCaseNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PriorCaseNumber.Location = New System.Drawing.Point(552, 200)
        Me.txt_PriorCaseNumber.MaxLength = 10
        Me.txt_PriorCaseNumber.Name = "txt_PriorCaseNumber"
        Me.txt_PriorCaseNumber.Size = New System.Drawing.Size(80, 20)
        Me.txt_PriorCaseNumber.TabIndex = 22
        '
        'txt_Race
        '
        Me.txt_Race.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Race.Location = New System.Drawing.Point(456, 200)
        Me.txt_Race.MaxLength = 1
        Me.txt_Race.Name = "txt_Race"
        Me.txt_Race.Size = New System.Drawing.Size(24, 20)
        Me.txt_Race.TabIndex = 21
        '
        'txt_MaritalStatus
        '
        Me.txt_MaritalStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MaritalStatus.Location = New System.Drawing.Point(392, 200)
        Me.txt_MaritalStatus.MaxLength = 1
        Me.txt_MaritalStatus.Name = "txt_MaritalStatus"
        Me.txt_MaritalStatus.Size = New System.Drawing.Size(24, 20)
        Me.txt_MaritalStatus.TabIndex = 20
        '
        'txt_DOB
        '
        Me.txt_DOB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_DOB.Location = New System.Drawing.Point(712, 168)
        Me.txt_DOB.MaxLength = 8
        Me.txt_DOB.Name = "txt_DOB"
        Me.txt_DOB.Size = New System.Drawing.Size(64, 20)
        Me.txt_DOB.TabIndex = 18
        '
        'txt_MiddleIntial
        '
        Me.txt_MiddleIntial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MiddleIntial.Location = New System.Drawing.Point(608, 168)
        Me.txt_MiddleIntial.MaxLength = 1
        Me.txt_MiddleIntial.Name = "txt_MiddleIntial"
        Me.txt_MiddleIntial.Size = New System.Drawing.Size(24, 20)
        Me.txt_MiddleIntial.TabIndex = 17
        '
        'txt_FirstName
        '
        Me.txt_FirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FirstName.Location = New System.Drawing.Point(440, 168)
        Me.txt_FirstName.MaxLength = 7
        Me.txt_FirstName.Name = "txt_FirstName"
        Me.txt_FirstName.Size = New System.Drawing.Size(88, 20)
        Me.txt_FirstName.TabIndex = 16
        '
        'txt_LastName
        '
        Me.txt_LastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_LastName.Location = New System.Drawing.Point(248, 168)
        Me.txt_LastName.MaxLength = 12
        Me.txt_LastName.Name = "txt_LastName"
        Me.txt_LastName.Size = New System.Drawing.Size(120, 20)
        Me.txt_LastName.TabIndex = 15
        '
        'txt_PerNumber
        '
        Me.txt_PerNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PerNumber.Location = New System.Drawing.Point(144, 168)
        Me.txt_PerNumber.MaxLength = 2
        Me.txt_PerNumber.Name = "txt_PerNumber"
        Me.txt_PerNumber.ReadOnly = True
        Me.txt_PerNumber.Size = New System.Drawing.Size(32, 20)
        Me.txt_PerNumber.TabIndex = 14
        Me.txt_PerNumber.TabStop = False
        '
        'txt_ProviderWarning
        '
        Me.txt_ProviderWarning.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ProviderWarning.Location = New System.Drawing.Point(418, 8)
        Me.txt_ProviderWarning.MaxLength = 1
        Me.txt_ProviderWarning.Name = "txt_ProviderWarning"
        Me.txt_ProviderWarning.ReadOnly = True
        Me.txt_ProviderWarning.Size = New System.Drawing.Size(24, 20)
        Me.txt_ProviderWarning.TabIndex = 3
        '
        'txt_CaseNumber
        '
        Me.txt_CaseNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CaseNumber.Location = New System.Drawing.Point(130, 8)
        Me.txt_CaseNumber.MaxLength = 10
        Me.txt_CaseNumber.Name = "txt_CaseNumber"
        Me.txt_CaseNumber.Size = New System.Drawing.Size(80, 20)
        Me.txt_CaseNumber.TabIndex = 1
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label34.Location = New System.Drawing.Point(45, 290)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(96, 15)
        Me.Label34.TabIndex = 210
        Me.Label34.Text = "Eligibility Status"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label29.Location = New System.Drawing.Point(546, 234)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(84, 15)
        Me.Label29.TabIndex = 209
        Me.Label29.Text = "Date Of Entry:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label28.Location = New System.Drawing.Point(449, 234)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(68, 15)
        Me.Label28.TabIndex = 208
        Me.Label28.Text = "Alien Type:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label26.Location = New System.Drawing.Point(162, 235)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(126, 15)
        Me.Label26.TabIndex = 206
        Me.Label26.Text = "Buy-In Effective Date:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label25.Location = New System.Drawing.Point(45, 234)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(86, 15)
        Me.Label25.TabIndex = 205
        Me.Label25.Text = "Buy-In-Status:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label23.Location = New System.Drawing.Point(486, 189)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(82, 33)
        Me.Label23.TabIndex = 203
        Me.Label23.Text = "Prior Case Number:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label20.Location = New System.Drawing.Point(249, 202)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 15)
        Me.Label20.TabIndex = 200
        Me.Label20.Text = "Sex:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label19.Location = New System.Drawing.Point(45, 202)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(143, 15)
        Me.Label19.TabIndex = 199
        Me.Label19.Text = "Social Security Number:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label18.Location = New System.Drawing.Point(632, 170)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 198
        Me.Label18.Text = "Date Of Birth:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label17.Location = New System.Drawing.Point(530, 170)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(77, 15)
        Me.Label17.TabIndex = 197
        Me.Label17.Text = "Middle Intial:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label16.Location = New System.Drawing.Point(370, 170)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 15)
        Me.Label16.TabIndex = 195
        Me.Label16.Text = "First Name:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label15.Location = New System.Drawing.Point(177, 170)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 15)
        Me.Label15.TabIndex = 194
        Me.Label15.Text = "Last Name:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label14.Location = New System.Drawing.Point(45, 170)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 15)
        Me.Label14.TabIndex = 193
        Me.Label14.Text = "Person Number:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label12.Location = New System.Drawing.Point(307, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 15)
        Me.Label12.TabIndex = 192
        Me.Label12.Text = "Provider Warning:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label9.Location = New System.Drawing.Point(45, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 15)
        Me.Label9.TabIndex = 191
        Me.Label9.Text = "Case Number:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_SocialSecurity
        '
        Me.txt_SocialSecurity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SocialSecurity.Location = New System.Drawing.Point(184, 200)
        Me.txt_SocialSecurity.MaxLength = 9
        Me.txt_SocialSecurity.Name = "txt_SocialSecurity"
        Me.txt_SocialSecurity.Size = New System.Drawing.Size(64, 20)
        Me.txt_SocialSecurity.TabIndex = 19
        '
        'txt_PregnancyDate2
        '
        Me.txt_PregnancyDate2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PregnancyDate2.Location = New System.Drawing.Point(656, 368)
        Me.txt_PregnancyDate2.MaxLength = 8
        Me.txt_PregnancyDate2.Name = "txt_PregnancyDate2"
        Me.txt_PregnancyDate2.Size = New System.Drawing.Size(88, 20)
        Me.txt_PregnancyDate2.TabIndex = 49
        '
        'txt_ExtTyp2
        '
        Me.txt_ExtTyp2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExtTyp2.Location = New System.Drawing.Point(600, 368)
        Me.txt_ExtTyp2.MaxLength = 1
        Me.txt_ExtTyp2.Name = "txt_ExtTyp2"
        Me.txt_ExtTyp2.Size = New System.Drawing.Size(32, 20)
        Me.txt_ExtTyp2.TabIndex = 48
        '
        'txt_CtyRes2
        '
        Me.txt_CtyRes2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CtyRes2.Location = New System.Drawing.Point(536, 368)
        Me.txt_CtyRes2.MaxLength = 2
        Me.txt_CtyRes2.Name = "txt_CtyRes2"
        Me.txt_CtyRes2.Size = New System.Drawing.Size(32, 20)
        Me.txt_CtyRes2.TabIndex = 47
        '
        'txt_CntySupvn2
        '
        Me.txt_CntySupvn2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CntySupvn2.Location = New System.Drawing.Point(456, 368)
        Me.txt_CntySupvn2.MaxLength = 3
        Me.txt_CntySupvn2.Name = "txt_CntySupvn2"
        Me.txt_CntySupvn2.Size = New System.Drawing.Size(48, 20)
        Me.txt_CntySupvn2.TabIndex = 46
        '
        'txt_PgmSta2
        '
        Me.txt_PgmSta2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PgmSta2.Location = New System.Drawing.Point(384, 368)
        Me.txt_PgmSta2.MaxLength = 3
        Me.txt_PgmSta2.Name = "txt_PgmSta2"
        Me.txt_PgmSta2.Size = New System.Drawing.Size(48, 20)
        Me.txt_PgmSta2.TabIndex = 45
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label40.Location = New System.Drawing.Point(446, 318)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(80, 15)
        Me.Label40.TabIndex = 253
        Me.Label40.Text = "CNTY SUPVN"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_TrmCode2
        '
        Me.txt_TrmCode2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TrmCode2.Location = New System.Drawing.Point(320, 368)
        Me.txt_TrmCode2.MaxLength = 2
        Me.txt_TrmCode2.Name = "txt_TrmCode2"
        Me.txt_TrmCode2.Size = New System.Drawing.Size(40, 20)
        Me.txt_TrmCode2.TabIndex = 44
        '
        'txt_AddCode2
        '
        Me.txt_AddCode2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AddCode2.Location = New System.Drawing.Point(248, 368)
        Me.txt_AddCode2.MaxLength = 2
        Me.txt_AddCode2.Name = "txt_AddCode2"
        Me.txt_AddCode2.Size = New System.Drawing.Size(40, 20)
        Me.txt_AddCode2.TabIndex = 43
        '
        'txt_TerminationDate2
        '
        Me.txt_TerminationDate2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TerminationDate2.Location = New System.Drawing.Point(144, 368)
        Me.txt_TerminationDate2.MaxLength = 8
        Me.txt_TerminationDate2.Name = "txt_TerminationDate2"
        Me.txt_TerminationDate2.Size = New System.Drawing.Size(72, 20)
        Me.txt_TerminationDate2.TabIndex = 42
        '
        'txt_EffectiveDate2
        '
        Me.txt_EffectiveDate2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EffectiveDate2.Location = New System.Drawing.Point(48, 368)
        Me.txt_EffectiveDate2.MaxLength = 8
        Me.txt_EffectiveDate2.Name = "txt_EffectiveDate2"
        Me.txt_EffectiveDate2.Size = New System.Drawing.Size(72, 20)
        Me.txt_EffectiveDate2.TabIndex = 41
        '
        'txt_PregnancyDate1
        '
        Me.txt_PregnancyDate1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PregnancyDate1.Location = New System.Drawing.Point(656, 336)
        Me.txt_PregnancyDate1.MaxLength = 8
        Me.txt_PregnancyDate1.Name = "txt_PregnancyDate1"
        Me.txt_PregnancyDate1.Size = New System.Drawing.Size(88, 20)
        Me.txt_PregnancyDate1.TabIndex = 40
        '
        'txt_ExtTyp1
        '
        Me.txt_ExtTyp1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExtTyp1.Location = New System.Drawing.Point(600, 336)
        Me.txt_ExtTyp1.MaxLength = 1
        Me.txt_ExtTyp1.Name = "txt_ExtTyp1"
        Me.txt_ExtTyp1.Size = New System.Drawing.Size(32, 20)
        Me.txt_ExtTyp1.TabIndex = 39
        '
        'txt_CtyRes1
        '
        Me.txt_CtyRes1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CtyRes1.Location = New System.Drawing.Point(536, 336)
        Me.txt_CtyRes1.MaxLength = 2
        Me.txt_CtyRes1.Name = "txt_CtyRes1"
        Me.txt_CtyRes1.Size = New System.Drawing.Size(32, 20)
        Me.txt_CtyRes1.TabIndex = 38
        '
        'txt_AddCode6
        '
        Me.txt_AddCode6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AddCode6.Location = New System.Drawing.Point(248, 496)
        Me.txt_AddCode6.MaxLength = 2
        Me.txt_AddCode6.Name = "txt_AddCode6"
        Me.txt_AddCode6.Size = New System.Drawing.Size(40, 20)
        Me.txt_AddCode6.TabIndex = 79
        '
        'txt_CntySupvn1
        '
        Me.txt_CntySupvn1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CntySupvn1.Location = New System.Drawing.Point(456, 336)
        Me.txt_CntySupvn1.MaxLength = 3
        Me.txt_CntySupvn1.Name = "txt_CntySupvn1"
        Me.txt_CntySupvn1.Size = New System.Drawing.Size(48, 20)
        Me.txt_CntySupvn1.TabIndex = 37
        '
        'txt_PregnancyDate6
        '
        Me.txt_PregnancyDate6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PregnancyDate6.Location = New System.Drawing.Point(656, 496)
        Me.txt_PregnancyDate6.MaxLength = 8
        Me.txt_PregnancyDate6.Name = "txt_PregnancyDate6"
        Me.txt_PregnancyDate6.Size = New System.Drawing.Size(88, 20)
        Me.txt_PregnancyDate6.TabIndex = 85
        '
        'txt_PgmSta1
        '
        Me.txt_PgmSta1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PgmSta1.Location = New System.Drawing.Point(384, 336)
        Me.txt_PgmSta1.MaxLength = 3
        Me.txt_PgmSta1.Name = "txt_PgmSta1"
        Me.txt_PgmSta1.Size = New System.Drawing.Size(48, 20)
        Me.txt_PgmSta1.TabIndex = 36
        '
        'txt_TrmCode1
        '
        Me.txt_TrmCode1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TrmCode1.Location = New System.Drawing.Point(320, 336)
        Me.txt_TrmCode1.MaxLength = 2
        Me.txt_TrmCode1.Name = "txt_TrmCode1"
        Me.txt_TrmCode1.Size = New System.Drawing.Size(40, 20)
        Me.txt_TrmCode1.TabIndex = 35
        '
        'txt_AddCode1
        '
        Me.txt_AddCode1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AddCode1.Location = New System.Drawing.Point(248, 336)
        Me.txt_AddCode1.MaxLength = 2
        Me.txt_AddCode1.Name = "txt_AddCode1"
        Me.txt_AddCode1.Size = New System.Drawing.Size(40, 20)
        Me.txt_AddCode1.TabIndex = 34
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label43.Location = New System.Drawing.Point(649, 318)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(122, 15)
        Me.Label43.TabIndex = 256
        Me.Label43.Text = "Pregnancy Due Date"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label42.Location = New System.Drawing.Point(589, 318)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(54, 15)
        Me.Label42.TabIndex = 255
        Me.Label42.Text = "EXT TYP"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label41.Location = New System.Drawing.Point(525, 318)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(55, 15)
        Me.Label41.TabIndex = 254
        Me.Label41.Text = "CTY RES"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_TerminationDate1
        '
        Me.txt_TerminationDate1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TerminationDate1.Location = New System.Drawing.Point(144, 336)
        Me.txt_TerminationDate1.MaxLength = 8
        Me.txt_TerminationDate1.Name = "txt_TerminationDate1"
        Me.txt_TerminationDate1.Size = New System.Drawing.Size(72, 20)
        Me.txt_TerminationDate1.TabIndex = 33
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label39.Location = New System.Drawing.Point(381, 318)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(59, 15)
        Me.Label39.TabIndex = 252
        Me.Label39.Text = "PGM STA"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label38.Location = New System.Drawing.Point(314, 318)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(64, 15)
        Me.Label38.TabIndex = 251
        Me.Label38.Text = "TRM Code"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label37.Location = New System.Drawing.Point(240, 318)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(61, 15)
        Me.Label37.TabIndex = 250
        Me.Label37.Text = "Add Code"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label36.Location = New System.Drawing.Point(130, 318)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(104, 15)
        Me.Label36.TabIndex = 249
        Me.Label36.Text = "Termination Date"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label35.Location = New System.Drawing.Point(45, 318)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(85, 15)
        Me.Label35.TabIndex = 248
        Me.Label35.Text = "Effective Date"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_EffectiveDate1
        '
        Me.txt_EffectiveDate1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EffectiveDate1.Location = New System.Drawing.Point(48, 336)
        Me.txt_EffectiveDate1.MaxLength = 8
        Me.txt_EffectiveDate1.Name = "txt_EffectiveDate1"
        Me.txt_EffectiveDate1.Size = New System.Drawing.Size(72, 20)
        Me.txt_EffectiveDate1.TabIndex = 32
        '
        'txt_PgmSta6
        '
        Me.txt_PgmSta6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PgmSta6.Location = New System.Drawing.Point(384, 496)
        Me.txt_PgmSta6.MaxLength = 3
        Me.txt_PgmSta6.Name = "txt_PgmSta6"
        Me.txt_PgmSta6.Size = New System.Drawing.Size(48, 20)
        Me.txt_PgmSta6.TabIndex = 81
        '
        'txt_TrmCode6
        '
        Me.txt_TrmCode6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TrmCode6.Location = New System.Drawing.Point(320, 496)
        Me.txt_TrmCode6.MaxLength = 2
        Me.txt_TrmCode6.Name = "txt_TrmCode6"
        Me.txt_TrmCode6.Size = New System.Drawing.Size(40, 20)
        Me.txt_TrmCode6.TabIndex = 80
        '
        'txt_CntySupvn6
        '
        Me.txt_CntySupvn6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CntySupvn6.Location = New System.Drawing.Point(456, 496)
        Me.txt_CntySupvn6.MaxLength = 3
        Me.txt_CntySupvn6.Name = "txt_CntySupvn6"
        Me.txt_CntySupvn6.Size = New System.Drawing.Size(48, 20)
        Me.txt_CntySupvn6.TabIndex = 82
        '
        'txt_ExtTyp6
        '
        Me.txt_ExtTyp6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExtTyp6.Location = New System.Drawing.Point(600, 496)
        Me.txt_ExtTyp6.MaxLength = 1
        Me.txt_ExtTyp6.Name = "txt_ExtTyp6"
        Me.txt_ExtTyp6.Size = New System.Drawing.Size(32, 20)
        Me.txt_ExtTyp6.TabIndex = 84
        '
        'txt_CtyRes6
        '
        Me.txt_CtyRes6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CtyRes6.Location = New System.Drawing.Point(536, 496)
        Me.txt_CtyRes6.MaxLength = 2
        Me.txt_CtyRes6.Name = "txt_CtyRes6"
        Me.txt_CtyRes6.Size = New System.Drawing.Size(32, 20)
        Me.txt_CtyRes6.TabIndex = 83
        '
        'txt_TerminationDate6
        '
        Me.txt_TerminationDate6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TerminationDate6.Location = New System.Drawing.Point(144, 496)
        Me.txt_TerminationDate6.MaxLength = 8
        Me.txt_TerminationDate6.Name = "txt_TerminationDate6"
        Me.txt_TerminationDate6.Size = New System.Drawing.Size(72, 20)
        Me.txt_TerminationDate6.TabIndex = 78
        '
        'txt_EffectiveDate6
        '
        Me.txt_EffectiveDate6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EffectiveDate6.Location = New System.Drawing.Point(48, 496)
        Me.txt_EffectiveDate6.MaxLength = 8
        Me.txt_EffectiveDate6.Name = "txt_EffectiveDate6"
        Me.txt_EffectiveDate6.Size = New System.Drawing.Size(72, 20)
        Me.txt_EffectiveDate6.TabIndex = 77
        '
        'txt_PregnancyDate5
        '
        Me.txt_PregnancyDate5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PregnancyDate5.Location = New System.Drawing.Point(656, 464)
        Me.txt_PregnancyDate5.MaxLength = 8
        Me.txt_PregnancyDate5.Name = "txt_PregnancyDate5"
        Me.txt_PregnancyDate5.Size = New System.Drawing.Size(88, 20)
        Me.txt_PregnancyDate5.TabIndex = 76
        '
        'txt_ExtTyp5
        '
        Me.txt_ExtTyp5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExtTyp5.Location = New System.Drawing.Point(600, 464)
        Me.txt_ExtTyp5.MaxLength = 1
        Me.txt_ExtTyp5.Name = "txt_ExtTyp5"
        Me.txt_ExtTyp5.Size = New System.Drawing.Size(32, 20)
        Me.txt_ExtTyp5.TabIndex = 75
        '
        'txt_CtyRes5
        '
        Me.txt_CtyRes5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CtyRes5.Location = New System.Drawing.Point(536, 464)
        Me.txt_CtyRes5.MaxLength = 2
        Me.txt_CtyRes5.Name = "txt_CtyRes5"
        Me.txt_CtyRes5.Size = New System.Drawing.Size(32, 20)
        Me.txt_CtyRes5.TabIndex = 74
        '
        'txt_CntySupvn5
        '
        Me.txt_CntySupvn5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CntySupvn5.Location = New System.Drawing.Point(456, 464)
        Me.txt_CntySupvn5.MaxLength = 3
        Me.txt_CntySupvn5.Name = "txt_CntySupvn5"
        Me.txt_CntySupvn5.Size = New System.Drawing.Size(48, 20)
        Me.txt_CntySupvn5.TabIndex = 73
        '
        'txt_PgmSta5
        '
        Me.txt_PgmSta5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PgmSta5.Location = New System.Drawing.Point(384, 464)
        Me.txt_PgmSta5.MaxLength = 3
        Me.txt_PgmSta5.Name = "txt_PgmSta5"
        Me.txt_PgmSta5.Size = New System.Drawing.Size(48, 20)
        Me.txt_PgmSta5.TabIndex = 72
        '
        'txt_TrmCode5
        '
        Me.txt_TrmCode5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TrmCode5.Location = New System.Drawing.Point(320, 464)
        Me.txt_TrmCode5.MaxLength = 2
        Me.txt_TrmCode5.Name = "txt_TrmCode5"
        Me.txt_TrmCode5.Size = New System.Drawing.Size(40, 20)
        Me.txt_TrmCode5.TabIndex = 71
        '
        'txt_AddCode5
        '
        Me.txt_AddCode5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AddCode5.Location = New System.Drawing.Point(248, 464)
        Me.txt_AddCode5.MaxLength = 2
        Me.txt_AddCode5.Name = "txt_AddCode5"
        Me.txt_AddCode5.Size = New System.Drawing.Size(40, 20)
        Me.txt_AddCode5.TabIndex = 70
        '
        'txt_TerminationDate5
        '
        Me.txt_TerminationDate5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TerminationDate5.Location = New System.Drawing.Point(144, 464)
        Me.txt_TerminationDate5.MaxLength = 8
        Me.txt_TerminationDate5.Name = "txt_TerminationDate5"
        Me.txt_TerminationDate5.Size = New System.Drawing.Size(72, 20)
        Me.txt_TerminationDate5.TabIndex = 69
        '
        'txt_EffectiveDate5
        '
        Me.txt_EffectiveDate5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EffectiveDate5.Location = New System.Drawing.Point(48, 464)
        Me.txt_EffectiveDate5.MaxLength = 8
        Me.txt_EffectiveDate5.Name = "txt_EffectiveDate5"
        Me.txt_EffectiveDate5.Size = New System.Drawing.Size(72, 20)
        Me.txt_EffectiveDate5.TabIndex = 68
        '
        'txt_PregnancyDate4
        '
        Me.txt_PregnancyDate4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PregnancyDate4.Location = New System.Drawing.Point(656, 432)
        Me.txt_PregnancyDate4.MaxLength = 8
        Me.txt_PregnancyDate4.Name = "txt_PregnancyDate4"
        Me.txt_PregnancyDate4.Size = New System.Drawing.Size(88, 20)
        Me.txt_PregnancyDate4.TabIndex = 67
        '
        'txt_ExtTyp4
        '
        Me.txt_ExtTyp4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExtTyp4.Location = New System.Drawing.Point(600, 432)
        Me.txt_ExtTyp4.MaxLength = 1
        Me.txt_ExtTyp4.Name = "txt_ExtTyp4"
        Me.txt_ExtTyp4.Size = New System.Drawing.Size(32, 20)
        Me.txt_ExtTyp4.TabIndex = 66
        '
        'txt_CtyRes4
        '
        Me.txt_CtyRes4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CtyRes4.Location = New System.Drawing.Point(536, 432)
        Me.txt_CtyRes4.MaxLength = 2
        Me.txt_CtyRes4.Name = "txt_CtyRes4"
        Me.txt_CtyRes4.Size = New System.Drawing.Size(32, 20)
        Me.txt_CtyRes4.TabIndex = 65
        '
        'txt_CntySupvn4
        '
        Me.txt_CntySupvn4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CntySupvn4.Location = New System.Drawing.Point(456, 432)
        Me.txt_CntySupvn4.MaxLength = 3
        Me.txt_CntySupvn4.Name = "txt_CntySupvn4"
        Me.txt_CntySupvn4.Size = New System.Drawing.Size(48, 20)
        Me.txt_CntySupvn4.TabIndex = 64
        '
        'txt_PgmSta4
        '
        Me.txt_PgmSta4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PgmSta4.Location = New System.Drawing.Point(384, 432)
        Me.txt_PgmSta4.MaxLength = 3
        Me.txt_PgmSta4.Name = "txt_PgmSta4"
        Me.txt_PgmSta4.Size = New System.Drawing.Size(48, 20)
        Me.txt_PgmSta4.TabIndex = 63
        '
        'txt_TrmCode4
        '
        Me.txt_TrmCode4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TrmCode4.Location = New System.Drawing.Point(320, 432)
        Me.txt_TrmCode4.MaxLength = 2
        Me.txt_TrmCode4.Name = "txt_TrmCode4"
        Me.txt_TrmCode4.Size = New System.Drawing.Size(40, 20)
        Me.txt_TrmCode4.TabIndex = 62
        '
        'txt_AddCode4
        '
        Me.txt_AddCode4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AddCode4.Location = New System.Drawing.Point(248, 432)
        Me.txt_AddCode4.MaxLength = 2
        Me.txt_AddCode4.Name = "txt_AddCode4"
        Me.txt_AddCode4.Size = New System.Drawing.Size(40, 20)
        Me.txt_AddCode4.TabIndex = 61
        '
        'txt_TerminationDate4
        '
        Me.txt_TerminationDate4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TerminationDate4.Location = New System.Drawing.Point(144, 432)
        Me.txt_TerminationDate4.MaxLength = 8
        Me.txt_TerminationDate4.Name = "txt_TerminationDate4"
        Me.txt_TerminationDate4.Size = New System.Drawing.Size(72, 20)
        Me.txt_TerminationDate4.TabIndex = 60
        '
        'txt_EffectiveDate4
        '
        Me.txt_EffectiveDate4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EffectiveDate4.Location = New System.Drawing.Point(48, 432)
        Me.txt_EffectiveDate4.MaxLength = 8
        Me.txt_EffectiveDate4.Name = "txt_EffectiveDate4"
        Me.txt_EffectiveDate4.Size = New System.Drawing.Size(72, 20)
        Me.txt_EffectiveDate4.TabIndex = 59
        '
        'txt_PregnancyDate3
        '
        Me.txt_PregnancyDate3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PregnancyDate3.Location = New System.Drawing.Point(656, 400)
        Me.txt_PregnancyDate3.MaxLength = 8
        Me.txt_PregnancyDate3.Name = "txt_PregnancyDate3"
        Me.txt_PregnancyDate3.Size = New System.Drawing.Size(88, 20)
        Me.txt_PregnancyDate3.TabIndex = 58
        '
        'txt_ExtTyp3
        '
        Me.txt_ExtTyp3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ExtTyp3.Location = New System.Drawing.Point(600, 400)
        Me.txt_ExtTyp3.MaxLength = 1
        Me.txt_ExtTyp3.Name = "txt_ExtTyp3"
        Me.txt_ExtTyp3.Size = New System.Drawing.Size(32, 20)
        Me.txt_ExtTyp3.TabIndex = 57
        '
        'txt_CtyRes3
        '
        Me.txt_CtyRes3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CtyRes3.Location = New System.Drawing.Point(536, 400)
        Me.txt_CtyRes3.MaxLength = 2
        Me.txt_CtyRes3.Name = "txt_CtyRes3"
        Me.txt_CtyRes3.Size = New System.Drawing.Size(32, 20)
        Me.txt_CtyRes3.TabIndex = 56
        '
        'txt_CntySupvn3
        '
        Me.txt_CntySupvn3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CntySupvn3.Location = New System.Drawing.Point(456, 400)
        Me.txt_CntySupvn3.MaxLength = 3
        Me.txt_CntySupvn3.Name = "txt_CntySupvn3"
        Me.txt_CntySupvn3.Size = New System.Drawing.Size(48, 20)
        Me.txt_CntySupvn3.TabIndex = 55
        '
        'txt_PgmSta3
        '
        Me.txt_PgmSta3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PgmSta3.Location = New System.Drawing.Point(384, 400)
        Me.txt_PgmSta3.MaxLength = 3
        Me.txt_PgmSta3.Name = "txt_PgmSta3"
        Me.txt_PgmSta3.Size = New System.Drawing.Size(48, 20)
        Me.txt_PgmSta3.TabIndex = 54
        '
        'txt_TrmCode3
        '
        Me.txt_TrmCode3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TrmCode3.Location = New System.Drawing.Point(320, 400)
        Me.txt_TrmCode3.MaxLength = 2
        Me.txt_TrmCode3.Name = "txt_TrmCode3"
        Me.txt_TrmCode3.Size = New System.Drawing.Size(40, 20)
        Me.txt_TrmCode3.TabIndex = 53
        '
        'txt_AddCode3
        '
        Me.txt_AddCode3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_AddCode3.Location = New System.Drawing.Point(248, 400)
        Me.txt_AddCode3.MaxLength = 2
        Me.txt_AddCode3.Name = "txt_AddCode3"
        Me.txt_AddCode3.Size = New System.Drawing.Size(40, 20)
        Me.txt_AddCode3.TabIndex = 52
        '
        'txt_TerminationDate3
        '
        Me.txt_TerminationDate3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TerminationDate3.Location = New System.Drawing.Point(144, 400)
        Me.txt_TerminationDate3.MaxLength = 8
        Me.txt_TerminationDate3.Name = "txt_TerminationDate3"
        Me.txt_TerminationDate3.Size = New System.Drawing.Size(72, 20)
        Me.txt_TerminationDate3.TabIndex = 51
        '
        'txt_EffectiveDate3
        '
        Me.txt_EffectiveDate3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_EffectiveDate3.Location = New System.Drawing.Point(48, 400)
        Me.txt_EffectiveDate3.MaxLength = 8
        Me.txt_EffectiveDate3.Name = "txt_EffectiveDate3"
        Me.txt_EffectiveDate3.Size = New System.Drawing.Size(72, 20)
        Me.txt_EffectiveDate3.TabIndex = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label1.Location = New System.Drawing.Point(354, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "LTC Code:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label2.Location = New System.Drawing.Point(632, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 33)
        Me.Label2.TabIndex = 204
        Me.Label2.Text = "Prior Person Number:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label4.Location = New System.Drawing.Point(419, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 15)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Race:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label13.Location = New System.Drawing.Point(306, 202)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 15)
        Me.Label13.TabIndex = 201
        Me.Label13.Text = "Marital Status:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_City
        '
        Me.txt_City.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_City.Location = New System.Drawing.Point(120, 136)
        Me.txt_City.MaxLength = 18
        Me.txt_City.Name = "txt_City"
        Me.txt_City.Size = New System.Drawing.Size(136, 20)
        Me.txt_City.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label3.Location = New System.Drawing.Point(89, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 312
        Me.Label3.Text = "City:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_State
        '
        Me.txt_State.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_State.Location = New System.Drawing.Point(304, 136)
        Me.txt_State.MaxLength = 2
        Me.txt_State.Name = "txt_State"
        Me.txt_State.Size = New System.Drawing.Size(32, 20)
        Me.txt_State.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label24.Location = New System.Drawing.Point(264, 138)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 15)
        Me.Label24.TabIndex = 314
        Me.Label24.Text = "State:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_PriorPerNum
        '
        Me.txt_PriorPerNum.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PriorPerNum.Location = New System.Drawing.Point(719, 200)
        Me.txt_PriorPerNum.MaxLength = 2
        Me.txt_PriorPerNum.Name = "txt_PriorPerNum"
        Me.txt_PriorPerNum.Size = New System.Drawing.Size(24, 20)
        Me.txt_PriorPerNum.TabIndex = 23
        '
        'txt_ErrorMessage
        '
        Me.txt_ErrorMessage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ErrorMessage.Location = New System.Drawing.Point(531, 26)
        Me.txt_ErrorMessage.MaxLength = 300
        Me.txt_ErrorMessage.Multiline = True
        Me.txt_ErrorMessage.Name = "txt_ErrorMessage"
        Me.txt_ErrorMessage.ReadOnly = True
        Me.txt_ErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_ErrorMessage.Size = New System.Drawing.Size(253, 62)
        Me.txt_ErrorMessage.TabIndex = 317
        Me.txt_ErrorMessage.TabStop = False
        '
        'btn_Continue
        '
        Me.btn_Continue.BackColor = System.Drawing.Color.Green
        Me.btn_Continue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Continue.Location = New System.Drawing.Point(625, 92)
        Me.btn_Continue.Name = "btn_Continue"
        Me.btn_Continue.Size = New System.Drawing.Size(78, 23)
        Me.btn_Continue.TabIndex = 87
        Me.btn_Continue.Text = "Continue"
        Me.btn_Continue.UseVisualStyleBackColor = False
        '
        'btn_Drop
        '
        Me.btn_Drop.BackColor = System.Drawing.Color.Red
        Me.btn_Drop.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Drop.Location = New System.Drawing.Point(709, 92)
        Me.btn_Drop.Name = "btn_Drop"
        Me.btn_Drop.Size = New System.Drawing.Size(75, 23)
        Me.btn_Drop.TabIndex = 88
        Me.btn_Drop.Text = "Drop"
        Me.btn_Drop.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label11.Location = New System.Drawing.Point(530, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 15)
        Me.Label11.TabIndex = 320
        Me.Label11.Text = "Error Message:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btn_GLink
        '
        Me.btn_GLink.BackColor = System.Drawing.Color.CadetBlue
        Me.btn_GLink.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_GLink.Location = New System.Drawing.Point(531, 92)
        Me.btn_GLink.Name = "btn_GLink"
        Me.btn_GLink.Size = New System.Drawing.Size(88, 23)
        Me.btn_GLink.TabIndex = 86
        Me.btn_GLink.Text = "Show Medi"
        Me.btn_GLink.UseVisualStyleBackColor = False
        '
        'txt_Worker
        '
        Me.txt_Worker.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Worker.Location = New System.Drawing.Point(198, 262)
        Me.txt_Worker.MaxLength = 2
        Me.txt_Worker.Name = "txt_Worker"
        Me.txt_Worker.Size = New System.Drawing.Size(24, 20)
        Me.txt_Worker.TabIndex = 30
        '
        'txt_Supervisor
        '
        Me.txt_Supervisor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Supervisor.Location = New System.Drawing.Point(116, 262)
        Me.txt_Supervisor.MaxLength = 2
        Me.txt_Supervisor.Name = "txt_Supervisor"
        Me.txt_Supervisor.Size = New System.Drawing.Size(24, 20)
        Me.txt_Supervisor.TabIndex = 29
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label21.Location = New System.Drawing.Point(146, 265)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 15)
        Me.Label21.TabIndex = 330
        Me.Label21.Text = "Worker:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.BlanchedAlmond
        Me.Label22.Location = New System.Drawing.Point(45, 265)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 15)
        Me.Label22.TabIndex = 329
        Me.Label22.Text = "Supervisor:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Opt61
        '
        Me.AcceptButton = Me.btn_Continue
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(165, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BackgroundImage = Global.Phoenix___Medicaid.My.Resources.Resources.RedBG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(792, 525)
        Me.Controls.Add(Me.txt_Worker)
        Me.Controls.Add(Me.txt_Supervisor)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.btn_GLink)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btn_Drop)
        Me.Controls.Add(Me.btn_Continue)
        Me.Controls.Add(Me.txt_PriorPerNum)
        Me.Controls.Add(Me.txt_State)
        Me.Controls.Add(Me.txt_City)
        Me.Controls.Add(Me.txt_Office)
        Me.Controls.Add(Me.txt_CaseNumber)
        Me.Controls.Add(Me.txt_PregnancyDate2)
        Me.Controls.Add(Me.txt_ExtTyp2)
        Me.Controls.Add(Me.txt_CtyRes2)
        Me.Controls.Add(Me.txt_CntySupvn2)
        Me.Controls.Add(Me.txt_PgmSta2)
        Me.Controls.Add(Me.txt_TrmCode2)
        Me.Controls.Add(Me.txt_AddCode2)
        Me.Controls.Add(Me.txt_TerminationDate2)
        Me.Controls.Add(Me.txt_EffectiveDate2)
        Me.Controls.Add(Me.txt_PregnancyDate1)
        Me.Controls.Add(Me.txt_ExtTyp1)
        Me.Controls.Add(Me.txt_CtyRes1)
        Me.Controls.Add(Me.txt_AddCode6)
        Me.Controls.Add(Me.txt_CntySupvn1)
        Me.Controls.Add(Me.txt_PregnancyDate6)
        Me.Controls.Add(Me.txt_PgmSta1)
        Me.Controls.Add(Me.txt_TrmCode1)
        Me.Controls.Add(Me.txt_AddCode1)
        Me.Controls.Add(Me.txt_TerminationDate1)
        Me.Controls.Add(Me.txt_EffectiveDate1)
        Me.Controls.Add(Me.txt_PgmSta6)
        Me.Controls.Add(Me.txt_TrmCode6)
        Me.Controls.Add(Me.txt_CntySupvn6)
        Me.Controls.Add(Me.txt_ExtTyp6)
        Me.Controls.Add(Me.txt_CtyRes6)
        Me.Controls.Add(Me.txt_TerminationDate6)
        Me.Controls.Add(Me.txt_EffectiveDate6)
        Me.Controls.Add(Me.txt_PregnancyDate5)
        Me.Controls.Add(Me.txt_ExtTyp5)
        Me.Controls.Add(Me.txt_CtyRes5)
        Me.Controls.Add(Me.txt_CntySupvn5)
        Me.Controls.Add(Me.txt_PgmSta5)
        Me.Controls.Add(Me.txt_TrmCode5)
        Me.Controls.Add(Me.txt_AddCode5)
        Me.Controls.Add(Me.txt_TerminationDate5)
        Me.Controls.Add(Me.txt_EffectiveDate5)
        Me.Controls.Add(Me.txt_PregnancyDate4)
        Me.Controls.Add(Me.txt_ExtTyp4)
        Me.Controls.Add(Me.txt_CtyRes4)
        Me.Controls.Add(Me.txt_CntySupvn4)
        Me.Controls.Add(Me.txt_PgmSta4)
        Me.Controls.Add(Me.txt_TrmCode4)
        Me.Controls.Add(Me.txt_AddCode4)
        Me.Controls.Add(Me.txt_TerminationDate4)
        Me.Controls.Add(Me.txt_EffectiveDate4)
        Me.Controls.Add(Me.txt_PregnancyDate3)
        Me.Controls.Add(Me.txt_ExtTyp3)
        Me.Controls.Add(Me.txt_CtyRes3)
        Me.Controls.Add(Me.txt_CntySupvn3)
        Me.Controls.Add(Me.txt_PgmSta3)
        Me.Controls.Add(Me.txt_TrmCode3)
        Me.Controls.Add(Me.txt_AddCode3)
        Me.Controls.Add(Me.txt_TerminationDate3)
        Me.Controls.Add(Me.txt_EffectiveDate3)
        Me.Controls.Add(Me.txt_Sex)
        Me.Controls.Add(Me.txt_EligSeg)
        Me.Controls.Add(Me.txt_PersonAction)
        Me.Controls.Add(Me.txt_AddressAction)
        Me.Controls.Add(Me.txt_ActionCode1)
        Me.Controls.Add(Me.txt_ZipCode)
        Me.Controls.Add(Me.txt_Address4)
        Me.Controls.Add(Me.txt_Address2)
        Me.Controls.Add(Me.txt_Address5)
        Me.Controls.Add(Me.txt_Address3)
        Me.Controls.Add(Me.txt_Address1)
        Me.Controls.Add(Me.txt_DateOfEntry)
        Me.Controls.Add(Me.txt_AlienType)
        Me.Controls.Add(Me.txt_LTC)
        Me.Controls.Add(Me.txt_BuyInDate)
        Me.Controls.Add(Me.txt_BuyInStatus)
        Me.Controls.Add(Me.txt_PriorCaseNumber)
        Me.Controls.Add(Me.txt_Race)
        Me.Controls.Add(Me.txt_MaritalStatus)
        Me.Controls.Add(Me.txt_DOB)
        Me.Controls.Add(Me.txt_MiddleIntial)
        Me.Controls.Add(Me.txt_FirstName)
        Me.Controls.Add(Me.txt_LastName)
        Me.Controls.Add(Me.txt_PerNumber)
        Me.Controls.Add(Me.txt_ProviderWarning)
        Me.Controls.Add(Me.txt_SocialSecurity)
        Me.Controls.Add(Me.txt_ErrorMessage)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label13)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Opt61"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Phoenix - OPT 61 Corrections"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
   Private Choice As String

    Private Sub Opt61_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Choice = Nothing
            AddEvents(Me)
            txt_ErrorMessage.Text = ErrorMessage1Medi & vbCrLf & ErrorMessage2Medi
            SetPage61()
            RedFieldCheck()
            txt_ActionCode1.Focus()
        Catch ex As Exception
            MessageBox.Show("Location: Opt61" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Opt61_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Choice = "Cont" Then
            isDrop = False
        Else
            isDrop = True
        End If
        e.Cancel = False
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

    Private Sub RedFieldCheck()
        Dim BlockArray(50), BlockName(50), BlockData(50) As String
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
                If BlockName(i) <> Nothing Then HighlightTextbox61(BlockName(i))
            Next
        End If
    End Sub
    Private Sub HighlightTextbox61(ByVal FieldNumber As String)
        With OPTS61Information
            If FieldNumber = .ActionCode.FieldNumber Then txt_ActionCode1.BackColor = Color.Red
            If FieldNumber = .CaseNumber.FieldNumber Then txt_CaseNumber.BackColor = Color.Red
            If FieldNumber = .Office.FieldNumber Then txt_Office.BackColor = Color.Red

            If FieldNumber = .AddressAction.FieldNumber Then txt_AddressAction.BackColor = Color.Red
            If FieldNumber = .Address.FieldNumber Then txt_Address1.BackColor = Color.Red
            If FieldNumber = .Address2.FieldNumber Then txt_Address2.BackColor = Color.Red
            If FieldNumber = .Address3.FieldNumber Then txt_Address3.BackColor = Color.Red
            If FieldNumber = .Address4.FieldNumber Then txt_Address4.BackColor = Color.Red
            'If FieldNumber = .a.FieldNumber Then txt_Address5.Text = txt_Address5.BackColor = Color.Red
            If FieldNumber = .City.FieldNumber Then txt_City.BackColor = Color.Red
            If FieldNumber = .State.FieldNumber Then txt_State.BackColor = Color.Red
            If FieldNumber = .Zip.FieldNumber Then txt_ZipCode.BackColor = Color.Red

            If FieldNumber = .PersonAction.FieldNumber Then txt_PersonAction.BackColor = Color.Red
            If FieldNumber = .PersonNumber.FieldNumber Then txt_PerNumber.BackColor = Color.Red
            If FieldNumber = .LastName.FieldNumber Then txt_LastName.BackColor = Color.Red
            If FieldNumber = .FirstName.FieldNumber Then txt_FirstName.BackColor = Color.Red
            If FieldNumber = .Middle.FieldNumber Then txt_MiddleIntial.BackColor = Color.Red
            If FieldNumber = .DateOfBirth.FieldNumber Then txt_DOB.BackColor = Color.Red

            If FieldNumber = .SocSec.FieldNumber Then txt_SocialSecurity.BackColor = Color.Red
            If FieldNumber = .Sex.FieldNumber Then txt_Sex.BackColor = Color.Red
            If FieldNumber = .MaritalStat.FieldNumber Then txt_MaritalStatus.BackColor = Color.Red
            If FieldNumber = .Race.FieldNumber Then txt_Race.BackColor = Color.Red
            If FieldNumber = .PriorCase.FieldNumber Then txt_PriorCaseNumber.BackColor = Color.Red
            If FieldNumber = .PriorPerNumber.FieldNumber Then txt_PriorPerNum.BackColor = Color.Red

            'txt_BuyInStatus.Text 	=	            'txt_BuyInStatus.backcolor = color.red 
            'txt_BuyInDate.Text 	=	            'txt_BuyInDate.backcolor = color.red 
            'txt_LTC.Text 	=	            'txt_LTC.backcolor = color.red 
            If FieldNumber = .AlienType.FieldNumber Then txt_AlienType.BackColor = Color.Red
            'If FieldNumber = ..FieldNumber Then   txt_DateOfEntry.Text = txt_DateOfEntry.BackColor = Color.Red
            If FieldNumber = .Supervisor.FieldNumber Then txt_Supervisor.BackColor = Color.Red
            If FieldNumber = .Worker61.FieldNumber Then txt_Worker.BackColor = Color.Red

            If FieldNumber = .EligSeg.FieldNumber Then txt_EligSeg.BackColor = Color.Red

            If FieldNumber = .EffDate(0).FieldNumber Then txt_EffectiveDate1.BackColor = Color.Red
            If FieldNumber = .TermDate(0).FieldNumber Then txt_TerminationDate1.BackColor = Color.Red
            If FieldNumber = .AddCode(0).FieldNumber Then txt_AddCode1.BackColor = Color.Red
            If FieldNumber = .TRMCode(0).FieldNumber Then txt_TrmCode1.BackColor = Color.Red
            If FieldNumber = .PGM(0).FieldNumber Then txt_PgmSta1.BackColor = Color.Red
            If FieldNumber = .SUPV(0).FieldNumber Then txt_CntySupvn1.BackColor = Color.Red
            If FieldNumber = .RES(0).FieldNumber Then txt_CtyRes1.BackColor = Color.Red
            If FieldNumber = .ExtType(0).FieldNumber Then txt_ExtTyp1.BackColor = Color.Red
            If FieldNumber = .PregDueDate(0).FieldNumber Then txt_PregnancyDate1.BackColor = Color.Red

            If FieldNumber = .EffDate(1).FieldNumber Then txt_EffectiveDate2.BackColor = Color.Red
            If FieldNumber = .TermDate(1).FieldNumber Then txt_TerminationDate2.BackColor = Color.Red
            If FieldNumber = .AddCode(1).FieldNumber Then txt_AddCode2.BackColor = Color.Red
            If FieldNumber = .TRMCode(1).FieldNumber Then txt_TrmCode2.BackColor = Color.Red
            If FieldNumber = .PGM(1).FieldNumber Then txt_PgmSta2.BackColor = Color.Red
            If FieldNumber = .SUPV(1).FieldNumber Then txt_CntySupvn2.BackColor = Color.Red
            If FieldNumber = .RES(1).FieldNumber Then txt_CtyRes2.BackColor = Color.Red
            If FieldNumber = .ExtType(1).FieldNumber Then txt_ExtTyp2.BackColor = Color.Red
            If FieldNumber = .PregDueDate(1).FieldNumber Then txt_PregnancyDate2.BackColor = Color.Red

            If FieldNumber = .EffDate(2).FieldNumber Then txt_EffectiveDate3.BackColor = Color.Red
            If FieldNumber = .TermDate(2).FieldNumber Then txt_TerminationDate3.BackColor = Color.Red
            If FieldNumber = .AddCode(2).FieldNumber Then txt_AddCode3.BackColor = Color.Red
            If FieldNumber = .TRMCode(2).FieldNumber Then txt_TrmCode3.BackColor = Color.Red
            If FieldNumber = .PGM(2).FieldNumber Then txt_PgmSta3.BackColor = Color.Red
            If FieldNumber = .SUPV(2).FieldNumber Then txt_CntySupvn3.BackColor = Color.Red
            If FieldNumber = .RES(2).FieldNumber Then txt_CtyRes3.BackColor = Color.Red
            If FieldNumber = .ExtType(2).FieldNumber Then txt_ExtTyp3.BackColor = Color.Red
            If FieldNumber = .PregDueDate(2).FieldNumber Then txt_PregnancyDate3.BackColor = Color.Red

            If FieldNumber = .EffDate(3).FieldNumber Then txt_EffectiveDate4.BackColor = Color.Red
            If FieldNumber = .TermDate(3).FieldNumber Then txt_TerminationDate4.BackColor = Color.Red
            If FieldNumber = .AddCode(3).FieldNumber Then txt_AddCode4.BackColor = Color.Red
            If FieldNumber = .TRMCode(3).FieldNumber Then txt_TrmCode4.BackColor = Color.Red
            If FieldNumber = .PGM(3).FieldNumber Then txt_PgmSta4.BackColor = Color.Red
            If FieldNumber = .SUPV(3).FieldNumber Then txt_CntySupvn4.BackColor = Color.Red
            If FieldNumber = .RES(3).FieldNumber Then txt_CtyRes4.BackColor = Color.Red
            If FieldNumber = .ExtType(3).FieldNumber Then txt_ExtTyp4.BackColor = Color.Red
            If FieldNumber = .PregDueDate(3).FieldNumber Then txt_PregnancyDate4.BackColor = Color.Red

            If FieldNumber = .EffDate(4).FieldNumber Then txt_EffectiveDate5.BackColor = Color.Red
            If FieldNumber = .TermDate(4).FieldNumber Then txt_TerminationDate5.BackColor = Color.Red
            If FieldNumber = .AddCode(4).FieldNumber Then txt_AddCode5.BackColor = Color.Red
            If FieldNumber = .TRMCode(4).FieldNumber Then txt_TrmCode5.BackColor = Color.Red
            If FieldNumber = .PGM(4).FieldNumber Then txt_PgmSta5.BackColor = Color.Red
            If FieldNumber = .SUPV(4).FieldNumber Then txt_CntySupvn5.BackColor = Color.Red
            If FieldNumber = .RES(4).FieldNumber Then txt_CtyRes5.BackColor = Color.Red
            If FieldNumber = .ExtType(4).FieldNumber Then txt_ExtTyp5.BackColor = Color.Red
            If FieldNumber = .PregDueDate(4).FieldNumber Then txt_PregnancyDate5.BackColor = Color.Red

            If FieldNumber = .EffDate(5).FieldNumber Then txt_EffectiveDate6.BackColor = Color.Red
            If FieldNumber = .TermDate(5).FieldNumber Then txt_TerminationDate6.BackColor = Color.Red
            If FieldNumber = .AddCode(5).FieldNumber Then txt_AddCode6.BackColor = Color.Red
            If FieldNumber = .TRMCode(5).FieldNumber Then txt_TrmCode6.BackColor = Color.Red
            If FieldNumber = .PGM(5).FieldNumber Then txt_PgmSta6.BackColor = Color.Red
            If FieldNumber = .SUPV(5).FieldNumber Then txt_CntySupvn6.BackColor = Color.Red
            If FieldNumber = .RES(5).FieldNumber Then txt_CtyRes6.BackColor = Color.Red
            If FieldNumber = .ExtType(5).FieldNumber Then txt_ExtTyp6.BackColor = Color.Red
            If FieldNumber = .PregDueDate(5).FieldNumber Then txt_PregnancyDate6.BackColor = Color.Red
        End With
    End Sub

    Sub SetPage61()
        With OPTS61Information
            txt_ActionCode1.Text = .ActionCode.GetData
            txt_CaseNumber.Text = .CaseNumber.GetData
            txt_Office.Text = .Office.GetData

            txt_AddressAction.Text = .AddressAction.GetData
            txt_Address1.Text = .CaseName.GetData
            txt_Address2.Text = .Address2.GetData
            txt_Address3.Text = .Address.GetData
            txt_Address4.Text = .Address3.GetData
            txt_Address5.Text = .Address4.GetData
            txt_City.Text = .City.GetData
            txt_State.Text = .State.GetData
            txt_ZipCode.Text = .Zip.GetData

            txt_PersonAction.Text = .PersonAction.GetData
            txt_PerNumber.Text = .PersonNumber.GetData
            txt_LastName.Text = .LastName.GetData
            txt_FirstName.Text = .FirstName.GetData
            txt_MiddleIntial.Text = .Middle.GetData
            txt_DOB.Text = .DateOfBirth.GetData

            txt_SocialSecurity.Text = .SocSec.GetData
            txt_Sex.Text = .Sex.GetData
            txt_MaritalStatus.Text = .MaritalStat.GetData
            txt_Race.Text = .Race.GetData
            txt_PriorCaseNumber.Text = .PriorCase.GetData
            txt_PriorPerNum.Text = .PriorPerNumber.GetData

            'txt_BuyInStatus.Text = .BUYINSTATUS
            'txt_BuyInDate.Text = .BUYINDATE
            'txt_LTC.Text = .LTC
            txt_AlienType.Text = .AlienType.GetData
            txt_DateOfEntry.Text = .tempDate.GetData
            txt_Supervisor.Text = .Supervisor.GetData
            txt_Worker.Text = .Worker61.GetData

            txt_EligSeg.Text = .EligSeg.GetData

            txt_EffectiveDate1.Text = .EffDate(0).GetData
            txt_TerminationDate1.Text = .TermDate(0).GetData
            txt_AddCode1.Text = .AddCode(0).GetData
            txt_TrmCode1.Text = .TRMCode(0).GetData
            txt_PgmSta1.Text = .PGM(0).GetData
            txt_CntySupvn1.Text = .SUPV(0).GetData
            txt_CtyRes1.Text = .RES(0).GetData
            txt_ExtTyp1.Text = .ExtType(0).GetData
            txt_PregnancyDate1.Text = .PregDueDate(0).GetData

            txt_EffectiveDate2.Text = .EffDate(1).GetData
            txt_TerminationDate2.Text = .TermDate(1).GetData
            txt_AddCode2.Text = .AddCode(1).GetData
            txt_TrmCode2.Text = .TRMCode(1).GetData
            txt_PgmSta2.Text = .PGM(1).GetData
            txt_CntySupvn2.Text = .SUPV(1).GetData
            txt_CtyRes2.Text = .RES(1).GetData
            txt_ExtTyp2.Text = .ExtType(1).GetData
            txt_PregnancyDate2.Text = .PregDueDate(1).GetData

            txt_EffectiveDate3.Text = .EffDate(2).GetData
            txt_TerminationDate3.Text = .TermDate(2).GetData
            txt_AddCode3.Text = .AddCode(2).GetData
            txt_TrmCode3.Text = .TRMCode(2).GetData
            txt_PgmSta3.Text = .PGM(2).GetData
            txt_CntySupvn3.Text = .SUPV(2).GetData
            txt_CtyRes3.Text = .RES(2).GetData
            txt_ExtTyp3.Text = .ExtType(2).GetData
            txt_PregnancyDate3.Text = .PregDueDate(2).GetData

            txt_EffectiveDate4.Text = .EffDate(3).GetData
            txt_TerminationDate4.Text = .TermDate(3).GetData
            txt_AddCode4.Text = .AddCode(3).GetData
            txt_TrmCode4.Text = .TRMCode(3).GetData
            txt_PgmSta4.Text = .PGM(3).GetData
            txt_CntySupvn4.Text = .SUPV(3).GetData
            txt_CtyRes4.Text = .RES(3).GetData
            txt_ExtTyp4.Text = .ExtType(3).GetData
            txt_PregnancyDate4.Text = .PregDueDate(3).GetData

            txt_EffectiveDate5.Text = .EffDate(4).GetData
            txt_TerminationDate5.Text = .TermDate(4).GetData
            txt_AddCode5.Text = .AddCode(4).GetData
            txt_TrmCode5.Text = .TRMCode(4).GetData
            txt_PgmSta5.Text = .PGM(4).GetData
            txt_CntySupvn5.Text = .SUPV(4).GetData
            txt_CtyRes5.Text = .RES(4).GetData
            txt_ExtTyp5.Text = .ExtType(4).GetData
            txt_PregnancyDate5.Text = .PregDueDate(4).GetData

            txt_EffectiveDate6.Text = .EffDate(5).GetData
            txt_TerminationDate6.Text = .TermDate(5).GetData
            txt_AddCode6.Text = .AddCode(5).GetData
            txt_TrmCode6.Text = .TRMCode(5).GetData
            txt_PgmSta6.Text = .PGM(5).GetData
            txt_CntySupvn6.Text = .SUPV(5).GetData
            txt_CtyRes6.Text = .RES(5).GetData
            txt_ExtTyp6.Text = .ExtType(5).GetData
            txt_PregnancyDate6.Text = .PregDueDate(5).GetData
        End With
    End Sub
    Sub transferPage61()
        With OPTS61Information
            .ActionCode.SetData(txt_ActionCode1.Text)
            .CaseNumber.SetData(txt_CaseNumber.Text)
            .Office.SetData(txt_Office.Text)

            .AddressAction.SetData(txt_AddressAction.Text)
            .CaseName.SetData(txt_Address1.Text)
            .Address2.SetData(txt_Address2.Text)
            .Address.SetData(txt_Address3.Text)
            .Address3.SetData(txt_Address4.Text)
            .Address4.SetData(txt_Address5.Text)
            .City.SetData(txt_City.Text)
            .State.SetData(txt_State.Text)
            .Zip.SetData(txt_ZipCode.Text)

            .PersonAction.SetData(txt_PersonAction.Text)
            '.PersonNumber.setdata(txt_PerNumber.text)
            .LastName.SetData(txt_LastName.Text)
            .FirstName.SetData(txt_FirstName.Text)
            .Middle.SetData(txt_MiddleIntial.Text)
            .DateOfBirth.SetData(txt_DOB.Text)

            .SocSec.SetData(txt_SocialSecurity.Text)
            .Sex.SetData(txt_Sex.Text)
            .MaritalStat.SetData(txt_MaritalStatus.Text)
            .Race.SetData(txt_Race.Text)
            .PriorCase.SetData(txt_PriorCaseNumber.Text)
            .PriorPerNumber.SetData(txt_PriorPerNum.Text)

            '.BUYINSTATUS	=	        'txt_BuyInStatus.text) 
            '.BUYINDATE	=	        'txt_BuyInDate.text) 
            '.LTC	=	        'txt_LTC.text) 
            .AlienType.SetData(txt_AlienType.Text)
            .tempDate.SetData(txt_DateOfEntry.Text)
            .Supervisor.SetData(txt_Supervisor.Text)
            .Worker61.SetData(txt_Worker.Text)

            .EligSeg.SetData(txt_EligSeg.Text)
            .EffDate(0).SetData(txt_EffectiveDate1.Text)
            .TermDate(0).SetData(txt_TerminationDate1.Text)
            .AddCode(0).SetData(txt_AddCode1.Text)
            .TRMCode(0).SetData(txt_TrmCode1.Text)
            .PGM(0).SetData(txt_PgmSta1.Text)
            .SUPV(0).SetData(txt_CntySupvn1.Text)
            .RES(0).SetData(txt_CtyRes1.Text)
            .ExtType(0).SetData(txt_ExtTyp1.Text)
            .PregDueDate(0).SetData(txt_PregnancyDate1.Text)

            .EffDate(1).SetData(txt_EffectiveDate2.Text)
            .TermDate(1).SetData(txt_TerminationDate2.Text)
            .AddCode(1).SetData(txt_AddCode2.Text)
            .TRMCode(1).SetData(txt_TrmCode2.Text)
            .PGM(1).SetData(txt_PgmSta2.Text)
            .SUPV(1).SetData(txt_CntySupvn2.Text)
            .RES(1).SetData(txt_CtyRes2.Text)
            .ExtType(1).SetData(txt_ExtTyp2.Text)
            .PregDueDate(1).SetData(txt_PregnancyDate2.Text)

            .EffDate(2).SetData(txt_EffectiveDate3.Text)
            .TermDate(2).SetData(txt_TerminationDate3.Text)
            .AddCode(2).SetData(txt_AddCode3.Text)
            .TRMCode(2).SetData(txt_TrmCode3.Text)
            .PGM(2).SetData(txt_PgmSta3.Text)
            .SUPV(2).SetData(txt_CntySupvn3.Text)
            .RES(2).SetData(txt_CtyRes3.Text)
            .ExtType(2).SetData(txt_ExtTyp3.Text)
            .PregDueDate(2).SetData(txt_PregnancyDate3.Text)

            .EffDate(3).SetData(txt_EffectiveDate4.Text)
            .TermDate(3).SetData(txt_TerminationDate4.Text)
            .AddCode(3).SetData(txt_AddCode4.Text)
            .TRMCode(3).SetData(txt_TrmCode4.Text)
            .PGM(3).SetData(txt_PgmSta4.Text)
            .SUPV(3).SetData(txt_CntySupvn4.Text)
            .RES(3).SetData(txt_CtyRes4.Text)
            .ExtType(3).SetData(txt_ExtTyp4.Text)
            .PregDueDate(3).SetData(txt_PregnancyDate4.Text)

            .EffDate(4).SetData(txt_EffectiveDate5.Text)
            .TermDate(4).SetData(txt_TerminationDate5.Text)
            .AddCode(4).SetData(txt_AddCode5.Text)
            .TRMCode(4).SetData(txt_TrmCode5.Text)
            .PGM(4).SetData(txt_PgmSta5.Text)
            .SUPV(4).SetData(txt_CntySupvn5.Text)
            .RES(4).SetData(txt_CtyRes5.Text)
            .ExtType(4).SetData(txt_ExtTyp5.Text)
            .PregDueDate(4).SetData(txt_PregnancyDate5.Text)

            .EffDate(5).SetData(txt_EffectiveDate6.Text)
            .TermDate(5).SetData(txt_TerminationDate6.Text)
            .AddCode(5).SetData(txt_AddCode6.Text)
            .TRMCode(5).SetData(txt_TrmCode6.Text)
            .PGM(5).SetData(txt_PgmSta6.Text)
            .SUPV(5).SetData(txt_CntySupvn6.Text)
            .RES(5).SetData(txt_CtyRes6.Text)
            .ExtType(5).SetData(txt_ExtTyp6.Text)
            .PregDueDate(5).SetData(txt_PregnancyDate6.Text)
        End With
    End Sub

    Private Sub btn_Continue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Continue.Click
        Choice = "Cont"
        transferPage61()
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
