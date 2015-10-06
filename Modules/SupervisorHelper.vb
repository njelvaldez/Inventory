Imports System.Data.SqlClient
Imports System.Collections.Generic
Module SupervisorHelper
    Public Function TeammanagerLookUp() As DataSet
        Dim dstemp As New DataSet
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            dstemp.Tables.Add("Table1")
            BusinessObject.Sub_Show(ServerPath2, "TeamManagerLookUp", CommandType.StoredProcedure, dstemp, "Table1")
        Catch ex As Exception
            MsgBox("Error : " + ex.Message)
        End Try
        Return dstemp
    End Function
End Module
