Public Class frmSetRemainLeave
    Private strQ As String
    Private RemainLeave(,) As String


    Private Sub LoadForm()
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData

        Dim Total_AL As Double = 0

        strQ = ""
        strQ = strQ & "  select rem.empCode as EMPCODE, mem.empName as NAME,mem.empSurname as SURNAME, rem.type_leave as TYPE_LEAVE , rem.remain as REMAIN"
        strQ = strQ & "  from remain_leave rem, member mem"
        strQ = strQ & "  where rem.empCode = '" & UCase(Trim(Me.txtEmpCode.Text)) & "' and mem.empCode ='" & UCase(Trim(Me.txtEmpCode.Text)) & "'"
        ClsGetData.GetRemainLeave(Connection, Me.dataGridRemainLeave, strQ, RemainLeave)

        strQ = ""
        strQ = strQ & "  select TOTAL_AL "
        strQ = strQ & "  from al_bl_status"
        strQ = strQ & "  where empCode = '" & UCase(Trim(Me.txtEmpCode.Text)) & "'"
        ClsGetData.GetTotal_AL(Connection, Total_AL, strQ)

        txtTotal_AL.Text = Total_AL

    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData
        Dim row As Integer = Me.dataGridRemainLeave.Rows.Count - 1
        Dim column As Integer = Me.dataGridRemainLeave.Columns.Count - 1
        Dim CheckEdit As Boolean = False
        Dim Value As String = ""
        Dim empCode As String = ""
        Dim TypeLeave As String = ""
        Dim AL As Double = 0
        Dim AL_RATIO As Double = 0

        Dim ComputerName As String = My.Computer.Name
        For i = 0 To row
            empCode = Me.dataGridRemainLeave.Rows(i).Cells(0).Value
            'For j = 0 To column
            TypeLeave = Me.dataGridRemainLeave.Rows(i).Cells(3).Value
            Value = Me.dataGridRemainLeave.Rows(i).Cells(4).Value

            If TypeLeave = "AL_EMERGENCY" And Value > 4 Then
                MsgBox("AL_EMERGENCY ไม่เกิน 4 วัน")
                Exit Sub
            ElseIf TypeLeave = "SPL" And Value > 3 Then
                MsgBox("SPL ไม่เกิน 3 วัน")
                Exit Sub
            ElseIf TypeLeave = "FL" And Value > 6 Then
                MsgBox("FL ไม่เกิน 6 วัน")
                Exit Sub
            ElseIf TypeLeave = "M2L" And Value > 98 Then
                MsgBox("M2L ไม่เกิน 98 วัน")
                Exit Sub
            ElseIf TypeLeave = "SL" And Value > 30 Then
                MsgBox("SL ไม่เกิน 30 วัน")
                Exit Sub
            ElseIf TypeLeave = "BL" And Value > 5 Then
                MsgBox("BL ไม่เกิน 30 วัน")
                Exit Sub
            End If

            If Value <> RemainLeave(i, 4) Then

                strQ = ""
                strQ = strQ & "  update remain_leave rem , set_pass_pro pas  set "
                strQ = strQ & "  rem.remain ='" & Value & "',rem.update_date = NOW() , rem.update_by ='" & ComputerName & "' , pas.pass_pro ='YES'"
                strQ = strQ & "  where rem.empCode ='" & empCode & "' and rem.TYPE_LEAVE ='" & TypeLeave & "' and pas.empCode ='" & empCode & "'"

                CheckEdit = True
            End If

            ClsUpdateData.Update(Connection, strQ)

            If TypeLeave = "AL" Then

                AL = Value

            End If

            If TypeLeave = "AL_RATIO" Then

                AL_RATIO = Value

            End If

            'Next j
        Next i


        strQ = ""
        strQ = strQ & "  update al_bl_status set "
        strQ = strQ & "  TOTAL_AL ='" & AL + AL_RATIO & "' "
        strQ = strQ & "  where empCode ='" & empCode & "' "
        ClsUpdateData.Update(Connection, strQ)

        If CheckEdit Then
            MsgBox("ทำการแก้ไขข้อมูลแล้ว")
            LoadForm()
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadForm()
    End Sub

    Private Sub ImportDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportDataToolStripMenuItem.Click
        Dim ClsExcel = New Cls_Excel
        Dim path As String
        path = ClsExcel.OpenExcelFile()
        If path <> "" Then

            ClsExcel.ImportRemainLeave(path)
        End If

        'Me.dataGridRemainLeave.Rows.Clear()
        'strq = ""
        'strq = strq & "  select * "
        'strq = strq & "  from member order by empCode "
        'LoadForm(strq)
    End Sub

    Private Sub txtEmpCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadForm()
        End If
    End Sub


    Private Sub ImportDataToolStripMenuItem_Disposed(sender As Object, e As EventArgs) Handles ImportDataToolStripMenuItem.Disposed

    End Sub

    Private Sub frmSetRemainLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ExportRemainLeaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportRemainLeaveToolStripMenuItem.Click
        frmExportRemainLeave.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtTotal_AL.TextChanged

    End Sub
End Class