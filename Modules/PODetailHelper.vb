Imports System.Data.SqlClient
Imports System.Collections.Generic
Module PODetailHelper

    Public Function PODetail_Qty(ByVal _itemcode As String) As Decimal
        Dim retval As Decimal = 0.0
        Try
            Dim RemoteDataSet As New DataSet
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim Itemcode As New SqlParameter("@Itemcode", SqlDbType.VarChar, 10) : Itemcode.Direction = ParameterDirection.Input : Itemcode.Value = _itemcode : Params(0) = Itemcode
            BusinessObject.Sub_Show(ServerPath2, "Item_MOQ", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables("Table1").Rows.Count > 0 Then
                retval = Convert.ToDecimal(RemoteDataSet.Tables(0).Rows(0)(0).ToString())
            End If
        Catch ex As Exception
            retval = 0.0
        End Try
        Return retval
    End Function

End Module
