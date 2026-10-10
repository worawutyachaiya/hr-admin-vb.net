Public Class frmExportRemainLeave

    Dim ClsSetDateTimeFormat As New Cls_SetDateTimerPickerformat
    Dim ClsSQLDateFormat As New Cls_SQLDateFormat
 
    Dim strQ As String = ""
    Private Sub frmExportRemainLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RadioExportAll.Checked = True
        ClsSetDateTimeFormat.fcnSetDateTimerPickerformat(Me.DateFinish)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim ClsGetData As New Cls_GetData
        Dim ClsExcel2 As New Cls_ExcelV2
        Dim RemainDataTable As DataTable
        Dim RemainDataTable1 As DataTable
        If Me.RadioEmpIdFrom.Checked = True And Me.txtFromEmpID.Text = "" Then
            MsgBox("Please insert range EmpId", vbOKOnly, "")
            Exit Sub
        ElseIf Me.RadioEmpIdFrom.Checked = True And Me.txtToEmpID.Text = "" Then
            MsgBox("Please insert range EmpId", vbOKOnly, "")
            Exit Sub
        End If


        Me.lbStatusExport.Text = "STATUS : Exporting data, Please wait."
        RemainDataTable = New DataTable
        RemainDataTable1 = New DataTable

        If Me.RadioExportAll.Checked = True Then
            strQ = ""
            strQ = strQ & " SELECT rem.empCode, mem.empName, mem.empSurname, rem.type_leave, rem.remain "
            strQ = strQ & " FROM  remain_leave rem left join member mem on rem.empCode = mem.empCode "
            strQ = strQ & " ORDER BY rem.empCode, rem.Index_no "
        Else
            strQ = ""
            strQ = strQ & " SELECT rem.empCode, mem.empName, mem.empSurname, rem.type_leave, rem.remain "
            strQ = strQ & " FROM  remain_leave rem left join member mem on rem.empCode = mem.empCode "
            strQ = strQ & " WHERE rem.empCode BETWEEN '" & Me.txtFromEmpID.Text & "' and '" & Me.txtToEmpID.Text & "' ORDER BY rem.empCode, rem.Index_no "
        End If
        

        RemainDataTable = ClsGetData.GetData1(Connection, strQ)
        Dim remainArray((RemainDataTable.Rows.Count - 1) / 9, 12) As String 'RemainDataTable.Rows.Count - 1
        Dim row As Integer = 0, colums As Integer = 3
        Dim EmpCode As String = "", empName As String = "", empSurname As String = ""
        Dim TypeLeave As String = ""
        Dim remainLeave As String = ""

        For Each record In RemainDataTable.Rows
            EmpCode = record("empCode").ToString
            TypeLeave = record("type_leave").ToString
            remainLeave = record("remain").ToString
            empName = record("empName").ToString
            empSurname = record("empSurname").ToString
            strQ = ""
            strQ = strQ & " SELECT SUM(req.Total)"
            strQ = strQ & " FROM  request_leave req "
            strQ = strQ & " WHERE req.type ='" & TypeLeave & "'"
            strQ = strQ & " AND req.empCode ='" & EmpCode & "'"
            strQ = strQ & " AND req.startDate >'" & ClsSQLDateFormat.SQLDateFormat(Me.DateFinish.Value) & "'"
            RemainDataTable1 = ClsGetData.GetData1(Connection, strQ)
            Dim remain2 As Double
            If RemainDataTable1.Rows(0)(0).ToString = "" Then
                remain2 = 0
            Else
                remain2 = CDbl(RemainDataTable1.Rows(0)(0).ToString)
            End If
            remainArray(row, 0) = EmpCode
            remainArray(row, 1) = empName
            remainArray(row, 2) = empSurname
            If remainLeave = "" Then
                remainArray(row, colums) = remainLeave + remain2
                GoTo Skip0_
            Else
                remainArray(row, colums) = remainLeave + remain2
            End If

            '======================================================================
            If colums = 12 Then
                If colums = 12 Then remainArray(row, colums) = remainLeave + remain2
                row = row + 1
                colums = 3
                GoTo Skip1_
            End If
            remainArray(row, colums) = remainLeave + remain2
Skip0_:     colums = colums + 1
Skip1_:     'NewEmpCode = record("empCode").ToString
        Next
        ClsExcel2.PathReport = "D:\Leave\Remain_leave.xls"
        ClsExcel2.PahtMaster = "\\192.168.0.249\hr\Master-Excel-Leave-Report\Remain_Leave.xls"
        ClsExcel2.ExportExcel(remainArray, "Sheet1", "A4", "")
        Me.lbStatusExport.Text = "STATUS : Exporting Successfully." & vbNewLine & "File was save as D:\Leave"
    End Sub
End Class