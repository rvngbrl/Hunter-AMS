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


Public Class Pooling
    Public Property GetAppID As String
    Public Property UserText As String
    Public Property PoolName As String


    Dim conn As OdbcConnection = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")

    Private Sub ShipboardEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        App_Endorser.Text = UserText

        conn.Open()

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If


        Dim PoolingList As String
        PoolingList = "SELECT ai.App_ID as 'ID', sc.App_AssignedPrincipal as 'Principal',  sc.App_DateApplied as 'Date Applied',sc.App_DateReported as 'Date Reported', sc.App_Source as 'Source', sc.App_RankApplied as 'Rank', sc.App_Experience  as 'Experience',ai.App_Pool as 'Status',
 CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Name', ai.App_Bday as 'Birthday',  YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'Age', ai.App_ContactNo as 'Contact No', sc.App_DateLastCalled as 'Last Called', sc.App_Availability as 'Availability',sc.Reps_Endorser as 'Called By', sc.App_Remarks as 'Officers Remarks'
FROM hunters_pooling.applicant_info ai 
LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID =sc.App_ID where ai.App_Pool ='Pooling';"

        Dim dvPoolingList As New DataTable("applicant_pooling")
        Dim PoolingAdapter As New Odbc.OdbcDataAdapter(PoolingList, conn)
        PoolingAdapter.Fill(dvPoolingList)
        PoolingDGV.DataSource = dvPoolingList
        PoolingAdapter.Dispose()

        For i = 0 To PoolingDGV.Rows.Count - 1
            Dim r As DataGridViewRow = PoolingDGV.Rows(i)
            r.Height = 31
        Next
        PoolingDGV.Columns("ID").Visible() = False
        'PoolingDGV.Columns.Item("ID").Width = 15
        'PoolingDGV.Columns.Item("Principal").Width = 160
        'PoolingDGV.Columns.Item("Date Applied").Width = 30
        'PoolingDGV.Columns.Item("Source").Width = 40
        'PoolingDGV.Columns.Item("Rank").Width = 30
        'PoolingDGV.Columns.Item("Experience").Width = 60
        'PoolingDGV.Columns.Item("Status").Width = 30
        PoolingDGV.Columns.Item("Name").Width = 250
        'PoolingDGV.Columns.Item("Birthday").Width = 30
        'PoolingDGV.Columns.Item("Age").Width = 60
        'PoolingDGV.Columns.Item("Contact No").Width = 30
        'PoolingDGV.Columns.Item("Remarks").Width = 40
        PoolingDGV.Columns.Item("Officers Remarks").Width = 400

        PoolingDGV.ScrollBars = ScrollBars.Both
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If


    End Sub

    Private Sub Closebtn_Click(sender As Object, e As EventArgs) Handles Closebtn.Click
        Me.Close()
        MainForm.Show()

    End Sub

    Private Sub BunifuImageButton3_Click(sender As Object, e As EventArgs) Handles BunifuImageButton3.Click
        Me.Close()
        MainForm.Show()
    End Sub





    Private dateTimePicker1 As DateTimePicker
    Private dateTimePicker2 As DateTimePicker

    Private Sub DateTimePickerChange1(ByVal sender As Object, ByVal e As EventArgs)
        PoolingDGV.CurrentCell.Value = dateTimePicker1.Text.ToString()
    End Sub
    Private Sub DateTimePickerClose1(ByVal sender As Object, ByVal e As EventArgs)
        dateTimePicker1.Visible = False
    End Sub
    Private Sub DateTimePickerChange2(ByVal sender As Object, ByVal e As EventArgs)
        PoolingDGV.CurrentCell.Value = dateTimePicker2.Text.ToString()
    End Sub
    Private Sub DateTimePickerClose2(ByVal sender As Object, ByVal e As EventArgs)
        dateTimePicker2.Visible = False
    End Sub

    Private Sub PoolingDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles PoolingDGV.CellClick

        If e.ColumnIndex = 3 Then
            dateTimePicker1 = New DateTimePicker()
            PoolingDGV.Controls.Add(dateTimePicker1)
            dateTimePicker1.Format = DateTimePickerFormat.Short
            Dim oRectangle As Rectangle = PoolingDGV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            dateTimePicker1.Size = New Size(oRectangle.Width, oRectangle.Height)
            dateTimePicker1.Location = New Point(oRectangle.X, oRectangle.Y)
            AddHandler dateTimePicker1.TextChanged, AddressOf DateTimePickerChange1
            AddHandler dateTimePicker1.CloseUp, AddressOf DateTimePickerClose1
        End If
        If e.ColumnIndex = 12 Then
            dateTimePicker2 = New DateTimePicker()
            PoolingDGV.Controls.Add(dateTimePicker2)
            dateTimePicker2.Format = DateTimePickerFormat.Short
            Dim oRectangle As Rectangle = PoolingDGV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            dateTimePicker2.Size = New Size(oRectangle.Width, oRectangle.Height)
            dateTimePicker2.Location = New Point(oRectangle.X, oRectangle.Y)
            AddHandler dateTimePicker2.TextChanged, AddressOf DateTimePickerChange2
            AddHandler dateTimePicker2.CloseUp, AddressOf DateTimePickerClose2
        End If
    End Sub

    Private Sub PoolingDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles PoolingDGV.CellContentClick
        If (e.RowIndex >= 0) Then


            AppIDIdentifier.Text = PoolingDGV.Rows.Item(e.RowIndex).Cells(0).Value
            GetAppID = PoolingDGV.Rows.Item(e.RowIndex).Cells(0).Value
            PoolName = PoolingDGV.Rows.Item(e.RowIndex).Cells(8).Value
        ElseIf e.RowIndex <> -1 Then

        End If



    End Sub

    Private Sub PoolingDGV_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles PoolingDGV.ColumnHeaderMouseClick
        For i = 0 To PoolingDGV.Rows.Count - 1
            Dim r As DataGridViewRow = PoolingDGV.Rows(i)
            r.Height = 31
        Next
    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub pool()

        'INSERTING SHIPBOARD Expi
        Dim updateDataStr As String

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'selecser


        'Query for count row of POOLS
        Dim poolstr As String
        poolstr = "SELECT ai.App_ID as 'ID', sc.App_AssignedPrincipal as 'Principal',  sc.App_DateApplied as 'Date Applied',sc.App_DateReported as 'Date Reported', sc.App_Source as 'Source', sc.App_RankApplied as 'Rank', sc.App_Experience  as 'Experience',ai.App_Pool as 'Status',
 CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Name', ai.App_Bday as 'Birthday',  YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'Age', ai.App_ContactNo as 'Contact No', sc.App_DateLastCalled as 'Last Called', sc.App_Availability as 'Availability', sc.Reps_Endorser as 'Endorser' ,sc.App_Remarks as 'Officer Remarks'
