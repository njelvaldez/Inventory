Imports System.Data.SqlClient
Public Class clsIntegratedSales
    Public Sub IntegratedSales_Show(ByVal StringConnection As String, ByVal StringProcedure As String, _
            ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
            Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
    Public Sub IntegratedSales_ShowYear(ByVal StringConnection As String, ByVal StringProcedure As String, _
        ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
        Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
    Public sub IntegratedSales_Insert(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal Params() As SqlParameter) 
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
    Public Sub IntegratedSales_Update(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
    Public Sub IntegratedSales_Delete(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
End Class
