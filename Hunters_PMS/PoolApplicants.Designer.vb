<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PoolApplicants
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PoolApplicants))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.BunifuDragControl2 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.ApplicantDataGridView = New System.Windows.Forms.DataGridView()
        Me.applicantName = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.AppSearchBtn = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AppIDIdentifier = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ApplicantDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.BunifuImageButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(788, 25)
        Me.Panel1.TabIndex = 16
        '
        'BunifuImageButton1
        '
        Me.BunifuImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton1.BackgroundImage = CType(resources.GetObject("BunifuImageButton1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuImageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BunifuImageButton1.ErrorImage = Nothing
        Me.BunifuImageButton1.ImageActive = Nothing
        Me.BunifuImageButton1.InitialImage = Nothing
        Me.BunifuImageButton1.Location = New System.Drawing.Point(746, 1)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(22, 22)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 16
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
        '
        'ApplicantDataGridView
        '
        Me.ApplicantDataGridView.AllowUserToAddRows = False
        Me.ApplicantDataGridView.AllowUserToDeleteRows = False
        Me.ApplicantDataGridView.AllowUserToOrderColumns = True
        Me.ApplicantDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.ApplicantDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.ApplicantDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ApplicantDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApplicantDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ApplicantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ApplicantDataGridView.DefaultCellStyle = DataGridViewCellStyle3
        Me.ApplicantDataGridView.Location = New System.Drawing.Point(22, 115)
        Me.ApplicantDataGridView.Name = "ApplicantDataGridView"
        Me.ApplicantDataGridView.ReadOnly = True
        Me.ApplicantDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApplicantDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ApplicantDataGridView.RowHeadersVisible = False
        Me.ApplicantDataGridView.RowHeadersWidth = 80
        Me.ApplicantDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ApplicantDataGridView.Size = New System.Drawing.Size(746, 511)
        Me.ApplicantDataGridView.TabIndex = 17
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
        Me.applicantName.Location = New System.Drawing.Point(22, 51)
        Me.applicantName.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.applicantName.Name = "applicantName"
        Me.applicantName.Size = New System.Drawing.Size(529, 41)
        Me.applicantName.TabIndex = 18
        Me.applicantName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'AppSearchBtn
        '
        Me.AppSearchBtn.ActiveBorderThickness = 1
        Me.AppSearchBtn.ActiveCornerRadius = 20
        Me.AppSearchBtn.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.AppSearchBtn.ActiveForecolor = System.Drawing.Color.White
        Me.AppSearchBtn.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.AppSearchBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.AppSearchBtn.BackgroundImage = CType(resources.GetObject("AppSearchBtn.BackgroundImage"), System.Drawing.Image)
        Me.AppSearchBtn.ButtonText = "Search"
        Me.AppSearchBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AppSearchBtn.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppSearchBtn.ForeColor = System.Drawing.Color.SeaGreen
        Me.AppSearchBtn.IdleBorderThickness = 1
        Me.AppSearchBtn.IdleCornerRadius = 20
        Me.AppSearchBtn.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.AppSearchBtn.IdleForecolor = System.Drawing.Color.SeaShell
        Me.AppSearchBtn.IdleLineColor = System.Drawing.Color.SeaShell
        Me.AppSearchBtn.Location = New System.Drawing.Point(591, 52)
        Me.AppSearchBtn.Margin = New System.Windows.Forms.Padding(5)
        Me.AppSearchBtn.Name = "AppSearchBtn"
        Me.AppSearchBtn.Size = New System.Drawing.Size(177, 46)
        Me.AppSearchBtn.TabIndex = 341
        Me.AppSearchBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 640)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(386, 24)
        Me.Label1.TabIndex = 342
        Me.Label1.Text = "DOUBLE CLICK your name to fill up form"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(17, 674)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(611, 24)
        Me.Label2.TabIndex = 343
        Me.Label2.Text = "If your name is not on the list go to recruitment look for Melba or Checket"
        '
        'AppIDIdentifier
        '
        Me.AppIDIdentifier.AutoSize = True
        Me.AppIDIdentifier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppIDIdentifier.Location = New System.Drawing.Point(24, 98)
        Me.AppIDIdentifier.Name = "AppIDIdentifier"
        Me.AppIDIdentifier.Size = New System.Drawing.Size(39, 13)
        Me.AppIDIdentifier.TabIndex = 344
        Me.AppIDIdentifier.Text = "Label1"
        '
        'PoolApplicants
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(788, 707)
        Me.Controls.Add(Me.AppIDIdentifier)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AppSearchBtn)
        Me.Controls.Add(Me.applicantName)
        Me.Controls.Add(Me.ApplicantDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PoolApplicants"
        Me.Text = "PoolApplicants"
        Me.Panel1.ResumeLayout(False)
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ApplicantDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuDragControl2 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents ApplicantDataGridView As DataGridView
    Friend WithEvents applicantName As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents AppSearchBtn As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents AppIDIdentifier As Label
End Class
