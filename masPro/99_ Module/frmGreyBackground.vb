Public Class frmGreyBackground
    Private Sub frmGreyBackground_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    End Sub
    Private Sub frmGreyBackground_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub frmGreyBackground_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Show()
            Select Case pubOpenFrom
                Case "masProduct"

                Case Else
                    MsgBox("ไม่พบฟอร์มกรอกข้อมูล : " & pubOpenFrom)
                    Me.Close()
            End Select

        Catch ex As Exception
            MsgBox(Err.Description)
            Me.Close()
        End Try
    End Sub

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        Me.Close()
    End Sub
  
End Class