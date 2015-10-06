Imports System.Data.SqlClient
Public Class clsPerformance
    Public Sub Performance_Generic(ByVal StringConnection As String, ByVal StringProcedure As String, ByVal ComType As CommandType, _
        ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
        Optional ByVal Params() As SqlParameter = Nothing)
        Dim DataHelper As New DataAccessLayer.DataAccessHelper
        DataHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
    Public Sub Performance_Calenderized_Populate(ByVal StringConnection As String, ByVal StringProcedure As String, _
        ByVal ComType As CommandType, Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
    Public Sub Performance_Calenderized_Show(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
    Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
End Class
