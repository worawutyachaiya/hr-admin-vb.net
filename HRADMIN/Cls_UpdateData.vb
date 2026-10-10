Imports MySql.Data.MySqlClient
Public Class Cls_UpdateData
    Private sqlCommand As MySqlCommand
    Public Overloads Sub Update(iConnection As MySqlConnection, strQ As String)

        CheckConnection(iConnection)
        sqlCommand = New MySqlCommand(strQ, iConnection)
        sqlCommand.ExecuteNonQuery()
        iConnection.Close()
        iConnection = Nothing
    End Sub
End Class
