Imports MySql.Data.MySqlClient

Public Class frmSetDepartment
    Private strQ As String = ""
    Private Department(,) As String
    'Private DescDept() As String
    'Dim Department As New List(Of String)()
    'Dim DescDept As New List(Of String)()


    Private Sub frmSetDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        LoadForm()
    End Sub

    Private Sub LoadForm()
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData

        strQ = ""
        strQ = strQ & "  select * "
        strQ = strQ & "  from set_dept "
        ClsGetData.GetDepartment(Connection, GridviewDept, strQ, Department)
    End Sub

    Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsInsert = New Cls_Insert
        Dim checkAdding As Boolean = False

        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

            If txtDepartment.Text = "" Or txtDescription.Text = "" Then

                MsgBox("กรุณาใส่ข้อมูลให้ครบ")
            Else

                strQ = ""
                strQ = strQ & "  Select DEPT_NAME From SET_DEPT Where DEPT_NAME ='" & txtDepartment.Text & "'"
                If Not ClsGetData.GetData(Connection, strQ) Then
                    strQ = ""
                    strQ = strQ & "  Insert into SET_DEPT(DEPT_NAME,DEPT_DESC) Values('" & txtDepartment.Text & "','" & txtDescription.Text & "')"
                    ClsInsert.Insert(Connection, strQ)

                    SetAllConnectionDB_Smart()
                    strQ = ""
                    strQ = strQ & "  Insert into SET_DEPT_fed(DEPT_NAME,DEPT_DESC) Values('" & txtDepartment.Text & "','" & txtDescription.Text & "')"
                    ClsInsert.Insert(Connection, strQ)

                    checkAdding = True
                Else
                    MsgBox("Department ซ้ำ กรุณาตรวจสอบอีกครั้ง")
                End If

            End If

        End If
        If checkAdding Then
            MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "")
            txtDepartment.Text = ""
            txtDescription.Text = ""
            txtDeptID.Text = ""
            LoadForm()
            ClsClickCurrentGridView.ClickGridview(Me.GridviewDept)
        End If


    End Sub


    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click

        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData
        SetAllConnectionDB()
        Dim CheckEdit As Boolean = False

        If txtDeptID.Text = "" Then

            MsgBox("คุณต้องการแก้ไขข้อมูลใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else

            If MsgBox("คุณต้องการบันทึกข้อมูลที่แก้ไขใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                If txtDepartment.Text = "" Or txtDescription.Text = "" Then

                    MsgBox("กรุณาใส่ข้อมูลให้ครบ")

                Else
                    strQ = ""
                    strQ = strQ & "  update SET_DEPT set"
                    strQ = strQ & "  DEPT_NAME ='" & txtDepartment.Text & "', DEPT_DESC ='" & txtDescription.Text & "'"
                    strQ = strQ & "  where DEPT_NAME ='" & txtDeptID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    'strQ = ""
                    'strQ = strQ & "  update SET_DEPT  set"
                    'strQ = strQ & "  DEPT_DESC ='" & txtDescription.Text & "'"
                    'strQ = strQ & "  where SECT_NAME ='" & txtDepartment.Text & "'"
                    'ClsUpdateData.Update(Connection, strQ)

                    strQ = ""
                    strQ = strQ & "  update member set "
                    strQ = strQ & "  empDept ='" & txtDepartment.Text & "'"
                    strQ = strQ & "  where empDept ='" & txtDeptID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)


                    SetAllConnectionDB_Smart()

                    strQ = ""
                    strQ = strQ & "  update SET_DEPT_fed set"
                    strQ = strQ & "  DEPT_NAME ='" & txtDepartment.Text & "', DEPT_DESC ='" & txtDescription.Text & "'"
                    strQ = strQ & "  where DEPT_NAME ='" & txtDeptID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    'strQ = ""
                    'strQ = strQ & "  update SET_DEPT  set"
                    'strQ = strQ & "  DEPT_DESC ='" & txtDescription.Text & "'"
                    'strQ = strQ & "  where SECT_NAME ='" & txtDepartment.Text & "'"
                    'ClsUpdateData.Update(Connection, strQ)

                    strQ = ""
                    strQ = strQ & "  update member_fed set "
                    strQ = strQ & "  empDept ='" & txtDepartment.Text & "'"
                    strQ = strQ & "  where empDept ='" & txtDeptID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    SetAllConnectionDB()
                    CheckEdit = True

                End If
            End If
            If CheckEdit Then
                MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
                txtDepartment.Text = ""
                txtDescription.Text = ""
                txtDeptID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewDept)
            End If
        End If

    End Sub




    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click
        Dim CheckDelete As Boolean = False

        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete

        If txtDeptID.Text = "" Then

            MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                strQ = ""
                strQ = strQ & "  delete "
                strQ = strQ & "  from SET_DEPT "
                strQ = strQ & "  where DEPT_NAME='" & txtDeptID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strQ)

                CheckDelete = True

            End If


            If CheckDelete Then
                MsgBox("ทำการลบข้อมูลแล้ว", , "")
                txtDepartment.Text = ""
                txtDescription.Text = ""
                txtDeptID.Text = ""
                LoadForm()
                ' ClsClickCurrentGridView.ClickGridview(Me.GridviewDept)
            End If
        End If
    End Sub


    Private Sub GridviewDept_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewDept.CellClick
        ClsClickCurrentGridView.Row = e.RowIndex
    End Sub

    Private Sub GridviewDept_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewDept.CellContentClick
        Dim CheckValue As Boolean
        Dim row As Integer = Me.GridviewDept.Rows.Count - 1

        If e.ColumnIndex = 2 Then

            If Me.GridviewDept.Rows(e.RowIndex).Cells(2).ReadOnly = True Then


            Else

                'DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex)
                CheckValue = Me.GridviewDept.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue

                For i = 0 To row

                    If i = e.RowIndex And CheckValue = True Then

                        Me.GridviewDept.Rows(i).Cells(2).Value = True

                        'Get data to textbox
                        txtDepartment.Text = Me.GridviewDept.Rows(i).Cells(0).Value
                        txtDescription.Text = Me.GridviewDept.Rows(i).Cells(1).Value
                        txtDeptID.Text = Me.GridviewDept.Rows(i).Cells(0).Value

                    ElseIf i <> e.RowIndex And CheckValue = True Then

                        Me.GridviewDept.Rows(i).Cells(2).Value = False

                    End If


                Next

            End If

        End If
    End Sub
End Class