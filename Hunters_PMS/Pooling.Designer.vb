<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pooling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pooling))
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BunifuImageButton3 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Closebtn = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.AppIDIdentifier = New System.Windows.Forms.Label()
        Me.App_Endorser = New System.Windows.Forms.Label()
        Me.PoolingDGV = New System.Windows.Forms.DataGridView()
        Me.applicantName = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.BtnSearch = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuImageButton2 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Panel1.SuspendLayout()
        CType(Me.BunifuImageButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Closebtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PoolingDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BunifuImageButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuElipse1
        '
        Me.BunifuElipse1.ElipseRadius = 5
        Me.BunifuElipse1.TargetControl = Me
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BunifuImageButton2)
        Me.Panel1.Controls.Add(Me.BunifuImageButton3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Closebtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1308, 27)
        Me.Panel1.TabIndex = 1
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
        Me.BunifuImageButton3.Location = New System.Drawing.Point(1211, 3)
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
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(12, 633)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(461, 25)
        Me.Label30.TabIndex = 251
        Me.Label30.Text = "*Verify all information are correct and accurate." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Panel1
        Me.BunifuDragControl1.Vertical = True
        '
        'AppIDIdentifier
        '
        Me.AppIDIdentifier.AutoSize = True
        Me.AppIDIdentifier.BackColor = System.Drawing.Color.Transparent
        Me.AppIDIdentifier.ForeColor = System.Drawing.Color.White
        Me.AppIDIdentifier.Location = New System.Drawing.Point(14, 41)
        Me.AppIDIdentifier.Name = "AppIDIdentifier"
        Me.AppIDIdentifier.Size = New System.Drawing.Size(18, 13)
        Me.AppIDIdentifier.TabIndex = 258
        Me.AppIDIdentifier.Text = "ID"
        '
        'App_Endorser
        '
        Me.App_Endorser.AutoSize = True
        Me.App_Endorser.BackColor = System.Drawing.Color.Transparent
        Me.App_Endorser.ForeColor = System.Drawing.Color.White
        Me.App_Endorser.Location = New System.Drawing.Point(1232, 624)
        Me.App_Endorser.Name = "App_Endorser"
        Me.App_Endorser.Size = New System.Drawing.Size(53, 13)
        Me.App_Endorser.TabIndex = 259
        Me.App_Endorser.Text = "Called BY"
        '
        'PoolingDGV
        '
        Me.PoolingDGV.AllowUserToAddRows = False
        Me.PoolingDGV.AllowUserToDeleteRows = False
        Me.PoolingDGV.AllowUserToOrderColumns = True
        Me.PoolingDGV.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.PoolingDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.PoolingDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PoolingDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.PoolingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PoolingDGV.DefaultCellStyle = DataGridViewCellStyle3
        Me.PoolingDGV.Location = New System.Drawing.Point(17, 128)
        Me.PoolingDGV.Name = "PoolingDGV"
        Me.PoolingDGV.ReadOnly = True
        Me.PoolingDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PoolingDGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.PoolingDGV.RowHeadersVisible = False
        Me.PoolingDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PoolingDGV.Size = New System.Drawing.Size(1268, 493)
        Me.PoolingDGV.TabIndex = 260
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
        Me.applicantName.Location = New System.Drawing.Point(17, 68)
        Me.applicantName.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.applicantName.Name = "applicantName"
        Me.applicantName.Size = New System.Drawing.Size(614, 41)
        Me.applicantName.TabIndex = 261
        Me.applicantName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
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
        Me.BtnSearch.Location = New System.Drawing.Point(642, 61)
        Me.BtnSearch.Margin = New System.Windows.Forms.Padding(5)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(165, 52)
        Me.BtnSearch.TabIndex = 341
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
        Me.BunifuImageButton2.Location = New System.Drawing.Point(1245, 0)
        Me.BunifuImageButton2.Name = "BunifuImageButton2"
        Me.BunifuImageButton2.Size = New System.Drawing.Size(21, 29)
        Me.BunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton2.TabIndex = 262
        Me.BunifuImageButton2.TabStop = False
        Me.BunifuImageButton2.Zoom = 10
        '
        'Pooling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1308, 670)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.applicantName)
        Me.Controls.Add(Me.PoolingDGV)
        Me.Controls.Add(Me.App_Endorser)
        Me.Controls.Add(Me.AppIDIdentifier)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Pooling"
        Me.Text = "VESSEL"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.BunifuImageButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Closebtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PoolingDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BunifuImageButton2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuImageButton3 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents Closebtn As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents AppIDIdentifier As Label
    Friend WithEvents App_Endorser As Label
    Friend WithEvents PoolingDGV As DataGridView
    Friend WithEvents applicantName As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents BtnSearch As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuImageButton2 As Bunifu.Framework.UI.BunifuImageButton
End Class
