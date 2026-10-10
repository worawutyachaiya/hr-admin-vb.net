Public Class Cls_ExcelV2
    Inherits Cls_Excel
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ArrayData">Array of data</param>
    ''' <param name="SheetName">Sheetname of your file Example "Sheet1"</param>
    ''' <param name="RangeStart">Fisrt range to start Example "A1"</param>
    ''' <param name="RangeSpecialValue">RangeSpecialValue is Insert some value in this range</param>
    ''' <remarks></remarks>
    Public Overloads Sub ExportExcel(ArrayData(,) As String, SheetName As String, RangeStart As String, Optional RangeSpecialValue As String = "")

        xlApp = New Microsoft.Office.Interop.Excel.Application
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkBook = xlApp.Workbooks.Add(PahtMaster)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        xlRange = xlWorkSheet.Range("A4")

        If RangeSpecialValue <> "" Then
            xlWorkSheet.Range("A2").Value = "สถิติการลาในช่วง " & Format(frmSummary.DateStart.Value, "dd-MM-yyyy") & " - " & Format(frmSummary.DateFinish.Value, "dd-MM-yyyy")
        End If
        For i = 0 To ArrayData.Length - 1
            Dim Data As String = Convert.ToString(ArrayData(i, 0))
            If Data = "" Then
                Exit For
            End If
            xlRange.Offset(i, 0).Value = ArrayData(i, 0).ToString
            xlRange.Offset(i, 1).Value = ArrayData(i, 1).ToString
            xlRange.Offset(i, 2).Value = ArrayData(i, 2).ToString
            xlRange.Offset(i, 3).Value = ArrayData(i, 3).ToString
            xlRange.Offset(i, 4).Value = ArrayData(i, 4).ToString
            xlRange.Offset(i, 5).Value = ArrayData(i, 5).ToString
            xlRange.Offset(i, 6).Value = ArrayData(i, 6).ToString
            xlRange.Offset(i, 7).Value = ArrayData(i, 7).ToString
            xlRange.Offset(i, 8).Value = ArrayData(i, 8).ToString
            xlRange.Offset(i, 9).Value = ArrayData(i, 9).ToString
            xlRange.Offset(i, 10).Value = ArrayData(i, 10).ToString
            xlRange.Offset(i, 11).Value = ArrayData(i, 11).ToString
            xlRange.Offset(i, 12).Value = ArrayData(i, 12).ToString
        Next
        System.IO.File.Delete(PathReport)
        xlWorkSheet.SaveAs(PathReport)
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub
End Class
