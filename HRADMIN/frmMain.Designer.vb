<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SetUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HolidaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PositionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExportData = New System.Windows.Forms.Button()
        Me.lbSummary = New System.Windows.Forms.Label()
        Me.cmbButton = New System.Windows.Forms.Button()
        Me.DataGridLeave = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbbDept = New System.Windows.Forms.ComboBox()
        Me.cmbSearcDept = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbbType = New System.Windows.Forms.ComboBox()
        Me.cmbSearchEmpCode = New System.Windows.Forms.Button()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbSearchDate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimeFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTimeTo = New System.Windows.Forms.DateTimePicker()
        Me.btnHROK = New System.Windows.Forms.Button()
        Me.checked_show_hr_ok = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridLeave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetUpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1271, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SetUpToolStripMenuItem
        '
        Me.SetUpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MemberToolStripMenuItem, Me.DepartmentToolStripMenuItem, Me.SectionToolStripMenuItem, Me.HolidaysToolStripMenuItem, Me.FlowToolStripMenuItem, Me.PCodeToolStripMenuItem, Me.PositionToolStripMenuItem})
        Me.SetUpToolStripMenuItem.Image = CType(resources.GetObject("SetUpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SetUpToolStripMenuItem.Name = "SetUpToolStripMenuItem"
        Me.SetUpToolStripMenuItem.Size = New System.Drawing.Size(86, 25)
        Me.SetUpToolStripMenuItem.Text = "Set Up"
        '
        'MemberToolStripMenuItem
        '
        Me.MemberToolStripMenuItem.Image = CType(resources.GetObject("MemberToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MemberToolStripMenuItem.Name = "MemberToolStripMenuItem"
        Me.MemberToolStripMenuItem.Size = New System.Drawing.Size(169, 26)
        Me.MemberToolStripMenuItem.Text = "Member"
        '
        'DepartmentToolStripMenuItem
        '
        Me.DepartmentToolStripMenuItem.Image = CType(resources.GetObject("DepartmentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DepartmentToolStripMenuItem.Name = "DepartmentToolStripMenuItem"
        Me.DepartmentToolStripMenuItem.Size = New System.Drawing.Size(169, 26)
        Me.DepartmentToolStripMenuItem.Text = "Department"
        '
        'SectionToolStripMenuItem
        '
        Me.SectionToolStripMenuItem.Image = CType(resources.GetObject("SectionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SectionToolStripMenuItem.Name = "SectionToolStripMenuItem"
        Me.SectionToolStripMenuItem.Size = New System.Drawing.Size(169, 26)
        Me.SectionToolStripMenuItem.Text = "Section"
        '
        'HolidaysToolStripMenuItem
        '
        Me.HolidaysToolStripMenuItem.Image = CType(resources.GetObject("HolidaysToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HolidaysToolStripMenuItem.Name = "HolidaysToolStripMenuItem"
        Me.HolidaysToolStripMenuItem.Size = New System.Drawing.Size(169, 26)
        Me.HolidaysToolStripMenuItem.Text = "Holidays"
        '
        'FlowToolStripMenuItem
        '
        Me.FlowToolStripMenuItem.Image = CType(resources.GetObject("FlowToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FlowToolStripMenuItem.Name = "FlowToolStripMenuItem"
        Me.FlowToolStripMenuItem.Size = New System.Drawing.Size(169, 26)
        Me.FlowToolStripMenuItem.Text = "Flow Leave"
        '
        'PCodeToolStripMenuItem
        '
        Me.PCodeToolStripMenuItem.Image = CType(resources.GetObject("PCodeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PCodeToolStripMenuItem.Name = "PCodeToolStripMenuItem"
        Me.PCodeToolStripMenuItem.Size = New System.Drawing.Size(169, 26)
        Me.PCodeToolStripMenuItem.Text = "PCode"
        '
        'PositionToolStripMenuItem
        '
        Me.PositionToolStripMenuItem.Image = CType(resources.GetObject("PositionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PositionToolStripMenuItem.Name = "PositionToolStripMenuItem"
        Me.PositionToolStripMenuItem.Size = New System.Drawing.Size(169, 26)
        Me.PositionToolStripMenuItem.Text = "Position"
        '
        'btnExportData
        '
        Me.btnExportData.Image = CType(resources.GetObject("btnExportData.Image"), System.Drawing.Image)
        Me.btnExportData.Location = New System.Drawing.Point(898, 66)
        Me.btnExportData.Name = "btnExportData"
        Me.btnExportData.Size = New System.Drawing.Size(108, 49)
        Me.btnExportData.TabIndex = 20
        Me.btnExportData.UseVisualStyleBackColor = True
        '
        'lbSummary
        '
        Me.lbSummary.AutoSize = True
        Me.lbSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lbSummary.Location = New System.Drawing.Point(15, 124)
        Me.lbSummary.Name = "lbSummary"
        Me.lbSummary.Size = New System.Drawing.Size(0, 16)
        Me.lbSummary.TabIndex = 19
        '
        'cmbButton
        '
        Me.cmbButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbButton.Location = New System.Drawing.Point(1132, 68)
        Me.cmbButton.Name = "cmbButton"
        Me.cmbButton.Size = New System.Drawing.Size(127, 48)
        Me.cmbButton.TabIndex = 18
        Me.cmbButton.Text = "Cancel  Leave Selected"
        Me.cmbButton.UseVisualStyleBackColor = True
        '
        'DataGridLeave
        '
        Me.DataGridLeave.AllowUserToAddRows = False
        Me.DataGridLeave.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki
        Me.DataGridLeave.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridLeave.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridLeave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridLeave.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridLeave.Location = New System.Drawing.Point(15, 146)
        Me.DataGridLeave.Name = "DataGridLeave"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridLeave.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridLeave.Size = New System.Drawing.Size(1244, 693)
        Me.DataGridLeave.TabIndex = 16
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbbDept)
        Me.GroupBox4.Controls.Add(Me.cmbSearcDept)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(600, 48)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(292, 72)
        Me.GroupBox4.TabIndex = 15
        Me.GroupBox4.TabStop = False
        '
        'cbbDept
        '
        Me.cbbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbbDept.FormattingEnabled = True
        Me.cbbDept.Location = New System.Drawing.Point(68, 30)
        Me.cbbDept.Name = "cbbDept"
        Me.cbbDept.Size = New System.Drawing.Size(148, 24)
        Me.cbbDept.TabIndex = 6
        '
        'cmbSearcDept
        '
        Me.cmbSearcDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbSearcDept.Image = CType(resources.GetObject("cmbSearcDept.Image"), System.Drawing.Image)
        Me.cmbSearcDept.Location = New System.Drawing.Point(222, 20)
        Me.cmbSearcDept.Name = "cmbSearcDept"
        Me.cmbSearcDept.Size = New System.Drawing.Size(64, 38)
        Me.cmbSearcDept.TabIndex = 5
        Me.cmbSearcDept.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Section"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbbType)
        Me.GroupBox2.Controls.Add(Me.cmbSearchEmpCode)
        Me.GroupBox2.Controls.Add(Me.txtID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 72)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'cbbType
        '
        Me.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbbType.FormattingEnabled = True
        Me.cbbType.Location = New System.Drawing.Point(98, 43)
        Me.cbbType.Name = "cbbType"
        Me.cbbType.Size = New System.Drawing.Size(97, 24)
        Me.cbbType.TabIndex = 6
        '
        'cmbSearchEmpCode
        '
        Me.cmbSearchEmpCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbSearchEmpCode.Image = CType(resources.GetObject("cmbSearchEmpCode.Image"), System.Drawing.Image)
        Me.cmbSearchEmpCode.Location = New System.Drawing.Point(201, 19)
        Me.cmbSearchEmpCode.Name = "cmbSearchEmpCode"
        Me.cmbSearchEmpCode.Size = New System.Drawing.Size(64, 40)
        Me.cmbSearchEmpCode.TabIndex = 5
        Me.cmbSearchEmpCode.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtID.Location = New System.Drawing.Point(98, 15)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(97, 22)
        Me.txtID.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "emp.Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbSearchDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DateTimeFrom)
        Me.GroupBox1.Controls.Add(Me.DateTimeTo)
        Me.GroupBox1.Location = New System.Drawing.Point(324, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 72)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'cmbSearchDate
        '
        Me.cmbSearchDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbSearchDate.Image = CType(resources.GetObject("cmbSearchDate.Image"), System.Drawing.Image)
        Me.cmbSearchDate.Location = New System.Drawing.Point(188, 16)
        Me.cmbSearchDate.Name = "cmbSearchDate"
        Me.cmbSearchDate.Size = New System.Drawing.Size(62, 42)
        Me.cmbSearchDate.TabIndex = 5
        Me.cmbSearchDate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Date "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To"
        '
        'DateTimeFrom
        '
        Me.DateTimeFrom.CustomFormat = ""
        Me.DateTimeFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DateTimeFrom.Location = New System.Drawing.Point(51, 16)
        Me.DateTimeFrom.Name = "DateTimeFrom"
        Me.DateTimeFrom.Size = New System.Drawing.Size(131, 22)
        Me.DateTimeFrom.TabIndex = 2
        '
        'DateTimeTo
        '
        Me.DateTimeTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DateTimeTo.Location = New System.Drawing.Point(52, 46)
        Me.DateTimeTo.Name = "DateTimeTo"
        Me.DateTimeTo.Size = New System.Drawing.Size(129, 22)
        Me.DateTimeTo.TabIndex = 3
        '
        'btnHROK
        '
        Me.btnHROK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHROK.Location = New System.Drawing.Point(1012, 68)
        Me.btnHROK.Name = "btnHROK"
        Me.btnHROK.Size = New System.Drawing.Size(114, 48)
        Me.btnHROK.TabIndex = 21
        Me.btnHROK.Text = "HR OK Selected"
        Me.btnHROK.UseVisualStyleBackColor = True
        '
        'checked_show_hr_ok
        '
        Me.checked_show_hr_ok.AutoSize = True
        Me.checked_show_hr_ok.Location = New System.Drawing.Point(18, 32)
        Me.checked_show_hr_ok.Name = "checked_show_hr_ok"
        Me.checked_show_hr_ok.Size = New System.Drawing.Size(215, 17)
        Me.checked_show_hr_ok.TabIndex = 23
        Me.checked_show_hr_ok.Text = "แสดงการลาที่ทำการตรวจสอบไปแล้วด้วย"
        Me.checked_show_hr_ok.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1271, 854)
        Me.Controls.Add(Me.checked_show_hr_ok)
        Me.Controls.Add(Me.btnHROK)
        Me.Controls.Add(Me.btnExportData)
        Me.Controls.Add(Me.lbSummary)
        Me.Controls.Add(Me.cmbButton)
        Me.Controls.Add(Me.DataGridLeave)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridLeave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SetUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MemberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepartmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HolidaysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PCodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PositionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExportData As System.Windows.Forms.Button
    Friend WithEvents lbSummary As System.Windows.Forms.Label
    Friend WithEvents cmbButton As System.Windows.Forms.Button
    Friend WithEvents DataGridLeave As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbbDept As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSearcDept As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbbType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSearchEmpCode As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSearchDate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimeFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimeTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnHROK As System.Windows.Forms.Button
    Friend WithEvents checked_show_hr_ok As System.Windows.Forms.CheckBox

End Class
