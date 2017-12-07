<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class masProject
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridMain = New Stone.WinUI.AsGridView()
        Me.iCode = New Stone.WinUI.AsGridViewColumn()
        Me.iName = New Stone.WinUI.AsGridViewColumn()
        Me.SearchKey = New Stone.WinUI.AsGridViewColumn()
        Me.Status = New Stone.WinUI.AsGridViewColumn()
        Me.groupFilter = New Stone.WinUI.AsGrouper()
        Me.rdoSelectTop = New Stone.WinUI.AsRadioButton()
        Me.rdoSelectAll = New Stone.WinUI.AsRadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.linkFilter = New System.Windows.Forms.LinkLabel()
        Me.chkCancel = New Stone.WinUI.AsCheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearch = New Stone.WinUI.AsTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdAddNew = New System.Windows.Forms.ToolStripButton()
        Me.cmdEdit = New System.Windows.Forms.ToolStripButton()
        Me.cmdSave = New System.Windows.Forms.ToolStripButton()
        Me.cmdDelete = New System.Windows.Forms.ToolStripButton()
        Me.cmdPrint = New System.Windows.Forms.ToolStripButton()
        Me.cmdUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdClose = New System.Windows.Forms.ToolStripButton()
        Me.HeadGroup = New Stone.WinUI.AsGrouper()
        Me.txtRemark1 = New Stone.WinUI.AsTextBox()
        Me.txtRemark2 = New Stone.WinUI.AsTextBox()
        Me.lblRemark2 = New System.Windows.Forms.Label()
        Me.lblRemark1 = New System.Windows.Forms.Label()
        Me.txtCode = New Stone.WinUI.AsTextBox()
        Me.txtSearchKey = New Stone.WinUI.AsTextBox()
        Me.l_KeyWord = New System.Windows.Forms.Label()
        Me.txtName = New Stone.WinUI.AsTextBox()
        Me.l_Code = New System.Windows.Forms.Label()
        Me.l_Name = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCancel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.groupFilter.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.HeadGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gridMain)
        Me.Panel1.Controls.Add(Me.groupFilter)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 616)
        Me.Panel1.TabIndex = 3
        '
        'gridMain
        '
        Me.gridMain.Columns.AddRange(New Stone.WinUI.AsGridViewColumn() {Me.iCode, Me.iName, Me.SearchKey, Me.Status})
        Me.gridMain.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.gridMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.gridMain.HeaderRowWidth = 24
        Me.gridMain.ItemHeight = 24
        Me.gridMain.Location = New System.Drawing.Point(0, 141)
        Me.gridMain.Name = "gridMain"
        Me.gridMain.Padding = New System.Windows.Forms.Padding(1)
        Me.gridMain.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.gridMain.ShowColumnMenuStrip = True
        Me.gridMain.Size = New System.Drawing.Size(390, 475)
        Me.gridMain.TabIndex = 5
        Me.gridMain.Text = "AsGridView1"
        '
        'iCode
        '
        Me.iCode.Field = "iCode"
        Me.iCode.Text = "รหัส"
        Me.iCode.TextAlign = System.Drawing.StringAlignment.Near
        '
        'iName
        '
        Me.iName.Field = "iName"
        Me.iName.Text = "ชื่อ"
        Me.iName.TextAlign = System.Drawing.StringAlignment.Near
        Me.iName.Width = 165
        '
        'SearchKey
        '
        Me.SearchKey.Field = "SearchKey"
        Me.SearchKey.Text = "คำค้นหา"
        Me.SearchKey.TextAlign = System.Drawing.StringAlignment.Near
        '
        'Status
        '
        Me.Status.Field = "Status"
        Me.Status.Text = "Status"
        Me.Status.Visible = False
        Me.Status.Width = 50
        '
        'groupFilter
        '
        Me.groupFilter.Controls.Add(Me.rdoSelectTop)
        Me.groupFilter.Controls.Add(Me.rdoSelectAll)
        Me.groupFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupFilter.HeaderHeight = 0
        Me.groupFilter.Location = New System.Drawing.Point(0, 88)
        Me.groupFilter.Name = "groupFilter"
        Me.groupFilter.ShowExpand = False
        Me.groupFilter.Size = New System.Drawing.Size(390, 53)
        Me.groupFilter.TabIndex = 4
        Me.groupFilter.Visible = False
        '
        'rdoSelectTop
        '
        Me.rdoSelectTop.AutoSize = True
        Me.rdoSelectTop.Checked = True
        Me.rdoSelectTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rdoSelectTop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoSelectTop.Location = New System.Drawing.Point(73, 5)
        Me.rdoSelectTop.Name = "rdoSelectTop"
        Me.rdoSelectTop.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.rdoSelectTop.Size = New System.Drawing.Size(315, 21)
        Me.rdoSelectTop.TabIndex = 1
        Me.rdoSelectTop.TabStop = True
        Me.rdoSelectTop.Text = "แสดง100รายการล่าสุด (เรียงตามรหัส จากมากมาน้อย)"
        Me.rdoSelectTop.UseVisualStyleBackColor = True
        '
        'rdoSelectAll
        '
        Me.rdoSelectAll.AutoSize = True
        Me.rdoSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rdoSelectAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdoSelectAll.Location = New System.Drawing.Point(73, 28)
        Me.rdoSelectAll.Name = "rdoSelectAll"
        Me.rdoSelectAll.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.rdoSelectAll.Size = New System.Drawing.Size(124, 21)
        Me.rdoSelectAll.TabIndex = 2
        Me.rdoSelectAll.Text = "แสดงข้อมูลทั้งหมด"
        Me.rdoSelectAll.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblHeader)
        Me.Panel3.Controls.Add(Me.linkFilter)
        Me.Panel3.Controls.Add(Me.chkCancel)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(390, 88)
        Me.Panel3.TabIndex = 0
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.DimGray
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHeader.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.Fuchsia
        Me.lblHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(390, 35)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "ข้อมูล แผนก"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'linkFilter
        '
        Me.linkFilter.AutoSize = True
        Me.linkFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.linkFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.linkFilter.Location = New System.Drawing.Point(273, 65)
        Me.linkFilter.Name = "linkFilter"
        Me.linkFilter.Size = New System.Drawing.Size(113, 17)
        Me.linkFilter.TabIndex = 121
        Me.linkFilter.TabStop = True
        Me.linkFilter.Text = "Show more Filter"
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.Checked = True
        Me.chkCancel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkCancel.Location = New System.Drawing.Point(73, 38)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.chkCancel.Size = New System.Drawing.Size(146, 21)
        Me.chkCancel.TabIndex = 4
        Me.chkCancel.Text = "ไม่แสดงรายการยกเลิก"
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(4, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 21)
        Me.Label4.TabIndex = 120
        Me.Label4.Text = "Search :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtSearch.Location = New System.Drawing.Point(75, 62)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(192, 23)
        Me.txtSearch.TabIndex = 119
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(64, 64)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdAddNew, Me.cmdEdit, Me.cmdSave, Me.cmdDelete, Me.cmdPrint, Me.cmdUndo, Me.ToolStripSeparator2, Me.cmdClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(390, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(604, 71)
        Me.ToolStrip1.TabIndex = 227
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdAddNew
        '
        Me.cmdAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAddNew.Image = Global.masPro.My.Resources.Resources.mAddNew
        Me.cmdAddNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(68, 68)
        Me.cmdAddNew.ToolTipText = "เพิ่มใหม่"
        '
        'cmdEdit
        '
        Me.cmdEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdEdit.Image = Global.masPro.My.Resources.Resources.mEdit
        Me.cmdEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(68, 68)
        Me.cmdEdit.ToolTipText = "แก้ไข"
        '
        'cmdSave
        '
        Me.cmdSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSave.Image = Global.masPro.My.Resources.Resources.mSave
        Me.cmdSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(68, 68)
        Me.cmdSave.ToolTipText = "บันทึก"
        '
        'cmdDelete
        '
        Me.cmdDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdDelete.Image = Global.masPro.My.Resources.Resources.mDelete
        Me.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(68, 68)
        Me.cmdDelete.ToolTipText = "ยกเลิกรายการ"
        '
        'cmdPrint
        '
        Me.cmdPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdPrint.Image = Global.masPro.My.Resources.Resources.mPrint
        Me.cmdPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(68, 68)
        Me.cmdPrint.ToolTipText = "พิมพ์"
        '
        'cmdUndo
        '
        Me.cmdUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdUndo.Image = Global.masPro.My.Resources.Resources.mCancel
        Me.cmdUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdUndo.Name = "cmdUndo"
        Me.cmdUndo.Size = New System.Drawing.Size(68, 68)
        Me.cmdUndo.ToolTipText = "ย้อนกลับ(ไม่บันทึก)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 71)
        '
        'cmdClose
        '
        Me.cmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdClose.Image = Global.masPro.My.Resources.Resources.mClose
        Me.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(68, 68)
        Me.cmdClose.ToolTipText = "ปิดฟอร์ม"
        '
        'HeadGroup
        '
        Me.HeadGroup.Controls.Add(Me.txtRemark1)
        Me.HeadGroup.Controls.Add(Me.txtRemark2)
        Me.HeadGroup.Controls.Add(Me.lblRemark2)
        Me.HeadGroup.Controls.Add(Me.lblRemark1)
        Me.HeadGroup.Controls.Add(Me.txtCode)
        Me.HeadGroup.Controls.Add(Me.txtSearchKey)
        Me.HeadGroup.Controls.Add(Me.l_KeyWord)
        Me.HeadGroup.Controls.Add(Me.txtName)
        Me.HeadGroup.Controls.Add(Me.l_Code)
        Me.HeadGroup.Controls.Add(Me.l_Name)
        Me.HeadGroup.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeadGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.HeadGroup.Location = New System.Drawing.Point(390, 71)
        Me.HeadGroup.Name = "HeadGroup"
        Me.HeadGroup.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.HeadGroup.ShowExpand = False
        Me.HeadGroup.Size = New System.Drawing.Size(604, 158)
        Me.HeadGroup.TabIndex = 228
        Me.HeadGroup.TabStop = False
        Me.HeadGroup.Text = "รายการ"
        '
        'txtRemark1
        '
        Me.txtRemark1.Location = New System.Drawing.Point(130, 105)
        Me.txtRemark1.MaxLength = 255
        Me.txtRemark1.Name = "txtRemark1"
        Me.txtRemark1.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtRemark1.Size = New System.Drawing.Size(367, 23)
        Me.txtRemark1.TabIndex = 3
        '
        'txtRemark2
        '
        Me.txtRemark2.Location = New System.Drawing.Point(130, 130)
        Me.txtRemark2.MaxLength = 255
        Me.txtRemark2.Name = "txtRemark2"
        Me.txtRemark2.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtRemark2.Size = New System.Drawing.Size(367, 23)
        Me.txtRemark2.TabIndex = 4
        '
        'lblRemark2
        '
        Me.lblRemark2.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblRemark2.ForeColor = System.Drawing.Color.Black
        Me.lblRemark2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRemark2.Location = New System.Drawing.Point(6, 130)
        Me.lblRemark2.Name = "lblRemark2"
        Me.lblRemark2.Size = New System.Drawing.Size(125, 23)
        Me.lblRemark2.TabIndex = 259
        Me.lblRemark2.Text = "หมายเหตุ2 :"
        Me.lblRemark2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRemark1
        '
        Me.lblRemark1.BackColor = System.Drawing.Color.Transparent
        Me.lblRemark1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblRemark1.ForeColor = System.Drawing.Color.Black
        Me.lblRemark1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRemark1.Location = New System.Drawing.Point(6, 105)
        Me.lblRemark1.Name = "lblRemark1"
        Me.lblRemark1.Size = New System.Drawing.Size(125, 23)
        Me.lblRemark1.TabIndex = 258
        Me.lblRemark1.Text = "หมายเหตุ1 :"
        Me.lblRemark1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.txtCode.Location = New System.Drawing.Point(130, 30)
        Me.txtCode.MaxLength = 30
        Me.txtCode.Name = "txtCode"
        Me.txtCode.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtCode.Size = New System.Drawing.Size(148, 23)
        Me.txtCode.TabIndex = 0
        '
        'txtSearchKey
        '
        Me.txtSearchKey.Location = New System.Drawing.Point(130, 80)
        Me.txtSearchKey.MaxLength = 50
        Me.txtSearchKey.Name = "txtSearchKey"
        Me.txtSearchKey.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtSearchKey.Size = New System.Drawing.Size(367, 23)
        Me.txtSearchKey.TabIndex = 2
        '
        'l_KeyWord
        '
        Me.l_KeyWord.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.l_KeyWord.ForeColor = System.Drawing.Color.Black
        Me.l_KeyWord.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.l_KeyWord.Location = New System.Drawing.Point(3, 80)
        Me.l_KeyWord.Name = "l_KeyWord"
        Me.l_KeyWord.Size = New System.Drawing.Size(127, 23)
        Me.l_KeyWord.TabIndex = 117
        Me.l_KeyWord.Text = "คำค้นหา :"
        Me.l_KeyWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.MistyRose
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtName.Location = New System.Drawing.Point(130, 55)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.txtName.Required = True
        Me.txtName.RequiredAlertText = "ต้องกรอกข้อมูล ห้ามเป็นค่าว่าง"
        Me.txtName.Size = New System.Drawing.Size(367, 23)
        Me.txtName.TabIndex = 1
        '
        'l_Code
        '
        Me.l_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.l_Code.ForeColor = System.Drawing.Color.Red
        Me.l_Code.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.l_Code.Location = New System.Drawing.Point(3, 30)
        Me.l_Code.Name = "l_Code"
        Me.l_Code.Size = New System.Drawing.Size(127, 23)
        Me.l_Code.TabIndex = 115
        Me.l_Code.Text = "รหัส :"
        Me.l_Code.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'l_Name
        '
        Me.l_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.l_Name.ForeColor = System.Drawing.Color.Red
        Me.l_Name.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.l_Name.Location = New System.Drawing.Point(3, 55)
        Me.l_Name.Name = "l_Name"
        Me.l_Name.Size = New System.Drawing.Size(127, 23)
        Me.l_Name.TabIndex = 114
        Me.l_Name.Text = "ชื่อ :"
        Me.l_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.Red
        Me.lblStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStatus.Location = New System.Drawing.Point(644, 265)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(88, 24)
        Me.lblStatus.TabIndex = 229
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCancel
        '
        Me.lblCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblCancel.ForeColor = System.Drawing.Color.Red
        Me.lblCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancel.Location = New System.Drawing.Point(490, 289)
        Me.lblCancel.Name = "lblCancel"
        Me.lblCancel.Size = New System.Drawing.Size(390, 31)
        Me.lblCancel.TabIndex = 230
        Me.lblCancel.Text = "***รายการนี้ ถูกยกเลิก***"
        Me.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCancel.Visible = False
        '
        'masProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 616)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblCancel)
        Me.Controls.Add(Me.HeadGroup)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "masProject"
        Me.Text = "masterProject"
        Me.Panel1.ResumeLayout(False)
        Me.groupFilter.ResumeLayout(False)
        Me.groupFilter.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.HeadGroup.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents gridMain As Stone.WinUI.AsGridView
    Friend WithEvents iCode As Stone.WinUI.AsGridViewColumn
    Friend WithEvents iName As Stone.WinUI.AsGridViewColumn
    Friend WithEvents SearchKey As Stone.WinUI.AsGridViewColumn
    Friend WithEvents Status As Stone.WinUI.AsGridViewColumn
    Friend WithEvents groupFilter As Stone.WinUI.AsGrouper
    Friend WithEvents rdoSelectTop As Stone.WinUI.AsRadioButton
    Friend WithEvents rdoSelectAll As Stone.WinUI.AsRadioButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblHeader As Label
    Friend WithEvents linkFilter As LinkLabel
    Friend WithEvents chkCancel As Stone.WinUI.AsCheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSearch As Stone.WinUI.AsTextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents cmdAddNew As ToolStripButton
    Friend WithEvents cmdEdit As ToolStripButton
    Friend WithEvents cmdSave As ToolStripButton
    Friend WithEvents cmdDelete As ToolStripButton
    Friend WithEvents cmdPrint As ToolStripButton
    Friend WithEvents cmdUndo As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdClose As ToolStripButton
    Friend WithEvents HeadGroup As Stone.WinUI.AsGrouper
    Friend WithEvents txtRemark1 As Stone.WinUI.AsTextBox
    Friend WithEvents txtRemark2 As Stone.WinUI.AsTextBox
    Friend WithEvents lblRemark2 As Label
    Friend WithEvents lblRemark1 As Label
    Friend WithEvents txtCode As Stone.WinUI.AsTextBox
    Friend WithEvents txtSearchKey As Stone.WinUI.AsTextBox
    Friend WithEvents l_KeyWord As Label
    Friend WithEvents txtName As Stone.WinUI.AsTextBox
    Friend WithEvents l_Code As Label
    Friend WithEvents l_Name As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCancel As Label
End Class
