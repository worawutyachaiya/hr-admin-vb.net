Public Class frmAddMemberPosition
    Private strQ As String = ""
    Private Sub frmAddMemberPosition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        strQ = ""
        strQ = strQ & "  select * "
        strQ = strQ & "  from set_position "
        ClsGetData.GetPosition(Connection, Me.cbbPosition, strQ)
    End Sub

    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(6).Value = Me.cbbPosition.Text
        Me.Close()
    End Sub
End Class