#Region "Imports"
Imports System.Management
Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports DAL
#End Region

Public Class DebugForm
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
    Public Sub send_sRetval(ByVal ParamArray ParaArray() As String)
        For i = 0 To 20
            sRetval(i) = ParaArray(i)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabMenuForm.TabPages.Clear()
        TabMenuForm.MdiMode = True


        pubProjectName = "TEST"
        pubServerName = "27.254.57.69"
        pubDatabaseName = "DB_IDG_TEST_DATA"
        pubDbUsername = "indigo"
        pubDbPassword = "@min9999"
        pubUserLanguage = "en-US"
        pubUserName = "Admin"
        mdiMainForm = Me
        pubMachineId = "1234-56789"
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

        Dim strSql As String
        strSql = " select 'x'"
        strSql += " ,(Select SysGroupName From SysUser Where SysUserName = '" & pubUserName & "') 'SysGroupName'"

        Dim dt As DataTable = pubGetData(Me.dal, strSql, "Data")
        'pubUseSpecialReport1 = dt.Rows(0)("useSpecialReport1").ToString

        pubUserGroup = dt.Rows(0)("SysGroupName").ToString


        strSql = "Select a.ComName,a.VatType,a.VatRate"
        strSql += " ,b.Department_code,b.DepartmentName,c.Project_code,c.ProjectName"
        strSql += " ,case when a.ProjectAliasName = '' then 'Project :' else a.ProjectAliasName end as 'ProjectAliasName' "
        strSql += " ,case when a.DepartmentAliasName = '' then 'Department :' else a.DepartmentAliasName end as 'DepartmentAliasName'"
        strSql += " ,coalesce(a.DecimalDigit,2) 'DecimalDigit'"
        strSql += " ,coalesce(a.QtyDecimalDigit,2) 'QtyDecimalDigit'"
        strSql += " ,coalesce(a.StockMinus,'0') 'StockMinus'"
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
        pubDecimalDigit = dt.Rows(0)("DecimalDigit")
        pubQtyDecimalDigit = dt.Rows(0)("QtyDecimalDigit")
        getDateServer = dt.Rows(0)("ServerDate")
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
    Private Sub cmdOpenForm_Click(sender As Object, e As EventArgs) Handles cmdOpenForm.Click
        'Dim f101 As masProject = New masProject
        'TabMenuForm.AddForm(f101, "Project", "101")
    End Sub
End Class