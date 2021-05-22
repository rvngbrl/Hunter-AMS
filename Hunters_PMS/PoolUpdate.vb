
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


Public Class PoolUpdate

    Public Property GetAppID As String
    Public Property UserText As String
    Public Property PoolName1 As String

    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")

    Function EscapeQuote(ByVal msData As Object) As String
        Return (Replace(msData, "'", "''"))
    End Function

    Private Sub PoolUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        PoolNameText.Text = PoolName1
        RepsUser.Text = UserText
        AppIDTxt.Text = GetAppID

        Dim poolstr As String
        poolstr = "SELECT ai.App_ID as 'ID', sc.App_AssignedPrincipal as 'Principal',  sc.App_DateApplied as 'Date Applied',sc.App_DateReported as 'Date Reported', sc.App_Source as 'Source', sc.App_RankApplied as 'Rank', sc.App_Experience  as 'Experience',ai.App_Pool as 'Status',
 CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Name', ai.App_Bday as 'Birthday',  YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'Age', ai.App_ContactNo as 'Contact No', sc.App_DateLastCalled as 'Last Called', sc.App_Availability as 'Availability', sc.Reps_Endorser as 'Endorser' ,sc.App_Remarks as 'Officer Remarks'
FROM hunters_pooling.applicant_info ai
LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID =sc.App_ID WHERE ai.App_ID = '" & GetAppID & "' ;"
        Dim Poolcommand As OdbcCommand
        Poolcommand = New OdbcCommand(poolstr, conn)
        Dim PoolmyReader As OdbcDataReader = Poolcommand.ExecuteReader()


        If PoolmyReader.Read Then
            PoolDateCallled.Text = PoolmyReader.Item(12).ToString
            PoolDateReported.Text = PoolmyReader.Item(3).ToString
            Availabilitytxt.Text = PoolmyReader.Item(13).ToString
            RemarksTxtbx.Text = PoolmyReader.Item(15).ToString

        End If
        '////////////////////////////////////////Endorsed History////////////////////////////////////////////
        'Query For Endorse_History
        Dim endorsestr As String

        endorsestr = "SELECT AppDateEndorse as 'Date Endorse', AppPrincipalEndorse as 'Principal',AppStatus as 'Status ',App_Remarks as 'Remarks',RepsEndorser as 'Endorser' FROM hunters_pooling.applicant_endorse where App_ID=" & GetAppID & ";"
        Dim appendrList As New DataTable("applicant_endorse")
        Dim appendradapter As New Odbc.OdbcDataAdapter(endorsestr, conn)
        appendradapter.Fill(appendrList)
        EndorseDGView.DataSource = appendrList
        appendradapter.Dispose()


        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\Endorsed History\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    End Sub

    Private Sub PoolSaveBtn_Click(sender As Object, e As EventArgs) Handles PoolSaveBtn.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If



        If ReportedCbox.Checked Then

            Dim updateDataStr As String
            updateDataStr = " Update hunters_pooling.applicant_screening SET App_DateReported= '" & DBNull.Value & "', 
     
App_DateLastCalled ='" & PoolDateCallled.Value.Date.ToString("yyyy-MM-dd") & "',  
          App_Remarks ='" & EscapeQuote(RemarksTxtbx.Text) & "',   
App_Availability= '" & Availabilitytxt.Text & "',
        Reps_Endorser='" & RepsUser.Text & "'
            WHERE App_ID='" & GetAppID & "' ;  "
            Dim updateeducmd As OdbcCommand = New OdbcCommand(updateDataStr, conn)

            Try
                updateeducmd.ExecuteNonQuery()
                updateeducmd.Dispose()

                MessageBox.Show("Appplicant Data Updated")
                Pooling.Hide()
                Pooling.Show()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try



        Else

            Dim updateDataStr As String
            updateDataStr = " Update hunters_pooling.applicant_screening SET App_DateReported= '" & PoolDateReported.Value.Date.ToString("yyyy-MM-dd") & "', 
       
App_DateLastCalled ='" & PoolDateCallled.Value.Date.ToString("yyyy-MM-dd") & "',  
          App_Remarks ='" & RemarksTxtbx.Text & "',   
App_Availability= '" & Availabilitytxt.Text & "',
        Reps_Endorser='" & RepsUser.Text & "'
            WHERE App_ID='" & GetAppID & "' ;  "
            Dim updateeducmd As OdbcCommand = New OdbcCommand(updateDataStr, conn)

            Try
                updateeducmd.ExecuteNonQuery()
                updateeducmd.Dispose()

                MessageBox.Show("Appplicant Data Updated")
                Pooling.Hide()
                Pooling.Show()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try




        End If






    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub

    Private Sub ReportedCbox_OnChange(sender As Object, e As EventArgs) Handles ReportedCbox.OnChange
        If ReportedCbox.Checked = True Then
            PoolDateReported.Enabled = False
        Else
            PoolDateReported.Enabled = True


        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

        If Len(Trim(RemarksTxtbx.Text)) = 0 Then

            MessageBox.Show("Can't Print CV because this applicant isnt endorse.")
        Else
            Dim OBJ As New CVPrinting
            OBJ.username = UserText
            'OBJ.appage = GetAge
            OBJ.GetAppID = GetAppID
            OBJ.Show()
        End If

    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class