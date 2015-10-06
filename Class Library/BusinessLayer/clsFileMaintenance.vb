Imports System.Data.SqlClient
Public Class clsFileMaintenance
    Public Sub Sub_Show(ByVal StringConnection As String, ByVal StringProcedure As String, _
            ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
            Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, _
                               StringDataTable, Params)
    End Sub
    Public Sub Sub_Insert(ByVal StringConnection As String, ByVal StringProcedure As String, _
        ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
        params=nothing
    End Sub
    Public Sub Sub_Update(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
    Public Sub Sub_Delete(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
    Public Sub Sub_Select(ByVal StringConnection As String, ByVal StringProcedure As String, ByVal ComType As CommandType, _
    ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
    Optional ByVal Params() As SqlParameter = Nothing)
        Dim DataHelper As New DataAccessLayer.DataAccessHelper
        DataHelper.ReturnDataSet(StringConnection, StringProcedure, ComType, RemoteDataSet, StringDataTable, Params)
    End Sub
    Public Function Sub_ReturnIntegerResult(ByVal StringConnection As String, ByVal StringProcedure As String, ByVal ComType As CommandType, _
    Optional ByVal Params() As SqlParameter = Nothing) As Integer
        Dim result As Integer
        Dim DataHelper As New DataAccessLayer.DataAccessHelper
        result = DataHelper.Return_IntegerResult(StringConnection, StringProcedure, ComType, Params)
        Return result
    End Function
    'added by dhonn brion --v
    Public Function Sub_ReturnStringResult(ByVal StringConnection As String, ByVal StringProcedure As String, _
         ByVal ComType As CommandType, Optional ByVal Params() As SqlParameter = Nothing) As String
        Dim result As String
        Dim DataHelper As New DataAccessLayer.DataAccessHelper
        result = DataHelper.Return_IntegerResult(StringConnection, StringProcedure, ComType, Params)
        Return result
    End Function

    Public Function Encr(ByVal xStr As String) As String
        Dim dh As New DataAccessLayer.DataAccessHelper
        Encr = dh.Encrypt(xStr)
    End Function

    Public Function Decr(ByVal xStr As String) As String
        Dim dh As New DataAccessLayer.DataAccessHelper
        Decr = dh.Decrypt(xStr)
    End Function
    'added by dhonn brion --^
End Class
