Public Class frmAddMemberPCode
    Private strQ As String
    Private Sub frmAddMemberPCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        strQ = ""
        strQ = strQ & "  select * "
        strQ = strQ & "  from set_pcode "
        ClsGetData.GetPCode(Connection, Me.cbbPCode, strQ)
    End Sub

    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(5).Value = Me.cbbPCode.Text
        Me.Close()
    End Sub
End Class