Imports System.Diagnostics
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Microsoft
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Module ExcelHelper
    Public Sub KillExcellApp()
        Dim xlp() As Process = Process.GetProcessesByName("EXCEL")

        For Each Process As Process In xlp
            Process.Kill()
            If Process.GetProcessesByName("EXCEL").Length = 0 Then
                Exit For
            End If
        Next
    End Sub

    Public Sub ExportToExcel(DataGridView1 As DataGridView)
        Dim xl As New Excel.Application
        'Dim wb As Excel.Workbook
        Dim wbtemplate As Excel.Workbook
        Dim ws As Excel.Worksheet
        Dim exporttemplatepath As String = System.Configuration.ConfigurationSettings.AppSettings.Item("ExportToExcelTemplate")
        Dim exportoutputpath As String = System.Configuration.ConfigurationSettings.AppSettings.Item("ExportToExcelOutPut")

        Dim RemoteDataSet As New DataSet
        Try
            'Open the Export to Excel Template
            Try
                wbtemplate = xl.Workbooks.Open(exporttemplatepath)
                xl.DisplayAlerts = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "OpenOutputTemplate module")
            End Try
            ws = CType(wbtemplate.Worksheets.Item("Sheet1"), Excel.Worksheet)

            'Export Header Names Start
            Dim columnsCount As Integer = DataGridView1.Columns.Count
            For Each column As DataGridViewColumn In DataGridView1.Columns
                Try
                    ws.Cells(1, column.Index + 1).Value = column.Name
                Catch ex As Exception

                End Try
            Next
            'Export Header Name End

            'Export Each Row Start
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                Dim columnIndex As Integer = 0
                Do Until columnIndex = columnsCount
                    Try
                        ws.Cells(i + 2, columnIndex + 1).Value = DataGridView1.Item(columnIndex, i).Value.ToString
                        columnIndex += 1
                    Catch ex As Exception
                    End Try
                Loop
            Next
            'Export Each Row End
            wbtemplate.SaveAs(exportoutputpath)
            wbtemplate.RefreshAll()
            wbtemplate.SaveAs(exportoutputpath)
            wbtemplate.Close()
            'wb.Close()
            xl.Quit()
            xl = Nothing
            KillExcellApp()
            MsgBox("File is exported to " & exportoutputpath)
        Catch ex As Exception
            MsgBox("Error in ExportToExcel : " & ex.Message)
        End Try
    End Sub

    Public Sub ExportDispatchReport(DataGridView1 As DataGridView, monthyear As DateTime)
        Dim xl As New Excel.Application
        'Dim wb As Excel.Workbook
        Dim wbtemplate As Excel.Workbook
        Dim ws As Excel.Worksheet
        Dim exporttemplatepath As String = System.Configuration.ConfigurationSettings.AppSettings.Item("DispatchReportTemplate")
        Dim exportoutputpath As String = System.Configuration.ConfigurationSettings.AppSettings.Item("DispatchReportOutput")

        Dim RemoteDataSet As New DataSet
        Try
            'Open the Export to Excel Template
            Try
                wbtemplate = xl.Workbooks.Open(exporttemplatepath)
                xl.DisplayAlerts = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "OpenOutputTemplate module")
            End Try
            ws = CType(wbtemplate.Worksheets.Item("Sheet1"), Excel.Worksheet)

            'Export Header Names Start
            Dim columnsCount As Integer = DataGridView1.Columns.Count
            For Each column As DataGridViewColumn In DataGridView1.Columns
                Try
                    ws.Cells(1, column.Index + 1).Value = column.Name
                Catch ex As Exception

                End Try
            Next
            'Export Header Name End

            'Export Each Row Start
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                Dim columnIndex As Integer = 0
                Do Until columnIndex = columnsCount
                    Try
                        ws.Cells(i + 2, columnIndex + 1).Value = DataGridView1.Item(columnIndex, i).Value.ToString.Replace("""", "")
                        columnIndex += 1
                    Catch ex As Exception
                        MsgBox("Error in Dispatch Report : " & ex.Message)
                    End Try
                Loop
            Next
            'Export Each Row End
            Dim sallocmonth As String = "Allocation for the Month of " & monthyear.Date.ToString("MMM", New CultureInfo("en-US")) & " " & monthyear.Year.ToString
            ws.Range("Z1").Value = sallocmonth
            'ws.PivotTables("PivotTable2").SourceData = "Sales Trend-Source!R1C1:R" + (DataGridView1.Rows.Count + 1).ToString.Trim + "C26"
            Dim wsadult As Excel.Worksheet
            Dim wsadultpedia As Excel.Worksheet
            Dim wsgovernment As Excel.Worksheet
            Dim wsgovhosp As Excel.Worksheet
            Dim wshospital As Excel.Worksheet
            Dim wspedia As Excel.Worksheet
            Dim wstrade As Excel.Worksheet

            wsadult = CType(wbtemplate.Worksheets.Item("Adult"), Excel.Worksheet)
            wsadultpedia = CType(wbtemplate.Worksheets.Item("Adult Pedia"), Excel.Worksheet)
            wsgovernment = CType(wbtemplate.Worksheets.Item("Government"), Excel.Worksheet)
            wsgovhosp = CType(wbtemplate.Worksheets.Item("GovtHosp"), Excel.Worksheet)
            wshospital = CType(wbtemplate.Worksheets.Item("Hospital"), Excel.Worksheet)
            wspedia = CType(wbtemplate.Worksheets.Item("Pedia"), Excel.Worksheet)
            wstrade = CType(wbtemplate.Worksheets.Item("Trade"), Excel.Worksheet)

            wsadult.PivotTables("PivotTable1").SourceData = "Sheet1!R1C1:R" + (DataGridView1.Rows.Count).ToString.Trim + "C16"
            wsadultpedia.PivotTables("PivotTable1").SourceData = "Sheet1!R1C1:R" + (DataGridView1.Rows.Count).ToString.Trim + "C16"
            wsgovernment.PivotTables("PivotTable1").SourceData = "Sheet1!R1C1:R" + (DataGridView1.Rows.Count).ToString.Trim + "C16"
            wsgovhosp.PivotTables("PivotTable1").SourceData = "Sheet1!R1C1:R" + (DataGridView1.Rows.Count).ToString.Trim + "C16"
            wshospital.PivotTables("PivotTable1").SourceData = "Sheet1!R1C1:R" + (DataGridView1.Rows.Count).ToString.Trim + "C16"
            wspedia.PivotTables("PivotTable1").SourceData = "Sheet1!R1C1:R" + (DataGridView1.Rows.Count).ToString.Trim + "C16"
            wstrade.PivotTables("PivotTable1").SourceData = "Sheet1!R1C1:R" + (DataGridView1.Rows.Count).ToString.Trim + "C16"

            wsadult.PivotTables("PivotTable1").RefreshTable()
            wsadultpedia.PivotTables("PivotTable1").RefreshTable()
            wsgovernment.PivotTables("PivotTable1").RefreshTable()
            wsgovhosp.PivotTables("PivotTable1").RefreshTable()
            wshospital.PivotTables("PivotTable1").RefreshTable()
            wspedia.PivotTables("PivotTable1").RefreshTable()
            wstrade.PivotTables("PivotTable1").RefreshTable()

            wbtemplate.SaveAs(exportoutputpath)
            wbtemplate.RefreshAll()
            wbtemplate.SaveAs(exportoutputpath)
            wbtemplate.Close()
            'wb.Close()
            xl.Quit()
            xl = Nothing
            KillExcellApp()
            MsgBox("File is exported to " & exportoutputpath)
        Catch ex As Exception
            MsgBox("Error in ExportToExcel : " & ex.Message)
        End Try
    End Sub
End Module
