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

Public Class EncodingForm

    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles Closebtn.Click
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Me.Close()
    End Sub

    Private Sub EncodingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim rankID As String
        'Query for Crew Name
        Dim rankstr As String
        rankstr = "SELECT Rank_ID, Rank_Fullname FROM csiaccountingdb.rank;"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        While rankmyReader.Read
            AppRank.Items.Add(rankmyReader.GetString(1))
            rankID = rankmyReader.GetInt32(0)
        End While

        AppBirthdate.Value = Date.Today.ToString("yyyy-MM-dd")
        SIRBIssued.Value = Date.Today.ToString("yyyy-MM-dd")
        SIRBExpired.Value = Date.Today.ToString("yyyy-MM-dd")
        PassportIssued.Value = Date.Today.ToString("yyyy-MM-dd")
        PassportExpired.Value = Date.Today.ToString("yyyy-MM-dd")
        LicenseIssued.Value = Date.Today.ToString("yyyy-MM-dd")
        SRCIssued.Value = Date.Today.ToString("yyyy-MM-dd")
        COCMARINAIssued.Value = Date.Today.ToString("yyyy-MM-dd")
        COCMARINAExpired.Value = Date.Today.ToString("yyyy-MM-dd")
        COEIssued.Value = Date.Today.ToString("yyyy-MM-dd")
        COEExpired.Value = Date.Today.ToString("yyyy-MM-dd")
        TesdaIssued.Value = Date.Today.ToString("yyyy-MM-dd")
        TesdaExpired.Value = Date.Today.ToString("yyyy-MM-dd")
        NCIssued.Value = Date.Today.ToString("yyyy-MM-dd")
        NCExpired.Value = Date.Today.ToString("yyyy-MM-dd")

        conn.Close()
    End Sub

    Public Sub Saving_Info()

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        'Sources
        Dim Walkin, SeafarersMarket, Internet, Referral, Program As String
        Dim commaSources As String = ", "
        Dim allSources As String
        Dim FinalCombinedSources As String
        Dim FinalCombinedSourcesTrimmed As String

        If CheckboxWalkin.Checked = True Then
            Walkin = (commaSources & WalkinLabel.Text)
        End If

        If CheckboxSeafarersMarket.Checked = True Then
            SeafarersMarket = (commaSources & SeafarersMarketLabel.Text)
        End If

        If CheckboxInternet.Checked = True Then
            Internet = (commaSources & InternetLabel.Text)
        End If

        If CheckboxReferral.Checked = True Then
            Referral = (commaSources & ReferralLabel.Text)
        End If

        If CheckboxProgram.Checked = True Then
            Program = (commaSources & ProgramLabel.Text)
        End If

        allSources = Walkin + SeafarersMarket + Internet + Referral + Program
        FinalCombinedSources = allSources.Trim(", ", "")
        FinalCombinedSourcesTrimmed = FinalCombinedSources.TrimStart()

        'INSERTING INFO HERE
        Dim AppInfoSTR As String
        AppInfoSTR = ("INSERT INTO hunters_pooling.applicant_info(App_LName,App_FName,App_MName,App_Suffix,App_NickName,App_Bday,App_BPlace,App_CivilStat,
                          App_ContactNo,App_Height,App_Weight,App_Religion,App_EmailAdd) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)")
        Dim AppInfocmd As OdbcCommand = New OdbcCommand(AppInfoSTR, conn)
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_LName", CType(AppLastName.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_FName", CType(AppMiddleName.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_MName", CType(AppSuffix.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Suffix", CType(AppFirstName.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_NickName", CType(AppFirstName.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Bday", CType(AppBirthdate.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_BPlace", CType(AppBirthPlace.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_CivilStat", CType(AppCivilStat.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_ContactNo", CType(AppContactNum.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Height", CType(AppHeight.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Weight", CType(AppWeight.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_Religion", CType(AppReligion.Text, String)))
        AppInfocmd.Parameters.Add(New OdbcParameter("@App_EmailAdd", CType(AppEmailAdd.Text, String)))
        AppInfocmd.ExecuteNonQuery()
        AppInfocmd.Dispose()

        'Query for Rank_ID
        Dim rankID As String
        'Query for Crew Name
        Dim rankstr As String
        rankstr = "SELECT Rank_ID FROM csiaccountingdb.rank;"
        Dim rankcommand As OdbcCommand
        rankcommand = New OdbcCommand(rankstr, conn)
        Dim rankmyReader As OdbcDataReader = rankcommand.ExecuteReader()
        While rankmyReader.Read
            '  AppRank.Items.Add(rankmyReader.GetString(1))
            rankID = rankmyReader.GetInt32(0)
        End While

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

        'INSERTING ADDRESS HERE
        Dim AppAddressSTR As String
        AppAddressSTR = ("INSERT INTO hunters_pooling.applicant_address(App_Address2,App_ID) VALUES (?,?)")
        Dim AppAddresscmd As OdbcCommand = New OdbcCommand(AppAddressSTR, conn)
        AppAddresscmd.Parameters.Add(New OdbcParameter("@App_Address2", CType(AppAddress.Text, String)))
        AppAddresscmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
        AppAddresscmd.ExecuteNonQuery()
        AppAddresscmd.Dispose()

        'INSERTING POSITION and SOURCE HERE
        Dim AppPosSourseSTR As String
        AppPosSourseSTR = ("INSERT INTO hunters_pooling.applicant_screening(App_Position,App_Source,App_ID,Rank_ID) VALUES (?,?,?,?)")
        Dim AppPosSoursecmd As OdbcCommand = New OdbcCommand(AppPosSourseSTR, conn)
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_Position", CType(AppRank.Text, String)))
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_Source", CType(FinalCombinedSourcesTrimmed, String)))
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
        AppPosSoursecmd.Parameters.Add(New OdbcParameter("@Rank_ID", CType(rankID, String)))
        AppPosSoursecmd.ExecuteNonQuery()
        AppPosSoursecmd.Dispose()
        'INSERTING DOCUMENTS HERE 

        '//SIRB
        Dim AppDocSIRBSTR As String
        AppDocSIRBSTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,ADoc_Expired,App_ID,Document_ID)  " &
                         "VALUES (?,?,?,?,?,?,?)")
        Dim AppDocSIRBcmd As OdbcCommand = New OdbcCommand(AppDocSIRBSTR, conn)
        AppDocSIRBcmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType("Seaman's Book", String)))
        AppDocSIRBcmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("SIRB", String)))
        AppDocSIRBcmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocSIRB.Text, String)))
        AppDocSIRBcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(SIRBIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppDocSIRBcmd.Parameters.Add(New OdbcParameter("@ADoc_Expired", CType(SIRBExpired.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppDocSIRBcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
        AppDocSIRBcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType("1004", String)))
        AppDocSIRBcmd.ExecuteNonQuery()
        AppDocSIRBcmd.Dispose()

        '//Passport
        Dim AppDocPassportSTR As String
        AppDocPassportSTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,ADoc_Expired,App_ID,Document_ID)  " &
                         "VALUES (?,?,?,?,?,?,?)")
        Dim AppDocPassportcmd As OdbcCommand = New OdbcCommand(AppDocPassportSTR, conn)
        AppDocPassportcmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType("Passport", String)))
        AppDocPassportcmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("Passport", String)))
        AppDocPassportcmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocPassport.Text, String)))
        AppDocPassportcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(PassportIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppDocPassportcmd.Parameters.Add(New OdbcParameter("@ADoc_Expired", CType(PassportExpired.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppDocPassportcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
        AppDocPassportcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType("1003", String)))
        AppDocPassportcmd.ExecuteNonQuery()
        AppDocPassportcmd.Dispose()

        '//SRC
        Dim AppDocSRCSTR As String
        AppDocSRCSTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,App_ID,Document_ID)  " &
                         "VALUES (?,?,?,?,?,?)")
        Dim AppDocSRCcmd As OdbcCommand = New OdbcCommand(AppDocSRCSTR, conn)
        AppDocSRCcmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType("Seafarer's Registration Certificate", String)))
        AppDocSRCcmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("SRC", String)))
        AppDocSRCcmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocSRC.Text, String)))
        AppDocSRCcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(SRCIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
        AppDocSRCcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
        AppDocSRCcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType("1005", String)))
        AppDocSRCcmd.ExecuteNonQuery()
        AppDocSRCcmd.Dispose()

        '//License
        'NOT DONE
        Dim AppDocLicenseSTR As String
        AppDocLicenseSTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,App_ID,Document_ID)  " &
                         "VALUES (?,?,?,?,?,?)")
        Dim AppDocLicensecmd As OdbcCommand = New OdbcCommand(AppDocLicenseSTR, conn)
        AppDocLicensecmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType("License", String)))
        AppDocLicensecmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("License", String)))
        AppDocLicensecmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocLicense.Text, String)))
        AppDocLicensecmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(LicenseIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
        ' AppDocLicensecmd.Parameters.Add(New OdbcParameter("@ADoc_DateExpired", CType("", Date)))
        AppDocLicensecmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
        AppDocLicensecmd.Parameters.Add(New OdbcParameter("@Document_ID", CType("1010", String)))
        AppDocLicensecmd.ExecuteNonQuery()
        AppDocLicensecmd.Dispose()

        '//VISA
        If DocVisa.Text = "" Then
        Else
            Dim AppDocVISASTR As String
            AppDocVISASTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,ADoc_Expired,App_ID,Document_ID)  " &
                             "VALUES (?,?,?,?,?,?,?)")
            Dim AppDocVISAcmd As OdbcCommand = New OdbcCommand(AppDocVISASTR, conn)
            AppDocVISAcmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType(DocVisaComboBox.Text, String)))
            AppDocVISAcmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("VISA", String)))
            AppDocVISAcmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocVisa.Text, String)))
            AppDocVISAcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(VISAIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocVISAcmd.Parameters.Add(New OdbcParameter("@ADoc_Expired", CType(VisaExpired.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocVISAcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
            AppDocVISAcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType("1571", String)))
            AppDocVISAcmd.ExecuteNonQuery()
            AppDocVISAcmd.Dispose()
        End If

        '//COC MARINA
        If DocCOCMarina.Text = "" Then
        Else
            Dim AppDocCOCMSTR As String
            AppDocCOCMSTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,ADoc_Expired,App_ID,Document_ID)  " &
                             "VALUES (?,?,?,?,?,?,?)")
            Dim AppDocCOCMcmd As OdbcCommand = New OdbcCommand(AppDocCOCMSTR, conn)
            AppDocCOCMcmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType("Certificate of Competency", String)))
            AppDocCOCMcmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("COC", String)))
            AppDocCOCMcmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocCOCMarina.Text, String)))
            AppDocCOCMcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(COCMARINAIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocCOCMcmd.Parameters.Add(New OdbcParameter("@ADoc_Expired", CType(COCMARINAExpired.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocCOCMcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
            AppDocCOCMcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType("1011", String)))
            AppDocCOCMcmd.ExecuteNonQuery()

            AppDocCOCMcmd.Dispose()
        End If


        '//COE
        If DocCOE.Text = "" Then
        Else
            Dim AppDocCOESTR As String
            AppDocCOESTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,ADoc_Expired,App_ID,Document_ID)  " &
                             "VALUES (?,?,?,?,?,?,?)")
            Dim AppDocCOEcmd As OdbcCommand = New OdbcCommand(AppDocCOESTR, conn)
            AppDocCOEcmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType("Certificate of Endorsement", String)))
            AppDocCOEcmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("COE", String)))
            AppDocCOEcmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocCOE.Text, String)))
            AppDocCOEcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(COEIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocCOEcmd.Parameters.Add(New OdbcParameter("@ADoc_Expired", CType(COEExpired.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocCOEcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
            AppDocCOEcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType("1012", String)))
            AppDocCOEcmd.ExecuteNonQuery()
            AppDocCOEcmd.Dispose()
        End If

        '//COC TESDA
        'NOT DONE
        If DocTesda.Text = "" Then
        Else
            Dim AppDocTesdaSTR As String
            AppDocTesdaSTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,ADoc_Expired,App_ID,Document_ID)  " &
                             "VALUES (?,?,?,?,?,?,?)")
            Dim AppDocTesdacmd As OdbcCommand = New OdbcCommand(AppDocTesdaSTR, conn)
            AppDocTesdacmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType("TESDA Training", String)))
            AppDocTesdacmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("TESDA", String)))
            AppDocTesdacmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocTesda.Text, String)))
            AppDocTesdacmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(TesdaIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocTesdacmd.Parameters.Add(New OdbcParameter("@ADoc_Expired", CType(TesdaExpired.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocTesdacmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
            AppDocTesdacmd.Parameters.Add(New OdbcParameter("@Document_ID", CType("1999", String)))
            AppDocTesdacmd.ExecuteNonQuery()

            AppDocTesdacmd.Dispose()
        End If


        'Doc_ID for NC Training
        Dim NCTrainingID As String
        If DocNCCombobox.SelectedIndex = 0 Then
            NCTrainingID = "1493"

        ElseIf DocNCCombobox.SelectedIndex = 1 Then
            NCTrainingID = "1135"

        ElseIf DocNCCombobox.SelectedIndex = 2 Then
            NCTrainingID = "1483"
        End If

        '//NC Training
        If DocNC.Text = "" Then
        Else
            Dim AppDocNCSTR As String
            AppDocNCSTR = ("INSERT INTO hunters_pooling.applicant_docs(ADoc_Name,ADoc_Shortcut,ADoc_No,ADoc_DateIssued,ADoc_Expired,App_ID,Document_ID) 
                            VALUES (?,?,?,?,?,?,?)")
            Dim AppDocNCcmd As OdbcCommand = New OdbcCommand(AppDocNCSTR, conn)
            AppDocNCcmd.Parameters.Add(New OdbcParameter("@ADoc_Name", CType(DocNCCombobox.Text, String)))
            AppDocNCcmd.Parameters.Add(New OdbcParameter("@ADoc_Shortcut", CType("VISA", String)))
            AppDocNCcmd.Parameters.Add(New OdbcParameter("@ADoc_No", CType(DocNC.Text, String)))
            AppDocNCcmd.Parameters.Add(New OdbcParameter("@ADoc_DateIssued", CType(NCIssued.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocNCcmd.Parameters.Add(New OdbcParameter("@ADoc_Expired", CType(NCExpired.Value.Date.ToString("yyyy-MM-dd"), Date)))
            AppDocNCcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(AppIDoutput, String)))
            AppDocNCcmd.Parameters.Add(New OdbcParameter("@Document_ID", CType(NCTrainingID, String)))
            AppDocNCcmd.ExecuteNonQuery()
            AppDocNCcmd.Dispose()
        End If

        conn.Close()

    End Sub

    Public Sub Checking()
        'Checking ng system sa mga hindi nafill-up-an
        If Len(Trim(AppLastName.Text)) = 0 Then
            MessageBox.Show("Please enter Last Name", "Input Error", MessageBoxButtons.OK)
            AppLastName.Focus()
            Exit Sub

        ElseIf Len(Trim(AppFirstName.Text)) = 0 Then
            MessageBox.Show("Please enter First Name", "Input Error", MessageBoxButtons.OK)
            AppFirstName.Focus()
            Exit Sub

        ElseIf Len(Trim(AppMiddleName.Text)) = 0 Then
            MessageBox.Show("Please enter Middle Name", "Input Error", MessageBoxButtons.OK)
            AppMiddleName.Focus()
            Exit Sub

        ElseIf AppRank.Text = "" Then
            MessageBox.Show("Please select your current Rank", "Input Error", MessageBoxButtons.OK)
            AppRank.Focus()
            Exit Sub

        ElseIf Len(Trim(AppBirthPlace.Text)) = 0 Then
            MessageBox.Show("Please enter Birth Place", "Input Error", MessageBoxButtons.OK)
            AppBirthPlace.Focus()
            Exit Sub

        ElseIf AppBirthdate.Value = Date.Today Then
            MessageBox.Show("Please enter your Birth Date", "Input Error", MessageBoxButtons.OK)
            AppBirthdate.Focus()
            Exit Sub

        ElseIf Len(Trim(AppCivilStat.Text)) = 0 Then
            MessageBox.Show("Please enter Civil Status", "Input Error", MessageBoxButtons.OK)
            AppCivilStat.Focus()
            Exit Sub

        ElseIf Len(Trim(AppAddress.Text)) = 0 Then
            MessageBox.Show("Please enter Address", "Input Error", MessageBoxButtons.OK)
            AppAddress.Focus()
            Exit Sub

        ElseIf Len(Trim(AppContactNum.Text)) = 0 Then
            MessageBox.Show("Please enter Contact Number", "Input Error", MessageBoxButtons.OK)
            AppContactNum.Focus()
            Exit Sub

        ElseIf Len(Trim(AppHeight.Text)) = 0 Then
            MessageBox.Show("Please enter Height", "Input Error", MessageBoxButtons.OK)
            AppHeight.Focus()
            Exit Sub

        ElseIf Len(Trim(AppWeight.Text)) = 0 Then
            MessageBox.Show("Please enter Weight in Pounds(lbs)", "Input Error", MessageBoxButtons.OK)
            AppWeight.Focus()
            Exit Sub

        ElseIf Len(Trim(AppReligion.Text)) = 0 Then
            MessageBox.Show("Please enter Religion", "Input Error", MessageBoxButtons.OK)
            AppReligion.Focus()
            Exit Sub

        ElseIf Len(Trim(AppEmailAdd.Text)) = 0 Then
            MessageBox.Show("Please enter Email Address", "Input Error", MessageBoxButtons.OK)
            AppEmailAdd.Focus()
            Exit Sub

            'Checking Documents
        ElseIf Len(Trim(DocSIRB.Text)) = 0 Then
            MessageBox.Show("Please enter SIRB Number", "Input Error", MessageBoxButtons.OK)
            DocSIRB.Focus()
            Exit Sub

        ElseIf Len(Trim(DocSRC.Text)) = 0 Then
            MessageBox.Show("Please enter SRC Number", "Input Error", MessageBoxButtons.OK)
            DocSRC.Focus()
            Exit Sub

        ElseIf Len(Trim(DocPassport.Text)) = 0 Then
            MessageBox.Show("Please enter Passport Number", "Input Error", MessageBoxButtons.OK)
            DocPassport.Focus()
            Exit Sub

        ElseIf Len(Trim(DocLicense.Text)) = 0 Then
            MessageBox.Show("Please enter License Number", "Input Error", MessageBoxButtons.OK)
            DocLicense.Focus()
            Exit Sub

        ElseIf DocVisaComboBox.Text = "" Then
            MessageBox.Show("Please select Visa", "Input Error", MessageBoxButtons.OK)
            DocSRC.Focus()
            Exit Sub

            'Checking Documents Date
        ElseIf SIRBIssued.Value = Date.Today Then
            MessageBox.Show("Please enter Date Issued of SIRB", "Input Error", MessageBoxButtons.OK)
            SIRBIssued.Focus()
            Exit Sub

        ElseIf SIRBExpired.Value = Date.Today Then
            MessageBox.Show("Please enter Date Expired of SIRB", "Input Error", MessageBoxButtons.OK)
            SIRBExpired.Focus()
            Exit Sub

        ElseIf PassportIssued.Value = Date.Today Then
            MessageBox.Show("Please enter Date Issued of Passport", "Input Error", MessageBoxButtons.OK)
            PassportIssued.Focus()
            Exit Sub

        ElseIf PassportExpired.Value = Date.Today Then
            MessageBox.Show("Please enter Date Expired of Passport", "Input Error", MessageBoxButtons.OK)
            PassportExpired.Focus()
            Exit Sub

        ElseIf SRCIssued.Value = Date.Today Then
            MessageBox.Show("Please enter Date Issued of SRC", "Input Error", MessageBoxButtons.OK)
            SRCIssued.Focus()
            Exit Sub

        Else
            Saving_Info()
            conn.Close()
            Me.Hide()
            MsgBox("Save")
            Pooling.Show()
        End If

    End Sub

    Private Sub NextBtn_Click(sender As Object, e As EventArgs) Handles NextBtn.Click


    End Sub

    Private Sub AppFirstName_OnValueChanged(sender As Object, e As EventArgs) Handles AppFirstName.OnValueChanged

    End Sub

    Private Sub AppMiddleName_OnValueChanged(sender As Object, e As EventArgs) Handles AppMiddleName.OnValueChanged

    End Sub

    Private Sub AppRank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppRank.SelectedIndexChanged

    End Sub

    Private Sub NCExpired_onValueChanged(sender As Object, e As EventArgs) Handles NCExpired.onValueChanged

    End Sub
End Class