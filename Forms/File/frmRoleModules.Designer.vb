<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRoleModules
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRoleModules))
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblUpdateBy = New System.Windows.Forms.Label()
        Me.txtModuleID = New System.Windows.Forms.TextBox()
        Me.txtRowid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCreateDate = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblUpdateDate = New System.Windows.Forms.Label()
        Me.txtRoleID = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkCanAdd = New System.Windows.Forms.CheckBox()
        Me.chkCanEdit = New System.Windows.Forms.CheckBox()
        Me.chkCanDelete = New System.Windows.Forms.CheckBox()
        Me.chkCanReport = New System.Windows.Forms.CheckBox()
        Me.txtCanAdd = New System.Windows.Forms.TextBox()
        Me.txtCanEdit = New System.Windows.Forms.TextBox()
        Me.txtCanDelete = New System.Windows.Forms.TextBox()
        Me.txtCanReport = New System.Windows.Forms.TextBox()
        Me.txtRole = New System.Windows.Forms.TextBox()
        Me.txtModule = New System.Windows.Forms.TextBox()
        Me.btnRoleLookUp = New System.Windows.Forms.Button()
        Me.btnModuleLookup = New System.Windows.Forms.Button()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn20 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn21 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn22 = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "Rowid"
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn20, Me.DataGridTextBoxColumn21, Me.DataGridTextBoxColumn22})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ProductFormCT_Show"
        Me.DataGridTableStyle1.ReadOnly = True
        Me.DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(6, 24)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(947, 304)
        Me.DataGrid1.TabIndex = 58
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.DataGrid1.Tag = "View"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(522, 91)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 20)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "Updated By :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUpdateBy
        '
        Me.lblUpdateBy.Location = New System.Drawing.Point(626, 90)
        Me.lblUpdateBy.Name = "lblUpdateBy"
        Me.lblUpdateBy.Size = New System.Drawing.Size(256, 20)
        Me.lblUpdateBy.TabIndex = 77
        Me.lblUpdateBy.Tag = "Read"
        '
        'txtModuleID
        '
        Me.txtModuleID.Enabled = False
        Me.txtModuleID.Location = New System.Drawing.Point(449, 60)
        Me.txtModuleID.MaxLength = 100
        Me.txtModuleID.Multiline = True
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.Size = New System.Drawing.Size(43, 23)
        Me.txtModuleID.TabIndex = 1
        Me.txtModuleID.Tag = "Input"
        Me.txtModuleID.Visible = False
        '
        'txtRowid
        '
        Me.txtRowid.Location = New System.Drawing.Point(19, 138)
        Me.txtRowid.Name = "txtRowid"
        Me.txtRowid.Size = New System.Drawing.Size(49, 20)
        Me.txtRowid.TabIndex = 59
        Me.txtRowid.Tag = "Input"
        Me.txtRowid.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Role :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Module :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(522, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Create Date :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(522, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Update Date :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreateDate
        '
        Me.lblCreateDate.Location = New System.Drawing.Point(626, 32)
        Me.lblCreateDate.Name = "lblCreateDate"
        Me.lblCreateDate.Size = New System.Drawing.Size(256, 20)
        Me.lblCreateDate.TabIndex = 50
        Me.lblCreateDate.Tag = "Read"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGrid1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(962, 344)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Role Modules"
        '
        'lblUpdateDate
        '
        Me.lblUpdateDate.Location = New System.Drawing.Point(626, 64)
        Me.lblUpdateDate.Name = "lblUpdateDate"
        Me.lblUpdateDate.Size = New System.Drawing.Size(256, 20)
        Me.lblUpdateDate.TabIndex = 51
        Me.lblUpdateDate.Tag = "Read"
        '
        'txtRoleID
        '
        Me.txtRoleID.Enabled = False
        Me.txtRoleID.Location = New System.Drawing.Point(449, 34)
        Me.txtRoleID.MaxLength = 10
        Me.txtRoleID.Name = "txtRoleID"
        Me.txtRoleID.Size = New System.Drawing.Size(43, 20)
        Me.txtRoleID.TabIndex = 0
        Me.txtRoleID.Tag = "Input"
        Me.txtRoleID.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = Global.InventoryDashboard2014.My.Resources.Resources.Product_sale_report_icon
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(767, 590)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 34)
        Me.Button1.TabIndex = 121
        Me.Button1.Tag = "Add"
        Me.Button1.Text = "   &Report"
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.InventoryDashboard2014.My.Resources.Resources.Search_icon
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(396, 590)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(86, 34)
        Me.btnSearch.TabIndex = 120
        Me.btnSearch.Tag = ""
        Me.btnSearch.Text = "   &Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(131, 598)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(256, 20)
        Me.txtSearch.TabIndex = 119
        Me.txtSearch.Tag = ""
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(591, 591)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(86, 34)
        Me.cmdEdit.TabIndex = 111
        Me.cmdEdit.Tag = "Edit"
        Me.cmdEdit.Text = "   &Edit"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(591, 591)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(86, 34)
        Me.cmdCancel.TabIndex = 116
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = CType(resources.GetObject("cmdDelete.Image"), System.Drawing.Image)
        Me.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDelete.Location = New System.Drawing.Point(679, 591)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(86, 34)
        Me.cmdDelete.TabIndex = 112
        Me.cmdDelete.Tag = "Delete"
        Me.cmdDelete.Text = "    &Del"
        '
        'cmdSave
        '
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(679, 591)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(86, 34)
        Me.cmdSave.TabIndex = 114
        Me.cmdSave.Tag = "Save"
        Me.cmdSave.Text = "   &Save"
        '
        'cmdAdd
        '
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(503, 591)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(86, 34)
        Me.cmdAdd.TabIndex = 110
        Me.cmdAdd.Tag = "Add"
        Me.cmdAdd.Text = "   &Add"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(859, 590)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(86, 34)
        Me.cmdExit.TabIndex = 113
        Me.cmdExit.Tag = "Exit"
        Me.cmdExit.Text = "E&xit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnModuleLookup)
        Me.GroupBox2.Controls.Add(Me.btnRoleLookUp)
        Me.GroupBox2.Controls.Add(Me.txtModule)
        Me.GroupBox2.Controls.Add(Me.txtRole)
        Me.GroupBox2.Controls.Add(Me.txtCanReport)
        Me.GroupBox2.Controls.Add(Me.txtCanDelete)
        Me.GroupBox2.Controls.Add(Me.txtCanEdit)
        Me.GroupBox2.Controls.Add(Me.txtCanAdd)
        Me.GroupBox2.Controls.Add(Me.chkCanReport)
        Me.GroupBox2.Controls.Add(Me.chkCanDelete)
        Me.GroupBox2.Controls.Add(Me.chkCanEdit)
        Me.GroupBox2.Controls.Add(Me.chkCanAdd)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblUpdateBy)
        Me.GroupBox2.Controls.Add(Me.txtModuleID)
        Me.GroupBox2.Controls.Add(Me.txtRowid)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblCreateDate)
        Me.GroupBox2.Controls.Add(Me.lblUpdateDate)
        Me.GroupBox2.Controls.Add(Me.txtRoleID)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 376)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(962, 208)
        Me.GroupBox2.TabIndex = 118
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Role Module Detail"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(29, 598)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 20)
        Me.Label14.TabIndex = 115
        Me.Label14.Text = "Name :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkCanAdd
        '
        Me.chkCanAdd.AutoSize = True
        Me.chkCanAdd.Location = New System.Drawing.Point(120, 106)
        Me.chkCanAdd.Name = "chkCanAdd"
        Me.chkCanAdd.Size = New System.Drawing.Size(45, 17)
        Me.chkCanAdd.TabIndex = 87
        Me.chkCanAdd.Tag = "Input"
        Me.chkCanAdd.Text = "Add"
        Me.chkCanAdd.UseVisualStyleBackColor = True
        '
        'chkCanEdit
        '
        Me.chkCanEdit.AutoSize = True
        Me.chkCanEdit.Location = New System.Drawing.Point(182, 106)
        Me.chkCanEdit.Name = "chkCanEdit"
        Me.chkCanEdit.Size = New System.Drawing.Size(44, 17)
        Me.chkCanEdit.TabIndex = 88
        Me.chkCanEdit.Tag = "Input"
        Me.chkCanEdit.Text = "Edit"
        Me.chkCanEdit.UseVisualStyleBackColor = True
        '
        'chkCanDelete
        '
        Me.chkCanDelete.AutoSize = True
        Me.chkCanDelete.Location = New System.Drawing.Point(243, 106)
        Me.chkCanDelete.Name = "chkCanDelete"
        Me.chkCanDelete.Size = New System.Drawing.Size(57, 17)
        Me.chkCanDelete.TabIndex = 89
        Me.chkCanDelete.Tag = "Input"
        Me.chkCanDelete.Text = "Delete"
        Me.chkCanDelete.UseVisualStyleBackColor = True
        '
        'chkCanReport
        '
        Me.chkCanReport.AutoSize = True
        Me.chkCanReport.Location = New System.Drawing.Point(317, 106)
        Me.chkCanReport.Name = "chkCanReport"
        Me.chkCanReport.Size = New System.Drawing.Size(58, 17)
        Me.chkCanReport.TabIndex = 90
        Me.chkCanReport.Tag = "Input"
        Me.chkCanReport.Text = "Report"
        Me.chkCanReport.UseVisualStyleBackColor = True
        '
        'txtCanAdd
        '
        Me.txtCanAdd.Location = New System.Drawing.Point(120, 138)
        Me.txtCanAdd.Name = "txtCanAdd"
        Me.txtCanAdd.Size = New System.Drawing.Size(49, 20)
        Me.txtCanAdd.TabIndex = 91
        Me.txtCanAdd.Tag = "Input"
        Me.txtCanAdd.Visible = False
        '
        'txtCanEdit
        '
        Me.txtCanEdit.Location = New System.Drawing.Point(182, 138)
        Me.txtCanEdit.Name = "txtCanEdit"
        Me.txtCanEdit.Size = New System.Drawing.Size(49, 20)
        Me.txtCanEdit.TabIndex = 92
        Me.txtCanEdit.Tag = "Input"
        Me.txtCanEdit.Visible = False
        '
        'txtCanDelete
        '
        Me.txtCanDelete.Location = New System.Drawing.Point(243, 138)
        Me.txtCanDelete.Name = "txtCanDelete"
        Me.txtCanDelete.Size = New System.Drawing.Size(49, 20)
        Me.txtCanDelete.TabIndex = 93
        Me.txtCanDelete.Tag = "Input"
        Me.txtCanDelete.Visible = False
        '
        'txtCanReport
        '
        Me.txtCanReport.Location = New System.Drawing.Point(317, 138)
        Me.txtCanReport.Name = "txtCanReport"
        Me.txtCanReport.Size = New System.Drawing.Size(49, 20)
        Me.txtCanReport.TabIndex = 94
        Me.txtCanReport.Tag = "Input"
        Me.txtCanReport.Visible = False
        '
        'txtRole
        '
        Me.txtRole.Enabled = False
        Me.txtRole.Location = New System.Drawing.Point(120, 34)
        Me.txtRole.MaxLength = 10
        Me.txtRole.Name = "txtRole"
        Me.txtRole.Size = New System.Drawing.Size(256, 20)
        Me.txtRole.TabIndex = 95
        Me.txtRole.Tag = "Input"
        '
        'txtModule
        '
        Me.txtModule.Enabled = False
        Me.txtModule.Location = New System.Drawing.Point(120, 64)
        Me.txtModule.MaxLength = 100
        Me.txtModule.Multiline = True
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(256, 23)
        Me.txtModule.TabIndex = 96
        Me.txtModule.Tag = "Input"
        '
        'btnRoleLookUp
        '
        Me.btnRoleLookUp.Enabled = False
        Me.btnRoleLookUp.Image = Global.InventoryDashboard2014.My.Resources.Resources.search_icon_new
        Me.btnRoleLookUp.Location = New System.Drawing.Point(385, 34)
        Me.btnRoleLookUp.Name = "btnRoleLookUp"
        Me.btnRoleLookUp.Size = New System.Drawing.Size(47, 22)
        Me.btnRoleLookUp.TabIndex = 100
        Me.btnRoleLookUp.Tag = "Input"
        Me.btnRoleLookUp.UseVisualStyleBackColor = True
        '
        'btnModuleLookup
        '
        Me.btnModuleLookup.Enabled = False
        Me.btnModuleLookup.Image = Global.InventoryDashboard2014.My.Resources.Resources.search_icon_new
        Me.btnModuleLookup.Location = New System.Drawing.Point(385, 64)
        Me.btnModuleLookup.Name = "btnModuleLookup"
        Me.btnModuleLookup.Size = New System.Drawing.Size(47, 22)
        Me.btnModuleLookup.TabIndex = 101
        Me.btnModuleLookup.Tag = "Input"
        Me.btnModuleLookup.UseVisualStyleBackColor = True
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Role ID"
        Me.DataGridTextBoxColumn12.MappingName = "ROLEID"
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "Role"
        Me.DataGridTextBoxColumn13.MappingName = "ROLE"
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Format = ""
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "Module ID"
        Me.DataGridTextBoxColumn14.MappingName = "MODULEID"
        Me.DataGridTextBoxColumn14.Width = 75
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "Module"
        Me.DataGridTextBoxColumn15.MappingName = "MODULE"
        Me.DataGridTextBoxColumn15.Width = 75
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Format = ""
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "Can Add"
        Me.DataGridTextBoxColumn16.MappingName = "CANADD"
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Format = ""
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "Can Edit"
        Me.DataGridTextBoxColumn17.MappingName = "CANEDIT"
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Format = ""
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "Can Delete"
        Me.DataGridTextBoxColumn18.MappingName = "CANDELETE"
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Format = ""
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "Can Report"
        Me.DataGridTextBoxColumn19.MappingName = "CANREPORT"
        Me.DataGridTextBoxColumn19.Width = 75
        '
        'DataGridTextBoxColumn20
        '
        Me.DataGridTextBoxColumn20.Format = ""
        Me.DataGridTextBoxColumn20.FormatInfo = Nothing
        Me.DataGridTextBoxColumn20.HeaderText = "Create Date"
        Me.DataGridTextBoxColumn20.MappingName = "CREATEDATE"
        Me.DataGridTextBoxColumn20.Width = 75
        '
        'DataGridTextBoxColumn21
        '
        Me.DataGridTextBoxColumn21.Format = ""
        Me.DataGridTextBoxColumn21.FormatInfo = Nothing
        Me.DataGridTextBoxColumn21.HeaderText = "Update Date"
        Me.DataGridTextBoxColumn21.MappingName = "UPDATEDATE"
        Me.DataGridTextBoxColumn21.Width = 75
        '
        'DataGridTextBoxColumn22
        '
        Me.DataGridTextBoxColumn22.Format = ""
        Me.DataGridTextBoxColumn22.FormatInfo = Nothing
        Me.DataGridTextBoxColumn22.HeaderText = "Update By"
        Me.DataGridTextBoxColumn22.MappingName = "UPDATEBY"
        Me.DataGridTextBoxColumn22.Width = 75
        '
        'frmRoleModules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 648)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label14)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRoleModules"
        Me.Text = "User Role Modules"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblUpdateBy As System.Windows.Forms.Label
    Friend WithEvents txtModuleID As System.Windows.Forms.TextBox
    Friend WithEvents txtRowid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCreateDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUpdateDate As System.Windows.Forms.Label
    Friend WithEvents txtRoleID As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkCanReport As System.Windows.Forms.CheckBox
    Friend WithEvents chkCanDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkCanEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkCanAdd As System.Windows.Forms.CheckBox
    Friend WithEvents txtCanReport As System.Windows.Forms.TextBox
    Friend WithEvents txtCanDelete As System.Windows.Forms.TextBox
    Friend WithEvents txtCanEdit As System.Windows.Forms.TextBox
    Friend WithEvents txtCanAdd As System.Windows.Forms.TextBox
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
    Friend WithEvents txtRole As System.Windows.Forms.TextBox
    Friend WithEvents btnModuleLookup As System.Windows.Forms.Button
    Friend WithEvents btnRoleLookUp As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn21 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn22 As System.Windows.Forms.DataGridTextBoxColumn
End Class
