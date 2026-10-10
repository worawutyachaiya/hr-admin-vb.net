<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMemberGroupWorkDesc
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
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxGroupProcess = New System.Windows.Forms.ComboBox()
        Me.btn_edit_process_name = New System.Windows.Forms.Button()
        Me.ListBox_process_name = New System.Windows.Forms.ListBox()
        Me.txtbox_process_name = New System.Windows.Forms.TextBox()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.btn_edit = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(488, 34)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(83, 38)
        Me.ButtonOK.TabIndex = 5
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 24)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "กลุ่มตาม Process"
        '
        'ComboBoxGroupProcess
        '
        Me.ComboBoxGroupProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxGroupProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxGroupProcess.FormattingEnabled = True
        Me.ComboBoxGroupProcess.Location = New System.Drawing.Point(161, 39)
        Me.ComboBoxGroupProcess.Name = "ComboBoxGroupProcess"
        Me.ComboBoxGroupProcess.Size = New System.Drawing.Size(321, 28)
        Me.ComboBoxGroupProcess.TabIndex = 3
        '
        'btn_edit_process_name
        '
        Me.btn_edit_process_name.Location = New System.Drawing.Point(466, 78)
        Me.btn_edit_process_name.Name = "btn_edit_process_name"
        Me.btn_edit_process_name.Size = New System.Drawing.Size(105, 23)
        Me.btn_edit_process_name.TabIndex = 6
        Me.btn_edit_process_name.Text = "เปิดแก้ไข Process"
        Me.btn_edit_process_name.UseVisualStyleBackColor = True
        '
        'ListBox_process_name
        '
        Me.ListBox_process_name.FormattingEnabled = True
        Me.ListBox_process_name.Location = New System.Drawing.Point(12, 149)
        Me.ListBox_process_name.Name = "ListBox_process_name"
        Me.ListBox_process_name.Size = New System.Drawing.Size(559, 251)
        Me.ListBox_process_name.TabIndex = 7
        '
        'txtbox_process_name
        '
        Me.txtbox_process_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_process_name.Location = New System.Drawing.Point(12, 118)
        Me.txtbox_process_name.Name = "txtbox_process_name"
        Me.txtbox_process_name.Size = New System.Drawing.Size(384, 22)
        Me.txtbox_process_name.TabIndex = 8
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(402, 117)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(56, 23)
        Me.btn_add.TabIndex = 9
        Me.btn_add.Text = "เพิ่ม"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'btn_edit
        '
        Me.btn_edit.Location = New System.Drawing.Point(464, 117)
        Me.btn_edit.Name = "btn_edit"
        Me.btn_edit.Size = New System.Drawing.Size(49, 23)
        Me.btn_edit.TabIndex = 10
        Me.btn_edit.Text = "แก้ไข"
        Me.btn_edit.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(519, 117)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(53, 23)
        Me.btn_delete.TabIndex = 11
        Me.btn_delete.Text = "ลบ"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'frmAddMemberGroupWorkDesc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 473)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_edit)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.txtbox_process_name)
        Me.Controls.Add(Me.ListBox_process_name)
        Me.Controls.Add(Me.btn_edit_process_name)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxGroupProcess)
        Me.Name = "frmAddMemberGroupWorkDesc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAddMemberGroupWorkDesc"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGroupProcess As System.Windows.Forms.ComboBox
    Friend WithEvents btn_edit_process_name As Button
    Friend WithEvents ListBox_process_name As ListBox
    Friend WithEvents txtbox_process_name As TextBox
    Friend WithEvents btn_add As Button
    Friend WithEvents btn_edit As Button
    Friend WithEvents btn_delete As Button
End Class
