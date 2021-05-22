<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login_Form))
        Me.ApplicantsDGV = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.UsernameBox = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.PasswordBox = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.BunifuDragControl2 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.LoginbBtn = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.AppLinkBtn = New System.Windows.Forms.LinkLabel()
        Me.ConctionBtn = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.ApplicantsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ApplicantsDGV
        '
        Me.ApplicantsDGV.AllowUserToAddRows = False
        Me.ApplicantsDGV.AllowUserToDeleteRows = False
        Me.ApplicantsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ApplicantsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ApplicantsDGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.ApplicantsDGV.Location = New System.Drawing.Point(30, 115)
        Me.ApplicantsDGV.Name = "ApplicantsDGV"
        Me.ApplicantsDGV.ReadOnly = True
        Me.ApplicantsDGV.RowHeadersVisible = False
        Me.ApplicantsDGV.Size = New System.Drawing.Size(337, 348)
        Me.ApplicantsDGV.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(113, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 33)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Applicants"
        '
        'UsernameBox
        '
        Me.UsernameBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.UsernameBox.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UsernameBox.HintForeColor = System.Drawing.Color.Empty
        Me.UsernameBox.HintText = "Type Your Username"
        Me.UsernameBox.isPassword = False
        Me.UsernameBox.LineFocusedColor = System.Drawing.Color.Blue
        Me.UsernameBox.LineIdleColor = System.Drawing.Color.Gray
        Me.UsernameBox.LineMouseHoverColor = System.Drawing.Color.Empty
        Me.UsernameBox.LineThickness = 4
        Me.UsernameBox.Location = New System.Drawing.Point(412, 208)
        Me.UsernameBox.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.UsernameBox.Name = "UsernameBox"
        Me.UsernameBox.Size = New System.Drawing.Size(362, 41)
        Me.UsernameBox.TabIndex = 8
        Me.UsernameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'PasswordBox
        '
        Me.PasswordBox.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.PasswordBox.Font = New System.Drawing.Font("Century Gothic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PasswordBox.HintForeColor = System.Drawing.Color.Empty
        Me.PasswordBox.HintText = ""
        Me.PasswordBox.isPassword = True
        Me.PasswordBox.LineFocusedColor = System.Drawing.Color.Blue
        Me.PasswordBox.LineIdleColor = System.Drawing.Color.Gray
        Me.PasswordBox.LineMouseHoverColor = System.Drawing.Color.Empty
        Me.PasswordBox.LineThickness = 4
        Me.PasswordBox.Location = New System.Drawing.Point(412, 298)
        Me.PasswordBox.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.PasswordBox.Name = "PasswordBox"
        Me.PasswordBox.Size = New System.Drawing.Size(362, 41)
        Me.PasswordBox.TabIndex = 9
        Me.PasswordBox.Text = "flash"
        Me.PasswordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Eras Light ITC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 25)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "list of people apply today"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Eras Light ITC", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(129, 466)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 25)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Total:"
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
        Me.BunifuDragControl2.TargetControl = Me.LoginbBtn
        Me.BunifuDragControl2.Vertical = True
        '
        'LoginbBtn
        '
        Me.LoginbBtn.ActiveBorderThickness = 1
        Me.LoginbBtn.ActiveCornerRadius = 20
        Me.LoginbBtn.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LoginbBtn.ActiveForecolor = System.Drawing.Color.White
        Me.LoginbBtn.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.LoginbBtn.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LoginbBtn.BackgroundImage = CType(resources.GetObject("LoginbBtn.BackgroundImage"), System.Drawing.Image)
        Me.LoginbBtn.ButtonText = "LOGIN"
        Me.LoginbBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoginbBtn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginbBtn.ForeColor = System.Drawing.Color.Black
        Me.LoginbBtn.IdleBorderThickness = 1
        Me.LoginbBtn.IdleCornerRadius = 20
        Me.LoginbBtn.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LoginbBtn.IdleForecolor = System.Drawing.Color.White
        Me.LoginbBtn.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.LoginbBtn.Location = New System.Drawing.Point(412, 361)
        Me.LoginbBtn.Margin = New System.Windows.Forms.Padding(5)
        Me.LoginbBtn.Name = "LoginbBtn"
        Me.LoginbBtn.Size = New System.Drawing.Size(362, 51)
        Me.LoginbBtn.TabIndex = 10
        Me.LoginbBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Panel1.Controls.Add(Me.BunifuImageButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(817, 25)
        Me.Panel1.TabIndex = 15
        '
        'BunifuImageButton1
        '
        Me.BunifuImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuImageButton1.BackgroundImage = CType(resources.GetObject("BunifuImageButton1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuImageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BunifuImageButton1.ErrorImage = Nothing
        Me.BunifuImageButton1.Image = CType(resources.GetObject("BunifuImageButton1.Image"), System.Drawing.Image)
        Me.BunifuImageButton1.ImageActive = Nothing
        Me.BunifuImageButton1.InitialImage = Nothing
        Me.BunifuImageButton1.Location = New System.Drawing.Point(783, 2)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(22, 22)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 16
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
        '
        'AppLinkBtn
        '
        Me.AppLinkBtn.AutoSize = True
        Me.AppLinkBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppLinkBtn.Location = New System.Drawing.Point(508, 420)
        Me.AppLinkBtn.Name = "AppLinkBtn"
        Me.AppLinkBtn.Size = New System.Drawing.Size(180, 24)
        Me.AppLinkBtn.TabIndex = 16
        Me.AppLinkBtn.TabStop = True
        Me.AppLinkBtn.Text = "Applicant Click Here"
        '
        'ConctionBtn
        '
        Me.ConctionBtn.BackColor = System.Drawing.Color.Transparent
        Me.ConctionBtn.BackgroundImage = Global.Hunters_PMS.My.Resources.Resources._96
        Me.ConctionBtn.Location = New System.Drawing.Point(566, 64)
        Me.ConctionBtn.Name = "ConctionBtn"
        Me.ConctionBtn.Size = New System.Drawing.Size(92, 93)
        Me.ConctionBtn.TabIndex = 18
        Me.ConctionBtn.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(739, 298)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(739, 208)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Eras Light ITC", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(752, 474)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "v.1.0.108"
        '
        'Login_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(817, 500)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ConctionBtn)
        Me.Controls.Add(Me.AppLinkBtn)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LoginbBtn)
        Me.Controls.Add(Me.PasswordBox)
        Me.Controls.Add(Me.UsernameBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ApplicantsDGV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.ApplicantsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ApplicantsDGV As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents UsernameBox As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents PasswordBox As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents LoginbBtn As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuDragControl2 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents AppLinkBtn As LinkLabel
    Friend WithEvents ConctionBtn As Button
    Friend WithEvents Label3 As Label
End Class
