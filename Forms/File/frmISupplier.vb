Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmISupplier
    Private RemoteDataSet As New DataSet
    Private EditMode As Boolean = False
    Private ModuleName As String = "SUPPLIER MASTER FILE"
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If UserCanAdd(gUserID, ModuleName) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            ControlMaintenance.ClearInputControlsGroup(Me)
            EditMode = False
            EnableCodeAndDesc(False)
            txtSuplName.Enabled = True
            modControlBehavior.SetBackgroundControlsGroup(Me)
            txtSuplName.Focus()
        End If
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If UserCanEdit(gUserID, ModuleName) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            If txtSuplCode.Text = "" And txtSuplName.Text = "" Then
                MessageBox.Show("Please select a record to modify!", "Record Selection", MessageBoxButtons.OK, _
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                modControlBehavior.EnableControlsGroup(Me, True)
                EditMode = True
                EnableCodeAndDesc(False)
                SetBackgroundControlsGroup(Me)
                txtSuplCode.Focus()
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
        MsgBox("Deletion of Supplier is not allowed!")
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
        If txtSuplName.Text.ToString <> "" And txtSuplCode.Text.ToString <> "" And _
           txtAddress1.Text.ToString <> "" And txtAttentionTo.Text.ToString <> "" And _
           txtPayTerm.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(7) As SqlParameter
            Dim SUPLCODE As New SqlParameter("@SUPLCODE", SqlDbType.VarChar, 5) : SUPLCODE.Direction = ParameterDirection.Input : SUPLCODE.Value = txtSuplCode.Text : Params(0) = SUPLCODE
            Dim SUPLNAME As New SqlParameter("@SUPLNAME", SqlDbType.VarChar, 50) : SUPLNAME.Direction = ParameterDirection.Input : SUPLNAME.Value = txtSuplName.Text : Params(1) = SUPLNAME
            Dim ADDRESS1 As New SqlParameter("@ADDRESS1", SqlDbType.VarChar, 50) : ADDRESS1.Direction = ParameterDirection.Input : ADDRESS1.Value = txtAddress1.Text : Params(2) = ADDRESS1
            Dim ADDRESS2 As New SqlParameter("@ADDRESS2", SqlDbType.VarChar, 50) : ADDRESS2.Direction = ParameterDirection.Input : ADDRESS2.Value = txtAddress2.Text : Params(3) = ADDRESS2
            Dim ATTENTIONTO As New SqlParameter("@ATTENTIONTO", SqlDbType.VarChar, 50) : ATTENTIONTO.Direction = ParameterDirection.Input : ATTENTIONTO.Value = txtAttentionTo.Text : Params(4) = ATTENTIONTO
            Dim CONTACTNO As New SqlParameter("@CONTACTNO", SqlDbType.VarChar, 12) : CONTACTNO.Direction = ParameterDirection.Input : CONTACTNO.Value = txtContactNo.Text : Params(5) = CONTACTNO
            Dim PAYMENTTERM As New SqlParameter("@PAYMENTTERM", SqlDbType.VarChar, 10) : PAYMENTTERM.Direction = ParameterDirection.Input : PAYMENTTERM.Value = txtPayTerm.Text : Params(6) = PAYMENTTERM
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(7) = UPDATEBY
            If ItemExists() Then
                MsgBox("Supplier Code : " & txtSuplCode.Text & ", Name : " & txtSuplName.Text & " already exists!")
            Else
                BusinessObject.Sub_Insert(ServerPath2, "ISupplier_Insert", CommandType.StoredProcedure, Params)
                LogHelper.InsertLog("ISupplier_Insert")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("ISupplier_Insert.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Update()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(8) As SqlParameter
            Dim ROWID As New SqlParameter("@ROWID", SqlDbType.Int, 10) : ROWID.Direction = ParameterDirection.Input : ROWID.Value = Convert.ToInt16(txtRowid.Text) : Params(0) = ROWID
            Dim SUPLCODE As New SqlParameter("@SUPLCODE", SqlDbType.VarChar, 5) : SUPLCODE.Direction = ParameterDirection.Input : SUPLCODE.Value = txtSuplCode.Text : Params(1) = SUPLCODE
            Dim SUPLNAME As New SqlParameter("@SUPLNAME", SqlDbType.VarChar, 50) : SUPLNAME.Direction = ParameterDirection.Input : SUPLNAME.Value = txtSuplName.Text : Params(2) = SUPLNAME
            Dim ADDRESS1 As New SqlParameter("@ADDRESS1", SqlDbType.VarChar, 50) : ADDRESS1.Direction = ParameterDirection.Input : ADDRESS1.Value = txtAddress1.Text : Params(3) = ADDRESS1
            Dim ADDRESS2 As New SqlParameter("@ADDRESS2", SqlDbType.VarChar, 50) : ADDRESS2.Direction = ParameterDirection.Input : ADDRESS2.Value = txtAddress2.Text : Params(4) = ADDRESS2
            Dim ATTENTIONTO As New SqlParameter("@ATTENTIONTO", SqlDbType.VarChar, 50) : ATTENTIONTO.Direction = ParameterDirection.Input : ATTENTIONTO.Value = txtAttentionTo.Text : Params(5) = ATTENTIONTO
            Dim CONTACTNO As New SqlParameter("@CONTACTNO", SqlDbType.VarChar, 12) : CONTACTNO.Direction = ParameterDirection.Input : CONTACTNO.Value = txtContactNo.Text : Params(6) = CONTACTNO
            Dim PAYMENTTERM As New SqlParameter("@PAYMENTTERM", SqlDbType.VarChar, 10) : PAYMENTTERM.Direction = ParameterDirection.Input : PAYMENTTERM.Value = txtPayTerm.Text : Params(7) = PAYMENTTERM
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(8) = UPDATEBY
            BusinessObject.Sub_Insert(ServerPath2, "ISupplier_Update", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("ISupplier_Update")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("ISupplier_Update.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Show()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            If Trim(txtSearch.Text = "") Then
                BusinessObject.Sub_Show(ServerPath2, "ISupplier_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            Else
                Dim Params(0) As SqlParameter
                Dim SUPLNAME As New SqlParameter("@SUPLNAME ", SqlDbType.VarChar, 50)
                SUPLNAME.Direction = ParameterDirection.Input
                SUPLNAME.Value = txtSearch.Text.ToString.Trim
                Params(0) = SUPLNAME
                BusinessObject.Sub_Show(ServerPath2, "ISupplier_Show_Search", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
            End If
            DataGrid1.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Number of Supplier : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
            LogHelper.InsertLog("ISupplier_Show_Search.Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("ISupplier_Show_Search.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Select(ByVal dbParams() As String, ByVal UpdateMode As String)
        'select case if add,edit or delete
        Dim i As Integer
        Dim myRowid As Integer
        Select Case UpdateMode
            Case "Insert"
                Dim BusinessObject As New BusinessLayer.clsFileMaintenance
                myRowid = CInt(BusinessObject.Sub_ReturnIntegerResult(ServerPath2, "ISupplier_GetInsertedRowid", CommandType.StoredProcedure))
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
    Private Sub frmISupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modControlBehavior.EnableControls(Me, False)
        modControlBehavior.EnableControlsGroup(Me, False)
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
        'LoadLookUp()
        Sub_Show()
        DataGrid1.AlternatingBackColor = Color.LightGreen
    End Sub
    Private Sub LoadLookUp()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            BusinessObject.Sub_Show(ServerPath2, "ISegment_LookUp", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            ResetTable()
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("ProductFormCT_Show.Error: " & ex.Message)
        End Try
    End Sub
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click, DataGrid1.CurrentCellChanged
        Try
            With DataGrid1
                txtRowid.Text = CStr(.Item(.CurrentCell.RowNumber, 0))
                txtSuplCode.Text = CStr(.Item(.CurrentCell.RowNumber, 1))
                txtSuplName.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                txtAddress1.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                txtAddress2.Text = CStr(.Item(.CurrentCell.RowNumber, 4))
                Try
                    txtAttentionTo.Text = CStr(.Item(.CurrentCell.RowNumber, 5))
                Catch ex As Exception

                End Try
                txtContactNo.Text = CStr(.Item(.CurrentCell.RowNumber, 6))
                txtPayTerm.Text = CStr(.Item(.CurrentCell.RowNumber, 7))

                lblCreateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 8))
                lblUpdateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 9))
                lblUpdateBy.Text = CStr(.Item(.CurrentCell.RowNumber, 10))
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
        If EditMode Then
            txtSuplCode.Enabled = False
            txtSuplName.Enabled = False
        Else

        End If
    End Sub
    Private Function ItemExists() As Boolean
        Dim retval As Boolean = False
        If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim Params(1) As SqlParameter

        Dim CODE As New SqlParameter("@CODE", SqlDbType.VarChar, 10)
        CODE.Direction = ParameterDirection.Input
        CODE.Value = txtSuplCode.Text.ToString.Trim
        Params(0) = CODE

        Dim NAME As New SqlParameter("@NAME", SqlDbType.VarChar, 50)
        Name.Direction = ParameterDirection.Input
        NAME.Value = txtSuplName.Text.ToString.Trim
        Params(1) = Name

        BusinessObject.Sub_Show(ServerPath2, "ISupplier_SearchCodeOrDesc", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
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
        If UserCanReport(gUserID, ModuleName) Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Supplier Master List Report"
            myLoadedForm.Status = "ALL"
            myLoadedForm.ShowDialog()
        End If
    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub
End Class