Imports System.data.SqlClient
Module NewObjects
    Public Function objConnection(ByVal strConnection As String) As SqlConnection
        Dim myConnection As New SqlConnection
        Try
            With myConnection
                .ConnectionString = strConnection
                .Open()
            End With
            Return myConnection
        Catch ex As Exception
            MessageBox.Show(ex.Message, "NewObjects Module : objConnection Function")
        Finally
            myConnection.Close()
        End Try
    End Function

End Module
