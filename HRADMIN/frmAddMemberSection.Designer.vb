<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMemberSection
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
        Me.cbbSection = New System.Windows.Forms.ComboBox()
        Me.cmbOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbbSection
        '
        Me.cbbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbSection.FormattingEnabled = True
        Me.cbbSection.Location = New System.Drawing.Point(21, 23)
        Me.cbbSection.Name = "cbbSection"
        Me.cbbSection.Size = New System.Drawing.Size(203, 21)
        Me.cbbSection.TabIndex = 0
        '
        'cmbOk
        '
        Me.cmbOk.Location = New System.Drawing.Point(239, 21)
        Me.cmbOk.Name = "cmbOk"
        Me.cmbOk.Size = New System.Drawing.Size(75, 23)
        Me.cmbOk.TabIndex = 1
        Me.cmbOk.Text = "OK"
        Me.cmbOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Section"
        '
        'frmAddMemberSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 62)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbOk)
        Me.Controls.Add(Me.cbbSection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddMemberSection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbbSection As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
