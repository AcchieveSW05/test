#Region "Imports"
Imports System.Management
Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports DAL
#End Region
Public Class iComponent
    Friend dal As Adapter
    Friend Shared strLang As String
    Private m_Connection As ConnectionInfo
    Dim cmdLogoff As String = "False"
    Public Property Connection() As ConnectionInfo
        Get
            Return m_Connection
        End Get
        Set(ByVal value As ConnectionInfo)
            m_Connection = value
        End Set
    End Property

#Region "Register"
    Public Sub send_sRetval(ByVal ParamArray ParaArray() As String)
        For i = 0 To 20
            sRetval(i) = ParaArray(i)
        Next

    End Sub


    Public Sub SetVariable(ByVal iProjectName As String,
                            ByVal iServerName As String,
                            ByVal iDatabaseName As String,
                            ByVal iDbUsername As String,
                            ByVal iDbPassword As String,
                            ByVal iUserLanguage As String,
                            ByVal iUserName As String,
                            ByVal imdiMainForm As Object,
                            ByVal iAllowUseTran As Boolean,
                            ByVal iMachineId As String)
        pubProjectName = iProjectName
        pubServerName = iServerName
        pubDatabaseName = iDatabaseName
        pubDbUsername = iDbUsername
        pubDbPassword = iDbPassword
        pubUserLanguage = iUserLanguage
        pubUserName = iUserName
        mdiMainForm = imdiMainForm
        pubAllowUseTran = iAllowUseTran
        pubMachineId = iMachineId
        pubRegister = True
        If Directory.Exists("C:\0_Indigo") = True Then
            If File.Exists(dirRoot & "\PrintSlip.idg") = True Then
                Dim rd As StreamReader = File.OpenText(dirRoot & "\PrintSlip.idg")
                pubPrinterSlip = rd.ReadLine
                pubSlipPaperSize = rd.ReadLine
                Dim st As String = rd.ReadLine
                Dim iReport As String = rd.ReadLine
                pubDefaultPrinter = rd.ReadLine
                rd.Close()
                If Directory.Exists(iReport) = True Then
                    pubReportDir = iReport & "\"
                Else
                    pubReportDir = "C:\0_Indigo\" & pubProjectName & "\3_TransectionReportForm\"
                End If
            End If
        End If

        Dim strAttachFile As String = ""
        If File.Exists(dirRoot & "\PathFileName.txt") = True Then
            Dim rd As StreamReader = File.OpenText(dirRoot & "\PathFileName.txt")
            strAttachFile = rd.ReadLine

            If Directory.Exists(strAttachFile & pubProjectName & "\2_AttachmentFiles") = True Then
                strAttachFile = rd.ReadLine
                strAttachFile = rd.ReadLine
                strAttachFile = rd.ReadLine
                rd.Close()
                pubAttachFileDir = strAttachFile & pubProjectName & "\2_AttachmentFiles\" & pubDatabaseName
            Else
                pubAttachFileDir = "C:\0_indigo\" & pubProjectName & "\2_AttachmentFiles\" & pubDatabaseName
            End If

            If Directory.Exists(pubAttachFileDir) = True Then
                pubAttachFileDir = pubAttachFileDir
            Else
                Directory.CreateDirectory(pubAttachFileDir)
            End If
        End If

        Me.Connection = New DAL.ConnectionInfo()
        Me.Connection.SetConnectionString(pubServerName, pubDatabaseName, pubDbUsername, pubDbPassword)
        Me.dal = New Adapter
        Me.dal.ConnectionInfo = Me.Connection

        Dim sql As String
        sql = " select "
        sql += " (Select AllowUse 'useSpecialReport1' From CustomAddon Where CustomName = 'useSpecialReport1')   'useSpecialReport1'"
        sql += " ,(Select AllowUse 'useSpecialReport2' From CustomAddon Where CustomName = 'useSpecialReport2')   'useSpecialReport2'"
        sql += " ,(Select AllowUse 'useSpecialReport3' From CustomAddon Where CustomName = 'useSpecialReport3')   'useSpecialReport3'"
        sql += " ,(Select AllowUse 'useFreeFields' From CustomAddon Where CustomName = 'useFreeFields')   'useFreeFields'"
        sql += " ,(Select AllowUse 'useLockDate' From CustomAddon Where CustomName = 'useLockDate')   'useLockDate'"
        sql += " ,(Select AllowUse 'usePaymentHold' From CustomAddon Where CustomName = 'usePaymentHold')   'usePaymentHold'"
        sql += " ,(Select AllowUse 'useSubMenuSale' From CustomAddon Where CustomName = 'useSubMenuSale')   'useSubMenuSale'"
        sql += " ,(Select AllowUse 'useSubMenuPurchase' From CustomAddon Where CustomName = 'useSubMenuPurchase')   'useSubMenuPurchase'"
        sql += " ,(Select AllowUse 'useDpManagement' From CustomAddon Where CustomName = 'useDpManagement')   'useDpManagement'"
        sql += " ,(Select AllowUse 'useCommitsion' From CustomAddon Where CustomName = 'useCommitsion')   'useCommitsion'"
        sql += " ,(Select AllowUse 'usePromotionDiscount' From CustomAddon Where CustomName = 'usePromotionDiscount')   'usePromotionDiscount'"
        sql += " ,(Select AllowUse 'usePromotionPremium' From CustomAddon Where CustomName = 'usePromotionPremium')   'usePromotionPremium'"
        sql += " ,(Select AllowUse 'useLockPeriodDay' From CustomAddon Where CustomName = 'useLockPeriodDay')   'useLockPeriodDay'"
        sql += " ,(Select AllowUse 'useBranchTransferProduct' From CustomAddon Where CustomName = 'useBranchTransferProduct')   'useBranchTransferProduct'"
        sql += " ,(Select AllowUse 'useMemberDiscount' From CustomAddon Where CustomName = 'useMemberDiscount')   'useMemberDiscount'"
        sql += " ,(Select AllowUse 'usePointRewards' From CustomAddon Where CustomName = 'usePointRewards')   'usePointRewards'"
        sql += " ,(Select AllowUse 'useSaleStandardCost' From CustomAddon Where CustomName = 'useSaleStandardCost')   'useSaleStandardCost'"
        sql += " ,(Select AllowUse 'DupplicateDocNumber' From CustomAddon Where CustomName = 'DupplicateDocNumber')  'DupplicateDocNumber'"
        sql += " ,(Select AllowUse 'PurchaseExchange' From CustomAddon Where CustomName = 'PurchaseExchange')  'PurchaseExchange'"
        sql += " ,(Select AllowUse 'AddOn' From CustomAddon Where CustomName = 'AddOn')  'AddOn'"
        sql += " ,(Select AllowUse 'PackingManagement' From CustomAddon Where CustomName = 'PackingManagement')  'PackingManagement'"
        sql += " ,(Select AllowUse 'Commission' From CustomAddon Where CustomName = 'Commission')  'Commission'"
        sql += " ,(Select AllowUse 'NonPos' From CustomAddon Where CustomName = 'NonPos')  'NonPos'"
        sql += " ,(Select AllowUse 'HideBalance' From CustomAddon Where CustomName = 'HideBalance')  'HideBalance'"
        sql += " ,(Select AllowUse 'PubSalePrice8' From CustomAddon Where CustomName = 'PubSalePrice8')  'PubSalePrice8'"
        sql += " ,(Select AllowUse 'pubEnterNewLine' From CustomAddon Where CustomName = 'pubEnterNewLine') 'pubEnterNewLine'"
        sql += " ,(Select SysGroupName From SysUser Where SysUserName = '" & pubUserName & "') 'SysGroupName'"

        Dim dt As DataTable = pubGetData(Me.dal, sql, "Data")
        pubUseSpecialReport1 = dt.Rows(0)("useSpecialReport1").ToString
        pubUseSpecialReport2 = dt.Rows(0)("useSpecialReport2").ToString
        pubUseSpecialReport3 = dt.Rows(0)("useSpecialReport3").ToString
        pubUseFreeFields = dt.Rows(0)("useFreeFields").ToString
        pubUseLockDate = dt.Rows(0)("useLockDate").ToString
        pubUsePaymentHold = dt.Rows(0)("usePaymentHold").ToString
        pubUseSubMenuSale = dt.Rows(0)("useSubMenuSale").ToString
        pubUseSubMenuPurchase = dt.Rows(0)("useSubMenuPurchase").ToString
        pubUseDpManagement = dt.Rows(0)("useDpManagement").ToString

        pubUsePromotionDiscount = dt.Rows(0)("usePromotionDiscount").ToString
        pubUsePromotionPremium = dt.Rows(0)("usePromotionPremium").ToString
        pubUseLockPeriodDay = dt.Rows(0)("useLockPeriodDay").ToString
        pubUseBranchTransferProduct = dt.Rows(0)("useBranchTransferProduct").ToString
        pubUseMemberDiscount = dt.Rows(0)("useMemberDiscount").ToString
        pubUsePointRewards = dt.Rows(0)("usePointRewards").ToString
        pubUseSaleStandardCost = dt.Rows(0)("useSaleStandardCost").ToString
        pubDupplicateDocNumber = dt.Rows(0)("DupplicateDocNumber").ToString
        pubPurchaseExchange = dt.Rows(0)("PurchaseExchange").ToString

        pubAddOn = dt.Rows(0)("AddOn").ToString
        pubUseCommitsion = dt.Rows(0)("useCommitsion").ToString
        pubNonPos = dt.Rows(0)("NonPos").ToString
        pubSalePrice8 = dt.Rows(0)("pubSalePrice8").ToString
        pubEnterNewLine = dt.Rows(0)("pubEnterNewLine").ToString
        pubUserGroup = dt.Rows(0)("SysGroupName").ToString

        If dt.Rows(0)("HideBalance").ToString = "1" Then
            HideBalanceAddOn = True
        Else
            HideBalanceAddOn = False
        End If

        Dim strSql As String
        strSql = "Select a.ComName,a.VatType,a.VatRate"
        strSql += " ,b.Department_code,b.DepartmentName,c.Project_code,c.ProjectName"
        strSql += " ,case when a.ProjectAliasName = '' then 'Project :' else a.ProjectAliasName end as 'ProjectAliasName' "
        strSql += " ,case when a.DepartmentAliasName = '' then 'Department :' else a.DepartmentAliasName end as 'DepartmentAliasName'"
        strSql += " ,case when coalesce(a.UseDocB, '0') = '1' then '1' else '0' end as 'UseDocB' "
        strSql += " ,case when coalesce(a.UseRegion, '0') = '1' then '1' else '0' end as 'UseRegion'"
        strSql += " ,coalesce(a.DecimalDigit,2) 'DecimalDigit'"
        strSql += " ,coalesce(a.QtyDecimalDigit,2) 'QtyDecimalDigit'"
        strSql += " ,coalesce(a.StockMinus,'0') 'StockMinus'"
        'strsql += " ,coalesce(a.UseFreeField,'0') 'UseFreeField'"
        strSql += " ,GetDate() 'ServerDate'"
        strSql += " from Company a With(NoLock)"
        strSql += " Left Outer Join Department b With(NoLock) on a.Department_Code= b.Department_code"
        strSql += " Left Outer Join Project c With(NoLock) on a.Project_Code= c.Project_code"
        dt = pubGetData(Me.dal, strSql, "Data")
        pubCompanyName = dt.Rows(0)("ComName").ToString
        pubVatType = dt.Rows(0)("VatType")
        pubVatRate = dt.Rows(0)("VatRate")
        pubDefaultProject(0) = dt.Rows(0)("Project_Code").ToString
        pubDefaultProject(1) = dt.Rows(0)("ProjectName").ToString
        pubDefaultProject(2) = dt.Rows(0)("ProjectAliasName").ToString
        pubDefaultDepartment(0) = dt.Rows(0)("Department_Code").ToString
        pubDefaultDepartment(1) = dt.Rows(0)("DepartmentName").ToString
        pubDefaultDepartment(2) = dt.Rows(0)("DepartmentAliasName").ToString
        pubUseRegion = dt.Rows(0)("UseRegion").ToString
        pubDecimalDigit = dt.Rows(0)("DecimalDigit")
        pubQtyDecimalDigit = dt.Rows(0)("QtyDecimalDigit")
        getDateServer = dt.Rows(0)("ServerDate")
        '       pubUseFreeField = dt.Rows(0)("UseFreeField").ToString
        If File.Exists(dirRoot & "\PrintSlip.idg") = True Then
            Dim rd As StreamReader = File.OpenText(dirRoot & "\PrintSlip.idg")
            pubPrinterSlip = rd.ReadLine
            pubSlipPaperSize = rd.ReadLine
            rd.Close()
        End If

        strSql = "IF EXISTS ( SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('SysFileAccess'))"
        strSql += " Select * from SysFileAccess"
        strSql += " Else"
        strSql += " Select * From (Select Null  )x(xx) Where xx is not null"

        dt = New DataTable
        dt = pubGetData(Me.dal, strSql, "DataList")
        If dt.Rows.Count >= 1 Then
            DirFileAttachment = dt.Rows(0)("FtpUrl").ToString
            FtpUsername = dt.Rows(0)("FtpUserName").ToString
            FtpPassword = dt.Rows(0)("FtpPassword").ToString
            pubOnLine = dt.Rows(0)("UseFtp").ToString

            DirUserName = dt.Rows(0)("DirUserName").ToString
            DirPassword = dt.Rows(0)("DirPassword").ToString
        End If
        If pubUserLanguage = "en-US" Then
            pubMsgDupplicateData = "Duplicate the existing data in the database"
            pubMsgRequestData = "Fill in the requested data is not complete"
            pubMsgDupplicateDocument = "Duplicate document numter in the database"
            pubMsgOutOfPeriod = "Date is not in the period"
            pubMsgDocUse = "Not alow to save data, Document is use to refer in other page"
        Else
            pubMsgDupplicateData = "รหัสหรือชื่อ ที่กรอกซ้ำกับในฐานข้อมูล"
            pubMsgRequestData = "กรอกข้อมูลที่ระบบต้องการไม่ครบ"
            pubMsgDupplicateDocument = "เลขที่เอกสารซ้ำกับในฐานข้อมูล"
            pubMsgOutOfPeriod = "วันที่บันทึก ไม่อยู่ในงวดการทำงาน"
            pubMsgDocUse = "ไม่อนุญาติให้แก้ไข เนื่องจาก เอกสารถูกนำไปใช้ต่อแล้ว"
        End If



    End Sub

    Public Function GenPassword(ByVal Password As String) As String
        Dim MD5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim Bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(Password)
        Dim Result As String = ""
        Dim strTemp As String = ""
        Bytes = MD5.ComputeHash(Bytes)
        For Each b As Byte In Bytes
            Result += b.ToString
        Next
        'Return Result
        For x = 0 To Result.Length - 1 Step 2
            Select Case Result.Substring(x, 1)
                Case "0" : strTemp = strTemp & "!"
                Case "1" : strTemp = strTemp & "@"
                Case "2" : strTemp = strTemp & "#"
                Case "3" : strTemp = strTemp & "$"
                Case "4" : strTemp = strTemp & "%"
                Case "5" : strTemp = strTemp & "^"
                Case "6" : strTemp = strTemp & "&"
                Case "7" : strTemp = strTemp & "*"
                Case "8" : strTemp = strTemp & "("
                Case "9" : strTemp = strTemp & ")"
            End Select
        Next
        Return strTemp
    End Function
    Function GetMD5Code(ByVal HarddiskModel As String) As String
        Dim MD5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim Bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(HarddiskModel)
        Dim Result As Double
        Dim strTemp As String = ""
        Bytes = MD5.ComputeHash(Bytes)
        For Each b As Byte In Bytes
            Result += Int(b.ToString) * 256
            'Result += Int(b.ToString) * 7
        Next
        Return Result
    End Function
    Function GetMD5Code2(ByVal HarddiskModel As String) As String
        Dim MD5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim Bytes() As Byte = System.Text.Encoding.ASCII.GetBytes(HarddiskModel)
        Dim Result As Double
        Dim strTemp As String = ""
        Bytes = MD5.ComputeHash(Bytes)
        For Each b As Byte In Bytes
            Result += Int(b.ToString) * 7
        Next
        Return Result
    End Function
    Public Function getX(ByVal MachineId As String) As String
        Dim intXXX As Double = 0
        Dim intYYY As Integer = 0
        Dim HddId As String = ""
        intXXX = GetMD5Code(MachineId)
        HddId = intXXX * 3
        HddId = HddId.Substring(HddId.Length - 6, 6)
        Return HddId
    End Function
    Public Function getX_G2(ByVal MachineId As String) As String
        Dim intXXX As Double = 0
        Dim intYYY As Integer = 0
        Dim HddId As String = ""
        intXXX = GetMD5Code(MachineId)
        HddId = intXXX * 3
        HddId = HddId.Substring(HddId.Length - 6, 6)
        Return HddId
    End Function
    Public Function getRegCode_G2(ByVal MachineId As String, ByVal ClientServer As Boolean) As String
        Dim intId As Long
        Dim strResult As String
        Dim intLength As Byte
        intLength = Len(MachineId)
        MachineId = Mid(MachineId, 1, 8)
        'strId = Mid(getCPUId(), 1, 8)
        'TextBox1.Text = strId
        intId = HexToDecimal(MachineId) / 3
        If ClientServer = True Then
            intId = Mid(intId, 1, 10)
            strResult = Format(intId, "0000000000")
        Else
            intId = Mid(intId, 1, 8)
            strResult = Format(intId, "00000000")
        End If
        Return strResult
    End Function
    Public Function getRegKey_G2(ByVal MachineId As String, ByVal ClientServer As Boolean) As String
        Dim strResult As String
        Dim intHw_id As Long
        Dim a1, a2 As String
        a1 = MachineId
        'getX(txtMachineId.Text.Replace("-", ""))
        a2 = getX_G2(a1)
        If ClientServer = True Then
            intHw_id = (a1 * 22 / 7) + a2 + 101
        Else
            intHw_id = (a1 * 22 / 7) + a2 + 100
        End If
        strResult = Format(intHw_id, "00000000")
        strResult = strResult.Substring(strResult.Length - 8, 8)
        'MsgBox(strResult)
        Return strResult
    End Function
    Public Function getRegKey_G3(ByVal MachineId As String) As String
        Dim strResult As String
        Dim intHw_id As Long
        Dim a2 As String
        'getX(txtMachineId.Text.Replace("-", ""))
        a2 = getX_G2(MachineId)
        intHw_id = (MachineId * 22 / 7) + a2 + 101
        strResult = Format(intHw_id, "00000000")
        strResult = strResult.Substring(strResult.Length - 8, 8)
        'MsgBox(strResult)
        Return strResult
    End Function
    Public Function HexToDecimal(ByVal Hex As String) As Double
        Dim i As Integer
        ' เก็บค่าเลขฐาน 10 เป็นตัวแปรแบบ Double มีขนาด 8 ไบต์
        ' หากกำหนดแบบ Long จะได้ค่าเลขฐาน 10 ไม่เกิน 2,147,483,647 ค่า
        Dim Dec As Double

        ' ตรวจสอบว่าหลักนั้นมีค่า A - F หรือไม่ หากใช่ต้องเปลี่ยนเป็นเลขฐาน 10 ก่อน
        ' เช่น A = 10, B = 11, C = 12 , ... F = 15
        Dim Hex2Dec As Byte

        ' ตัวแปรกำหนดค่าเลขยกกำลังของแต่ละหลัก จาก 0, 1, 2, 3 ... ไปเรื่อยๆจนครบจำนวนหลักฐาน 16
        Dim HexWeight As Byte

        ' เริ่มต้นให้เป็น 0 เพราะต้องให้ 16 ยกกำลัง 0 และ เพิ่มขึ้นทีละ 1 จนกว่าจะครบจำนวนจำนวนหลัก
        HexWeight = 0

        ' เป็นการคำนวณหาจากหลักขวามือสุด ไปทางหลักซ้ายมือสุด
        ' ลดค่าความยาวของเลขฐาน 16 ลงครั้งละ 1 หลัก
        ' โดยปกติเรามักจะถนัดอ่านจากซ้ายไปขวา ทำให้เขียนโปรแกรมได้ง่ายขึ้น ... พอเจอแบบนี้อาจงงกัน
        ' ยกตัวอย่างเช่น A3F (มีความยาว = 3) ... ต้องลองทำการ Debug Program ดูด้วยน่ะครับ
        ' รอบแรก i จะอ่านค่าเริ่มต้นได้ 3 นั่นคือคำสั่ง Mid$(Hex, 3, 1) ก็อ่านค่าได้หลักที่ 3 (1 ตัว) คือ F
        ' รอบที่สอง i จะถูกลดค่าลง 1 (เหลือ 2) นั่นคือคำสั่ง Mid$(Hex, 2, 1) ก็จะอ่านค่าในหลักที่ 2 (1 ตัว) คือ 3
        ' รอบที่สาม i จะถูกลดค่าลง 1 (เหลือ 1) นั่นคือคำสั่ง Mid$(Hex, 1, 1) ก็จะอ่านค่าในหลักที่ 1 (1 ตัว) คือ A
        For i = Len(Hex) To 1 Step -1

            ' ทดสอบหาค่าตัวอักษร A - F ที่แทนเลขฐาน 10 ระหว่าง 10 - 15 ก่อน
            Select Case Mid$(Hex, i, 1)
                Case "A"
                    Hex2Dec = 10
                Case "B"
                    Hex2Dec = 11
                Case "C"
                    Hex2Dec = 12
                Case "D"
                    Hex2Dec = 13
                Case "E"
                    Hex2Dec = 14
                Case "F"
                    Hex2Dec = 15
                Case Else

                    ' หากเป็นค่า 0 - 9 ก็ใช้ค่าของตัวมันเองไปเลย (เพราะเท่ากับ ฐาน 10 อยู่แล้ว)
                    Hex2Dec = Mid$(Hex, i, 1)

            End Select

            ' ตรวจสอบว่าหลักนั้นเป็น 0 หรือไม่ หากใช่ให้ข้ามไปเลย เพราะ 0 คูณกับอะไรก็ได้ 0 เสมอ
            If Hex2Dec <> 0 Then Dec = Dec + ((16 ^ HexWeight) * Hex2Dec)

            ' เพิ่มค่าเลขยกกำลังขึ้นอีก 1
            HexWeight = HexWeight + 1

        Next

        ' ส่งค่ากลับผ่านชื่อฟังค์ชั่นตัวมันเอง
        HexToDecimal = Dec

    End Function
    Public Function ConnString(ByVal ServerName As String, ByVal DatabaseName As String) As String
        Return "Data Source=" & ServerName & ";Initial Catalog=" & DatabaseName & "; User Id=indigo;Password=@min9999;"
    End Function
    Public Function getRegCode(ByVal MachineId As String, ByVal ClientServer As Boolean) As String

        Dim intId As Long
        Dim strResult As String
        Dim intLength As Byte

        intLength = Len(MachineId)
        MachineId = Mid(MachineId, 1, 8)
        'strId = Mid(getCPUId(), 1, 8)
        'TextBox1.Text = strId
        intId = HexToDecimal(MachineId) / 3
        If ClientServer = True Then
            intId = Mid(intId, 1, 10)
            strResult = Format(intId, "0000000000")
        Else
            intId = Mid(intId, 1, 8)
            strResult = Format(intId, "00000000")
        End If
        Return strResult
    End Function
    Public Function getRegKey(ByVal MachineId As String, ByVal ClientServer As Boolean) As String
        Dim strResult As String
        Dim intHw_id As Long
        Dim a1, a2 As String
        a1 = MachineId
        'getX(txtMachineId.Text.Replace("-", ""))
        a2 = getX_G2(a1)
        If ClientServer = True Then
            intHw_id = (a1 * 22 / 7) + a2 + 101
        Else
            intHw_id = (a1 * 22 / 7) + a2 + 100
        End If
        strResult = Format(intHw_id, "00000000")
        strResult = strResult.Substring(strResult.Length - 8, 8)

        'MsgBox(strResult)


        Return strResult
    End Function





    'Function RexecUpdateCheque(ByVal code As String) '-----
    '    Dim para As New ParameterList
    '    Dim sql As String
    '    Dim bufDt As DataTable
    '    sql = "  SELECT * FROM PaidByCheque With(NoLock)"
    '    sql += " Where DocNumber =@DocNumber"
    '    sql += " And   DocSource =@DocSource"
    '    para.Add("@DocNumber", String.Format("{0}", code))
    '    para.Add("@DocSource", String.Format("{0}", "Sale"))

    '    bufDt = pubGetData(Me.dal, sql, "PaidByCheque", para)
    '    bufDt.TableName = "PaidByCheque"
    '    para.Items.Clear()

    '    If txtAmountCheque.Value <= 0 Then
    '        For a = 0 To bufDt.Rows.Count - 1
    '            bufDt.Rows(a).Delete()
    '        Next
    '        Return bufDt
    '    End If

    '    Dim glineNum As Integer = 0
    '    Dim c As Integer = 0
    '    Dim strChequeNumber As String = ""
    '    Dim strBankBook_Code As String = ""
    '    Dim strBank_Code As String = ""
    '    Dim strBranchName As String = ""
    '    Dim strChequeDueDate As String = ""
    '    Dim strAmount As String = ""
    '    Dim rowcount As Integer = bufDt.Rows.Count
    '    For i = 0 To dtPaymentCheque.Rows.Count - 1
    '        c = 0
    '        glineNum = i + 1
    '        strChequeNumber = dtPaymentCheque.Rows.Item(i).Cells("ChequeNo").Value
    '        'strBankBook_Code = dtPaymentCheque.Rows.Item(i).Cells("BankBook_Code").Value
    '        strBank_Code = dtPaymentCheque.Rows.Item(i).Cells("Bank_Code").Value
    '        strBranchName = dtPaymentCheque.Rows.Item(i).Cells("BranchName").Value
    '        strChequeDueDate = dtPaymentCheque.Rows.Item(i).Cells("ChequeDueDate").Value
    '        strAmount = dtPaymentCheque.Rows.Item(i).Cells("AmountGrandTotal").Value
    '        For x = 0 To bufDt.Rows.Count - 1
    '            If glineNum = bufDt.Rows.Item(x)("LineNumber") _
    '            And strChequeNumber = bufDt.Rows.Item(x)("ChequeNo") Then
    '                bufDt.Rows.Item(x)("DocNumber") = code
    '                bufDt.Rows.Item(x)("LineNumber") = i + 1
    '                bufDt.Rows.Item(x)("ChequeNo") = strChequeNumber
    '                bufDt.Rows.Item(x)("Bank_Code") = strBank_Code
    '                bufDt.Rows.Item(x)("BankBook_Code") = strBankBook_Code
    '                bufDt.Rows.Item(x)("BankBranchName") = strBranchName
    '                bufDt.Rows.Item(x)("AmountGrandTotal") = strAmount
    '                bufDt.Rows.Item(x)("ChequeDueDate") = strChequeDueDate
    '                bufDt.Rows.Item(x)("ChequeReceiptDate") = CDate(txtDocDate.Value)
    '            Else
    '                c += 1
    '            End If
    '        Next
    '        If c = bufDt.Rows.Count And strChequeNumber <> "" Then
    '            Dim newRows As DataRow = bufDt.NewRow
    '            newRows("PaidType") = "R"
    '            newRows("DocSource") = "Sale"
    '            newRows("DocNumber") = code
    '            newRows("LineNumber") = i + 1
    '            newRows("ChequeNo") = strChequeNumber
    '            newRows("Bank_Code") = strBank_Code
    '            newRows("BankBook_Code") = strBankBook_Code
    '            newRows("BankBranchName") = strBranchName
    '            newRows("ChequeDueDate") = strChequeDueDate
    '            newRows("AmountGrandTotal") = strAmount
    '            newRows("AmountBankFee") = 0.0
    '            newRows("ChequeCurrentStatus") = "0"
    '            newRows("ChequeReceiptDate") = CDate(txtDocDate.Value)
    '            newRows("ChequeSendOutDate") = strDefDeteTime
    '            newRows("ChequePassDate") = strDefDeteTime
    '            newRows("ChequeReturnDate") = strDefDeteTime
    '            newRows("DocRefNumber") = ""
    '            newRows("DocRefDate") = strDefDeteTime
    '            newRows("AmountBankFee") = 0.0
    '            newRows("i_Code") = txtCus_Code.Text
    '            bufDt.Rows.Add(newRows)
    '        End If
    '    Next
    '    If rowcount >= 1 Then
    '        Dim strChequeNumberNew As String
    '        Dim strChequeNumberOld As String
    '        Dim lineNumNew As String
    '        Dim lineNumOld As String
    '        For i = 0 To rowcount - 1
    '            lineNumOld = bufDt.Rows.Item(i)("LineNumber")
    '            strChequeNumberOld = bufDt.Rows.Item(i)("ChequeNo")
    '            For x = 0 To dtPaymentCheque.Rows.Count - 1
    '                lineNumNew = x + 1
    '                strChequeNumberNew = dtPaymentCheque.Rows.Item(0).Cells("ChequeNo").Value
    '                If strChequeNumberNew = strChequeNumberOld And lineNumNew = lineNumOld Then
    '                    c = 1
    '                    Exit For
    '                Else
    '                    c = 0
    '                End If
    '            Next
    '            If c = 0 Then
    '                bufDt.Rows(i).Delete()
    '            End If
    '        Next
    '    End If

    '    Return bufDt
    'End Function
    'Function RexecUpdateCreditCard(ByVal code As String)
    '    Dim para As New ParameterList
    '    Dim sql As String
    '    Dim bufDt As DataTable
    '    sql = "  SELECT * FROM PaidByCreditCard With(NoLock) "
    '    sql += " Where DocNumber =@DocNumber"
    '    sql += " And   DocSource =@DocSource"
    '    para.Add("@DocNumber", String.Format("{0}", code))
    '    para.Add("@DocSource", String.Format("{0}", "Sale"))
    '    bufDt = pubGetData(Me.dal, sql, "PaidByCreditCard", para)
    '    bufDt.TableName = "PaidByCreditCard"
    '    para.Items.Clear()
    '    For a = 0 To bufDt.Rows.Count - 1
    '        bufDt.Rows(a).Delete()
    '    Next

    '    Dim glineNum As Integer = 0
    '    Dim c As Integer = 0
    '    Dim strCreditCardNo As String = ""
    '    Dim strCreditCardSlipNo As String = ""
    '    Dim strBankBook_Code As String = ""
    '    Dim strBank_Code As String = ""
    '    Dim strBankBranchName As String = ""
    '    Dim strCreditCardReceiptDate As String = ""
    '    Dim strAmount As String = ""
    '    Dim rowcount As Integer = bufDt.Rows.Count
    '    For i = 0 To dtPaymentCreditCard.Rows.Count - 1
    '        c = 0
    '        glineNum = i + 1
    '        strCreditCardNo = dtPaymentCreditCard.Rows.Item(i).Cells("CreditCardNo").Value
    '        strCreditCardSlipNo = dtPaymentCreditCard.Rows.Item(i).Cells("SlipNo").Value
    '        strBank_Code = dtPaymentCreditCard.Rows.Item(i).Cells("Bank_Code").Value
    '        strAmount = dtPaymentCreditCard.Rows.Item(i).Cells("AmountGrandTotal").Value
    '        If strCreditCardNo <> "" Then
    '            Dim newRows As DataRow = bufDt.NewRow
    '            newRows("PaidType") = "R"
    '            newRows("DocSource") = "Sale"
    '            newRows("DocNumber") = code
    '            newRows("LineNumber") = i + 1
    '            newRows("CreditCardNo") = strCreditCardNo
    '            newRows("SlipNo") = strCreditCardSlipNo
    '            newRows("Bank_Code") = strBank_Code
    '            newRows("AmountGrandTotal") = strAmount
    '            newRows("CreditCardCurrentStatus") = "0"
    '            newRows("CreditCardPassDate") = strDefDeteTime
    '            newRows("DocRefNumber") = ""
    '            newRows("DocRefDate") = strDefDeteTime
    '            newRows("BankBook_Code") = ""
    '            newRows("AmountBankFee") = 0.0
    '            bufDt.Rows.Add(newRows)
    '        End If
    '    Next
    '    Return bufDt
    'End Function
    'Function RexecUpdateBank(ByVal code As String)
    '    Dim para As New ParameterList
    '    Dim sql As String
    '    Dim bufDt As DataTable
    '    Dim glineNum As Integer = 0
    '    Dim strBankBookCode As String = ""
    '    Dim strAmount As String = ""

    '    sql = "  SELECT * FROM PaidByBank With(NoLock)"
    '    sql += " Where DocNumber =@DocNumber"
    '    sql += " And   DocSource =@DocSource"
    '    para.Add("@DocNumber", String.Format("{0}", code))
    '    para.Add("@DocSource", String.Format("{0}", "Sale"))
    '    bufDt = pubGetData(Me.dal, sql, "PaidByBank", para)
    '    bufDt.TableName = "PaidByBank"
    '    para.Items.Clear()

    '    If txtAmountBank.Value <= 0 Then
    '        For a = 0 To bufDt.Rows.Count - 1
    '            bufDt.Rows(a).Delete()
    '        Next
    '        Return bufDt
    '    End If

    '    For i = 0 To dtPaymentBank.Rows.Count - 1
    '        glineNum = i + 1
    '        strBankBookCode = dtPaymentBank.Rows.Item(i).Cells("BankBook_Code").Value
    '        strAmount = dtPaymentBank.Rows.Item(i).Cells("AmountGrandTotal").Value
    '        If strBankBookCode <> "" Then
    '            Dim newRows As DataRow = bufDt.NewRow
    '            newRows("PaidType") = "R"
    '            newRows("DocSource") = "Sale"
    '            newRows("DocNumber") = code
    '            newRows("LineNumber") = glineNum
    '            newRows("BankBook_Code") = strBankBookCode
    '            newRows("AmountGrandTotal") = strAmount
    '            newRows("AmountBankFee") = 0.0
    '            bufDt.Rows.Add(newRows)
    '        End If
    '    Next

    '    Return bufDt
    'End Function
    'Function RexecUpdateBankBookCard(ByVal code As String)
    '    Dim para As New ParameterList
    '    Dim sql As String
    '    Dim bufDt As DataTable
    '    sql = "  Select * From BankBookCard With(NoLock)"
    '    sql += " Where DocNumber =@DocNumber"
    '    sql += " And   DocSource =@DocSource"
    '    para.Add("@DocNumber", String.Format("{0}", code))
    '    para.Add("@DocSource", String.Format("{0}", "Sale"))
    '    bufDt = pubGetData(Me.dal, sql, "BankBookCard", para)
    '    bufDt.TableName = "BankBookCard"
    '    para.Items.Clear()

    '    For i = 0 To dtPaymentBank.Rows.Count - 1
    '        With bufDt
    '            If dtPaymentBank.Rows.Item(i).Cells("BankBook_Code").Value <> "" Then
    '                Dim newRows As DataRow = bufDt.NewRow
    '                newRows("BankBook_Code") = dtPaymentBank.Rows.Item(i).Cells("BankBook_Code").Value
    '                newRows("BankBookDate") = CDate(txtDocDate.Value)
    '                newRows("DocSource") = "Sale"
    '                newRows("DocNumber") = txtDocNumber.Text
    '                newRows("DocDate") = CDate(txtDocDate.Value)
    '                newRows("LineNumber") = i + 1
    '                newRows("AmountIn") = dtPaymentBank.Rows.Item(i).Cells("AmountGrandTotal").Value
    '                newRows("AmountOut") = 0
    '                newRows("AmountBalance") = 0
    '                newRows("sOrder") = 0
    '                newRows("Remark") = "ขายสินค้า " & txtCusName.Text
    '                newRows("ChequePassBank") = ""
    '                newRows("ChequeNumber") = ""
    '                bufDt.Rows.Add(newRows)
    '            End If
    '        End With
    '    Next
    '    Return bufDt
    'End Function
    'Function RexecUpdateOther(ByVal code As String)
    '    Dim para As New ParameterList
    '    Dim sql As String
    '    Dim bufDt As DataTable
    '    sql = "  SELECT * FROM PaidByOther With(Nolock)"
    '    sql += " Where DocNumber =@DocNumber"
    '    sql += " And   DocSource =@DocSource"
    '    para.Add("@DocNumber", String.Format("{0}", code))
    '    para.Add("@DocSource", String.Format("{0}", "Sale"))

    '    bufDt = pubGetData(Me.dal, sql, "PaymentOther", para)
    '    bufDt.TableName = "PaidByOther"
    '    para.Items.Clear()
    '    For a = 0 To bufDt.Rows.Count - 1
    '        bufDt.Rows(a).Delete()
    '    Next
    '    If txtAmountOther.Value = 0 Then Return bufDt

    '    Dim glineNum As Integer = 0
    '    Dim c As Integer = 0
    '    Dim strPaidOtherCode As String = ""
    '    Dim strAmount As String = ""
    '    Dim rowcount As Integer = bufDt.Rows.Count
    '    For i = 0 To dtPaymentOther.Rows.Count - 1
    '        c = 0
    '        glineNum = i + 1
    '        ' MsgBox(gridPaymentOther.SelectedRow("PaidOther_Code").ToString)
    '        strPaidOtherCode = dtPaymentOther.Rows.Item(i).Cells("PaidOther_Code").Value
    '        strAmount = dtPaymentOther.Rows.Item(i).Cells("AmountGrandTotal").Value

    '        If c = bufDt.Rows.Count And strPaidOtherCode <> "" Then
    '            Dim newRows As DataRow = bufDt.NewRow
    '            newRows("PaidType") = "R"
    '            newRows("DocSource") = "Sale"
    '            newRows("DocNumber") = code
    '            newRows("LineNumber") = glineNum
    '            newRows("PaidOther_Code") = strPaidOtherCode
    '            newRows("AmountGrandTotal") = strAmount
    '            bufDt.Rows.Add(newRows)
    '        End If
    '    Next

    '    Return bufDt
    'End Function




#End Region
End Class
