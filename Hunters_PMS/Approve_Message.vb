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
Imports GemBox.Pdf

Public Class Approve_Message
    Dim principalID As String
    Public Property username As String


    Public Property GetAppID As String
    Public Property rankID As String
    Public Property GetCrewID As String
    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")


    '//NEED TO INSERT IN THIS DATABASE: cREW-iNFO -cREW-sTATUS -VESSEL

    Dim PrincipalEndorse As String

    'info
    Dim Lname, Fname, Mname, Suffix, NNname, Address, Address2, citizenship, Bplace, CivilStat, ContactNo, ContactNo2 As String
    Dim Sex, Religion, EmailAdd, Pagibig, Tin, SSS, Philhealth, Heights, Weight, Shirtsize, Suitsize, WaisteSize, ShoeSize As String
    Dim CCourse, CStudies, CYear As String

    Dim Bday, DateMarriage As Date
    'seaservice
    Dim PName, VName, Flag, Nationality, Agency, Rank, VType, Grt, EType, Bhp, Duration, Reason, TRoute, Salary As String

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub

    Dim Signedon, Signedoff As Date

    'family
    Dim Klname, KFname, KMname, KSuffix, Kaddress, KBplace, KSex, KContact, KRelation, KOccupation, KStat As String
    Dim KBday As Date


    'crewdoc
    Dim docid, docname, docshortcut, docno, docplace, docexpired, doccountry, crewdocid, docstatus As String
    Dim dateissued, dateexpired As Date


    'crewcert
    Dim certdocid, certname, certshortcut, certno, certplace, certcountry, certtraining, certstatus As String
    Dim certissued, certexpired As Date

    'crewvessel
    Dim PrincID, Vessel, VesselId As String
    Dim VesselDate As Date


    'crew_rank
    Dim ranID, rankname, higherrank, shorcut, radept, raclass As String
    Dim rankdate As Date

    'crewstat
    Dim StatCrewID, StatvesselAssignID, StatVesselID, StatPrincipalID, StatCRankID, StatRankID As String
    Dim StatVAssignedDate As Date

    Dim datenow As Date = Date.UtcNow

    Private Sub Approve_Message_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

    End Sub

    'crew_info
    Private Sub insertinfo()

        Dim selinfo As String
        selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

        Dim selinfocmd As OdbcCommand
        selinfocmd = New OdbcCommand(selinfo, conn)


        Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()

        If selinforeader.Read Then

            'ipalit to sa dati

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
            ' DateMarriage = selinforeader.Item("App_DateMarriage").Date.ToString()
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

            Dim insertinfo As String
            insertinfo = ("INSERT INTO csiaccountingdb.crew_info(Crew_INfocode, Crew_LName, Crew_FName, Crew_MName, Crew_Suffix, Crew_Address ,Crew_Bday ,Crew_Bplace ,Crew_CivilStat ,Crew_PagibigNo ,Crew_SSSNo
,Crew_TinNo, Crew_PhilhealthNo, Crew_ContactNo,  Crew_Address2, Crew_ContactNo2, Crew_Nickname, Crew_Height, Crew_Weight, Crew_EmailAdd,  Crew_Citizenship, Crew_Religion, Crew_Sex, Crew_CourseGraduated,
Crew_SchoolGraduated, Crew_YearGraduated, Crew_DateMarriage, Crew_SuitSize, Crew_ShirtSize, Crew_WaistSize, Crew_ShoesSize,Crew_CurrentStatus ) " &
                              "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")

            Dim insertinfocmd As OdbcCommand = New OdbcCommand(insertinfo, conn)
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_INfocod", CType("CSI", String))) '0
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_LName", CType(Lname, String))) '1
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_FName", CType(Fname, String))) ' 2
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_MName", CType(Mname, String))) '3
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Suffix", CType(Suffix, String))) ' 4
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Address", CType(Address, String))) '5
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Bday", CType(Bday.Date.ToString("yyyy-MM-dd"), Date))) '6
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Bplace", CType(Bplace, String))) '7
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_CivilStat", CType(CivilStat, String))) '8
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_PagibigNo", CType(Pagibig, String))) '9
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_SSSNo", CType(SSS, String))) '10
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_TinNo", CType(Tin, String))) '11
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_PhilhealthNo", CType(Philhealth, String))) '12
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_ContactNo", CType(ContactNo, String))) '13
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Address2", CType(Address2, String))) '14
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_ContactNo2", CType(ContactNo2, String))) '15
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Nickname", CType(NNname, String))) '16
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Height", CType(Heights, String))) '17
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Weight", CType(Weight, String))) '18
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_EmailAdd", CType(EmailAdd, String))) '19
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Citizenship", CType(citizenship, String))) '20
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Religion", CType(Religion, String))) '21
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_Sex", CType(Sex, String))) '22
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_CourseGraduated", CType(CCourse, String))) '23
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_SchoolGraduated", CType(CStudies, String))) '24
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_YearGraduated", CType(CYear, String))) '25
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_DateMarriage", CType(DateMarriage.Date.ToString("yyyy-MM-dd"), Date))) '26
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_SuitSize", CType(Suitsize, String))) '27
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_ShirtSize", CType(Shirtsize, String))) '28
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_WaistSize", CType(WaisteSize, String))) '29
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_ShoesSize", CType(ShoeSize, String))) '30
            insertinfocmd.Parameters.Add(New OdbcParameter("@Crew_CurrentStatus", CType("ACTIVE", String))) '31
            insertinfocmd.ExecuteNonQuery()
            insertinfocmd.Dispose()



            'query for crew_id
            Dim getcrewidstr As String
            ' getcrewidstr = "SELECT Crew_ID FROM csiaccountingdb.crew_info where Crew_FName = 'Isaiah John' And Crew_LName = 'Ranigo'   order by Crew_ID desc limit 1;"
            getcrewidstr = "SELECT Crew_ID FROM csiaccountingdb.crew_info where Crew_FName = '" & Fname & "' And Crew_LName = '" & Lname & "'   order by Crew_ID desc limit 1;"
            Dim getcrewidcmd As OdbcCommand
            getcrewidcmd = New OdbcCommand(getcrewidstr, conn)
            Dim getcrewidReader As OdbcDataReader = getcrewidcmd.ExecuteReader()

            If getcrewidReader.Read Then
                GetCrewID = getcrewidReader.Item(0).ToString

            End If
            ' MessageBox.Show("CREW INFO INSERTED")
            ' insfamily()
            crewdoc()
            MsgBox(GetCrewID)



        End If


    End Sub

    'crewfamily
    Private Sub insfamily()
        Try
            Dim kinfamstr As String

            kinfamstr = "Select * from hunters_pooling.applicant_family where appkin_Status = 'ACTIVE' and App_ID = " & GetAppID & ";   "
            Dim kinfamcmd As OdbcCommand
            kinfamcmd = New OdbcCommand(kinfamstr, conn)
            Dim kinfamreader As OdbcDataReader = kinfamcmd.ExecuteReader()




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

                'insert
                Dim inskinstr As String
                inskinstr = ("INSERT INTO csiaccountingdb.crew_family(Kin_Lname, Kin_Fname, Kin_Mname, Kin_Suffix, Kin_Address,  Kin_Bday ,Kin_Sex ,Kin_Bplace,
                                                      Kin_ContactNo ,Kin_Occupation ,Kin_RelationtoCrew, Kin_Status ,Crew_ID) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)")
                Dim inskincmd As OdbcCommand = New OdbcCommand(inskinstr, conn)

                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Lname", CType(Klname, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Fname", CType(KFname, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Mname", CType(KMname, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Suffix", CType(KSuffix, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Address", CType(Kaddress, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Bday", CType(KBday.Date.ToString("yyyy-MM-dd"), Date)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Sex", CType(KSex, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Bplace", CType(KBplace, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_ContactNo", CType(KContact, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Occupation", CType(KOccupation, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_RelationtoCrew", CType(KRelation, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Kin_Status", CType(KStat, String)))
                inskincmd.Parameters.Add(New OdbcParameter("@Crew_ID", CType(GetCrewID, String)))



                inskincmd.ExecuteNonQuery()
                inskincmd.Dispose()





            End While
            ' MessageBox.Show("Crew_Family Inserted")
            crewdoc()
        Catch ex As Exception
            MessageBox.Show("Crew_Family Inserted")
            crewdoc()
        End Try


    End Sub


    'crew_doc
    Private Sub crewdoc()
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
                dateexpired = datenow.ToString()
            End Try


            Dim insdoc As String

            insdoc = ("INSERT INTO csiaccountingdb.crew_doc(Doc_Name, Doc_Shortcut, Doc_Country ,Doc_No ,Doc_Place ,Doc_DateIssued,Doc_DateExpired ,
            Doc_Remarks ,Doc_Requirements, Doc_Status ,Doc_Date, Doc_Qty ,Crew_ID,Document_ID ) " &
                    "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?)")

            Dim insdoccmd As OdbcCommand = New OdbcCommand(insdoc, conn)

            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Name", CType(docname, String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Shortcut", CType(docshortcut, String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Country", CType(doccountry, String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_No", CType(docno, String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Place", CType(docplace, String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_DateIssued", CType(dateissued.Date.ToString("yyyy-MM-dd"), Date)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_DateExpired", CType(dateexpired.Date.ToString("yyyy-MM-dd"), Date)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Remarks", CType("--", String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Requirements", CType("--", String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Status", CType(docstatus, String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Date", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Doc_Qty", CType("0", String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Crew_ID,", CType(GetCrewID, String)))
            insdoccmd.Parameters.Add(New OdbcParameter("@Document_ID ", CType(docid, String)))
            insdoccmd.ExecuteNonQuery()
            insdoccmd.Dispose()







        End While
        ' MessageBox.Show("Crew_Doc Inserted")
        inscert()


    End Sub


    'crew_cert
    Private Sub inscert()
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
                certexpired = datenow.ToString()
            End Try


            Dim inscel As String
            inscel = ("INSERT INTO csiaccountingdb.crew_trainingcert(Cert_Name, Cert_Shortcut, Cert_Country ,Cert_No ,Cert_Place ,Cert_DateIssued, Cert_DateExpired ,
            Cert_Remarks ,Cert_TrainingCenter,Cert_Category, Cert_Requirements, Cert_Status,Cert_Date,  Cert_Qty ,Crew_ID,Document_ID ) " &
                    "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
            Dim inscelcmd As OdbcCommand = New OdbcCommand(inscel, conn)

            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Name", CType(certname, String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Shortcut", CType(certshortcut, String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Country", CType(certcountry, String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_No", CType(certno, String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Place", CType(certplace, String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_DateIssued", CType(certissued.Date.ToString("yyyy-MM-dd"), Date)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_DateExpired ", CType(certexpired.Date.ToString("yyyy-MM-dd"), Date)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Remarks", CType("--", String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_TrainingCenter", CType(certtraining, String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Category", CType("--", String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Requirements", CType("--", String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Status", CType(certstatus, String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Date", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Cert_Qty", CType("0", String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Crew_ID,", CType(GetCrewID, String)))
            inscelcmd.Parameters.Add(New OdbcParameter("@Document_ID ", CType(certdocid, String)))
            inscelcmd.ExecuteNonQuery()
            inscelcmd.Dispose()



        End While
        ' MessageBox.Show("Crew_Cert Inserted")
        insertsea()
    End Sub

    'shipboard experience
    Private Sub insertsea()

        Dim selseastr As String
        selseastr = "SELECT * FROM hunters_pooling.applicant_seaservice where App_ID=" & GetAppID & ";"
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
            EType = selseaReader.Item("App_EngineType").ToString
            Bhp = selseaReader.Item("App_BHP").ToString
            Signedon = selseaReader.Item(12).Date.ToString
            Signedoff = selseaReader.Item(13).Date.ToString
            Duration = selseaReader.Item("App_Duration").ToString
            Reason = selseaReader.Item("App_Reason").ToString
            TRoute = selseaReader.Item("App_TradingRoute").ToString
            Salary = selseaReader.Item("App_Salary").ToString



            Dim inssea As String
            inssea = ("INSERT INTO csiaccountingdb.crew_shipboardexperience(Sbexp_PrincipalName, Sbexp_VesselName, Sbexp_Flag ,Sbexp_Nationality ,Sbexp_Agency ,Sbexp_Rank ,Sbexp_VesselType ,
            Sbexp_GRT ,Sbexp_EngineType,  Sbexp_BHP, Sbexp_DateSignedON,Sbexp_DateSignedOFF, Sbexp_Duration, Sbexp_Reason,Sbexp_TradingRoute, Sbexp_Salary,Crew_ID  ) " &
                       "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")

            Dim insseacmd As OdbcCommand = New OdbcCommand(inssea, conn)
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_PrincipalName", CType(PName, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_VesselName", CType(VName, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_Flag", CType(Flag, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_Nationality", CType(Nationality, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_Agency", CType(Agency, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_Rank", CType(Rank, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_VesselType", CType(VType, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_GRT", CType(Grt, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_EngineType", CType(EType, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_BHP", CType(Bhp, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_DateSignedON", CType(Signedon.Date.ToString("yyyy-MM-dd"), Date)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_DateSignedOFF", CType(Signedoff.Date.ToString("yyyy-MM-dd"), Date)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_Duration", CType(Duration, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_Reason", CType(Reason, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_TradingRoute", CType(TRoute, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Sbexp_Salary", CType(Salary, String)))
            insseacmd.Parameters.Add(New OdbcParameter("@Crew_ID", CType(GetCrewID, String)))



            insseacmd.ExecuteNonQuery()
            insseacmd.Dispose()




        End While
        ' MessageBox.Show("Crew_Shipboard Inserted")

        Vesselassign()
    End Sub

    'crew_vesselassign

    Private Sub Vesselassign()

        Dim SelVesstr As String
        SelVesstr = "SELECT *  FROM hunters_pooling.applicant_vesselassign where App_ID = '" & GetAppID & "';"
        Dim Vesselcmd As OdbcCommand
        Vesselcmd = New OdbcCommand(SelVesstr, conn)
        Dim VesselRead As OdbcDataReader = Vesselcmd.ExecuteReader()



        If VesselRead.Read Then

            PrincID = VesselRead.Item("APrincipal_ID").ToString
            Vessel = VesselRead.Item("AVessel").ToString
            VesselId = VesselRead.Item("AVessel_ID").ToString
            VesselDate = VesselRead.Item("AVessel_AssignDate").Date.ToString

            Dim InsVes As String
            InsVes = ("INSERT INTO csiaccountingdb.crew_vesselassign(Crew_VesselAssignDate, Vessel_ID, Principal_ID, Crew_ID) VALUES (?,?,?,?)")

            Dim InsVescmd As OdbcCommand = New OdbcCommand(InsVes, conn)

            InsVescmd.Parameters.Add(New OdbcParameter("@Crew_VesselAssignDate", CType(VesselDate.Date.ToString("yyyy-MM-dd"), Date)))
            InsVescmd.Parameters.Add(New OdbcParameter("@Vessel_ID", CType(VesselId, String)))
            InsVescmd.Parameters.Add(New OdbcParameter("@Principal_ID", CType(PrincID, String)))
            InsVescmd.Parameters.Add(New OdbcParameter("@Crew_ID", CType(GetCrewID, String)))
            InsVescmd.ExecuteNonQuery()
            InsVescmd.Dispose()
            '   MessageBox.Show("Crew_Vessel Inserted")
            crewRank()
        Else
            MessageBox.Show("Cant read")

        End If


    End Sub

    'crew_rank
    Public Sub crewRank()
        Dim SelRank As String
        SelRank = "Select * From hunters_pooling.applicant_rank Where App_ID = '" & GetAppID & "' Order By Applied_RankID desc  limit 1 ;"
        Dim SelRankcmd As OdbcCommand
        SelRankcmd = New OdbcCommand(SelRank, conn)
        Dim SelRankreader As OdbcDataReader = SelRankcmd.ExecuteReader()



        If SelRankreader.Read Then

            ranID = SelRankreader.Item("AppRank_ID").ToString
            rankname = SelRankreader.Item("AppRank_Name").ToString
            higherrank = SelRankreader.Item("AppHigherRank_Name").ToString
            rankdate = SelRankreader.Item("AppRank_Date").Date.ToString


            'select rank in crew_info

            Dim crewrank As String
            crewrank = "SELECT * FROM csiaccountingdb.rank where Rank_ID ='" & ranID & "';"
            Dim crewrankcmd As OdbcCommand
            crewrankcmd = New OdbcCommand(crewrank, conn)
            Dim crewrankreader As OdbcDataReader = crewrankcmd.ExecuteReader()



            If crewrankreader.Read Then

                shorcut = crewrankreader.Item("Rank_Shortcut").ToString
                radept = crewrankreader.Item("Rank_Department").ToString
                raclass = crewrankreader.Item("Rank_Class").ToString

                'insert rank
                Dim insrank As String
                insrank = ("INSERT INTO csiaccountingdb.crew_rank(Crew_Rank, Crew_Rankdate, Crew_Srank, Crew_HigherRank, Crew_RankType, Crew_RankStatus, Rank_ID, Crew_ID) VALUES (?,?,?,?,?,?,?,?)")

                Dim insrankcmd As OdbcCommand = New OdbcCommand(insrank, conn)
                MessageBox.Show(ranID)

                insrankcmd.Parameters.Add(New OdbcParameter("@Crew_Rank", CType(rankname, String)))
                insrankcmd.Parameters.Add(New OdbcParameter("@Crew_Rankdate", CType(rankdate.Date.ToString("yyyy-MM-dd"), Date)))
                insrankcmd.Parameters.Add(New OdbcParameter("@Crew_Srank", CType(shorcut, String)))
                insrankcmd.Parameters.Add(New OdbcParameter("@Crew_HigherRank", CType(higherrank, String)))
                insrankcmd.Parameters.Add(New OdbcParameter("@Crew_RankType", CType(radept, String)))
                insrankcmd.Parameters.Add(New OdbcParameter("@Crew_RankStatus", CType(raclass, String)))
                insrankcmd.Parameters.Add(New OdbcParameter("@Rank_ID", CType(ranID, String)))
                insrankcmd.Parameters.Add(New OdbcParameter("@Crew_ID", CType(GetCrewID, String)))


                insrankcmd.ExecuteNonQuery()
                insrankcmd.Dispose()
                ' MessageBox.Show("Crew_Rank Inserted")
                crewStat()

            End If



        End If


    End Sub

    'crew_stat
    Public Sub crewStat()
        Dim selstat As String
        selstat = "SELECT cv.Crew_ID, cv.Crew_VesselAssignDate, cv.Crew_VesselAssignID, cv.Vessel_ID, cv.Principal_ID, cr.Crew_RankID, cr.Rank_ID FROM csiaccountingdb.crew_vesselassign cv LEFT JOIN csiaccountingdb.crew_rank cr ON cv.Crew_ID=cr.Crew_ID  where cv.Crew_ID= '" & GetCrewID & "';"
        Dim selstatcmd As OdbcCommand
        selstatcmd = New OdbcCommand(selstat, conn)
        Dim selstatreader As OdbcDataReader = selstatcmd.ExecuteReader()

        If selstatreader.Read Then

            StatCrewID = selstatreader.Item("Crew_ID").ToString

            StatVAssignedDate = selstatreader.Item("Crew_VesselAssignDate").Date.ToString
            StatvesselAssignID = selstatreader.Item("Crew_VesselAssignID").ToString
            StatVesselID = selstatreader.Item("Vessel_ID").ToString

            StatPrincipalID = selstatreader.Item("Principal_ID").ToString
            StatCRankID = selstatreader.Item("Crew_RankID").ToString
            StatRankID = selstatreader.Item("Rank_ID").ToString

            Dim insstats As String



            insstats = ("INSERT INTO csiaccountingdb.crew_status(CrewStat_Name,CrewStat_Date, CrewStat_Remarks, Crew_ID, Crew_RankID, Crew_VesselAssignID, Vessel_ID , Rank_ID, Principal_ID) VALUES (?,?,?,?,?,?,?,?,?)")

            Dim insstatcmd As OdbcCommand = New OdbcCommand(insstats, conn)

            insstatcmd.Parameters.Add(New OdbcParameter("@CrewStat_Name", CType("PENDING", String)))
            insstatcmd.Parameters.Add(New OdbcParameter("@CrewStat_Date", CType(StatVAssignedDate.Date.ToString("yyyy-MM-dd"), Date)))
            insstatcmd.Parameters.Add(New OdbcParameter("@CrewStat_Remarks", CType("PENDING", String)))
            insstatcmd.Parameters.Add(New OdbcParameter("@Crew_ID", CType(StatCrewID, String)))
            insstatcmd.Parameters.Add(New OdbcParameter("@Crew_RankID", CType(StatCRankID, String)))
            insstatcmd.Parameters.Add(New OdbcParameter("@Crew_VesselAssignID", CType(StatvesselAssignID, String)))
            insstatcmd.Parameters.Add(New OdbcParameter("@Vessel_ID", CType(StatVesselID, String)))
            insstatcmd.Parameters.Add(New OdbcParameter("@Rank_ID", CType(StatRankID, String)))
            insstatcmd.Parameters.Add(New OdbcParameter("@Principal_ID", CType(StatPrincipalID, String)))


            insstatcmd.ExecuteNonQuery()
                insstatcmd.Dispose()
            MessageBox.Show("Applicant Succesfully Added in COI")


        End If



    End Sub


    Private Sub AprvBtn_Click(sender As Object, e As EventArgs) Handles AprvBtn.Click

        'Try

        'GetStatus

        Dim getStat As String
        getStat = "SELECT App_Status FROM hunters_pooling.applicant_info where App_ID= '" & GetAppID & "';"
        Dim getStatcmd As OdbcCommand
        getStatcmd = New OdbcCommand(getStat, conn)
        Dim getStatreader As OdbcDataReader = getStatcmd.ExecuteReader()

        If getStatreader.Read Then
            Dim getAppStat = getStatreader.Item("App_Status").ToString()
            If getAppStat.ToString.Equals("Applicant") Then

                '////////////////////////////////////////////////////////////////get_principal////////////////////////////

                Dim getendorsed As String
                getendorsed = "SELECT AppPrincipalEndorse FROM hunters_pooling.applicant_endorse WHERE App_ID = '" & GetAppID & "' and AppStatus= 'Endorsed' order by Appendorsed_ID desc limit 1 ;"
                Dim getEndrsdsmd As OdbcCommand
                getEndrsdsmd = New OdbcCommand(getendorsed, conn)
                Dim getEndrsdReader As OdbcDataReader = getEndrsdsmd.ExecuteReader()

                If getEndrsdReader.Read Then
                    PrincipalEndorse = getEndrsdReader.Item("AppPrincipalEndorse").ToString()
                End If
                '///////////////////////////////////////app_endorse///////////////////////////////////////
                Dim CVRankStr As String
                CVRankStr = ("INSERT INTO hunters_pooling.applicant_endorse(RepsEndorser,AppStatus, AppPrincipalEndorse,
                      AppDateEndorse,App_RankID,App_ID) VALUES (?,?,?,?,?,?)")
                Dim CVRankcmd As OdbcCommand = New OdbcCommand(CVRankStr, conn)
                CVRankcmd.Parameters.Add(New OdbcParameter("@RepsEndorser", CType(username, String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@AppStatus", CType("Approved", String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@AppPrincipalEndorse", CType(" PrincipalEndorse", String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@AppDateEndorse", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@App_RankID", CType(rankID, String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))
                CVRankcmd.ExecuteNonQuery()
                CVRankcmd.Dispose()


                '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\app_endorse\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                'update applicant status
                '////////////////////////////////////////update_current-status in app_info///////////////////////////////////////

                'update_applicant vesselassign
                Dim updatestatstr As String
                updatestatstr = " Update hunters_pooling.applicant_info SET App_CurrentStatus= 'Approved',
            App_Status='CREW'
            WHERE App_ID='" & GetAppID & "'; "
                Dim updatestatcmd As OdbcCommand = New OdbcCommand(updatestatstr, conn)
                updatestatcmd.ExecuteNonQuery()
                updatestatcmd.Dispose()

                '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\update_current-status in app_info\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                insertinfo()
                MsgBox(GetAppID)


                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                'End Try
                Me.Close()




            Else
                MsgBox("This Applicant is already Approved.")

            End If

        End If






        '\\\\\\\\\\\\\\\\\\


    End Sub



    Private Sub sampleprint_PrintPage(sender As Object, e As PrintPageEventArgs) Handles sampleprint.PrintPage
        Dim selinfo As String
        selinfo = " SELECT ai.App_LName, ai.App_FName, ai.App_MName, ai.App_Suffix, ai.App_Nickname, 
            CONCAT(ad.App_Street, ' ',ad.App_Barangay,' ',ad.App_City,' ',ad.App_Province,' ',ad.App_Country,'', App_Suffix) AS 'Address',
            ad.App_address2,ai.App_Citezenship,  ai.App_Bday, ai.App_BPlace,ai.App_CivilStat,ai.App_DateMarriage, ai.App_ContactNo, ai.App_ContactNo2, ai.App_Sex, ai.App_Religion,
        ai.App_EmailAdd,  ai.App_PagibigNo, ai.App_PhilHealthNo, ai.App_SSSNo, ai.App_TinNo,ai.App_Height, ai.App_Weight,ai.App_ShirtSize, ai.App_SuitSize, ai.App_WaisteSize, ai.App_ShoeSize,
        ae.Studies_Course, ae.Studies_Name, ae.Studies_Year
            FROM hunters_pooling.applicant_info ai
                   LEFT JOIN hunters_pooling.applicant_address ad ON ai.App_ID=ad.App_ID
                    LEFT JOIN hunters_pooling.applicant_education ae ON ai.App_ID=ae.App_ID
                    WHERE ai.App_ID = " & GetAppID & " ;"

        Dim selinfocmd As OdbcCommand
        selinfocmd = New OdbcCommand(selinfo, conn)


        Dim selinforeader As OdbcDataReader = selinfocmd.ExecuteReader()





        While selinforeader.Read

            e.Graphics.DrawString(selinforeader.Item(0).ToString, Font, Brushes.Black, 155, 100)


            e.Graphics.DrawString(Fname, Font, Brushes.Black, 155, 120)
            e.Graphics.DrawString(Mname, Font, Brushes.Black, 155, 140)
            e.Graphics.DrawString(Suffix, Font, Brushes.Black, 155, 160)
            e.Graphics.DrawString(Address, Font, Brushes.Black, 155, 180)
            e.Graphics.DrawString(Address2, Font, Brushes.Black, 155, 200)
            e.Graphics.DrawString(citizenship, Font, Brushes.Black, 155, 220)
            e.Graphics.DrawString(Bday, Font, Brushes.Black, 155, 240)
            e.Graphics.DrawString(Bplace, Font, Brushes.Black, 155, 260)
            e.Graphics.DrawString(CivilStat, Font, Brushes.Black, 155, 280)
            e.Graphics.DrawString(DateMarriage, Font, Brushes.Black, 155, 300)
            e.Graphics.DrawString(ContactNo, Font, Brushes.Black, 155, 320)
            e.Graphics.DrawString(ContactNo2, Font, Brushes.Black, 155, 340)
            e.Graphics.DrawString(Sex, Font, Brushes.Black, 155, 360)
            e.Graphics.DrawString(Religion, Font, Brushes.Black, 155, 380)
            e.Graphics.DrawString(EmailAdd, Font, Brushes.Black, 155, 400)

            e.Graphics.DrawString(Pagibig, Font, Brushes.Black, 155, 420)
            e.Graphics.DrawString(Tin, Font, Brushes.Black, 155, 440)
            e.Graphics.DrawString(SSS, Font, Brushes.Black, 155, 460)
            e.Graphics.DrawString(Philhealth, Font, Brushes.Black, 155, 480)
            e.Graphics.DrawString(Height, Font, Brushes.Black, 155, 500)
            e.Graphics.DrawString(Weight, Font, Brushes.Black, 155, 520)
            e.Graphics.DrawString(Shirtsize, Font, Brushes.Black, 155, 540)
            e.Graphics.DrawString(Suitsize, Font, Brushes.Black, 155, 560)
            e.Graphics.DrawString(WaisteSize, Font, Brushes.Black, 155, 580)

            e.Graphics.DrawString(ShoeSize, Font, Brushes.Black, 155, 600)
            e.Graphics.DrawString(CCourse, Font, Brushes.Black, 155, 620)
            e.Graphics.DrawString(CStudies, Font, Brushes.Black, 155, 640)
            e.Graphics.DrawString(CYear, Font, Brushes.Black, 155, 680)


        End While




    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Me.Close()




    End Sub

End Class