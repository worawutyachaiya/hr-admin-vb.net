Imports System.Security.Cryptography
Imports System.Text
Public Class Cls_FcnEncodMD5

    Public Function EncodePasswordMD5(strString As String) As String
        Dim ASCIIenc As New ASCIIEncoding
        Dim strReturn As String = ""
        Dim ByteSourceText() As Byte = ASCIIenc.GetBytes(strString)
        Dim Md5Hash As New MD5CryptoServiceProvider
        Dim ByteHash() As Byte = Md5Hash.ComputeHash(ByteSourceText)
        For Each b As Byte In ByteHash
            strReturn = strReturn & b.ToString("x2")
        Next b

        Return strReturn
    End Function
End Class
