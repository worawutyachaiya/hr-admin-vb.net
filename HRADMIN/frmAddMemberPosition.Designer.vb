<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMemberPosition
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
        Me.cbbPosition = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Position"
        '
        'cmbOk
        '
        Me.cmbOk.Location = New System.Drawing.Point(230, 24)
        Me.cmbOk.Name = "cmbOk"
        Me.cmbOk.Size = New System.Drawing.Size(75, 23)
        Me.cmbOk.TabIndex = 10
        Me.cmbOk.Text = "OK"
        Me.cmbOk.UseVisualStyleBackColor = True
        '
        'cbbPosition
        '
        Me.cbbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbPosition.FormattingEnabled = True
        Me.cbbPosition.Location = New System.Drawing.Point(12, 26)
        Me.cbbPosition.Name = "cbbPosition"
        Me.cbbPosition.Size = New System.Drawing.Size(203, 21)
        Me.cbbPosition.TabIndex = 9
        '
        'frmAddMemberPosition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 63)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbOk)
        Me.Controls.Add(Me.cbbPosition)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddMemberPosition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOk As System.Windows.Forms.Button
    Friend WithEvents cbbPosition As System.Windows.Forms.ComboBox
End Class
