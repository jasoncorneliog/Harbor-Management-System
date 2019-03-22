Imports MySql.Data.MySqlClient
Public Class p2pack
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim shi As String
    Dim pid As String
    Dim occ As Integer
    Dim max As Integer
    Dim free As Integer
    Private Sub p2pack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        load_table()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

       shi = TextBox5.Text
        pid = TextBox1.Text
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        Dim READER As MySqlDataReader
        Try
            MysqlConn.Open()

            Dim Query1 As String
            Query1 = "select * from harbour.ship where ship_id='" & shi & "' "
            COMMAND = New MySqlCommand(Query1, MysqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                occ = READER.GetString("occupied_capacity")
                max = READER.GetString("max_capacity")
            End While
            MysqlConn.Close()


        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()

        End Try

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
        "server=localhost;userid=root;password=root;database=harbour"
        If (TextBox1.Text.Trim.Length > 0 And TextBox4.Text.Trim.Length > 0 And TextBox5.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()



                occ = occ + TextBox4.Text

                If (max < occ) Then
                    MessageBox.Show("Exceeding")
                    Me.Show()


                Else
                    free = max - occ

                    Dim Query2 As String
                    Query2 = "update harbour.ship set occupied_capacity='" & occ & "',free_capacity='" & free & "' where ship_id= '" & shi & "' "
                    COMMAND = New MySqlCommand(Query2, MysqlConn)
                    READER = COMMAND.ExecuteReader
                    load_table()
                    MysqlConn.Close()

                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()

            End Try



            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString =
            "server=localhost;userid=root;password=root;database=harbour"


            Try
                MysqlConn.Open()


                If (max >= occ) Then
                    Dim Query As String
                    Query = "insert into harbour.package values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
                    COMMAND = New MySqlCommand(Query, MysqlConn)
                    READER = COMMAND.ExecuteReader
                    MessageBox.Show("Data Saved")

                    MysqlConn.Close()
                End If

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
            Query = "select package_id as 'Package ID',owner_name as 'Owner Name',owner_phone as 'Phone no',package_weight as 'Weight',package_ship_id as 'Ship ID'  from harbour.package,harbour.ship where port_identity=33 and package_ship_id=ship_id"
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
                Query = "delete from harbour.package where package_id='" & TextBox1.Text & "'"
                COMMAND = New MySqlCommand(Query, MysqlConn)
                READER = COMMAND.ExecuteReader
                MessageBox.Show("Data Deleted")
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()



            End Try
        Else
            MessageBox.Show("Wrong or NULL values")
        End If


                shi = TextBox5.Text
                pid = TextBox1.Text
                MysqlConn = New MySqlConnection
                MysqlConn.ConnectionString =
                "server=localhost;userid=root;password=root;database=harbour"
        If (TextBox1.Text.Trim.Length > 0 And TextBox4.Text.Trim.Length > 0 And TextBox5.Text.Trim.Length > 0) Then
            Try
                MysqlConn.Open()

                Dim Query1 As String
                Query1 = "select * from harbour.ship where ship_id='" & shi & "' "
                COMMAND = New MySqlCommand(Query1, MysqlConn)
                READER = COMMAND.ExecuteReader
                While READER.Read
                    occ = READER.GetString("occupied_capacity")
                    max = READER.GetString("max_capacity")
                End While
                MysqlConn.Close()


            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()

            End Try

            MysqlConn = New MySqlConnection
            MysqlConn.ConnectionString =
            "server=localhost;userid=root;password=root;database=harbour"

            Try
                MysqlConn.Open()



                occ = occ - TextBox4.Text

                If (max < occ) Then
                    MessageBox.Show("Exceeding")
                    Me.Show()


                Else
                    free = max - occ

                    Dim Query2 As String
                    Query2 = "update harbour.ship set occupied_capacity='" & occ & "',free_capacity='" & free & "' where ship_id= '" & shi & "' "
                    COMMAND = New MySqlCommand(Query2, MysqlConn)
                    READER = COMMAND.ExecuteReader
                    load_table()
                    MysqlConn.Close()

                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                MysqlConn.Dispose()

            End Try
            MysqlConn.Close()

        Else
            MessageBox.Show("Wrong or NULL values")
        End If


        load_table()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("Package ID").Value.ToString
            TextBox2.Text = row.Cells("Owner Name").Value.ToString
            TextBox3.Text = row.Cells("Phone no").Value.ToString
            TextBox4.Text = row.Cells("Weight").Value.ToString
            TextBox5.Text = row.Cells("Ship ID").Value.ToString

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        p2main.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        Me.Hide()
    End Sub

    Private Sub p2pack_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to quit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label13.Text = Date.Now.ToString("dd-MM-yyyy hh:mm:ss")
    End Sub
End Class