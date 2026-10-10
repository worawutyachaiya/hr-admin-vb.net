Public Class Cls_ClickCurrentGridView
    Public Row As Integer = 0

    Public Sub ClickGridview(ByRef GridMembers As DataGridView)
        If GridMembers Is Nothing OrElse GridMembers.Rows.Count = 0 Then
            Row = 0
            Exit Sub
        End If

        If Row < 0 Then Row = 0
        If Row >= GridMembers.Rows.Count Then Row = GridMembers.Rows.Count - 1

        GridMembers.Rows(Row).Selected = True
        If GridMembers.Rows(Row).Visible Then
            GridMembers.FirstDisplayedScrollingRowIndex = Row
        End If

    End Sub

End Class
