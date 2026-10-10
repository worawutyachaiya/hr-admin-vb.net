<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMemberBirthDay
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
        Me.DatePickerBirthDay = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DatePickerBirthDay
        '
        Me.DatePickerBirthDay.Location = New System.Drawing.Point(21, 35)
        Me.DatePickerBirthDay.Name = "DatePickerBirthDay"
        Me.DatePickerBirthDay.Size = New System.Drawing.Size(200, 20)
        Me.DatePickerBirthDay.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Birth day"
        '
        'cmbOk
        '
        Me.cmbOk.Location = New System.Drawing.Point(246, 26)
        Me.cmbOk.Name = "cmbOk"
        Me.cmbOk.Size = New System.Drawing.Size(75, 29)
        Me.cmbOk.TabIndex = 10
        Me.cmbOk.Text = "OK"
        Me.cmbOk.UseVisualStyleBackColor = True
        '
        'frmAddMemberBirthDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 72)
        Me.Controls.Add(Me.DatePickerBirthDay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddMemberBirthDay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DatePickerBirthDay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOk As System.Windows.Forms.Button
End Class
