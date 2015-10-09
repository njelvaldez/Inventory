Imports System.Data.SqlClient
Imports Microsoft
Imports Microsoft.Office.Interop
Imports System.Configuration
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Collections.Generic

Public Class frmProcessMDI
    Private MDIInvFile As String = System.Configuration.ConfigurationSettings.AppSettings.Item("MDIInventoryFile")

    Private Sub frmProcessMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMDI.Text = MDIInvFile
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProcessMDI()
    End Sub
    Private Sub ProcessMDI()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim mdidict As New Dictionary(Of String, String)
            Dim tempdt As New DataTable
            tempdt = DataMapHelper.Util_MetroDrugItem_SelectMDIItemCode().Tables(0)
            mdidict = DataMapHelper.DatatableToDictionary(tempdt, "MDICode", "ItemCode")

            '1.1 open MDI Source
            Dim xlmdi As New Excel.Application
            Dim wbmdi As Excel.Workbook
            Dim wsmdi As Excel.Worksheet
            Dim strmdifile As String = txtMDI.Text.ToString.Trim
            wbmdi = xlmdi.Workbooks.Open(strmdifile)
            wsmdi = CType(wbmdi.Worksheets.Item("Sheet1"), Excel.Worksheet)

            '2.iterate MDI Source
            Dim warehouse As String = "MDI"
            Dim mdiitemdesc As String = ""
            Dim mdicode As String = ""
            Dim itemcode As String = ""
            Dim lotno As String = ""
            Dim expdate As String = ""
            Dim iqty As String = ""

            'Delete Stkcard of MDI
            Stkcard_DeleteMDI(warehouse)

            For mdirownumber As Integer = 6 To 3500

                '2.1 Get MDIItem Description
                Try
                    mdicode = wsmdi.Range("C" & mdirownumber.ToString()).Value
                Catch ex As Exception
                    mdicode = ""
                End Try
                Try
                    mdiitemdesc = wsmdi.Range("D" & mdirownumber.ToString()).Value
                Catch ex As Exception
                    mdiitemdesc = ""
                End Try
                Try
                    iqty = wsmdi.Range("J" & mdirownumber.ToString()).Value
                Catch ex As Exception
                    iqty = 0
                End Try
                Try
                    lotno = wsmdi.Range("H" & mdirownumber.ToString()).Value
                Catch ex As Exception
                    lotno = ""
                End Try
                Try
                    expdate = wsmdi.Range("I" & mdirownumber.ToString()).Value
                Catch ex As Exception
                    expdate = ""
                End Try

                'If Item is Valid then Populate Inventory Dashboard MDIInventory
                If Not String.IsNullOrEmpty(mdicode) Then
                    If mdidict.ContainsKey(mdicode) Then
                        itemcode = mdidict.Item(mdicode)
                        If String.IsNullOrEmpty(itemcode) Then
                            ListBox1.Items.Add("Item code not found for " + mdicode + ":" + mdiitemdesc)
                        End If
                    Else
                        ListBox1.Items.Add("Process MDI: Unable to find Item Code in Scores Database: " + mdicode + ":" + mdiitemdesc)
                        itemcode = ""
                    End If
                Else
                    mdicode = ""
                    itemcode = ""
                End If

                'ItemCode,ItemDesc,Unrestricted QTy > 0
                If Not String.IsNullOrEmpty(itemcode) And Not String.IsNullOrEmpty(mdiitemdesc) And iqty > 0 Then
                    StkcardMDI_Insert(itemcode, warehouse, lotno, expdate, iqty, gUserID)
                End If
            Next
            xlmdi.DisplayAlerts = False
            wbmdi.Close()
            xlmdi.Quit()
            xlmdi = Nothing
            KillExcellApp()
            MessageBox.Show("MDIprocess is complete!")
        Catch ex As Exception
            MsgBox(ex.Message + ex.Message + ex.InnerException.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class