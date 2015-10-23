<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdjustment))
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblUpdateBy = New System.Windows.Forms.Label()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtRowid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCreateDate = New System.Windows.Forms.Label()
        Me.lblUpdateDate = New System.Windows.Forms.Label()
        Me.txtAdjustNo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAdjDate = New System.Windows.Forms.TextBox()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAdd
        '
        Me.cmdAdd.Image = CType(resources.GetObject("cmdAdd.Image"), System.Drawing.Image)
        Me.cmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAdd.Location = New System.Drawing.Point(503, 595)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(86, 34)
        Me.cmdAdd.TabIndex = 134
        Me.cmdAdd.Tag = "Add"
        Me.cmdAdd.Text = "   &Add"
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Update By"
        Me.DataGridTextBoxColumn4.MappingName = "UpdateBy"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "HAid"
        Me.DataGridTextBoxColumn1.MappingName = "HAid"
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn4})
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
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Adjustment No"
        Me.DataGridTextBoxColumn2.MappingName = "AdjNo"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 150
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "CreateDate"
        Me.DataGridTextBoxColumn3.MappingName = "CreateDate"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Update Date"
        Me.DataGridTextBoxColumn10.MappingName = "UpdateDate"
        Me.DataGridTextBoxColumn10.Width = 150
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGrid1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(962, 336)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "List of Inventory Adjustment"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(483, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 20)
        Me.Label13.TabIndex = 76
        Me.Label13.Text = "Updated By :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(878, 594)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(86, 34)
        Me.cmdExit.TabIndex = 137
        Me.cmdExit.Tag = "Exit"
        Me.cmdExit.Text = "E&xit"
        '
        'Button1
        '
        Me.Button1.Image = Global.TradeInventory.My.Resources.Resources.Gear_icon
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(767, 594)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 34)
        Me.Button1.TabIndex = 145
        Me.Button1.Tag = "Add"
        Me.Button1.Text = "      &Adjustment Detail"
        '
        'btnSearch
        '
        Me.btnSearch.Image = Global.TradeInventory.My.Resources.Resources.Search_icon
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(396, 594)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(86, 34)
        Me.btnSearch.TabIndex = 144
        Me.btnSearch.Tag = ""
        Me.btnSearch.Text = "   &Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(131, 602)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(256, 20)
        Me.txtSearch.TabIndex = 143
        Me.txtSearch.Tag = ""
        '
        'cmdEdit
        '
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEdit.Location = New System.Drawing.Point(591, 595)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(86, 34)
        Me.cmdEdit.TabIndex = 135
        Me.cmdEdit.Tag = "Edit"
        Me.cmdEdit.Text = "   &Edit"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(591, 595)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(86, 34)
        Me.cmdCancel.TabIndex = 140
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "&Cancel"
        '
        'lblUpdateBy
        '
        Me.lblUpdateBy.Location = New System.Drawing.Point(587, 83)
        Me.lblUpdateBy.Name = "lblUpdateBy"
        Me.lblUpdateBy.Size = New System.Drawing.Size(256, 20)
        Me.lblUpdateBy.TabIndex = 77
        Me.lblUpdateBy.Tag = "Read"
        '
        'cmdDelete
        '
        Me.cmdDelete.Image = CType(resources.GetObject("cmdDelete.Image"), System.Drawing.Image)
        Me.cmdDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDelete.Location = New System.Drawing.Point(679, 595)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(86, 34)
        Me.cmdDelete.TabIndex = 136
        Me.cmdDelete.Tag = "Delete"
        Me.cmdDelete.Text = "    &Del"
        '
        'cmdSave
        '
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(679, 595)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(86, 34)
        Me.cmdSave.TabIndex = 138
        Me.cmdSave.Tag = "Save"
        Me.cmdSave.Text = "   &Save"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtAdjDate)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblUpdateBy)
        Me.GroupBox2.Controls.Add(Me.txtRowid)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblCreateDate)
        Me.GroupBox2.Controls.Add(Me.lblUpdateDate)
        Me.GroupBox2.Controls.Add(Me.txtAdjustNo)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 361)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(962, 227)
        Me.GroupBox2.TabIndex = 142
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Selected Adjustment"
        '
        'txtRowid
        '
        Me.txtRowid.Location = New System.Drawing.Point(387, 25)
        Me.txtRowid.Name = "txtRowid"
        Me.txtRowid.Size = New System.Drawing.Size(49, 20)
        Me.txtRowid.TabIndex = 59
        Me.txtRowid.Tag = "Input"
        Me.txtRowid.Visible = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Adjustment No :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(483, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Create Date :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(483, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Update Date :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreateDate
        '
        Me.lblCreateDate.Location = New System.Drawing.Point(587, 25)
        Me.lblCreateDate.Name = "lblCreateDate"
        Me.lblCreateDate.Size = New System.Drawing.Size(256, 20)
        Me.lblCreateDate.TabIndex = 50
        Me.lblCreateDate.Tag = "Read"
        '
        'lblUpdateDate
        '
        Me.lblUpdateDate.Location = New System.Drawing.Point(587, 57)
        Me.lblUpdateDate.Name = "lblUpdateDate"
        Me.lblUpdateDate.Size = New System.Drawing.Size(256, 20)
        Me.lblUpdateDate.TabIndex = 51
        Me.lblUpdateDate.Tag = "Read"
        '
        'txtAdjustNo
        '
        Me.txtAdjustNo.Enabled = False
        Me.txtAdjustNo.Location = New System.Drawing.Point(122, 25)
        Me.txtAdjustNo.MaxLength = 10
        Me.txtAdjustNo.Name = "txtAdjustNo"
        Me.txtAdjustNo.Size = New System.Drawing.Size(256, 20)
        Me.txtAdjustNo.TabIndex = 0
        Me.txtAdjustNo.Tag = "Input"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(29, 602)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 20)
        Me.Label14.TabIndex = 139
        Me.Label14.Text = "Search Supplier :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(18, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Adjustment Date :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAdjDate
        '
        Me.txtAdjDate.Enabled = False
        Me.txtAdjDate.Location = New System.Drawing.Point(122, 57)
        Me.txtAdjDate.MaxLength = 10
        Me.txtAdjDate.Name = "txtAdjDate"
        Me.txtAdjDate.Size = New System.Drawing.Size(256, 20)
        Me.txtAdjDate.TabIndex = 78
        Me.txtAdjDate.Tag = "Input"
        '
        'frmAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 648)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label14)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdjustment"
        Me.Text = "Inventory Adjustment Summary"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblUpdateBy As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRowid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCreateDate As System.Windows.Forms.Label
    Friend WithEvents lblUpdateDate As System.Windows.Forms.Label
    Friend WithEvents txtAdjustNo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAdjDate As System.Windows.Forms.TextBox
End Class
