Public Class frmAddGroup

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(14).Value = Me.ComboBoxGroup.Text
        Me.Close()
    End Sub

    Private Sub frmAddGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ComboBoxGroup.SelectedIndex = 0
    End Sub
End Class