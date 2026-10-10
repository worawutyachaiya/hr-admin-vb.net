Imports MySql.Data.MySqlClient
Public Class Cls_GetAttachment

    Public Overloads Function GetAttachment(ByVal i_Connection As MySqlConnection, ByRef iGridview As DataGridView, strQ As String) As Boolean

        Dim countRow As Integer = 0
        Dim Da As MySqlDataAdapter
        Dim Dt As DataTable

        'Connection.Open()
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            For Each recode In Dt.Rows
                Return True
                Exit Function
            Next
        End If
        Return False
    End Function


    Public Overloads Function GetAttachment(ByVal i_Connection As MySqlConnection, ByRef FilesNameAttachment As String, strQ As String) As Boolean


        Dim Da As MySqlDataAdapter
        Dim Dt As DataTable

        'Connection.Open()
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            For Each recode In Dt.Rows
                FilesNameAttachment = recode("FilesName")
                Return True
                Exit Function
            Next
        End If
        Return False
    End Function
End Class
