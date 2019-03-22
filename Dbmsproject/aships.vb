Imports MySql.Data.MySqlClient

Public Class aships
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim shippy As String
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        If (TextBox1.Text.Trim.Length > 0 And TextBox2.Text.Trim.Length > 0 And TextBox3.Text.Trim.Length > 0 And TextBox4.Text.Trim.Length > 0 And TextBox5.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "update harbour.ship set ship_id='" & TextBox1.Text & "',ship_name='" & TextBox2.Text & "',source='" & TextBox3.Text & "',destination='" & TextBox4.Text & "',max_capacity='" & TextBox5.Text & "',occupied_capacity='" & TextBox6.Text & "',free_capacity='" & TextBox7.Text & "' ,ship_status='" & shippy & "',route_identity='" & TextBox8.Text & "',port_identity='" & TextBox9.Text & "'where ship_id='" & TextBox1.Text & "'"
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

    Private Sub aships_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        load_table()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        If (TextBox1.Text.Trim.Length > 0 And TextBox2.Text.Trim.Length > 0 And TextBox3.Text.Trim.Length > 0 And TextBox4.Text.Trim.Length > 0 And TextBox5.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "insert into harbour.ship values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & shippy & "','" & TextBox8.Text & "','" & TextBox9.Text & "')"
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
            Query = "select ship_id as 'Ship ID',ship_name as 'Ship Name',source as 'Source',destination as 'Destination',max_capacity as 'Max Capacity',occupied_capacity as 'Occupied Capacity',free_capacity as 'Free Capacity',ship_status as 'Status',route_identity as 'Route ID',port_identity as 'Port ID' from harbour.ship"
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        If (TextBox1.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()
                Dim Query As String
                Query = "delete from harbour.ship where ship_id='" & TextBox1.Text & "'"
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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        shippy = "Sailing"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        shippy = "Docked"
    End Sub

    

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        amain.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        Me.Hide()
    End Sub

    Private Sub aships_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label13.Text = Date.Now.ToString("dd-MM-yyyy hh:mm:ss")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        load_table()
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("Ship ID").Value.ToString
            TextBox2.Text = row.Cells("Ship Name").Value.ToString
            TextBox3.Text = row.Cells("Source").Value.ToString
            TextBox4.Text = row.Cells("Destination").Value.ToString
            TextBox5.Text = row.Cells("Max Capacity").Value.ToString
            TextBox6.Text = row.Cells("Occupied Capacity").Value.ToString
            TextBox7.Text = row.Cells("Free Capacity").Value.ToString
            TextBox8.Text = row.Cells("Route ID").Value.ToString
            TextBox9.Text = row.Cells("Port ID").Value.ToString

        End If
    End Sub
End Class