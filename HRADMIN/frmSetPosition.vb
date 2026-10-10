Public Class frmSetPosition
    Private strQ As String = ""
    Public Position(,) As String
    Private Sub frmSetPosition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        LoadForm()
    End Sub

    Private Sub LoadForm()

        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData

        strQ = ""
        strQ = strQ & "  select * "
        strQ = strQ & "  from set_position "
        ClsGetData.GetPosition(Connection, Me.GridviewPositon, strQ, Position)
    End Sub

    Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsInsert = New Cls_Insert

        Dim checkAdding As Boolean = False

        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            If txtPosition.Text = "" Then

                MsgBox("กรุณาใส่ข้อมูลให้ครบ")

            Else
                'Check duplicate 
                strQ = ""
                strQ = strQ & "  select POSITION from SET_POSITION"
                strQ = strQ & "  where POSITION ='" & txtPosition.Text & "' "

                If Not ClsGetData.GetData(Connection, strQ) Then

                    strQ = ""
                    strQ = strQ & "  Insert into SET_POSITION (POSITION) Values('" & txtPosition.Text & "')"
                    ClsInsert.Insert(Connection, strQ)

                    SetAllConnectionDB_Smart()
                    strQ = ""
                    strQ = strQ & "  Insert into SET_POSITION_fed (POSITION) Values('" & txtPosition.Text & "')"
                    ClsInsert.Insert(Connection, strQ)

                    checkAdding = True
                Else

                    MsgBox("Position ซ้ำ กรุณาตรวจสอบอีกครั้ง")

                End If
            End If
        End If

        If checkAdding Then
            MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "")
            txtPosition.Text = ""
            txtPositionID.Text = ""
            LoadForm()
            ClsClickCurrentGridView.ClickGridview(Me.GridviewPositon)
        End If


    End Sub

    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData

        Dim CheckEdit As Boolean = False
        If txtPositionID.Text = "" Then

            MsgBox("คุณต้องการแก้ไขข้อมูลใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการบันทึกข้อมูลที่แก้ไขใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                If txtPosition.Text = "" Then

                    MsgBox("กรุณาใส่ข้อมูลให้ครบ")

                Else
                    strQ = ""
                    strQ = strQ & "  update set_position  set"
                    strQ = strQ & "  POSITION ='" & txtPosition.Text & "'"
                    strQ = strQ & "  where POSITION ='" & txtPositionID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    SetAllConnectionDB_Smart()
                    strQ = ""
                    strQ = strQ & "  update set_position_fed  set"
                    strQ = strQ & "  POSITION ='" & txtPosition.Text & "'"
                    strQ = strQ & "  where POSITION ='" & txtPositionID.Text & "'"
                    ClsUpdateData.Update(Connection, strQ)

                    SetAllConnectionDB()
                    CheckEdit = True
                End If
            End If

            If CheckEdit Then
                MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
                txtPosition.Text = ""
                txtPositionID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewPositon)
            End If
        End If
    End Sub

    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click
        Dim CheckDelete As Boolean = False
        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete
        If txtPositionID.Text = "" Then

            MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                strQ = ""
                strQ = strQ & "  delete "
                strQ = strQ & "  from set_position "
                strQ = strQ & "  where POSITION ='" & txtPositionID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strQ)

                SetAllConnectionDB_Smart()
                strQ = ""
                strQ = strQ & "  delete "
                strQ = strQ & "  from set_position_fed "
                strQ = strQ & "  where POSITION ='" & txtPositionID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strQ)

                CheckDelete = True

            End If

            If CheckDelete Then
                MsgBox("ทำการลบข้อมูลแล้ว", , "")
                txtPosition.Text = ""
                txtPositionID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridviewPositon)
            End If
        End If
    End Sub

    Private Sub GridviewPositon_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewPositon.CellClick
        ClsClickCurrentGridView.Row = e.RowIndex
    End Sub

    Private Sub GridviewPositon_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridviewPositon.CellContentClick
        Dim CheckValue As Boolean
        Dim row As Integer = Me.GridviewPositon.Rows.Count - 1

        If e.ColumnIndex = 1 Then

            If Me.GridviewPositon.Rows(e.RowIndex).Cells(1).ReadOnly = True Then



            Else

                'DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex)
                CheckValue = Me.GridviewPositon.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue

                For i = 0 To row

                    If i = e.RowIndex And CheckValue = True Then

                        Me.GridviewPositon.Rows(i).Cells(1).Value = True

                        'Get data to textbox
                        txtPosition.Text = Me.GridviewPositon.Rows(i).Cells(0).Value
                        txtPositionID.Text = Me.GridviewPositon.Rows(i).Cells(0).Value


                    ElseIf i <> e.RowIndex And CheckValue = True Then

                        Me.GridviewPositon.Rows(i).Cells(1).Value = False

                    End If


                Next

            End If

        End If
    End Sub
End Class