<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintMaster2
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintMaster2))
        Me.reportDocument1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Me.gMaster = New Stone.WinUI.AsGrouper
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.กำหนดขนาดกระดาษToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblVatType = New System.Windows.Forms.Label
        Me.cmdSale = New Stone.WinUI.AsButton
        Me.cmdPrint = New Stone.WinUI.AsButton
        Me.cmdClose = New Stone.WinUI.AsButton
        Me.rdoPrintSale0 = New Stone.WinUI.AsRadioButton
        Me.cboFileName = New System.Windows.Forms.ComboBox
        Me.lblChangeReport = New System.Windows.Forms.LinkLabel
        Me.cboPrinter = New System.Windows.Forms.ComboBox
        Me.cboPaper = New System.Windows.Forms.ComboBox
        Me.rdoPrintSale1 = New Stone.WinUI.AsRadioButton
        Me.cboFileNameDp = New System.Windows.Forms.ComboBox
        Me.gbReport = New Stone.WinUI.AsGrouper
        Me.cmdOpenFile = New Stone.WinUI.AsButton
        Me.txtFileName = New Stone.WinUI.AsTextBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.gMaster.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.gbReport.SuspendLayout()
        Me.SuspendLayout()
        '
        'gMaster
        '
        Me.gMaster.AccessibleDescription = Nothing
        Me.gMaster.AccessibleName = Nothing
        resources.ApplyResources(Me.gMaster, "gMaster")
        Me.gMaster.BackgroundImage = Nothing
        Me.gMaster.BaseColor = System.Drawing.Color.Black
        Me.gMaster.ContextMenuStrip = Me.ContextMenuStrip1
        Me.gMaster.Controls.Add(Me.Label2)
        Me.gMaster.Controls.Add(Me.Label1)
        Me.gMaster.Controls.Add(Me.lblVatType)
        Me.gMaster.Controls.Add(Me.cmdSale)
        Me.gMaster.Controls.Add(Me.cmdPrint)
        Me.gMaster.Controls.Add(Me.cmdClose)
        Me.gMaster.Controls.Add(Me.rdoPrintSale0)
        Me.gMaster.Controls.Add(Me.cboFileName)
        Me.gMaster.Controls.Add(Me.lblChangeReport)
        Me.gMaster.Controls.Add(Me.cboPrinter)
        Me.gMaster.Controls.Add(Me.cboPaper)
        Me.gMaster.Controls.Add(Me.rdoPrintSale1)
        Me.gMaster.Controls.Add(Me.cboFileNameDp)
        Me.gMaster.Controls.Add(Me.gbReport)
        Me.gMaster.Font = Nothing
        Me.gMaster.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.gMaster.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.gMaster.HeaderHeight = 30
        Me.gMaster.Name = "gMaster"
        Me.gMaster.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.gMaster.ShowExpand = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.AccessibleDescription = Nothing
        Me.ContextMenuStrip1.AccessibleName = Nothing
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.BackgroundImage = Nothing
        Me.ContextMenuStrip1.Font = Nothing
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.กำหนดขนาดกระดาษToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'กำหนดขนาดกระดาษToolStripMenuItem
        '
        Me.กำหนดขนาดกระดาษToolStripMenuItem.AccessibleDescription = Nothing
        Me.กำหนดขนาดกระดาษToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.กำหนดขนาดกระดาษToolStripMenuItem, "กำหนดขนาดกระดาษToolStripMenuItem")
        Me.กำหนดขนาดกระดาษToolStripMenuItem.BackgroundImage = Nothing
        Me.กำหนดขนาดกระดาษToolStripMenuItem.Name = "กำหนดขนาดกระดาษToolStripMenuItem"
        Me.กำหนดขนาดกระดาษToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Name = "Label1"
        '
        'lblVatType
        '
        Me.lblVatType.AccessibleDescription = Nothing
        Me.lblVatType.AccessibleName = Nothing
        resources.ApplyResources(Me.lblVatType, "lblVatType")
        Me.lblVatType.BackColor = System.Drawing.Color.Transparent
        Me.lblVatType.ForeColor = System.Drawing.Color.Black
        Me.lblVatType.Name = "lblVatType"
        '
        'cmdSale
        '
        Me.cmdSale.AccessibleDescription = Nothing
        Me.cmdSale.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdSale, "cmdSale")
        Me.cmdSale.BackgroundImage = Nothing
        Me.cmdSale.ImageTransparentColor = System.Drawing.Color.Indigo
        Me.cmdSale.Name = "cmdSale"
        Me.cmdSale.RendererType = Stone.WinUI.RendererTypes.Office2007
        '
        'cmdPrint
        '
        Me.cmdPrint.AccessibleDescription = Nothing
        Me.cmdPrint.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdPrint, "cmdPrint")
        Me.cmdPrint.BackgroundImage = Nothing
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.cmdPrint.UseVisualStyleBackColor = True
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
        'rdoPrintSale0
        '
        Me.rdoPrintSale0.AccessibleDescription = Nothing
        Me.rdoPrintSale0.AccessibleName = Nothing
        resources.ApplyResources(Me.rdoPrintSale0, "rdoPrintSale0")
        Me.rdoPrintSale0.BackgroundImage = Nothing
        Me.rdoPrintSale0.Checked = True
        Me.rdoPrintSale0.Image = Nothing
        Me.rdoPrintSale0.Name = "rdoPrintSale0"
        Me.rdoPrintSale0.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.rdoPrintSale0.TabStop = True
        Me.rdoPrintSale0.UseVisualStyleBackColor = True
        '
        'cboFileName
        '
        Me.cboFileName.AccessibleDescription = Nothing
        Me.cboFileName.AccessibleName = Nothing
        resources.ApplyResources(Me.cboFileName, "cboFileName")
        Me.cboFileName.BackgroundImage = Nothing
        Me.cboFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Name = "cboFileName"
        '
        'lblChangeReport
        '
        Me.lblChangeReport.AccessibleDescription = Nothing
        Me.lblChangeReport.AccessibleName = Nothing
        resources.ApplyResources(Me.lblChangeReport, "lblChangeReport")
        Me.lblChangeReport.BackColor = System.Drawing.Color.Transparent
        Me.lblChangeReport.Name = "lblChangeReport"
        Me.lblChangeReport.TabStop = True
        '
        'cboPrinter
        '
        Me.cboPrinter.AccessibleDescription = Nothing
        Me.cboPrinter.AccessibleName = Nothing
        resources.ApplyResources(Me.cboPrinter, "cboPrinter")
        Me.cboPrinter.BackgroundImage = Nothing
        Me.cboPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinter.FormattingEnabled = True
        Me.cboPrinter.Name = "cboPrinter"
        '
        'cboPaper
        '
        Me.cboPaper.AccessibleDescription = Nothing
        Me.cboPaper.AccessibleName = Nothing
        resources.ApplyResources(Me.cboPaper, "cboPaper")
        Me.cboPaper.BackgroundImage = Nothing
        Me.cboPaper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaper.FormattingEnabled = True
        Me.cboPaper.Items.AddRange(New Object() {resources.GetString("cboPaper.Items"), resources.GetString("cboPaper.Items1"), resources.GetString("cboPaper.Items2")})
        Me.cboPaper.Name = "cboPaper"
        '
        'rdoPrintSale1
        '
        Me.rdoPrintSale1.AccessibleDescription = Nothing
        Me.rdoPrintSale1.AccessibleName = Nothing
        resources.ApplyResources(Me.rdoPrintSale1, "rdoPrintSale1")
        Me.rdoPrintSale1.BackgroundImage = Nothing
        Me.rdoPrintSale1.Image = Nothing
        Me.rdoPrintSale1.Name = "rdoPrintSale1"
        Me.rdoPrintSale1.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.rdoPrintSale1.UseVisualStyleBackColor = True
        '
        'cboFileNameDp
        '
        Me.cboFileNameDp.AccessibleDescription = Nothing
        Me.cboFileNameDp.AccessibleName = Nothing
        resources.ApplyResources(Me.cboFileNameDp, "cboFileNameDp")
        Me.cboFileNameDp.BackgroundImage = Nothing
        Me.cboFileNameDp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFileNameDp.Font = Nothing
        Me.cboFileNameDp.FormattingEnabled = True
        Me.cboFileNameDp.Name = "cboFileNameDp"
        '
        'gbReport
        '
        Me.gbReport.AccessibleDescription = Nothing
        Me.gbReport.AccessibleName = Nothing
        resources.ApplyResources(Me.gbReport, "gbReport")
        Me.gbReport.BackgroundImage = Nothing
        Me.gbReport.BaseColor = System.Drawing.Color.Green
        Me.gbReport.Controls.Add(Me.cmdOpenFile)
        Me.gbReport.Controls.Add(Me.txtFileName)
        Me.gbReport.Font = Nothing
        Me.gbReport.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.gbReport.HeaderHeight = 18
        Me.gbReport.Name = "gbReport"
        Me.gbReport.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.gbReport.ShowExpand = False
        '
        'cmdOpenFile
        '
        Me.cmdOpenFile.AccessibleDescription = Nothing
        Me.cmdOpenFile.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdOpenFile, "cmdOpenFile")
        Me.cmdOpenFile.BackgroundImage = Nothing
        Me.cmdOpenFile.Font = Nothing
        Me.cmdOpenFile.ImageTransparentColor = System.Drawing.Color.Indigo
        Me.cmdOpenFile.Name = "cmdOpenFile"
        Me.cmdOpenFile.RendererType = Stone.WinUI.RendererTypes.Office2007
        '
        'txtFileName
        '
        Me.txtFileName.AccessibleDescription = Nothing
        Me.txtFileName.AccessibleName = Nothing
        resources.ApplyResources(Me.txtFileName, "txtFileName")
        Me.txtFileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.RendererType = Stone.WinUI.RendererTypes.Office2007
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
        'frmPrintMaster2
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.gMaster)
        Me.Icon = Nothing
        Me.Name = "frmPrintMaster2"
        Me.ShowInTaskbar = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gMaster.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.gbReport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents reportDocument1 As CrystalDecisions.CrystalReports.Engine.ReportDocument
    Friend WithEvents cmdClose As Stone.WinUI.AsButton
    Friend WithEvents cmdPrint As Stone.WinUI.AsButton
    Friend WithEvents gMaster As Stone.WinUI.AsGrouper
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdOpenFile As Stone.WinUI.AsButton
    Friend WithEvents txtFileName As Stone.WinUI.AsTextBox
    Friend WithEvents cboPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents gbReport As Stone.WinUI.AsGrouper
    Friend WithEvents lblChangeReport As System.Windows.Forms.LinkLabel
    Friend WithEvents lblVatType As System.Windows.Forms.Label
    Friend WithEvents rdoPrintSale0 As Stone.WinUI.AsRadioButton
    Friend WithEvents rdoPrintSale1 As Stone.WinUI.AsRadioButton
    Friend WithEvents cboPaper As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSale As Stone.WinUI.AsButton
    Friend WithEvents กำหนดขนาดกระดาษToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboFileName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFileNameDp As System.Windows.Forms.ComboBox
End Class
