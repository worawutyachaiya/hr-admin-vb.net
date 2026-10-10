Imports System.IO

Public Class Cls_GetFilesInFloder

    Public Function fcnGetFilesInFloder(PathFile As String, empCode As String) As Boolean
        Dim di As New DirectoryInfo(PathFile)
        ' Get a reference to each file in that directory.
        Dim fiArr As FileInfo() = di.GetFiles()
        ' Display the names of the files.
        Dim fri As FileInfo
        Dim valueReturn As Boolean = False


        Dim Data As String()
        For Each fri In fiArr
            Data = fri.Name.Split("-")
            If Data(0) = empCode Then
                Kill(PathFile & "\" & fri.Name)
                valueReturn = True
            End If
            Array.Clear(Data, 0, Data.Length)
        Next fri
        Return valueReturn
    End Function
End Class
