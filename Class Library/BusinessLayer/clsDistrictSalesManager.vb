Imports System.Data.SqlClient
Public Class clsDistrictSalesManager
    Public Sub Dsm_Show(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
    Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
    Public Sub Dsm_ShowPerDivision(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
    Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
    Public Sub Dsm_Insert(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
    Public Sub Dsm_Update(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
    Public Sub Dsm_Delete(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub

End Class
