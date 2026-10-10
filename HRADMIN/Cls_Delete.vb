
Imports MySql.Data.MySqlClient
Public Class Cls_Delete
    Private sqlCommand As MySqlCommand
    Public Sub fcnDelete(iConnection As MySqlConnection, strQ As String)
        CheckConnection(iConnection)
        sqlCommand = New MySqlCommand(strQ, iConnection)
        sqlCommand.ExecuteNonQuery()
        iConnection.Close()
        iConnection = Nothing
    End Sub
End Class
