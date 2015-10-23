<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockOverview
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnopentemplate2 = New System.Windows.Forms.Button()
        Me.btnopenreport = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTemplate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnopentemplate2)
        Me.GroupBox5.Controls.Add(Me.btnopenreport)
        Me.GroupBox5.Controls.Add(Me.txtOutput)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txtTemplate)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(960, 97)
        Me.GroupBox5.TabIndex = 161
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Item"
        '
        'btnopentemplate2
        '
        Me.btnopentemplate2.Image = Global.TradeInventory.My.Resources.Resources.search_icon_new
        Me.btnopentemplate2.Location = New System.Drawing.Point(528, 20)
        Me.btnopentemplate2.Name = "btnopentemplate2"
        Me.btnopentemplate2.Size = New System.Drawing.Size(43, 22)
        Me.btnopentemplate2.TabIndex = 51
        Me.btnopentemplate2.UseVisualStyleBackColor = True
        '
        'btnopenreport
        '
        Me.btnopenreport.Image = Global.TradeInventory.My.Resources.Resources.search_icon_new
        Me.btnopenreport.Location = New System.Drawing.Point(528, 48)
        Me.btnopenreport.Name = "btnopenreport"
        Me.btnopenreport.Size = New System.Drawing.Size(43, 22)
        Me.btnopenreport.TabIndex = 50
        Me.btnopenreport.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Enabled = False
        Me.txtOutput.Location = New System.Drawing.Point(116, 48)
        Me.txtOutput.MaxLength = 100
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(406, 23)
        Me.txtOutput.TabIndex = 48
        Me.txtOutput.Tag = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(12, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 20)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Report Output :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTemplate
        '
        Me.txtTemplate.Enabled = False
        Me.txtTemplate.Location = New System.Drawing.Point(116, 19)
        Me.txtTemplate.MaxLength = 100
        Me.txtTemplate.Multiline = True
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Size = New System.Drawing.Size(406, 23)
        Me.txtTemplate.TabIndex = 46
        Me.txtTemplate.Tag = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Report Template :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGrid1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(962, 470)
        Me.GroupBox1.TabIndex = 164
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inventory List"
        '
        'DataGrid1
        '
        Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(9, 22)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.Size = New System.Drawing.Size(947, 442)
        Me.DataGrid1.TabIndex = 6
        Me.DataGrid1.Tag = "View"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(882, 603)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(86, 34)
        Me.cmdExit.TabIndex = 163
        Me.cmdExit.Tag = "Exit"
        Me.cmdExit.Text = "E&xit"
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Image = Global.TradeInventory.My.Resources.Resources.Product_sale_report_icon
        Me.BtnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGenerate.Location = New System.Drawing.Point(790, 603)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(86, 34)
        Me.BtnGenerate.TabIndex = 162
        Me.BtnGenerate.Tag = "Add"
        Me.BtnGenerate.Text = "   &Generate"
        '
        'frmStockOverview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 648)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "frmStockOverview"
        Me.Text = "Stock Overview"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnopentemplate2 As System.Windows.Forms.Button
    Friend WithEvents btnopenreport As System.Windows.Forms.Button
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTemplate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents BtnGenerate As System.Windows.Forms.Button
End Class
