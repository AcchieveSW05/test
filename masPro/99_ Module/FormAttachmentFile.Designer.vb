<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAttachmentFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAttachmentFile))
        Me.gbAttach = New Stone.WinUI.AsGrouper
        Me.pubGridAttachment = New Stone.WinUI.AsGridData
        Me.iFileDescription = New Stone.WinUI.AsGridDataColumn
        Me.iFileName = New Stone.WinUI.AsGridDataColumn
        Me.iPathFileName = New Stone.WinUI.AsGridDataColumn
        Me.iOpen = New Stone.WinUI.AsGridDataColumn
        Me.gbAttach.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbAttach
        '
        Me.gbAttach.AccessibleDescription = Nothing
        Me.gbAttach.AccessibleName = Nothing
        resources.ApplyResources(Me.gbAttach, "gbAttach")
        Me.gbAttach.BackColor = System.Drawing.Color.Silver
        Me.gbAttach.BackgroundImage = Nothing
        Me.gbAttach.BaseColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.gbAttach.Controls.Add(Me.pubGridAttachment)
        Me.gbAttach.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.gbAttach.HeaderForeColor = System.Drawing.Color.White
        Me.gbAttach.HeaderHeight = 18
        Me.gbAttach.Name = "gbAttach"
        Me.gbAttach.RendererType = Stone.WinUI.RendererTypes.Office2007
        '
        'pubGridAttachment
        '
        Me.pubGridAttachment.AccessibleDescription = Nothing
        Me.pubGridAttachment.AccessibleName = Nothing
        resources.ApplyResources(Me.pubGridAttachment, "pubGridAttachment")
        Me.pubGridAttachment.BackgroundImage = Nothing
        Me.pubGridAttachment.ColumnKeyField = "iFileName"
        Me.pubGridAttachment.Columns.AddRange(New Stone.WinUI.AsGridViewColumn() {Me.iFileDescription, Me.iFileName, Me.iPathFileName, Me.iOpen})
        Me.pubGridAttachment.Font = Nothing
        Me.pubGridAttachment.HeaderRowWidth = 24
        Me.pubGridAttachment.Name = "pubGridAttachment"
        Me.pubGridAttachment.RendererType = Stone.WinUI.RendererTypes.Office2007
        Me.pubGridAttachment.ShowHeader = False
        '
        'iFileDescription
        '
        Me.iFileDescription.Field = "FileDescription"
        resources.ApplyResources(Me.iFileDescription, "iFileDescription")
        Me.iFileDescription.Spring = True
        Me.iFileDescription.Width = 300
        '
        'iFileName
        '
        Me.iFileName.EditBoxStyle = Stone.WinUI.BoxStyles.None
        Me.iFileName.Field = "iFileName"
        resources.ApplyResources(Me.iFileName, "iFileName")
        Me.iFileName.Visible = False
        Me.iFileName.Width = 50
        '
        'iPathFileName
        '
        Me.iPathFileName.ButtonText = "Attach"
        Me.iPathFileName.ColumnFormat = Stone.WinUI.ColumnFormats.Button
        Me.iPathFileName.Field = "iPathFileName"
        Me.iPathFileName.FixedWidth = True
        resources.ApplyResources(Me.iPathFileName, "iPathFileName")
        Me.iPathFileName.Width = 60
        '
        'iOpen
        '
        Me.iOpen.ButtonText = "Open"
        Me.iOpen.ColumnFormat = Stone.WinUI.ColumnFormats.Button
        Me.iOpen.Field = "iOpen"
        Me.iOpen.FixedWidth = True
        resources.ApplyResources(Me.iOpen, "iOpen")
        Me.iOpen.Width = 60
        '
        'FormAttachmentFile
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.gbAttach)
        Me.Icon = Nothing
        Me.Name = "FormAttachmentFile"
        Me.gbAttach.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbAttach As Stone.WinUI.AsGrouper
    Friend WithEvents pubGridAttachment As Stone.WinUI.AsGridData
    Friend WithEvents iFileDescription As Stone.WinUI.AsGridDataColumn
    Friend WithEvents iFileName As Stone.WinUI.AsGridDataColumn
    Friend WithEvents iPathFileName As Stone.WinUI.AsGridDataColumn
    Friend WithEvents iOpen As Stone.WinUI.AsGridDataColumn
End Class
