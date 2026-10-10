Public Class Cls_SQLDateFormat

    Public Function SQLDateFormat(ByVal dt As Date) As String
        ' dt.Year จะเป็นปี ค.ศ. เสมอ ไม่ว่า Regional Setting จะเป็นอะไรก็ตาม
        Return dt.Year.ToString + dt.ToString("-MM-dd")
    End Function
End Class
