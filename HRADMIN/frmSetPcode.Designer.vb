<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetPcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetPcode))
        Me.cmbAdd = New System.Windows.Forms.Button()
        Me.cmbDeleteSelected = New System.Windows.Forms.Button()
        Me.cbmEdit = New System.Windows.Forms.Button()
        Me.GridviewPCode = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPCodeID = New System.Windows.Forms.TextBox()
        CType(Me.GridviewPCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbAdd
        '
        Me.cmbAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbAdd.Location = New System.Drawing.Point(361, 201)
        Me.cmbAdd.Name = "cmbAdd"
        Me.cmbAdd.Size = New System.Drawing.Size(97, 39)
        Me.cmbAdd.TabIndex = 14
        Me.cmbAdd.Text = "Save Add"
        Me.cmbAdd.UseVisualStyleBackColor = True
        '
        'cmbDeleteSelected
        '
        Me.cmbDeleteSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbDeleteSelected.Location = New System.Drawing.Point(361, 333)
        Me.cmbDeleteSelected.Name = "cmbDeleteSelected"
        Me.cmbDeleteSelected.Size = New System.Drawing.Size(97, 37)
        Me.cmbDeleteSelected.TabIndex = 12
        Me.cmbDeleteSelected.Text = "Delete"
        Me.cmbDeleteSelected.UseVisualStyleBackColor = True
        '
        'cbmEdit
        '
        Me.cbmEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbmEdit.Location = New System.Drawing.Point(361, 266)
        Me.cbmEdit.Name = "cbmEdit"
        Me.cbmEdit.Size = New System.Drawing.Size(97, 39)
        Me.cbmEdit.TabIndex = 11
        Me.cbmEdit.Text = "Save Edit"
        Me.cbmEdit.UseVisualStyleBackColor = True
        '
        'GridviewPCode
        '
        Me.GridviewPCode.AllowUserToAddRows = False
        Me.GridviewPCode.AllowUserToDeleteRows = False
        Me.GridviewPCode.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.GridviewPCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridviewPCode.Location = New System.Drawing.Point(22, 114)
        Me.GridviewPCode.Name = "GridviewPCode"
        Me.GridviewPCode.RowHeadersWidth = 51
        Me.GridviewPCode.Size = New System.Drawing.Size(312, 409)
        Me.GridviewPCode.TabIndex = 10
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepartmentToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(500, 29)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DepartmentToolStripMenuItem
        '
        Me.DepartmentToolStripMenuItem.Image = CType(resources.GetObject("DepartmentToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DepartmentToolStripMenuItem.Name = "DepartmentToolStripMenuItem"
        Me.DepartmentToolStripMenuItem.Size = New System.Drawing.Size(91, 25)
        Me.DepartmentToolStripMenuItem.Text = "PCode"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(22, 40)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(454, 64)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input data for Add and Selected data for Edit and Delete"
        '
        'txtPCode
        '
        Me.txtPCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPCode.Location = New System.Drawing.Point(172, 30)
        Me.txtPCode.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPCode.Name = "txtPCode"
        Me.txtPCode.Size = New System.Drawing.Size(125, 23)
        Me.txtPCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label1.Location = New System.Drawing.Point(102, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PCode:"
        '
        'txtPCodeID
        '
        Me.txtPCodeID.Location = New System.Drawing.Point(145, 11)
        Me.txtPCodeID.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPCodeID.Name = "txtPCodeID"
        Me.txtPCodeID.Size = New System.Drawing.Size(76, 20)
        Me.txtPCodeID.TabIndex = 16
        Me.txtPCodeID.Visible = False
        '
        'frmSetPcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 554)
        Me.Controls.Add(Me.txtPCodeID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbAdd)
        Me.Controls.Add(Me.cmbDeleteSelected)
        Me.Controls.Add(Me.cbmEdit)
        Me.Controls.Add(Me.GridviewPCode)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmSetPcode"
        CType(Me.GridviewPCode, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GridviewPCode As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DepartmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPCode As TextBox
    Friend WithEvents txtPCodeID As TextBox
End Class
