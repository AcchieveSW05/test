#Region "Import"
Imports System.Data
Imports Stone.WinUI
Imports System.Windows.Forms
Imports DAL
Imports System.IO
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Globalization
Imports CrystalDecisions.Shared
Imports System.Management
Imports System.Drawing.Printing
'Imports WebSupergoo.ABCpdf8
'Imports WebSupergoo.ABCpdf8.Objects
'Imports WebSupergoo.ABCpdf8.Atoms
'Imports WebSupergoo.ABCpdf8.Operations
Imports CrystalDecisions.CrystalReports.Engine



#End Region
Public Class frmPrintMaster2
    Dim strSourceForm As String
    Dim mnForm As String
    Dim strDocNumber As String
    Dim strCancel As String
    Dim strPathFile As String
    Dim strDirectoryFilePrint As String
    Dim strReportName As String
    Dim strReportNameSaleDp As String
    Dim dHalfSize As Integer = 0
    Dim cboPrinterLoad As Boolean = False
    Dim sReportName As String
    Dim chkcbo As String = ""
    Private Sub frmPrintMaster_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' Me.Dispose()
        CrystalReportViewer1.ReportSource = Nothing
    End Sub
    Private Sub frmPrintMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.Control And e.KeyCode = Keys.P) Or e.KeyCode = Keys.F9 Then
            If pubRegister = True And strCancel <> "C" Then
                cmdPrint.PerformClick()
            End If
        End If
        If e.Control And e.KeyCode = Keys.O Then
            strPathFile = strDirectoryFilePrint & cboFileName.SelectedValue.ToString
            If File.Exists(strPathFile) = True Then
                System.Diagnostics.Process.Start(strPathFile)
            End If
        End If
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub frmPrintMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.TopMost = True
        cboPrinterLoad = False
        Me.Refresh()
        Dim strHeader As String = ""
        Me.Connection = New DAL.ConnectionInfo()
        Me.Connection.SetConnectionString(pubServerName, pubDatabaseName, pubDbUsername, pubDbPassword)
        Me.dal = New Adapter
        Me.dal.ConnectionInfo = Me.Connection
        chkcbo = "0"
        If pubComBranch_Code = "" Then
            pubComBranch_Code = "00000"
        End If
        strDocNumber = sRetval(0)
        strSourceForm = sRetval(1)
        strCancel = sRetval(2)
        mnForm = sRetval(3)
        gbReport.Visible = False
        lblChangeReport.Visible = True

        Select Case strSourceForm
            Case "Quotation"
                If pubUserLanguage = "en-US" Then strHeader = "Quotation" Else strHeader = "ใบเสนอราคา"
            Case "SaleOrder"
                If pubUserLanguage = "en-US" Then strHeader = "Sale order" Else strHeader = "ใบสั่งขายสินค้า"
            Case "SaleDeposit"
                If pubUserLanguage = "en-US" Then strHeader = "Sale deposit" Else strHeader = "ใบรับเงินล่วงหน้า"
            Case "CnSaleDeposit"
                If pubUserLanguage = "en-US" Then strHeader = "CN Sale deposit" Else strHeader = "ใบคืนเงินรับล่วงหน้า"
            Case "SaleCash", "SaleCash1", "SaleCash2", "SaleCash3", "SaleCash4", "SaleCash5"
                If pubUserLanguage = "en-US" Then strHeader = "Sale by cash" Else strHeader = "ใบขายสินค้า (เงินสด)"
            Case "SaleCredit", "SaleCredit1", "SaleCredit2", "SaleCredit3", "SaleCredit4", "SaleCredit5"
                If pubUserLanguage = "en-US" Then strHeader = "Sale by credit" Else strHeader = "ใบขายสินค้า (เงินเชื่อ)"
            Case "SaleService"
                If pubUserLanguage = "en-US" Then strHeader = "Sale Service (VAT suspense)" Else strHeader = "ใบแจ้งหนี้ค่าบริการ"
            Case "CnSale"
                If pubUserLanguage = "en-US" Then strHeader = "CN Sale" Else strHeader = "ใบรับคืนสินค้า/ลดหนี้ลูกหนี้"
            Case "DnSale"
                If pubUserLanguage = "en-US" Then strHeader = "DN Sale" Else strHeader = "ใบเพิ่มหนี้ลูกหนี้"
            Case "POS"
                If pubUserLanguage = "en-US" Then strHeader = "Print invoice (from POS)" Else strHeader = "ใบกำกับภาษี(POS)อย่างย่อ"
            Case "PosInvoice"
                If pubUserLanguage = "en-US" Then strHeader = "Print invoice (from POS)" Else strHeader = "ใบกำกับภาษีเต็มรูปแบบ(POS)"
            Case "AdvanceReceipt"
                If pubUserLanguage = "en-US" Then strHeader = "Received (no matched invoice)" Else strHeader = "ใบรับเงินชำระหนี้ล่วงหน้า"
            Case "CnAdvanceReceipt"
                If pubUserLanguage = "en-US" Then strHeader = "CN Receipt (no matched invoice)" Else strHeader = "ใบคืน เงินรับชำระหนี้ล่วงหน้า"
            Case "Bill"
                If pubUserLanguage = "en-US" Then strHeader = "Billing to customer" Else strHeader = "ใบวางบิล"
            Case "Receipt"
                If pubUserLanguage = "en-US" Then strHeader = "Receipt" Else strHeader = "ใบรับชำระหนี้"
            Case "ReceiptService"
                If pubUserLanguage = "en-US" Then strHeader = "Receipt (sale service)" Else strHeader = "ใบรับชำระหนี้ ค่าบริการ"
            Case "Pr"
                If pubUserLanguage = "en-US" Then strHeader = "Purchase requisition" Else strHeader = "ใบขออนุมัติซื้อ"
            Case "PurchaseOrder"
                If pubUserLanguage = "en-US" Then strHeader = "Purchase order" Else strHeader = "ใบสั่งซื้อสินค้า"
            Case "PurchaseDeposit"
                If pubUserLanguage = "en-US" Then strHeader = "Purchase deposit" Else strHeader = "ใบจ่ายเงินล่วงหน้า"
            Case "CnPurchaseDeposit"
                If pubUserLanguage = "en-US" Then strHeader = "CN Purchase deposit" Else strHeader = "ใบคืนเงินจ่ายล่วงหน้า"
            Case "PurchaseCash", "PurchaseCash2", "PurchaseCash3", "PurchaseCash4", "PurchaseCash5"
                If pubUserLanguage = "en-US" Then strHeader = "Purchase by cash" Else strHeader = "ใบซื้อสินค้า(เงินสด)"
            Case "PurchaseCredit", "PurchaseCredit2", "PurchaseCredit3", "PurchaseCredit4", "PurchaseCredit5"
                If pubUserLanguage = "en-US" Then strHeader = "Purchase by credit" Else strHeader = "ใบซื้อสินค้า(เงินเชื่อ)"
            Case "PurchaseService"
                If pubUserLanguage = "en-US" Then strHeader = "Purchase service (VAT suspense)" Else strHeader = "รายจ่ายค่าบริการ"
            Case "CnPurchase"
                If pubUserLanguage = "en-US" Then strHeader = "CN Purchase" Else strHeader = "ใบลดหนี้จากการส่งคืนสินค้า"
            Case "DnPurchase"
                If pubUserLanguage = "en-US" Then strHeader = "DN Purchase" Else strHeader = "ใบเพิ่มหนี้เจ้าหนี้"
            Case "AdvancePayment"
                If pubUserLanguage = "en-US" Then strHeader = "Payment (no matched invoice)" Else strHeader = "ใบจ่ายชำระหนี้ล่วงหน้า"
            Case "CnAdvancePayment"
                If pubUserLanguage = "en-US" Then strHeader = "CN Payment (no matched invoice)" Else strHeader = "ใบคืน เงินจ่ายชำระหนี้ล่วงหน้า"
            Case "WaitPayment"
                If pubUserLanguage = "en-US" Then strHeader = "Billing from supplier" Else strHeader = "ใบรับวางบิล (รอจ่ายชำระหนี้)"
            Case "Payment"
                If pubUserLanguage = "en-US" Then strHeader = "Payment" Else strHeader = "ใบจ่ายชำระหนี้"
            Case "PaymentService"
                If pubUserLanguage = "en-US" Then strHeader = "Payment (purchase service)" Else strHeader = "ใบจ่ายชำระหนี้ ค่าบริการ"
            Case "Irl"
                If pubUserLanguage = "en-US" Then strHeader = "Inventory relocation" Else strHeader = "ใบปรับ การโอนย้ายสินค้าระหว่างคลัง"
            Case "Iov"
                If pubUserLanguage = "en-US" Then strHeader = "Inventory adjustment(+)" Else strHeader = "ใบรับ เพื่อปรับเพิ่มสต๊อก"
            Case "Ist"
                If pubUserLanguage = "en-US" Then strHeader = "Inventory adjustment(-)" Else strHeader = "ใบเบิก เพื่อปรับลดสต๊อก"
            Case "Iof"
                If pubUserLanguage = "en-US" Then strHeader = "Inventory office use" Else strHeader = "ใบเบิก ใช้ในกิจการ"
            Case "Irtof"
                If pubUserLanguage = "en-US" Then strHeader = "Inventory return (office use)" Else strHeader = "ใบรับคืน จากการเบิกใช้ในกิจการ "
            Case "OrderExpenses"
                If pubUserLanguage = "en-US" Then strHeader = "Other Expenses (Order)" Else strHeader = "ใบรอจ่าย ค่าใช้จ่ายอื่นๆ"
            Case "OtherExpenses"
                If pubUserLanguage = "en-US" Then strHeader = "Other Expenses" Else strHeader = "ใบบันทึก ค่าใช้จ่ายอื่นๆ"
            Case "OrderIncome"
                If pubUserLanguage = "en-US" Then strHeader = "Other income (Order)" Else strHeader = "ใบรอรับ รายได้อื่นๆ"
            Case "OtherIncome"
                If pubUserLanguage = "en-US" Then strHeader = "Other income" Else strHeader = "ใบบันทึก รายได้อื่นๆ"
            Case "PettyCash"
                If pubUserLanguage = "en-US" Then strHeader = "Petty Cash" Else strHeader = "ใบบันทึก เงินสดย่อย"
            Case "Usp"
                If pubUserLanguage = "en-US" Then strHeader = "Sale price change" Else strHeader = "เปลี่ยนราคาขายสินค้า"
            Case "BankTransfer"
                If pubUserLanguage = "en-US" Then strHeader = "Bank transfer" Else strHeader = "บันทึกฝาก / ถอนเงินธนาคาร"
            Case "CheckStock"
                If pubUserLanguage = "en-US" Then strHeader = "Physical counting(Prepare)" Else strHeader = "ใบตรวจนับสต็อกสินค้า(เตรียมข้อมูล)"
            Case "CheckStock2"
                If pubUserLanguage = "en-US" Then strHeader = "Physical counting(Record)" Else strHeader = "ใบตรวจนับสต็อกสินค้า(บันทึกข้อมูล)"
            Case "CheckStock3"
                If pubUserLanguage = "en-US" Then strHeader = "Physical counting(Verify)" Else strHeader = "ใบตรวจนับสต็อกสินค้า(ตรวจสอบข้อมูล)"
            Case "BfProduct"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Inventory" Else strHeader = "ใบบันทึกยกมา สินค้า"
            Case "BfCustomer"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Trade receivable" Else strHeader = "ใบบันทึกยกมา ลูกหนี้การค้า"
            Case "BfSupplier"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Trade payable" Else strHeader = "ใบบันทึกยกมา เจ้าหนี้การค้า"
            Case "BfCustomerService"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Service receivable(VAT suspense)" Else strHeader = "ใบบันทึกยกมา ลูกหนี้ค่าบริการ"
            Case "BfSupplierService"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Service payable(VAT suspense)" Else strHeader = "ใบบันทึกยกมา เจ้าหนี้ค่าบริการ"
            Case "BfSaleDeposit"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Sale deposit" Else strHeader = "ใบบันทึกยกมา ใบรับเงินมัดจำ"
            Case "BfPurchaseDeposit"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Purchase deposit" Else strHeader = "ใบบันทึกยกมา ใบจ่ายเงินมัดจำ"
            Case "BfBankBook"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Bank account" Else strHeader = "ใบบันทึกยกมา สมุดบัญชีเงินฝากธนาคาร"
            Case "BfPurchaseVAT"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Purchase VAT" Else strHeader = "ใบบันทึกยกมา ภาษีซื้อ"
            Case "BfChequePaid"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Cheque paid" Else strHeader = "ใบบันทึกยกมา เช็คจ่าย"
            Case "BfChequeReceived"
                If pubUserLanguage = "en-US" Then strHeader = "Beginning balance-Cheque received" Else strHeader = "ใบบันทึกยกมา เช็ครับ"
            Case "ReceiptProduct"
                If pubUserLanguage = "en-US" Then strHeader = "Received product" Else strHeader = "ใบรับบันทึกรับสินค้า"
            Case "ReNewInvoice"
                If pubUserLanguage = "en-US" Then strHeader = "Renew invoice" Else strHeader = "ยกเลิกและออกใบกำกับภาษีแทน"
            Case "UpdateSalePrice"
                If pubUserLanguage = "en-US" Then strHeader = "Sale price changes" Else strHeader = "ใบเปลี่ยนราคาขายสินค้า"
            Case "ChequePassPaid"
                If pubUserLanguage = "en-US" Then strHeader = "Cheque paid-deducted from bank account" Else strHeader = "รายการผ่านเช็คจ่าย"
            Case "ChequePassReceipt"
                If pubUserLanguage = "en-US" Then strHeader = "Cheque received-added to bank account" Else strHeader = "รายการผ่านเช็ครับ"
            Case "SaleOrderCancel"
                If pubUserLanguage = "en-US" Then strHeader = "Cancel remaining sale order" Else strHeader = "ยกเลิกใบสั่งขายค้างส่ง"
            Case "PurchaseOrderCancel"
                If pubUserLanguage = "en-US" Then strHeader = "Cancel remaining purchase order" Else strHeader = "ยกเลิกใบสั่งซื้อค้างรับ"
            Case "BillService"
                If pubUserLanguage = "en-US" Then strHeader = "Bill Service to customer" Else strHeader = "ใบวางบิล ค่าบริการ"
            Case "WaitPaymentService"
                If pubUserLanguage = "en-US" Then strHeader = "Bill Service to supplier" Else strHeader = "ใบรับวางบิล รายจ่ายค่าบริการ"
            Case "LandedCost"
                If pubUserLanguage = "en-US" Then strHeader = "LandedCost" Else strHeader = "บันส่วนต้นทุน"
            Case "BarCode"
                If pubUserLanguage = "en-US" Then strHeader = "Barcode" Else strHeader = "Barcode"
            Case "PettyCashSetup"
                If pubUserLanguage = "en-US" Then strHeader = "PettyCash Setup" Else strHeader = "ตั้งวงเงินสดย่อย"
            Case "PettyCashCompensate"
                If pubUserLanguage = "en-US" Then strHeader = "PettyCashCompensate" Else strHeader = "ชดเชยเงินสดย่อย"
            Case "PettyCashCancel"
                If pubUserLanguage = "en-US" Then strHeader = "PettyCashCancel" Else strHeader = "ยกเลิกเงินสดย่อย"
            Case "AdvanceCashPay"
                If pubUserLanguage = "en-US" Then strHeader = "AdvanceCashPay" Else strHeader = "จ่ายเงินยืมทดรองจ่าย"
            Case "AdvanceCashClear"
                If pubUserLanguage = "en-US" Then strHeader = "AdvanceCashClear" Else strHeader = "เคลียร์เงินยืมทดรองจ่าย"
            Case "AdvanceCashReceipt"
                If pubUserLanguage = "en-US" Then strHeader = "AdvanceCashReceipt" Else strHeader = "รับคืนเงินยืมทดรองจ่าย (เต็มจำนวน)"
            Case Else
                '    strHeader = "" : MsgBox("file not found") : Me.Close()
        End Select
        If strSourceForm = "SaleCash" OrElse strSourceForm = "SaleCredit" _
             OrElse strSourceForm = "SaleCash1" OrElse strSourceForm = "SaleCredit1" _
             OrElse strSourceForm = "SaleCash2" OrElse strSourceForm = "SaleCredit2" _
             OrElse strSourceForm = "SaleCash3" OrElse strSourceForm = "SaleCredit3" _
             OrElse strSourceForm = "SaleCash4" OrElse strSourceForm = "SaleCredit4" _
             OrElse strSourceForm = "SaleCash5" OrElse strSourceForm = "SaleCredit5" Then

            gMaster.Height = 90
            rdoPrintSale0.Visible = True
            rdoPrintSale1.Visible = True
            cboFileName.Visible = True
            cboFileNameDp.Visible = False
            Call getReportFileSaleDP()
        Else
            gMaster.Height = 90
            rdoPrintSale0.Visible = False
            rdoPrintSale1.Visible = False
            cboFileName.Visible = True
            cboFileNameDp.Visible = False
        End If
        rdoPrintSale0.Checked = True
        gMaster.Text = strHeader
        Me.Text = strHeader

        If File.Exists(dirRoot & "\PrintSlip.idg") = True Then
            Dim rd As StreamReader = File.OpenText(dirRoot & "\PrintSlip.idg")
            pubPrinterSlip = rd.ReadLine
            pubSlipPaperSize = rd.ReadLine
            strDirectoryFilePrint = rd.ReadLine
            pubDefaultPrinter = rd.ReadLine
            pubDefaultPrinter = rd.ReadLine
            rd.Close()
            If Directory.Exists(strDirectoryFilePrint) = True Then
                strDirectoryFilePrint = strDirectoryFilePrint & "\"
            Else
                strDirectoryFilePrint = "C:\0_Indigo\" & pubProjectName & "\4_TransectionPrintForm\"
            End If

            If pubDefaultPrinter Is Nothing OrElse pubDefaultPrinter = "" OrElse pubDefaultPrinter = "NoPrinter" Then
                Call getPrintList()
            Else
                cboPrinter.Items.Clear()
                cboPrinter.Items.Add(pubDefaultPrinter)
                cboPrinter.SelectedIndex = 0
            End If
        Else
            strDirectoryFilePrint = "C:\0_Indigo\" & pubProjectName & "\4_TransectionPrintForm\"
        End If
        Try
            Call getcboReportFile()
            Call PreviewReport()
            '  CrystalReportViewer1.ReportSource = Nothing
            If pubRegister = False Or strCancel = "C" Then
                cmdPrint.Visible = False
                CrystalReportViewer1.ShowExportButton = False
                CrystalReportViewer1.ShowPrintButton = False
            Else
                cmdPrint.Visible = True
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
        chkcbo = "1"
    End Sub
    Sub getPrintList()
        Try
            cboPrinter.Items.Clear()
            Dim searchQuery As String = "Select * FROM Win32_Printer "
            Dim searchPrinters As New ManagementObjectSearcher(searchQuery)
            Dim printerCollection As ManagementObjectCollection = searchPrinters.Get()
            Dim printer As ManagementObject
            For Each printer In printerCollection
                cboPrinter.Items.Add(printer.Properties("Name").Value.ToString())
            Next
            Dim ps As New PrinterSettings
            cboPrinter.SelectedItem = ps.PrinterName.ToString
            'cmdPrint.Enabled = True
        Catch ex As Exception
            'MsgBox("No printer.")
            'cmdPrint.Enabled = False
        End Try
    End Sub
    Sub getcboReportFile()
        Try
            Dim strFile As String = ""
            Dim dt As DataTable

            Dim sql As String
            sql = "Select ReportName,DefaultReportName,CaptionTh From MasterReportList With(NoLock) Where DocSourceName='" & strSourceForm & "' And ComBranch_Code ='" & pubComBranch_Code & "'"
            Me.dal.Open()
            dt = Me.dal.GetData(sql, "DataList")
            Me.dal.Close()
            If dt.Rows.Count > 0 Then
                gMaster.Text = dt.Rows(0)("CaptionTh").ToString
                Me.Text = dt.Rows(0)("CaptionTh").ToString
                strFile = dt.Rows(0)("ReportName").ToString
                sql = "Select DefaultReportName From MasterReportList With(NoLock) Where DocSourceName='" & strSourceForm & "' And ComBranch_Code ='" & pubComBranch_Code & "'"
                cboFileName.DataSource = pubGetData(Me.dal, sql, "XXX")
                cboFileName.ValueMember = "DefaultReportName"
                cboFileName.DisplayMember = "DefaultReportName"
                If File.Exists(strDirectoryFilePrint & strFile) = True Then
                    cboFileName.SelectedValue = strFile.ToString
                    strReportName = strFile
                Else
                    dt = New DataTable
                    sql = "Select DefaultReportName From MasterReportList With(NoLock) Where DocSourceName='" & strSourceForm & "' And DefaultStatus = 1 And ComBranch_Code ='" & pubComBranch_Code & "'"
                    Me.dal.Open()
                    dt = Me.dal.GetData(sql, "DataList")
                    Me.dal.Close()
                    If dt.Rows.Count = 1 Then strReportName = dt.Rows(0)("DefaultReportName").ToString
                    cboFileName.SelectedValue = strReportName.ToString

                End If
            Else
                MsgBox("ยังไม่ได้ตั้งค่าแบบฟอร์ม") : Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex)
            Exit Sub
        End Try
    End Sub
    Sub getReportFile()
        Try
            Dim dt As DataTable
            Dim sql As String
            Dim strFile As String = ""
            sql = "Select MasReportName,DefaultFileName From MasterReport With(NoLock) Where DocSourceName='" & strSourceForm & "' And ComBranch_Code ='" & pubComBranch_Code & "'"
            sql += " And ComBranch_Code ='" & pubComBranch_Code & "'"
            Me.dal.Open()
            dt = Me.dal.GetData(sql, "DataList")
            Me.dal.Close()
            If dt.Rows.Count = 1 Then strFile = dt.Rows(0)("MasReportName").ToString : txtFileName.Text = dt.Rows(0)("MasReportName").ToString
            If File.Exists(strDirectoryFilePrint & strFile) = True Then
                txtFileName.Text = strFile
                strReportName = strFile
            Else
                If dt.Rows.Count = 1 Then strReportName = dt.Rows(0)("DefaultFileName").ToString
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub getReportFileSaleDP()
        Try
            Dim strFile As String = ""
            Dim dt As DataTable

            Dim sql As String
            sql = "Select ReportName,DefaultReportName From MasterReportList With(NoLock) Where DocSourceName='SaleDp' And ComBranch_Code ='" & pubComBranch_Code & "'"
            Me.dal.Open()
            dt = Me.dal.GetData(sql, "DataList")
            Me.dal.Close()
            If dt.Rows.Count > 0 Then
                strFile = dt.Rows(0)("ReportName").ToString
                sql = "Select DefaultReportName From MasterReportList With(NoLock) Where DocSourceName='SaleDp' And ComBranch_Code ='" & pubComBranch_Code & "'"
                cboFileNameDp.DataSource = pubGetData(Me.dal, sql, "XXX")
                cboFileNameDp.ValueMember = "DefaultReportName"
                cboFileNameDp.DisplayMember = "DefaultReportName"

                If File.Exists(strDirectoryFilePrint & strFile) = True Then
                    cboFileNameDp.SelectedValue = strFile.ToString
                    strReportNameSaleDp = strFile
                Else
                    dt = New DataTable
                    sql = "Select DefaultReportName From MasterReportList With(NoLock) Where DocSourceName='SaleDp' And DefaultStatus = 1 And ComBranch_Code ='" & pubComBranch_Code & "'"
                    Me.dal.Open()
                    dt = Me.dal.GetData(sql, "DataList")
                    Me.dal.Close()
                    If dt.Rows.Count = 1 Then strReportNameSaleDp = dt.Rows(0)("DefaultReportName").ToString
                    cboFileNameDp.SelectedValue = strReportNameSaleDp.ToString

                End If
            Else
                MsgBox("ยังไม่ได้ตั้งค่าแบบฟอร์ม") : Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex)
            Exit Sub
        End Try
    End Sub
    Sub PrintCounter(ByVal strUser As String)
        Dim da As New DAL.Adapter
        Dim bufDt As DataTable
        Dim para As New ParameterList
        da.ConnectionInfo = Me.Connection
        da.Open()
        da.TransBegin()
        Dim strSql As String
        strSql = "Select * From PrintCounter With(Nolock) Where DocSource='" & strSourceForm & "' And DocNumber='" & strDocNumber & "'"
        bufDt = pubGetData(Me.dal, strSql, "PrintCounter")
        bufDt.TableName = "PrintCounter"
        Try
            If bufDt.Rows.Count = 0 Then
                Dim newRows As DataRow = bufDt.NewRow
                newRows("DocSource") = strSourceForm
                newRows("DocNumber") = strDocNumber
                newRows("PrintCount") = 1
                bufDt.Rows.Add(newRows)
            ElseIf bufDt.Rows.Count = 1 Then
                bufDt.Rows(0)("PrintCount") = bufDt.Rows(0)("PrintCount") + 1
            End If
            da.UpdateData(bufDt)
            pubInsertLogfile(da, para, "Print", strSourceForm, strDocNumber, Now, "")

            strSql = "Insert Into SysLogFile (SysLogFileDate, UserAction, DocSource, DocNumber, DocDate, DocRemark, CreatedUser) "
            strSql += " Values ( @SysLogFileDate, @UserAction, @DocSource, @DocNumber, @DocDate, @DocRemark, @CreatedUser)"
            para.Add("@SysLogFileDate", Now)
            para.Add("@UserAction", String.Format("{0}", "Print"))
            para.Add("@DocSource", strSourceForm)
            para.Add("@DocNumber", strDocNumber)
            para.Add("@DocDate", Now)
            para.Add("@DocRemark", "")
            para.Add("@CreatedUser", strUser)
            da.ExecuteNonQuery(strSql, para)
            para.Items.Clear()
            da.TransCommit()
        Catch ex As Exception
            da.TransRollback()
        End Try
    End Sub

    Sub PreviewReport()
        If rdoPrintSale1.Checked = True Then
            strPathFile = strDirectoryFilePrint & cboFileNameDp.SelectedValue.ToString
        Else
            strPathFile = strDirectoryFilePrint & cboFileName.SelectedValue.ToString
        End If
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

        Dim pfs As New ParameterFields
        Dim pdv1 As New ParameterDiscreteValue
        Dim pf1 As New ParameterField
        pf1.ParameterFieldName = "@strDocNumber"
        pdv1.Value = strDocNumber
        pf1.CurrentValues.Add(pdv1)
        pfs.Add(pf1)
        CrystalReportViewer1.ParameterFieldInfo = pfs

        'Debug.Print(reportDocument1.PrintOptions.PaperSize)

        CrystalReportViewer1.ReportSource = reportDocument1

    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Function printChk(ByVal SysGroupName As String) As Boolean
        Try
            Dim para As New ParameterList
            Dim dt As DataTable
            Dim strSql As String
            strSql = "Select a.AllowPrintCopy,Coalesce(b.PrintCount,0) 'PrintCount'"
            strSql += " From SysRole a"
            strSql += " Left Outer Join PrintCounter b "
            strSql += "	    On   b.DocNumber = @DocNumber"
            strSql += "	    And  b.DocSource = @DocSource"
            strSql += " Where a.MenuName     = @MenuName"
            strSql += " And   a.SysGroupName = @SysGroupName"
            para.Add("@DocNumber", strDocNumber)
            para.Add("@DocSource", strSourceForm)
            para.Add("@MenuName", mnForm)
            para.Add("@SysGroupName", SysGroupName)
            dt = pubGetData(Me.dal, strSql, "DataList", para)
            If dt.Rows.Count > 0 AndAlso dt.Rows(0)("AllowPrintCopy") >= dt.Rows(0)("PrintCount") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False

            MsgBox(Err.Description)
        End Try
    End Function
    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboPrinter.Text = "" Then MsgBox("No printer") : Exit Sub
        resetsRetval()
        Dim printUser As String
        If printChk(pubUserGroup) = False Then
            If MsgBox("คุณได้พิมพ์สำเนาเอกสารเลขที่ " & strDocNumber & " ครบจำนวนที่กำหนดแล้ว" & vbNewLine & _
                      "ถ้าต้องการพิมพ์ กรุณาให้ผู้มีสิทธิ์" & vbNewLine & "กรอกชื่อผู้ใช้ และรหัสผ่าน เพื่อพิมพ์เอกสารนี้" _
                      , MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = Microsoft.VisualBasic.MsgBoxResult.Yes Then
                sRetval(0) = strDocNumber
                sRetval(1) = strSourceForm
                sRetval(2) = mnForm
                ' dialogPrintBill.ShowDialog()
                If sRetval(0) = "Exit" Then Exit Sub
                If sRetval(0) = "0" Then Exit Sub
                printUser = sRetval(1)
            Else
                Exit Sub
            End If
        Else
            printUser = pubUserName
        End If
        Dim CryViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        strPathFile = strDirectoryFilePrint & cboFileName.SelectedValue.ToString
        If File.Exists(strPathFile) = False Then
            MsgBox("File not found." & vbNewLine & "File name :" & strPathFile)
            Exit Sub
        End If
        Try
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
            reportDocument1.SetParameterValue("@strDocNumber", strDocNumber)
            reportDocument1.PrintOptions.PrinterName = cboPrinter.SelectedItem
            reportDocument1.PrintToPrinter(1, False, 0, 0)
            If (strSourceForm = "SaleCash" OrElse strSourceForm = "SaleCredit") AndAlso rdoPrintSale0.Checked = True Then
                Call SaveEffect(Me)
            Else
                ' Me.Close()
            End If
            Call PrintCounter(printUser)
        Catch ex As Exception
            Dim ErrDescription As String = Err.Description.Trim
            If ErrDescription = "Invalid printer specified." AndAlso pubUserLanguage = "th-TH" Then
                MsgBox("ไม่พบเครื่องพิมพ์ที่ตั้งค่าไว้")
            Else
                MsgBox(Err.Description)
            End If
            Exit Sub
        End Try
        Call PreviewReport()
    End Sub
    Private Sub cmdOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenFile.Click
        gMaster.Height = 88
        Dim sfd As New OpenFileDialog()
        sfd.InitialDirectory = strDirectoryFilePrint
        sfd.Filter = [String].Format("{0} (*{1})|*{1}", "Crystal Reports File", ".rpt")
        If sfd.ShowDialog() = DialogResult.OK Then
            If Path.GetDirectoryName(sfd.FileName) & "\" <> strDirectoryFilePrint Then
                MsgBox("The selected file is not in specific directory." & vbNewLine & _
                        "Specific directory =" & strDirectoryFilePrint)
            Else
                txtFileName.Text = Path.GetFileName(sfd.FileName)
                If (strSourceForm = "SaleCash" OrElse strSourceForm = "SaleCredit") AndAlso rdoPrintSale1.Checked = True Then
                    strReportNameSaleDp = txtFileName.Text
                Else
                    strReportName = txtFileName.Text
                End If
            End If
        End If
        Dim da As New DAL.Adapter
        Dim para As New ParameterList
        da.ConnectionInfo = Me.Connection
        da.Open()
        da.TransBegin()
        Dim sql As String
        Try
            sql = "Update MasterReport Set MasReportName=@MasReportName"
            sql += " Where DocSourceName=@DocSourceName And ComBranch_Code ='" & pubComBranch_Code & "'"
            para.Add("@MasReportName", String.Format("{0}", txtFileName.Text))
            If (strSourceForm = "SaleCash" OrElse strSourceForm = "SaleCredit") AndAlso rdoPrintSale1.Checked = True Then
                para.Add("@DocSourceName", String.Format("{0}", "SaleDP"))
            Else
                para.Add("@DocSourceName", String.Format("{0}", strSourceForm))
            End If
            da.ExecuteNonQuery(sql, para)
            da.TransCommit()
        Catch ex As Exception
            da.TransRollback()
        End Try
        PreviewReport()
    End Sub

    Private Sub lblChangeReport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblChangeReport.LinkClicked
        gbReport.Visible = True
        lblChangeReport.Visible = False
    End Sub

    Private Sub rdoPrintSale1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPrintSale1.Click, rdoPrintSale0.Click
        If rdoPrintSale0.Checked = True Then
            cboFileName.Visible = True
            cboFileNameDp.Visible = False
            cboFileName.SelectedValue = strReportName.ToString
        Else
            cboFileName.Visible = False
            cboFileNameDp.Visible = True
            cboFileNameDp.SelectedValue = strReportNameSaleDp.ToString

        End If
        Call PreviewReport()
    End Sub
    Private Sub cboFileNameDp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileNameDp.SelectedIndexChanged
        If chkcbo <> "1" Then Exit Sub
        strReportNameSaleDp = cboFileNameDp.SelectedValue.ToString

        Dim da As New DAL.Adapter
        Dim para As New ParameterList
        da.ConnectionInfo = Me.Connection
        da.Open()
        da.TransBegin()
        Dim sql As String
        Try
            sql = "Update MasterReportList Set ReportName=@ReportName"
            sql += " Where DocSourceName=@DocSourceName And ComBranch_Code ='" & pubComBranch_Code & "'"
            para.Add("@ReportName", String.Format("{0}", strReportNameSaleDp))
            If rdoPrintSale1.Checked = True Then
                para.Add("@DocSourceName", String.Format("{0}", "SaleDP"))
            Else
                para.Add("@DocSourceName", String.Format("{0}", strSourceForm))
            End If
            da.ExecuteNonQuery(sql, para)
            da.TransCommit()
        Catch ex As Exception
            da.TransRollback()
        End Try
        PreviewReport()
    End Sub
    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor : gbReport.Enabled = False
        Call PreviewReport()
        gbReport.Enabled = True : Me.Cursor = Cursors.Default

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub cboPaper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaper.SelectedIndexChanged, cboPrinter.SelectedIndexChanged
        If gMaster.Height <> 150 Then Exit Sub
        strPathFile = strDirectoryFilePrint & cboFileName.SelectedValue.ToString
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

        Dim pfs As New ParameterFields
        Dim pdv1 As New ParameterDiscreteValue
        Dim pf1 As New ParameterField
        pf1.ParameterFieldName = "@strDocNumber"
        pdv1.Value = strDocNumber
        pf1.CurrentValues.Add(pdv1)
        pfs.Add(pf1)

        Select Case cboPaper.SelectedIndex
            Case 0
                reportDocument1.PrintOptions.PrinterName = cboPrinter.Text
                reportDocument1.PrintOptions.PaperSize = PaperSizesRawKind(cboPrinter.Text)
            Case 1
                reportDocument1.PrintOptions.PrinterName = cboPrinter.Text
                reportDocument1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
            Case 2
                reportDocument1.PrintOptions.PrinterName = cboPrinter.Text
                reportDocument1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        End Select
        CrystalReportViewer1.ParameterFieldInfo = pfs
        CrystalReportViewer1.ReportSource = reportDocument1
    End Sub

    Private Sub cboPrinter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPrinter.Click
        If cboPrinterLoad = False Then
            getPrintList()
            cboPrinterLoad = True
        End If
    End Sub

    Private Sub AsButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim settings As New PrinterSettings()
        For Each size As Object In settings.PaperSizes
            Debug.WriteLine(size)
        Next
    End Sub
    Function PaperSizesRawKind(ByVal iPrinterName As String) As Integer
        Dim iRawKind As Integer = 0
        Dim pd As New System.Drawing.Printing.PrintDocument
        pd.PrinterSettings.PrinterName = iPrinterName
        For a11 = 0 To pd.PrinterSettings.PaperSizes.Count - 1
            If pd.PrinterSettings.PaperSizes(a11).PaperName = "HalfLetter" Then
                iRawKind = pd.PrinterSettings.PaperSizes(a11).RawKind
            End If
        Next
        If iRawKind = 0 Then MsgBox("เครื่องพิมพ์นี้ไม่รองรับ  Half Letter")
        Return iRawKind
        'Try
        '    Dim wt As StreamWriter = File.CreateText(dirRoot & "\PaperSize.idg")
        '    wt.WriteLine(reportDocument1.PrintOptions.PaperSize)
        '    wt.Close()
        'Catch ex As Exception
        'End Try

    End Function

    Private Sub lblVatType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblVatType.Click

    End Sub

    Private Sub กำหนดขนาดกระดาษToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles กำหนดขนาดกระดาษToolStripMenuItem.Click
        gMaster.Height = 150
    End Sub
    Dim cryRpt As New ReportDocument
    Private Sub AsButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSale.Click
        Try
            '   PreviewReport("")
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            CrDiskFileDestinationOptions.DiskFileName = strDirectoryFilePrint & txtFileName.Text
            CrExportOptions = reportDocument1.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.CrystalReport
                .DestinationOptions = CrDiskFileDestinationOptions
            End With

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
            reportDocument1.SetParameterValue("@strDocNumber", "")
            Select Case cboPaper.SelectedIndex
                Case 0
                    reportDocument1.PrintOptions.PrinterName = cboPrinter.Text
                    reportDocument1.PrintOptions.PaperSize = PaperSizesRawKind(cboPrinter.Text)
                Case 1
                    reportDocument1.PrintOptions.PrinterName = cboPrinter.Text
                    reportDocument1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                Case 2
                    reportDocument1.PrintOptions.PrinterName = cboPrinter.Text
                    reportDocument1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
            End Select
            reportDocument1.Export()
            Call SaveEffect(Me)
            PreviewReport()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub cmdSaleAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ss = InputBox("กำหนดชื่อไฟล์", "ACChieve Trading", txtFileName.Text, 0, 0)
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            '   Dim CrFormatTypeOptions As New re
            CrDiskFileDestinationOptions.DiskFileName = strDirectoryFilePrint & ss
            CrExportOptions = reportDocument1.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.CrystalReport
                .DestinationOptions = CrDiskFileDestinationOptions
                ' .FormatOptions = CrFormatTypeOptions
            End With
            reportDocument1.Export()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cboFileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFileName.SelectedIndexChanged
        If chkcbo <> "1" Then Exit Sub
        strReportName = cboFileName.SelectedValue.ToString

        Dim da As New DAL.Adapter
        Dim para As New ParameterList
        da.ConnectionInfo = Me.Connection
        da.Open()
        da.TransBegin()
        Dim sql As String
        Try
            sql = "Update MasterReportList Set ReportName=@ReportName"
            sql += " Where DocSourceName=@DocSourceName And ComBranch_Code ='" & pubComBranch_Code & "' "
            para.Add("@ReportName", String.Format("{0}", strReportName))
            If (strSourceForm = "SaleCash" OrElse strSourceForm = "SaleCredit") AndAlso rdoPrintSale1.Checked = True Then
                para.Add("@DocSourceName", String.Format("{0}", "SaleDP"))
            Else
                para.Add("@DocSourceName", String.Format("{0}", strSourceForm))
            End If
            da.ExecuteNonQuery(sql, para)
            da.TransCommit()
        Catch ex As Exception
            da.TransRollback()
        End Try
        PreviewReport()
    End Sub

    Private Sub rdoPrintSale0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPrintSale0.CheckedChanged

    End Sub

    Private Sub gMaster_ExpandChanged(ByVal sender As System.Object, ByVal e As Stone.WinUI.AsExpandEventArgs) Handles gMaster.ExpandChanged

    End Sub
End Class