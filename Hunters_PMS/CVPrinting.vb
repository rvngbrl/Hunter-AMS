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


Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports Excel = Microsoft.Office.Interop.Excel




Public Class CVPrinting


    Dim principalID As String
    Public Property username As String
    Public Property appage As String
    Public Property GetAppID As String = 1940
    Public Property rankID As String
    Public Property GetCrewID As String
    Private PageNum As Integer = 1
    Public Property GetVesselID As String
    Public ReadOnly Property PageSettings As PageSettings
    Dim Year, Month, Day As Integer

    ' this property is for COiPrint
    Public Property yrec As Integer
    Public Property lastindex As Integer

    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")

    'info
    Dim Lname, Fname, Mname, Suffix, NNname, Address, Address2, citizenship, Bplace, CivilStat, ContactNo, ContactNo2, Vessel, Principal,VesselFlag As String
    Dim Sex, Religion, ZipCode, City, EmailAdd, Pagibig, Tin, SSS, Philhealth, Heights, Weight, Shirtsize, Suitsize, WaisteSize, ShoeSize, Skype, Whatsapp As String

    'ref
    Dim refName, refAddress, refCPerson, refNumber, refEmail, refType As String
    Dim HSchool, HSchoolFr, HSchooolTo, CCourse, CStudies, CYear, VSchool, VSchoolCourse, VSchooolTo As String
    Dim CHSchoolFr, CHSchooolTo, CVSchoolFr, CVSchooolTo As Date

    'family
    Dim Klname, KFname, KMname, KSuffix, Kaddress, KBplace, KSex, KContact, KRelation, KOccupation, KStat, KPassport, KPsprtPlace As String
    Dim KBday, KPsprtIssued, KPsprtExpired As Date

    'crewdoc
    Dim docid, dateissued,dateexpired, docname, docshortcut, docno, docplace, docexpired, doccountry, crewdocid, docstatus As String

    Dim null As String = ""


    'crewcert
    Dim certissued, certexpired, certdocid, certname, certshortcut, certno, certplace, certcountry, certtraining, certstatus As String


    Dim filenamepic As String
    'screening
    Dim rankapplied As String
    Dim dateapplied As Date

    Dim datenow As Date = Date.UtcNow
    Dim Bday, DateMarriage As Date



    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Esm03_Click(sender As Object, e As EventArgs) Handles Esm03.Click
        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized
        PPV.Document.DefaultPageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1100)
        AddHandler PD.PrintPage, AddressOf Esm03Print_PrintPage


        'Printing na may set up ng page
        Dim AmsPrintDialog As New PrintDialog()
        ' PrintDialog1.Document = CvPrint


        If AmsPrintDialog.ShowDialog(PPV) = Windows.Forms.DialogResult.OK Then
            EsmPrint.PrinterSettings = AmsPrintDialog.PrinterSettings
            AmsPrintDialog.AllowSomePages = True
            Esm03Print.Print()
            'esm09Print.Print()
            Me.Hide()
        End If
    End Sub
    ' esm09Print_PrintPage
    '/////////////////////////////ESM 03///////////////////////////////////
    Private Sub Esm03Print_PrintPage(sender As Object, e As PrintPageEventArgs) Handles Esm03Print.PrintPage
        Dim Font As New Font(" Nirmala UI", 14, FontStyle.Bold)
        Dim Font10B As New Font("Nirmala UI", 10, FontStyle.Bold)
        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)
        Dim Font12B As New Font("Nirmala UI", 12, FontStyle.Bold)
        Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
        Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)
        Dim Font9 As New Font("Nirmala UI", 9, FontStyle.Regular)
        Dim Font8 As New Font("Nirmala UI", 8, FontStyle.Regular)
        Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
        Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)
        Dim bg As SolidBrush = New SolidBrush(Color.SkyBlue)
        Dim bg1 As SolidBrush = New SolidBrush(Color.LightGray)


        Select Case PageNum
            Case 1
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\OC9_Offshore_Page_1.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image         
                e.Graphics.DrawImage(newImage, 0, 0, 827, 1169)
                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)


                Dim selinfo As String
                selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year ,ae.School_From, ae.School_To, ae.School_Name, ae.Voc_Course,ae.Voc_To, ae.Voc_School, sc.App_RankApplied, sc.App_DateApplied,ai.App_Picture
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
 LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

                Dim selinfocmd As OdbcCommand
                selinfocmd = New OdbcCommand(selinfo, conn)
                Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

                Dim Fullname As String

                If selinforeader.Read Then



                    Lname = selinforeader.Item("App_LName").ToString

                    Fname = selinforeader.Item("App_FName").ToString
                    Mname = selinforeader.Item("App_MName").ToString

                    Fullname = Lname + ",  " + Fname + "  " + Mname

                    Suffix = selinforeader.Item("App_Suffix").ToString
                    NNname = selinforeader.Item("App_Nickname").ToString
                    Address = selinforeader.Item("Address").ToString
                    Address2 = selinforeader.Item("App_address2").ToString
                    citizenship = selinforeader.Item("App_Citezenship").ToString
                    Bday = selinforeader.Item("App_Bday").Date.ToString()
                    Bplace = selinforeader.Item("App_BPlace").ToString
                    CivilStat = selinforeader.Item("App_CivilStat").ToString
                    DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
                    ContactNo = selinforeader.Item("App_ContactNo").ToString
                    ContactNo2 = selinforeader.Item("App_ContactNo2").ToString
                    Sex = selinforeader.Item("App_Sex").ToString
                    Religion = selinforeader.Item("App_Religion").ToString
                    EmailAdd = selinforeader.Item("App_EmailAdd").ToString
                    Pagibig = selinforeader.Item("App_PagibigNo").ToString
                    Tin = selinforeader.Item("App_TinNo").ToString
                    SSS = selinforeader.Item("App_SSSNo").ToString
                    Philhealth = selinforeader.Item("App_PhilHealthNo").ToString
                    Heights = selinforeader.Item("App_Height").ToString
                    Weight = selinforeader.Item("App_Weight").ToString
                    Shirtsize = selinforeader.Item("App_ShirtSize").ToString
                    Suitsize = selinforeader.Item("App_SuitSize").ToString
                    WaisteSize = selinforeader.Item("App_WaisteSize").ToString
                    ShoeSize = selinforeader.Item("App_ShoeSize").ToString
                    CCourse = selinforeader.Item("Studies_Course").ToString
                    CStudies = selinforeader.Item("Studies_Name").ToString
                    CYear = selinforeader.Item("Studies_Year").ToString
                    HSchool = selinforeader.Item("School_Name").ToString
                    HSchoolFr = selinforeader.Item("School_From").ToString
                    HSchooolTo = selinforeader.Item("School_To").ToString
                    VSchool = selinforeader.Item("Voc_School").ToString
                    VSchoolCourse = selinforeader.Item("Voc_Course").ToString
                    VSchooolTo = selinforeader.Item("Voc_To").ToString
                    rankapplied = selinforeader.Item("App_RankApplied").ToString
                    dateapplied = selinforeader.Item("App_DateApplied").ToString
                    filenamepic = selinforeader.Item("App_Picture").ToString

                    CHSchoolFr = Convert.ToDateTime(HSchoolFr)
                    CHSchooolTo = Convert.ToDateTime(HSchooolTo)
                    '     CVSchoolFr = Convert.ToDateTime(VSchoolFr)
                End If

                Dim courseyear As String

                courseyear = CYear + "\ " + CCourse

                filenamepic = selinforeader.Item("App_Picture").ToString
                Try

                    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                    e.Graphics.DrawImage(newDp, 630, 160, 120, 120)

                Catch ex As Exception

                End Try



                e.Graphics.DrawString(Fname, Font10B, Brushes.Black, 150, 80)

                e.Graphics.DrawString(Mname, Font10B, Brushes.Black, 400, 80)
                e.Graphics.DrawString(Lname, Font10B, Brushes.Black, 650, 80)
                e.Graphics.DrawString(Address, Font9, Brushes.Black, 180, 170)
                e.Graphics.DrawString(citizenship, Font9, Brushes.Black, 150, 100)
                e.Graphics.DrawString(Bplace, Font8, Brushes.Black, 400, 100)
                e.Graphics.DrawString(Bday, Font9, Brushes.Black, 680, 100)
                e.Graphics.DrawString(rankapplied, Font10B, Brushes.Black, 170, 120)

                e.Graphics.DrawString(ContactNo, Font10B, Brushes.Black, 420, 265)

                e.Graphics.DrawString(EmailAdd, Font10, Brushes.Black, 140, 288)

                e.Graphics.DrawString(Heights, Font9, Brushes.Black, 100, 768)
                e.Graphics.DrawString(Weight, Font10, Brushes.Black, 250, 768)
                e.Graphics.DrawString(Suitsize, Font7, Brushes.Black, 530, 768)
                e.Graphics.DrawString(ShoeSize, Font10, Brushes.Black, 750, 768)


                'All
                Dim doccertstr As String
                doccertstr = "Select Document_ID, AppCert_Name, AppCert_No, AppCert_Place,  date_format(AppCert_DateIssued, '%d-%b-%Y') AS datein,   date_format(AppCert_DateExpired, '%d-%b-%Y') as dateout, App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' 
                           UNION 
                           Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, date_format(AppDoc_DateIssued, '%d-%b-%Y')AS datein, date_format(AppDoc_DateExpired, '%d-%b-%Y') as dateout, App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID = '" & GetAppID & "'; "
                Dim doccertcommand As OdbcCommand
                doccertcommand = New OdbcCommand(doccertstr, conn)
                Dim doccertreader As OdbcDataReader = doccertcommand.ExecuteReader()
                While doccertreader.Read
                    certdocid = doccertreader.Item("Document_ID").ToString()
                    certname = doccertreader.Item("AppCert_Name").ToString()
                    certno = doccertreader.Item("AppCert_No").ToString()
                    certplace = doccertreader.Item("AppCert_Place").ToString()
                    certissued = doccertreader.Item("datein").ToString
                    certexpired = doccertreader.Item("dateout").ToString()



                    If certdocid.ToString.Equals("1003") Then
                        'Passport
                        e.Graphics.DrawString(certno, Font10, Brushes.Black, 60, 350) 'PASSPORTNO
                        e.Graphics.DrawString(certissued, Font10, Brushes.Black, 180, 350) 'PASSPORTexpired
                        e.Graphics.DrawString(certexpired.ToString(), Font10, Brushes.Black, 300, 350) 'PASSPORTexpired
                        e.Graphics.DrawString(certplace, Font10, Brushes.Black, 410, 350) 'PASSPORTexpired
                    End If

                    If certdocid.ToString.Equals("1004") Then
                        'SIRB no1
                        e.Graphics.DrawString(certno, Font10, Brushes.Black, 210, 420)
                        e.Graphics.DrawString(certissued, Font10, Brushes.Black, 325, 420)
                        e.Graphics.DrawString(certexpired, Font10, Brushes.Black, 420, 420) '
                        e.Graphics.DrawString("PH", Font10, Brushes.Black, 540, 420) '
                        e.Graphics.DrawString(certplace, Font10, Brushes.Black, 680, 420)

                    End If

                    If certdocid.ToString.Equals("1013") Then
                        'goc-license
                        e.Graphics.DrawString(certname, Font10B, Brushes.Black, 60, 473)
                        e.Graphics.DrawString(certno, Font10B, Brushes.Black, 180, 473)
                        e.Graphics.DrawString(certissued, Font10B, Brushes.Black, 300, 473)
                        e.Graphics.DrawString(certexpired.ToString(), Font10B, Brushes.Black, 390, 473)
                        e.Graphics.DrawString("PH", Font10B, Brushes.Black, 530, 473)
                        e.Graphics.DrawString(certplace, Font10B, Brushes.Black, 655, 473)
                    End If

                    If certdocid.ToString.Equals("1104") Then
                        'GMDSS
                        e.Graphics.DrawString(certshortcut, Font9, Brushes.Black, 65, 445)
                        e.Graphics.DrawString(certno, Font9, Brushes.Black, 180, 445)
                        e.Graphics.DrawString(certissued, Font9, Brushes.Black, 290, 445)
                        e.Graphics.DrawString(certexpired, Font9, Brushes.Black, 390, 445)
                        e.Graphics.DrawString("PH", Font10B, Brushes.Black, 500, 473)
                        e.Graphics.DrawString(certplace, Font9, Brushes.Black, 490, 445)
                    End If


                    'If certdocid.ToString.Equals("1468") Then
                    '    'BTCERTNO
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 590)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 590)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 590)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 590)
                    'End If
                    'If certdocid.ToString.Equals("1468") Then
                    '    'BFF
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 620)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 620)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 620)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 620)
                    'End If
                    'If certdocid.ToString.Equals("1477") Then
                    '    'AFF
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 650)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 650)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 650)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 650)
                    'End If
                    'If certdocid.ToString.Equals("1102") Then
                    '    'EFA
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 680)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 680)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 680)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 680)
                    'End If
                    'If certdocid.ToString.Equals("1043") Then
                    '    'MFA
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 710)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 710)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 710)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 710)
                    'End If
                    'If certdocid.ToString.Equals("1044") Then
                    '    'Meca
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 740)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 740)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 740)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 740)
                    'End If

                    'If certdocid.ToString.Equals("0001") Then
                    '    'pst
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 770)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 770)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 770)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 770)
                    'End If
                    'If certdocid.ToString.Equals("1568") Then
                    '    'pscrb
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 800)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 800)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 800)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 800)
                    'End If
                    'If certdocid.ToString.Equals("1239") Then
                    '    'btm
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 830)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 830)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 830)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 830)
                    'End If
                    'If certdocid.ToString.Equals("0001") Then
                    '    'pssr
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 860)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 860)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 860)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 860)
                    'End If
                    'If certdocid.ToString.Equals("1145") Then
                    '    'brm
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 903)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 903)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 903)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 903)
                    'End If
                    'If certdocid.ToString.Equals("1231") Then
                    '    'arpa
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 933)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 933)
                    '    e.Graphics.DrawString(cetnewexpired.ToString("MM-dd-yyyy"), Font8, Brushes.Black, 510, 933)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 933)
                    'End If

                    'If certdocid.ToString.Equals("1105") Then
                    '    'ecdis
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 963)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 963)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 963)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 963)
                    'End If

                    'If certdocid.ToString.Equals("1657") Then
                    '    'ecdis-jrc
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 993)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 993)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 993)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 993)
                    'End If

                    'If certdocid.ToString.Equals("1122") Then
                    '    'sms
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1048)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1048)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 1048)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1048)
                    'End If

                    'If certdocid.ToString.Equals("1164") Then
                    '    'ers
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1078)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1078)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1078)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1078)
                    'End If
                    'If certdocid.ToString.Equals("1361") Then
                    '    'soc
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1108)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1108)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1108)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1108)
                    'End If
                    'If certdocid.ToString.Equals("1032") Then
                    '    'sso
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1138)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1136)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1136)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1136)
                    'End If
                    'If certdocid.ToString.Equals("0001") Then
                    '    'stfs
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1166)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1166)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1166)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1166)
                    'End If

                End While
                'kinners
                Dim kinStr As String
                kinStr = "Select appkin_ID, CONCAT(appkin_LName,', ',appkin_FName,' ',appkin_MName,' ',appkin_Suffix) AS 'Name' ,appkin_Relation ,appkin_Bday, appkin_Passport,appkin_IssueDate, appkin_ExpiryDate,  appkin_PsprtPlaceIssue FROM hunters_pooling.applicant_family where App_ID=" & GetAppID & ";"

                Dim kincmd As OdbcCommand
                kincmd = New OdbcCommand(kinStr, conn)
                Dim kinreader As OdbcDataReader = kincmd.ExecuteReader()
                Dim Ykin = 640
                While kinreader.Read

                    KFname = kinreader.Item("Name").ToString()
                    KBday = kinreader.Item("appkin_Bday").Date.ToString
                    KPassport = kinreader.Item("appkin_Passport").ToString()
                    KPsprtIssued = kinreader.Item("appkin_IssueDate").Date.ToString()
                    KPsprtExpired = kinreader.Item("appkin_ExpiryDate").Date.ToString()
                    KPsprtPlace = kinreader.Item("appkin_PsprtPlaceIssue").ToString()
                    KRelation = kinreader.Item("appkin_Relation").ToString()


                    If KRelation.ToString.Equals("Wife") Then

                        e.Graphics.DrawString(KFname, Font9, Brushes.Black, 130, Ykin)
                        e.Graphics.DrawString(KBday, Font9, Brushes.Black, 2850, Ykin)
                        e.Graphics.DrawString(KPassport, Font9, Brushes.Black, 380, Ykin)

                        e.Graphics.DrawString(KPsprtIssued, Font9, Brushes.Black, 485, Ykin)
                        e.Graphics.DrawString(KPsprtExpired.ToString(), Font9, Brushes.Black, 585, Ykin)
                        e.Graphics.DrawString(KPsprtPlace, Font9, Brushes.Black, 700, Ykin)
                    End If

                    If KRelation.ToString.Equals("Daugther") And KRelation.ToString.Equals("Son") Then

                        e.Graphics.DrawString(KFname, Font9, Brushes.Black, 125, Ykin)
                        e.Graphics.DrawString(KBday, Font9, Brushes.Black, 270, Ykin)
                        e.Graphics.DrawString(KPassport, Font9, Brushes.Black, 370, Ykin)

                        e.Graphics.DrawString(KPsprtIssued, Font9, Brushes.Black, 470, Ykin)
                        e.Graphics.DrawString(KPsprtExpired.ToString(), Font9, Brushes.Black, 570, Ykin)
                        e.Graphics.DrawString(KPsprtPlace, Font9, Brushes.Black, 680, Ykin)
                        Ykin = Ykin + 30
                    End If


                End While

                e.HasMorePages = True
            Case 2
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\OC9_Offshore_Page_2.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image         
                e.Graphics.DrawImage(newImage, 0, 0, 827, 1169)


                'All
                Dim doccertstr As String
                doccertstr = "Select Document_ID, AppCert_Name, AppCert_No, AppCert_Place,  date_format(AppCert_DateIssued, '%d-%b-%Y') AS datein,   date_format(AppCert_DateExpired, '%d-%b-%Y') as dateout, App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' 
                           UNION 
                           Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place,  date_format(AppDoc_DateIssued, '%d-%b-%Y')AS datein, date_format(AppDoc_DateExpired, '%d-%b-%Y') as dateout, App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID = '" & GetAppID & "'; "
                Dim doccertcommand As OdbcCommand
                doccertcommand = New OdbcCommand(doccertstr, conn)
                Dim doccertreader As OdbcDataReader = doccertcommand.ExecuteReader()
                While doccertreader.Read
                    certdocid = doccertreader.Item("Document_ID").ToString()
                    certname = doccertreader.Item("AppCert_Name").ToString()
                    certno = doccertreader.Item("AppCert_No").ToString()
                    certplace = doccertreader.Item("AppCert_Place").ToString()
                    certissued = doccertreader.Item("datein").ToString()
                    certexpired = doccertreader.Item("dateout").ToString()




                    If certdocid.ToString.Equals("1477") Then
                        'AFF
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 220)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 220)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 520, 220)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 220)
                    End If

                    If certdocid.ToString.Equals("1231") Then
                        'arpa
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 240)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 240)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 520, 240)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 240)
                    End If

                    If certdocid.ToString.Equals("1468") Then
                        'BFF
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 255)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 255)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 520, 255)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 255)
                    End If

                    If certdocid.ToString.Equals("1145") Then
                        'brm -1145
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 293)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 293)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 520, 293)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 293)
                    End If

                    If certdocid.ToString.Equals("1239") Then
                        'btm-1239
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 310)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 310)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 520, 310)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 310)
                    End If

                    If certdocid.ToString.Equals("1498") Then
                        'advancedp no11 --1498
                        e.Graphics.DrawString(certno, Font7, Brushes.Black, 290, 380) 'ADVANCEDPNO
                        e.Graphics.DrawString(certissued, Font7, Brushes.Black, 410, 380) 'ADVANCEDPissued
                        e.Graphics.DrawString(certexpired.ToString(), Font7, Brushes.Black, 520, 380) 'ADVANCEDPexpired
                        e.Graphics.DrawString(certplace, Font7, Brushes.Black, 620, 380)
                    End If


                    If certdocid.ToString.Equals("1105") Then
                        'ecdis-1105
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 415)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 415)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 415)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 415)
                    End If

                    If certdocid.ToString.Equals("1102") Then
                        'EFA--1102
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 432)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 432)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 432)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 432)
                    End If


                    If certdocid.ToString.Equals("1164") Then
                        'ers-1164
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 450)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 450)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 450)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 450)
                    End If

                    If certdocid.ToString.Equals("1043") Then
                        'MFA-1043
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 500)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 500)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 500)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 500)
                    End If


                    If certdocid.ToString.Equals("1044") Then
                        'Meca-1044
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 520)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 520)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 520)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 520)
                    End If


                    If certdocid.ToString.Equals("0001") Then
                        'pst---0001
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 563)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 563)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 563)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 563)
                    End If



                    If certdocid.ToString.Equals("1117") Then
                        'pfrb-1117
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 580)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 580)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 580)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 580)
                    End If

                    If certdocid.ToString.Equals("1468") Then
                        'pscrb
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 610)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 610)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 610)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 610)
                    End If

                    If certdocid.ToString.Equals("1240") Then
                        'roc-1240
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 628)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 628)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 628)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 628)
                    End If

                    If certdocid.ToString.Equals("1106") Then
                        'rsc-1106
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 648)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 648)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 648)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 648)
                    End If

                    If certdocid.ToString.Equals("1234") Then
                        'ship-handling-1234
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 720)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 720)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 720)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 720)
                    End If
                    If certdocid.ToString.Equals("1032") Then
                        'sso-1032
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 737)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 737)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 737)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 737)
                    End If


                    If certdocid.ToString.Equals("1361") Then
                        'soc-1361
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 290, 755)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 755)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 755)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 755)
                    End If






                    'If certdocid.ToString.Equals("0001") Then
                    '    'pssr
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 860)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 860)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 860)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 860)
                    'End If



                    'If certdocid.ToString.Equals("1105") Then
                    '    'ecdis
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 963)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 963)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 963)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 963)
                    'End If

                    'If certdocid.ToString.Equals("1657") Then
                    '    'ecdis-jrc
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 993)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 993)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 993)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 993)
                    'End If

                    'If certdocid.ToString.Equals("1122") Then
                    '    'sms
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1048)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1048)
                    '    e.Graphics.DrawString(cetnewexpired, Font8, Brushes.Black, 510, 1048)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1048)
                    'End If




                    'If certdocid.ToString.Equals("0001") Then
                    '    'stfs
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1166)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1166)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1166)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1166)
                    'End If

                End While




                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                e.HasMorePages = True
            Case 3
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\OC9_Offshore_Page_3.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image         
                e.Graphics.DrawImage(newImage, 0, 0, 827, 1169)

                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                e.HasMorePages = True
            Case 4
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\OC9_Offshore_Page_4.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image         
                e.Graphics.DrawImage(newImage, 0, 0, 827, 1169)


        End Select
        PageNum += 1


    End Sub


    '/////////////////////////////ESM TANKER 04///////////////////////////////////
    Private Sub Esm_Tanker_04_PrintPage(sender As Object, e As PrintPageEventArgs) Handles Esm_Tanker_04.PrintPage
        Dim Font As New Font("Arial", 10, FontStyle.Regular)

        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)

        Dim FontMID As New Font("Arial", 12, FontStyle.Regular)

        '    Dim Font As New Font(" Nirmala UI", 14, FontStyle.Bold)
        Dim Font10B As New Font("Nirmala UI", 10, FontStyle.Bold)

        Dim Font12B As New Font("Nirmala UI", 12, FontStyle.Bold)
        Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
        Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)
        Dim Font9 As New Font("Nirmala UI", 9, FontStyle.Regular)
        Dim Font8 As New Font("Nirmala UI", 8, FontStyle.Regular)
        Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
        Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)
        Dim Font6 As New Font("Nirmala UI", 6, FontStyle.Regular)

        Dim Fontbox As New Font("Arial", 8, FontStyle.Regular)

        Dim fontdate As New Font("Arial", 7, FontStyle.Regular)
        Dim fontinside As New Font("Arial", 10, FontStyle.Regular)
        Dim fontside As New Font("Arial", 9, FontStyle.Regular)
        Dim FontMID1 As New Font("Arial", 12, FontStyle.Regular)

        Select Case PageNum
            Case 1
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\ESM TANKER OC09-melba_Page_1.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                e.Graphics.DrawImage(newImage, 1, 1, 1300, 855)

                Dim counter As Integer = 0
                Dim ysb = 155
                Dim sbstr As String
                'sqlquery

                sbstr = "SELECT App_PrincipalName,App_Rank, App_VesselName, App_ImportFlag, App_VesselType, App_EngineType, App_GRT, App_KW, App_TradingRoute, App_DateSignedON, App_DateSignedOFF, App_Duration,App_Reason FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc  limit 15 ; "

                Dim sbcmd As OdbcCommand
                sbcmd = New OdbcCommand(sbstr, conn)
                Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()
                Dim inyear, outyear As Date
                Dim tyear, tmonth, tdate As Integer
                Dim Vcompany, Vname, Vrank, Vflag, Vtype, Vetype, Vgrt, Vkw, VTroute, Vdur, Vreason

                tyear = 0
                While sbreader.Read
                    Vcompany = sbreader.Item("App_PrincipalName").ToString()
                    Vrank = sbreader.Item("App_Rank").ToString()
                    Vname = sbreader.Item("App_VesselName").ToString()
                    Vflag = sbreader.Item("App_ImportFlag").ToString()
                    Vtype = sbreader.Item("App_VesselType").ToString()
                    Vetype = sbreader.Item("App_EngineType").ToString()
                    Vgrt = sbreader.Item("App_GRT").ToString()
                    Vkw = sbreader.Item("App_KW").ToString()
                    VTroute = sbreader.Item("App_TradingRoute").ToString()
                    Vdur = sbreader.Item("App_Duration").ToString()
                    Vreason = sbreader.Item("App_Reason").ToString()
                    Try
                        e.Graphics.DrawString(outyear, Font8, Brushes.Black, 935, ysb + 20)
                        e.Graphics.DrawString(inyear, Font8, Brushes.Black, 935, ysb)
                    Catch ex As Exception
                        e.Graphics.DrawString(outyear, Font8, Brushes.Black, 935, ysb + 20)
                        e.Graphics.DrawString(inyear, Font8, Brushes.Black, 935, ysb)
                    End Try
                    inyear = sbreader.GetDate(9).ToString
                    outyear = sbreader.GetDate(10).ToString
                    Difference(inyear, outyear)

                    e.Graphics.DrawString(Vdur, Font10, Brushes.Black, 1030, ysb + 15)
                    e.Graphics.DrawString(Vreason, Font9, Brushes.Black, 1130, ysb + 15)
                    e.Graphics.DrawString(Vcompany, Font9, Brushes.Black, 70, ysb)
                    e.Graphics.DrawString(Vname, Font9, Brushes.Black, 70, ysb + 20)


                    If Vrank.ToString.Contains("2nd") Or Vrank.ToString.Contains("2M") Then
                        e.Graphics.DrawString("2M", Font9, Brushes.Black, 260, ysb + 15)
                    Else
                        e.Graphics.DrawString(Vrank, Font9, Brushes.Black, 260, ysb + 15)
                    End If
                    e.Graphics.DrawString(Vtype, Font9, Brushes.Black, 303, ysb)
                    e.Graphics.DrawString(Vflag, Font9, Brushes.Black, 303, ysb + 20)

                    e.Graphics.DrawString(Vgrt, Font9, Brushes.Black, 720, ysb)
                    e.Graphics.DrawString(Vkw, Font9, Brushes.Black, 710, ysb + 20)

                    e.Graphics.DrawString(Vetype, Font8, Brushes.Black, 780, ysb + 15)

                    tyear = tyear + Year
                    ysb = ysb + 40
                End While

                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1330)
                e.HasMorePages = True
            Case 2
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\ESM TANKER OC09-04_Page_2.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                e.Graphics.DrawImage(newImage, 1, 1, 1300, 855)


                Dim counter As Integer = 0
                Dim ysb = 135
                Dim sbstr As String
                'sqlquery

                sbstr = "SELECT App_PrincipalName,App_Rank, App_VesselName, App_ImportFlag, App_VesselType, App_EngineType, App_GRT, App_KW, App_TradingRoute, App_DateSignedON, App_DateSignedOFF, App_Duration,App_Reason FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc  limit 5 ; "

                Dim sbcmd As OdbcCommand
                sbcmd = New OdbcCommand(sbstr, conn)
                Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()
                Dim inyear, outyear As Date
                Dim tyear, tmonth, tdate As Integer
                Dim Vcompany, Vname, Vrank, Vflag, Vtype, Vetype, Vgrt, Vkw, VTroute, Vdur, Vreason

                tyear = 0
                While sbreader.Read
                    Vcompany = sbreader.Item("App_PrincipalName").ToString()
                    Vrank = sbreader.Item("App_Rank").ToString()
                    Vname = sbreader.Item("App_VesselName").ToString()
                    Vflag = sbreader.Item("App_ImportFlag").ToString()
                    Vtype = sbreader.Item("App_VesselType").ToString()
                    Vetype = sbreader.Item("App_EngineType").ToString()
                    Vgrt = sbreader.Item("App_GRT").ToString()
                    Vkw = sbreader.Item("App_KW").ToString()
                    VTroute = sbreader.Item("App_TradingRoute").ToString()
                    Vdur = sbreader.Item("App_Duration").ToString()
                    Vreason = sbreader.Item("App_Reason").ToString()
                    Try
                        e.Graphics.DrawString(outyear, Font8, Brushes.Black, 935, ysb + 20)
                        e.Graphics.DrawString(inyear, Font8, Brushes.Black, 935, ysb)
                    Catch ex As Exception
                        e.Graphics.DrawString(outyear, Font8, Brushes.Black, 935, ysb + 20)
                        e.Graphics.DrawString(inyear, Font8, Brushes.Black, 935, ysb)
                    End Try
                    inyear = sbreader.GetDate(9).ToString
                    outyear = sbreader.GetDate(10).ToString
                    Difference(inyear, outyear)

                    e.Graphics.DrawString(Vdur, Font10, Brushes.Black, 1030, ysb + 15)
                    e.Graphics.DrawString(Vreason, Font9, Brushes.Black, 1130, ysb + 15)
                    e.Graphics.DrawString(Vcompany, Font9, Brushes.Black, 70, ysb)
                    e.Graphics.DrawString(Vname, Font9, Brushes.Black, 70, ysb + 20)


                    If Vrank.ToString.Contains("2nd") Or Vrank.ToString.Contains("2M") Then
                        e.Graphics.DrawString("2M", Font9, Brushes.Black, 260, ysb + 15)
                    Else
                        e.Graphics.DrawString(Vrank, Font9, Brushes.Black, 260, ysb + 15)
                    End If
                    e.Graphics.DrawString(Vtype, Font9, Brushes.Black, 303, ysb)
                    e.Graphics.DrawString(Vflag, Font9, Brushes.Black, 303, ysb + 20)

                    e.Graphics.DrawString(Vgrt, Font9, Brushes.Black, 720, ysb)
                    e.Graphics.DrawString(Vkw, Font9, Brushes.Black, 720, ysb + 20)

                    e.Graphics.DrawString(Vetype, Font8, Brushes.Black, 780, ysb + 15)

                    tyear = tyear + Year
                    ysb = ysb + 40
                End While

        End Select
        PageNum += 1

    End Sub

    Private Sub ESMOC904_Click(sender As Object, e As EventArgs) Handles ESMOC904.Click

        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized

        AddHandler PD.PrintPage, AddressOf Esm_Tanker_04_PrintPage

        'Printing na may set up ng page
        Dim AmsPrintDialog As New PrintDialog()
        ' PrintDialog1.Document = CvPrint

        If AmsPrintDialog.ShowDialog(PPV) = Windows.Forms.DialogResult.OK Then
            Esm_Tanker_04.PrinterSettings = AmsPrintDialog.PrinterSettings
            Esm_Tanker_04.DefaultPageSettings.Landscape = True
            ' Esm_Tanker_04.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)

            Esm_Tanker_04.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("Legal", 850, 1330)
            AmsPrintDialog.AllowSomePages = True

            Esm_Tanker_04.Print()
            Me.Hide()
        End If
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub












    ''//////////////////////////////////CRYSTAL CV/////////////////////////////////
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles CvPrint.PrintPage




        'drawing ng text
        'x, y
        Dim Font As New Font("Arial", 10, FontStyle.Regular)

        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)

        Dim FontMID As New Font("Arial", 12, FontStyle.Regular)
        Select Case PageNum

            Case 1
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                Dim path As String = "C:\Users\Arvin Trinidad\source\repos\Hunters_PMS\Hunters_PMS\Resource\cvapplication.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                e.Graphics.DrawImage(newImage, e.PageBounds)


                'crew_in

                Dim selinfo As String
                selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ai.App_Skype ,ai.App_Whatsapp, ae.Studies_Course, ae.Studies_Name, ae.Studies_Year ,ae.School_From, ae.School_To, ae.School_Name, ae.Voc_Course,ae.Voc_To, ae.Voc_School, sc.App_RankApplied, sc.App_DateApplied,ai.App_Picture
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
                    LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

                Dim selinfocmd As OdbcCommand
                selinfocmd = New OdbcCommand(selinfo, conn)

                Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

                If selinforeader.Read Then



                    Lname = selinforeader.Item("App_LName").ToString

                    Fname = selinforeader.Item("App_FName").ToString
                    Mname = selinforeader.Item("App_MName").ToString
                    Suffix = selinforeader.Item("App_Suffix").ToString
                    NNname = selinforeader.Item("App_Nickname").ToString
                    Address = selinforeader.Item("Address").ToString
                    Address2 = selinforeader.Item("App_address2").ToString
                    citizenship = selinforeader.Item("App_Citezenship").ToString
                    Bday = selinforeader.Item("App_Bday").Date.ToString()
                    Bplace = selinforeader.Item("App_BPlace").ToString
                    CivilStat = selinforeader.Item("App_CivilStat").ToString

                    Try
                        DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
                    Catch ex As Exception
                        DateMarriage = ""

                    End Try
                    ContactNo = selinforeader.Item("App_ContactNo").ToString
                    ContactNo2 = selinforeader.Item("App_ContactNo2").ToString
                    Sex = selinforeader.Item("App_Sex").ToString
                    Religion = selinforeader.Item("App_Religion").ToString
                    EmailAdd = selinforeader.Item("App_EmailAdd").ToString
                    Pagibig = selinforeader.Item("App_PagibigNo").ToString
                    Tin = selinforeader.Item("App_TinNo").ToString
                    SSS = selinforeader.Item("App_SSSNo").ToString
                    Philhealth = selinforeader.Item("App_PhilHealthNo").ToString
                    Heights = selinforeader.Item("App_Height").ToString
                    Weight = selinforeader.Item("App_Weight").ToString
                    Shirtsize = selinforeader.Item("App_ShirtSize").ToString
                    Suitsize = selinforeader.Item("App_SuitSize").ToString
                    WaisteSize = selinforeader.Item("App_WaisteSize").ToString
                    ShoeSize = selinforeader.Item("App_ShoeSize").ToString
                    Skype = selinforeader.Item("App_Skype").ToString
                    Whatsapp = selinforeader.Item("App_Whatsapp").ToString
                    CCourse = selinforeader.Item("Studies_Course").ToString
                    CStudies = selinforeader.Item("Studies_Name").ToString
                    CYear = selinforeader.Item("Studies_Year").ToString
                    HSchool = selinforeader.Item("School_Name").ToString
                    HSchoolFr = selinforeader.Item("School_From").ToString
                    HSchooolTo = selinforeader.Item("School_To").ToString
                    VSchool = selinforeader.Item("Voc_School").ToString
                    VSchoolCourse = selinforeader.Item("Voc_Course").ToString
                    VSchooolTo = selinforeader.Item("Voc_To").ToString
                    rankapplied = selinforeader.Item("App_RankApplied").ToString
                    dateapplied = selinforeader.Item("App_DateApplied").ToString

                    CHSchoolFr = Convert.ToDateTime(HSchoolFr)
                    CHSchooolTo = Convert.ToDateTime(HSchooolTo)
                    'CVSchoolFr = Convert.ToDateTime(VSchoolFr)
                    CVSchooolTo = Convert.ToDateTime(VSchooolTo)

                End If
                filenamepic = selinforeader.Item("App_Picture").ToString
                Try
                    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                    e.Graphics.DrawImage(newDp, 590, 50, 150, 150)

                Catch ex As Exception

                End Try

                'APPLIEDDATEPOSITION
                e.Graphics.DrawString(rankapplied, Font, Brushes.Black, 230, 217) 'pOSITIONaPPLIED
                e.Graphics.DrawString(dateapplied, Font, Brushes.Black, 643, 217) 'DATEAPPLIED

                ''PERSONALINFO
                e.Graphics.DrawString(Lname, Font, Brushes.Black, 170, 240) 'lname
                e.Graphics.DrawString(Fname, Font, Brushes.Black, 400, 240) 'fname
                e.Graphics.DrawString(Mname, Font, Brushes.Black, 620, 240) 'mname

                e.Graphics.DrawString(Address, Font, Brushes.Black, 130, 270)
                e.Graphics.DrawString(ContactNo, Font, Brushes.Black, 190, 298) 'no1
                e.Graphics.DrawString(ContactNo2, Font, Brushes.Black, 190, 319) 'no2

                e.Graphics.DrawString(Bday, Font, Brushes.Black, 540, 298) 'DATEBIRTH
                e.Graphics.DrawString(appage, Font, Brushes.Black, 680, 298) 'age

                e.Graphics.DrawString(Bplace, Font, Brushes.Black, 480, 319) 'placeBIRTH
                e.Graphics.DrawString(EmailAdd, Font, Brushes.Black, 190, 338) 'EMAILADD
                e.Graphics.DrawString(CivilStat, Font, Brushes.Black, 691, 319) 'cvstatus
                e.Graphics.DrawString(Religion, Font, Brushes.Black, 480, 338) 'religion

                e.Graphics.DrawString(" ", Font, Brushes.Black, 180, 359) 'wifename
                e.Graphics.DrawString(" ", Font, Brushes.Black, 485, 359) 'wifeno
                e.Graphics.DrawString(" ", Font, Brushes.Black, 180, 380) 'mothersname
                e.Graphics.DrawString(" ", Font, Brushes.Black, 485, 380) 'motherno


                e.Graphics.DrawString(Skype, Font, Brushes.Black, 180, 405) 'skypeid
                e.Graphics.DrawString(Whatsapp, Font, Brushes.Black, 480, 405) 'whatsappid
                ''PHYSICAL DETAILS




                e.Graphics.DrawString(Heights, Font, Brushes.Black, 108, 453) 'HEIGHT
                e.Graphics.DrawString(Weight, Font, Brushes.Black, 225, 453) 'WEIGHT

                e.Graphics.DrawString(Shirtsize, Font, Brushes.Black, 480, 453) 'CSIZE
                e.Graphics.DrawString(ShoeSize, Font, Brushes.Black, 690, 453) 'SHOESIZE
                e.Graphics.DrawString(" ", Font, Brushes.Black, 141, 473) 'eyecolor
                e.Graphics.DrawString(" ", Font, Brushes.Black, 290, 473) 'haircolor
                e.Graphics.DrawString(" ", Font, Brushes.Black, 519, 473) 'dmark
                e.Graphics.DrawString(WaisteSize, Font, Brushes.Black, 680, 473) 'waistline



                e.Graphics.DrawString(HSchool, Font, Brushes.Black, 215, 544) 'highschool
                e.Graphics.DrawString(CHSchoolFr, Font, Brushes.Black, 420, 544) 'highschoolfrom
                e.Graphics.DrawString(CHSchooolTo, Font, Brushes.Black, 515, 544) 'highschoolto
                e.Graphics.DrawString("HighSchool Graduate", Font, Brushes.Black, 605, 544) 'highschooldiploma

                e.Graphics.DrawString(VSchool, Font, Brushes.Black, 215, 560) 'vocationalschool
                e.Graphics.DrawString(CVSchoolFr, Font, Brushes.Black, 420, 560) 'vocationalfrom
                e.Graphics.DrawString(CVSchooolTo, Font, Brushes.Black, 515, 560) 'vocationalto
                e.Graphics.DrawString(VSchoolCourse, Font, Brushes.Black, 605, 560) 'vocationaldiploma



                '''convert cyear to int

                e.Graphics.DrawString(CStudies, Font, Brushes.Black, 215, 580) 'college
                '    e.Graphics.DrawString("2014", Font, Brushes.Black, 420, 580) 'collegefrom
                e.Graphics.DrawString(CYear, Font, Brushes.Black, 515, 580) 'collegeto
                e.Graphics.DrawString(CCourse, Font, Brushes.Black, 605, 580) 'collegediploma


                'LICENSES AND OTHER REQUIRED DOCS

                'documents
                Dim seldoc As String
                seldoc = "Select  Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place,AppDoc_Shortcut, AppDoc_DateIssued, AppDoc_Country, AppDoc_Status, AppDoc_DateExpired, App_DocID FROM hunters_pooling.applicant_doc where App_ID=" & GetAppID & ";"

                Dim doccommand As OdbcCommand
                doccommand = New OdbcCommand(seldoc, conn)
                Dim docreader As OdbcDataReader = doccommand.ExecuteReader()



                While docreader.Read
                    docid = docreader.Item("Document_ID").ToString()
                    docname = docreader.Item("AppDoc_Name").ToString()
                    docshortcut = docreader.Item("AppDoc_Shortcut").ToString()
                    docno = docreader.Item("AppDoc_No").ToString()
                    docplace = docreader.Item("AppDoc_Place").ToString()
                    crewdocid = docreader.Item("App_DocID").ToString()
                    docstatus = docreader.Item("AppDoc_Status").ToString()
                    doccountry = docreader.Item("AppDoc_Country").ToString()
                    dateissued = docreader.Item("AppDoc_DateIssued").Date.ToString()
                    Try

                        dateexpired = docreader.Item("AppDoc_DateExpired").Date.ToString()
                    Catch ex As Exception
                        dateexpired.ToString("n/a")

                    End Try


                    Dim cntr As Integer


                    For cntr = 1 To 8

                    Next




                    If docid.ToString.Equals("1004") Then
                        'SIRB no1
                        e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 645) 'PSBNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 645) 'PSBrank
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 645) 'PSBissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 645) 'PSBexpired


                    End If




                    If docid.ToString.Equals("1005") Then
                        'src no2
                        e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 665) 'SRCNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 665) 'SRCrank
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 665) 'SRCissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 665) 'SRCexpired

                    End If

                    If docid.ToString.Equals("1003") Then
                        'passport no3
                        e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 685) 'PASSPORTNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 685) 'PASSPORTrank
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 685) 'PASSPORTissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 685) 'PASSPORTexpired

                    End If





                    If docid.ToString.Equals("1010") Then
                        'phil license no4
                        e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 705) 'PHILLICENSENO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 705) 'PHILLICENSrank
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 705) 'PHILLICENSeissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 705) 'PHILLICENSexpired
                    End If



                    If docid.ToString.Equals("1011") Then
                        'coc(marina) no5
                        e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 725) 'COCMARINANO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 725) 'COCMARINArank
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 725) 'COCMARINAeissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 725) 'COCMARINAexpired
                    End If


                    If docid.ToString.Equals("1012") Then
                        'certificate of endorsement no6
                        e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 745) 'ENDORSEMENTMARINANO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 745) 'ENDORSEMENTMARINAArank
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 745) 'ENDORSEMENTMARINAissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 745) 'ENDORSEMENTMARINAexpired

                    End If


                    If docid.ToString.Equals("1011") Then

                        'coc(marina) no8
                        e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 785) 'COCMARINANO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 785) 'COCMARINArank
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 785) 'COCMARINAeissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 785) 'COCMARINAexpired
                    End If



                    If docid.ToString.Equals("1272") Then
                        'pilotexception no13

                        e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 885) 'PILOTEXCEPTIONNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 435, 885) 'PILOTEXCEPTIONrank
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 885) 'PILOTEXCEPTIONissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 885) 'PILOTEXCEPTIONexpired


                    End If

                    If docid.ToString.Equals("1006") Then
                        'yellow fever '14
                        e.Graphics.DrawString(docname, Font, Brushes.Black, 280, 905) 'YELLOWFEVERNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 905) 'YELLOWFEVERno
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523, 905) 'YELLOWFEVERissued
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 905) 'YELLOWFEVERexpired

                    End If





                    If docid.ToString.Equals("1014") Then
                        'us -visa

                        e.Graphics.DrawString(docno, Font, Brushes.Black, 190, 970) 'USVISANO
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 325, 970) 'USVISAEXPIRY

                    End If

                    If docid.ToString.Equals("1090") Then
                        'schengen -visa

                        e.Graphics.DrawString(docno, Font, Brushes.Black, 190, 990) 'SCHEVISANO
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 325, 990) 'SCHEVISAEXPIRY
                    End If


                    'e.Graphics.DrawString("123456M", Font, Brushes.Black, 190, 833) 'BRUVISANO
                    'e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 305, 833) 'BRUVISAVISAEXPIRY

                    'e.Graphics.DrawString("123456M", Font, Brushes.Black, 190, 850) 'NIGEVISANO
                    'e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 305, 850) 'NIGEVISAEXPIRY

                    If docid.ToString.Equals("1050") Then

                        e.Graphics.DrawString(docno, Font, Brushes.Black, 615, 1130) 'NISISSUE
                    End If

                End While


                'cert
                Dim selcel As String
                selcel = "Select Document_ID, AppCert_Name, AppCert_Shortcut, AppCert_No, AppCert_Place, AppCert_Country,AppCert_DateIssued, AppCert_DateExpired, AppCert_Trainingcenter, AppCert_Status FROM hunters_pooling.applicant_cert where App_ID=" & GetAppID & ";"


                Dim celcmd As OdbcCommand
                celcmd = New OdbcCommand(selcel, conn)
                Dim celreader As OdbcDataReader = celcmd.ExecuteReader()

                While celreader.Read
                    certdocid = celreader.Item("Document_ID").ToString()
                    certname = celreader.Item("AppCert_Name").ToString()
                    certshortcut = celreader.Item("AppCert_Shortcut").ToString()
                    certno = celreader.Item("AppCert_No").ToString()
                    certplace = celreader.Item("AppCert_Place").ToString()
                    certcountry = celreader.Item("AppCert_Country").ToString()
                    certtraining = celreader.Item("AppCert_Trainingcenter").ToString()
                    certstatus = celreader.Item("AppCert_Status").ToString()
                    certissued = celreader.Item("AppCert_DateIssued").Date.ToString

                    Try
                        certexpired = celreader.Item("AppCert_DateExpired").Date.ToString()
                    Catch ex As Exception
                        certexpired = ""

                    End Try


                    If certdocid.ToString.Equals("1104") Then


                        'GOC License no7
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 280, 765) 'GOCLICENO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 765) 'GOCLICErank
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 523, 765) 'GOCLICEissued
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 650, 765) 'GOCLICEexpired

                    End If

                    ''full dp no9
                    ''e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 805) 'FULLDPNO
                    ''e.Graphics.DrawString(docno, Font, Brushes.Black, 425, 805) 'FULLDPrank
                    ''e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523,805) 'FULLDPissued
                    ''e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 805) 'FULLDPexpire





                    If certdocid.ToString.Equals("1386") Then

                        'basicdp no10
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 280, 820) 'BASICDPNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 820) 'BASICDPrank
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 523, 820) 'BASICDPissued
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 650, 820) 'BASICDPexpired
                    End If

                    If certdocid.ToString.Equals("1498") Then
                        'advancedp no11
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 280, 840) 'ADVANCEDPNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 840) 'ADVANCEDPrank
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 523, 840) 'ADVANCEDPissued
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 650, 840) 'ADVANCEDPexpired
                    End If

                    If certdocid.ToString.Equals("1254") Then
                        'dpm no12
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 280, 860) 'DPMCERTNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 860) 'DPMCERTPrank
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 523, 860) 'DPMCERTPissued
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 650, 860) 'DPMCERTexpired

                    End If


                    ''VISA/LOGBOOK

                    If certdocid.ToString.Equals("1683") And certshortcut.ToString.Equals("DP Logbook") Then
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 970) 'DPLBISSUE 1683
                    End If


                    If certdocid.ToString.Equals("1395") Then
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 990) 'IMCAISSUE
                    End If

                    If certdocid.ToString.Equals("1287") Then
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 1110) 'CRNOPISSUE
                    End If








                End While


                'e.Graphics.DrawString("123456H", Font, Brushes.Black, 280, 631) 'DECKCOCNO
                'e.Graphics.DrawString("12345A", Font, Brushes.Black, 405, 631) 'DECKCOCrank
                'e.Graphics.DrawString("July 16 2018", Font, Brushes.Black, 513, 631) 'DECKCOCissued
                'e.Graphics.DrawString("July 31 2022", Font, Brushes.Black, 640, 631) 'DECKCOCexpired





                Dim kinfamstr As String

                kinfamstr = "Select * from hunters_pooling.applicant_family where appkin_Status = 'ACTIVE' and App_ID = " & GetAppID & ";   "
                Dim kinfamcmd As OdbcCommand
                kinfamcmd = New OdbcCommand(kinfamstr, conn)
                Dim kinfamreader As OdbcDataReader = kinfamcmd.ExecuteReader()

                Dim ykin As Integer = 1120


                While kinfamreader.Read
                    Klname = kinfamreader.Item("appkin_LName").ToString()
                    KFname = kinfamreader.Item("appkin_FName").ToString()
                    KMname = kinfamreader.Item("appkin_MName").ToString()
                    KSuffix = kinfamreader.Item("appkin_Suffix").ToString()
                    Kaddress = kinfamreader.Item("appkin_Address").ToString()
                    KBday = kinfamreader.Item(7).Date.ToString()
                    KBplace = kinfamreader.Item("appkin_Bplace").ToString()
                    KSex = kinfamreader.Item("appkin_Sex").ToString()
                    KContact = kinfamreader.Item("appkin_ContactNo").ToString()
                    KRelation = kinfamreader.Item("appkin_Relation").ToString()
                    KOccupation = kinfamreader.Item("appkin_Occupation").ToString()
                    KStat = kinfamreader.Item("appkin_Status").ToString()
                    KPassport = kinfamreader.Item("appkin_Passport").ToString()


                    'FAMILY BACKGROUND
                    If KRelation.ToString.ToLower.Equals("wife") Then
                        e.Graphics.DrawString(Klname + ", " + KFname + " " + KMname, Font, Brushes.Black, 140, 1100) 'WIFENAME
                        e.Graphics.DrawString(KBday, Font, Brushes.Black, 305, 1100) 'WIFEbirth
                        e.Graphics.DrawString(KPassport, Font, Brushes.Black, 400, 1100) 'WIFEpassport
                        e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 490, 1100) 'WIFEdateissued
                        e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 570, 1100) 'WIFEdateEXPIRED
                        e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 660, 1100) 'WIFEPLACEISSUE



                    End If

                    If KRelation.ToString.ToLower.Equals("son") Or KRelation.ToString.ToLower.Equals("daughter") Then

                        e.Graphics.DrawString(Klname + ", " + KFname + " " + KMname, Font, Brushes.Black, 140, ykin) 'CHILD1NAME  'M
                        e.Graphics.DrawString(KBday, Font, Brushes.Black, 305, ykin) 'CHILD1BIRTH  'M
                        e.Graphics.DrawString(KPassport, Font, Brushes.Black, 400, ykin) 'CHILD1PASSPORT  'M
                        'e.Graphics.DrawString("07 16 2018", Font, Brushes.Black, 490, 922) 'CHILD1issued 'M
                        'e.Graphics.DrawString("07 16 2028", Font, Brushes.Black, 570, 922) ''CHILD1EXPIRED  'M
                        'e.Graphics.DrawString("DFA MANILA", Font, Brushes.Black, 660, 922) 'CHILD1ISSUED  'M
                        ykin = ykin + 20
                    End If



                End While









                e.HasMorePages = True

            Case 2
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                Dim certstr As String

                certstr = "Select AppCert_Shortcut, AppCert_No,  AppCert_DateIssued, AppCert_Place,AppCert_DateExpired FROM hunters_pooling.applicant_cert where App_ID='" & GetAppID & "';"
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
                    Try
                        e.Graphics.DrawString(certreader.GetDate(4).ToString("MM-dd-yyyy"), Font, Brushes.Black, 690, y)

                    Catch ex As Exception
                        e.Graphics.DrawString("", Font, Brushes.Black, 690, y)

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


                e.HasMorePages = True
                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                e.PageSettings.Landscape = True

            'Case 3

            '    e.HasMorePages = True
            '    e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
            '    e.PageSettings.Landscape = True

            Case 3





                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dim y As Integer = 113
                Dim yrec As Integer = 40

                Dim Fontbox As New Font("Arial", 9, FontStyle.Bold)

                Dim hereby As New Font("Arial", 7, FontStyle.Italic)
                Dim fontinside As New Font("Arial", 10, FontStyle.Regular)
                Dim fontside As New Font("Arial", 8, FontStyle.Regular)
                Dim FontMID1 As New Font("Arial", 12, FontStyle.Regular)

                Dim FontTitle1 As New Font("Arial", 7, FontStyle.Regular)

                Dim myPen As Pen = New Pen(Drawing.Color.Black, 2)
                Dim bg As SolidBrush = New SolidBrush(Color.Aqua)
                Dim counter As Integer = 0
                Dim ysb = 65

                ' 'drawing ng text (x, y)
                ' DrawRectangle(myPen, X, Y, width, height)
                e.Graphics.DrawString("Service Record (Running Vessel)", FontMID, Brushes.Black, 620, 20)

                e.Graphics.DrawString("PRINCIPAL NAME", FontTitle1, Brushes.Black, 45, 45)
                e.Graphics.DrawRectangle(myPen, 30, yrec, 110, 20) 'principal
                e.Graphics.DrawString("VESSEL NAME", FontTitle1, Brushes.Black, 155, 45)
                e.Graphics.DrawRectangle(myPen, 140, yrec, 110, 20) 'vesselname
                e.Graphics.DrawString("FLAG", FontTitle1, Brushes.Black, 265, 45)
                e.Graphics.DrawRectangle(myPen, 250, yrec, 55, 20) 'flaG
                e.Graphics.DrawString("NATIONALITY", FontTitle1, Brushes.Black, 310, 45)
                e.Graphics.DrawRectangle(myPen, 305, yrec, 85, 20) 'nationality
                e.Graphics.DrawString("AGENCY", FontTitle1, Brushes.Black, 420, 45)
                e.Graphics.DrawRectangle(myPen, 390, yrec, 110, 20) 'agency
                e.Graphics.DrawString("Rank", FontTitle1, Brushes.Black, 515, 45)
                e.Graphics.DrawRectangle(myPen, 500, yrec, 55, 20) 'rank
                e.Graphics.DrawString("Vessel Type", FontTitle1, Brushes.Black, 560, 45)
                e.Graphics.DrawRectangle(myPen, 555, yrec, 65, 20) 'vesseltype
                e.Graphics.DrawString("GRT", FontTitle1, Brushes.Black, 635, 45)
                e.Graphics.DrawRectangle(myPen, 620, yrec, 55, 20) 'grt
                e.Graphics.DrawString("ENGINE MAKE", FontTitle1, Brushes.Black, 700, 45)
                e.Graphics.DrawRectangle(myPen, 675, yrec, 110, 20) 'engine make
                e.Graphics.DrawString("KW", FontTitle1, Brushes.Black, 800, 45)
                e.Graphics.DrawRectangle(myPen, 785, yrec, 55, 20) 'kw
                e.Graphics.DrawString("FROM", FontTitle1, Brushes.Black, 875, 45)
                e.Graphics.DrawRectangle(myPen, 840, yrec, 110, 20) 'from
                e.Graphics.DrawString("TO", FontTitle1, Brushes.Black, 990, 45)
                e.Graphics.DrawRectangle(myPen, 950, yrec, 110, 20) 'to
                e.Graphics.DrawString("T.M", FontTitle1, Brushes.Black, 1075, 45)
                e.Graphics.DrawRectangle(myPen, 1060, yrec, 55, 20) 'totalmonths
                e.Graphics.DrawString("R.D", FontTitle1, Brushes.Black, 1150, 45)
                e.Graphics.DrawRectangle(myPen, 1115, yrec, 85, 20) 'reason
                e.Graphics.DrawString("TRADING", FontTitle1, Brushes.Black, 1215, 45)
                e.Graphics.DrawRectangle(myPen, 1200, yrec, 85, 20) 'trading route
                e.Graphics.DrawString("SALARY", FontTitle1, Brushes.Black, 1300, 45)
                e.Graphics.DrawRectangle(myPen, 1285, yrec, 85, 20) 'salary


                Dim sbstr As String

                sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc ; "




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
                    e.Graphics.DrawString(sbreader.GetDate(12).ToString("MM-dd-yyyy"), Font, Brushes.Black, 860, ysb)
                    e.Graphics.DrawString(sbreader.GetDate(13).ToString("MM-dd-yyyy"), Font, Brushes.Black, 972, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_Duration").ToString(), Font, Brushes.Black, 1075, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_Reason").ToString(), Font, Brushes.Black, 1150, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_TradingRoute").ToString(), Font, Brushes.Black, 1215, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_Salary").ToString(), Font, Brushes.Black, 1300, ysb)
                    ysb = ysb + 20
                End While

                Dim lastcmp As String
                Dim lastque As String
                lastque = "SELECT * FROM hunters_pooling.applicant_seaservice where app_id = '" & GetAppID & "' order by App_DateSignedOFF desc limit  1;"



                Dim lastquecmd As OdbcCommand
                lastquecmd = New OdbcCommand(lastque, conn)
                Dim lastquereader As OdbcDataReader = lastquecmd.ExecuteReader()
                If lastquereader.Read Then
                    lastcmp = lastquereader.Item("App_Agency").ToString()
                End If






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
                e.Graphics.DrawString(lastcmp, fontside, Brushes.Black, 450, yrec + 55)

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
                e.Graphics.DrawString(datenow.ToString("MM-dd-yyyy"), Fontbox, Brushes.Black, 1000, yrec + 320)
                e.Graphics.DrawString("SEAFARER'S DECLARATION", Fontbox, Brushes.Black, 610, yrec + 235)
                e.Graphics.DrawRectangle(myPen, 30, yrec + 250, 1343, 90) '3RD BOX


                'If conn.State = ConnectionState.Closed Then
                '    conn.Open()
                'End If
                'Dim path As String = "F:\Crystal_Files\PMS ICONS\cvapplication3.jpg" 'pathfile
                'Dim newImage As Image = Image.FromFile(path) 'read image



                '' e.Graphics.DrawImage(newImage, e.PageBounds)

                'e.Graphics.DrawImage(newImage, e.PageBounds)


        End Select
        PageNum += 1



    End Sub

    ''/////////////////////////////////OC_31/////////////////////////////////
    Private Sub OC31Doc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles OC31Print.PrintPage

        Dim Font As New Font("Arial", 10, FontStyle.Regular)
        Dim Font9 As New Font("Arial", 9, FontStyle.Regular)
        Dim Font6 As New Font("Arial", 6, FontStyle.Regular)

        Dim FontTitle As New Font("Arial", 11, FontStyle.Bold)

        Dim Fontbox As New Font("Arial", 14, FontStyle.Bold)

        Dim myPen As Pen = New Pen(Drawing.Color.Black, 2)
        Dim myPen1 As Pen = New Pen(Drawing.Color.Black, 1)

        Select Case PageNum

            Case 1
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If


                ' DrawRectangle(myPen, X, Y, width, height)
                e.Graphics.DrawRectangle(myPen, 30, 200, 770, 800) 'bixbox
                e.Graphics.DrawString("EXECUTIVE SHIP MANAGEMENT ", Font, Brushes.Black, 30, 70) 'title
                e.Graphics.DrawRectangle(myPen, 400, 70, 250, 20)
                e.Graphics.DrawString("File Ref: Phoenix ", Font, Brushes.Black, 460, 70) 'title
                e.Graphics.DrawString("OC 31 ", Font, Brushes.Black, 760, 70) 'title
                e.Graphics.DrawString("Page 1 Of 4", Font, Brushes.Black, 725, 90) 'title
                e.Graphics.DrawString("(06/17 Rev 0) ", Font, Brushes.Black, 715, 110) 'title
                e.Graphics.DrawString(" SENIOR OFFICER MANAGEMENT APPROVAL", FontTitle, Brushes.Black, 225, 170) 'title

                'information
                e.Graphics.DrawString("PD NBR :                                          Vessel : MT                                                                      Date   ", Font, Brushes.Black, 40, 230)
                e.Graphics.DrawString("NAME / RANK 			: ", Font, Brushes.Black, 40, 270)
                e.Graphics.DrawString("DOB / POB			:                                                                    Age  : ", Font, Brushes.Black, 40, 290)
                e.Graphics.DrawString("HT / WT 			:          	cms/            	kg/                     BMI  :  ", Font, Brushes.Black, 40, 310)

                e.Graphics.DrawString("PRE SEA TRAINING		:", Font, Brushes.Black, 40, 330)
                e.Graphics.DrawString("PRE SEA TRAINING FROM	:     ", Font, Brushes.Black, 40, 350)
                e.Graphics.DrawString("PRE SEA TRAINING TO		:  ", Font, Brushes.Black, 40, 370)
                e.Graphics.DrawString("PPT NBR			:	      DOI/                              DOE/                          POI/ ", Font, Brushes.Black, 40, 390)

                e.Graphics.DrawString("US VISA			:	      DOI/                              DOE/                          POI/ ", Font, Brushes.Black, 40, 410)
                e.Graphics.DrawString("CDC NBR			:	      DOI/                              DOE/                          POI/ ", Font, Brushes.Black, 40, 430)

                e.Graphics.DrawString("COC NBR			:	      DOI/                              DOE/                          POI/ ", Font, Brushes.Black, 40, 450)

                Dim ctr As Integer
                Dim ybox = 510

                e.Graphics.DrawString("Course", Fontbox, Brushes.Black, 150, ybox + 15) 'title
                e.Graphics.DrawString("DCE", Fontbox, Brushes.Black, 470, ybox + 15) 'title
                For ctr = 1 To 8 Step 1
                    e.Graphics.DrawRectangle(myPen, 45, ybox, 300, 50) 'box
                    e.Graphics.DrawRectangle(myPen, 345, ybox, 300, 50) 'box

                    ybox = ybox + 50
                Next

                Dim selinfo As String
                selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year ,ae.School_From, ae.School_To, ae.School_Name, ae.Voc_Course,ae.Voc_To, ae.Voc_School, sc.App_RankApplied, sc.App_DateApplied,ai.App_Picture,va.AVessel
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
 LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
 LEFT JOIN hunters_pooling.applicant_vesselassign va ON ai.App_ID=va.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

                Dim selinfocmd As OdbcCommand
                selinfocmd = New OdbcCommand(selinfo, conn)

                Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

                Dim Fullname As String


                If selinforeader.Read Then
                    Lname = selinforeader.Item("App_LName").ToString

                    Fname = selinforeader.Item("App_FName").ToString
                    Mname = selinforeader.Item("App_MName").ToString

                    Fullname = Lname + ",  " + Fname + "  " + Mname

                    Suffix = selinforeader.Item("App_Suffix").ToString
                    NNname = selinforeader.Item("App_Nickname").ToString
                    Address = selinforeader.Item("Address").ToString
                    Address2 = selinforeader.Item("App_address2").ToString
                    citizenship = selinforeader.Item("App_Citezenship").ToString
                    Bday = selinforeader.GetDate(8).ToString("MM-dd-yyyy")
                    Bplace = selinforeader.Item("App_BPlace").ToString
                    CivilStat = selinforeader.Item("App_CivilStat").ToString
                    DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
                    ContactNo = selinforeader.Item("App_ContactNo").ToString
                    ContactNo2 = selinforeader.Item("App_ContactNo2").ToString

                    rankapplied = selinforeader.Item("App_RankApplied").ToString
                    Heights = selinforeader.Item("App_Height").ToString
                    Weight = selinforeader.Item("App_Weight").ToString
                    Vessel = selinforeader.Item("AVessel").ToString
                End If



                e.Graphics.DrawString(Fullname + " /" + rankapplied, Font, Brushes.Black, 270, 268)

                Dim Bmi, WeightD, HeightD As Double
                Double.TryParse(Weight, WeightD)
                Double.TryParse(Height, HeightD)
                Bmi = WeightD / ((HeightD / 100) * (HeightD / 100))
                e.Graphics.DrawString(Heights, Font, Brushes.Black, 360, 310)
                e.Graphics.DrawString(Weight, Font, Brushes.Black, 460, 310)
                e.Graphics.DrawString(Bmi.ToString("#.##"), Font, Brushes.Black, 580, 310)
                e.Graphics.DrawString(appage, Font, Brushes.Black, 580, 290)
                e.Graphics.DrawString(datenow.ToString("MM-dd-yyyy"), Font, Brushes.Black, 680, 230)

                e.Graphics.DrawString(Vessel, Font, Brushes.Black, 345, 230)

                e.Graphics.DrawString(Bday + " /" + Bplace, Font, Brushes.Black, 270, 290)



                'documents
                Dim seldoc As String
                seldoc = "Select  Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, AppDoc_Shortcut, date_format(AppDoc_DateIssued, '%d-%b-%Y')AS datein, AppDoc_Country, AppDoc_Status, date_format(AppDoc_DateExpired, '%d-%b-%Y'), App_DocID FROM hunters_pooling.applicant_doc where App_ID=" & GetAppID & ";"

                Dim doccommand As OdbcCommand
                doccommand = New OdbcCommand(seldoc, conn)
                Dim docreader As OdbcDataReader = doccommand.ExecuteReader()



                While docreader.Read
                    docid = docreader.Item("Document_ID").ToString()
                    docname = docreader.Item("AppDoc_Name").ToString()
                    docshortcut = docreader.Item("AppDoc_Shortcut").ToString()
                    docno = docreader.Item("AppDoc_No").ToString()
                    docplace = docreader.Item("AppDoc_Place").ToString()
                    crewdocid = docreader.Item("App_DocID").ToString()
                    docstatus = docreader.Item("AppDoc_Status").ToString()
                    doccountry = docreader.Item("AppDoc_Country").ToString()
                    dateissued = docreader.Item(5).ToString()
                    dateexpired = docreader.Item(8).ToString()
                    '  Try

                    ' dateexpired = docreader.GetDate(8).ToString("MM-dd-yyyy")
                    'Catch ex As Exception
                    '    dateexpired = ""

                    'End Try

                    Dim certnewexp As String

                    If dateexpired.Equals(" ") Then
                        certnewexp = ""

                    Else
                        certnewexp = dateexpired
                    End If

                    'ditotayoiniwan
                    If docid.ToString.Equals("1003") Then
                        'data
                        e.Graphics.DrawString("PPT NBR			:	      DOI/                              DOE/                          POI/ ", Font, Brushes.Black, 40, 390)

                        e.Graphics.DrawString(docno, Font9, Brushes.Black, 270, 390) 'PASSPORTNO
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 380, 390) 'PASSPORTexpired
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 530, 390) 'PASSPORTexpired
                        e.Graphics.DrawString(docplace, Font, Brushes.Black, 680, 390) 'PASSPORTexpired
                    End If

                    If docid.ToString.Equals("1004") Then  '430
                        'SIRB no1
                        e.Graphics.DrawString(docno, Font9, Brushes.Black, 270, 430) 'PSBNO
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 380, 430) 'PASSPORTexpired
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 530, 430) 'PSBexpired
                        e.Graphics.DrawString(docplace, Font, Brushes.Black, 680, 430) 'PASSPORTexpired

                    End If
                    If docid.ToString.Equals("1014") Then
                        'us -visa


                        e.Graphics.DrawString(docno, Font9, Brushes.Black, 270, 410) 'PASSPORTNO
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 380, 410) 'PASSPORTexpired
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 530, 410) 'PASSPORTexpired
                        e.Graphics.DrawString(docplace, Font, Brushes.Black, 680, 410) 'PASSPORTexpired
                    End If
                    If docid.ToString.Equals("1469") Then
                        'us -visa


                        e.Graphics.DrawString(docno, Font9, Brushes.Black, 270, 450) 'PASSPORTNO
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 380, 450) 'PASSPORTexpired
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 530, 450) 'PASSPORTexpired
                        e.Graphics.DrawString(docplace, Font, Brushes.Black, 680, 450) 'PASSPORTexpired
                    End If
                    If docid.ToString.Equals("1011") Then
                        'COC
                        e.Graphics.DrawString(docno, Font6, Brushes.Black, 270, 450) 'PSBNO
                        e.Graphics.DrawString(dateissued, Font, Brushes.Black, 380, 450) 'PASSPORTexpired
                        e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 530, 450) 'PSBexpired
                        e.Graphics.DrawString(docplace, Font, Brushes.Black, 680, 450) 'PASSPORTexpired

                    End If

                End While





                'boxes
                e.HasMorePages = True
            Case 2


                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If


                e.Graphics.DrawRectangle(myPen, 30, 190, 780, 800) 'bixbox
                e.Graphics.DrawString("EXECUTIVE SHIP MANAGEMENT ", Font, Brushes.Black, 30, 70) 'title
                e.Graphics.DrawRectangle(myPen, 400, 70, 250, 20)
                e.Graphics.DrawString("File Ref: Phoenix ", Font, Brushes.Black, 460, 70) 'title
                e.Graphics.DrawString("OC 31 ", Font, Brushes.Black, 760, 70) 'title
                e.Graphics.DrawString("Page 2 of 4 ", Font, Brushes.Black, 725, 90) 'title
                e.Graphics.DrawString("(06/17 Rev 0) ", Font, Brushes.Black, 715, 110) 'title
                'title

                Dim yrec = 200



                e.Graphics.DrawString("Manning", Font, Brushes.Black, 45, 215)
                e.Graphics.DrawString("Company", Font, Brushes.Black, 45, 235)
                e.Graphics.DrawRectangle(myPen, 40, yrec, 120, 60) 'rank
                e.Graphics.DrawString("Vessel", Font, Brushes.Black, 165, 215)
                e.Graphics.DrawRectangle(myPen, 160, yrec, 65, 60) 'rank

                e.Graphics.DrawString("Type", Font, Brushes.Black, 230, 215)
                e.Graphics.DrawRectangle(myPen, 225, yrec, 65, 60) 'rank
                e.Graphics.DrawString("GRT", Font, Brushes.Black, 295, 215)
                e.Graphics.DrawRectangle(myPen, 290, yrec, 60, 60) 'rank
                e.Graphics.DrawString("KW", Font, Brushes.Black, 355, 215)
                e.Graphics.DrawRectangle(myPen, 350, yrec, 60, 60) 'rank

                e.Graphics.DrawString("Engine Type", Font, Brushes.Black, 410, 215)
                e.Graphics.DrawRectangle(myPen, 410, yrec, 90, 60) 'rank

                e.Graphics.DrawString("RN", Font, Brushes.Black, 505, 215)
                e.Graphics.DrawRectangle(myPen, 500, yrec, 60, 60) 'rank

                e.Graphics.DrawString("Fr", Font, Brushes.Black, 565, 215)
                e.Graphics.DrawRectangle(myPen, 560, yrec, 60, 60) 'rank
                e.Graphics.DrawString("To", Font, Brushes.Black, 625, 215)
                e.Graphics.DrawRectangle(myPen, 620, yrec, 60, 60) 'rank

                e.Graphics.DrawString("M/D", Font, Brushes.Black, 685, 215)
                e.Graphics.DrawRectangle(myPen, 680, yrec, 60, 60) 'rank

                e.Graphics.DrawString("Sign Off", Font, Brushes.Black, 745, 215)
                e.Graphics.DrawRectangle(myPen, 740, yrec, 60, 60) 'rank


                Dim Font11B As New Font("Nirmala UI", 11, FontStyle.Bold)
                Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
                Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)

                Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
                Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)

                Dim Font5 As New Font("Nirmala UI", 5, FontStyle.Regular)

                Dim sbstr As String

                sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc limit 20; "


                Dim sbcmd As OdbcCommand
                sbcmd = New OdbcCommand(sbstr, conn)
                Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()
                yrec = yrec + 60


                While sbreader.Read
                    e.Graphics.DrawString(sbreader.Item("App_Agency").ToString(), Font6, Brushes.Black, 40, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_VesselName").ToString(), Font6, Brushes.Black, 160, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_VesselType").ToString(), Font6, Brushes.Black, 245, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_GRT").ToString(), Font6, Brushes.Black, 300, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_KW").ToString(), Font6, Brushes.Black, 360, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_EngineType").ToString(), Font6, Brushes.Black, 430, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_Rank").ToString(), Font6, Brushes.Black, 500, yrec + 5)
                    e.Graphics.DrawString(sbreader.GetDate(12).ToString("MM-dd-yyyy"), Font6, Brushes.Black, 560, yrec + 5)
                    e.Graphics.DrawString(sbreader.GetDate(13).ToString("MM-dd-yyyy"), Font6, Brushes.Black, 620, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_Duration").ToString(), Font6, Brushes.Black, 700, yrec + 5)

                    Dim rectF1 As New RectangleF(748, yrec, 45, 40)

                    e.Graphics.DrawString(sbreader.Item("App_Reason").ToString(), Font5, Brushes.Black, rectF1)

                    e.Graphics.DrawRectangle(myPen1, 40, yrec, 120, 40)
                    e.Graphics.DrawRectangle(myPen1, 160, yrec, 65, 40)
                    e.Graphics.DrawRectangle(myPen1, 225, yrec, 65, 40)
                    e.Graphics.DrawRectangle(myPen1, 290, yrec, 60, 40)
                    e.Graphics.DrawRectangle(myPen1, 350, yrec, 60, 40)
                    e.Graphics.DrawRectangle(myPen1, 410, yrec, 90, 40)

                    e.Graphics.DrawRectangle(myPen1, 500, yrec, 60, 40)
                    e.Graphics.DrawRectangle(myPen1, 560, yrec, 60, 40)
                    e.Graphics.DrawRectangle(myPen1, 620, yrec, 60, 40)
                    e.Graphics.DrawRectangle(myPen1, 680, yrec, 60, 40)
                    e.Graphics.DrawRectangle(myPen1, 740, yrec, 60, 40)


                    yrec = yrec + 20

                End While



                'If yrec >= 950 Then

                '    e.HasMorePages = True
                '    e.Graphics.DrawRectangle(myPen, 30, 190, 780, 800) 'bixbox
                '    e.Graphics.DrawString("EXECUTIVE SHIP MANAGEMENT ", Font, Brushes.Black, 30, 70) 'title
                '    e.Graphics.DrawRectangle(myPen, 400, 70, 250, 20)
                '    e.Graphics.DrawString("File Ref: Phoenix ", Font, Brushes.Black, 460, 70) 'title
                '    e.Graphics.DrawString("OC 31 ", Font, Brushes.Black, 760, 70) 'title
                '    e.Graphics.DrawString("Page 2 of 3", Font, Brushes.Black, 725, 90) 'title
                '    e.Graphics.DrawString("(06/17 Rev 0) ", Font, Brushes.Black, 715, 110) 'title
                '    yrec = 200
                'End If

                e.Graphics.DrawString("AVAILABILITY                                              :  ANYTIME", Font9B, Brushes.Black, 40, yrec + 60)
                e.Graphics.DrawString("CONTACT NO : ", Font9B, Brushes.Black, 550, yrec + 60)
                e.Graphics.DrawString(ContactNo, Font9, Brushes.Black, 640, yrec + 60)

                e.Graphics.DrawString("BANK CHECKED                                            :", Font9B, Brushes.Black, 40, yrec + 80)

                e.Graphics.DrawString("DOC IN HAND                                              :   YES", Font9B, Brushes.Black, 40, yrec + 100)

                e.Graphics.DrawString("VERIFIED AND CHECKED BY DIRECTOR    :", Font9B, Brushes.Black, 40, yrec + 120)


                e.Graphics.DrawString("FIELD OFFICE REMARKS                               :", Font9B, Brushes.Black, 40, yrec + 190)

                e.Graphics.DrawString("MUMBAI REMARKS                              :", Font9B, Brushes.Black, 40, yrec + 290)

                e.HasMorePages = True
            Case 3

                Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
                Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)
                Dim Font10B As New Font("Nirmala UI", 10, FontStyle.Bold)

                Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
                Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)
                Dim Font11B As New Font("Nirmala UI", 11, FontStyle.Bold)
                e.Graphics.DrawRectangle(myPen, 30, 190, 780, 800) 'bixbox
                e.Graphics.DrawString("EXECUTIVE SHIP MANAGEMENT ", Font, Brushes.Black, 30, 70) 'title
                e.Graphics.DrawRectangle(myPen, 400, 70, 250, 20)
                e.Graphics.DrawString("File Ref: Phoenix ", Font, Brushes.Black, 460, 70) 'title
                e.Graphics.DrawString("OC 31 ", Font, Brushes.Black, 760, 70) 'title
                e.Graphics.DrawString("Page 3 of 4", Font, Brushes.Black, 725, 90) 'title
                e.Graphics.DrawString("(06/17 Rev 0) ", Font, Brushes.Black, 715, 110) 'title


                e.Graphics.DrawRectangle(myPen1, 40, 250, 100, 120)
                e.Graphics.DrawRectangle(myPen1, 140, 250, 90, 60)
                e.Graphics.DrawString("ON", Font11B, Brushes.Black, 155, 260) 'title

                e.Graphics.DrawRectangle(myPen1, 230, 250, 90, 60)
                e.Graphics.DrawString("RANK", Font11B, Brushes.Black, 247, 260) 'title
                e.Graphics.DrawString("EXP", Font11B, Brushes.Black, 252, 278) 'title
                e.Graphics.DrawRectangle(myPen1, 320, 250, 110, 60)
                e.Graphics.DrawString("COMBINED", Font11B, Brushes.Black, 326, 260) 'title
                e.Graphics.DrawString("EXP", Font11B, Brushes.Black, 349, 278) 'title

                e.Graphics.DrawRectangle(myPen1, 140, 310, 90, 60)
                e.Graphics.DrawString("FROM", Font11B, Brushes.Black, 155, 320) 'title
                e.Graphics.DrawRectangle(myPen1, 230, 310, 90, 60)
                e.Graphics.DrawString("IN", Font11B, Brushes.Black, 258, 320) 'title
                e.Graphics.DrawString("MONTHS", Font11B, Brushes.Black, 239, 338) 'title

                e.Graphics.DrawRectangle(myPen1, 320, 310, 110, 60)
                e.Graphics.DrawString("IN", Font11B, Brushes.Black, 360, 320) 'title
                e.Graphics.DrawString("MONTHS", Font11B, Brushes.Black, 335, 338) 'title
                e.Graphics.DrawRectangle(myPen1, 430, 250, 140, 120)


                Dim rectF1 As New RectangleF(440, 270, 140, 120)
                e.Graphics.DrawString("COMBINED EXP (IF JOINING TOGETHER) IN MONTHS", Font11B, Brushes.Black, rectF1)



                e.Graphics.DrawRectangle(myPen1, 570, 250, 230, 120)
                e.Graphics.DrawString("REMARKS", Font11B, Brushes.Black, 625, 310) 'title

                ''small rectangle
                Dim yrec = 370
                For counter = 1 To 4 Step 1
                    e.Graphics.DrawRectangle(myPen1, 40, yrec, 100, 30)
                    e.Graphics.DrawRectangle(myPen1, 140, yrec, 90, 30)
                    e.Graphics.DrawRectangle(myPen1, 230, yrec, 90, 30)
                    e.Graphics.DrawRectangle(myPen1, 320, yrec, 110, 30)
                    e.Graphics.DrawRectangle(myPen1, 430, yrec, 140, 30)
                    e.Graphics.DrawRectangle(myPen1, 570, yrec, 230, 30)

                    yrec = yrec + 30
                Next
                e.Graphics.DrawString("Master", Font12, Brushes.Black, 43, 375) 'title

                e.Graphics.DrawString("CO", Font12, Brushes.Black, 43, 405) 'title
                e.Graphics.DrawString("CE", Font12, Brushes.Black, 43, 435) 'title
                e.Graphics.DrawString("2E", Font12, Brushes.Black, 43, 465) 'title


                e.Graphics.DrawString("CHECKED BY            :", Font11B, Brushes.Black, 40, 550) 'title
                e.Graphics.DrawString("COMPILED BY          :", Font11B, Brushes.Black, 40, 570) 'title
                e.Graphics.DrawString("VERIFIED BY             :", Font11B, Brushes.Black, 40, 590) 'title



                e.Graphics.DrawString("_____________________________", Font11B, Brushes.Black, 40, 690) 'title
                e.Graphics.DrawString("GENERAL MANAGER", Font10B, Brushes.Black, 80, 710) 'title
                e.Graphics.DrawString("HR & CREW", Font10B, Brushes.Black, 102, 730) 'title
                e.Graphics.DrawString("_____________________________", Font11B, Brushes.Black, 320, 690) 'title
                e.Graphics.DrawString("GENERAL MANAGER", Font10B, Brushes.Black, 360, 710) 'title
                e.Graphics.DrawString("HSEQA", Font10B, Brushes.Black, 395, 730) 'title
                e.Graphics.DrawString("_____________________________", Font11B, Brushes.Black, 580, 690) 'title
                e.Graphics.DrawString("TECHNICAL DIRECTOR", Font10B, Brushes.Black, 618, 710) 'title

                e.Graphics.DrawString("_____________________________", Font11B, Brushes.Black, 580, 830) 'title
                e.Graphics.DrawString("MANAGING DIRECTOR", Font10B, Brushes.Black, 618, 850) 'title
                'e.Graphics.DrawRectangle(myPen1, 390, yrec, 110, 40)


                'e.Graphics.DrawRectangle(myPen1, 40, yrec, 100, 40)
                'e.Graphics.DrawRectangle(myPen1, 140, yrec, 65, 40)
                'e.Graphics.DrawRectangle(myPen1, 205, yrec, 65, 40)
                'e.Graphics.DrawRectangle(myPen1, 270, yrec, 60, 40)
                'e.Graphics.DrawRectangle(myPen1, 330, yrec, 60, 40)
                'e.Graphics.DrawRectangle(myPen1, 390, yrec, 110, 40)
                'e.Graphics.DrawRectangle(myPen1, 500, yrec, 60, 40)
                'e.Graphics.DrawRectangle(myPen1, 560, yrec, 60, 40)
                'e.Graphics.DrawRectangle(myPen1, 620, yrec, 60, 40)
                'e.Graphics.DrawRectangle(myPen1, 680, yrec, 60, 40)
                'e.Graphics.DrawRectangle(myPen1, 740, yrec, 60, 40)
                e.HasMorePages = True
            Case 4
                Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
                Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)
                Dim Font10B As New Font("Nirmala UI", 10, FontStyle.Bold)

                Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
                Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)
                Dim Font11B As New Font("Nirmala UI", 11, FontStyle.Bold)
                e.Graphics.DrawRectangle(myPen, 30, 190, 780, 800) 'bixbox
                e.Graphics.DrawString("EXECUTIVE SHIP MANAGEMENT ", Font, Brushes.Black, 30, 70) 'title
                e.Graphics.DrawRectangle(myPen, 400, 70, 250, 20)
                e.Graphics.DrawString("File Ref: Phoenix ", Font, Brushes.Black, 460, 70) 'title
                e.Graphics.DrawString("OC 31 ", Font, Brushes.Black, 760, 70) 'title
                e.Graphics.DrawString("Page 4 of 4", Font, Brushes.Black, 725, 90) 'title
                e.Graphics.DrawString("(06/17 Rev 0) ", Font, Brushes.Black, 715, 110) 'title

        End Select

        PageNum += 1
    End Sub

    ''//////////////////////////////////ESMCV_31/////////////////////////////////
    Private Sub EsmCv31_Click(sender As Object, e As EventArgs) Handles EsmCv31.Click


        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized
        PPV.Document.DefaultPageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1100)
        AddHandler PD.PrintPage, AddressOf OC31Doc_PrintPage


        'Printing na may set up ng page
        Dim AmsPrintDialog As New PrintDialog()
        ' PrintDialog1.Document = CvPrint


        If AmsPrintDialog.ShowDialog(PPV) = Windows.Forms.DialogResult.OK Then
            OC31Print.PrinterSettings = AmsPrintDialog.PrinterSettings
            AmsPrintDialog.AllowSomePages = True
            OC31Print.Print()
            Me.Hide()
        End If



    End Sub
    ''///////////////////////////////////////////////ESM CV////////////////////////////////////////
    Private Sub EsmPrint_PrintPage(sender As Object, e As PrintPageEventArgs) Handles EsmPrint.PrintPage
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Dim Font As New Font("Nirmala UI", 14, FontStyle.Bold)
        Dim Font10B As New Font("Nirmala UI", 10, FontStyle.Bold)
        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)
        Dim Font12B As New Font("Nirmala UI", 12, FontStyle.Bold)
        Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
        Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)
        Dim Font9 As New Font("Nirmala UI", 9, FontStyle.Regular)
        Dim Font8 As New Font("Nirmala UI", 8, FontStyle.Regular)
        Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
        Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)
        Dim Font7B As New Font("Nirmala UI", 7, FontStyle.Bold)
        Dim bg As SolidBrush = New SolidBrush(Color.SkyBlue)
        Dim bg1 As SolidBrush = New SolidBrush(Color.LightGray)

        Select Case PageNum

            Case 1
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\ESM-OC9_ESM_Tanker_final_Page_1.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                'e.Graphics.DrawImage(newImage, e.PageBounds)
                ' MsgBox(e.PageBounds.ToString)
                e.Graphics.DrawImage(newImage, 0, 0, 827, 1169)
                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                Dim selinfo As String
                selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ad.App_ZipCode, ad.App_City, ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year ,ae.School_From, ae.School_To, ae.School_Name, ae.Voc_Course,ae.Voc_To, ae.Voc_School, sc.App_RankApplied, sc.App_DateApplied,ai.App_Picture
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
 LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

                Dim selinfocmd As OdbcCommand
                selinfocmd = New OdbcCommand(selinfo, conn)

                Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

                Dim Fullname As String


                If selinforeader.Read Then



                    Lname = selinforeader.Item("App_LName").ToString

                    Fname = selinforeader.Item("App_FName").ToString
                    Mname = selinforeader.Item("App_MName").ToString

                    Fullname = Lname + ",  " + Fname + "  " + Mname
                    ZipCode = selinforeader.Item("App_ZipCode").ToString
                    City = selinforeader.Item("App_City").ToString
                    Suffix = selinforeader.Item("App_Suffix").ToString
                    NNname = selinforeader.Item("App_Nickname").ToString
                    Address = selinforeader.Item("Address").ToString
                    Address2 = selinforeader.Item("App_address2").ToString
                    citizenship = selinforeader.Item("App_Citezenship").ToString
                    Bday = selinforeader.Item("App_Bday").Date.ToString()
                    Bplace = selinforeader.Item("App_BPlace").ToString
                    CivilStat = selinforeader.Item("App_CivilStat").ToString
                    DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
                    ContactNo = selinforeader.Item("App_ContactNo").ToString
                    ContactNo2 = selinforeader.Item("App_ContactNo2").ToString
                    Sex = selinforeader.Item("App_Sex").ToString
                    Religion = selinforeader.Item("App_Religion").ToString
                    EmailAdd = selinforeader.Item("App_EmailAdd").ToString
                    Pagibig = selinforeader.Item("App_PagibigNo").ToString
                    Tin = selinforeader.Item("App_TinNo").ToString
                    SSS = selinforeader.Item("App_SSSNo").ToString
                    Philhealth = selinforeader.Item("App_PhilHealthNo").ToString
                    Heights = selinforeader.Item("App_Height").ToString
                    Weight = selinforeader.Item("App_Weight").ToString
                    Shirtsize = selinforeader.Item("App_ShirtSize").ToString
                    Suitsize = selinforeader.Item("App_SuitSize").ToString
                    WaisteSize = selinforeader.Item("App_WaisteSize").ToString
                    ShoeSize = selinforeader.Item("App_ShoeSize").ToString
                    CCourse = selinforeader.Item("Studies_Course").ToString
                    CStudies = selinforeader.Item("Studies_Name").ToString
                    CYear = selinforeader.Item("Studies_Year").ToString
                    HSchool = selinforeader.Item("School_Name").ToString
                    HSchoolFr = selinforeader.Item("School_From").ToString
                    HSchooolTo = selinforeader.Item("School_To").ToString
                    VSchool = selinforeader.Item("Voc_School").ToString
                    VSchoolCourse = selinforeader.Item("Voc_Course").ToString
                    VSchooolTo = selinforeader.Item("Voc_To").ToString
                    rankapplied = selinforeader.Item("App_RankApplied").ToString
                    dateapplied = selinforeader.Item("App_DateApplied").ToString
                    filenamepic = selinforeader.Item("App_Picture").ToString

                    CHSchoolFr = Convert.ToDateTime(HSchoolFr)
                    CHSchooolTo = Convert.ToDateTime(HSchooolTo)
                    '     CVSchoolFr = Convert.ToDateTime(VSchoolFr)



                End If

                Dim courseyear As String

                courseyear = CYear + "\ " + CCourse

                filenamepic = selinforeader.Item("App_Picture").ToString
                Try

                    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                    e.Graphics.DrawImage(newDp, 645, 210, 120, 120)

                Catch ex As Exception

                End Try






                e.Graphics.DrawString(Fname, Font12B, Brushes.Black, 150, 140)

                e.Graphics.DrawString(Mname, Font12B, Brushes.Black, 400, 140)
                e.Graphics.DrawString(Lname, Font12B, Brushes.Black, 650, 140)
                e.Graphics.DrawString(Address, Font9B, Brushes.Black, 55, 232)

                e.Graphics.DrawString(citizenship, Font12B, Brushes.Black, 150, 165)
                e.Graphics.DrawString(Bplace, Font7B, Brushes.Black, 400, 165)
                e.Graphics.DrawString(Bday, Font12B, Brushes.Black, 660, 165)

                e.Graphics.DrawString(rankapplied, Font12B, Brushes.Black, 182, 192)

                e.Graphics.DrawString("+63", Font12B, Brushes.Black, 200, 375)
                e.Graphics.DrawString(ContactNo, Font10B, Brushes.Black, 105, 408)
                e.Graphics.DrawString(ContactNo2, Font10B, Brushes.Black, 260, 408)
                e.Graphics.DrawString(EmailAdd, Font9B, Brushes.Black, 90, 430)
                e.Graphics.DrawString("+63", Font12B, Brushes.Black, 565, 375)

                e.Graphics.DrawString(ZipCode, Font9B, Brushes.Black, 150, 332) 'postal

                e.Graphics.DrawString(City, Font9B, Brushes.Black, 260, 332) 'city
                e.Graphics.DrawString("Philippines", Font9B, Brushes.Black, 290, 357) 'country

                'After KIN Details
                e.Graphics.DrawString(Height, Font9, Brushes.Black, 106, 978)
                e.Graphics.DrawString(Weight, Font9, Brushes.Black, 240, 978)
                e.Graphics.DrawString(ShoeSize, Font9, Brushes.Black, 730, 978)

                'Civil Stat
                If CivilStat.ToString.Equals("Single") Then
                    e.Graphics.DrawString("yes", Font8, Brushes.Black, 106, 1078)
                ElseIf CivilStat.ToString.Equals("Married") Then
                    e.Graphics.DrawString("yes", Font8, Brushes.Black, 195, 1078)
                ElseIf CivilStat.ToString.Equals("Seperated") Then
                    e.Graphics.DrawString("yes", Font8, Brushes.Black, 289, 1078)

                ElseIf CivilStat.ToString.Equals("Divorced") Then
                    e.Graphics.DrawString("yes", Font8, Brushes.Black, 383, 1078)

                ElseIf CivilStat.ToString.Equals("Widowed") Then
                    e.Graphics.DrawString("yes", Font8, Brushes.Black, 485, 1078)
                End If





                'documents
                Dim seldoc As String
                seldoc = "Select  Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, AppDoc_Shortcut, date_format(AppDoc_DateIssued, '%d-%b-%Y')AS datein, AppDoc_Country, AppDoc_Status, date_format(AppDoc_DateExpired, '%d-%b-%Y') as dateout, App_DocID FROM hunters_pooling.applicant_doc where App_ID=" & GetAppID & ";"

                Dim doccommand As OdbcCommand
                doccommand = New OdbcCommand(seldoc, conn)
                Dim docreader As OdbcDataReader = doccommand.ExecuteReader()



                While docreader.Read
                    docid = docreader.Item("Document_ID").ToString()
                    docname = docreader.Item("AppDoc_Name").ToString()
                    docshortcut = docreader.Item("AppDoc_Shortcut").ToString()
                    docno = docreader.Item("AppDoc_No").ToString()
                    docplace = docreader.Item("AppDoc_Place").ToString()
                    crewdocid = docreader.Item("App_DocID").ToString()
                    docstatus = docreader.Item("AppDoc_Status").ToString()
                    doccountry = docreader.Item("AppDoc_Country").ToString()
                    dateissued = docreader.Item(5).ToString()
                    dateexpired = docreader.Item(8).ToString()



                    If docid.ToString.Equals("1003") Then
                        'Passport
                        e.Graphics.DrawString(docno, Font10B, Brushes.Black, 60, 480) 'PASSPORTNO
                        e.Graphics.DrawString(dateissued, Font10B, Brushes.Black, 180, 480) 'PASSPORTexpired
                        e.Graphics.DrawString(dateexpired.ToString(), Font10B, Brushes.Black, 300, 480) 'PASSPORTexpired
                        e.Graphics.DrawString(docplace, Font10B, Brushes.Black, 390, 480) 'PASSPORTexpired
                    End If

                    If docid.ToString.Equals("1004") Then
                        'SIRB no1
                        e.Graphics.DrawString(docno, Font10B, Brushes.Black, 148, 563)
                        e.Graphics.DrawString(dateissued, Font10B, Brushes.Black, 255, 563)
                        e.Graphics.DrawString(dateexpired, Font10B, Brushes.Black, 365, 563) '
                        e.Graphics.DrawString("PH", Font10B, Brushes.Black, 500, 563) '
                        e.Graphics.DrawString(docplace, Font10B, Brushes.Black, 610, 563)

                    End If
                    If docid.ToString.Equals("1469") Then
                        'us -visa
                        e.Graphics.DrawString(docno, Font10B, Brushes.Black, 60, 523)
                        e.Graphics.DrawString(dateissued, Font10B, Brushes.Black, 180, 523)
                        e.Graphics.DrawString(dateexpired.ToString(), Font10B, Brushes.Black, 300, 523)
                        e.Graphics.DrawString(docplace, Font10B, Brushes.Black, 390, 523)
                    End If
                    If docid.ToString.Equals("1013") Then
                        'goc-license
                        e.Graphics.DrawString(docname, Font10B, Brushes.Black, 60, 625)
                        e.Graphics.DrawString(docno, Font10B, Brushes.Black, 180, 625)
                        e.Graphics.DrawString(dateissued, Font10B, Brushes.Black, 300, 625)
                        e.Graphics.DrawString(dateexpired.ToString(), Font10B, Brushes.Black, 390, 625)
                        e.Graphics.DrawString("PH", Font10B, Brushes.Black, 500, 625)
                        e.Graphics.DrawString(docplace, Font10B, Brushes.Black, 620, 625)
                    End If
                End While


                'cert
                Dim selcel As String
                selcel = "Select Document_ID, AppCert_Name, AppCert_Shortcut, AppCert_No, AppCert_Place, AppCert_Country,  date_format(AppCert_DateIssued, '%d-%b-%Y') AS datein,   date_format(AppCert_DateExpired, '%d-%b-%Y') as dateout,    AppCert_Trainingcenter, AppCert_Status FROM hunters_pooling.applicant_cert where App_ID=" & GetAppID & ";"

                Dim celcmd As OdbcCommand
                celcmd = New OdbcCommand(selcel, conn)
                Dim celreader As OdbcDataReader = celcmd.ExecuteReader()
                While celreader.Read
                    certdocid = celreader.Item("Document_ID").ToString()
                    certname = celreader.Item("AppCert_Name").ToString()
                    certshortcut = celreader.Item("AppCert_Shortcut").ToString()
                    certno = celreader.Item("AppCert_No").ToString()
                    certplace = celreader.Item("AppCert_Place").ToString()
                    certcountry = celreader.Item("AppCert_Country").ToString()
                    certtraining = celreader.Item("AppCert_Trainingcenter").ToString()
                    certstatus = celreader.Item("AppCert_Status").ToString()
                    certissued = celreader.Item("datein").ToString

                    certexpired = celreader.Item("dateout").ToString()

                    If certdocid.ToString.Equals("1104") Then
                        'GMDSS
                        e.Graphics.DrawString(certshortcut, Font9, Brushes.Black, 65, 710)
                        e.Graphics.DrawString(certno, Font9, Brushes.Black, 180, 710)
                        e.Graphics.DrawString(certissued, Font9, Brushes.Black, 290, 710)
                        e.Graphics.DrawString(certexpired.ToString(), Font9, Brushes.Black, 390, 710)
                        e.Graphics.DrawString(certplace, Font9, Brushes.Black, 490, 710)
                    End If

                    ''full dp no9
                    ''e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 805) 'FULLDPNO
                    ''e.Graphics.DrawString(docno, Font, Brushes.Black, 425, 805) 'FULLDPrank
                    ''e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523,805) 'FULLDPissued
                    ''e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 805) 'FULLDPexpire

                    'If certdocid.ToString.Equals("1386") Then

                    '    'basicdp no10
                    '    e.Graphics.DrawString(certno, Font7, Brushes.Black, 280, 820) 'BASICDPNO
                    '    e.Graphics.DrawString("", Font7, Brushes.Black, 425, 820) 'BASICDPrank
                    '    e.Graphics.DrawString(certissued, Font7, Brushes.Black, 523, 820) 'BASICDPissued
                    '    e.Graphics.DrawString(certexpired.ToString(), Font7, Brushes.Black, 650, 820) 'BASICDPexpired
                    'End If

                    'If certdocid.ToString.Equals("1498") Then
                    '    'advancedp no11
                    '    e.Graphics.DrawString(certno, Font7, Brushes.Black, 280, 840) 'ADVANCEDPNO
                    '    e.Graphics.DrawString("", Font7, Brushes.Black, 425, 840) 'ADVANCEDPrank
                    '    e.Graphics.DrawString(certissued, Font7, Brushes.Black, 523, 840) 'ADVANCEDPissued
                    '    e.Graphics.DrawString(certexpired.ToString(), Font7, Brushes.Black, 650, 840) 'ADVANCEDPexpired
                    'End If

                    'If certdocid.ToString.Equals("1254") Then
                    '    'dpm no12
                    '    e.Graphics.DrawString(certno, Font7, Brushes.Black, 280, 860) 'DPMCERTNO
                    '    e.Graphics.DrawString("", Font7, Brushes.Black, 425, 860) 'DPMCERTPrank
                    '    e.Graphics.DrawString(certissued, Font7, Brushes.Black, 523, 860) 'DPMCERTPissued
                    '    e.Graphics.DrawString(certexpired.ToString(), Font7, Brushes.Black, 650, 860) 'DPMCERTexpired

                    'End If


                    ''VISA/LOGBOOK

                    'If certdocid.ToString.Equals("1683") And certshortcut.ToString.Equals("DP Logbook") Then
                    '    e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 970) 'DPLBISSUE 1683
                    'End If


                    'If certdocid.ToString.Equals("1395") Then
                    '    e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 990) 'IMCAISSUE
                    'End If

                    'If certdocid.ToString.Equals("1287") Then
                    '    e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 1110) 'CRNOPISSUE
                    'End If
                End While


                ' CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                'Family-wife
                Dim kinStr As String
                kinStr = "Select appkin_ID, CONCAT(appkin_LName,', ',appkin_FName,' ',appkin_MName,' ',appkin_Suffix) AS 'Name' ,appkin_Relation ,appkin_Bday, appkin_Passport,appkin_IssueDate, appkin_ExpiryDate,  appkin_PsprtPlaceIssue FROM hunters_pooling.applicant_family where App_ID=" & GetAppID & ";"

                Dim kincmd As OdbcCommand
                kincmd = New OdbcCommand(kinStr, conn)
                Dim kinreader As OdbcDataReader = kincmd.ExecuteReader()

                Dim Ykin = 890
                While kinreader.Read
                    'kinners
                    KFname = kinreader.Item("Name").ToString()
                    KBday = kinreader.Item("appkin_Bday").Date.ToString
                    KPassport = kinreader.Item("appkin_Passport").ToString()
                    KPsprtIssued = kinreader.Item("appkin_IssueDate").Date.ToString()
                    KPsprtExpired = kinreader.Item("appkin_ExpiryDate").Date.ToString()
                    KPsprtPlace = kinreader.Item("appkin_PsprtPlaceIssue").ToString()
                    KRelation = kinreader.Item("appkin_Relation").ToString()


                    'Try
                    '    certexpired = celreader.Item("AppCert_DateExpired").Date.ToString()
                    'Catch ex As Exception
                    '    certexpired = ""
                    'End Try


                    If KRelation.ToString.Equals("Wife") Then

                        e.Graphics.DrawString(KFname, Font9, Brushes.Black, 125, Ykin)
                        e.Graphics.DrawString(KBday, Font9, Brushes.Black, 270, Ykin)
                        e.Graphics.DrawString(KPassport, Font9, Brushes.Black, 370, Ykin)

                        e.Graphics.DrawString(KPsprtIssued, Font9, Brushes.Black, 470, Ykin)
                        e.Graphics.DrawString(KPsprtExpired.ToString(), Font9, Brushes.Black, 570, Ykin)
                        e.Graphics.DrawString(KPsprtPlace, Font9, Brushes.Black, 680, Ykin)
                    End If

                    If KRelation.ToString.Equals("Daugther") And KRelation.ToString.Equals("Son") Then

                        e.Graphics.DrawString(KFname, Font9, Brushes.Black, 125, Ykin)
                        e.Graphics.DrawString(KBday, Font9, Brushes.Black, 270, Ykin)
                        e.Graphics.DrawString(KPassport, Font9, Brushes.Black, 370, Ykin)

                        e.Graphics.DrawString(KPsprtIssued, Font9, Brushes.Black, 470, Ykin)
                        e.Graphics.DrawString(KPsprtExpired.ToString(), Font9, Brushes.Black, 570, Ykin)
                        e.Graphics.DrawString(KPsprtPlace, Font9, Brushes.Black, 680, Ykin)
                        Ykin = Ykin + 30
                    End If


                End While

                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                e.HasMorePages = True
            Case 2
                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\ESM-OC9_ESM_Tanker_final_Page_2.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                e.Graphics.DrawImage(newImage, e.PageBounds)
                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                e.HasMorePages = True



                'All
                Dim doccertstr As String
                doccertstr = "Select Document_ID, AppCert_Name, AppCert_No, AppCert_Place, date_format(AppCert_DateIssued, '%d-%b-%Y') AS datein,   date_format(AppCert_DateExpired, '%d-%b-%Y') as dateout, App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' 
                           UNION 
                           Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, date_format(AppDoc_DateIssued, '%d-%b-%Y')AS datein, date_format(AppDoc_DateExpired, '%d-%b-%Y') as dateout, App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID = '" & GetAppID & "'; "
                Dim doccertcommand As OdbcCommand
                doccertcommand = New OdbcCommand(doccertstr, conn)
                Dim doccertreader As OdbcDataReader = doccertcommand.ExecuteReader()
                While doccertreader.Read
                    certdocid = doccertreader.Item("Document_ID").ToString()
                    certname = doccertreader.Item("AppCert_Name").ToString()
                    certno = doccertreader.Item("AppCert_No").ToString()
                    certplace = doccertreader.Item("AppCert_Place").ToString()
                    certissued = doccertreader.Item("datein").ToString
                    certexpired = doccertreader.Item("dateout").ToString()




                    If certdocid.ToString.Equals("1468") Then
                        'BTCERTNO
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 590)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 590)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 590)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 590)
                    End If
                    If certdocid.ToString.Equals("1468") Then
                        'BFF
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 620)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 620)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 620)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 620)
                    End If
                    If certdocid.ToString.Equals("1477") Then
                        'AFF
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 650)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 650)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 650)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 650)
                    End If
                    If certdocid.ToString.Equals("1102") Then
                        'EFA
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 680)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 680)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 680)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 680)
                    End If
                    If certdocid.ToString.Equals("1043") Then
                        'MFA
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 710)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 710)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 710)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 710)
                    End If
                    If certdocid.ToString.Equals("1044") Then
                        'Meca
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 740)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 740)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 740)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 740)
                    End If

                    If certdocid.ToString.Equals("0001") Then
                        'pst
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 770)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 770)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 770)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 770)
                    End If
                    If certdocid.ToString.Equals("1568") Then
                        'pscrb
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 800)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 800)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 800)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 800)
                    End If
                    If certdocid.ToString.Equals("1239") Then
                        'btm
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 830)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 830)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 830)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 830)
                    End If
                    If certdocid.ToString.Equals("0001") Then
                        'pssr
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 860)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 860)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 860)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 860)
                    End If
                    If certdocid.ToString.Equals("1145") Then
                        'brm
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 903)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 903)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 903)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 903)
                    End If
                    If certdocid.ToString.Equals("1231") Then
                        'arpa
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 933)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 933)
                        e.Graphics.DrawString(certexpired.ToString("MM-dd-yyyy"), Font8, Brushes.Black, 510, 933)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 933)
                    End If

                    If certdocid.ToString.Equals("1105") Then
                        'ecdis
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 963)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 963)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 963)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 963)
                    End If

                    If certdocid.ToString.Equals("1657") Then
                        'ecdis-jrc
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 993)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 993)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 993)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 993)
                    End If

                    If certdocid.ToString.Equals("1122") Then
                        'sms
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1048)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1048)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1048)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1048)
                    End If

                    If certdocid.ToString.Equals("1164") Then
                        'ers
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1078)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1078)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1078)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1078)
                    End If
                    If certdocid.ToString.Equals("1361") Then
                        'soc
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1108)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1108)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1108)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1108)
                    End If
                    If certdocid.ToString.Equals("1032") Then
                        'sso
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1138)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1136)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1136)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1136)
                    End If
                    If certdocid.ToString.Equals("0001") Then
                        'stfs
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1166)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1166)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1166)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1166)
                    End If

                End While

            Case 3
                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\ESM-OC9_ESM_Tanker_final_Page_3.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                e.Graphics.DrawImage(newImage, e.PageBounds)

        End Select

        PageNum += 1
    End Sub

    Private Sub EsmCvBtn_Click(sender As Object, e As EventArgs) Handles EsmCvBtn.Click

        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized
        PPV.Document.DefaultPageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)

        AddHandler PD.PrintPage, AddressOf EsmPrint_PrintPage

        ' PPV.Show()

        'PPV.Show()  'Printing na may set up ng page
        Dim AmsPrintDialog As New PrintDialog()
        AmsPrintDialog.Document = CvPrint


        If AmsPrintDialog.ShowDialog(PPV) = Windows.Forms.DialogResult.OK Then
            EsmPrint.PrinterSettings = AmsPrintDialog.PrinterSettings
            AmsPrintDialog.AllowSomePages = True
            EsmPrint.Print()
            Me.Hide()
        End If

    End Sub


    ''/////////////////////////////////////NOVO CV/////////////////////////////////////////
    Private Sub NovoPrint_PrintPage(sender As Object, e As PrintPageEventArgs) Handles NovoPrint.PrintPage
        Dim Font As New Font("Arial", 10, FontStyle.Regular)

        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)

        Dim FontMID As New Font("Arial", 12, FontStyle.Regular)

        '    Dim Font As New Font(" Nirmala UI", 14, FontStyle.Bold)
        Dim Font10B As New Font("Nirmala UI", 10, FontStyle.Bold)

        Dim Font12B As New Font("Nirmala UI", 12, FontStyle.Bold)
        Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
        Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)
        Dim Font9 As New Font("Nirmala UI", 9, FontStyle.Regular)
        Dim Font8 As New Font("Nirmala UI", 8, FontStyle.Regular)
        Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
        Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)
        Dim Font6 As New Font("Nirmala UI", 6, FontStyle.Regular)





        Select Case PageNum
            Case 1
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\novoform1.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                'e.Graphics.DrawImage(newImage, e.PageBounds)

                e.Graphics.DrawImage(newImage, 1, 1, 825, 1300)

                Dim selinfo As String
                selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year ,ae.School_From, ae.School_To, ae.School_Name, ae.Voc_Course,ae.Voc_To, ae.Voc_School, sc.App_RankApplied, sc.App_DateApplied,ai.App_Picture
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
 LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

                Dim selinfocmd As OdbcCommand
                selinfocmd = New OdbcCommand(selinfo, conn)

                Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

                Dim Fullname As String


                If selinforeader.Read Then



                    Lname = selinforeader.Item("App_LName").ToString

                    Fname = selinforeader.Item("App_FName").ToString
                    Mname = selinforeader.Item("App_MName").ToString

                    Fullname = Lname + ",  " + Fname + "  " + Mname

                    Suffix = selinforeader.Item("App_Suffix").ToString
                    NNname = selinforeader.Item("App_Nickname").ToString
                    Address = selinforeader.Item("Address").ToString
                    Address2 = selinforeader.Item("App_address2").ToString
                    citizenship = selinforeader.Item("App_Citezenship").ToString
                    Bday = selinforeader.Item("App_Bday").Date.ToString()
                    Bplace = selinforeader.Item("App_BPlace").ToString
                    CivilStat = selinforeader.Item("App_CivilStat").ToString
                    DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
                    ContactNo = selinforeader.Item("App_ContactNo").ToString
                    ContactNo2 = selinforeader.Item("App_ContactNo2").ToString
                    Sex = selinforeader.Item("App_Sex").ToString
                    Religion = selinforeader.Item("App_Religion").ToString
                    EmailAdd = selinforeader.Item("App_EmailAdd").ToString
                    Pagibig = selinforeader.Item("App_PagibigNo").ToString
                    Tin = selinforeader.Item("App_TinNo").ToString
                    SSS = selinforeader.Item("App_SSSNo").ToString
                    Philhealth = selinforeader.Item("App_PhilHealthNo").ToString
                    Heights = selinforeader.Item("App_Height").ToString
                    Weight = selinforeader.Item("App_Weight").ToString
                    Shirtsize = selinforeader.Item("App_ShirtSize").ToString
                    Suitsize = selinforeader.Item("App_SuitSize").ToString
                    WaisteSize = selinforeader.Item("App_WaisteSize").ToString
                    ShoeSize = selinforeader.Item("App_ShoeSize").ToString
                    CCourse = selinforeader.Item("Studies_Course").ToString
                    CStudies = selinforeader.Item("Studies_Name").ToString
                    CYear = selinforeader.Item("Studies_Year").ToString
                    HSchool = selinforeader.Item("School_Name").ToString
                    HSchoolFr = selinforeader.Item("School_From").ToString
                    HSchooolTo = selinforeader.Item("School_To").ToString
                    VSchool = selinforeader.Item("Voc_School").ToString
                    VSchoolCourse = selinforeader.Item("Voc_Course").ToString
                    VSchooolTo = selinforeader.Item("Voc_To").ToString
                    rankapplied = selinforeader.Item("App_RankApplied").ToString
                    dateapplied = selinforeader.Item("App_DateApplied").ToString
                    filenamepic = selinforeader.Item("App_Picture").ToString

                    CHSchoolFr = Convert.ToDateTime(HSchoolFr)
                    CHSchooolTo = Convert.ToDateTime(HSchooolTo)
                    '     CVSchoolFr = Convert.ToDateTime(VSchoolFr)



                End If

                Dim courseyear As String

                courseyear = CYear + "\ " + CCourse

                filenamepic = selinforeader.Item("App_Picture").ToString
                Try

                    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                    e.Graphics.DrawImage(newDp, 625, 195, 130, 130)

                Catch ex As Exception

                End Try






                'APPLIEDDATEPOSITION
                e.Graphics.DrawString(rankapplied, Font, Brushes.Black, 170, 210) 'pOSITIONaPPLIED
                e.Graphics.DrawString(dateapplied, Font, Brushes.Black, 680, 175) 'DATEAPPLIED


                ''PERSONALINFO
                e.Graphics.DrawString(Fullname, Font, Brushes.Black, 170, 248) 'fullname

                e.Graphics.DrawString(Bday, Font, Brushes.Black, 170, 280) 'DATEBIRTH
                e.Graphics.DrawString(Bplace, Font, Brushes.Black, 250, 280) 'placeBIRTH

                e.Graphics.DrawString(citizenship, Font, Brushes.Black, 170, 295) 'nationality
                e.Graphics.DrawString(CivilStat, Font, Brushes.Black, 170, 315) 'cvstatus
                e.Graphics.DrawString(Religion, Font, Brushes.Black, 170, 330) 'religion
                e.Graphics.DrawString(ContactNo, Font, Brushes.Black, 170, 352) 'no1
                e.Graphics.DrawString(EmailAdd, Font, Brushes.Black, 170, 375) 'EMAILADD
                e.Graphics.DrawString(Address, Font8, Brushes.Black, 170, 395) 'address




                e.Graphics.DrawString(Heights, Font, Brushes.Black, 540, 332) 'HEIGHT
                e.Graphics.DrawString(Weight, Font, Brushes.Black, 540, 352) 'WEIGHT
                e.Graphics.DrawString(appage, Font, Brushes.Black, 700, 332) 'age

                e.Graphics.DrawString(Shirtsize, Font, Brushes.Black, 700, 352) 'CSIZE
                e.Graphics.DrawString(ShoeSize, Font, Brushes.Black, 700, 375) 'SHOESIZE

                e.Graphics.DrawString(WaisteSize, Font, Brushes.Black, 700, 395) 'waistline
                '   e.Graphics.DrawString(ContactNo2, Font, Brushes.Black, 675, 350 + 25) 'no1



                ''education

                e.Graphics.DrawString(courseyear, Font7, Brushes.Black, 300, 515)
                e.Graphics.DrawString(CStudies, Font8, Brushes.Black, 555, 515)

                'novokinners
                Dim kinStr As String
                kinStr = "Select appkin_ID, CONCAT(appkin_LName,', ',appkin_FName,' ',appkin_MName,' ',appkin_Suffix) AS 'Name' ,appkin_Relation ,appkin_Bday, appkin_Passport,appkin_IssueDate, appkin_ExpiryDate,  appkin_PsprtPlaceIssue FROM hunters_pooling.applicant_family where App_ID=" & GetAppID & ";"

                Dim kincmd As OdbcCommand
                kincmd = New OdbcCommand(kinStr, conn)
                Dim kinreader As OdbcDataReader = kincmd.ExecuteReader()

                If kinreader.Read Then

                    KFname = kinreader.Item("Name").ToString()

                    KRelation = kinreader.Item("appkin_Relation").ToString()

                    e.Graphics.DrawString(KFname, Font9, Brushes.Black, 170, 415)
                    e.Graphics.DrawString(KRelation, Font9, Brushes.Black, 500, 415)

                End If






                'DE-BUG
                'All
                Dim doccertstr As String
                doccertstr = "Select Document_ID, AppCert_Name, AppCert_No, AppCert_Place, date_format(AppCert_DateIssued, '%d-%b-%Y') AS datein,   date_format(AppCert_DateExpired, '%d-%b-%Y') as dateout, App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID ='" & GetAppID & "' 
                           UNION 
                          Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place,  date_format(AppDoc_DateIssued, '%d-%b-%Y') AS datein, date_format(AppDoc_DateExpired, '%d-%b-%Y') as dateout, App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID  = '" & GetAppID & "'  "
                Dim doccertcommand As OdbcCommand
                doccertcommand = New OdbcCommand(doccertstr, conn)
                Dim doccertreader As OdbcDataReader = doccertcommand.ExecuteReader()

                'dito kinopya
                While doccertreader.Read
                    certdocid = doccertreader.Item("Document_ID").ToString()
                    certname = doccertreader.Item("AppCert_Name").ToString()
                    certno = doccertreader.Item("AppCert_No").ToString()
                    certplace = doccertreader.Item("AppCert_Place").ToString()
                    certissued = doccertreader.Item("datein").ToString()
                    certexpired = doccertreader.Item("dateout").ToString()


                    'Dim certnewexp As String

                    'If certexpired.Equals("") Then
                    '    certnewexp = ""

                    'Else
                    '    certnewexp = certexpired
                    'End If

                    If certdocid.ToString.Equals("1011") Then
                        'COP_COC
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 555)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 580, 555)

                    End If

                    If certdocid.ToString.Equals("1490") Then
                        'COP_COE
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 595)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 580, 595)

                    End If
                    If certdocid.ToString.Equals("1013") Then
                        'GOC-License
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 595)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 580, 595)
                    ElseIf certdocid.ToString.Equals("1167") Then
                        'Watch-Keeping
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 595)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 580, 595)
                    End If

                    If certdocid.ToString.Equals("1003") Then
                        'passport
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 460) 'PASSPORTNO
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 580, 460) 'PASSPORTexpired

                    End If

                    If certdocid.ToString.Equals("1004") Then
                        'SIRB no1
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 480) 'PSBNO
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 580, 480) 'PSBexpired


                    End If

                    If certdocid.ToString.Equals("1468") OrElse certdocid.ToString.Equals("1452") Then

                        If certdocid.ToString.Equals("1468") Then
                            'BTCERTNO-cop
                            e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 680) 'btNO
                            e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 680) 'btissued
                            e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 680) 'btBexpired

                            'ElseIf certdocid.ToString.Equals("1452") Then
                            '    'BTCERTNO
                            '    e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 680) 'btNO
                            '    e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 680) 'btissued
                            '    e.Graphics.DrawString(certnewexp, Font, Brushes.Black, 680, 680) 'btBexpired
                        End If

                    End If



                    'ATFF
                    If certdocid.ToString.Equals("1477") Or certdocid.ToString.Equals("1567") Then

                        If certdocid.ToString.Equals("1477") Then
                            'aff-cop
                            e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 700)


                            e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 700)
                            e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 700)
                            'ElseIf certdocid.ToString.Equals("1567") Then
                            '    e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 700)
                            '    e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 700)
                            '    e.Graphics.DrawString(certnewexp, Font, Brushes.Black, 680, 700)
                        End If
                    End If

                    'PSCRB
                    If certdocid.ToString.Equals("1568") Or certdocid.ToString.Equals("1478") Then
                        If certdocid.ToString.Equals("1478") Then
                            'ref-pscrb
                            e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 720) 'btNO
                            e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 720) 'btissued
                            e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 720) 'btBexpired
                            'ElseIf certdocid.ToString.Equals("1568") Then
                            '    e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 720) 'btNO
                            '    e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 720) 'btissued
                            '    e.Graphics.DrawString(certnewexp, Font, Brushes.Black, 680, 720) 'btBexpired
                        End If

                    End If

                    'mefa
                    If certdocid.ToString.Equals("1043") Or certdocid.ToString.Equals("1479") Then

                        If certdocid.ToString.Equals("1479") Then
                            e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 740)
                            e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 740)
                            e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 740)
                            'ElseIf certdocid.ToString.Equals("1043") Then
                            '    e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 740)
                            '    e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 740)
                            '    e.Graphics.DrawString(certnewexp, Font, Brushes.Black, 680, 740)
                        End If

                    End If

                    'MECA
                    If certdocid.ToString.Equals("1044") Or certdocid.ToString.Equals("1508") Then
                        If certdocid.ToString.Equals("1508") Then
                            e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 760)
                            e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 760)
                            e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 760)
                            'ElseIf certdocid.ToString.Equals("1044") Then
                            '    e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 760)
                            '    e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 760)
                            '    e.Graphics.DrawString(certnewexp, Font, Brushes.Black, 680, 760)
                        End If
                    End If

                    If certdocid.ToString.Equals("1231") Then
                        'arpa
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 780)
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 780)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 780)

                    End If

                    If certdocid.ToString.Equals("1684") Then
                        'radar
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 800) 'btNO
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 800) 'btissued
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 800) 'btBexpired
                    End If

                    If certdocid.ToString.Equals("1105") Then
                        'ecdis
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 825)
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 825)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 825)

                    End If

                    'brm
                    If certdocid.ToString.Equals("1696") Or certdocid.ToString.Equals("1145") Then
                        If certdocid.ToString.Equals("1696") Then 'ref-brm
                            e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 848)
                            e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 848)
                            e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 848)

                        ElseIf certdocid.ToString.Equals("1145") Then
                            e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 848)
                            e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 848)
                            e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 848)
                        End If
                    End If


                    If certdocid.ToString.Equals("1164") Then
                        'ERM
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 868)
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 868)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 868)

                    End If


                    If certdocid.ToString.Equals("1032") Then
                        'SSO
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 888)
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 888)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 888)

                    End If

                    If certdocid.ToString.Equals("1290") Then
                        'HUET
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 908)
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 908)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 908)


                    End If

                    If certdocid.ToString.Equals("1205") Then
                        'bosiet
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 928)
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 928)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 928)

                    End If


                    If certdocid.ToString.Equals("1117") Then
                        'frb
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 320, 968)
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 530, 968)
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 680, 968)

                    End If


                    If certdocid.ToString.Equals("1241") Then
                        'incident
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 320, 998)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 530, 998)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 680, 998)

                    End If
                    If certdocid.ToString.Equals("1424") Then
                        'sdsd
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 320, 1018)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 530, 1018)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 680, 1018)

                    End If
                    If certdocid.ToString.Equals("1287") Then
                        'crane
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 320, 1038)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 530, 1038)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 680, 1038)

                    End If


                    If certdocid.ToString.Equals("1322") Then
                        'rigging
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 320, 1058)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 530, 1058)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 680, 1058)

                    End If
                    If certdocid.ToString.Equals("1339") Then
                        'banksman
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 320, 1078)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 530, 1078)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 680, 1078)

                    End If
                    If certdocid.ToString.Equals("1372") Then
                        'btm
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 320, 1098)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 530, 1098)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 680, 1098)

                    End If
                    'If certdocid.ToString.Equals("0001") Then
                    '    'pssr
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 860)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 860)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 860)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 860)
                    'End If




                    'If certdocid.ToString.Equals("1657") Then
                    '    'ecdis-jrc
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 993)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 993)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 993)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 993)
                    'End If

                    'If certdocid.ToString.Equals("1122") Then
                    '    'sms
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1048)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1048)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1048)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1048)
                    'End If

                    'If certdocid.ToString.Equals("1164") Then
                    '    'ers
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1078)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1078)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1078)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1078)
                    'End If
                    'If certdocid.ToString.Equals("1361") Then
                    '    'soc
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1108)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1108)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1108)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1108)
                    'End If

                    'If certdocid.ToString.Equals("0001") Then
                    '    'stfs
                    '    e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1166)
                    '    e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1166)
                    '    e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1166)
                    '    e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1166)
                    'End If

                End While

                Dim crctrstr, reftype As String
                crctrstr = "SELECT * FROM hunters_pooling.applicant_reference  where App_ID = '" & GetAppID & "' ORDER BY Reference_ID desc limit 1 ; "
                Dim crctcommand As OdbcCommand
                crctcommand = New OdbcCommand(crctrstr, conn)
                Dim crctrreader As OdbcDataReader = crctcommand.ExecuteReader()



                While crctrreader.Read

                    reftype = crctrreader.Item("Ref_Type").ToString()
                    refName = crctrreader.Item("Ref_Name").ToString()
                    refAddress = crctrreader.Item("Ref_Address").ToString()
                    refCPerson = crctrreader.Item("Ref_CPerson").ToString()
                    refNumber = crctrreader.Item("Ref_Number").ToString()
                    refEmail = crctrreader.Item("Ref_Email").ToString()

                    If reftype.ToString.Equals("Agency") Then

                        e.Graphics.DrawString(refCPerson, Font8, Brushes.Black, 100, 1110)
                        e.Graphics.DrawString(refName, Font7, Brushes.Black, 100, 1133)
                        e.Graphics.DrawString("    ", Font8, Brushes.Black, 100, 1150)
                        e.Graphics.DrawString(refNumber, Font8, Brushes.Black, 120, 1170)
                    Else

                        e.Graphics.DrawString(refCPerson, Font8, Brushes.Black, 510, 1110)
                        e.Graphics.DrawString(refName, Font7, Brushes.Black, 510, 1133)
                        e.Graphics.DrawString("    ", Font8, Brushes.Black, 510, 1150)
                        e.Graphics.DrawString(refNumber, Font8, Brushes.Black, 510, 1170)


                    End If

                End While




                Dim sbstr As String
                sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc limit 1 ; "


                Dim sbcmd As OdbcCommand
                sbcmd = New OdbcCommand(sbstr, conn)
                Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()
                If sbreader.Read Then
                    e.Graphics.DrawString(sbreader.Item("App_Salary").ToString(), Font, Brushes.Black, 170, 232)
                End If


                e.HasMorePages = True
                e.PageSettings.Landscape = True
            Case 2


                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Dim y As Integer = 113
                Dim yrec As Integer = 40
                Dim ynovo As Integer = 80

                Dim Fontbox As New Font("Arial", 8, FontStyle.Regular)

                Dim fontdate As New Font("Arial", 7, FontStyle.Regular)
                Dim fontinside As New Font("Arial", 10, FontStyle.Regular)
                Dim fontside As New Font("Arial", 9, FontStyle.Regular)
                Dim FontMID1 As New Font("Arial", 12, FontStyle.Regular)

                Dim FontTitle1 As New Font("Arial", 9, FontStyle.Regular)

                Dim myPen As Pen = New Pen(Drawing.Color.Black, 2)
                Dim bg As SolidBrush = New SolidBrush(Color.Aqua)
                Dim counter As Integer = 0
                Dim ysb = 85


                Dim sbstr As String
                'sqlquery

                sbstr = "SELECT App_Rank, App_VesselName, App_ImportFlag, App_VesselType, App_EngineType, App_GRT, App_KW, App_TradingRoute, date_format(App_DateSignedON, '%d-%b-%Y') AS datein,  date_format(App_DateSignedOFF , '%d-%b-%Y') AS dateoff,  App_Duration FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc  limit 20 ; "




                Dim sbcmd As OdbcCommand
                sbcmd = New OdbcCommand(sbstr, conn)
                Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()
                Dim inyear, outyear As Date
                Dim tyear, tmonth, tdate As Integer

                tyear = 0

                Dim initialDay, initialMonth, initialYear, TotalDay, TotalMonth, TotalYear As Integer
                initialDay = 0
                initialMonth = 0
                initialYear = 0
                TotalDay = 0
                TotalMonth = 0
                TotalYear = 0

                While sbreader.Read
                    e.Graphics.DrawString(sbreader.Item("App_Rank").ToString(), FontTitle1, Brushes.Black, 65, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_VesselName").ToString(), FontTitle1, Brushes.Black, 165, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_ImportFlag").ToString(), FontTitle1, Brushes.Black, 315, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_VesselType").ToString(), FontTitle1, Brushes.Black, 415, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_EngineType").ToString(), FontTitle1, Brushes.Black, 515, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_GRT").ToString(), FontTitle1, Brushes.Black, 645, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_KW").ToString(), FontTitle1, Brushes.Black, 735, ysb)
                    e.Graphics.DrawString(sbreader.Item("App_TradingRoute").ToString(), FontTitle1, Brushes.Black, 825, ysb)

                    Try
                        e.Graphics.DrawString(sbreader.Item("datein").ToString(), fontdate, Brushes.Black, 1063, ysb)
                        e.Graphics.DrawString(sbreader.Item("dateoff").ToString(), fontdate, Brushes.Black, 960, ysb)
                    Catch ex As Exception
                        e.Graphics.DrawString(outyear, fontdate, Brushes.Black, 1063, ysb)
                        e.Graphics.DrawString(inyear, fontdate, Brushes.Black, 960, ysb)
                    End Try


                    ysb = ysb + 30
                End While

                'solving date
                Dim sbdatestr As String
                sbdatestr = "SELECT App_Rank, App_VesselName, App_ImportFlag, App_VesselType, App_EngineType, App_GRT, App_KW, App_TradingRoute,App_DateSignedON, App_DateSignedOFF,  App_Duration FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc  limit 20 ; "
                Dim sbdatecmd As OdbcCommand
                sbdatecmd = New OdbcCommand(sbdatestr, conn)
                Dim sbdatereader As OdbcDataReader = sbdatecmd.ExecuteReader()
                ysb = 85
                While sbdatereader.Read
                    inyear = sbdatereader.GetDate(8).ToString()
                    outyear = sbdatereader.GetDate(9).ToString()

                    Difference(inyear, outyear)


                    e.Graphics.DrawString(Year.ToString, fontside, Brushes.Black, 1155, ysb)
                    e.Graphics.DrawString(Month.ToString, fontside, Brushes.Black, 1227, ysb)
                    e.Graphics.DrawString(Day.ToString, fontside, Brushes.Black, 1289, ysb)

                    tyear = tyear + Year
                    ysb = ysb + 30
                    initialDay = initialDay + Day
                    initialMonth = initialMonth + Month
                    initialYear = initialYear + Year
                End While



                Dim inM, inY As Integer
                Dim iYears, iMonths, iWeeks, iDays As Integer

                If initialMonth >= 12 Then

                    inM = initialMonth * 30 'months magiging days 
                    initialDay = initialDay + inM ' total ng days
                    inY = initialYear * 12 * 30  'Year na mgiging days
                    TotalDay = initialDay + inY



                    '1 Year = 365 Days, 1 Month = 30 Days, 1 Week = 7 Days
                    ' To keep things simple, We are Not considering Leap years 
                    'And assuming 1 Month = 30 Days  
                    iYears = TotalDay / 365
                    'Remaining days after year
                    TotalDay = TotalDay - iYears * 365
                    iMonths = TotalDay / 30
                    'Remaining days after month
                    TotalDay = TotalDay - iMonths * 30
                    iWeeks = TotalDay / 7
                    'Remaining days after week
                    TotalDay = TotalDay - iWeeks * 7
                    iDays = TotalDay

                End If




                e.Graphics.DrawString(iYears, fontside, Brushes.Black, 1155, 695)
                e.Graphics.DrawString(iMonths, fontside, Brushes.Black, 1227, 695)
                e.Graphics.DrawString(iDays, fontside, Brushes.Black, 1289, 695)

                'drawings
                e.Graphics.DrawString("RECORD OF SEASERVICE", FontMID, Brushes.Black, 40, 20)

                e.Graphics.DrawString("NO", Fontbox, Brushes.Black, 32, 45)
                e.Graphics.DrawRectangle(myPen, 30, yrec, 30, 40) 'no

                e.Graphics.DrawString("Rank", Fontbox, Brushes.Black, 65, 45)
                e.Graphics.DrawRectangle(myPen, 60, yrec, 100, 40) 'rank
                e.Graphics.DrawString("Name of Ship", Fontbox, Brushes.Black, 170, 45)
                e.Graphics.DrawRectangle(myPen, 160, yrec, 150, 40) 'ship
                e.Graphics.DrawString("Flag", Fontbox, Brushes.Black, 325, 45)
                e.Graphics.DrawRectangle(myPen, 310, yrec, 100, 40) 'nationality
                e.Graphics.DrawString("Type", Fontbox, Brushes.Black, 420, 45)
                e.Graphics.DrawRectangle(myPen, 410, yrec, 100, 40) 'type
                e.Graphics.DrawString("Engine Type", Fontbox, Brushes.Black, 520, 45)
                e.Graphics.DrawRectangle(myPen, 510, yrec, 130, 40) 'enginetype
                e.Graphics.DrawString("GRT", Fontbox, Brushes.Black, 670, 45)
                e.Graphics.DrawRectangle(myPen, 640, yrec, 90, 40) 'grt
                e.Graphics.DrawString("KW", Fontbox, Brushes.Black, 738, 45)
                e.Graphics.DrawRectangle(myPen, 730, yrec, 90, 40)
                e.Graphics.DrawString("Trading Area", Fontbox, Brushes.Black, 830, 45)
                e.Graphics.DrawRectangle(myPen, 820, yrec, 130, 40) 'ship
                e.Graphics.DrawString("Sign in", Fontbox, Brushes.Black, 955, 45)
                e.Graphics.DrawRectangle(myPen, 950, yrec, 100, 40) 'type
                e.Graphics.DrawString("Sign off", Fontbox, Brushes.Black, 1056, 45)
                e.Graphics.DrawRectangle(myPen, 1050, yrec, 100, 40) 'type
                e.Graphics.DrawString("Seatime", Fontbox, Brushes.Black, 1195, 45)
                e.Graphics.DrawRectangle(myPen, 1150, yrec, 200, 40) 'engine make
                e.Graphics.DrawString("Year", Fontbox, Brushes.Black, 1155, 65)
                e.Graphics.DrawRectangle(myPen, 1150, 60, 67, 20) 'year
                e.Graphics.DrawString("Month", Fontbox, Brushes.Black, 1227, 65)
                e.Graphics.DrawRectangle(myPen, 1217, 60, 67, 20) 'month
                e.Graphics.DrawString("Day", Fontbox, Brushes.Black, 1289, 65)
                e.Graphics.DrawRectangle(myPen, 1284, 60, 66, 20) 'date


                Dim ctr As Integer
                Dim yctr = 82
                For ctr = 1 To 20 Step 1
                    e.Graphics.DrawString(ctr, Fontbox, Brushes.Black, 34, yctr)
                    e.Graphics.DrawRectangle(myPen, 30, ynovo, 30, 30) 'no
                    e.Graphics.DrawRectangle(myPen, 60, ynovo, 100, 30) 'rank
                    e.Graphics.DrawRectangle(myPen, 160, ynovo, 150, 30) 'nameship

                    e.Graphics.DrawRectangle(myPen, 310, ynovo, 100, 30) 'flag
                    e.Graphics.DrawRectangle(myPen, 410, ynovo, 100, 30) 'type
                    e.Graphics.DrawRectangle(myPen, 510, ynovo, 130, 30) 'enginetype
                    e.Graphics.DrawRectangle(myPen, 640, ynovo, 90, 30) 'grt
                    e.Graphics.DrawRectangle(myPen, 730, ynovo, 90, 30)

                    e.Graphics.DrawRectangle(myPen, 820, ynovo, 130, 30) 'traidingarea
                    e.Graphics.DrawRectangle(myPen, 950, ynovo, 100, 30) 'signin
                    e.Graphics.DrawRectangle(myPen, 1050, ynovo, 100, 30) 'signoff

                    e.Graphics.DrawRectangle(myPen, 1150, ynovo, 67, 30) ' year
                    e.Graphics.DrawRectangle(myPen, 1217, ynovo, 67, 30) 'month
                    e.Graphics.DrawRectangle(myPen, 1284, ynovo, 66, 30) 'day



                    ynovo = ynovo + 30
                    yctr = yctr + 30
                Next

                e.Graphics.DrawRectangle(myPen, 1050, ynovo, 100, 30) 'signin
                e.Graphics.DrawString("Total Seatime", Fontbox, Brushes.Black, 1060, ynovo + 15)

                e.Graphics.DrawString(tyear, Fontbox, Brushes.Black, 1560, ynovo + 15)
                e.Graphics.DrawRectangle(myPen, 1150, ynovo, 67, 30) ' year
                e.Graphics.DrawRectangle(myPen, 1217, ynovo, 67, 30) 'month
                e.Graphics.DrawRectangle(myPen, 1284, ynovo, 66, 30) 'day

                e.HasMorePages = True
                e.PageSettings.Landscape = False
                'dito isusulat

            Case 3
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                Dim certstr As String

                certstr = "Select AppCert_Shortcut, AppCert_No,   date_format(AppCert_DateIssued, '%d-%b-%Y') AS datein, AppCert_Place,AppCert_DateExpired FROM hunters_pooling.applicant_cert where App_ID='" & GetAppID & "';"
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

                e.Graphics.DrawRectangle(myPen, 30, 80, 235, 30)
                e.Graphics.DrawString("Course Name", FontMID, Brushes.Black, 70, 85)

                e.Graphics.DrawRectangle(myPen, 265, 80, 185, 30)
                e.Graphics.DrawString("Certificate Number", Font, Brushes.Black, 295, 85)

                e.Graphics.DrawRectangle(myPen, 450, 80, 185, 30)
                e.Graphics.DrawString("Issued Date", Font, Brushes.Black, 485, 85)

                '  e.Graphics.DrawRectangle(myPen, 530, 80, 140, 30)
                '   e.Graphics.DrawString("COP Number", Font, Brushes.Black, 560, 85)

                e.Graphics.DrawRectangle(myPen, 635, 80, 165, 30)
                e.Graphics.DrawString("Validity Date", Font, Brushes.Black, 666, 85)
                Dim counter As Integer = 0

                While certreader.Read



                    'box
                    e.Graphics.DrawRectangle(myPen, 30, yrec, 235, 25)
                    e.Graphics.DrawRectangle(myPen, 265, yrec, 185, 25)
                    e.Graphics.DrawRectangle(myPen, 450, yrec, 185, 25)
                    e.Graphics.DrawRectangle(myPen, 635, yrec, 165, 25)

                    'data
                    e.Graphics.DrawString(certreader.Item(0).ToString(), FontMID, Brushes.Black, 30, y)
                    e.Graphics.DrawString(certreader.Item(1).ToString(), Font, Brushes.Black, 295, y)

                    e.Graphics.DrawString(certreader.Item(2).ToString(), Font, Brushes.Black, 480, y)



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

        End Select
        PageNum += 1

    End Sub



    Private Sub NovoCvBtn_Click(sender As Object, e As EventArgs) Handles NovoCvBtn.Click


        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized

        AddHandler PD.PrintPage, AddressOf NovoPrint_PrintPage


        'Printing na may set up ng page
        Dim AmsPrintDialog As New PrintDialog()
        ' PrintDialog1.Document = CvPrint

        If AmsPrintDialog.ShowDialog(PPV) = Windows.Forms.DialogResult.OK Then
            NovoPrint.PrinterSettings = AmsPrintDialog.PrinterSettings
            AmsPrintDialog.AllowSomePages = True
            NovoPrint.Print()
            Me.Hide()
        End If

    End Sub
    Dim Lines As New List(Of String)
    Dim overallRecordIndex As Integer


    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles CoiPrintBtn.Click

        Dim font As XFont = New XFont(" Nirmala UI", 14, FontStyle.Bold)


        Dim Font10B As XFont = New XFont("Nirmala UI", 10, FontStyle.Bold)
        Dim FontTitle As XFont = New XFont("Arial", 13, FontStyle.Bold)

        Dim Font12 As XFont = New XFont("Nirmala UI", 12, FontStyle.Regular)
        Dim Font10 As XFont = New XFont("Nirmala UI", 10, FontStyle.Regular)
        Dim Font9 As XFont = New XFont("Nirmala UI", 9, FontStyle.Regular)
        Dim Font9B As XFont = New XFont("Nirmala UI", 9, FontStyle.Bold)
        Dim Font7 As XFont = New XFont("Nirmala UI", 7, FontStyle.Regular)
        Dim Font6 As XFont = New XFont("Nirmala UI", 6, FontStyle.Regular)
        Dim Font5 As XFont = New XFont("Nirmala UI", 5, FontStyle.Regular)
        Dim Font4 As XFont = New XFont("Nirmala UI", 4, FontStyle.Regular)

        Dim bg As XSolidBrush = New XSolidBrush(XColors.SkyBlue)
        Dim bg1 As XSolidBrush = New XSolidBrush(XColors.LightGray)




        Dim pdf As PdfDocument = New PdfDocument
        pdf.info.Title = "My First PDF"
        Dim pdfPage As PdfPage = pdf.AddPage
        Dim graph As XGraphics = XGraphics.FromPdfPage(pdfPage)
        pdfPage.Size = PageSize.Legal


        'docs entry
        Dim doccertstr As String
        Dim doccertcommand As OdbcCommand
        Dim doccertreader As OdbcDataReader

        Static startAt As Integer = 0

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If



        Dim selinfo As String
        selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year ,ae.School_From, ae.School_To, ae.School_Name, ae.Voc_Course,ae.Voc_To, ae.Voc_School, sc.App_RankApplied, sc.App_DateApplied,ai.App_Picture,sc.App_AssignedPrincipal,va.AVessel,va.APrincipal_ID
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
 LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
 LEFT JOIN hunters_pooling.applicant_vesselassign va ON ai.App_ID=va.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

        Dim selinfocmd As OdbcCommand
        selinfocmd = New OdbcCommand(selinfo, conn)

        Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

        Dim Fullname As String
        Dim PrincipalID As Integer

        If selinforeader.Read Then
            Lname = selinforeader.Item("App_LName").ToString
            Fname = selinforeader.Item("App_FName").ToString
            Mname = selinforeader.Item("App_MName").ToString
            Fullname = Lname + ",  " + Fname + "  " + Mname
            Suffix = selinforeader.Item("App_Suffix").ToString
            NNname = selinforeader.Item("App_Nickname").ToString
            Address = selinforeader.Item("Address").ToString
            Address2 = selinforeader.Item("App_address2").ToString
            citizenship = selinforeader.Item("App_Citezenship").ToString
            Bday = selinforeader.Item("App_Bday").Date.ToString()
            Bplace = selinforeader.Item("App_BPlace").ToString
            CivilStat = selinforeader.Item("App_CivilStat").ToString
            DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
            ContactNo = selinforeader.Item("App_ContactNo").ToString
            ContactNo2 = selinforeader.Item("App_ContactNo2").ToString
            Sex = selinforeader.Item("App_Sex").ToString
            Religion = selinforeader.Item("App_Religion").ToString
            EmailAdd = selinforeader.Item("App_EmailAdd").ToString
            Pagibig = selinforeader.Item("App_PagibigNo").ToString
            Tin = selinforeader.Item("App_TinNo").ToString
            SSS = selinforeader.Item("App_SSSNo").ToString
            Philhealth = selinforeader.Item("App_PhilHealthNo").ToString
            Heights = selinforeader.Item("App_Height").ToString
            Weight = selinforeader.Item("App_Weight").ToString
            Shirtsize = selinforeader.Item("App_ShirtSize").ToString
            Suitsize = selinforeader.Item("App_SuitSize").ToString
            WaisteSize = selinforeader.Item("App_WaisteSize").ToString
            ShoeSize = selinforeader.Item("App_ShoeSize").ToString
            CCourse = selinforeader.Item("Studies_Course").ToString
            CStudies = selinforeader.Item("Studies_Name").ToString
            CYear = selinforeader.Item("Studies_Year").ToString
            HSchool = selinforeader.Item("School_Name").ToString
            HSchoolFr = selinforeader.Item("School_From").ToString
            HSchooolTo = selinforeader.Item("School_To").ToString
            VSchool = selinforeader.Item("Voc_School").ToString
            VSchoolCourse = selinforeader.Item("Voc_Course").ToString
            VSchooolTo = selinforeader.Item("Voc_To").ToString
            rankapplied = selinforeader.Item("App_RankApplied").ToString
            dateapplied = selinforeader.Item("App_DateApplied").ToString
            filenamepic = selinforeader.Item("App_Picture").ToString
            Principal = selinforeader.Item("App_AssignedPrincipal").ToString
            Vessel = selinforeader.Item("AVessel").ToString
            PrincipalID = selinforeader.Item("APrincipal_ID").ToString
            CHSchoolFr = Convert.ToDateTime(HSchoolFr)
            CHSchooolTo = Convert.ToDateTime(HSchooolTo)

        End If


        yrec = 340

        Dim courseyear As String

        courseyear = CYear + "\ " + CCourse

        Dim myPen As XPen = New XPen(XColors.Black, 1)

        Dim myPen1 As XPen = New XPen(XColors.Black, 1)


        '//DRAWS THE PICTURE IN THE CANVASS////////////////////////////
        filenamepic = selinforeader.Item("App_Picture").ToString
        Try
            Dim newDp As XImage = XImage.FromFile(filenamepic) 'read image
            graph.DrawImage(newDp, 15, 15, 90, 90)

        Catch ex As Exception

        End Try

        Dim getFlag As String
        getFlag = "SELECT Vessel_Flag FROM csiaccountingdb.vessel where Principal_ID= " & PrincipalID & "; "
        Dim getFlagcmd As OdbcCommand
        getFlagcmd = New OdbcCommand(getFlag, conn)
        Dim getFlagreader As OdbcDataReader = getFlagcmd.ExecuteReader()
        If getFlagreader.Read Then
            VesselFlag = getFlagreader.Item("Vessel_Flag").ToString
        End If

        graph.DrawString(GetAppID, Font10, XBrushes.Black, 45, 127) 'religion
        '//////////////////////////////////////////////////////////////

        '//HEADER APPLICANT INFORMATION SHEET/////////////////////////////////////


        graph.DrawRectangle(myPen, XBrushes.SkyBlue, 115, 15, 350, 30)
        graph.DrawString("APPLICANT INFORMATION SHEET", font, XBrushes.White, 175, 35)
        '  '//////////////////////////////////////////////////////////////////////////

        ''  //WRITES THE CURRENT  DATE////////////////////////////////////////////////
        graph.DrawString("DATE: " + datenow.ToString("dd-MMM-yy"), Font12, XBrushes.Black, 480, 35)
        ' //////////////////////////////////////////////////////////////////////////
        '//NAME VESSEL BOXES///////////////////////////////////////////////////////
        graph.DrawRectangle(myPen, 115, 50, 240, 80)
        graph.DrawString("LAST NAME:", Font10, XBrushes.Black, 120, 65)
        graph.DrawString("FIRST NAME:", Font10, XBrushes.Black, 120, 83)
        graph.DrawString("MIDDLE NAME:", Font10, XBrushes.Black, 120, 103)
        graph.DrawString("NICK NAME:", Font10, XBrushes.Black, 120, 123)
        graph.DrawRectangle(myPen, 355, 50, 240, 80)
        graph.DrawString("POSITION APPLIED:", Font10, XBrushes.Black, 360, 65)
        graph.DrawString("AVAILABILITY:", Font10, XBrushes.Black, 360, 83)
        graph.DrawString("VESSEL:", Font10, XBrushes.Black, 360, 98)
        graph.DrawString("PRINCIPAL:", Font10, XBrushes.Black, 360, 113)
        graph.DrawString("FLAG:", Font10, XBrushes.Black, 360, 125)


        '''''''''''''''''''''''''''''''''''''''''''information'''''''''''''''''''''''''''''''''''''
        graph.DrawString(Lname, Font9B, XBrushes.Black, 180, 65)
        graph.DrawString(Fname, Font9B, XBrushes.Black, 180, 83)
        graph.DrawString(Mname, Font9B, XBrushes.Black, 195, 103)
        graph.DrawString(Fname, Font9B, XBrushes.Black, 180, 123)
        graph.DrawString(rankapplied, Font9B, XBrushes.Black, 450, 65)
        graph.DrawString("Available", Font9B, XBrushes.Black, 430, 83)
        graph.DrawString(Vessel, Font9B, XBrushes.Black, 400, 98)
        graph.DrawString(Principal, Font9B, XBrushes.Black, 418, 113)
        graph.DrawString(VesselFlag, Font9B, XBrushes.Black, 400, 125)

        '''''''''''''''''''''''''''''''''''''''''''Personal Info sheet Box'''''''''''''''''''''''''''''''''''''
        graph.DrawRectangle(myPen, XBrushes.SkyBlue, 15, 140, 340, 30)
        graph.DrawString("PERSONAL INFORMATION SHEET", font, XBrushes.White, 20, 160)
        graph.DrawRectangle(myPen, 15, 140, 340, 160)
        graph.DrawString("DATE OF BIRTH:", Font9, XBrushes.Black, 20, 180)
        graph.DrawString("AGE: ", Font9, XBrushes.Black, 270, 180)
        graph.DrawString("BIRTHPLACE:", Font9, XBrushes.Black, 20, 195)
        graph.DrawString("CIVIL STATUS:", Font9, XBrushes.Black, 20, 210)
        graph.DrawString("SPOUSE:", Font9, XBrushes.Black, 20, 225)
        graph.DrawString("HEIGHT:", Font9, XBrushes.Black, 20, 240)
        graph.DrawString("WEIGHT:", Font9, XBrushes.Black, 150, 240)
        graph.DrawString("BMI:", Font9, XBrushes.Black, 270, 240)
        '''''''''''''''''''''''''DATA ''''''''''''''''''''''''''''''
        graph.DrawString(Bday, Font9B, XBrushes.Black, 90, 180)
        graph.DrawString(appage, Font9B, XBrushes.Black, 290, 180)
        graph.DrawString(Bplace, Font9B, XBrushes.Black, 80, 195)
        graph.DrawString(CivilStat, Font9B, XBrushes.Black, 80, 210)
        graph.DrawString("N/A", Font9B, XBrushes.Black, 80, 225)


        Dim Bmi, WeightD, HeightD As Double
        Double.TryParse(Weight, WeightD)
        Double.TryParse(Height, HeightD)
        Bmi = WeightD / ((HeightD / 100) * (HeightD / 100))
        graph.DrawString(Heights + " CM", Font9B, XBrushes.Black, 60, 240)
        graph.DrawString(Weight + " KG", Font9B, XBrushes.Black, 190, 240)
        graph.DrawString(Bmi.ToString("#.##"), Font9B, XBrushes.Black, 290, 240)

        graph.DrawString("SCHOOL:", Font9, XBrushes.Black, 20, 255)
        graph.DrawString("COURSE:", Font9, XBrushes.Black, 20, 270)
        graph.DrawString("YR GRADUATED:", Font9, XBrushes.Black, 20, 285)
        graph.DrawString(CStudies, Font9B, XBrushes.Black, 80, 255)
        graph.DrawString(CCourse, Font9B, XBrushes.Black, 80, 270)
        graph.DrawString(CYear, Font9B, XBrushes.Black, 120, 285)
        '''''''''''''''''''''''''''''''''''''''''''Contact Info sheet Box'''''''''''''''''''''''''''''''''''''
        graph.DrawRectangle(myPen, XBrushes.SkyBlue, 355, 140, 240, 30)
        graph.DrawString("CONTACT INFORMATION", font, XBrushes.White, 365, 160)
        graph.DrawRectangle(myPen, 355, 140, 240, 160)

        graph.DrawString("CITY ADDRESS:", Font9, XBrushes.Black, 360, 180)
        graph.DrawString("PROVINCIAL ADDRESS:", Font9, XBrushes.Black, 360, 225)
        graph.DrawString("CONTACT NO.:", Font9, XBrushes.Black, 360, 270)
        graph.DrawString("E-MAIL ADD:", Font9, XBrushes.Black, 360, 285)

        ' graph.DrawString(Address2, Font9B, XBrushes.Black, rectF3)
        ' graph.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF3))

        graph.DrawString(Address, Font9B, XBrushes.Black, 360, 240)
        graph.DrawString(ContactNo, Font9B, XBrushes.Black, 430, 270)
        graph.DrawString(EmailAdd, Font9B, XBrushes.Black, 430, 285)





        '''''''''''''''''''''''''''''''''''''''''''Document Box'''''''''''''''''''''''''''''''''''''




        Dim rectF2 As New Rectangle(460, 185, 330, 40)



        Dim sbstr1 As String
        sbstr1 = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc limit  20; "
        Dim sbcmd1 As OdbcCommand
        sbcmd1 = New OdbcCommand(sbstr1, conn)
        Dim sbreader1 As OdbcDataReader = sbcmd1.ExecuteReader()
        'pinatangal ni melba
        'If sbreader1.Read Then
        '    graph.DrawString(sbreader1.Item("App_ImportFlag").ToString(), Font9B, XBrushes.Black, 510, 115)
        'End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




        '  graph.DrawString(Address, Font9B, XBrushes.Black, rectF2)
        ' graph.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF2))

        ' graph.DrawString(Address, Font9B, XBrushes.Black, 460, 185)

        Dim rectF3 As New RectangleF(460, 230, 330, 40)


        graph.DrawRectangle(myPen, XBrushes.SkyBlue, 15, 310, 170, 25)
        graph.DrawString("DOCUMENTS", Font10B, XBrushes.White, 20, 325)

        graph.DrawRectangle(myPen, XBrushes.SkyBlue, 185, 310, 120, 25)
        graph.DrawString("DOC. NO.", Font10B, XBrushes.White, 190, 325)

        graph.DrawRectangle(myPen, XBrushes.SkyBlue, 305, 310, 90, 25)
        graph.DrawString("ISSUE DATE", Font10B, XBrushes.White, 310, 325)

        graph.DrawRectangle(myPen, XBrushes.SkyBlue, 395, 310, 90, 25)
        graph.DrawString("VALIDITY", Font10B, XBrushes.White, 400, 325)

        graph.DrawRectangle(myPen, XBrushes.SkyBlue, 485, 310, 110, 25)
        graph.DrawString("DOC. INFO", Font10B, XBrushes.White, 490, 325)

        doccertstr = "Select Document_ID, AppCert_Name, AppCert_No, AppCert_Place, AppCert_DateIssued, AppCert_DateExpired, App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' 
                           UNION 
                           Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, AppDoc_DateIssued, AppDoc_DateExpired, App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' ; "

        doccertcommand = New OdbcCommand(doccertstr, conn)

        doccertreader = doccertcommand.ExecuteReader()

        Dim counter As Integer
        While doccertreader.Read
            'If (yrec >= 1350) Then       'Print new page
            '    'e.HasMorePages = True
            '    'yrec = 0
            '    'pageNumberToPrint = 2

            '    lastindex = yrec
            '    'The PrintPage event handler will be raised again
            'End If
            Dim rectF1 As New RectangleF(318, yrec + 2, 175, 20)
            myPen.DashStyle = Drawing.Drawing2D.DashStyle.DashDotDot
            graph.DrawRectangle(myPen, 15, yrec - 5, 170, 20)
            graph.DrawRectangle(myPen, 185, yrec - 5, 120, 20)
            graph.DrawRectangle(myPen, 305, yrec - 5, 90, 20)
            graph.DrawRectangle(myPen, 395, yrec - 5, 90, 20)
            graph.DrawRectangle(myPen, 485, yrec - 5, 110, 20)

            graph.DrawString(doccertreader.Item(1).ToString(), Font7, XBrushes.Black, 18, yrec + 7)
            graph.DrawString(doccertreader.Item(2).ToString(), Font6, XBrushes.Black, 190, yrec + 7)
            graph.DrawString(doccertreader.GetDate(4).ToString("MM-dd-yyyy"), Font7, XBrushes.Black, 310, yrec + 7)

            Try
                graph.DrawString(doccertreader.GetDate(5).ToString("MM-dd-yyyy"), Font7, XBrushes.Black, 400, yrec + 7)
            Catch ex As Exception
                graph.DrawString(" ", Font, XBrushes.Black, 690, yrec)
            End Try
            If counter Mod 2 = 0 Then

                'graph.FillRectangle(bg1, 15, yrec, 300, 20)
                'graph.FillRectangle(bg1, 315, yrec, 170, 20)
                'graph.FillRectangle(bg1, 485, yrec, 100, 20)
                'graph.FillRectangle(bg1, 585, yrec, 100, 20)
                'graph.FillRectangle(bg1, 685, yrec, 113, 20)
            End If

            yrec = yrec + 20
            counter = counter + 1

            If yrec = 940 Then
                pdfPage = pdf.AddPage()
                graph.Dispose()
                graph = XGraphics.FromPdfPage(pdfPage)
                pdfPage.Size = PageSize.Legal
                yrec = 20
            End If
        End While
        ' this is ThreadExceptionDialog sea exp

        ' graph.DrawString(e.MarginBounds.Bottom.ToString, Font10B, XBrushes.White, 20, 90)

        graph.DrawString("SEA EXPERIENCE", Font12, XBrushes.Black, 18, yrec + 15)
        yrec = yrec + 30




        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 15, yrec, 70, 20)
        graph.DrawString("VESSEL", Font10, XBrushes.White, 20, yrec + 13)

        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 85, yrec, 60, 20)
        graph.DrawString("Principal", Font10, XBrushes.White, 90, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 145, yrec, 40, 20)
        graph.DrawString("Flag", Font10, XBrushes.White, 150, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 185, yrec, 30, 20)
        graph.DrawString("Rank", Font10, XBrushes.White, 190, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 215, yrec, 35, 20)
        graph.DrawString("Vessel", Font10, XBrushes.White, 220, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 250, yrec, 40, 20)
        graph.DrawString("Grt", Font10, XBrushes.White, 255, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 290, yrec, 50, 20)
        graph.DrawString("Engine", Font10, XBrushes.White, 295, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 340, yrec, 40, 20)
        graph.DrawString("KW", Font10, XBrushes.White, 345, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 380, yrec, 50, 20)
        graph.DrawString("From", Font10, XBrushes.White, 385, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 430, yrec, 50, 20)
        graph.DrawString("To", Font10, XBrushes.White, 435, yrec + 13)

        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 480, yrec, 40, 20)
        graph.DrawString("Trade", Font10, XBrushes.White, 485, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 520, yrec, 40, 20)
        graph.DrawString("Reason", Font10, XBrushes.White, 525, yrec + 13)


        graph.DrawRectangle(myPen1, XBrushes.SkyBlue, 560, yrec, 40, 20)
        graph.DrawString("Mos", Font10, XBrushes.White, 565, yrec + 13)


        Dim sbstr As String
        sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "'; "

        ' sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc; "
        Dim sbcmd As OdbcCommand
        sbcmd = New OdbcCommand(sbstr, conn)
        Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()
        yrec = yrec + 20

        While sbreader.Read

            graph.DrawString(sbreader.Item("App_VesselName").ToString(), Font6, XBrushes.Black, 20, yrec + 10)


            Dim rectF4 As New RectangleF(120, yrec + 2, 65, 20)
            graph.DrawString(sbreader.Item("App_PrincipalName").ToString(), Font4, XBrushes.Black, 90, yrec + 10)
            ' graph.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF4))

            'graph.DrawString(sbreader.Item("App_PrincipalName").ToString(), Font6, XBrushes.Black, 120, yrec + 5)
            graph.DrawString(sbreader.Item("App_ImportFlag").ToString(), Font6, XBrushes.Black, 150, yrec + 10)
            graph.DrawString(sbreader.Item("App_Rank").ToString(), Font5, XBrushes.Black, 190, yrec + 10)
            graph.DrawString(sbreader.Item("App_VesselType").ToString(), Font5, XBrushes.Black, 220, yrec + 10)
            graph.DrawString(sbreader.Item("App_GRT").ToString(), Font6, XBrushes.Black, 255, yrec + 10)
            graph.DrawString(sbreader.Item("App_EngineType").ToString(), Font6, XBrushes.Black, 295, yrec + 10)
            graph.DrawString(sbreader.Item("App_KW").ToString(), Font6, XBrushes.Black, 345, yrec + 10)
            graph.DrawString(sbreader.GetDate(12).ToString("MMM-dd-yyyy"), Font6, XBrushes.Black, 385, yrec + 10)
            graph.DrawString(sbreader.GetDate(13).ToString("MMM-dd-yyyy"), Font6, XBrushes.Black, 435, yrec + 10)
            graph.DrawString(sbreader.Item("App_TradingRoute").ToString(), Font6, XBrushes.Black, 485, yrec + 10)
            graph.DrawString(sbreader.Item("App_Reason").ToString(), Font6, XBrushes.Black, 525, yrec + 10)
            graph.DrawString(sbreader.Item("App_Duration").ToString(), Font6, XBrushes.Black, 565, yrec + 10)
            graph.DrawRectangle(myPen, 15, yrec, 70, 20)
            graph.DrawRectangle(myPen, 85, yrec, 60, 20)
            graph.DrawRectangle(myPen, 145, yrec, 40, 20)
            graph.DrawRectangle(myPen, 185, yrec, 30, 20)
            graph.DrawRectangle(myPen, 215, yrec, 35, 20)
            graph.DrawRectangle(myPen, 250, yrec, 40, 20)
            graph.DrawRectangle(myPen, 290, yrec, 50, 20)
            graph.DrawRectangle(myPen, 340, yrec, 40, 20)
            graph.DrawRectangle(myPen, 380, yrec, 50, 20)
            graph.DrawRectangle(myPen, 430, yrec, 50, 20)
            graph.DrawRectangle(myPen, 480, yrec, 40, 20)
            graph.DrawRectangle(myPen, 520, yrec, 40, 20)
            graph.DrawRectangle(myPen, 560, yrec, 40, 20)

            yrec = yrec + 20

            If yrec = 940 Then
                pdfPage = pdf.AddPage()
                graph.Dispose()
                graph = XGraphics.FromPdfPage(pdfPage)
                pdfPage.Size = PageSize.Legal
                yrec = 20
            End If
        End While

        Dim qstring As String

        qstring = "SELECT c.org_name, cp.position_rank, rep_signature FROM crystal_organization c 
                LEFT JOIN crystal_position cp ON c.position_id=cp.position_id 
                LEFT JOIN crystal_contract cc ON cc.position_id=c.position_id 
                LEFT JOIN crystal_representatives cr ON cr.user_id=cc.user_id 
                WHERE c.position_id=22;"
        Dim qcmd As OdbcCommand
        qcmd = New OdbcCommand(qstring, conn)
        Dim qreader As OdbcDataReader = qcmd.ExecuteReader()
        Dim orgname, repspos As String

        If qreader.Read Then
            orgname = qreader.Item("org_name").ToString
            repspos = qreader.Item("position_rank").ToString
        End If
        graph.DrawString("Nominated By:", Font9, XBrushes.Black, 70, yrec + 25)
        graph.DrawString("_____________________________________", Font9, XBrushes.Black, 18, yrec + 55)
        graph.DrawString("Melba B. Lorenzo", Font9, XBrushes.Black, 55, yrec + 70)

        Try
            filenamepic = "\\192.168.11.3\Dropbox\ALL CREW DOCUMENTS\SIGNATURES\Azarcon_Allyson_01.png"

            Dim newDp As XImage = XImage.FromFile(filenamepic) 'read image
            graph.DrawImage(newDp, 235, yrec + 20, 185, 50)

        Catch ex As Exception
            filenamepic = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resources\Azarcon_Allyson_01.png"

            Dim newDp As XImage = XImage.FromFile(filenamepic) 'read image
            graph.DrawImage(newDp, 235, yrec + 20, 185, 50)

        End Try
        graph.DrawString(orgname, Font9, XBrushes.Black, 250, yrec + 70)
        graph.DrawString(repspos, Font9, XBrushes.Black, 260, yrec + 85)


        graph.DrawString("Certified Correct By:", Font9, XBrushes.Black, 480, yrec + 25)
        graph.DrawString("_____________________________________", Font9, XBrushes.Black, 445, yrec + 55)
        graph.DrawString(Fullname, Font9, XBrushes.Black, 480, yrec + 70)
        graph.DrawString("Seafarer", Font9, XBrushes.Black, 495, yrec + 85)











        Dim pdfFilename As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\PDF" + Lname + ".pdf"
        pdf.Save(pdfFilename)
        Process.Start(pdfFilename)

    End Sub

    '/////////////////////////////COI PRINT///////////////////////////////////


    Private Sub CoiPrint_PrintPage(sender As Object, e As PrintPageEventArgs) Handles CoiPrint.PrintPage
        'Dim PD As New Drawing.Printing.PrintDocument
        'AddHandler PD.PrintPage, AddressOf CoiPrint_PrintPage
        Dim Font As New Font(" Nirmala UI", 14, FontStyle.Bold)
        Dim Font10B As New Font("Nirmala UI", 10, FontStyle.Bold)
        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)

        Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
        Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)
        Dim Font9 As New Font("Nirmala UI", 9, FontStyle.Regular)
        Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
        Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)
        Dim Font6 As New Font("Nirmala UI", 6, FontStyle.Regular)
        Dim Font5 As New Font("Nirmala UI", 5, FontStyle.Regular)
        Dim Font4 As New Font("Nirmala UI", 4, FontStyle.Regular)

        Dim bg As SolidBrush = New SolidBrush(Color.SkyBlue)
        Dim bg1 As SolidBrush = New SolidBrush(Color.LightGray)


        'docs entry
        Dim doccertstr As String
        Dim doccertcommand As OdbcCommand
        Dim doccertreader As OdbcDataReader

        Static startAt As Integer = 0

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Dim selinfo As String
        selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year ,ae.School_From, ae.School_To, ae.School_Name, ae.Voc_Course,ae.Voc_To, ae.Voc_School, sc.App_RankApplied, sc.App_DateApplied,ai.App_Picture,sc.App_AssignedPrincipal,va.AVessel
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
 LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
 LEFT JOIN hunters_pooling.applicant_vesselassign va ON ai.App_ID=va.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

        Dim selinfocmd As OdbcCommand
        selinfocmd = New OdbcCommand(selinfo, conn)

        Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

        Dim Fullname As String


        If selinforeader.Read Then
            Lname = selinforeader.Item("App_LName").ToString
            Fname = selinforeader.Item("App_FName").ToString
            Mname = selinforeader.Item("App_MName").ToString
            Fullname = Lname + ",  " + Fname + "  " + Mname
            Suffix = selinforeader.Item("App_Suffix").ToString
            NNname = selinforeader.Item("App_Nickname").ToString
            Address = selinforeader.Item("Address").ToString
            Address2 = selinforeader.Item("App_address2").ToString
            citizenship = selinforeader.Item("App_Citezenship").ToString
            Bday = selinforeader.Item("App_Bday").Date.ToString()
            Bplace = selinforeader.Item("App_BPlace").ToString
            CivilStat = selinforeader.Item("App_CivilStat").ToString
            DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
            ContactNo = selinforeader.Item("App_ContactNo").ToString
            ContactNo2 = selinforeader.Item("App_ContactNo2").ToString
            Sex = selinforeader.Item("App_Sex").ToString
            Religion = selinforeader.Item("App_Religion").ToString
            EmailAdd = selinforeader.Item("App_EmailAdd").ToString
            Pagibig = selinforeader.Item("App_PagibigNo").ToString
            Tin = selinforeader.Item("App_TinNo").ToString
            SSS = selinforeader.Item("App_SSSNo").ToString
            Philhealth = selinforeader.Item("App_PhilHealthNo").ToString
            Heights = selinforeader.Item("App_Height").ToString
            Weight = selinforeader.Item("App_Weight").ToString
            Shirtsize = selinforeader.Item("App_ShirtSize").ToString
            Suitsize = selinforeader.Item("App_SuitSize").ToString
            WaisteSize = selinforeader.Item("App_WaisteSize").ToString
            ShoeSize = selinforeader.Item("App_ShoeSize").ToString
            CCourse = selinforeader.Item("Studies_Course").ToString
            CStudies = selinforeader.Item("Studies_Name").ToString
            CYear = selinforeader.Item("Studies_Year").ToString
            HSchool = selinforeader.Item("School_Name").ToString
            HSchoolFr = selinforeader.Item("School_From").ToString
            HSchooolTo = selinforeader.Item("School_To").ToString
            VSchool = selinforeader.Item("Voc_School").ToString
            VSchoolCourse = selinforeader.Item("Voc_Course").ToString
            VSchooolTo = selinforeader.Item("Voc_To").ToString
            rankapplied = selinforeader.Item("App_RankApplied").ToString
            dateapplied = selinforeader.Item("App_DateApplied").ToString
            filenamepic = selinforeader.Item("App_Picture").ToString
            Principal = selinforeader.Item("App_AssignedPrincipal").ToString
            Vessel = selinforeader.Item("AVessel").ToString
            CHSchoolFr = Convert.ToDateTime(HSchoolFr)
            CHSchooolTo = Convert.ToDateTime(HSchooolTo)

        End If

        Select Case PageNum

            Case 1

                yrec = 340

                Dim courseyear As String

                courseyear = CYear + "\ " + CCourse

                Dim myPen As Pen = New Pen(Drawing.Color.Black, 1)

                Dim myPen1 As Pen = New Pen(Drawing.Color.Black, 1)
                '//DRAWS THE PICTURE IN THE CANVASS////////////////////////////
                filenamepic = selinforeader.Item("App_Picture").ToString
                Try
                    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                    e.Graphics.DrawImage(newDp, 15, 15, 90, 90)

                Catch ex As Exception

                End Try






                e.Graphics.DrawString(GetAppID, Font10, Brushes.Black, 45, 107) 'religion
                '//////////////////////////////////////////////////////////////

                '//HEADER APPLICANT INFORMATION SHEET/////////////////////////////////////
                e.Graphics.FillRectangle(bg, 115, 15, 500, 30)
                e.Graphics.DrawRectangle(myPen, 115, 15, 500, 30)
                e.Graphics.DrawString("APPLICANT INFORMATION SHEET", Font, Brushes.White, 175, 20)
                '  '//////////////////////////////////////////////////////////////////////////

                ''  //WRITES THE CURRENT  DATE////////////////////////////////////////////////
                e.Graphics.DrawString("DATE: " + datenow.ToString("dd-MMM-yy"), Font12, Brushes.Black, 620, 20)
                ' //////////////////////////////////////////////////////////////////////////
                '//NAME VESSEL BOXES///////////////////////////////////////////////////////
                e.Graphics.DrawRectangle(myPen, 115, 50, 340, 80)
                e.Graphics.DrawString("LAST NAME:", Font10, Brushes.Black, 120, 50)
                e.Graphics.DrawString("FIRST NAME:", Font10, Brushes.Black, 120, 73)
                e.Graphics.DrawString("MIDDLE NAME:", Font10, Brushes.Black, 120, 93)
                e.Graphics.DrawString("NICK NAME:", Font10, Brushes.Black, 120, 113)
                e.Graphics.DrawRectangle(myPen, 455, 50, 340, 80)
                e.Graphics.DrawString("POSITION APPLIED:", Font10, Brushes.Black, 465, 50)
                e.Graphics.DrawString("AVAILABILITY:", Font10, Brushes.Black, 465, 65)
                e.Graphics.DrawString("VESSEL:", Font10, Brushes.Black, 465, 83)
                e.Graphics.DrawString("PRINCIPAL:", Font10, Brushes.Black, 465, 100)
                e.Graphics.DrawString("FLAG:", Font10, Brushes.Black, 465, 115)
                e.Graphics.FillRectangle(bg, 15, 140, 440, 30)
                e.Graphics.DrawRectangle(myPen, 15, 140, 440, 30)
                e.Graphics.DrawString("PERSONAL INFORMATION SHEET", Font, Brushes.White, 20, 145)
                e.Graphics.DrawRectangle(myPen, 15, 140, 440, 160)
                e.Graphics.DrawString("DATE OF BIRTH:", Font9, Brushes.Black, 20, 170)
                e.Graphics.DrawString("AGE: ", Font9, Brushes.Black, 350, 170)
                e.Graphics.DrawString("BIRTHPLACE:", Font9, Brushes.Black, 20, 185)
                e.Graphics.DrawString("CIVIL STATUS:", Font9, Brushes.Black, 20, 200)
                e.Graphics.DrawString("SPOUSE:", Font9, Brushes.Black, 20, 215)
                e.Graphics.DrawString("HEIGHT:", Font9, Brushes.Black, 20, 230)
                e.Graphics.DrawString("WEIGHT:", Font9, Brushes.Black, 180, 230)
                e.Graphics.DrawString("BMI:", Font9, Brushes.Black, 350, 230)

                Dim Bmi, WeightD, HeightD As Double
                Double.TryParse(Weight, WeightD)
                Double.TryParse(Height, HeightD)
                Bmi = WeightD / ((HeightD / 100) * (HeightD / 100))
                e.Graphics.DrawString(Heights + " CM", Font9B, Brushes.Black, 80, 230)
                e.Graphics.DrawString(Weight + " KG", Font9B, Brushes.Black, 250, 230)
                e.Graphics.DrawString(Bmi.ToString("#.##"), Font9B, Brushes.Black, 380, 230)
                e.Graphics.DrawString("SCHOOL:", Font9, Brushes.Black, 20, 245)
                e.Graphics.DrawString("COURSE:", Font9, Brushes.Black, 20, 260)
                e.Graphics.DrawString("YR GRADUATED:", Font9, Brushes.Black, 20, 275)
                e.Graphics.DrawString(CStudies, Font9B, Brushes.Black, 80, 245)
                e.Graphics.DrawString(CCourse, Font9B, Brushes.Black, 80, 260)
                e.Graphics.DrawString(CYear, Font9B, Brushes.Black, 120, 275)
                '''''''''''''''''''''''''''''''''''''''''''information'''''''''''''''''''''''''''''''''''''
                e.Graphics.DrawString(Lname, Font9B, Brushes.Black, 200, 50)
                e.Graphics.DrawString(Fname, Font9B, Brushes.Black, 200, 73)
                e.Graphics.DrawString(Mname, Font9B, Brushes.Black, 220, 93)
                e.Graphics.DrawString(Fname, Font9B, Brushes.Black, 200, 113)
                e.Graphics.DrawString(rankapplied, Font9B, Brushes.Black, 590, 50)
                e.Graphics.DrawString("Available", Font9B, Brushes.Black, 560, 65)
                e.Graphics.DrawString(Vessel, Font9B, Brushes.Black, 520, 83)
                e.Graphics.DrawString(Principal, Font9B, Brushes.Black, 535, 100)
                Dim sbstr1 As String
                sbstr1 = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc limit  20; "
                Dim sbcmd1 As OdbcCommand
                sbcmd1 = New OdbcCommand(sbstr1, conn)
                Dim sbreader1 As OdbcDataReader = sbcmd1.ExecuteReader()
                'pinatangal ni melba
                'If sbreader1.Read Then
                '    e.Graphics.DrawString(sbreader1.Item("App_ImportFlag").ToString(), Font9B, Brushes.Black, 510, 115)
                'End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                e.Graphics.DrawString("DATE OF BIRTH:", Font9, Brushes.Black, 20, 170)
                e.Graphics.DrawString("AGE: ", Font9, Brushes.Black, 350, 170)
                e.Graphics.DrawString("BIRTHPLACE:", Font9, Brushes.Black, 20, 185)
                e.Graphics.DrawString("CIVIL STATUS:", Font9, Brushes.Black, 20, 200)
                e.Graphics.DrawString("SPOUSE:", Font9, Brushes.Black, 20, 215)
                e.Graphics.DrawString(Bday, Font9B, Brushes.Black, 120, 170)
                e.Graphics.DrawString(appage, Font9B, Brushes.Black, 380, 170)
                e.Graphics.DrawString(Bplace, Font9B, Brushes.Black, 120, 185)
                e.Graphics.DrawString(CivilStat, Font9B, Brushes.Black, 120, 200)
                e.Graphics.DrawString("N/A", Font9B, Brushes.Black, 120, 215)
                e.Graphics.FillRectangle(bg, 455, 140, 340, 30)
                e.Graphics.DrawRectangle(myPen, 455, 140, 340, 30)
                e.Graphics.DrawString("CONTACT INFORMATION", Font, Brushes.White, 460, 145)
                e.Graphics.DrawRectangle(myPen, 455, 140, 340, 160)
                e.Graphics.DrawString("CITY ADDRESS:", Font9, Brushes.Black, 460, 170)
                e.Graphics.DrawString("PROVINCIAL ADDRESS:", Font9, Brushes.Black, 460, 215)
                e.Graphics.DrawString("CONTACT NO.:", Font9, Brushes.Black, 460, 260)
                e.Graphics.DrawString("E-MAIL ADD:", Font9, Brushes.Black, 460, 275)


                Dim rectF2 As New RectangleF(460, 185, 330, 40)
                e.Graphics.DrawString(Address, Font9B, Brushes.Black, rectF2)
                e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF2))

                ' e.Graphics.DrawString(Address, Font9B, Brushes.Black, 460, 185)

                Dim rectF3 As New RectangleF(460, 230, 330, 40)
                e.Graphics.DrawString(Address2, Font9B, Brushes.Black, rectF3)
                e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF3))

                ' e.Graphics.DrawString(Address2, Font9B, Brushes.Black, 460, 230)
                e.Graphics.DrawString(ContactNo, Font9B, Brushes.Black, 550, 260)
                e.Graphics.DrawString(EmailAdd, Font9B, Brushes.Black, 550, 275)
                e.Graphics.FillRectangle(bg, 15, 310, 300, 30)
                e.Graphics.DrawRectangle(myPen, 15, 310, 300, 30)
                e.Graphics.DrawString("DOCUMENTS", Font10B, Brushes.White, 20, 315)
                e.Graphics.FillRectangle(bg, 315, 310, 170, 30)
                e.Graphics.DrawRectangle(myPen, 315, 310, 170, 30)
                e.Graphics.DrawString("DOC. NO.", Font10B, Brushes.White, 320, 315)
                e.Graphics.FillRectangle(bg, 485, 310, 100, 30)
                e.Graphics.DrawRectangle(myPen, 485, 310, 100, 30)
                e.Graphics.DrawString("ISSUE DATE", Font10B, Brushes.White, 490, 315)
                e.Graphics.FillRectangle(bg, 585, 310, 100, 30)
                e.Graphics.DrawRectangle(myPen, 585, 310, 100, 30)
                e.Graphics.DrawString("VALIDITY", Font10B, Brushes.White, 590, 315)
                e.Graphics.FillRectangle(bg, 685, 310, 113, 30)
                e.Graphics.DrawRectangle(myPen, 685, 310, 113, 30)
                e.Graphics.DrawString("DOC. INFO", Font10B, Brushes.White, 690, 315)

                doccertstr = "Select Document_ID, AppCert_Name, AppCert_No, AppCert_Place, AppCert_DateIssued, AppCert_DateExpired, App_CertID FROM
                           hunters_pooling.applicant_cert where AppCert_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' 
                           UNION 
                           Select Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, AppDoc_DateIssued, AppDoc_DateExpired, App_DocID
                           FROM hunters_pooling.applicant_doc where AppDoc_Status = 'ACTIVE' and App_ID = '" & GetAppID & "' ; "

                doccertcommand = New OdbcCommand(doccertstr, conn)

                doccertreader = doccertcommand.ExecuteReader()

                Dim counter As Integer
                While doccertreader.Read
                    'If (yrec >= 1350) Then       'Print new page
                    '    'e.HasMorePages = True
                    '    'yrec = 0
                    '    'pageNumberToPrint = 2

                    '    lastindex = yrec
                    '    'The PrintPage event handler will be raised again
                    'End If
                    Dim rectF1 As New RectangleF(318, yrec + 2, 175, 20)
                        myPen.DashStyle = Drawing.Drawing2D.DashStyle.DashDotDot
                    e.Graphics.DrawRectangle(myPen, 15, yrec, 300, 20)
                    e.Graphics.DrawRectangle(myPen, 315, yrec, 170, 20)
                    e.Graphics.DrawRectangle(myPen, 485, yrec, 100, 20)
                    e.Graphics.DrawRectangle(myPen, 585, yrec, 100, 20)
                    e.Graphics.DrawRectangle(myPen, 685, yrec, 113, 20)

                    e.Graphics.DrawString(doccertreader.Item(1).ToString(), Font7, Brushes.Black, 18, yrec)
                    e.Graphics.DrawString(doccertreader.Item(2).ToString(), Font6, Brushes.Black, rectF1)
                    e.Graphics.DrawString(doccertreader.GetDate(4).ToString("MM-dd-yyyy"), Font7, Brushes.Black, 488, yrec)

                    Try
                        e.Graphics.DrawString(doccertreader.GetDate(5).ToString("MM-dd-yyyy"), Font7, Brushes.Black, 588, yrec)
                    Catch ex As Exception
                        e.Graphics.DrawString(" ", Font, Brushes.Black, 690, yrec)
                    End Try
                    If counter Mod 2 = 0 Then

                        'e.Graphics.FillRectangle(bg1, 15, yrec, 300, 20)
                        'e.Graphics.FillRectangle(bg1, 315, yrec, 170, 20)
                        'e.Graphics.FillRectangle(bg1, 485, yrec, 100, 20)
                        'e.Graphics.FillRectangle(bg1, 585, yrec, 100, 20)
                        'e.Graphics.FillRectangle(bg1, 685, yrec, 113, 20)
                    End If

                    yrec = yrec + 20
                    counter = counter + 1


                End While

                ' this is ThreadExceptionDialog sea exp

                'e.Graphics.DrawString(e.MarginBounds.Bottom.ToString, Font10B, Brushes.White, 20, 90)

                'e.Graphics.DrawString("SEA EXPERIENCE", Font12, Brushes.Black, 18, yrec + 15)
                'yrec = yrec + 40


                'e.Graphics.FillRectangle(bg, 15, yrec, 100, 20)
                'e.Graphics.DrawRectangle(myPen1, 15, yrec, 100, 20)
                'e.Graphics.DrawString("VESSEL", Font10B, Brushes.White, 20, yrec)

                'e.Graphics.FillRectangle(bg, 115, yrec, 65, 20)
                'e.Graphics.DrawRectangle(myPen1, 115, yrec, 65, 20)
                'e.Graphics.DrawString("Principal", Font10, Brushes.White, 120, yrec)

                'e.Graphics.FillRectangle(bg, 180, yrec, 55, 20)
                'e.Graphics.DrawRectangle(myPen1, 180, yrec, 55, 20)
                'e.Graphics.DrawString("Flag", Font10, Brushes.White, 185, yrec)

                'e.Graphics.FillRectangle(bg, 235, yrec, 60, 20)
                'e.Graphics.DrawRectangle(myPen1, 235, yrec, 60, 20)
                'e.Graphics.DrawString("Rank", Font10, Brushes.White, 240, yrec)

                'e.Graphics.FillRectangle(bg, 295, yrec, 60, 20)
                'e.Graphics.DrawRectangle(myPen1, 295, yrec, 60, 20)
                'e.Graphics.DrawString("Vessel", Font10, Brushes.White, 300, yrec)

                'e.Graphics.FillRectangle(bg, 355, yrec, 50, 20)
                'e.Graphics.DrawRectangle(myPen1, 355, yrec, 50, 20)
                'e.Graphics.DrawString("Grt", Font10, Brushes.White, 360, yrec)

                'e.Graphics.FillRectangle(bg, 405, yrec, 70, 20)
                'e.Graphics.DrawRectangle(myPen1, 405, yrec, 70, 20)
                'e.Graphics.DrawString("Engine", Font10, Brushes.White, 410, yrec)

                'e.Graphics.FillRectangle(bg, 475, yrec, 50, 20)
                'e.Graphics.DrawRectangle(myPen1, 475, yrec, 50, 20)
                'e.Graphics.DrawString("KW", Font10, Brushes.White, 490, yrec)

                'e.Graphics.FillRectangle(bg, 525, yrec, 60, 20)
                'e.Graphics.DrawRectangle(myPen1, 525, yrec, 60, 20)
                'e.Graphics.DrawString("From", Font10, Brushes.White, 540, yrec)

                'e.Graphics.FillRectangle(bg, 585, yrec, 60, 20)
                'e.Graphics.DrawRectangle(myPen1, 585, yrec, 60, 20)
                'e.Graphics.DrawString("To", Font10, Brushes.White, 590, yrec)

                'e.Graphics.FillRectangle(bg, 635, yrec, 60, 20)
                'e.Graphics.DrawRectangle(myPen1, 635, yrec, 60, 20)
                'e.Graphics.DrawString("Trade", Font10, Brushes.White, 640, yrec)

                'e.Graphics.FillRectangle(bg, 695, yrec, 60, 20)
                'e.Graphics.DrawRectangle(myPen1, 695, yrec, 60, 20)
                'e.Graphics.DrawString("Reason", Font10, Brushes.White, 700, yrec)

                'e.Graphics.FillRectangle(bg, 755, yrec, 45, 20)
                'e.Graphics.DrawRectangle(myPen1, 755, yrec, 45, 20)
                'e.Graphics.DrawString("Mos", Font10, Brushes.White, 760, yrec)


                'Dim sbstr As String
                'sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc limit 20; "

                '' sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc; "
                'Dim sbcmd As OdbcCommand
                'sbcmd = New OdbcCommand(sbstr, conn)
                'Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()
                'yrec = yrec + 20

                'While sbreader.Read
                '    '    If (yrec >= 1350) Then       'Print new page



                '    '    pageNo = pageNo + 1
                '    '    yrec = 0
                '    '    e.HasMorePages = pageNo <= 2


                '    '    'The PrintPage event handler will be raised again
                '    'End If
                '    e.Graphics.DrawString(sbreader.Item("App_VesselName").ToString(), Font6, Brushes.Black, 20, yrec + 5)


                '    Dim rectF4 As New RectangleF(120, yrec + 2, 65, 20)
                '    e.Graphics.DrawString(sbreader.Item("App_PrincipalName").ToString(), Font4, Brushes.Black, rectF4)
                '    e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF4))

                '    'e.Graphics.DrawString(sbreader.Item("App_PrincipalName").ToString(), Font6, Brushes.Black, 120, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_ImportFlag").ToString(), Font6, Brushes.Black, 185, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_Rank").ToString(), Font5, Brushes.Black, 240, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_VesselType").ToString(), Font5, Brushes.Black, 300, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_GRT").ToString(), Font6, Brushes.Black, 360, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_EngineType").ToString(), Font6, Brushes.Black, 410, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_KW").ToString(), Font6, Brushes.Black, 490, yrec + 5)
                '    e.Graphics.DrawString(sbreader.GetDate(12).ToString("MMM-dd-yyyy"), Font6, Brushes.Black, 525, yrec + 5)
                '    e.Graphics.DrawString(sbreader.GetDate(13).ToString("MMM-dd-yyyy"), Font6, Brushes.Black, 585, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_TradingRoute").ToString(), Font6, Brushes.Black, 640, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_Reason").ToString(), Font6, Brushes.Black, 695, yrec + 5)
                '    e.Graphics.DrawString(sbreader.Item("App_Duration").ToString(), Font6, Brushes.Black, 760, yrec + 5)
                '    e.Graphics.DrawRectangle(myPen, 15, yrec, 100, 20)
                '    e.Graphics.DrawRectangle(myPen, 115, yrec, 65, 20)
                '    e.Graphics.DrawRectangle(myPen, 180, yrec, 55, 20)
                '    e.Graphics.DrawRectangle(myPen, 235, yrec, 60, 20)
                '    e.Graphics.DrawRectangle(myPen, 295, yrec, 60, 20)
                '    e.Graphics.DrawRectangle(myPen, 355, yrec, 50, 20)
                '    e.Graphics.DrawRectangle(myPen, 405, yrec, 70, 20)
                '    e.Graphics.DrawRectangle(myPen, 475, yrec, 50, 20)
                '    e.Graphics.DrawRectangle(myPen, 525, yrec, 60, 20)
                '    e.Graphics.DrawRectangle(myPen, 585, yrec, 50, 20)
                '    e.Graphics.DrawRectangle(myPen, 635, yrec, 60, 20)
                '    e.Graphics.DrawRectangle(myPen, 695, yrec, 60, 20)
                '    e.Graphics.DrawRectangle(myPen, 755, yrec, 45, 20)

                '    yrec = yrec + 20
                '    'If (yrec >= 1350) Then       'Print new page
                '    '    'e.HasMorePages = True
                '    '    yrec = 0
                '    '    'pageNumberToPrint = 2
                '    '    ' GoTo LastLine
                '    '    lastindex = yrec
                '    'End If
                '    'The 
                '    '    Me.pageNumber = 1
                '    'If (yrec >= 1350) Then       'Print new page
                '    '    e.HasMorePages = (pageNumber >= 2)

                '    '    Me.pageNumber = +1


                '    '    'The PrintPage event handler will be raised again
                '    'End If
                '    'If Me.pageNumber = MAX_PAGE_COUNT Then
                '    '    'We have printed all the pages.
                '    '    e.HasMorePages = False

                '    '    'Reset the page number because if this is a preview and the user presses
                '    '    'the Print button the printing routine will be executed a second time.
                '    '    Me.pageNumber = 1
                '    'Else
                '    '    'There are more pages to print.
                '    '    If yrec >= 1350 Then
                '    '        yrec = 40
                '    '    End If

                '    '    e.HasMorePages = True

                '    '    'Increment the page number.
                '    '    Me.pageNumber += 1
                '    'End If

                'End While

                'Dim qstring As String

                'qstring = "SELECT c.org_name, cp.position_rank, rep_signature FROM crystal_organization c 
                '        LEFT JOIN crystal_position cp ON c.position_id=cp.position_id 
                '        LEFT JOIN crystal_contract cc ON cc.position_id=c.position_id 
                '        LEFT JOIN crystal_representatives cr ON cr.user_id=cc.user_id 
                '        WHERE c.position_id=22;"
                'Dim qcmd As OdbcCommand
                'qcmd = New OdbcCommand(qstring, conn)
                'Dim qreader As OdbcDataReader = qcmd.ExecuteReader()
                'Dim orgname, repspos As String

                'If qreader.Read Then
                '    orgname = qreader.Item("org_name").ToString
                '    repspos = qreader.Item("position_rank").ToString
                'End If
                'e.Graphics.DrawString("Nominated By:", Font9, Brushes.Black, 70, yrec + 25)
                'e.Graphics.DrawString("_____________________________________", Font9, Brushes.Black, 18, yrec + 55)
                'e.Graphics.DrawString("Melba B. Lorenzo", Font9, Brushes.Black, 55, yrec + 70)

                'Try
                '    filenamepic = "\\192.168.11.3\Dropbox\ALL CREW DOCUMENTS\SIGNATURES\Azarcon_Allyson_01.png"

                '    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                '    e.Graphics.DrawImage(newDp, 340, yrec + 25, 185, 50)

                'Catch ex As Exception
                '    filenamepic = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resources\Azarcon_Allyson_01.png"

                '    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                '    e.Graphics.DrawImage(newDp, 340, yrec + 25, 185, 50)

                'End Try
                'e.Graphics.DrawString(orgname, Font9, Brushes.Black, 350, yrec + 70)
                'e.Graphics.DrawString(repspos, Font9, Brushes.Black, 360, yrec + 85)


                'e.Graphics.DrawString("Certified Correct By:", Font9, Brushes.Black, 618, yrec + 25)
                'e.Graphics.DrawString("_____________________________________", Font9, Brushes.Black, 583, yrec + 55)
                'e.Graphics.DrawString(Fullname, Font9, Brushes.Black, 610, yrec + 70)
                'e.Graphics.DrawString("Seafarer", Font9, Brushes.Black, 660, yrec + 85)

                e.HasMorePages = True

                yrec = 0
            Case 2
                yrec = 40
                Dim myPen As Pen = New Pen(Drawing.Color.Black, 1)

                Dim myPen1 As Pen = New Pen(Drawing.Color.Black, 1)

                e.Graphics.DrawString(e.MarginBounds.Bottom.ToString, Font10B, Brushes.White, 20, 90)

                e.Graphics.DrawString("SEA EXPERIENCE", Font12, Brushes.Black, 18, yrec + 15)
                yrec = yrec + 40


                e.Graphics.FillRectangle(bg, 15, yrec, 100, 20)
                e.Graphics.DrawRectangle(myPen1, 15, yrec, 100, 20)
                e.Graphics.DrawString("VESSEL", Font10B, Brushes.White, 20, yrec)

                e.Graphics.FillRectangle(bg, 115, yrec, 65, 20)
                e.Graphics.DrawRectangle(myPen1, 115, yrec, 65, 20)
                e.Graphics.DrawString("Principal", Font10, Brushes.White, 120, yrec)

                e.Graphics.FillRectangle(bg, 180, yrec, 55, 20)
                e.Graphics.DrawRectangle(myPen1, 180, yrec, 55, 20)
                e.Graphics.DrawString("Flag", Font10, Brushes.White, 185, yrec)

                e.Graphics.FillRectangle(bg, 235, yrec, 60, 20)
                e.Graphics.DrawRectangle(myPen1, 235, yrec, 60, 20)
                e.Graphics.DrawString("Rank", Font10, Brushes.White, 240, yrec)

                e.Graphics.FillRectangle(bg, 295, yrec, 60, 20)
                e.Graphics.DrawRectangle(myPen1, 295, yrec, 60, 20)
                e.Graphics.DrawString("Vessel", Font10, Brushes.White, 300, yrec)

                e.Graphics.FillRectangle(bg, 355, yrec, 50, 20)
                e.Graphics.DrawRectangle(myPen1, 355, yrec, 50, 20)
                e.Graphics.DrawString("Grt", Font10, Brushes.White, 360, yrec)

                e.Graphics.FillRectangle(bg, 405, yrec, 70, 20)
                e.Graphics.DrawRectangle(myPen1, 405, yrec, 70, 20)
                e.Graphics.DrawString("Engine", Font10, Brushes.White, 410, yrec)

                e.Graphics.FillRectangle(bg, 475, yrec, 50, 20)
                e.Graphics.DrawRectangle(myPen1, 475, yrec, 50, 20)
                e.Graphics.DrawString("KW", Font10, Brushes.White, 490, yrec)

                e.Graphics.FillRectangle(bg, 525, yrec, 60, 20)
                e.Graphics.DrawRectangle(myPen1, 525, yrec, 60, 20)
                e.Graphics.DrawString("From", Font10, Brushes.White, 540, yrec)

                e.Graphics.FillRectangle(bg, 585, yrec, 60, 20)
                e.Graphics.DrawRectangle(myPen1, 585, yrec, 60, 20)
                e.Graphics.DrawString("To", Font10, Brushes.White, 590, yrec)

                e.Graphics.FillRectangle(bg, 635, yrec, 60, 20)
                e.Graphics.DrawRectangle(myPen1, 635, yrec, 60, 20)
                e.Graphics.DrawString("Trade", Font10, Brushes.White, 640, yrec)

                e.Graphics.FillRectangle(bg, 695, yrec, 60, 20)
                e.Graphics.DrawRectangle(myPen1, 695, yrec, 60, 20)
                e.Graphics.DrawString("Reason", Font10, Brushes.White, 700, yrec)

                e.Graphics.FillRectangle(bg, 755, yrec, 45, 20)
                e.Graphics.DrawRectangle(myPen1, 755, yrec, 45, 20)
                e.Graphics.DrawString("Mos", Font10, Brushes.White, 760, yrec)


                Dim sbstr As String
                sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc limit 20; "

                ' sbstr = "SELECT * FROM hunters_pooling.applicant_seaservice  where App_ID = '" & GetAppID & "' ORDER BY App_DateSignedOFF desc; "
                Dim sbcmd As OdbcCommand
                sbcmd = New OdbcCommand(sbstr, conn)
                Dim sbreader As OdbcDataReader = sbcmd.ExecuteReader()
                yrec = yrec + 20

                While sbreader.Read
                    '    If (yrec >= 1350) Then       'Print new page



                    '    pageNo = pageNo + 1
                    '    yrec = 0
                    '    e.HasMorePages = pageNo <= 2


                    '    'The PrintPage event handler will be raised again
                    'End If
                    e.Graphics.DrawString(sbreader.Item("App_VesselName").ToString(), Font6, Brushes.Black, 20, yrec + 5)


                    Dim rectF4 As New RectangleF(120, yrec + 2, 65, 20)
                    e.Graphics.DrawString(sbreader.Item("App_PrincipalName").ToString(), Font4, Brushes.Black, rectF4)
                    e.Graphics.DrawRectangle(Pens.Transparent, Rectangle.Round(rectF4))

                    'e.Graphics.DrawString(sbreader.Item("App_PrincipalName").ToString(), Font6, Brushes.Black, 120, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_ImportFlag").ToString(), Font6, Brushes.Black, 185, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_Rank").ToString(), Font5, Brushes.Black, 240, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_VesselType").ToString(), Font5, Brushes.Black, 300, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_GRT").ToString(), Font6, Brushes.Black, 360, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_EngineType").ToString(), Font6, Brushes.Black, 410, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_KW").ToString(), Font6, Brushes.Black, 490, yrec + 5)
                    e.Graphics.DrawString(sbreader.GetDate(12).ToString("MMM-dd-yyyy"), Font6, Brushes.Black, 525, yrec + 5)
                    e.Graphics.DrawString(sbreader.GetDate(13).ToString("MMM-dd-yyyy"), Font6, Brushes.Black, 585, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_TradingRoute").ToString(), Font6, Brushes.Black, 640, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_Reason").ToString(), Font6, Brushes.Black, 695, yrec + 5)
                    e.Graphics.DrawString(sbreader.Item("App_Duration").ToString(), Font6, Brushes.Black, 760, yrec + 5)
                    e.Graphics.DrawRectangle(myPen, 15, yrec, 100, 20)
                    e.Graphics.DrawRectangle(myPen, 115, yrec, 65, 20)
                    e.Graphics.DrawRectangle(myPen, 180, yrec, 55, 20)
                    e.Graphics.DrawRectangle(myPen, 235, yrec, 60, 20)
                    e.Graphics.DrawRectangle(myPen, 295, yrec, 60, 20)
                    e.Graphics.DrawRectangle(myPen, 355, yrec, 50, 20)
                    e.Graphics.DrawRectangle(myPen, 405, yrec, 70, 20)
                    e.Graphics.DrawRectangle(myPen, 475, yrec, 50, 20)
                    e.Graphics.DrawRectangle(myPen, 525, yrec, 60, 20)
                    e.Graphics.DrawRectangle(myPen, 585, yrec, 50, 20)
                    e.Graphics.DrawRectangle(myPen, 635, yrec, 60, 20)
                    e.Graphics.DrawRectangle(myPen, 695, yrec, 60, 20)
                    e.Graphics.DrawRectangle(myPen, 755, yrec, 45, 20)

                    yrec = yrec + 20
                    'If (yrec >= 1350) Then       'Print new page
                    '    'e.HasMorePages = True
                    '    yrec = 0
                    '    'pageNumberToPrint = 2
                    '    ' GoTo LastLine
                    '    lastindex = yrec
                    'End If
                    'The 
                    '    Me.pageNumber = 1
                    'If (yrec >= 1350) Then       'Print new page
                    '    e.HasMorePages = (pageNumber >= 2)

                    '    Me.pageNumber = +1


                    '    'The PrintPage event handler will be raised again
                    'End If
                    'If Me.pageNumber = MAX_PAGE_COUNT Then
                    '    'We have printed all the pages.
                    '    e.HasMorePages = False

                    '    'Reset the page number because if this is a preview and the user presses
                    '    'the Print button the printing routine will be executed a second time.
                    '    Me.pageNumber = 1
                    'Else
                    '    'There are more pages to print.
                    '    If yrec >= 1350 Then
                    '        yrec = 40
                    '    End If

                    '    e.HasMorePages = True

                    '    'Increment the page number.
                    '    Me.pageNumber += 1
                    'End If

                End While

                Dim qstring As String

                qstring = "SELECT c.org_name, cp.position_rank, rep_signature FROM crystal_organization c 
                        LEFT JOIN crystal_position cp ON c.position_id=cp.position_id 
                        LEFT JOIN crystal_contract cc ON cc.position_id=c.position_id 
                        LEFT JOIN crystal_representatives cr ON cr.user_id=cc.user_id 
                        WHERE c.position_id=22;"
                Dim qcmd As OdbcCommand
                qcmd = New OdbcCommand(qstring, conn)
                Dim qreader As OdbcDataReader = qcmd.ExecuteReader()
                Dim orgname, repspos As String

                If qreader.Read Then
                    orgname = qreader.Item("org_name").ToString
                    repspos = qreader.Item("position_rank").ToString
                End If
                e.Graphics.DrawString("Nominated By:", Font9, Brushes.Black, 70, yrec + 25)
                e.Graphics.DrawString("_____________________________________", Font9, Brushes.Black, 18, yrec + 55)
                e.Graphics.DrawString("Melba B. Lorenzo", Font9, Brushes.Black, 55, yrec + 70)

                Try
                    filenamepic = "\\192.168.11.3\Dropbox\ALL CREW DOCUMENTS\SIGNATURES\Azarcon_Allyson_01.png"

                    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                    e.Graphics.DrawImage(newDp, 340, yrec + 25, 185, 50)

                Catch ex As Exception
                    filenamepic = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resources\Azarcon_Allyson_01.png"

                    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                    e.Graphics.DrawImage(newDp, 340, yrec + 25, 185, 50)

                End Try
                e.Graphics.DrawString(orgname, Font9, Brushes.Black, 350, yrec + 70)
                e.Graphics.DrawString(repspos, Font9, Brushes.Black, 360, yrec + 85)


                e.Graphics.DrawString("Certified Correct By:", Font9, Brushes.Black, 618, yrec + 25)
                e.Graphics.DrawString("_____________________________________", Font9, Brushes.Black, 583, yrec + 55)
                e.Graphics.DrawString(Fullname, Font9, Brushes.Black, 610, yrec + 70)
                e.Graphics.DrawString("Seafarer", Font9, Brushes.Black, 660, yrec + 85)

                e.HasMorePages = True

        End Select

        PageNum += 1

        'pageNo = pageNo + 1
        'e.HasMorePages = pageNo <= 2
    End Sub




    Public Sub Difference(ByVal FD As DateTime, ByVal SD As DateTime)
        Day = 0
        Month = 0
        Year = 0

        If FD <> SD Then
            If SD.Year > FD.Year Then
                Year = SD.AddYears(-FD.Year).Year
            End If
            Month = SD.AddMonths(-FD.Month).Month
            If SD.Month <= FD.Month Then
                If Year > 0 Then Year -= 1
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
                Year += 1
            End If
            If FD.Year = SD.Year AndAlso FD.Month = SD.Month Then
                Year = 0

            End If

        Else
            MsgBox("Second Date Cannot Be Smaller")
        End If

    End Sub


    Private Sub CoiPrint_QueryPageSettings(sender As Object, e As QueryPageSettingsEventArgs) Handles CoiPrint.QueryPageSettings
        For Each SupportedPaperSize As System.Drawing.Printing.PaperSize In AmsPrintDialog.PrinterSettings.PaperSizes
            If SupportedPaperSize.Kind = System.Drawing.Printing.PaperKind.Legal Then
                e.PageSettings.PaperSize = SupportedPaperSize
                Exit For
            End If
        Next
    End Sub

    Private Sub OC31Print_QueryPageSettings(sender As Object, e As QueryPageSettingsEventArgs) Handles OC31Print.QueryPageSettings
        For Each SupportedPaperSize As System.Drawing.Printing.PaperSize In OC31Print.PrinterSettings.PaperSizes
            If SupportedPaperSize.Kind = System.Drawing.Printing.PaperKind.A4 Then
                e.PageSettings.PaperSize = SupportedPaperSize
                Exit For
            End If
        Next
    End Sub

    Private Sub NovoPrint_QueryPageSettings(sender As Object, e As QueryPageSettingsEventArgs) Handles NovoPrint.QueryPageSettings
        For Each SupportedPaperSize As System.Drawing.Printing.PaperSize In NovoPrint.PrinterSettings.PaperSizes
            If SupportedPaperSize.Kind = System.Drawing.Printing.PaperKind.Legal Then
                e.PageSettings.PaperSize = SupportedPaperSize
                Exit For
            End If
        Next
    End Sub

    Private Sub EsmPrint_QueryPageSettings(sender As Object, e As QueryPageSettingsEventArgs) Handles EsmPrint.QueryPageSettings
        For Each SupportedPaperSize As System.Drawing.Printing.PaperSize In EsmPrint.PrinterSettings.PaperSizes
            If SupportedPaperSize.Kind = System.Drawing.Printing.PaperKind.Legal Then
                e.PageSettings.PaperSize = SupportedPaperSize
                Exit For
            End If
        Next
    End Sub

    Private Sub Esm09_Click(sender As Object, e As EventArgs) Handles Esm02.Click

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim sql As String
        Dim i, j As Integer
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add("\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\oc9_Template.xltx")
        xlWorkSheet = xlWorkBook.Sheets("Record of Sea Service")
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        'xlWorkSheet = xlWorkBook.Sheets("sheet1")

        sql = "SELECT App_Agency, App_VesselName, App_Rank, App_VesselType, App_DP123,App_DpModel, App_Grt,App_EngineType, App_Model,
App_BHP,App_Propulsion, App_Supply,App_Anchor, App_Towing, App_DiveSupport, App_ROV, App_Flotel, App_InstalType,App_TradingRoute,
App_Charterer, App_DateSignedON,App_DateSignedOFF, App_Duration, App_Reason FROM hunters_pooling.applicant_seaservice where App_ID = '" & GetAppID & "';"
        Dim dscmd As New Odbc.OdbcDataAdapter(sql, conn)
        Dim ds As New DataSet
        dscmd.Fill(ds)
        For i = 0 To ds.Tables(0).Rows.Count - 1
            For j = 0 To ds.Tables(0).Columns.Count - 1
                xlWorkSheet.Cells(i + 6, j + 2) =
                ds.Tables(0).Rows(i).Item(j)
            Next
        Next
        Try
            xlWorkSheet.SaveAs("\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\vexcel.xlsx")
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            conn.Close()

            'MsgBox("You can find the file \\Hunter_pc02\recruitment\vexcel.xlsx")
            Me.Hide()


            'auto open
            Dim xls As Excel.Application
            Dim wb As Excel.Workbook
            xls = New Excel.Application
            wb = xls.Workbooks.Open(Filename:="\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\vexcel.xlsx", ReadOnly:=False)
            xls.Visible = True


        Catch ex As Exception
            MsgBox("Please Close the Previous Excel File")
        End Try

    End Sub


    '/////////////////////////////ESM 09///////////////////////////////////
    Private Sub esm09Print_PrintPage(sender As Object, e As PrintPageEventArgs) Handles esm09Print.PrintPage
        Dim Font As New Font("Arial", 10, FontStyle.Regular)

        Dim FontTitle As New Font("Arial", 13, FontStyle.Bold)

        Dim FontMID As New Font("Arial", 12, FontStyle.Regular)

        '    Dim Font As New Font(" Nirmala UI", 14, FontStyle.Bold)
        Dim Font10B As New Font("Nirmala UI", 10, FontStyle.Bold)

        Dim Font12B As New Font("Nirmala UI", 12, FontStyle.Bold)
        Dim Font12 As New Font("Nirmala UI", 12, FontStyle.Regular)
        Dim Font10 As New Font("Nirmala UI", 10, FontStyle.Regular)
        Dim Font9 As New Font("Nirmala UI", 9, FontStyle.Regular)
        Dim Font8 As New Font("Nirmala UI", 8, FontStyle.Regular)
        Dim Font9B As New Font("Nirmala UI", 9, FontStyle.Bold)
        Dim Font7 As New Font("Nirmala UI", 7, FontStyle.Regular)
        Dim Font6 As New Font("Nirmala UI", 6, FontStyle.Regular)

        Select Case PageNum

            Case 1
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If

                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\OC9-Prejoining_Part1.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                'e.Graphics.DrawImage(newImage, e.PageBounds)
                ' MsgBox(e.PageBounds.ToString)
                e.Graphics.DrawImage(newImage, 0, 0, 827, 1169)
                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                Dim selinfo As String
                selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year ,ae.School_From, ae.School_To, ae.School_Name, ae.Voc_Course,ae.Voc_To, ae.Voc_School, sc.App_RankApplied, sc.App_DateApplied,ai.App_Picture
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
 LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID=sc.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

                Dim selinfocmd As OdbcCommand
                selinfocmd = New OdbcCommand(selinfo, conn)
                Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

                Dim Fullname As String

                If selinforeader.Read Then



                    Lname = selinforeader.Item("App_LName").ToString

                    Fname = selinforeader.Item("App_FName").ToString
                    Mname = selinforeader.Item("App_MName").ToString

                    Fullname = Lname + ",  " + Fname + "  " + Mname

                    Suffix = selinforeader.Item("App_Suffix").ToString
                    NNname = selinforeader.Item("App_Nickname").ToString
                    Address = selinforeader.Item("Address").ToString
                    Address2 = selinforeader.Item("App_address2").ToString
                    citizenship = selinforeader.Item("App_Citezenship").ToString
                    Bday = selinforeader.Item("App_Bday").Date.ToString()
                    Bplace = selinforeader.Item("App_BPlace").ToString
                    CivilStat = selinforeader.Item("App_CivilStat").ToString
                    DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
                    ContactNo = selinforeader.Item("App_ContactNo").ToString
                    ContactNo2 = selinforeader.Item("App_ContactNo2").ToString
                    Sex = selinforeader.Item("App_Sex").ToString
                    Religion = selinforeader.Item("App_Religion").ToString
                    EmailAdd = selinforeader.Item("App_EmailAdd").ToString
                    Pagibig = selinforeader.Item("App_PagibigNo").ToString
                    Tin = selinforeader.Item("App_TinNo").ToString
                    SSS = selinforeader.Item("App_SSSNo").ToString
                    Philhealth = selinforeader.Item("App_PhilHealthNo").ToString
                    Heights = selinforeader.Item("App_Height").ToString
                    Weight = selinforeader.Item("App_Weight").ToString
                    Shirtsize = selinforeader.Item("App_ShirtSize").ToString
                    Suitsize = selinforeader.Item("App_SuitSize").ToString
                    WaisteSize = selinforeader.Item("App_WaisteSize").ToString
                    ShoeSize = selinforeader.Item("App_ShoeSize").ToString
                    CCourse = selinforeader.Item("Studies_Course").ToString
                    CStudies = selinforeader.Item("Studies_Name").ToString
                    CYear = selinforeader.Item("Studies_Year").ToString
                    HSchool = selinforeader.Item("School_Name").ToString
                    HSchoolFr = selinforeader.Item("School_From").ToString
                    HSchooolTo = selinforeader.Item("School_To").ToString
                    VSchool = selinforeader.Item("Voc_School").ToString
                    VSchoolCourse = selinforeader.Item("Voc_Course").ToString
                    VSchooolTo = selinforeader.Item("Voc_To").ToString
                    rankapplied = selinforeader.Item("App_RankApplied").ToString
                    dateapplied = selinforeader.Item("App_DateApplied").ToString
                    filenamepic = selinforeader.Item("App_Picture").ToString

                    CHSchoolFr = Convert.ToDateTime(HSchoolFr)
                    CHSchooolTo = Convert.ToDateTime(HSchooolTo)
                    '     CVSchoolFr = Convert.ToDateTime(VSchoolFr)
                End If

                Dim courseyear As String

                courseyear = CYear + "\ " + CCourse

                filenamepic = selinforeader.Item("App_Picture").ToString
                Try

                    Dim newDp As Image = Image.FromFile(filenamepic) 'read image
                    e.Graphics.DrawImage(newDp, 645, 205, 120, 120)

                Catch ex As Exception

                End Try






                e.Graphics.DrawString(Fname, Font12B, Brushes.Black, 150, 140)

                e.Graphics.DrawString(Mname, Font12B, Brushes.Black, 400, 140)
                e.Graphics.DrawString(Lname, Font12B, Brushes.Black, 650, 140)
                e.Graphics.DrawString(Address, Font9, Brushes.Black, 55, 232)
                e.Graphics.DrawString(citizenship, Font12B, Brushes.Black, 150, 165)
                e.Graphics.DrawString(Bplace, Font12B, Brushes.Black, 450, 165)
                e.Graphics.DrawString(Bday, Font12B, Brushes.Black, 680, 165)
                e.Graphics.DrawString(rankapplied, Font12B, Brushes.Black, 182, 192)
                e.Graphics.DrawString("+63", Font12B, Brushes.Black, 200, 375)
                e.Graphics.DrawString(ContactNo, Font10B, Brushes.Black, 105, 408)
                e.Graphics.DrawString(ContactNo2, Font10B, Brushes.Black, 280, 455)
                e.Graphics.DrawString(EmailAdd, Font10, Brushes.Black, 90, 430)
                e.Graphics.DrawString("+63", Font12B, Brushes.Black, 565, 375)

                'documents
                Dim seldoc As String
                seldoc = "Select  Document_ID, AppDoc_Name, AppDoc_No, AppDoc_Place, AppDoc_Shortcut, date_format(AppDoc_DateIssued , '%d-%b-%Y') AS 'ISSUED DATE', AppDoc_Country, AppDoc_Status, date_format(AppDoc_DateExpired , '%d-%b-%Y') AS 'EXPIRY DATE', App_DocID FROM hunters_pooling.applicant_doc where App_ID=" & GetAppID & ";"

                Dim doccommand As OdbcCommand
                doccommand = New OdbcCommand(seldoc, conn)
                Dim docreader As OdbcDataReader = doccommand.ExecuteReader()



                While docreader.Read
                    docid = docreader.Item("Document_ID").ToString()
                    docname = docreader.Item("AppDoc_Name").ToString()
                    docshortcut = docreader.Item("AppDoc_Shortcut").ToString()
                    docno = docreader.Item("AppDoc_No").ToString()
                    docplace = docreader.Item("AppDoc_Place").ToString()
                    crewdocid = docreader.Item("App_DocID").ToString()
                    docstatus = docreader.Item("AppDoc_Status").ToString()
                    doccountry = docreader.Item("AppDoc_Country").ToString()
                    dateissued = docreader.Item("ISSUED DATE").ToString()
                    dateexpired = docreader.Item("EXPIRY DATE").ToString()


                    If docid.ToString.Equals("1003") Then
                        'data
                        e.Graphics.DrawString(docno, Font10B, Brushes.Black, 60, 480) 'PASSPORTNO
                        e.Graphics.DrawString(dateissued, Font10B, Brushes.Black, 180, 480) 'PASSPORTexpired
                        e.Graphics.DrawString(dateexpired, Font10B, Brushes.Black, 300, 480) 'PASSPORTexpired
                        e.Graphics.DrawString(docplace, Font10B, Brushes.Black, 390, 480) 'PASSPORTexpired
                    End If

                    If docid.ToString.Equals("1004") Then
                        'SIRB no1
                        'e.Graphics.DrawString(docno, Font, Brushes.Black, 320, 400) 'PSBNO
                        'e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 580, 400) 'PSBexpired
                    End If

                    If docid.ToString.Equals("1469") Then
                        'us -visa
                        e.Graphics.DrawString(docno, Font10B, Brushes.Black, 60, 523) 'PASSPORTNO
                        e.Graphics.DrawString(dateissued, Font10B, Brushes.Black, 180, 523) 'PASSPORTexpired
                        e.Graphics.DrawString(dateexpired, Font10B, Brushes.Black, 300, 523) 'PASSPORTexpired
                        e.Graphics.DrawString(docplace, Font10B, Brushes.Black, 390, 523) 'PASSPORTexpired
                    End If

                End While


                'cert
                Dim selcel As String
                selcel = "Select Document_ID, AppCert_Name, AppCert_Shortcut, AppCert_No, AppCert_Place, AppCert_Country,date_format(AppCert_DateIssued , '%d-%b-%Y') AS 'ISSUED DATE',date_format(AppCert_DateExpired , '%d-%b-%Y') AS 'EXPIRY DATE', AppCert_Trainingcenter, AppCert_Status FROM hunters_pooling.applicant_cert where App_ID=" & GetAppID & ";"

                Dim celcmd As OdbcCommand
                celcmd = New OdbcCommand(selcel, conn)
                Dim celreader As OdbcDataReader = celcmd.ExecuteReader()
                While celreader.Read
                    certdocid = celreader.Item("Document_ID").ToString()
                    certname = celreader.Item("AppCert_Name").ToString()
                    certshortcut = celreader.Item("AppCert_Shortcut").ToString()
                    certno = celreader.Item("AppCert_No").ToString()
                    certplace = celreader.Item("AppCert_Place").ToString()
                    certcountry = celreader.Item("AppCert_Country").ToString()
                    certtraining = celreader.Item("AppCert_Trainingcenter").ToString()
                    certstatus = celreader.Item("AppCert_Status").ToString()
                    certissued = celreader.Item("ISSUED DATE").ToString()
                    certexpired = celreader.Item("EXPIRY DATE").ToString()

                    If certdocid.ToString.Equals("1104") Then
                        'GMDSS
                        e.Graphics.DrawString(certshortcut, Font9, Brushes.Black, 65, 710)
                        e.Graphics.DrawString(certno, Font9, Brushes.Black, 180, 710)
                        e.Graphics.DrawString(certissued, Font9, Brushes.Black, 290, 710)
                        e.Graphics.DrawString(certexpired, Font9, Brushes.Black, 390, 710)
                        e.Graphics.DrawString(certplace, Font9, Brushes.Black, 490, 710)
                    End If

                    ''full dp no9
                    ''e.Graphics.DrawString(docno, Font, Brushes.Black, 280, 805) 'FULLDPNO
                    ''e.Graphics.DrawString(docno, Font, Brushes.Black, 425, 805) 'FULLDPrank
                    ''e.Graphics.DrawString(dateissued, Font, Brushes.Black, 523,805) 'FULLDPissued
                    ''e.Graphics.DrawString(dateexpired, Font, Brushes.Black, 650, 805) 'FULLDPexpire

                    If certdocid.ToString.Equals("1386") Then

                        'basicdp no10
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 280, 820) 'BASICDPNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 820) 'BASICDPrank
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 523, 820) 'BASICDPissued
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 650, 820) 'BASICDPexpired
                    End If

                    If certdocid.ToString.Equals("1498") Then
                        'advancedp no11
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 280, 840) 'ADVANCEDPNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 840) 'ADVANCEDPrank
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 523, 840) 'ADVANCEDPissued
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 650, 840) 'ADVANCEDPexpired
                    End If

                    If certdocid.ToString.Equals("1254") Then
                        'dpm no12
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 280, 860) 'DPMCERTNO
                        e.Graphics.DrawString("", Font, Brushes.Black, 425, 860) 'DPMCERTPrank
                        e.Graphics.DrawString(certissued, Font, Brushes.Black, 523, 860) 'DPMCERTPissued
                        e.Graphics.DrawString(certexpired, Font, Brushes.Black, 650, 860) 'DPMCERTexpired

                    End If


                    ''VISA/LOGBOOK

                    If certdocid.ToString.Equals("1683") And certshortcut.ToString.Equals("DP Logbook") Then
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 970) 'DPLBISSUE 1683
                    End If


                    If certdocid.ToString.Equals("1395") Then
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 990) 'IMCAISSUE
                    End If

                    If certdocid.ToString.Equals("1287") Then
                        e.Graphics.DrawString(certno, Font, Brushes.Black, 615, 1110) 'CRNOPISSUE
                    End If
                End While

                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                e.HasMorePages = True

            Case 2

                Dim path As String = "\\192.168.11.22\Hunters_PMS\Hunters_PMS\Resource\OC9-Prejoining_Part2.jpg" 'pathfile
                Dim newImage As Image = Image.FromFile(path) 'read image
                e.Graphics.DrawImage(newImage, e.PageBounds)
                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)
                e.HasMorePages = True



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
                While doccertreader.Read
                    certdocid = doccertreader.Item("Document_ID").ToString()
                    certname = doccertreader.Item("AppCert_Name").ToString()
                    certno = doccertreader.Item("AppCert_No").ToString()
                    certplace = doccertreader.Item("AppCert_Place").ToString()
                    certissued = doccertreader.Item("AppCert_DateIssued").Date.ToString
                    Try
                        certexpired = doccertreader.Item("AppCert_DateExpired").Date.ToString()
                    Catch ex As Exception
                        certexpired.ToString("n/a")
                    End Try

                    If certdocid.ToString.Equals("1468") Then
                        'BTCERTNO
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 590)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 590)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 590)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 590)
                    End If
                    If certdocid.ToString.Equals("1468") Then
                        'BFF
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 620)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 620)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 620)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 620)
                    End If
                    If certdocid.ToString.Equals("1477") Then
                        'AFF
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 650)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 650)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 650)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 650)
                    End If
                    If certdocid.ToString.Equals("1102") Then
                        'EFA
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 680)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 680)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 680)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 680)
                    End If
                    If certdocid.ToString.Equals("1043") Then
                        'MFA
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 710)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 710)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 710)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 710)
                    End If
                    If certdocid.ToString.Equals("1044") Then
                        'Meca
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 740)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 740)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 740)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 740)
                    End If

                    If certdocid.ToString.Equals("0001") Then
                        'pst
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 770)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 770)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 770)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 770)
                    End If
                    If certdocid.ToString.Equals("1568") Then
                        'pscrb
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 800)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 800)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 800)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 800)
                    End If
                    If certdocid.ToString.Equals("1239") Then
                        'btm
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 830)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 830)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 830)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 830)
                    End If
                    If certdocid.ToString.Equals("0001") Then
                        'pssr
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 860)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 860)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 860)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 860)
                    End If
                    If certdocid.ToString.Equals("1145") Then
                        'brm
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 903)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 903)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 903)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 903)
                    End If
                    If certdocid.ToString.Equals("1231") Then
                        'arpa
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 933)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 933)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 933)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 933)
                    End If

                    If certdocid.ToString.Equals("1105") Then
                        'ecdis
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 963)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 963)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 963)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 963)
                    End If

                    If certdocid.ToString.Equals("1657") Then
                        'ecdis-jrc
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 993)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 993)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 993)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 993)
                    End If

                    If certdocid.ToString.Equals("1122") Then
                        'sms
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1048)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1048)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1048)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1048)
                    End If

                    If certdocid.ToString.Equals("1164") Then
                        'ers
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1078)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1078)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1078)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1078)
                    End If
                    If certdocid.ToString.Equals("1361") Then
                        'soc
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1108)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1108)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1108)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1108)
                    End If
                    If certdocid.ToString.Equals("1032") Then
                        'sso
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1138)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1136)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1136)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1136)
                    End If
                    If certdocid.ToString.Equals("0001") Then
                        'stfs
                        e.Graphics.DrawString(certno, Font8, Brushes.Black, 260, 1166)
                        e.Graphics.DrawString(certissued, Font8, Brushes.Black, 410, 1166)
                        e.Graphics.DrawString(certexpired, Font8, Brushes.Black, 510, 1166)
                        e.Graphics.DrawString(certplace, Font8, Brushes.Black, 620, 1166)
                    End If

                End While
                e.PageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1400)


            Case 3


        End Select

    End Sub


    Private Sub Esm0901_Click(sender As Object, e As EventArgs) Handles Esm0901.Click
        Dim PPV As New PrintPreviewDialog
        Dim PD As New Drawing.Printing.PrintDocument

        PPV.Document = PD

        DirectCast(PPV, Form).WindowState = FormWindowState.Maximized
        PPV.Document.DefaultPageSettings.PaperSize = New Drawing.Printing.PaperSize("Legal", 850, 1100)
        AddHandler PD.PrintPage, AddressOf EsmPrint_PrintPage


        'Printing na may set up ng page
        Dim AmsPrintDialog As New PrintDialog()
        ' PrintDialog1.Document = CvPrint


        If AmsPrintDialog.ShowDialog(PPV) = Windows.Forms.DialogResult.OK Then
            EsmPrint.PrinterSettings = AmsPrintDialog.PrinterSettings
            AmsPrintDialog.AllowSomePages = True
            OC31Print.Print()
            Me.Hide()
        End If

    End Sub




    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub




End Class