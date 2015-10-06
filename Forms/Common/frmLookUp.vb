Imports System.Data.SqlClient
Imports Microsoft
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Globalization
Imports System.Runtime.InteropServices
Public Class frmLookUp
    Public RemoteDataTable As New DataTable
    Public lookupcaption As String = "Look Up"

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.ToString.Trim.Length >= 3 Or _
           txtSearch.Text.ToString.Trim.Length = 0 Then
            Dim dv As DataView
            dv = New DataView(RemoteDataTable, "Description Like '*" & txtSearch.Text & "*'", "Description", DataViewRowState.CurrentRows)
            DataGrid1.DataSource = dv
        End If
    End Sub
    Private Sub frmLookUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = lookupcaption
        DataGrid1.DataSource = RemoteDataTable
        DataGrid1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        DataGrid1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub DataGrid1_Click_1(sender As Object, e As EventArgs)
        ApplySelectedItem()
    End Sub

    Private Sub DataGrid1_DoubleClick_1(sender As Object, e As EventArgs)
        ApplySelectedItem()
    End Sub

    Private Sub ApplySelectedItem()
        gCode = DataGrid1.CurrentRow.Cells(0).Value.ToString
        gDesc = DataGrid1.CurrentRow.Cells(1).Value.ToString
        Close()
    End Sub

    Private Sub DataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellClick
        'ApplySelectedItem()
    End Sub

    Private Sub DataGrid1_DoubleClick(sender As Object, e As EventArgs) Handles DataGrid1.DoubleClick
        ApplySelectedItem()
    End Sub
End Class