Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Configuration
'Imports DataAccessHelper
Public Class Main
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem126 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem127 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem41 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem46 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem44 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem47 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem48 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem49 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem50 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem51 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem52 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem53 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem129 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem46 = New System.Windows.Forms.MenuItem()
        Me.MenuItem27 = New System.Windows.Forms.MenuItem()
        Me.MenuItem33 = New System.Windows.Forms.MenuItem()
        Me.MenuItem30 = New System.Windows.Forms.MenuItem()
        Me.MenuItem32 = New System.Windows.Forms.MenuItem()
        Me.MenuItem31 = New System.Windows.Forms.MenuItem()
        Me.mnuExit = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem44 = New System.Windows.Forms.MenuItem()
        Me.MenuItem43 = New System.Windows.Forms.MenuItem()
        Me.MenuItem45 = New System.Windows.Forms.MenuItem()
        Me.MenuItem39 = New System.Windows.Forms.MenuItem()
        Me.MenuItem38 = New System.Windows.Forms.MenuItem()
        Me.MenuItem37 = New System.Windows.Forms.MenuItem()
        Me.MenuItem49 = New System.Windows.Forms.MenuItem()
        Me.MenuItem129 = New System.Windows.Forms.MenuItem()
        Me.MenuItem28 = New System.Windows.Forms.MenuItem()
        Me.MenuItem29 = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItem47 = New System.Windows.Forms.MenuItem()
        Me.MenuItem42 = New System.Windows.Forms.MenuItem()
        Me.MenuItem41 = New System.Windows.Forms.MenuItem()
        Me.MenuItem40 = New System.Windows.Forms.MenuItem()
        Me.MenuItem50 = New System.Windows.Forms.MenuItem()
        Me.MenuItem51 = New System.Windows.Forms.MenuItem()
        Me.MenuItem48 = New System.Windows.Forms.MenuItem()
        Me.MenuItem52 = New System.Windows.Forms.MenuItem()
        Me.MenuItem53 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem126 = New System.Windows.Forms.MenuItem()
        Me.MenuItem127 = New System.Windows.Forms.MenuItem()
        Me.MenuItem36 = New System.Windows.Forms.MenuItem()
        Me.MenuItem19 = New System.Windows.Forms.MenuItem()
        Me.MenuItem18 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem21 = New System.Windows.Forms.MenuItem()
        Me.MenuItem22 = New System.Windows.Forms.MenuItem()
        Me.MenuItem25 = New System.Windows.Forms.MenuItem()
        Me.MenuItem23 = New System.Windows.Forms.MenuItem()
        Me.MenuItem24 = New System.Windows.Forms.MenuItem()
        Me.MenuItem26 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.MenuItem16 = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        Me.MenuItem35 = New System.Windows.Forms.MenuItem()
        Me.MenuItem34 = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem20 = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem8, Me.MenuItem1, Me.MenuItem28, Me.MenuItem11, Me.MenuItem5, Me.MenuItem126, Me.MenuItem36})
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 0
        Me.MenuItem8.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem46, Me.MenuItem27, Me.MenuItem33, Me.mnuExit})
        Me.MenuItem8.Text = "File"
        '
        'MenuItem46
        '
        Me.MenuItem46.Index = 0
        Me.MenuItem46.Text = "Item"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 1
        Me.MenuItem27.Text = "Suppliers"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 2
        Me.MenuItem33.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem30, Me.MenuItem32, Me.MenuItem31})
        Me.MenuItem33.Text = "Users"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 0
        Me.MenuItem30.Text = "Change Password"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 1
        Me.MenuItem32.Text = "Master File"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 2
        Me.MenuItem31.Text = "Role Modules"
        '
        'mnuExit
        '
        Me.mnuExit.Index = 3
        Me.mnuExit.Shortcut = System.Windows.Forms.Shortcut.CtrlDel
        Me.mnuExit.Text = "E&xit"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem44, Me.MenuItem43, Me.MenuItem45, Me.MenuItem129})
        Me.MenuItem1.Text = "&Transactions"
        '
        'MenuItem44
        '
        Me.MenuItem44.Index = 0
        Me.MenuItem44.Text = "Forecast"
        '
        'MenuItem43
        '
        Me.MenuItem43.Index = 1
        Me.MenuItem43.Text = "Process MDI Inventory"
        '
        'MenuItem45
        '
        Me.MenuItem45.Index = 2
        Me.MenuItem45.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem39, Me.MenuItem38, Me.MenuItem37, Me.MenuItem49})
        Me.MenuItem45.Text = "IMS Inventory"
        '
        'MenuItem39
        '
        Me.MenuItem39.Index = 0
        Me.MenuItem39.Text = "Adjustment"
        '
        'MenuItem38
        '
        Me.MenuItem38.Index = 1
        Me.MenuItem38.Text = "Issuance (SARS,MDI)"
        '
        'MenuItem37
        '
        Me.MenuItem37.Index = 2
        Me.MenuItem37.Text = "Receiving"
        '
        'MenuItem49
        '
        Me.MenuItem49.Index = 3
        Me.MenuItem49.Text = "Transfer (FG,QUALITY,WIP)"
        '
        'MenuItem129
        '
        Me.MenuItem129.Index = 3
        Me.MenuItem129.Text = "-"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 2
        Me.MenuItem28.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem29})
        Me.MenuItem28.Text = "Purchase Order"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 0
        Me.MenuItem29.Text = "Purchase Order Entry"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 3
        Me.MenuItem11.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem47, Me.MenuItem50, Me.MenuItem51})
        Me.MenuItem11.Text = "Reports"
        '
        'MenuItem47
        '
        Me.MenuItem47.Index = 0
        Me.MenuItem47.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem42, Me.MenuItem41, Me.MenuItem40})
        Me.MenuItem47.Text = "IMS Inventory"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 0
        Me.MenuItem42.Text = "Adjustment"
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 1
        Me.MenuItem41.Text = "Issuance"
        '
        'MenuItem40
        '
        Me.MenuItem40.Index = 2
        Me.MenuItem40.Text = "Receiving"
        '
        'MenuItem50
        '
        Me.MenuItem50.Index = 1
        Me.MenuItem50.Text = "Stock Overview"
        '
        'MenuItem51
        '
        Me.MenuItem51.Index = 2
        Me.MenuItem51.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem48, Me.MenuItem52, Me.MenuItem53})
        Me.MenuItem51.Text = "Inventory Reports Analysis"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 0
        Me.MenuItem48.Text = "Inventory Report - SH Forecast"
        '
        'MenuItem52
        '
        Me.MenuItem52.Index = 1
        Me.MenuItem52.Text = "Inventory Report - Sales History"
        '
        'MenuItem53
        '
        Me.MenuItem53.Index = 2
        Me.MenuItem53.Text = "Inventory Report - Sales & Forecast"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem6})
        Me.MenuItem5.Text = "&Window"
        Me.MenuItem5.Visible = False
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Tile Horizontally"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Tile Vertically"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.Text = "Cascade"
        '
        'MenuItem126
        '
        Me.MenuItem126.Index = 5
        Me.MenuItem126.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem127})
        Me.MenuItem126.Text = "Help"
        '
        'MenuItem127
        '
        Me.MenuItem127.Index = 0
        Me.MenuItem127.Shortcut = System.Windows.Forms.Shortcut.F1
        Me.MenuItem127.Text = "About"
        '
        'MenuItem36
        '
        Me.MenuItem36.Enabled = False
        Me.MenuItem36.Index = 6
        Me.MenuItem36.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem19, Me.MenuItem18, Me.MenuItem4, Me.MenuItem7, Me.MenuItem21, Me.MenuItem22, Me.MenuItem25, Me.MenuItem26, Me.MenuItem35, Me.MenuItem10, Me.MenuItem9, Me.MenuItem20})
        Me.MenuItem36.Text = "Hidden"
        Me.MenuItem36.Visible = False
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 0
        Me.MenuItem19.Text = "Samples Allocation"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 1
        Me.MenuItem18.Text = "Promats Allocation"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Inventory Dash Board"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 3
        Me.MenuItem7.Text = "Samples and Promats"
        Me.MenuItem7.Visible = False
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 4
        Me.MenuItem21.Text = "ISSPM Template"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 5
        Me.MenuItem22.Text = "ISSPM Entry"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 6
        Me.MenuItem25.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem23, Me.MenuItem24})
        Me.MenuItem25.Text = "IMS"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 0
        Me.MenuItem23.Text = "&Promats Master List (Active) XLS"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 1
        Me.MenuItem24.Text = "Samples Master List(Active) XLS"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 7
        Me.MenuItem26.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem12, Me.MenuItem14, Me.MenuItem16, Me.MenuItem13, Me.MenuItem15, Me.MenuItem17})
        Me.MenuItem26.Text = "Master List"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 0
        Me.MenuItem12.Text = "&Promats Master List (Active)"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 1
        Me.MenuItem14.Text = "&Promats Master List(In-Active)"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 2
        Me.MenuItem16.Text = "&Promats Master List (All)"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 3
        Me.MenuItem13.Text = "&Samples Master List(Active)"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 4
        Me.MenuItem15.Text = "&Samples Master List(In-Active)"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 5
        Me.MenuItem17.Text = "&Samples Master List(All)"
        '
        'MenuItem35
        '
        Me.MenuItem35.Index = 8
        Me.MenuItem35.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem34})
        Me.MenuItem35.Text = "Dispatch"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 0
        Me.MenuItem34.Text = "Dispatch Report"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 9
        Me.MenuItem10.Text = "&ProMats"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 10
        Me.MenuItem9.Text = "&Samples"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 11
        Me.MenuItem20.Text = "Specialis&ts"
        '
        'Main
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(968, 1)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "Main"
        Me.Text = "Trade Inventory"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        Application.Exit()
        LogHelper.InsertLog("User Logout")
    End Sub

    Private Sub FrmShw(ByVal vfrm As Form)
        vfrm.MdiParent = Me
        vfrm.StartPosition = FormStartPosition.CenterScreen
        vfrm.Show()
    End Sub

    Private Sub MenuItem127_Click(sender As Object, e As EventArgs) Handles MenuItem127.Click
        Dim documentpath As String = System.Configuration.ConfigurationSettings.AppSettings.Item("InventoryDashboardPath")
        Process.Start(documentpath + "USERSMANUAL.DOCX")
    End Sub






    Private Sub MenuItem12_Click(sender As Object, e As EventArgs) Handles MenuItem12.Click
        If AccessIsAlowed(gUserID, "PROMATS MASTER LIST") Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Promats Master List Report"
            myLoadedForm.Status = "A"
            myLoadedForm.ShowDialog()
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem13_Click(sender As Object, e As EventArgs) Handles MenuItem13.Click

        If AccessIsAlowed(gUserID, "SAMPLES MASTER LIST") Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Samples Master List Report"
            myLoadedForm.Status = "A"
            myLoadedForm.ShowDialog()
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem14_Click(sender As Object, e As EventArgs) Handles MenuItem14.Click

        If AccessIsAlowed(gUserID, "PROMATS MASTER LIST") Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Promats Master List Report"
            myLoadedForm.Status = "I"
            myLoadedForm.ShowDialog()
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem15_Click(sender As Object, e As EventArgs) Handles MenuItem15.Click

        If AccessIsAlowed(gUserID, "SAMPLES MASTER LIST") Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Samples Master List Report"
            myLoadedForm.Status = "I"
            myLoadedForm.ShowDialog()
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem16_Click(sender As Object, e As EventArgs) Handles MenuItem16.Click

        If AccessIsAlowed(gUserID, "PROMATS MASTER LIST") Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Promats Master List Report"
            myLoadedForm.Status = "ALL"
            myLoadedForm.ShowDialog()
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem17_Click(sender As Object, e As EventArgs) Handles MenuItem17.Click

        If AccessIsAlowed(gUserID, "SAMPLES MASTER LIST") Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Samples Master List Report"
            myLoadedForm.Status = "ALL"
            myLoadedForm.ShowDialog()
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub


    Private Sub MenuItem23_Click(sender As Object, e As EventArgs) Handles MenuItem23.Click
        If AccessIsAlowed(gUserID, "IMS PROMATS MASTER LIST") Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Promats Master List Report XLS"
            myLoadedForm.Status = "ALL"
            myLoadedForm.ShowDialog()
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem24_Click(sender As Object, e As EventArgs) Handles MenuItem24.Click
        If AccessIsAlowed(gUserID, "IMS SAMPLES MASTER LIST") Then
            Dim myLoadedForm As New frmReportViewer
            myLoadedForm.Report = "Samples Master List Report XLS"
            myLoadedForm.Status = "A"
            myLoadedForm.ShowDialog()
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem27_Click(sender As Object, e As EventArgs) Handles MenuItem27.Click
        If AccessIsAlowed(gUserID, "SUPPLIER MASTER FILE") Then
            Dim myLoadedForm As New frmISupplier
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem29_Click(sender As Object, e As EventArgs) Handles MenuItem29.Click
        If AccessIsAlowed(gUserID, "PURCHASE ORDER") Then
            Dim myLoadedForm As New frmPOHeader
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem30_Click(sender As Object, e As EventArgs) Handles MenuItem30.Click
        Dim myLoadedForm As New frmChangePassword
        FrmShw(myLoadedForm)
    End Sub

    Private Sub MenuItem31_Click(sender As Object, e As EventArgs) Handles MenuItem31.Click
        If AccessIsAlowed(gUserID, "ROLE MODULES") Then
            Dim myLoadedForm As New frmRoleModules
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem32_Click(sender As Object, e As EventArgs) Handles MenuItem32.Click
        If AccessIsAlowed(gUserID, "USER MASTER FILE") Then
            Dim myLoadedForm As New frmUsers
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem26_Click(sender As Object, e As EventArgs) Handles MenuItem26.Click

    End Sub

    Private Sub MenuItem46_Click(sender As Object, e As EventArgs) Handles MenuItem46.Click
        If AccessIsAlowed(gUserID, "USER MASTER FILE") Then
            Dim myLoadedForm As New frmItem
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem44_Click(sender As Object, e As EventArgs) Handles MenuItem44.Click
        If AccessIsAlowed(gUserID, "SEGMENT FORECASTS") Then
            Dim myLoadedForm As New frmForecasts
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem43_Click(sender As Object, e As EventArgs) Handles MenuItem43.Click
        If AccessIsAlowed(gUserID, "SEGMENT FORECASTS") Then
            Dim myLoadedForm As New frmProcessMDI
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem48_Click(sender As Object, e As EventArgs) Handles MenuItem48.Click
        If AccessIsAlowed(gUserID, "INVENTORY REPORT") Then
            Dim myLoadedForm As New frmInventoryReport
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem39_Click(sender As Object, e As EventArgs) Handles MenuItem39.Click
        If AccessIsAlowed(gUserID, "INVENTORY ADJUSTMENT") Then
            Dim myLoadedForm As New frmAdjustment
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem37_Click(sender As Object, e As EventArgs) Handles MenuItem37.Click
        If AccessIsAlowed(gUserID, "RECEIVE INVENTORY") Then
            Dim myLoadedForm As New frmHReceive
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem38_Click(sender As Object, e As EventArgs) Handles MenuItem38.Click
        If AccessIsAlowed(gUserID, "ISSUE INVENTORY") Then
            Dim myLoadedForm As New frmHIssue
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem49_Click(sender As Object, e As EventArgs) Handles MenuItem49.Click
        If AccessIsAlowed(gUserID, "TRANSFER INVENTORY") Then
            Dim myLoadedForm As New frmTransfer
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem50_Click(sender As Object, e As EventArgs) Handles MenuItem50.Click
        If AccessIsAlowed(gUserID, "INVENTORY REPORT") Then
            Dim myLoadedForm As New frmStockOverview
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem52_Click(sender As Object, e As EventArgs) Handles MenuItem52.Click
        If AccessIsAlowed(gUserID, "INVENTORY REPORT") Then
            Dim myLoadedForm As New frmInventoryReportSales
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub

    Private Sub MenuItem53_Click(sender As Object, e As EventArgs) Handles MenuItem53.Click
        If AccessIsAlowed(gUserID, "INVENTORY REPORT") Then
            Dim myLoadedForm As New frmInventoryReportSalesandFcst
            FrmShw(myLoadedForm)
        Else
            MsgBox("User acces is not allowed!")
        End If
    End Sub
End Class
