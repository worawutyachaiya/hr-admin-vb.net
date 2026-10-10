'********************************************
'
' @Autor         Pipimphorn
' @Company       Furukawa FITEL
' @Date          7 Mar 2018
' @Description   Program remind email to HR for leave BL type.
' @Tool          - Visual Studio 2012 VB
'                
'********************************************
Imports Schedule

Public Class Form1
    Dim timeSchedule As ScheduledTime
    Dim time As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Timer1.Start()
        Me.show_status.Text = "Running .."
        Dim temp As New List(Of String)

        'เปิด file เพื่อ get เวลาแจ้งเตือน
        If System.IO.File.Exists(path_remind_time) Then
            Dim reader() As String = System.IO.File.ReadAllLines(path_remind_time)
            Dim txt As String
            For Each txt In reader
                temp.Add(txt)
            Next
            time = temp(0)
            Me.remind_time.Text = time

            If Not IsDate(time) Then
                'ส่ง email แจ้ง HR ให้ตรวจสอบเวลาที่จะให้ program ส่ง email
                send_email("<p style='font-size:16px'>" & headMail & "Setting time to send reminder email is not a time. Please contact IT dept. to check this !!" & footMail & "</p>", "Setting", "HR")

            Else
                'สร้าง loop แจ้งเตือนตามเวลาที่ set ไว้
                Dim timeSchedule = New ScheduleTimer()
                AddHandler timeSchedule.Elapsed, New ScheduledEventHandler(AddressOf maincode.send_reminder)
                timeSchedule.AddEvent(New ScheduledTime(EventTimeBase.Daily, time))
                timeSchedule.Start()
            End If
        Else
            MsgBox("ไม่พบไฟล์ : " & vbNewLine & path_remind_time & vbNewLine & vbNewLine & "กรุณาตรวจสอบ ที่อยู่ไฟล์หรือชื่อไฟล์ ให้ถูกต้อง", vbExclamation, "Information message")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.showtime.Text = DateAndTime.Now
    End Sub

    Private Sub set_email_Click(sender As Object, e As EventArgs) Handles set_email.Click
        If System.IO.File.Exists(path_email_list) Then
            Process.Start(path_email_list)
        Else
            System.IO.File.Create(path_email_list).Dispose()
            Process.Start(path_email_list)
        End If
    End Sub

    Private Sub view_log_Click(sender As Object, e As EventArgs) Handles view_log.Click
        If System.IO.File.Exists(path_record_log) Then
            Process.Start(path_record_log)
        Else
            System.IO.File.Create(path_record_log).Dispose()
            Process.Start(path_record_log)
        End If
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Visible = False
                Me.NotifyIcon1.Visible = True
                Me.NotifyIcon1.ShowBalloonTip(1, "Program remind email to HR for leave BL type", "Running in minimized windows", ToolTipIcon.Info)
            End If
        Catch ex As Exception
            MsgBox("ไม่สามารถย่อหน้าต่างได้" & vbNewLine & ex.Message, vbInformation, "Program remind email to HR for leave BL type")
        End Try
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            Me.NotifyIcon1.Visible = False
        Catch ex As Exception
            MsgBox("ไม่สามารถขยายหน้าต่างกลับได้" & vbNewLine & ex.Message, vbExclamation, "Program remind email to HR for leave BL type")
        End Try
    End Sub
End Class
