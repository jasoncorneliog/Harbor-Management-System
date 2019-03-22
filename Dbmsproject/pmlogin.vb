Imports MySql.Data.MySqlClient
Public Class pmlogin
    Dim MysqlConn As MySqlConnection
    Dim command As MySqlCommand
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "22" And TextBox2.Text = "mumbai") Then
            p1main.Show()
            Me.Hide()

        ElseIf (TextBox1.Text = "33" And TextBox2.Text = "kolkata") Then
            p2main.Show()
            Me.Hide()
        ElseIf (TextBox1.Text = "44" And TextBox2.Text = "chennai") Then
            p3main.Show()
            Me.Hide()
        Else
            MessageBox.Show("Incorrect Username or password")
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub pmlogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to quit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()
        End If
    End Sub

    Public Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Public Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub pmlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class