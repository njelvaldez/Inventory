Imports System.Data.SqlClient
Imports Microsoft
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Globalization
Imports System.Runtime.InteropServices
Public Class frmIssuanceReport
    Private RemoteDataSet As New DataSet
    Private IssuanceReport As String = System.Configuration.ConfigurationSettings.AppSettings.Item("IssuanceReport")
    Private salesinvupdpath As String = System.Configuration.ConfigurationSettings.AppSettings.Item("SalesAndTargetsTransfer")
    Private SalesTransDate As String = ""
    Private n10k As Integer = 10000
    Private Sub SetDate()
        Dim afterayear As String
        afterayear = DateTime.Now.Date.Month.ToString() + "/1/" + (DateTime.Now.Date.Year + 1).ToString()
    End Sub

    Private Sub SetPath()
        Dim currentdate As String
        Dim format As String = "MMM d yyyy"
        currentdate = DateTime.Now.ToString("MMM", New CultureInfo("en-US")) + " 1 - " + DateTime.Now.Date.Day.ToString() + " " + DateTime.Now.Date.Year.ToString()
        txtTemplate.Text = IssuanceReport
        txtOutput.Text = IssuanceReport.Replace(".xlsx", currentdate + ".xlsx")
    End Sub

    Private Sub frmIssuanceReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modControlBehavior.EnableControls(Me, False)
        modControlBehavior.EnableControlsGroup(Me, False)
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
        DataGrid1.AlternatingBackColor = Color.LightGreen
        SetDate()
        SetPath()
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        btnExportExcel_Click(sender, e)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Process.Start(txtOutput.Text.ToString())
    End Sub

    Private Sub txtExpFrom_TextChanged_1(sender As Object, e As EventArgs)

    End Sub
    Private Sub InventoryReportShow()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "IssuanceReportSelect", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            DataGrid1.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Inventory List : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("InventoryReportShow.Error: " & ex.Message)
        End Try
    End Sub
    Private Sub ResetTable()
        If RemoteDataSet.Tables.Count > 0 Then
            RemoteDataSet.Tables.Remove("ProductFormCT_Show")
        End If
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
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
            range = wssalestrend.Range("A2", "G" + GetRangeEnd(counter10k, reccount).ToString().Trim)
            Dim strArr(GetArraySize(counter10k, reccount), 6) As Object
            For Each dr As DataRow In dt.Rows
                'Issno
                strArr(rownumber, 0) = dr("Issno").ToString
                'htr.IssDate
                strArr(rownumber, 1) = dr("IssDate").ToString
                'htr.IssCode
                strArr(rownumber, 2) = dr("IssCode").ToString
                'dtr.ItemCode
                strArr(rownumber, 3) = dr("ItemCode").ToString
                ' itm.ItemDesc
                strArr(rownumber, 4) = dr("ItemDesc").ToString
                'dtr.Qty 
                strArr(rownumber, 5) = dr("Qty").ToString
                'UpdateBy, 
                strArr(rownumber, 6) = dr("UpdateBy").ToString
                'array is zero base , lets subtract by 1
                If rownumber >= n10k - 1 Then
                    range.Value2 = strArr
                    counter10k = counter10k + 1
                    ReDim strArr(0, 0)
                    ReDim strArr(GetArraySize(counter10k, reccount), 6)
                    range = wssalestrend.Range("A" + (GetRangeStart(counter10k, reccount)).ToString().Trim(), "G" + GetRangeEnd(counter10k, reccount).ToString().Trim)
                    rownumber = 0
                Else
                    rownumber = rownumber + 1
                End If
            Next
            range.Value2 = strArr
            'Save Sales Transaction Date To Excel to Cell A3
            Dim monthname As String = DateTime.Now.ToString("MMMM", New CultureInfo("en-US")) & " " & DateTime.Now.Day.ToString & " " & DateTime.Now.Year.ToString
            ws.Range("A3").Value = "Date Printed : " & monthname
            'Refresh PivotTable3
            'pivot.SourceData = "SheetName!R1C1:R18C18"
            ws.PivotTables("PivotTable1").SourceData = "Source!R1C1:R" + (reccount + 1).ToString.Trim + "C6"
            If reccount > 1 Then
                ws.PivotTables("PivotTable1").RefreshTable()
                'wb.RefreshAll()
                RefreshPivots(wb)
            End If
            xl.DisplayAlerts = False
            wb.SaveAs(salesinvupdout)
            wb.Close()
            xl.Quit()
            xl = Nothing
            'MessageBox.Show("Generation of Trade Inventory Analysis Report is complete!")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "frmInventoryReport module")
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

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Dim salesinvupdfile As String = txtTemplate.Text.ToString
        'SetDate()
        Me.Cursor = Cursors.WaitCursor
        InventoryReportShow()
        'this is now faster
        ExportInventoryReport(salesinvupdfile)
        Me.Cursor = Cursors.Default
        'MsgBox("Process is complete." + " Sales Trend File : " + txtOutput.Text.ToString + " is generated!")
        'KillExcellApp()
    End Sub

    Private Sub btnopenreport_Click(sender As Object, e As EventArgs) Handles btnopenreport.Click
        Process.Start(txtOutput.Text.ToString())
    End Sub

    Private Sub btnopentemplate2_Click(sender As Object, e As EventArgs) Handles btnopentemplate2.Click
        Process.Start(txtTemplate.Text.ToString())
    End Sub
    Private Sub RefreshPivots(wb As Excel.Workbook)
        Dim wSheet As Excel.Worksheet
        For Each wSheet In wb.Worksheets
            For Each Pivot As Excel.PivotTable In wSheet.PivotTables
                Pivot.RefreshTable()
                Pivot.Update()
            Next
        Next
    End Sub
End Class