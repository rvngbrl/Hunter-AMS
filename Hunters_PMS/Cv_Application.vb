Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports Bunifu
Imports BunifuAnimatorNS
Imports System.Globalization
Imports Bunifu.Framework.UI
Imports Bunifu.Framework.Lib
Imports System.Drawing.Printing
Imports System.Printing
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Text
Imports System.dialogresult
Imports Gembox.Pdf


Public Class CV_APPLICATION

    Dim principalID As String
    Public Property username As String
    Public Property GetAppID As String
    Public Property rankID As String
    Public Property GetVesselID As String
    Private PageNum As Integer = 1


    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")

    Private Sub CV_APPLICATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        ' MessageBox.Show(username, "Input Error", MessageBoxButtons.OK)
        EndorsedBy.Text = username

        ApplicantID.Text = GetAppID  'app_id crew


        'Query for CREWRANk
        Dim rankstr As String
        rankstr = "SELECT Rank_ID, Rank_Fullname FROM csiaccountingdb.rank order by Rank_Fullname asc ;"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        While rankmyReader.Read
            AppRankCmbx.Items.Add(rankmyReader.GetString(1))
            rankID = rankmyReader.GetInt32(0)
        End While


        'Query for principal
        Dim principalstr As String
        principalstr = "SELECT Principal_Name FROM csiaccountingdb.payroll_schedule order by Principal_Name asc;"
        Dim principalcommand As OdbcCommand
        principalcommand = New OdbcCommand(principalstr, conn)
        Dim principalmyReader As OdbcDataReader = principalcommand.ExecuteReader()
        While principalmyReader.Read
            AppPrincipalCmbx.Items.Add(principalmyReader.GetString(0))
        End While











        Dim getStat As String
        getStat = " Select  App_AssignedPosition, App_AssignedPrincipal , App_Source FROM hunters_pooling.applicant_info ai
   Left JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID  Where ai.App_ID= " & GetAppID & ";"
        Dim getStatcommand As OdbcCommand
        getStatcommand = New OdbcCommand(getStat, conn)
        Dim getStatreader As OdbcDataReader = getStatcommand.ExecuteReader()

        If getStatreader.Read Then

            'position = getStatreader.Item(0).ToString
            'status = getStatreader.Item(1).ToString
            'remarks = getStatreader.Item(2).ToString

            AppRankCmbx.Text = getStatreader.Item("App_AssignedPosition").ToString
            AppPrincipalCmbx.Text = getStatreader.Item("App_AssignedPrincipal").ToString
            Sourcetxt.Text = getStatreader.Item("App_Source").ToString

        End If



    End Sub


    Public Sub Endorse()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Dim datenow As Date = Date.UtcNow
        'MessageBox.Show(datenow.ToString("d"), "datenow", MessageBoxButtons.OK)

        Dim position, status, remarks As String




        ''Insert Info
        'Dim EndroseStr As String
        'EndroseStr = ("INSERT INTO hunters_pooling.applicant_endorse(RepsEndorser,AppStatus,AppPrincipalEndorse,AppDateEndorse,App_ID) VALUES (?,?,?,?,?)")
        'Dim Endorsecmd As OdbcCommand = New OdbcCommand(EndroseStr, conn)
        'Endorsecmd.Parameters.Add(New OdbcParameter("@RepsEndorser", CType(EndorsedBy.Text, String)))
        'Endorsecmd.Parameters.Add(New OdbcParameter("@AppStatus", CType(status, String)))
        'Endorsecmd.Parameters.Add(New OdbcParameter("@AppPrincipalEndorse", CType(AppPrincipalCmbx.Text, String)))
        'Endorsecmd.Parameters.Add(New OdbcParameter("@AppDateEndorse", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))
        'Endorsecmd.Parameters.Add(New OdbcParameter("@App_ID", CType(appID, String)))
        'Endorsecmd.ExecuteNonQuery()
        'Endorsecmd.Dispose()

        'MessageBox.Show("SAVE")
    End Sub

    Public Sub Endorsed_Data()
        Dim datenow As Date = Date.UtcNow 'datenow

        'getting app_rankID
        Dim GetRank As String

        '/////////////////////////////////////////INSERTING RANK///////////////////////////////////////
        'insert_applicant vesselassign
        Dim RankStr As String
        RankStr = ("INSERT INTO hunters_pooling.applicant_rank(AppRank_ID ,AppRank_Name, AppRank_Date, AppHigherRank_Name,App_ID) VALUES (?,?,?,?,?)")
        Dim Rankcmd As OdbcCommand = New OdbcCommand(RankStr, conn)
        Rankcmd.Parameters.Add(New OdbcParameter("@AppRank_ID", CType(rankID, String)))
        Rankcmd.Parameters.Add(New OdbcParameter("@AppRank_Name", CType(AppRankCmbx.Text, String)))
        Rankcmd.Parameters.Add(New OdbcParameter("@AppRank_Date", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))
        Rankcmd.Parameters.Add(New OdbcParameter("@AppHigherRank_Name", CType(HigherText.Text, String))) 'Okay na
        Rankcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))
        Try
            Rankcmd.ExecuteNonQuery()
            Rankcmd.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\INSERTING RANK\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        '////////////////////////////////////////update_current-status in app_info///////////////////////////////////////

        'update_applicant vesselassign
        Dim updatestatstr As String
        updatestatstr = " Update hunters_pooling.applicant_info SET App_CurrentStatus= 'Endorsed',
    App_RankID ='" & rankID & "'
            WHERE App_ID='" & GetAppID & "'; "
        Dim updatestatcmd As OdbcCommand = New OdbcCommand(updatestatstr, conn)
        Try
            updatestatcmd.ExecuteNonQuery()
            updatestatcmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\update_current-status in app_info\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        '////////////////////////////////////////update_app_availabity///////////////////////////////////////

        'update_applicant vesselassign
        Dim updateavstr As String
        updateavstr = " Update hunters_pooling.applicant_screening SET App_Availability= '" & Availabilitytxt.Text & "',
