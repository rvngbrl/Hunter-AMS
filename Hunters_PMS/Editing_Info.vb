Imports System
Imports System.Data
Imports System.Data.Odbc
Imports Bunifu
Imports BunifuAnimatorNS
Imports System.Globalization
Imports System.IO
Imports System.Data.SqlClient


Public Class Editing_Info
    Public Property GetAppID As String = 1000
    Public Property UserText As String
    Public Property GetDocID As String
    Public Property GetSeaID As String
    Public Property GetNewID As String
    Public Property GetRecord As String
    Public Property GetAge As String
    Public Property GetAppDCID As String
    Public Property GetShipStat As String
    Public Property GetRefStat As String
    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")
    Dim Day, Month, year As Integer
    Dim selectedRowIndex As Integer
    Public Property GetKinStat As String = "Insert"


    Function EscapeQuote(ByVal msData As Object) As String
        Return (Replace(msData, "'", "''"))
    End Function

    Function EscapeBack(ByVal msData As Object) As String
        Return (Replace(msData, "\", "\\"))
    End Function

    Private Sub Editing_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetNewID = "New"
        AppIDIdentifier.Text = GetAppID
        Dim usertextstr As String
        usertextstr = UserText
        If Len(GetRecord) <= 0 Then
            GetRecord = "NOT"
        End If


        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim rankID As String
        'Query for Crew Name
        Dim rankstr As String
        rankstr = "SELECT Rank_ID, Rank_Fullname FROM csiaccountingdb.rank order by Rank_Fullname asc;"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        While rankmyReader.Read
            AppPosition.Items.Add(rankmyReader.GetString(1))
            rankID = rankmyReader.GetInt32(0)
        End While
        Dim AppInfo As String

        AppInfo = "SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, sc.App_AssignedPosition, ai.App_CurrentStatus,
	               ai.App_Bday, ai.App_BPlace, ad.App_Address2, YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', 
	               ai.App_Religion, ai.App_ContactNo, ai.App_EmailAdd, ai.App_Height, ai.App_Weight, sc.App_Experience, App_Source, ai.App_LastDisembark, sc.App_PreStatus,
                   ai.App_Citezenship, ad.App_ZipCode, ad.App_City, ad.App_Barangay, ad.App_Province,ad.App_Country, ad.App_CountryCode, ad.App_Street,  
                   ai.App_Sex, ai.App_Religion, ai.App_ContactNo2, ai.App_EmailAdd, ai.App_Skype, ai.App_Whatsapp, ai.App_Viber, ai.App_CivilStat, ai.App_DateMarriage, ai.App_SSSNo, ai.App_TinNo,
                   ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
                   ae.Voc_School, ae.Voc_Course, ae.Voc_To, ae.School_Name, ae.School_From, ae.School_To, Studies_Name, Studies_Course, Studies_Year,ai.App_Picture,ai.App_HairColor,App_Mark,App_FacebookName
	               FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                   LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
                   WHERE ai.App_ID = " & GetAppID & ";"


        Dim AppInfocommand As OdbcCommand
        AppInfocommand = New OdbcCommand(AppInfo, conn)

        'App_HairColor ='" & HairColor.Text & "',
        'App_Mark ='" & DMark.Text & "',
        'App_FacebookName ='" & FbUName.Text & "',
        Dim AppInforeader As OdbcDataReader = AppInfocommand.ExecuteReader()

        If AppInforeader.Read Then

            AppLName.Text = AppInforeader.Item(0).ToString
            AppFName.Text = AppInforeader.Item(1).ToString
            AppMName.Text = AppInforeader.Item(2).ToString
            AppSuffix.Text = AppInforeader.Item(3).ToString
            AppPosition.Text = AppInforeader.Item(4).ToString
            AppLastStat.Text = AppInforeader.Item(5).ToString
            AppBDay.Value = AppInforeader.Item(6).ToString
            AppBPlace.Text = AppInforeader.Item(7).ToString
            AppAddress2.Text = AppInforeader.Item(8).ToString
            AppAge.Text = AppInforeader.Item(9).ToString
            GetAge = AppInforeader.Item(9).ToString
            AppReligion.Text = AppInforeader.Item(10).ToString
            AppContact1.Text = AppInforeader.Item(11).ToString
            AppEmailAdd.Text = AppInforeader.Item(12).ToString
            AppHeight.Text = AppInforeader.Item(13).ToString
            AppWeight.Text = AppInforeader.Item(14).ToString
            AppVessel.Text = AppInforeader.Item(15).ToString
            AppSource.Text = AppInforeader.Item(16).ToString
            DisembarkDatePick.Value = AppInforeader.Item(17).ToString
            ' AppLastStat.Text = AppInforeader.Item(18).ToString
            AppCitizenship.Text = AppInforeader.Item(19).ToString
            AppZipCode.Text = AppInforeader.Item(20).ToString
            AppCity.Text = AppInforeader.Item(21).ToString
            App_Barangay.Text = AppInforeader.Item(22).ToString
            AppProvince.Text = AppInforeader.Item(23).ToString
            AppCountry.Text = AppInforeader.Item(24).ToString
            AppCountryCode.Text = AppInforeader.Item(25).ToString
            App_Strret.Text = AppInforeader.Item(26).ToString
            AppSex.Text = AppInforeader.Item(27).ToString
            AppReligion.Text = AppInforeader.Item(28).ToString
            AppContact2.Text = AppInforeader.Item(29).ToString
            AppEmailAdd.Text = AppInforeader.Item(30).ToString
            AppSkype.Text = AppInforeader.Item(31).ToString
            AppWhatsapp.Text = AppInforeader.Item(32).ToString
            AppViber.Text = AppInforeader.Item(33).ToString
            AppCivilStatusCbox.Text = AppInforeader.Item(34).ToString
            AppDateMarried.Text = AppInforeader.Item(35).ToString
            AppSSSNo.Text = AppInforeader.Item(36).ToString
            AppTinNo.Text = AppInforeader.Item(37).ToString
            AppPagIbigNo.Text = AppInforeader.Item(38).ToString
            AppPhilNo.Text = AppInforeader.Item(39).ToString
            AppShirt.Text = AppInforeader.Item(40).ToString
            AppSuit.Text = AppInforeader.Item(41).ToString
            AppWaist.Text = AppInforeader.Item(42).ToString
            AppShoe.Text = AppInforeader.Item(43).ToString
            AppEducName.Text = AppInforeader.Item(44).ToString
            AppEducCourse.Text = AppInforeader.Item(45).ToString
            AppEducTo.Text = AppInforeader.Item(46).ToString
            AppSchoolName.Text = AppInforeader.Item(47).ToString
            AppSchoolFrom.Text = AppInforeader.Item(48).ToString
            AppSchoolTo.Text = AppInforeader.Item(49).ToString
            AppStudiesName.Text = AppInforeader.Item(50).ToString
            AppStudiesCourse.Text = AppInforeader.Item(51).ToString
            AppStudiesYear.Text = AppInforeader.Item(52).ToString
            Dim filenamepic As String
            filenamepic = AppInforeader.Item(53).ToString
            Try
                PictureBox1.Image = Image.FromFile(filenamepic)
            Catch ex As Exception
            End Try
            HairColor.Text = AppInforeader.Item(54).ToString
            DMark.Text = AppInforeader.Item(55).ToString
            FbUName.Text = AppInforeader.Item(56).ToString

        End If


        Try

            If GetRecord.Equals("ApplicantEncode") Then

                AprvBtn.Visible = False
                DaprvBtn.Visible = False
                EndorsedBTN.Visible = False
                PrintCvBtn.Visible = False
                HomeBtn.Visible = False

            Else
                If AppLastStat.Text.ToLower.Equals("endorsed") Then
                    AprvBtn.Enabled = True
                    DaprvBtn.Enabled = True
                    EndorsedBTN.Enabled = False
                    PrintCvBtn.Enabled = True
                ElseIf AppLastStat.Text.ToLower.Equals("approved") Then
                    AprvBtn.Enabled = False
                    DaprvBtn.Enabled = True
                    EndorsedBTN.Enabled = False
                    PrintCvBtn.Enabled = True
                ElseIf AppLastStat.Text.ToLower.Equals("disapproved") Then
                    AprvBtn.Enabled = True
                    DaprvBtn.Enabled = False
                    EndorsedBTN.Enabled = True
                    PrintCvBtn.Enabled = False
                Else
                    AprvBtn.Enabled = False
                    DaprvBtn.Enabled = False
                    EndorsedBTN.Enabled = True
                    PrintCvBtn.Enabled = False

                End If

            End If

        Catch ex As Exception
            If AppLastStat.Text.ToLower.Equals("endorsed") Then
                AprvBtn.Enabled = True
                DaprvBtn.Enabled = True
                EndorsedBTN.Enabled = False
                PrintCvBtn.Enabled = True
            ElseIf AppLastStat.Text.ToLower.Equals("approved") Then
                AprvBtn.Enabled = False
                DaprvBtn.Enabled = True
                EndorsedBTN.Enabled = False
                PrintCvBtn.Enabled = True
            ElseIf AppLastStat.Text.ToLower.Equals("disapproved") Then
                AprvBtn.Enabled = True
                DaprvBtn.Enabled = False
                EndorsedBTN.Enabled = True
                PrintCvBtn.Enabled = False

            Else
                AprvBtn.Enabled = False
                DaprvBtn.Enabled = False
                EndorsedBTN.Enabled = True
                PrintCvBtn.Enabled = False

            End If
        End Try


        'Query for DOC_NAme
        Dim docertstr As String
        docertstr = "SELECT Document_ID, Document_Longname,Document_Shortcut,Document_Category,Document_Status FROM csiaccountingdb.document_list where Document_Status = 'ACTIVE' Order By Document_Longname ASC ;"
        Dim decertcommand As OdbcCommand
        decertcommand = New OdbcCommand(docertstr, conn)
        Dim docertmyReader As OdbcDataReader = decertcommand.ExecuteReader()

        While docertmyReader.Read
            AppGName.Items.Add(docertmyReader.GetString(1))
        End While




        'Query for country
        Dim countrystr As String
        countrystr = "SELECT country_ID, country_name FROM hunters_pooling.country_list;"
        Dim countrycommand As OdbcCommand
        countrycommand = New OdbcCommand(countrystr, conn)
        Dim countrymyReader As OdbcDataReader = countrycommand.ExecuteReader()

        While countrymyReader.Read
            AppCountryList.Items.Add(countrymyReader.GetString(1))

        End While

        DocCertView.Columns("Document_ID").Visible() = False
        DocCertView.Columns("App_CertID").Visible() = False


    End Sub



    Public Sub addcertdoc()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Query for DOC_NAme
        Dim GetDocCtgry As String
        Dim docertstr As String
        docertstr = "SELECT Document_ID, Document_Longname,Document_Shortcut,Document_Category,Document_Status FROM csiaccountingdb.document_list where Document_ID= '" & GetDocID & "';"
        Dim decertcommand As OdbcCommand
        decertcommand = New OdbcCommand(docertstr, conn)
        Dim docertmyReader As OdbcDataReader = decertcommand.ExecuteReader()

        Dim DOB As String = Nothing

        If docertmyReader.Read Then
            GetDocCtgry = docertmyReader.Item(3).ToString
        End If

        If GetDocCtgry.ToString.ToLower.Equals("cert") Then

            'Adding new Certificates
            Dim AppCertDocSTR As String
            AppCertDocSTR = ("INSERT INTO hunters_pooling.applicant_cert(AppCert_Name,AppCert_Shortcut,AppCert_No,AppCert_Place,AppCert_Country,AppCert_DateIssued,AppCert_DateExpired,AppCert_Trainingcenter,AppCert_Status,App_ID,Document_ID) " &
                       "VALUES (?,?,?,?,?,?,?,?,?,?,?)")
            Dim AppCertDoccmd As OdbcCommand = New OdbcCommand(AppCertDocSTR, conn)
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Name", CType(AppGName.SelectedItem, String)))
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Shortcut", CType(AppDocShortcut.Text, String)))
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_No", CType(doccertno.Text, String)))
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Place", CType(PlaceTxt.Text, String)))
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Country", CType(AppCountryList.Text, String)))
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_DateIssued", CType(doccertissued.Value.Date.ToString("yyyy-MM-dd"), Date)))

            If expirycbox.Checked Then

                'AppCertDoccmd.Parameters.Add(New OdbcParameter _
                '       With {.ParameterName = "@AppCert_Expired",
                '             .DbType = DbType.Date,
                '             .Value = DBNull.Value})
                AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Expired", CType(DOB, String)))


            Else
                '  AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Expired", CDate(doccertexpiry.Value.Date.ToShortDateString())))
                AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Expired", CType(doccertexpiry.Value.ToString("yyyy-MM-dd"), String)))

            End If

            AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Trainingcenter", CType(TCenterTxt.Text, String)))
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@AppCert_Status", CType(doccertStat.selectedValue, String)))
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))
            AppCertDoccmd.Parameters.Add(New OdbcParameter("@Document_ID", CType(GetDocID, String)))
            AppCertDoccmd.ExecuteNonQuery()
            AppCertDoccmd.Dispose()

        Else
            'Adding new Documents
            Dim AppDocCertSTR As String
            AppDocCertSTR = ("INSERT INTO hunters_pooling.applicant_doc(AppDoc_Name,AppDoc_Shortcut,AppDoc_No,AppDoc_Place,AppDoc_Country,AppDoc_DateIssued,AppDoc_DateExpired,AppDoc_Status,App_ID,Document_ID) " &
                          "VALUES (?,?,?,?,?,?,?,?,?,?)")
            Dim AppDocCertcmd As OdbcCommand = New OdbcCommand(AppDocCertSTR, conn)
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_Name", CType(AppGName.SelectedItem, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_Shortcut", CType(AppDocShortcut.Text, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_No", CType(doccertno.Text, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_Place", CType(PlaceTxt.Text, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_Country", CType(AppCountryList.Text, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(doccertissued.Value.Date.ToString("yyyy-MM-dd"), Date)))


            If expirycbox.Checked Then

                'AppCertDoccmd.Parameters.Add(New OdbcParameter _
                '       With {.ParameterName = "@AppCert_Expired",
                '             .DbType = DbType.Date,
                '             .Value = DBNull.Value})

                AppDocCertcmd.Parameters.Add(New OdbcParameter("@ADoc_DateExpired", CType(DOB, String)))
            Else
                AppDocCertcmd.Parameters.Add(New OdbcParameter("@ADoc_DateExpired", CType(doccertexpiry.Value.ToString("yyyy-MM-dd"), String)))

            End If
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@AppDoc_Status", CType(doccertStat.selectedValue, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))
            AppDocCertcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType(GetDocID, String)))
            AppDocCertcmd.ExecuteNonQuery()
            AppDocCertcmd.Dispose()
        End If

    End Sub

    Public Sub loadcertdoc()

        If doccertfilter.selectedValue.Equals("DOCUMENTS") Then
            'Query For DOCUMENTS
            Dim documentstr As String
            documentstr = "Select  Document_ID, AppDoc_Name AS 'TITLE', AppDoc_No AS 'NUMBER', AppDoc_Place AS 'PLACE', date_format(AppDoc_DateIssued , '%d-%b-%Y') AS 'ISSUED DATE', date_format(AppDoc_DateExpired , '%d-%b-%Y') AS 'EXPIRY DATE', App_DocID FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID=" & GetAppID & ";"
            Dim documentList As New DataTable("applicant_doc")
            Dim documentadapter As New Odbc.OdbcDataAdapter(documentstr, conn)
            documentadapter.Fill(documentList)
            DocCertView.DataSource = documentList
            documentadapter.Dispose()

            DocCertView.Columns(6).Visible() = False
            DocCertView.Columns(6).Visible() = False
            DocCertView.Columns(4).DefaultCellStyle.Format = "MM-dd-yyyy"
            DocCertView.Columns(5).DefaultCellStyle.Format = "MM-dd-yyyy"

        ElseIf doccertfilter.selectedValue.Equals("TRAINING CERTS") Then
            'Query For TRAINING CERTS
            Dim certstr As String
            certstr = "Select  Document_ID,  AppCert_Name AS 'TITLE', AppCert_No AS 'NUMBER', AppCert_Place AS 'PLACE', date_format(AppCert_DateIssued , '%d-%b-%Y')AS 'ISSUED DATE', AppCert_DateExpired  AS 'EXPIRY DATE', App_CertID FROM hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID=" & GetAppID & ";"
            Dim certList As New DataTable("applicant_cert")
            Dim certadapter As New Odbc.OdbcDataAdapter(certstr, conn)
            certadapter.Fill(certList)
            DocCertView.DataSource = certList
            certadapter.Dispose()
            DocCertView.Columns(6).Visible() = False
            DocCertView.Columns(6).Visible() = False
            DocCertView.Columns(4).DefaultCellStyle.Format = "MM-dd-yyyy"


        Else
            'ASK SIR COI
            'Query For DOC and TRAINING CERTS
            Dim docccertstr As String
            docccertstr = "Select Document_ID, AppCert_Name AS 'TITLE', AppCert_No AS 'NUMBER', AppCert_Place AS 'PLACE',  date_format(AppCert_DateIssued , '%d-%b-%Y') AS 'ISSUED DATE', AppCert_DateExpired AS 'EXPIRY DATE', App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' 
                           UNION 
                           Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, date_format(AppDoc_DateIssued , '%d-%b-%Y') , date_format(AppDoc_DateExpired , '%d-%b-%Y'), App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID = '" & GetAppID & "'; "


            Dim docccertList As New DataTable("applicant_doc")
            Dim docccertadapter As New Odbc.OdbcDataAdapter(docccertstr, conn)
            docccertadapter.Fill(docccertList)
            DocCertView.DataSource = docccertList
            docccertadapter.Dispose()





        End If

    End Sub


    Private Sub DCerts_Btn_Click(sender As Object, e As EventArgs) Handles DCerts_Btn.Click

        printdocert.Visible() = True
        SBoardT_Tab.Visible() = False
        History_Tab.Visible() = False
        AppIDIdentifier.Visible() = False
        loadcertdoc()
    End Sub

    Private Sub PInfo_Btn_Click(sender As Object, e As EventArgs) Handles PInfo_Btn.Click
        printdocert.Visible() = False
        SBoardT_Tab.Visible() = False
        History_Tab.Visible() = False
        AppIDIdentifier.Visible() = True

    End Sub

    Private Sub Closebtn_Click(sender As Object, e As EventArgs) Handles Closebtn.Click
        Me.Close()
    End Sub

    Private Sub BunifuImageButton3_Click(sender As Object, e As EventArgs) Handles HomeBtn.Click
        Me.Hide()
        MainForm.Show()
    End Sub

    Private Sub BunifuImageButton6_Click(sender As Object, e As EventArgs) Handles BunifuImageButton6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Private Sub SBoard_Btn_Click(sender As Object, e As EventArgs) Handles SBoard_Btn.Click
        '///////////////////////SHIPBOARD TAB CODE///////////////////////////////////////
        printdocert.Visible() = False
        AppIDIdentifier.Visible() = False
        SBoardT_Tab.Visible() = True
        History_Tab.Visible() = False

        GetShipStat = "Simple"

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Query For Shipboard (normal)
        Dim SbList As String
        SbList = "SELECT Seaservice_ID as 'ID',App_PrincipalName as 'Principal' ,App_VesselName as 'VesselName',App_ImportFlag as 'Flag', App_Nationality as 'Nationality', App_Agency as 'Agency', App_Rank as 'Rank', App_VesselType  as 'Vessel Type', App_GRT as 'GRT',App_EngineType as 'Engine Type', App_BHP as 'BHP',App_KW as 'KW',  date_format(App_DateSignedON , '%d-%b-%Y') AS 'Signed On',  date_format(App_DateSignedOFF , '%d-%b-%Y') AS 'Signed Off',
        App_Duration as 'Duration', App_Reason as 'Reason', App_TradingRoute as 'Route', App_Salary as 'Salary' FROM hunters_pooling.applicant_seaservice WHERE App_ID = '" & GetAppID & "';"

        Dim dvSbList As New DataTable("applicant_seaservice")
        Dim Sbadapter As New Odbc.OdbcDataAdapter(SbList, conn)
        Sbadapter.Fill(dvSbList)
        SBDGView.DataSource = dvSbList
        Sbadapter.Dispose()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        SBDGView.Columns(0).Visible() = False

    End Sub

    Private Sub AppGName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppGName.SelectedIndexChanged

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        AppDocTitle.Text = AppGName.Text
        Dim docertstr As String
        'Query For Selected Document
        docertstr = "SELECT Document_ID, Document_Shortcut FROM csiaccountingdb.document_list where Document_Status = 'ACTIVE' and Document_Longname =  '" & EscapeQuote(AppGName.Text) & "' ;"
        Dim decertcommand As OdbcCommand
        decertcommand = New OdbcCommand(docertstr, conn)
        Dim DocsCertreader As OdbcDataReader = decertcommand.ExecuteReader()
        If DocsCertreader.Read Then

            GetDocID = DocsCertreader.Item(0).ToString
            AppDocShortcut.Text = DocsCertreader.Item(1).ToString

        End If

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles EndorsedBTN.Click
        'Check Applicant Status
        If AppLastStat.Text.ToLower.Equals("endorsed") Then
            MessageBox.Show("The Applicant Sttatus Already Endorsed")

        Else
            Dim OBJ As New CV_APPLICATION
            OBJ.username = UserText
            OBJ.GetAppID = AppIDIdentifier.Text
            OBJ.Show()

        End If

    End Sub


    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click

        'Updating Applicant Information
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to save this Information?", "Update Personal Info", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            'Inserting 
            updateappinfo()
            Editing_Info_Load(Me, New System.EventArgs)
        ElseIf result = DialogResult.No Then
            MessageBox.Show("Please check the Information before saving")

        End If
    End Sub

    Private Sub updateappinfo()
        'Inserting Document and Cert
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim pool As String
        pool = "Pooling"

        If GetRecord.ToString.Equals("ApplicantEncode") Then

            Dim updateinfo As String
            updateinfo = " Update hunters_pooling.applicant_info SET App_Bday= '" & AppBDay.Value.Date.ToString("yyyy-MM-dd") & "', 
        App_BPlace ='" & AppBPlace.Text & "', 
       App_Citezenship='" & AppCitizenship.Text & "',
        App_Pool='" & pool & "',
        App_Sex ='" & AppSex.Text & "',  
        App_Religion ='" & AppReligion.Text & "',  
        App_ContactNo ='" & AppContact1.Text & "',  
        App_ContactNo2 ='" & AppContact2.Text & "',  
        App_EmailAdd ='" & AppEmailAdd.Text & "',  
        App_Skype ='" & AppSkype.Text & "',  
        App_Whatsapp = '" & AppWhatsapp.Text & "', 
        App_Viber= '" & AppViber.Text & "',
        App_CivilStat ='" & AppCivilStatusCbox.Text & "',  
        App_DateMarriage='" & AppDateMarried.Value.Date.ToString("yyyy-MM-dd") & "',
        App_Weight ='" & AppWeight.Text & "',  
        App_Height ='" & EscapeQuote(AppHeight.Text) & "',  
        App_SSSNO ='" & AppSSSNo.Text & "',  
        App_TinNo ='" & AppTinNo.Text & "',  
        App_PagibigNo ='" & AppPagIbigNo.Text & "',  
        App_PhilHealthNo ='" & AppPhilNo.Text & "',  
        App_ShirtSize ='" & AppShirt.Text & "',  
        App_SuitSize ='" & AppSuit.Text & "',  
        App_WaisteSize ='" & AppWaist.Text & "', 
        App_HairColor ='" & HairColor.Text & "',
        App_Mark ='" & DMark.Text & "',
        App_FacebookName ='" & FbUName.Text & "',
        App_ShoeSize ='" & AppShoe.Text & "'  WHERE  App_ID='" & GetAppID & "' ;  "
            Dim updatetinfocmd As OdbcCommand = New OdbcCommand(updateinfo, conn)

            Try
                updatetinfocmd.ExecuteNonQuery()
                updatetinfocmd.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        Else
            Dim updateinfo As String
            updateinfo = " Update hunters_pooling.applicant_info SET App_Bday= '" & AppBDay.Value.Date.ToString("yyyy-MM-dd") & "', 
        App_BPlace ='" & AppBPlace.Text & "', 
       App_Citezenship='" & AppCitizenship.Text & "',
        App_Sex ='" & AppSex.Text & "',  
        App_Religion ='" & AppReligion.Text & "',  
        App_ContactNo ='" & AppContact1.Text & "',  
        App_ContactNo2 ='" & AppContact2.Text & "',  
        App_EmailAdd ='" & AppEmailAdd.Text & "',  
        App_Skype ='" & AppSkype.Text & "',  
          App_Whatsapp = '" & AppWhatsapp.Text & "', 
        App_Viber= '" & AppViber.Text & "',
        App_CivilStat ='" & AppCivilStatusCbox.Text & "',  
        App_DateMarriage='" & AppDateMarried.Value.Date.ToString("yyyy-MM-dd") & "',
        App_Weight ='" & AppWeight.Text & "',  
        App_Height ='" & EscapeQuote(AppHeight.Text) & "',  
        App_SSSNO ='" & AppSSSNo.Text & "',  
        App_TinNo ='" & AppTinNo.Text & "',  
        App_PagibigNo ='" & AppPagIbigNo.Text & "',  
        App_PhilHealthNo ='" & AppPhilNo.Text & "',  
        App_ShirtSize ='" & AppShirt.Text & "',  
        App_SuitSize ='" & AppSuit.Text & "',  
        App_WaisteSize ='" & AppWaist.Text & "', 
          App_HairColor ='" & HairColor.Text & "',
        App_Mark ='" & DMark.Text & "',
        App_FacebookName ='" & FbUName.Text & "',
        App_ShoeSize ='" & AppShoe.Text & "'  WHERE  App_ID='" & GetAppID & "' ;  "
            Dim updatetinfocmd As OdbcCommand = New OdbcCommand(updateinfo, conn)

            Try
                updatetinfocmd.ExecuteNonQuery()
                updatetinfocmd.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End If


        'Query for App_ID
        Dim checkID As String
        Dim appIDstr As String
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Query Applicant Address
        appIDstr = "SELECT  App_ID FROM hunters_pooling.applicant_address where App_ID = '" & GetAppID & "';"
        Dim appIDcommand As OdbcCommand
        appIDcommand = New OdbcCommand(appIDstr, conn)
        Dim appIDReader As OdbcDataReader = appIDcommand.ExecuteReader()

        While appIDReader.Read
            checkID = appIDReader.GetInt32(0)

        End While

        If checkID = GetAppID Then
            'Applicant Address Update
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim updateaddinfo As String
            updateaddinfo = " Update hunters_pooling.applicant_address SET App_ZipCode= '" & AppZipCode.Text & "', 
        App_City ='" & AppCity.Text & "', 
        App_Barangay ='" & App_Barangay.Text & "',
        App_Province ='" & AppProvince.Text & "',  
        App_Country ='" & AppCountry.Text & "',  
        App_CountryCode ='" & AppCountryCode.Text & "',  
        App_Street ='" & App_Strret.Text & "',  
        App_Address2 ='" & AppAddress2.Text & "'  
        WHERE App_ID='" & GetAppID & "' ;  "
            Dim updateaddcmd As OdbcCommand = New OdbcCommand(updateaddinfo, conn)
            'update_address
            updateaddcmd.ExecuteNonQuery()
            updateaddcmd.Dispose()
            MessageBox.Show("The Data has been Updated")

        Else

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            'Applicant Insert Address
            Dim insertaddinfo As String
            insertaddinfo = ("INSERT INTO hunters_pooling.applicant_address(App_ZipCode, App_City, App_Barangay, App_Province, App_Country ,App_CountryCode ,App_Street ,App_Address2 ,App_ID) " &
                          "VALUES (?,?,?,?,?,?,?,?,?)")
            Dim insertaddcmd As OdbcCommand = New OdbcCommand(insertaddinfo, conn)
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_ZipCode", CType(AppZipCode.Text, String)))
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_City", CType(AppCity.Text, String)))
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_Barangay", CType(App_Barangay.Text, String)))
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_Province", CType(AppProvince.Text, String)))
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_Country", CType(AppCountry.Text, String)))
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_CountryCode", CType(AppCountryCode.Text, String)))
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_Street", CType(App_Strret.Text, String)))
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_Address2", CType(AppAddress2.Text, String)))
            insertaddcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))

            Try

                insertaddcmd.ExecuteNonQuery()
                insertaddcmd.Dispose()
                MessageBox.Show("The Data has been Updated")

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



        End If
        Dim checkeduID As String
        Dim appeduIDstr As String
        appeduIDstr = "SELECT App_ID FROM hunters_pooling.applicant_education where App_ID = '" & GetAppID & "';"
        Dim appeduIDcmd As OdbcCommand
        appeduIDcmd = New OdbcCommand(appeduIDstr, conn)
        Dim appeduReader As OdbcDataReader = appeduIDcmd.ExecuteReader()

        While appeduReader.Read
            checkeduID = appeduReader.GetInt32(0)
        End While

        If checkeduID = GetAppID Then
            'Applicant_Update Education
            Dim updateeduinfo As String
            updateeduinfo = " Update hunters_pooling.applicant_education SET Voc_School= '" & AppEducName.Text & "', 
        Voc_Course ='" & AppEducCourse.Text & "',  
        Voc_To ='" & AppEducTo.Value.Date.ToString("yyyy-MM-dd") & "',       
        School_Name ='" & AppSchoolName.Text & "',  
        School_From ='" & AppSchoolFrom.Value.Date.ToString("yyyy-MM-dd") & "',  
        School_To ='" & AppSchoolTo.Value.Date.ToString("yyyy-MM-dd") & "',  
        Studies_Name ='" & AppStudiesName.Text & "',  
        Studies_Course ='" & AppStudiesCourse.Text & "',  
        Studies_Year ='" & AppStudiesYear.Text & "' 
        WHERE App_ID='" & GetAppID & "' ;  "

            Dim updateeducmd As OdbcCommand = New OdbcCommand(updateeduinfo, conn)
            Try
                updateeducmd.ExecuteNonQuery()
                updateeducmd.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            'Applicant Insert Education 
            Dim inserteduinfo As String
            inserteduinfo = ("INSERT INTO hunters_pooling.applicant_education(Voc_School, Voc_Course, Voc_To, School_Name, School_From ,School_To ,Studies_Name ,Studies_Course ,Studies_Year ,App_ID) " &
                          "VALUES (?,?,?,?,?,?,?,?,?,?)")
            Dim inserteduinfocmd As OdbcCommand = New OdbcCommand(inserteduinfo, conn)
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@Voc_School", CType(AppEducName.Text, String)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@Voc_Course", CType(AppEducCourse.Text, String)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@Voc_To", CType(AppEducTo.Value.Date.ToString("yyyy-MM-dd"), Date)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@School_Name", CType(AppSchoolName.Text, String)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@School_From", CType(AppSchoolFrom.Value.Date.ToString("yyyy-MM-dd"), Date)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@School_To", CType(AppSchoolTo.Value.Date.ToString("yyyy-MM-dd"), Date)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@Studies_Name", CType(AppStudiesName.Text, String)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@Studies_Course", CType(AppStudiesCourse.Text, String)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@Studies_Year", CType(AppStudiesYear.Text, String)))
            inserteduinfocmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))

            Try
                inserteduinfocmd.ExecuteNonQuery()
                inserteduinfocmd.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End If


    End Sub

    Private Sub AprvBtn_Click(sender As Object, e As EventArgs) Handles AprvBtn.Click
        '////////////////update also the app endorsed status if the applicant is approved 

        Dim OBJ As New Approve_Message()
        OBJ.username = UserText
        OBJ.GetAppID = AppIDIdentifier.Text
        OBJ.Show()

    End Sub

    Private Sub BunifuFlatButton2_Click_1(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        '////////////////////////////////////////Endorsed History////////////////////////////////////////////
        'Query For Endorse_History
        Dim endorsestr As String
        GetKinStat = "Insert"

        endorsestr = "SELECT AppDateEndorse as 'Date Endorse', AppPrincipalEndorse as 'Principal',AppStatus as 'Status ',App_Remarks as 'Remarks',RepsEndorser as 'Endorser' FROM hunters_pooling.applicant_endorse where App_ID=" & GetAppID & ";"
        Dim appendrList As New DataTable("applicant_endorse")
        Dim appendradapter As New Odbc.OdbcDataAdapter(endorsestr, conn)
        appendradapter.Fill(appendrList)
        EndorseDGView.DataSource = appendrList
        appendradapter.Dispose()

        History_Tab.Visible() = True
        printdocert.Visible() = False
        AppIDIdentifier.Visible() = False

        SBoardT_Tab.Visible() = False
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\Endorsed History\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        '////////////////////////////////////////familyinfo////////////////////////////////////////////
        Dim kinstr As String
        kinstr = "SELECT appkin_ID as 'ID', CONCAT(appkin_LName, ', ',appkin_FName,' ', appkin_Mname,' ', appkin_Suffix) AS 'Name',appkin_Relation as 'Relation'  FROM hunters_pooling.applicant_family where App_ID=" & GetAppID & ";"
        Dim kinList As New DataTable("applicant_family")
        Dim kinadapter As New Odbc.OdbcDataAdapter(kinstr, conn)
        kinadapter.Fill(kinList)
        FamilyInfoDGView.DataSource = kinList
        kinadapter.Dispose()


        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\familyinfo\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\




    End Sub





    Private Sub SBSaveBtn_Click(sender As Object, e As EventArgs) Handles SBSaveBtn.Click

        'select the next row for 
        Me.SBDGView.CurrentCell = Me.SBDGView(1, Me.SBDGView.NewRowIndex)


        ''Validate Status First 

        If GetShipStat.Equals("Simple") Then




            'INSERTING SHIPBOARD Expi
            Dim InsertDataStr As String
            Dim UpdateDataStr As String

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            'Query for count row of SeaService
            Dim SSstr As String
            SSstr = "SELECT COUNT(*) FROM hunters_pooling.applicant_seaservice WHERE App_ID = '" & GetAppID & "' ;"
            Dim SScommand As OdbcCommand
            SScommand = New OdbcCommand(SSstr, conn)
            Dim SSmyReader As OdbcDataReader = SScommand.ExecuteReader()
            Dim sscounter As String
            If SSmyReader.Read Then
                sscounter = SSmyReader.GetInt32(0)
            End If



            Dim i As Integer = SBDGView.Rows.Count - 1

            If i = sscounter Then

                Dim row As New DataGridViewRow()
                row = SBDGView.Rows(selectedRowIndex)

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dim datein, dateout As Date


                '& doccertissued.Value.Date.ToString("yyyy-MM-dd") & "',
                Try
                    datein = Convert.ToDateTime(conDate1.ToString("yyyy-MM-dd")).ToShortDateString
                    dateout = Convert.ToDateTime(conDate2.ToString("yyyy-MM-dd")).ToShortDateString
                    UpdateDataStr = " Update hunters_pooling.applicant_seaservice SET App_PrincipalName= '" & row.Cells(1).Value.ToString() & "',
                        App_VesselName ='" & row.Cells(2).Value.ToString() & "', 
                      App_ImportFlag='" & row.Cells(3).Value.ToString() & "',
                       App_Nationality='" & row.Cells(4).Value.ToString() & "', 
                        App_Agency='" & row.Cells(5).Value.ToString() & "',
                       App_Rank='" & row.Cells(6).Value.ToString() & "',
                         App_VesselType ='" & row.Cells(7).Value.ToString() & "', 
                   App_GRT='" & row.Cells(8).Value.ToString() & "',
                       App_EngineType='" & row.Cells(9).Value.ToString() & "', 
                       App_BHP='" & row.Cells(10).Value.ToString() & "',
                      App_KW='" & row.Cells(11).Value.ToString() & "',     
                   App_DateSignedOn='" & datein.ToString("yyyy-MM-dd") & "',  
                  App_DateSignedOff='" & dateout.ToString("yyyy-MM-dd") & "', 
                 App_Duration='" & row.Cells(14).Value.ToString() & "',
                      App_Reason='" & row.Cells(15).Value.ToString() & "', 
                     App_TradingRoute='" & row.Cells(16).Value.ToString() & "',
                    App_Salary='" & row.Cells(17).Value.ToString() & "'
                        WHERE  App_ID='" & GetAppID & "' and Seaservice_ID ='" & GetSeaID & "';  "
                Catch


                    UpdateDataStr = " Update hunters_pooling.applicant_seaservice SET App_PrincipalName= '" & row.Cells(1).Value.ToString() & "',
                        App_VesselName ='" & row.Cells(2).Value.ToString() & "', 
                      App_ImportFlag='" & row.Cells(3).Value.ToString() & "',
                       App_Nationality='" & row.Cells(4).Value.ToString() & "', 
                        App_Agency='" & row.Cells(5).Value.ToString() & "',
                       App_Rank='" & row.Cells(6).Value.ToString() & "',
                         App_VesselType ='" & row.Cells(7).Value.ToString() & "', 
                   App_GRT='" & row.Cells(8).Value.ToString() & "',
                       App_EngineType='" & row.Cells(9).Value.ToString() & "', 
                       App_BHP='" & row.Cells(10).Value.ToString() & "',
                      App_KW='" & row.Cells(11).Value.ToString() & "',              
                 App_Duration='" & row.Cells(14).Value.ToString() & "',
                      App_Reason='" & row.Cells(15).Value.ToString() & "', 
                     App_TradingRoute='" & row.Cells(16).Value.ToString() & "',
                    App_Salary='" & row.Cells(17).Value.ToString() & "'
                        WHERE  App_ID='" & GetAppID & "' and Seaservice_ID ='" & GetSeaID & "';  "

                    End Try






                    Dim UpdateDataCmd As OdbcCommand = New OdbcCommand(UpdateDataStr, conn)


                    Try
                        UpdateDataCmd.ExecuteNonQuery()
                        UpdateDataCmd.Dispose()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                    'Pareho yung count ng nasa Database sa Datagridview.rows.count
                    MsgBox("The Data has been Updated")







                Else

                    If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                For ctr As Integer = sscounter To SBDGView.Rows.Count - 2 Step +1



                    InsertDataStr = ("INSERT INTO hunters_pooling.applicant_seaservice(App_PrincipalName,App_VesselName,App_ImportFlag,App_Nationality,App_Agency,App_Rank,App_VesselType,
                                                      App_GRT,App_EngineType,App_BHP, App_KW,App_DateSignedON,App_DateSignedOFF,App_Duration,App_Reason,App_TradingRoute,App_Salary,App_ID) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
                    Dim IsrtDatacmd As OdbcCommand = New OdbcCommand(InsertDataStr, conn)

                    IsrtDatacmd.Parameters.AddWithValue("@App_PrincipalName", CType(SBDGView.Rows(ctr).Cells(1).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_VesselName", CType(SBDGView.Rows(ctr).Cells(2).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_ImportFlag", CType(SBDGView.Rows(ctr).Cells(3).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Nationality", CType(SBDGView.Rows(ctr).Cells(4).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Agency", CType(SBDGView.Rows(ctr).Cells(5).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Rank", CType(SBDGView.Rows(ctr).Cells(6).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_VesselType", CType(SBDGView.Rows(ctr).Cells(7).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_GRT", CType(SBDGView.Rows(ctr).Cells(8).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_EngineType", CType(SBDGView.Rows(ctr).Cells(9).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_BHP", CType(SBDGView.Rows(ctr).Cells(10).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_KW", CType(SBDGView.Rows(ctr).Cells(11).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_DateSignedON", CType(Convert.ToDateTime(conDate1.ToString("yyyy-MM-dd")).ToShortDateString, Date))
                    IsrtDatacmd.Parameters.AddWithValue("@App_DateSignedOFF", CType(Convert.ToDateTime(conDate2.ToString("yyyy-MM-dd")).ToShortDateString, Date))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Duration", CType(SBDGView.Rows(ctr).Cells(14).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Reason", CType(SBDGView.Rows(ctr).Cells(15).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_TradingRoute", CType(SBDGView.Rows(ctr).Cells(16).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Salary", CType(SBDGView.Rows(ctr).Cells(17).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_ID", CType(GetAppID, String))
                    IsrtDatacmd.ExecuteNonQuery()
                    IsrtDatacmd.Dispose()

                Next

                MessageBox.Show("The Data has been Inserted")

            End If


        ElseIf GetShipStat.Equals("Offshore") Then



            'INSERTING SHIPBOARD Expi
            Dim InsertDataStr As String

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            Dim datein, dateout As Date
            datein = Convert.ToDateTime(conDate1.ToString("yyyy-MM-dd")).ToShortDateString
            dateout = Convert.ToDateTime(conDate2.ToString("yyyy-MM-dd")).ToShortDateString
            Dim UpdateDataStr As String
            'Query for count row of SeaService
            Dim SSstr As String
            SSstr = "SELECT COUNT(*) FROM hunters_pooling.applicant_seaservice WHERE App_ID = '" & GetAppID & "' ;"
            Dim SScommand As OdbcCommand
            SScommand = New OdbcCommand(SSstr, conn)
            Dim SSmyReader As OdbcDataReader = SScommand.ExecuteReader()
            Dim sscounter As String
            If SSmyReader.Read Then
                sscounter = SSmyReader.GetInt32(0)
            End If

            Dim i As Integer = SBDGView.Rows.Count - 1

            If i = sscounter Then

                Dim row As New DataGridViewRow()
                row = SBDGView.Rows(selectedRowIndex)

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                UpdateDataStr = " Update hunters_pooling.applicant_seaservice SET App_PrincipalName= '" & row.Cells(1).Value.ToString() & "',
                        App_VesselName ='" & row.Cells(2).Value.ToString() & "', 
                      App_ImportFlag='" & row.Cells(3).Value.ToString() & "',
                       App_Nationality='" & row.Cells(4).Value.ToString() & "', 
                        App_Agency='" & row.Cells(5).Value.ToString() & "',
                       App_Rank='" & row.Cells(6).Value.ToString() & "',
                         App_VesselType ='" & row.Cells(7).Value.ToString() & "', 
                   App_GRT='" & row.Cells(8).Value.ToString() & "',
                       App_EngineType='" & row.Cells(9).Value.ToString() & "', 
                       App_BHP='" & row.Cells(10).Value.ToString() & "',
                      App_KW='" & row.Cells(11).Value.ToString() & "',        
                     App_DateSignedOn='" & datein.ToString("yyyy-MM-dd") & "',  
                  App_DateSignedOff='" & dateout.ToString("yyyy-MM-dd") & "', 
                 App_Duration='" & row.Cells(14).Value.ToString() & "',
                      App_Reason='" & row.Cells(15).Value.ToString() & "', 
                     App_TradingRoute='" & row.Cells(16).Value.ToString() & "',
                    App_Salary='" & row.Cells(17).Value.ToString() & "',
                         App_DP123='" & row.Cells(18).Value.ToString() & "',
                  App_DpModel='" & row.Cells(19).Value.ToString() & "', 
                    App_Propulsion='" & row.Cells(20).Value.ToString() & "',
                    App_Supply='" & row.Cells(21).Value.ToString() & "',
                    App_Anchor='" & row.Cells(22).Value.ToString() & "',
                   App_Towing='" & row.Cells(23).Value.ToString() & "', 
                   App_DiveSupport='" & row.Cells(24).Value.ToString() & "',
                    App_Rov='" & row.Cells(25).Value.ToString() & "',
                         App_Flotel = '" & row.Cells(26).Value.ToString() & "',
                  App_InstalType='" & row.Cells(27).Value.ToString() & "', 
                App_Charterer='" & row.Cells(28).Value.ToString() & "'
                        WHERE  App_ID='" & GetAppID & "' and Seaservice_ID ='" & GetSeaID & "';  "


                ' AppCert_DateIssued ='" & doccertissued.Value.Date.ToString("yyyy-MM-dd") & "',
                Dim UpdateDataCmd As OdbcCommand = New OdbcCommand(UpdateDataStr, conn)


                Try
                    UpdateDataCmd.ExecuteNonQuery()
                    UpdateDataCmd.Dispose()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                'Pareho yung count ng nasa Database sa Datagridview.rows.count
                MsgBox("The Offshore Data has been Updated")



            Else

                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                For ctr As Integer = sscounter To SBDGView.Rows.Count - 2 Step +1

                    InsertDataStr = ("INSERT INTO hunters_pooling.applicant_seaservice(App_PrincipalName,App_VesselName,App_ImportFlag,App_Nationality,App_Agency,App_Rank,App_VesselType,
                                                      App_GRT,App_EngineType,App_BHP, App_KW,App_DateSignedON,App_DateSignedOFF,App_Duration,App_Reason,App_TradingRoute,App_Salary,App_DP123, App_DpModel, App_Propulsion, App_Supply, App_Anchor, App_Towing, App_DiveSupport, App_Rov, App_Flotel, App_InstalType, App_Charterer, App_ID) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
                    Dim IsrtDatacmd As OdbcCommand = New OdbcCommand(InsertDataStr, conn)

                    IsrtDatacmd.Parameters.AddWithValue("@App_PrincipalName", CType(SBDGView.Rows(ctr).Cells(1).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_VesselName", CType(SBDGView.Rows(ctr).Cells(2).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_ImportFlag", CType(SBDGView.Rows(ctr).Cells(3).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Nationality", CType(SBDGView.Rows(ctr).Cells(4).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Agency", CType(SBDGView.Rows(ctr).Cells(5).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Rank", CType(SBDGView.Rows(ctr).Cells(6).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_VesselType", CType(SBDGView.Rows(ctr).Cells(7).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_GRT", CType(SBDGView.Rows(ctr).Cells(8).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_EngineType", CType(SBDGView.Rows(ctr).Cells(9).Value.ToString(), String))

                    IsrtDatacmd.Parameters.AddWithValue("@App_BHP", CType(SBDGView.Rows(ctr).Cells(10).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_KW", CType(SBDGView.Rows(ctr).Cells(11).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_DateSignedON", CType(Convert.ToDateTime(SBDGView.Rows(ctr).Cells(12).Value.Date).ToShortDateString, Date))
                    IsrtDatacmd.Parameters.AddWithValue("@App_DateSignedOFF", CType(Convert.ToDateTime(SBDGView.Rows(ctr).Cells(13).Value.Date).ToShortDateString, Date))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Duration", CType(SBDGView.Rows(ctr).Cells(14).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Reason", CType(SBDGView.Rows(ctr).Cells(15).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_TradingRoute", CType(SBDGView.Rows(ctr).Cells(16).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Salary", CType(SBDGView.Rows(ctr).Cells(17).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_DP123", CType(SBDGView.Rows(ctr).Cells(18).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_DpModel", CType(SBDGView.Rows(ctr).Cells(19).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Propulsion", CType(SBDGView.Rows(ctr).Cells(20).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Supply", CType(SBDGView.Rows(ctr).Cells(21).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Anchor", CType(SBDGView.Rows(ctr).Cells(22).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Towing", CType(SBDGView.Rows(ctr).Cells(23).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_DiveSupport", CType(SBDGView.Rows(ctr).Cells(24).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Rov", CType(SBDGView.Rows(ctr).Cells(25).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Flotel", CType(SBDGView.Rows(ctr).Cells(26).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_InstalType", CType(SBDGView.Rows(ctr).Cells(27).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_Charterer", CType(SBDGView.Rows(ctr).Cells(28).Value.ToString(), String))
                    IsrtDatacmd.Parameters.AddWithValue("@App_ID", CType(GetAppID, String))
                    IsrtDatacmd.ExecuteNonQuery()
                    IsrtDatacmd.Dispose()

                Next

                MessageBox.Show("The Data has been Inserted")

            End If
        Else
            MessageBox.Show("Please Check the Shipboard Status.")

        End If

        If conn.State = ConnectionState.Closed Then
            conn.Close()
        End If

    End Sub


    Public Sub updateDoc()
        '--------------------------update doc cert-----------------------------------------'
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'End If


        Dim GetDocCtgry As String


        Dim DOB As String = Nothing


        MessageBox.Show(GetDocID)
        'Query for DOC_NAme
        Dim docertstr As String

        docertstr = "SELECT Document_ID, Document_Longname,Document_Shortcut,Document_Category,Document_Status FROM csiaccountingdb.document_list where Document_ID= '" & GetDocID & "';"
        Dim decertcommand As OdbcCommand
        decertcommand = New OdbcCommand(docertstr, conn)
        Dim docertmyReader As OdbcDataReader = decertcommand.ExecuteReader()

        If docertmyReader.Read Then
            GetDocCtgry = docertmyReader.Item(3).ToString

        End If


        If GetDocCtgry.ToString.ToLower.Equals("cert") Then
            'certs
            Dim updatecertstr As String
            ' //dito tayo




            If expirycbox.Checked = True Then

                updatecertstr = " Update hunters_pooling.applicant_cert SET AppCert_Name= '" & EscapeQuote(AppDocTitle.Text) & "',
                AppCert_No ='" & doccertno.Text & "', 
                AppCert_Place='" & PlaceTxt.Text & "',
                AppCert_Country='" & AppCountryList.Text & "', 
                AppCert_DateIssued='" & doccertissued.Value.Date.ToString("yyyy-MM-dd") & "',
                AppCert_DateExpired='" & DOB & "',
                AppCert_Trainingcenter='" & TCenterTxt.Text & "',
                AppCert_Status='" & doccertStat.selectedValue & "'
                WHERE  App_ID='" & GetAppID & "' and App_CertID ='" & GetAppDCID & "';  "



            Else
                updatecertstr = " Update hunters_pooling.applicant_cert SET AppCert_Name= '" & EscapeQuote(AppDocTitle.Text) & "',
                AppCert_No ='" & doccertno.Text & "', 
                AppCert_Place='" & PlaceTxt.Text & "',
                AppCert_Country='" & AppCountryList.Text & "', 
                AppCert_DateIssued='" & doccertissued.Value.Date.ToString("yyyy-MM-dd") & "',
                AppCert_DateExpired='" & doccertexpiry.Value.Date.ToString("yyyy-MM-dd") & "',
                AppCert_Trainingcenter='" & TCenterTxt.Text & "',
                AppCert_Status='" & doccertStat.selectedValue & "'
                WHERE  App_ID='" & GetAppID & "' and App_CertID ='" & GetAppDCID & "';  "

            End If

            Dim updatecertcmd As OdbcCommand = New OdbcCommand(updatecertstr, conn)


            Try
                updatecertcmd.ExecuteNonQuery()
                updatecertcmd.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Else
            'doc
            Dim updatedocstr As String
            Dim datenow As Date = Date.UtcNow

            If expirycbox.Checked = True Then

                updatedocstr = " Update hunters_pooling.applicant_doc SET AppDoc_Name= '" & EscapeQuote(AppDocTitle.Text) & "',
AppDoc_No ='" & doccertno.Text & "', 
AppDoc_Place='" & PlaceTxt.Text & "',
AppDoc_Country='" & AppCountryList.Text & "', 
AppDoc_DateIssued='" & doccertissued.Value.Date.ToString("yyyy-MM-dd") & "',
           AppDoc_DateExpired='" & DOB & "',
AppDoc_Status='" & doccertStat.selectedValue & "'
WHERE  App_ID='" & GetAppID & "' and App_DocID ='" & GetAppDCID & "' ;  "
            Else
                updatedocstr = " Update hunters_pooling.applicant_doc SET AppDoc_Name= '" & EscapeQuote(AppDocTitle.Text) & "',
AppDoc_No ='" & doccertno.Text & "', 
AppDoc_Place='" & PlaceTxt.Text & "',
AppDoc_Country='" & AppCountryList.Text & "', 
AppDoc_DateIssued='" & doccertissued.Value.Date.ToString("yyyy-MM-dd") & "',
           AppDoc_DateExpired='" & doccertexpiry.Value.Date.ToString("yyyy-MM-dd") & "',
AppDoc_Status='" & doccertStat.selectedValue & "'
WHERE  App_ID='" & GetAppID & "' and App_DocID ='" & GetAppDCID & "' ;  "



            End If

            Dim updatedoccmd As OdbcCommand = New OdbcCommand(updatedocstr, conn)
            Try
                updatedoccmd.ExecuteNonQuery()
                updatedoccmd.Dispose()
            Catch ex As Exception
                ' MessageBox.Show(ex.Message)

            End Try



        End If
    End Sub
    Public Sub Checking()
        'Checking ng system sa mga hindi nafill-up-an



        If Len(Trim(AppGName.Text)) = 0 Then
            MessageBox.Show("Please select Generic Name", "Input Error", MessageBoxButtons.OK)
            AppGName.Focus()
            Exit Sub

        ElseIf Len(Trim(AppDocTitle.Text)) = 0 Then
            MessageBox.Show("Please enter Doc/Cert Title", "Input Error", MessageBoxButtons.OK)
            AppDocTitle.Focus()
            Exit Sub

        ElseIf Len(Trim(AppDocShortcut.Text)) = 0 Then
            MessageBox.Show("Please enter Doc/cert Shortcut", "Input Error", MessageBoxButtons.OK)
            AppDocShortcut.Focus()
            Exit Sub

        ElseIf doccertno.Text = "" Then
            MessageBox.Show("Please enter Doc/Cert Number", "Input Error", MessageBoxButtons.OK)
            doccertno.Focus()
            Exit Sub

        ElseIf Len(Trim(PlaceTxt.Text)) = 0 Then
            MessageBox.Show("Please enter Doc/Cert Place", "Input Error", MessageBoxButtons.OK)
            PlaceTxt.Focus()
            Exit Sub


        ElseIf Len(Trim(AppCountryList.Text)) = 0 Then
            MessageBox.Show("Please select Country List", "Input Error", MessageBoxButtons.OK)
            AppCountryList.Focus()
            Exit Sub


            'Checking Documents Date
        ElseIf doccertissued.Value = Date.Today Then
            MessageBox.Show("Please enter Date Issued", "Input Error", MessageBoxButtons.OK)
            doccertissued.Focus()
            Exit Sub


        Else

            If GetNewID.Equals("New") Then
                'insert

                ' inserting data
                Dim ask As MsgBoxResult = MsgBox("Do You want to add this Document", MsgBoxStyle.YesNo)
                If ask = MsgBoxResult.Yes Then


                    If AppGName.Text.Equals(AppDocTitle.Text) Then


                        addcertdoc()
                        MessageBox.Show("Data Successfully Saved")

                    Else
                        MessageBox.Show("Please Check the Information Before Saving")
                    End If

                Else
                    MessageBox.Show("Please Check the Information Before Saving")
                End If


            ElseIf GetNewID.Equals("Update") Then
                'update 
                'If AppGName.Text.Equals(AppDocTitle.Text) Then

                '    Dim ask As MsgBoxResult = MsgBox("Confirm Update? ", MsgBoxStyle.YesNo)
                '    If ask = MsgBoxResult.Yes Then

                '        updateDoc()
                '        MessageBox.Show("Data Successfully Saved")
                '    Else
                '        MessageBox.Show("Kindly Check the Information Before Saving")
                '    End If

                '    'ElseIf AppGName.Text.Contains("VISA") Then

                '    '    Dim ask As MsgBoxResult = MsgBox("Confirm Update? ", MsgBoxStyle.YesNo)
                '    '        If ask = MsgBoxResult.Yes Then

                '    '            updateDoc()
                '    '            MessageBox.Show("Data Successfully Saved")
                '    '        Else
                '    '            MessageBox.Show("Kindly Check the Information Before Saving")
                '    '        End If


                'Else

                '        MessageBox.Show("Please Check the Information Before Saving")
                'End If


                Try
                    Dim ask As MsgBoxResult = MsgBox("Confirm Update? ", MsgBoxStyle.YesNo)
                    If ask = MsgBoxResult.Yes Then

                        updateDoc()
                        MessageBox.Show("Data Successfully Saved")
                    Else
                        MessageBox.Show("Kindly Check the Information Before Saving")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Please Check the Information Before Saving")
                End Try



            End If
            conn.Close()


        End If
    End Sub

    Private Sub DCSaveBtn_Click(sender As Object, e As EventArgs) Handles DCSaveBtn.Click
        Checking()
        ' MsgBox(doccertStat.selectedValue)
        GetNewID = "New"

        AppGName.Text = String.Empty
        AppDocTitle.Text = String.Empty
        AppDocShortcut.Text = String.Empty
        doccertno.Text = String.Empty
        PlaceTxt.Text = String.Empty
        AppCountryList.Text = String.Empty
        doccertissued.Text = String.Empty
        doccertexpiry.Text = String.Empty
        TCenterTxt.Text = String.Empty
        doccertStat.Text = String.Empty





    End Sub

    Private Sub BunifuCheckbox1_OnChange(sender As Object, e As EventArgs) Handles expirycbox.OnChange

        If expirycbox.Checked = True Then
            doccertexpiry.Enabled = False
        Else
            doccertexpiry.Enabled = True


        End If
    End Sub

    Private Sub doccertfilter_onItemSelected(sender As Object, e As EventArgs) Handles doccertfilter.onItemSelected
        loadcertdoc()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles AddDocCertBtn.Click

        GetNewID = "New"

        AppGName.Text = String.Empty
        AppDocTitle.Text = String.Empty
        AppDocShortcut.Text = String.Empty
        doccertno.Text = String.Empty
        PlaceTxt.Text = String.Empty
        AppCountryList.Text = String.Empty
        doccertissued.Text = String.Empty
        doccertexpiry.Text = String.Empty
        TCenterTxt.Text = String.Empty
        doccertStat.Text = String.Empty

    End Sub

    Private Sub DocCertView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DocCertView.CellClick

        GetNewID = "Update"

        'certification
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Dim selectcert As String
        Dim counters As Integer


        DocCertView.Columns(6).Visible() = False
        DocCertView.Columns(6).Visible() = False

        If (e.RowIndex >= 0) Then



            If doccertfilter.selectedValue.Equals("TRAINING CERTS") Then

                ' TCenterTxt.Enabled = True
                'cERT
                selectcert = "Select Document_ID, App_CertID, AppCert_Name, AppCert_Shortcut, AppCert_No, AppCert_Place, AppCert_Country,AppCert_DateIssued, AppCert_DateExpired, AppCert_Trainingcenter, AppCert_Status FROM hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and Document_ID = '" & DocCertView.Rows.Item(e.RowIndex).Cells(0).Value & "' and App_CertID = '" & DocCertView.Rows.Item(e.RowIndex).Cells(6).Value & "';   "

                Dim decertcommand As OdbcCommand
                decertcommand = New OdbcCommand(selectcert, conn)

                Dim doccertreader As OdbcDataReader = decertcommand.ExecuteReader()
                'MessageBox.Show("cert_id " + DocCertView.Rows.Item(e.RowIndex).Cells(6).Value.ToString)
                If doccertreader.Read Then
                    GetAppDCID = doccertreader.Item("App_CertID").ToString()
                    AppGName.Text = doccertreader.Item("AppCert_Name").ToString()
                    AppDocTitle.Text = doccertreader.Item("AppCert_Name").ToString()
                    AppDocShortcut.Text = doccertreader.Item("AppCert_Shortcut").ToString()
                    doccertno.Text = doccertreader.Item("AppCert_No").ToString()
                    PlaceTxt.Text = doccertreader.Item("AppCert_Place").ToString() 'palatandaan
                    AppCountryList.Text = doccertreader.Item("AppCert_Country").ToString()
                    doccertissued.Value = doccertreader.Item("AppCert_DateIssued").ToString()
                    doccertexpiry.Text = doccertreader.Item("AppCert_DateExpired").ToString()
                    TCenterTxt.Text = doccertreader.Item("AppCert_Trainingcenter").ToString()
                    doccertStat.Text = doccertreader.Item("AppCert_Status").ToString()

                End If

            ElseIf doccertfilter.selectedValue.Equals("DOCUMENTS") Then
                '  TCenterTxt.Enabled = False



                'Documents
                Dim selectdoc As String

                selectdoc = "Select Document_ID, App_DocID, AppDoc_Name, AppDoc_No,AppDoc_Shortcut, AppDoc_Place,AppDoc_Country, AppDoc_DateIssued, AppDoc_DateExpired FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and Document_ID = '" & DocCertView.Rows.Item(e.RowIndex).Cells(0).Value & "'   and App_DocID = '" & DocCertView.Rows.Item(e.RowIndex).Cells(6).Value & "'  ;   "
                Dim doccommand As OdbcCommand
                doccommand = New OdbcCommand(selectdoc, conn)
                Dim docreader As OdbcDataReader = doccommand.ExecuteReader()

                If docreader.Read Then
                    GetAppDCID = docreader.Item("App_DocID").ToString()
                    AppGName.Text = docreader.Item("AppDoc_Name").ToString()
                    AppDocTitle.Text = docreader.Item("AppDoc_Name").ToString()
                    AppDocShortcut.Text = docreader.Item("AppDoc_Shortcut").ToString()
                    doccertno.Text = docreader.Item("AppDoc_No").ToString()
                    PlaceTxt.Text = docreader.Item("AppDoc_Place").ToString()
                    AppCountryList.Text = docreader.Item("AppDoc_Country").ToString()
                    doccertissued.Value = docreader.Item("AppDoc_DateIssued").ToString()
                    doccertexpiry.Text = docreader.Item("AppDoc_DateExpired").ToString()


                End If
            Else
                'Documents
                Dim selectdoc As String

                selectdoc = "Select Document_ID,App_DocID, AppDoc_Name, AppDoc_No,AppDoc_Shortcut, AppDoc_Place,AppDoc_Country, AppDoc_DateIssued, AppDoc_DateExpired FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and Document_ID = '" & DocCertView.Rows.Item(e.RowIndex).Cells(0).Value & "'   and App_DocID = '" & DocCertView.Rows.Item(e.RowIndex).Cells(6).Value & "'  ;   "
                Dim doccommand As OdbcCommand
                doccommand = New OdbcCommand(selectdoc, conn)
                Dim docreader As OdbcDataReader = doccommand.ExecuteReader()

                If docreader.Read Then
                    doccertexpiry.Enabled = True
                    expirycbox.Checked = False
                    GetAppDCID = docreader.Item("App_DocID").ToString()
                    AppGName.Text = docreader.Item("AppDoc_Name").ToString()
                    AppDocTitle.Text = docreader.Item("AppDoc_Name").ToString()
                    AppDocShortcut.Text = docreader.Item("AppDoc_Shortcut").ToString()
                    doccertno.Text = docreader.Item("AppDoc_No").ToString()
                    PlaceTxt.Text = docreader.Item("AppDoc_Place").ToString()
                    AppCountryList.Text = docreader.Item("AppDoc_Country").ToString()
                    doccertissued.Value = docreader.Item("AppDoc_DateIssued").ToString()
                    doccertexpiry.Text = docreader.Item("AppDoc_DateExpired").ToString()
                    TCenterTxt.Text = String.Empty
                End If


                'If expirycbox.Checked = True Then
                '    doccertexpiry.Enabled = False
                'Else
                '    doccertexpiry.Enabled = True
                'End If
                'cERT
                selectcert = "Select Document_ID,App_CertID, AppCert_Name, AppCert_Shortcut, AppCert_No, AppCert_Place, AppCert_Country,AppCert_DateIssued, AppCert_DateExpired, AppCert_Trainingcenter, AppCert_Status FROM hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and Document_ID = '" & DocCertView.Rows.Item(e.RowIndex).Cells(0).Value & "' and App_CertID = '" & DocCertView.Rows.Item(e.RowIndex).Cells(6).Value & "';   "

                    Dim decertcommand As OdbcCommand
                    decertcommand = New OdbcCommand(selectcert, conn)

                    Dim doccertreader As OdbcDataReader = decertcommand.ExecuteReader()
                'MessageBox.Show("cert_id " + DocCertView.Rows.Item(e.RowIndex).Cells(6).Value.ToString)
                If doccertreader.Read Then
                    doccertexpiry.Enabled = False
                    expirycbox.Checked = True
                    GetAppDCID = doccertreader.Item("App_CertID").ToString()
                    AppGName.Text = doccertreader.Item("AppCert_Name").ToString()
                    AppDocTitle.Text = doccertreader.Item("AppCert_Name").ToString()
                    AppDocShortcut.Text = doccertreader.Item("AppCert_Shortcut").ToString()
                    doccertno.Text = doccertreader.Item("AppCert_No").ToString()
                    PlaceTxt.Text = doccertreader.Item("AppCert_Place").ToString()
                    AppCountryList.Text = doccertreader.Item("AppCert_Country").ToString()
                    doccertissued.Value = doccertreader.Item("AppCert_DateIssued").ToString()
                    doccertexpiry.Text = doccertreader.Item("AppCert_DateExpired").ToString()
                    TCenterTxt.Text = doccertreader.Item("AppCert_Trainingcenter").ToString()
                    doccertStat.Text = doccertreader.Item("AppCert_Status").ToString()

                End If







            End If

                ElseIf e.RowIndex <> -1 Then

        End If


    End Sub

    Private Sub printdocBtn_Click(sender As Object, e As EventArgs) Handles printdocBtn.Click

        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized

        AddHandler PD.PrintPage, AddressOf doccertPrintPage_PrintPage

        PPV.Show()


        'Printing na may set up ng page
        Dim PrintDialog1 As New PrintDialog()
        PrintDialog1.Document = doccertPrintPage
        If PrintDialog1.ShowDialog(PPV) = Windows.Forms.DialogResult.OK Then

        End If


    End Sub

    Private Sub doccertPrintPage_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles doccertPrintPage.PrintPage
        Dim y As Integer = 113
        Dim yrec As Integer = 110
        Dim yhereby As Integer = 110

        Dim Font As New Font("Arial", 10, FontStyle.Regular)
        Dim hereby As New Font("Arial", 10, FontStyle.Italic)

        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)

        Dim FontMID As New Font("Arial", 12, FontStyle.Regular)
        Dim myPen As Pen = New Pen(Drawing.Color.Black, 2)
        Dim bg As SolidBrush = New SolidBrush(Color.Aqua)
        Dim counter As Integer = 0
        If doccertfilter.selectedValue.Equals("All DOCS & CERTS") Then
            'All
            Dim doccertstr As String
            doccertstr = "Select Document_ID, AppCert_Name, AppCert_No, AppCert_Place, AppCert_DateIssued, AppCert_DateExpired, App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' 
                           UNION 
                           Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, AppDoc_DateIssued, AppDoc_DateExpired, App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID = '" & GetAppID & "'; "
            Dim doccertcommand As OdbcCommand
            doccertcommand = New OdbcCommand(doccertstr, conn)
            Dim doccertreader As OdbcDataReader = doccertcommand.ExecuteReader()

            ' DrawRectangle(myPen, X, Y, width, height)
            e.Graphics.DrawRectangle(myPen, 30, 50, 770, 30)
            e.Graphics.DrawString("DOCUMENTS AND CERTIFICATES", FontTitle, Brushes.Black, 320, 60)
            e.Graphics.DrawRectangle(myPen, 30, 80, 200, 30)
            e.Graphics.DrawString("Document Name", FontMID, Brushes.Black, 70, 85)
            e.Graphics.DrawRectangle(myPen, 230, 80, 150, 30)
            e.Graphics.DrawString("Document Number", Font, Brushes.Black, 250, 85)
            e.Graphics.DrawRectangle(myPen, 380, 80, 150, 30)
            e.Graphics.DrawString("Place Issued", Font, Brushes.Black, 410, 85)
            e.Graphics.DrawRectangle(myPen, 530, 80, 140, 30)
            e.Graphics.DrawString("Issued Date", Font, Brushes.Black, 560, 85)
            e.Graphics.DrawRectangle(myPen, 670, 80, 130, 30)
            e.Graphics.DrawString("Validity Date", Font, Brushes.Black, 690, 85)



            While doccertreader.Read


                'box
                e.Graphics.DrawRectangle(myPen, 30, yrec, 200, 25)
                e.Graphics.DrawRectangle(myPen, 230, yrec, 150, 25)
                e.Graphics.DrawRectangle(myPen, 380, yrec, 150, 25)
                e.Graphics.DrawRectangle(myPen, 530, yrec, 140, 25)
                e.Graphics.DrawRectangle(myPen, 670, yrec, 130, 25)

                'data
                e.Graphics.DrawString(doccertreader.Item(1).ToString(), FontMID, Brushes.Black, 30, y)
                e.Graphics.DrawString(doccertreader.Item(2).ToString(), Font, Brushes.Black, 250, y)
                e.Graphics.DrawString(doccertreader.Item(3).ToString(), Font, Brushes.Black, 410, y)
                e.Graphics.DrawString(doccertreader.GetDate(4).ToString("MM-dd-yyyy"), Font, Brushes.Black, 560, y)

                Try
                    e.Graphics.DrawString(doccertreader.GetDate(5).ToString("MM-dd-yyyy"), Font, Brushes.Black, 690, y)

                Catch ex As Exception
                    e.Graphics.DrawString(" ", Font, Brushes.Black, 690, y)

                End Try

                y = y + 25
                yrec = yrec + 25

                If counter Mod 2 = 0 Then

                    e.Graphics.FillRectangle(bg, 30, yrec, 200, 25)
                    e.Graphics.FillRectangle(bg, 230, yrec, 150, 25)
                    e.Graphics.FillRectangle(bg, 380, yrec, 150, 25)
                    e.Graphics.FillRectangle(bg, 530, yrec, 140, 25)
                    e.Graphics.FillRectangle(bg, 670, yrec, 130, 25)

                End If
                counter = counter + 1




            End While
            Dim sf As New StringFormat
            sf.Alignment = StringAlignment.Center

            Dim str As String
            str = "I hereby certify that this checklist Is complete, correct And True To the best Of my knowledge. I acknowledge that I have received all the original documents "
            str = str & "listed in this checklist as reviewed by me and have been inserted in the blue folder. Furthermore, I assure that nothing will be removed nor taken out from this "
            str = str & "folder and that this folder will be surrendered to the Master for safe keeping as soon as I embark on my assigned vessel."
            ' e.Graphics.DrawString(str, hereby, Brushes.Black, New Rectangle(30, yrec, 950, 105), sf)
            e.Graphics.DrawString(str, hereby, Brushes.Black, New Rectangle(30, yrec + 15, 780, 250), StringFormat.GenericTypographic)
            e.Graphics.DrawString("NOTED BY:", FontMID, Brushes.Black, 40, yrec + 150)
            e.Graphics.DrawString("RECEIVED BY:", FontMID, Brushes.Black, 650, yrec + 150)


        ElseIf doccertfilter.selectedValue.Equals("DOCUMENTS") Then
            'Doc
            Dim docstr As String
            docstr = "Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, AppDoc_DateIssued, AppDoc_DateExpired, App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID = '" & GetAppID & "'; "
            Dim doccommand As OdbcCommand
            doccommand = New OdbcCommand(docstr, conn)
            Dim docreader As OdbcDataReader = doccommand.ExecuteReader()
            ' DrawRectangle(myPen, X, Y, width, height)
            e.Graphics.DrawRectangle(myPen, 30, 50, 770, 30)
            e.Graphics.DrawString("APPLICANT DOCUMENTS ", FontTitle, Brushes.Black, 320, 60)
            e.Graphics.DrawRectangle(myPen, 30, 80, 200, 30)
            e.Graphics.DrawString("Document Name", FontMID, Brushes.Black, 70, 85)
            e.Graphics.DrawRectangle(myPen, 230, 80, 150, 30)
            e.Graphics.DrawString("Document Number", Font, Brushes.Black, 250, 85)
            e.Graphics.DrawRectangle(myPen, 380, 80, 150, 30)
            e.Graphics.DrawString("Place Issued", Font, Brushes.Black, 410, 85)
            e.Graphics.DrawRectangle(myPen, 530, 80, 140, 30)
            e.Graphics.DrawString("Issued Date", Font, Brushes.Black, 560, 85)
            e.Graphics.DrawRectangle(myPen, 670, 80, 130, 30)
            e.Graphics.DrawString("Expired Date", Font, Brushes.Black, 690, 85)
            While docreader.Read
                'box
                e.Graphics.DrawRectangle(myPen, 30, yrec, 200, 25)
                e.Graphics.DrawRectangle(myPen, 230, yrec, 150, 25)
                e.Graphics.DrawRectangle(myPen, 380, yrec, 150, 25)
                e.Graphics.DrawRectangle(myPen, 530, yrec, 140, 25)
                e.Graphics.DrawRectangle(myPen, 670, yrec, 130, 25)

                'data

                e.Graphics.DrawString(docreader.Item(1).ToString(), FontMID, Brushes.Black, 30, y)
                e.Graphics.DrawString(docreader.Item(2).ToString(), Font, Brushes.Black, 250, y)
                e.Graphics.DrawString(docreader.Item(3).ToString(), Font, Brushes.Black, 410, y)
                e.Graphics.DrawString(docreader.GetDate(4).ToString("MM-dd-yyyy"), Font, Brushes.Black, 560, y)
                e.Graphics.DrawString(docreader.GetDate(5).ToString("MM-dd-yyyy"), Font, Brushes.Black, 690, y)
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

            Dim str As String
            str = "I hereby certify that this checklist Is complete, correct And True To the best Of my knowledge. I acknowledge that I have received all the original documents "
            str = str & "listed in this checklist as reviewed by me and have been inserted in the blue folder. Furthermore, I assure that nothing will be removed nor taken out from this "
            str = str & "folder and that this folder will be surrendered to the Master for safe keeping as soon as I embark on my assigned vessel."
            ' e.Graphics.DrawString(str, hereby, Brushes.Black, New Rectangle(30, yrec, 950, 105), sf)
            e.Graphics.DrawString(str, hereby, Brushes.Black, New Rectangle(30, yrec + 15, 780, 250), StringFormat.GenericTypographic)
            e.Graphics.DrawString("NOTED BY:", FontMID, Brushes.Black, 40, yrec + 150)
            e.Graphics.DrawString("RECEIVED BY:", FontMID, Brushes.Black, 650, yrec + 150)


        ElseIf doccertfilter.selectedValue.Equals("TRAINING CERTS") Then

            'CERT
            Dim certstr As String
            certstr = "Select Document_ID, AppCert_Name, AppCert_No, AppCert_Place, AppCert_DateIssued, AppCert_DateExpired, App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID = '" & GetAppID & "'; "
            Dim certcommand As OdbcCommand
            certcommand = New OdbcCommand(certstr, conn)
            Dim certreader As OdbcDataReader = certcommand.ExecuteReader()
            ' DrawRectangle(myPen, X, Y, width, height)
            e.Graphics.DrawRectangle(myPen, 30, 50, 770, 30)
            e.Graphics.DrawString("APPLICANT CERTIFICATES", FontTitle, Brushes.Black, 320, 60)
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
            While certreader.Read
                'box
                e.Graphics.DrawRectangle(myPen, 30, yrec, 200, 25)
                e.Graphics.DrawRectangle(myPen, 230, yrec, 150, 25)
                e.Graphics.DrawRectangle(myPen, 380, yrec, 150, 25)
                e.Graphics.DrawRectangle(myPen, 530, yrec, 140, 25)
                e.Graphics.DrawRectangle(myPen, 670, yrec, 130, 25)

                'data
                e.Graphics.DrawString(certreader.Item(1).ToString(), FontMID, Brushes.Black, 30, y)
                e.Graphics.DrawString(certreader.Item(2).ToString(), Font, Brushes.Black, 250, y)
                e.Graphics.DrawString(certreader.Item(3).ToString(), Font, Brushes.Black, 410, y)
                e.Graphics.DrawString(certreader.GetDate(4).ToString("MM-dd-yyyy"), Font, Brushes.Black, 560, y)
                e.Graphics.DrawString(certreader.GetDate(5).ToString("MM-dd-yyyy"), Font, Brushes.Black, 690, y)
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
            Dim str As String
            str = "I hereby certify that this checklist Is complete, correct And True To the best Of my knowledge. I acknowledge that I have received all the original documents "
            str = str & "listed in this checklist as reviewed by me and have been inserted in the blue folder. Furthermore, I assure that nothing will be removed nor taken out from this "
            str = str & "folder and that this folder will be surrendered to the Master for safe keeping as soon as I embark on my assigned vessel."
            ' e.Graphics.DrawString(str, hereby, Brushes.Black, New Rectangle(30, yrec, 950, 105), sf)
            e.Graphics.DrawString(str, hereby, Brushes.Black, New Rectangle(30, yrec + 15, 780, 250), StringFormat.GenericTypographic)
            e.Graphics.DrawString("NOTED BY:", FontMID, Brushes.Black, 40, yrec + 150)
            e.Graphics.DrawString("RECEIVED BY:", FontMID, Brushes.Black, 650, yrec + 150)

        End If

    End Sub




    Private Sub AppZipCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AppZipCode.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True

        End If

    End Sub

    Private Sub AppCivilStatusCbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppCivilStatusCbox.SelectedIndexChanged
        If AppCivilStatusCbox.SelectedItem.Equals("Single") Then
            AppDateMarried.Enabled = False
        Else
            AppDateMarried.Enabled = True
        End If
    End Sub

    Private Sub AppSSSNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AppSSSNo.KeyPress
        If Char.IsNumber(e.KeyChar) = False Then
            e.Handled = True

        End If
    End Sub

    Private Sub PrintSBInfo_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles PrintSBInfo.PrintPage

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim y As Integer = 113
        Dim yrec As Integer = 40

        Dim Fontbox As New Font("Arial", 9, FontStyle.Bold)

        Dim hereby As New Font("Arial", 7, FontStyle.Italic)
        Dim fontinside As New Font("Arial", 10, FontStyle.Regular)
        Dim fontside As New Font("Arial", 8, FontStyle.Regular)
        Dim FontMID As New Font("Arial", 12, FontStyle.Regular)

        Dim FontTitle As New Font("Arial", 7, FontStyle.Regular)

        Dim myPen As Pen = New Pen(Drawing.Color.Black, 2)
        Dim bg As SolidBrush = New SolidBrush(Color.Aqua)
        Dim counter As Integer = 0
        Dim ysb = 65

        ' 'drawing ng text (x, y)
        ' DrawRectangle(myPen, X, Y, width, height)
        e.Graphics.DrawString("Service Record (Running Vessel)", FontMID, Brushes.Black, 620, 20)

        e.Graphics.DrawString("PRINCIPAL NAME", FontTitle, Brushes.Black, 45, 45)
        e.Graphics.DrawRectangle(myPen, 30, yrec, 110, 20) 'principal
        e.Graphics.DrawString("VESSEL NAME", FontTitle, Brushes.Black, 155, 45)
        e.Graphics.DrawRectangle(myPen, 140, yrec, 110, 20) 'vesselname
        e.Graphics.DrawString("FLAG", FontTitle, Brushes.Black, 265, 45)
        e.Graphics.DrawRectangle(myPen, 250, yrec, 55, 20) 'flaG
        e.Graphics.DrawString("NATIONALITY", FontTitle, Brushes.Black, 310, 45)
        e.Graphics.DrawRectangle(myPen, 305, yrec, 85, 20) 'nationality
        e.Graphics.DrawString("AGENCY", FontTitle, Brushes.Black, 420, 45)
        e.Graphics.DrawRectangle(myPen, 390, yrec, 110, 20) 'agency
        e.Graphics.DrawString("Rank", FontTitle, Brushes.Black, 515, 45)
        e.Graphics.DrawRectangle(myPen, 500, yrec, 55, 20) 'rank
        e.Graphics.DrawString("Vessel Type", FontTitle, Brushes.Black, 560, 45)
        e.Graphics.DrawRectangle(myPen, 555, yrec, 65, 20) 'vesseltype
        e.Graphics.DrawString("GRT", FontTitle, Brushes.Black, 635, 45)
        e.Graphics.DrawRectangle(myPen, 620, yrec, 55, 20) 'grt
        e.Graphics.DrawString("ENGINE MAKE", FontTitle, Brushes.Black, 700, 45)
        e.Graphics.DrawRectangle(myPen, 675, yrec, 110, 20) 'engine make
        e.Graphics.DrawString("KW", FontTitle, Brushes.Black, 800, 45)
        e.Graphics.DrawRectangle(myPen, 785, yrec, 55, 20) 'kw
        e.Graphics.DrawString("FROM", FontTitle, Brushes.Black, 875, 45)
        e.Graphics.DrawRectangle(myPen, 840, yrec, 110, 20) 'from
        e.Graphics.DrawString("TO", FontTitle, Brushes.Black, 990, 45)
        e.Graphics.DrawRectangle(myPen, 950, yrec, 110, 20) 'to
        e.Graphics.DrawString("T.M", FontTitle, Brushes.Black, 1075, 45)
        e.Graphics.DrawRectangle(myPen, 1060, yrec, 55, 20) 'totalmonths
        e.Graphics.DrawString("R.D", FontTitle, Brushes.Black, 1150, 45)
        e.Graphics.DrawRectangle(myPen, 1115, yrec, 85, 20) 'reason
        e.Graphics.DrawString("TRADING", FontTitle, Brushes.Black, 1215, 45)
        e.Graphics.DrawRectangle(myPen, 1200, yrec, 85, 20) 'trading route
        e.Graphics.DrawString("SALARY", FontTitle, Brushes.Black, 1300, 45)
        e.Graphics.DrawRectangle(myPen, 1285, yrec, 85, 20) 'salary


        Dim sbstr As String

        sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc; "




        Dim sbcmd As OdbcCommand
        sbcmd = New OdbcCommand(sbstr, conn)
        Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()


        While sbreader.Read

            e.Graphics.DrawString(sbreader.Item("App_PrincipalName").ToString(), fontside, Brushes.Black, 45, ysb)
            e.Graphics.DrawString(sbreader.Item("App_VesselName").ToString(), fontside, Brushes.Black, 155, ysb)
            e.Graphics.DrawString(sbreader.Item("App_ImportFlag").ToString(), Font, Brushes.Black, 265, ysb)
            e.Graphics.DrawString(sbreader.Item("App_Nationality").ToString(), Font, Brushes.Black, 310, ysb)
            e.Graphics.DrawString(sbreader.Item("App_Agency").ToString(), Font, Brushes.Black, 420, ysb)
            e.Graphics.DrawString(sbreader.Item("App_Rank").ToString(), Font, Brushes.Black, 515, ysb)
            e.Graphics.DrawString(sbreader.Item("App_VesselType").ToString(), Font, Brushes.Black, 560, ysb)
            e.Graphics.DrawString(sbreader.Item("App_GRT").ToString(), Font, Brushes.Black, 635, ysb)
            e.Graphics.DrawString(sbreader.Item("App_EngineType").ToString(), Font, Brushes.Black, 700, ysb)
            e.Graphics.DrawString(sbreader.Item("App_KW").ToString(), Font, Brushes.Black, 800, ysb)
            e.Graphics.DrawString(sbreader.GetDate(12).ToString("MM-dd-yyyy"), Font, Brushes.Black, 875, ysb)
            e.Graphics.DrawString(sbreader.GetDate(13).ToString("MM-dd-yyyy"), Font, Brushes.Black, 990, ysb)
            e.Graphics.DrawString(sbreader.Item("App_Duration").ToString(), Font, Brushes.Black, 1075, ysb)
            e.Graphics.DrawString(sbreader.Item("App_Reason").ToString(), Font, Brushes.Black, 1150, ysb)
            e.Graphics.DrawString(sbreader.Item("App_TradingRoute").ToString(), Font, Brushes.Black, 1215, ysb)
            e.Graphics.DrawString(sbreader.Item("App_Salary").ToString(), Font, Brushes.Black, 1300, ysb)
            ysb = ysb + 20
        End While


        Dim ctr As Integer

        For ctr = 1 To 20 Step 1
            e.Graphics.DrawRectangle(myPen, 30, yrec, 110, 20) 'principal
            e.Graphics.DrawRectangle(myPen, 140, yrec, 110, 20) 'vesselname
            e.Graphics.DrawRectangle(myPen, 250, yrec, 55, 20) 'flaG
            e.Graphics.DrawRectangle(myPen, 305, yrec, 85, 20) 'nationality
            e.Graphics.DrawRectangle(myPen, 390, yrec, 110, 20) 'agency
            e.Graphics.DrawRectangle(myPen, 500, yrec, 55, 20) 'rank
            e.Graphics.DrawRectangle(myPen, 555, yrec, 65, 20) 'vesseltype
            e.Graphics.DrawRectangle(myPen, 620, yrec, 55, 20) 'grt
            e.Graphics.DrawRectangle(myPen, 675, yrec, 110, 20) 'engine make
            e.Graphics.DrawRectangle(myPen, 785, yrec, 55, 20) 'kw
            e.Graphics.DrawRectangle(myPen, 840, yrec, 110, 20) 'from
            e.Graphics.DrawRectangle(myPen, 950, yrec, 110, 20) 'to
            e.Graphics.DrawRectangle(myPen, 1060, yrec, 55, 20) 'totalmonths
            e.Graphics.DrawRectangle(myPen, 1115, yrec, 85, 20) 'reason
            e.Graphics.DrawRectangle(myPen, 1200, yrec, 85, 20) 'trading route
            e.Graphics.DrawRectangle(myPen, 1285, yrec, 85, 20) 'salary
            yrec = yrec + 20
        Next
        ' DrawRectangle(myPen, X, Y, width, height)



        e.Graphics.DrawString("Shipboard Experience", Fontbox, Brushes.Black, 35, yrec + 40)
        e.Graphics.DrawString("Last Philippine Manning Agency Employer's Name      ___________________________________________", fontside, Brushes.Black, 45, yrec + 55)
        e.Graphics.DrawString("Contact Person      _______________________________________________________________________", fontside, Brushes.Black, 45, yrec + 70)
        e.Graphics.DrawString("Name of Foreign Principal      _______________________________________________________________", fontside, Brushes.Black, 45, yrec + 85)
        e.Graphics.DrawString("Contact Person      _______________________________________________________________________", fontside, Brushes.Black, 45, yrec + 100)


        e.Graphics.DrawString("Telephone/Mobile Number      __________________________________________________________________________________", fontside, Brushes.Black, 700, yrec + 55)
        e.Graphics.DrawString("Telephone/Mobile Number      __________________________________________________________________________________", fontside, Brushes.Black, 700, yrec + 70)
        e.Graphics.DrawString("Telephone/Mobile Number      __________________________________________________________________________________", fontside, Brushes.Black, 700, yrec + 85)
        e.Graphics.DrawString("Telephone/Mobile Number      __________________________________________________________________________________", fontside, Brushes.Black, 700, yrec + 100)


        e.Graphics.DrawString("PAST EMPLOYMENT", Fontbox, Brushes.Black, 630, yrec + 15)
        e.Graphics.DrawRectangle(myPen, 30, yrec + 30, 1343, 90) '1ST BOX

        e.Graphics.DrawString("Any previous Surgery", fontinside, Brushes.Black, 60, yrec + 145)
        e.Graphics.DrawString("Any previous Illness", fontinside, Brushes.Black, 60, yrec + 165)
        e.Graphics.DrawString("Any previous Handicap", fontinside, Brushes.Black, 60, yrec + 185)
        e.Graphics.DrawString("Any previous drug/alcohol problem", fontinside, Brushes.Black, 60, yrec + 205)

        e.Graphics.DrawString("No", fontinside, Brushes.Black, 400, yrec + 145)
        e.Graphics.DrawString("No", fontinside, Brushes.Black, 400, yrec + 165)
        e.Graphics.DrawString("No", fontinside, Brushes.Black, 400, yrec + 185)
        e.Graphics.DrawString("No", fontinside, Brushes.Black, 400, yrec + 205)
        e.Graphics.DrawString("Yes", fontinside, Brushes.Black, 550, yrec + 145)
        e.Graphics.DrawString("Yes", fontinside, Brushes.Black, 550, yrec + 165)
        e.Graphics.DrawString("Yes", fontinside, Brushes.Black, 550, yrec + 185)
        e.Graphics.DrawString("Yes", fontinside, Brushes.Black, 550, yrec + 205)

        e.Graphics.DrawString(",please describe briefly          ____________________________________________________________________", fontinside, Brushes.Black, 650, yrec + 145)
        e.Graphics.DrawString(",please describe briefly          ____________________________________________________________________", fontinside, Brushes.Black, 650, yrec + 165)
        e.Graphics.DrawString(",please describe briefly          ____________________________________________________________________", fontinside, Brushes.Black, 650, yrec + 185)
        e.Graphics.DrawString(",please describe briefly          ____________________________________________________________________", fontinside, Brushes.Black, 650, yrec + 205)


        e.Graphics.DrawString("MEDICAL HISTORY", Fontbox, Brushes.Black, 632, yrec + 125)
        e.Graphics.DrawRectangle(myPen, 30, yrec + 140, 1343, 90) '2ND BOX

        '3rd box
        Dim str As String
        str = "I hereby confirm that the information given by me is true and correct to the best of my knowledge and belief. I have not withheld any information that may affect my appication unfavorably, any false data herein constitutes ground for my "
        str = str & "disqualification or non-acceptance of my application. I also understand that strict medical examination inclusive of a Drug and Alcohol Test is a company prerequisite for my employment. "
        str = str & "I am will to be examined and to provide this company's accredited medical clinic a complete and detailed personal medical history. I also agree that the findings and results of the examination are final. "
        str = str & "I am not presently employed with any company and if my application is accepted, i will be available to report starting on (dd-mm-yy) "

        ' e.Graphics.DrawString(str, hereby, Brushes.Black, New Rectangle(30, yrec, 950, 105), sf)
        e.Graphics.DrawString(str, hereby, Brushes.Black, New Rectangle(35, yrec + 255, 1340, 60), StringFormat.GenericTypographic)
        e.Graphics.DrawString("Signature of Seafarer:_____________________________________________________________________________", Fontbox, Brushes.Black, 35, yrec + 320)
        e.Graphics.DrawString("Date:__________________________________________________________________________", Fontbox, Brushes.Black, 790, yrec + 320)
        e.Graphics.DrawString("SEAFARER'S DECLARATION", Fontbox, Brushes.Black, 610, yrec + 235)
        e.Graphics.DrawRectangle(myPen, 30, yrec + 250, 1343, 90) '3RD BOX



    End Sub

    Private Sub SBPrintBtn_Click(sender As Object, e As EventArgs) Handles SBPrintBtn.Click

        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized
        PPV.Document.DefaultPageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
        AddHandler PD.PrintPage, AddressOf PrintSBInfo_PrintPage
        PPV.Document.DefaultPageSettings.Landscape = True


        PPV.Show()

    End Sub




    Private Sub DaprvBtn_Click(sender As Object, e As EventArgs) Handles DaprvBtn.Click

        'App_Remarks.Show()  

        Dim OBJ As New App_Remarks
        OBJ.username = UserText
        OBJ.GetAppID = AppIDIdentifier.Text
        OBJ.Show()
    End Sub









    Private Sub SavekinBtn_Click(sender As Object, e As EventArgs) Handles SavekinBtn.Click

        If GetKinStat.ToString.Equals("Insert") Then
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            'insert
            Dim inskinstr As String
            inskinstr = ("INSERT INTO hunters_pooling.applicant_family(appkin_LName,appkin_FName,appkin_MName,appkin_Suffix,appkin_Address, appkin_Sex , appkin_Bday ,appkin_Bplace,appkin_ContactNo ,appkin_Occupation ,appkin_Relation ,appkin_Status ,appkin_Passport,appkin_PsprtPlaceIssue, appkin_IssueDate,appkin_ExpiryDate, App_ID) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
            Dim inskincmd As OdbcCommand = New OdbcCommand(inskinstr, conn)
            'noted
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_LName", CType(Kin_Lastname.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_FName", CType(Kin_Firstname.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_MName", CType(Kin_Middlename.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Suffix", CType(Kin_Suffix.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Address", CType(Kin_Address.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Sex", CType(SexCmbox.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Bday", CType(Kin_Bday.Value.Date.ToString("yyyy-MM-dd"), Date)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Bplace", CType(Kin_Bplace.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_ContactNo", CType(Kin_Contact.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Occupation", CType(Kin_Occupation.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Relation", CType(Kin_Relation.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Status", CType(Kin_Stat.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_Passport", CType(Kin_Passport.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_PsprtPlaceIssue", CType(Kin_PlaceIssued.Text, String)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_IssueDate", CType(Kin_IssueDate.Value.Date.ToString("yyyy-MM-dd"), Date)))
            inskincmd.Parameters.Add(New OdbcParameter("@appkin_ExpiryDate", CType(Kin_ExpiryDate.Value.Date.ToString("yyyy-MM-dd"), Date)))
            inskincmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))



            inskincmd.ExecuteNonQuery()
            inskincmd.Dispose()

            MessageBox.Show("Your Family Named: " + Kin_Firstname.Text + " SAVED", "Applicant Family", MessageBoxButtons.OK)
            Kin_Lastname.Text = String.Empty
            Kin_Firstname.Text = String.Empty
            Kin_Middlename.Text = String.Empty
            Kin_Suffix.Text = String.Empty
            Kin_Address.Text = String.Empty
            Kin_Bplace.Text = String.Empty
            Kin_Contact.Text = String.Empty
            Kin_Relation.Text = String.Empty
            Kin_Stat.Text = String.Empty
            Kin_Passport.Text = String.Empty

        Else
            Dim updatekin As String
            updatekin = " Update hunters_pooling.applicant_family SET appkin_LName= '" & Kin_Lastname.Text & "', 
       appkin_FName ='" & Kin_Firstname.Text & "', 
       appkin_MName='" & Kin_Middlename.Text & "',
       appkin_Suffix='" & Kin_Suffix.Text & "',
     appkin_Address ='" & Kin_Address.Text & "',  
    appkin_Sex ='" & SexCmbox.Text & "',  
        appkin_Bday ='" & Kin_Bday.Value.Date.ToString("yyyy-MM-dd") & "',  
       appkin_Bplace ='" & Kin_Bplace.Text & "',  
      appkin_ContactNo ='" & Kin_Contact.Text & "',  
       appkin_Occupation ='" & Kin_Occupation.Text & "',  
     appkin_Relation = '" & Kin_Relation.Text & "', 
    appkin_Status= '" & Kin_Stat.Text & "',
       appkin_Passport ='" & Kin_Passport.Text & "',  
appkin_PsprtPlaceIssue='" & Kin_PlaceIssued.Text & "',  
appkin_IssueDate ='" & Kin_IssueDate.Value.Date.ToString("yyyy-MM-dd") & "',  
appkin_ExpiryDate='" & Kin_ExpiryDate.Value.Date.ToString("yyyy-MM-dd") & "'
 WHERE appkin_ID='" & KinID.Text & "' ;  "
            Dim updatetinfocmd As OdbcCommand = New OdbcCommand(updatekin, conn)

            Try
                updatetinfocmd.ExecuteNonQuery()
                updatetinfocmd.Dispose()
                MessageBox.Show("Your Family Named: " + Kin_Firstname.Text + "has been Updated", "Applicant Family", MessageBoxButtons.OK)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try






        End If




    End Sub

    Private Sub addkinBtn_Click(sender As Object, e As EventArgs) Handles addkinBtn.Click
        GetKinStat = "Insert"
        Kin_Lastname.Text = String.Empty
        Kin_Firstname.Text = String.Empty
        Kin_Middlename.Text = String.Empty
        Kin_Suffix.Text = String.Empty
        Kin_Address.Text = String.Empty
        Kin_Bplace.Text = String.Empty
        Kin_Contact.Text = String.Empty
        Kin_Relation.Text = String.Empty
        Kin_Stat.Text = String.Empty
        Kin_Passport.Text = String.Empty
    End Sub



    Private Sub FamilyInfoDGView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles FamilyInfoDGView.CellClick
        GetKinStat = "Update"

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        If (e.RowIndex >= 0) Then

            KinID.Text = FamilyInfoDGView.Rows.Item(e.RowIndex).Cells(0).Value

            Dim kinfamstr As String

            kinfamstr = "Select * from hunters_pooling.applicant_family where appkin_Status = 'ACTIVE' and appkin_ID = '" & FamilyInfoDGView.Rows.Item(e.RowIndex).Cells(0).Value & "';   "
            Dim kinfamcmd As OdbcCommand
            kinfamcmd = New OdbcCommand(kinfamstr, conn)
            Dim kinfamreader As OdbcDataReader = kinfamcmd.ExecuteReader()

            If kinfamreader.Read Then

                Kin_Lastname.Text = kinfamreader.Item("appkin_LName").ToString()
                Kin_Firstname.Text = kinfamreader.Item("appkin_FName").ToString()
                Kin_Middlename.Text = kinfamreader.Item("appkin_MName").ToString()
                Kin_Suffix.Text = kinfamreader.Item("appkin_Suffix").ToString()
                Kin_Address.Text = kinfamreader.Item("appkin_Address").ToString()
                Kin_Bday.Text = kinfamreader.Item("appkin_Bday").ToString()
                Kin_Bplace.Text = kinfamreader.Item("appkin_Bplace").ToString()
                SexCmbox.Text = kinfamreader.Item("appkin_Sex").ToString()
                Kin_Contact.Text = kinfamreader.Item("appkin_ContactNo").ToString()
                Kin_Relation.Text = kinfamreader.Item("appkin_Relation").ToString()
                SexCmbox.Text = kinfamreader.Item("appkin_Sex").ToString()
                Kin_Occupation.Text = kinfamreader.Item("appkin_Occupation").ToString()
                Kin_Stat.Text = kinfamreader.Item("appkin_Status").ToString()

                Kin_Passport.Text = kinfamreader.Item("appkin_Passport").ToString()
                Kin_PlaceIssued.Text = kinfamreader.Item("appkin_PsprtPlaceIssue").ToString()
                Kin_IssueDate.Text = kinfamreader.Item("appkin_IssueDate").ToString()
                Kin_ExpiryDate.Text = kinfamreader.Item("appkin_ExpiryDate").ToString()


            End If

        ElseIf e.RowIndex <> -1 Then

        End If

    End Sub

    Private Sub PrintCvBtn_Click(sender As Object, e As EventArgs) Handles PrintCvBtn.Click

        'CVPRINTING.Show()  

        Dim OBJ As New CVPrinting
        OBJ.username = UserText
        OBJ.appage = GetAge
        OBJ.GetAppID = AppIDIdentifier.Text
        OBJ.Show()
    End Sub



    Private Sub AppPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppPosition.SelectedIndexChanged
        Dim pool As String

        pool = AppPosition.Text

        RankTxtbox.Text = pool

    End Sub


    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles UploadBtn.Click
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        Dim opf As New OpenFileDialog

        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif"

        'Dim ask As MsgBoxResult = MsgBox("Confirm Update?", MsgBoxStyle.YesNo)
        'If ask = MsgBoxResult.Yes Then
        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(opf.FileName)

            conn.Open()
            Dim updateinfo As String
            updateinfo = "Update hunters_pooling.applicant_info SET App_Picture= '" & EscapeBack(opf.FileName) & "'
                          WHERE  App_ID='" & GetAppID & "';"
            Dim updatetinfocmd As OdbcCommand = New OdbcCommand(updateinfo, conn)

            Try
                MessageBox.Show("Image Saved " + opf.FileName)
                updatetinfocmd.ExecuteNonQuery()
                updatetinfocmd.Dispose()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MsgBox("Cancel")
        End If
        'End If

        'Dim updateinfo As String
        'updateinfo = (" Update hunters_pooling.applicant_info SET (App_Picture, App_ID) " & "VALUES (?,?)")
        'Dim updatetinfocmd As OdbcCommand = New OdbcCommand(updateinfo, conn)

        'Dim ms As New MemoryStream
        'PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)

        'updatetinfocmd.Parameters.Add("@App_Picture", SqlDbType.Image, ms.Length).Value = ms.ToArray()


        'updatetinfocmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))

        'Try
        '    updatetinfocmd.ExecuteNonQuery()
        '    updatetinfocmd.Dispose()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        ' AppBDay.Value.Date.ToString("yyyy-MM-dd")

        ' Dim updateinfo As String
        ' updateinfo = " Update hunters_pooling.applicant_info SET App_Picture= '" & ms.ToArray & "'
        'WHERE  App_ID='" & GetAppID & "' ;  "
        ' Dim updatetinfocmd As OdbcCommand = New OdbcCommand(updateinfo, conn)



        ' Command.Parameters.Add("@img", SqlDbType.Image).Value = ms.ToArray()

        ' insertaddcmd.Parameters.Add(New OdbcParameter("@App_ZipCode", CType(AppZipCode.Text, String)))
        ' insertaddcmd.Parameters.Add(New OdbcParameter("@App_City", CType(AppCity.Text, String)))
        ' insertaddcmd.Parameters.Add(New OdbcParameter("@App_Barangay", CType(App_Barangay.Text, String)))

        ' Try
        '     updatetinfocmd.ExecuteNonQuery()
        '     updatetinfocmd.Dispose()

        ' Catch ex As Exception
        '     MessageBox.Show(ex.Message)
        ' End Try

    End Sub



    Private Sub doccertissued_onValueChanged(sender As Object, e As EventArgs)

        If AppGName.Text.Equals("Seaman's Book") Then

            Me.doccertexpiry.Value = sender.Value.AddYears(10)
        ElseIf AppGName.Text.Equals("Passport") Then
            Me.doccertexpiry.Value = sender.Value.AddYears(10)

        End If


    End Sub





    Private Sub OffshoreBtn_Click(sender As Object, e As EventArgs) Handles OffshoreBtn.Click
        '///////////////////////SHIPBOARD TAB CODE///////////////////////////////////////
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        GetShipStat = "Offshore"
        Dim SbList As String
        SbList = "SELECT Seaservice_ID as ID, App_PrincipalName as 'Principal' ,App_VesselName as 'VesselName',App_ImportFlag as 'Flag', App_Nationality as 'Nationality', App_Agency as 'Agency', App_Rank as 'Rank', App_VesselType  as 'Vessel Type', App_GRT as 'GRT',App_EngineType as 'Engine Type', App_BHP as 'BHP', App_KW as 'KW', date_format(App_DateSignedON , '%d-%b-%Y') AS 'Signed On',  date_format(App_DateSignedOFF , '%d-%b-%Y') AS 'Signed Off',
        App_Duration as 'Duration', App_Reason as 'Reason', App_TradingRoute as 'Route', App_Salary as 'Salary', App_DP123 as 'DP 123', App_DpModel as 'DP Model', App_Propulsion as 'Propulsion', App_Supply as 'Supply', App_Anchor as 'Anchor', App_Towing as 'Towing', App_DiveSupport as 'Dive Support', App_Rov as 'Rov' , App_Flotel as 'Flotel', App_InstalType as 'Install Type', App_Charterer as 'Charterer' FROM hunters_pooling.applicant_seaservice WHERE App_ID = '" & GetAppID & "';"

        Dim dvSbList As New DataTable("applicant_seaservice")
        Dim Sbadapter As New Odbc.OdbcDataAdapter(SbList, conn)
        Sbadapter.Fill(dvSbList)
        SBDGView.DataSource = dvSbList
        Sbadapter.Dispose()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

    End Sub

    Private Sub BunifuFlatButton1_Click_1(sender As Object, e As EventArgs)


        'SBDGView.Size = New Size(1169, 347) original'

        SBDGView.Size = New Size(1169, 75) 'changed
    End Sub

    Private Sub RefPerson_OnValueChanged(sender As Object, e As EventArgs) Handles RefPerson.OnValueChanged

    End Sub

    Private Sub SaveRefBtn_Click(sender As Object, e As EventArgs) Handles SaveRefBtn.Click


        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()

        'Character References
        'Agency
        If Len(Trim(RefLEN.Text)) = 0 And Len(Trim(RefAdd.Text)) = 0 And Len(Trim(RefPerson.Text)) = 0 And Len(Trim(RefCPNo.Text)) = 0 Then
            Exit Sub
        Else



            Dim InsRef As String
            InsRef = ("INSERT INTO hunters_pooling.applicant_reference(Ref_Name, Ref_Address, Ref_CPerson, Ref_Number, Ref_Email, Ref_Type, App_ID) VALUES (?,?,?,?,?,?,?)")
            Dim IsrtRefcmd As OdbcCommand = New OdbcCommand(InsRef, conn)


            IsrtRefcmd.Parameters.Add(New OdbcParameter("@Ref_Name", CType(RefLEN.Text, String)))
            IsrtRefcmd.Parameters.Add(New OdbcParameter("@Ref_Address", CType(RefAdd.Text, String)))
            IsrtRefcmd.Parameters.Add(New OdbcParameter("@Ref_CPerson", CType(RefPerson.Text, String)))
            IsrtRefcmd.Parameters.Add(New OdbcParameter("@Ref_Number", CType(RefCPNo.Text, String)))
            IsrtRefcmd.Parameters.Add(New OdbcParameter("@Ref_Email", CType(RefEmail.Text, String)))
            IsrtRefcmd.Parameters.Add(New OdbcParameter("@Ref_Type", CType("Agency", String)))

            IsrtRefcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))

            'Try
            '    IsrtRefcmd.ExecuteNonQuery()
            '    IsrtRefcmd.Dispose()
            '    MessageBox.Show("Character Reference Saved")

            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try
            IsrtRefcmd.ExecuteNonQuery()
            IsrtRefcmd.Dispose()
            MessageBox.Show("Character Reference Saved")
        End If

        'Principal
        If Len(Trim(RefPrin.Text)) = 0 And Len(Trim(RefPriAdd.Text)) = 0 And Len(Trim(RePrinCName.Text)) = 0 And Len(Trim(RePrinCNo.Text)) = 0 Then
            Exit Sub
        Else

            Dim InsPrinRef As String
            InsPrinRef = ("INSERT INTO hunters_pooling.applicant_reference(Ref_Name, Ref_Address, Ref_CPerson, Ref_Number, Ref_Email, Ref_Type, App_ID) VALUES (?,?,?,?,?,?,?)")
            Dim InsPrinRefcmd As OdbcCommand = New OdbcCommand(InsPrinRef, conn)


            InsPrinRefcmd.Parameters.Add(New OdbcParameter("@Ref_Name", CType(RefPrin.Text, String)))
            InsPrinRefcmd.Parameters.Add(New OdbcParameter("@Ref_Address", CType(RefPriAdd.Text, String)))
            InsPrinRefcmd.Parameters.Add(New OdbcParameter("@Ref_CPerson", CType(RePrinCName.Text, String)))
            InsPrinRefcmd.Parameters.Add(New OdbcParameter("@Ref_Number", CType(RePrinCNo.Text, String)))
            InsPrinRefcmd.Parameters.Add(New OdbcParameter("@Ref_Email", CType(RePrinEmail.Text, String)))
            InsPrinRefcmd.Parameters.Add(New OdbcParameter("@Ref_Type", CType("Principal", String)))

            InsPrinRefcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))

            'Try
            '    InsPrinRefcmd.ExecuteNonQuery()
            '    InsPrinRefcmd.Dispose()
            '    MessageBox.Show("Character Reference Saved")
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try
            InsPrinRefcmd.ExecuteNonQuery()
            InsPrinRefcmd.Dispose()
            MessageBox.Show("Character Reference Saved")
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End If
    End Sub


    Private Sub BunifuFlatButton1_Click_2(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        RefLEN.ResetText()
        RefAdd.ResetText()
        RefPerson.ResetText()
        RefCPNo.ResetText()
        RefEmail.ResetText()


        RefLEN.ResetText()
        RefAdd.ResetText()
        RefPerson.ResetText()
        RefCPNo.ResetText()
        RefEmail.ResetText()
    End Sub

    Private Sub AppIDIdentifier_Paint(sender As Object, e As PaintEventArgs) Handles AppIDIdentifier.Paint

    End Sub

    Private Sub FamilyInfoDGView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles FamilyInfoDGView.CellContentClick

    End Sub

    Private Sub Kin_IssueDate_onValueChanged(sender As Object, e As EventArgs) Handles Kin_IssueDate.onValueChanged

        Me.Kin_ExpiryDate.Value = sender.Value.AddYears(10)

    End Sub



    'Private dateTimePicker1 As DateTimePicker
    'Private dateTimePicker2 As DateTimePicker

    Private conDate1 As DateTime
    Private conDate2 As DateTime


    Private Sub SBDGView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SBDGView.CellClick
        'This Is Problem
        selectedRowIndex = e.RowIndex

        If Not e.RowIndex = -1 Then



            If e.ColumnIndex = 12 Then
                If SBDGView.Rows(e.RowIndex).Cells(12).Value.ToString.Equals("") Then
                    SBDGView.Rows.Item(e.RowIndex).Cells(12).Value = "dd-MMM-yyyy"
                End If

                'dateTimePicker1 = New DateTimePicker()
                'SBDGView.Controls.Add(dateTimePicker1)
                'dateTimePicker1.Format = DateTimePickerFormat.Short
                'Dim oRectangle As Rectangle = SBDGView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                'dateTimePicker1.Size = New Size(oRectangle.Width, oRectangle.Height)
                'dateTimePicker1.Location = New Point(oRectangle.X, oRectangle.Y)
                'AddHandler dateTime Picker1.TextChanged, AddressOf DateTimePickerChange1
                'AddHandler SBDGView.Scroll, AddressOf DateTimePickerScroll1

                'dateBox1 = New TextBox()
                'SBDGView.Controls.Add(dateBox1)
                'dateBox1.Text = 
                'Dim oRectangle As Rectangle = SBDGView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                'dateBox1.Size = New Size(oRectangle.Width, oRectangle.Height)
                'dateBox1.Location = New Point(oRectangle.X, oRectangle.Y)
                'AddHandler dateTimePicker1.TextChanged, AddressOf DateTimePickerChange1
                'AddHandler SBDGView.Scroll, AddressOf DateTimePickerScroll1    

            End If
            If e.ColumnIndex = 13 Then
                If SBDGView.Rows(e.RowIndex).Cells(13).Value.ToString.Equals("") Then
                    SBDGView.Rows.Item(e.RowIndex).Cells(13).Value = "dd-MMM-yyyy"
                End If
                'dateTimePicker2 = New DateTimePicker()
                'SBDGView.Controls.Add(dateTimePicker2)
                'dateTimePicker2.Format = DateTimePickerFormat.Short
                'Dim oRectangle As Rectangle = SBDGView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
                'dateTimePicker2.Size = New Size(oRectangle.Width, oRectangle.Height)
                'dateTimePicker2.Location = New Point(oRectangle.X, oRectangle.Y)
                'AddHandler dateTimePicker2.TextChanged, AddressOf DateTimePickerChange2
                'AddHandler SBDGView.Scroll, AddressOf DateTimePickerScroll2
                'SBDGView.Rows.Item(e.RowIndex).Cells(13).Value = SBDGView.Rows(e.RowIndex).Cells(12).Value
            End If



            If e.ColumnIndex = 14 Then
                Dim inyear, outyear As Date
                ' Dim tyear, tmonth, tday As String

                Try
                    conDate1 = Convert.ToDateTime(SBDGView.Rows(e.RowIndex).Cells(12).Value)
                    conDate2 = Convert.ToDateTime(SBDGView.Rows(e.RowIndex).Cells(13).Value)
                    inyear = conDate1.ToString("dd-MMM-yyyy")
                    outyear = conDate2.ToString("dd-MMM-yyyy")
                Catch ex As Exception
                    MsgBox("Please Input Sign On and Sign Off First")
                End Try


                '  doccertissued.Value.Date.ToString("yyyy-MM-dd")
                'inyear = Convert.ToDateTime(SBDGView.Rows.Item(e.RowIndex).Cells(12).ToString("dd-MMM-yyyy")).ToShortDateString
                'outyear = Convert.ToDateTime(SBDGView.Rows.Item(e.RowIndex).Cells(13).ToString("dd-MMM-yyyy")).ToShortDateString

                Difference(inyear, outyear)
                If year = 0 Then
                    SBDGView.Rows.Item(e.RowIndex).Cells(14).Value = Month.ToString + "." + Day.ToString
                Else
                    SBDGView.Rows.Item(e.RowIndex).Cells(14).Value = Month.ToString + "." + Day.ToString
                End If


            End If

        End If


        If (e.RowIndex >= 0) Then



            Try
                GetSeaID = SBDGView.Rows.Item(e.RowIndex).Cells(0).Value
                ' MsgBox(GetSeaID)
            Catch ex As Exception

            End Try


            Dim query As String
            Dim RefType As String

            ' RefID.Text = SBDGView.Rows.Item(e.RowIndex).Cells(0).Value

            RefLEN.ResetText()
            RefAdd.ResetText()
            RefPerson.ResetText()
            RefCPNo.ResetText()
            RefEmail.ResetText()


            RefLEN.ResetText()
            RefAdd.ResetText()
            RefPerson.ResetText()
            RefCPNo.ResetText()
            RefEmail.ResetText()

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            query = "SELECT Reference_ID, Ref_Name,Ref_Address,Ref_CPerson,Ref_Number,Ref_Email,Ref_Type,App_ID FROM hunters_pooling.applicant_reference WHERE App_ID = '" & GetAppID & "' order by reference_ID desc ;  "

            Dim command As OdbcCommand
            command = New OdbcCommand(query, conn)
            Dim reader As OdbcDataReader = command.ExecuteReader()



            While reader.Read

                RefType = reader.Item("Ref_Type").ToString()

                If RefType.ToString.Equals("Agency") Then
                    RefLEN.Text = reader.Item("Ref_Name").ToString()
                    RefAdd.Text = reader.Item("Ref_Address").ToString()
                    RefPerson.Text = reader.Item("Ref_CPerson").ToString()
                    RefCPNo.Text = reader.Item("Ref_Number").ToString()
                    RefEmail.Text = reader.Item("Ref_Email").ToString()

                End If

                If RefType.ToString.Equals("Principal") Then

                    RefPrin.Text = reader.Item("Ref_Name").ToString()
                    RefPriAdd.Text = reader.Item("Ref_Address").ToString()
                    RePrinCName.Text = reader.Item("Ref_CPerson").ToString()
                    RePrinCNo.Text = reader.Item("Ref_Number").ToString()
                    RePrinEmail.Text = reader.Item("Ref_Email").ToString()

                End If





                'PictureBox1.Image = Image.FromFile(x)

            End While

        End If
    End Sub

    Public Sub Difference(ByVal FD As DateTime, ByVal SD As DateTime)
        Day = 0
        Month = 0
        year = 0

        If FD <> SD Then
            If SD.Year > FD.Year Then
                year = SD.AddYears(-FD.Year).Year
            End If
            Month = SD.AddMonths(-FD.Month).Month
            If SD.Month <= FD.Month Then
                If year > 0 Then year -= 1
            End If
            Day = SD.AddDays(-FD.Day).Day
            If SD.Day <= FD.Day Then
                If Month > 0 Then Month -= 1
            End If
            If FD.Day = SD.Day Then
                Day = 0
                Month += 1
            End If
            If Month = 12 Then
                Month = 0
                year += 1
            End If
            If FD.Year = SD.Year AndAlso FD.Month = SD.Month Then
                year = 0

            End If

        Else
            MsgBox("Second Date Cannot Be Smaller")
        End If

    End Sub

End Class