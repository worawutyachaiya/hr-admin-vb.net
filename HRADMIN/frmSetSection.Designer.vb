<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetSection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetSection))
        Me.cmbAdd = New System.Windows.Forms.Button()
        Me.cmbDeleteSelected = New System.Windows.Forms.Button()
        Me.cbmEdit = New System.Windows.Forms.Button()
        Me.GridviewSection = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.txtSectionID = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.GridviewSection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbAdd
        '
        Me.cmbAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbAdd.Location = New System.Drawing.Point(599, 190)
        Me.cmbAdd.Name = "cmbAdd"
        Me.cmbAdd.Size = New System.Drawing.Size(91, 39)
        Me.cmbAdd.TabIndex = 9
        Me.cmbAdd.Text = "Save Add"
        Me.cmbAdd.UseVisualStyleBackColor = True
        '
        'cmbDeleteSelected
        '
        Me.cmbDeleteSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbDeleteSelected.Location = New System.Drawing.Point(602, 327)
        Me.cmbDeleteSelected.Name = "cmbDeleteSelected"
        Me.cmbDeleteSelected.Size = New System.Drawing.Size(88, 39)
        Me.cmbDeleteSelected.TabIndex = 7
        Me.cmbDeleteSelected.Text = "Delete"
        Me.cmbDeleteSelected.UseVisualStyleBackColor = True
        '
        'cbmEdit
        '
        Me.cbmEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbmEdit.Location = New System.Drawing.Point(599, 257)
        Me.cbmEdit.Name = "cbmEdit"
        Me.cbmEdit.Size = New System.Drawing.Size(88, 39)
        Me.cbmEdit.TabIndex = 6
        Me.cbmEdit.Text = "Save Edit"
        Me.cbmEdit.UseVisualStyleBackColor = True
        '
        'GridviewSection
        '
        Me.GridviewSection.AllowUserToAddRows = False
        Me.GridviewSection.AllowUserToDeleteRows = False
        Me.GridviewSection.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.GridviewSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridviewSection.Location = New System.Drawing.Point(28, 113)
        Me.GridviewSection.Name = "GridviewSection"
        Me.GridviewSection.RowHeadersWidth = 51
        Me.GridviewSection.Size = New System.Drawing.Size(544, 438)
        Me.GridviewSection.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepartmentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(727, 29)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DepartmentToolStripMenuItem
        '
        Me.DepartmentToolStripMenuItem.Image = CType(resources.GetObject("DepartmentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DepartmentToolStripMenuItem.Name = "DepartmentToolStripMenuItem"
        Me.DepartmentToolStripMenuItem.Size = New System.Drawing.Size(99, 25)
        Me.DepartmentToolStripMenuItem.Text = "Section"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Section:"
        '
        'txtSection
        '
        Me.txtSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSection.Location = New System.Drawing.Point(86, 29)
        Me.txtSection.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(270, 23)
        Me.txtSection.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label2.Location = New System.Drawing.Point(379, 32)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Department:"
        '
        'txtDepartment
        '
        Me.txtDepartment.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.Location = New System.Drawing.Point(478, 29)
        Me.txtDepartment.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(199, 23)
        Me.txtDepartment.TabIndex = 13
        '
        'txtSectionID
        '
        Me.txtSectionID.Location = New System.Drawing.Point(99, 10)
        Me.txtSectionID.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtSectionID.Name = "txtSectionID"
        Me.txtSectionID.Size = New System.Drawing.Size(147, 20)
        Me.txtSectionID.TabIndex = 14
        Me.txtSectionID.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSection)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDepartment)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(14, 40)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(693, 63)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input data for Add and Selected data for Edit and Delete"
        '
        'frmSetSection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 572)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtSectionID)
        Me.Controls.Add(Me.cmbAdd)
        Me.Controls.Add(Me.cmbDeleteSelected)
        Me.Controls.Add(Me.cbmEdit)
        Me.Controls.Add(Me.GridviewSection)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmSetSection"
        CType(Me.GridviewSection, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GridviewSection As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DepartmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSection As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents txtSectionID As TextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
