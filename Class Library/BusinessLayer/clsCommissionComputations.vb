Imports System.Data.SqlClient
Public Class clsCommissionComputations
    Public Sub Store_CommissionTable(ByVal StringConnection As String, ByVal StringProcedure As String, _
        ByVal ComType As CommandType, ByVal Params() As SqlParameter)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
End Class
