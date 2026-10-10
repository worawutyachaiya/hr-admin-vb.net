Module Mo2_Fcn
    Public Function fcnConvertDate(ByVal strDate As String) As String
        Dim iDate As String = Left(strDate, 2)
        Dim iMonth As String = Mid(strDate, 4, 3)
        Dim iYear As String = Right(strDate, 4)
        Select Case iMonth
            Case "Jan" : iMonth = "01"
            Case "Feb" : iMonth = "02"
            Case "Mar" : iMonth = "03"
            Case "Apr" : iMonth = "04"
            Case "May" : iMonth = "05"
            Case "Jun" : iMonth = "06"
            Case "Jul" : iMonth = "07"
            Case "Aug" : iMonth = "08"
            Case "Sep" : iMonth = "09"
            Case "Oct" : iMonth = "10"
            Case "Nov" : iMonth = "11"
            Case "Dec" : iMonth = "12"
        End Select

        Return iYear & "-" & iMonth & "-" & iDate
    End Function
End Module
