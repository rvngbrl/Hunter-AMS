<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PoolUpdate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PoolUpdate))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.BunifuDragControl2 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.BunifuImageButton3 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Closebtn = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PoolDateReported = New Bunifu.Framework.UI.BunifuDatepicker()
        Me.PoolDateCallled = New Bunifu.Framework.UI.BunifuDatepicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Availabilitytxt = New Bunifu.Framework.UI.BunifuMetroTextbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RemarksTxtbx = New WindowsFormsControlLibrary1.BunifuCustomTextbox()
        Me.PoolSaveBtn = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PoolNameText = New System.Windows.Forms.Label()
        Me.RepsUser = New System.Windows.Forms.Label()
        Me.AppIDTxt = New System.Windows.Forms.Label()
        Me.ReportedCbox = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.EndorseDGView = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuImageButton2 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Panel1.SuspendLayout()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Closebtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EndorseDGView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Nothing
        Me.BunifuDragControl1.Vertical = True
        '
        'BunifuDragControl2
        '
        Me.BunifuDragControl2.Fixed = True
        Me.BunifuDragControl2.Horizontal = True
        Me.BunifuDragControl2.TargetControl = Nothing
        Me.BunifuDragControl2.Vertical = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BunifuImageButton2)
        Me.Panel1.Controls.Add(Me.BunifuImageButton1)
        Me.Panel1.Controls.Add(Me.BunifuImageButton3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Closebtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(527, 27)
        Me.Panel1.TabIndex = 2
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
        Me.BunifuImageButton1.Location = New System.Drawing.Point(494, 1)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(22, 24)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 260
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
        '
        'BunifuImageButton3
        '
        Me.BunifuImageButton3.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton3.BackgroundImage = CType(resources.GetObject("BunifuImageButton3.BackgroundImage"), System.Drawing.Image)
        Me.BunifuImageButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BunifuImageButton3.Cursor = System.Windows.Forms.Cursors.Default
        Me.BunifuImageButton3.ErrorImage = Nothing
        Me.BunifuImageButton3.Image = CType(resources.GetObject("BunifuImageButton3.Image"), System.Drawing.Image)
        Me.BunifuImageButton3.ImageActive = Nothing
        Me.BunifuImageButton3.InitialImage = Nothing
        Me.BunifuImageButton3.Location = New System.Drawing.Point(1244, 3)
        Me.BunifuImageButton3.Name = "BunifuImageButton3"
        Me.BunifuImageButton3.Size = New System.Drawing.Size(22, 24)
        Me.BunifuImageButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton3.TabIndex = 259
        Me.BunifuImageButton3.TabStop = False
        Me.BunifuImageButton3.Zoom = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "APPLICANT POOLING"
        '
        'Closebtn
        '
        Me.Closebtn.BackColor = System.Drawing.Color.Transparent
        Me.Closebtn.BackgroundImage = CType(resources.GetObject("Closebtn.BackgroundImage"), System.Drawing.Image)
        Me.Closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Closebtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.Closebtn.ErrorImage = Nothing
        Me.Closebtn.Image = CType(resources.GetObject("Closebtn.Image"), System.Drawing.Image)
        Me.Closebtn.ImageActive = Nothing
        Me.Closebtn.InitialImage = Nothing
        Me.Closebtn.Location = New System.Drawing.Point(1272, 3)
        Me.Closebtn.Name = "Closebtn"
        Me.Closebtn.Size = New System.Drawing.Size(22, 24)
        Me.Closebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Closebtn.TabIndex = 258
        Me.Closebtn.TabStop = False
        Me.Closebtn.Zoom = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(5, 325)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(171, 25)
        Me.Label5.TabIndex = 356
        Me.Label5.Text = "Last Date Called"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(4, 379)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(198, 25)
        Me.Label2.TabIndex = 358
        Me.Label2.Text = "Last Date Reported"
        '
        'PoolDateReported
        '
        Me.PoolDateReported.BackColor = System.Drawing.Color.White
        Me.PoolDateReported.BorderRadius = 1
        Me.PoolDateReported.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PoolDateReported.ForeColor = System.Drawing.Color.Black
        Me.PoolDateReported.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.PoolDateReported.FormatCustom = Nothing
        Me.PoolDateReported.Location = New System.Drawing.Point(275, 370)
        Me.PoolDateReported.Name = "PoolDateReported"
        Me.PoolDateReported.Size = New System.Drawing.Size(226, 35)
        Me.PoolDateReported.TabIndex = 357
        Me.PoolDateReported.Value = New Date(2020, 3, 26, 19, 9, 26, 665)
        '
        'PoolDateCallled
        '
        Me.PoolDateCallled.BackColor = System.Drawing.Color.White
        Me.PoolDateCallled.BorderRadius = 1
        Me.PoolDateCallled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PoolDateCallled.ForeColor = System.Drawing.Color.Black
        Me.PoolDateCallled.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.PoolDateCallled.FormatCustom = Nothing
        Me.PoolDateCallled.Location = New System.Drawing.Point(210, 323)
        Me.PoolDateCallled.Name = "PoolDateCallled"
        Me.PoolDateCallled.Size = New System.Drawing.Size(289, 35)
        Me.PoolDateCallled.TabIndex = 359
        Me.PoolDateCallled.Value = New Date(2020, 3, 26, 19, 9, 26, 665)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(5, 433)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 25)
        Me.Label3.TabIndex = 360
        Me.Label3.Text = "Availability"
        '
        'Availabilitytxt
        '
        Me.Availabilitytxt.BackColor = System.Drawing.Color.White
        Me.Availabilitytxt.BorderColorFocused = System.Drawing.Color.Blue
        Me.Availabilitytxt.BorderColorIdle = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Availabilitytxt.BorderColorMouseHover = System.Drawing.Color.Blue
        Me.Availabilitytxt.BorderThickness = 3
        Me.Availabilitytxt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Availabilitytxt.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Availabilitytxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Availabilitytxt.isPassword = False
        Me.Availabilitytxt.Location = New System.Drawing.Point(212, 422)
        Me.Availabilitytxt.Margin = New System.Windows.Forms.Padding(4)
        Me.Availabilitytxt.Name = "Availabilitytxt"
        Me.Availabilitytxt.Size = New System.Drawing.Size(291, 36)
        Me.Availabilitytxt.TabIndex = 361
        Me.Availabilitytxt.Text = "Anytime"
        Me.Availabilitytxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(9, 490)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 25)
        Me.Label4.TabIndex = 362
        Me.Label4.Text = "Remarks"
        '
        'RemarksTxtbx
        '
        Me.RemarksTxtbx.BorderColor = System.Drawing.Color.SeaGreen
        Me.RemarksTxtbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemarksTxtbx.Location = New System.Drawing.Point(112, 475)
        Me.RemarksTxtbx.Multiline = True
        Me.RemarksTxtbx.Name = "RemarksTxtbx"
        Me.RemarksTxtbx.Size = New System.Drawing.Size(391, 63)
        Me.RemarksTxtbx.TabIndex = 363
        '
        'PoolSaveBtn
        '
        Me.PoolSaveBtn.Activecolor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.PoolSaveBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.PoolSaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PoolSaveBtn.BorderRadius = 0
        Me.PoolSaveBtn.ButtonText = "Save"
        Me.PoolSaveBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PoolSaveBtn.DisabledColor = System.Drawing.Color.Gray
        Me.PoolSaveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PoolSaveBtn.Iconcolor = System.Drawing.Color.Transparent
        Me.PoolSaveBtn.Iconimage = Nothing
        Me.PoolSaveBtn.Iconimage_right = Nothing
        Me.PoolSaveBtn.Iconimage_right_Selected = Nothing
        Me.PoolSaveBtn.Iconimage_Selected = Nothing
        Me.PoolSaveBtn.IconMarginLeft = 0
        Me.PoolSaveBtn.IconMarginRight = 0
        Me.PoolSaveBtn.IconRightVisible = True
        Me.PoolSaveBtn.IconRightZoom = 0R
        Me.PoolSaveBtn.IconVisible = True
        Me.PoolSaveBtn.IconZoom = 90.0R
        Me.PoolSaveBtn.IsTab = False
        Me.PoolSaveBtn.Location = New System.Drawing.Point(165, 556)
        Me.PoolSaveBtn.Name = "PoolSaveBtn"
        Me.PoolSaveBtn.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.PoolSaveBtn.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.PoolSaveBtn.OnHoverTextColor = System.Drawing.Color.White
        Me.PoolSaveBtn.selected = False
        Me.PoolSaveBtn.Size = New System.Drawing.Size(186, 45)
        Me.PoolSaveBtn.TabIndex = 364
        Me.PoolSaveBtn.Text = "Save"
        Me.PoolSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.PoolSaveBtn.Textcolor = System.Drawing.Color.White
        Me.PoolSaveBtn.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Location = New System.Drawing.Point(9, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 25)
        Me.Label6.TabIndex = 365
        Me.Label6.Text = "Name"
        '
        'PoolNameText
        '
        Me.PoolNameText.AutoSize = True
        Me.PoolNameText.BackColor = System.Drawing.Color.Transparent
        Me.PoolNameText.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PoolNameText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.PoolNameText.Location = New System.Drawing.Point(220, 43)
        Me.PoolNameText.Name = "PoolNameText"
        Me.PoolNameText.Size = New System.Drawing.Size(272, 25)
        Me.PoolNameText.TabIndex = 366
        Me.PoolNameText.Text = "Arvin Gabriel R. Trinidad"
        '
        'RepsUser
        '
        Me.RepsUser.AutoSize = True
        Me.RepsUser.Location = New System.Drawing.Point(8, 603)
        Me.RepsUser.Name = "RepsUser"
        Me.RepsUser.Size = New System.Drawing.Size(27, 13)
        Me.RepsUser.TabIndex = 367
        Me.RepsUser.Text = "reps"
        '
        'AppIDTxt
        '
        Me.AppIDTxt.AutoSize = True
        Me.AppIDTxt.Location = New System.Drawing.Point(13, 31)
        Me.AppIDTxt.Name = "AppIDTxt"
        Me.AppIDTxt.Size = New System.Drawing.Size(33, 13)
        Me.AppIDTxt.TabIndex = 368
        Me.AppIDTxt.Text = "appid"
        '
        'ReportedCbox
        '
        Me.ReportedCbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ReportedCbox.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ReportedCbox.Checked = True
        Me.ReportedCbox.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ReportedCbox.ForeColor = System.Drawing.Color.White
        Me.ReportedCbox.Location = New System.Drawing.Point(207, 378)
        Me.ReportedCbox.Name = "ReportedCbox"
        Me.ReportedCbox.Size = New System.Drawing.Size(20, 20)
        Me.ReportedCbox.TabIndex = 370
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(234, 379)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 20)
        Me.Label11.TabIndex = 369
        Me.Label11.Text = "N/A"
        '
        'EndorseDGView
        '
        Me.EndorseDGView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.EndorseDGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EndorseDGView.Location = New System.Drawing.Point(9, 104)
        Me.EndorseDGView.Name = "EndorseDGView"
        Me.EndorseDGView.RowHeadersVisible = False
        Me.EndorseDGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EndorseDGView.Size = New System.Drawing.Size(491, 207)
        Me.EndorseDGView.TabIndex = 371
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Location = New System.Drawing.Point(7, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 25)
        Me.Label7.TabIndex = 372
        Me.Label7.Text = "Endorsed History"
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "Print CV"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Enabled = False
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(441, 603)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(186, 45)
        Me.BunifuFlatButton1.TabIndex = 373
        Me.BunifuFlatButton1.Text = "Print CV"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.Visible = False
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
        Me.BunifuImageButton2.Location = New System.Drawing.Point(467, -1)
        Me.BunifuImageButton2.Name = "BunifuImageButton2"
        Me.BunifuImageButton2.Size = New System.Drawing.Size(21, 29)
        Me.BunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton2.TabIndex = 261
        Me.BunifuImageButton2.TabStop = False
        Me.BunifuImageButton2.Zoom = 10
        '
        'PoolUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(527, 627)
        Me.Controls.Add(Me.BunifuFlatButton1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.EndorseDGView)
        Me.Controls.Add(Me.ReportedCbox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.AppIDTxt)
        Me.Controls.Add(Me.RepsUser)
        Me.Controls.Add(Me.PoolNameText)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PoolSaveBtn)
        Me.Controls.Add(Me.RemarksTxtbx)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Availabilitytxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PoolDateCallled)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PoolDateReported)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PoolUpdate"
        Me.Text = "PoolUpdate"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Closebtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EndorseDGView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuDragControl2 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BunifuImageButton3 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Closebtn As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents Label3 As Label
    Friend WithEvents PoolDateCallled As Bunifu.Framework.UI.BunifuDatepicker
    Friend WithEvents Label2 As Label
    Friend WithEvents PoolDateReported As Bunifu.Framework.UI.BunifuDatepicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Availabilitytxt As Bunifu.Framework.UI.BunifuMetroTextbox
    Friend WithEvents RemarksTxtbx As WindowsFormsControlLibrary1.BunifuCustomTextbox
    Friend WithEvents PoolSaveBtn As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PoolNameText As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents RepsUser As Label
    Friend WithEvents AppIDTxt As Label
    Friend WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents ReportedCbox As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents EndorseDGView As DataGridView
    Friend WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BunifuImageButton2 As Bunifu.Framework.UI.BunifuImageButton
End Class
