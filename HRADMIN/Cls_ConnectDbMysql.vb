Imports MySql.Data.MySqlClient
Public Class Cls_ConnectDbMysql
    Public Sub ConnectDBMySql(ByRef iConnection As MySqlConnection)
        'iConnection = New MySqlConnection
        iConnection.ConnectionString = "server=" & iServerName & ";" _
                                    & "user id=" & iUserName & ";" _
                                    & "password=" & iPass & ";" _
                                    & "database=" & iTableName & ";CharSet=utf8"

        'iConnection.ConnectionString = "server=" & iServerName & ";" _
        '                       & "user id=" & iUserName & ";" _
        '                       & "password=" & iPass & ";" _
        '                       & "database=" & iTableName & "; Convert Zero Datetime=True "
    End Sub

    Public Sub ConnectDBMySql_Smart(ByRef iConnection As MySqlConnection)
        'iConnection = New MySqlConnection
        iConnection.ConnectionString = "server=" & Smart_iServerName & ";" _
                                    & "user id=" & Smart_iUserName & ";" _
                                    & "password=" & Smart_iPass & ";" _
                                    & "database=" & Smart_iTableName & ";CharSet=utf8"
    End Sub
End Class
