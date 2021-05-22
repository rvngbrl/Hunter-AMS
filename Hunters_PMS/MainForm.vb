Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports Bunifu
Imports BunifuAnimatorNS

Public Class MainForm
    Public Property myacc As String
    Public Property GetAppID As String
    Public Property GetUserID As String
    Public Property rankID As String
    Dim userinitials As String
    Dim imgData As Byte()
    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")
    Function EscapeQuote(ByVal msData As Object) As String
        Return (Replace(msData, "'", "''"))
    End Function
    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        conn.Close()
        Windows.Forms.Application.Exit()
        Windows.Forms.Application.ExitThread()
    End Sub

    Private Sub MainForm_Closed(sender As Object, e As CancelEventArgs) Handles Me.Closed
        conn.Close()
        Windows.Forms.Application.Exit()
        Windows.Forms.Application.ExitThread()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        conn.Open()

        'User initials and User dept using username in login form
        Dim str As String
        str = ("SELECT * FROM csi_user WHERE User_Name = '" & myacc & "'")
        Dim command As OdbcCommand
        command = New OdbcCommand(str, conn)

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim reader As OdbcDataReader = command.ExecuteReader()

        If reader.Read Then
            UserLabel.Text = reader.Item("User_initials")
            GetUserID = reader.Item("User_ID")
            userinitials = reader.Item("User_initials")

        End If

        'Displaying an image of Crystal
        Dim imgstr As String
        imgstr = ("SELECT User_Pic FROM csi_user WHERE User_ID = '" & GetAppID & "'")
        Dim imgcommand As OdbcCommand
        imgcommand = New OdbcCommand(imgstr, conn)

        Dim imgreader As OdbcDataReader = imgcommand.ExecuteReader()
        If imgreader.Read Then
            imgData = TryCast(imgreader.Item(0), Byte())
            If imgData IsNot Nothing Then
                Using ms As New MemoryStream(imgData)
                    UserPicture.SizeMode = PictureBoxSizeMode.StretchImage
                    UserPicture.Image = CType(Image.FromStream(ms), Image)
                End Using
            End If
        End If


        'Show Data Grid View
        Dim mainAppList As String
        mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                       YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                       FROM hunters_pooling.applicant_info ai 
                       LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                       LEFT JOIN hunters_pooling.applicant_screening ac ON ai.App_ID=ac.App_ID
                       WHERE ai.App_Status ='APPLICANT'
                       ORDER BY ac.App_DateApplied desc;  "

        Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
        Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
        applist.Fill(ApplicantView)
        MainDataGridView.DataSource = ApplicantView
        applist.Dispose()
        MainDataGridView.Columns("App_ID").Visible() = False

        MainDataGridView.AutoResizeColumn(2)

        'Total count of ACTIVE Applicant
        Dim counter As String
        counter = "SELECT COUNT(*) FROM hunters_pooling.applicant_info"
        Dim countercommand As OdbcCommand
        countercommand = New OdbcCommand(counter, conn)
        Dim counterreader As OdbcDataReader = countercommand.ExecuteReader()
        If counterreader.Read Then
            AppTotalLabel.Text = counterreader.Item(0).ToString
        End If


        'Query for CREWRANk
        Dim rankstr As String
        rankstr = "SELECT Rank_ID, Rank_Fullname FROM csiaccountingdb.rank order by Rank_Fullname asc;"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        While rankmyReader.Read
            AppAssignPosition.Items.Add(rankmyReader.GetString(1))
            rankID = rankmyReader.GetInt32(0)
        End While


        'Query for principal
        Dim principalstr As String
        principalstr = "SELECT Principal_Name FROM csiaccountingdb.payroll_schedule;"
        Dim principalcommand As OdbcCommand
        principalcommand = New OdbcCommand(principalstr, conn)
        Dim principalmyReader As OdbcDataReader = principalcommand.ExecuteReader()
        While principalmyReader.Read
            AppAssignPrincipal.Items.Add(principalmyReader.GetString(0))
        End While


        conn.Close()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If


    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Close()
        Windows.Forms.Application.Exit()
        Windows.Forms.Application.ExitThread()
    End Sub

    Private Sub EncBtn_Click_1(sender As Object, e As EventArgs) Handles EncBtn.Click
        conn.Close()
        EncodingForm.Show()
        'Application_Form.Show()
    End Sub

    Private Sub MainDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MainDataGridView.CellClick
        conn.Open()

        SaveBtn.Enabled = True
        AppLastname.ResetText()
        AppFirstname.ResetText()
        AppMiddlename.ResetText()
        AppSuffix.ResetText()
        AppStatus.ResetText()
        AppBirthday.ResetText()
        AppContactNum.ResetText()
        AppAssignPrincipal.ResetText()
        AppAssignPosition.ResetText()
        AppDateApplied.ResetText()
        AppTRORemarks.ResetText()
        AppStatus.ResetText()
        AppRemarks.SelectedItem = Nothing
        AppExperience.ResetText()
        AppAssignPrincipal.ResetText()
        AppAssignPosition.ResetText()
        AppExperience.ResetText()
        AppSources.ResetText()
        RemarksTxtbx.ResetText()
        AppPreAgency.ResetText()
        AppPreSalary.ResetText()
        AppDateCalled.ResetText()
        Endorser.ResetText()
        Dim query As String

        If (e.RowIndex >= 0) Then

            AppIDIdentifier.Text = MainDataGridView.Rows.Item(e.RowIndex).Cells(0).Value
            GetAppID = MainDataGridView.Rows.Item(e.RowIndex).Cells(0).Value
            query = "SELECT * FROM hunters_pooling.applicant_info ai
            LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
            LEFT JOIN hunters_pooling.applicant_vesselassign av ON ai.App_ID=av.App_ID WHERE ai.App_ID = '" & MainDataGridView.Rows.Item(e.RowIndex).Cells(0).Value & "'"

            Dim command As OdbcCommand
            command = New OdbcCommand(query, conn)
            Dim reader As OdbcDataReader = command.ExecuteReader()
            Dim userID As String

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            While reader.Read
                'Showing Data in Textbox
                Try
                    RemarksTxtbx.Text = reader.Item("App_Remarks").ToString()
                    AppLastname.Text = reader.Item("App_LName").ToString()
                    AppFirstname.Text = reader.Item("App_FName").ToString()
                    AppMiddlename.Text = reader.Item("App_MName").ToString()
                    AppSuffix.Text = reader.Item("App_Suffix").ToString()
                    AppStatus.Text = reader.Item("App_Status").ToString()
                    AppBirthday.Value = reader.Item("App_Bday").ToString()
                    'AppDateCalled.Value = reader.Item("App_DateLastCalled").ToString()
                    AppContactNum.Text = reader.Item("App_ContactNo").ToString()
                    AppAssignPrincipal.Text = reader.Item("App_AssignedPrincipal").ToString()
                    AppAssignPosition.Text = reader.Item("App_AssignedPosition").ToString()
                    AppDateApplied.Value = reader.Item("App_DateApplied").ToString()
                    AppTRORemarks.Text = reader.Item("App_PreStatus").ToString()
                    AppStatus.Text = reader.Item("App_Status").ToString()
                    AppRemarks.Text = reader.Item("App_CurrentStatus").ToString()
                    AppExperience.Text = reader.Item("App_Experience").ToString()
                    AppAssignPrincipal.Text = reader.Item("App_AssignedPrincipal").ToString()
                    AppAssignPosition.Text = reader.Item("App_AssignedPosition").ToString()
                    AppAssignVessel.Text = reader.Item("AVessel").ToString()
                    AppSources.Text = reader.Item("App_Source").ToString()
                    AppExperience.Text = reader.Item("App_Experience").ToString()
                    AppPreAgency.Text = reader.Item("App_PreAgency").ToString()
                    AppPreSalary.Text = reader.Item("App_PreSalary").ToString()
                    Endorser.Text = reader.Item("Reps_Endorser").ToString()
                    'AppDateEndorsed.Value = reader.Item("App_DateEndorsed").ToString()

                    'MsgBox(AppSources.Text = reader.Item("App_Source").ToString())





                Catch ex As Exception
                End Try
            End While

        ElseIf e.RowIndex <> -1 Then

        End If
        conn.Close()
    End Sub


    Private Sub savingpool()
        'Updating Applicant Pre-Information
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim datenow As Date = Date.UtcNow
        Dim updatepoolstr As String
        updatepoolstr = "Update hunters_pooling.applicant_screening SET App_PreStatus= '" & AppTRORemarks.Text & "',     
        App_AssignedPosition ='" & AppAssignPosition.Text & "',
        App_AssignedPrincipal ='" & AppAssignPrincipal.Text & "',
        App_Remarks = '" & EscapeQuote(RemarksTxtbx.Text) & "',
        App_DateLastCalled = '" & AppDateCalled.Value.ToString("yyyy-MM-dd") & "',
        Rank_ID ='" & rankID & "',
        Reps_Endorser='" & UserLabel.Text & "'
        WHERE App_ID='" & GetAppID & "' ;  "


        Dim updatepoolcmd As OdbcCommand = New OdbcCommand(updatepoolstr, conn)
        Dim updateinfo As String

        updateinfo = " Update hunters_pooling.applicant_info SET App_Bday= '" & AppBirthday.Value.Date.ToString("yyyy-MM-dd") & "', 
        App_ContactNo ='" & AppContactNum.Text & "',
        App_CurrentStatus ='" & AppRemarks.Text & "',
        App_LName = '" & AppLastname.Text & "',
        App_FName = '" & AppFirstname.Text & "',
        App_MName = '" & AppMiddlename.Text & "',
        App_PreAgency = '" & AppPreAgency.Text & "',
        App_PreSalary = '" & AppPreSalary.Text & "'
        WHERE  App_ID='" & GetAppID & "' ;  "

        Dim updatetinfocmd As OdbcCommand = New OdbcCommand(updateinfo, conn)
        If AppRemarks.Text.Equals("POOLING") Then
            Dim updatepool As String
            updatepool = " Update hunters_pooling.applicant_info SET App_Pool= '" & "Pooling" & "'
            WHERE  App_ID='" & GetAppID & "' ;  "

            Dim poolcmd As OdbcCommand = New OdbcCommand(updatepool, conn)
            poolcmd.ExecuteNonQuery()
            poolcmd.Dispose()
        End If
        updatetinfocmd.ExecuteNonQuery()
        updatetinfocmd.Dispose()
        updatepoolcmd.ExecuteNonQuery()
        updatepoolcmd.Dispose()
        MessageBox.Show("The data has been Updated")

    End Sub

    Private Sub MainDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles MainDataGridView.CellDoubleClick
        If (e.RowIndex >= 0) Then

            Dim OBJ As New Editing_Info
            OBJ.GetAppID = AppIDIdentifier.Text
            OBJ.UserText = UserLabel.Text
            OBJ.Hide()
            OBJ.Show()
        ElseIf e.RowIndex <> -1 Then
        End If

    End Sub


    Public Sub FilterByCategory()


        If CBoxCategory.SelectedIndex = 0 Then
            'APPLICANT STATUS: ALL
            Dim mainAppList As String
            mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                       YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                       FROM hunters_pooling.applicant_info ai 
                       LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                       ORDER BY ai.App_ID Desc;"

            Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
            Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
            applist.Fill(ApplicantView)
            MainDataGridView.DataSource = ApplicantView
            applist.Dispose()
            MainDataGridView.Columns("App_ID").Visible() = False
            MainDataGridView.AutoResizeColumn(2)

        ElseIf CBoxCategory.SelectedIndex = 1 Then
            'APPLICANT STATUS: APPROVED
            Dim mainAppList As String
            mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                           YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                           FROM hunters_pooling.applicant_info ai 
                           LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                           WHERE ai.App_CurrentStatus = 'APPROVED'
                           ORDER BY ai.App_ID Desc;"

            Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
            Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
            applist.Fill(ApplicantView)
            MainDataGridView.DataSource = ApplicantView
            applist.Dispose()
            MainDataGridView.Columns("App_ID").Visible() = False
            MainDataGridView.AutoResizeColumn(2)

        ElseIf CBoxCategory.SelectedIndex = 2 Then
            'APPLICANT STATUS: DISSAPPROVED
            Dim mainAppList As String
            mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                           YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                           FROM hunters_pooling.applicant_info ai 
                           LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                           WHERE ai.App_CurrentStatus = 'DISAPPROVED'
                           ORDER BY ai.App_ID Desc;"

            Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
            Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
            applist.Fill(ApplicantView)
            MainDataGridView.DataSource = ApplicantView
            applist.Dispose()
            MainDataGridView.Columns("App_ID").Visible() = False
            MainDataGridView.AutoResizeColumn(2)

        ElseIf CBoxCategory.SelectedIndex = 3 Then
            'APPLICANT STATUS: ENDORSED
            Dim mainAppList As String
            mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                           YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                           FROM hunters_pooling.applicant_info ai 
                           LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                           WHERE ai.App_CurrentStatus = 'ENDORSED'
                           ORDER BY ai.App_ID Desc;"

            Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
            Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
            applist.Fill(ApplicantView)
            MainDataGridView.DataSource = ApplicantView
            applist.Dispose()
            MainDataGridView.Columns("App_ID").Visible() = False
            MainDataGridView.AutoResizeColumn(2)

        ElseIf CBoxCategory.SelectedIndex = 4 Then
            'APPLICANT STATUS: ONPROCESS
            Dim mainAppList As String
            mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                           YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                           FROM hunters_pooling.applicant_info ai 
                           LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                           WHERE ai.App_CurrentStatus = 'ON PROCESS'
                           ORDER ai.App_ID Desc;"

            Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
            Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
            applist.Fill(ApplicantView)
            MainDataGridView.DataSource = ApplicantView
            applist.Dispose()
            MainDataGridView.Columns("App_ID").Visible() = False
            MainDataGridView.AutoResizeColumn(2)

        ElseIf CBoxCategory.SelectedIndex = 5 Then
            'APPLICANT STATUS: RESERVE
            Dim mainAppList As String
            mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                           YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                           FROM hunters_pooling.applicant_info ai 
                           LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                           WHERE ai.App_CurrentStatus = 'RESERVE'
                           ORDER BY ai.App_ID Desc;"

            Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
            Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
            applist.Fill(ApplicantView)
            MainDataGridView.DataSource = ApplicantView
            applist.Dispose()
            MainDataGridView.Columns("App_ID").Visible() = False
            MainDataGridView.AutoResizeColumn(2)

        ElseIf CBoxCategory.SelectedIndex = 6 Then
            'APPLICANT STATUS: POOLING
            Dim mainAppList As String
            mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name',                            
                           YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                           FROM hunters_pooling.applicant_info ai 
                           LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                           WHERE ai.App_CurrentStatus = 'POOLING'
                           ORDER BY ai.App_ID Desc;"

            Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
            Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
            applist.Fill(ApplicantView)
            MainDataGridView.DataSource = ApplicantView
            applist.Dispose()
            MainDataGridView.Columns("App_ID").Visible() = False
            MainDataGridView.AutoResizeColumn(2)

        End If
    End Sub

    Private Sub CBoxCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBoxCategory.SelectedIndexChanged

        FilterByCategory()
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Searching Applicant By Name 
        Dim mainAppList As String
        mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                       YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                       FROM hunters_pooling.applicant_info ai 
                       LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID 
                       WHERE ai.App_LName LIKE '%" & applicantName.Text & "%' OR ai.App_FName LIKE '%" & applicantName.Text & "%' OR ai.App_MName LIKE '%" & applicantName.Text & "%'
                       ORDER BY ai.App_ID Desc;"


        Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
        Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
        applist.Fill(ApplicantView)
        MainDataGridView.DataSource = ApplicantView
        applist.Dispose()
        MainDataGridView.Columns("App_ID").Visible() = False

        conn.Close()

    End Sub
    Private Sub applicantName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles applicantName.KeyPress

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        If e.KeyChar = Chr(13) Then

            Dim mainAppList As String
            mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                           YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                           FROM hunters_pooling.applicant_info ai 
                           LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID 
                           WHERE ai.App_LName LIKE '%" & applicantName.Text & "%' OR ai.App_FName LIKE '%" & applicantName.Text & "%' OR ai.App_MName LIKE '%" & applicantName.Text & "%'
                           ORDER BY ai.App_ID Desc;"

            Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
            Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
            applist.Fill(ApplicantView)
            MainDataGridView.DataSource = ApplicantView
            applist.Dispose()
            MainDataGridView.Columns("App_ID").Visible() = False

        End If
        conn.Close()
    End Sub

    Private Sub ScrBtn_Click(sender As Object, e As EventArgs)

        Screening.Show()

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

        Dim OBJ As New PreQualification_Form
        OBJ.UserText = UserLabel.Text
        OBJ.Hide()
        OBJ.Show()
    End Sub


    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click

        AppTRORemarks.Enabled = True
        AppStatus.Enabled = True
        AppAssignPrincipal.Enabled = True
        AppAssignPosition.Enabled = True
        AppSources.Enabled = True
        AppExperience.Enabled = True
        AppBirthday.Enabled = True
        AppContactNum.Enabled = True
        AppDateCalled.Enabled = True
        AppRemarks.Enabled = True
        SaveBtn.Enabled = True
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        savingpool()
        conn.Close()
    End Sub


    Private Sub RepBtn_Click(sender As Object, e As EventArgs) Handles RepBtn.Click

        Dim OBJ As New Pooling
        OBJ.UserText = UserLabel.Text
        OBJ.Hide()
        OBJ.Show()
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MainDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MainDataGridView.CellContentClick
        'SaveBtn.Enabled = True
        'AppLastname.ResetText()
        'AppFirstname.ResetText()
        'AppMiddlename.ResetText()
        'AppSuffix.ResetText()
        'AppStatus.ResetText()
        'AppBirthday.ResetText()
        'AppContactNum.ResetText()
        'AppAssignPrincipal.ResetText()
        'AppAssignPosition.ResetText()
        'AppDateApplied.ResetText()
        'AppDateCalled.ResetText()
        'AppTRORemarks.ResetText()
        'AppStatus.ResetText()
        'AppRemarks.SelectedItem = Nothing
        'AppExperience.ResetText()
        'AppAssignPrincipal.ResetText()
        'AppAssignPosition.ResetText()
        'AppExperience.ResetText()
        'AppSources.ResetText()
        'RemarksTxtbx.ResetText()
        'AppPreAgency.ResetText()
        'AppPreSalary.ResetText()

    End Sub

    Private Sub AppBtn_Click(sender As Object, e As EventArgs) Handles AppBtn.Click
        Dim OBJ As New OnlineForm
        OBJ.Hide()
        OBJ.Show()
    End Sub

    Private Sub AppDateCalled_onValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub applicantName_OnValueChanged(sender As Object, e As EventArgs) Handles applicantName.OnValueChanged

    End Sub
End Class