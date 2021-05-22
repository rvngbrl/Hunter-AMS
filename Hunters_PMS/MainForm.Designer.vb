<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UserLabel = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBoxCategory = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AppTotalLabel = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.MainDataGridView = New System.Windows.Forms.DataGridView()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.BunifuDragControl2 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.BunifuDragControl3 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.applicantName = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.AppIDIdentifier = New System.Windows.Forms.Label()
        Me.ToolTip_Total = New System.Windows.Forms.ToolTip(Me.components)
        Me.Endorser = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.AppAssignVessel = New System.Windows.Forms.TextBox()
        Me.AppSources = New System.Windows.Forms.TextBox()
        Me.AppExperience = New System.Windows.Forms.TextBox()
        Me.AppStatus = New System.Windows.Forms.TextBox()
        Me.AppContactNum = New System.Windows.Forms.TextBox()
        Me.AppTRORemarks = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.AppSuffix = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.AppMiddlename = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.AppFirstname = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.AppLastname = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.AppRemarks = New System.Windows.Forms.ComboBox()
        Me.SaveBtn = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.AppAssignPosition = New System.Windows.Forms.ComboBox()
        Me.AppAssignPrincipal = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.RemarksTxtbx = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.AppPreSalary = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.AppPreAgency = New System.Windows.Forms.TextBox()
        Me.AppDateCalled = New System.Windows.Forms.DateTimePicker()
        Me.AppBirthday = New System.Windows.Forms.DateTimePicker()
        Me.AppDateApplied = New System.Windows.Forms.DateTimePicker()
        Me.AppDateEndorsed = New System.Windows.Forms.DateTimePicker()
        Me.BtnSearch = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuImageButton2 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.UserPicture = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AppBtn = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.RepBtn = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.EncBtn = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BunifuFlatButton1)
        Me.Panel1.Controls.Add(Me.UserPicture)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.UserLabel)
        Me.Panel1.Controls.Add(Me.AppBtn)
        Me.Panel1.Controls.Add(Me.RepBtn)
        Me.Panel1.Controls.Add(Me.EncBtn)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(30)
        Me.Panel1.Size = New System.Drawing.Size(208, 643)
        Me.Panel1.TabIndex = 0
        '
        'UserLabel
        '
        Me.UserLabel.Font = New System.Drawing.Font("Nirmala UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserLabel.ForeColor = System.Drawing.Color.White
        Me.UserLabel.Location = New System.Drawing.Point(9, 606)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(192, 21)
        Me.UserLabel.TabIndex = 13
        Me.UserLabel.Text = "Arvin Gabriel Trinidad"
        Me.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(208, 53)
        Me.Panel3.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Nirmala UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(38, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Pool Management"
        '
        'CBoxCategory
        '
        Me.CBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBoxCategory.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CBoxCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.CBoxCategory.FormattingEnabled = True
        Me.CBoxCategory.Items.AddRange(New Object() {"ALL", "APPROVED", "DISAPPROVED", "ENDORSED", "ON PROCESS", "RESERVE", "POOLING"})
        Me.CBoxCategory.Location = New System.Drawing.Point(227, 81)
        Me.CBoxCategory.Name = "CBoxCategory"
        Me.CBoxCategory.Size = New System.Drawing.Size(433, 33)
        Me.CBoxCategory.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(223, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Status"
        '
        'AppTotalLabel
        '
        Me.AppTotalLabel.AutoSize = True
        Me.AppTotalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppTotalLabel.Location = New System.Drawing.Point(423, 609)
        Me.AppTotalLabel.Name = "AppTotalLabel"
        Me.AppTotalLabel.Size = New System.Drawing.Size(51, 24)
        Me.AppTotalLabel.TabIndex = 6
        Me.AppTotalLabel.Text = "Total"
        Me.ToolTip_Total.SetToolTip(Me.AppTotalLabel, "Total count of all applicants")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.BunifuImageButton2)
        Me.Panel2.Controls.Add(Me.BunifuImageButton1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(208, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1057, 53)
        Me.Panel2.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 30)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Dashboard"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'MainDataGridView
        '
        Me.MainDataGridView.AllowUserToAddRows = False
        Me.MainDataGridView.AllowUserToDeleteRows = False
        Me.MainDataGridView.AllowUserToOrderColumns = True
        Me.MainDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.MainDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.MainDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.MainDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MainDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MainDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.MainDataGridView.Location = New System.Drawing.Point(227, 136)
        Me.MainDataGridView.Name = "MainDataGridView"
        Me.MainDataGridView.ReadOnly = True
        Me.MainDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MainDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.MainDataGridView.RowHeadersVisible = False
        Me.MainDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MainDataGridView.Size = New System.Drawing.Size(433, 461)
        Me.MainDataGridView.TabIndex = 9
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 7
        Me.BunifuElipse1.TargetControl = Me
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me
        Me.BunifuDragControl1.Vertical = True
        '
        'BunifuDragControl2
        '
        Me.BunifuDragControl2.Fixed = True
        Me.BunifuDragControl2.Horizontal = True
        Me.BunifuDragControl2.TargetControl = Me.Panel2
        Me.BunifuDragControl2.Vertical = True
        '
        'BunifuDragControl3
        '
        Me.BunifuDragControl3.Fixed = True
        Me.BunifuDragControl3.Horizontal = True
        Me.BunifuDragControl3.TargetControl = Me.Panel3
        Me.BunifuDragControl3.Vertical = True
        '
        'applicantName
        '
        Me.applicantName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.applicantName.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.applicantName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.applicantName.HintForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.applicantName.HintText = "Enter Name"
        Me.applicantName.isPassword = False
        Me.applicantName.LineFocusedColor = System.Drawing.Color.Blue
        Me.applicantName.LineIdleColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.applicantName.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.applicantName.LineThickness = 4
        Me.applicantName.Location = New System.Drawing.Point(693, 74)
        Me.applicantName.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.applicantName.Name = "applicantName"
        Me.applicantName.Size = New System.Drawing.Size(364, 41)
        Me.applicantName.TabIndex = 10
        Me.applicantName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'AppIDIdentifier
        '
        Me.AppIDIdentifier.AutoSize = True
        Me.AppIDIdentifier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppIDIdentifier.Location = New System.Drawing.Point(680, 139)
        Me.AppIDIdentifier.Name = "AppIDIdentifier"
        Me.AppIDIdentifier.Size = New System.Drawing.Size(39, 13)
        Me.AppIDIdentifier.TabIndex = 2
        Me.AppIDIdentifier.Text = "Label1"
        '
        'Endorser
        '
        Me.Endorser.AutoSize = True
        Me.Endorser.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Endorser.Location = New System.Drawing.Point(753, 538)
        Me.Endorser.Name = "Endorser"
        Me.Endorser.Size = New System.Drawing.Size(48, 18)
        Me.Endorser.TabIndex = 360
        Me.Endorser.Text = "Melba"
        Me.ToolTip_Total.SetToolTip(Me.Endorser, "Total count of all applicants")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(679, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Assigned Vessel:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(679, 281)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Assigned Position:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(679, 347)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Date Applied:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(679, 376)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Sources:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(679, 252)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(142, 20)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Assigned Principal:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(679, 406)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 20)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Experience:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(679, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 20)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Status:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(679, 436)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 20)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Birthday:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1003, 436)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 20)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Contact No:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(679, 473)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 20)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Date Called:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1005, 469)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 20)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Pre Status:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(679, 315)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 20)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Date Endorsed:"
        '
        'AppAssignVessel
        '
        Me.AppAssignVessel.Enabled = False
        Me.AppAssignVessel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppAssignVessel.Location = New System.Drawing.Point(823, 225)
        Me.AppAssignVessel.Name = "AppAssignVessel"
        Me.AppAssignVessel.Size = New System.Drawing.Size(425, 22)
        Me.AppAssignVessel.TabIndex = 35
        '
        'AppSources
        '
        Me.AppSources.Enabled = False
        Me.AppSources.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppSources.Location = New System.Drawing.Point(823, 376)
        Me.AppSources.Name = "AppSources"
        Me.AppSources.Size = New System.Drawing.Size(425, 22)
        Me.AppSources.TabIndex = 40
        '
        'AppExperience
        '
        Me.AppExperience.Enabled = False
        Me.AppExperience.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppExperience.Location = New System.Drawing.Point(823, 406)
        Me.AppExperience.Name = "AppExperience"
        Me.AppExperience.Size = New System.Drawing.Size(425, 22)
        Me.AppExperience.TabIndex = 41
        '
        'AppStatus
        '
        Me.AppStatus.Enabled = False
        Me.AppStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppStatus.Location = New System.Drawing.Point(823, 197)
        Me.AppStatus.Name = "AppStatus"
        Me.AppStatus.Size = New System.Drawing.Size(234, 22)
        Me.AppStatus.TabIndex = 42
        '
        'AppContactNum
        '
        Me.AppContactNum.Enabled = False
        Me.AppContactNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppContactNum.Location = New System.Drawing.Point(1106, 434)
        Me.AppContactNum.Name = "AppContactNum"
        Me.AppContactNum.Size = New System.Drawing.Size(142, 22)
        Me.AppContactNum.TabIndex = 44
        '
        'AppTRORemarks
        '
        Me.AppTRORemarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AppTRORemarks.Enabled = False
        Me.AppTRORemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.AppTRORemarks.FormattingEnabled = True
        Me.AppTRORemarks.Items.AddRange(New Object() {"Pre Qualified", "Not Qualified"})
        Me.AppTRORemarks.Location = New System.Drawing.Point(823, 164)
        Me.AppTRORemarks.Name = "AppTRORemarks"
        Me.AppTRORemarks.Size = New System.Drawing.Size(234, 24)
        Me.AppTRORemarks.TabIndex = 51
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(679, 166)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(114, 20)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "TRO Remarks:"
        '
        'AppSuffix
        '
        Me.AppSuffix.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AppSuffix.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.AppSuffix.ForeColor = System.Drawing.Color.Black
        Me.AppSuffix.HintForeColor = System.Drawing.Color.Black
        Me.AppSuffix.HintText = "Suffix"
        Me.AppSuffix.isPassword = False
        Me.AppSuffix.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppSuffix.LineIdleColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.AppSuffix.LineMouseHoverColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppSuffix.LineThickness = 3
        Me.AppSuffix.Location = New System.Drawing.Point(1188, 124)
        Me.AppSuffix.Margin = New System.Windows.Forms.Padding(4)
        Me.AppSuffix.Name = "AppSuffix"
        Me.AppSuffix.Size = New System.Drawing.Size(48, 33)
        Me.AppSuffix.TabIndex = 298
        Me.AppSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'AppMiddlename
        '
        Me.AppMiddlename.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AppMiddlename.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.AppMiddlename.ForeColor = System.Drawing.Color.Black
        Me.AppMiddlename.HintForeColor = System.Drawing.Color.Black
        Me.AppMiddlename.HintText = "Middle Name"
        Me.AppMiddlename.isPassword = False
        Me.AppMiddlename.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppMiddlename.LineIdleColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.AppMiddlename.LineMouseHoverColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppMiddlename.LineThickness = 3
        Me.AppMiddlename.Location = New System.Drawing.Point(1033, 124)
        Me.AppMiddlename.Margin = New System.Windows.Forms.Padding(4)
        Me.AppMiddlename.Name = "AppMiddlename"
        Me.AppMiddlename.Size = New System.Drawing.Size(150, 33)
        Me.AppMiddlename.TabIndex = 297
        Me.AppMiddlename.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'AppFirstname
        '
        Me.AppFirstname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AppFirstname.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.AppFirstname.ForeColor = System.Drawing.Color.Black
        Me.AppFirstname.HintForeColor = System.Drawing.Color.Black
        Me.AppFirstname.HintText = "First Name"
        Me.AppFirstname.isPassword = False
        Me.AppFirstname.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppFirstname.LineIdleColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.AppFirstname.LineMouseHoverColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppFirstname.LineThickness = 3
        Me.AppFirstname.Location = New System.Drawing.Point(880, 124)
        Me.AppFirstname.Margin = New System.Windows.Forms.Padding(4)
        Me.AppFirstname.Name = "AppFirstname"
        Me.AppFirstname.Size = New System.Drawing.Size(150, 33)
        Me.AppFirstname.TabIndex = 296
        Me.AppFirstname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'AppLastname
        '
        Me.AppLastname.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.AppLastname.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.AppLastname.ForeColor = System.Drawing.Color.Black
        Me.AppLastname.HintForeColor = System.Drawing.Color.Black
        Me.AppLastname.HintText = "Last Name"
        Me.AppLastname.isPassword = False
        Me.AppLastname.LineFocusedColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppLastname.LineIdleColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.AppLastname.LineMouseHoverColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppLastname.LineThickness = 3
        Me.AppLastname.Location = New System.Drawing.Point(726, 124)
        Me.AppLastname.Margin = New System.Windows.Forms.Padding(4)
        Me.AppLastname.Name = "AppLastname"
        Me.AppLastname.Size = New System.Drawing.Size(150, 33)
        Me.AppLastname.TabIndex = 295
        Me.AppLastname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'AppRemarks
        '
        Me.AppRemarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AppRemarks.Enabled = False
        Me.AppRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.AppRemarks.FormattingEnabled = True
        Me.AppRemarks.Items.AddRange(New Object() {"ON PROCESS", "RESERVE", "POOLING"})
        Me.AppRemarks.Location = New System.Drawing.Point(1106, 468)
        Me.AppRemarks.Name = "AppRemarks"
        Me.AppRemarks.Size = New System.Drawing.Size(141, 24)
        Me.AppRemarks.TabIndex = 343
        '
        'SaveBtn
        '
        Me.SaveBtn.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.SaveBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SaveBtn.BorderRadius = 0
        Me.SaveBtn.ButtonText = "Save"
        Me.SaveBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SaveBtn.DisabledColor = System.Drawing.Color.Gray
        Me.SaveBtn.Enabled = False
        Me.SaveBtn.Iconcolor = System.Drawing.Color.Transparent
        Me.SaveBtn.Iconimage = Nothing
        Me.SaveBtn.Iconimage_right = Nothing
        Me.SaveBtn.Iconimage_right_Selected = Nothing
        Me.SaveBtn.Iconimage_Selected = Nothing
        Me.SaveBtn.IconMarginLeft = 0
        Me.SaveBtn.IconMarginRight = 0
        Me.SaveBtn.IconRightVisible = True
        Me.SaveBtn.IconRightZoom = 0R
        Me.SaveBtn.IconVisible = True
        Me.SaveBtn.IconZoom = 90.0R
        Me.SaveBtn.IsTab = False
        Me.SaveBtn.Location = New System.Drawing.Point(1070, 164)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.SaveBtn.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.SaveBtn.OnHoverTextColor = System.Drawing.Color.White
        Me.SaveBtn.selected = False
        Me.SaveBtn.Size = New System.Drawing.Size(85, 55)
        Me.SaveBtn.TabIndex = 344
        Me.SaveBtn.Text = "Save"
        Me.SaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SaveBtn.Textcolor = System.Drawing.Color.White
        Me.SaveBtn.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 0
        Me.BunifuFlatButton3.ButtonText = "Edit Information"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.Iconimage = Nothing
        Me.BunifuFlatButton3.Iconimage_right = Nothing
        Me.BunifuFlatButton3.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton3.Iconimage_Selected = Nothing
        Me.BunifuFlatButton3.IconMarginLeft = 0
        Me.BunifuFlatButton3.IconMarginRight = 0
        Me.BunifuFlatButton3.IconRightVisible = True
        Me.BunifuFlatButton3.IconRightZoom = 0R
        Me.BunifuFlatButton3.IconVisible = True
        Me.BunifuFlatButton3.IconZoom = 90.0R
        Me.BunifuFlatButton3.IsTab = False
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(1163, 164)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(85, 55)
        Me.BunifuFlatButton3.TabIndex = 345
        Me.BunifuFlatButton3.Text = "Edit Information"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton3.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'AppAssignPosition
        '
        Me.AppAssignPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AppAssignPosition.Enabled = False
        Me.AppAssignPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.AppAssignPosition.FormattingEnabled = True
        Me.AppAssignPosition.Location = New System.Drawing.Point(823, 280)
        Me.AppAssignPosition.Name = "AppAssignPosition"
        Me.AppAssignPosition.Size = New System.Drawing.Size(424, 24)
        Me.AppAssignPosition.TabIndex = 346
        '
        'AppAssignPrincipal
        '
        Me.AppAssignPrincipal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AppAssignPrincipal.Enabled = False
        Me.AppAssignPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.AppAssignPrincipal.FormattingEnabled = True
        Me.AppAssignPrincipal.Location = New System.Drawing.Point(823, 252)
        Me.AppAssignPrincipal.Name = "AppAssignPrincipal"
        Me.AppAssignPrincipal.Size = New System.Drawing.Size(424, 24)
        Me.AppAssignPrincipal.TabIndex = 347
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(679, 537)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 20)
        Me.Label16.TabIndex = 350
        Me.Label16.Text = "Remarks:"
        '
        'RemarksTxtbx
        '
        Me.RemarksTxtbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemarksTxtbx.Location = New System.Drawing.Point(683, 567)
        Me.RemarksTxtbx.Multiline = True
        Me.RemarksTxtbx.Name = "RemarksTxtbx"
        Me.RemarksTxtbx.Size = New System.Drawing.Size(564, 58)
        Me.RemarksTxtbx.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(679, 507)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 20)
        Me.Label17.TabIndex = 351
        Me.Label17.Text = "Last Agency"
        '
        'AppPreSalary
        '
        Me.AppPreSalary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppPreSalary.Location = New System.Drawing.Point(1106, 505)
        Me.AppPreSalary.Name = "AppPreSalary"
        Me.AppPreSalary.Size = New System.Drawing.Size(143, 22)
        Me.AppPreSalary.TabIndex = 354
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(1005, 506)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 20)
        Me.Label18.TabIndex = 353
        Me.Label18.Text = "Last Salary"
        '
        'AppPreAgency
        '
        Me.AppPreAgency.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppPreAgency.Location = New System.Drawing.Point(823, 506)
        Me.AppPreAgency.Name = "AppPreAgency"
        Me.AppPreAgency.Size = New System.Drawing.Size(176, 22)
        Me.AppPreAgency.TabIndex = 355
        '
        'AppDateCalled
        '
        Me.AppDateCalled.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppDateCalled.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.AppDateCalled.Location = New System.Drawing.Point(823, 473)
        Me.AppDateCalled.Name = "AppDateCalled"
        Me.AppDateCalled.Size = New System.Drawing.Size(176, 22)
        Me.AppDateCalled.TabIndex = 356
        '
        'AppBirthday
        '
        Me.AppBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppBirthday.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.AppBirthday.Location = New System.Drawing.Point(821, 436)
        Me.AppBirthday.Name = "AppBirthday"
        Me.AppBirthday.Size = New System.Drawing.Size(176, 22)
        Me.AppBirthday.TabIndex = 357
        '
        'AppDateApplied
        '
        Me.AppDateApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppDateApplied.Location = New System.Drawing.Point(823, 348)
        Me.AppDateApplied.Name = "AppDateApplied"
        Me.AppDateApplied.Size = New System.Drawing.Size(426, 22)
        Me.AppDateApplied.TabIndex = 358
        '
        'AppDateEndorsed
        '
        Me.AppDateEndorsed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppDateEndorsed.Location = New System.Drawing.Point(821, 315)
        Me.AppDateEndorsed.Name = "AppDateEndorsed"
        Me.AppDateEndorsed.Size = New System.Drawing.Size(426, 22)
        Me.AppDateEndorsed.TabIndex = 359
        '
        'BtnSearch
        '
        Me.BtnSearch.ActiveBorderThickness = 1
        Me.BtnSearch.ActiveCornerRadius = 20
        Me.BtnSearch.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.BtnSearch.ActiveForecolor = System.Drawing.Color.White
        Me.BtnSearch.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.BtnSearch.BackColor = System.Drawing.Color.White
        Me.BtnSearch.BackgroundImage = CType(resources.GetObject("BtnSearch.BackgroundImage"), System.Drawing.Image)
        Me.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSearch.ButtonText = "Search"
        Me.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSearch.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.BtnSearch.ForeColor = System.Drawing.Color.SeaGreen
        Me.BtnSearch.IdleBorderThickness = 1
        Me.BtnSearch.IdleCornerRadius = 20
        Me.BtnSearch.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BtnSearch.IdleForecolor = System.Drawing.Color.SeaShell
        Me.BtnSearch.IdleLineColor = System.Drawing.Color.SeaShell
        Me.BtnSearch.Location = New System.Drawing.Point(1066, 74)
        Me.BtnSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(177, 46)
        Me.BtnSearch.TabIndex = 11
        Me.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuImageButton2
        '
        Me.BunifuImageButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Default
        Me.BunifuImageButton2.ErrorImage = Nothing
        Me.BunifuImageButton2.Image = CType(resources.GetObject("BunifuImageButton2.Image"), System.Drawing.Image)
        Me.BunifuImageButton2.ImageActive = Nothing
        Me.BunifuImageButton2.InitialImage = Nothing
        Me.BunifuImageButton2.Location = New System.Drawing.Point(980, 11)
        Me.BunifuImageButton2.Name = "BunifuImageButton2"
        Me.BunifuImageButton2.Size = New System.Drawing.Size(31, 30)
        Me.BunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton2.TabIndex = 2
        Me.BunifuImageButton2.TabStop = False
        Me.BunifuImageButton2.Zoom = 10
        '
        'BunifuImageButton1
        '
        Me.BunifuImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton1.BackgroundImage = CType(resources.GetObject("BunifuImageButton1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuImageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Default
        Me.BunifuImageButton1.ErrorImage = Nothing
        Me.BunifuImageButton1.Image = CType(resources.GetObject("BunifuImageButton1.Image"), System.Drawing.Image)
        Me.BunifuImageButton1.ImageActive = Nothing
        Me.BunifuImageButton1.InitialImage = Nothing
        Me.BunifuImageButton1.Location = New System.Drawing.Point(1018, 11)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(31, 30)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 1
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "Pre Qualification"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = CType(resources.GetObject("BunifuFlatButton1.Iconimage"), System.Drawing.Image)
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 50.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(0, 54)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(208, 48)
        Me.BunifuFlatButton1.TabIndex = 16
        Me.BunifuFlatButton1.Text = "Pre Qualification"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.LightGray
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'UserPicture
        '
        Me.UserPicture.BackColor = System.Drawing.Color.Transparent
        Me.UserPicture.Location = New System.Drawing.Point(55, 495)
        Me.UserPicture.Name = "UserPicture"
        Me.UserPicture.Size = New System.Drawing.Size(102, 98)
        Me.UserPicture.TabIndex = 15
        Me.UserPicture.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(377, 424)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(110, 105)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'AppBtn
        '
        Me.AppBtn.Activecolor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.AppBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.AppBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AppBtn.BorderRadius = 0
        Me.AppBtn.ButtonText = "Online Application"
        Me.AppBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AppBtn.DisabledColor = System.Drawing.Color.Gray
        Me.AppBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppBtn.Iconcolor = System.Drawing.Color.Transparent
        Me.AppBtn.Iconimage = Global.Hunters_PMS.My.Resources.Resources.pooling1
        Me.AppBtn.Iconimage_right = Nothing
        Me.AppBtn.Iconimage_right_Selected = Nothing
        Me.AppBtn.Iconimage_Selected = Nothing
        Me.AppBtn.IconMarginLeft = 0
        Me.AppBtn.IconMarginRight = 0
        Me.AppBtn.IconRightVisible = True
        Me.AppBtn.IconRightZoom = 0R
        Me.AppBtn.IconVisible = True
        Me.AppBtn.IconZoom = 75.0R
        Me.AppBtn.IsTab = False
        Me.AppBtn.Location = New System.Drawing.Point(0, 149)
        Me.AppBtn.Margin = New System.Windows.Forms.Padding(5)
        Me.AppBtn.Name = "AppBtn"
        Me.AppBtn.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.AppBtn.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppBtn.OnHoverTextColor = System.Drawing.Color.White
        Me.AppBtn.selected = False
        Me.AppBtn.Size = New System.Drawing.Size(208, 48)
        Me.AppBtn.TabIndex = 12
        Me.AppBtn.Text = "Online Application"
        Me.AppBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AppBtn.Textcolor = System.Drawing.Color.LightGray
        Me.AppBtn.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'RepBtn
        '
        Me.RepBtn.Activecolor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.RepBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.RepBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RepBtn.BorderRadius = 0
        Me.RepBtn.ButtonText = "Pooling"
        Me.RepBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RepBtn.DisabledColor = System.Drawing.Color.Gray
        Me.RepBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RepBtn.Iconcolor = System.Drawing.Color.Transparent
        Me.RepBtn.Iconimage = Global.Hunters_PMS.My.Resources.Resources.web_online_01
        Me.RepBtn.Iconimage_right = Nothing
        Me.RepBtn.Iconimage_right_Selected = Nothing
        Me.RepBtn.Iconimage_Selected = Nothing
        Me.RepBtn.IconMarginLeft = 0
        Me.RepBtn.IconMarginRight = 0
        Me.RepBtn.IconRightVisible = True
        Me.RepBtn.IconRightZoom = 0R
        Me.RepBtn.IconVisible = True
        Me.RepBtn.IconZoom = 75.0R
        Me.RepBtn.IsTab = False
        Me.RepBtn.Location = New System.Drawing.Point(0, 100)
        Me.RepBtn.Margin = New System.Windows.Forms.Padding(5)
        Me.RepBtn.Name = "RepBtn"
        Me.RepBtn.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.RepBtn.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.RepBtn.OnHoverTextColor = System.Drawing.Color.White
        Me.RepBtn.selected = False
        Me.RepBtn.Size = New System.Drawing.Size(208, 48)
        Me.RepBtn.TabIndex = 11
        Me.RepBtn.Text = "Pooling"
        Me.RepBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RepBtn.Textcolor = System.Drawing.Color.LightGray
        Me.RepBtn.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'EncBtn
        '
        Me.EncBtn.Activecolor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.EncBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.EncBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.EncBtn.BorderRadius = 0
        Me.EncBtn.ButtonText = "          Encoding"
        Me.EncBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EncBtn.DisabledColor = System.Drawing.Color.Gray
        Me.EncBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EncBtn.Iconcolor = System.Drawing.Color.Transparent
        Me.EncBtn.Iconimage = CType(resources.GetObject("EncBtn.Iconimage"), System.Drawing.Image)
        Me.EncBtn.Iconimage_right = Nothing
        Me.EncBtn.Iconimage_right_Selected = Nothing
        Me.EncBtn.Iconimage_Selected = Nothing
        Me.EncBtn.IconMarginLeft = 0
        Me.EncBtn.IconMarginRight = 0
        Me.EncBtn.IconRightVisible = True
        Me.EncBtn.IconRightZoom = 0R
        Me.EncBtn.IconVisible = True
        Me.EncBtn.IconZoom = 90.0R
        Me.EncBtn.IsTab = False
        Me.EncBtn.Location = New System.Drawing.Point(0, 262)
        Me.EncBtn.Margin = New System.Windows.Forms.Padding(5)
        Me.EncBtn.Name = "EncBtn"
        Me.EncBtn.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.EncBtn.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.EncBtn.OnHoverTextColor = System.Drawing.Color.White
        Me.EncBtn.selected = False
        Me.EncBtn.Size = New System.Drawing.Size(208, 48)
        Me.EncBtn.TabIndex = 9
        Me.EncBtn.Text = "          Encoding"
        Me.EncBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EncBtn.Textcolor = System.Drawing.Color.LightGray
        Me.EncBtn.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EncBtn.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1265, 643)
        Me.Controls.Add(Me.Endorser)
        Me.Controls.Add(Me.AppDateEndorsed)
        Me.Controls.Add(Me.AppDateApplied)
        Me.Controls.Add(Me.AppBirthday)
        Me.Controls.Add(Me.AppDateCalled)
        Me.Controls.Add(Me.AppPreAgency)
        Me.Controls.Add(Me.AppPreSalary)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.RemarksTxtbx)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.AppAssignPrincipal)
        Me.Controls.Add(Me.AppAssignPosition)
        Me.Controls.Add(Me.BunifuFlatButton3)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.AppRemarks)
        Me.Controls.Add(Me.AppSuffix)
        Me.Controls.Add(Me.AppMiddlename)
        Me.Controls.Add(Me.AppFirstname)
        Me.Controls.Add(Me.AppLastname)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.AppTRORemarks)
        Me.Controls.Add(Me.AppContactNum)
        Me.Controls.Add(Me.AppStatus)
        Me.Controls.Add(Me.AppExperience)
        Me.Controls.Add(Me.AppSources)
        Me.Controls.Add(Me.AppAssignVessel)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.AppIDIdentifier)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.applicantName)
        Me.Controls.Add(Me.MainDataGridView)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.AppTotalLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBoxCategory)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserPicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents CBoxCategory As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents AppTotalLabel As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents MainDataGridView As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents AppBtn As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents RepBtn As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents EncBtn As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuDragControl2 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuDragControl3 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents applicantName As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents BtnSearch As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents UserLabel As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents UserPicture As PictureBox
    Friend WithEvents AppIDIdentifier As Label
    Friend WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents ToolTip_Total As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents AppContactNum As TextBox
    Friend WithEvents AppStatus As TextBox
    Friend WithEvents AppExperience As TextBox
    Friend WithEvents AppSources As TextBox
    Friend WithEvents AppAssignVessel As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents AppTRORemarks As ComboBox
    Friend WithEvents AppSuffix As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents AppMiddlename As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents AppFirstname As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents AppLastname As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents AppRemarks As ComboBox
    Friend WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents SaveBtn As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents AppAssignPosition As ComboBox
    Friend WithEvents AppAssignPrincipal As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents RemarksTxtbx As TextBox
    Friend WithEvents BunifuImageButton2 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents AppPreSalary As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents AppPreAgency As TextBox
    Friend WithEvents AppBirthday As DateTimePicker
    Friend WithEvents AppDateCalled As DateTimePicker
    Friend WithEvents AppDateApplied As DateTimePicker
    Friend WithEvents AppDateEndorsed As DateTimePicker
    Friend WithEvents Endorser As Label
End Class
