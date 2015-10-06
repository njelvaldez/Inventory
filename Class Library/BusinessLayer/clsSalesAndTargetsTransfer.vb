Imports System.data.SqlClient
Public Class clsSalesAndTargetsTransfer
    'Public Function Show_SalesAndTargetsTransfer(ByVal StringConnection As String, ByVal StringProcedure As String, _
    'ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, Optional ByVal Params() As SqlParameter = Nothing) As DataSet
    '    Dim daHelper As New DataAccessLayer.DataAccessHelper
    '    RemoteDataSet = daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    '    Return RemoteDataSet
    'End Function
    Public Sub Show_SalesAndTargetsTransfer(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
    Public Sub Show_SalesAndTargetsDirect(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
End Class
