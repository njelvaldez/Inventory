Imports System.Data.SqlClient
Public Class clsDsm
    Public Sub Dsm_Browse(ByVal StringConnection As String, ByVal StringProcedure As String, ByVal ComType As CommandType, _
    ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
    Optional ByVal Params() As SqlParameter = Nothing)
        Dim DataHelper As New DataAccessLayer.DataAccessHelper
        DataHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
End Class