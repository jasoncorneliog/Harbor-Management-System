Imports MySql.Data.MySqlClient
Public Class p3semp
    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim gender As String
    Private Sub p3semp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
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
            Query = "select distinct semp_ssn as 'SSN',semp_name as 'Name',semp_dob as 'DOB',semp_sex as 'Gender',semp_designation as 'Designation',working_ship_id as 'Ship ID' from harbour.ship_emp,harbour.ship,harbour.port where working_ship_id=ship_id and port_identity=44"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        load_table()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        p3ship.Show()
        Me.Hide()
    End Sub

    Private Sub p3semp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to quit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label13.Text = Date.Now.ToString("dd-MM-yyyy hh:mm:ss")
    End Sub
End Class