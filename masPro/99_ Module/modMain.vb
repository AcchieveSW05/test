#Region "Imports"
Imports System.Windows.Forms
Imports System.Management
Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
#End Region
Module modMain
    Public pubServerName As String = ""
    Public pubDatabaseName As String = ""
    Public pubDbUsername As String = ""
    Public pubDbPassword As String = ""
    Public pubUserName As String = "" 'Get from user login
    Public pubUserGroup As String = "" 'Get from user login
    Public pubUserLanguage As String = "" 'Get from user login
    Public pubDefaultEmployee(2) As String 'Get from user (Project Load)
    Public pubDefaultProject(2) As String 'Get from company (Project Load)
    Public pubDefaultDepartment(2) As String 'Get from company (Project Load)
    Public sRetval(20) As String
    Public pubDataView As DataView
    Public pubDatatable_1 As DataTable
    Public pubCompanyName As String 'Get from company (Project Load)
    Public pubVatRate As Double
    Public pubVatType As String
    Public pubReportDir As String
    Public pubRegister As Boolean
    Public pubAllowUseTran As Boolean
    Public pubDefaultReportDir As String = "C:\idg_acc_Data\ReportFile"
    Public pubPrinterSlip, pubSlipPaperSize, pubPosDisplay As String
    Public pubAttachFileDir As String = ""
    Public dpf As New Stone.WinUI.StyleFormat
    Public strDefDeteTime As DateTime = DateTimePicker.MaximumDateTime
    Public dirRoot As String = Directory.GetCurrentDirectory
    Public pubCom_Id As String
    Public pubOpenFrom As String
    Public pubMachineId As String
    Public pubComBranch_Code As String = ""
    Public dDate As DateTime
    Public pubMsgRequestData, pubMsgDupplicateData, pubMsgDupplicateDocument, pubMsgOutOfPeriod, pubMsgDocUse As String
    Public pubDecimalDigit As Integer
    Public pubQtyDecimalDigit As Integer
    Public pubUseSpecialReport1 As String = "0"
    Public pubUseSpecialReport2 As String = "0"
    Public pubUseSpecialReport3 As String = "0"
    Public pubUseFreeFields As String = "0"
    Public pubUseLockDate As String = "0"
    Public pubUsePaymentHold As String = "0"
    Public pubUseSubMenuSale As String = "0"
    Public pubUseSubMenuPurchase As String = "0"
    Public pubUseDpManagement As String = "0"
    Public pubUseCommitsion As String = "0"
    Public pubUsePromotionDiscount As String = "0"
    Public pubUsePromotionPremium As String = "0"
    Public pubUseRegion As String = "1"
    Public pubUseLockPeriodDay As String = "0"
    Public pubUseBranchTransferProduct As String = "0"
    Public pubUseMemberDiscount As String = "0"
    Public pubUsePointRewards As String = "0"
    Public pubUseSaleStandardCost As String = "0"
    Public pubUseMinStock As String = "1"
    Public pubBusinessName As String = ""
    Public pubComputerName As String = ""
    Public pubDupplicateDocNumber As String = ""
    Public pubPurchaseExchange As String = ""
    Public pubDefaultPrinter As String = ""
    Public pubNonPos As String = ""
    Public pubAddOn As String = ""
    Public pubPackingManagement As String = ""
    Public pubSalePrice8 As String = ""
    Public pubEnterNewLine As String = ""
    Public pubEmail As String = ""
    Public pubFtpAttachmentFile As String
    Public DirFileAttachment As String
    Public DirUserName As String = ""
    Public DirPassword As String = ""
    Public FtpUsername As String = ""
    Public FtpPassword As String = ""
    Public pubOnLine As String = "1"

    Public getDateServer As DateTime
    Public formSize As String
    Public HideBalanceAddOn As Boolean
    Public HideBalanceRole As Boolean
    Public mdiMainForm As Object

    Public pubProjectName As String = ""

    Public Sub SaveEffect(ByVal pForm As Form)
        Dim frm As New frmSave
        frm.Show(pForm)
        System.Threading.Thread.Sleep(250)
        frm.Close()
    End Sub
    Public Sub reDimGreyBackground(ByVal mdiMainForm As Object)
        Dim ifrmGreyBackground As frmGreyBackground = New frmGreyBackground
        'gen.updateDynamics(get_prospect.dynamicsID)
        Dim sWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim sHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Try
            ifrmGreyBackground.Location = New Drawing.Point(0, 0)
            ifrmGreyBackground.Size = New Drawing.Size(sWidth, sHeight - 30)
            ifrmGreyBackground.StartPosition = mdiMainForm.StartPosition
            ifrmGreyBackground.ShowDialog()
        Catch ex As Exception
            ifrmGreyBackground.Close()
        End Try
    End Sub

    Public Function pubStockMinus(ByVal da As DAL.Adapter) As Boolean
        If pubGetData(da, "Select StockMinus From Company", "DataList").Rows(0)("StockMinus").ToString = "1" Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function SQL_FormatDate(ByVal strDate As Date) As String
        Dim tmpYear As String
        Dim tmpDate As String
        If DatePart("yyyy", strDate) > 2500 Then
            tmpYear = DatePart("yyyy", strDate) - 543
        Else
            tmpYear = DatePart("yyyy", strDate)
            If tmpYear < 1800 Then tmpYear = 1800
        End If
        tmpDate = CStr(Format(strDate, "MM-dd-yyyy"))
        SQL_FormatDate = tmpYear & "-" & Left(tmpDate, Len(tmpDate) - 5)
    End Function

    Public Sub CenterScreen(ByVal frm As Form)
        Dim sWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim sHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        With frm
            .Left = (sWidth - .Width) / 2
            .Top = (sHeight - .Height) / 2   ' -  amdiACChieveEnt.StatusBar1.Height) / 2
            'If .MdiChildren Then
            '    .Top = (.Top - 500)
            'End If
            If .Top < 0 Then .Top = 0
        End With
    End Sub
    Public Sub resetsRetval()
        For x = 0 To 20
            sRetval(x) = ""
        Next
    End Sub
    Public Sub pubInsertLogfile(ByVal da As DAL.Adapter, ByVal para As DAL.ParameterList, ByVal UserAction As String,
                                ByVal DocSource As String, ByVal DocNumber As String, ByVal DocDate As DateTime, ByVal Remark As String)
        Dim strSql As String
        strSql = "Insert Into SysLogFile (SysLogFileDate, UserAction, DocSource, DocNumber, DocDate, DocRemark, CreatedUser,MachineId)"
        strSql += " Values (GetDate(), @UserAction, @DocSource, @DocNumber, @DocDate, @DocRemark, @CreatedUser,@MachineId)"
        para.Add("@UserAction", String.Format("{0}", UserAction))
        para.Add("@DocSource", String.Format("{0}", DocSource))
        para.Add("@DocNumber", String.Format("{0}", DocNumber))
        para.Add("@DocDate", SQL_FormatDate(DocDate))
        para.Add("@DocRemark", String.Format("{0}", Remark))
        para.Add("@CreatedUser", String.Format("{0}", pubUserName))
        para.Add("@MachineId", pubMachineId)
        da.ExecuteNonQuery(strSql, para)
        para.Items.Clear()
    End Sub
    Public Sub OpenReferenceForm(ByVal SourceForm As String, ByVal DocNumber As String, ByVal da As DAL.Adapter)
        Dim strEdit As String = 0
        Dim strDelete As String = 0
        Dim strPrint As String = 0
        Dim sql As String = ""
        Dim dt As DataTable
        Select Case SourceForm
            Case "Pr"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnPr'"
            Case "PurchaseOrder"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnPurchaseOrder'"
            Case "PurchaseOrderCancel"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnPurchaseOrderCancel'"
            Case "PurchaseDeposit"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnPurchaseDeposit'"
            Case "CnPurchaseDeposit"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnCnPurchaseDeposit'"
            Case "PurchaseCash"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnPurchaseCash'"
            Case "PurchaseCredit"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnPurchaseCredit'"
            Case "PurchaseService"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnPurchaseService'"
            Case "ReceiptProduct"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnReceiptProduct'"
            Case "AccountPayable"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnAccountPayable'"
            Case "CnPurchase"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnCnPurchase'"
            Case "DnPurchase"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnDnPurchase'"
            Case "LandedCost"
                sql = "Select * From SysRole Where SysGroupName = '" & pubUserGroup & "' And MenuName = 'mnLandedCost'"
        End Select
        dt = pubGetData(da, sql, "DataList")
        If dt.Rows.Count >= 1 AndAlso dt.Rows(0)("RoleAdd").ToString() = "1" Then
            strEdit = dt.Rows(0)("RoleUpdate").ToString
        Else
            MsgBox("Not allow use function") : Exit Sub
        End If
        sRetval(0) = ""
        sRetval(1) = DocNumber
        sRetval(2) = strEdit
        sRetval(3) = ""
        sRetval(4) = 0
        sRetval(5) = strDelete
        sRetval(6) = strPrint
        Select Case SourceForm
            Case "Pr"
                '    Dim _inputPr As New SwIVF_Purchase.inputPr
                '    _inputPr.ShowDialog()
                'Case "PurchaseOrder"
                '    Dim _inputPurchaseOrder As New SwIVF_Purchase.inputPurchaseOrder
                '    _inputPurchaseOrder.ShowDialog()
                'Case "PurchaseOrderCancel"
                '    Dim _inputPurchaseOrderCancel As New SwIVF_Purchase.inputPurchaseOrderCancel
                '    _inputPurchaseOrderCancel.ShowDialog()
                'Case "PurchaseDeposit"
                '    Dim _inputPurchaseDeposit As New SwIVF_Purchase.inputPurchaseDeposit
                '    _inputPurchaseDeposit.ShowDialog()
                'Case "CnPurchaseDeposit"
                '    Dim _inputCnPurchaseDeposit As New SwIVF_Purchase.inputCnPurchaseDeposit
                '    _inputCnPurchaseDeposit.ShowDialog()
                'Case "PurchaseCash"
                '    Dim _inputPurchaseCash As New SwIVF_Purchase.inputPurchaseCash
                '    _inputPurchaseCash.ShowDialog()
                'Case "PurchaseCredit"
                '    Dim _inputPurchaseCredit As New SwIVF_Purchase.inputPurchaseCredit
                '    _inputPurchaseCredit.ShowDialog()
                'Case "PurchaseService"
                '    Dim _inputPurchaseService As New SwIVF_Purchase.inputPurchaseService
                '    _inputPurchaseService.ShowDialog()
                'Case "ReceiptProduct"
                '    Dim _inputReceiptProduct As New SwIVF_Purchase.inputReceiptProduct
                '    _inputReceiptProduct.ShowDialog()
                'Case "AccountPayable"
                '    Dim _inputAccountPayable As New SwIVF_Purchase.inputAccountPayable
                '    _inputAccountPayable.ShowDialog()
                'Case "CnPurchase"
                '    Dim _inputCnPurchase As New SwIVF_Purchase.inputCnPurchase
                '    _inputCnPurchase.ShowDialog()
                'Case "DnPurchase"
                '    Dim _inputDnPurchase As New SwIVF_Purchase.inputDnPurchase
                '    _inputDnPurchase.ShowDialog()
                'Case "LandedCost"
                '    Dim _inputLandedCost As New SwIVF_Purchase.inputLandedCost
                '    _inputLandedCost.ShowDialog()
        End Select
    End Sub
    ''' <summary>
    ''' Public Get Data.
    ''' </summary>
    ''' <param name="da">DAL.Adapter</param>
    ''' <param name="sql">The SQL.</param>
    ''' <param name="TableName">Name of the table.</param>
    ''' <returns></returns>
    Public Function pubGetData(ByVal da As DAL.Adapter, ByVal sql As String, ByVal TableName As String) As DataTable
        da.Open()
        Dim dt As DataTable = da.GetData(sql, "DataList")
        da.Close()
        Return dt
    End Function

    ''' <summary>
    ''' Public Get Data.
    ''' </summary>
    ''' <param name="da">DAL.Adapter</param>
    ''' <param name="sql">The SQL.</param>
    ''' <param name="TableName">Name of the table.</param>
    ''' <param name="para">The paras.</param>
    ''' <returns></returns>
    Public Function pubGetData(ByVal da As DAL.Adapter, ByVal sql As String, ByVal TableName As String, ByVal para As DAL.ParameterList) As DataTable
        da.Open()
        Dim dt As DataTable = da.GetData(sql, "DataList", para)
        para.Items.Clear()
        Return dt
    End Function

    Public Function genStrConn(ByVal dbName As String)
        Dim strconn As String = ""
        Select Case pubDbUsername
            Case "indigo", "sa"
                strconn = "Data Source=" & pubServerName & ";Initial Catalog=" & dbName & "; User Id=" & pubDbUsername & ";Password=" & pubDbPassword & ";"
            Case Else
                strconn = "Data Source=" & pubServerName & ";Initial Catalog=" & dbName & "; Integrated Security=SSPI"
        End Select

        Return strconn
    End Function
    Public Function pubChkCreditCustomer(ByVal da As DAL.Adapter, ByVal strCusCode As String, ByVal dblAmountUse As Double) As String
        Dim strSql As String
        Dim dt2 As New DataTable
        Dim dblCreditUse As Double = 0.0
        strSql = "DECLARE @str_Code Varchar(30)"
        strSql += " Select @str_Code='" & strCusCode & "'"
        strSql += " Select Coalesce(SUM(AmountRemain),0) 'AmountRemain'"
        strSql += " From ("
        strSql += " Select	a.AmountRemain"
        strSql += " From	Sale a With(NoLock)"
        strSql += " Where a.AmountRemain <> 0 And	a.DocStatus <> 'C' And a.DocType = '9' And a.Cus_Code =@str_Code"
        strSql += " Union All"
        strSql += " Select a.AmountRemain"
        strSql += " From	Sale a With(NoLock)"
        strSql += " Where	a.DocStatus <> 'C' And (a.DocType in ('1','9','2') Or a.PaidType = '1') And a.Cus_Code =@str_Code"
        strSql += " Union All"
        strSql += " Select	a.AmountRemain"
        strSql += " From	DnSale a With(NoLock)"
        strSql += " Where	a.AmountRemain <> 0 And	a.DocStatus <> 'C' And	a.Cus_Code =@str_Code And PaidType='1'"
        strSql += " Union All"
        strSql += " Select	a.AmountRemain"
        strSql += " From	OtherIncome a With(NoLock) "
        strSql += " Where	a.AmountRemain <> 0 And	a.DocStatus <> 'C' And	a.Cus_Code =@str_Code And PaidType='1'"
        strSql += " Union All"
        strSql += " select	-a.AmountRemain"
        strSql += " From	CnSaleDeposit a With(NoLock)"
        strSql += " Where a.AmountRemain <> 0 And	a.DocStatus <> 'C' And a.Cus_Code =@str_Code"
        strSql += " Union All"
        strSql += " select	-a.AmountRemain"
        strSql += " From	CnSale a With(NoLock)"
        strSql += " Where	a.AmountRemain <> 0 And	a.DocStatus <> 'C' And a.CnType='1' And a.Cus_Code =@str_Code"
        strSql += " Union All"
        strSql += " select	-a.AmountRemain"
        strSql += " From	AdvanceReceipt a With(NoLock)"
        strSql += " Where	a.AmountRemain <> 0 And	a.DocStatus <> 'C' And	a.Cus_Code =@str_Code"
        strSql += " ) x (AmountRemain)"
        dblCreditUse = pubGetData(da, strSql, "XXX").Rows(0)("AmountRemain")

        Dim sql As String
        Dim dt As New DataTable

        sql = "Select"
        sql += "  Coalesce(CreditStatus,'0')     'CreditStatus'"
        sql += " ,Coalesce(CreditAmount,0)       'CreditAmount'"
        sql += " ,Coalesce(CreditAmount,0) - " & dblCreditUse & " As  'CreditAmountRemain'"
        sql += " From Customer With(Nolock)"
        sql += " Where Cus_Code='" & strCusCode & "'"

        dt = pubGetData(da, sql, "XXX")

        Select Case dt.Rows(0)("CreditStatus")
            Case "0" : Return (dt.Rows(0)("CreditAmountRemain") - dblAmountUse).ToString
            Case "1" : Return "-1"
            Case "2"
                If (dt.Rows(0)("CreditAmountRemain") - dblAmountUse) < 0 Then
                    Return (dt.Rows(0)("CreditAmountRemain") - dblAmountUse).ToString
                Else
                    Return "Not allow"
                End If
            Case "3"
                If (dt.Rows(0)("CreditAmountRemain") - dblAmountUse) < 0 Then
                    Return (dt.Rows(0)("CreditAmountRemain") - dblAmountUse).ToString
                Else
                    Return "Not allow(Temporary)"
                End If
            Case Else : Return "Not allow"
        End Select
    End Function
    Public Function pubChkCreditSupplier(ByVal da As DAL.Adapter, ByVal strSupCode As String, ByVal dblAmountUse As Double) As String

        Dim sql As String
        Dim dt As New DataTable

        sql = "Select CreditStatus,CreditAmount,CreditAmountRemain From Supplier With(Nolock)"
        sql += " Where Sup_Code='" & strSupCode & "'"
        da.Open()
        dt = da.GetData(sql, "data")
        da.Close()
        Select Case dt.Rows(0)("CreditStatus")
            Case "0" : Return (dt.Rows(0)("CreditAmountRemain") - dblAmountUse).ToString
            Case "1" : Return "-1"
            Case "2"
                If (dt.Rows(0)("CreditAmountRemain") - dblAmountUse) < 0 Then
                    Return (dt.Rows(0)("CreditAmountRemain") - dblAmountUse).ToString
                Else
                    Return "Not allow"
                End If
            Case "3"
                If (dt.Rows(0)("CreditAmountRemain") - dblAmountUse) < 0 Then
                    Return (dt.Rows(0)("CreditAmountRemain") - dblAmountUse).ToString
                Else
                    Return "Not allow(Temporary)"
                End If
            Case Else : Return "Not allow"
        End Select
    End Function
    Function pubGetProdData(ByVal da As DAL.Adapter, ByVal strCode As String, ByVal Source As String, ByVal para As DAL.ParameterList) As DataTable
        Dim intVat As Double = 1 + (pubVatRate / 100)
        Dim strSql As String
        strSql = "Select top 1"
        strSql += " b.Prod_Code as 'Prod_Code'"
        strSql += " ,a.ProdBarcode"
        strSql += " ,b.ProdName as 'ProdName'"
        If Source = "Purchase" Then
            If pubVatType = 2 Then 'ราคารวม Vat
                strSql += " ,Case when Coalesce(b.CostMavg,0) > 0 Then b.CostMavg * a.subUnitScale"
                strSql += "       when Coalesce(b.PurchasePriceLastDate,0) > 0 then b.PurchasePriceLastDate * a.subUnitScale"
                strSql += "       when Coalesce(b.EstimateCostPrice,0) > 0 then b.EstimateCostPrice  * a.subUnitScale * " & intVat
                strSql += " Else 0.0 "
                strSql += " End	 'ShowPricePerUnit'"
            Else
                strSql += " ,Case when Coalesce(b.CostMavg,0) > 0 then b.CostMavg * a.subUnitScale"
                strSql += "       when Coalesce(b.PurchasePriceLastDate,0) > 0 then b.PurchasePriceLastDate  * a.subUnitScale"
                strSql += "       when Coalesce(b.EstimateCostPrice,0) > 0 then b.EstimateCostPrice  * a.subUnitScale"
                strSql += " Else 0.0"
                strSql += " End	 'ShowPricePerUnit'"
            End If
        Else
            strSql += " ,a.SalePricePos as 'ShowPricePerUnit'"
            strSql += " ,a.SalePrice1 as 'SalePrice1'"
            strSql += " ,a.SalePrice2 as 'SalePrice2'"
            strSql += " ,a.SalePrice3 as 'SalePrice3'"
            strSql += " ,a.SalePrice4 as 'SalePrice4'"

            If pubSalePrice8 = "1" Then
                strSql += " ,a.SalePrice5 as 'SalePrice5'"
                strSql += " ,a.SalePrice6 as 'SalePrice6'"
                strSql += " ,a.SalePrice7 as 'SalePrice7'"
                strSql += " ,a.SalePrice8 as 'SalePrice8'"
            End If

        End If
        strSql += " ,a.SubUnitName as 'ShowUnit'"
        strSql += " ,b.UnitName as 'UnitName'"
        strSql += " ,a.SubUnitScale as 'UnitScale'"
        strSql += " ,b.VatType"
        strSql += " ,w.WareHouse_Code"
        strSql += " ,w.WareHouseName"
        strSql += " ,1.0 as 'ShowQty'"
        strSql += " ,Coalesce(b.QtyBalance,0)/Coalesce(a.SubUnitScale,0) as 'QtyBalance'"
        strSql += " ,Case When @VatType <> '2' Or b.VatType='0' Then b.CostMavg Else (b.CostMavg *(100+ @VatRate))/100 End 'CostMavg'"
        strSql += " ,Coalesce(d.Promotion_Code,e.ProPremium_Code,'N') 'Pro'"
        strSql += " ,Case when b.PurchasePriceLastDate  <= 0 then b.PurchasePriceLastDate * a.subUnitScale Else b.CostMavg * a.subUnitScale End 'CostBeforeVat'"
        strSql += " ,b.PurchasePriceLastDate"
        strSql += " ,b.PurchaseLastDate"
        strSql += " From SubUnit a With(Nolock)"
        strSql += " Left Outer Join Product b With(Nolock) On a.Prod_Code =b.Prod_Code"
        strSql += " Left Outer Join Warehouse w With(Nolock)"
        Select Case Source
            Case "Pos" : strSql += " On b.WareHouse_Code_Pos = w.WareHouse_Code"
            Case "Sale", "SaleService" : strSql += " On b.WareHouse_Code_Sale = w.WareHouse_Code"
            Case "Purchase" : strSql += " On b.WareHouse_Code_Purchase = w.WareHouse_Code"
        End Select
        strSql += " Left Outer Join PromotionList c On a.Prod_Code = c.Prod_Code And a.SubUnitName =c.ShowUnit"
        strSql += " Left outer join Promotion d "
        strSql += " On c.Promotion_Code = d.Promotion_Code	And d.StartDate < Getdate() and d.EndDate > Getdate()"
        strSql += " Left Outer Join ProPremiumList e"
        strSql += " On a.Prod_Code = e.Prod_Code And a.SubUnitName =e.ShowUnit"
        strSql += " Left outer join ProPremium f "
        strSql += " On e.ProPremium_Code = f.ProPremium_Code And f.StartDate < Getdate() and f.EndDate > Getdate()	"
        strSql += " Where a.ProdBarcode=@strCode And b.DocStatus <>'C'"
        If Source = "Purchase" Then strSql += " And b.ProdType = '0'"
        para.Add("@VatType", pubVatType)
        para.Add("@VatRate", CDbl(pubVatRate))
        para.Add("@strCode", strCode)
        Return pubGetData(da, strSql, "Product", para)
    End Function
    Public Function pubValueSubStr(ByVal Values As String, ByVal iLength As Integer) As String
        Try
            If Values.ToString.Trim.Length > iLength Then
                Return Values.ToString.Trim.Substring(0, iLength)
            Else
                Return Values.ToString.Trim
            End If
        Catch ex As Exception
            Return Values.ToString.Trim
        End Try
    End Function
    Public Function iRound(ByVal iValues As Decimal, ByVal iDigit As Integer) As Decimal
        Return Math.Round(iValues + 0.0000000001, iDigit, MidpointRounding.AwayFromZero)
    End Function
    Public Function chkPeriodStatus(ByVal da As DAL.Adapter, ByVal DocDate As DateTime) As Boolean
        Dim para As New DAL.ParameterList

        Dim sql As String = ""
        Dim StartDate As DateTime = Now
        Dim EndDate As DateTime = Now
        Dim enCodeSerialNumber As String = ""
        Dim enCodeActivateCode As String = ""
        da.Open()
        sql = "Select * From LicenseTime"
        sql += " Where  StartDate <= GetDate() And EndDate >= GetDate()"
        sql += " And PeriodStatus ='O' And RegStatus ='R'"
        Dim dt As DataTable = da.GetData(sql, "Data")
        sql = "Select * From LicenseTime"
        sql += " Where  StartDate <= @date And EndDate >= @date"
        sql += " And PeriodStatus ='O'"
        para.Add("@Date", SQL_FormatDate(DocDate))
        Dim dt2 As DataTable = da.GetData(sql, "Data", para)
        para.Items.Clear()
        da.Close()
        If dt.Rows.Count = 1 AndAlso dt2.Rows.Count = 1 Then
            StartDate = dt2.Rows(0)("StartDate")
            EndDate = dt2.Rows(0)("EndDate")
            enCodeSerialNumber = dt2.Rows(0)("SerialNumber")
            enCodeActivateCode = dt2.Rows(0)("ActivateCode")
            'If chkRegister(StartDate, EndDate, enCodeSerialNumber, enCodeActivateCode) = True Then
            Return True
            'Else
            '    Return False
            'End If
        Else
            If pubUserLanguage = "en-US" Then
                MsgBox("Not allow save data." & vbNewLine &
                       "Because the date of the document not in period work.")
            Else
                MsgBox("ไม่อนุญาต ให้บันทึกข้อมูล" & vbNewLine &
                       "เนื่องจากวันที่ของเอกสาร ไม่ได้อยู่ในงวดการทำงาน")
            End If
            Return False
        End If

    End Function

    Public Function chkPeriodStatus(ByVal da As DAL.Adapter, ByVal para As DAL.ParameterList, ByVal DocDate As DateTime) As Boolean
        Dim sql As String = ""
        Dim StartDate As DateTime = Now
        Dim EndDate As DateTime = Now
        Dim enCodeSerialNumber As String = ""
        Dim enCodeActivateCode As String = ""
        da.Open()
        sql = "Select * From LicenseTime"
        sql += " Where  StartDate <= GetDate() And EndDate >= GetDate()"
        sql += " And PeriodStatus ='O' And RegStatus ='R'"
        Dim dt As DataTable = da.GetData(sql, "Data")
        sql = "Select * From LicenseTime"
        sql += " Where  StartDate <= @date And EndDate >= @date"
        sql += " And PeriodStatus ='O'"
        para.Add("@Date", SQL_FormatDate(DocDate))
        Dim dt2 As DataTable = da.GetData(sql, "Data", para)
        para.Items.Clear()
        da.Close()
        If dt.Rows.Count = 1 AndAlso dt2.Rows.Count = 1 Then
            StartDate = dt2.Rows(0)("StartDate")
            EndDate = dt2.Rows(0)("EndDate")
            enCodeSerialNumber = dt2.Rows(0)("SerialNumber")
            enCodeActivateCode = dt2.Rows(0)("ActivateCode")
            'If chkRegister(StartDate, EndDate, enCodeSerialNumber, enCodeActivateCode) = True Then
            Return True
            'Else
            '    Return False
            'End If
        Else
            If pubUserLanguage = "en-US" Then
                MsgBox("Not allow save data." & vbNewLine &
                       "Because the date of the document not in period work.")
            Else
                MsgBox("ไม่อนุญาต ให้บันทึกข้อมูล" & vbNewLine &
                       "เนื่องจากวันที่ของเอกสาร ไม่ได้อยู่ในงวดการทำงาน")
            End If
            Return False
        End If

    End Function
    Public Function chkDupplicateDocNumber(ByVal DocNumber As String, ByVal para As DAL.ParameterList, ByVal da As DAL.Adapter) As String
        If pubDupplicateDocNumber <> "1" Then Return ""
        Dim strSql As String = ""
        Try
            strSql += " Select Top 1 Docdate, Case DocSource"
            strSql += " When 'AccountPayable' Then 'ใบตั้งหนี้จากใบบันทึกรับสินค้า'"
            strSql += " When 'AdvancePayment' Then 'ใบจ่ายชำระหนี้ล่วงหน้า'"
            strSql += " When 'AdvanceReceipt' Then 'ใบรับเงินชำระหนี้ล่วงหน้า'"
            strSql += " When 'Barcode' Then 'ใบสั่งพิมพ์บาร์โค้ด'"
            strSql += " When 'BfBankBook' Then 'ใบบันทึก ภาษีซื้อยกมา'"
            strSql += " When 'BfChequePaid' Then 'ใบบันทึก เช็คจ่ายยกมา'"
            strSql += " When 'BfCustomer' Then 'บันทึกยอด ลูกหนี้ยกมา'"
            strSql += " When 'BfProduct' Then 'บันทึกยอด สินค้ายกมา'"
            strSql += " When 'BfPurchaseDeposit' Then 'บันทึกยอด เงินจ่ายล่วงหน้ายกมา'"
            strSql += " When 'BfPurchaseVat' Then 'ใบบันทึก ภาษีซื้อยกมา'"
            strSql += " When 'BfSaleDeposit' Then 'บันทึกยอด เงินรับล่วงหน้ายกมา'"
            strSql += " When 'BfServiceIncome' Then 'บันทึกยอด เจ้าหนี้ค่าบริการยกมา'"
            strSql += " When 'BfSupplier' Then 'บันทึกยอด รายได้ค่าบริการยกมา'"
            strSql += " When 'BfSupplierService' Then 'บันทึกยอด เจ้าหนี้ยกมา'"
            strSql += " When 'Bill' Then 'ใบวางบิล'"
            strSql += " When 'BillService' Then 'ใบวางบิลค่าบริการ'"
            strSql += " When 'ChangeCostProduct' Then 'ใบปรับต้นทุนสินค้า'"
            strSql += " When 'CheckStock' Then 'ใบตรวจนับสต๊อก'"
            strSql += " When 'ChequePassPaid' Then 'ใบผ่านเช็คจ่าย'"
            strSql += " When 'ChequePassReceipt' Then 'ใบผ่านเช็ครับ'"
            strSql += " When 'CnAdvancePayment' Then 'ใบคืน เงินจ่ายชำระหนี้ล่วงหน้า'"
            strSql += " When 'CnAdvanceReceipt' Then 'ใบคืน เงินรับชำระหนี้ล่วงหน้า'"
            strSql += " When 'CnPurchase' Then 'ใบส่งคืนสินค้า(ลดหนี้)'"
            strSql += " When 'CnPurchaseDeposit' Then 'ใบรับคืนเงินจ่ายล่วงหน้า'"
            strSql += " When 'CnSale' Then 'ใบรับคืนสินค้า (ลดหนี้)'"
            strSql += " When 'CnSaleDeposit' Then 'ใบจ่ายคืนเงินรับล่วงหน้า'"
            strSql += " When 'CreditCardPassReceipt' Then 'ใบผ่านบัตรเครดิต'"
            strSql += " When 'DepositWithdraw' Then 'ใบบันทึก ฝาก/ถอนเงิน'"
            strSql += " When 'DnPurchase' Then 'ใบเพิ่มหนี้'"
            strSql += " When 'DnSale' Then 'ใบเพิ่มหนี้'"
            strSql += " When 'InventoryOv' Then 'ใบรับ เพื่อปรับเพิ่มสต๊อก'"
            strSql += " When 'InventoryRelocation' Then 'ใบโอนย้ายสินค้าระหว่างคลัง'"
            strSql += " When 'InventorySt' Then 'ใบเบิก เพื่อปรับลดสต๊อก'"
            strSql += " When 'Iof' Then 'ใบเบิกใช้ในกินการ'"
            strSql += " When 'Irtof' Then 'ใบรับคืนจากการเบิกใช้ในกิจการ'"
            strSql += " When 'LandedCost' Then 'ปันส่วนต้นทุน'"
            strSql += " When 'OrderExpenses' Then 'ใบบันทึก ค่าใช้จ่ายอื่นๆ'"
            strSql += " When 'OrderIncome' Then 'ใบรอรับ รายได้อื่นๆ'"
            strSql += " When 'OtherExpenses' Then 'ใบบันทึก ค่าใช้จ่ายอื่นๆ'"
            strSql += " When 'OtherIncome' Then 'ใบรอจ่าย รายได้อื่นๆ'"
            strSql += " When 'Payment' Then 'ใบจ่ายชำระหนี้'"
            strSql += " When 'PaymentService' Then 'ใบจ่ายชำระหนี้ค่าบริการ'"
            strSql += " When 'POS' Then 'POS'"
            strSql += " When 'Pr' Then 'ใบขออนุมัติซื้อ'"
            strSql += " When 'PrintBarcode' Then 'ใบบันทึกขอพิมพ์บาร์โค้ด'"
            strSql += " When 'Purchase deposit' Then 'ใบจ่ายเงินล่วงหน้า'"
            strSql += " When 'PurchaseCash' Then 'ใบซื้อเงินสด'"
            strSql += " When 'PurchaseCredit' Then 'ใบซื้อเงินเชื่อ'"
            strSql += " When 'PurchaseOrder' Then 'ใบสั่งซื้อ'"
            strSql += " When 'PurchaseOrderCancel' Then 'ยกเลิกใบสั่งซื้อปริมาณค้างรับ'"
            strSql += " When 'PurchaseService' Then 'รายจ่ายค่าบริการ'"
            strSql += " When 'Quotation' Then 'ใบเสนอราคา'"
            strSql += " When 'Receipt' Then 'ใบรับชำระหนี้'"
            strSql += " When 'ReceiptProduct' Then 'ใบบันทึกรับสินค้า'"
            strSql += " When 'ReceiptService' Then 'ใบรับชำระหนี้ ค่าบริการ'"
            strSql += " When 'ReNewInvoice' Then 'ยกเลิกและออกใบกำกับภาษีแทน'"
            strSql += " When 'Sale deposit' Then 'ใบรับเงินล่วงหน้า'"
            strSql += " When 'SaleCash' Then 'ใบขายเงินสด'"
            strSql += " When 'SaleCredit' Then 'ใบขายเงินเชื่อ'"
            strSql += " When 'SaleOrder' Then 'ใบสั่งขาย'"
            strSql += " When 'SaleOrderCancel' Then 'ยกเลิกใบสั่งขายปริมาณค้างส่ง'"
            strSql += " When 'SaleService' Then 'รายได้ค่าบริการ'"
            strSql += " When 'UpdateSalePrice' Then 'ใบปรับราคาขายสินค้า'"
            strSql += " When 'WaitPayment' Then 'ใบรับวางบิล (รอจ่ายชำระหนี้)'"
            strSql += " When 'WaitPaymentService' Then 'ใบรอจ่ายชำระหนี้ค่าบริการ'"
            strSql += " End  'DocSource'"
            strSql += " From SysLogFile"
            strSql += " Where DocNumber=@DocNumber"
            para.Add("@DocNumber", DocNumber)
            Dim dt As DataTable = pubGetData(da, strSql, "SysLogFile", para)
            If dt.Rows.Count > 0 Then
                Dim idate As DateTime = dt.Rows(0)("Docdate")
                Return "ไม่อนุญาติให้บันทึกข้อมูล" & vbNewLine & "เนื่องจากเอกสารเลขที่ " & DocNumber & " ถูกใช้ในหน้าจอ " & dt.Rows(0)("DocSource") &
                       " วันที่ " & Format(idate.Day, "00") & "/" & Format(idate.Month, "00") & "/" & Format(idate.Year + 543, "0000")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return "chkDupplicateDocNumber " & Err.Description
        End Try
    End Function
    Public Function chkDupplicateVat(ByVal DocNumber As String, ByVal TaxNumber As String, ByVal TaxDate As DateTime, ByVal SupName As String, ByVal para As DAL.ParameterList, ByVal da As DAL.Adapter) As String
        Dim strSql As String = ""
        strSql = "Select * From PurchaseVat"
        strSql += " Where TaxinvoiceNumber=@TaxNumber"
        strSql += " And   cast(cast(TaxinvoiceDate as varchar(11))as datetime)=@TaxDate"
        strSql += " And   SupName=@SupName"
        strSql += " And   DocNumber<>@DocNumber"
        strSql += " And   DocStatus<>'C'"
        Try
            para.Add("@TaxNumber", String.Format("{0}", TaxNumber))
            para.Add("@TaxDate", SQL_FormatDate(TaxDate))
            para.Add("@SupName", SupName)
            para.Add("@DocNumber", DocNumber)
            Dim dt As DataTable = pubGetData(da, strSql, "PurchaseVat", para)
            para.Items.Clear()
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("DocNumber").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Return "chkDupplicateVat : " & Err.Description
        End Try
    End Function
    Public Function checkAllowUseLockPeriodDay(ByVal da As DAL.Adapter, ByVal DocDate As Date, ByVal strSource As String) As Boolean
        If pubUseLockPeriodDay = "0" Then Return True
        Dim para As New DAL.ParameterList
        Dim strSql As String = ""
        strSql = "Select * From PeriodDay"
        strSql += " Where DocDate = @DocDate"
        strSql += " And " & strSource & " = 1"
        Try
            para.Add("@DocDate", SQL_FormatDate(DocDate))
            Dim dt As DataTable = da.GetData(strSql, "Data", para)
            para.Items.Clear()
            If dt.Rows.Count > 0 Then
                If pubUserLanguage = "en-US" Then MsgBox("This item has been lock. Can't allow data change") Else MsgBox("ไม่อนุญาติให้เปลียนแปลงข้อมูล เนื่องจากวันที่ ดังกล่าวนี้ถูกLock")
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return "XXXXXX"
        End Try
    End Function
    Public Function getMasterCode(ByVal da As DAL.Adapter, ByVal strTable As String, ByVal strCode As String, ByVal strName As String, ByVal strSearch As String) As String
        Dim sql As String
        Dim dt As DataTable
        Try
            sql = "Select top 1 " & strName & " as 'iName' From " & strTable & " With(NoLock) Where " & strCode & " = '" & strSearch & "' And DocStatus <> 'C'"
            dt = pubGetData(da, sql, "DataList")
            If dt.Rows.Count >= 1 Then
                Return dt.Rows(0)("iName").ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
            Return ""
        End Try
    End Function
#Region "Register"




#End Region

    Public Function MoveUpGrid(ByVal RowsIndex As Integer, ByVal UpDown As Char, ByVal dt As DataTable, ByVal gridOjb As Stone.WinUI.AsGridData) As DataTable
        Dim b_IndexRows As Integer = RowsIndex
        If UpDown = "U" Then b_IndexRows = RowsIndex - 1 Else b_IndexRows = RowsIndex + 1
        Dim ColumnsName As String
        For i = 0 To gridOjb.Columns.Count - 1
            ColumnsName = gridOjb.Columns.Item(i).Field
            Select Case gridOjb.Columns(i).ColumnFormat
                Case Stone.WinUI.ColumnFormats.Button
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.CheckBox
                    Dim varArray As Integer = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.Image
                    Dim buf As Object = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = buf
                Case Stone.WinUI.ColumnFormats.Color
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.DataIndex
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.Date
                    Dim varArray As DateTime = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.ImageFromPath
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.ImageListIndex
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.Money
                    Dim varArray As Double = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.Text
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.TextLink
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.Time
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case Stone.WinUI.ColumnFormats.TreeView
                    Dim varArray As TreeView = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
            End Select
        Next
        Return dt
    End Function


End Module

