Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports System.Text

Public Class Cls_ApproverGroupSync
    Public LastErrorMessage As String = ""

    Public Function SyncFromAllFlows() As Boolean
        LastErrorMessage = ""

        Try
            Return PostApproverGroupSync()
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Return False
        End Try
    End Function

    Private Function BuildSyncErrorMessage(jsonResult As Dictionary(Of String, Object)) As String
        Dim message As String = "Security Center sync failed"

        If jsonResult.ContainsKey("Message") Then
            message = Convert.ToString(jsonResult("Message"))
        End If

        If jsonResult.ContainsKey("ResultOnDb") AndAlso TypeOf jsonResult("ResultOnDb") Is Newtonsoft.Json.Linq.JObject Then
            Dim resultOnDb = CType(jsonResult("ResultOnDb"), Newtonsoft.Json.Linq.JObject)
            Dim detail As New List(Of String)

            AddJsonArrayDetail(detail, resultOnDb, "MissingUsers", "Missing/Inactive")
            AddJsonArrayDetail(detail, resultOnDb, "MissingPersonUsers", "Missing in person")
            AddJsonArrayDetail(detail, resultOnDb, "ResignedUsers", "Resigned")
            AddJsonArrayDetail(detail, resultOnDb, "BlockedUsers", "Blocked")

            If resultOnDb.ContainsKey("BlockedReason") Then
                Dim blockedReason As String = Trim(Convert.ToString(resultOnDb("BlockedReason")))
                If blockedReason <> "" Then detail.Add("Reason=" & blockedReason)
            End If

            If detail.Count > 0 Then
                message = message & " : " & String.Join(" | ", detail.ToArray())
            Else
                message = message & " : " & JsonConvert.SerializeObject(resultOnDb)
            End If
        End If

        Return message
    End Function

    Private Sub AddJsonArrayDetail(ByRef detail As List(Of String), resultOnDb As Newtonsoft.Json.Linq.JObject, propertyName As String, label As String)
        If Not resultOnDb.ContainsKey(propertyName) Then Exit Sub
        If Not TypeOf resultOnDb(propertyName) Is Newtonsoft.Json.Linq.JArray Then Exit Sub

        Dim values As New List(Of String)
        For Each item In CType(resultOnDb(propertyName), Newtonsoft.Json.Linq.JArray)
            values.Add(Convert.ToString(item))
        Next

        If values.Count > 0 Then
            detail.Add(label & "=" & String.Join(",", values.ToArray()))
        End If
    End Sub

    Private Function PostApproverGroupSync() As Boolean
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        Dim payload As New Dictionary(Of String, Object)
        payload("USER_GROUP_ID") = ApproverUserGroupId
        payload("UPDATE_BY") = CurrentUserId

        Dim jsonData As String = JsonConvert.SerializeObject(payload)
        Dim request As HttpWebRequest = CType(WebRequest.Create(url_security_center_sync_approver_group), HttpWebRequest)
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
            Return True
        End If

        LastErrorMessage = BuildSyncErrorMessage(jsonResult)
        Return False
    End Function
End Class
