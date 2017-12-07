#Region "Imports"
Imports System.Windows.Forms
Imports System.Management
Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports DAL

#End Region
Module modSubFunction


    Public Sub openFormDialog(ByVal frmXxx As Object)
        Dim xx As Form
        xx = frmXxx
        xx.ShowDialog()
        'resetsRetval()
    End Sub

    Public Sub doPrint(ByVal _DocNumber As String, ByVal _Source As String, ByVal _DocStatus As String, ByVal _MenuForm As String)
        sRetval(0) = _DocNumber
        sRetval(1) = _Source
        sRetval(2) = _DocStatus
        sRetval(3) = _MenuForm
        Dim ifrmPrintMaster = New frmPrintMaster2
        ifrmPrintMaster.ShowDialog()
        resetsRetval()
    End Sub
    Public Function getRole(ByVal da As DAL.Adapter, ByVal _MenuName As String, ByVal _UserGroup As String, ByVal _MenuApprove As String) As Boolean
        Dim sql As String = ""
        Dim dt As DataTable
        sRetval(0) = 0 'MenuCaption
        sRetval(1) = 0 'MenuCaptionTh
        sRetval(2) = 0 'Add
        sRetval(3) = 0 'Edit
        sRetval(4) = 0 'Delete
        sRetval(5) = 0 'Print
        sRetval(6) = 0 'Use
        sRetval(7) = 0 'Approve
        Try
            sql = "Select"
            sql += " coalesce(b.MenuCaption,'') 'MenuCaption'"
            sql += " ,coalesce(b.MenuCaptionTh,'') 'MenuCaptionTh'"
            sql += " ,coalesce(a.RoleAdd,0) 'RoleAdd'"
            sql += " ,coalesce(a.RoleUpdate,0) 'RoleUpdate'"
            sql += " ,coalesce(a.RoleDelete,0) 'RoleDelete'"
            sql += " ,coalesce(a.RolePrint,0) 'RolePrint'"
            sql += " ,coalesce(a.RoleSearch,0) 'RoleUse'"
            sql += " ,coalesce(c.RoleSearch,0) 'RoleApprove'"
            sql += " From	SysRole a With(NoLock)"
            sql += " Left outer join Menulist b With(NoLock)"
            sql += " on a.MenuName = b.MenuName"
            sql += " Left outer join Sysrole c With(NoLock)"
            sql += " on a.SysGroupName = c.SysGroupName"
            sql += " and c.MenuName = '" & _MenuApprove & "'"
            sql += " Where a.SysGroupName = '" & _UserGroup & "' And a.MenuName = '" & _MenuName & "'"

            dt = pubGetData(da, sql, "DataList")
            If dt.Rows.Count >= 1 Then
                sRetval(0) = dt.Rows(0)("MenuCaption").ToString 'MenuCaption
                sRetval(1) = dt.Rows(0)("MenuCaptionTh").ToString 'MenuCaptionTh
                sRetval(2) = dt.Rows(0)("RoleAdd").ToString 'Add
                sRetval(3) = dt.Rows(0)("RoleUpdate").ToString 'Edit
                sRetval(4) = dt.Rows(0)("RoleDelete").ToString 'Delete
                sRetval(5) = dt.Rows(0)("RolePrint").ToString 'Print
                sRetval(6) = dt.Rows(0)("RoleUse").ToString 'Use
                sRetval(7) = dt.Rows(0)("RoleApprove").ToString 'Approve
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function getRole(ByVal da As DAL.Adapter, ByVal _MenuName As String, ByVal _UserGroup As String) As Boolean
        Dim sql As String = ""
        Dim dt As DataTable
        sRetval(0) = 0 'MenuCaption
        sRetval(1) = 0 'MenuCaptionTh
        sRetval(2) = 0 'Add
        sRetval(3) = 0 'Edit
        sRetval(4) = 0 'Delete
        sRetval(5) = 0 'Print
        sRetval(6) = 0 'Use
        sRetval(7) = 0 'Approve

        Try
            sql = "Select"
            sql += " coalesce(b.MenuCaption,'') 'MenuCaption'"
            sql += " ,coalesce(b.MenuCaptionTh,'') 'MenuCaptionTh'"
            sql += " ,coalesce(a.RoleAdd,0) 'RoleAdd'"
            sql += " ,coalesce(a.RoleUpdate,0) 'RoleUpdate'"
            sql += " ,coalesce(a.RoleDelete,0) 'RoleDelete'"
            sql += " ,coalesce(a.RolePrint,0) 'RolePrint'"
            sql += " ,coalesce(a.RoleSearch,0) 'RoleUse'"
            sql += " From	SysRole a With(NoLock)"
            sql += " Left outer join Menulist b With(NoLock)"
            sql += " on a.MenuName = b.MenuName"
            sql += " Where a.SysGroupName = '" & _UserGroup & "' And a.MenuName = '" & _MenuName & "'"

            dt = pubGetData(da, sql, "DataList")
            If dt.Rows.Count >= 1 Then
                sRetval(0) = dt.Rows(0)("MenuCaption").ToString 'MenuCaption
                sRetval(1) = dt.Rows(0)("MenuCaptionTh").ToString 'MenuCaptionTh
                sRetval(2) = dt.Rows(0)("RoleAdd").ToString 'Add
                sRetval(3) = dt.Rows(0)("RoleUpdate").ToString 'Edit
                sRetval(4) = dt.Rows(0)("RoleDelete").ToString 'Delete
                sRetval(5) = dt.Rows(0)("RolePrint").ToString 'Print
                sRetval(6) = dt.Rows(0)("RoleUse").ToString 'Use
                sRetval(7) = "0" 'Approve
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


End Module
