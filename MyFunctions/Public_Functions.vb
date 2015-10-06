Imports Microsoft
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection
Module Public_Functions
    Public Function GetCode(ByVal strValue As String) As String
        Dim MyCode As String
        If InStr(strValue, "-") = 0 Then
            Return ""
        Else
            MyCode = Left(strValue, InStr(strValue, "-") - 1)
            Return MyCode
        End If
    End Function

    Public Function GetDescription(ByVal strValue As String) As String
        Dim MyDescription As String
        If InStr(strValue, "-") = 0 Then
            Return ""
        Else
            MyDescription = Mid(strValue, InStr(strValue, "-") + 2)
            Return MyDescription
        End If
    End Function

    Public Function GetCode2(ByVal strValue As String) As String
        Dim MyCode As String
        If InStr(strValue, "-") = 0 Then
            Return strValue
        Else
            MyCode = Left(strValue, InStr(strValue, "-") - 1)
            Return MyCode
        End If
    End Function

    'added-DBrion --v
    Function wHole(ByVal numba As Double) As Boolean
        'for testing if the number is a whole number
        If numba = Int(numba) Then
            wHole = True
        Else
            wHole = False
        End If

    End Function

    Function NxtLineFromComma(ByVal watStr As String, ByVal numstr As String) As String
        Dim strLen As Integer, commaCtr As Integer
        Dim tmpVar As String, cutVar As String
        strLen = Len(watStr)
        If strLen = 0 Then
            NxtLineFromComma = "''"
            Exit Function
        End If
        tmpVar = "" : cutVar = watStr : commaCtr = 0
        Do While Trim(cutVar) <> ""
            If commaCtr = 5 Then
                If numstr = "STR" Then
                    tmpVar = tmpVar & Chr(13) & "'" & Mid(cutVar, 1, InStr(cutVar, ",") - 1) & "',"
                ElseIf numstr = "NUM" Then
                    tmpVar = tmpVar & Mid(cutVar, 1, InStr(cutVar, ","))
                End If
                commaCtr = 1
            Else
                If numstr = "STR" Then
                    tmpVar = tmpVar & "'" & Mid(cutVar, 1, InStr(cutVar, ",") - 1) & "',"
                ElseIf numstr = "NUM" Then
                    tmpVar = tmpVar & Mid(cutVar, 1, InStr(cutVar, ","))
                End If
                commaCtr = commaCtr + 1
            End If
            cutVar = Mid(cutVar, (InStr(cutVar, ",") + 2), (Len(cutVar) - InStr(cutVar, ",")))
        Loop
        NxtLineFromComma = Mid(tmpVar, 1, Len(tmpVar) - 1)
    End Function

    Function GetEOM(ByVal vDate As String) As String
        'for getting the end date of a month
        Dim emem, deedee, waiwai As String
        emem = Mid(Trim(vDate), 1, 2)
        waiwai = Mid(Trim(vDate), 7, 4)
        If Val(emem) = 1 Or Val(emem) = 3 Or Val(emem) = 5 Or Val(emem) = 7 Or _
              Val(emem) = 8 Or Val(emem) = 10 Or Val(emem) = 12 Then
            deedee = "31"
        ElseIf Val(emem) = 4 Or Val(emem) = 6 Or Val(emem) = 9 Or Val(emem) = 11 Then
            deedee = "30"
        ElseIf Val(emem) = 2 Then
            If wHole(Val(waiwai) / 4) = True Then
                deedee = "29"
            Else
                deedee = "28"
            End If
        End If
        GetEOM = emem & "/" & deedee & "/" & waiwai
    End Function

    'Function numkeys(ByVal nk As Integer) As Integer

    '    Dim KeyFound As Integer

    '    numkeys = nk
    '    If nk >= 32 And nk <= 126 Then
    '        KeyFound = InStr(1, "0123456789.+-/", Chr(nk))
    '        If KeyFound = 0 Then
    '            numkeys = 0
    '            Beep()
    '        End If
    '    End If

    'End Function

    Function NumKeys(ByVal actualChr As String, ByVal nk As Object, _
                     Optional ByVal Norm_Int As String = "NORM") As Boolean
        'for determining if a key pressed is numeric
        Dim KeyFound As Integer
        Dim s As Object
        NumKeys = True
        If DKcodes(nk) = True Then
            'nk = KC2int(nk.ToString)
            If KC2int(nk.ToString) = True Then
                If Norm_Int = "NORM" Then
                    KeyFound = InStr(1, "0123456789.+-/", actualChr)
                ElseIf Norm_Int = "INT" Then
                    KeyFound = InStr(1, "0123456789", actualChr)
                End If
            End If
            'If Norm_Int = "NORM" Then
            '    KeyFound = InStr(1, "0123456789.+-/", nk.ToString)
            'ElseIf Norm_Int = "INT" Then
            '    KeyFound = InStr(1, "0123456789", nk.ToString)
            'End If
            If KeyFound = 0 Then
                NumKeys = False
                Beep()
            End If
        End If

    End Function

    Function KC2int(ByVal ik As Object) As Boolean
        If ik.ToString = System.Windows.Forms.Keys.D0.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D1.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D2.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D3.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D4.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D5.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D6.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D7.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D8.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.D9.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.OemPeriod.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.OemMinus.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.Oemplus.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad0.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad1.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad2.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad3.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad4.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad5.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad6.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad7.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad8.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.NumPad9.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.Decimal.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.Add.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.Subtract.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.Multiply.ToString Or _
           ik.ToString = System.Windows.Forms.Keys.Divide.ToString Or _
           ik.ToString = "D8, Shift" Then

            ik = Right(ik.ToString, 1)
            KC2int = True
        Else
            KC2int = False
        End If
    End Function

    Function DKcodes(ByVal dk As Object) As Boolean
        DKcodes = False
        If dk.ToString = System.Windows.Forms.Keys.A.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.B.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.C.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.E.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.F.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.G.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.H.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.I.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.J.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.K.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.L.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.M.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.N.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.O.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.P.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Q.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.R.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.S.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.T.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.U.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.V.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.W.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.X.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Y.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Z.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D0.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D1.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D2.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D3.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D4.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D5.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D6.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D7.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D8.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.D9.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Oemcomma.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.OemPeriod.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.OemQuestion.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.OemPipe.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.OemSemicolon.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.OemQuotes.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.OemOpenBrackets.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.OemCloseBrackets.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Oemtilde.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.OemMinus.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Oemplus.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad0.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad1.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad2.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad3.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad4.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad5.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad6.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad7.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad8.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.NumPad9.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Decimal.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Add.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Subtract.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Multiply.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Divide.ToString Or _
           dk.ToString = System.Windows.Forms.Keys.Space.ToString Then

            DKcodes = True
        ElseIf dk.ToString = System.Windows.Forms.Keys.Shift.ToString Or _
               dk.ToString = System.Windows.Forms.Keys.ControlKey.ToString Then

            DKcodes = False
        End If

    End Function

    'Function AlphaNumChr(ByVal Tx As String) As Boolean
    '    'for checking if a character/(a single string) is alphanumeric
    '    If InStr(1, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ,0123456789+-*/.!@#$%^&*()_=[]{};:'\~<> ", Tx) <> 0 Then
    '        AlphaNumChr = True
    '    Else
    '        AlphaNumChr = False
    '    End If
    'End Function 

    Function jTrim(ByVal pram1 As String) As String
        'for returning "" value if an object or control is null, or replace 1 single quote into 2 so to avoid error
        If IsDBNull(pram1) = True Then
            pram1 = ""
        Else
            If pram1 = "" Then
                jTrim = ""
            Else
                jTrim = StrTran(pram1, "'", "''")
            End If
        End If
    End Function

    Function DatValid(ByVal xdat_val As String) As String
        'for validating if an entry is a valid date
        Dim ErrNow As Boolean
        Dim FldVal As String
        Dim TmpDat As Date
        FldVal = xdat_val.ToString
        FldVal = StrTran$(FldVal, "/", "")
        FldVal = StrTran$(FldVal, "-", "")
        FldVal = StrTran$(FldVal, ".", "")
        ErrNow = False
        If (Len(FldVal) = 7) Or (Len(FldVal) < 6) Then
            GoTo DateTrap
            'DatValid = "mm/dd/yyyy"
            Exit Function
        ElseIf Len(FldVal) = 6 Then
            If jVal(Mid$(FldVal, 5, 2)) <= 30 Then
                FldVal = Mid$(FldVal, 1, 4) & Mid$(Year(Now).ToString, 1, 2) & Mid$(FldVal, 5, 2)
            Else
                FldVal = Mid$(FldVal, 1, 4) & Format(Int(jVal(Mid$(Year(Now).ToString, 1, 2)) - 1)) & Mid$(FldVal, 5, 2)
            End If
        End If
        FldVal = Mid$(FldVal, 1, 2) & "/" & Mid$(FldVal, 3, 2) & "/" & Mid$(FldVal, 5, 4)
        On Error GoTo DateTrap
        TmpDat = CDate(FldVal)
        FldVal = Format$(TmpDat, "MM/dd/yyyy")
        DatValid = FldVal
        Exit Function
