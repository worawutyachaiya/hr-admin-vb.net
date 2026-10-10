<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMemberStartWork
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOk = New System.Windows.Forms.Button()
        Me.DatePickerStartWork = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Start Work"
        '
        'cmbOk
        '
        Me.cmbOk.Location = New System.Drawing.Point(253, 34)
        Me.cmbOk.Name = "cmbOk"
        Me.cmbOk.Size = New System.Drawing.Size(75, 23)
        Me.cmbOk.TabIndex = 7
        Me.cmbOk.Text = "OK"
        Me.cmbOk.UseVisualStyleBackColor = True
        '
        'DatePickerStartWork
        '
        Me.DatePickerStartWork.Location = New System.Drawing.Point(28, 37)
        Me.DatePickerStartWork.Name = "DatePickerStartWork"
        Me.DatePickerStartWork.Size = New System.Drawing.Size(200, 20)
        Me.DatePickerStartWork.TabIndex = 9
        '
        'frmAddMemberStartWork
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 73)
        Me.Controls.Add(Me.DatePickerStartWork)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddMemberStartWork"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOk As System.Windows.Forms.Button
    Friend WithEvents DatePickerStartWork As System.Windows.Forms.DateTimePicker
End Class
