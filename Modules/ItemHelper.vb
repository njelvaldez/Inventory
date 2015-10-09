Imports System.Data.SqlClient
Module ItemHelper
    Public Function Getitem(ByVal itmcode As String) As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim itemcode As New SqlParameter("@itemcode", SqlDbType.VarChar, 10) : itemcode.Direction = ParameterDirection.Input : itemcode.Value = itmcode : Params(0) = itemcode
            BusinessObject.Sub_Show(ServerPath2, "Util_Item_SearchCode", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception

        End Try
        Return RemoteDataSet
    End Function

    Public Function GetItemDataMap(ByVal search As String, ByVal code As String) As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = search : Params(0) = SearchName
            Dim SearchCode As New SqlParameter("@SearchCode", SqlDbType.VarChar, 50) : SearchCode.Direction = ParameterDirection.Input : SearchCode.Value = code : Params(1) = SearchCode
            BusinessObject.Sub_Show(ServerPath2, "Util_DataMap_JoinItem", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception

        End Try
        Return RemoteDataSet
    End Function

    Public Function Item_Leadtime(ByVal _itemcode As String) As Decimal
        Dim retval As Decimal = 0.0
        Try
            Dim RemoteDataSet As New DataSet
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim Itemcode As New SqlParameter("@Itemcode", SqlDbType.VarChar, 10) : Itemcode.Direction = ParameterDirection.Input : Itemcode.Value = _itemcode : Params(0) = Itemcode
            BusinessObject.Sub_Show(ServerPath2, "Item_Leadtime", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables("Table1").Rows.Count > 0 Then
                retval = Convert.ToDecimal(RemoteDataSet.Tables(0).Rows(0)(0).ToString())
            End If
        Catch ex As Exception
            retval = 0.0
        End Try
        Return retval
    End Function

    Public Function Item_Processing(ByVal _itemcode As String) As Decimal
        Dim retval As Decimal = 0.0
        Try
            Dim RemoteDataSet As New DataSet
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim Itemcode As New SqlParameter("@Itemcode", SqlDbType.VarChar, 10) : Itemcode.Direction = ParameterDirection.Input : Itemcode.Value = _itemcode : Params(0) = Itemcode
            BusinessObject.Sub_Show(ServerPath2, "Item_Processing", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables("Table1").Rows.Count > 0 Then
                retval = Convert.ToDecimal(RemoteDataSet.Tables(0).Rows(0)(0).ToString())
            End If
        Catch ex As Exception
            retval = 0.0
        End Try
        Return retval
    End Function

    Public Function Item_UnitCost(ByVal _itemcode As String) As Decimal
        Dim retval As Decimal = 0.0
        Try
            Dim RemoteDataSet As New DataSet
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim Itemcode As New SqlParameter("@Itemcode", SqlDbType.VarChar, 10) : Itemcode.Direction = ParameterDirection.Input : Itemcode.Value = _itemcode : Params(0) = Itemcode
            BusinessObject.Sub_Show(ServerPath2, "Item_UnitCost", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables("Table1").Rows.Count > 0 Then
                retval = Convert.ToDecimal(RemoteDataSet.Tables(0).Rows(0)(0).ToString())
            End If
        Catch ex As Exception
            retval = 0.0
        End Try
        Return retval
    End Function

End Module
