Public Class frmDialogBox
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        cboYear.Value = Year(Now())
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents noEmps As System.Windows.Forms.TextBox
    Friend WithEvents LnoEmps As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LnoEmps = New System.Windows.Forms.Label
        Me.noEmps = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnPreview = New System.Windows.Forms.Button
        Me.cboYear = New System.Windows.Forms.NumericUpDown
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LnoEmps)
        Me.GroupBox1.Controls.Add(Me.noEmps)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnPreview)
        Me.GroupBox1.Controls.Add(Me.cboYear)
        Me.GroupBox1.Controls.Add(Me.cboMonth)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 134)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Commission Date"
        '
        'LnoEmps
        '
        Me.LnoEmps.AutoSize = True
        Me.LnoEmps.Location = New System.Drawing.Point(3, 1084)
        Me.LnoEmps.Name = "LnoEmps"
        Me.LnoEmps.Size = New System.Drawing.Size(117, 16)
        Me.LnoEmps.TabIndex = 10
        Me.LnoEmps.Text = "No. of emp. to share :"
        '
        'noEmps
        '
        Me.noEmps.Location = New System.Drawing.Point(128, 1082)
        Me.noEmps.Name = "noEmps"
        Me.noEmps.Size = New System.Drawing.Size(121, 20)
        Me.noEmps.TabIndex = 3
        Me.noEmps.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(56, 89)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Cancel"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Month :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Year :"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(132, 89)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.TabIndex = 4
        Me.btnPreview.Text = "&Preview"
        '
        'cboYear
        '
        Me.cboYear.Location = New System.Drawing.Point(96, 29)
        Me.cboYear.Maximum = New Decimal(New Integer() {2099, 0, 0, 0})
        Me.cboYear.Minimum = New Decimal(New Integer() {2001, 0, 0, 0})
        Me.cboYear.Name = "cboYear"
        Me.cboYear.TabIndex = 10
        Me.cboYear.Value = New Decimal(New Integer() {2004, 0, 0, 0})
        '
        'cboMonth
        '
        Me.cboMonth.DropDownWidth = 121
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(96, 53)
        Me.cboMonth.MaxDropDownItems = 12
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(120, 21)
        Me.cboMonth.TabIndex = 2
        '
        'frmDialogBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(262, 134)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDialogBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Parameters"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.cboYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public myCommissionDate As String
    Public noEmp As String

    Public Property CommissionDate() As String
        Get
            Return myCommissionDate
        End Get
        Set(ByVal Value As String)
            myCommissionDate = Value
        End Set
    End Property

    Public Property NoOfEmps() As String
        Get
            Return noEmp
        End Get
        Set(ByVal Value As String)
            noEmp = Value
        End Set
    End Property

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim myMain As New Main
        If Trim(cboMonth.Text) = "" Then GoTo errx

        CommissionDate = CStr(cboMonth.SelectedIndex + 1) & "/1/" & cboYear.Text
        NoOfEmps = Trim(noEmps.Text)

        'If CDate(CommissionDate) < #8/1/2004# Then
        '    MessageBox.Show("Scores DotNet System will only process data not earlier than August 2004!", "System Information", _
        '    MessageBoxButtons.OK)
        'Else
        '    Me.Dispose()
        'End If
        Me.Close()
        Exit Sub
errx:
        MsgBox("Please select a month!")
        cboMonth.Select()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cancelProcess = True
        Close()
    End Sub

    Private Sub frmDialogBox_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim myfrm As New frmDialogBox
        myfrm.GroupBox1.Height = 120
        myfrm.Height = 161
        myfrm.noEmps.Top = 1082
        myfrm.LnoEmps.Top = 1084
        myfrm.btnPreview.Top = 80
        myfrm.Button1.Top = 88
    End Sub

    Private Sub noEmps_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles noEmps.Validating
        Try
            Int(noEmps.Text)
        Catch ex As Exception
            MsgBox("This is a number field.Please try again.")
            e.Cancel = True
        End Try
    End Sub

End Class
