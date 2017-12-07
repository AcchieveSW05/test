Imports System
Imports System.Data


Public Class ConnectionInfo
    Public Sub New()
        Me.ConnectionString = ""
    End Sub


    Private m_ConnectionString As String
    Public Property ConnectionString() As String
        Get
            Return m_ConnectionString
        End Get
        Private Set(ByVal value As String)
            m_ConnectionString = value
        End Set
    End Property

    Public Sub SetConnectionString(ByVal serverName As String, ByVal dbName As String, ByVal user As String, ByVal pass As String)
        Dim s As String
        If user <> "" And pass <> "" Then
            s = String.Format("Data Source={0}; Initial Catalog={1}; User Id={2}; Password={3}; Connection Timeout=0;", serverName, dbName, user, pass)
        Else
            s = String.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=SSPI; Connection Timeout=30;", serverName, dbName)
        End If
        Me.ConnectionString = s
    End Sub


    'Select Case cboAuthen.SelectedIndex
    '            Case 0
    '                strConn = "Data Source=" & txt_Server.Text.Trim() & ";Initial Catalog=master; Integrated Security=SSPI"
    '            Case 1
    '                strConn = "Data Source=" & txt_Server.Text.Trim() & ";Initial Catalog=master; User Id=" & txtuser.Text & ";Password=" & txtpass.Text & ";"
    '        End Select


    Public Sub SetConnectionString(ByVal strConn As String)
        If strConn.Length > 10 Then
            Me.ConnectionString = strConn
        End If
    End Sub

End Class
