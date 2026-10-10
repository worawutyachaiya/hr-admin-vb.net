Imports MySql.Data.MySqlClient
Public Class Cls_SetDataGridView
    'Dim PathAttachmentIcon As String = AppDomain.CurrentDomain.BaseDirectory & "Images\attach.png"
    'Dim PathAttachmentIcon As String = "..\..\Images\attach.png"
    Dim PathAttachmentIcon As String = "Picture\attach.png"

    Public Sub SetDataGridView(ByVal i_Connection As MySqlConnection, ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)
        Dim countRow As Integer = 0
        Dim strQ As String = ""
        Dim i_datatable As New DataTable
        ClsGetAttachment = New Cls_GetAttachment
        ClsGetData = New Cls_GetData
        'Connection = New MySqlConnection
        DataGridView.ColumnCount = 17

        DataGridView.Columns(0).Name = "leaveCode"
        DataGridView.Columns(1).Name = "EmpCode"
        DataGridView.Columns(2).Name = "Name"
        DataGridView.Columns(3).Name = "Dept"
        DataGridView.Columns(4).Name = "RequestDate"
        DataGridView.Columns(5).Name = "LeaveDate"
        DataGridView.Columns(6).Name = "Time"
        DataGridView.Columns(7).Name = "Type"
        DataGridView.Columns(8).Name = "Total"
        DataGridView.Columns(9).Name = "Reason"
        DataGridView.Columns(10).Name = "Note"
        DataGridView.Columns(11).Name = "Checker1"
        DataGridView.Columns(12).Name = "Checker2"
        DataGridView.Columns(13).Name = "Approve1"
        DataGridView.Columns(14).Name = "Approve2"
        DataGridView.Columns(15).Name = "Approve3"
        DataGridView.Columns(16).Name = "Attach"


        DataGridView.Columns(0).Width = 70
        DataGridView.Columns(1).Width = 70
        DataGridView.Columns(2).Width = 200
        DataGridView.Columns(3).Width = 150
        DataGridView.Columns(4).Width = 100
        DataGridView.Columns(5).Width = 200
        DataGridView.Columns(6).Width = 80
        DataGridView.Columns(7).Width = 65
        DataGridView.Columns(8).Width = 50
        DataGridView.Columns(9).Width = 200
        DataGridView.Columns(10).Width = 200
        DataGridView.Columns(11).Width = 300

        DataGridView.Columns(12).Width = 300
        DataGridView.Columns(13).Width = 300
        DataGridView.Columns(14).Width = 300
        DataGridView.Columns(15).Width = 300
        DataGridView.Columns(16).Width = 50
        'DataGridView.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        DataGridView.Columns(5).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells



        'DataGridView.ReadOnly = True
        With DataGridView
            '.BackColor = Color.Navy
            '.ForeColor = Color.White
            '.Font = New Font(DataGridView.Font, FontStyle.Bold)
            .Font = New Font(DataGridView.Font.Size, 9)

        End With



        For Each Record In DataTable.Rows

            Dim Img = New DataGridViewImageCell 'DataGridViewButtonCell
            Img.Value = Image.FromFile(PathAttachmentIcon)
            Img.ImageLayout = DataGridViewImageCellLayout.Normal
            Dim i_stringApproveBy As String = "by"
            Dim i_approveList As New List(Of String)
            Dim i_approveNo1 As String = "-"
            Dim i_approveNo2 As String = "-"
            Dim i_approveNo3 As String = "-"
            Dim i_approveNo4 As String = "-"
            Dim i_approveNo5 As String = "-"

            Dim i_recordApproveNo1 As String = Record("approveNo1_By").ToString
            Dim i_recordApproveNo2 As String = Record("approveNo2_By").ToString
            Dim i_recordApproveNo3 As String = Record("approveNo3_By").ToString
            Dim i_recordApproveNo4 As String = Record("approveNo4_By").ToString
            Dim i_recordApproveNo5 As String = Record("approveNo5_By").ToString

            If i_recordApproveNo1 <> "" Then
                i_recordApproveNo1 = " by " & i_recordApproveNo1
            End If
            If i_recordApproveNo2 <> "" Then
                i_recordApproveNo2 = " by " & i_recordApproveNo2
            End If
            If i_recordApproveNo3 <> "" Then
                i_recordApproveNo3 = " by " & i_recordApproveNo3
            End If
            If i_recordApproveNo4 <> "" Then
                i_recordApproveNo4 = " by " & i_recordApproveNo4
            End If
            If i_recordApproveNo5 <> "" Then
                i_recordApproveNo5 = " by " & i_recordApproveNo5
            End If

            '====================================== get approvelist
            strQ = ""
            strQ = strQ & " select approveNo1, approveNo2, ApproveNo3, ApproveNo4, approveNo5 "
            strQ = strQ & " from flow where nameFlow ='" & Record("deptFlow").ToString & "'"
            i_datatable = ClsGetData.GetData1(Connection, strQ)
            For Each flow In i_datatable.Rows
                i_approveList.Add(flow("approveNo1"))
                i_approveList.Add(flow("approveNo2"))
                i_approveList.Add(flow("approveNo3"))
                i_approveList.Add(flow("approveNo4"))
                i_approveList.Add(flow("approveNo5"))
            Next
            i_approveList.ToArray()
            If i_approveList.Count > 0 Then
                If i_approveList(0) <> "" Then
                    i_approveNo1 = Record("approveNo1").ToString
                End If

                If i_approveList(1) <> "" Then
                    i_approveNo2 = Record("approveNo2").ToString
                End If

                If i_approveList(2) <> "" Then
                    i_approveNo3 = Record("approveNo3").ToString
                End If

                If i_approveList(3) <> "" Then
                    i_approveNo4 = Record("approveNo4").ToString
                End If

                If i_approveList(4) <> "" Then
                    i_approveNo5 = Record("approveNo5").ToString
                End If
            Else

            End If



            '================================================
            Dim Data = New String() {Record("leaveCode"), Record("empCode"), Record("empName") & " " & Record("empSurname"), Record("empSection"), _
                                 Format(Record("reqDate"), "dd-MMM-yyyy"), Format(Record("startDate"), "dd-MMM-yyyy") & " - " & Format(Record("finishDate"), "dd-MMM-yyyy"), _
                                 Record("reqTime").ToString, Record("type").ToString, Record("total").ToString, Record("leaveReason").ToString, Record("note").ToString, _
                                     i_approveNo1 & i_recordApproveNo1, i_approveNo2 & i_recordApproveNo2, _
                                 i_approveNo3 & i_recordApproveNo3, i_approveNo4 & i_recordApproveNo4, _
                                      i_approveNo5 & i_recordApproveNo5}
            'Dim a As New DataGridViewRow

            DataGridView.Rows.Add(Data)

            strQ = ""
            strQ = strQ & " select  FilesName "
            strQ = strQ & " from doc_leave "
            strQ = strQ & " where leaveCode ='" & Record("leaveCode") & "'"

            If (ClsGetAttachment.GetAttachment(i_Connection, DataGridView, strQ)) Then
                DataGridView.Rows(countRow).Cells(16) = Img
            End If


            countRow = countRow + 1
        Next



        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.HeaderText = ""
        chk.Name = "chk"
        chk.HeaderText = "Select"
        DataGridView.Columns(17).Width = 53

        DataGridView.Columns(3).Frozen = True
        'Dim hr_checked As New DataGridViewCheckBoxColumn()
        'DataGridView.Columns.Add(hr_checked)
        'chk.HeaderText = ""
        'chk.Name = "chk"
        'chk.HeaderText = "HR Checked"
        'DataGridView.Columns(17).Width = 53
        ''DataGridView.Columns(16).ReadOnly = False


    End Sub



    Public Sub SetDataGridViewDepartMent(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = 2
        DataGridView.Columns(0).Name = "Department"
        DataGridView.Columns(1).Name = "Description"
        DataGridView.Columns(0).Width = 150
        DataGridView.Columns(1).Width = 240
        DataGridView.Columns(0).ReadOnly = True
        DataGridView.Columns(1).ReadOnly = True

        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With
        For Each Record In DataTable.Rows
            Dim Data = New String() {Record("DEPT_NAME"), Record("DEPT_DESC")}
            DataGridView.Rows.Add(Data)
        Next


        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.HeaderText = ""
        chk.Name = "chk"
        chk.HeaderText = "Select"
        DataGridView.Columns(2).Width = 65
        'DataGridView.Columns(16).ReadOnly = False
    End Sub

    Public Sub SetDataGridViewFlow(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = 6
        DataGridView.Columns(0).Name = "Name Flow"
        DataGridView.Columns(1).Name = "Checker1"
        DataGridView.Columns(2).Name = "Checker2"
        DataGridView.Columns(3).Name = "Approve1"
        DataGridView.Columns(4).Name = "Approve2"
        DataGridView.Columns(5).Name = "Approve3"

        DataGridView.Columns(0).Width = 300
        DataGridView.Columns(1).Width = 100
        DataGridView.Columns(2).Width = 100
        DataGridView.Columns(3).Width = 100
        DataGridView.Columns(4).Width = 100
        DataGridView.Columns(5).Width = 100

        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With
        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        For Each Record In DataTable.Rows
            Dim v1 As String = Record(1).ToString() 'Left(Record(1).ToString(), Len(Record(1).ToString()) - 5)
            Dim v2 As String = Record(2).ToString()
            Dim v3 As String = Record(3).ToString()
            Dim v4 As String = Record(4).ToString()
            Dim v5 As String = Record(5).ToString()
            Dim v6 As String = Record(6).ToString()
            Dim Data = New String() {v1, v2, v3, v4, v5, v6}
            DataGridView.Rows.Add(Data)
        Next

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.HeaderText = ""
        chk.Name = "chk"
        chk.HeaderText = "Select"
        DataGridView.Columns(6).Width = 60
        'DataGridView.Columns(16).ReadOnly = False
    End Sub


    Public Sub SetDataGridViewHolidays(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = 3
        DataGridView.Columns(0).Name = "Holidays (dd-MMM-yyyy)"
        DataGridView.Columns(1).Name = "Title"
        DataGridView.Columns(2).Name = "Holiday Code"


        DataGridView.Columns(0).Width = 150
        DataGridView.Columns(1).Width = 425
        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

            DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            For Each Record In DataTable.Rows
                Dim v1 As String = Format(Record(1), "dd-MMM-yyyy")
                Dim v2 As String = Record(2).ToString()
            Dim v3 As String = Record(3).ToString()
            Dim Data = New String() {v1, v2, v3}
                DataGridView.Rows.Add(Data)
            Next

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.Name = ""

        DataGridView.Columns(3).Width = 55

        DataGridView.Columns(0).ReadOnly = True
        DataGridView.Columns(1).ReadOnly = True
        DataGridView.Columns(2).ReadOnly = True

            'DataGridView.Columns(16).ReadOnly = False
    End Sub

    Public Sub SetDataGridViewMembers(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)
        Dim countRow As Integer = 0

        DataGridView.ColumnCount = 16
        DataGridView.Columns(0).Name = "Emp.Code"
        DataGridView.Columns(1).Name = "Name"
        DataGridView.Columns(2).Name = "Surname"
        DataGridView.Columns(3).Name = "Sex"
        DataGridView.Columns(4).Name = "Email"
        DataGridView.Columns(5).Name = "Pcode"
        DataGridView.Columns(6).Name = "Position"
        DataGridView.Columns(7).Name = "Section"
        DataGridView.Columns(8).Name = "Dept"
        DataGridView.Columns(9).Name = "Flow"
        DataGridView.Columns(10).Name = "StartWork"
        DataGridView.Columns(11).Name = "Birthday"
        DataGridView.Columns(12).Name = "Exp"
        DataGridView.Columns(13).Name = "Bus-Position"
        DataGridView.Columns(14).Name = "Team"
        DataGridView.Columns(15).Name = "Group"

        DataGridView.Columns(0).Width = 65
        DataGridView.Columns(1).Width = 120
        DataGridView.Columns(2).Width = 120
        DataGridView.Columns(3).Width = 50
        DataGridView.Columns(4).Width = 130
        DataGridView.Columns(5).Width = 80
        DataGridView.Columns(6).Width = 80
        DataGridView.Columns(7).Width = 80
        DataGridView.Columns(8).Width = 90
        DataGridView.Columns(9).Width = 90
        DataGridView.Columns(10).Width = 90
        DataGridView.Columns(11).Width = 90
        DataGridView.Columns(12).Width = 90
        DataGridView.Columns(13).Width = 90
        DataGridView.Columns(14).Width = 50
        DataGridView.Columns(15).Width = 50
        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        For Each Record In DataTable.Rows
            ' Dim v1 As String = Record("INDEX_NO").ToString()
            Dim v1 As String = Record("empCode").ToString()
            Dim v2 As String = Record("empName").ToString()
            Dim v3 As String = Record("empSurname").ToString()
            Dim v4 As String = Record("empSex").ToString()
            Dim v5 As String = Record("empEmail").ToString()
            Dim v6 As String = Record("empPcode").ToString()
            Dim v7 As String = Record("empPosition").ToString()
            Dim v8 As String = Record("empSection").ToString()
            Dim v9 As String = Record("empDept").ToString()
            Dim v10 As String = Record("deptFlow").ToString() 'Left(Record("deptFlow").ToString(), Len(Record("deptFlow").ToString()) - 5) 'Record("deptFlow").ToString()
            Dim v11 As String = Format(Record("empStartWork"), "dd-MMM-yyyy")
            Dim v12 As String = Format(Record("empBirthday"), "dd-MMM-yyyy")
            Dim v13 As String = Record("empExp").ToString()
            Dim v14 As String = Record("bus_position").ToString()
            Dim v15 As String = Record("emp_group").ToString()
            Dim v16 As String = Record("emp_group_work_desc").ToString()
            Dim Data = New String() {v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16}
            DataGridView.Rows.Add(Data)

            'Dim cbCell As New DataGridViewComboBoxCell
            'cbCell.Items.Add("A")
            'DataGridView.Rows(countRow).Cells(13) = cbCell
            'countRow = countRow + 1
        Next

        'Dim row As Integer = DataGridView.Rows.Count


        'Dim chk As New DataGridViewCheckBoxColumn()
        '    DataGridView.Columns.Add(chk)
        '    chk.Name = ""
        '    chk.HeaderText = "Select"
        '    DataGridView.Columns(15).Width = 55





        'Dim btn As New DataGridViewButtonColumn()
        'DataGridView.Columns.Add(btn)
        'btn.HeaderText = "Click Data"
        'btn.Text = "Click Here"

        'DataGridView.Columns(12).Width = 20
        'DataGridView.ReadOnly = True

    End Sub

    Public Sub SetDataGridViewSection(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = 2
        DataGridView.Columns(0).Name = "Section"
        DataGridView.Columns(1).Name = "Department"

        DataGridView.Columns(0).Width = 200
        DataGridView.Columns(1).Width = 200

        DataGridView.Columns(0).ReadOnly = True
        DataGridView.Columns(1).ReadOnly = True

        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        For Each Record In DataTable.Rows
            Dim v1 As String = Record(0).ToString
            Dim v2 As String = Record(1).ToString
            'Dim v2 As String = Record(2).ToString()

            Dim Data = New String() {v1, v2}
            DataGridView.Rows.Add(Data)
        Next

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.Name = ""
        chk.HeaderText = "Select"
        DataGridView.Columns(2).Width = 70
        'DataGridView.Columns(2).ReadOnly = True
    End Sub

    Public Sub SetDataGridViewPcode(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = 1
        DataGridView.Columns(0).Name = "PCode"

        DataGridView.Columns(0).Width = 170

        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        For Each Record In DataTable.Rows
            Dim v1 As String = Record(1).ToString
            'Dim v2 As String = Record(2).ToString()

            Dim Data = New String() {v1}
            DataGridView.Rows.Add(Data)
        Next

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.Name = ""
        chk.HeaderText = "Select"
        DataGridView.Columns(1).Width = 70

        'DataGridView.Columns(16).ReadOnly = False
    End Sub

    Public Sub SetDataGridViewPosition(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = 1
        DataGridView.Columns(0).Name = "Position"

        DataGridView.Columns(0).Width = 250

        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        For Each Record In DataTable.Rows
            Dim v1 As String = Record(1).ToString
            'Dim v2 As String = Record(2).ToString()

            Dim Data = New String() {v1}
            DataGridView.Rows.Add(Data)
        Next

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.Name = ""
        chk.HeaderText = "Select"
        DataGridView.Columns(1).Width = 70


        'DataGridView.Columns(16).ReadOnly = False
    End Sub


    Public Sub SetDataGridViewRemainLeave(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        'DataGridView.ColumnCount = DataTable.Columns.Count
        'DataGridView.Columns(0).Name = "empCode"

        'DataGridView.Columns(0).Width = 373
        DataGridView.DataSource = DataTable
        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridView.Columns(0).ReadOnly = True
        DataGridView.Columns(1).ReadOnly = True
        DataGridView.Columns(2).ReadOnly = True
        DataGridView.Columns(3).ReadOnly = True

        'For Each Record In DataTable.Rows
        '    Dim v1 As String = Record(1).ToString
        '    'Dim v2 As String = Record(2).ToString()

        '    Dim Data = New String() {v1}
        '    DataGridView.Rows.Add(Data)
        'Next

        'Dim chk As New DataGridViewCheckBoxColumn()
        'DataGridView.Columns.Add(chk)
        'chk.Name = ""
        'DataGridView.Columns(1).Width = 55


        'DataGridView.Columns(16).ReadOnly = False
    End Sub




    Public Sub SetDataGridViewEmpCodeSpecial(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = 1
        DataGridView.Columns(0).Name = "Emp Code"

        DataGridView.Columns(0).Width = 200

        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        'DataGridView.DataSource = DataTable
        For Each Record In DataTable.Rows
            Dim Data = New String() {Record("empCode").ToString}
            DataGridView.Rows.Add(Data)
        Next

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.Name = ""
        chk.HeaderText = "Select"
        DataGridView.Columns(1).Width = 70

    End Sub



    Public Sub SetDataGridViewBusPosition(ByRef DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = DataTable.Columns.Count
        DataGridView.Columns(0).Name = "BUS Position"

        DataGridView.Columns(0).Width = 480
        'DataGridView.DataSource = DataTable
        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        For Each Record In DataTable.Rows
            Dim v1 As String = Record("bus_position").ToString
            'Dim v2 As String = Record(2).ToString()

            Dim Data = New String() {v1}
            DataGridView.Rows.Add(Data)
        Next

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.HeaderText = "Select"
        DataGridView.Columns(1).Width = 55


        'DataGridView.Columns(16).ReadOnly = False
    End Sub


    Public Sub SetDataGridViewAccumulateAl(DataGridView As DataGridView, ByVal DataTable As DataTable)

        DataGridView.ColumnCount = 2
        DataGridView.Columns(0).Name = "Year"
        DataGridView.Columns(1).Name = "Qty"
        DataGridView.Columns(0).Width = 100
        DataGridView.Columns(1).Width = 100
        With DataGridView.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(DataGridView.Font, FontStyle.Bold)
        End With

        DataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        ''DataGridView.DataSource = DataTable
        For Each Record In DataTable.Rows
            Dim Data = New String() {Record("year").ToString, Record("qty").ToString}
            DataGridView.Rows.Add(Data)
        Next

        Dim chk As New DataGridViewCheckBoxColumn()
        DataGridView.Columns.Add(chk)
        chk.Name = ""
        chk.HeaderText = "Select"
        DataGridView.Columns(2).Width = 70

    End Sub
End Class
