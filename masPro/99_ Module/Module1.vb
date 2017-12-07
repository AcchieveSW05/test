Module Module1
    Public Class TransparentLabel
        Inherits System.Windows.Forms.Control

        'UserControl overrides dispose to clean up the component list.
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
            Me.SuspendLayout()
            '
            'TransparentLabel
            '
            Me.Name = "TransparentLabel"
            Me.Text = "I am Transparent"
            Me.Size = New System.Drawing.Size(217, 32)
            Me.ResumeLayout(False)

        End Sub
        ' Custom code starts here...
        Public Sub New()
            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            Me.TabStop = False
        End Sub


        Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                cp.ExStyle = cp.ExStyle Or &H20
                Return cp
            End Get
        End Property


        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            'Do nothing...
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Using brush As SolidBrush = New SolidBrush(ForeColor)
                e.Graphics.DrawString(Text, Font, brush, -1, 0)
            End Using
        End Sub

    End Class
End Module
