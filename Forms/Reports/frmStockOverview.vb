Imports System.Data.SqlClient
Imports Microsoft
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Globalization
Imports System.Runtime.InteropServices
Public Class frmStockOverview
    Private RemoteDataSet As New DataSet
    Private InventoryOverview As String = System.Configuration.ConfigurationSettings.AppSettings.Item("InventoryOverview")
    Private SalesTransDate As String = ""
    Private n10k As Integer = 10000
    Private Sub frmStockOverview_Load(sender As Object, e As EventArgs) Handles Me.Load
        modControlBehavior.EnableControls(Me, False)
        modControlBehavior.EnableControlsGroup(Me, False)
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
        DataGrid1.AlternatingBackColor = Color.LightGreen
        SetPath()
    End Sub
    Private Sub SetPath()
        Dim currentdate As String
        Dim format As String = "MMM d yyyy"
        currentdate = DateTime.Now.ToString("MMM", New CultureInfo("en-US")) + " 1 - " + DateTime.Now.Date.Day.ToString() + " " + DateTime.Now.Date.Year.ToString()
        txtTemplate.Text = InventoryOverview
        txtOutput.Text = InventoryOverview.Replace(".xlsx", currentdate + ".xlsx")
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
   
    Private Sub InventoryReportShow()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "StockOverview_Report", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            DataGrid1.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Inventory List : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("StockOverview_Report.Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ExportInventoryReport(ByVal strFileName As String)
        Dim xl As New Excel.Application
        Dim wb As Excel.Workbook
        Dim ws As Excel.Worksheet
        Dim wssalestrend As Excel.Worksheet
        Dim range As Excel.Range
        Dim rownumber As Integer = 0
        Dim counter10k As Integer = 1
        Dim salesinvupdout As String = txtOutput.Text.ToString
        Dim salesinvupd As String = txtTemplate.Text.ToString
        Dim reccount As Integer
        Try
            wb = xl.Workbooks.Open(strFileName)
            Dim dt As New DataTable
            dt = (DirectCast(DataGrid1.DataSource, DataTable))
            reccount = dt.Rows.Count + 1
            ws = CType(wb.Worksheets.Item("Pivot"), Excel.Worksheet)
            wssalestrend = CType(wb.Worksheets.Item("Source"), Excel.Worksheet)
            range = wssalestrend.Range("A2", "P" + GetRangeEnd(counter10k, reccount).ToString().Trim)
            Dim strArr(GetArraySize(counter10k, reccount), 16) As Object
            For Each dr As DataRow In dt.Rows
                'ItemCode
                strArr(rownumber, 0) = dr("Itemcode").ToString
                'ItemDesc()
                strArr(rownumber, 1) = dr("Itemdesc").ToString
                'Warehouse()
                strArr(rownumber, 2) = dr("Warehouse").ToString
                'LocCode()
                strArr(rownumber, 3) = dr("LocCode").ToString
                'LotNo()
                strArr(rownumber, 4) = dr("LotNo").ToString
                'ExpDate()
                strArr(rownumber, 5) = dr("ExpDate").ToString
                'BegQty()
                strArr(rownumber, 6) = dr("BegQty").ToString
                'RecQty()
                strArr(rownumber, 7) = dr("RecQty").ToString
                'IssQty()
                strArr(rownumber, 8) = dr("IssQty").ToString
                'AdjQty()
                strArr(rownumber, 9) = dr("AdjQty").ToString
                'TrnQty()
                strArr(rownumber, 10) = dr("TrnQty").ToString
                'EndQty()
                strArr(rownumber, 11) = dr("EndQty").ToString
                'CreateDate()
                strArr(rownumber, 12) = dr("CreateDate").ToString
                'UpdateDate()
                strArr(rownumber, 13) = dr("UpdateDate").ToString
                'UpdateBy()
                strArr(rownumber, 14) = dr("UpdateBy").ToString
                'MonthYear()
                strArr(rownumber, 15) = dr("MonthYear").ToString
                'array is zero base , lets subtract by 1
                If rownumber >= n10k - 1 Then
                    range.Value2 = strArr
                    counter10k = counter10k + 1
                    ReDim strArr(0, 0)
                    ReDim strArr(GetArraySize(counter10k, reccount), 16)
                    range = wssalestrend.Range("A" + (GetRangeStart(counter10k, reccount)).ToString().Trim(), "P" + GetRangeEnd(counter10k, reccount).ToString().Trim)
                    rownumber = 0
                Else
                    rownumber = rownumber + 1
                End If
            Next
            range.Value2 = strArr
            'Save Sales Transaction Date To Excel to Cell A3
            ws.Range("A3").Value = "Printed Date : " & DateTime.Now.ToShortDateString
            'Refresh PivotTable3
            'pivot.SourceData = "SheetName!R1C1:R18C18"
            ws.PivotTables("PivotTable1").SourceData = "Source!R1C1:R" + (reccount + 1).ToString.Trim + "C16"
            If reccount > 1 Then
                ws.PivotTables("PivotTable1").RefreshTable()
            End If
            xl.DisplayAlerts = False
            wb.SaveAs(salesinvupdout)
            wb.Close()
            xl.Quit()
            xl = Nothing
            MessageBox.Show("Generation of Inventory Overview Report is complete!")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "frmStockOverview module")
        Finally
        End Try
    End Sub

    Function GetArraySize(counter10k As Integer, reccount As Integer) As Integer
        Dim retval As Integer = 0
        If ((reccount - (n10k * counter10k)) >= 10000) Then
            retval = n10k
        Else
            retval = n10k   'reccount - (n10k * counter10k)
        End If
        Return retval
    End Function

    Function GetRangeStart(counter10k As Integer, reccount As Integer) As Integer
        Dim retval As Integer = 0
        retval = n10k * (counter10k - 1)
        'Plus 2 because it starts from row 2, A2
        Return retval + 2
    End Function
    Function GetRangeEnd(counter10k As Integer, reccount As Integer) As Integer
        Dim retval As Integer = 0
        If ((reccount - (n10k * (counter10k - 1))) >= 10000) Then
            retval = n10k * counter10k
        Else
            retval = reccount
        End If
        'Plus 2 because it starts from row 2, A2
        Return retval + 2
    End Function

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim salesinvupdfile As String = txtTemplate.Text.ToString
        'SetDate()
        Me.Cursor = Cursors.WaitCursor
        InventoryReportShow()
        'this is now faster
        ExportInventoryReport(salesinvupdfile)
        Me.Cursor = Cursors.Default
        'MsgBox("Process is complete." + " Sales Trend File : " + txtOutput.Text.ToString + " is generated!")
        'KillExcellApp()
        Process.Start(txtOutput.Text.ToString())
    End Sub
End Class