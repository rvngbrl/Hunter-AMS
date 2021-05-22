Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Data
Imports System.Data.Odbc
Imports Bunifu
Imports BunifuAnimatorNS
Imports System.Globalization

Public Class Login_Form

    Dim conn As OdbcConnection

    Private Sub MainForm_Closed(sender As Object, e As CancelEventArgs) Handles Me.Closed
        conn.Close()
        Windows.Forms.Application.Exit()
        Windows.Forms.Application.ExitThread()
    End Sub

    Private Sub Login_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Computer.Network.Ping("192.168.11.3", 2000) Then
            MsgBox("Crystal Office")
            conn = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=192.168.11.3;uid=crystal_admin;")
        Else
            MsgBox("Crystal Remote")
            conn = New OdbcConnection("Dsn=csi_accounting;database=csiaccountingdb;port=3306;server=25.30.157.108;uid=crystal_admin;")
        End If



        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim applicantList As String
        applicantList = " SELECT CONCAT(ai.App_LName, ', ',ai.App_FName,' ', ai.App_Mname) AS 'Applicant Name',  
                        ai.App_PositionApplied AS 'Position' FROM web.applicant_info ai
                          Left Join web.applicant_stat ap ON ai.App_ID=ap.App_onlineID WHERE ai.App_Status ='APPLICANT' 
                          and  ap.App_Status is null and ai.App_DateApplied = '" & Date.Today.ToString("yyyy-MM-dd") & "' ORDER BY App_DateApplied desc;"



        Dim dvappList As New DataTable("sched_names")
        Dim rssechedule As New Odbc.OdbcDataAdapter(applicantList, conn)
        rssechedule.Fill(dvappList)
        ApplicantsDGV.DataSource = dvappList
        rssechedule.Dispose()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

    End Sub



    Private Sub LoginbBtn_Click(sender As Object, e As EventArgs) Handles LoginbBtn.Click

        If Len(Trim(UsernameBox.Text)) = 0 Then
            MessageBox.Show("Please enter Username", "Input Error", MessageBoxButtons.OK)
            UsernameBox.Focus()
            Exit Sub
        End If

        If Len(Trim(PasswordBox.Text)) = 0 Then
            MessageBox.Show("Please enter Password", "Input Error", MessageBoxButtons.OK)
            PasswordBox.Focus()
            Exit Sub
        End If

        Try
            Dim str As String
            str = ("SELECT * FROM csi_user WHERE User_Name = '" & UsernameBox.Text & "' AND User_Password = '" & PasswordBox.Text & "'")
            Dim command As OdbcCommand
            command = New OdbcCommand(str, conn)
            conn.Open()
            Dim myReader As OdbcDataReader = command.ExecuteReader()
            Dim Login As Object = 0
            Dim OBJ As New MainForm

            OBJ.myacc = UsernameBox.Text
            'OBJ1.username = UsernameBox.Text

            If myReader.HasRows Then
                myReader.Read()
                Login = myReader(Login)

            End If

            If Login = Nothing Then
                MsgBox("Login Failed. Try again!", MsgBoxStyle.Critical, "Login Denied")
                UsernameBox.Focus()
            Else
                MsgBox("Successfully Login", MsgBoxStyle.Information)
                UsernameBox.Text = ""
                PasswordBox.Text = ""
                Me.Hide()
                OBJ.Show()
            End If
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            conn.Close()
        End Try
        conn.Close()
    End Sub



    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        conn.Close()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        Windows.Forms.Application.Exit()
        Windows.Forms.Application.ExitThread()
    End Sub

    Private Sub AppLinkBtn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles AppLinkBtn.LinkClicked

        Me.Hide()
        PoolApplicants.Show()

    End Sub

    Private Sub PasswordBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PasswordBox.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then

            If Len(Trim(UsernameBox.Text)) = 0 Then
                MessageBox.Show("Please enter Username", "Input Error", MessageBoxButtons.OK)
                UsernameBox.Focus()
                Exit Sub
            End If

            If Len(Trim(PasswordBox.Text)) = 0 Then
                MessageBox.Show("Please enter Password", "Input Error", MessageBoxButtons.OK)
                PasswordBox.Focus()
                Exit Sub
            End If

            Try
                Dim str As String
                str = ("SELECT * FROM csi_user WHERE User_Name = '" & UsernameBox.Text & "' AND User_Password = '" & PasswordBox.Text & "'")
                Dim command As OdbcCommand
                command = New OdbcCommand(str, conn)
                conn.Open()
                Dim myReader As OdbcDataReader = command.ExecuteReader()
                Dim Login As Object = 0
                Dim OBJ As New MainForm

                OBJ.myacc = UsernameBox.Text
                'OBJ1.username = UsernameBox.Text

                If myReader.HasRows Then
                    myReader.Read()
                    Login = myReader(Login)

                End If

                If Login = Nothing Then
                    MsgBox("Login Failed. Try again!", MsgBoxStyle.Critical, "Login Denied")
                    UsernameBox.Focus()
                Else
                    MsgBox("Successfully Login", MsgBoxStyle.Information)
                    UsernameBox.Text = ""
                    PasswordBox.Text = ""
                    Me.Hide()
                    OBJ.Show()
                End If
                conn.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                conn.Close()
            End Try
            conn.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ConctionBtn.Click
        Dim myValue As String = InputBox("Enter Value", "Enter Value", "Please Enter Value")
    End Sub



    Private Sub PasswordBox_Click(sender As Object, e As EventArgs) Handles PasswordBox.Click
        PasswordBox.ResetText()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
