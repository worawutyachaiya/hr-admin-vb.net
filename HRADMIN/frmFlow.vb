Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports System.Text

Public Class frmFlow
    Private Flow(,) As String
    Private strq As String = ""

    Private Function SyncFlowChanged(flowName As String) As Boolean

        Try

            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

            Dim url As String = url_flow_change

            Dim payload As New Dictionary(Of String, Object)
            payload("FLOW_NAME") = flowName
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

    Private Function SyncApproverGroup() As Boolean
        Dim approverGroupSync As New Cls_ApproverGroupSync
        Dim result As Boolean = approverGroupSync.SyncFromAllFlows()

        If result = False Then
            If approverGroupSync.LastErrorMessage <> "" Then
                MsgBox("Sync Approver Group Failed : " & approverGroupSync.LastErrorMessage)
            Else
                MsgBox("Sync Approver Group Failed")
            End If
        End If

        Return result
    End Function

    Private Sub frmFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        LoadForm()
    End Sub
    Private Sub LoadForm()

        ClsGetData = New Cls_GetData
        'ClsClickCurrentGridView = New Cls_ClickCurrentGridView
        SetAllConnectionDB()
        strq = ""
        strq = strq & "  select * "
        strq = strq & "  from flow  order by nameFlow "
        ClsGetData.GetFlow(Connection, Me.GridFlow, strq, Flow)
    End Sub
    Private Sub cmbAdd_Click(sender As Object, e As EventArgs) Handles cmbAdd.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsInsert = New Cls_Insert
        Dim checkAdding As Boolean = False

        If MsgBox("คุณต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then
            If txtNameFlow.Text = "" And txtChecker1.Text = "" And txtChecker2.Text = "" And txtApprove1.Text = "" And txtApprove2.Text = "" And txtApprove3.Text = "" Then

                MsgBox("กรุณาใส่ข้อมูลให้ครบ")

            Else

                'Check duplicate section
                strq = ""
                strq = strq & "  select nameFlow from flow "
                strq = strq & "  where nameFlow ='" & txtNameFlow.Text & "' "

                If Not ClsGetData.GetData(Connection, strq) Then

                    strq = ""
                    strq = strq & "  Insert into Flow(nameFlow,approveNo1,approveNo2,approveNo3,approveNo4, approveNo5) "
                    strq = strq & "  Values('" & txtNameFlow.Text & "','" & txtChecker1.Text & "','" & txtChecker2.Text & "','" & txtApprove1.Text & "','" & txtApprove2.Text & "','" & txtApprove3.Text & "')"
                    ClsInsert.Insert(Connection, strq)

                    SetAllConnectionDB_Smart()
                    strq = ""
                    strq = strq & "  Insert into flow_fed(nameFlow,approveNo1,approveNo2,approveNo3,approveNo4, approveNo5) "
                    strq = strq & "  Values('" & txtNameFlow.Text & "','" & txtChecker1.Text & "','" & txtChecker2.Text & "','" & txtApprove1.Text & "','" & txtApprove2.Text & "','" & txtApprove3.Text & "')"
                    ClsInsert.Insert(Connection, strq)

                    checkAdding = True

                Else

                    MsgBox("Name Flow ซ้ำ กรุณาตรวจสอบอีกครั้ง")

                End If


            End If
        End If

        If checkAdding Then
            Dim apiResult As Boolean = SyncFlowChanged(txtNameFlow.Text)

            If apiResult = False Then
                MsgBox("Sync Flow API Failed")
            End If

            SyncApproverGroup()
            MsgBox("ทำการเพิ่มข้อมูลแล้ว", , "")
            txtNameFlow.Text = ""
            txtChecker1.Text = ""
            txtChecker2.Text = ""
            txtApprove1.Text = ""
            txtApprove2.Text = ""
            txtApprove3.Text = ""
            LoadForm()
            ClsClickCurrentGridView.ClickGridview(Me.GridFlow)
        End If


    End Sub


    Private Sub cbmEdit_Click(sender As Object, e As EventArgs) Handles cbmEdit.Click
        SetAllConnectionDB()
        ClsGetData = New Cls_GetData
        ClsUpdateData = New Cls_UpdateData
        Dim CheckEdit As Boolean = False
        If txtFlowID.Text = "" Then

            MsgBox("คุณต้องการแก้ไขข้อมูลใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการบันทึกข้อมูลที่แก้ไขใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                If txtNameFlow.Text = "" And txtChecker1.Text = "" And txtChecker2.Text = "" And txtApprove1.Text = "" And txtApprove2.Text = "" And txtApprove3.Text = "" Then

                    MsgBox("กรุณาใส่ข้อมูลให้ครบ")

                Else

                    strq = ""
                    strq = strq & "  update flow  set"
                    strq = strq & "  nameFlow ='" & txtNameFlow.Text & "', "
                    strq = strq & "  approveNo1 ='" & txtChecker1.Text & "', approveNo2 ='" & txtChecker2.Text & "', "
                    strq = strq & "  approveNo3 ='" & txtApprove1.Text & "', approveNo4 ='" & txtApprove2.Text & "', "
                    strq = strq & "  approveNo5 ='" & txtApprove3.Text & "' "
                    strq = strq & "  where nameFlow ='" & txtFlowID.Text & "'"
                    ClsUpdateData.Update(Connection, strq)

                    strq = ""
                    strq = strq & "  update request_leave  set"
                    strq = strq & "  deptFlow ='" & txtNameFlow.Text & "'"
                    strq = strq & "  where deptFlow ='" & txtFlowID.Text & "'"
                    ClsUpdateData.Update(Connection, strq)

                    strq = ""
                    strq = strq & "  update member  set"
                    strq = strq & "  deptFlow ='" & txtNameFlow.Text & "'"
                    strq = strq & "  where deptFlow ='" & txtFlowID.Text & "'"
                    ClsUpdateData.Update(Connection, strq)


                    SetAllConnectionDB_Smart()
                    strq = ""
                    strq = strq & "  update flow_fed  set"
                    strq = strq & "  nameFlow ='" & txtNameFlow.Text & "', "
                    strq = strq & "  approveNo1 ='" & txtChecker1.Text & "', approveNo2 ='" & txtChecker2.Text & "', "
                    strq = strq & "  approveNo3 ='" & txtApprove1.Text & "', approveNo4 ='" & txtApprove2.Text & "', "
                    strq = strq & "  approveNo5 ='" & txtApprove3.Text & "' "
                    strq = strq & "  where nameFlow ='" & txtFlowID.Text & "'"
                    ClsUpdateData.Update(Connection, strq)

                    strq = ""
                    strq = strq & "  update member_fed  set"
                    strq = strq & "  deptFlow ='" & txtNameFlow.Text & "'"
                    strq = strq & "  where deptFlow ='" & txtFlowID.Text & "'"
                    ClsUpdateData.Update(Connection, strq)

                    'strq = ""
                    'strq = strq & "  update flow  set"
                    'strq = strq & "  approveNo1 ='" & txtChecker1.Text & "', approveNo2 ='" & txtChecker2.Text & "', "
                    'strq = strq & "  approveNo3 ='" & txtApprove1.Text & "', approveNo4 ='" & txtApprove2.Text & "', "
                    'strq = strq & "  approveNo5 ='" & txtApprove3.Text & "' "
                    'strq = strq & "  where nameFlow ='" & txtNameFlow.Text & "'"
                    'ClsUpdateData.Update(Connection, strq)

                    CheckEdit = True

                End If
            End If

            If CheckEdit Then
                Dim apiResult As Boolean = SyncFlowChanged(txtNameFlow.Text)

                If apiResult = False Then
                    MsgBox("Sync Flow API Failed")
                End If

                SyncApproverGroup()
                MsgBox("ทำการแก้ไขข้อมูลแล้ว", , "")
                txtNameFlow.Text = ""
                txtChecker1.Text = ""
                txtChecker2.Text = ""
                txtApprove1.Text = ""
                txtApprove2.Text = ""
                txtApprove3.Text = ""
                txtFlowID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridFlow)
            End If
        End If
    End Sub
    Private Sub cmbDeleteSelected_Click(sender As Object, e As EventArgs) Handles cmbDeleteSelected.Click
        Dim CheckDelete As Boolean = False
        SetAllConnectionDB()
        ClsDeleteData = New Cls_Delete

        If txtFlowID.Text = "" Then

            MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่? กรุณาตรวจสอบอีกครั้ง")

        Else
            If MsgBox("คุณต้องการลบรายการนี้ใช่หรือไม่?", MsgBoxStyle.YesNo, "Confirm") = vbYes Then

                strq = ""
                strq = strq & "  delete "
                strq = strq & "  from flow "
                strq = strq & "  where NameFlow ='" & txtFlowID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strq)

                SetAllConnectionDB_Smart()
                strq = ""
                strq = strq & "  delete "
                strq = strq & "  from flow_fed "
                strq = strq & "  where NameFlow ='" & txtFlowID.Text & "'"
                ClsDeleteData.fcnDelete(Connection, strq)

                CheckDelete = True

            End If

            If CheckDelete Then
                Dim apiResult As Boolean = SyncFlowChanged(txtFlowID.Text)

                If apiResult = False Then
                    MsgBox("Sync Flow API Failed")
                End If

                SyncApproverGroup()
                MsgBox("ทำการลบข้อมูลแล้ว", , "")
                txtNameFlow.Text = ""
                txtChecker1.Text = ""
                txtChecker2.Text = ""
                txtApprove1.Text = ""
                txtApprove2.Text = ""
                txtApprove3.Text = ""
                txtFlowID.Text = ""
                LoadForm()
                ClsClickCurrentGridView.ClickGridview(Me.GridFlow)
            End If
        End If
    End Sub



    Private Sub GridFlow_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridFlow.CellClick
        ClsClickCurrentGridView.Row = e.RowIndex
    End Sub

    Private Sub GridFlow_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridFlow.CellContentClick
        Dim CheckValue As Boolean
        Dim row As Integer = Me.GridFlow.Rows.Count - 1

        If e.ColumnIndex = 6 Then

            If Me.GridFlow.Rows(e.RowIndex).Cells(2).ReadOnly = True Then

                MsgBox("ReadOnly True")

            Else

                'DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)Me.GridviewSection.Rows(e.RowIndex).Cells(e.ColumnIndex)
                CheckValue = Me.GridFlow.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue

                For i = 0 To row

                    If i = e.RowIndex And CheckValue = True Then

                        Me.GridFlow.Rows(i).Cells(6).Value = True

                        'Get data to textbox
                        txtFlowID.Text = Me.GridFlow.Rows(i).Cells(0).Value
                        txtNameFlow.Text = Me.GridFlow.Rows(i).Cells(0).Value
                        txtChecker1.Text = Me.GridFlow.Rows(i).Cells(1).Value
                        txtChecker2.Text = Me.GridFlow.Rows(i).Cells(2).Value
                        txtApprove1.Text = Me.GridFlow.Rows(i).Cells(3).Value
                        txtApprove2.Text = Me.GridFlow.Rows(i).Cells(4).Value
                        txtApprove3.Text = Me.GridFlow.Rows(i).Cells(5).Value


                    ElseIf i <> e.RowIndex And CheckValue = True Then

                        Me.GridFlow.Rows(i).Cells(6).Value = False

                    End If


                Next

            End If

        End If
    End Sub
End Class
