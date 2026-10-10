<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMemberSex
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
        Me.cbbSex = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Sex"
        '
        'cmbOk
        '
        Me.cmbOk.Location = New System.Drawing.Point(230, 26)
        Me.cmbOk.Name = "cmbOk"
        Me.cmbOk.Size = New System.Drawing.Size(75, 23)
        Me.cmbOk.TabIndex = 4
        Me.cmbOk.Text = "OK"
        Me.cmbOk.UseVisualStyleBackColor = True
        '
        'cbbSex
        '
        Me.cbbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSex.FormattingEnabled = True
        Me.cbbSex.Location = New System.Drawing.Point(12, 28)
        Me.cbbSex.Name = "cbbSex"
        Me.cbbSex.Size = New System.Drawing.Size(203, 21)
        Me.cbbSex.TabIndex = 3
        '
        'frmAddMemberSex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 66)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbOk)
        Me.Controls.Add(Me.cbbSex)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddMemberSex"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOk As System.Windows.Forms.Button
    Friend WithEvents cbbSex As System.Windows.Forms.ComboBox
End Class
