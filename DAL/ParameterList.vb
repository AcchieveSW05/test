Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Public Class ParameterList
    Implements IDisposable
    Public Sub New()
        Me.m_List = New List(Of SqlParameter)()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If Me.m_List IsNot Nothing Then
            Me.m_List.Clear()
            Me.m_List = Nothing
        End If
    End Sub
    Private m_List As List(Of SqlParameter)
    Public ReadOnly Property Items() As List(Of SqlParameter)
        Get
            Return m_List
        End Get
    End Property
    Private Sub AddPara(ByVal para As SqlParameter)
        If Me.m_List.Contains(para) Then
            Return
        End If
        Me.m_List.Add(para)
    End Sub
    Public Function Add(ByVal parameterName As String, ByVal [date] As DateTime) As SqlParameter
        Dim para As New SqlParameter(parameterName, SqlDbType.DateTime)
        para.Value = [date]
        Me.AddPara(para)
        Return para
    End Function
    Public Function Add(ByVal parameterName As String, ByVal num As Integer) As SqlParameter
        Dim para As New SqlParameter(parameterName, SqlDbType.Int)
        para.Value = num
        Me.AddPara(para)
        Return para
    End Function

    Public Function Add(ByVal parameterName As String, ByVal num As Double) As SqlParameter
        Dim para As New SqlParameter(parameterName, SqlDbType.Money)
        para.Value = num
        Me.AddPara(para)
        Return para
    End Function
    Public Function Add(ByVal parameterName As String, ByVal s As String) As SqlParameter
        Dim para As New SqlParameter(parameterName, SqlDbType.VarChar, s.Length)
        'If s.Length = 0 Or s = "1900-01-01" Then
        '    para.Value = DBNull.Value
        'Else
        '    para.Value = s
        'End If
        para.Value = s
        Me.AddPara(para)
        Return para
    End Function
    Public Function Add(ByVal parameterName As String, ByVal s() As Byte) As SqlParameter
        Dim para As SqlParameter
        If s(0) = 0 And s(1) = 0 And s(2) = 0 Then
            para = New SqlParameter(parameterName, SqlDbType.Image)
            para.Value = DBNull.Value
        Else
            para = New SqlParameter(parameterName, SqlDbType.Image, s.Length)
            para.Value = s
        End If
        Me.AddPara(para)
        Return para
    End Function
End Class
