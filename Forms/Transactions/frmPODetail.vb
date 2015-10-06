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
        txtInvtyCode.Enabled = True
        modControlBehavior.SetBackgroundControlsGroup(Me)
        btnItem_Click(sender, e)
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        modControlBehavior.EnableControlsGroup(Me, True)
        If txtPONo.Text = "" And txtInvtyCode.Text = "" Then
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
        If EditMode = False Then
            If AllValidFields() Then
                Sub_Insert()
            Else
                MsgBox("Invalid entries! Please check all fields!")
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
        If txtPONo.Text.ToString <> "" And txtInvtyCode.Text.ToString <> "" And _
           txtQty.Text.ToString <> "" And txtUnitPrice.Text.ToString <> "" And _
           txtCostCenter.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(7) As SqlParameter
            Dim PONO As New SqlParameter("@PONO", SqlDbType.VarChar, 10) : PONO.Direction = ParameterDirection.Input : PONO.Value = txtPONo.Text : Params(0) = PONO
            Dim INVTYCODE As New SqlParameter("@INVTYCODE", SqlDbType.VarChar, 10) : INVTYCODE.Direction = ParameterDirection.Input : INVTYCODE.Value = txtInvtyCode.Text : Params(1) = INVTYCODE
            Dim QTY As New SqlParameter("@QTY", SqlDbType.Decimal, 10) : QTY.Direction = ParameterDirection.Input : QTY.Value = txtQty.Text : Params(2) = QTY
            Dim UNITPRICE As New SqlParameter("@UNITPRICE", SqlDbType.Decimal, 10) : UNITPRICE.Direction = ParameterDirection.Input : UNITPRICE.Value = txtUnitPrice.Text : Params(3) = UNITPRICE
            Dim AMOUNT As New SqlParameter("@AMOUNT", SqlDbType.Decimal, 10) : AMOUNT.Direction = ParameterDirection.Input : AMOUNT.Value = txtAmount.Text : Params(4) = AMOUNT
            Dim COSTCENTER As New SqlParameter("@COSTCENTER", SqlDbType.VarChar, 250) : COSTCENTER.Direction = ParameterDirection.Input : COSTCENTER.Value = txtCostCenter.Text : Params(5) = COSTCENTER
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
            Dim SPECIFICATIONS As New SqlParameter("@SPECIFICATIONS", SqlDbType.VarChar, 250) : SPECIFICATIONS.Direction = ParameterDirection.Input : SPECIFICATIONS.Value = txtSpecs.Text : Params(7) = SPECIFICATIONS
            If ItemExists() Then
                MsgBox("PO Number : " & txtPONo.Text & " and Inventory Description : " & txtInvtyDesc.Text & " already exists!")
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
            Dim Params(8) As SqlParameter
            Dim PONO As New SqlParameter("@PONO", SqlDbType.VarChar, 10) : PONO.Direction = ParameterDirection.Input : PONO.Value = txtPONo.Text : Params(0) = PONO
            Dim INVTYCODE As New SqlParameter("@INVTYCODE", SqlDbType.VarChar, 10) : INVTYCODE.Direction = ParameterDirection.Input : INVTYCODE.Value = txtInvtyCode.Text : Params(1) = INVTYCODE
            Dim QTY As New SqlParameter("@QTY", SqlDbType.Decimal, 10) : QTY.Direction = ParameterDirection.Input : QTY.Value = txtQty.Text : Params(2) = QTY
            Dim UNITPRICE As New SqlParameter("@UNITPRICE", SqlDbType.Decimal, 10) : UNITPRICE.Direction = ParameterDirection.Input : UNITPRICE.Value = txtUnitPrice.Text : Params(3) = UNITPRICE
            Dim AMOUNT As New SqlParameter("@AMOUNT", SqlDbType.Decimal, 10) : AMOUNT.Direction = ParameterDirection.Input : AMOUNT.Value = txtAmount.Text : Params(4) = AMOUNT
            Dim COSTCENTER As New SqlParameter("@COSTCENTER", SqlDbType.VarChar, 250) : COSTCENTER.Direction = ParameterDirection.Input : COSTCENTER.Value = txtCostCenter.Text : Params(5) = COSTCENTER
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
            Dim ROWID As New SqlParameter("@ROWID", SqlDbType.Int, 10) : ROWID.Direction = ParameterDirection.Input : ROWID.Value = Convert.ToInt16(txtRowid.Text) : Params(7) = ROWID
            Dim SPECIFICATIONS As New SqlParameter("@SPECIFICATIONS", SqlDbType.VarChar, 250) : SPECIFICATIONS.Direction = ParameterDirection.Input : SPECIFICATIONS.Value = txtSpecs.Text : Params(8) = SPECIFICATIONS
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
            GroupBox1.Text = "Number of Samples/Promats : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
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
                txtInvtyCode.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                txtInvtyDesc.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                txtqty.Text = CStr(.Item(.CurrentCell.RowNumber, 4))
                txtUNITPRICE.Text = CStr(.Item(.CurrentCell.RowNumber, 5))
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
        txtInvtyCode.Enabled = False
        txtInvtyDesc.Enabled = False
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

        Dim INVTYCODE As New SqlParameter("@INVTYCODE", SqlDbType.VarChar, 10)
        INVTYCODE.Direction = ParameterDirection.Input
        INVTYCODE.Value = txtInvtyCode.Text.ToString.Trim
        Params(1) = INVTYCODE

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
        BusinessObject.Sub_Show(ServerPath2, "ISSPMTemplate_LookUpAll", CommandType.StoredProcedure, dstemp, "Table1")
        gCode = txtInvtyCode.Text : gDesc = txtInvtyDesc.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Samples and Promats Look-Up"
        myLoadedForm.RemoteDataTable = dstemp.Tables("Table1")
        myLoadedForm.ShowDialog(Me)
        txtInvtyCode.Text = gCode
        txtInvtyDesc.Text = gDesc
        txtQty.Focus()
    End Sub

    Private Sub ComputeAmount()
        If txtUnitPrice.Text <> "" And txtQty.Text <> "" Then
            txtAmount.Text = Convert.ToString(StringToDecimal(txtUnitPrice.Text) * StringToDecimal(txtQty.Text))
        Else
            txtAmount.Text = "0.00"
        End If
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        ComputeAmount()
    End Sub

    Private Sub txtUnitPrice_TextChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.TextChanged
        ComputeAmount()
    End Sub
End Class