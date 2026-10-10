'********************************************
'
' @Autor         Pipimphorn
' @Company       Furukawa FITEL
' @Date          7 Mar 2018
' @Description   Program remind email to HR for leave BL type.
' @Tool          - Visual Studio 2012 VB
'                
'********************************************

Imports System.Net.Mail
Imports System.Net.ServicePointManager
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Globalization

Module maincode
    Public path_remind_time = Application.StartupPath & "\FILE_default_var.txt"
    Public path_email_list = Application.StartupPath & "\FILE_email_list.txt"
    Public path_record_log = Application.StartupPath & "\FILE_record_log.txt"
    Public headMail As String = "Dear HR members,<br><br>"
    Public footMail As String = "<br><br>-------------------------------------------------------------------<br>This email send from reminding system.<br>Please don't reply email."

    Public Sub send_reminder()
        'เปิด file เพื่อ get ค่า remind time
        Dim reader() As String = File.ReadAllLines(path_remind_time)
        Dim txt As String
        Dim tempo As New List(Of String)
        For Each txt In reader
            tempo.Add(txt)
        Next
        
        Dim time As String = tempo(0)
        Dim EmailBody As String = ""

        If Not IsDate(time) Then
            'ส่ง email แจ้ง HR ให้ตรวจสอบเวลาที่จะให้ program ส่ง email
            send_email("<p style='font-size:16px'>" & headMail & "Setting time to send reminder email is not a time. Please contact IT dept. to check this !!" & footMail & "</p>", "Setting", "HR")

        Else
            'เชื่อมต่อ database เพื่อดึงข้อมูล
            Dim conn As New MySqlConnection
            Dim comm As New MySqlCommand
            Dim adapter As New MySqlDataAdapter
            Dim dt As New DataTable
            Dim sql As String
            Dim i As Double
            Dim today_date As Date = Now
            Dim finish_date As Date
            Dim empemail As String = ""

            conn.ConnectionString = "Server=" & server_name & ";User Id=" & us_leave & "; Password=" & pw_leave & "; Database=" & db_leave & "; Pooling=false"
            conn.Open()

            sql = "SELECT a.leavecode lcode,a.empcode empcode,a.empname empname,a.empsurname empsurname,a.startdate startdate,a.finishdate finishdate,a.total total,a.leavereason reason,m.empemail empemail" & _
                    " FROM request_leave a" & _
                    " left join doc_leave b on a.leavecode = b.leavecode" & _
                    " left join member m on a.empcode = m.empcode" & _
                    " where a.type = 'BL'" & _
                    " and UCASE(a.approveno1) <> 'CANCEL'" & _
                    " and UCASE(a.approveno2) <> 'CANCEL'" & _
                    " and UCASE(a.approveno3) <> 'CANCEL'" & _
                    " and UCASE(a.approveno4) <> 'CANCEL'" & _
                    " and UCASE(a.approveno5) <> 'CANCEL'" & _
                    " and b.filesname IS NULL and a.hr_checked IS NULL" & _
                    " ORDER BY a.startdate"

            comm = New MySqlCommand(sql, conn)
            adapter = New MySqlDataAdapter(comm)
            dt = New DataTable
            adapter.Fill(dt)
            conn.Close()

            'ถ้ามีข้อมูลให้ส่ง email แจ้งเตือน
            If dt.Rows.Count > 0 Then
                'แจ้งเตือน HR
                EmailBody = EmailBody & "<tr><td style='border: 1px solid black;'>Leave code</td><td style='border: 1px solid black;'>Empcode</td><td style='border: 1px solid black;'>Emp name</td>" & _
                                        "<td style='border: 1px solid black;'>Emp surname</td><td style='border: 1px solid black;'>Start date</td><td style='border: 1px solid black;'>Finish date</td>" & _
                                        "<td style='border: 1px solid black;'>Total</td><td style='border: 1px solid black;'>Reason</td></tr>"
                For i = 0 To (dt.Rows.Count - 1)
                    EmailBody = EmailBody & "<tr><td style='border: 1px solid black;'>" & dt.Rows(i)("lcode").ToString & "</td>" & _
                                "<td style='border: 1px solid black;'>" & dt.Rows(i)("empcode").ToString & "</td>" & _
                                "<td style='border: 1px solid black;'>" & dt.Rows(i)("empname").ToString & "</td>" & _
                                "<td style='border: 1px solid black;'>" & dt.Rows(i)("empsurname").ToString & "</td>" & _
                                "<td style='border: 1px solid black;'>" & dt.Rows(i)("startdate").ToString & "</td>" & _
                                "<td style='border: 1px solid black;'>" & dt.Rows(i)("finishdate").ToString & "</td>" & _
                                "<td style='border: 1px solid black;'>" & dt.Rows(i)("total").ToString & "</td>" & _
                                "<td style='border: 1px solid black;'>" & dt.Rows(i)("reason").ToString & "</tr>"
                Next i
                EmailBody = "<p style='font-size:16px'>" & headMail & "สำหรับพนักงานที่ยื่นลาประเภท BL แต่ไม่ได้แนบเอกสารประกอบการลา แสดงดังตารางต่อไปนี้</p><br>" & _
                            "<table style='border-collapse: collapse;border: 1px solid black;'>" & EmailBody & "</table><p style='font-size:16px'>" & footMail & "</p>"
                send_email(EmailBody, "Reminder", "HR")

                'แจ้งเตือนพนักงานที่ไม่แนบเอกสารการลา BL หลังจากสิ้นสุดการลาแล้ว 1 วัน  => today >= finish date + 1
                For i = 0 To (dt.Rows.Count - 1)
                    EmailBody = ""
                    empemail = Trim(dt.Rows(i)("empemail").ToString)
                    finish_date = CDate(dt.Rows(i)("finishdate").AddDays(1)).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                    If CDate(today_date).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) >= finish_date Then
                        EmailBody = "<p style='font-size:16px'>Dear " & dt.Rows(i)("empname").ToString & "</p><br>" & _
                                    "Leave Code : " & dt.Rows(i)("lcode").ToString & "<br>" & _
                                    "Start date : " & CDate(dt.Rows(i)("startdate")).ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) & "<br>" & _
                                    "Finish date : " & CDate(dt.Rows(i)("finishdate")).ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture) & "<br>" & _
                                    "Type : BL<br>" & _
                                    "<p style='font-size:22px;font-weight:bold;color:blue;'>กรุณาแนบเอกสารประกอบการลากิจ (BL) ที่ท่านได้ลาไว้ภายใน 7 วัน หลังจากวันที่ลา หากท่านไม่แนบเอกสารประกอบการลาภายในวันที่กำหนด ทางแผนก HR จะทำการเปลี่ยนลากิจ (BL) ของท่านเป็นลาอื่นๆไม่จ่ายค่าจ้าง (OL)</p>" & footMail
                        If empemail <> "-" And empemail <> "" Then
                            send_email(EmailBody, "Reminder", empemail)
                        End If
                    End If
                Next i
            End If
        End If
    End Sub

    Public Sub send_email(ByVal messageText As String, ByVal typeSending As String, ByVal send_to As String)
        Dim writer As System.IO.StreamWriter
        Dim dataRecordInFile As String = ""

        Dim emailMessage As New MailMessage()
        Dim SMTP As New SmtpClient()

        Dim email_list As New List(Of String)
        Dim email_text As String = ""
        Dim idx As Integer

        If send_to = "HR" Then
            'เปิด file เพื่อ get ค่า email list ของ HR
            Dim reader2() As String = File.ReadAllLines(path_email_list)
            Dim txt2 As String
            For Each txt2 In reader2
                email_list.Add(txt2)
                email_text = email_text & txt2 & ";"
            Next
        Else
            email_list.Add(send_to)
            email_text = send_to & ";"
        End If

        Try
            emailMessage = New MailMessage
            emailMessage.From = New MailAddress("canon_2@fitel.co.th", "Remind leave BL type")
            For idx = 0 To (email_list.Count - 1)
                emailMessage.To.Add(email_list(idx))
            Next idx

            emailMessage.Subject = "Remind leave BL type (not found attached files)"
            emailMessage.Body = "" & messageText
            emailMessage.IsBodyHtml = True

            SMTP = New SmtpClient()
            SMTP.Host = "203.146.237.242"
            SMTP.Port = 25
            SMTP.EnableSsl = True
            SMTP.UseDefaultCredentials = False
            SMTP.Credentials = New Net.NetworkCredential("canon_2@fitel.co.th", "fi870870")
            Net.ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidateCertificate)
            SMTP.Send(emailMessage)

            'บันทึกการส่ง email[send successful] ลงใน record_log
            dataRecordInFile = vbNewLine & Now & vbTab & typeSending & vbTab & vbTab & "send successful" & vbTab & Left(email_text, Len(email_text) - 1)
            writer = New System.IO.StreamWriter(path_record_log, True)
            writer.Write(dataRecordInFile)
            writer.Close()
        Catch ex As Exception
            'บันทึกการส่ง email[send failed] ลงใน record_log
            dataRecordInFile = vbNewLine & Now & vbTab & typeSending & vbTab & vbTab & "send failed" & vbTab & Left(email_text, Len(email_text) - 1)
            writer = New System.IO.StreamWriter(path_record_log, True)
            writer.Write(dataRecordInFile)
            writer.Close()
        End Try
    End Sub

    Function ValidateCertificate(ByVal sender As Object, ByVal cert As X509Certificate, ByVal chain As X509Chain, ByVal errors As SslPolicyErrors) As Boolean
        Return True
    End Function
End Module
