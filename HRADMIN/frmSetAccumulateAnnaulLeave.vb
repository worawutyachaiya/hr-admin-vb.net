Public Class frmSetAccumulateAnnaulLeave
    Public AccumulateAL As String(,)
    Private strq As String = ""
    Private Sub frmSetConditionAnnaulLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        LoadForm()
    End Sub
    Private Sub LoadForm()
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        strq = ""
        strq = strq & "  select * "
        strq = strq & "  from set_accumulate_al order by year"
        ClsGetData.GetAccumulateAL(Connection, Me.GridviewAccumulateAL, strq, AccumulateAL)
    End Sub


    Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsInsert = New Cls_Insert
        Dim CheckAdding As Boolean = False

        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            If txtYear.Text = "" And txtQty.Text = "" Then

                MsgBox("กรุณาใส่ข้อมูลให้ครบ")

            Else

                'Check duplicate section
                strq = ""
                strq = strq & "  select year from set_accumulate_al "
                strq = strq & "  where year ='" & txtYear.Text & "' "

                If Not ClsGetData.GetData(Connection, strq) Then

                    strq = ""
                    strq = strq & "  Insert into set_accumulate_al (year, qty) Values('" & txtYear.Text & "', '" & txtQty.Text & "')"
                    ClsInsert.Insert(Connection, strq)
                    CheckAdding = True

                Else

                    MsgBox("จำนวนปีซ้ำ กรุณาตรวจสอบอีกครั้ง")

                End If


            End If
        End If

        If CheckAdding Then
            MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "")
            txtYear.Text = ""
            txtQty.Text = ""
            txtAccumulateID.Text = ""
            LoadForm()
            ClsClickCurrentGridView.ClickGridview(Me.GridviewAccumulateAL)
        End If

    End Sub

    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData

        Dim CheckEdit As Boolean = False

        If txtAccumulateID.Text = "" Then

            MsgBox("คุณต้องการแก้ไขข้อมูลใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else

            If MsgBox("คุณต้องการบันทึกข้อมูลที่แก้ไขใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                If txtYear.Text = "" And txtQty.Text = "" Then

                    MsgBox("กรุณาใส่ข้อมูลให้ครบ")

                Else

                    strq = ""
                    strq = strq & "  update set_accumulate_al  set"
                    strq = strq & "  year ='" & txtYear.Text & "',  qty ='" & txtQty.Text & "'"
                    strq = strq & "  where year ='" & txtAccumulateID.Text & "'"
                    ClsUpdateData.Update(Connection, strq)
                    'strq = ""
                    'strq = strq & "  update set_accumulate_al  set"
                    'strq = strq & "  qty ='" & txtQty.Text & "'"
                    'strq = strq & "  where year ='" & txtYear.Text & "'"
                    'ClsUpdateData.Update(Connection, strq)

                    CheckEdit = True

                End If
            End If

            If CheckEdit Then
                MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
                txtYear.Text = ""
                txtQty.Text = ""
                txtAccumulateID.Text = ""

                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewAccumulateAL)
            End If
        End If
    End Sub

    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click
        Dim CheckDelete As Boolean = False
        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete
        If txtAccumulateID.Text = "" Then

            MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                strq = ""
                strq = strq & "  delete "
                strq = strq & "  from set_accumulate_al "
                strq = strq & "  where year ='" & txtAccumulateID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strq)

                CheckDelete = True

            End If

            If CheckDelete Then
                MsgBox("ทำการลบข้อมูลแล้ว", , "")
                txtYear.Text = ""
                txtQty.Text = ""
                txtAccumulateID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewAccumulateAL)
            End If
        End If
    End Sub

    Private Sub GridviewAccumulateAL_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewAccumulateAL.CellContentClick
        Dim CheckValue As Boolean
        Dim row As Integer = Me.GridviewAccumulateAL.Rows.Count - 1
        If e.ColumnIndex = 2 Then

            If Me.GridviewAccumulateAL.Rows(e.RowIndex).Cells(2).ReadOnly = True Then

            Else

                'DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex)
                CheckValue = Me.GridviewAccumulateAL.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue

                For i = 0 To row

                    If i = e.RowIndex And CheckValue = True Then

                        Me.GridviewAccumulateAL.Rows(i).Cells(2).Value = True

                        'Get data to textbox
                        txtYear.Text = Me.GridviewAccumulateAL.Rows(i).Cells(0).Value
                        txtQty.Text = Me.GridviewAccumulateAL.Rows(i).Cells(1).Value
                        txtAccumulateID.Text = Me.GridviewAccumulateAL.Rows(i).Cells(0).Value


                    ElseIf i <> e.RowIndex And CheckValue = True Then

                        Me.GridviewAccumulateAL.Rows(i).Cells(2).Value = False

                    End If


                Next

            End If

        End If
    End Sub
End Class