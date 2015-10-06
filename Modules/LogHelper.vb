Imports System.Data.SqlClient
Module LogHelper
    Public Sub InsertLog(ByVal Msg As String)
        Dim enablelog As String = System.Configuration.ConfigurationSettings.AppSettings.Item("EnableLog")
        Dim strtempuser As String = "nouser"
        If enablelog.Equals("true") Then
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter

            Dim Message As New SqlParameter("@Message", SqlDbType.Text, 1500)
            Message.Direction = ParameterDirection.Input
            Message.Value = Msg
            Params(0) = Message

            Dim LogDate As New SqlParameter("@LogDate", SqlDbType.DateTime, 10)
            LogDate.Direction = ParameterDirection.Input
            LogDate.Value = DateTime.Now()
            Params(1) = LogDate

            If Not gUserName Is Nothing Then
                strtempuser = gUserName
            End If
            Dim UserName As New SqlParameter("@UserName", SqlDbType.VarChar, 25)
            UserName.Direction = ParameterDirection.Input
            UserName.Value = strtempuser
            Params(2) = UserName

            Try
                BusinessObject.Sub_Insert(ServerPath2, "Log_Insert", CommandType.StoredProcedure, Params)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                BusinessObject = Nothing
                Params = Nothing
                Message = Nothing
                LogDate = Nothing
            End Try
        End If
    End Sub
End Module
