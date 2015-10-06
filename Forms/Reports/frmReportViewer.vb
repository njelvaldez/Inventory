Option Strict Off
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmReportViewer
    Inherits System.Windows.Forms.Form
    Public Const ExportPath As String = "D:\Temp\ExportReports\"
    Public Status As String = "A"
    Public PrintedBy As String = gUserID
    Public MonthYear As DateTime
    Public PONO As String = ""

    Private ReportName As String
    Private CommissionMonth As String
    Private BusinessObject As New BusinessLayer.clsFileMaintenance

    
    Property Report() As String
        Get
            Return ReportName
        End Get
        Set(ByVal Value As String)
            ReportName = Value
        End Set
    End Property   ' Month
    Private Sub frmReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim x As String
        x = Application.StartupPath
        Try
            Select Case Report
                Case "Promats Master List Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "IPromats_Report"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@Status", SqlDbType.VarChar, 3).Value = Status
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crPromats
                    'myReport.SetParameterValue("printedby", printedby)
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Promats Master List Report XLS"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "IPromats_ReportXLS"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@Status", SqlDbType.VarChar, 3).Value = Status
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crPromatsExportXls
                    'myReport.SetParameterValue("printedby", printedby)
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Samples Master List Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "ISamples_Report"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@Status", SqlDbType.VarChar, 3).Value = Status
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crSamples
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Samples Master List Report XLS"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "ISamples_Report"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@Status", SqlDbType.VarChar, 3).Value = Status
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crSamplesXLS
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Promats Allocations Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "IPromatsAllocation_Report"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@MONTHYEAR", SqlDbType.DateTime, 10).Value = MonthYear
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crPromatsAllocations
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Samples Allocations Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "ISamplesAllocation_Report"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@MONTHYEAR", SqlDbType.DateTime, 10).Value = MonthYear
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crSamplesAllocations
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Specialist Master List Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "ISpecialist_Report"
                        .CommandType = CommandType.StoredProcedure
                        '.Parameters.Add("@Status", SqlDbType.VarChar, 3).Value = Status
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crSpecialist
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Supplier Master List Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "ISupplier_Report"
                        .CommandType = CommandType.StoredProcedure
                        '.Parameters.Add("@Status", SqlDbType.VarChar, 3).Value = Status
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crSupplier
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "ISSPM Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "ISSPM_Report"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@MONTHYEAR", SqlDbType.DateTime, 10).Value = MonthYear
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crISSMReport
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                    'Purchase Order Report
                Case "Purchase Order Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "IPOHeader_Report"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@PONO", SqlDbType.VarChar, 10).Value = PONO
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crPurchaseOrder
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Role Modules Report"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = ServerPath2
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "IRoleModules_Report"
                        .CommandType = CommandType.StoredProcedure
                        '.Parameters.Add("@PONO", SqlDbType.VarChar, 10).Value = PONO
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crRoleModules
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport

                Case "Dispatch Report Not In TAS Inventory"
                    Dim myDialogBox As New frmDialogBox
                    Dim myConnection As New SqlConnection
                    With myConnection
                        .ConnectionString = TASServerPath
                        .Open()
                    End With

                    Dim myCommand As New SqlCommand
                    With myCommand
                        .Connection = myConnection
                        .CommandText = "SP_DISPATCHREPORTNOTININV"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add("@MONTHYEAR", SqlDbType.DateTime, 10).Value = MonthYear
                    End With

                    Dim myDataAdapter As New SqlDataAdapter
                    myDataAdapter.SelectCommand = myCommand
                    Dim myDataset As New DataSet
                    myDataset.Tables.Add("Table1")
                    myDataAdapter.Fill(myDataset, "Table1")

                    Dim myReport As New crDispatchReportNotInInv
                    myReport.DataDefinition.FormulaFields("printedby").Text = "'Printed by : " + gUserID + "'"
                    myReport.SetDataSource(myDataset.Tables("Table1"))
                    CrystalReportViewer1.ReportSource = myReport
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.GetBaseException.ToString)
        End Try
    End Sub

    Private Sub Frm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        EnDisMainMenu(Me, True)
    End Sub

    Private Sub Frm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        EnDisMainMenu(Me, False)
    End Sub
End Class
