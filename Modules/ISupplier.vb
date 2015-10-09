Imports System.Data.SqlClient
Module ISupplier
    Public Function GetSupplierPaymentTerm(ByVal suplcodeval As String) As String
        Dim retval As String = ""
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim suplcode As New SqlParameter("@suplcode", SqlDbType.VarChar, 10) : suplcode.Direction = ParameterDirection.Input : suplcode.Value = suplcodeval : Params(0) = suplcode
            BusinessObject.Sub_Show(ServerPath2, "Util_Supplier_PaymentTerm", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            retval = RemoteDataSet.Tables(0).Rows(0)(0).ToString()
        Catch ex As Exception
        End Try
        Return retval
    End Function

    Public Function Supplier_Leadtime(supcodeval As String) As Decimal
        Dim retval As Decimal = 0.0
        Try
            Dim RemoteDataSet As New DataSet
            Dim Params(0) As SqlParameter
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim suplcode As New SqlParameter("@suplcode", SqlDbType.VarChar, 10) : suplcode.Direction = ParameterDirection.Input : suplcode.Value = supcodeval : Params(0) = suplcode
            RemoteDataSet.Tables.Add("Table1")
            BusinessObject.Sub_Show(ServerPath2, "Supplier_Leadtime", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables("Table1").Rows.Count > 0 Then
                retval = Convert.ToDecimal(RemoteDataSet.Tables(0).Rows(0)(0).ToString())
            End If
        Catch ex As Exception
            retval = 0.0
        End Try
        Return retval
    End Function

    Public Function Supplier_Processing(supcodeval As String) As Decimal
        Dim retval As Decimal = 0.0
        Try
            Dim RemoteDataSet As New DataSet
            Dim Params(0) As SqlParameter
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim suplcode As New SqlParameter("@suplcode", SqlDbType.VarChar, 10) : suplcode.Direction = ParameterDirection.Input : suplcode.Value = supcodeval : Params(0) = suplcode
            RemoteDataSet.Tables.Add("Table1")
            BusinessObject.Sub_Show(ServerPath2, "Supplier_Processing", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables("Table1").Rows.Count > 0 Then
                retval = Convert.ToDecimal(RemoteDataSet.Tables(0).Rows(0)(0).ToString())
            End If
        Catch ex As Exception
            retval = 0.0
        End Try
        Return retval
    End Function
End Module
