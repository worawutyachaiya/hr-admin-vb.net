Public Class frmAddMemberSection
    Private strQ As String = ""
    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(7).Value = Me.cbbSection.Text
        Me.Close()
    End Sub

    Private Sub frmAddMemberSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        strQ = ""
        strQ = strQ & "  select * "
        strQ = strQ & "  from set_section "
        ClsGetData.GetSection(Connection, Me.cbbSection, strQ)
    End Sub
End Class