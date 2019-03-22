﻿Imports MySql.Data.MySqlClient

Public Class aroute
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim gender As String
    Private Sub aroute_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        load_table()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        If (TextBox1.Text.Trim.Length > 0 And TextBox2.Text.Trim.Length > 0 And TextBox3.Text.Trim.Length > 0 And TextBox4.Text.Trim.Length > 0 And TextBox5.Text.Trim.Length > 0 And TextBox6.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "insert into harbour.route values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Saved")

                MysqlConn.Close()


            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()



            End Try
        Else
            MessageBox.Show("Wrong value")
        End If
        load_table()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        If (TextBox1.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "delete from harbour.route where route_id='" & TextBox1.Text & "'"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Deleted")
                MysqlConn.Close()


            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()



            End Try
        Else
            MessageBox.Show("Wrong or NULL value")
        End If
        load_table()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        If (TextBox1.Text.Trim.Length > 0 And TextBox2.Text.Trim.Length > 0 And TextBox3.Text.Trim.Length > 0 And TextBox4.Text.Trim.Length > 0 And TextBox5.Text.Trim.Length > 0 And TextBox6.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "update harbour.route set route_id='" & TextBox1.Text & "',source_name='" & TextBox2.Text & "',destination_id='" & TextBox3.Text & "',departure_time='" & TextBox4.Text & "',arrival_time='" & TextBox5.Text & "',travel_time='" & TextBox6.Text & "' where route_id='" & TextBox1.Text & "'"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Saved")
                MysqlConn.Close()


            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()



            End Try
        Else
            MessageBox.Show("Wrong or NULL value")
        End If
        load_table()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("Route ID").Value.ToString
            TextBox2.Text = row.Cells("Source").Value.ToString
            TextBox3.Text = row.Cells("Destination").Value.ToString
            TextBox4.Text = row.Cells("Departure Time").Value.ToString
            TextBox5.Text = row.Cells("Arrival Time").Value.ToString
            TextBox6.Text = row.Cells("Travel Days").Value.ToString

        End If
    End Sub
    Private Sub load_table()
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim SDA As New MySqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bsource As New BindingSource
        Try
            MysqlConn.Open()
            Dim Query As String
            Query = "select route_id as 'Route ID',source_name as 'Source',destination_id as 'Destination',departure_time as 'Departure Time',arrival_time as 'Arrival Time',travel_time as 'Travel Days' from harbour.route"
            COMMAND = New MySqlCommand(Query, MysqlConn)
            SDA.SelectCommand = COMMAND
            SDA.Fill(dbDataSet)
            bsource.DataSource = dbDataSet
            DataGridView1.DataSource = bsource
            SDA.Update(dbDataSet)
            MysqlConn.Close()


        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()



        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        amain.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        Me.Hide()
    End Sub

    Private Sub aroute_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to quit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label10.Text = Date.Now.ToString("dd-MM-yyyy hh:mm:ss")
    End Sub
End Class