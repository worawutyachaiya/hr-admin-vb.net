Public Class frmAddMemberBirthDay

    Private Sub frmAddMemberBirthDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ClsSetDateTimerPickerFormat As New Cls_SetDateTimerPickerformat
        ClsSetDateTimerPickerFormat.fcnSetDateTimerPickerformat(Me.DatePickerBirthDay)
    End Sub

    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(11).Value = Me.DatePickerBirthDay.Value.ToString("dd-MMM-yyyy")
        Me.Close()
    End Sub

End Class