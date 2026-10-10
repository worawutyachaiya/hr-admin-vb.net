Imports MySql.Data.MySqlClient
Public Class frmMain

    Private strQ As String
    Private Type() As String = {"", "A/L", "B/L", "BD/L", "S/L", "F/L", "P/L", "M1/L", "M2/L", "M3/L", "SP/L", "A/L_EMERGENCY"}

    Private ALSum As Double, BLSum As Double, SLSum As Double, BDLSum As Double, FLSum As Double, PLSum As Double, M1LSum As Double, _
                             M2LSum As Double, M3LSum As Double, SPLSum As Double
    Private LeaveCode As String
    Private empCode As String = ""
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsLoggedIn() Then
            Dim loginForm As New frmLogin()
            If loginForm.ShowDialog() <> DialogResult.OK Then
                Me.Close()
                Exit Sub
            End If
        End If

        Me.Text = "HR Admin - " & CurrentUserId

        Dim ClsSetDateTimeFormat = New Cls_SetDateTimerPickerformat

        ClsSetDateTimeFormat.fcnSetDateTimerPickerformat(Me.DateTimeFrom)
        ClsSetDateTimeFormat.fcnSetDateTimerPickerformat(Me.DateTimeTo)
        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData
        SetAllConnectionDB()

        '======================================================= แอด Department to combobox
        strQ = ""
        strQ = strQ & "select DEPT_NAME from  SET_DEPT "
        ClsGetData.GetDepartment(Connection, Me.cbbDept, strQ)

        '======================================================= เช็คการยื่นใบลาย้อนหลัง
        strQ = ""
        strQ = strQ & "select * from  request_leave where belated = 1 order by startDate"
        ClsGetData.GetLeave(Connection, Me.DataGridLeave, strQ)
        If Me.DataGridLeave.Rows.Count > 0 Then
            MsgBox("วันนี้มีการยื่นเอกสารย้อนหลังเราได้ทำการลิสต์การลามาให้แล้ว คุณควรจะทำการตรวจสอบ", vbOKOnly, "")
        End If
        '======================================================= เช็คว่า HR เห็นแล้ว
        strQ = ""
        strQ = strQ & "Update request_leave set belated = 0 where belated = 1"
        ClsUpdateData.Update(Connection, strQ)
        '=======================================================

        For i = 0 To Type.Length - 1
            Me.cbbType.Items.Add(Type(i))
        Next

        My.Application.ChangeCulture("en-GB")

        'ClsSetDataGridView.SetDataGridView(Me.DataGridView1)

        'Me.GridViewLeave.DefaultCellStyle.WrapMode = DataGridViewTriState.True

    End Sub
    Private Sub cmbSearchEmpCode_Click(sender As Object, e As EventArgs) Handles cmbSearchEmpCode.Click

        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        strQ = ""
        If Me.txtID.Text = "" Then MsgBox("Please insert emp.Code") : Exit Sub
        If Me.checked_show_hr_ok.Checked = True Then
            If Me.cbbType.Text = "" Then
                strQ = strQ & "select * from  request_leave where  empCode ='" & Me.txtID.Text & "'  order by startDate"
            Else
                strQ = strQ & "select * from  request_leave where  empCode ='" & Me.txtID.Text & "' and type='" & Me.cbbType.Text.Replace("/", "") & "' order by startDate"
            End If
        Else
            If Me.cbbType.Text = "" Then
                strQ = strQ & "select * from  request_leave where  empCode ='" & Me.txtID.Text & "' and hr_checked is null order by startDate"
            Else
                strQ = strQ & "select * from  request_leave where  empCode ='" & Me.txtID.Text & "' and type='" & Me.cbbType.Text.Replace("/", "") & "' and hr_checked is null  order by startDate"
            End If
        End If
       

        ClsGetData.GetLeave(Connection, Me.DataGridLeave, strQ)
        CalSum(Me.DataGridLeave)

    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridLeave.Click

        On Error GoTo endsub
        Dim row As Integer = Me.DataGridLeave.CurrentCell.RowIndex
        Dim col As Integer = Me.DataGridLeave.CurrentCell.ColumnIndex
        Me.DataGridLeave.Rows(row).Selected = True


        On Error Resume Next
        Dim img As Image = Me.DataGridLeave.Rows(row).Cells(col).Value

        'Dim str As String = Me.DataGridLeave.Rows(row).Cells(col).Value
        Dim strQ As String = ""
        LeaveCode = Me.DataGridLeave.Rows(row).Cells(0).Value
        empCode = Me.DataGridLeave.Rows(row).Cells(1).Value
        'If str = "Attach" Then
        If Not img Is Nothing Then
            ClsGetAttachment = New Cls_GetAttachment
            strQ = ""
            strQ = strQ & " select  FilesName "
            strQ = strQ & " from doc_leave "
            strQ = strQ & " where leaveCode ='" & LeaveCode & "'"

            SetAllConnectionDB()
            ClsGetAttachment.GetAttachment(Connection, FilesNameAttachment, strQ)
            frmShowAttachment.Show()
            'End If
        End If
