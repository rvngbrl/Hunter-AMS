Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports Bunifu
Imports BunifuAnimatorNS

Public Class OnlineForm
    Public Property GetOAppID As String
    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")
    Function EscapeQuote(ByVal msData As Object) As String
        Return (Replace(msData, "'", "''"))
    End Function

    Private Sub OnlineForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Show Data Grid View
        Dim mainAppList As String
        mainAppList = "SELECT ai.App_ID,CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname) AS 'Applicant Name',  YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'AGE', ai.App_PositionApplied AS 'Position' FROM web.applicant_info ai
Left Join web.applicant_stat ap ON ai.App_ID=ap.App_onlineID WHERE ai.App_Status ='APPLICANT' and  ap.App_Status is null  ORDER BY App_DateApplied desc; "

        Dim ApplicantView As New DataTable("hunters_pooling.applicant_info")
        Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
        applist.Fill(ApplicantView)
        onlineDGView.DataSource = ApplicantView
        applist.Dispose()
        onlineDGView.Columns("App_ID").Visible() = False
    End Sub


    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub

    'Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
    '    Using sqlCon As New SqlConnection(cloudConn)
    '        Try
    '            sqlCon.Open()

    '            MsgBox(sqlCon.State)


    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '        Console.ReadKey()
    '    End Using
    'End Sub

    Private Sub applicantName_OnValueChanged(sender As Object, e As EventArgs) Handles applicantName.OnValueChanged

    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If



        'Searching Applicant By Name 
        Dim mainAppList As String
        mainAppList = "SELECT App_ID,CONCAT(App_LName, ', ',App_FName,' ', App_Mname) AS 'Applicant Name',  YEAR(CURDATE()) - YEAR(App_Bday) AS 'AGE',
 App_PositionApplied AS 'Position' FROM web.applicant_info WHERE App_Status ='APPLICANT' and App_LName LIKE '%" & applicantName.Text & "%' OR App_FName LIKE '%" & applicantName.Text & "%' OR App_MName LIKE '%" & applicantName.Text & "%' ORDER BY App_DateApplied desc; "


        Dim ApplicantView As New DataTable("applicant_info")
        Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
        applist.Fill(ApplicantView)
        onlineDGView.DataSource = ApplicantView
        applist.Dispose()
        onlineDGView.Columns("App_ID").Visible() = False

        conn.Close()
    End Sub

    Private Sub applicantName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles applicantName.KeyPress

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        'Searching Applicant By Name 
        Dim mainAppList As String
        mainAppList = "SELECT App_ID,CONCAT(App_LName, ', ',App_FName,' ', App_Mname) AS 'Applicant Name',  YEAR(CURDATE()) - YEAR(App_Bday) AS 'AGE',
 App_PositionApplied AS 'Position' FROM web.applicant_info WHERE App_Status ='APPLICANT' and App_LName LIKE '%" & applicantName.Text & "%' OR App_FName LIKE '%" & applicantName.Text & "%' OR App_MName LIKE '%" & applicantName.Text & "%' ORDER BY App_DateApplied desc; "


        Dim ApplicantView As New DataTable("applicant_info")
        Dim applist As New Odbc.OdbcDataAdapter(mainAppList, conn)
        applist.Fill(ApplicantView)
        onlineDGView.DataSource = ApplicantView
        applist.Dispose()
        onlineDGView.Columns("App_ID").Visible() = False

        conn.Close()
    End Sub



    Private Sub onlineDGView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles onlineDGView.CellDoubleClick
        If (e.RowIndex >= 0) Then

            Dim OBJ As New OnlineAppInfo
            OBJ.GetOAppID = AppIDIdentifier.Text
            OBJ.Hide()
            OBJ.Show()
        ElseIf e.RowIndex <> -1 Then
        End If
        ' Me.Close()
    End Sub


    Private Sub onlineDGView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles onlineDGView.CellClick
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        If (e.RowIndex >= 0) Then
            AppIDIdentifier.Text = onlineDGView.Rows.Item(e.RowIndex).Cells(0).Value
            GetOAppID = onlineDGView.Rows.Item(e.RowIndex).Cells(0).Value
        ElseIf e.RowIndex <> -1 Then

        End If



    End Sub

    Private Sub onlineDGView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles onlineDGView.CellContentClick

    End Sub
End Class