FROM hunters_pooling.applicant_info ai
LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID =sc.App_ID WHERE ai.App_ID = '" & GetAppID & "' ;"
        Dim Poolcommand As OdbcCommand
        Poolcommand = New OdbcCommand(poolstr, conn)
        Dim PoolmyReader As OdbcDataReader = Poolcommand.ExecuteReader()
        Dim poolcounter As String
        If PoolmyReader.Read Then
            poolcounter = PoolmyReader.GetInt32(0)
        End If
        Dim i As Integer = PoolingDGV.Rows.Count - 1

        If i = poolcounter Then

            'Pareho yung count ng nasa Database sa Datagridview.rows.count
            MsgBox("No Changes Made")

        Else

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            ' AppIDIdentifier.Text = PoolingDGV.Rows.Item(e.RowIndex).Cells(0).Value
            '
            '    MessageBox.Show((PoolingDGV.Rows.Cells(12).Value.Date).ToShortDateString)

            '   MessageBox.Show(PoolingDGV.Rows.Item(e.RowIndex).Cells(0).Value.ToString)
            For ctr As Integer = poolcounter To PoolingDGV.Rows.Count - 2 Step +1


                'MessageBox.Show(PoolingDGV.Rows(ctr).Cells(12).Value.Date)
                MessageBox.Show((PoolingDGV.Rows(ctr).Cells(12).Value.Date).ToShortDateString)
                '    SBDGView.Rows(ctr).Cells(10).Value.Date).ToShortDateString


            Next

            MessageBox.Show("The Data has been Inserted")

        End If

        If conn.State = ConnectionState.Closed Then
            conn.Close()
        End If

    End Sub

    Private Sub PoolSaveBtn_Click(sender As Object, e As EventArgs)


        pool()



    End Sub

    Private Sub PoolingDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles PoolingDGV.CellDoubleClick
        If (e.RowIndex >= 0) Then

            Dim OBJ As New PoolUpdate
            OBJ.GetAppID = AppIDIdentifier.Text
            OBJ.UserText = App_Endorser.Text
            OBJ.PoolName1 = PoolName

            OBJ.Show()



        ElseIf e.RowIndex <> -1 Then
        End If
    End Sub

    Private Sub App_Endorser_Click(sender As Object, e As EventArgs) Handles App_Endorser.Click

    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If



        Dim PoolingList As String
        PoolingList = "SELECT ai.App_ID as 'ID', sc.App_AssignedPrincipal as 'Principal',  sc.App_DateApplied as 'Date Applied',sc.App_DateReported as 'Date Reported', sc.App_Source as 'Source', sc.App_RankApplied as 'Rank', sc.App_Experience  as 'Experience',ai.App_Pool as 'Status',
 CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname,' ', App_Suffix) AS 'Name', ai.App_Bday as 'Birthday',  YEAR(CURDATE()) - YEAR(ai.App_Bday) AS 'Age', ai.App_ContactNo as 'Contact No', sc.App_DateLastCalled as 'Last Called', sc.App_Availability as 'Availability',sc.Reps_Endorser as 'Called By', sc.App_Remarks as 'Officers Remarks'
