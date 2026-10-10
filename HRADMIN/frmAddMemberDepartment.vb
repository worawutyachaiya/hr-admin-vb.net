Public Class frmAddMemberDepartment
    Private strQ As String = ""
    Private Sub frmAddMemberDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        strQ = ""
        strQ = strQ & "  select * "
        strQ = strQ & "  from set_dept "
        ClsGetData.GetDepartment(Connection, Me.cbbDepartment, strQ)
    End Sub

    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(8).Value = Me.cbbDepartment.Text
        Me.Close()
    End Sub
End Class