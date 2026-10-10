<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHolidays
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHolidays))
        Me.cmbAdd = New System.Windows.Forms.Button()
        Me.cmbDeleteSelected = New System.Windows.Forms.Button()
        Me.cbmEdit = New System.Windows.Forms.Button()
        Me.GridHolidays = New System.Windows.Forms.DataGridView()
        Me.HolidysSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportHolidaysToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.dtpHoliday = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbbHolidayCode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GridHolidays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbAdd
        '
        Me.cmbAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbAdd.Location = New System.Drawing.Point(20, 168)
        Me.cmbAdd.Name = "cmbAdd"
        Me.cmbAdd.Size = New System.Drawing.Size(97, 39)
        Me.cmbAdd.TabIndex = 11
        Me.cmbAdd.Text = "Save Add"
        Me.cmbAdd.UseVisualStyleBackColor = True
        '
        'cmbDeleteSelected
        '
        Me.cmbDeleteSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbDeleteSelected.Location = New System.Drawing.Point(68, 229)
        Me.cmbDeleteSelected.Name = "cmbDeleteSelected"
        Me.cmbDeleteSelected.Size = New System.Drawing.Size(97, 39)
        Me.cmbDeleteSelected.TabIndex = 10
        Me.cmbDeleteSelected.Text = "Delete"
        Me.cmbDeleteSelected.UseVisualStyleBackColor = True
        '
        'cbmEdit
        '
        Me.cbmEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbmEdit.Location = New System.Drawing.Point(137, 168)
        Me.cbmEdit.Name = "cbmEdit"
        Me.cbmEdit.Size = New System.Drawing.Size(97, 39)
        Me.cbmEdit.TabIndex = 9
        Me.cbmEdit.Text = "Save Edit"
        Me.cbmEdit.UseVisualStyleBackColor = True
        '
        'GridHolidays
        '
        Me.GridHolidays.AllowUserToAddRows = False
        Me.GridHolidays.AllowUserToDeleteRows = False
        Me.GridHolidays.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GridHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridHolidays.Location = New System.Drawing.Point(12, 43)
        Me.GridHolidays.Name = "GridHolidays"
        Me.GridHolidays.Size = New System.Drawing.Size(796, 411)
        Me.GridHolidays.TabIndex = 8
        '
        'HolidysSetupToolStripMenuItem
        '
        Me.HolidysSetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportHolidaysToolStripMenuItem})
        Me.HolidysSetupToolStripMenuItem.Image = CType(resources.GetObject("HolidysSetupToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HolidysSetupToolStripMenuItem.Name = "HolidysSetupToolStripMenuItem"
        Me.HolidysSetupToolStripMenuItem.Size = New System.Drawing.Size(105, 25)
        Me.HolidysSetupToolStripMenuItem.Text = "Holidays"
        '
        'ImportHolidaysToolStripMenuItem
        '
        Me.ImportHolidaysToolStripMenuItem.Name = "ImportHolidaysToolStripMenuItem"
        Me.ImportHolidaysToolStripMenuItem.Size = New System.Drawing.Size(203, 26)
        Me.ImportHolidaysToolStripMenuItem.Text = "Import Holidays"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HolidysSetupToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1099, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(20, 58)
        Me.txtTitle.Multiline = True
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(214, 62)
        Me.txtTitle.TabIndex = 12
        '
        'dtpHoliday
        '
        Me.dtpHoliday.Location = New System.Drawing.Point(20, 19)
        Me.dtpHoliday.Name = "dtpHoliday"
        Me.dtpHoliday.Size = New System.Drawing.Size(125, 20)
        Me.dtpHoliday.TabIndex = 13
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbDeleteSelected)
        Me.GroupBox1.Controls.Add(Me.cbbHolidayCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpHoliday)
        Me.GroupBox1.Controls.Add(Me.cmbAdd)
        Me.GroupBox1.Controls.Add(Me.txtTitle)
        Me.GroupBox1.Controls.Add(Me.cbmEdit)
        Me.GroupBox1.Location = New System.Drawing.Point(831, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 286)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'cbbHolidayCode
        '
        Me.cbbHolidayCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbbHolidayCode.FormattingEnabled = True
        Me.cbbHolidayCode.Items.AddRange(New Object() {"C", "S", "T"})
        Me.cbbHolidayCode.Location = New System.Drawing.Point(20, 126)
        Me.cbbHolidayCode.Name = "cbbHolidayCode"
        Me.cbbHolidayCode.Size = New System.Drawing.Size(214, 28)
        Me.cbbHolidayCode.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Title"
        '
        'frmHolidays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1099, 485)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridHolidays)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmHolidays"
        CType(Me.GridHolidays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbAdd As System.Windows.Forms.Button
    Friend WithEvents cmbDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents cbmEdit As System.Windows.Forms.Button
    Friend WithEvents GridHolidays As System.Windows.Forms.DataGridView
    Friend WithEvents HolidysSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents dtpHoliday As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImportHolidaysToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbbHolidayCode As System.Windows.Forms.ComboBox
End Class
