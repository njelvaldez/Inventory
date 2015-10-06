Imports System.Data.SqlClient
Module AdoDotNet
    Public Const ScoresDotNetConnectionString As String = "Data Source=MicDb ; Initial Catalog=ScoresDotNet ;User Id=sa ; Password=jynxz ;"
    Public Function myConnection(ByVal strConnection As String) As SqlConnection
        Dim objConnection As New SqlConnection
        With objConnection
            .ConnectionString = strConnection
            .Open()
        End With
        Return objConnection
    End Function
    'Public Function MedrepBudgetListRows(ByVal strSelect As String, ByVal strCommandType As CommandType, ByVal myArray(,) As Object) As DataSet
    '    Dim objDataSet As New dsMedrepBudgetList
    '    Dim objCommand As New SqlCommand
    '    Dim myDataAdapter As New SqlDataAdapter

    '    With objCommand
    '        .Connection = myConnection(ScoresDotNetConnectionString)
    '        .CommandText = strSelect
    '        .CommandType = strCommandType
    '        .Parameters.Add(CStr(myArray(0, 0)), CType(myArray(0, 1), SqlDbType), CInt(myArray(0, 2))).Value = myArray(0, 3)
    '    End With

    '    'Add the parameters from the array


    '    myDataAdapter.SelectCommand = objCommand
    '    myDataAdapter.Fill(objDataSet, "MedrepBudgetList")
    '    Return objDataSet
    'End Function
    'Public Function BudgetAmounts(ByVal strSelect As String, ByVal strCommandType As CommandType, ByVal myArray(,) As Object) As DataSet
    '    Dim objDataSet As New dsMedrepBudgetList
    '    Dim objCommand As New SqlCommand
    '    Dim myDataAdapter As New SqlDataAdapter

    '    With objCommand
    '        .Connection = myConnection(ScoresDotNetConnectionString)
    '        .CommandText = strSelect
    '        .CommandType = strCommandType
    '        .Parameters.Add(CStr(myArray(0, 0)), CType(myArray(0, 1), SqlDbType), CInt(myArray(0, 2))).Value = myArray(0, 3)
    '        .Parameters.Add(CStr(myArray(1, 0)), CType(myArray(1, 1), SqlDbType), CInt(myArray(1, 2))).Value = myArray(1, 3)
    '    End With

    '    myDataAdapter.SelectCommand = objCommand
    '    myDataAdapter.Fill(objDataSet, "BudgetAmounts")
    '    Return objDataSet
    'End Function

End Module
