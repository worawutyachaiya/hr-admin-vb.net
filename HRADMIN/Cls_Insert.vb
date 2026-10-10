Imports MySql.Data.MySqlClient

Public Class Cls_Insert
    Private sqlCommand As MySqlCommand

    Public Sub Insert(iConnection As MySqlConnection, strQ As String)
        CheckConnection(iConnection)
        sqlCommand = New MySqlCommand(strQ, iConnection)
        sqlCommand.ExecuteNonQuery()
        iConnection.Close()
        iConnection = Nothing
    End Sub

    Public Function ExecuteTransaction(iConnection As MySqlConnection, queries As List(Of String)) As Boolean
        Dim transaction As MySqlTransaction = Nothing

        Try
            CheckConnection(iConnection)
            transaction = iConnection.BeginTransaction()

            For Each strQ As String In queries
                Using command As New MySqlCommand(strQ, iConnection, transaction)
                    command.ExecuteNonQuery()
                End Using
            Next

            transaction.Commit()
            Return True
        Catch ex As Exception
            Dim errorMessage As String = ex.Message

            If Not transaction Is Nothing Then
                Try
                    transaction.Rollback()
                Catch rollbackEx As Exception
                    errorMessage = errorMessage & " | Rollback failed: " & rollbackEx.Message
                End Try
            End If

            MessageBox.Show("Transaction failed: " & errorMessage)
            Return False
        Finally
            If Not transaction Is Nothing Then
                transaction.Dispose()
            End If

            If Not iConnection Is Nothing AndAlso iConnection.State = ConnectionState.Open Then
                iConnection.Close()
            End If
        End Try
    End Function
End Class
