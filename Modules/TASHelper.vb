Imports System.Data.SqlClient
Imports System.Collections.Generic
Module TASHelper
    Public Function TAS_DispacthReportNotInInv(DMONTHYEAR As DateTime) As DataSet
        Dim dstemp As New DataSet
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params1(0) As SqlParameter
            Dim MONTHYEAR As New SqlParameter("@MONTHYEAR", SqlDbType.DateTime, 10)
            dstemp.Tables.Add("Table1")
            MONTHYEAR.Direction = ParameterDirection.Input
            MONTHYEAR.Value = DMONTHYEAR
            Params1(0) = MONTHYEAR
            BusinessObject.Sub_Show(ServerPath2, "ISSPM_DispatchNotInTAS", CommandType.StoredProcedure, dstemp, "Table1", Params1)
        Catch ex As Exception
            MsgBox("Error : " + ex.Message)
        End Try
        Return dstemp
    End Function

    Public Function CopyDispatchToTAS(DMONTHYEAR As DateTime) As Boolean
        Dim retval As Boolean = True
        Using connection As New SqlConnection(TASServerPath)
            Try
                connection.Open()
                Dim myDataSet As DataSet = New DataSet
                myDataSet.Tables().Add("Table1")
                myDataSet = TAS_DispacthReportNotInInv(DMONTHYEAR)
                'Delete dispatch for monthyear
                Dim delcommand As New SqlCommand("Delete from tmpDispatch Where MonthYear = '" & DMONTHYEAR.ToShortDateString & "'", connection)
                Try
                    delcommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error in Delete from tmpDispatch")
                End Try
                Dim r As DataRow

                For Each r In myDataSet.Tables(0).Rows
                    Dim updqueryString As String = "INSERT INTO [tmpDispatch]"
                    updqueryString += " ([TEAMSEGMENT] "
                    updqueryString += ",[MONTHYEAR]"
                    updqueryString += ",[INVTYCODE]"
                    updqueryString += ",[INVTYDESC]"
                    updqueryString += ",[TYPE])"
                    updqueryString += "VALUES"
                    updqueryString += "('" & r("TEAMSEGMENT") & "',"
                    updqueryString += "'" & r("MONTHYEAR") & "',"
                    updqueryString += "'" & r("INVTYCODE") & "',"
                    updqueryString += "'" & r("INVTYDESC").ToString().Replace("'", "''") & "',"
                    updqueryString += "'" & r("TYPE") & "')"
                    Dim updcommand As New SqlCommand(updqueryString, connection)
                    Try
                        updcommand.ExecuteNonQuery()
                    Catch ex As Exception
                        MessageBox.Show("Error :" + ex.Message)
                        retval = False
                    End Try
                Next
            Catch ex As Exception
                MessageBox.Show("Error :" + ex.Message)
            End Try
            connection.Close()
        End Using
        Return retval
    End Function

End Module
