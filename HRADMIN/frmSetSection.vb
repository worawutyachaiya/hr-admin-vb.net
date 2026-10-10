Public Class frmSetSection
    Private strQ As String = ""
    Private Section(,) As String
    Dim SectionName As String = ""
    Dim DeptName As String = ""

    Private Sub frmSetSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        LoadForm()
    End Sub

    Private Sub LoadForm()

        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData

        strQ = ""
        strQ = strQ & "  select SECT_NAME, DEPT_NAME "
        strQ = strQ & "  from set_section "
        ClsGetData.GetSection(Connection, Me.GridviewSection, strQ, Section)

    End Sub

    Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsInsert = New Cls_Insert
        Dim CheckAdding As Boolean = False

        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            If txtSection.Text = "" Or txtDepartment.Text = "" Then

                MsgBox("กรุณาใส่ข้อมูลให้ครบ")

            Else

                'Check duplicate section
                strQ = ""
                strQ = strQ & "  select SECT_NAME from set_section "
                strQ = strQ & "  where SECT_NAME ='" & txtSection.Text & "' "

                If Not ClsGetData.GetData(Connection, strQ) Then

                    strQ = ""
                    strQ = strQ & " Insert into SET_SECTION (SECT_NAME,DEPT_NAME) Values('" & txtSection.Text & "','" & txtDepartment.Text & "')"
                    ClsInsert.Insert(Connection, strQ)

                    SetAllConnectionDB_Smart()
                    strQ = ""
                    strQ = strQ & " Insert into SET_SECTION_fed (SECT_NAME,DEPT_NAME) Values('" & txtSection.Text & "','" & txtDepartment.Text & "')"

                    ClsInsert.Insert(Connection, strQ)

                    SetAllConnectionDB()
                    CheckAdding = True

                Else

                    MsgBox("Section ซ้ำ กรุณาตรวจสอบอีกครั้ง")

                End If


            End If
        End If

        If CheckAdding Then
            MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "")
            txtSection.Text = ""
            txtDepartment.Text = ""
            LoadForm()
            ClsClickCurrentGridView.ClickGridview(Me.GridviewSection)
        End If

    End Sub

    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData
        Dim CheckEdit As Boolean = False

        If txtSectionID.Text = "" Then

            MsgBox("คุณต้องการแก้ไขข้อมูลใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการบันทึกข้อมูลที่แก้ไขใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                If txtSection.Text = "" Or txtDepartment.Text = "" Then

                    MsgBox("กรุณาใส่ข้อมูลให้ครบ")

                Else

                    strQ = ""
                    strQ = strQ & "  update set_section set"
                    strQ = strQ & "  SECT_NAME ='" & txtSection.Text & "', DEPT_NAME ='" & txtDepartment.Text & "'"
                    strQ = strQ & "  where SECT_NAME ='" & txtSectionID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    strQ = ""
                    strQ = strQ & "  update member set"
                    strQ = strQ & "  empSection ='" & txtSection.Text & "'"
                    strQ = strQ & "  where empSection ='" & txtSectionID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    strQ = ""
                    strQ = strQ & "  update request_leave set"
                    strQ = strQ & "  empSection ='" & txtSection.Text & "'"
                    strQ = strQ & "  where empSection ='" & txtSectionID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    SetAllConnectionDB_Smart()
                    strQ = ""
                    strQ = strQ & "  update set_section_fed set"
                    strQ = strQ & "  SECT_NAME ='" & txtSection.Text & "', DEPT_NAME ='" & txtDepartment.Text & "'"
                    strQ = strQ & "  where SECT_NAME ='" & txtSectionID.Text & "'"

                    ClsUpdateData.Update(Connection, strQ)
                    strQ = ""
                    strQ = strQ & "  update member_fed set"
                    strQ = strQ & "  empSection ='" & txtSection.Text & "'"
                    strQ = strQ & "  where empSection ='" & txtSectionID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    'strQ = ""
                    'strQ = strQ & "  update set_section  set"
                    'strQ = strQ & "  DEPT_NAME ='" & txtDepartment.Text & "'"
                    'strQ = strQ & "  where SECT_NAME ='" & txtSection.Text & "'"
                    'ClsUpdateData.Update(Connection, strQ)

                    CheckEdit = True

                End If
            End If

            If CheckEdit Then
                MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
                txtSection.Text = ""
                txtDepartment.Text = ""
                txtSectionID.Text = ""

                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewSection)
            End If
        End If
    End Sub

    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click
        Dim CheckDelete As Boolean = False

        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete

        If txtSectionID.Text = "" Then

            MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                strQ = ""
                strQ = strQ & "  delete "
                strQ = strQ & "  from SET_Section "
                strQ = strQ & "  where SECT_NAME ='" & txtSectionID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strQ)

                SetAllConnectionDB_Smart()

                strQ = ""
                strQ = strQ & "  delete "
                strQ = strQ & "  from SET_Section_fed "
                strQ = strQ & "  where SECT_NAME ='" & txtSectionID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strQ)

                CheckDelete = True

            End If

            If CheckDelete Then
                MsgBox("ทำการลบข้อมูลแล้ว", , "")
                txtSection.Text = ""
                txtDepartment.Text = ""
                txtSectionID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewSection)
            End If
        End If
    End Sub

    Private Sub GridviewSection_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewSection.CellClick
        ClsClickCurrentGridView.Row = e.RowIndex
    End Sub

    Private Sub GridviewSection_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewSection.CellContentClick
        Dim CheckValue As Boolean
        Dim row As Integer = Me.GridviewSection.Rows.Count - 1

        If e.ColumnIndex = 2 Then

            If Me.GridviewSection.Rows(e.RowIndex).Cells(2).ReadOnly = True Then


            Else

                'DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex)
                CheckValue = Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue

                For i = 0 To row

                    If i = e.RowIndex And CheckValue = True Then

                        Me.GridviewSection.Rows(i).Cells(2).Value = True

                        'Get data to textbox
                        txtSection.Text = Me.GridviewSection.Rows(i).Cells(0).Value
                        txtDepartment.Text = Me.GridviewSection.Rows(i).Cells(1).Value
                        txtSectionID.Text = Me.GridviewSection.Rows(i).Cells(0).Value


                    ElseIf i <> e.RowIndex And CheckValue = True Then

                        Me.GridviewSection.Rows(i).Cells(2).Value = False

                    End If


                Next

            End If

        End If
    End Sub
End Class