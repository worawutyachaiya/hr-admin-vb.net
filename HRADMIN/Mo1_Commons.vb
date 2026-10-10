Imports MySql.Data.MySqlClient
Module Mo1_Commons


    Public Const iServerName As String = "192.168.0.249"
    Public Const iUserName As String = "usrrw"
    Public Const iPass As String = "commonrw"
    'Public Const iServerName As String = "localhost"
    'Public Const iUserName As String = "user_ro"
    'Public Const iPass As String = "12345"
    Public Const iTableName As String = "db_leave"
    Public Const iPahtAttachment As String = "\\192.168.0.249\myfile\"

    Public Const Smart_iServerName As String = "192.168.14.236"
    Public Const Smart_iUserName As String = "SoftwareDev"
    Public Const Smart_iPass As String = "mMQf489^"
    Public Const Smart_iTableName As String = "person"

    Public Const iUrl_ As String = "http://localhost:7004/api/personal-information/insert"
    Public Const iUrl As String = "http://192.168.14.247:7004/api/personal-information/insert"

    Public Const url_flow_change As String = "https://fitelsmart-leaveapi.azurewebsites.net/api/leave-system/sync/on-flow-changed"
    Public Const url_flow_change_ As String = "http://localhost:7015/api/leave-system/sync/on-flow-changed"

    Public Const url_member_flow_change As String = "https://fitelsmart-leaveapi.azurewebsites.net/api/leave-system/sync/member-on-flow-changed"
    Public Const url_member_flow_change_ As String = "http://localhost:7015/api/leave-system/sync/member-on-flow-changed"

    Public Const ApproverUserGroupId As Integer = 93
    Public Const url_security_center_sync_approver_group_ As String = "http://localhost:7010/api/security-center/user-security-group/sync-members"
    Public Const url_security_center_sync_approver_group As String = "http://192.168.14.235:7010/api/security-center/user-security-group/sync-members"

    Public Const MfgUserGroupId As Integer = 16
    Public Const url_security_center_sync_mfg_group_ As String = "http://localhost:7010/api/security-center/user-security-group/sync-mfg-members"
    Public Const url_security_center_sync_mfg_group As String = "http://192.168.14.235:7010/api/security-center/user-security-group/sync-mfg-members"

    Public Const EngineerUserGroupId As Integer = 123
    Public Const url_security_center_sync_engineer_group_ As String = "http://localhost:7010/api/security-center/user-security-group/sync-engineer-members"
    Public Const url_security_center_sync_engineer_group As String = "http://192.168.14.235:7010/api/security-center/user-security-group/sync-engineer-members"

    Public FilesNameAttachment As String
    Public CurrentUserId As String = ""

    Public Function IsLoggedIn() As Boolean
        Return Trim(CurrentUserId) <> ""
    End Function

    Public ClsConnectDbMysql As Cls_ConnectDbMysql
    Public Connection As MySqlConnection
    'Public strQ As String = ""
    'Public sqlCommand As MySqlCommand
    'Public Da As MySqlDataAdapter
    'Public Dt As DataTable


    '============================= Class
    Public ClsGetAttachment As Cls_GetAttachment
    Public ClsGetData As Cls_GetData
    Public ClsUpdateData As Cls_UpdateData
    Public ClsDeleteData As Cls_Delete
    Public ClsInsert As Cls_Insert
    Public ClsEncodMD5 As Cls_FcnEncodMD5
    Public ClsExcel As Cls_Excel
    Public ClsExcel2 As Cls_ExcelV2
    Public ClsSQLDateFormat As Cls_SQLDateFormat
    Public ClsGetFilesInFloder As Cls_GetFilesInFloder
    Public ClsSetDateTimerPickerformat As Cls_SetDateTimerPickerformat
    Public ClsClickCurrentGridView As Cls_ClickCurrentGridView

    Public Sub SetAllConnectionDB()
        ClsConnectDbMysql = New Cls_ConnectDbMysql
        Connection = New MySqlConnection
        ClsConnectDbMysql.ConnectDBMySql(Connection)
    End Sub

    Public Sub SetAllConnectionDB_Smart()
        ClsConnectDbMysql = New Cls_ConnectDbMysql
        Connection = New MySqlConnection
        ClsConnectDbMysql.ConnectDBMySql_Smart(Connection)
    End Sub

    Public Sub CheckConnection(UConnection As MySqlConnection)
        If Not UConnection Is Nothing Then
            Select Case UConnection.State
                Case ConnectionState.Closed
                    UConnection.Open()
                Case Else
            End Select
        Else
            'reset connection object
        End If
    End Sub


End Module

