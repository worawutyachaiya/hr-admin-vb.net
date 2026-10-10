Public Class frmHolidays
    Private Holidays(,) As String
    Private strq As String = ""
    Private HolidayFromClickGridview As String = ""
    Private Sub frmHolidays_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        LoadForm()
    End Sub
    Private Sub LoadForm()
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        ClsSetDateTimerPickerformat = New Cls_SetDateTimerPickerformat

        strq = ""
        strq = strq & "  select * "
        strq = strq & "  from holidays order by day_holiday "
        ClsGetData.GetHolidays(Connection, Me.GridHolidays, strq, Holidays)
        ClsSetDateTimerPickerformat.fcnSetDateTimerPickerformat(Me.dtpHoliday)
        Me.cbbHolidayCode.SelectedIndex = 0
    End Sub


    Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsInsert = New Cls_Insert
        Dim row As Integer = Me.GridHolidays.Rows.Count - 2
        Dim column As Integer = Me.GridHolidays.Columns.Count - 2
        Dim Holidays As String, Title As String, HolidayCode As String

        Dim checkAdding As Boolean = False

        Holidays = Me.dtpHoliday.Value.ToString("yyyy-MM-dd")
        Title = Me.txtTitle.Text.Replace("'", "")
        HolidayCode = Me.cbbHolidayCode.Text

        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            If Not IsDate(Holidays) Then
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากวันที่ไม่ถูกต้อง", vbOKOnly, "")
                Exit Sub
            End If

            If Title = "" Then
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เนื่องจาก Titel เป็นค่าว่าง ", vbOKOnly, "")
                Exit Sub
            End If

            strq = ""
            strq = strq & "  Select day_holiday From holidays Where day_holiday ='" & Holidays & "'"
            If Not ClsGetData.GetData(Connection, strq) Then
                strq = ""
                strq = strq & "  Insert into holidays(day_holiday,title_holiday,holiday_code) "
                strq = strq & "  Values('" & Holidays & "','" & Title & "','" & HolidayCode & "')"
                ClsInsert.Insert(Connection, strq)

                SetAllConnectionDB_Smart()
                ClsInsert.Insert(Connection, strq)

                Me.GridHolidays.Rows.Add(Me.dtpHoliday.Value.ToString("dd-MMM-yyyy"), Title, HolidayCode)
                GridHolidays.FirstDisplayedScrollingRowIndex = Me.GridHolidays.Rows.Count - 1
                checkAdding = True
            Else
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากวันที่นี้มีอยู่แล้ว ", vbOKOnly, "")
            End If

            If checkAdding Then
                MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "")
                txtTitle.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridHolidays)
            End If
        End If
        'For i = 0 To row
        '    ' For j = 0 To column


        '    Holidays = fcnConvertDate(Me.GridHolidays.Rows(i).Cells(0).Value.ToString.Replace("(", "").Replace(")", "").Replace("'", ""))
        '    Title = Me.GridHolidays.Rows(i).Cells(1).Value '.Replace("(", "").Replace(")", "").Replace("'", "")
        '    If Not IsDate(Holidays) Then
        '        MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากวันที่ไม่ถูกต้อง", vbOKOnly, "")
        '        Exit Sub
        '    End If

        '    If Title Is Nothing Then
        '        MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เนื่องจาก Titel เป็นค่าว่าง ", vbOKOnly, "")
        '        Exit Sub
        '    End If



        '    'If DeptName = Nothing And DeptDesc <> Nothing Then MsgBox("Please Insert Department") : Exit Sub
        '    'If DeptDesc = Nothing And DeptName <> Nothing Then MsgBox("Please Insert Discription") : Exit Sub

        '    'If DeptName <> Nothing And DeptDesc <> Nothing Then
        '    strq = ""
        '    strq = strq & "  Select day_holiday From holidays Where day_holiday ='" & Holidays & "'"
        '    If Not ClsGetData.GetData(Connection, strq) Then
        '        strq = ""
        '        strq = strq & "  Insert into holidays(day_holiday,title_holiday) "
        '        strq = strq & "  Values('" & Holidays & "','" & Title & "')"
        '        ClsInsert.Insert(Connection, strq)
        '        checkAdding = True

        '    End If
        '    'Next j
        '    'End If
        'Next i
        'If checkAdding Then MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "") : LoadForm()
    End Sub


    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData
        Dim row As Integer = Me.GridHolidays.Rows.Count - 1
        Dim column As Integer = Me.GridHolidays.Columns.Count - 2
        Dim HolidayFromCombobox As String, Title As String, HolidayCode As String
        Dim value As String = ""
        Dim checkUpdate As Boolean = False

        HolidayFromCombobox = Me.dtpHoliday.Value.ToString("yyyy-MM-dd")
        Title = Me.txtTitle.Text.Replace("'", "").ToString
        HolidayCode = Me.cbbHolidayCode.Text

        If MsgBox("คุณต้องการบันทึกข้อมูลที่แก้ไขใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            If Not IsDate(HolidayFromCombobox) Then
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากวันที่ไม่ถูกต้อง", vbOKOnly, "")
                Exit Sub
            End If

            If Title = "" Then
                MsgBox("ไม่สามารถเพิ่มข้อมูลได้ เนื่องจาก Titel เป็นค่าว่าง ", vbOKOnly, "")
                Exit Sub
            End If

            'strq = ""
            'strq = strq & "  Select day_holiday From holidays Where day_holiday ='" & HolidayFromCombobox & "'"
            'If Not ClsGetData.GetData(Connection, strq) Then
            strq = ""
            strq = strq & "  update holidays  set"
            strq = strq & "  day_holiday = '" & HolidayFromCombobox & "'"
            strq = strq & "  ,title_holiday ='" & Title & "'"
            strq = strq & "  ,holiday_code ='" & HolidayCode & "'"
            strq = strq & "  where day_holiday ='" & fcnConvertDate(HolidayFromClickGridview) & "'"
            ClsUpdateData.Update(Connection, strq)


            SetAllConnectionDB_Smart()
            ClsUpdateData.Update(Connection, strq)


            SetAllConnectionDB()
            MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
            LoadForm()
            txtTitle.Text = ""
            ClsClickCurrentGridView.ClickGridview(Me.GridHolidays)

        End If
    End Sub

    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click
        Dim row As Integer = Me.GridHolidays.Rows.Count - 1
        Dim selected As Boolean
        Dim HolidayName As String = ""

        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete
        If MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            For i = 0 To row
                On Error Resume Next
                selected = Me.GridHolidays.Rows(i).Cells(3).Value

                'If Me.checboxSelectAll.Checked = True Then
                '    strq = ""
                '    strq = strq & "  delete "
                '    strq = strq & "  from holidays "
                '    ClsDeleteData.fcnDelete(Connection, strq)
                '    Me.checboxSelectAll.Checked = False
                '    LoadForm()
                '    Exit Sub
                'End If

                If selected = True And Me.GridHolidays.Rows(i).Cells(0).Value <> "" Then

                    HolidayName = fcnConvertDate(Me.GridHolidays.Rows(i).Cells(0).Value)
                    strq = ""
                    strq = strq & "  delete "
                    strq = strq & "  from holidays "
                    strq = strq & "  where day_holiday ='" & HolidayName & "'"
                    ClsDeleteData.fcnDelete(Connection, strq)
                    Me.GridHolidays.Rows.Remove(Me.GridHolidays.Rows(i))
                    GridHolidays.FirstDisplayedScrollingRowIndex = Me.GridHolidays.Rows.Count - 1
                    ClsClickCurrentGridView.ClickGridview(Me.GridHolidays)
                End If
            Next
        End If
        MsgBox("ทำการลบข้อมูลแล้ว", , "")
        LoadForm()
        txtTitle.Text = ""
        ClsClickCurrentGridView.ClickGridview(Me.GridHolidays)
    End Sub

    Private Sub checboxSelectAll_CheckedChanged(sender As Object, e As EventArgs)
        'If Me.checboxSelectAll.Checked = True Then
        '    For i = 0 To Me.GridHolidays.Rows.Count - 1
        '        Me.GridHolidays.Rows(i).Cells(3).Value = True
        '    Next
        'Else
        '    For i = 0 To Me.GridHolidays.Rows.Count - 1
        '        Me.GridHolidays.Rows(i).Cells(3).Value = False
        '    Next
        'End If
    End Sub

    Private Sub GridHolidays_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridHolidays.CellClick
        If e.RowIndex >= 0 Then
            Me.dtpHoliday.Value = Me.GridHolidays.Rows(e.RowIndex).Cells(0).Value
            Me.txtTitle.Text = Me.GridHolidays.Rows(e.RowIndex).Cells(1).Value

            If Me.GridHolidays.Rows(e.RowIndex).Cells(2).Value = "" Then
                Me.cbbHolidayCode.SelectedIndex = -1
            Else
                Me.cbbHolidayCode.Text = Me.GridHolidays.Rows(e.RowIndex).Cells(2).Value
            End If

            HolidayFromClickGridview = Me.GridHolidays.Rows(e.RowIndex).Cells(0).Value
            ClsClickCurrentGridView.Row = e.RowIndex
        End If
    End Sub


    Private Sub ImportHolidaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportHolidaysToolStripMenuItem.Click
        Dim ClsExcel = New Cls_Excel
        Dim path As String
        path = ClsExcel.OpenExcelFile()
        If path <> "" Then
            ClsExcel.ImportHolidays(path, Me.GridHolidays)
            LoadForm()

        End If

    End Sub

    Private Sub GridHolidays_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridHolidays.CellContentClick
        Dim CheckValue As Boolean
        Dim row As Integer = Me.GridHolidays.Rows.Count - 1
        If e.ColumnIndex = 3 Then

            If Me.GridHolidays.Rows(e.RowIndex).Cells(3).ReadOnly = True Then


            Else

                'DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex)
                CheckValue = Me.GridHolidays.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue

                For i = 0 To row

                    If i = e.RowIndex And CheckValue = True Then

                        Me.GridHolidays.Rows(i).Cells(3).Value = True

                        'Get data to textbox

                    ElseIf i <> e.RowIndex And CheckValue = True Then

                        Me.GridHolidays.Rows(i).Cells(3).Value = False

                    End If


                Next

            End If

        End If
    End Sub
End Class