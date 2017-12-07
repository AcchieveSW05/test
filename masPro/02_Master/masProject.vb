#Region "Import"
Imports System.Data
Imports Stone.WinUI
Imports System.Windows.Forms
Imports DAL
Imports System.Data.OleDb
Imports System.Transactions
#End Region
Public Class masProject

#Region "Dim"
    Dim strUse, strAdd, strEdit, strDelete, strPrint As String
    Dim strWarning As String = "Warning"
    Dim SelectedRow As DataRowView
    Dim strMenuForm As String   'รับค่าจาก grid sRetval(13)
#End Region

#Region "Form"

    Private Sub masProject_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub masProject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1    'Help

            Case Keys.F2    'Edit
                If cmdEdit.Visible = True Then cmdEdit.PerformClick()
            Case Keys.F3    'Undo 
                If cmdUndo.Visible = True Then cmdUndo.PerformClick()
            Case Keys.F4    'AddNew
                If cmdAddNew.Visible = True Then cmdAddNew.PerformClick()
            Case Keys.F5    'Save
                If cmdSave.Visible = True Then cmdSave.PerformClick()
            Case Keys.F9    'Print
                If cmdPrint.Visible = True Then cmdPrint.PerformClick()
            Case Keys.F10   'Delete or Cancel
                If cmdDelete.Visible = True Then cmdDelete.PerformClick()
            Case Keys.Escape 'Close Form
                If cmdUndo.Visible = True Then Call cmdUndo_Click(sender, e) : Exit Sub
                If cmdClose.Visible = False Then Exit Sub
                If (MsgBox("Do you want to close this form?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Information, "Close Form")) = Microsoft.VisualBasic.MsgBoxResult.Yes Then Me.Close()
        End Select
    End Sub
    Private Sub masProject_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CenterScreen(Me)
        Me.Refresh()
        Me.Connection = New DAL.ConnectionInfo()
        Me.Connection.SetConnectionString(pubServerName, pubDatabaseName, pubDbUsername, pubDbPassword)
        strMenuForm = "mnProject"
        txtSearch.Text = ""
        Call showData()
        If modSubFunction.getRole(Me.dal, strMenuForm, pubUserGroup) = True Then
            If pubUserLanguage = "en-US" Then lblHeader.Text = sRetval(0) : Me.Text = sRetval(0) Else lblHeader.Text = sRetval(1) : Me.Text = sRetval(1)
            strAdd = sRetval(2)
            strEdit = sRetval(3)
            strDelete = sRetval(4)
            strPrint = sRetval(5)
            strUse = sRetval(6)
        Else
            strAdd = "0"
            strEdit = "0"
            strDelete = "0"
            strPrint = "0"
            strUse = "0"

        End If
        Call setMenuNormal()
        lblStatus.Text = ""
        If strUse = 0 Then MsgBox("Not allow use this Function") : Me.Close()
        Call lockcontrol()
        groupFilter.Visible = False
        linkFilter.Text = "Show more Filter"

    End Sub
#End Region
#Region "Sub"
    Sub clearData()
        txtCode.Text = ""
        txtName.Text = ""
        txtSearchKey.Text = ""
        txtRemark1.Text = ""
        txtRemark2.Text = ""
    End Sub
    Sub lockcontrol()
        txtCode.ReadOnly = True
        txtName.ReadOnly = True
        txtSearchKey.ReadOnly = True
        txtRemark1.ReadOnly = True
        txtRemark2.ReadOnly = True
    End Sub
    Sub unlockControl()
        'txtCode.ReadOnly = False
        txtName.ReadOnly = False
        txtSearchKey.ReadOnly = False
        txtRemark1.ReadOnly = False
        txtRemark2.ReadOnly = False
    End Sub
    Sub execDeleteData()
        Dim strSql As String
        If txtCode.Text.Trim() = "" OrElse txtName.Text.Trim() = "" Then MsgBox("Please Select the item you want To Cancel.", MsgBoxStyle.OkOnly, strWarning) : Exit Sub
        If MsgBox("Do you want To cancel?" & vbNewLine & "Item code = " & txtCode.Text.Trim(), MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Critical, strWarning) = Microsoft.VisualBasic.MsgBoxResult.No Then Exit Sub
        Dim para As ParameterList = New ParameterList()
        Dim da As New DAL.Adapter
        da.ConnectionInfo = Me.Connection
        da.Open()
        da.TransBegin()
        Try
            strSql = "  Update Project Set "
            strSql += " DocStatus= 'C'"
            strSql += " ,UpdatedUser  = @User"
            strSql += " ,UpdatedDate  = @Date"
            strSql += " Where Project_Code = @Project_Code"

            para.Add("@User", String.Format("{0}", pubUserName))
            para.Add("@Date", Now)
            para.Add("@Project_Code", String.Format("{0}", txtCode.Text))
            da.ExecuteNonQuery(strSql, para)
            para.Items.Clear()
            Call pubInsertLogfile(da, para, "Cancel", "Project", txtCode.Text, Now, txtName.Text)
            da.TransCommit()
            Call SaveEffect(Me)
            Call clearData()
            Call showData()
        Catch ex As Exception
            MsgBox("An error occurred during the save data" + vbNewLine + Err.Description, MsgBoxStyle.OkOnly, strWarning)
            da.TransRollback()
        End Try
    End Sub
    Sub execSaveData()
        Dim strSql As String = ""
        Dim strCode As String = Me.txtCode.Text.Replace("'", "").Trim()
        Dim strName As String = Me.txtName.Text.Replace("'", "").Trim()
        Dim para As ParameterList = New ParameterList()

        If chkRequestData() = False Then MsgBox(pubMsgRequestData) : Exit Sub
        Dim da As New DAL.Adapter
        da.ConnectionInfo = Me.Connection
        da.Open()
        da.TransBegin()
        Try
            Select Case (lblStatus.Text.Replace("'", ""))
                Case "***Add New***"
                    Call setRunningNumber()
                    If chkDupplicateData() = False Then MsgBox(pubMsgDupplicateData) : Exit Sub
                    strCode = Me.txtCode.Text.Replace("'", "").Trim()
                    'Command1
                    strSql = "Insert Into Project"
                    strSql += " (Project_Code,ProjectName,SearchKey,Remark1,Remark2"
                    strSql += " ,CreatedUser,CreatedDate,UpdatedUser,UpdatedDate,DocStatus)"
                    strSql += " VALUES"
                    strSql += " (@Project_Code,@ProjectName,@SearchKey,@Remark1,@Remark2"
                    strSql += " ,@CreatedUser,@CreatedDate,@UpdatedUser,@UpdatedDate,@DocStatus)"
                    para.Add("@Project_Code", String.Format("{0}", strCode))
                    para.Add("@ProjectName", String.Format("{0}", strName))
                    para.Add("@SearchKey", String.Format("{0}", txtSearchKey.Text.Replace("'", "").ToString))
                    para.Add("@Remark1", String.Format("{0}", txtRemark1.Text.Replace("'", "").ToString))
                    para.Add("@Remark2", String.Format("{0}", txtRemark2.Text.Replace("'", "").ToString))
                    para.Add("@CreatedUser", pubUserName)
                    para.Add("@CreatedDate", Now)
                    para.Add("@UpdatedUser", pubUserName)
                    para.Add("@UpdatedDate", Now)
                    para.Add("@DocStatus", "W")
                    da.ExecuteNonQuery(strSql, para)
                    para.Items.Clear()
                    'Command 2
                    strSql = "Update PrefixNumber Set RunningNo = RunningNo + 1 Where PrefixSource = 'Project' and RunType = '0'"
                    da.ExecuteNonQuery(strSql)
                    'Command 3
                    Call pubInsertLogfile(da, para, "AddNew", "Master Project", strCode, Now, strName)

                Case "***Edit***"
                    If chkDupplicateData() = False Then MsgBox(pubMsgDupplicateData) : Exit Sub
                    'Command 1
                    strSql = "UPDATE Project SET "
                    strSql += " ProjectName = @ProjectName"
                    strSql += " ,SearchKey = @SearchKey"
                    strSql += " ,Remark1 = @Remark1"
                    strSql += " ,Remark2 = @Remark2"
                    strSql += " ,UpdatedUser = @UpdatedUser"
                    strSql += " ,UpdatedDate = @UpdatedDate"
                    strSql += " ,DocStatus = @DocStatus"
                    strSql += " WHERE Project_Code = @Project_Code"
                    para.Add("@ProjectName", String.Format("{0}", strName))
                    para.Add("@SearchKey", String.Format("{0}", txtSearchKey.Text.Replace("'", "")))
                    para.Add("@Remark1", String.Format("{0}", txtRemark1.Text.Replace("'", "").ToString))
                    para.Add("@Remark2", String.Format("{0}", txtRemark2.Text.Replace("'", "").ToString))
                    para.Add("@UpdatedUser", pubUserName)
                    para.Add("@UpdatedDate", Now)
                    para.Add("@DocStatus", "W")
                    para.Add("@Project_Code", String.Format("{0}", strCode))
                    da.ExecuteNonQuery(strSql, para)
                    para.Items.Clear()
                    'Command 2
                    Call pubInsertLogfile(da, para, "Edit", "Master Project", strCode, Now, strName)
            End Select
            da.TransCommit()
            Call SaveEffect(Me)
            Call clearData()
            Call showData()
            Call setMenuNormal()
            Call lockcontrol()
        Catch ex As Exception
            da.TransRollback()
            MsgBox("เกิดข้อผิดพลาดระหว่างบันทึกข้อมูล " + vbNewLine + Err.Description, MsgBoxStyle.OkOnly, strWarning)
            Exit Sub
        End Try
        da.Close()
    End Sub
    Sub getRetrieveData(ByVal strCode As String)
        Me.Cursor = Cursors.WaitCursor
        Dim strSql As String = ""
        strCode = "'" & strCode & "'"
        strSql = "Select * From Project With(NoLock)"
        strSql += " Where Project_Code = " & strCode
        Me.dal.Open()
        Dim dt As DataTable = Me.dal.GetData(strSql, "DataList")
        Me.dal.Close()
        If dt.Rows.Count >= 1 Then
            txtCode.Text = dt.Rows(0)("Project_Code").ToString
            txtName.Text = dt.Rows(0)("ProjectName").ToString
            txtSearchKey.Text = dt.Rows(0)("SearchKey").ToString
            txtRemark1.Text = dt.Rows(0)("Remark1").ToString
            txtRemark2.Text = dt.Rows(0)("Remark2").ToString
        Else
            MsgBox("Data not found")
            Call clearData()
        End If
        Me.Cursor = Cursors.Default
        Call setMenuNormal()
        Call lockcontrol()
    End Sub
    Sub setMenuNormal()
        If strAdd = "1" AndAlso pubRegister = "True" Then cmdAddNew.Visible = True Else cmdAddNew.Visible = False
        If strEdit = "1" AndAlso pubRegister = "True" Then cmdEdit.Visible = True Else cmdEdit.Visible = False
        If strDelete = "1" AndAlso pubRegister = "True" Then cmdDelete.Visible = True Else cmdDelete.Visible = False
        If strPrint = "1" Then cmdPrint.Visible = True Else cmdPrint.Visible = False
        cmdClose.Visible = True
        cmdSave.Visible = False
        cmdUndo.Visible = False
        lblStatus.Text = ""
    End Sub
    Sub setMenuAddEdit()
        cmdAddNew.Visible = False
        cmdEdit.Visible = False
        cmdDelete.Visible = False
        cmdPrint.Visible = False
        cmdClose.Visible = False
        cmdSave.Visible = True
        cmdUndo.Visible = True
    End Sub
    Sub setRunningNumber()
        Me.Cursor = Cursors.WaitCursor
        Dim sql As String = "Select * From PrefixNumber With(NoLock) Where PrefixSource = 'Project' and RunType = '0'"
        Me.dal.Open()
        Dim dt As DataTable = Me.dal.GetData(sql, "DataList")
        Me.dal.Close()
        If dt.Rows.Count >= 1 Then
            Dim strFormat As String = "000000000000000"
            strFormat = Mid(strFormat, 1, dt.Rows(0)("RunningLength"))
            txtCode.Text = dt.Rows(0)("PrefixDoc").ToString() & dt.Rows(0)("RunString").ToString() & Format(dt.Rows(0)("RunningNo"), strFormat).ToString()
            txtCode.ReadOnly = True
            txtCode.BackColor = Drawing.Color.PowderBlue
        Else
            txtCode.ReadOnly = False
            txtCode.BackColor = Drawing.Color.White
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Sub showData()
        Dim strSql As String = ""
        Dim strSearchKey As String
        strSearchKey = "'%" & txtSearch.Text.ToString.Trim.Replace("'", "") & "%'"
        If rdoSelectTop.Checked = True Then
            strSql = "Select Top 100"
        Else
            strSql = "Select"
        End If
        strSql += " Project_Code as 'iCode'"
        strSql += " ,ProjectName as 'iName'"
        strSql += " ,SearchKey"
        strSql += " ,DocStatus"
        strSql += " From Project With(NoLock)"
        strSql += " Where"
        If chkCancel.Checked = True Then
            strSql += " DocStatus <> 'C' And"
        End If
        strSql += " (Project_Code Like " & strSearchKey
        strSql += "    Or ProjectName Like " & strSearchKey
        strSql += "    Or SearchKey Like " & strSearchKey & ")"
        strSql += " Order by Project_Code desc"
        Me.dal = New Adapter
        Me.dal.ConnectionInfo = Me.Connection
        Me.dal.Open()
        Me.gridMain.DataSource = Me.dal.GetData(strSql, "DataList")
        Me.dal.Close()
    End Sub
#End Region
#Region "Function"
    Function chkRequestData()
        If txtCode.Text.Length <= 0 OrElse txtName.Text.Length <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Function chkDupplicateData()
        Dim strCode As String = txtCode.Text.Trim
        Dim strName As String = txtName.Text.Trim
        Dim sql As String = ""
        Select Case (lblStatus.Text)
            Case "***Add New***"
                sql = "Select Project_Code From Project With(NoLock) Where Project_Code = '" & strCode & "' Or ProjectName = '" & strName & "'"
            Case "***Edit***"
                sql = "Select Project_Code From Project With(NoLock) Where Project_Code <> '" & strCode & "' And ProjectName = '" & strName & "'"
        End Select
        Try
            Dim para As ParameterList = New ParameterList()
            para.Add("@strCode", String.Format("{0}", strCode))
            para.Add("@strName", String.Format("{0}", strName))

            Me.dal.Open()
            Dim dt As DataTable = Me.dal.GetData(sql, "DataList", para)
            Me.dal.Close()
            If dt.Rows.Count >= 1 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MsgBox("An error occurred during check duplicate data" + vbNewLine + Err.Description, MsgBoxStyle.OkOnly, strWarning)
            Return False
        End Try
    End Function
#End Region
#Region "Grid"
    Private Sub gridMain_RowActivate(ByVal sender As System.Object, ByVal e As Stone.WinUI.AsGridRowActivateEventArgs) Handles gridMain.RowActivate
        If lblStatus.Text <> "" Then Exit Sub
        If txtCode.Text = "" Then
            Me.SelectedRow = e.RowView
            txtCode.Text = e.RowView("iCode")
            txtName.Text = e.RowView("iName")
            If e.RowView("DocStatus").ToString = "C" Then
                lblCancel.Visible = True
            Else
                lblCancel.Visible = False
            End If
            Call getRetrieveData(txtCode.Text)
        End If
        If cmdEdit.Visible = True Then Me.cmdEdit.PerformClick()
    End Sub
    Private Sub gridMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridMain.KeyDown
        If e.KeyCode = Keys.Enter Then
            If lblStatus.Text <> "" Then Exit Sub
            If cmdEdit.Visible = True Then Me.cmdEdit.PerformClick()
        End If
    End Sub
    Private Sub gridMain_RowColorData(ByVal sender As Object, ByVal e As Stone.WinUI.AsGridRowColorEventArgs) Handles gridMain.RowColorData
        If e.RowView("DocStatus").ToString = "C" Then
            e.BackColor = Drawing.Color.LightPink
            e.FillBackColor = True
        End If
    End Sub
    Private Sub gridMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As Stone.WinUI.AsGridRowActivateEventArgs) Handles gridMain.SelectedIndexChanged
        If lblStatus.Text <> "" Then Exit Sub
        Me.SelectedRow = e.RowView
        txtCode.Text = e.RowView("iCode")
        txtName.Text = e.RowView("iName")
        If e.RowView("DocStatus").ToString = "C" Then
            lblCancel.Visible = True
        Else
            lblCancel.Visible = False
        End If
        Call getRetrieveData(txtCode.Text)
    End Sub
#End Region
#Region "Master Control"
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim strMsg As String
        If pubUserLanguage = "en-US" Then strMsg = "Please select an item to edit" Else strMsg = "กรุณาเลือก รายการที่ต้องการแก้ไข"
        If txtCode.Text = "" AndAlso txtName.Text = "" Then MsgBox(strMsg) : Exit Sub
        Call setMenuAddEdit()
        lblStatus.Text = "***Edit***"
        Call unlockControl()
        txtCode.ReadOnly = True
        txtName.Focus()
    End Sub
    Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
        Call setMenuAddEdit()
        Call clearData()
        lblStatus.Text = "***Add New***"
        Call unlockControl()
        Call setRunningNumber()
        If txtCode.Text = "" Then txtCode.Focus() Else txtName.Focus()
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        txtSearch.Focus()
        ToolStrip1.Enabled = False : Me.Cursor = Cursors.WaitCursor
        Call execSaveData()
        ToolStrip1.Enabled = True : Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Call execDeleteData()
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        sRetval(0) = "Project"
        Call modSubFunction.openFormDialog(New ReportMaster)
    End Sub
    Private Sub cmdUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUndo.Click
        Select Case (MsgBox("Unsaved data." & vbNewLine & "Do you want to save data?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton3 + MsgBoxStyle.Information, strWarning))
            Case Microsoft.VisualBasic.MsgBoxResult.Yes
                cmdSave_Click(sender, e)
            Case Microsoft.VisualBasic.MsgBoxResult.No
                Call setMenuNormal()
                Call lockcontrol()
                gridMain.SelectedIndex = 0
                gridMain.Focus()
                gridMain.Select()
                Call clearData()
            Case Microsoft.VisualBasic.MsgBoxResult.Cancel
                txtName.Select()
                txtName.Focus()
        End Select
    End Sub
#End Region
#Region "Other Control"
    Private Sub chkCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCancel.Click
        Call showData()
    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Call showData()
    End Sub
#End Region

    Private Sub linkFilter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkFilter.LinkClicked
        If linkFilter.Text = "Show more Filter" Then
            linkFilter.Text = "Hide more Filter"
            groupFilter.Visible = True
        Else
            linkFilter.Text = "Show more Filter"
            groupFilter.Visible = False
        End If
    End Sub

End Class