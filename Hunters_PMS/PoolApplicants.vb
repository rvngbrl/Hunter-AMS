Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports Bunifu
Imports BunifuAnimatorNS


Public Class PoolApplicants
    Public Property myacc As String
    Public Property GetAppID As String
    Public Property GetUserID As String
    Public Property rankID As String
    Dim userinitials As String
    Dim imgData As Byte()
    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")

    Private Sub PoolApplicants_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim mainAppList As String
        mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                       YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                       FROM hunters_pooling.applicant_info ai 
                       LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID
                       WHERE ai.App_Status ='APPLICANT'
                       ORDER BY ai.App_LName ASC;"

        Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
        Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
        applist.Fill(ApplicantView)
        ApplicantDataGridView.DataSource = ApplicantView
        applist.Dispose()
        ApplicantDataGridView.Columns("App_ID").Visible() = False

        ApplicantDataGridView.AutoResizeColumn(2.5)






    End Sub

    Private Sub applicantName_OnValueChanged(sender As Object, e As EventArgs) Handles applicantName.OnValueChanged

    End Sub

    Private Sub AppSearchBtn_Click(sender As Object, e As EventArgs) Handles AppSearchBtn.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim mainAppList As String
        mainAppList = "SELECT ai.App_ID, CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Applicant Name', 
                       YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ra.Rank_Fullname AS 'Rank' 
                       FROM hunters_pooling.applicant_info ai 
                       LEFT JOIN csiaccountingdb.rank ra ON ai.App_RankID=ra.Rank_ID 
                       WHERE ai.App_LName LIKE '%" & applicantName.Text & "%' OR ai.App_FName LIKE '%" & applicantName.Text & "%' OR ai.App_MName LIKE '%" & applicantName.Text & "%'
                       ORDER BY ai.App_LName ASC;"


        Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
        Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
        applist.Fill(ApplicantView)
        ApplicantDataGridView.DataSource = ApplicantView
        applist.Dispose()
        ApplicantDataGridView.Columns("App_ID").Visible() = False

        conn.Close()
    End Sub



    Private Sub ApplicantDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles ApplicantDataGridView.CellDoubleClick
        If (e.RowIndex >= 0) Then

            Dim OBJ As New Editing_Info
            OBJ.GetAppID = AppIDIdentifier.Text
            OBJ.GetRecord = "ApplicantEncode"
            OBJ.Hide()

            OBJ.Show()

        ElseIf e.RowIndex <> -1 Then


        End If

    End Sub



    Private Sub ApplicantDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles ApplicantDataGridView.CellClick


        If (e.RowIndex >= 0) Then

            AppIDIdentifier.Text = ApplicantDataGridView.Rows.Item(e.RowIndex).Cells(0).Value
            GetAppID = ApplicantDataGridView.Rows.Item(e.RowIndex).Cells(0).Value

        ElseIf e.RowIndex <> -1 Then

        End If
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub
End Class