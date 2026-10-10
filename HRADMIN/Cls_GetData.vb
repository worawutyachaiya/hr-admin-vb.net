Imports MySql.Data.MySqlClient
Public Class Cls_GetData
    Dim ClsSetDataGridView = New Cls_SetDataGridView
    Dim Da As MySqlDataAdapter
    Dim Dt As DataTable
    Public Overloads Sub GetLeave(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String)
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        ClsSetDataGridView.SetDataGridView(i_Connection, iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Sub GetLeaveAmount(i_Connection As MySqlConnection, ByRef remian As Double, strQ As String)
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            remian = record("remain").ToString
        Next
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Sub GetLeaveAL_EMERGENCY(i_Connection As MySqlConnection, ByRef remian As Double, strQ As String)
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            remian = record("remain").ToString
        Next
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Sub GetLeaveAL_RATIO(i_Connection As MySqlConnection, ByRef remian As Double, strQ As String)
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            remian = record("remain").ToString
        Next
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Sub GetRequestLeave(i_Connection As MySqlConnection, ByRef LeaveQtyAL As Double, ByRef LeaveQtyAL_RATIO As Double, strQ As String)
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            LeaveQtyAL = record("LeaveQtyAL").ToString
            LeaveQtyAL_RATIO = record("LeaveQtyAL_RATIO").ToString
        Next
        i_Connection.Close()
        i_Connection = Nothing
    End Sub


    Public Overloads Sub GetDepartment(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef Department(,) As String)
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim Department_clone(Dt.Rows.Count, 1) As String
        For Each record In Dt.Rows
            Department_clone(countRow, 0) = record("DEPT_NAME")
            Department_clone(countRow, 1) = record("DEPT_DESC")
            countRow = countRow + 1
        Next
        Department = Department_clone
        ClsSetDataGridView.SetDataGridViewDepartMent(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Function GetData(i_Connection As MySqlConnection, strQ As String) As Boolean
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
        i_Connection.Close()
        i_Connection = Nothing
    End Function


    Public Overloads Function GetDataGroupName(i_Connection As MySqlConnection, strQ As String) As String()
        Dim result As New List(Of String)
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        If Dt.Rows.Count > 0 Then
            For Each record In Dt.Rows
                result.Add(record("process_name"))
            Next
        End If
        Return result.ToArray()
        i_Connection.Close()
        i_Connection = Nothing
    End Function

    Public Overloads Sub GetDepartment(i_Connection As MySqlConnection, ByRef Commbobox As ComboBox, strQ As String)
        Commbobox.Items.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            Commbobox.Items.Add(record("DEPT_NAME"))
        Next
        Commbobox.SelectedIndex = -1
        i_Connection.Close()
        i_Connection = Nothing
    End Sub



    Public Overloads Sub GetFlow(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef Flow(,) As String)
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim Flow_clone(Dt.Rows.Count, 6) As String
        For Each record In Dt.Rows
            Flow_clone(countRow, 0) = record("nameFlow") 'Left(record("nameFlow").ToString(), Len(record("nameFlow").ToString()) - 5)
            Flow_clone(countRow, 1) = record("approveNo1").ToString()
            Flow_clone(countRow, 2) = record("approveNo2").ToString()
            Flow_clone(countRow, 3) = record("approveNo3").ToString()
            Flow_clone(countRow, 4) = record("approveNo4").ToString()
            Flow_clone(countRow, 5) = record("approveNo5").ToString()
            countRow = countRow + 1
        Next
        Flow = Flow_clone
        ClsSetDataGridView.SetDataGridViewFlow(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub
    Public Overloads Sub GetHolidays(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef Holidays(,) As String)
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim Holiday_clone(Dt.Rows.Count, 2) As String
        For Each record In Dt.Rows
            Holiday_clone(countRow, 0) = Format(record("day_holiday"), "dd-MMM-yyyy")
            Holiday_clone(countRow, 1) = record("title_holiday").ToString()
            Holiday_clone(countRow, 2) = record("holiday_code").ToString()
            countRow = countRow + 1
        Next
        'Array.Clear(Holidays, 0, Holidays.Length)
        Holidays = Holiday_clone
        ClsSetDataGridView.SetDataGridViewHolidays(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub


    Public Overloads Sub GetMembers(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef Members(,) As String)
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim Member_clone(Dt.Rows.Count - 1, Dt.Columns.Count - 4) As String
        For Each record In Dt.Rows
            Member_clone(countRow, 0) = record("empCode").ToString()
            Member_clone(countRow, 1) = record("empName").ToString()
            Member_clone(countRow, 2) = record("empSurname").ToString
            Member_clone(countRow, 3) = record("empSex").ToString()
            Member_clone(countRow, 4) = record("empEmail").ToString()
            Member_clone(countRow, 5) = record("empPcode").ToString()
            Member_clone(countRow, 6) = record("empPosition").ToString()
            Member_clone(countRow, 7) = record("empSection").ToString()
            Member_clone(countRow, 8) = record("empDept").ToString()
            Member_clone(countRow, 9) = record("deptFlow").ToString()
            Member_clone(countRow, 10) = Format(record("empStartWork"), "dd-MMM-yyyy")
            Member_clone(countRow, 11) = Format(record("empBirthday"), "dd-MMM-yyyy")
            Member_clone(countRow, 12) = record("empExp").ToString()
            Member_clone(countRow, 13) = record("bus_position").ToString()
            Member_clone(countRow, 14) = record("emp_group").ToString()
            Member_clone(countRow, 15) = record("emp_group_work_desc").ToString()
            countRow = countRow + 1
        Next
        'Array.Clear(Members, 0, Members.Length)
        Members = Member_clone
        ClsSetDataGridView.SetDataGridViewMembers(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub


    Public Overloads Sub GetSection(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef Section(,) As String)
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0, countIndex As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim Section_clone(Dt.Rows.Count, Dt.Columns.Count - 1) As String
        For Each record In Dt.Rows
            Section_clone(countRow, 0) = record("SECT_NAME")
            Section_clone(countRow, 1) = record("DEPT_NAME")
            countRow = countRow + 1
        Next
        'Array.Clear(Section, 0, Section.Length)
        Section = Section_clone
        ClsSetDataGridView.SetDataGridViewSection(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Sub GetSection(i_Connection As MySqlConnection, ByRef Commbobox As ComboBox, strQ As String)
        Commbobox.Items.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim Department_clone(Dt.Rows.Count, 0) As String
        For Each record In Dt.Rows
            Commbobox.Items.Add(record("SECT_NAME"))
        Next
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Sub GetFlow(i_Connection As MySqlConnection, ByRef Commbobox As ComboBox, strQ As String)
        Commbobox.Items.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            Commbobox.Items.Add(record("nameFlow")) 'Left(record("nameFlow").ToString(), Len(record("nameFlow").ToString()) - 5)
        Next
        Commbobox.SelectedIndex = 0
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    '#=======================================================================================
    Public Overloads Sub GetPCode(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef Pcode(,) As String)
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0, countIndex As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim Pcode_clone(Dt.Rows.Count, 0) As String
        For Each record In Dt.Rows

            Pcode_clone(countRow, 0) = record("PCODE")
            countIndex = countIndex + 1
            countRow = countRow + 1
        Next
        Pcode = Pcode_clone
        ClsSetDataGridView.SetDataGridViewPcode(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Sub GetPCode(i_Connection As MySqlConnection, ByRef Commbobox As ComboBox, strQ As String)
        Commbobox.Items.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            Commbobox.Items.Add(record("PCODE").ToString())
        Next
        Commbobox.SelectedIndex = 0
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    '=======================================================================================#

    '#=======================================================================================
    Public Overloads Sub GetPosition(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef Position(,) As String)
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0, countIndex As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim Position_clone(Dt.Rows.Count, 0) As String
        For Each record In Dt.Rows
            Position_clone(countRow, 0) = record("POSITION")

            countRow = countRow + 1
        Next
        Position = Position_clone
        ClsSetDataGridView.SetDataGridViewPosition(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    Public Overloads Sub GetPosition(i_Connection As MySqlConnection, ByRef Commbobox As ComboBox, strQ As String)
        Commbobox.Items.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            Commbobox.Items.Add(record("POSITION").ToString())
        Next
        Commbobox.SelectedIndex = 0
        i_Connection.Close()
        i_Connection = Nothing
    End Sub
    '=======================================================================================#

    Public Sub GetSettingLeave(i_Connection As MySqlConnection, ByRef dataTable As DataTable, strQ As String)
        dataTable.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    '=========================================================================================================================
    Public Overloads Sub GetRemainLeave(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef RemainLeave(,) As String)
        'iGridview.Rows.Clear()
        Dim countRow As Integer = 0, countIndex As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim RemainLeave_clone(Dt.Rows.Count, Dt.Columns.Count - 1) As String
        For Each record In Dt.Rows
            RemainLeave_clone(countRow, 0) = record("empCode")
            RemainLeave_clone(countRow, 1) = record("Name")
            RemainLeave_clone(countRow, 2) = record("Surname")
            RemainLeave_clone(countRow, 3) = record("TYPE_LEAVE")
            RemainLeave_clone(countRow, 4) = record("REMAIN")
            countRow = countRow + 1
        Next
        RemainLeave = RemainLeave_clone
        ClsSetDataGridView.SetDataGridViewRemainLeave(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub


    '=================================================================================
    Public Overloads Sub GetEmpCodeSpecial(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef empCodeSpecial As String())
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0, countIndex As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim empCodeSpecial_clone(Dt.Rows.Count) As String
        For Each record In Dt.Rows
            empCodeSpecial_clone(countRow) = record("empCode")
            countRow = countRow + 1
        Next
        empCodeSpecial = empCodeSpecial_clone
        ClsSetDataGridView.SetDataGridViewEmpCodeSpecial(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub

    '=================================================================================
    Public Overloads Sub GetBusPosition(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef BusPosition As String())
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim busPosition_clone(Dt.Rows.Count) As String
        For Each record In Dt.Rows
            busPosition_clone(countRow) = record("bus_position")
            countRow = countRow + 1
        Next
        BusPosition = busPosition_clone
        ClsSetDataGridView.SetDataGridViewBusPosition(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub


    Public Overloads Sub GetBusPosition(i_Connection As MySqlConnection, ByRef Combobox As ComboBox, strQ As String)
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            Combobox.Items.Add(record("bus_position"))
        Next
        i_Connection.Close()
        i_Connection = Nothing
    End Sub
    '=================================================================================
    '=================================================================================
    Public Overloads Sub GetAccumulateAL(i_Connection As MySqlConnection, iGridview As DataGridView, strQ As String, ByRef AccumulateAl As String(,))
        iGridview.Rows.Clear()
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Dim array_clone(Dt.Rows.Count, Dt.Columns.Count) As String
        For Each record In Dt.Rows
            array_clone(countRow, 0) = record("year").ToString
            array_clone(countRow, 1) = record("qty").ToString
            countRow = countRow + 1
        Next
        AccumulateAl = array_clone
        ClsSetDataGridView.SetDataGridViewAccumulateAl(iGridview, Dt)
        i_Connection.Close()
        i_Connection = Nothing
    End Sub



    Public Function GetData1(i_Connection As MySqlConnection, strQ As String) As DataTable
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        Return Dt
    End Function

    Public Overloads Sub GetTotal_AL(i_Connection As MySqlConnection, ByRef Total_AL As Double, strQ As String)
        Dim countRow As Integer = 0
        CheckConnection(i_Connection)
        Da = New MySqlDataAdapter(strQ, i_Connection)
        Dt = New DataTable
        Da.Fill(Dt)
        For Each record In Dt.Rows
            Total_AL = record("Total_AL").ToString
        Next
        i_Connection.Close()
        i_Connection = Nothing
    End Sub
End Class

