Imports System.Data.SqlClient
Imports System.Collections.Generic

Module DataMapHelper
    Public Function DataMap_Insert(ByVal name As String, ByVal code As String, ByVal returnvalue As String) As Boolean
        Dim retval As Boolean = True
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter
            Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = name : Params(0) = SearchName
            Dim SearchCode As New SqlParameter("@SearchCode", SqlDbType.VarChar, 50) : SearchCode.Direction = ParameterDirection.Input : SearchCode.Value = code : Params(1) = SearchCode
            Dim ReturnCode As New SqlParameter("@ReturnCode", SqlDbType.VarChar, 50) : ReturnCode.Direction = ParameterDirection.Input : ReturnCode.Value = returnvalue : Params(2) = ReturnCode
            BusinessObject.Sub_Insert(ServerPath2, "Util_DataMap_Insert", CommandType.StoredProcedure, Params)
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function
    Public Function GetReturnCode(ByVal name As String, ByVal itemcode As String) As Boolean
        Dim retval As Boolean = True
        Try
            Dim RemoteDataSet As New DataSet
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = name : Params(0) = SearchName
            Dim SearchCode As New SqlParameter("@SearchCode", SqlDbType.VarChar, 50) : SearchCode.Direction = ParameterDirection.Input : SearchCode.Value = itemcode : Params(1) = SearchCode

            BusinessObject.Sub_Show(ServerPath2, "Util_DataMap_Select", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If Not RemoteDataSet.Tables("Table1").Rows.Count > 0 Then
                retval = False
            End If

        Catch ex As Exception

        End Try
        Return retval

    End Function
    Public Function DataMap_Delete(ByVal name As String, ByVal code As String) As Boolean
        Dim retval As Boolean = True
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = name : Params(0) = SearchName
            Dim SearchCode As New SqlParameter("@SearchCode", SqlDbType.VarChar, 50) : SearchCode.Direction = ParameterDirection.Input : SearchCode.Value = code : Params(1) = SearchCode
            BusinessObject.Sub_Delete(ServerPath2, "Util_DataMap_Delete", CommandType.StoredProcedure, Params)
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function

    Public Function GetIMSFG() As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = "IMS FG" : Params(0) = SearchName
            BusinessObject.Sub_Show(ServerPath2, "Util_DataMap_SelectIMSFG", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception

        End Try
        Return RemoteDataSet
    End Function

    Public Function DatatableToDictionary(dt As DataTable, strkey As String, strvalue As String) As Dictionary(Of String, String)
        Dim retval As New Dictionary(Of String, String)

        For Each drow As DataRow In dt.Rows
            'braccoitems.Add(11225, "IOPAMIRO 300 1x100 ml")
            Try
                retval.Add(drow(strkey), drow(strvalue))
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        Next

        Return retval
    End Function

    Public Function Util_MetroDrugItem_Select() As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            'Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = "IMS FG" : Params(0) = SearchName
            Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = "ITEMCODE" : Params(0) = SearchName
            BusinessObject.Sub_Show(ServerPath2, "Util_MetroDrugItem_Select", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception

        End Try
        Return RemoteDataSet
    End Function
    Public Function Util_MetroDrugItem_SelectItemCode() As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = "IMS FG" : Params(0) = SearchName
            BusinessObject.Sub_Show(ServerPath2, "Util_MetroDrugItem_SelectItemCode", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception

        End Try
        Return RemoteDataSet
    End Function


    Public Function Util_MetroDrugItem_SelectGBItemCode() As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim SearchName As New SqlParameter("@SearchName", SqlDbType.VarChar, 50) : SearchName.Direction = ParameterDirection.Input : SearchName.Value = "IMS FG" : Params(0) = SearchName
            BusinessObject.Sub_Show(ServerPath2, "Util_MetroDrugItem_SelectGBItemCode", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception

        End Try
        Return RemoteDataSet
    End Function
    Public Function Util_MetroDrugItem_SelectMDIItemCode() As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "Util_MetroDrugItem_SelectItemCode", CommandType.StoredProcedure, RemoteDataSet, "Table1")
        Catch ex As Exception

        End Try
        Return RemoteDataSet
    End Function

    Public Function Util_Promats_Select() As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "IPromats_Show", CommandType.StoredProcedure, RemoteDataSet, "Table1")
        Catch ex As Exception
            MsgBox("Error in : " & ex.Message)
        End Try
        Return RemoteDataSet
    End Function

    Public Function Util_Samples_Select() As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "ISamples_Show", CommandType.StoredProcedure, RemoteDataSet, "Table1")
        Catch ex As Exception
            MsgBox("Error in : " & ex.Message)
        End Try
        Return RemoteDataSet
    End Function

End Module
