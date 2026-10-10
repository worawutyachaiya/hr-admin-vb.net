<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSummary))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DateFinish = New System.Windows.Forms.DateTimePicker()
        Me.DateStart = New System.Windows.Forms.DateTimePicker()
        Me.RadioExportAll = New System.Windows.Forms.RadioButton()
        Me.RadioEmpIdFrom = New System.Windows.Forms.RadioButton()
        Me.lbStatusExport = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtToEmpID = New System.Windows.Forms.TextBox()
        Me.txtFromEmpID = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ExportRemainLeaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateFinish)
        Me.GroupBox1.Controls.Add(Me.DateStart)
        Me.GroupBox1.Controls.Add(Me.RadioExportAll)
        Me.GroupBox1.Controls.Add(Me.RadioEmpIdFrom)
        Me.GroupBox1.Controls.Add(Me.lbStatusExport)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnExport)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtToEmpID)
        Me.GroupBox1.Controls.Add(Me.txtFromEmpID)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 150)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'DateFinish
        '
        Me.DateFinish.Location = New System.Drawing.Point(274, 68)
        Me.DateFinish.Name = "DateFinish"
        Me.DateFinish.Size = New System.Drawing.Size(134, 23)
        Me.DateFinish.TabIndex = 8
        '
        'DateStart
        '
        Me.DateStart.Location = New System.Drawing.Point(122, 68)
        Me.DateStart.Name = "DateStart"
        Me.DateStart.Size = New System.Drawing.Size(134, 23)
        Me.DateStart.TabIndex = 8
        '
        'RadioExportAll
        '
        Me.RadioExportAll.AutoSize = True
        Me.RadioExportAll.Location = New System.Drawing.Point(16, 16)
        Me.RadioExportAll.Name = "RadioExportAll"
        Me.RadioExportAll.Size = New System.Drawing.Size(88, 20)
        Me.RadioExportAll.TabIndex = 7
        Me.RadioExportAll.TabStop = True
        Me.RadioExportAll.Text = "Export All"
        Me.RadioExportAll.UseVisualStyleBackColor = True
        '
        'RadioEmpIdFrom
        '
        Me.RadioEmpIdFrom.AutoSize = True
        Me.RadioEmpIdFrom.Location = New System.Drawing.Point(16, 42)
        Me.RadioEmpIdFrom.Name = "RadioEmpIdFrom"
        Me.RadioEmpIdFrom.Size = New System.Drawing.Size(100, 20)
        Me.RadioEmpIdFrom.TabIndex = 6
        Me.RadioEmpIdFrom.TabStop = True
        Me.RadioEmpIdFrom.Text = "EmpId From"
        Me.RadioEmpIdFrom.UseVisualStyleBackColor = True
        '
        'lbStatusExport
        '
        Me.lbStatusExport.AutoSize = True
        Me.lbStatusExport.Location = New System.Drawing.Point(203, 101)
        Me.lbStatusExport.Name = "lbStatusExport"
        Me.lbStatusExport.Size = New System.Drawing.Size(65, 16)
        Me.lbStatusExport.TabIndex = 3
        Me.lbStatusExport.Text = "STATUS :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date From"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(122, 101)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 43)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(259, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(259, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "-"
        '
        'txtToEmpID
        '
        Me.txtToEmpID.Enabled = False
        Me.txtToEmpID.Location = New System.Drawing.Point(274, 39)
        Me.txtToEmpID.Name = "txtToEmpID"
        Me.txtToEmpID.Size = New System.Drawing.Size(134, 23)
        Me.txtToEmpID.TabIndex = 1
        '
        'txtFromEmpID
        '
        Me.txtFromEmpID.Enabled = False
        Me.txtFromEmpID.Location = New System.Drawing.Point(122, 39)
        Me.txtFromEmpID.Name = "txtFromEmpID"
        Me.txtFromEmpID.Size = New System.Drawing.Size(134, 23)
        Me.txtFromEmpID.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportRemainLeaveToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(597, 25)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExportRemainLeaveToolStripMenuItem
        '
        Me.ExportRemainLeaveToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportRemainLeaveToolStripMenuItem.Image = CType(resources.GetObject("ExportRemainLeaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExportRemainLeaveToolStripMenuItem.Name = "ExportRemainLeaveToolStripMenuItem"
        Me.ExportRemainLeaveToolStripMenuItem.Size = New System.Drawing.Size(134, 21)
        Me.ExportRemainLeaveToolStripMenuItem.Text = "Summary Leave"
        '
        'frmSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 198)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioExportAll As System.Windows.Forms.RadioButton
    Friend WithEvents RadioEmpIdFrom As System.Windows.Forms.RadioButton
    Friend WithEvents lbStatusExport As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtToEmpID As System.Windows.Forms.TextBox
    Friend WithEvents txtFromEmpID As System.Windows.Forms.TextBox
    Friend WithEvents DateFinish As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExportRemainLeaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
