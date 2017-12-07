Imports Stone.WinUI
Module modTool
    Public Function MoveUpGrid(ByVal RowsIndex As Integer, ByVal UpDown As Char, ByVal dt As DataTable, ByVal gridOjb As Stone.WinUI.AsGridData) As DataTable
        Dim b_IndexRows As Integer = RowsIndex
        If UpDown = "U" Then b_IndexRows = RowsIndex - 1 Else b_IndexRows = RowsIndex + 1
        Dim ColumnsName As String
        For i = 0 To gridOjb.Columns.Count - 1
            ColumnsName = gridOjb.Columns.Item(i).Field
            Select Case gridOjb.Columns(i).ColumnFormat
                Case ColumnFormats.Button
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.CheckBox
                    Dim varArray As Integer = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.Image
                    Dim buf As Object = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = buf
                Case ColumnFormats.Color
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.DataIndex
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.Date
                    Dim varArray As DateTime = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.ImageFromPath
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.ImageListIndex
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.Money
                    Dim varArray As Double = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.Text
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.TextLink
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.Time
                    Dim varArray As String = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
                Case ColumnFormats.TreeView
                    Dim varArray As TreeView = dt.Rows(b_IndexRows)(ColumnsName)
                    dt.Rows(b_IndexRows)(ColumnsName) = dt.Rows(RowsIndex)(ColumnsName)
                    dt.Rows(RowsIndex)(ColumnsName) = varArray
            End Select
        Next
        Return dt
    End Function





End Module
