<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMember
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMember))
        Me.cmbDeleteSelected = New System.Windows.Forms.Button()
        Me.cbmEdit = New System.Windows.Forms.Button()
        Me.GridMembers = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HolidysSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportMemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmpCode = New System.Windows.Forms.TextBox()
        Me.cmbSearchEmpCode = New System.Windows.Forms.Button()
        Me.cmbSearcDept = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbbDept = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnResigned = New System.Windows.Forms.Button()
        Me.lbImportStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.GridMembers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbDeleteSelected
        '
        Me.cmbDeleteSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbDeleteSelected.Location = New System.Drawing.Point(693, 19)
        Me.cmbDeleteSelected.Name = "cmbDeleteSelected"
        Me.cmbDeleteSelected.Size = New System.Drawing.Size(88, 41)
        Me.cmbDeleteSelected.TabIndex = 15
        Me.cmbDeleteSelected.Text = "Delete"
        Me.cmbDeleteSelected.UseVisualStyleBackColor = True
        '
        'cbmEdit
        '
        Me.cbmEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbmEdit.Location = New System.Drawing.Point(591, 19)
        Me.cbmEdit.Name = "cbmEdit"
        Me.cbmEdit.Size = New System.Drawing.Size(84, 41)
        Me.cbmEdit.TabIndex = 14
        Me.cbmEdit.Text = "Edit"
        Me.cbmEdit.UseVisualStyleBackColor = True
        '
        'GridMembers
        '
        Me.GridMembers.AllowUserToAddRows = False
        Me.GridMembers.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GridMembers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.GridMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.GridMembers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridMembers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.GridMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridMembers.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GridMembers.Location = New System.Drawing.Point(0, 99)
        Me.GridMembers.Name = "GridMembers"
        Me.GridMembers.Size = New System.Drawing.Size(1312, 683)
        Me.GridMembers.TabIndex = 13
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HolidysSetupToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1312, 29)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HolidysSetupToolStripMenuItem
        '
        Me.HolidysSetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportMemberToolStripMenuItem})
        Me.HolidysSetupToolStripMenuItem.Image = CType(resources.GetObject("HolidysSetupToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HolidysSetupToolStripMenuItem.Name = "HolidysSetupToolStripMenuItem"
        Me.HolidysSetupToolStripMenuItem.Size = New System.Drawing.Size(102, 25)
        Me.HolidysSetupToolStripMenuItem.Text = "Member"
        '
        'ImportMemberToolStripMenuItem
        '
        Me.ImportMemberToolStripMenuItem.Image = CType(resources.GetObject("ImportMemberToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImportMemberToolStripMenuItem.Name = "ImportMemberToolStripMenuItem"
        Me.ImportMemberToolStripMenuItem.Size = New System.Drawing.Size(200, 26)
        Me.ImportMemberToolStripMenuItem.Text = "Import Member"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Emp.Code"
        '
        'txtEmpCode
        '
        Me.txtEmpCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtEmpCode.Location = New System.Drawing.Point(91, 28)
        Me.txtEmpCode.Name = "txtEmpCode"
        Me.txtEmpCode.Size = New System.Drawing.Size(100, 22)
        Me.txtEmpCode.TabIndex = 18
        '
        'cmbSearchEmpCode
        '
        Me.cmbSearchEmpCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbSearchEmpCode.Location = New System.Drawing.Point(197, 18)
        Me.cmbSearchEmpCode.Name = "cmbSearchEmpCode"
        Me.cmbSearchEmpCode.Size = New System.Drawing.Size(75, 41)
        Me.cmbSearchEmpCode.TabIndex = 19
        Me.cmbSearchEmpCode.Text = "Search"
        Me.cmbSearchEmpCode.UseVisualStyleBackColor = True
        '
        'cmbSearcDept
        '
        Me.cmbSearcDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbSearcDept.Location = New System.Drawing.Point(500, 18)
        Me.cmbSearcDept.Name = "cmbSearcDept"
        Me.cmbSearcDept.Size = New System.Drawing.Size(75, 41)
        Me.cmbSearcDept.TabIndex = 22
        Me.cmbSearcDept.Text = "Search"
        Me.cmbSearcDept.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(278, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Department"
        '
        'cbbDept
        '
        Me.cbbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbbDept.FormattingEnabled = True
        Me.cbbDept.Location = New System.Drawing.Point(374, 28)
        Me.cbbDept.Name = "cbbDept"
        Me.cbbDept.Size = New System.Drawing.Size(116, 24)
        Me.cbbDept.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.GroupBox1.Controls.Add(Me.btnResigned)
        Me.GroupBox1.Controls.Add(Me.lbImportStatus)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbbDept)
        Me.GroupBox1.Controls.Add(Me.cbmEdit)
        Me.GroupBox1.Controls.Add(Me.cmbSearcDept)
        Me.GroupBox1.Controls.Add(Me.cmbDeleteSelected)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtEmpCode)
        Me.GroupBox1.Controls.Add(Me.cmbSearchEmpCode)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1312, 70)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'btnResigned
        '
        Me.btnResigned.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResigned.Location = New System.Drawing.Point(800, 19)
        Me.btnResigned.Name = "btnResigned"
        Me.btnResigned.Size = New System.Drawing.Size(96, 40)
        Me.btnResigned.TabIndex = 25
        Me.btnResigned.Text = "Resigned"
        Me.btnResigned.UseVisualStyleBackColor = True
        '
        'lbImportStatus
        '
        Me.lbImportStatus.AutoSize = True
        Me.lbImportStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbImportStatus.Location = New System.Drawing.Point(929, 23)
        Me.lbImportStatus.Name = "lbImportStatus"
        Me.lbImportStatus.Size = New System.Drawing.Size(105, 16)
        Me.lbImportStatus.TabIndex = 24
        Me.lbImportStatus.Text = "Import Status :"
        '
        'Timer1
        '
        '
        'frmMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1312, 782)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridMembers)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MaximizeBox = False
        Me.Name = "frmMember"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.GridMembers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents cbmEdit As System.Windows.Forms.Button
    Friend WithEvents GridMembers As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HolidysSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmpCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbSearchEmpCode As System.Windows.Forms.Button
    Friend WithEvents cmbSearcDept As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbbDept As System.Windows.Forms.ComboBox
    Friend WithEvents ImportMemberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbImportStatus As System.Windows.Forms.Label
    Friend WithEvents btnResigned As System.Windows.Forms.Button
End Class
