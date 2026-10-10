Public Class frmAddMemberStartWork

    Private Sub frmAddMemberStartWork_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ClsSetDateTimerPickerFormat As New Cls_SetDateTimerPickerformat
        ClsSetDateTimerPickerFormat.fcnSetDateTimerPickerformat(Me.DatePickerStartWork)
    End Sub

    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(10).Value = Me.DatePickerStartWork.Value.ToString("dd-MMM-yyyy")
        Me.Close()
    End Sub
End Class