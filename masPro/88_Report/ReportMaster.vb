#Region "Import"
Imports System.Data
Imports Stone.WinUI
Imports System.Windows.Forms
Imports DAL
Imports System.IO
Imports System.Data.OleDb
Imports System.Transactions
Imports CrystalDecisions.Shared

#End Region
Public Class ReportMaster
#Region "Dim"
    Dim strPathFile As String = ""
    Dim strSource, strType As String
    Dim strFilter As String = ""
    Dim strWhere As String = ""
    Dim strReport As String = ""
    Dim strFilterCodeFrom As String
    Dim strFilterCodeTo As String
    Dim intZoom As Integer = 100
#End Region

    Private Sub ReportMaster_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ReportMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.O Then
            strPathFile = strPathFile ' "C:\ACChieveTrading_Data\ReportFile\Print\" & txtFileName.Text
            If File.Exists(strPathFile) = True Then
                System.Diagnostics.Process.Start(strPathFile)
            Else
                MsgBox("Not found report")
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub ReportPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strSource = sRetval(0)
        strType = sRetval(1)
        ClarDataMaster()
        If pubUserLanguage = "th-TH" Then
            lblFrom.Text = "ตั้งแต่รหัส :"
            lblTo.Text = "ถึง :"
            Select Case strSource
                Case "Bank"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "ธนาคาร"
                Case "Bank Book"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "สมุดบัญชีเงินฝากธนาคาร"
                Case "Brand"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "ยี่ห้อ"
                Case "Customer"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "ลูกค้า"
                Case "Customer Group"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "กลุ่มลูกค้า"
                Case "Department"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "แผนก"
                Case "Project"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "โครงการ"
                Case "Employee"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "พนักงาน"
                Case "Expenses"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "รหัสค่าใช้จ่าย"
                Case "Income"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "รหัสรายได้"
                Case "Paid Other"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "รหัสค่าใช้จ่ายอื่นๆ"
                Case "Product"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "สินค้า"
                Case "ProductGroup"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "กลุ่มสินค้า"
                Case "Sale Location"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "เขตการขาย"
                Case "Supplier"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "ผู้จำหน่าย"
                Case "Supplier Group"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "กลุ่มผู้จำหน่าย"
                Case "Warehouse"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "คลังสินค้า"
                Case "Office"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "รหัสการเบิกใช้ในกิจการ"
                Case "TypeCash"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "TypeCash"
                Case "PettyCash"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "PettyCash"
                Case "TypeAdvanceCashPay"
                    If pubUserLanguage = "th-TH" Then gHeader.Text = "TypeAdvanceCashPay"
            End Select
        Else
            gHeader.Text = strSource
            lblTo.Text = "To :"
            Select Case strSource
                Case "Bank"
                    lblFrom.Text = "Bank code :"
                Case "Bank Book"
                    lblFrom.Text = "Bank account :"
                Case "Brand"
                    lblFrom.Text = "Brand :"
                Case "Customer"
                    lblFrom.Text = "Customer :"
                Case "Customer Group"
                    lblFrom.Text = "Customer Group :"
                Case "Department"
                    lblFrom.Text = "Department :"
                Case "Project"
                    lblFrom.Text = "Project :"
                Case "Employee"
                    lblFrom.Text = "Employee :"
                Case "Expenses"
                    lblFrom.Text = "Expenses :"
                Case "Income"
                    lblFrom.Text = "Incomes :"
                Case "Paid Other"
                    lblFrom.Text = "Paid Other :"
                Case "Product"
                    lblFrom.Text = "Product :"
                Case "ProductGroup"
                    lblFrom.Text = "Product Group :"
                Case "Sale Location"
                    lblFrom.Text = "Sale Location :"
                Case "Supplier"
                    lblFrom.Text = "Supplier :"
                Case "Supplier Group"
                    lblFrom.Text = "Supplier Group :"
                Case "Warehouse"
                    lblFrom.Text = "Warehouse :"
                Case "Office"
                    lblFrom.Text = "Office :"
                Case "TypeCash"
                    lblFrom.Text = "TypeCash :"
                Case "PettyCash"
                    lblFrom.Text = "PettyCash :"
                Case "TypeAdvanceCashPay"
                    lblFrom.Text = "TypeAdvanceCashPay :"
            End Select
        End If

        If pubRegister = False Then
            CrystalReportViewer1.ShowExportButton = False
            CrystalReportViewer1.ShowPrintButton = False
        End If
    End Sub
    'Private Sub ReportPurchase_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
    '    Select Case e.Delta
    '        Case 120
    '            If intZoom >= 400 Then Exit Sub
    '            intZoom += 10
    '            CrystalReportViewer1.Zoom(intZoom)
    '        Case -120
    '            If intZoom <= 10 Then Exit Sub
    '            intZoom -= 10
    '            CrystalReportViewer1.Zoom(intZoom)
    '    End Select
    'End Sub
    Sub PreviewReport()
        strPathFile = ""
        Select Case strSource
            Case "Bank"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Bank.rpt"
            Case "Bank Book"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_BankBook.rpt"
            Case "Brand"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Brand.rpt"
            Case "Customer"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Customer.rpt"
            Case "Customer Group"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_CustomerGroup.rpt"
            Case "Department"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Department.rpt"
            Case "Project"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Project.rpt"
            Case "Employee"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Employee.rpt"
            Case "Expenses"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Expenses.rpt"
            Case "Income"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Income.rpt"
            Case "Paid Other"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_PaidOther.rpt"
            Case "Product"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Product.rpt"
            Case "ProductGroup"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_ProductGroup.rpt"
            Case "Sale Location"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_SaleLocation.rpt"
            Case "Supplier"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Supplier.rpt"
            Case "Supplier Group"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_SupplierGroup.rpt"
            Case "Warehouse"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Warehouse.rpt"
            Case "Office"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_Office.rpt"
            Case "TypeCash"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_TypeCash.rpt"
            Case "PettyCash"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_PettyCash.rpt"
            Case "TypeAdvanceCashPay"
                strPathFile = pubReportDir & pubUserLanguage & "\Master\Master_TypeAdvanceCashPay.rpt"
        End Select
        If File.Exists(strPathFile) = False Then
            MsgBox("File not found." & vbNewLine & "File name :" & strPathFile)
            Exit Sub
        End If
        reportDocument1.FileName = strPathFile
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        For Each tbCurrent In reportDocument1.Database.Tables
            tliCurrent = tbCurrent.LogOnInfo
            With tliCurrent.ConnectionInfo
                .ServerName = pubServerName
                .DatabaseName = pubDatabaseName
                If pubDbUsername <> "" And pubDbPassword <> "" Then
                    .UserID = pubDbUsername
                    .Password = pubDbPassword
                    .IntegratedSecurity = False
                Else
                    .IntegratedSecurity = True
                End If
            End With
            tbCurrent.ApplyLogOnInfo(tliCurrent)
        Next tbCurrent
        getVariable()
        getParameter()
        CrystalReportViewer1.ParameterFieldInfo = AddParamiter()
        CrystalReportViewer1.ReportSource = reportDocument1
        If Me.Width < 1024 Then CrystalReportViewer1.Zoom(130) Else CrystalReportViewer1.Zoom(1)
    End Sub
    Sub getParameter()
        Dim strFrom As String = "Char(0)"
        Dim strTo As String = "Char(255)"
        If txtFilterCodeFrom.Text <> "" Then strFrom = "'" & Replace(txtFilterCodeFrom.Text, "'", "") & "'"
        If txtFilterCodeTo.Text <> "" Then strTo = "'" & Replace(txtFilterCodeTo.Text, "'", "") & "'"

        strFilter = ""
        If pubUserLanguage = "en-US" Then
            If strFrom = "Char(0)" AndAlso strTo <> "Char(255)" Then
                strFilter += "From beginning - to :" & strTo
            ElseIf strFrom <> "Char(0)" AndAlso strTo = "Char(255)" Then
                strFilter += "From :" & strFrom & " to end"
            ElseIf strFrom <> "Char(0)" AndAlso strTo <> "Char(255)" Then
                strFilter += "From :" & strFrom & " to :" & strTo
            End If
        Else
            If strFrom = "Char(0)" AndAlso strTo <> "Char(255)" Then
                strFilter += "ตั้งแต่เริ่มต้น จนถึง :" & strTo
            ElseIf strFrom <> "Char(0)" AndAlso strTo = "Char(255)" Then
                strFilter += "ตั้งแต่รหัส :" & strFrom & " ถึงสุดท้าย"
            ElseIf strFrom <> "Char(0)" AndAlso strTo <> "Char(255)" Then
                strFilter += "ตั้งแต่รหัส :" & strFrom & " ถึง :" & strTo
            End If
        End If


        Select Case strSource
            Case "Bank"
                strWhere = " Where (a.Bank_Code Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Bank Book"
                strWhere = " Where (a.BankBook_Code Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Brand"
                strWhere = " Where (a.Brand_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Customer"
                strWhere = " Where (a.Cus_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Customer Group"
                strWhere = " Where (a.CustomerGroup_Code Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Department"
                strWhere = " Where (a.Department_Code Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Project"
                strWhere = " Where (a.Project_Code Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Employee"
                strWhere = " Where (a.Emp_Code Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Expenses"
                strWhere = " Where (a.Expenses_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Income"
                strWhere = " Where (a.Income_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Paid Other"
                strWhere = " Where (a.PaidOther_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Product"
                strWhere = " Where (a.Prod_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "ProductGroup"
                strWhere = " Where (a.ProdGroup_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Sale Location"
                strWhere = " Where (a.SaleLocation_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Supplier"
                strWhere = " Where (a.Sup_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Supplier Group"
                strWhere = " Where (a.SupplierGroup_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Warehouse"
                strWhere = " Where (a.Warehouse_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "Office"
                strWhere = " Where (a.Office_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "TypeCash"
                strWhere = " Where (a.TypeCash_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "PettyCash"
                strWhere = " Where (a.PettyCash_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
            Case "TypeAdvanceCashPay"
                strWhere = " Where (a.AdvanceCashType_Code  Between " & strFilterCodeFrom & " And " & strFilterCodeTo & ")"
        End Select
        strWhere += " And a.DocStatus<>'C'"
    End Sub
    Sub ClarDataMaster()
        txtFilterCodeFrom.Text = ""
        txtFilterNameFrom.Text = ""
        txtFilterCodeTo.Text = ""
        txtFilterNameTo.Text = ""
        CrystalReportViewer1.ReportSource = Nothing
    End Sub
    Function AddParamiter() As ParameterFields
        Dim pfs As New ParameterFields
        'Parameter ตัวที่ 1
        Dim pdv1 As New ParameterDiscreteValue
        Dim pdv2 As New ParameterDiscreteValue
        Dim pdv3 As New ParameterDiscreteValue
        Dim pdv4 As New ParameterDiscreteValue
        Dim pdv5 As New ParameterDiscreteValue
        Dim pdv6 As New ParameterDiscreteValue
        Dim pdv7 As New ParameterDiscreteValue
        Dim pdv8 As New ParameterDiscreteValue
        Dim pf1 As New ParameterField
        Dim pf2 As New ParameterField
        Dim pf3 As New ParameterField
        Dim pf4 As New ParameterField
        Dim pf5 As New ParameterField
        Dim pf6 As New ParameterField
        Dim pf7 As New ParameterField
        Dim pf8 As New ParameterField
        pf1.ParameterFieldName = "@ComName"
        pf2.ParameterFieldName = "@PrintDate"
        pf3.ParameterFieldName = "@PathFile"
        pf4.ParameterFieldName = "@strWhere"
        pf5.ParameterFieldName = "@strDateFrom"
        pf6.ParameterFieldName = "@strDateTo"
        pf7.ParameterFieldName = "@strFilter"
        pf8.ParameterFieldName = "@Type"
        pdv1.Value = pubCompanyName
        pdv2.Value = Now
        pdv3.Value = strPathFile.Substring(0, 6) & "....\" & Path.GetFileName(strPathFile)
        pdv4.Value = strWhere
        pdv5.Value = SQL_FormatDate(Now)
        pdv6.Value = SQL_FormatDate(Now)
        pdv7.Value = strFilter
        pdv8.Value = strType
        pf1.CurrentValues.Add(pdv1)
        pf2.CurrentValues.Add(pdv2)
        pf3.CurrentValues.Add(pdv3)
        pf4.CurrentValues.Add(pdv4)
        pf5.CurrentValues.Add(pdv5)
        pf6.CurrentValues.Add(pdv6)
        pf7.CurrentValues.Add(pdv7)
        pf8.CurrentValues.Add(pdv8)
        pfs.Add(pf1)
        pfs.Add(pf2)
        pfs.Add(pf3)
        pfs.Add(pf4)
        pfs.Add(pf5)
        pfs.Add(pf6)
        pfs.Add(pf7)
        pfs.Add(pf8)
        Return pfs
    End Function
    Sub getVariable()
        If txtFilterCodeFrom.Text = "" Then strFilterCodeFrom = "Char(0)" Else strFilterCodeFrom = "'" & Replace(txtFilterCodeFrom.Text, "'", "") & "'"
        If txtFilterCodeTo.Text = "" Then strFilterCodeTo = "Char(255)" Else strFilterCodeTo = "'" & Replace(txtFilterCodeTo.Text, "'", "") & "'"
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Me.Cursor = Cursors.WaitCursor : gHeader.Enabled = False
        Call PreviewReport()
        gHeader.Enabled = True : Me.Cursor = Cursors.Default
    End Sub
    Private Sub cmdFilterFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterFrom.Click
        sRetval(0) = txtFilterCodeFrom.Value
        Select Case strSource
            'Case "Bank"
            '    Call modSubFunction.openFormDialog(New searchBank)
            'Case "Bank Book"
            '    Call modSubFunction.openFormDialog(New searchBankBook)
            'Case "Customer"
            '    Call modSubFunction.openFormDialog(New searchCustomer)
            'Case "Customer Group"
            '    Call modSubFunction.openFormDialog(New searchCustomerGroup)
            'Case "Department"
            '    Call modSubFunction.openFormDialog(New searchDepartment)
            'Case "Project"
            '    Call modSubFunction.openFormDialog(New searchProject)
            'Case "Employee"
            '    Call modSubFunction.openFormDialog(New searchEmployee)
            'Case "Expenses"
            '    Call modSubFunction.openFormDialog(New searchExpenses)
            'Case "Income"
            '    Call modSubFunction.openFormDialog(New searchIncome)
            'Case "Paid Other"
            '    Call modSubFunction.openFormDialog(New searchPaidOther)
            'Case "Product"
            '    Call modSubFunction.openFormDialog(New searchProduct) '----
            'Case "ProductGroup"
            '    Call modSubFunction.openFormDialog(New searchProductGroup)
            'Case "Supplier"
            '    Call modSubFunction.openFormDialog(New searchSupplier)
            'Case "Supplier Group"
            '    Call modSubFunction.openFormDialog(New searchSupplierGroup)
            'Case "Warehouse"
            '    Call modSubFunction.openFormDialog(New searchWarehouse)
            'Case "Office"
            '    Call modSubFunction.openFormDialog(New searchOffice)
        End Select

        txtFilterCodeFrom.Text = sRetval(0)
        txtFilterNameFrom.Text = sRetval(1)
        If txtFilterCodeTo.Text = "" Then
            txtFilterCodeTo.Text = sRetval(0)
            txtFilterNameTo.Text = sRetval(1)
        End If
        resetsRetval()
    End Sub
    Private Sub txtFilterCodeFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFilterCodeFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call cmdFilterFrom_Click(sender, e)
        End If
    End Sub
    Private Sub txtFilterCodeFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilterCodeFrom.TextChanged
        If txtFilterCodeFrom.Text = "" Then txtFilterNameFrom.Text = ""
    End Sub
    Private Sub cmdFilterTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterTo.Click
        sRetval(0) = txtFilterCodeTo.Value
        Select Case strSource
            'Case "Bank"
            '    Call modSubFunction.openFormDialog(New searchBank)
            'Case "Bank Book"
            '    Call modSubFunction.openFormDialog(New searchBankBook)
            'Case "Customer"
            '    Call modSubFunction.openFormDialog(New searchCustomer)
            'Case "Customer Group"
            '    Call modSubFunction.openFormDialog(New searchCustomerGroup)
            'Case "Department"
            '    Call modSubFunction.openFormDialog(New searchDepartment)
            'Case "Project"
            '    Call modSubFunction.openFormDialog(New searchProject)
            'Case "Employee"
            '    Call modSubFunction.openFormDialog(New searchEmployee)
            'Case "Expenses"
            '    Call modSubFunction.openFormDialog(New searchExpenses)
            'Case "Income"
            '    Call modSubFunction.openFormDialog(New searchIncome)
            'Case "Paid Other"
            '    Call modSubFunction.openFormDialog(New searchPaidOther)
            'Case "Product"
            '    Call modSubFunction.openFormDialog(New searchProduct) '----
            'Case "ProductGroup"
            '    Call modSubFunction.openFormDialog(New searchProductGroup)
            'Case "Supplier"
            '    Call modSubFunction.openFormDialog(New searchSupplier)
            'Case "Supplier Group"
            '    Call modSubFunction.openFormDialog(New searchSupplierGroup)
            'Case "Warehouse"
            '    Call modSubFunction.openFormDialog(New searchWarehouse)

        End Select
        txtFilterCodeTo.Text = sRetval(0)
        txtFilterNameTo.Text = sRetval(1)
        resetsRetval()
    End Sub
    Private Sub txtFilterCodeTo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFilterCodeTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call cmdFilterTo_Click(sender, e)
        End If
    End Sub
    Private Sub txtFilterCodeTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilterCodeTo.TextChanged
        If txtFilterCodeTo.Text = "" Then txtFilterNameTo.Text = ""
    End Sub

End Class