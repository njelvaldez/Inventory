Imports System.Data.SqlClient
Module UserAccess
    Public Function AccessIsAlowed(useridval As String, modulename As String) As Boolean
        Dim retval As Boolean = False
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim USERID As New SqlParameter("@USERID", SqlDbType.VarChar, 10) : USERID.Direction = ParameterDirection.Input : USERID.Value = useridval : Params(0) = USERID
            Dim MODULES As New SqlParameter("@MODULE", SqlDbType.VarChar, 25) : MODULES.Direction = ParameterDirection.Input : MODULES.Value = modulename : Params(1) = MODULES
            BusinessObject.Sub_Show(ServerPath2, "IRoleModules_Exists", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables(0).Rows.Count > 0 Then
                retval = True
            Else
                retval = False
            End If
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function

    Public Function GetUserName(useridval As String) As String
        Dim retval As String = "Undefined"
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim USERID As New SqlParameter("@USERID", SqlDbType.VarChar, 10) : USERID.Direction = ParameterDirection.Input : USERID.Value = useridval : Params(0) = USERID
            BusinessObject.Sub_Show(ServerPath2, "UserTab_UserName", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables(0).Rows.Count > 0 Then
                retval = RemoteDataSet.Tables(0).Rows(0)(0).ToString
            End If
        Catch ex As Exception
        End Try
        Return retval
    End Function

    Public Function GetUserPassword(useridval As String) As String
        Dim retval As String = "Undefined"
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim USERID As New SqlParameter("@USERID", SqlDbType.VarChar, 10) : USERID.Direction = ParameterDirection.Input : USERID.Value = useridval : Params(0) = USERID
            BusinessObject.Sub_Show(ServerPath2, "UserTab_Password", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables(0).Rows.Count > 0 Then
                retval = RemoteDataSet.Tables(0).Rows(0)(0).ToString
            End If
        Catch ex As Exception
        End Try
        Return retval
    End Function

    Public Function SaveUserPassword(useridval As String, userpassword As String) As Boolean
        Dim retval As Boolean = True
        Dim RemoteDataSet As New DataSet
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim USERID As New SqlParameter("@USERID", SqlDbType.VarChar, 10) : USERID.Direction = ParameterDirection.Input : USERID.Value = useridval : Params(0) = USERID
            Dim PASSWORD As New SqlParameter("@PASSWORD", SqlDbType.VarChar, 15) : PASSWORD.Direction = ParameterDirection.Input : PASSWORD.Value = userpassword : Params(1) = PASSWORD
            BusinessObject.Sub_Update(ServerPath2, "UserTab_SavePassword", CommandType.StoredProcedure, Params)
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function

    Public Function UserCanAdd(useridval As String, modulename As String) As Boolean
        Dim retval As Boolean = False
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim USERID As New SqlParameter("@USERID", SqlDbType.VarChar, 10) : USERID.Direction = ParameterDirection.Input : USERID.Value = useridval : Params(0) = USERID
            Dim MODULES As New SqlParameter("@MODULE", SqlDbType.VarChar, 25) : MODULES.Direction = ParameterDirection.Input : MODULES.Value = modulename : Params(1) = MODULES
            BusinessObject.Sub_Show(ServerPath2, "IRoleModules_CanAdd", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables(0).Rows.Count > 0 Then
                retval = True
            Else
                retval = False
                MsgBox("User Access is not allowed!")

            End If
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function

    Public Function UserCanEdit(useridval As String, modulename As String) As Boolean
        Dim retval As Boolean = False
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim USERID As New SqlParameter("@USERID", SqlDbType.VarChar, 10) : USERID.Direction = ParameterDirection.Input : USERID.Value = useridval : Params(0) = USERID
            Dim MODULES As New SqlParameter("@MODULE", SqlDbType.VarChar, 25) : MODULES.Direction = ParameterDirection.Input : MODULES.Value = modulename : Params(1) = MODULES
            BusinessObject.Sub_Show(ServerPath2, "IRoleModules_CanEdit", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables(0).Rows.Count > 0 Then
                retval = True
            Else
                retval = False
                MsgBox("User Access is not allowed!")
            End If
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function


    Public Function UserCanDelete(useridval As String, modulename As String) As Boolean
        Dim retval As Boolean = False
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim USERID As New SqlParameter("@USERID", SqlDbType.VarChar, 10) : USERID.Direction = ParameterDirection.Input : USERID.Value = useridval : Params(0) = USERID
            Dim MODULES As New SqlParameter("@MODULE", SqlDbType.VarChar, 25) : MODULES.Direction = ParameterDirection.Input : MODULES.Value = modulename : Params(1) = MODULES
            BusinessObject.Sub_Show(ServerPath2, "IRoleModules_CanDelete", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables(0).Rows.Count > 0 Then
                retval = True
            Else
                retval = False
                MsgBox("User Access is not allowed!")
            End If
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function


    Public Function UserCanReport(useridval As String, modulename As String) As Boolean
        Dim retval As Boolean = False
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim USERID As New SqlParameter("@USERID", SqlDbType.VarChar, 10) : USERID.Direction = ParameterDirection.Input : USERID.Value = useridval : Params(0) = USERID
            Dim MODULES As New SqlParameter("@MODULE", SqlDbType.VarChar, 25) : MODULES.Direction = ParameterDirection.Input : MODULES.Value = modulename : Params(1) = MODULES
            BusinessObject.Sub_Show(ServerPath2, "IRoleModules_CanReport", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables(0).Rows.Count > 0 Then
                retval = True
            Else
                retval = False
                MsgBox("User Access is not allowed!")
            End If
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function
End Module