DateTrap:
        MsgBox("Invalid Date Entry!", vbCritical)
        DatValid = "mm/dd/yyyy"
        Exit Function
    End Function

    Function StrTran$(ByVal arg1 As Object, ByVal arg2 As Object, ByVal arg3 As Object)
        'for converting a specified char or number of chars 
        'into another string or char from w/in a specified variable/string

        Dim Xstrtran As String, xpoint As Integer, xlen As Integer
        Dim xtemp1 As String, xtemp2 As String
        Xstrtran$ = arg1.ToString
        StrTran$ = arg1.ToString
        xpoint% = 1
        While True
            xpoint% = Strings.InStr(xpoint%, Xstrtran$, arg2.ToString)
            xlen% = Len(arg2)
            If xpoint% > 0 Then
                xtemp1$ = Left$(Xstrtran$, xpoint% - 1)
                xtemp2$ = Right$(Xstrtran$, Len(Xstrtran$) - (xpoint% + (xlen% - 1)))
                Xstrtran$ = xtemp1$ & arg3.ToString & xtemp2$
                xpoint% = xpoint% + Len(arg3)
                StrTran$ = Xstrtran$
            Else
                Exit Function
            End If
        End While
    End Function

    Function jVal(ByVal arg_2 As Object) As Double
        'for returning "0" value if an object or control is null so to avoid error
        If IsDBNull(arg_2) = True Then
            jVal = 0
        Else
            If arg_2.ToString = "" Then
                jVal = 0
            Else
                jVal = Val(StrTran(arg_2, ",", ""))
            End If
        End If
    End Function

    Private Sub CollectParameters(ByVal Params() As SqlParameter, ByVal LocalCommand As SqlCommand)
        Dim i As Integer
        With LocalCommand
            For i = 0 To Params.GetUpperBound(0)
                .Parameters.Add(Params(i))
            Next
        End With
    End Sub

    Public Function ObjectConnection(ByVal StringConnection As String) As SqlConnection
        Dim LocalConnection As New SqlConnection
        With LocalConnection
            .ConnectionString = StringConnection
            .Open()
        End With
        Return LocalConnection
        'LocalConnection.Close()
    End Function

    Public Function Find_w_Param(ByVal StringProcedure As String, _
                                 ByVal Params() As SqlParameter) As String
        'for retreiving a value
        Dim result As String
        Dim LocalCommand As New SqlCommand
        With LocalCommand
            .Connection = ObjectConnection(ServerPath2)
            .CommandText = StringProcedure
            .CommandType = CommandType.StoredProcedure
            If Not Params Is Nothing Then
                CollectParameters(Params, LocalCommand)
            End If
        End With
        Try
            result = LocalCommand.ExecuteScalar.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
            result = ""
            Return result : LocalCommand.Connection.Close()
            Exit Function
        End Try
        Return result : LocalCommand.Transaction.Connection.Close()
    End Function

    Public Function FindValue(ByVal SqlStm As String) As String
        'for retreiving a value
        Dim result As String
        Dim LocalCommand As New SqlCommand
        result = ""
        Dim Params As SqlParameter
        Dim SQLq As New SqlParameter("@SqlQry", SqlDbType.NVarChar, 3000)
        SQLq.Direction = ParameterDirection.Input
        SQLq.Value = SqlStm
        Params = SQLq

        With LocalCommand
            .Connection = ObjectConnection(ServerPath2)
            .CommandText = "GenericQryProc"
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 10000
            .Parameters.Add(Params)
        End With
        Try
            If LocalCommand.ExecuteScalar Is DBNull.Value Or LocalCommand.ExecuteScalar.ToString Is Nothing Then
                result = ""
            Else
                result = LocalCommand.ExecuteScalar.ToString
            End If
        Catch ex As Exception
            'MsgBox(ex.Message) '"Record not found.")
            result = ""
            Return result : LocalCommand.Connection.Close()
            Exit Function
        End Try
        FindValue = result : LocalCommand.Connection.Close()
    End Function

    Public Function Existing(ByVal SqlStm As String) As Boolean
        'for testing if a query returns a value
        Dim result As String
        Dim LocalCommand As New SqlCommand

        Dim Params As SqlParameter
        Dim SQLq As New SqlParameter("@SqlQry", SqlDbType.NVarChar, 3000)
        SQLq.Direction = ParameterDirection.Input
        SQLq.Value = SqlStm
        Params = SQLq

        With LocalCommand
            .Connection = ObjectConnection(ServerPath2)
            .CommandText = "GenericQryProc"
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add(Params)
        End With
        Try
            If LocalCommand.ExecuteScalar Is DBNull.Value Then
                result = ""
            Else
                result = LocalCommand.ExecuteScalar.ToString
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Existing = False
            LocalCommand.Connection.Close()
            Exit Function
        End Try
        If Trim(result) = "" Then
            Existing = False
        Else
            Existing = True
        End If : LocalCommand.Connection.Close()
    End Function

    Public Function GetDateTimeNow(Optional ByVal dt As String = "M/d/yyyy h:mm:ss tt") As String
        'for getting the system date from the server (to avoid tampering)
        Dim result As String
        Dim LocalCommand As New SqlCommand
        With LocalCommand
            .Connection = ObjectConnection(ServerPath2)
            .CommandText = "select getdate() as datnow from datetab where datnow = '01/01/1900'"
            .CommandType = CommandType.Text
        End With
        result = LocalCommand.ExecuteScalar.ToString
        result = Format(CDate(result), dt)
        GetDateTimeNow = result : LocalCommand.Connection.Close()
    End Function

    Public Function RightStr(ByVal str1 As String, ByVal dGits As Integer) As String
        z = Mid(str1, ((Len(str1) - dGits) + 1), dGits)
        RightStr = z
    End Function

    Public Function MoWord(ByVal mo As Double) As String
        If mo = 1 Then
            MoWord = "January"
        ElseIf mo = 2 Then
            MoWord = "February"
        ElseIf mo = 3 Then
            MoWord = "March"
        ElseIf mo = 4 Then
            MoWord = "April"
        ElseIf mo = 5 Then
            MoWord = "May"
        ElseIf mo = 6 Then
            MoWord = "June"
        ElseIf mo = 7 Then
            MoWord = "July"
        ElseIf mo = 8 Then
            MoWord = "August"
        ElseIf mo = 9 Then
            MoWord = "September"
        ElseIf mo = 10 Then
            MoWord = "October"
        ElseIf mo = 11 Then
            MoWord = "November"
        ElseIf mo = 12 Then
            MoWord = "December"
        End If
    End Function

    Public Function MoAbbr(ByVal mo As Double) As String
        If mo = 1 Then
            MoAbbr = "Jan"
        ElseIf mo = 2 Then
            MoAbbr = "Feb"
        ElseIf mo = 3 Then
            MoAbbr = "Mar"
        ElseIf mo = 4 Then
            MoAbbr = "Apr"
        ElseIf mo = 5 Then
            MoAbbr = "May"
        ElseIf mo = 6 Then
            MoAbbr = "Jun"
        ElseIf mo = 7 Then
            MoAbbr = "Jul"
        ElseIf mo = 8 Then
            MoAbbr = "Aug"
        ElseIf mo = 9 Then
            MoAbbr = "Sep"
        ElseIf mo = 10 Then
            MoAbbr = "Oct"
        ElseIf mo = 11 Then
            MoAbbr = "Nov"
        ElseIf mo = 12 Then
            MoAbbr = "Dec"
        End If
    End Function

    Public Sub EnDisMainMenu(ByVal watFrm As Form, ByVal bln As Boolean)
        If Not watFrm.MdiParent Is Nothing Then
            watFrm.MdiParent.Menu.MenuItems.Item(0).Visible = bln     'Enabled = bln
            watFrm.MdiParent.Menu.MenuItems.Item(1).Visible = bln     'Enabled = bln
            watFrm.MdiParent.Menu.MenuItems.Item(2).Visible = bln     'Enabled = bln
            watFrm.MdiParent.Menu.MenuItems.Item(3).Visible = bln     'Enabled = bln
            'watFrm.MdiParent.Menu.MenuItems.Item(4).Visible = bln     'Enabled = bln
        End If
        
    End Sub

    'added-DBrion --^


End Module