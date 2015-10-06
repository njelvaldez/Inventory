Imports System.Data.SqlClient
Module ISpecialistHelper
    Public Function ISpecialist_Select_TeamSegment(steamsegment As String, smonthyear As String) As DataSet
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim TEAMSEGMENT As New SqlParameter("@TEAMSEGMENT", SqlDbType.VarChar, 25) : TEAMSEGMENT.Direction = ParameterDirection.Input : TEAMSEGMENT.Value = steamsegment : Params(0) = TEAMSEGMENT
            Dim MONTHYEAR As New SqlParameter("@MONTHYEAR", SqlDbType.DateTime, 10) : MONTHYEAR.Direction = ParameterDirection.Input : MONTHYEAR.Value = Convert.ToDateTime(smonthyear) : Params(1) = MONTHYEAR
            BusinessObject.Sub_Show(ServerPath2, "ISpecialist_Select_TeamSegment", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
        Catch ex As Exception
        End Try
        Return RemoteDataSet
    End Function
End Module
