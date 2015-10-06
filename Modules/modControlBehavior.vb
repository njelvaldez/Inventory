Module modControlBehavior
    Public Sub EnableControls(ByVal MyForm As Form, ByVal bln As Boolean)
        Dim myControl As Control
        Dim mystring As String
        For Each myControl In MyForm.Controls
            Select Case CStr(myControl.Tag)
                Case "Input"
                    myControl.Enabled = bln
                Case "Line", "Numeric"
                    myControl.Enabled = bln
                Case "View", "Add", "Exit"
                    myControl.Enabled = Not (bln)
                Case "Edit", "Delete"
                    myControl.Enabled = Not (bln)
                    myControl.Visible = Not (bln)
                Case "Cancel", "Save"
                    myControl.Enabled = bln
                    myControl.Visible = bln
            End Select
        Next
    End Sub
    Public Sub EnableLineControls(ByVal MyForm As Form, ByVal bln As Boolean)
        Dim myControl As Control
        Dim mystring As String
        For Each myControl In MyForm.Controls
            Select Case CStr(myControl.Tag)
                Case "Line", "Numeric"
                    myControl.Enabled = bln
                Case "View", "Add", "Exit"
                    myControl.Enabled = Not (bln)
                Case "Edit", "Delete"
                    myControl.Enabled = Not (bln)
                    myControl.Visible = Not (bln)
                Case "Cancel", "Save"
                    myControl.Enabled = bln
                    myControl.Visible = bln
            End Select
        Next
    End Sub

    Public Sub EnableControlsGroup(ByVal MyForm As Form, ByVal bln As Boolean)
        Dim myControl As Control
        Dim mystring As String
        For Each myControl In MyForm.Controls
            Select Case CStr(myControl.Tag)
                Case "Input"
                    myControl.Enabled = bln
                    If bln Then
                        myControl.BackColor = Color.LightYellow
                    Else
                        myControl.BackColor = Color.LightBlue
                    End If
                Case "Line", "Numeric"
                    myControl.Enabled = bln
                Case "View", "Add", "Exit"
                    myControl.Enabled = Not (bln)
                Case "Edit", "Delete"
                    myControl.Enabled = Not (bln)
                    myControl.Visible = Not (bln)
                Case "Cancel", "Save"
                    myControl.Enabled = bln
                    myControl.Visible = bln
                Case "Read"
                    myControl.Enabled = False
            End Select
            If myControl.GetType Is GetType(GroupBox) Then
                For Each subcontrol As Control In myControl.Controls
                    Select Case CStr(subcontrol.Tag)
                        Case "Input"
                            subcontrol.Enabled = bln
                            If bln Then
                                subcontrol.BackColor = Color.LightYellow
                            Else
                                subcontrol.BackColor = Color.LightBlue
                            End If
                        Case "Line", "Numeric"
                            subcontrol.Enabled = bln
                        Case "View", "Add", "Exit"
                            subcontrol.Enabled = Not (bln)
                        Case "Edit", "Delete"
                            subcontrol.Enabled = Not (bln)
                            subcontrol.Visible = Not (bln)
                        Case "Cancel", "Save"
                            subcontrol.Enabled = bln
                            subcontrol.Visible = bln
                        Case "Read"
                            subcontrol.Enabled = False
                    End Select
                Next
            End If
        Next
    End Sub

    Public Sub SetBackgroundControlsGroup(ByVal MyForm As Form)
        Dim myControl As Control
        For Each myControl In MyForm.Controls
            Select Case CStr(myControl.Tag)
                Case "Input"
                    If myControl.Enabled Then
                        myControl.BackColor = Color.LightYellow
                    Else
                        myControl.BackColor = Color.LightBlue
                    End If
                Case "Read"
                    myControl.Enabled = False
                    myControl.BackColor = Color.LightBlue
            End Select
            If myControl.GetType Is GetType(GroupBox) Then
                For Each subcontrol As Control In myControl.Controls
                    Select Case CStr(subcontrol.Tag)
                        Case "Input"
                            If subcontrol.Enabled Then
                                subcontrol.BackColor = Color.LightYellow
                            Else
                                subcontrol.BackColor = Color.LightBlue
                            End If
                        Case "Read"
                            subcontrol.Enabled = False
                            subcontrol.BackColor = Color.LightBlue
                    End Select
                Next
            End If
        Next
    End Sub

End Module

