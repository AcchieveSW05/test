#Region "Import"
Imports System.Data
Imports Stone.WinUI
Imports System.Windows.Forms
Imports DAL
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.IO
Imports System.Globalization
#End Region



Module AttachmentFile
    Dim strSql As String
    Dim strDirAttFolderData As String = pubFtpAttachmentFile


    Sub DeleteRowAttachment(ByRef DocNumber As String, ByVal DocSource As String, ByVal da As DAL.Adapter, ByVal strDelFile As String)
        If MsgBox("การลบไฟล์แนบ ระบบจะทำการลบไฟล์เอกสารทันที่ โดยไม่ต้องผ่านการกดปุ่มบันทึกด้านบน" & vbNewLine & _
                  "คุณต้องการลบไฟล์แนบนี้หรือไม่ ?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Critical, "") = Microsoft.VisualBasic.MsgBoxResult.No Then Exit Sub
        If pubOnLine = "1" Then
            Dim strDirForm As String = strDirAttFolderData & "/" & DocSource
            Try
                Dim FTPDelReq As System.Net.FtpWebRequest = System.Net.WebRequest.Create(New Uri(strDirForm & "/" & strDelFile))
                FTPDelReq.Credentials = New Net.NetworkCredential(FtpUsername, FtpPassword)
                FTPDelReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
                Dim FTPDelResp As System.Net.FtpWebResponse = FTPDelReq.GetResponse
            Catch ex As Exception
            End Try
        Else
            Dim strDirForm As String = strDirAttFolderData & "\" & DocSource
            If File.Exists(strDirForm & "\" & strDelFile) = True Then
                File.Delete(strDirForm & "\" & strDelFile)
            End If
        End If

        Try
            strSql = "Delete From  AttachmentFile"
            strSql += " Where DocSource = @DocSource And DocNumber = @DocNum And FileName=@FileName"
            Dim para As New DAL.ParameterList
            para.Add("@DocSource", DocSource)
            para.Add("@DocNum", DocNumber)
            para.Add("@FileName", strDelFile)
            da.Open()
            da.ExecuteNonQuery(strSql, para)
            da.Open()
        Catch ex As Exception
        End Try
    End Sub
    Function pubGetDataAttachment(ByRef DocNumber As String, ByVal DocSource As String, ByVal da As DAL.Adapter) As DataTable
        Try
            Dim strDirForm As String = ""
            If pubOnLine = "1" Then
                strDirForm = strDirAttFolderData & "/" & DocSource & "/"
            Else
                strDirForm = strDirAttFolderData & "\" & DocSource & "\"
            End If
            strSql = "  SELECT LineNumber as LineNumber, FileName as 'iFileName'"
            strSql += " ,'" & strDirForm & "' as 'iPathFileName', '' as 'iOpen'"
            strSql += " ,Case When FileDescription is null Then FileName Else FileDescription End 'FileDescription'"
            strSql += " FROM AttachmentFile With(NoLock)"
            strSql += " Where DocSource = @DocSource And DocNumber = @DocNum"
            Dim para As New DAL.ParameterList
            para.Add("@DocSource", String.Format("{0}", DocSource))
            para.Add("@DocNum", String.Format("{0}", DocNumber))
            Return pubGetData(da, strSql, "RefDocFile", para)
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
    Public Function pubExecUpdateAttachmentFile(ByVal code As String, ByVal DocSource As String, ByVal da As DAL.Adapter, ByVal dtAtt As DataTable) As DataTable
        Dim strSql As String = ""
        Dim FileDescription As String = ""
        strSql = "IF  EXISTS ( SELECT name FROM sys.columns WHERE object_id = OBJECT_ID('AttachmentFile') And name='FileDescription')"
        strSql += " Select '1' 'iFlag' Else Select  '0' 'iFlag'"
        FileDescription = pubGetData(da, strSql, "XX").Rows(0)("iFlag")
        Dim dtList As DataTable
        Dim para As New DAL.ParameterList
        strSql = "  Select * From AttachmentFile With(NoLock)"
        strSql += " Where DocSource = @DocSource And DocNumber = @DocNum"
        para.Add("@DocSource", String.Format("{0}", DocSource))
        para.Add("@DocNum", String.Format("{0}", code))
        dtList = pubGetData(da, strSql, "AttachmentFile", para)
        dtList.TableName = "AttachmentFile"
        para.Items.Clear()
        Dim rowcount As Integer = dtList.Rows.Count
        If dtAtt.Rows.Count <= 0 Then Return dtList
        Dim strDirForm As String = ""
        Dim glineNum As Integer
        Dim gFileName As String
        Dim gPathFileName As String
        Dim gFileDescription As String = ""
        Dim sourceFile As String
        Dim DestFileName As String
        For d = 0 To dtList.Rows.Count - 1
            dtList.Rows(d).Delete()
        Next
        If pubOnLine = "1" Then
            strDirForm = strDirAttFolderData & "/" & DocSource
            Try
                'สร้าง folder เก็บไฟล์
                Dim FTPDelReq As System.Net.FtpWebRequest = System.Net.WebRequest.Create(New Uri(strDirAttFolderData))
                FTPDelReq.Credentials = New Net.NetworkCredential(FtpUsername, FtpPassword)
                FTPDelReq.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory
                FTPDelReq.UsePassive = True
                FTPDelReq.UseBinary = True
                FTPDelReq.KeepAlive = False
                ' FTPDelReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
                Dim FTPDelResp As System.Net.FtpWebResponse = FTPDelReq.GetResponse
            Catch ex As Exception
                Debug.Print(Err.Description)
            End Try
            Try
                'สร้าง folder เก็บไฟล์
                Dim FTPDelReq As System.Net.FtpWebRequest = System.Net.WebRequest.Create(New Uri(strDirForm))
                FTPDelReq.Credentials = New Net.NetworkCredential(FtpUsername, FtpPassword)
                FTPDelReq.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory
                FTPDelReq.UsePassive = True
                FTPDelReq.UseBinary = True
                FTPDelReq.KeepAlive = False
                ' FTPDelReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
                Dim FTPDelResp As System.Net.FtpWebResponse = FTPDelReq.GetResponse
            Catch ex As Exception
                Debug.Print(Err.Description)
            End Try

            Dim c As Integer
            For i = 0 To dtAtt.Rows.Count - 1
                c = 0
                glineNum = i + 1
                gFileName = dtAtt(i)("iFileName")
                gPathFileName = dtAtt(i)("iPathFileName") & gFileName
                If FileDescription = "1" Then gFileDescription = dtAtt(i)("FileDescription")
                sourceFile = gPathFileName
                DestFileName = strDirForm & "/" & code & "-" & glineNum & Path.GetExtension(gPathFileName)
                'For x = 0 To dtList.Rows.Count - 1
                '    If glineNum = dtList.Rows.Item(x)("LineNumber") Then
                '        Try
                '            If dtAtt(i)("iFileName") <> dtList.Rows.Item(x)("FileName") Then
                '                Dim FTPDelReq As System.Net.FtpWebRequest = System.Net.WebRequest.Create(New Uri(strDirForm & "/" & dtList.Rows.Item(x)("FileName")))
                '                FTPDelReq.Credentials = New Net.NetworkCredential(FtpUsername, FtpPassword)
                '                FTPDelReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
                '                Dim FTPDelResp As System.Net.FtpWebResponse = FTPDelReq.GetResponse
                '                dtList.Rows.Item(x)("FileName") = code & "-" & glineNum & Path.GetExtension(gPathFileName)
                '            End If

                '        Catch ex As Exception
                '            MsgBox("Error Not Connect FTP ** ")
                '        End Try
                '        Exit For
                '    Else
                '        c += 1
                '    End If
                'Next

                Dim newRows As DataRow = dtList.NewRow
                newRows("DocNumber") = code
                newRows("LineNumber") = glineNum
                newRows("DocSource") = DocSource
                newRows("FileName") = code & "-" & glineNum & Path.GetExtension(gPathFileName)
                If FileDescription = "1" Then newRows("FileDescription") = dtAtt(i)("FileDescription")
                dtList.Rows.Add(newRows)

                'MsgBox(sourceFile.ToUpper.IndexOf("FTP"))
                Dim sourceFile2 As String = ""
                If sourceFile.ToUpper.IndexOf("FTP") > -1 AndAlso sourceFile <> DestFileName Then
                    sourceFile2 = Path.GetTempPath & Now.Date.ToString & Now.TimeOfDay.ToString.Replace(".", "") & Path.GetExtension(gPathFileName)
                    sourceFile2 = sourceFile2.Replace(" ", "")
                    sourceFile2 = sourceFile2.Replace(":", "")
                    sourceFile2 = sourceFile2.Replace("/", "")
                    My.Computer.Network.DownloadFile(sourceFile, sourceFile2, FtpUsername, FtpPassword)

                    Try
                        Dim FTPDelReq As System.Net.FtpWebRequest = System.Net.WebRequest.Create(New Uri(sourceFile))
                        FTPDelReq.Credentials = New Net.NetworkCredential("indigo", "@min9999")
                        FTPDelReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
                        Dim FTPDelResp As System.Net.FtpWebResponse = FTPDelReq.GetResponse
                    Catch ex As Exception
                    End Try
                    sourceFile = sourceFile2

                End If
                If File.Exists(sourceFile) = True AndAlso sourceFile <> DestFileName Then
                    My.Computer.Network.UploadFile(sourceFile, DestFileName, FtpUsername, FtpPassword)
                End If
            Next
            rowcount = dtList.Rows.Count

        Else
            strDirForm = strDirAttFolderData & "\" & DocSource
            If Directory.Exists(strDirForm) = False Then
                Directory.CreateDirectory(strDirForm)
            End If
            Dim c As Integer
            For i = 0 To dtAtt.Rows.Count - 1
                c = 0

                glineNum = i + 1
                gFileName = dtAtt(i)("iFileName")

                gPathFileName = dtAtt(i)("iPathFileName") & gFileName
                sourceFile = gPathFileName
                DestFileName = strDirForm & "\" & code & "-" & glineNum & Path.GetExtension(gPathFileName)
                If FileDescription = "1" Then gFileDescription = dtAtt(i)("FileDescription")

                Dim newRows As DataRow = dtList.NewRow
                newRows("DocNumber") = code
                newRows("LineNumber") = glineNum
                newRows("DocSource") = DocSource
                newRows("FileName") = code & "-" & glineNum & Path.GetExtension(gPathFileName)
                If FileDescription = "1" Then newRows("FileDescription") = gFileDescription
                dtList.Rows.Add(newRows)

                Dim sourceFile2 As String = ""
                If sourceFile <> DestFileName Then
                    sourceFile2 = Path.GetTempPath & Now.Date.ToString & Now.TimeOfDay.ToString.Replace(".", "") & Path.GetExtension(gPathFileName)
                    sourceFile2 = sourceFile2.Replace(" ", "")
                    sourceFile2 = sourceFile2.Replace(":", "")
                    sourceFile2 = sourceFile2.Replace("/", "")
                    File.Copy(sourceFile, sourceFile2, True)
                    File.Delete(sourceFile)
                    sourceFile = sourceFile2
                End If
                If File.Exists(sourceFile) = True AndAlso sourceFile <> DestFileName Then
                    File.Copy(sourceFile, DestFileName, True)
                End If
            Next
            rowcount = dtList.Rows.Count

        End If
        Return dtList
    End Function

    Public Sub AttactFile_ButtonClick(ByVal sender As Object, ByVal e As Stone.WinUI.AsGridButtonClickEventArgs, ByVal iForm As Object)
        Dim gridAttachment As New Stone.WinUI.AsGridData
        gridAttachment = sender

        Select Case e.Field
            Case "iPathFileName"
                Dim clsDialog As New OpenFileDialog
                clsDialog.Title = "Select File(s)"
                clsDialog.Multiselect = False
                clsDialog.Filter = "All Files (*.*)|*.*"
                If clsDialog.ShowDialog(iForm) = Windows.Forms.DialogResult.OK Then
                    e.RowView("LineNumber") = gridAttachment.SelectedIndex + 1
                    e.RowView("iFileName") = Path.GetFileName(clsDialog.FileName)
                    e.RowView("FileDescription") = Path.GetFileName(clsDialog.FileName)
                    e.RowView("iPathFileName") = Path.GetDirectoryName(clsDialog.FileName) & "\"
                End If
                gridAttachment.BeginEditNewRow()
            Case "iOpen"
                If e.RowView("iFileName").ToString = "" Then Exit Sub
                If File.Exists(Path.GetTempPath & e.RowView("iFileName")) = True Then
                    My.Computer.FileSystem.DeleteFile(Path.GetTempPath & e.RowView("iFileName"))
                End If
                If pubOnLine = "1" Then
                    Debug.Print(pubFtpAttachmentFile & "/" & iForm.Name.Replace("input", "") & "/" & e.RowView("iFileName"))
                    My.Computer.Network.DownloadFile(pubFtpAttachmentFile & "/" & iForm.Name.Replace("input", "") & "/" & e.RowView("iFileName"), Path.GetTempPath & e.RowView("iFileName"), FtpUsername, FtpPassword)
                Else
                    File.Copy(e.RowView("iPathFileName") & "\" & e.RowView("iFileName"), Path.GetTempPath & e.RowView("iFileName"), True)
                End If
                If File.Exists(Path.GetTempPath & e.RowView("iFileName")) = True Then
                    System.Diagnostics.Process.Start(Path.GetTempPath & e.RowView("iFileName"))
                Else
                    MsgBox("File not found" & vbNewLine & "Please check the source file")
                End If
        End Select
        gridAttachment.DeleteRowBlankBeforeSave()
        gridAttachment.Refresh()
    End Sub

    Public Sub cmdAddFileMultiselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal iForm As Object)
        Dim gridAttachment As New Stone.WinUI.AsGridData
        gridAttachment = sender
        gridAttachment.DeleteRowBlankBeforeSave()
        gridAttachment.Refresh()
        Dim sfd As New OpenFileDialog()
        sfd.Multiselect = True
        sfd.Filter = "All Files (*.*)|*.*"
        If sfd.ShowDialog() = DialogResult.OK Then
            Dim ifile As String
            Dim rowView As DataRowView
            For Each ifile In sfd.FileNames
                rowView = gridAttachment.BeginEditNewRow
                'rowView("iStrawNo") = 
                rowView("LineNumber") = gridAttachment.SelectedIndex + 1
                rowView("iFileName") = Path.GetFileName(ifile)
                rowView("FileDescription") = Path.GetFileName(ifile)
                rowView("iPathFileName") = Path.GetDirectoryName(ifile) & "\"
                gridAttachment.EndEditNewRow(rowView)
            Next
            gridAttachment.DeleteRowBlankBeforeSave()
            gridAttachment.Refresh()
        End If
    End Sub


End Module
