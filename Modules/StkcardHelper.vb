Imports System.Data.SqlClient
Module StkcardHelper
    Public Sub StkcardMDI_Insert(_ItemCode As String, _Warehouse As String, _LotNo As String, _ExpDate As DateTime, _EndQty As Decimal, _Updateby As String)
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(5) As SqlParameter
            Dim ItemCode As New SqlParameter("@ItemCode", SqlDbType.VarChar, 10) : ItemCode.Direction = ParameterDirection.Input : ItemCode.Value = _ItemCode : Params(0) = ItemCode
            Dim Warehouse As New SqlParameter("@Warehouse", SqlDbType.VarChar, 10) : Warehouse.Direction = ParameterDirection.Input : Warehouse.Value = _Warehouse : Params(1) = Warehouse
            Dim Lotno As New SqlParameter("@Lotno", SqlDbType.VarChar, 10) : Lotno.Direction = ParameterDirection.Input : Lotno.Value = _LotNo : Params(2) = Lotno
            Dim Expdate As New SqlParameter("@Expdate", SqlDbType.DateTime, 10) : Expdate.Direction = ParameterDirection.Input : Expdate.Value = _ExpDate : Params(3) = Expdate
            Dim Endqty As New SqlParameter("@Endqty", SqlDbType.Money, 12) : Endqty.Direction = ParameterDirection.Input : Endqty.Value = _EndQty : Params(4) = Endqty
            Dim Updateby As New SqlParameter("@Updateby", SqlDbType.VarChar, 10) : Updateby.Direction = ParameterDirection.Input : Updateby.Value = gUserID : Params(5) = Updateby
            BusinessObject.Sub_Insert(ServerPath2, "StkcardMDI_Insert", CommandType.StoredProcedure, Params)
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("Item_Insert.Error: " & ex.Message)
        End Try

    End Sub

    Public Sub Stkcard_DeleteMDI(_Warehouse As String)
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim Warehouse As New SqlParameter("@Warehouse", SqlDbType.VarChar, 10) : Warehouse.Direction = ParameterDirection.Input : Warehouse.Value = _Warehouse : Params(0) = Warehouse
            BusinessObject.Sub_Insert(ServerPath2, "StkcardMDI_Delete", CommandType.StoredProcedure, Params)
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("StkcardMDI_Delete.Error: " & ex.Message)
        End Try
    End Sub
End Module
