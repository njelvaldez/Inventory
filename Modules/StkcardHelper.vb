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

    Public Function IMSLotNoExpdate(_itemcode As String, _lotno As String) As DateTime
        Dim retval As DateTime = DefaultDate()
        Dim RemoteDataSet As New DataSet
        Try
            RemoteDataSet.Tables.Add("Table1")
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(1) As SqlParameter
            Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10) : ITEMCODE.Direction = ParameterDirection.Input : ITEMCODE.Value = _itemcode : Params(0) = ITEMCODE
            Dim LOTNO As New SqlParameter("@LOTNO", SqlDbType.VarChar, 10) : LOTNO.Direction = ParameterDirection.Input : LOTNO.Value = _lotno : Params(1) = LOTNO
            BusinessObject.Sub_Show(ServerPath2, "IMSLotNoExpdate", CommandType.StoredProcedure, RemoteDataSet, "Table1", Params)
            If RemoteDataSet.Tables(0).Rows.Count > 0 Then
                retval = RemoteDataSet.Tables(0).Rows(0)(0)
            End If
        Catch ex As Exception
            MsgBox("Error in IMSLotNoExpdate : " & ex.Message)
        End Try
        Return retval
    End Function

    Public Function DefaultDate() As DateTime
        Return Convert.ToDateTime("1/1/1901")
    End Function

    'Update Stkcard IMS Adjustment Inventory
    Public Sub StkcardIMSAdjustment(_LocCode As String, _ItemCode As String, _LotNo As String, _ExpDate As DateTime, _Adjqty As Decimal)
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(5) As SqlParameter
            Dim LocCode As New SqlParameter("@LocCode", SqlDbType.VarChar, 5) : LocCode.Direction = ParameterDirection.Input : LocCode.Value = _LocCode : Params(0) = LocCode
            Dim ItemCode As New SqlParameter("@ItemCode", SqlDbType.VarChar, 10) : ItemCode.Direction = ParameterDirection.Input : ItemCode.Value = _ItemCode : Params(1) = ItemCode
            Dim Lotno As New SqlParameter("@Lotno", SqlDbType.VarChar, 10) : Lotno.Direction = ParameterDirection.Input : Lotno.Value = _LotNo : Params(2) = Lotno
            Dim Expdate As New SqlParameter("@Expdate", SqlDbType.DateTime, 10) : Expdate.Direction = ParameterDirection.Input : Expdate.Value = _ExpDate : Params(3) = Expdate
            Dim Adjqty As New SqlParameter("@Adjqty", SqlDbType.Money, 12) : Adjqty.Direction = ParameterDirection.Input : Adjqty.Value = _Adjqty : Params(4) = Adjqty
            Dim Updateby As New SqlParameter("@Updateby", SqlDbType.VarChar, 10) : Updateby.Direction = ParameterDirection.Input : Updateby.Value = gUserID : Params(5) = Updateby

            'Check if IMS,Location,Itemcode,LotNo exists?
            If IMSLotNoExpdate(_ItemCode, _LotNo) = DefaultDate() Then
                'Inventory does not exist
                BusinessObject.Sub_Insert(ServerPath2, "StkcardIMSAdjustmentInsert", CommandType.StoredProcedure, Params)
            Else
                'Inventory exists
                BusinessObject.Sub_Insert(ServerPath2, "StkcardIMSAdjustmentUpdate", CommandType.StoredProcedure, Params)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("StkcardIMSAdjustment: " & ex.Message)
        End Try
    End Sub

    'Update Stkcard IMS Receive Inventory
    Public Sub StkcardIMSReceive(_LocCode As String, _ItemCode As String, _LotNo As String, _ExpDate As DateTime, _Recqty As Decimal)
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(5) As SqlParameter
            Dim LocCode As New SqlParameter("@LocCode", SqlDbType.VarChar, 5) : LocCode.Direction = ParameterDirection.Input : LocCode.Value = _LocCode : Params(0) = LocCode
            Dim ItemCode As New SqlParameter("@ItemCode", SqlDbType.VarChar, 10) : ItemCode.Direction = ParameterDirection.Input : ItemCode.Value = _ItemCode : Params(1) = ItemCode
            Dim Lotno As New SqlParameter("@Lotno", SqlDbType.VarChar, 10) : Lotno.Direction = ParameterDirection.Input : Lotno.Value = _LotNo : Params(2) = Lotno
            Dim Expdate As New SqlParameter("@Expdate", SqlDbType.DateTime, 10) : Expdate.Direction = ParameterDirection.Input : Expdate.Value = _ExpDate : Params(3) = Expdate
            Dim RecQty As New SqlParameter("@RecQty", SqlDbType.Money, 12) : RecQty.Direction = ParameterDirection.Input : RecQty.Value = _Recqty : Params(4) = RecQty
            Dim Updateby As New SqlParameter("@Updateby", SqlDbType.VarChar, 10) : Updateby.Direction = ParameterDirection.Input : Updateby.Value = gUserID : Params(5) = Updateby

            'Check if IMS,Location,Itemcode,LotNo exists?
            If IMSLotNoExpdate(_ItemCode, _LotNo) = DefaultDate() Then
                'Inventory does not exist
                BusinessObject.Sub_Insert(ServerPath2, "StkcardIMSReceiveInsert", CommandType.StoredProcedure, Params)
            Else
                'Inventory exists
                BusinessObject.Sub_Insert(ServerPath2, "StkcardIMSReceiveUpdate", CommandType.StoredProcedure, Params)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("StkcardIMSReceive: " & ex.Message)
        End Try
    End Sub

    'Update Stkcard Issued Inventory
    Public Sub StkcardIMSIssue(_LocCode As String, _ItemCode As String, _LotNo As String, _ExpDate As DateTime, _Issqty As Decimal)
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(5) As SqlParameter
            Dim LocCode As New SqlParameter("@LocCode", SqlDbType.VarChar, 5) : LocCode.Direction = ParameterDirection.Input : LocCode.Value = _LocCode : Params(0) = LocCode
            Dim ItemCode As New SqlParameter("@ItemCode", SqlDbType.VarChar, 10) : ItemCode.Direction = ParameterDirection.Input : ItemCode.Value = _ItemCode : Params(1) = ItemCode
            Dim Lotno As New SqlParameter("@Lotno", SqlDbType.VarChar, 10) : Lotno.Direction = ParameterDirection.Input : Lotno.Value = _LotNo : Params(2) = Lotno
            Dim Expdate As New SqlParameter("@Expdate", SqlDbType.DateTime, 10) : Expdate.Direction = ParameterDirection.Input : Expdate.Value = _ExpDate : Params(3) = Expdate
            Dim IssQty As New SqlParameter("@IssQty", SqlDbType.Money, 12) : IssQty.Direction = ParameterDirection.Input : IssQty.Value = _IssQty : Params(4) = IssQty
            Dim Updateby As New SqlParameter("@Updateby", SqlDbType.VarChar, 10) : Updateby.Direction = ParameterDirection.Input : Updateby.Value = gUserID : Params(5) = Updateby

            'Check if IMS,Location,Itemcode,LotNo exists?
            If IMSLotNoExpdate(_ItemCode, _LotNo) = DefaultDate() Then
                'Inventory does not exist
                BusinessObject.Sub_Insert(ServerPath2, "StkcardIMSIssueInsert", CommandType.StoredProcedure, Params)
            Else
                'Inventory exists
                BusinessObject.Sub_Insert(ServerPath2, "StkcardIMSIssueUpdate", CommandType.StoredProcedure, Params)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("StkcardIMSIssue: " & ex.Message)
        End Try
    End Sub
End Module