App_AssignedPosition= '" & AppRankCmbx.Text & "',
App_AssignedPrincipal = '" & AppPrincipalCmbx.Text & "',
            App_DateEndorsed ='" & datenow.Date.ToString("yyyy-MM-dd") & "' 
            WHERE App_ID='" & GetAppID & "'; "
        Dim updateavcmd As OdbcCommand = New OdbcCommand(updateavstr, conn)

        Try
            updateavcmd.ExecuteNonQuery()
            updateavcmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\update_app_availabity/\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        '///////////////////////////////////////app_endorse///////////////////////////////////////
        Dim CVRankStr As String
        CVRankStr = ("INSERT INTO hunters_pooling.applicant_endorse(RepsEndorser,AppStatus,AppPrincipalEndorse,
                      AppDateEndorse,App_RankID,App_ID) VALUES (?,?,?,?,?,?)")
        Dim CVRankcmd As OdbcCommand = New OdbcCommand(CVRankStr, conn)
        CVRankcmd.Parameters.Add(New OdbcParameter("@RepsEndorser", CType(EndorsedBy.Text, String)))
        CVRankcmd.Parameters.Add(New OdbcParameter("@AppStatus", CType("Endorsed", String)))
        CVRankcmd.Parameters.Add(New OdbcParameter("@AppPrincipalEndorse", CType(AppPrincipalCmbx.Text, String)))
        CVRankcmd.Parameters.Add(New OdbcParameter("@AppDateEndorse", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))
        CVRankcmd.Parameters.Add(New OdbcParameter("@App_RankID", CType(rankID, String)))
        CVRankcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))

        Try
            CVRankcmd.ExecuteNonQuery()
            CVRankcmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim checkHigherRank As String
        If CheckboxContainer.Checked = True Then
            checkHigherRank = HigherText.Text
        Else
            checkHigherRank = ""
        End If
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\app_endorse\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\








        '////////////////////////////////////////vessel_assign///////////////////////////////////////
        'Query for App_ID
        Dim checkID As String
        Dim appIDstr As String

        appIDstr = "SELECT  App_ID FROM hunters_pooling.applicant_vesselassign where App_ID = '" & GetAppID & "';"
        Dim appIDcommand As OdbcCommand
        appIDcommand = New OdbcCommand(appIDstr, conn)
        Dim appIDReader As OdbcDataReader = appIDcommand.ExecuteReader()

        While appIDReader.Read
            checkID = appIDReader.GetInt32(0)

        End While
        If checkID = GetAppID Then
            'update_applicant vesselassign
            Dim updatevesselstr As String
            updatevesselstr = " Update hunters_pooling.applicant_vesselassign SET APrincipal= '" & AppPrincipalCmbx.Text & "', 
            APrincipal_ID ='" & principalIDlabel.Text & "', 
            AVessel ='" & AppVesselCmbx.Text & "',
            AVessel_ID ='" & vesselID.Text & "',  
            AVessel_AssignDate ='" & datenow.Date.ToString("yyyy-MM-dd") & "' 
            WHERE App_ID='" & GetAppID & "'; "
            Dim updatevesselcmd As OdbcCommand = New OdbcCommand(updatevesselstr, conn)

            Try
                updatevesselcmd.ExecuteNonQuery()
                updatevesselcmd.Dispose()
                MessageBox.Show("Data Updated")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Else
            'insert_applicant vesselassign
            Dim VessAsiStr As String
            VessAsiStr = ("INSERT INTO hunters_pooling.applicant_vesselassign(APrincipal,APrincipal_ID,AVessel,AVessel_ID,AVessel_AssignDate,App_ID) VALUES (?,?,?,?,?,?)")
            Dim VessAsicmd As OdbcCommand = New OdbcCommand(VessAsiStr, conn)
            VessAsicmd.Parameters.Add(New OdbcParameter("@APrincipal", CType(AppPrincipalCmbx.Text, String)))
            VessAsicmd.Parameters.Add(New OdbcParameter("@APrincipal_ID", CType(principalIDlabel.Text, String)))
            VessAsicmd.Parameters.Add(New OdbcParameter("@AVessel", CType(AppVesselCmbx.Text, String)))
            VessAsicmd.Parameters.Add(New OdbcParameter("@AVessel_ID", CType(vesselID.Text, String))) 'Okay na
            VessAsicmd.Parameters.Add(New OdbcParameter("@AVessel_AssignDate", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))
            VessAsicmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))
            Try
                VessAsicmd.ExecuteNonQuery()
                VessAsicmd.Dispose()

            Catch ex As Exception

                MessageBox.Show(ex.Message)
            End Try

        End If
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\vessel_assign\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\











        '/////////////////////////////////////////dito sunod///////////////////////////////////////
        'insert_CVdata in screening 'Availability and Source
        'Dim AvsStr As String
        'AvsStr = ("INSERT INTO hunters_pooling.applicant_screening(App_Availability,App_Source,App_DateEndorsed,App_ID) VALUES (?,?,?)")
        'Dim AvsStrcmd As OdbcCommand = New OdbcCommand(AvsStr, conn)
        'AvsStrcmd.Parameters.Add(New OdbcParameter("@App_Availability", CType(Availabilitytxt.Text, String)))
        'AvsStrcmd.Parameters.Add(New OdbcParameter("@App_Source", CType(Sourcetxt.Text, String))) ''pede update
        'AvsStrcmd.Parameters.Add(New OdbcParameter("@App_DateEndorsed", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))
        'AvsStrcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(ApplicantID.Text, String)))

    End Sub
    Private Sub Checker()
        'Checking ng system sa mga hindi nafill-up-an
        If AppRankCmbx.Text.Equals("") Then
            MessageBox.Show("Please select Rank", "Input Error", MessageBoxButtons.OK)
            AppRankCmbx.Focus()
            Exit Sub

        ElseIf AppPrincipalCmbx.Text.Equals("") Then
            MessageBox.Show("Please select Principal", "Input Error", MessageBoxButtons.OK)
            AppPrincipalCmbx.Focus()
            Exit Sub

        Else
            Try
                Endorsed_Data()
                conn.Close()
                MessageBox.Show("The Applicants is now Endorsed to: " + AppPrincipalCmbx.Text, "Applicant Status", MessageBoxButtons.OK)

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try

        End If


    End Sub

    Private Sub EndorsedBTN_Click(sender As Object, e As EventArgs) Handles EndorsedBTN.Click

        ''dito lagay yung vessel_assign
        'Query for App_ID
        Dim checkedID As String
        Dim appIDstr As String

        appIDstr = "SELECT  App_ID FROM hunters_pooling.applicant_vesselassign where App_ID = '" & GetAppID & "';"
        Dim appIDcommand As OdbcCommand
        appIDcommand = New OdbcCommand(appIDstr, conn)
        Dim appIDReader As OdbcDataReader = appIDcommand.ExecuteReader()

        While appIDReader.Read
            checkedID = appIDReader.GetInt32(0)

        End While




        If AppVesselCmbx.SelectedIndex = -1 Then
            MsgBox("Please Select Vessel")
        Else
            Checker()
            Me.Hide()
        End If

    End Sub

    Private Sub BunifuImageButton4_Click(sender As Object, e As EventArgs) Handles BunifuImageButton4.Click
        Me.Close()


    End Sub

    Private Sub AppPrincipalCmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppPrincipalCmbx.SelectedIndexChanged

        'Query for principal
        Dim principalstr As String
        principalstr = "SELECT Principal_ID FROM csiaccountingdb.payroll_schedule WHERE Principal_Name = '" & AppPrincipalCmbx.SelectedItem & "';"
            Dim principalcommand As OdbcCommand
        principalcommand = New OdbcCommand(principalstr, conn)
        Dim principalmyReader As OdbcDataReader = principalcommand.ExecuteReader()
        While principalmyReader.Read
            principalIDlabel.Text = principalmyReader.GetInt32(0)

        End While

        AppVesselCmbx.Items.Clear()

        Dim vesselID As String
        'Query for vessel
        Dim vesselstr As String
        vesselstr = "SELECT Vessel_Name FROM csiaccountingdb.vessel where Vessel_Status = 'ACTIVE' and Principal_ID = '" & principalIDlabel.Text & "';"
        Dim vesselcommand As OdbcCommand
        vesselcommand = New OdbcCommand(vesselstr, conn)
        Dim vesselmyReader As OdbcDataReader = vesselcommand.ExecuteReader()
        While vesselmyReader.Read
            AppVesselCmbx.Items.Add(vesselmyReader.GetString(0))
        End While

    End Sub

    Private Sub AppRankCmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppRankCmbx.SelectedIndexChanged
        'Query for CREWRANk
        Dim rankstr As String
        rankstr = "SELECT Rank_ID FROM csiaccountingdb.rank where Rank_Fullname= '" & AppRankCmbx.Text & "';"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        If rankmyReader.Read Then
            ' AppLName.Text = rankmyReader.Item(0).ToString
            rankID = rankmyReader.Item(0).ToString
        End If

    End Sub

    Private Sub AppVesselCmbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppVesselCmbx.SelectedIndexChanged
        MessageBox.Show(principalIDlabel.Text)
        'Query for vessel
        Dim vesselstr As String
        vesselstr = "SELECT Vessel_ID, Vessel_Name FROM csiaccountingdb.vessel where vessel_Status = 'ACTIVE' and Vessel_Name ='" & AppVesselCmbx.Text & "' ORDER BY Vessel_Name desc  ;"
        Dim vesselcmd As OdbcCommand
        vesselcmd = New OdbcCommand(vesselstr, conn)
        Dim vesselReader As OdbcDataReader = vesselcmd.ExecuteReader()
        While vesselReader.Read
            GetVesselID = vesselReader.Item(0).ToString
            vesselID.Text = vesselReader.Item(0).ToString
            'ditomali AppVesselCmbx.Items.Add(vesselReader.GetString(0))
            AppVesselCmbx.Items.Add(vesselReader.GetString(1))
        End While

        If AppPrincipalCmbx.Text.Equals("") Then
            AppVesselCmbx.Enabled = False
        Else
            AppVesselCmbx.Enabled = True

        End If










    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles CvPrint.PrintPage




        'drawing ng text
        'x, y
        Dim Font As New Font("Arial", 10, FontStyle.Regular)

        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)

        Dim FontMID As New Font("Arial", 12, FontStyle.Regular)
        Select Case PageNum

            Case 1

                Dim path As String = "C:\Users\Arvin Trinidad\source\repos\Hunters_PMS\Hunters_PMS\Resource\CV_APPLICATION_01.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                e.Graphics.DrawImage(newImage, e.PageBounds)

                'APPLIEDDATEPOSITION
                e.Graphics.DrawString("IT COORDINATOR", Font, Brushes.Black, 230, 174) 'pOSITIONaPPLIED
                e.Graphics.DrawString("JUNE 28 2018", Font, Brushes.Black, 640, 174) 'DATEAPPLIED

                'PERSONALINFO
                e.Graphics.DrawString("Trinidad", Font, Brushes.Black, 170, 194) 'lname
                e.Graphics.DrawString("Arvin Gabriel", Font, Brushes.Black, 400, 194) 'fname
                e.Graphics.DrawString("Roque", Font, Brushes.Black, 620, 194) 'mname
                e.Graphics.DrawString("San Roque Macabebe Pampanga", Font, Brushes.Black, 130, 220)
                e.Graphics.DrawString("09951319199", Font, Brushes.Black, 190, 240) 'no1
                e.Graphics.DrawString("09951618499", Font, Brushes.Black, 190, 258) 'no2
                e.Graphics.DrawString("July 31, 1998", Font, Brushes.Black, 540, 240) 'DATEBIRTH
                e.Graphics.DrawString("21", Font, Brushes.Black, 690, 240) 'age
                e.Graphics.DrawString("Arayat", Font, Brushes.Black, 500, 258) 'placeBIRTH
                e.Graphics.DrawString("arvingabriel7@gmail.com", Font, Brushes.Black, 190, 271) 'EMAILADD
                e.Graphics.DrawString("Single", Font, Brushes.Black, 690, 258) 'cvstatus
                e.Graphics.DrawString("Roman Catholic", Font, Brushes.Black, 480, 271) 'religion
                e.Graphics.DrawString("aaaaaaaaaaaaaaaaaaaaaaaa", Font, Brushes.Black, 180, 290) 'wifename
                e.Graphics.DrawString("0995131919965", Font, Brushes.Black, 480, 290) 'wifeno
                e.Graphics.DrawString("ugsdfuiweghruiweiur", Font, Brushes.Black, 180, 310) 'mothersname
                e.Graphics.DrawString("0995131919965", Font, Brushes.Black, 480, 310) 'motherno
                e.Graphics.DrawString("0458renj589f", Font, Brushes.Black, 180, 325) 'skypeid
                e.Graphics.DrawString("0rujnu^*op3", Font, Brushes.Black, 480, 325) 'whatsappid
                'PHYSICAL DETAILS
                e.Graphics.DrawString("526", Font, Brushes.Black, 108, 365) 'HEIGHT
                e.Graphics.DrawString("52", Font, Brushes.Black, 225, 365) 'WEIGHT
                e.Graphics.DrawString("M", Font, Brushes.Black, 480, 365) 'CSIZE
                e.Graphics.DrawString("10", Font, Brushes.Black, 690, 365) 'SHOESIZE
                e.Graphics.DrawString("yellow", Font, Brushes.Black, 138, 380) 'eyecolor
                e.Graphics.DrawString("brownx", Font, Brushes.Black, 290, 380) 'haircolor
                e.Graphics.DrawString("mole on lips", Font, Brushes.Black, 495, 380) 'dmark
                e.Graphics.DrawString("30", Font, Brushes.Black, 650, 380) 'waistline


                'EDUCATION
                e.Graphics.DrawString("Pampanga Colleges", Font, Brushes.Black, 215, 436) 'highschool
                e.Graphics.DrawString("2014", Font, Brushes.Black, 425, 436) 'highschoolfrom
                e.Graphics.DrawString("2018", Font, Brushes.Black, 520, 436) 'highschoolto
                e.Graphics.DrawString("HighSchool Graduate", Font, Brushes.Black, 590, 436) 'highschooldiploma

                e.Graphics.DrawString("Tesda", Font, Brushes.Black, 215, 451) 'vocationalschool
                e.Graphics.DrawString("2015", Font, Brushes.Black, 425, 451) 'vocationalfrom
                e.Graphics.DrawString("2016", Font, Brushes.Black, 520, 451) 'vocationalto
                e.Graphics.DrawString("Tesda Cert", Font, Brushes.Black, 590, 451) 'vocationaldiploma


                e.Graphics.DrawString("BSU", Font, Brushes.Black, 215, 468) 'college
                e.Graphics.DrawString("2014", Font, Brushes.Black, 425, 468) 'collegefrom
                e.Graphics.DrawString("2018", Font, Brushes.Black, 520, 468) 'collegeto
                e.Graphics.DrawString("BS MATH", Font, Brushes.Black, 590, 468) 'collegediploma

                'LICENSES AND OTHER REQUIRED DOCS
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 280, 522) 'PSBNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 522) 'PSBrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 522) 'PSBissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 522) 'PSBexpired

                e.Graphics.DrawString("123456B", Font, Brushes.Black, 280, 538) 'SRCNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 538) 'SRCrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 538) 'SRCissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 538) 'SRCexpired

                e.Graphics.DrawString("123456C", Font, Brushes.Black, 280, 553) 'PASSPORTNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 553) 'PASSPORTrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 553) 'PASSPORTissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 553) 'PASSPORTexpired

                e.Graphics.DrawString("123456D", Font, Brushes.Black, 280, 568) 'PHILLICENSENO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 568) 'PHILLICENSrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 568) 'PHILLICENSeissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 568) 'PHILLICENSexpired

                e.Graphics.DrawString("123456E", Font, Brushes.Black, 280, 585) 'COCMARINANO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 585) 'COCMARINArank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 585) 'COCMARINAeissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 585) 'COCMARINAexpired

                e.Graphics.DrawString("123456F", Font, Brushes.Black, 280, 600) 'ENDORSEMENTMARINANO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 600) 'ENDORSEMENTMARINAArank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 600) 'ENDORSEMENTMARINAissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 600) 'ENDORSEMENTMARINAexpired

                e.Graphics.DrawString("123456G", Font, Brushes.Black, 280, 616) 'GOCLICENO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 616) 'GOCLICErank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 616) 'GOCLICEissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 616) 'GOCLICEexpired

                e.Graphics.DrawString("123456H", Font, Brushes.Black, 280, 631) 'DECKCOCNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 631) 'DECKCOCrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 631) 'DECKCOCissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 631) 'DECKCOCexpired

                e.Graphics.DrawString("123456I", Font, Brushes.Black, 280, 647) 'FULLDPNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 647) 'FULLDPrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 647) 'FULLDPissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 647) 'FULLDPexpired

                e.Graphics.DrawString("123456J", Font, Brushes.Black, 280, 663) 'BASICDPNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 663) 'BASICDPrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 663) 'BASICDPissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 663) 'BASICDPexpired

                e.Graphics.DrawString("123456K", Font, Brushes.Black, 280, 679) 'ADVANCEDPNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 679) 'ADVANCEDPrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 679) 'ADVANCEDPissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 679) 'ADVANCEDPexpired

                e.Graphics.DrawString("123456L", Font, Brushes.Black, 280, 694) 'DPMCERTNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 694) 'DPMCERTPrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 694) 'DPMCERTPissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 694) 'DPMCERTexpired

                e.Graphics.DrawString("123456M", Font, Brushes.Black, 280, 712) 'PILOTEXCEPTIONNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 712) 'PILOTEXCEPTIONrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 712) 'PILOTEXCEPTIONissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 712) 'PILOTEXCEPTIONexpired

                e.Graphics.DrawString("123456N", Font, Brushes.Black, 280, 729) 'YELLOWFEVERNO
                e.Graphics.DrawString("12345A", Font, Brushes.Black, 425, 729) 'YELLOWFEVERrank
                e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 729) 'YELLOWFEVERissued
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 729) 'YELLOWFEVERexpired

                'VISA/LOGBOOK
                e.Graphics.DrawString("123456M", Font, Brushes.Black, 190, 782) 'USVISANO
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 305, 782) 'USVISAEXPIRY

                e.Graphics.DrawString("123456M", Font, Brushes.Black, 190, 799) 'SCHEVISANO
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 305, 799) 'SCHEVISAEXPIRY

                e.Graphics.DrawString("123456M", Font, Brushes.Black, 190, 816) 'BRUVISANO
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 305, 816) 'SCHEVISAEXPIRY

                e.Graphics.DrawString("123456M", Font, Brushes.Black, 190, 831) 'NIGEVISANO
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 305, 831) 'NIGEVISAEXPIRY

                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 615, 782) 'DPLBISSUE
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 615, 799) 'IMCAISSUE
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 615, 816) 'CRNOPISSUE
                e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 615, 831) 'NISISSUE


                'FAMILY BACKGROUND
                'WIFE
                e.Graphics.DrawString("Bbb Cccccccc", Font, Brushes.Black, 137, 888) 'WIFENAME
                e.Graphics.DrawString("July 16 1997", Font, Brushes.Black, 288, 888) 'WIFEbirth
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 888) 'WIFEpassport
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 888) 'WIFEdateissued
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 888) 'WIFEdateEXPIRED
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 888) 'WIFEPLACEISSUE

                'CHILD1
                e.Graphics.DrawString("ALEX BBBBBB", Font, Brushes.Black, 137, 922) 'CHILD1NAME  'M
                e.Graphics.DrawString("July 16 2027", Font, Brushes.Black, 288, 922) 'CHILD1BIRTH  'M
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 922) 'CHILD1PASSPORT  'M
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 922) 'CHILD1issued 'M
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 922) ''CHILD1EXPIRED  'M
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 922) 'CHILD1ISSUED  'M

                e.Graphics.DrawString("ALEX BBBBBB", Font, Brushes.Black, 137, 938) 'CHILD1NAME  'F
                e.Graphics.DrawString("July 16 2027", Font, Brushes.Black, 288, 938) 'CHILD1BIRTH  'F
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 938) 'CHILD1PASSPORT  'F
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 938) 'CHILD1issued 'F
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 938) ''CHILD1EXPIRED  'F
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 938) 'CHILD1ISSUED  'F

                'CHILD2
                e.Graphics.DrawString("ALEX BBBBBB", Font, Brushes.Black, 137, 954) 'CHILD2NAME  'M
                e.Graphics.DrawString("July 16 2027", Font, Brushes.Black, 288, 954) 'CHILD2BIRTH  'M
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 954) 'CHILD2PASSPORT  'M
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 954) 'CHILD2issued 'M
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 954) ''CHILD12XPIRED  'M
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 954) 'CHILD2ISSUED  'M


                e.Graphics.DrawString("ALEX BBBBBB", Font, Brushes.Black, 137, 971) 'CHILD2NAME  'F
                e.Graphics.DrawString("July 16 2027", Font, Brushes.Black, 288, 971) 'CHILD2BIRTH  'F
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 971) 'CHILD2PASSPORT  'F
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 971) 'CHILD2issued 'F
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 971) ''CHILD12XPIRED  'F
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 971) 'CHILD2ISSUED  'F

                'CHILD3
                e.Graphics.DrawString("ALEX BBBBBB", Font, Brushes.Black, 137, 987) 'CHILD3NAME  'M
                e.Graphics.DrawString("July 16 2027", Font, Brushes.Black, 288, 987) 'CHILD2BIRTH  'M
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 987) 'CHILD2PASSPORT  'M
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 987) 'CHILD2issued 'M
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 987) ''CHILD12XPIRED  'M
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 987) 'CHILD2ISSUED  'M

                e.Graphics.DrawString("ALEX BBBBBB", Font, Brushes.Black, 137, 1003) 'CHILD3NAME  'F
                e.Graphics.DrawString("July 16 2027", Font, Brushes.Black, 288, 1003) 'CHILD2BIRTH  'F
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 1003) 'CHILD2PASSPORT  'F
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 1003) 'CHILD2issued 'F
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 1003) ''CHILD12XPIRED  'F
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 1003) 'CHILD2ISSUED  'F

                'CHILD4
                e.Graphics.DrawString("ALEX BBBBBB", Font, Brushes.Black, 137, 1019) 'CHILD4NAME  'M
                e.Graphics.DrawString("July 16 2027", Font, Brushes.Black, 288, 1019) 'CHILD2BIRTH  'M
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 1019) 'CHILD2PASSPORT  'M
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 1019) 'CHILD2issued 'M
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 1019) ''CHILD12XPIRED  'M
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 1019) 'CHILD2ISSUED  'M

                e.Graphics.DrawString("ALEX BBBBBB", Font, Brushes.Black, 137, 1036) 'CHILD4NAME  'F
                e.Graphics.DrawString("July 16 2027", Font, Brushes.Black, 288, 1036) 'CHILD2BIRTH  'F
                e.Graphics.DrawString("HG08KDO", Font, Brushes.Black, 383, 1036) 'CHILD2PASSPORT  'F
                e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 475, 1036) 'CHILD2issued 'F
                e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 555, 1036) ''CHILD12XPIRED  'F
                e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 645, 1036) 'CHILD2ISSUED  'F

                e.HasMorePages = True

            Case 2
                ' Dim path2 As String = "F:\Crystal_Files\PMS ICONS\Crew_Application_Page_03_Page_1.jpg" 'pathfile
                ' Dim newImage2 As Image = Image.FromFile(path2) 'read image
                ' e.Graphics.DrawImage(e.PageBounds)
                'TRAINING CERT LIST

                Dim certstr As String

                certstr = "Select AppCert_Name, AppCert_No,  AppCert_DateIssued, AppCert_Place,AppCert_DateExpired FROM hunters_pooling.applicant_cert where App_ID='" & GetAppID & "';"
                Dim certcommand As OdbcCommand
                certcommand = New OdbcCommand(certstr, conn)
                Dim certreader As OdbcDataReader = certcommand.ExecuteReader()


                Dim y As Integer = 113
                Dim yrec As Integer = 110


                Dim myPen As Pen = New Pen(Drawing.Color.Black, 2)
                Dim bg As SolidBrush = New SolidBrush(Color.Aqua)

                ' DrawRectangle(myPen, X, Y, width, height)
                e.Graphics.DrawRectangle(myPen, 30, 50, 770, 30)
                e.Graphics.DrawString("TRAINING CERTIFICATE", FontTitle, Brushes.Black, 320, 60)
                e.Graphics.DrawRectangle(myPen, 30, 80, 200, 30)
                e.Graphics.DrawString("Course Name", FontMID, Brushes.Black, 70, 85)
                e.Graphics.DrawRectangle(myPen, 230, 80, 150, 30)
                e.Graphics.DrawString("Certificate Number", Font, Brushes.Black, 250, 85)
                e.Graphics.DrawRectangle(myPen, 380, 80, 150, 30)
                e.Graphics.DrawString("Issued Date", Font, Brushes.Black, 410, 85)
                e.Graphics.DrawRectangle(myPen, 530, 80, 140, 30)
                e.Graphics.DrawString("COP Number", Font, Brushes.Black, 560, 85)
                e.Graphics.DrawRectangle(myPen, 670, 80, 130, 30)
                e.Graphics.DrawString("Validity Date", Font, Brushes.Black, 690, 85)
                Dim counter As Integer = 0

                While certreader.Read



                    'box
                    e.Graphics.DrawRectangle(myPen, 30, yrec, 200, 25)
                    e.Graphics.DrawRectangle(myPen, 230, yrec, 150, 25)
                    e.Graphics.DrawRectangle(myPen, 380, yrec, 150, 25)
                    e.Graphics.DrawRectangle(myPen, 530, yrec, 140, 25)
                    e.Graphics.DrawRectangle(myPen, 670, yrec, 130, 25)

                    'data
                    e.Graphics.DrawString(certreader.Item(0).ToString(), FontMID, Brushes.Black, 30, y)
                    e.Graphics.DrawString(certreader.Item(1).ToString(), Font, Brushes.Black, 250, y)

                    e.Graphics.DrawString(certreader.GetDate(2).ToString("MM-dd-yyyy"), Font, Brushes.Black, 410, y)
                    e.Graphics.DrawString(certreader.Item(3).ToString, Font, Brushes.Black, 560, y)
                    e.Graphics.DrawString(certreader.GetDate(4).ToString("MM-dd-yyyy"), Font, Brushes.Black, 690, y)


                    y = y + 25
                    yrec = yrec + 25

                    If counter Mod 2 = 0 Then
                        e.Graphics.FillRectangle(bg, 30, yrec, 200, 25)
                        e.Graphics.FillRectangle(bg, 230, yrec, 150, 25)
                        e.Graphics.FillRectangle(bg, 380, yrec, 150, 25)
                        e.Graphics.FillRectangle(bg, 530, yrec, 140, 25)
                        e.Graphics.FillRectangle(bg, 670, yrec, 130, 25)
                        counter = counter + 1
                    End If





                End While


                e.HasMorePages = True

            Case 3

                e.HasMorePages = True
            Case 4
                Dim path As String = "F:\Crystal_Files\PMS ICONS\cvapplication3.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image



                ' e.Graphics.DrawImage(newImage, e.PageBounds)

                e.Graphics.DrawImage(newImage, e.PageBounds)


        End Select
        PageNum += 1











    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles CvPrintBtn.Click





        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized

        AddHandler PD.PrintPage, AddressOf PrintDocument1_PrintPage

        PPV.Show()






        ''Printing na may set up ng page
        'Dim PrintDialog1 As New PrintDialog()
        'PrintDialog1.Document = CvPrint
        'If PrintDialog1.ShowDialog(PPV) = Windows.Forms.DialogResult.OK Then

        'End If

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class