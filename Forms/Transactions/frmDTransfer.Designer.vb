<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDTransfer
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDTransfer))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtToLocDesc = New System.Windows.Forms.TextBox()
        Me.btnToLocationLookup = New System.Windows.Forms.Button()
        Me.txtToLocCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtexpdate = New System.Windows.Forms.DateTimePicker()
        Me.txtHTid = New System.Windows.Forms.TextBox()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFromLocDesc = New System.Windows.Forms.TextBox()
        Me.btnFromLocationLookup = New System.Windows.Forms.Button()
        Me.txtFromLocCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtItemDesc = New System.Windows.Forms.TextBox()
        Me.btnItem = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblUpdateBy = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.txtRowid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCreateDate = New System.Windows.Forms.Label()
        Me.lblUpdateDate = New System.Windows.Forms.Label()
        Me.txtTrnNo = New System.Windows.Forms.TextBox()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgPODetail = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtavailableqty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgPODetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.TradeInventory.My.Resources.Resources.Search_icon
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(395, 596)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(86, 34)
        Me.btnSearch.TabIndex = 180
        Me.btnSearch.Tag = ""
        Me.btnSearch.Text = "   &Search"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(858, 596)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(86, 34)
        Me.cmdExit.TabIndex = 173
        Me.cmdExit.Tag = "Exit"
        Me.cmdExit.Text = "E&xit"
        '
        'Button1
        '
        Me.Button1.Image = Global.TradeInventory.My.Resources.Resources.Product_sale_report_icon
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(766, 596)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 34)
        Me.Button1.TabIndex = 181
        Me.Button1.Tag = "Add"
        Me.Button1.Text = "   &Report"
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(590, 597)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(86, 34)
        Me.cmdEdit.TabIndex = 171
        Me.cmdEdit.Tag = "Edit"
        Me.cmdEdit.Text = "   &Edit"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(590, 597)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(86, 34)
        Me.cmdCancel.TabIndex = 176
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = CType(resources.GetObject("cmdDelete.Image"), System.Drawing.Image)
        Me.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDelete.Location = New System.Drawing.Point(678, 597)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(86, 34)
        Me.cmdDelete.TabIndex = 172
        Me.cmdDelete.Tag = "Delete"
        Me.cmdDelete.Text = "    &Del"
        '
        'cmdSave
        '
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(678, 597)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(86, 34)
        Me.cmdSave.TabIndex = 174
        Me.cmdSave.Tag = "Save"
        Me.cmdSave.Text = "   &Save"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtavailableqty)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtToLocDesc)
        Me.GroupBox2.Controls.Add(Me.btnToLocationLookup)
        Me.GroupBox2.Controls.Add(Me.txtToLocCode)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.dtexpdate)
        Me.GroupBox2.Controls.Add(Me.txtHTid)
        Me.GroupBox2.Controls.Add(Me.txtLotNo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtQty)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtFromLocDesc)
        Me.GroupBox2.Controls.Add(Me.btnFromLocationLookup)
        Me.GroupBox2.Controls.Add(Me.txtFromLocCode)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtItemDesc)
        Me.GroupBox2.Controls.Add(Me.btnItem)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblUpdateBy)
        Me.GroupBox2.Controls.Add(Me.txtItemCode)
        Me.GroupBox2.Controls.Add(Me.txtRowid)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblCreateDate)
        Me.GroupBox2.Controls.Add(Me.lblUpdateDate)
        Me.GroupBox2.Controls.Add(Me.txtTrnNo)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 299)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(962, 279)
        Me.GroupBox2.TabIndex = 178
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Detail"
        '
        'txtToLocDesc
        '
        Me.txtToLocDesc.Enabled = False
        Me.txtToLocDesc.Location = New System.Drawing.Point(120, 87)
        Me.txtToLocDesc.MaxLength = 100
        Me.txtToLocDesc.Multiline = True
        Me.txtToLocDesc.Name = "txtToLocDesc"
        Me.txtToLocDesc.Size = New System.Drawing.Size(256, 23)
        Me.txtToLocDesc.TabIndex = 105
        Me.txtToLocDesc.Tag = "Input"
        '
        'btnToLocationLookup
        '
        Me.btnToLocationLookup.Enabled = False
        Me.btnToLocationLookup.Image = Global.TradeInventory.My.Resources.Resources.search_icon_new
        Me.btnToLocationLookup.Location = New System.Drawing.Point(385, 87)
        Me.btnToLocationLookup.Name = "btnToLocationLookup"
        Me.btnToLocationLookup.Size = New System.Drawing.Size(52, 26)
        Me.btnToLocationLookup.TabIndex = 1
        Me.btnToLocationLookup.Tag = "Input"
        Me.btnToLocationLookup.UseVisualStyleBackColor = True
        '
        'txtToLocCode
        '
        Me.txtToLocCode.Enabled = False
        Me.txtToLocCode.Location = New System.Drawing.Point(448, 86)
        Me.txtToLocCode.MaxLength = 100
        Me.txtToLocCode.Multiline = True
        Me.txtToLocCode.Name = "txtToLocCode"
        Me.txtToLocCode.Size = New System.Drawing.Size(23, 23)
        Me.txtToLocCode.TabIndex = 103
        Me.txtToLocCode.Tag = "Input"
        Me.txtToLocCode.Visible = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 20)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "To Location  :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtexpdate
        '
        Me.dtexpdate.CustomFormat = "MM/dd/yyyy"
        Me.dtexpdate.Enabled = False
        Me.dtexpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtexpdate.Location = New System.Drawing.Point(120, 203)
        Me.dtexpdate.Name = "dtexpdate"
        Me.dtexpdate.Size = New System.Drawing.Size(257, 20)
        Me.dtexpdate.TabIndex = 5
        Me.dtexpdate.Value = New Date(2015, 10, 15, 0, 0, 0, 0)
        '
        'txtHTid
        '
        Me.txtHTid.Location = New System.Drawing.Point(448, 32)
        Me.txtHTid.Name = "txtHTid"
        Me.txtHTid.Size = New System.Drawing.Size(49, 20)
        Me.txtHTid.TabIndex = 101
        Me.txtHTid.Tag = ""
        Me.txtHTid.Visible = False
        '
        'txtLotNo
        '
        Me.txtLotNo.Enabled = False
        Me.txtLotNo.Location = New System.Drawing.Point(120, 174)
        Me.txtLotNo.MaxLength = 10
        Me.txtLotNo.Multiline = True
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(256, 23)
        Me.txtLotNo.TabIndex = 4
        Me.txtLotNo.Tag = "Input"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 20)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Exp Date :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(16, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 20)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "Lot No :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQty
        '
        Me.txtQty.Enabled = False
        Me.txtQty.Location = New System.Drawing.Point(121, 145)
        Me.txtQty.MaxLength = 10
        Me.txtQty.Multiline = True
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(256, 23)
        Me.txtQty.TabIndex = 3
        Me.txtQty.Tag = "Input"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "Quantity :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFromLocDesc
        '
        Me.txtFromLocDesc.Enabled = False
        Me.txtFromLocDesc.Location = New System.Drawing.Point(120, 58)
        Me.txtFromLocDesc.MaxLength = 100
        Me.txtFromLocDesc.Multiline = True
        Me.txtFromLocDesc.Name = "txtFromLocDesc"
        Me.txtFromLocDesc.Size = New System.Drawing.Size(256, 23)
        Me.txtFromLocDesc.TabIndex = 94
        Me.txtFromLocDesc.Tag = "Input"
        '
        'btnFromLocationLookup
        '
        Me.btnFromLocationLookup.Enabled = False
        Me.btnFromLocationLookup.Image = Global.TradeInventory.My.Resources.Resources.search_icon_new
        Me.btnFromLocationLookup.Location = New System.Drawing.Point(385, 57)
        Me.btnFromLocationLookup.Name = "btnFromLocationLookup"
        Me.btnFromLocationLookup.Size = New System.Drawing.Size(52, 26)
        Me.btnFromLocationLookup.TabIndex = 0
        Me.btnFromLocationLookup.Tag = "Input"
        Me.btnFromLocationLookup.UseVisualStyleBackColor = True
        '
        'txtFromLocCode
        '
        Me.txtFromLocCode.Enabled = False
        Me.txtFromLocCode.Location = New System.Drawing.Point(448, 56)
        Me.txtFromLocCode.MaxLength = 100
        Me.txtFromLocCode.Multiline = True
        Me.txtFromLocCode.Name = "txtFromLocCode"
        Me.txtFromLocCode.Size = New System.Drawing.Size(23, 23)
        Me.txtFromLocCode.TabIndex = 92
        Me.txtFromLocCode.Tag = "Input"
        Me.txtFromLocCode.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 20)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "From Location  :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtItemDesc
        '
        Me.txtItemDesc.Enabled = False
        Me.txtItemDesc.Location = New System.Drawing.Point(120, 116)
        Me.txtItemDesc.MaxLength = 100
        Me.txtItemDesc.Multiline = True
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(256, 23)
        Me.txtItemDesc.TabIndex = 90
        Me.txtItemDesc.Tag = "Input"
        '
        'btnItem
        '
        Me.btnItem.Enabled = False
        Me.btnItem.Image = Global.TradeInventory.My.Resources.Resources.search_icon_new
        Me.btnItem.Location = New System.Drawing.Point(385, 116)
        Me.btnItem.Name = "btnItem"
        Me.btnItem.Size = New System.Drawing.Size(52, 26)
        Me.btnItem.TabIndex = 2
        Me.btnItem.Tag = "Input"
        Me.btnItem.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(531, 91)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 20)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "Updated By :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUpdateBy
        '
        Me.lblUpdateBy.Location = New System.Drawing.Point(635, 90)
        Me.lblUpdateBy.Name = "lblUpdateBy"
        Me.lblUpdateBy.Size = New System.Drawing.Size(256, 20)
        Me.lblUpdateBy.TabIndex = 77
        Me.lblUpdateBy.Tag = "Read"
        '
        'txtItemCode
        '
        Me.txtItemCode.Enabled = False
        Me.txtItemCode.Location = New System.Drawing.Point(448, 115)
        Me.txtItemCode.MaxLength = 100
        Me.txtItemCode.Multiline = True
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(23, 23)
        Me.txtItemCode.TabIndex = 1
        Me.txtItemCode.Tag = "Input"
        Me.txtItemCode.Visible = False
        '
        'txtRowid
        '
        Me.txtRowid.Location = New System.Drawing.Point(385, 32)
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
        Me.Label1.Text = "Receive No:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 20)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Item Description  :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(531, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Create Date :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(531, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Update Date :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreateDate
        '
        Me.lblCreateDate.Location = New System.Drawing.Point(635, 32)
        Me.lblCreateDate.Name = "lblCreateDate"
        Me.lblCreateDate.Size = New System.Drawing.Size(256, 20)
        Me.lblCreateDate.TabIndex = 50
        Me.lblCreateDate.Tag = "Read"
        '
        'lblUpdateDate
        '
        Me.lblUpdateDate.Location = New System.Drawing.Point(635, 64)
        Me.lblUpdateDate.Name = "lblUpdateDate"
        Me.lblUpdateDate.Size = New System.Drawing.Size(256, 20)
        Me.lblUpdateDate.TabIndex = 51
        Me.lblUpdateDate.Tag = "Read"
        '
        'txtTrnNo
        '
        Me.txtTrnNo.Enabled = False
        Me.txtTrnNo.Location = New System.Drawing.Point(120, 32)
        Me.txtTrnNo.MaxLength = 10
        Me.txtTrnNo.Name = "txtTrnNo"
        Me.txtTrnNo.Size = New System.Drawing.Size(256, 20)
        Me.txtTrnNo.TabIndex = 0
        Me.txtTrnNo.Tag = ""
        '
        'cmdAdd
        '
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(502, 597)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(86, 34)
        Me.cmdAdd.TabIndex = 170
        Me.cmdAdd.Tag = "Add"
        Me.cmdAdd.Text = "   &Add"
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Update By"
        Me.DataGridTextBoxColumn9.MappingName = "UPDATEBY"
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "From Location"
        Me.DataGridTextBoxColumn11.MappingName = "FromLocation"
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Update Date"
        Me.DataGridTextBoxColumn8.MappingName = "UPDATEDATE"
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Create Date"
        Me.DataGridTextBoxColumn7.MappingName = "CREATEDATE"
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Qty"
        Me.DataGridTextBoxColumn6.MappingName = "QTY"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgPODetail)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 18)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(962, 275)
        Me.GroupBox1.TabIndex = 177
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "No. of Items :"
        '
        'dgPODetail
        '
        Me.dgPODetail.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgPODetail.DataMember = ""
        Me.dgPODetail.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPODetail.Location = New System.Drawing.Point(6, 24)
        Me.dgPODetail.Name = "dgPODetail"
        Me.dgPODetail.ReadOnly = True
        Me.dgPODetail.Size = New System.Drawing.Size(947, 244)
        Me.dgPODetail.TabIndex = 58
        Me.dgPODetail.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgPODetail.Tag = "View"
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridTableStyle1.DataGrid = Me.dgPODetail
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ProductFormCT_Show"
        Me.DataGridTableStyle1.ReadOnly = True
        Me.DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "DTID"
        Me.DataGridTextBoxColumn1.MappingName = "DTID"
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "From Loc Code"
        Me.DataGridTextBoxColumn2.MappingName = "FROMLOCCODE"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 150
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Item Code"
        Me.DataGridTextBoxColumn3.MappingName = "ITEMCODE"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Item Description"
        Me.DataGridTextBoxColumn10.MappingName = "ITEMDESC"
        Me.DataGridTextBoxColumn10.Width = 150
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Lot No"
        Me.DataGridTextBoxColumn4.MappingName = "LOTNO"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Exp Date"
        Me.DataGridTextBoxColumn5.MappingName = "EXPDATE"
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "To Loc Code"
        Me.DataGridTextBoxColumn12.MappingName = "ToLocCode"
        Me.DataGridTextBoxColumn12.Width = 75
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "To Location"
        Me.DataGridTextBoxColumn13.MappingName = "ToLocation"
        Me.DataGridTextBoxColumn13.Width = 75
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(130, 604)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(256, 20)
        Me.txtSearch.TabIndex = 179
        Me.txtSearch.Tag = ""
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(28, 604)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 20)
        Me.Label14.TabIndex = 175
        Me.Label14.Text = "Name :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtavailableqty
        '
        Me.txtavailableqty.Enabled = False
        Me.txtavailableqty.Location = New System.Drawing.Point(121, 229)
        Me.txtavailableqty.MaxLength = 10
        Me.txtavailableqty.Multiline = True
        Me.txtavailableqty.Name = "txtavailableqty"
        Me.txtavailableqty.ReadOnly = True
        Me.txtavailableqty.Size = New System.Drawing.Size(256, 23)
        Me.txtavailableqty.TabIndex = 106
        Me.txtavailableqty.Tag = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(1, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 20)
        Me.Label10.TabIndex = 107
        Me.Label10.Text = "Available Quantity :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmDTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 648)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDTransfer"
        Me.Text = "Transfer Inventory"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgPODetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtexpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtHTid As System.Windows.Forms.TextBox
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFromLocDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnFromLocationLookup As System.Windows.Forms.Button
    Friend WithEvents txtFromLocCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnItem As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblUpdateBy As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents txtRowid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCreateDate As System.Windows.Forms.Label
    Friend WithEvents lblUpdateDate As System.Windows.Forms.Label
    Friend WithEvents txtTrnNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgPODetail As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtToLocDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnToLocationLookup As System.Windows.Forms.Button
    Friend WithEvents txtToLocCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtavailableqty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
