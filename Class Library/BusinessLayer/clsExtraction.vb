Imports System.Data.SqlClient
Public Class clsExtraction
    Public Sub Process_MDIData(ByVal StringConnection As String, ByVal StringProcedure As String, _
        ByVal ComType As CommandType, Optional ByVal Params() As SqlParameter = Nothing)
        Dim daHelper As New DataAccessLayer.DataAccessHelper
        daHelper.ExecuteNonQuery(StringConnection, StringProcedure, ComType, Params)
    End Sub
End Class