Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmRoleModules
    Private RemoteDataSet As New DataSet
    Private EditMode As Boolean = False
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        modControlBehavior.EnableControlsGroup(Me, True)
        ControlMaintenance.ClearInputControlsGroup(Me)
        EditMode = False
        EnableCodeAndDesc(False)
        modControlBehavior.SetBackgroundControlsGroup(Me)
        btnRoleLookUp.Focus()
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        modControlBehavior.EnableControlsGroup(Me, True)
        If txtRoleID.Text = "" And txtModuleID.Text = "" Then
            MessageBox.Show("Please select a record to modify!", "Record Selection", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            modControlBehavior.EnableControlsGroup(Me, True)
            EditMode = True
            EnableCodeAndDesc(False)
            SetBackgroundControlsGroup(Me)
            btnRoleLookUp.Focus()
        End If
    End Sub
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If txtRowid.Text > "" Then
            If (MessageBox.Show("Do you really want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)) = DialogResult.Yes Then
                Sub_Delete()
                ControlMaintenance.ClearInputControlsGroup(Me)
                Sub_Show()
            End If
        End If
        'MsgBox("Deletion of Role Module is not allowed!")
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
        If txtRoleID.Text.ToString <> "" And _
           txtModuleID.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(6) As SqlParameter
            Dim ROLEID As New SqlParameter("@ROLEID", SqlDbType.Int, 10) : ROLEID.Direction = ParameterDirection.Input : ROLEID.Value = txtRoleID.Text : Params(0) = ROLEID
            Dim MODULEID As New SqlParameter("@MODULEID", SqlDbType.Int, 10) : MODULEID.Direction = ParameterDirection.Input : MODULEID.Value = txtModuleID.Text : Params(1) = MODULEID
            Dim CANADD As New SqlParameter("@CANADD", SqlDbType.VarChar, 1) : CANADD.Direction = ParameterDirection.Input : CANADD.Value = txtCanAdd.Text : Params(2) = CANADD
            Dim CANEDIT As New SqlParameter("@CANEDIT", SqlDbType.VarChar, 1) : CANEDIT.Direction = ParameterDirection.Input : CANEDIT.Value = txtCanEdit.Text : Params(3) = CANEDIT
            Dim CANDELETE As New SqlParameter("@CANDELETE", SqlDbType.VarChar, 1) : CANDELETE.Direction = ParameterDirection.Input : CANDELETE.Value = txtCanDelete.Text : Params(4) = CANDELETE
            Dim CANREPORT As New SqlParameter("@CANREPORT", SqlDbType.VarChar, 1) : CANREPORT.Direction = ParameterDirection.Input : CANREPORT.Value = txtCanReport.Text : Params(5) = CANREPORT
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
            If ItemExists() Then
                MsgBox("Role ID: " & txtRoleID.Text & ", Role Name : " & txtModuleID.Text & " already exists!")
            Else
                BusinessObject.Sub_Insert(ServerPath2, "IRoleModules_Insert", CommandType.StoredProcedure, Params)
                LogHelper.InsertLog("IRoleModules_Insert")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IRoleModules_Insert.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Update()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(7) As SqlParameter
            Dim ROLEID As New SqlParameter("@ROLEID", SqlDbType.Int, 10) : ROLEID.Direction = ParameterDirection.Input : ROLEID.Value = txtRoleID.Text : Params(0) = ROLEID
            Dim MODULEID As New SqlParameter("@MODULEID", SqlDbType.Int, 10) : MODULEID.Direction = ParameterDirection.Input : MODULEID.Value = txtModuleID.Text : Params(1) = MODULEID
            Dim CANADD As New SqlParameter("@CANADD", SqlDbType.VarChar, 1) : CANADD.Direction = ParameterDirection.Input : CANADD.Value = txtCanAdd.Text : Params(2) = CANADD
            Dim CANEDIT As New SqlParameter("@CANEDIT", SqlDbType.VarChar, 1) : CANEDIT.Direction = ParameterDirection.Input : CANEDIT.Value = txtCanEdit.Text : Params(3) = CANEDIT
            Dim CANDELETE As New SqlParameter("@CANDELETE", SqlDbType.VarChar, 1) : CANDELETE.Direction = ParameterDirection.Input : CANDELETE.Value = txtCanDelete.Text : Params(4) = CANDELETE
            Dim CANREPORT As New SqlParameter("@CANREPORT", SqlDbType.VarChar, 1) : CANREPORT.Direction = ParameterDirection.Input : CANREPORT.Value = txtCanReport.Text : Params(5) = CANREPORT
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 25) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(6) = UPDATEBY
            Dim ROWID As New SqlParameter("@ROWID", SqlDbType.Int, 10) : ROWID.Direction = ParameterDirection.Input : ROWID.Value = txtRowid.Text : Params(7) = ROWID
            BusinessObject.Sub_Insert(ServerPath2, "IRoleModules_Update", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("IRoleModules_Update")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IRoleModules_Update.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Show()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            If Trim(txtSearch.Text = "") Then
                BusinessObject.Sub_Show(ServerPath2, "IRoleModules_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            Else
                Dim Params(0) As SqlParameter
                Dim ROLE As New SqlParameter("@ROLE ", SqlDbType.VarChar, 25)
                ROLE.Direction = ParameterDirection.Input
                ROLE.Value = txtSearch.Text.ToString.Trim
                Params(0) = ROLE
                BusinessObject.Sub_Show(ServerPath2, "IRoleModules_SearchShow", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
            End If
            DataGrid1.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Number of Modules: " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
            LogHelper.InsertLog("IRoleModules_SearchShow.Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IRoleModules_SearchShow.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Select(ByVal dbParams() As String, ByVal UpdateMode As String)
        'select case if add,edit or delete
        Dim i As Integer
        Dim myRowid As Integer
        Select Case UpdateMode
            Case "Insert"
                Dim BusinessObject As New BusinessLayer.clsFileMaintenance
                myRowid = CInt(BusinessObject.Sub_ReturnIntegerResult(ServerPath2, "IRoleModules_GetInsertedRowid", CommandType.StoredProcedure))
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
    Private Sub Sub_Delete()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(0) As SqlParameter
            Dim Rowid As New SqlParameter("@Rowid", SqlDbType.Int) : Rowid.Direction = ParameterDirection.Input : Rowid.Value = txtRowid.Text : Params(0) = Rowid
            BusinessObject.Sub_Delete(ServerPath2, "IRoleModules_Delete", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("IRoleModules_Delete.Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("IRoleModules_Delete.Error")
        End Try
    End Sub
    Private Sub frmRoleModules_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modControlBehavior.EnableControls(Me, False)
        modControlBehavior.EnableControlsGroup(Me, False)
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
        Sub_Show()
        DataGrid1.AlternatingBackColor = Color.LightGreen
    End Sub
  
    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click, DataGrid1.CurrentCellChanged
        Try
            With DataGrid1
                txtRowid.Text = CStr(.Item(.CurrentCell.RowNumber, 0))
                txtRoleID.Text = CStr(.Item(.CurrentCell.RowNumber, 1))
                txtRole.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                txtModuleID.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                txtModule.Text = CStr(.Item(.CurrentCell.RowNumber, 4))

                txtCanAdd.Text = CStr(.Item(.CurrentCell.RowNumber, 5))
                txtCanEdit.Text = CStr(.Item(.CurrentCell.RowNumber, 6))
                txtCanDelete.Text = CStr(.Item(.CurrentCell.RowNumber, 7))
                txtCanReport.Text = CStr(.Item(.CurrentCell.RowNumber, 8))

                lblCreateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 9))
                lblUpdateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 10))
                lblUpdateBy.Text = CStr(.Item(.CurrentCell.RowNumber, 11))
                RefreshUserRights()
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
        txtRoleID.Enabled = False
        txtModuleID.Enabled = False

        If EditMode Then
        Else

        End If
    End Sub
    Private Function ItemExists() As Boolean
        Dim retval As Boolean = False
        If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim Params(1) As SqlParameter

        Dim ROLEID As New SqlParameter("@ROLEID", SqlDbType.Int, 10)
        ROLEID.Direction = ParameterDirection.Input
        ROLEID.Value = txtRoleID.Text.ToString.Trim
        Params(0) = ROLEID

        Dim MODULEID As New SqlParameter("@MODULEID", SqlDbType.Int, 10)
        MODULEID.Direction = ParameterDirection.Input
        MODULEID.Value = txtModuleID.Text.ToString.Trim
        Params(1) = MODULEID

        BusinessObject.Sub_Show(ServerPath2, "IRoleModules_SearchCodeOrDesc", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
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
        myLoadedForm.Report = "Role Modules Report"
        myLoadedForm.Status = "ALL"
        myLoadedForm.ShowDialog()
    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    Private Sub chkCanAdd_CheckedChanged(sender As Object, e As EventArgs) Handles chkCanAdd.CheckedChanged
        If chkCanAdd.Checked Then
            txtCanAdd.Text = "Y"
        Else
            txtCanAdd.Text = "N"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkCanEdit.CheckedChanged
        If chkCanEdit.Checked Then
            txtCanEdit.Text = "Y"
        Else
            txtCanEdit.Text = "N"
        End If
    End Sub

    Private Sub chkCanDelete_CheckedChanged(sender As Object, e As EventArgs) Handles chkCanDelete.CheckedChanged
        If chkCanDelete.Checked Then
            txtCanDelete.Text = "Y"
        Else
            txtCanDelete.Text = "N"
        End If
    End Sub

    Private Sub chkCanReport_CheckedChanged(sender As Object, e As EventArgs) Handles chkCanReport.CheckedChanged
        If chkCanReport.Checked Then
            txtCanReport.Text = "Y"
        Else
            txtCanReport.Text = "N"
        End If
    End Sub

    Private Sub btnItemLookUp_Click(sender As Object, e As EventArgs) Handles btnRoleLookUp.Click
        gCode = txtRoleID.Text : gDesc = txtRole.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Role Look Up"
        myLoadedForm.RemoteDataTable = RoleLookUp().Tables(0)
        myLoadedForm.ShowDialog(Me)
        txtRoleID.Text = gCode
        txtRole.Text = gDesc
        btnModuleLookup.Focus()
    End Sub

    Private Sub btnModuleLookup_Click(sender As Object, e As EventArgs) Handles btnModuleLookup.Click
        gCode = txtModuleID.Text : gDesc = txtModule.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Module Look Up"
        myLoadedForm.RemoteDataTable = ModuleLookUp().Tables(0)
        myLoadedForm.ShowDialog(Me)
        txtModuleID.Text = gCode
        txtModule.Text = gDesc
    End Sub

    Private Sub RefreshUserRights()
        If txtCanAdd.Text = "Y" Then
            chkCanAdd.Checked = True
        Else
            chkCanAdd.Checked = False
        End If

        If txtCanEdit.Text = "Y" Then
            chkCanEdit.Checked = True
        Else
            chkCanEdit.Checked = False
        End If

        If txtCanDelete.Text = "Y" Then
            chkCanDelete.Checked = True
        Else
            chkCanDelete.Checked = False
        End If

        If txtCanReport.Text = "Y" Then
            chkCanReport.Checked = True
        Else
            chkCanReport.Checked = False
        End If
    End Sub
End Class