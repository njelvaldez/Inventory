Imports System.Data.SqlClient
Public Class DataAccessHelper
    Public Function ObjectConnection(ByVal StringConnection As String) As SqlConnection
        Dim LocalConnection As New SqlConnection
        With LocalConnection
            .ConnectionString = StringConnection
            .Open()
        End With
        Return LocalConnection
    End Function
    Public Sub ExecuteNonQuery(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, Optional ByVal Params() As SqlParameter = Nothing)
        Dim LocalCommand As New SqlCommand
        With LocalCommand
            .Connection = ObjectConnection(StringConnection)
            .CommandText = StringProcedure
            .CommandType = ComType
            .CommandTimeout = 0
            If Not Params Is Nothing Then
                CollectParameters(Params, LocalCommand)
            End If
            .ExecuteNonQuery()
            .Parameters.Clear()
            .Dispose()
            Params = Nothing
        End With
    End Sub
    Public Function ReturnDataTable(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, _
    Optional ByVal Params() As SqlParameter = Nothing) As DataTable
        Dim LocalCommand As New SqlCommand
        Dim DataAdapter As New SqlDataAdapter
        Dim LocalDataTable As DataTable
        With LocalCommand
            .Connection = ObjectConnection(StringConnection)
            .CommandText = StringProcedure
            .CommandType = ComType
            If Not Params Is Nothing Then
                CollectParameters(Params, LocalCommand)
            End If
        End With
        DataAdapter.SelectCommand = LocalCommand
        DataAdapter.Fill(RemoteDataSet.Tables(StringDataTable))
        LocalDataTable = RemoteDataSet.Tables(StringDataTable)
        Return LocalDataTable
    End Function
    Public Sub ReturnDataSet(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, ByVal RemoteDataSet As DataSet, ByVal StringDataTable As String, Optional ByVal Params() As SqlParameter = Nothing)
        Dim LocalCommand As New SqlCommand
        Dim DataAdapter As New SqlDataAdapter
        With LocalCommand
            .Connection = ObjectConnection(StringConnection)
            .CommandText = StringProcedure
            .CommandType = ComType
            .CommandTimeout = 0
            If Not Params Is Nothing Then
                CollectParameters(Params, LocalCommand)
            End If
            DataAdapter.SelectCommand = LocalCommand
            DataAdapter.Fill(RemoteDataSet.Tables(StringDataTable))
        End With
    End Sub
    Public Function Return_IntegerResult(ByVal StringConnection As String, _
                                         ByVal StringProcedure As String, _
                                         ByVal ComType As CommandType, _
                                         Optional ByVal Params() As SqlParameter = Nothing) As Integer
        Dim result As Integer
        Dim LocalCommand As New SqlCommand
        With LocalCommand
            .Connection = ObjectConnection(StringConnection)
            .CommandText = StringProcedure
            .CommandType = ComType
            If Not Params Is Nothing Then
                CollectParameters(Params, LocalCommand)
            End If
        End With
        result = LocalCommand.ExecuteScalar
        Return result
    End Function
    'added by dhonn brion --v
    Public Function Return_StringResult(ByVal StringConnection As String, ByVal StringProcedure As String, _
    ByVal ComType As CommandType, Optional ByVal Params() As SqlParameter = Nothing) As String
        Dim result As String
        Dim LocalCommand As New SqlCommand
        With LocalCommand
            .Connection = ObjectConnection(StringConnection)
            .CommandText = StringProcedure
            .CommandType = ComType
            If Not Params Is Nothing Then
                CollectParameters(Params, LocalCommand)
            End If
        End With
        result = LocalCommand.ExecuteScalar
        Return result
    End Function

    Function Decrypt(ByVal xpassword As Object) As String
        Dim i As Integer
        Dim curr_lett As String, decr_lett As String, decr_pass As String
        For i = Len(xpassword) To 1 Step -1
            curr_lett = Mid(xpassword.ToString, i, 1)
            'If Len(curr_left) = 0 Then curr_lett = " "
            decr_lett = Chr(Asc(curr_lett) - ((Len(xpassword.ToString) + 1) - i))
            decr_pass = Trim$(decr_pass & decr_lett)
        Next i
        Decrypt = decr_pass
    End Function

    Function Encrypt(ByVal xpassword As Object) As String
        Dim i As Integer
        Dim curr_lett As String, encr_lett As String, encr_pass As String
        For i = Len(xpassword) To 1 Step -1
            curr_lett = Mid(xpassword.ToString, i, 1)
            'If Len(curr_left) = 0 Then curr_lett = " "
            encr_lett = Chr(Asc(curr_lett) + i)
            encr_pass = Trim(encr_pass & encr_lett)
        Next i
        Encrypt = encr_pass
    End Function
    'added by dhonn brion --^
    Private Sub CollectParameters(ByVal Params() As SqlParameter, ByVal LocalCommand As SqlCommand)
        Dim i As Integer
        With LocalCommand
            For i = 0 To Params.GetUpperBound(0)
                .Parameters.Add(Params(i))
            Next
        End With
    End Sub
End Class
