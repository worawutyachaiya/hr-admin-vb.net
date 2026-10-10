Public Class frmAddMemberBusPosition
    Private strq As String = ""
    Private Sub frmAddMemberBusPosition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        ClsUpdateData = New Cls_UpdateData
        strQ = ""
        strq = strq & "  select BUS_POSITION "
        strq = strq & "  from set_bus_position order by BUS_POSITION "
        Me.cbbBusPosition.Items.Add("-")
        ClsGetData.GetBusPosition(Connection, Me.cbbBusPosition, strq)
    End Sub

    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(13).Value = Me.cbbBusPosition.Text
        Me.Close()
    End Sub
End Class