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
End Module
