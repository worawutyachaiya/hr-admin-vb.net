Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class frmMember

    Private Function SyncFlowChanged(employeeId As String) As Boolean

        Try

            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

            Dim url As String = url_member_flow_change

            Dim payload As New Dictionary(Of String, Object)
            payload("EMPLOYEE_ID") = employeeId
            payload("UPDATE_BY") = CurrentUserId
            Dim jsonData As String = JsonConvert.SerializeObject(payload)

            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/json"

            Dim bytes As Byte() = Encoding.UTF8.GetBytes(jsonData)
            request.ContentLength = bytes.Length

            Using stream = request.GetRequestStream()
                stream.Write(bytes, 0, bytes.Length)
            End Using

            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Dim result As String
            Using reader As New StreamReader(response.GetResponseStream())
                result = reader.ReadToEnd()
            End Using

            Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result)

            Return Convert.ToBoolean(jsonResult("Status"))

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function SyncMfgGroupForMember(employeeId As String, dept As String) As Boolean
        Dim mfgSync As New Cls_MfgGroupSync

        If mfgSync.SyncMember(employeeId, dept) = False Then
            MsgBox("Sync MFG Group Failed : " & mfgSync.LastErrorMessage)
            Return False
        ElseIf mfgSync.LastWarningMessage <> "" Then
            MsgBox("Sync MFG Group Warning : " & mfgSync.LastWarningMessage)
        End If

        Return True
    End Function

    Private Function SyncEngineerGroupForMember(employeeId As String, dept As String, section As String) As Boolean
        Dim engineerSync As New Cls_EngineerGroupSync

        If engineerSync.SyncMember(employeeId, dept, section) = False Then
            MsgBox("Sync Engineer Group Failed : " & engineerSync.LastErrorMessage)
            Return False
        ElseIf engineerSync.LastWarningMessage <> "" Then
            MsgBox("Sync Engineer Group Warning : " & engineerSync.LastWarningMessage)
        End If

        Return True
    End Function

    Private Function IsMemberAssignmentSaved(checkConnection As MySqlConnection, tableName As String, employeeId As String, dept As String, section As String) As Boolean
        ' Compare Unicode values on the server. The legacy driver cannot decode utf8mb3 metadata.
        ' Return only the ASCII count as latin1, without changing the stored text or connection charset.
        Dim query As String = "SELECT CAST(COUNT(*) AS CHAR CHARACTER SET latin1) FROM " & tableName & _
            " WHERE empCode = @empCode" & _
            " AND LOWER(TRIM(COALESCE(empDept, ''))) = LOWER(TRIM(@empDept))" & _
            " AND LOWER(TRIM(COALESCE(empSection, ''))) = LOWER(TRIM(@empSection))"

        Using command As New MySqlCommand(query, checkConnection)
            command.Parameters.AddWithValue("@empCode", employeeId)
            command.Parameters.AddWithValue("@empDept", dept)
            command.Parameters.AddWithValue("@empSection", section)
            Dim matchingCount As Object = command.ExecuteScalar()
            If matchingCount Is Nothing OrElse matchingCount Is DBNull.Value Then Return False
            Return Convert.ToInt32(matchingCount) = 1
        End Using
    End Function

    Private Function IsDbLeaveAssignmentSaved(employeeId As String, dept As String, section As String) As Boolean
        Try
            Dim dbConnector As New Cls_ConnectDbMysql
            Using checkConnection As New MySqlConnection
                dbConnector.ConnectDBMySql(checkConnection)
                checkConnection.Open()

                Return IsMemberAssignmentSaved(checkConnection, "member", employeeId, dept, section)
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function UpdatePersonAssignmentAndSyncGroups(employeeId As String, dept As String, section As String, departmentChanged As Boolean) As Boolean
        If Not IsDbLeaveAssignmentSaved(employeeId, dept, section) Then
            MsgBox("db_leave.member department/section was not saved. person and department groups were not synced.")
            Return False
        End If

        Try
            Dim dbConnector As New Cls_ConnectDbMysql
            Using updateConnection As New MySqlConnection
                dbConnector.ConnectDBMySql_Smart(updateConnection)
                updateConnection.Open()

                Using command As New MySqlCommand("UPDATE member_fed SET empDept = @empDept, empSection = @empSection WHERE empCode = @empCode", updateConnection)
                    command.Parameters.AddWithValue("@empDept", dept)
                    command.Parameters.AddWithValue("@empSection", section)
                    command.Parameters.AddWithValue("@empCode", employeeId)
                    command.ExecuteNonQuery()
                End Using

                If Not IsMemberAssignmentSaved(updateConnection, "member_fed", employeeId, dept, section) Then
                    MsgBox("Update person.member_fed failed. Department groups were not synced.")
                    Return False
                End If
            End Using
        Catch ex As Exception
            MsgBox("Update person.member_fed failed. Department groups were not synced : " & ex.Message)
            Return False
        End Try

        Dim mfgSucceeded As Boolean = True
        If departmentChanged Then mfgSucceeded = SyncMfgGroupForMember(employeeId, dept)
        Dim engineerSucceeded As Boolean = SyncEngineerGroupForMember(employeeId, dept, section)
        Return mfgSucceeded AndAlso engineerSucceeded
    End Function
    Private Member(,) As String
    Private strq As String = ""
    Private CheckPressButton As Integer = 0
    Private Const PahtAttach = "\\192.168.0.249\myfile"
    Private countTimer As Integer = 0

    Private Sub frmMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        strq = ""
        strq = strq & "  select * "
        strq = strq & "  from member where empcode_resign is null order by empCode "
        LoadForm(strq)
        strq = ""
        strq = strq & "  select * "
        strq = strq & "  from set_dept "
        ClsGetData.GetDepartment(Connection, Me.cbbDept, strq)

        GridMembers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        With GridMembers
            ' คอลัมน์ที่ต้องการให้อยู่กลาง
            .Columns("Pcode").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Sex").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Exp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Team").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    Private Sub LoadForm(strQ As String)
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()

        ClsGetData.GetMembers(Connection, Me.GridMembers, strQ, Member)

        cbmEdit.Visible = False
        cmbDeleteSelected.Visible = False
        btnResigned.Visible = False



    End Sub
    Private Sub cmbSearchEmpCode_Click(sender As Object, e As EventArgs) Handles cmbSearchEmpCode.Click
        ClsGetData = New Cls_GetData
        SetAllConnectionDB()

        strq = ""
        strq = strq & "  select * "
        strq = strq & "  from member "
        strq = strq & "  where empCode like '%" & UCase(Trim(Me.txtEmpCode.Text)) & "%' and empcode_resign is null"
        ClsGetData.GetMembers(Connection, Me.GridMembers, strq, Member)
        CheckPressButton = 1

        If txtEmpCode.Text = "" Then
            cbmEdit.Visible = False
            cmbDeleteSelected.Visible = False
            btnResigned.Visible = False
        Else
            cbmEdit.Visible = True
            cmbDeleteSelected.Visible = True
            btnResigned.Visible = True
        End If


    End Sub

    Private Sub GridMembers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridMembers.CellClick

        If e.RowIndex < 0 Then Exit Sub

        If e.ColumnIndex = 3 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberSex.Show()
        ElseIf e.ColumnIndex = 5 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberPCode.Show()
        ElseIf e.ColumnIndex = 6 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberPosition.Show()
        ElseIf e.ColumnIndex = 7 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberSection.Show()
        ElseIf e.ColumnIndex = 8 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberDepartment.Show()
        ElseIf e.ColumnIndex = 9 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberFlow.ShowDialog()
        ElseIf e.ColumnIndex = 10 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberStartWork.Show()
        ElseIf e.ColumnIndex = 11 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberBirthDay.Show()
        ElseIf e.ColumnIndex = 13 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberBusPosition.Show()
        ElseIf e.ColumnIndex = 14 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddGroup.Show()
        ElseIf e.ColumnIndex = 15 Then
            ClsClickCurrentGridView.Row = e.RowIndex
            frmAddMemberGroupWorkDesc.Show()
        End If
    End Sub


    'Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
    '    SetAllConnectionDB()
    '    ClsGetData = New Cls_GetData
    '    ClsInsert = New Cls_Insert
    '    ClsEncodMD5 = New Cls_FcnEncodMD5
    '    Dim row As Integer = Me.GridMembers.Rows.Count - 2
    '    Dim column As Integer = Me.GridMembers.Columns.Count - 2
    '    Dim empCode As String, empName As String, empSurname As String, empSex As String, empPass As String, empEmail As String
    '    Dim empPcode As String, empPosition As String, empSection As String, empDept As String, empDeptFlow As String
    '    Dim empStartWork As String, empBirthday As String, empExp As Integer
    '    Dim tempStr As String = ""
    '    Dim tempArray As String() = {}

    '    For i = 0 To row
    '        ' For j = 0 To column

    '        empCode = Me.GridMembers.Rows(i).Cells(0).Value
    '        'tempStr = Trim(Me.GridMembers.Rows(i).Cells(1).Value)
    '        empName = Me.GridMembers.Rows(i).Cells(1).Value
    '        empSurname = Me.GridMembers.Rows(i).Cells(2).Value
    '        empSex = Me.GridMembers.Rows(i).Cells(3).Value

    '        'If tempStr <> "" Then
    '        '    tempArray = tempStr.Split(" ")
    '        '    If tempArray.Length > 1 Then
    '        '        empName = tempArray(0)
    '        '        empSurname = tempArray(1)
    '        '    Else
    '        '        empName = tempArray(0)
    '        '        empSurname = ""
    '        '    End If

    '        'Else
    '        '    empName = ""
    '        '    empSurname = ""
    '        'End If
    '        empEmail = IIf(Me.GridMembers.Rows(i).Cells(4).Value = "", "-", Me.GridMembers.Rows(i).Cells(4).Value)
    '        empPcode = Me.GridMembers.Rows(i).Cells(5).Value
    '        empPosition = Me.GridMembers.Rows(i).Cells(6).Value
    '        empSection = Me.GridMembers.Rows(i).Cells(7).Value
    '        empDept = Me.GridMembers.Rows(i).Cells(8).Value
    '        empDeptFlow = Me.GridMembers.Rows(i).Cells(9).Value
    '        empStartWork = fcnConvertDate(Me.GridMembers.Rows(i).Cells(10).Value)
    '        empBirthday = fcnConvertDate(Me.GridMembers.Rows(i).Cells(11).Value)
    '        empExp = Me.GridMembers.Rows(i).Cells(12).Value
    '        'empPass = ClsEncodMD5.EncodePasswordMD5(empCode)

    '        If empCode = Nothing Or empName = Nothing Or empEmail = Nothing Or empPcode = Nothing Or empPosition = Nothing Or empSection = Nothing Or empDept = Nothing Or empDeptFlow = Nothing Or empStartWork = Nothing Or empBirthday = Nothing Or empExp = 0 Then
    '            MsgBox("ข้อมูลไม่ครบ")
    '            Exit Sub
    '        Else
    '            strq = ""
    '            strq = strq & "  Select empCode From member Where empCode ='" & empCode & "'"
    '            If Not ClsGetData.GetData(Connection, strq) Then
    '                empPass = ClsEncodMD5.EncodePasswordMD5(empCode)
    '                strq = ""
    '                strq = strq & "  Insert into member(empCode,empName,empSurname,empSex"
    '                strq = strq & " ,empPass,empEmail,empPcode,empPosition,empSection,empDept"
    '                strq = strq & " ,deptFlow,empStartwork,empBirthday,empExp) "
    '                strq = strq & "  Values('" & empCode & "','" & empName & "','"
    '                strq = strq & empSurname & "','" & empSex & "','" & empPass & "','" & empEmail & "','"
    '                strq = strq & empPcode & "','" & empPosition & "','" & empSection & "','" & empDept & "','"
    '                strq = strq & empDeptFlow & "','" & empStartWork & "','" & empBirthday & "','" & empExp & "')"
    '                ClsInsert.Insert(Connection, strq)

    '                strq = ""
    '                strq = strq & "  Insert into remain_leave(empCode,remainAL,remainBL,remainBDL,remainSL,remainFL,remainPL,remainM1L,remainM2L,remainM3L,remainSPL)"
    '                strq = strq & "  Values('" & empCode & "','0','0','0','30','0','0','0','0','0','0')"
    '                ClsInsert.Insert(Connection, strq)

    '                If CheckPressButton = 0 Then
    '                    strq = ""
    '                    strq = strq & "  Select * From member "
    '                    LoadForm(strq)
    '                ElseIf CheckPressButton = 1 Then
    '                    strq = ""
    '                    strq = strq & "  Select * From member Where empCode ='" & UCase(Trim(Me.txtEmpCode.Text)) & "'"
    '                    LoadForm(strq)
    '                ElseIf CheckPressButton = 2 Then
    '                    strq = ""
    '                    strq = strq & "  Select * From member Where empDept ='" & Me.cbbDept.Text & "'"
    '                    LoadForm(strq)
    '                End If

    '                MsgBox("ทำการเพิ่มข้อมูลเรียบร้อย")
    '            End If
    '            End If
    '    Next i
    '    ' If checkUpdatting Then 
    'End Sub



    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData
        ClsSQLDateFormat = New Cls_SQLDateFormat

        Dim row As Integer = Me.GridMembers.Rows.Count - 1
        Dim column As Integer = Me.GridMembers.Columns.Count - 1
        'Dim NameFlow As String, Checker1 As String, Checker2 As String, Approve1 As String, Approve2 As String, Approve3 As String
        Dim value As String = ""
        Dim strQUpdate As String = ""
        Dim strQWhere As String = ""
        Dim Count As Integer = 0
        Dim CheckUpdatting As Boolean = False
        If MsgBox("คุณต้องการที่จะแก้ไขข้อมูลหรือไม่ ", vbYesNo, "ยืนยัน") = vbYes Then
            For i = 0 To row
                strq = ""
                strQWhere = " where mem.empCode ='" & Member(i, 0) & "'"
                For j = 0 To column
                    On Error Resume Next

                    ' If j <> 13 Then
                    value = Me.GridMembers.Rows(i).Cells(j).Value
                    If value <> Member(i, j) Then
                        strq = ""
                        If j = 0 Then
                            strq = "select empCode from member where empCode ='" & value & "'"

                            If Not ClsGetData.GetData(Connection, strq) Then
                                strq = ""
                                strq = strq & "update member m, remain_leave re, al_bl_status albl, request_leave req set "
                                strq = strq & "m.empCode = '" & value & "', re.empCode = '" & value & "', albl.empCode ='" & value & "', req.empCode ='" & value & "'  "
                                strq = strq & "where m.empCode ='" & value & "' and re.empCode = '" & Member(i, 0) & "' and albl.empCode='" & Member(i, 0) & "' "
                                strq = strq & "and  req.empCode = '" & Member(i, 0) & "' "

                                ClsUpdateData.Update(Connection, strq)

                                'strq = ""
                                'strq = "update al_bl_status set empCode='" & value & "' where empCode = '" & Member(i, 0) & "'"
                                'ClsUpdateData.Update(Connection, strq)

                                'strq = ""
                                'strq = "update request_leave set empCode='" & value & "' where empCode = '" & Member(i, 0) & "'"
                                'ClsUpdateData.Update(Connection, strq)
                            Else
                                MsgBox("รหัสพนักงานนี้มีอยู่แล้ว ไม่สามารถเปลี่ยนแปลงได้")
                                Exit Sub
                            End If

                        ElseIf j = 1 Then

                            strq = " update member mem set "
                            strq = strq & " mem.empName ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)

                        ElseIf j = 2 Then
                            strq = " update member mem set "
                            strq = strq & " mem.empSurname ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)


                        ElseIf j = 3 Then
                            strq = " update member mem set "
                            strq = strq & " mem.empSex ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 4 Then
                            strq = " update member mem set "
                            strq = strq & " mem.empEmail ='" & value & "'"
                            ClsUpdateData.Update(Connection, strQUpdate & strq & strQWhere)
                        ElseIf j = 5 Then
                            strq = " update member mem set "
                            strq = strq & " mem.empPcode ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 6 Then
                            strq = " update member mem set "
                            strq = strq & " mem.empPosition ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 7 Then
                            strq = " update member mem set "
                            strq = strq & " mem.empSection ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)

                            strq = " update request_leave request set "
                            strq = strq & " request.empSection ='" & value & "'"
                            strq = strq & " where request.empCode ='" & Member(i, 0) & "'"
                            ClsUpdateData.Update(Connection, strq)
                        ElseIf j = 8 Then
                            strq = " update member mem set "
                            strq = strq & " mem.empDept ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)

                            strq = " update request_leave request set "
                            strq = strq & " request.empDept ='" & value & "'"
                            strq = strq & " where request.empCode ='" & Member(i, 0) & "'"
                            ClsUpdateData.Update(Connection, strq)

                        ElseIf j = 9 Then
                            strq = " update member mem set "
                            strq = strq & " mem.deptFlow ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)

                            strq = " update request_leave request set "
                            strq = strq & " request.deptFlow ='" & value & "'"
                            strq = strq & " Where request.empCode ='" & Member(i, 0) & "'"
                            ClsUpdateData.Update(Connection, strq)
                        ElseIf j = 10 Then
                            Dim startwork As Date = Me.GridMembers.Rows(i).Cells(j).Value
                            Dim s As String = ClsSQLDateFormat.SQLDateFormat(startwork)
                            strq = " update member mem set "
                            strq = strq & "mem.empStartwork ='" & ClsSQLDateFormat.SQLDateFormat(s) & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 11 Then
                            Dim birthday As Date = Me.GridMembers.Rows(i).Cells(j).Value
                            Dim b As String = ClsSQLDateFormat.SQLDateFormat(birthday)
                            strq = "  update member mem set mem.empBirthday ='" & ClsSQLDateFormat.SQLDateFormat(b) & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 12 Then
                            strq = "  update member mem set mem.empExp ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 13 Then
                            strq = "  update member mem set mem.bus_position ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 14 Then
                            strq = "  update member mem set mem.emp_group ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 15 Then
                            strq = "  update member mem set mem.emp_group_work_desc ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        End If
                        CheckUpdatting = True
                    End If
                    ' End If
                Next j
            Next i

            SetAllConnectionDB_Smart()
            For i = 0 To row
                Dim savedDept As String = Convert.ToString(Me.GridMembers.Rows(i).Cells(8).Value)
                Dim savedSection As String = Convert.ToString(Me.GridMembers.Rows(i).Cells(7).Value)
                Dim departmentChanged As Boolean = savedDept <> Member(i, 8)
                If departmentChanged OrElse savedSection <> Member(i, 7) Then
                    If Not UpdatePersonAssignmentAndSyncGroups(Member(i, 0), savedDept, savedSection, departmentChanged) Then
                        Exit Sub
                    End If
                End If

                strq = ""
                strQWhere = " where mem.empCode ='" & Member(i, 0) & "'"
                For j = 0 To column
                    On Error Resume Next

                    ' If j <> 13 Then
                    value = Me.GridMembers.Rows(i).Cells(j).Value
                    If value <> Member(i, j) Then
                        strq = ""
                        If j = 0 Then
                            strq = "select empCode from member_fed where empCode ='" & value & "'"

                            If Not ClsGetData.GetData(Connection, strq) Then
                                strq = ""
                                strq = strq & "update member_fed m set "
                                strq = strq & "m.empCode = '" & value & "' "
                                strq = strq & "where m.empCode ='" & value & "' "
                                ' strq = strq & "and  req.empCode = '" & Member(i, 0) & "' "

                                ClsUpdateData.Update(Connection, strq)

                                'strq = ""
                                'strq = "update al_bl_status set empCode='" & value & "' where empCode = '" & Member(i, 0) & "'"
                                'ClsUpdateData.Update(Connection, strq)

                                'strq = ""
                                'strq = "update request_leave set empCode='" & value & "' where empCode = '" & Member(i, 0) & "'"
                                'ClsUpdateData.Update(Connection, strq)
                            Else
                                MsgBox("รหัสพนักงานนี้มีอยู่แล้ว ไม่สามารถเปลี่ยนแปลงได้")
                                Exit Sub
                            End If

                        ElseIf j = 1 Then

                            strq = " update member_fed mem set "
                            strq = strq & " mem.empName ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)

                        ElseIf j = 2 Then
                            strq = " update member_fed mem set "
                            strq = strq & " mem.empSurname ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)


                        ElseIf j = 3 Then
                            strq = " update member_fed mem set "
                            strq = strq & " mem.empSex ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 4 Then
                            strq = " update member_fed mem set "
                            strq = strq & " mem.empEmail ='" & value & "'"
                            ClsUpdateData.Update(Connection, strQUpdate & strq & strQWhere)
                        ElseIf j = 5 Then
                            strq = " update member_fed mem set "
                            strq = strq & " mem.empPcode ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 6 Then
                            strq = " update member_fed mem set "
                            strq = strq & " mem.empPosition ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 7 Then
                            ' Department and section were saved together before this loop.

                            'strq = " update request_leave request set "
                            'strq = strq & " request.empSection ='" & value & "'"
                            'strq = strq & " where request.empCode ='" & Member(i, 0) & "'"
                            'ClsUpdateData.Update(Connection, strq)
                        ElseIf j = 8 Then
                            ' Group sync already read the final department/section pair.

                            'strq = " update request_leave request set "
                            'strq = strq & " request.empDept ='" & value & "'"
                            'strq = strq & " where request.empCode ='" & Member(i, 0) & "'"
                            'ClsUpdateData.Update(Connection, strq)

                        ElseIf j = 9 Then
                            strq = " update member_fed mem set "
                            strq = strq & " mem.deptFlow ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)

                            Dim apiResult As Boolean = SyncFlowChanged(Member(i, 0))

                            If apiResult = False Then
                                MsgBox("Sync Flow API Failed")
                            End If

                            'strq = " update request_leave request set "
                            'strq = strq & " request.deptFlow ='" & value & "'"
                            'strq = strq & " Where request.empCode ='" & Member(i, 0) & "'"
                            'ClsUpdateData.Update(Connection, strq)
                        ElseIf j = 10 Then
                            Dim startwork As Date = Me.GridMembers.Rows(i).Cells(j).Value
                            Dim s As String = ClsSQLDateFormat.SQLDateFormat(startwork)
                            strq = " update member_fed mem set "
                            strq = strq & "mem.empStartwork ='" & ClsSQLDateFormat.SQLDateFormat(s) & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 11 Then
                            Dim birthday As Date = Me.GridMembers.Rows(i).Cells(j).Value
                            Dim b As String = ClsSQLDateFormat.SQLDateFormat(birthday)
                            strq = "  update member_fed mem set mem.empBirthday ='" & ClsSQLDateFormat.SQLDateFormat(b) & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 12 Then
                            strq = "  update member_fed mem set mem.empExp ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 13 Then
                            strq = "  update member_fed mem set mem.bus_position ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 14 Then
                            strq = "  update member_fed mem set mem.emp_group ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        ElseIf j = 15 Then
                            strq = "  update member_fed mem set mem.emp_group_work_desc ='" & value & "'"
                            ClsUpdateData.Update(Connection, strq & strQWhere)
                        End If
                        CheckUpdatting = True
                    End If
                    ' End If
                Next j
            Next i

            SetAllConnectionDB()

            If CheckUpdatting Then
                If CheckPressButton = 0 Then
                    strq = ""
                    strq = strq & "  Select * From member order by empCode "
                    LoadForm(strq)
                ElseIf CheckPressButton = 1 And Me.txtEmpCode.Text IsNot Nothing Then
                    strq = ""
                    strq = strq & "  Select * From member Where empCode ='" & UCase(Trim(Me.txtEmpCode.Text)) & "'"
                    LoadForm(strq)
                ElseIf CheckPressButton = 2 And cbbDept.Text IsNot Nothing Then
                    strq = ""
                    strq = strq & "  Select * From member Where empDept ='" & Me.cbbDept.Text & "'"
                    LoadForm(strq)
                End If
                ClsClickCurrentGridView.ClickGridview(Me.GridMembers)
                MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
            End If
        End If
    End Sub

    Private Sub cmbSearcDept_Click(sender As Object, e As EventArgs) Handles cmbSearcDept.Click

        ClsGetData = New Cls_GetData
        SetAllConnectionDB()
        strq = ""
        strq = strq & "  select * "
        strq = strq & "  from member "
        strq = strq & "  where empDept ='" & Me.cbbDept.Text & "' and empcode_resign is null"
        ClsGetData.GetMembers(Connection, Me.GridMembers, strq, Member)
        CheckPressButton = 2

        cbmEdit.Visible = False
        cmbDeleteSelected.Visible = False
        btnResigned.Visible = False
    End Sub

    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click
        Dim row As Integer = Me.GridMembers.Rows.Count - 1
        Dim selected As Boolean
        Dim empCode As String = ""
        Dim CheckDelete As Boolean = False
        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete
        ClsGetFilesInFloder = New Cls_GetFilesInFloder

        empCode = Me.GridMembers.Rows(0).Cells(0).Value


        If MsgBox("คุณต้องการที่จะลบ " & empCode & " ใช่หรือไม่?", MsgBoxStyle.YesNo, "ยืนยัน") = vbYes Then
            'For i = 0 To row
            '    On Error Resume Next
            'selected = Me.GridMembers.Rows(i).Cells(16).Value
            'If selected = True Then


            strq = ""
            'strq = strq & "  delete m,r "
            'strq = strq & "  from member m LEFT JOIN request_leave r ON r.empCode = m.empCode  "
            'strq = strq & "  where m.empCode ='" & empCode & "'"

            strq = strq & " DELETE m, re, ab, pass "
            strq = strq & " FROM member   m , remain_leave   re , al_bl_status   ab, set_pass_pro pass"
            strq = strq & " WHERE m.empCode = re.empCode and  re.empCode = ab.empCode  and m.empCode ='" & empCode & "' and  pass.empCode='" & empCode & "'"
            ClsDeleteData.fcnDelete(Connection, strq)


            strq = ""
            strq = strq & "  DELETE  "
            strq = strq & "  FROM doc_leave "
            strq = strq & "  WHERE empCode ='" & empCode & "'"
            ClsDeleteData.fcnDelete(Connection, strq)


            strq = ""
            strq = strq & "  DELETE  "
            strq = strq & "  FROM request_leave "
            strq = strq & "  WHERE empCode ='" & empCode & "'"
            ClsDeleteData.fcnDelete(Connection, strq)


            ClsGetFilesInFloder.fcnGetFilesInFloder(PahtAttach, empCode)
            ' Me.GridMembers.Rows.Remove(Me.GridMembers.Rows(i))
            CheckDelete = True

            'End If
            'Next
        End If


        If CheckDelete Then
            If CheckPressButton = 0 Then
                strq = ""
                strq = strq & "  Select * From member "
                LoadForm(strq)
            ElseIf CheckPressButton = 1 Then
                strq = ""
                strq = strq & "  Select * From member Where empCode ='" & UCase(Trim(Me.txtEmpCode.Text)) & "'"
                LoadForm(strq)
            ElseIf CheckPressButton = 2 Then
                strq = ""
                strq = strq & "  Select * From member Where empDept ='" & Me.cbbDept.Text & "'"
                LoadForm(strq)
            End If
            ClsClickCurrentGridView.ClickGridview(Me.GridMembers)
        End If

    End Sub


    Private Sub ImportMemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportMemberToolStripMenuItem.Click
        Dim ClsExcel = New Cls_Excel
        Dim path As String
        path = ClsExcel.OpenExcelFile()
        If path <> "" Then
            Me.lbImportStatus.Text = "Import Status : Importing,Please wait."
            Me.Timer1.Enabled = True
            Me.Timer1.Interval = 1000
            'frmLoadingWaiting.Show()
            ClsExcel.ImportMembers(path)
            Me.GridMembers.Rows.Clear()
            strq = ""
            strq = strq & "  select * "
            strq = strq & "  from member order by empCode "
            LoadForm(strq)
            Me.Timer1.Enabled = False
            Me.lbImportStatus.Text = "Import Status : Finished."
            'frmLoadingWaiting.Close()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        countTimer = countTimer + 1
    End Sub

    Private Sub btnResigned_Click(sender As Object, e As EventArgs) Handles btnResigned.Click
        Dim row As Integer = Me.GridMembers.Rows.Count - 1
        Dim selected As Boolean
        Dim empCode As String = ""
        Dim CheckDelete As Boolean = False
        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete
        ClsGetFilesInFloder = New Cls_GetFilesInFloder

        empCode = Me.GridMembers.Rows(0).Cells(0).Value

        If MsgBox("คุณต้องการที่จะกำหนดว่า " & empCode & " ลาออกไปแล้วใช่หรือไม่?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "แจ้งเตือน") = vbYes Then
            'For i = 0 To row
            '    On Error Resume Next
            '    selected = Me.GridMembers.Rows(i).Cells(16).Value
            '    If selected = True Then


            strq = ""
            'strq = strq & "  delete m,r "
            'strq = strq & "  from member m LEFT JOIN request_leave r ON r.empCode = m.empCode  "
            'strq = strq & "  where m.empCode ='" & empCode & "'"

            strq = strq & " DELETE re, ab, pass "
            strq = strq & " FROM  remain_leave   re , al_bl_status   ab, set_pass_pro pass"
            strq = strq & " WHERE re.empCode = '" & empCode & "'  and ab.empCode ='" & empCode & "' and  pass.empCode='" & empCode & "'"
            ClsDeleteData.fcnDelete(Connection, strq)

            strq = ""
            strq = strq & "  UPDATE member set  "
            strq = strq & "  empcode_resign ='RESIGNED'"
            strq = strq & "  WHERE empCode ='" & empCode & "'"
            ClsDeleteData.fcnDelete(Connection, strq)

            strq = ""
            strq = strq & "  DELETE  "
            strq = strq & "  FROM doc_leave "
            strq = strq & "  WHERE empCode ='" & empCode & "'"
            ClsDeleteData.fcnDelete(Connection, strq)


            strq = ""
            strq = strq & "  DELETE  "
            strq = strq & "  FROM request_leave "
            strq = strq & "  WHERE empCode ='" & empCode & "'"
            ClsDeleteData.fcnDelete(Connection, strq)


            SetAllConnectionDB_Smart()
            strq = ""
            strq = strq & "  UPDATE member_fed set  "
            strq = strq & "  empcode_resign ='RESIGNED'"
            strq = strq & "  WHERE empCode ='" & empCode & "'"
            ClsDeleteData.fcnDelete(Connection, strq)

            SyncEngineerGroupForMember(empCode, _
                Convert.ToString(Me.GridMembers.Rows(0).Cells(8).Value), _
                Convert.ToString(Me.GridMembers.Rows(0).Cells(7).Value))

            SetAllConnectionDB()

            ClsGetFilesInFloder.fcnGetFilesInFloder(PahtAttach, empCode)
            ' Me.GridMembers.Rows.Remove(Me.GridMembers.Rows(i))
            CheckDelete = True

        End If
        '    Next
        'End If

        SetAllConnectionDB()

        If CheckDelete Then
            If CheckPressButton = 0 Then
                strq = ""
                strq = strq & "  Select * From member  where empcode_resign is null"
                LoadForm(strq)
            ElseIf CheckPressButton = 1 Then
                strq = ""
                strq = strq & "  Select * From member Where empCode ='" & UCase(Trim(Me.txtEmpCode.Text)) & "' and empcode_resign is null "
                LoadForm(strq)
            ElseIf CheckPressButton = 2 Then
                strq = ""
                strq = strq & "  Select * From member Where empDept ='" & Me.cbbDept.Text & "' and empcode_resign is null"
                LoadForm(strq)
            End If
            ClsClickCurrentGridView.ClickGridview(Me.GridMembers)
        End If
    End Sub


    Private Sub txtEmpCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbSearchEmpCode.PerformClick()
        End If
    End Sub
End Class

