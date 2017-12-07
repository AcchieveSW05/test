Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class Adapter
    Implements IDisposable

#Region "Constructor and Dispose"

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Adapter" /> class.
    ''' </summary>
    Public Sub New()
        Me.m_ConnInfo = Nothing
        Me.m_TimeOut = 10000000
    End Sub

    ''' <summary>
    ''' Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    ''' </summary>
    Public Sub Dispose() Implements System.IDisposable.Dispose
        If Me.m_Transaction IsNot Nothing Then
            Me.m_Transaction.Dispose()
        End If
        If (Me.m_SqlConn IsNot Nothing) AndAlso (Me.m_SqlConn.State = ConnectionState.Open) Then
            Me.m_SqlConn.Close()
            Me.m_SqlConn.Dispose()
        End If
    End Sub

#End Region

    Private m_SqlConn As SqlConnection
    Private m_Transaction As SqlTransaction
    Private m_ConnInfo As ConnectionInfo

    ''' <summary>
    ''' Gets or sets the connection info.
    ''' </summary>
    ''' <value>The connection info.</value>
    Public Property ConnectionInfo() As ConnectionInfo
        Get
            Return m_ConnInfo
        End Get
        Set(ByVal value As ConnectionInfo)
            m_ConnInfo = value
        End Set
    End Property

    Private m_TimeOut As Integer
    ''' <summary>
    ''' Gets or sets the time out.
    ''' </summary>
    ''' <value>The time out.</value>
    Public Property TimeOut() As Integer
        Get
            Return Me.m_TimeOut
        End Get
        Set(ByVal value As Integer)
            If Me.m_TimeOut <> value Then
                Me.m_TimeOut = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Open the connection.
    ''' </summary>
    ''' <returns></returns>
    Public Function Open() As Boolean
        Return (Me.Open(Me.m_ConnInfo.ConnectionString))
    End Function

    ''' <summary>
    ''' Opens the specified connection string.
    ''' </summary>
    ''' <param name="connectionString">The connection string.</param>
    ''' <returns></returns>
    Public Function Open(ByVal connectionString As String) As Boolean
        Dim flag As Boolean = False
        Try
            If (m_SqlConn IsNot Nothing) AndAlso (m_SqlConn.State = ConnectionState.Open) Then
                m_SqlConn.Close()
            End If
            m_SqlConn = New SqlConnection(connectionString)
            m_SqlConn.Open()
            flag = True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return flag
    End Function

    ''' <summary>
    ''' Closes connection.
    ''' </summary>
    Public Sub Close()
        If (m_SqlConn IsNot Nothing) AndAlso (m_SqlConn.State = ConnectionState.Open) Then
            m_SqlConn.Close()
        End If
    End Sub

    ''' <summary>
    ''' Begin transaction.
    ''' </summary>
    Public Sub TransBegin()
        Me.m_Transaction = m_SqlConn.BeginTransaction()
    End Sub

    ''' <summary>
    ''' Commit transaction.
    ''' </summary>
    Public Sub TransCommit()
        Me.m_Transaction.Commit()
    End Sub

    ''' <summary>
    ''' Rollback transaction.
    ''' </summary>
    Public Sub TransRollback()
        Me.m_Transaction.Rollback()
    End Sub

    ''' <summary>
    ''' Gets the data.
    ''' </summary>
    ''' <param name="tableName">Name of the table.</param>
    ''' <returns></returns>
    Public Function GetData(ByVal tableName As String) As DataTable
        Dim sql As String = "Select * From " + tableName
        Return Me.GetData(sql, tableName)
    End Function
    ''' <summary>
    ''' Gets the data.
    ''' </summary>
    ''' <param name="sql">The SQL.</param>
    ''' <param name="tableName">Name of the table.</param>
    ''' <returns></returns>
    Public Function GetData(ByVal sql As String, ByVal tableName As String) As DataTable
        Return Me.GetData(sql, tableName, Nothing)
    End Function

    ''' <summary>
    ''' Gets the data.
    ''' </summary>
    ''' <param name="sql">The SQL.</param>
    ''' <param name="tableName">Name of the table.</param>
    ''' <param name="paras">The paras.</param>
    ''' <returns></returns>
    Public Function GetData(ByVal sql As String, ByVal tableName As String, ByVal paras As ParameterList) As DataTable
        Dim dt As New DataTable(tableName)
        Using da As New SqlDataAdapter(sql, m_SqlConn)
            da.SelectCommand.Transaction = Me.m_Transaction
            da.SelectCommand.CommandTimeout = Me.m_TimeOut
            If (paras IsNot Nothing) AndAlso (paras.Items.Count > 0) Then
                For Each para1 As SqlParameter In paras.Items
                    da.SelectCommand.Parameters.Add(para1)
                Next
                da.GetFillParameters()
            End If
            da.Fill(dt)
        End Using
    Return dt
    End Function
    ''' <summary>
    ''' Executes the non query.
    ''' </summary>
    ''' <param name="sql">The SQL.</param>
    ''' <returns></returns>
    Public Function ExecuteNonQuery(ByVal sql As String) As Integer
        Return Me.ExecuteNonQuery(sql, Nothing)
    End Function
    ''' <summary>
    ''' Executes the non query.
    ''' </summary>
    ''' <param name="sql">The SQL.</param>
    ''' <param name="paras">The paras.</param>
    ''' <returns></returns>
    Public Function ExecuteNonQuery(ByVal sql As String, ByVal paras As ParameterList) As Integer
        Dim Cmd As New SqlCommand(sql, m_SqlConn)
        Cmd.Transaction = Me.m_Transaction
        Cmd.CommandTimeout = Me.m_TimeOut
        If paras IsNot Nothing Then
            For Each para1 As SqlParameter In paras.Items
                Cmd.Parameters.Add(para1)
            Next
        End If
        Return Cmd.ExecuteNonQuery()
    End Function

    ''' <summary>
    ''' Updates the data.
    ''' </summary>
    ''' <param name="ds">The ds.</param>
    Public Sub UpdateData(ByVal ds As DataSet)
        For Each dt As DataTable In ds.Tables
            Me.UpdateData(dt)
        Next
    End Sub
    ''' <summary>
    ''' Updates the data.
    ''' </summary>
    ''' <param name="dt">The dt.</param>
    ''' <returns></returns>
    Public Function UpdateData(ByVal dt As DataTable) As Integer
        Dim rowsAffect As Integer = -1
        Dim sql As String = "Select * From " + dt.TableName
        Using da As New SqlDataAdapter(sql, m_SqlConn)
            da.SelectCommand.Transaction = Me.m_Transaction
            da.SelectCommand.CommandTimeout = Me.m_TimeOut
            Dim Cmb As New SqlCommandBuilder(da)
            rowsAffect = da.Update(dt) 
        End Using
        Return rowsAffect



    End Function

End Class
