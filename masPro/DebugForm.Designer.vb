<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DebugForm
    Inherits frmBase

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
        Me.reportDocument1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
        Me.AsPanel1 = New Stone.WinUI.AsPanel()
        Me.cmdOpenForm = New System.Windows.Forms.Button()
        Me.TabMenuForm = New Stone.WinUI.AsTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.AsPanel1.ContentPanel.SuspendLayout()
        Me.AsPanel1.SuspendLayout()
        Me.TabMenuForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'AsPanel1
        '
        '
        'AsPanel1.ContentPanel
        '
        Me.AsPanel1.ContentPanel.Controls.Add(Me.cmdOpenForm)
        Me.AsPanel1.ContentPanel.Location = New System.Drawing.Point(1, 1)
        Me.AsPanel1.ContentPanel.Name = "ContentPanel"
        Me.AsPanel1.ContentPanel.Size = New System.Drawing.Size(925, 64)
        Me.AsPanel1.ContentPanel.TabIndex = 3
        Me.AsPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AsPanel1.Location = New System.Drawing.Point(0, 0)
        Me.AsPanel1.Name = "AsPanel1"
        Me.AsPanel1.Size = New System.Drawing.Size(927, 66)
        Me.AsPanel1.TabIndex = 0
        Me.AsPanel1.Text = "AsPanel1"
        '
        'cmdOpenForm
        '
        Me.cmdOpenForm.Location = New System.Drawing.Point(77, 11)
        Me.cmdOpenForm.Name = "cmdOpenForm"
        Me.cmdOpenForm.Size = New System.Drawing.Size(104, 32)
        Me.cmdOpenForm.TabIndex = 4
        Me.cmdOpenForm.Text = "Open Form"
        Me.cmdOpenForm.UseVisualStyleBackColor = True
        '
        'TabMenuForm
        '
        Me.TabMenuForm.BehindRender = Stone.WinUI.RendererTypes.Office2007
        Me.TabMenuForm.Controls.Add(Me.TabPage1)
        Me.TabMenuForm.Controls.Add(Me.TabPage2)
        Me.TabMenuForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMenuForm.Location = New System.Drawing.Point(0, 66)
        Me.TabMenuForm.Name = "TabMenuForm"
        Me.TabMenuForm.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.TabMenuForm.SelectedIndex = 0
        Me.TabMenuForm.Size = New System.Drawing.Size(927, 386)
        Me.TabMenuForm.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(919, 360)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(919, 360)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 452)
        Me.Controls.Add(Me.TabMenuForm)
        Me.Controls.Add(Me.AsPanel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.AsPanel1.ContentPanel.ResumeLayout(False)
        Me.AsPanel1.ResumeLayout(False)
        Me.TabMenuForm.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents reportDocument1 As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Friend WithEvents AsPanel1 As Stone.WinUI.AsPanel
    Friend WithEvents cmdOpenForm As Button
    Friend WithEvents TabMenuForm As Stone.WinUI.AsTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
End Class
