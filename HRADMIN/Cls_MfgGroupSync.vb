Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports System.Text

Public Class Cls_MfgGroupSync
    Public LastErrorMessage As String = ""
    Public LastWarningMessage As String = ""

    Public Function SyncMember(employeeId As String, dept As String) As Boolean
        Dim members As New List(Of Dictionary(Of String, Object))
        AddMember(members, employeeId, dept)
        Return SyncMembers(members)
    End Function

    Public Function SyncMembers(members As List(Of Dictionary(Of String, Object))) As Boolean
        LastErrorMessage = ""
        LastWarningMessage = ""

        Try
            Return PostMembers(members)
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Public Sub AddMember(ByRef members As List(Of Dictionary(Of String, Object)), employeeId As String, dept As String)
        Dim empCode As String = Trim(employeeId)
        If empCode = "" Then Exit Sub

        Dim item As New Dictionary(Of String, Object)
        item("USER_NAME") = empCode
        item("EMP_DEPT") = Trim(dept)
        members.Add(item)
    End Sub

    Private Function PostMembers(members As List(Of Dictionary(Of String, Object))) As Boolean
        If members Is Nothing OrElse members.Count = 0 Then Return True

        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        Dim payload As New Dictionary(Of String, Object)
        payload("USER_GROUP_ID") = MfgUserGroupId
        payload("MEMBERS") = members
        payload("UPDATE_BY") = CurrentUserId

        Dim jsonData As String = JsonConvert.SerializeObject(payload)
        Dim request As HttpWebRequest = CType(WebRequest.Create(url_security_center_sync_mfg_group), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Timeout = 15000
        request.ReadWriteTimeout = 15000

        Dim bytes As Byte() = Encoding.UTF8.GetBytes(jsonData)
        request.ContentLength = bytes.Length

        Using stream = request.GetRequestStream()
            stream.Write(bytes, 0, bytes.Length)
        End Using

        Dim result As String

        Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            Using reader As New StreamReader(response.GetResponseStream())
                result = reader.ReadToEnd()
            End Using
        End Using

        Dim jsonResult = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(result)
        If jsonResult Is Nothing Then
            LastErrorMessage = "Security Center returned empty response"
            Return False
        End If

        If jsonResult.ContainsKey("Status") AndAlso Convert.ToBoolean(jsonResult("Status")) Then
            LastWarningMessage = BuildSyncWarningMessage(jsonResult)
            Return True
        End If

        LastErrorMessage = BuildSyncErrorMessage(jsonResult)
        Return False
    End Function

    Private Function BuildSyncErrorMessage(jsonResult As Dictionary(Of String, Object)) As String
        Dim message As String = "Security Center MFG sync failed"

        If jsonResult.ContainsKey("Message") Then
            message = Convert.ToString(jsonResult("Message"))
        End If

        If jsonResult.ContainsKey("ResultOnDb") AndAlso TypeOf jsonResult("ResultOnDb") Is Newtonsoft.Json.Linq.JObject Then
            message = message & " : " & JsonConvert.SerializeObject(jsonResult("ResultOnDb"))
        End If

        Return message
    End Function

    Private Function BuildSyncWarningMessage(jsonResult As Dictionary(Of String, Object)) As String
        If Not jsonResult.ContainsKey("ResultOnDb") Then Return ""
        If Not TypeOf jsonResult("ResultOnDb") Is Newtonsoft.Json.Linq.JObject Then Return ""

        Dim resultOnDb = CType(jsonResult("ResultOnDb"), Newtonsoft.Json.Linq.JObject)
        If Not resultOnDb.ContainsKey("SkippedUsers") Then Return ""
        If Not TypeOf resultOnDb("SkippedUsers") Is Newtonsoft.Json.Linq.JArray Then Return ""

        Dim skippedUsers As New List(Of String)
        For Each item In CType(resultOnDb("SkippedUsers"), Newtonsoft.Json.Linq.JArray)
            skippedUsers.Add(Convert.ToString(item))
        Next

        If skippedUsers.Count = 0 Then Return ""

        Return "SkippedUsers=" & String.Join(",", skippedUsers.ToArray())
    End Function
End Class
