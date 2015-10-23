Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmTransfer
    Private RemoteDataSet As New DataSet
    Private EditMode As Boolean = False
    Private MODULENAME As String = "TRANSFER INVENTORY"
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If UserCanAdd(gUserID, MODULENAME) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            ControlMaintenance.ClearInputControlsGroup(Me)
            EditMode = False
            EnableCodeAndDesc(False)
            modControlBehavior.SetBackgroundControlsGroup(Me)
            'set default noted and approved
            txtTrnDate.Text = DateTime.Now.ToShortDateString
            txtTrnNo.Focus()
        End If
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If UserCanEdit(gUserID, MODULENAME) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            If txtTrnNo.Text = "" Then
                MessageBox.Show("Please select a record to modify!", "Record Selection", MessageBoxButtons.OK, _
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                modControlBehavior.EnableControlsGroup(Me, True)
                EditMode = True
                EnableCodeAndDesc(False)
                SetBackgroundControlsGroup(Me)
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
        MsgBox("Deletion of Inventory is not allowed!")
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
        If txtTrnNo.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(2) As SqlParameter
            Dim TRNNO As New SqlParameter("@TRNNO", SqlDbType.VarChar, 10) : TRNNO.Direction = ParameterDirection.Input : TRNNO.Value = txtTrnNo.Text : Params(0) = TRNNO
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(1) = UPDATEBY
            Dim TRNDATE As New SqlParameter("@TRNDATE", SqlDbType.DateTime, 10) : TRNDATE.Direction = ParameterDirection.Input : TRNDATE.Value = Convert.ToDateTime(txtTrnDate.Text) : Params(2) = TRNDATE
            BusinessObject.Sub_Insert(ServerPath2, "HTransfer_Insert", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("IPOHeader_Insert")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("HTransfer_Insert.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Update()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(3) As SqlParameter
            Dim HTID As New SqlParameter("@HTID", SqlDbType.Int, 10) : HTID.Direction = ParameterDirection.Input : HTID.Value = Convert.ToInt16(txtRowid.Text) : Params(0) = HTID
            Dim TRNNO As New SqlParameter("@TRNNO", SqlDbType.VarChar, 10) : TRNNO.Direction = ParameterDirection.Input : TRNNO.Value = txtTrnNo.Text : Params(1) = TRNNO
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(2) = UPDATEBY
            Dim TRNDATE As New SqlParameter("@TRNDATE", SqlDbType.DateTime, 10) : TRNDATE.Direction = ParameterDirection.Input : TRNDATE.Value = Convert.ToDateTime(txtTrnDate.Text) : Params(3) = TRNDATE

            BusinessObject.Sub_Insert(ServerPath2, "HTransfer_Update", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("HTransfer_Update")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("HTransfer_Update.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Show()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            If Trim(txtSearch.Text = "") Then
                BusinessObject.Sub_Show(ServerPath2, "HTransfer_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            Else
                Dim Params(0) As SqlParameter
                Dim TRNNO As New SqlParameter("@TRNNO ", SqlDbType.VarChar, 10)
                TRNNO.Direction = ParameterDirection.Input
                TRNNO.Value = txtSearch.Text.ToString.Trim
                Params(0) = TRNNO
                BusinessObject.Sub_Show(ServerPath2, "HTransfer_Show_Search", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
            End If
            DataGrid1.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Number of Transferd : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
            LogHelper.InsertLog("HTransfer_Show.Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("HTransfer_Show.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Select(ByVal dbParams() As String, ByVal UpdateMode As String)
        Try
            'select case if add,edit or delete
            Dim i As Integer
            Dim myRowid As Integer
            Select Case UpdateMode
                Case "Insert"
                    Dim BusinessObject As New BusinessLayer.clsFileMaintenance
                    myRowid = CInt(BusinessObject.Sub_ReturnIntegerResult(ServerPath2, "HTransfer_GetInsertedRowid", CommandType.StoredProcedure))
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
        Catch ex As Exception
            MsgBox("Error in Transferment Header : " & ex.Message)
        End Try
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
    Private Sub frmHTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                txtTrnNo.Text = CStr(.Item(.CurrentCell.RowNumber, 1))
                lblCreateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                lblUpdateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                lblUpdateBy.Text = CStr(.Item(.CurrentCell.RowNumber, 4))
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
            txtTrnNo.Enabled = False
        Else
            txtTrnNo.Enabled = True
        End If
    End Sub

    Private Sub ResetTable()
        If RemoteDataSet.Tables.Count > 0 Then
            RemoteDataSet.Tables.Remove("ProductFormCT_Show")
        End If
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtTrnNo.Text = "" Then
            MessageBox.Show("Please select Adjusment to modify!", "Record Selection", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim myLoadedForm As New frmDTransfer
            myLoadedForm.txtTRNNO.Text = txtTrnNo.Text
            myLoadedForm.txtHTID.Text = txtRowid.Text
            myLoadedForm.ShowDialog()
        End If

    End Sub
End Class