endsub: Exit Sub
    End Sub


    Private Sub cmbSearchDate_Click(sender As Object, e As EventArgs) Handles cmbSearchDate.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsSQLDateFormat = New Cls_SQLDateFormat

        Dim startDate As Date = Me.DateTimeFrom.Value.ToString("yyyy-MM-dd")
        Dim finishDate As Date = Me.DateTimeTo.Value.ToString("yyyy-MM-dd")
    
        Dim s As String = ClsSQLDateFormat.SQLDateFormat(startDate)
        Dim f As String = ClsSQLDateFormat.SQLDateFormat(finishDate)
        If Me.checked_show_hr_ok.Checked = True Then
            strQ = ""
            strQ = strQ & " select  *   "
            strQ = strQ & "  from request_leave"
            strQ = strQ & "  where startDate between '" & s & "'"
            strQ = strQ & "  and '" & f & "' order by  startDate"

        Else
            strQ = ""
            strQ = strQ & " select  *   "
            strQ = strQ & "  from request_leave"
            strQ = strQ & "  where startDate between '" & s & "'"
            strQ = strQ & "  and '" & f & "' and hr_checked is null order by  startDate"
        End If
      
        ClsGetData.GetLeave(Connection, Me.DataGridLeave, strQ)
        Me.lbSummary.Text = ""
    End Sub


    Private Sub cmbSearcDept_Click(sender As Object, e As EventArgs) Handles cmbSearcDept.Click
        ClsConnectDbMysql = New Cls_ConnectDbMysql
        Connection = New MySqlConnection
        ClsConnectDbMysql.ConnectDBMySql(Connection)
        ClsGetData = New Cls_GetData
        If Me.checked_show_hr_ok.Checked = True Then
            strQ = ""
            strQ = strQ & " select  *   "
            strQ = strQ & "  from request_leave"
            strQ = strQ & "  where empSection ='" & Me.cbbDept.Text & "'"
            ClsGetData.GetLeave(Connection, Me.DataGridLeave, strQ)
        Else
            strQ = ""
            strQ = strQ & " select  *   "
            strQ = strQ & "  from request_leave"
            strQ = strQ & "  where empSection ='" & Me.cbbDept.Text & "' and hr_checked is null"
            ClsGetData.GetLeave(Connection, Me.DataGridLeave, strQ)
        End If
        
        Me.lbSummary.Text = ""
        'CalSum(Me.DataGridLeave)
    End Sub



    Private Sub CalSum(dataGridview As DataGridView)
        Dim row As Integer = dataGridview.Rows.Count - 1
        Dim column As Integer = 7
        ALSum = 0 : BLSum = 0 : BDLSum = 0 : SLSum = 0 : SLSum = 0 : FLSum = 0 : PLSum = 0 : M1LSum = 0 : M2LSum = 0 : M3LSum = 0 : SPLSum = 0
        For i = 0 To row
            Dim Type As String = dataGridview.Rows(i).Cells(column).Value
            Dim Total As String = dataGridview.Rows(i).Cells(8).Value
            Select Case Type
                Case "AL" : ALSum = ALSum + Total
                Case "BL" : BLSum = BLSum + Total
                Case "BDL" : BDLSum = BDLSum + Total
                Case "SL" : SLSum = SLSum + Total
                Case "FL" : FLSum = FLSum + Total
                Case "PL" : PLSum = PLSum + Total
                Case "M1L" : M1LSum = M1LSum + Total
                Case "M2L" : M2LSum = M2LSum + Total
                Case "M3L" : M3LSum = M3LSum + Total
                Case "SPL" : SPLSum = SPLSum + Total
            End Select

        Next
        Me.lbSummary.Text = "Summary  A/L = " & ALSum & " B/L =  " & BLSum & " S/L = " & SLSum & "  F/L =  " & FLSum & " P/L = " & PLSum
        Me.lbSummary.Text = Me.lbSummary.Text & " M1/L = " & M1LSum & " M2/L = " & M2LSum & " M3/L = " & M3LSum & " SP/L = " & SPLSum
    End Sub

    Private Sub cmbButton_Click(sender As Object, e As EventArgs) Handles cmbButton.Click
        Dim row As Integer = Me.DataGridLeave.Rows.Count - 1
        Dim selected As Boolean

        Dim LeaveType As String = ""

        Dim Remain As Double = 0
        Dim Remain_AL_RATIO As Double = 0
        Dim Remain_AL_EMERGENCY As Double = 0
        Dim Sum_AL_EMERGENCY As Double = 0
        Dim LeaveQtyAL As Double = 0
        Dim LeaveQtyAL_RATIO As Double = 0
        Dim iLeaveQtyAL As Double = 0
        Dim iLeaveQtyAL_RATIO As Double = 0
        Dim Total As Double = 0
        Dim checkSelected As Boolean = False
        SetAllConnectionDB()
        If MsgBox("คุณต้องการที่จะ ยกเลิกการลาใช่หรือไม่ ? ", MsgBoxStyle.YesNo, "ยืนยัน") = vbYes Then
            For i = 0 To row
                selected = Me.DataGridLeave.Rows(i).Cells(17).Value
                If selected = True And Me.DataGridLeave.Rows(i).Cells(10).Value <> "Cancel" Then
                    ClsUpdateData = New Cls_UpdateData

                    LeaveCode = Me.DataGridLeave.Rows(i).Cells(0).Value
                    empCode = Me.DataGridLeave.Rows(i).Cells(1).Value
                    LeaveType = Me.DataGridLeave.Rows(i).Cells(7).Value
                    Total = Me.DataGridLeave.Rows(i).Cells(8).Value
                    strQ = ""
                    strQ = strQ & "  update request_leave set "
                    strQ = strQ & "  approveNo1 = 'Cancel', approveNo2 = 'Cancel', approveNo3 = 'Cancel', approveNo4 = 'Cancel',approveNo5 = 'Cancel'"
                    strQ = strQ & "  ,approveNo1_by = '', approveNo2_by = '', approveNo3_by = '', approveNo4_by = '',approveNo5_by = ''"
                    strQ = strQ & "  where leaveCode ='" & LeaveCode & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    'Remain AL
                    strQ = ""
                    strQ = strQ & "  select remain from remain_leave "
                    strQ = strQ & "  where empCode ='" & empCode & "' and type_leave ='" & LeaveType & "'"
                    ClsGetData.GetLeaveAmount(Connection, Remain, strQ)

                    If LeaveType = "AL_EMERGENCY" Or LeaveType = "AL" Then

                        'Remain AL_RATIO
                        strQ = ""
                        strQ = strQ & "  select remain from remain_leave "
                        strQ = strQ & "  where empCode ='" & empCode & "' and type_leave ='AL_RATIO'"
                        ClsGetData.GetLeaveAL_RATIO(Connection, Remain_AL_RATIO, strQ)

                        If LeaveType = "AL_EMERGENCY" Then
                            'Remain AL
                            strQ = ""
                            strQ = strQ & "  select remain from remain_leave "
                            strQ = strQ & "  where empCode ='" & empCode & "' and type_leave ='AL'"
                            ClsGetData.GetLeaveAmount(Connection, Remain, strQ)

                        End If

                        'Requet AL
                        strQ = ""
                        strQ = strQ & "  SELECT LeaveQtyAL, LeaveQtyAL_RATIO FROM request_leave "
                        strQ = strQ & "  where leaveCode ='" & LeaveCode & "' "
                        ClsGetData.GetRequestLeave(Connection, LeaveQtyAL, LeaveQtyAL_RATIO, strQ)

                        iLeaveQtyAL = LeaveQtyAL + Remain
                        iLeaveQtyAL_RATIO = LeaveQtyAL_RATIO + Remain_AL_RATIO

                        'remain_leave AL
                        strQ = ""
                        strQ = strQ & "  update remain_leave set "
                        strQ = strQ & "  remain = '" & iLeaveQtyAL & "'"
                        strQ = strQ & "  where empCode ='" & empCode & "'"
                        strQ = strQ & "  and type_leave ='AL'"
                        ClsUpdateData.Update(Connection, strQ)

                        'remain_leave AL RATIO
                        strQ = ""
                        strQ = strQ & "  update remain_leave set "
                        strQ = strQ & "  remain = '" & iLeaveQtyAL_RATIO & "'"
                        strQ = strQ & "  where empCode ='" & empCode & "'"
                        strQ = strQ & "  and type_leave ='AL_RATIO'"
                        ClsUpdateData.Update(Connection, strQ)

                        If LeaveType = "AL_EMERGENCY" Then
                            'Remain AL_EMERGENCY
                            strQ = ""
                            strQ = strQ & "  select remain from remain_leave "
                            strQ = strQ & "  where empCode ='" & empCode & "' and type_leave ='AL_EMERGENCY'"
                            ClsGetData.GetLeaveAL_EMERGENCY(Connection, Remain_AL_EMERGENCY, strQ)

                            Sum_AL_EMERGENCY = Remain_AL_EMERGENCY + Total

                            strQ = ""
                            strQ = strQ & "  update remain_leave set "
                            strQ = strQ & "  remain = '" & Sum_AL_EMERGENCY & "'"
                            strQ = strQ & "  where empCode ='" & empCode & "'"
                            strQ = strQ & "  and type_leave ='AL_EMERGENCY'"
                            ClsUpdateData.Update(Connection, strQ)

                        End If

                        'al_bl_status

                        strQ = ""
                        strQ = strQ & "  update al_bl_status set "
                        strQ = strQ & "  TOTAL_AL = '" & iLeaveQtyAL + iLeaveQtyAL_RATIO & "'"
                        strQ = strQ & "  where empCode ='" & empCode & "'"
                        ClsUpdateData.Update(Connection, strQ)


                    Else

                        strQ = ""
                        strQ = strQ & "  update remain_leave set "
                        strQ = strQ & "  remain = '" & Remain + Total & "'"
                        strQ = strQ & "  where empCode ='" & empCode & "'"
                        strQ = strQ & "  and type_leave ='" & LeaveType & "'"
                        ClsUpdateData.Update(Connection, strQ)

                    End If


                    Me.DataGridLeave.Rows(i).Cells(10).Value = "Cancel"
                    Me.DataGridLeave.Rows(i).Cells(11).Value = "Cancel"
                    Me.DataGridLeave.Rows(i).Cells(12).Value = "Cancel"
                    Me.DataGridLeave.Rows(i).Cells(13).Value = "Cancel"
                    Me.DataGridLeave.Rows(i).Cells(14).Value = "Cancel"
                    Me.DataGridLeave.Rows(i).Selected = True
                        checkSelected = True
                    End If
            Next
        End If
        If Not checkSelected Then
            MsgBox("คุณยังไม่ได้เลือก Selected ", vbOKOnly, "")
        End If
    End Sub

    'Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
    '    ClsGetData = New Cls_GetData
    '    SetAllConnectionDB()
    '    strQ = ""
    '    strQ = strQ & "select * from  request_leave "
    '    ClsGetData.GetLeave(Connection, Me.DataGridLeave, strQ)
    '    Me.lbSummary.Text = ""
    'End Sub

    Private Sub btnExportData_Click(sender As Object, e As EventArgs) Handles btnExportData.Click

        Dim ClsExcel = New Cls_Excel
        If MsgBox("คูณต้องการที่จะ export data ใช่หรือไม่?", vbYesNo, "ยืนยัน") = vbYes Then
            If (Me.DataGridLeave.Rows.Count = 0) Then
                MsgBox("ไม่สามารถ export data ได้")
            Else
                ClsExcel.ExportExcel(Me.DataGridLeave)
            End If
        End If
    End Sub



    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'frmViewLeave.Show()
    End Sub

    Private Sub DepartmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentToolStripMenuItem.Click
        frmSetDepartment.Show()
    End Sub



    Private Sub FlowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FlowToolStripMenuItem.Click
        frmFlow.Show()
    End Sub

    Private Sub HolidaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HolidaysToolStripMenuItem.Click
        frmHolidays.Show()
    End Sub

    Private Sub MemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberToolStripMenuItem.Click
        frmMember.Show()
    End Sub

    Private Sub SectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SectionToolStripMenuItem.Click
        frmSetSection.Show()
    End Sub

    Private Sub PCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCodeToolStripMenuItem.Click
        frmSetPcode.Show()
    End Sub

    Private Sub PositionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PositionToolStripMenuItem.Click
        frmSetPosition.Show()
    End Sub

    Private Sub ResetPasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        frmResetPassword.Show()
    End Sub

    Private Sub RemainLeaveToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        frmSetRemainLeave.Show()
    End Sub

    Private Sub HRApproveCaseSpacialToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        frmSetHRApproveSpecial.Show()
    End Sub



    Private Sub AccumulToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        frmSetAccumulateAnnaulLeave.Show()
    End Sub

    Private Sub btnHROK_Click(sender As Object, e As EventArgs) Handles btnHROK.Click
        Dim row As Integer = Me.DataGridLeave.Rows.Count - 1
        Dim selected As Boolean
        If MsgBox("คุณได้ทำการตรวจสอบการลานี้แล้วใช่หรือไม่, " & vbNewLine & "กด Yes การลาที่ทำการเลือก จะไม่ปรากฏ ในการค้นหาครั้งต่อไป " & vbNewLine & "กด No ยกเลิก ", vbYesNo, "") = vbYes Then
            For i = 0 To row
                selected = Me.DataGridLeave.Rows(i).Cells(17).Value
                If selected = True Then
                    ClsUpdateData = New Cls_UpdateData

                    LeaveCode = Me.DataGridLeave.Rows(i).Cells(0).Value
                    empCode = Me.DataGridLeave.Rows(i).Cells(1).Value
                    strQ = ""
                    strQ = strQ & "  update request_leave set "
                    strQ = strQ & "  hr_checked = '1'"
                    strQ = strQ & "  where leaveCode ='" & LeaveCode & "' and empCode ='" & empCode & "'"
                    ClsUpdateData.Update(Connection, strQ)

                End If
            Next i

        End If
    End Sub

    Private Sub SummaryLeaveToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        frmSummary.Show()
    End Sub

    Private Sub txtID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbSearchEmpCode.PerformClick()
        End If
    End Sub
End Class

