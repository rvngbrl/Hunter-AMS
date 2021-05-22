<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OnlineForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OnlineForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Closebtn = New Bunifu.Framework.UI.BunifuImageButton()
        Me.BunifuCustomLabel8 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.applicantName = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.AppIDIdentifier = New System.Windows.Forms.Label()
        Me.onlineDGView = New System.Windows.Forms.DataGridView()
        Me.BtnSearch = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuDragControl2 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Closebtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.onlineDGView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BunifuImageButton1)
        Me.Panel1.Controls.Add(Me.Closebtn)
        Me.Panel1.Controls.Add(Me.BunifuCustomLabel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(527, 34)
        Me.Panel1.TabIndex = 3
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
        Me.BunifuImageButton1.Location = New System.Drawing.Point(480, 0)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(30, 31)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 253
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
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
        Me.Closebtn.Location = New System.Drawing.Point(1159, 0)
        Me.Closebtn.Name = "Closebtn"
        Me.Closebtn.Size = New System.Drawing.Size(22, 24)
        Me.Closebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Closebtn.TabIndex = 252
        Me.Closebtn.TabStop = False
        Me.Closebtn.Zoom = 10
        '
        'BunifuCustomLabel8
        '
        Me.BunifuCustomLabel8.AutoSize = True
        Me.BunifuCustomLabel8.BackColor = System.Drawing.Color.Transparent
        Me.BunifuCustomLabel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuCustomLabel8.ForeColor = System.Drawing.Color.White
        Me.BunifuCustomLabel8.Location = New System.Drawing.Point(12, 8)
        Me.BunifuCustomLabel8.Name = "BunifuCustomLabel8"
        Me.BunifuCustomLabel8.Size = New System.Drawing.Size(151, 20)
        Me.BunifuCustomLabel8.TabIndex = 10
        Me.BunifuCustomLabel8.Text = "Applicant Screening"
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
        Me.applicantName.Location = New System.Drawing.Point(14, 74)
        Me.applicantName.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.applicantName.Name = "applicantName"
        Me.applicantName.Size = New System.Drawing.Size(349, 41)
        Me.applicantName.TabIndex = 343
        Me.applicantName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'AppIDIdentifier
        '
        Me.AppIDIdentifier.AutoSize = True
        Me.AppIDIdentifier.BackColor = System.Drawing.Color.Transparent
        Me.AppIDIdentifier.ForeColor = System.Drawing.Color.White
        Me.AppIDIdentifier.Location = New System.Drawing.Point(11, 47)
        Me.AppIDIdentifier.Name = "AppIDIdentifier"
        Me.AppIDIdentifier.Size = New System.Drawing.Size(18, 13)
        Me.AppIDIdentifier.TabIndex = 342
        Me.AppIDIdentifier.Text = "ID"
        '
        'onlineDGView
        '
        Me.onlineDGView.AllowUserToAddRows = False
        Me.onlineDGView.AllowUserToDeleteRows = False
        Me.onlineDGView.AllowUserToOrderColumns = True
        Me.onlineDGView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.onlineDGView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.onlineDGView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.onlineDGView.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.onlineDGView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.onlineDGView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.onlineDGView.DefaultCellStyle = DataGridViewCellStyle3
        Me.onlineDGView.Location = New System.Drawing.Point(18, 142)
        Me.onlineDGView.Name = "onlineDGView"
        Me.onlineDGView.ReadOnly = True
        Me.onlineDGView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.onlineDGView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.onlineDGView.RowHeadersVisible = False
        Me.onlineDGView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.onlineDGView.Size = New System.Drawing.Size(492, 478)
        Me.onlineDGView.TabIndex = 373
        '
        'BtnSearch
        '
        Me.BtnSearch.ActiveBorderThickness = 1
        Me.BtnSearch.ActiveCornerRadius = 20
        Me.BtnSearch.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.BtnSearch.ActiveForecolor = System.Drawing.Color.White
        Me.BtnSearch.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.BtnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtnSearch.BackgroundImage = CType(resources.GetObject("BtnSearch.BackgroundImage"), System.Drawing.Image)
        Me.BtnSearch.ButtonText = "Search"
        Me.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSearch.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearch.ForeColor = System.Drawing.Color.SeaGreen
        Me.BtnSearch.IdleBorderThickness = 1
        Me.BtnSearch.IdleCornerRadius = 20
        Me.BtnSearch.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BtnSearch.IdleForecolor = System.Drawing.Color.SeaShell
        Me.BtnSearch.IdleLineColor = System.Drawing.Color.SeaShell
        Me.BtnSearch.Location = New System.Drawing.Point(373, 74)
        Me.BtnSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(137, 42)
        Me.BtnSearch.TabIndex = 344
        Me.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me
        Me.BunifuDragControl1.Vertical = True
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'BunifuDragControl2
        '
        Me.BunifuDragControl2.Fixed = True
        Me.BunifuDragControl2.Horizontal = True
        Me.BunifuDragControl2.TargetControl = Me.Panel1
        Me.BunifuDragControl2.Vertical = True
        '
        'OnlineForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(527, 644)
        Me.Controls.Add(Me.onlineDGView)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.applicantName)
        Me.Controls.Add(Me.AppIDIdentifier)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "OnlineForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OnlineForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Closebtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.onlineDGView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Closebtn As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BunifuCustomLabel8 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents BtnSearch As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents applicantName As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents AppIDIdentifier As Label
    Friend WithEvents onlineDGView As DataGridView
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuDragControl2 As Bunifu.Framework.UI.BunifuDragControl
End Class
