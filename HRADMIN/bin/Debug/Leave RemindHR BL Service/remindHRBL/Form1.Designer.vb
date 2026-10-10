<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.remind_time = New System.Windows.Forms.TextBox()
        Me.set_email = New System.Windows.Forms.Button()
        Me.view_log = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.showtime = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.show_status = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "เวลาแจ้งเตือน :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Email HR :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(109, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Log :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(259, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "โปรแกรมแจ้งเตือน HR สำหรับการลาประเภท BL"
        '
        'remind_time
        '
        Me.remind_time.BackColor = System.Drawing.Color.White
        Me.remind_time.Location = New System.Drawing.Point(167, 94)
        Me.remind_time.Multiline = True
        Me.remind_time.Name = "remind_time"
        Me.remind_time.ReadOnly = True
        Me.remind_time.Size = New System.Drawing.Size(97, 26)
        Me.remind_time.TabIndex = 4
        Me.remind_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'set_email
        '
        Me.set_email.AccessibleName = ""
        Me.set_email.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.set_email.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.set_email.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.set_email.ForeColor = System.Drawing.Color.White
        Me.set_email.Location = New System.Drawing.Point(167, 138)
        Me.set_email.Name = "set_email"
        Me.set_email.Size = New System.Drawing.Size(97, 26)
        Me.set_email.TabIndex = 5
        Me.set_email.Text = "Email list"
        Me.set_email.UseVisualStyleBackColor = False
        '
        'view_log
        '
        Me.view_log.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.view_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.view_log.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.view_log.ForeColor = System.Drawing.Color.White
        Me.view_log.Location = New System.Drawing.Point(167, 185)
        Me.view_log.Name = "view_log"
        Me.view_log.Size = New System.Drawing.Size(97, 26)
        Me.view_log.TabIndex = 6
        Me.view_log.Text = "view log"
        Me.view_log.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'showtime
        '
        Me.showtime.Location = New System.Drawing.Point(12, 340)
        Me.showtime.Name = "showtime"
        Me.showtime.Size = New System.Drawing.Size(307, 19)
        Me.showtime.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(93, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Status :"
        '
        'show_status
        '
        Me.show_status.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.show_status.ForeColor = System.Drawing.Color.Green
        Me.show_status.Location = New System.Drawing.Point(164, 242)
        Me.show_status.Name = "show_status"
        Me.show_status.Size = New System.Drawing.Size(100, 16)
        Me.show_status.TabIndex = 9
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "123"
        Me.NotifyIcon1.BalloonTipTitle = "456"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Program remind email to HR for leave BL type"
        Me.NotifyIcon1.Visible = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 368)
        Me.Controls.Add(Me.show_status)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.showtime)
        Me.Controls.Add(Me.view_log)
        Me.Controls.Add(Me.set_email)
        Me.Controls.Add(Me.remind_time)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "โปรแกรมแจ้งเตือน HR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents remind_time As System.Windows.Forms.TextBox
    Friend WithEvents set_email As System.Windows.Forms.Button
    Friend WithEvents view_log As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents showtime As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents show_status As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon

End Class
