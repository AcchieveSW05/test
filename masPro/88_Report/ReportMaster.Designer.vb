<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportMaster
    Inherits frmBase 'System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportMaster))
        Me.reportDocument1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Me.gHeader = New Stone.WinUI.AsGrouper
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdPreview = New Stone.WinUI.AsButton
        Me.cmdClose = New Stone.WinUI.AsButton
        Me.txtFilterNameTo = New Stone.WinUI.AsTextBox
        Me.txtFilterNameFrom = New Stone.WinUI.AsTextBox
        Me.cmdFilterTo = New System.Windows.Forms.Button
        Me.cmdFilterFrom = New System.Windows.Forms.Button
        Me.txtFilterCodeTo = New Stone.WinUI.AsTextBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.lblFrom = New System.Windows.Forms.Label
        Me.txtFilterCodeFrom = New Stone.WinUI.AsTextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.gHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gHeader
        '
        Me.gHeader.AccessibleDescription = Nothing
        Me.gHeader.AccessibleName = Nothing
        resources.ApplyResources(Me.gHeader, "gHeader")
        Me.gHeader.BackgroundImage = Nothing
        Me.gHeader.BaseColor = System.Drawing.Color.Black
        Me.gHeader.Controls.Add(Me.Panel1)
        Me.gHeader.Controls.Add(Me.txtFilterNameTo)
        Me.gHeader.Controls.Add(Me.txtFilterNameFrom)
        Me.gHeader.Controls.Add(Me.cmdFilterTo)
        Me.gHeader.Controls.Add(Me.cmdFilterFrom)
        Me.gHeader.Controls.Add(Me.txtFilterCodeTo)
        Me.gHeader.Controls.Add(Me.lblTo)
        Me.gHeader.Controls.Add(Me.lblFrom)
        Me.gHeader.Controls.Add(Me.txtFilterCodeFrom)
        Me.gHeader.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gHeader.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.gHeader.HeaderHeight = 30
        Me.gHeader.Name = "gHeader"
        Me.gHeader.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.gHeader.ShowExpand = False
        '
        'Panel1
        '
        Me.Panel1.AccessibleDescription = Nothing
        Me.Panel1.AccessibleName = Nothing
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackgroundImage = Nothing
        Me.Panel1.Controls.Add(Me.cmdPreview)
        Me.Panel1.Controls.Add(Me.cmdClose)
        Me.Panel1.Font = Nothing
        Me.Panel1.Name = "Panel1"
        '
        'cmdPreview
        '
        Me.cmdPreview.AccessibleDescription = Nothing
        Me.cmdPreview.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdPreview, "cmdPreview")
        Me.cmdPreview.BackgroundImage = Nothing
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.cmdPreview.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.AccessibleDescription = Nothing
        Me.cmdClose.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.BackgroundImage = Nothing
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'txtFilterNameTo
        '
        Me.txtFilterNameTo.AccessibleDescription = Nothing
        Me.txtFilterNameTo.AccessibleName = Nothing
        resources.ApplyResources(Me.txtFilterNameTo, "txtFilterNameTo")
        Me.txtFilterNameTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFilterNameTo.Name = "txtFilterNameTo"
        Me.txtFilterNameTo.ReadOnly = True
        Me.txtFilterNameTo.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtFilterNameTo.Required = True
        Me.txtFilterNameTo.RequiredFieldColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFilterNameTo.TabStop = False
        '
        'txtFilterNameFrom
        '
        Me.txtFilterNameFrom.AccessibleDescription = Nothing
        Me.txtFilterNameFrom.AccessibleName = Nothing
        resources.ApplyResources(Me.txtFilterNameFrom, "txtFilterNameFrom")
        Me.txtFilterNameFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFilterNameFrom.Name = "txtFilterNameFrom"
        Me.txtFilterNameFrom.ReadOnly = True
        Me.txtFilterNameFrom.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtFilterNameFrom.Required = True
        Me.txtFilterNameFrom.RequiredFieldColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtFilterNameFrom.TabStop = False
        '
        'cmdFilterTo
        '
        Me.cmdFilterTo.AccessibleDescription = Nothing
        Me.cmdFilterTo.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdFilterTo, "cmdFilterTo")
        Me.cmdFilterTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdFilterTo.BackgroundImage = Nothing
        Me.cmdFilterTo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.cmdFilterTo.Name = "cmdFilterTo"
        Me.cmdFilterTo.TabStop = False
        Me.cmdFilterTo.UseVisualStyleBackColor = False
        '
        'cmdFilterFrom
        '
        Me.cmdFilterFrom.AccessibleDescription = Nothing
        Me.cmdFilterFrom.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdFilterFrom, "cmdFilterFrom")
        Me.cmdFilterFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdFilterFrom.BackgroundImage = Nothing
        Me.cmdFilterFrom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.cmdFilterFrom.Name = "cmdFilterFrom"
        Me.cmdFilterFrom.TabStop = False
        Me.cmdFilterFrom.UseVisualStyleBackColor = False
        '
        'txtFilterCodeTo
        '
        Me.txtFilterCodeTo.AccessibleDescription = Nothing
        Me.txtFilterCodeTo.AccessibleName = Nothing
        resources.ApplyResources(Me.txtFilterCodeTo, "txtFilterCodeTo")
        Me.txtFilterCodeTo.BackColor = System.Drawing.Color.MistyRose
        Me.txtFilterCodeTo.Name = "txtFilterCodeTo"
        Me.txtFilterCodeTo.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtFilterCodeTo.Required = True
        '
        'lblTo
        '
        Me.lblTo.AccessibleDescription = Nothing
        Me.lblTo.AccessibleName = Nothing
        resources.ApplyResources(Me.lblTo, "lblTo")
        Me.lblTo.BackColor = System.Drawing.Color.Transparent
        Me.lblTo.ForeColor = System.Drawing.Color.Black
        Me.lblTo.Name = "lblTo"
        '
        'lblFrom
        '
        Me.lblFrom.AccessibleDescription = Nothing
        Me.lblFrom.AccessibleName = Nothing
        resources.ApplyResources(Me.lblFrom, "lblFrom")
        Me.lblFrom.BackColor = System.Drawing.Color.Transparent
        Me.lblFrom.ForeColor = System.Drawing.Color.Black
        Me.lblFrom.Name = "lblFrom"
        '
        'txtFilterCodeFrom
        '
        Me.txtFilterCodeFrom.AccessibleDescription = Nothing
        Me.txtFilterCodeFrom.AccessibleName = Nothing
        resources.ApplyResources(Me.txtFilterCodeFrom, "txtFilterCodeFrom")
        Me.txtFilterCodeFrom.BackColor = System.Drawing.Color.MistyRose
        Me.txtFilterCodeFrom.Name = "txtFilterCodeFrom"
        Me.txtFilterCodeFrom.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtFilterCodeFrom.Required = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.AccessibleDescription = Nothing
        Me.CrystalReportViewer1.AccessibleName = Nothing
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        resources.ApplyResources(Me.CrystalReportViewer1, "CrystalReportViewer1")
        Me.CrystalReportViewer1.BackgroundImage = Nothing
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Font = Nothing
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'ReportMaster
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.gHeader)
        Me.Font = Nothing
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Nothing
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportMaster"
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents reportDocument1 As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Friend WithEvents gHeader As Stone.WinUI.AsGrouper
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdPreview As Stone.WinUI.AsButton
    Friend WithEvents cmdClose As Stone.WinUI.AsButton
    Friend WithEvents txtFilterNameTo As Stone.WinUI.AsTextBox
    Friend WithEvents txtFilterNameFrom As Stone.WinUI.AsTextBox
    Friend WithEvents cmdFilterTo As System.Windows.Forms.Button
    Friend WithEvents cmdFilterFrom As System.Windows.Forms.Button
    Friend WithEvents txtFilterCodeTo As Stone.WinUI.AsTextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents txtFilterCodeFrom As Stone.WinUI.AsTextBox
End Class
