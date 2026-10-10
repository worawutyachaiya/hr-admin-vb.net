Public Class frmAddMemberSex

    Private Sub frmAddMemberSex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cbbSex.Items.Add("female")
        Me.cbbSex.Items.Add("male")
    End Sub

    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(3).Value = Me.cbbSex.Text
        Me.Close()
    End Sub
End Class