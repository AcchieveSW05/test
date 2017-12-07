Imports DAL

Public Class frmBase
    Friend dal As Adapter
    Private m_Connection As ConnectionInfo
    Public Property Connection() As ConnectionInfo
        Get
            Return m_Connection
        End Get
        Set(ByVal value As ConnectionInfo)
            m_Connection = value
        End Set
    End Property

    Private Sub frmBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class