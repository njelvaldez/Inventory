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


End Module
