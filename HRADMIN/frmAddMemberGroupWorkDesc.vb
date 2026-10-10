Public Class frmAddMemberGroupWorkDesc
    Private ClsGetData As New Cls_GetData()
    Private ClsUpdate As New Cls_UpdateData()
    Private ClsDelete As New Cls_Delete()
    Private ClsInsert As New Cls_Insert()
    Private StringSQL As String
    Private Check_btn_edit_process As Boolean
    Private Old_Process_name As String

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(15).Value = Me.ComboBoxGroupProcess.Text
        Me.Close()
    End Sub

    Private Sub frmAddMemberGroupWorkDesc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 147
        Me.ComboBoxGroupProcess.SelectedIndex = -1
        Load_Process()
    End Sub

    Private Sub Load_Process()
        SetAllConnectionDB()
        Me.ListBox_process_name.Items.Clear()
        Me.ComboBoxGroupProcess.Items.Clear()
        Me.txtbox_process_name.Text = ""
        StringSQL = ""
        StringSQL = StringSQL & "SELECT * FROM T_PROCESS_GROUP"
        Dim result As String() = ClsGetData.GetDataGroupName(Connection, StringSQL)
        For Each myData In result
            Me.ComboBoxGroupProcess.Items.Add(myData)
            Me.ListBox_process_name.Items.Add(myData)
        Next
    End Sub

    Private Sub btn_edit_process_name_Click(sender As Object, e As EventArgs) Handles btn_edit_process_name.Click
        If Not Check_btn_edit_process Then
            Me.Height = 419
            Check_btn_edit_process = True
            Me.btn_edit_process_name.Text = "ปิดแก้ไข Process"
        Else
            Me.Height = 145
            Check_btn_edit_process = False
            Me.btn_edit_process_name.Text = "เปิดแก้ไข Process"
        End If
    End Sub



    Private Sub ListBox_process_name_Click(sender As Object, e As EventArgs) Handles ListBox_process_name.Click
        Me.txtbox_process_name.Text = Me.ListBox_process_name.Text
        Old_Process_name = Me.txtbox_process_name.Text
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        SetAllConnectionDB()

        Try
            If MsgBox("คุณแน่ใจหรือไม่ว่าจะทำการเปลี่ยน Process name นี้ การเปลี่ยนนี้ จะถูกเปลี่ยนใน member ด้วย", vbYesNo, "แจ้งเตือน") = vbYes Then
                StringSQL = ""
                StringSQL = StringSQL & " UPDATE T_PROCESS_GROUP SET"
                StringSQL = StringSQL & " PROCESS_NAME = '" & Me.txtbox_process_name.Text & "'"
                StringSQL = StringSQL & " WHERE PROCESS_NAME ='" & Old_Process_name & "'"
                ClsUpdate.Update(Connection, StringSQL)

                StringSQL = ""
                StringSQL = StringSQL & " UPDATE MEMBER SET"
                StringSQL = StringSQL & " emp_group_work_desc = '" & Me.txtbox_process_name.Text & "'"
                StringSQL = StringSQL & " WHERE emp_group_work_desc ='" & Old_Process_name & "'"
                ClsUpdate.Update(Connection, StringSQL)

                SetAllConnectionDB_Smart()
                StringSQL = ""
                StringSQL = StringSQL & " UPDATE MEMBER SET"
                StringSQL = StringSQL & " emp_group_work_desc = '" & Me.txtbox_process_name.Text & "'"
                StringSQL = StringSQL & " WHERE emp_group_work_desc ='" & Old_Process_name & "'"
                ClsUpdate.Update(Connection, StringSQL)

                SetAllConnectionDB()
                Load_Process()
                MsgBox("เปลี่ยน process name เรียบร้อย")

            End If

        Catch ex As Exception
            MsgBox("โปรแกรม error " & ex.Message)
        End Try

    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            StringSQL = ""
            StringSQL = StringSQL & "INSERT T_PROCESS_GROUP(PROCESS_NAME) VALUES('" & Me.txtbox_process_name.Text & "')"
            ClsInsert.Insert(Connection, StringSQL)
            Load_Process()
            MsgBox("เพิ่มข้อมูลเรียบร้อย")
        Catch ex As Exception
            MsgBox("โปรแกรม error " & ex.Message)
        End Try
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Try
            StringSQL = ""
            StringSQL = StringSQL & "DELETE FROM T_PROCESS_GROUP WHERE PROCESS_NAME =  '" & Me.txtbox_process_name.Text & "'"
            ClsInsert.Insert(Connection, StringSQL)
            Load_Process()
            MsgBox("ลบข้อมูลแล้ว")
        Catch ex As Exception
            MsgBox("โปรแกรม error " & ex.Message)
        End Try
    End Sub
End Class