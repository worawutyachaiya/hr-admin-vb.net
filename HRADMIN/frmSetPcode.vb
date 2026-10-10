Public Class frmSetPcode
    Private strQ As String
    Private PCode(,) As String
    Private Sub frmSetPcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        LoadForm()
    End Sub
    Private Sub LoadForm()
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        strQ = ""
        strQ = strQ & "  select * "
        strQ = strQ & "  from set_pcode order by pcode "
        ClsGetData.GetPCode(Connection, Me.GridviewPCode, strQ, PCode)
    End Sub

    Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsInsert = New Cls_Insert

        Dim CheckAdding As Boolean = False

        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            If txtPCode.Text = "" Then

                MsgBox("กรุณาใส่ข้อมูลให้ครบ")

            Else
                'Check duplicate 
                strQ = ""
                strQ = strQ & "  select PCODE from SET_PCODE"
                strQ = strQ & "  where PCODE ='" & txtPCode.Text & "' "

                If Not ClsGetData.GetData(Connection, strQ) Then

                    strQ = ""
                    strQ = strQ & "  Insert into SET_PCODE (PCODE) Values('" & txtPCode.Text & "')"
                    ClsInsert.Insert(Connection, strQ)

                    SetAllConnectionDB_Smart()
                    strQ = ""
                    strQ = strQ & "  Insert into set_pcode_fed (PCODE) Values('" & txtPCode.Text & "')"
                    ClsInsert.Insert(Connection, strQ)

                    CheckAdding = True
                Else

                    MsgBox("PCode ซ้ำ กรุณาตรวจสอบอีกครั้ง")

                End If
            End If
        End If

        If CheckAdding Then
            MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "")
            txtPCode.Text = ""
            txtPCodeID.Text = ""
            LoadForm()
            ClsClickCurrentGridView.ClickGridview(Me.GridviewPCode)
        End If

    End Sub


    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData

        Dim CheckEdit As Boolean = False
        If txtPCodeID.Text = "" Then

            MsgBox("คุณต้องการแก้ไขข้อมูลใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการบันทึกข้อมูลที่แก้ไขใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                If txtPCode.Text = "" Then

                    MsgBox("กรุณาใส่ข้อมูลให้ครบ")

                Else

                    strQ = ""
                    strQ = strQ & "  update set_pcode   set"
                    strQ = strQ & "  PCODE ='" & txtPCode.Text & "'"
                    strQ = strQ & "  where PCODE ='" & txtPCodeID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    strQ = ""
                    strQ = strQ & "  update member  set"
                    strQ = strQ & "  emppcode ='" & txtPCode.Text & "'"
                    strQ = strQ & "  where emppcode ='" & txtPCodeID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)


                    SetAllConnectionDB_Smart()

                    strQ = ""
                    strQ = strQ & "  update set_pcode_fed   set"
                    strQ = strQ & "  PCODE ='" & txtPCode.Text & "'"
                    strQ = strQ & "  where PCODE ='" & txtPCodeID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    strQ = ""
                    strQ = strQ & "  update member_fed  set"
                    strQ = strQ & "  emppcode ='" & txtPCode.Text & "'"
                    strQ = strQ & "  where emppcode ='" & txtPCodeID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    SetAllConnectionDB()
                    CheckEdit = True

                End If
            End If

            If CheckEdit Then
                MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
                txtPCode.Text = ""
                txtPCodeID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewPCode)
            End If
        End If
    End Sub
    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click
        Dim CheckDelete As Boolean = False
        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete

        If txtPCodeID.Text = "" Then

            MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                strQ = ""
                strQ = strQ & "  delete "
                strQ = strQ & "  from SET_PCODE "
                strQ = strQ & "  where PCODE ='" & txtPCodeID.Text & "' "
                ClsDeleteData.fcnDelete(Connection, strQ)

                SetAllConnectionDB_Smart()
                strQ = ""
                strQ = strQ & "  delete "
                strQ = strQ & "  from SET_PCODE "
                strQ = strQ & "  where PCODE ='" & txtPCodeID.Text & "' "
                ClsDeleteData.fcnDelete(Connection, strQ)
                CheckDelete = True

            End If

            If CheckDelete Then
                MsgBox("ทำการลบข้อมูลแล้ว", , "")
                txtPCode.Text = ""
                txtPCodeID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewPCode)
            End If
        End If
    End Sub


    Private Sub GridviewPCode_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewPCode.CellClick
        ClsClickCurrentGridView.Row = e.RowIndex
    End Sub

    Private Sub GridviewPCode_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewPCode.CellContentClick
        Dim CheckValue As Boolean
        Dim row As Integer = Me.GridviewPCode.Rows.Count - 1

        If e.ColumnIndex = 1 Then

            If Me.GridviewPCode.Rows(e.RowIndex).Cells(1).ReadOnly = True Then


            Else

                'DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex)
                CheckValue = Me.GridviewPCode.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue

                For i = 0 To row

                    If i = e.RowIndex And CheckValue = True Then

                        Me.GridviewPCode.Rows(i).Cells(1).Value = True

                        'Get data to textbox
                        txtPCode.Text = Me.GridviewPCode.Rows(i).Cells(0).Value
                        txtPCodeID.Text = Me.GridviewPCode.Rows(i).Cells(0).Value


                    ElseIf i <> e.RowIndex And CheckValue = True Then

                        Me.GridviewPCode.Rows(i).Cells(1).Value = False

                    End If


                Next

            End If

        End If
    End Sub
End Class