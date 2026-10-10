<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetAccumulateAnnaulLeave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetAccumulateAnnaulLeave))
        Me.cmbAdd = New System.Windows.Forms.Button()
        Me.cmbDeleteSelected = New System.Windows.Forms.Button()
        Me.cbmEdit = New System.Windows.Forms.Button()
        Me.GridviewAccumulateAL = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAccumulateID = New System.Windows.Forms.TextBox()
        CType(Me.GridviewAccumulateAL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbAdd
        '
        Me.cmbAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbAdd.Location = New System.Drawing.Point(390, 177)
        Me.cmbAdd.Name = "cmbAdd"
        Me.cmbAdd.Size = New System.Drawing.Size(97, 39)
        Me.cmbAdd.TabIndex = 19
        Me.cmbAdd.Text = "Save Add"
        Me.cmbAdd.UseVisualStyleBackColor = True
        '
        'cmbDeleteSelected
        '
        Me.cmbDeleteSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbDeleteSelected.Location = New System.Drawing.Point(390, 327)
        Me.cmbDeleteSelected.Name = "cmbDeleteSelected"
        Me.cmbDeleteSelected.Size = New System.Drawing.Size(97, 39)
        Me.cmbDeleteSelected.TabIndex = 17
        Me.cmbDeleteSelected.Text = "Delete"
        Me.cmbDeleteSelected.UseVisualStyleBackColor = True
        '
        'cbmEdit
        '
        Me.cbmEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbmEdit.Location = New System.Drawing.Point(390, 254)
        Me.cbmEdit.Name = "cbmEdit"
        Me.cbmEdit.Size = New System.Drawing.Size(97, 39)
        Me.cbmEdit.TabIndex = 16
        Me.cbmEdit.Text = "Save Edit"
        Me.cbmEdit.UseVisualStyleBackColor = True
        '
        'GridviewAccumulateAL
        '
        Me.GridviewAccumulateAL.AllowUserToAddRows = False
        Me.GridviewAccumulateAL.AllowUserToDeleteRows = False
        Me.GridviewAccumulateAL.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GridviewAccumulateAL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridviewAccumulateAL.Location = New System.Drawing.Point(21, 141)
        Me.GridviewAccumulateAL.Name = "GridviewAccumulateAL"
        Me.GridviewAccumulateAL.RowHeadersWidth = 51
        Me.GridviewAccumulateAL.Size = New System.Drawing.Size(339, 262)
        Me.GridviewAccumulateAL.TabIndex = 15
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepartmentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(518, 29)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DepartmentToolStripMenuItem
        '
        Me.DepartmentToolStripMenuItem.Image = CType(resources.GetObject("DepartmentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DepartmentToolStripMenuItem.Name = "DepartmentToolStripMenuItem"
        Me.DepartmentToolStripMenuItem.Size = New System.Drawing.Size(192, 25)
        Me.DepartmentToolStripMenuItem.Text = "Accumulate Annual"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtQty)
        Me.GroupBox1.Controls.Add(Me.txtYear)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(32, 46)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(441, 81)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input data for Add and Selected data for Edit and Delete"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(284, 39)
        Me.txtQty.Margin = New System.Windows.Forms.Padding(2)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(76, 23)
        Me.txtQty.TabIndex = 3
        '
        'txtYear
        '
        Me.txtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYear.Location = New System.Drawing.Point(104, 39)
        Me.txtYear.Margin = New System.Windows.Forms.Padding(2)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(76, 23)
        Me.txtYear.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label2.Location = New System.Drawing.Point(245, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Qty:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label1.Location = New System.Drawing.Point(46, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Year:"
        '
        'txtAccumulateID
        '
        Me.txtAccumulateID.Location = New System.Drawing.Point(225, 11)
        Me.txtAccumulateID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtAccumulateID.Name = "txtAccumulateID"
        Me.txtAccumulateID.Size = New System.Drawing.Size(76, 20)
        Me.txtAccumulateID.TabIndex = 21
        Me.txtAccumulateID.Visible = False
        '
        'frmSetAccumulateAnnaulLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 425)
        Me.Controls.Add(Me.txtAccumulateID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbAdd)
        Me.Controls.Add(Me.cmbDeleteSelected)
        Me.Controls.Add(Me.cbmEdit)
        Me.Controls.Add(Me.GridviewAccumulateAL)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetAccumulateAnnaulLeave"
        CType(Me.GridviewAccumulateAL, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GridviewAccumulateAL As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DepartmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtYear As TextBox
    Friend WithEvents txtQty As TextBox
    Friend WithEvents txtAccumulateID As TextBox
End Class
