Imports MySql.Data.MySqlClient

Public Class frmAddMemberFlow
    Private strQ As String
    Private gridFlowList As DataGridView
    Private selectedFlowName As String = ""

    Private Sub frmAddMemberFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFlowGrid()
        LoadFlowList()
    End Sub

    Private Sub InitializeFlowGrid()
        If Not gridFlowList Is Nothing Then Exit Sub

        Me.Text = "Select Flow"
        Me.ClientSize = New Size(1120, 560)
        Me.MinimumSize = New Size(900, 420)
        Me.MaximizeBox = True
        Me.MinimizeBox = False

        Me.Label1.Text = "Flow"
        Me.Label1.Location = New Point(12, 12)
        Me.cbbFlow.Visible = False

        Me.cmbOk.Text = "OK"
        Me.cmbOk.Size = New Size(90, 30)
        Me.cmbOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        Me.cmbOk.Location = New Point(Me.ClientSize.Width - Me.cmbOk.Width - 12, Me.ClientSize.Height - Me.cmbOk.Height - 12)

        gridFlowList = New DataGridView()
        gridFlowList.Location = New Point(12, 35)
        gridFlowList.Size = New Size(Me.ClientSize.Width - 24, Me.ClientSize.Height - 85)
        gridFlowList.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        gridFlowList.AllowUserToAddRows = False
        gridFlowList.AllowUserToDeleteRows = False
        gridFlowList.AllowUserToResizeRows = False
        gridFlowList.MultiSelect = False
        gridFlowList.ReadOnly = True
        gridFlowList.RowHeadersVisible = False
        gridFlowList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        gridFlowList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        gridFlowList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        gridFlowList.StandardTab = True
        AddHandler gridFlowList.CellContentClick, AddressOf gridFlowList_CellContentClick

        Me.Controls.Add(gridFlowList)
    End Sub

    Private Sub LoadFlowList()
        Try
            SetAllConnectionDB()
            CheckConnection(Connection)

            strQ = ""
            strQ = strQ & " SELECT f.nameFlow, f.approveNo1, f.approveNo2, f.approveNo3, f.approveNo4, f.approveNo5 "
            strQ = strQ & " FROM flow f "
            strQ = strQ & " ORDER BY f.nameFlow "

            Dim table As New DataTable()
            Using adapter As New MySqlDataAdapter(strQ, Connection)
                adapter.Fill(table)
            End Using

            BindFlowGrid(table)
        Catch ex As Exception
            MsgBox("Cannot load flow list: " & ex.Message)
        Finally
            If Not Connection Is Nothing AndAlso Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub

    Private Sub BindFlowGrid(table As DataTable)
        gridFlowList.Columns.Clear()
        gridFlowList.Rows.Clear()

        Dim selectColumn As New DataGridViewButtonColumn()
        selectColumn.Name = "SelectAction"
        selectColumn.HeaderText = "Select"
        selectColumn.Text = "Select"
        selectColumn.UseColumnTextForButtonValue = True
        selectColumn.Width = 70
        gridFlowList.Columns.Add(selectColumn)

        AddTextColumn("FlowName", "Flow", 260)
        AddTextColumn("Checker1", "Checker1", 105)
        AddTextColumn("Checker2", "Checker2", 105)
        AddTextColumn("Approve1", "Approve1", 105)
        AddTextColumn("Approve2", "Approve2", 105)
        AddTextColumn("Approve3", "Approve3", 105)

        For Each row As DataRow In table.Rows
            Dim rowIndex As Integer = gridFlowList.Rows.Add()
            Dim gridRow As DataGridViewRow = gridFlowList.Rows(rowIndex)

            gridRow.Cells("FlowName").Value = GetText(row, "nameFlow")
            gridRow.Cells("Checker1").Value = GetText(row, "approveNo1")
            gridRow.Cells("Checker2").Value = GetText(row, "approveNo2")
            gridRow.Cells("Approve1").Value = GetText(row, "approveNo3")
            gridRow.Cells("Approve2").Value = GetText(row, "approveNo4")
            gridRow.Cells("Approve3").Value = GetText(row, "approveNo5")
        Next
        selectedFlowName = ""
        gridFlowList.ClearSelection()
    End Sub

    Private Sub AddTextColumn(name As String, headerText As String, width As Integer)
        Dim column As New DataGridViewTextBoxColumn()
        column.Name = name
        column.HeaderText = headerText
        column.Width = width
        column.SortMode = DataGridViewColumnSortMode.Automatic
        gridFlowList.Columns.Add(column)
    End Sub

    Private Function GetText(row As DataRow, columnName As String) As String
        If row Is Nothing OrElse Not row.Table.Columns.Contains(columnName) Then Return ""
        If row(columnName) Is DBNull.Value Then Return ""
        Return Trim(Convert.ToString(row(columnName)))
    End Function

    Private Sub SelectFlowRow(rowIndex As Integer)
        If rowIndex < 0 OrElse rowIndex >= gridFlowList.Rows.Count Then Exit Sub

        Dim value As Object = gridFlowList.Rows(rowIndex).Cells("FlowName").Value
        selectedFlowName = Trim(Convert.ToString(value))

        gridFlowList.ClearSelection()
        gridFlowList.Rows(rowIndex).Selected = True
        gridFlowList.CurrentCell = gridFlowList.Rows(rowIndex).Cells("FlowName")
    End Sub



    Private Sub gridFlowList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub
        If gridFlowList.Columns(e.ColumnIndex).Name = "SelectAction" Then
            SelectFlowRow(e.RowIndex)
        End If
    End Sub



    Private Sub cmbOk_Click(sender As Object, e As EventArgs) Handles cmbOk.Click
        If selectedFlowName = "" Then
            MsgBox("Please select flow.")
            Exit Sub
        End If

        If ClsClickCurrentGridView.Row < 0 OrElse ClsClickCurrentGridView.Row >= frmMember.GridMembers.Rows.Count Then
            MsgBox("Cannot set flow: selected member row is invalid.")
            Exit Sub
        End If

        frmMember.GridMembers.Rows(ClsClickCurrentGridView.Row).Cells(9).Value = selectedFlowName
        Me.Close()
    End Sub
End Class