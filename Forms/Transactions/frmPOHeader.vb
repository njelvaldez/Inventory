Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmPOHeader
    Private RemoteDataSet As New DataSet
    Private EditMode As Boolean = False
    Private DefaultNotedBy As String = System.Configuration.ConfigurationSettings.AppSettings.Item("DefaultNotedBy")
    Private DefaultApproveBy1 As String = System.Configuration.ConfigurationSettings.AppSettings.Item("DefaultApproveBy1")
    Private DefaultApproveBy2 As String = System.Configuration.ConfigurationSettings.AppSettings.Item("DefaultApproveBy2")
    Private MODULENAME As String = "PURCHASE ORDER"
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If UserCanAdd(gUserID, MODULENAME) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            ControlMaintenance.ClearInputControlsGroup(Me)
            EditMode = False
            EnableCodeAndDesc(False)
            txtSuplCode.Enabled = True
            modControlBehavior.SetBackgroundControlsGroup(Me)
            'set default noted and approved
            txtNotedBy.Text = DefaultNotedBy
            txtApprovedby1.Text = DefaultApproveBy1
            txtapprovedby2.Text = DefaultApproveBy2
            txtNMPCContact.Text = gUserName
            txtPONo.Focus()
        End If
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If UserCanEdit(gUserID, MODULENAME) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            If txtPONo.Text = "" And txtSuplCode.Text = "" Then
                MessageBox.Show("Please select a record to modify!", "Record Selection", MessageBoxButtons.OK, _
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                modControlBehavior.EnableControlsGroup(Me, True)
                EditMode = True
                EnableCodeAndDesc(False)
                SetBackgroundControlsGroup(Me)
                txtPORFNo.Focus()
            End If
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
        If txtPONo.Text.ToString <> "" And txtSuplCode.Text.ToString <> "" And _
           txtPaymentTerm.Text.ToString <> "" And txtPORFNo.Text.ToString <> "" And _
           txtDeliveryDate.Text.ToString <> "" And txtNotedBy.Text.ToString <> "" And _
           txtApprovedby1.Text.ToString <> "" And txtapprovedby2.Text.ToString <> "" And _
           txtNMPCContact.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(9) As SqlParameter
            Dim PONO As New SqlParameter("@PONO", SqlDbType.VarChar, 10) : PONO.Direction = ParameterDirection.Input : PONO.Value = txtPONo.Text : Params(0) = PONO
            Dim SUPLCODE As New SqlParameter("@SUPLCODE", SqlDbType.VarChar, 5) : SUPLCODE.Direction = ParameterDirection.Input : SUPLCODE.Value = txtSuplCode.Text : Params(1) = SUPLCODE
            Dim PAYMENTTERM As New SqlParameter("@PAYMENTTERM", SqlDbType.VarChar, 10) : PAYMENTTERM.Direction = ParameterDirection.Input : PAYMENTTERM.Value = txtPaymentTerm.Text : Params(2) = PAYMENTTERM
            Dim PORFNO As New SqlParameter("@PORFNO", SqlDbType.VarChar, 10) : PORFNO.Direction = ParameterDirection.Input : PORFNO.Value = txtPORFNo.Text : Params(3) = PORFNO
            Dim DELIVERYDATE As New SqlParameter("@DELIVERYDATE", SqlDbType.VarChar, 10) : DELIVERYDATE.Direction = ParameterDirection.Input : DELIVERYDATE.Value = txtDeliveryDate.Text : Params(4) = DELIVERYDATE
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(5) = UPDATEBY
            Dim NOTEDBY As New SqlParameter("@NOTEDBY", SqlDbType.VarChar, 25) : NOTEDBY.Direction = ParameterDirection.Input : NOTEDBY.Value = txtNotedBy.Text : Params(6) = NOTEDBY
            Dim APPROVEDBY1 As New SqlParameter("@APPROVEDBY1", SqlDbType.VarChar, 25) : APPROVEDBY1.Direction = ParameterDirection.Input : APPROVEDBY1.Value = txtApprovedby1.Text : Params(7) = APPROVEDBY1
            Dim APPROVEDBY2 As New SqlParameter("@APPROVEDBY2", SqlDbType.VarChar, 25) : APPROVEDBY2.Direction = ParameterDirection.Input : APPROVEDBY2.Value = txtapprovedby2.Text : Params(8) = APPROVEDBY2
            Dim NMPCCONTACT As New SqlParameter("@NMPCCONTACT", SqlDbType.VarChar, 25) : NMPCCONTACT.Direction = ParameterDirection.Input : NMPCCONTACT.Value = txtNMPCContact.Text : Params(9) = NMPCCONTACT
            If ItemExists() Then
                MsgBox("PO Number : " & txtPONo.Text & txtPONo.Text & " already exists!")
            Else
                BusinessObject.Sub_Insert(ServerPath2, "IPOHeader_Insert", CommandType.StoredProcedure, Params)
                LogHelper.InsertLog("IPOHeader_Insert")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IPOHeader_Insert.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Update()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(10) As SqlParameter
            Dim ROWID As New SqlParameter("@ROWID", SqlDbType.Int, 10) : ROWID.Direction = ParameterDirection.Input : ROWID.Value = Convert.ToInt16(txtRowid.Text) : Params(0) = ROWID
            Dim PONO As New SqlParameter("@PONO", SqlDbType.VarChar, 10) : PONO.Direction = ParameterDirection.Input : PONO.Value = txtPONo.Text : Params(1) = PONO
            Dim SUPLCODE As New SqlParameter("@SUPLCODE", SqlDbType.VarChar, 5) : SUPLCODE.Direction = ParameterDirection.Input : SUPLCODE.Value = txtSuplCode.Text : Params(2) = SUPLCODE
            Dim PAYMENTTERM As New SqlParameter("@PAYMENTTERM", SqlDbType.VarChar, 10) : PAYMENTTERM.Direction = ParameterDirection.Input : PAYMENTTERM.Value = txtPaymentTerm.Text : Params(3) = PAYMENTTERM
            Dim PORFNO As New SqlParameter("@PORFNO", SqlDbType.VarChar, 10) : PORFNO.Direction = ParameterDirection.Input : PORFNO.Value = txtPORFNo.Text : Params(4) = PORFNO
            Dim DELIVERYDATE As New SqlParameter("@DELIVERYDATE", SqlDbType.VarChar, 10) : DELIVERYDATE.Direction = ParameterDirection.Input : DELIVERYDATE.Value = txtDeliveryDate.Text : Params(5) = DELIVERYDATE
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
            Dim NOTEDBY As New SqlParameter("@NOTEDBY", SqlDbType.VarChar, 25) : NOTEDBY.Direction = ParameterDirection.Input : NOTEDBY.Value = txtNotedBy.Text : Params(7) = NOTEDBY
            Dim APPROVEDBY1 As New SqlParameter("@APPROVEDBY1", SqlDbType.VarChar, 25) : APPROVEDBY1.Direction = ParameterDirection.Input : APPROVEDBY1.Value = txtApprovedby1.Text : Params(8) = APPROVEDBY1
            Dim APPROVEDBY2 As New SqlParameter("@APPROVEDBY2", SqlDbType.VarChar, 25) : APPROVEDBY2.Direction = ParameterDirection.Input : APPROVEDBY2.Value = txtapprovedby2.Text : Params(9) = APPROVEDBY2
            Dim NMPCCONTACT As New SqlParameter("@NMPCCONTACT", SqlDbType.VarChar, 25) : NMPCCONTACT.Direction = ParameterDirection.Input : NMPCCONTACT.Value = txtNMPCContact.Text : Params(10) = NMPCCONTACT

            BusinessObject.Sub_Insert(ServerPath2, "IPOHeader_Update", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("IPOHeader_Update")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IPOHeader_Update.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Show()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            If Trim(txtSearch.Text = "") Then
                BusinessObject.Sub_Show(ServerPath2, "IPOHeader_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            Else
                Dim Params(0) As SqlParameter
                Dim SUPLNAME As New SqlParameter("@SUPLNAME ", SqlDbType.VarChar, 50)
                SUPLNAME.Direction = ParameterDirection.Input
                SUPLNAME.Value = txtSearch.Text.ToString.Trim
                Params(0) = SUPLNAME
                BusinessObject.Sub_Show(ServerPath2, "IPOHeader_Show_Search", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
            End If
            DataGrid1.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Number of POs : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
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
                myRowid = CInt(BusinessObject.Sub_ReturnIntegerResult(ServerPath2, "IPOHeader_GetInsertedRowid", CommandType.StoredProcedure))
            Case "Update"
                myRowid = CInt(dbParams(0))
        End Select
        For i = 0 To (RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count - 1)
            With DataGrid1
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
        DataGrid1.AlternatingBackColor = Color.LightGreen
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
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click, DataGrid1.CurrentCellChanged
        Try
            With DataGrid1
                txtRowid.Text = CStr(.Item(.CurrentCell.RowNumber, 0))
                txtPONo.Text = CStr(.Item(.CurrentCell.RowNumber, 1))
                txtSuplCode.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                txtSupplier.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                txtPaymentTerm.Text = CStr(.Item(.CurrentCell.RowNumber, 4))
                txtPORFNo.Text = CStr(.Item(.CurrentCell.RowNumber, 5))
                Try
                    txtDeliveryDate.Text = CStr(.Item(.CurrentCell.RowNumber, 6))
                Catch ex As Exception

                End Try

                lblCreateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 7))
                lblUpdateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 8))
                lblUpdateBy.Text = CStr(.Item(.CurrentCell.RowNumber, 9))
                txtNotedBy.Text = CStr(.Item(.CurrentCell.RowNumber, 10))
                txtApprovedby1.Text = CStr(.Item(.CurrentCell.RowNumber, 11))
                txtapprovedby2.Text = CStr(.Item(.CurrentCell.RowNumber, 12))
                txtNMPCContact.Text = CStr(.Item(.CurrentCell.RowNumber, 13))
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
        txtSuplCode.Enabled = False
        txtSupplier.Enabled = False
        txtPaymentTerm.Enabled = False
        If EditMode Then
            btnSupplier.Enabled = False
            txtPONo.Enabled = False
        Else
            txtPONo.Enabled = True
            btnSupplier.Enabled = True
        End If
    End Sub
    Private Function ItemExists() As Boolean
        Dim retval As Boolean = False
        If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim Params(0) As SqlParameter

        Dim CODE As New SqlParameter("@CODE", SqlDbType.VarChar, 10)
        CODE.Direction = ParameterDirection.Input
        CODE.Value = txtPONo.Text.ToString.Trim
        Params(0) = CODE

        'Dim NAME As New SqlParameter("@NAME", SqlDbType.VarChar, 50)
        'NAME.Direction = ParameterDirection.Input
        'NAME.Value = txtSuplCode.Text.ToString.Trim
        'Params(1) = NAME

        BusinessObject.Sub_Show(ServerPath2, "IPOHeader_SearchCodeOrDesc", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
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
        If txtPONo.Text = "" And txtSuplCode.Text = "" Then
            MessageBox.Show("Please select a PO to modify!", "Record Selection", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim myLoadedForm As New frmPODetail
            myLoadedForm.txtPONo.Text = txtPONo.Text
            myLoadedForm.ShowDialog()
        End If

    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    Private Sub btnSupplier_Click(sender As Object, e As EventArgs) Handles btnSupplier.Click
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim dstemp As New DataSet
        dstemp.Tables.Add("Table1")
        BusinessObject.Sub_Show(ServerPath2, "ISupplier_LookUp", CommandType.StoredProcedure, dstemp, "Table1")
        gCode = txtSuplCode.Text : gDesc = txtSupplier.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Supplier Look-Up"
        myLoadedForm.RemoteDataTable = dstemp.Tables("Table1")
        myLoadedForm.ShowDialog(Me)
        txtSuplCode.Text = gCode
        txtSupplier.Text = gDesc
        txtPORFNo.Focus()
    End Sub

    Private Sub txtSuplCode_TextChanged(sender As Object, e As EventArgs) Handles txtSuplCode.TextChanged
        If txtSuplCode.Text <> "" Then
            txtPaymentTerm.Text = GetSupplierPaymentTerm(txtSuplCode.Text)
        End If
    End Sub
End Class