Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmItem
    Private RemoteDataSet As New DataSet
    Private EditMode As Boolean = False
    Private ModuleName As String = "ITEM MASTER FILE"
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If UserCanAdd(gUserID, ModuleName) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            ControlMaintenance.ClearInputControlsGroup(Me)
            EditMode = False
            EnableCodeAndDesc(False)
            txtItemCode.Enabled = True
            modControlBehavior.SetBackgroundControlsGroup(Me)
            txtItemCode.Focus()
        End If
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If UserCanEdit(gUserID, ModuleName) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            If txtItemCode.Text = "" And txtItemDesc.Text = "" Then
                MessageBox.Show("Please select a record to modify!", "Record Selection", MessageBoxButtons.OK, _
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                modControlBehavior.EnableControlsGroup(Me, True)
                EditMode = True
                EnableCodeAndDesc(False)
                SetBackgroundControlsGroup(Me)
                txtItemCode.Focus()
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
        MsgBox("Deletion of Item is not allowed!")
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
        If txtItemCode.Text.ToString <> "" And txtItemDesc.Text.ToString <> "" And _
           txtMOQ.Text.ToString <> "" And txtShelflife.Text.ToString <> "" And _
           txtLeadtime.Text.ToString <> "" And TxtSafLvl.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(7) As SqlParameter
            Dim ItemCode As New SqlParameter("@ItemCode", SqlDbType.VarChar, 10) : ItemCode.Direction = ParameterDirection.Input : ItemCode.Value = txtItemCode.Text : Params(0) = ItemCode
            Dim ItemDesc As New SqlParameter("@ItemDesc", SqlDbType.VarChar, 50) : ItemDesc.Direction = ParameterDirection.Input : ItemDesc.Value = txtItemDesc.Text : Params(1) = ItemDesc
            Dim MdiCode As New SqlParameter("@MdiCode", SqlDbType.VarChar, 10) : MdiCode.Direction = ParameterDirection.Input : MdiCode.Value = txtMDICode.Text : Params(2) = MdiCode
            Dim Leadtime As New SqlParameter("@Leadtime", SqlDbType.Money, 12) : Leadtime.Direction = ParameterDirection.Input : Leadtime.Value = Convert.ToDecimal(txtLeadtime.Text) : Params(3) = Leadtime
            Dim Saflvl As New SqlParameter("@Saflvl", SqlDbType.Money, 12) : Saflvl.Direction = ParameterDirection.Input : Saflvl.Value = Convert.ToDecimal(TxtSafLvl.Text) : Params(4) = Saflvl
            Dim MOQ As New SqlParameter("@MOQ", SqlDbType.Money, 12) : MOQ.Direction = ParameterDirection.Input : MOQ.Value = Convert.ToDecimal(txtMOQ.Text) : Params(5) = MOQ
            Dim Shelflife As New SqlParameter("@Shelflife", SqlDbType.Money, 12) : Shelflife.Direction = ParameterDirection.Input : Shelflife.Value = Convert.ToDecimal(txtShelflife.Text) : Params(6) = Shelflife
            Dim UpdateBy As New SqlParameter("@UpdateBy", SqlDbType.VarChar, 10) : UpdateBy.Direction = ParameterDirection.Input : UpdateBy.Value = gUserName : Params(7) = UpdateBy
            If ItemExists() Then
                MsgBox("User Id : " & txtItemCode.Text & ", User Name : " & txtItemDesc.Text & " already exists!")
            Else
                BusinessObject.Sub_Insert(ServerPath2, "Item_Insert", CommandType.StoredProcedure, Params)
                LogHelper.InsertLog("Item_Insert")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("Item_Insert.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Update()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(8) As SqlParameter
            Dim ItemCode As New SqlParameter("@ItemCode", SqlDbType.VarChar, 10) : ItemCode.Direction = ParameterDirection.Input : ItemCode.Value = txtItemCode.Text : Params(0) = ItemCode
            Dim ItemDesc As New SqlParameter("@ItemDesc", SqlDbType.VarChar, 50) : ItemDesc.Direction = ParameterDirection.Input : ItemDesc.Value = txtItemDesc.Text : Params(1) = ItemDesc
            Dim MdiCode As New SqlParameter("@MdiCode", SqlDbType.VarChar, 10) : MdiCode.Direction = ParameterDirection.Input : MdiCode.Value = txtMDICode.Text : Params(2) = MdiCode
            Dim Leadtime As New SqlParameter("@Leadtime", SqlDbType.Money, 12) : Leadtime.Direction = ParameterDirection.Input : Leadtime.Value = Convert.ToDecimal(txtLeadtime.Text) : Params(3) = Leadtime
            Dim Saflvl As New SqlParameter("@Saflvl", SqlDbType.Money, 12) : Saflvl.Direction = ParameterDirection.Input : Saflvl.Value = Convert.ToDecimal(TxtSafLvl.Text) : Params(4) = Saflvl
            Dim MOQ As New SqlParameter("@MOQ", SqlDbType.Money, 12) : MOQ.Direction = ParameterDirection.Input : MOQ.Value = Convert.ToDecimal(txtMOQ.Text) : Params(5) = MOQ
            Dim Shelflife As New SqlParameter("@Shelflife", SqlDbType.Money, 12) : Shelflife.Direction = ParameterDirection.Input : Shelflife.Value = Convert.ToDecimal(txtShelflife.Text) : Params(6) = Shelflife
            Dim UpdateBy As New SqlParameter("@UpdateBy", SqlDbType.VarChar, 10) : UpdateBy.Direction = ParameterDirection.Input : UpdateBy.Value = gUserName : Params(7) = UpdateBy
            Dim ROWID As New SqlParameter("@Itmid", SqlDbType.Int, 10) : ROWID.Direction = ParameterDirection.Input : ROWID.Value = Convert.ToInt16(txtRowid.Text) : Params(8) = ROWID
            BusinessObject.Sub_Insert(ServerPath2, "Item_Update", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("Item_Update")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("Item_Update.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Show()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            If Trim(txtSearch.Text = "") Then
                BusinessObject.Sub_Show(ServerPath2, "Item_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            Else
                Dim Params(0) As SqlParameter
                Dim ItemDesc As New SqlParameter("@ItemDesc ", SqlDbType.VarChar, 50)
                ItemDesc.Direction = ParameterDirection.Input
                ItemDesc.Value = txtSearch.Text.ToString.Trim
                Params(0) = ItemDesc
                BusinessObject.Sub_Show(ServerPath2, "Item_Search_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
            End If
            DataGrid1.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Number of Items : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
            LogHelper.InsertLog("Item_Search_Show.Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("Item_Search_Show.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Select(ByVal dbParams() As String, ByVal UpdateMode As String)
        'select case if add,edit or delete
        Dim i As Integer
        Dim myRowid As Integer
        Select Case UpdateMode
            Case "Insert"
                Dim BusinessObject As New BusinessLayer.clsFileMaintenance
                myRowid = CInt(BusinessObject.Sub_ReturnIntegerResult(ServerPath2, "Item_GetInsertedRowid", CommandType.StoredProcedure))
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
    Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modControlBehavior.EnableControls(Me, False)
        modControlBehavior.EnableControlsGroup(Me, False)
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
        Sub_Show()
        DataGrid1.AlternatingBackColor = Color.LightGreen
    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click, DataGrid1.CurrentCellChanged
        Try
            With DataGrid1
                'select itmid,itemcode,ItemDesc,MdiCode,Leadtime,SafLvl,MOQ,Shelflife,CreateDate,UpdateDate,UpdateBy from item 
                txtRowid.Text = CStr(.Item(.CurrentCell.RowNumber, 0))
                txtItemCode.Text = CStr(.Item(.CurrentCell.RowNumber, 1))
                txtItemDesc.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                txtMDICode.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                txtLeadtime.Text = CStr(.Item(.CurrentCell.RowNumber, 4))
                TxtSafLvl.Text = CStr(.Item(.CurrentCell.RowNumber, 5))
                txtMOQ.Text = CStr(.Item(.CurrentCell.RowNumber, 6))
                txtShelflife.Text = CStr(.Item(.CurrentCell.RowNumber, 7))
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
        'txtLeadtime.Enabled = False
        If EditMode Then
            txtItemCode.Enabled = False
            txtItemDesc.Enabled = False
        Else

        End If
    End Sub
    Private Function ItemExists() As Boolean
        Dim retval As Boolean = False
        If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim Params(1) As SqlParameter

        Dim CODE As New SqlParameter("@ItemCode", SqlDbType.VarChar, 10)
        CODE.Direction = ParameterDirection.Input
        CODE.Value = txtItemCode.Text.ToString.Trim
        Params(0) = CODE

        Dim NAME As New SqlParameter("@ItemDesc", SqlDbType.VarChar, 50)
        NAME.Direction = ParameterDirection.Input
        NAME.Value = txtItemDesc.Text.ToString.Trim
        Params(1) = NAME

        BusinessObject.Sub_Show(ServerPath2, "Item_SearchCodeOrDesc", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
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
            myLoadedForm.Report = "User Master List Report"
            myLoadedForm.Status = "ALL"
            myLoadedForm.ShowDialog()
        End If
    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub


End Class