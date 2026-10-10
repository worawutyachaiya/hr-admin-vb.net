<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlow))
        Me.GridFlow = New System.Windows.Forms.DataGridView()
        Me.cmbAdd = New System.Windows.Forms.Button()
        Me.cmbDeleteSelected = New System.Windows.Forms.Button()
        Me.cbmEdit = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HolidysSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtApprove3 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtApprove2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtApprove1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtChecker2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtChecker1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNameFlow = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFlowID = New System.Windows.Forms.TextBox()
        CType(Me.GridFlow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridFlow
        '
        Me.GridFlow.AllowUserToAddRows = False
        Me.GridFlow.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GridFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridFlow.Location = New System.Drawing.Point(31, 190)
        Me.GridFlow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridFlow.Name = "GridFlow"
        Me.GridFlow.RowHeadersWidth = 51
        Me.GridFlow.Size = New System.Drawing.Size(1241, 625)
        Me.GridFlow.TabIndex = 0
        '
        'cmbAdd
        '
        Me.cmbAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbAdd.Location = New System.Drawing.Point(1317, 300)
        Me.cmbAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbAdd.Name = "cmbAdd"
        Me.cmbAdd.Size = New System.Drawing.Size(129, 48)
        Me.cmbAdd.TabIndex = 7
        Me.cmbAdd.Text = "Save Add"
        Me.cmbAdd.UseVisualStyleBackColor = True
        '
        'cmbDeleteSelected
        '
        Me.cmbDeleteSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbDeleteSelected.Location = New System.Drawing.Point(1317, 501)
        Me.cmbDeleteSelected.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbDeleteSelected.Name = "cmbDeleteSelected"
        Me.cmbDeleteSelected.Size = New System.Drawing.Size(129, 49)
        Me.cmbDeleteSelected.TabIndex = 6
        Me.cmbDeleteSelected.Text = "Delete"
        Me.cmbDeleteSelected.UseVisualStyleBackColor = True
        '
        'cbmEdit
        '
        Me.cbmEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cbmEdit.Location = New System.Drawing.Point(1317, 398)
        Me.cbmEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbmEdit.Name = "cbmEdit"
        Me.cbmEdit.Size = New System.Drawing.Size(129, 48)
        Me.cbmEdit.TabIndex = 5
        Me.cbmEdit.Text = "Save Edit"
        Me.cbmEdit.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HolidysSetupToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1481, 36)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HolidysSetupToolStripMenuItem
        '
        Me.HolidysSetupToolStripMenuItem.Image = CType(resources.GetObject("HolidysSetupToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HolidysSetupToolStripMenuItem.Name = "HolidysSetupToolStripMenuItem"
        Me.HolidysSetupToolStripMenuItem.Size = New System.Drawing.Size(150, 32)
        Me.HolidysSetupToolStripMenuItem.Text = "Flow Leave"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtApprove3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtApprove2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtApprove1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtChecker2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtChecker1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNameFlow)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(51, 48)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(1381, 130)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input data for Add and Selected data for Edit and Delete"
        '
        'txtApprove3
        '
        Me.txtApprove3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprove3.Location = New System.Drawing.Point(1083, 84)
        Me.txtApprove3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtApprove3.Name = "txtApprove3"
        Me.txtApprove3.Size = New System.Drawing.Size(159, 27)
        Me.txtApprove3.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label6.Location = New System.Drawing.Point(949, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Approve3:"
        '
        'txtApprove2
        '
        Me.txtApprove2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprove2.Location = New System.Drawing.Point(637, 87)
        Me.txtApprove2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtApprove2.Name = "txtApprove2"
        Me.txtApprove2.Size = New System.Drawing.Size(159, 27)
        Me.txtApprove2.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label5.Location = New System.Drawing.Point(509, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Approve2:"
        '
        'txtApprove1
        '
        Me.txtApprove1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprove1.Location = New System.Drawing.Point(231, 87)
        Me.txtApprove1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtApprove1.Name = "txtApprove1"
        Me.txtApprove1.Size = New System.Drawing.Size(159, 27)
        Me.txtApprove1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label4.Location = New System.Drawing.Point(95, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Approve1:"
        '
        'txtChecker2
        '
        Me.txtChecker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChecker2.Location = New System.Drawing.Point(1140, 38)
        Me.txtChecker2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtChecker2.Name = "txtChecker2"
        Me.txtChecker2.Size = New System.Drawing.Size(159, 27)
        Me.txtChecker2.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label3.Location = New System.Drawing.Point(1015, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Checker2:"
        '
        'txtChecker1
        '
        Me.txtChecker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChecker1.Location = New System.Drawing.Point(793, 38)
        Me.txtChecker1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtChecker1.Name = "txtChecker1"
        Me.txtChecker1.Size = New System.Drawing.Size(159, 27)
        Me.txtChecker1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label2.Location = New System.Drawing.Point(657, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Checker1:"
        '
        'txtNameFlow
        '
        Me.txtNameFlow.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameFlow.Location = New System.Drawing.Point(161, 38)
        Me.txtNameFlow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNameFlow.Name = "txtNameFlow"
        Me.txtNameFlow.Size = New System.Drawing.Size(453, 27)
        Me.txtNameFlow.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label1.Location = New System.Drawing.Point(29, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name Flow:"
        '
        'txtFlowID
        '
        Me.txtFlowID.Location = New System.Drawing.Point(381, 20)
        Me.txtFlowID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFlowID.Name = "txtFlowID"
        Me.txtFlowID.Size = New System.Drawing.Size(100, 22)
        Me.txtFlowID.TabIndex = 10
        Me.txtFlowID.Visible = False
        '
        'frmFlow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1481, 878)
        Me.Controls.Add(Me.txtFlowID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cmbAdd)
        Me.Controls.Add(Me.cmbDeleteSelected)
        Me.Controls.Add(Me.cbmEdit)
        Me.Controls.Add(Me.GridFlow)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmFlow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.GridFlow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridFlow As System.Windows.Forms.DataGridView
    Friend WithEvents cmbAdd As System.Windows.Forms.Button
    Friend WithEvents cmbDeleteSelected As System.Windows.Forms.Button
    Friend WithEvents cbmEdit As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HolidysSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNameFlow As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtChecker1 As TextBox
    Friend WithEvents txtChecker2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtApprove1 As TextBox
    Friend WithEvents txtApprove2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtApprove3 As TextBox
    Friend WithEvents txtFlowID As TextBox
End Class
