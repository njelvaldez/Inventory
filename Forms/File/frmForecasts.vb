Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmForecasts
    Private RemoteDataSet As New DataSet
    Private EditMode As Boolean = False
    Private ModuleName As String = "SEGMENT FORECASTS"
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If UserCanAdd(gUserID, ModuleName) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            ControlMaintenance.ClearInputControlsGroup(Me)
            EditMode = False
            EnableCodeAndDesc(False)
            txtQuantity.Enabled = True
            modControlBehavior.SetBackgroundControlsGroup(Me)
            btnItemLookUp.Focus()
            btnItemLookUp_Click(sender, e)
            txtQuantity.Focus()
        End If
    End Sub
    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        If UserCanEdit(gUserID, ModuleName) Then
            modControlBehavior.EnableControlsGroup(Me, True)
            If txtItemDesc.Text = "" And txtQuantity.Text = "" And txtDivCode.Text = "" Then
                MessageBox.Show("Please select a record to modify!", "Record Selection", MessageBoxButtons.OK, _
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                modControlBehavior.EnableControlsGroup(Me, True)
                EditMode = True
                EnableCodeAndDesc(False)
                SetBackgroundControlsGroup(Me)
                txtQuantity.Focus()
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
        MsgBox("Deletion of Segment Forecast is not allowed!")
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
        If txtQuantity.Text.ToString <> "" And txtItemCode.Text.ToString <> "" And _
           txtDivCode.Text.ToString <> "" And txtFcstDate.Text.ToString <> "" Then
            retval = True
        End If
        Return retval
    End Function
    Private Sub Sub_Insert()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(4) As SqlParameter
            Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10) : ITEMCODE.Direction = ParameterDirection.Input : ITEMCODE.Value = txtItemCode.Text : Params(0) = ITEMCODE
            Dim QTY As New SqlParameter("@QTY", SqlDbType.Money, 12) : QTY.Direction = ParameterDirection.Input : QTY.Value = txtQuantity.Text : Params(1) = QTY
            Dim DIVCODE As New SqlParameter("@DIVCODE", SqlDbType.VarChar, 3) : DIVCODE.Direction = ParameterDirection.Input : DIVCODE.Value = txtDivCode.Text : Params(2) = DIVCODE
            Dim FCSTDATE As New SqlParameter("@FCSTDATE", SqlDbType.DateTime, 10) : FCSTDATE.Direction = ParameterDirection.Input : FCSTDATE.Value = txtFcstDate.Text : Params(3) = FCSTDATE
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 10) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(4) = UPDATEBY
            If ForecastExists() Then
                MsgBox("Item Desciption : " & txtItemDesc.Text & ", Segment : " & txtDivDesc.Text & " already exists!")
            Else
                BusinessObject.Sub_Insert(ServerPath2, "Forecast_Insert", CommandType.StoredProcedure, Params)
                LogHelper.InsertLog("Forecast_Insert")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("Forecast_Insert.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Update()
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            Dim Params(5) As SqlParameter
            Dim FCID As New SqlParameter("@FCID", SqlDbType.Int, 10) : FCID.Direction = ParameterDirection.Input : FCID.Value = Convert.ToInt16(txtRowid.Text) : Params(0) = FCID
            Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10) : ITEMCODE.Direction = ParameterDirection.Input : ITEMCODE.Value = txtItemCode.Text : Params(1) = ITEMCODE
            Dim QTY As New SqlParameter("@QTY", SqlDbType.Money, 12) : QTY.Direction = ParameterDirection.Input : QTY.Value = txtQuantity.Text : Params(2) = QTY
            Dim DIVCODE As New SqlParameter("@DIVCODE", SqlDbType.VarChar, 3) : DIVCODE.Direction = ParameterDirection.Input : DIVCODE.Value = txtDivCode.Text : Params(3) = DIVCODE
            Dim FCSTDATE As New SqlParameter("@FCSTDATE", SqlDbType.DateTime, 10) : FCSTDATE.Direction = ParameterDirection.Input : FCSTDATE.Value = txtFcstDate.Text : Params(4) = FCSTDATE
            Dim UPDATEBY As New SqlParameter("@UPDATEBY", SqlDbType.VarChar, 10) : UPDATEBY.Direction = ParameterDirection.Input : UPDATEBY.Value = gUserID : Params(5) = UPDATEBY
            BusinessObject.Sub_Insert(ServerPath2, "Forecast_Update", CommandType.StoredProcedure, Params)
            LogHelper.InsertLog("Forecast_Update")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("Forecast_Update.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Show()
        Try
            If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            If Trim(txtSearch.Text = "") Then
                BusinessObject.Sub_Show(ServerPath2, "Forecast_Show", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show")
            Else
                Dim Params(0) As SqlParameter
                Dim ITEMDESC As New SqlParameter("@ITEMDESC ", SqlDbType.VarChar, 50)
                ITEMDESC.Direction = ParameterDirection.Input
                ITEMDESC.Value = txtSearch.Text.ToString.Trim
                Params(0) = ITEMDESC
                BusinessObject.Sub_Show(ServerPath2, "Forecast_Show_Search", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
            End If
            DataGrid1.DataSource = RemoteDataSet.Tables("ProductFormCT_Show")
            GroupBox1.Text = "Number of Segment Forecast : " & RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count.ToString()
            LogHelper.InsertLog("Forecast_Show_Search.Success")
        Catch ex As Exception
            MsgBox(ex.Message)
            LogHelper.InsertLog("Forecast_Show_Search.Error: " & ex.Message)
        End Try

    End Sub
    Private Sub Sub_Select(ByVal dbParams() As String, ByVal UpdateMode As String)
        'select case if add,edit or delete
        Dim i As Integer
        Dim myRowid As Integer
        Select Case UpdateMode
            Case "Insert"
                Dim BusinessObject As New BusinessLayer.clsFileMaintenance
                myRowid = CInt(BusinessObject.Sub_ReturnIntegerResult(ServerPath2, "Forecast_GetInsertedRowid", CommandType.StoredProcedure))
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
    Private Sub frmForecast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        modControlBehavior.EnableControls(Me, False)
        modControlBehavior.EnableControlsGroup(Me, False)
        RemoteDataSet.Tables.Add("ProductFormCT_Show")
        'LoadLookUp()
        Sub_Show()
        DataGrid1.AlternatingBackColor = Color.LightGreen
    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click, DataGrid1.CurrentCellChanged
        Try
            With DataGrid1
                txtRowid.Text = CStr(.Item(.CurrentCell.RowNumber, 0))
                txtItemCode.Text = CStr(.Item(.CurrentCell.RowNumber, 1))
                txtItemDesc.Text = CStr(.Item(.CurrentCell.RowNumber, 2))
                txtQuantity.Text = CStr(.Item(.CurrentCell.RowNumber, 3))
                txtDivCode.Text = CStr(.Item(.CurrentCell.RowNumber, 4))
                txtDivDesc.Text = CStr(.Item(.CurrentCell.RowNumber, 5))
                txtFcstDate.Text = CStr(.Item(.CurrentCell.RowNumber, 6))
                lblCreateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 7))
                lblUpdateDate.Text = CStr(.Item(.CurrentCell.RowNumber, 8))
                lblUpdateBy.Text = CStr(.Item(.CurrentCell.RowNumber, 9))
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
        txtQuantity.Enabled = True
        txtFcstDate.Enabled = True
        btnItemLookUp.Enabled = True
        btnDivLookup.Enabled = True
        txtItemDesc.Enabled = False
        txtDivDesc.Enabled = False
        If EditMode Then
        Else
        End If
    End Sub
    Private Function ForecastExists() As Boolean
        Dim retval As Boolean = False
        If RemoteDataSet.Tables("ProductFormCT_Show").Rows.Count > 0 Then RemoteDataSet.Tables("ProductFormCT_Show").Clear()
        Dim BusinessObject As New BusinessLayer.clsFileMaintenance
        Dim Params(2) As SqlParameter

        Dim ITEMCODE As New SqlParameter("@ITEMCODE", SqlDbType.VarChar, 10)
        ITEMCODE.Direction = ParameterDirection.Input
        ITEMCODE.Value = txtItemCode.Text.ToString.Trim
        Params(0) = ITEMCODE

        Dim DIVCODE As New SqlParameter("@DIVCODE", SqlDbType.VarChar, 3)
        DIVCODE.Direction = ParameterDirection.Input
        DIVCODE.Value = txtDivCode.Text.ToString.Trim
        Params(1) = DIVCODE

        Dim FCSTDATE As New SqlParameter("@FCSTDATE", SqlDbType.DateTime, 10)
        FCSTDATE.Direction = ParameterDirection.Input
        FCSTDATE.Value = txtFcstDate.Text.ToString.Trim
        Params(2) = FCSTDATE

        BusinessObject.Sub_Show(ServerPath2, "Forecast_Exists", CommandType.StoredProcedure, RemoteDataSet, "ProductFormCT_Show", Params)
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
            myLoadedForm.Report = "Segment Forecasts"
            myLoadedForm.Status = "ALL"
            myLoadedForm.ShowDialog()
        End If
    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs) Handles DataGrid1.Navigate

    End Sub

    Private Sub btnItemLookUp_Click(sender As Object, e As EventArgs) Handles btnItemLookUp.Click
        gCode = txtItemCode.Text : gDesc = txtItemDesc.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Item Look Up"
        myLoadedForm.RemoteDataTable = ItemLookUp().Tables(0)
        myLoadedForm.ShowDialog(Me)
        txtItemCode.Text = gCode
        txtItemDesc.Text = gDesc
    End Sub

    Private Sub btnDivLookup_Click(sender As Object, e As EventArgs) Handles btnDivLookup.Click
        gCode = txtDivCode.Text() : gDesc = txtDivDesc.Text
        Dim myLoadedForm As New frmLookUp
        myLoadedForm.lookupcaption = "Segment Look Up"
        myLoadedForm.RemoteDataTable = SegmentLookUp().Tables(0)
        myLoadedForm.ShowDialog(Me)
        txtDivCode.Text = gCode
        txtDivDesc.Text = gDesc
        txtFcstDate.Focus()
    End Sub
End Class