Public Class frmSetHRApproveSpecial
    Private strQ As String = ""
    Private empCodeSpecial As String()
    Private Sub frmSetHRApproveSpecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        LoadForm()
    End Sub

    Private Sub LoadForm()
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        strQ = ""
        strQ = strQ & "  select * "
        strQ = strQ & "  from hr_approve "
        ClsGetData.GetEmpCodeSpecial(Connection, Me.GridviewSpecial, strQ, empCodeSpecial)
    End Sub

    Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsInsert = New Cls_Insert

        Dim CheckAdding As Boolean = False

        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            If txtHRSpecialCode.Text = "" Then

                MsgBox("กรุณาใส่ข้อมูลให้ครบ")

            Else
                'Check duplicate 
                strQ = ""
                strQ = strQ & "  select empCode from hr_approve"
                strQ = strQ & "  where empCode ='" & txtHRSpecialCode.Text & "' "

                If Not ClsGetData.GetData(Connection, strQ) Then

                    strQ = ""
                    strQ = strQ & "  Insert into hr_approve(empCode) Values('" & txtHRSpecialCode.Text & "')"
                    ClsInsert.Insert(Connection, strQ)
                    CheckAdding = True
                Else

                    MsgBox("Emp Code ซ้ำ กรุณาตรวจสอบอีกครั้ง")

                End If
            End If
        End If


        If CheckAdding Then
            MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "")
            txtHRSpecialCode.Text = ""
            txtHRSpecialID.Text = ""
            LoadForm()
            ClsClickCurrentGridView.ClickGridview(Me.GridviewSpecial)
        End If

    End Sub

    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData

        Dim CheckEdit As Boolean = False
        If txtHRSpecialID.Text = "" Then

            MsgBox("คุณต้องการแก้ไขข้อมูลใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการบันทึกข้อมูลที่แก้ไขใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                If txtHRSpecialCode.Text = "" Then

                    MsgBox("กรุณาใส่ข้อมูลให้ครบ")

                Else
                    strQ = ""
                    strQ = strQ & "  update hr_approve  set"
                    strQ = strQ & "  empCode ='" & txtHRSpecialCode.Text & "'"
                    strQ = strQ & "  where empCode ='" & txtHRSpecialID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)
                    CheckEdit = True

                End If
            End If

            If CheckEdit Then
                MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
                txtHRSpecialCode.Text = ""
                txtHRSpecialID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewSpecial)
            End If
        End If

    End Sub

    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click

        Dim CheckDelete As Boolean = False
        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete
        If txtHRSpecialID.Text = "" Then

            MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
                strQ = ""
                strQ = strQ & "  delete "
                strQ = strQ & "  from hr_approve "
                strQ = strQ & "  where empCode ='" & txtHRSpecialID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strQ)

                CheckDelete = True

            End If

            If CheckDelete Then
                MsgBox("ทำการลบข้อมูลแล้ว", , "")
                txtHRSpecialCode.Text = ""
                txtHRSpecialID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewSpecial)
            End If
        End If
    End Sub

    Private Sub GridviewSpecial_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewSpecial.CellClick
        ClsClickCurrentGridView.Row = e.RowIndex
    End Sub

    Private Sub GridviewSpecial_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewSpecial.CellContentClick
        Dim CheckValue As Boolean
        Dim row As Integer = Me.GridviewSpecial.Rows.Count - 1

        If e.ColumnIndex = 1 Then

            If Me.GridviewSpecial.Rows(e.RowIndex).Cells(1).ReadOnly = True Then

                'MsgBox("ReadOnly True")

            Else

                'DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex)
                CheckValue = Me.GridviewSpecial.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue

                For i = 0 To row

                    If i = e.RowIndex And CheckValue = True Then

                        Me.GridviewSpecial.Rows(i).Cells(1).Value = True

                        'Get data to textbox
                        txtHRSpecialCode.Text = Me.GridviewSpecial.Rows(i).Cells(0).Value
                        txtHRSpecialID.Text = Me.GridviewSpecial.Rows(i).Cells(0).Value


                    ElseIf i <> e.RowIndex And CheckValue = True Then

                        Me.GridviewSpecial.Rows(i).Cells(1).Value = False

                    End If


                Next

            End If

        End If
    End Sub
End Class