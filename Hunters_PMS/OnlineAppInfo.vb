Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports Bunifu
Imports BunifuAnimatorNS


Public Class OnlineAppInfo
    Public Property GetOAppID As String
    Public Property rankID As String
    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")

    Dim AppOID, LName, FName, Mname, Position, Contact, Email, BPlace, Suit, Waist, Shoe, DMark, HColor As String 'Applicant Information
    Dim BDay, kinBday, DApplied As Date

    Dim docid, docname, docshortcut, docno, docplace, docexpired, doccountry, crewdocid, docstatus, dateexpired As String 'Applicant Documents

    Dim kinRelation, kinLName, kinFName, kinMName, kinContact, kinPassport As String 'Family Information

    Dim refName, refAddress, refCPerson, refCPersonNo, refEmail, refStatus As String 'Character Reference


    Private Sub btnCharRef_Click(sender As Object, e As EventArgs) Handles btnCharRef.Click
        refLabel.ResetText()
        refLabel.Text = "Character Reference"
        famDGView.Visible = False
        crDGView.Visible = True
    End Sub

    Private Sub BunifuGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles refPanel.Paint

    End Sub

    Private Sub btnRef_Click(sender As Object, e As EventArgs) Handles btnRef.Click
        DocCertView.Visible = False
        SBDGView.Visible = False
        refPanel.Visible = True

        Dim refstr As String
        refstr = "SELECT ref_Status as Reference, ref_Name as Name,ref_Address as Address, ref_CPerson as Perosn_Name, ref_CPersonNo as Mobile_No, ref_Email as Email from web.applicant_reference where App_ID='" & GetOAppID & "';"
        Dim refList As New DataTable("applicant_kin")
        Dim refadapter As New Odbc.OdbcDataAdapter(refstr, conn)
        refadapter.Fill(refList)
        crDGView.DataSource = refList
        refadapter.Dispose()

    End Sub

    Private Sub btnFamilyInfo_Click(sender As Object, e As EventArgs) Handles btnFamilyInfo.Click
        refLabel.ResetText()
        refLabel.Text = "Family Information"
        crDGView.Visible = False
        famDGView.Visible = True


        Dim familystr As String
        familystr = "SELECT kin_Relation as Relation, CONCAT(kin_LName,',',kin_FName,' ',kin_MName )as Name, DATE_FORMAT(kin_Bday, '%d-%b-%Y') as Birthday, kin_Contact as Mobile, kin_Passport as Passport FROM web.applicant_kin  where App_ID='" & GetOAppID & "';"
        Dim familyList As New DataTable("applicant_kin")
        Dim familyadapter As New Odbc.OdbcDataAdapter(familystr, conn)
        familyadapter.Fill(familyList)
        famDGView.DataSource = familyList
        familyadapter.Dispose()



    End Sub

    Dim dateissued As Date
    Dim AppIDoutput As String
    Dim Signedon, Signedoff As Date

    'seaservice
    Dim PName, VName, Flag, Nationality, Agency, Rank, VType, Grt, EType, Bhp, Duration, Reason, TRoute, Salary As String



    Private Sub OnlineAppInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        AppIDTxt.ResetText()
        AppNameTxt.ResetText()
        AppPositionTxt.ResetText()
        AppContactTxt.ResetText()
        AppEmailTxt.ResetText()
        AppBirthday.ResetText()
        AppBPlaceTxt.ResetText()
        AppDateAppliedTxt.ResetText()
        AppIDTxt.Text = GetOAppID


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
        DocCertView.Visible = True
        'Query for OnlineApplicant
        Dim queryApp As String
        queryApp = "Select App_PositionApplied,  concat(App_LName,', ',App_FName,' ',App_Mname) as Name, App_MobileNo, App_EmailAdd, App_Bday, App_BPlace,date_format(App_DateApplied  , '%d-%b-%Y') AS 'Applied Date'  from web.applicant_info where App_ID= '" & GetOAppID & "';"
        Dim queryAppcmd As OdbcCommand
        queryAppcmd = New OdbcCommand(queryApp, conn)
        Dim Appreader As OdbcDataReader = queryAppcmd.ExecuteReader()

        If Appreader.Read Then
            AppNameTxt.Text = Appreader.Item("Name").ToString()
            AppPositionTxt.Text = Appreader.Item("App_PositionApplied").ToString()
            AppContactTxt.Text = Appreader.Item("App_MobileNo").ToString()
            AppEmailTxt.Text = Appreader.Item("App_EmailAdd").ToString()
            AppBirthday.Value = Appreader.Item("App_Bday").ToString()
            AppBPlaceTxt.Text = Appreader.Item("App_BPlace").ToString()
            AppDateAppliedTxt.Text = Appreader.Item("Applied Date").ToString()
        End If
    End Sub

    Private Sub DCerts_Btn_Click(sender As Object, e As EventArgs) Handles DCerts_Btn.Click
        SBDGView.Visible = False
        refPanel.Visible = False
        DocCertView.Visible = True


        Dim documentstr As String
        documentstr = "Select  Document_ID, AppDoc_Name AS 'TITLE', AppDoc_No AS 'NUMBER', date_format(AppDoc_DateIssued , '%d-%b-%Y') AS 'ISSUED DATE', date_format(AppDoc_DateExpired , '%d-%b-%Y') AS 'EXPIRY DATE', App_DocID FROM web.applicant_doc where App_ID='" & GetOAppID & "';"
        Dim documentList As New DataTable("applicant_doc")
        Dim documentadapter As New Odbc.OdbcDataAdapter(documentstr, conn)
        documentadapter.Fill(documentList)
        DocCertView.DataSource = documentList
        documentadapter.Dispose()
        DocCertView.Columns(0).Visible() = False
        DocCertView.Columns(5).Visible() = False
    End Sub
    Private Sub SBoard_Btn_Click(sender As Object, e As EventArgs) Handles SBoard_Btn.Click
        DocCertView.Visible = False
        refPanel.Visible = False
        SBDGView.Visible = True
        ' DocCertView.Size = New Size(1169, 75) 'changed
        Dim documentstr As String
        documentstr = "SELECT App_PrincipalName As 'PRINCIPAL', App_VesselName as 'VESSEL',App_ImportFlag as 'FLAG', App_Nationality as 'NATIONALITY', App_Agency as 'AGENCY', App_Rank as 'RANK',
 App_VesselType as 'VESSEL TYPE', App_Grt as 'GRT', App_BHP as 'BHP',   date_format(App_DateSignedON , '%d-%b-%Y') as 'SIGN ON', date_format(App_DateSignedOFF , '%d-%b-%Y')
 as 'SIGN OFF', App_Duration as 'DURATION', App_Salary as 'SALARY'  FROM web.applicant_seaservice where App_ID='" & GetOAppID & "';"
        Dim documentList As New DataTable("applicant_sea")
        Dim documentadapter As New Odbc.OdbcDataAdapter(documentstr, conn)
        documentadapter.Fill(documentList)
        SBDGView.DataSource = documentList
        documentadapter.Dispose()

    End Sub
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub

    Private Sub DocCertView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DocCertView.CellContentClick

    End Sub

    Private Sub AprvBtn_Click(sender As Object, e As EventArgs) Handles AprvBtn.Click

        Dim checkerStr As String
        checkerStr = "SELECT Count(1) as Counting FROM web.applicant_kin  where App_ID='" & GetOAppID & "';"
        Dim checkercmd As OdbcCommand
        checkercmd = New OdbcCommand(checkerStr, conn)
        Dim checkerReader As OdbcDataReader = checkercmd.ExecuteReader()
        Dim Checker As Integer = 0

        If checkerReader.Read Then
            Checker = checkerReader.Item("Counting")
        End If

        If Checker <= 0 Then
            Dim ask As MsgBoxResult = MsgBox("Are you sure you want to transfer this applicant without a complete application?", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then
                Checking()
            End If
        Else
            Dim ask As MsgBoxResult = MsgBox("Complete", MsgBoxStyle.YesNo)
            If ask = MsgBoxResult.Yes Then
                Checking()
            End If
        End If






    End Sub
    Public Sub Checking()
        'Checking ng system sa mga hindi nafill-up-an

        If DisembarkDatePick.Value = Date.Today Then
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

            Dim queryApp As String
            queryApp = "Select App_PositionApplied, App_LName,App_FName,App_Mname, App_MobileNo, App_EmailAdd, App_Bday, App_BPlace,App_DateApplied,App_Suit,App_Waist,App_Shoe,App_DMark,App_HColor  from web.applicant_info where App_ID= '" & GetOAppID & "';"
            Dim queryAppcmd As OdbcCommand
            queryAppcmd = New OdbcCommand(queryApp, conn)
            Dim Appreader As OdbcDataReader = queryAppcmd.ExecuteReader()

            If Appreader.Read Then
                LName = Appreader.Item("App_LName").ToString()
                FName = Appreader.Item("App_FName").ToString()
                Mname = Appreader.Item("App_Mname").ToString()
                Position = Appreader.Item("App_PositionApplied").ToString()
                Contact = Appreader.Item("App_MobileNo").ToString()
                Email = Appreader.Item("App_EmailAdd").ToString()
                BDay = Appreader.Item("App_Bday").Date.ToString()
                BPlace = Appreader.Item("App_BPlace").ToString()
                DApplied = Appreader.Item("App_DateApplied").ToString()
                Suit = Appreader.Item("App_Suit").ToString()
                Waist = Appreader.Item("App_Waist").ToString()
                Shoe = Appreader.Item("App_Shoe").ToString()
                DMark = Appreader.Item("App_DMark").ToString()
                HColor = Appreader.Item("App_HColor").ToString()

                ' MsgBox(GetOAppID)

                insertInfoAMS()
                Me.Hide()

            End If

        End If

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

    Private Sub insertInfoAMS()

        Dim AppInfoIns As String
        AppInfoIns = ("INSERT INTO hunters_pooling.applicant_info(App_LName,App_FName,App_MName,App_Suffix,App_Status,App_Bday,App_ContactNo,App_LastDisembark,App_RankID,App_SuitSize,App_WaisteSize,App_ShoeSize,App_Mark,App_HairColor) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
        Dim AppInfocmd As OdbcCommand = New OdbcCommand(AppInfoIns, conn)

        AppInfocmd.Parameters.Add(New OdbcParameter("@App_LName", CType(LName, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_FName", CType(FName, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_MName", CType(Mname, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_MName", CType(" ", String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Status", CType("Applicant", String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Bday", CType(BDay.Date.ToString("yyyy-MM-dd"), Date)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_ContactNo", CType(Contact, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_LastDisembark", CType(DisembarkDatePick.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_RankID", CType(rankID, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Suit", CType(Suit, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_WaisteSize", CType(Waist, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_ShoeSize", CType(Shoe, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Mark", CType(DMark, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_HairColor", CType(HColor, String)))
        AppInfocmd.ExecuteNonQuery()
        AppInfocmd.Dispose()


        'Query for App_ID
        Dim AppIDstr As String
        AppIDstr = "SELECT App_ID FROM hunters_pooling.applicant_info ORDER BY App_ID DESC LIMIT 1;"
        Dim AppIDcommand As OdbcCommand
        AppIDcommand = New OdbcCommand(AppIDstr, conn)
        Dim AppIDmyReader As OdbcDataReader = AppIDcommand.ExecuteReader()

        While AppIDmyReader.Read
            AppIDoutput = AppIDmyReader.GetInt32(0) 'Applicant_ID value
        End While

        'insertApplicantOnlineSTATUS
        Dim onlineStat As String
        onlineStat = ("INSERT INTO web.applicant_stat(App_Status,App_onlineID,App_ID) VALUES (?,?,?)")
        Dim onlineStatcmd As OdbcCommand = New OdbcCommand(onlineStat, conn)
        onlineStatcmd.Parameters.Add(New OdbcParameter("@App_Status", CType("AMS", String)))
        onlineStatcmd.Parameters.Add(New OdbcParameter("@App_onlineID", CType(GetOAppID, String)))
        onlineStatcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
        onlineStatcmd.ExecuteNonQuery()
        onlineStatcmd.Dispose()


        'Query for OnlineApplicant
        Dim queryApp As String
        queryApp = "Select App_DateApplied  from web.applicant_info where App_ID= '" & GetOAppID & "';"
        Dim queryAppcmd As OdbcCommand
        queryAppcmd = New OdbcCommand(queryApp, conn)
        Dim Appreader As OdbcDataReader = queryAppcmd.ExecuteReader()
        Dim appliedDate As Date
        If Appreader.Read Then
            appliedDate = Appreader.Item("App_DateApplied").Date.ToString()
        End If

        'INSERTING VESSEL SOURCE POSITION  PRINCIPAL and DISEMBARK HERE
        Dim AppPosScreenSTR As String
        AppPosScreenSTR = ("INSERT INTO hunters_pooling.applicant_screening(App_RankApplied,App_Source,App_PreStatus,App_AssignedPosition,App_AssignedPrincipal,App_DateApplied, App_ID,Rank_ID) VALUES (?,?,?,?,?,?,?,?)")
        Dim AppPosSoursecmd As OdbcCommand = New OdbcCommand(AppPosScreenSTR, conn)
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_RankApplied", CType(AppPositionTxt.Text, String))) 'rank
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_Source", CType("Online Application", String))) 'source 
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_PreStatus", CType("Pre Qualified", String))) 'remarks
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_AssignedPosition", CType(AppRankCmb.Text, String))) 'Assigned Position
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_AssignedPrincipal", CType(PrincipalCmbx.Text, String))) 'principal
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_DateApplied", CType(appliedDate.Date.ToString("yyyy-MM-dd"), Date))) 'dateapplied
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
        AppRankSTRcmd.Parameters.Add(New OdbcParameter("@AppRank_Date", CType(appliedDate.Date.ToString("yyyy-MM-dd"), Date))) 'source 
        AppRankSTRcmd.Parameters.Add(New OdbcParameter("@AppHigherRank_Name", CType("", String))) 'remarks
        AppRankSTRcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String))) 'Assigned Position
        AppRankSTRcmd.ExecuteNonQuery()
        AppRankSTRcmd.Dispose()


        insertDocAMS()
    End Sub

    Private Sub insertDocAMS()
        Dim datenow As Date = Date.UtcNow
        Dim seldoc As String
        seldoc = "Select  Document_ID, AppDoc_Name ,AppDoc_Shortcut, AppDoc_No, AppDoc_DateIssued,AppDoc_DateExpired, App_DocID FROM web.applicant_doc where App_ID='" & GetOAppID & "';"
        Dim doccommand As OdbcCommand
        doccommand = New OdbcCommand(seldoc, conn)
        Dim docreader As OdbcDataReader = doccommand.ExecuteReader()



        While docreader.Read
            docid = docreader.Item("Document_ID").ToString()
            docname = docreader.Item("AppDoc_Name").ToString()
            docshortcut = docreader.Item("AppDoc_Shortcut").ToString()
            docno = docreader.Item("AppDoc_No").ToString()
            Try
                dateissued = docreader.Item("AppDoc_DateIssued").Date.ToString()
            Catch ex As Exception
                dateissued = datenow.Date.ToString()
            End Try
            dateexpired = docreader.Item("AppDoc_DateExpired").ToString()
            crewdocid = docreader.Item("App_DocID").ToString()



            'Adding new Documents
            Dim AppDocCertSTR As String
            AppDocCertSTR = ("INSERT INTO hunters_pooling.applicant_doc(AppDoc_Name,AppDoc_Shortcut,AppDoc_No,AppDoc_Status,AppDoc_DateIssued,AppDoc_DateExpired,App_ID,Document_ID) " &
                          "VALUES (?,?,?,?,?,?,?,?)")
            Dim AppDocCertcmd As OdbcCommand = New OdbcCommand(AppDocCertSTR, conn)
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_Name", CType(docname, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_Shortcut", CType(docshortcut, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_No", CType(docno, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_No", CType("ACTIVE", String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(dateissued, Date)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_DateExpired", CType(dateexpired, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType(docid, String)))
            AppDocCertcmd.ExecuteNonQuery()
            AppDocCertcmd.Dispose()




        End While

        insertSeaAMS()


    End Sub

    Private Sub insertSeaAMS()


        Dim selseastr As String
        selseastr = "SELECT App_PrincipalName , App_VesselName, App_ImportFlag , App_Nationality, App_Agency , App_Rank ,
 App_VesselType , App_Grt , App_BHP , App_DateSignedON , App_DateSignedOFF, App_Duration , App_Salary FROM web.applicant_seaservice where App_ID='" & GetOAppID & "';"
        Dim selseacmd As OdbcCommand
        selseacmd = New OdbcCommand(selseastr, conn)
        Dim selseaReader As OdbcDataReader = selseacmd.ExecuteReader()

        While selseaReader.Read
            PName = selseaReader.Item("App_PrincipalName").ToString
            VName = selseaReader.Item("App_VesselName").ToString
            Flag = selseaReader.Item("App_ImportFlag").ToString
            Nationality = selseaReader.Item("App_Nationality").ToString
            Agency = selseaReader.Item("App_Agency").ToString
            Rank = selseaReader.Item("App_Rank").ToString
            VType = selseaReader.Item("App_VesselType").ToString
            Grt = selseaReader.Item("App_Grt").ToString
            Bhp = selseaReader.Item("App_BHP").ToString
            Signedon = selseaReader.Item("App_DateSignedON").Date.ToString
            Signedoff = selseaReader.Item("App_DateSignedOFF").Date.ToString
            Duration = selseaReader.Item("App_Duration").ToString
            Salary = selseaReader.Item("App_Salary").ToString

            Dim InsertDataStr As String

            InsertDataStr = ("INSERT INTO hunters_pooling.applicant_seaservice(App_PrincipalName,App_VesselName,App_ImportFlag,App_Nationality,App_Agency,App_Rank,App_VesselType,
                                                      App_GRT,App_BHP, App_DateSignedON,App_DateSignedOFF,App_Duration,App_Salary,App_ID) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
            Dim IsrtDatacmd As OdbcCommand = New OdbcCommand(InsertDataStr, conn)

            IsrtDatacmd.Parameters.AddWithValue("@App_PrincipalName", CType(PName, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_VesselName", CType(VName, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_ImportFlag", CType(Flag, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_Nationality", CType(Nationality, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_Agency", CType(Agency, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_Rank", CType(Rank, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_VesselType", CType(VType, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_GRT", CType(Grt, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_BHP", CType(Bhp, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_DateSignedON", CType(Signedon.ToShortDateString, Date))
            IsrtDatacmd.Parameters.AddWithValue("@App_DateSignedOFF", CType(Signedoff.ToShortDateString, Date))
            IsrtDatacmd.Parameters.AddWithValue("@App_Duration", CType(Duration, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_Salary", CType(Salary, String))
            IsrtDatacmd.Parameters.AddWithValue("@App_ID", CType(AppIDoutput, String))
            IsrtDatacmd.ExecuteNonQuery()
            IsrtDatacmd.Dispose()
        End While
        insertFamily()

    End Sub


    Private Sub insertFamily()
        'Inserting Family Information
        Dim selectFam As String
        selectFam = "SELECT kin_Relation, kin_LName, kin_FName, kin_MName, kin_Bday,kin_Contact,kin_Passport FROM web.applicant_kin where App_ID='" & GetOAppID & "';"
        Dim selFamcmd As OdbcCommand
        selFamcmd = New OdbcCommand(selectFam, conn)
        Dim selFamReader As OdbcDataReader = selFamcmd.ExecuteReader()

        While selFamReader.Read()
            kinRelation = selFamReader.Item("kin_Relation").ToString
            kinLName = selFamReader.Item("kin_LName").ToString
            kinFName = selFamReader.Item("kin_FNamen").ToString
            kinMName = selFamReader.Item("kin_MName").ToString
            kinBday = selFamReader.Item("kin_Bday").Date.ToString
            kinContact = selFamReader.Item("kin_Contact").ToString
            kinPassport = selFamReader.Item("kin_Passport").ToString

            Dim insertFam As String

            insertFam = ("INSERT INTO hunters_pooling.applicant_family(appkin_Relation,appkin_LName,appkin_FName,appkin_MName,appkin_Bday,appkin_ContactNo,appkin_Status,appkin_Passport,
                                   App_ID) VALUES (?,?,?,?,?,?,?,?,?)")
            Dim insertFamcmd As OdbcCommand = New OdbcCommand(insertFam, conn)

            insertFamcmd.Parameters.AddWithValue("@appkin_Relation", CType(kinRelation, String))
            insertFamcmd.Parameters.AddWithValue("@appkin_LName", CType(kinLName, String))
            insertFamcmd.Parameters.AddWithValue("@appkin_FName", CType(kinFName, String))
            insertFamcmd.Parameters.AddWithValue("@appkin_MName", CType(kinMName, String))
            insertFamcmd.Parameters.AddWithValue("@appkin_Bday", CType(kinBday.ToShortDateString, Date))
            insertFamcmd.Parameters.AddWithValue("@appkin_ContactNo", CType(kinContact, String))
            insertFamcmd.Parameters.AddWithValue("@appkin_Status", CType("ACTIVE", String))
            insertFamcmd.Parameters.AddWithValue("@appkin_Passport", CType(kinPassport, String))
            insertFamcmd.Parameters.AddWithValue("@App_ID", CType(AppIDoutput, String))
            insertFamcmd.ExecuteNonQuery()
            insertFamcmd.Dispose()


        End While
        insertReference()
    End Sub


    Private Sub insertReference()

        Dim selRef As String
        selRef = "Select ref_Name, ref_Address, ref_CPerson, ref_CPersonNo, ref_Email, ref_Status From web.applicant_reference where App_ID='" & GetOAppID & "';"
        Dim selRefcmd As OdbcCommand
        selRefcmd = New OdbcCommand(selRef, conn)
        Dim selRefreader As OdbcDataReader = selRefcmd.ExecuteReader()

        While selRefreader.Read()
            refName = selRefreader.Item("ref_Name").ToString
            refAddress = selRefreader.Item("ref_Address").ToString
            refCPerson = selRefreader.Item("ref_CPerson").ToString
            refCPersonNo = selRefreader.Item("ref_CPersonNo").ToString
            refEmail = selRefreader.Item("ref_Email").ToString
            refStatus = selRefreader.Item("ref_Status").ToString

            Dim insertRef As String
            insertRef = ("INSERT INTO hunters_pooling.applicant_reference(Ref_Name, Ref_Address, Ref_CPerson, Ref_Number, Ref_Email, Ref_Type,
                                   App_ID) VALUES (?,?,?,?,?,?,?)")
            Dim insertRefcmd As OdbcCommand = New OdbcCommand(insertRef, conn)
            insertRefcmd.Parameters.AddWithValue("@Ref_Name", CType(refName, String))
            insertRefcmd.Parameters.AddWithValue("@Ref_Address", CType(refAddress, String))
            insertRefcmd.Parameters.AddWithValue("@Ref_CPerson", CType(refCPerson, String))
            insertRefcmd.Parameters.AddWithValue("@Ref_Number", CType(refCPersonNo, String))
            insertRefcmd.Parameters.AddWithValue("@Ref_Email", CType(refEmail, String))
            insertRefcmd.Parameters.AddWithValue("@Ref_Type", CType(refStatus, String))
            insertRefcmd.ExecuteNonQuery()
            insertRefcmd.Dispose()


        End While
        MsgBox("Applicant Succesfuly Transferrd to AMS.")

    End Sub


End Class