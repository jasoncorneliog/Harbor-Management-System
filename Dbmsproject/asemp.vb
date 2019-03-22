Imports MySql.Data.MySqlClient
Public Class asemp
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim gender As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        If (TextBox1.Text.Trim.Length > 0 And TextBox2.Text.Trim.Length > 0 And DateTimePicker1.Text.Trim.Length > 0 And TextBox4.Text.Trim.Length > 0 And TextBox6.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String

                Query = "insert into harbour.ship_emp values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker1.Text & "','" & gender & "','" & TextBox6.Text & "','" & TextBox4.Text & "')"
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

            TextBox1.Text = row.Cells("Name").Value.ToString
            TextBox2.Text = row.Cells("SSN").Value.ToString
            DateTimePicker1.Text = row.Cells("DOB").Value.ToString
            TextBox6.Text = row.Cells("Job").Value.ToString
            TextBox4.Text = row.Cells("Ship ID").Value.ToString



               

        End If
    End Sub

    Private Sub asemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        load_table()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        If (TextBox2.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "delete from harbour.ship_emp where semp_ssn='" & TextBox2.Text & "'"
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
        If (TextBox1.Text.Trim.Length > 0 And TextBox2.Text.Trim.Length > 0 And DateTimePicker1.Text.Trim.Length > 0 And TextBox4.Text.Trim.Length > 0 And TextBox6.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "update harbour.ship_emp set semp_name='" & TextBox1.Text & "',semp_ssn='" & TextBox2.Text & "',semp_dob='" & DateTimePicker1.Text & "',semp_sex='" & gender & "',semp_designation='" & TextBox6.Text & "',working_ship_id='" & TextBox4.Text & "' where semp_ssn='" & TextBox2.Text & "'"
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
            Query = "select semp_name as 'Name',semp_ssn as 'SSN',semp_dob as 'DOB',semp_sex as 'Gender',semp_designation as 'Job',working_ship_id as 'Ship ID'from harbour.ship_emp"
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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        gender = "Male"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        gender = "Female"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        amain.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        TextBox4.Text = ""
        Me.Hide()

    End Sub

    Private Sub asemp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to quit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox6.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label10.Text = Date.Now.ToString("dd-MM-yyyy hh:mm:ss")
    End Sub
End Class