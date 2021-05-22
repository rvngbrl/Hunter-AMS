Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports Bunifu
Imports BunifuAnimatorNS

Public Class PreQualification_Form

    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")
    Public Property rankID As String
    Public Property UserText As String

    Dim dstatus As String
    Function Escapespace(ByVal msData As Object) As String
        Return (Replace(msData, " ", "  "))
    End Function
    Public Sub Save_Info()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Sources
        Dim Bulletin, OnlineApplication, Facebook, WordMouth, Referal, kalaw, other As String

        Dim commaSources As String = ", "
        Dim allSources As String
        Dim FinalCombinedSources As String  'Stringbuilder
        Dim FinalCombinedSourcesTrimmed As String  'Stringbuilder


        If CheckboxBulletin.Checked = True Then
            Bulletin = (commaSources & BulletinTxt.Text)
        End If

        If CheckboxSeaJob.Checked = True Then
            OnlineApplication = (commaSources & SeaJobTxt.Text)
        End If

        If CheckboxFacebook.Checked = True Then
            Facebook = (commaSources & FacebookTxt.Text)
        End If

        If CheckboxWord.Checked = True Then
            WordMouth = (commaSources & WordTxt.Text)
        End If

        If CheckboxReferal.Checked = True Then
            Referal = (commaSources & ReferalTxt.Text)
        End If

        If CheckboxKalaw.Checked = True Then
            kalaw = (commaSources & KalawTxt.Text)
        End If
        If CheckboxSource.Checked = True Then
            other = (commaSources & SourceTxtbx.Text)
        End If

        allSources = Bulletin + OnlineApplication + Facebook + WordMouth + Referal + kalaw + other

        FinalCombinedSources = allSources.Trim(", ", "")
        FinalCombinedSourcesTrimmed = FinalCombinedSources.TrimStart()

        'VesselExp
        Dim Tanker, Gencargo, Container, Offshore, Passenger, Bulk, others As String

        Dim commaExp As String = ", "
        Dim allExp As String
        Dim FinalCombinedExp As String  'Stringbuilder
        Dim FinalCombinedExpTrimmed As String  'Stringbuilder


        If CheckboxTanker.Checked = True Then
            Tanker = (commaSources & TankerTxt.Text)
        End If

        If CheckboxGCargo.Checked = True Then
            Gencargo = (commaSources & GCargoTxt.Text)
        End If

        If CheckboxContainer.Checked = True Then
            Container = (commaSources & ContainerTxt.Text)
        End If

        If CheckboxOffshore.Checked = True Then
            Offshore = (commaSources & OffshoreTxt.Text)
        End If

        If CheckboxPassenger.Checked = True Then
            Passenger = (commaSources & PassengerTxt.Text)
        End If

        If CheckboxBulk.Checked = True Then
            Bulk = (commaSources & BulkTxt.Text)
        End If
        If CheckboxExp.Checked = True Then
            others = (commaSources & ExpTxt.Text)
        End If

        allExp = Tanker + Gencargo + Container + Offshore + Passenger + Bulk + others
        FinalCombinedExp = allExp.Trim(", ", "")
        FinalCombinedExpTrimmed = FinalCombinedExp.TrimStart()

        'Inserting Data
        Dim AppInfoIns As String
        AppInfoIns = ("INSERT INTO hunters_pooling.applicant_info(App_LName,App_FName,App_MName,App_Suffix,App_Status,App_Bday,App_ContactNo,App_LastDisembark,App_RankID,App_PreAgency,App_PreSalary) VALUES (?,?,?,?,?,?,?,?,?,?,?)")
        Dim AppInfocmd As OdbcCommand = New OdbcCommand(AppInfoIns, conn)

        AppInfocmd.Parameters.Add(New OdbcParameter("@App_LName", CType(AppLastName.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_FName", CType(AppFirstName.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_MName", CType(AppMiddleName.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Suffix", CType(AppSuffix.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Status", CType("Applicant", String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Bday", CType(AppBirthdate.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_ContactNo", CType(AppContactNum.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_LastDisembark", CType(DisembarkDatePick.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_RankID", CType(rankID, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_PreAgency", CType(AgencyTxtbx.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_PreSalary", CType(SalaryTxtBx.Text, String)))
        AppInfocmd.ExecuteNonQuery()
        AppInfocmd.Dispose()

        'Query for App_ID
        Dim AppIDstr As String
        AppIDstr = "SELECT App_ID FROM hunters_pooling.applicant_info ORDER BY App_ID DESC LIMIT 1;"
        Dim AppIDcommand As OdbcCommand
        AppIDcommand = New OdbcCommand(AppIDstr, conn)
        Dim AppIDmyReader As OdbcDataReader = AppIDcommand.ExecuteReader()
        Dim AppIDoutput As String
        While AppIDmyReader.Read
            AppIDoutput = AppIDmyReader.GetInt32(0) 'Applicant_ID value
        End While

        'Query for Rank_ID
        Dim rankstr As String
        rankstr = "SELECT Rank_ID FROM csiaccountingdb.rank WHERE Rank_Fullname = '" & AppRankCmb.Text & "';"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        While rankmyReader.Read
            rankID = rankmyReader.GetInt32(0)
        End While
        Dim datenow As Date = Date.UtcNow 'DATE NOW IN UTC FORMAT

        'INSERTING VESSEL SOURCE POSITION  PRINCIPAL and DISEMBARK HERE
        Dim AppPosScreenSTR As String
        AppPosScreenSTR = ("INSERT INTO hunters_pooling.applicant_screening(App_RankApplied,App_Experience,App_Source,App_PreStatus,App_AssignedPosition,App_AssignedPrincipal,App_DateApplied, App_ID,Rank_ID) VALUES (?,?,?,?,?,?,?,?,?)")
        Dim AppPosSoursecmd As OdbcCommand = New OdbcCommand(AppPosScreenSTR, conn)
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_RankApplied", CType(AppRankTxt.Text, String))) 'rank
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_Experience", CType(FinalCombinedExpTrimmed, String))) 'vessel
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_Source", CType(FinalCombinedSourcesTrimmed, String))) 'source 
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_PreStatus", CType(StatusTxt.selectedValue, String))) 'remarks
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_AssignedPosition", CType(AppRankCmb.Text, String))) 'Assigned Position
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_AssignedPrincipal", CType(PrincipalCmbx.Text, String))) 'principal
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_DateApplied", CType(datenow.Date.ToString("yyyy-MM-dd"), Date))) 'dateapplied
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))

        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@Rank_ID", CType(rankID, String)))
        AppPosSoursecmd.ExecuteNonQuery()
        AppPosSoursecmd.Dispose()



        'INSERTING TO RANK
        Dim AppRankSTR As String
        AppRankSTR = ("INSERT INTO hunters_pooling.applicant_rank(AppRank_ID,AppRank_Name,AppRank_Date,AppHigherRank_Name,App_ID) VALUES (?,?,?,?,?)")
        Dim AppRankSTRcmd As OdbcCommand = New OdbcCommand(AppRankSTR, conn)
        AppRankSTRcmd.Parameters.Add(New OdbcParameter("@AppRank_ID", CType(rankID, String))) 'rank
        AppRankSTRcmd.Parameters.Add(New OdbcParameter("@AppRank_Name", CType(AppRankCmb.Text, String))) 'vessel
        AppRankSTRcmd.Parameters.Add(New OdbcParameter("@AppRank_Date", CType(datenow.Date.ToString("yyyy-MM-dd"), Date))) 'source 
        AppRankSTRcmd.Parameters.Add(New OdbcParameter("@AppHigherRank_Name", CType("", String))) 'remarks
        AppRankSTRcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String))) 'Assigned Position
        AppRankSTRcmd.ExecuteNonQuery()
        AppRankSTRcmd.Dispose()










    End Sub

    Public Sub Checking()
        'Checking ng system sa mga hindi nafill-up-an
        If Len(Trim(AppLastName.Text)) = 0 Then
            MessageBox.Show("Please enter Last Name", "Input Error", MessageBoxButtons.OK)
            AppLastName.Focus()
            Exit Sub

            'firstname
        ElseIf Len(Trim(AppFirstName.Text)) = 0 Then
            MessageBox.Show("Please enter First Name", "Input Error", MessageBoxButtons.OK)
            AppFirstName.Focus()
            Exit Sub
            'bdate
        ElseIf AppBirthdate.Value = Date.Today Then
            MessageBox.Show("Please enter your Birth Date", "Input Error", MessageBoxButtons.OK)
            AppBirthdate.Focus()
            Exit Sub
            'cellphone
        ElseIf Len(Trim(AppContactNum.Text)) = 0 Then
            MessageBox.Show("Please enter Contact Number", "Input Error", MessageBoxButtons.OK)
            AppContactNum.Focus()
            Exit Sub
            'rank
        ElseIf Len(Trim(AppRankTxt.Text)) = 0 Then
            MessageBox.Show("Please enter Rank", "Input Error", MessageBoxButtons.OK)
            AppRankTxt.Focus()
            Exit Sub
            'disembark
        ElseIf DisembarkDatePick.Value = Date.Today Then
            MessageBox.Show("Please enter the Last Disembark Date", "Input Error", MessageBoxButtons.OK)
            DisembarkDatePick.Focus()
            Exit Sub
            'position
        ElseIf Len(Trim(AppRankCmb.Text)) = 0 Then
            MessageBox.Show("Please enter Position", "Input Error", MessageBoxButtons.OK)
            AppRankCmb.Focus()
            Exit Sub
            'principal
        ElseIf Len(Trim(PrincipalCmbx.Text)) = 0 Then
            MessageBox.Show("Please enter Principal", "Input Error", MessageBoxButtons.OK)
            PrincipalCmbx.Focus()
            Exit Sub

        Else
            Dim AppIDoutput, applname, appfname As String
            applname = AppLastName.Text
            appfname = AppFirstName.Text

            'Query for App_ID
            Dim AppIDstr As String
            AppIDstr = "SELECT App_ID, App_LName,App_FName FROM hunters_pooling.applicant_info 
                        WHERE App_LName = '" & AppLastName.Text & "' AND App_FName = '" & AppFirstName.Text & "';"
            Dim AppIDcommand As OdbcCommand
            AppIDcommand = New OdbcCommand(AppIDstr, conn)

            Dim AppmyReader As OdbcDataReader = AppIDcommand.ExecuteReader()

            If AppmyReader.Read Then

                If AppLastName.Text = AppmyReader.Item(1).ToString And AppFirstName.Text = AppmyReader.Item(2).ToString Then

                    MsgBox("This Applicant is already in the system.")
                End If
            Else
                Save_Info()
                conn.Close()
                MsgBox("Applicant Saved")
                Me.Hide()

            End If
        End If

    End Sub

    Private Sub AppSaveBtn_Click(sender As Object, e As EventArgs) Handles AppSaveBtn.Click
        StatDouble.Text = "Status"

        Checking()
    End Sub

    Private Sub Application_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Query for CREWRANk
        Dim rankstr As String
        rankstr = "SELECT Rank_ID, Rank_Fullname FROM csiaccountingdb.rank order by Rank_Fullname asc;"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        While rankmyReader.Read
            AppRankCmb.Items.Add(rankmyReader.GetString(1))
        End While

        'Query for principal
        Dim principalstr As String
        principalstr = "SELECT Principal_Name FROM csiaccountingdb.payroll_schedule order by Principal_Name asc;"
        Dim principalcommand As OdbcCommand
        principalcommand = New OdbcCommand(principalstr, conn)
        Dim principalmyReader As OdbcDataReader = principalcommand.ExecuteReader()
        While principalmyReader.Read
            PrincipalCmbx.Items.Add(principalmyReader.GetString(0))
        End While


    End Sub

    Private Sub Closebtn_Click(sender As Object, e As EventArgs) Handles Closebtn.Click
        Me.Hide()
    End Sub

    Private Sub BunifuImageButton3_Click(sender As Object, e As EventArgs) Handles BunifuImageButton3.Click
        Me.Hide()
    End Sub



    Private Sub AppRank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppRankCmb.SelectedIndexChanged
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Query for Rank_ID
        Dim rankstr As String
        rankstr = "SELECT Rank_ID FROM csiaccountingdb.rank WHERE Rank_Fullname = '" & AppRankCmb.Text & "';"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        While rankmyReader.Read
            rankID = rankmyReader.GetInt32(0)
        End While

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show(rankID)

    End Sub

    Private Sub PrincipalCmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrincipalCmbx.SelectedIndexChanged

    End Sub

    Private Sub AppRankTxt_OnValueChanged(sender As Object, e As EventArgs) Handles AppRankTxt.OnValueChanged

    End Sub

    Private Sub AppBirthdate_onValueChanged(sender As Object, e As EventArgs) Handles AppBirthdate.onValueChanged

        Dim Age As Integer


        Math.Floor(DateDiff(DateInterval.Month, Me.AppBirthdate.Value, System.DateTime.Now) / 12)

        'Textbox1.text = Now.Year - datetimepicker1.value.year
        Age = System.DateTime.Now.Year - Me.AppBirthdate.Value.Year

        AgeTxtbox.Text = Age


        'If AppGName.Text.Equals("Seaman's Book") Then

        '    Me.doccertexpiry.Value = sender.Value.AddYears(10)
        'ElseIf AppGName.Text.Equals("Passport") Then
        '    Me.doccertexpiry.Value = sender.Value.AddYears(10)

        'End If

    End Sub



End Class