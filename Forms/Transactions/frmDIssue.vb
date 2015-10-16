Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmDIssue
    Private RemoteDataSet As New DataSet
    Private EditMode As Boolean = False
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        modControlBehavior.EnableControlsGroup(Me, True)
        ControlMaintenance.ClearInputControlsGroup(Me)
        EditMode = False
        EnableCodeAndDesc(False)
        txtItemCode.Enabled = True
        modControlBehavior.SetBackgroundControlsGroup(Me)
        btnLocationLookup_Click(sender, e)
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        'modControlBehavior.EnableControlsGroup(Me, True)
        'If txtRecNo.Text = "" And txtItemDesc.Text = "" Then
        '    MessageBox.Show("Please select a record to modify!", "Record Selection", MessageBoxButtons.OK, _
        '    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        'Else
        '    modControlBehavior.EnableControlsGroup(Me, True)
        '    EditMode = True
        '    EnableCodeAndDesc(False)
        '    SetBackgroundControlsGroup(Me)
        '    txtQty.Focus()
        'End If
        MsgBox("Update of Issued Inventory is not allowed!")
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
        MsgBox("Deletion of Issued Inventory is not allowed!")
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
                'Update Stkcard IMS Issued Inventory
                StkcardIMSIssue(txtLocCode.Text, txtItemCode.Text, txtLotNo.Text, dtexpdate.Value, txtQty.Text)
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
        dtexpdate.Enabled = False
        modControlBehavior.EnableControlsGroup(Me, False)
    End Sub
    Private Function AllValidFields() As Boolean
        Dim retval As Boolean = False
        If txtIssNo.Text.ToString <> "" And txtLocCode.Text.ToString <> "" And _
           txtLotNo.Text.ToString <> "" And dtexpdate.Value.ToString <> "" And _
           txtQty.Text.ToString <> "" And txtItemCode.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(6) As SqlParameter
            Dim HIID As New SqlParameter("@HIID", SqlDbType.Int, 10) : HIID.Direction = ParameterDirection.Input : HIID.Value = Convert.ToInt16(txtHIID.Text) : Params(0) = HIID
            Dim LOCCODE As New SqlParameter("@LOCCODE", SqlDbType.VarChar, 5) : LOCCODE.Direction = ParameterDirection.Input : LOCCODE.Value = txtLocCode.Text : Params(1) = LOCCODE
            Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10) : ITEMCODE.Direction = ParameterDirection.Input : ITEMCODE.Value = txtItemCode.Text : Params(2) = ITEMCODE
            Dim LOTNO As New SqlParameter("@LOTNO", SqlDbType.VarChar, 10) : LOTNO.Direction = ParameterDirection.Input : LOTNO.Value = txtLotNo.Text : Params(3) = LOTNO
            Dim EXPDATE As New SqlParameter("@EXPDATE", SqlDbType.DateTime, 10) : EXPDATE.Direction = ParameterDirection.Input : EXPDATE.Value = dtexpdate.Value.ToShortDateString : Params(4) = EXPDATE
            Dim QTY As New SqlParameter("@QTY", SqlDbType.Decimal, 10) : QTY.Direction = ParameterDirection.Input : QTY.Value = txtQty.Text : Params(5) = QTY
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
            BusinessObject.Sub_Insert(ServerPath2, "DIssue_Insert", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("DIssue_Insert")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("DIssue_Insert.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Update()
        'Try
        '    Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        '    Dim Params(7) As SqlParameter
        '    Dim HIID As New SqlParameter("@HIID", SqlDbType.Int, 10) : HIID.Direction = ParameterDirection.Input : HIID.Value = txtHIID.Text : Params(0) = HIID
        '    Dim LOCCODE As New SqlParameter("@LOCCODE", SqlDbType.VarChar, 5) : LOCCODE.Direction = ParameterDirection.Input : LOCCODE.Value = txtLocCode.Text : Params(1) = LOCCODE
        '    Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10) : ITEMCODE.Direction = ParameterDirection.Input : ITEMCODE.Value = txtItemCode.Text : Params(2) = ITEMCODE
        '    Dim LOTNO As New SqlParameter("@LOTNO", SqlDbType.VarChar, 10) : LOTNO.Direction = ParameterDirection.Input : LOTNO.Value = txtLotNo.Text : Params(3) = LOTNO
        '    Dim EXPDATE As New SqlParameter("@EXPDATE", SqlDbType.DateTime, 10) : EXPDATE.Direction = ParameterDirection.Input : EXPDATE.Value = txtExpDate.Text : Params(4) = EXPDATE
        '    Dim QTY As New SqlParameter("@QTY", SqlDbType.Decimal, 10) : QTY.Direction = ParameterDirection.Input : QTY.Value = txtQty.Text : Params(5) = QTY
        '    Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
        '    Dim DAID As New SqlParameter("@DAID", SqlDbType.Int, 10) : DAID.Direction = ParameterDirection.Input : DAID.Value = txtRowid.Text : Params(7) = DAID
        '    BusinessObject.Sub_Insert(ServerPath2, "DIssue_Update", CommandType.StoredProcedure, Params)
        '    LogHelper.InsertLog("DIssue_Update")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    LogHelper.InsertLog("DIssue_Update.Error: " & ex.Message)
        'End Try
        MsgBox("Update of Issued Inventory is not allowed.")
    End Sub
    Private Sub Sub_Show()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim HIID As New SqlParameter("@HIID ", SqlDbType.Int, 10)
            HIID.Direction = ParameterDirection.Input
            HIID.Value = txtHIID.Text.ToString.Trim
            Params(0) = HIID
            BusinessObject.Sub_Show(ServerPath2, "DIssue_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
            dgPODetail.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Number of Items : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
            LogHelper.InsertLog("DIssue_Show.Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("DIssue_Show.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Select(ByVal dbParams() As String, ByVal UpdateMode As String)
        'select case if add,edit or delete
        Dim i As Integer
        Dim myRowid As Integer
        Select Case UpdateMode
            Case "Insert"
                Dim BusinessObject As New BusinessLayer.clsFileMaintenance
                myRowid = CInt(BusinessObject.Sub_ReturnIntegerResult(ServerPath2, "DIssue_GetInsertedRowid", CommandType.StoredProcedure))
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
    Private Sub frmDIssue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modControlBehavior.EnableControls(Me, False)
        modControlBehavior.EnableControlsGroup(Me, False)
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
        'LoadLookUp()
        Sub_Show()
        dgPODetail.AlternatingBackColor = Color.LightGreen
    End Sub
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPODetail.Click, dgPODetail.CurrentCellChanged
        Try
            With dgPODetail
                txtRowid.Text = CStr(.Item(.CurrentCell.RowNumber, 0))
                txtLocCode.Text = CStr(.Item(.CurrentCell.RowNumber, 1))
                txtItemCode.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                txtItemDesc.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                txtLotNo.Text = CStr(.Item(.CurrentCell.RowNumber, 4))
                dtexpdate.Text = CStr(.Item(.CurrentCell.RowNumber, 5))
                txtQty.Text = CStr(.Item(.CurrentCell.RowNumber, 6))
                lblCreateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 7))
                lblUpdateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 8))
                lblUpdateBy.Text = CStr(.Item(.CurrentCell.RowNumber, 9))
                txtLocDesc.Text = CStr(.Item(.CurrentCell.RowNumber, 10))
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
        txtItemCode.Enabled = False
        txtItemDesc.Enabled = False
        txtIssNo.Enabled = False
        txtQty.Enabled = True
        If EditMode Then
            btnItem.Enabled = False
        Else
            btnItem.Enabled = True
        End If
    End Sub
    Private Sub ResetTable()
        If RemoteDataSet.Tables.Count > 0 Then
            RemoteDataSet.Tables.Remove("ProductFormCT_Show")
        End If
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myLoadedForm As New frmReportViewer
        myLoadedForm.Report = "Issued Inventory Report"
        myLoadedForm.Status = "ALL"
        myLoadedForm.PONO = txtIssNo.Text
        myLoadedForm.ShowDialog()
    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs) Handles dgPODetail.Navigate

    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim dstemp As New DataSet
        dstemp.Tables.Add("Table1")
        BusinessObject.Sub_Show(ServerPath2, "Item_LookUp", CommandType.StoredProcedure, dstemp, "Table1")
        gCode = txtItemCode.Text : gDesc = txtItemDesc.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Item Look-Up"
        myLoadedForm.RemoteDataTable = dstemp.Tables("Table1")
        myLoadedForm.ShowDialog(Me)
        txtItemCode.Text = gCode
        txtItemDesc.Text = gDesc
        txtQty.Focus()
    End Sub

    Private Sub btnLocationLookup_Click(sender As Object, e As EventArgs) Handles btnLocationLookup.Click
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim dstemp As New DataSet
        dstemp.Tables.Add("Table1")
        BusinessObject.Sub_Show(ServerPath2, "Location_LookUp", CommandType.StoredProcedure, dstemp, "Table1")
        gCode = txtLocCode.Text : gDesc = txtLocDesc.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Location Look-Up"
        myLoadedForm.RemoteDataTable = dstemp.Tables("Table1")
        myLoadedForm.ShowDialog(Me)
        txtLocCode.Text = gCode
        txtLocDesc.Text = gDesc
        If txtLocCode.Text.ToString <> "" Then
            btnItem_Click(sender, e)
        End If
    End Sub

    Private Sub txtLotNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLotNo.Validating
        Dim lotexpdate As DateTime

        If txtLotNo.Text.ToString <> "" Then
            lotexpdate = IMSLotNoExpdate(txtItemCode.Text, txtLotNo.Text)
            If lotexpdate = DefaultDate() Then
                'Display Lotnot is not found, Prompt are you sure Lotno is correct?
                If (MessageBox.Show("LotNo not found,Are you sure you want to add this LotNo?", "Confirm Add of LotNo", _
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) = DialogResult.Yes Then
                    'If Yes,Enable entry for Expiration Date
                    dtexpdate.Enabled = True
                    dtexpdate.Focus()
                    SendKeys.Send("{F4}")
                Else
                    txtLotNo.Focus()
                End If

            Else
                'Lotno already exists, populate Expirationdate
                dtexpdate.Value = lotexpdate
                dtexpdate.Enabled = False
            End If
        End If
    End Sub

    Private Sub dtexpdate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtexpdate.Validating
        If dtexpdate.Value <= DateTime.Now Then
            'Display a warning message, Prompt are you sure Expiration Date is correct?
            If (MessageBox.Show("Warning on expiration date,are you sure expiration date is correct?", "Confirm Expiration Date", _
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) = DialogResult.Yes Then
                'If Yes,Enable entry for Expiration Date
            Else
                dtexpdate.Focus()
                SendKeys.Send("{F4}")
            End If
        End If
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class