FROM hunters_pooling.applicant_info ai 
LEFT JOIN hunters_pooling.applicant_screening sc ON ai.App_ID =sc.App_ID where ai.App_Pool ='Pooling'  and ai.App_LName LIKE '%" & applicantName.Text & "%' OR ai.App_FName LIKE '%" & applicantName.Text & "%' OR ai.App_MName LIKE '%" & applicantName.Text & "%'; "

        Dim dvPoolingList As New DataTable("applicant_pooling")
        Dim PoolingAdapter As New Odbc.OdbcDataAdapter(PoolingList, conn)
        PoolingAdapter.Fill(dvPoolingList)
        PoolingDGV.DataSource = dvPoolingList
        PoolingAdapter.Dispose()



        For i = 0 To PoolingDGV.Rows.Count - 1
            Dim r As DataGridViewRow = PoolingDGV.Rows(i)
            r.Height = 31
        Next
        PoolingDGV.Columns("ID").Visible() = False
        'PoolingDGV.Columns.Item("ID").Width = 15
        'PoolingDGV.Columns.Item("Principal").Width = 160
        'PoolingDGV.Columns.Item("Date Applied").Width = 30
        'PoolingDGV.Columns.Item("Source").Width = 40
        'PoolingDGV.Columns.Item("Rank").Width = 30
        'PoolingDGV.Columns.Item("Experience").Width = 60
        'PoolingDGV.Columns.Item("Status").Width = 30
        PoolingDGV.Columns.Item("Name").Width = 250
        'PoolingDGV.Columns.Item("Birthday").Width = 30
        'PoolingDGV.Columns.Item("Age").Width = 60
        'PoolingDGV.Columns.Item("Contact No").Width = 30
        'PoolingDGV.Columns.Item("Remarks").Width = 40
        PoolingDGV.Columns.Item("Officers Remarks").Width = 400

        PoolingDGV.ScrollBars = ScrollBars.Both
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If






        conn.Close()
    End Sub
End Class