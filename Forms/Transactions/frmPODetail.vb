Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmPODetail
    Private RemoteDataSet As New DataSet
    Private EditMode As Boolean = False
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        modControlBehavior.EnableControlsGroup(Me, True)
        ControlMaintenance.ClearInputControlsGroup(Me)
        EditMode = False
        EnableCodeAndDesc(False)
        txtITEMCODE.Enabled = True
        modControlBehavior.SetBackgroundControlsGroup(Me)
        btnItem_Click(sender, e)
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        modControlBehavior.EnableControlsGroup(Me, True)
        If txtPONo.Text = "" And txtITEMCODE.Text = "" Then
            MessageBox.Show("Please select a record to modify!", "Record Selection", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            modControlBehavior.EnableControlsGroup(Me, True)
            EditMode = True
            EnableCodeAndDesc(False)
            SetBackgroundControlsGroup(Me)
            txtqty.Focus()
        End If
    End Sub
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'If txtRowid.Text > "" Then
        '    If (MessageBox.Show("Do you really want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, _
        '    MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)) = DialogResult.Yes Then
        '        Sub_Delete()
        '        ControlMaintenance.ClearInputControlsGroup(Me)
        '        Sub_Show()
        '    End If
        'End If
        MsgBox("Deletion of PO is not allowed!")
    End Sub
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        modControlBehavior.EnableControlsGroup(Me, False)
        ControlMaintenance.ClearInputControlsGroup(Me)
        EditMode = False
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Dim Params(0) As String
        Params(0) = txtRowid.Text
        If ErrorProvider1.GetError(txtQty).ToString <> "" Then
            MsgBox(ErrorProvider1.GetError(txtQty).ToString)
            Return
        End If
        If ErrorProvider1.GetError(txtDeliveryDate).ToString <> "" Then
            MsgBox(ErrorProvider1.GetError(txtDeliveryDate).ToString)
            Return
        End If
        If EditMode = False Then
            If AllValidFields() Then
                Sub_Insert()
            Else
                MsgBox("Invalid entries! Please check all fields!")
                Return
            End If
        Else
            Sub_Update()
        End If

        Sub_Show()
        Sub_Select(Params, CStr(IIf(EditMode = False, "Insert", "Update")))
        EditMode = False
        modControlBehavior.EnableControlsGroup(Me, False)
    End Sub
    Private Function AllValidFields() As Boolean
        Dim retval As Boolean = False
        If txtPONo.Text.ToString <> "" And txtITEMCODE.Text.ToString <> "" And _
           txtQty.Text.ToString <> "" And txtUnitCost.Text.ToString <> "" And _
           txtCostCenter.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(8) As SqlParameter
            Dim PONO As New SqlParameter("@PONO", SqlDbType.VarChar, 10) : PONO.Direction = ParameterDirection.Input : PONO.Value = txtPONo.Text : Params(0) = PONO
            Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10) : ITEMCODE.Direction = ParameterDirection.Input : ITEMCODE.Value = txtITEMCODE.Text : Params(1) = ITEMCODE
            Dim QTY As New SqlParameter("@QTY", SqlDbType.Decimal, 10) : QTY.Direction = ParameterDirection.Input : QTY.Value = txtQty.Text : Params(2) = QTY
            Dim UNITPRICE As New SqlParameter("@UNITPRICE", SqlDbType.Decimal, 10) : UNITPRICE.Direction = ParameterDirection.Input : UNITPRICE.Value = txtUnitCost.Text : Params(3) = UNITPRICE
            Dim AMOUNT As New SqlParameter("@AMOUNT", SqlDbType.Decimal, 10) : AMOUNT.Direction = ParameterDirection.Input : AMOUNT.Value = txtAmount.Text : Params(4) = AMOUNT
            Dim COSTCENTER As New SqlParameter("@COSTCENTER", SqlDbType.VarChar, 250) : COSTCENTER.Direction = ParameterDirection.Input : COSTCENTER.Value = txtCostCenter.Text : Params(5) = COSTCENTER
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
            Dim SPECIFICATIONS As New SqlParameter("@SPECIFICATIONS", SqlDbType.VarChar, 250) : SPECIFICATIONS.Direction = ParameterDirection.Input : SPECIFICATIONS.Value = txtSpecs.Text : Params(7) = SPECIFICATIONS
            Dim DELIVERYDATE As New SqlParameter("@DELIVERYDATE", SqlDbType.DateTime, 10) : DELIVERYDATE.Direction = ParameterDirection.Input : DELIVERYDATE.Value = Convert.ToDateTime(txtDeliveryDate.Text) : Params(8) = DELIVERYDATE
            If ItemExists() Then
                MsgBox("PO Number : " & txtPONo.Text & " and Inventory Description : " & txtITEMDESC.Text & " already exists!")
            Else
                BusinessObject.Sub_Insert(ServerPath2, "IPODetail_Insert", CommandType.StoredProcedure, Params)
                LogHelper.InsertLog("IPODetail_Insert")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IPODetail_Insert.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Update()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(9) As SqlParameter
            Dim PONO As New SqlParameter("@PONO", SqlDbType.VarChar, 10) : PONO.Direction = ParameterDirection.Input : PONO.Value = txtPONo.Text : Params(0) = PONO
            Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10) : ITEMCODE.Direction = ParameterDirection.Input : ITEMCODE.Value = txtITEMCODE.Text : Params(1) = ITEMCODE
            Dim QTY As New SqlParameter("@QTY", SqlDbType.Decimal, 10) : QTY.Direction = ParameterDirection.Input : QTY.Value = txtQty.Text : Params(2) = QTY
            Dim UNITPRICE As New SqlParameter("@UNITPRICE", SqlDbType.Decimal, 10) : UNITPRICE.Direction = ParameterDirection.Input : UNITPRICE.Value = txtUnitCost.Text : Params(3) = UNITPRICE
            Dim AMOUNT As New SqlParameter("@AMOUNT", SqlDbType.Decimal, 10) : AMOUNT.Direction = ParameterDirection.Input : AMOUNT.Value = txtAmount.Text : Params(4) = AMOUNT
            Dim COSTCENTER As New SqlParameter("@COSTCENTER", SqlDbType.VarChar, 250) : COSTCENTER.Direction = ParameterDirection.Input : COSTCENTER.Value = txtCostCenter.Text : Params(5) = COSTCENTER
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
            Dim ROWID As New SqlParameter("@ROWID", SqlDbType.Int, 10) : ROWID.Direction = ParameterDirection.Input : ROWID.Value = Convert.ToInt16(txtRowid.Text) : Params(7) = ROWID
            Dim SPECIFICATIONS As New SqlParameter("@SPECIFICATIONS", SqlDbType.VarChar, 250) : SPECIFICATIONS.Direction = ParameterDirection.Input : SPECIFICATIONS.Value = txtSpecs.Text : Params(8) = SPECIFICATIONS
            Dim DELIVERYDATE As New SqlParameter("@DELIVERYDATE", SqlDbType.DateTime, 10) : DELIVERYDATE.Direction = ParameterDirection.Input : DELIVERYDATE.Value = Convert.ToDateTime(txtDeliveryDate.Text) : Params(9) = DELIVERYDATE
            BusinessObject.Sub_Insert(ServerPath2, "IPODetail_Update", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("IPODetail_Update")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IPODetail_Update.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Show()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim PONO As New SqlParameter("@PONO ", SqlDbType.VarChar, 10)
            PONO.Direction = ParameterDirection.Input
            PONO.Value = txtPONo.Text.ToString.Trim
            Params(0) = PONO

            BusinessObject.Sub_Show(ServerPath2, "IPODetail_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
            dgPODetail.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Number of Items : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
            LogHelper.InsertLog("IPOHeader_Show.Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IPOHeader_Show.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Select(ByVal dbParams() As String, ByVal UpdateMode As String)
        'select case if add,edit or delete
        Dim i As Integer
        Dim myRowid As Integer
        Select Case UpdateMode
            Case "Insert"
                Dim BusinessObject As New BusinessLayer.clsFileMaintenance
                myRowid = CInt(BusinessObject.Sub_ReturnIntegerResult(ServerPath2, "IPODetail_GetInsertedRowid", CommandType.StoredProcedure))
            Case "Update"
                myRowid = CInt(dbParams(0))
        End Select
        For i = 0 To (RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count - 1)
            With dgPODetail
                If myRowid = CInt(.Item(i, 0)) Then
                    .CurrentCell = New DataGridCell(i, 0)
                    Dim e As System.EventArgs
                    DataGrid1_Click(Me, e)
                    Exit For
                End If
            End With
        Next
    End Sub
    'Private Sub Sub_Delete()
    '    Try
    '        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
    '        Dim Params(0) As SqlParameter
    '        Dim Rowid As New SqlParameter("@Rowid", SqlDbType.Int) : Rowid.Direction = ParameterDirection.Input : Rowid.Value = txtRowid.Text : Params(0) = Rowid
    '        BusinessObject.Sub_Delete(ServerPath2, "ProductFormCT_Delete", CommandType.StoredProcedure, Params)
    '        LogHelper.InsertLog("ProductFormCT_Delete.Success")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        LogHelper.InsertLog("ProductFormCT_Delete.Error")
    '    End Try
    'End Sub
    Private Sub frmPOHeader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modControlBehavior.EnableControls(Me, False)
        modControlBehavior.EnableControlsGroup(Me, False)
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
        'LoadLookUp()
        Sub_Show()
        dgPODetail.AlternatingBackColor = Color.LightGreen
    End Sub
    'Private Sub LoadLookUp()
    '    Try
    '        If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
    '        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
    '        BusinessObject.Sub_Show(ServerPath2, "ISegment_LookUp", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
    '        ResetTable()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        LogHelper.InsertLog("ProductFormCT_Show.Error: " & ex.Message)
    '    End Try
    'End Sub
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPODetail.Click, dgPODetail.CurrentCellChanged
        Try
            With dgPODetail
                txtRowid.Text = CStr(.Item(.CurrentCell.RowNumber, 0))
                'no need to fill txtPONo.Text = CStr(.Item(.CurrentCell.RowNumber, 1))
                txtITEMCODE.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                txtITEMDESC.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                txtqty.Text = CStr(.Item(.CurrentCell.RowNumber, 4))
                txtUnitCost.Text = CStr(.Item(.CurrentCell.RowNumber, 5))
                Try
                    txtAmount.Text = CStr(.Item(.CurrentCell.RowNumber, 6))
                Catch ex As Exception

                End Try
                txtCostCenter.Text = CStr(.Item(.CurrentCell.RowNumber, 7))
                lblCreateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 8))
                lblUpdateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 9))
                lblUpdateBy.Text = CStr(.Item(.CurrentCell.RowNumber, 10))
                txtSpecs.Text = CStr(.Item(.CurrentCell.RowNumber, 11))
                .Select(.CurrentCell.RowNumber)
            End With
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try

    End Sub

    Private Sub Frm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        EnDisMainMenu(Me, True)
        'ChildCtr = ChildCtr - 1              '<--ready for 2forms need
    End Sub

    Private Sub Frm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        EnDisMainMenu(Me, False)
    End Sub

    Private Sub frmProcessInMarketData_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        'If CloseFrm = True Then              '<- ready
        '    CloseFrm = False                 '<- for
        '    Close()                          '<- 2forms
        'End If                               '<- need
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Sub_Show()
    End Sub
    Private Sub EnableCodeAndDesc(enableflag As Boolean)
        txtITEMCODE.Enabled = False
        txtITEMDESC.Enabled = False
        txtPONo.Enabled = False
        txtQty.Enabled = True
        txtAmount.Enabled = False
        If EditMode Then
            btnItem.Enabled = False
        Else
            btnItem.Enabled = True
        End If
    End Sub
    Private Function ItemExists() As Boolean
        Dim retval As Boolean = False
        If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim Params(1) As SqlParameter

        Dim PONO As New SqlParameter("@PONO", SqlDbType.VarChar, 10)
        PONO.Direction = ParameterDirection.Input
        PONO.Value = txtPONo.Text.ToString.Trim
        Params(0) = PONO

        Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10)
        ITEMCODE.Direction = ParameterDirection.Input
        ITEMCODE.Value = txtITEMCODE.Text.ToString.Trim
        Params(1) = ITEMCODE

        BusinessObject.Sub_Show(ServerPath2, "IPODetail_SearchCodeOrDesc", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
        If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then
            retval = True
        End If
        Return retval
    End Function

    Private Sub ResetTable()
        If RemoteDataSet.Tables.Count > 0 Then
            RemoteDataSet.Tables.Remove("ProductFormCT_Show")
        End If
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myLoadedForm As New frmReportViewer
        myLoadedForm.Report = "Purchase Order Report"
        myLoadedForm.Status = "ALL"
        myLoadedForm.PONO = txtPONo.Text
        myLoadedForm.ShowDialog()
    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs) Handles dgPODetail.Navigate

    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim dstemp As New DataSet
        dstemp.Tables.Add("Table1")
        BusinessObject.Sub_Show(ServerPath2, "Item_LookUp", CommandType.StoredProcedure, dstemp, "Table1")
        gCode = txtITEMCODE.Text : gDesc = txtITEMDESC.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Samples and Promats Look-Up"
        myLoadedForm.RemoteDataTable = dstemp.Tables("Table1")
        myLoadedForm.ShowDialog(Me)
        txtITEMCODE.Text = gCode
        txtITEMDESC.Text = gDesc
        txtQty.Focus()
    End Sub

    Private Sub ComputeAmount()
        If txtUnitCost.Text <> "" And txtQty.Text <> "" Then
            txtAmount.Text = Convert.ToString(StringToDecimal(txtUnitCost.Text) * StringToDecimal(txtQty.Text))
        Else
            txtAmount.Text = "0.00"
        End If
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        ComputeAmount()
    End Sub

    Private Sub txtUnitPrice_TextChanged(sender As Object, e As EventArgs) Handles txtUnitCost.TextChanged
        ComputeAmount()
    End Sub

    Private Sub txtQty_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtQty.Validating
        Dim MOQ As Decimal = 0
        MOQ = PODetail_Qty(txtItemCode.Text)
        If MOQ > 0 And Convert.ToDecimal(txtQty.Text) < MOQ Then
            ErrorProvider1.SetError(txtQty, "Invalid Quantity!")
        Else
            ErrorProvider1.SetError(txtQty, "")
            SetCost()
        End If
    End Sub

    Private Sub txtItemDesc_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtItemDesc.Validating
     

    End Sub

    Private Sub txtItemDesc_TextChanged(sender As Object, e As EventArgs) Handles txtItemDesc.TextChanged
        Dim LeadTime As Decimal = 0.0
        Dim Processing As Decimal = 0.0
        Dim TotalTime As Decimal = 0.0
        Dim DeliveryDate As DateTime
        Dim LeadtimeDate As DateTime
        Dim CreateDate As DateTime
        DeliveryDate = Convert.ToDateTime(txtDeliveryDate.Text)
        LeadTime = Item_Leadtime(txtItemCode.Text)
        Processing = Item_Processing(txtItemCode.Text)
        TotalTime = LeadTime + Processing
        If lblCreateDate.Text <> "" Then
            CreateDate = Convert.ToDateTime(lblCreateDate.Text)
        Else
            CreateDate = DateTime.Now
        End If
        LeadtimeDate = DateAdd(DateInterval.Month, TotalTime, CreateDate)
        If txtItemDesc.Text <> "" Then
            If TotalTime > 0 And DateDiff(DateInterval.Day, DeliveryDate, LeadtimeDate) > 1 Then
                ErrorProvider1.SetError(txtDeliveryDate, "Invalid delivery date!")
            Else
                ErrorProvider1.SetError(txtDeliveryDate, "")
            End If
        Else
            'MsgBox("Please select valid Item!")
        End If
    End Sub
    Private Sub SetCost()
        txtUnitCost.Text = Item_UnitCost(txtItemCode.Text).ToString
        txtAmount.Text = Convert.ToDecimal(txtUnitCost.Text) * Convert.ToDecimal(txtQty.Text)
    End Sub
End Class