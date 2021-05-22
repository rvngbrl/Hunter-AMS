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


Public Class App_Remarks

    Dim principalID As String
    Public Property username As String
    Public Property GetAppID As String
    Public Property rankID As String
    Public Property GetVesselID As String




    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.20;uid=crystal_admin;")
    Dim datenow As Date = Date.UtcNow
    Dim PrincipalEndorse As String
    Private Sub App_Remarks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Private Sub DappvdBtn_Click(sender As Object, e As EventArgs) Handles DappvdBtn.Click


        'messagebox concerning to endorse again

        Dim result As DialogResult = MessageBox.Show("Applicant Disapproved do you want to Endorse in another Principal", "Disapproved Applicant", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Me.Close()
        ElseIf result = DialogResult.No Then
            MessageBox.Show("No pressed")

            '////////////////////////////////////////////////////////////////get_principal////////////////////////////


            Dim getendorsed As String
            getendorsed = "SELECT AppPrincipalEndorse FROM hunters_pooling.applicant_endorse WHERE App_ID = '" & GetAppID & "' and AppStatus= 'Endorsed' order by Appendorsed_ID desc limit 1 ;"
            Dim getEndrsdsmd As OdbcCommand
            getEndrsdsmd = New OdbcCommand(getendorsed, conn)
            Dim getEndrsdReader As OdbcDataReader = getEndrsdsmd.ExecuteReader()

            If getEndrsdReader.Read Then
                PrincipalEndorse = getEndrsdReader.Item("AppPrincipalEndorse").ToString()

            End If



            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\get_principal\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\





            '////////////////////////////////////////update_current-status in app_info///////////////////////////////////////

            'update_applicant vesselassign
            Dim updatestatstr As String
            updatestatstr = " Update hunters_pooling.applicant_info SET App_CurrentStatus= 'Disapproved'
            WHERE App_ID='" & GetAppID & "'; "
            Dim updatestatcmd As OdbcCommand = New OdbcCommand(updatestatstr, conn)
            updatestatcmd.ExecuteNonQuery()
            updatestatcmd.Dispose()

            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\update_current-status in app_info\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

            '////////////////////////////////////////update_remarks in app_screening///////////////////////////////////////

            'update_applicant vesselassign
            Dim updateremstr As String
            updateremstr = " Update hunters_pooling.applicant_screening SET App_Remarks= '" & RemarksTxtbx.Text & "'
                WHERE App_ID='" & GetAppID & "'; "
            Dim updateremcmd As OdbcCommand = New OdbcCommand(updateremstr, conn)
            updateremcmd.ExecuteNonQuery()
            updateremcmd.Dispose()

            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\update_remarks in app_screening\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\



            '///////////////////////////////////////app_endorse///////////////////////////////////////
            Dim remarkstext = RemarksTxtbx.Text

            Dim CVRankStr As String
            CVRankStr = ("INSERT INTO hunters_pooling.applicant_endorse(RepsEndorser,AppStatus, AppPrincipalEndorse, App_Remarks,
                      AppDateEndorse,App_RankID,App_ID) VALUES (?,?,?,?,?,?,?)")
            Dim CVRankcmd As OdbcCommand = New OdbcCommand(CVRankStr, conn)
            CVRankcmd.Parameters.Add(New OdbcParameter("@RepsEndorser", CType(username, String)))
            CVRankcmd.Parameters.Add(New OdbcParameter("@AppStatus", CType("Disapproved", String)))
            CVRankcmd.Parameters.Add(New OdbcParameter("@AppPrincipalEndorse", CType(PrincipalEndorse, String)))
            CVRankcmd.Parameters.Add(New OdbcParameter("@App_Remarks", CType(remarkstext, String)))
            CVRankcmd.Parameters.Add(New OdbcParameter("@AppDateEndorse", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))

            CVRankcmd.Parameters.Add(New OdbcParameter("@App_RankID", CType(rankID, String)))
            CVRankcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))
            CVRankcmd.ExecuteNonQuery()
            CVRankcmd.Dispose()


            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\app_endorse\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\





            MessageBox.Show("Applicant Disapproved", "Applicant Status", MessageBoxButtons.OK)
        ElseIf result = DialogResult.Yes Then

            Dim ids As String = GetAppID
            Try
                '////////////////////////////////////////////////////////////////get_principal////////////////////////////


                Dim getendorsed As String
                getendorsed = "SELECT AppPrincipalEndorse FROM hunters_pooling.applicant_endorse WHERE App_ID = '" & GetAppID & "' and AppStatus= 'Endorsed' order by Appendorsed_ID desc limit 1 ;"
                Dim getEndrsdsmd As OdbcCommand
                getEndrsdsmd = New OdbcCommand(getendorsed, conn)
                Dim getEndrsdReader As OdbcDataReader = getEndrsdsmd.ExecuteReader()

                If getEndrsdReader.Read Then
                    PrincipalEndorse = getEndrsdReader.Item("AppPrincipalEndorse").ToString()

                End If



                '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\get_principal\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\





                '////////////////////////////////////////update_current-status in app_info///////////////////////////////////////

                'update_applicant vesselassign
                Dim updatestatstr As String
                updatestatstr = " Update hunters_pooling.applicant_info SET App_CurrentStatus= 'Disapproved'
            WHERE App_ID='" & GetAppID & "'; "
                Dim updatestatcmd As OdbcCommand = New OdbcCommand(updatestatstr, conn)
                updatestatcmd.ExecuteNonQuery()
                updatestatcmd.Dispose()

                '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\update_current-status in app_info\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                '////////////////////////////////////////update_remarks in app_screening///////////////////////////////////////

                'update_applicant vesselassign
                Dim updateremstr As String
                updateremstr = " Update hunters_pooling.applicant_screening SET App_Remarks= '" & RemarksTxtbx.Text & "'
                WHERE App_ID='" & GetAppID & "'; "
                Dim updateremcmd As OdbcCommand = New OdbcCommand(updateremstr, conn)
                updateremcmd.ExecuteNonQuery()
                updateremcmd.Dispose()

                '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\update_remarks in app_screening\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\



                '///////////////////////////////////////app_endorse///////////////////////////////////////
                Dim remarkstext = RemarksTxtbx.Text

                Dim CVRankStr As String
                CVRankStr = ("INSERT INTO hunters_pooling.applicant_endorse(RepsEndorser,AppStatus, AppPrincipalEndorse, App_Remarks,
                      AppDateEndorse,App_RankID,App_ID) VALUES (?,?,?,?,?,?,?)")
                Dim CVRankcmd As OdbcCommand = New OdbcCommand(CVRankStr, conn)
                CVRankcmd.Parameters.Add(New OdbcParameter("@RepsEndorser", CType(username, String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@AppStatus", CType("Disapproved", String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@AppPrincipalEndorse", CType(PrincipalEndorse, String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@App_Remarks", CType(remarkstext, String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@AppDateEndorse", CType(datenow.Date.ToString("yyyy-MM-dd"), Date)))

                CVRankcmd.Parameters.Add(New OdbcParameter("@App_RankID", CType(rankID, String)))
                CVRankcmd.Parameters.Add(New OdbcParameter("@App_ID", CType(GetAppID, String)))
                CVRankcmd.ExecuteNonQuery()
                CVRankcmd.Dispose()


                '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\app_endorse\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


                Dim OBJ As New CV_APPLICATION
                Me.Hide()
                OBJ.GetAppID = ids
                OBJ.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try


        End If
















    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()

    End Sub
End Class