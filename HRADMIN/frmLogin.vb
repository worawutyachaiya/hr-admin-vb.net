Imports MySql.Data.MySqlClient

Public Partial Class frmLogin

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim empCode As String = UCase(Trim(txtEmpCode.Text))
        Dim password As String = Trim(txtPassword.Text)

        If empCode = "" Or password = "" Then
            MsgBox("Please insert Emp.Code and Password.")
            Exit Sub
        End If

        If ValidateLogin(empCode, password) Then
            CurrentUserId = empCode
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Emp.Code or Password is incorrect.")
            txtPassword.Text = ""
            txtPassword.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub txtEmpCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Function ValidateLogin(empCode As String, password As String) As Boolean
        Dim hashedPassword As String = New Cls_FcnEncodMD5().EncodePasswordMD5(password)

        Try
            SetAllConnectionDB()
            CheckConnection(Connection)

            Using command As New MySqlCommand("SELECT empCode FROM member WHERE empCode = @empCode AND empPass = @empPass AND empcode_resign IS NULL LIMIT 1", Connection)
                command.Parameters.AddWithValue("@empCode", empCode)
                command.Parameters.AddWithValue("@empPass", hashedPassword)

                Using reader As MySqlDataReader = command.ExecuteReader()
                    Return reader.Read()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Cannot login: " & ex.Message)
            Return False
        Finally
            If Not Connection Is Nothing AndAlso Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Function

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class