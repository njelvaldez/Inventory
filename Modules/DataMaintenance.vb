Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Text

Module DataMaintenance
    Private m_ParamArray(100, 5) As Object
    Private _existingMDSTransaction As New ArrayList
    Public Property ExistingMDSTransaction() As ArrayList
        Get
            Return _existingMDSTransaction
        End Get
        Set(ByVal Value As ArrayList)
            _existingMDSTransaction.Add(Value)
        End Set
    End Property

    Public Property myParamArray(ByVal index1 As Integer, ByVal index2 As Integer) As Object
        Get
            Return m_ParamArray(index1, index2)
        End Get
        Set(ByVal Value As Object)
            'Redim Preserve to increase the indices
            m_ParamArray(index1, index2) = Value
        End Set
    End Property

    Public Function objConnection(ByVal strConnection As String) As SqlConnection
        Dim myConnection As New SqlConnection
        With myConnection
            .ConnectionString = strConnection
            .Open()
        End With
        Return myConnection
        myConnection.Close()
    End Function

    Public Function ExecuteCommand(ByVal strConnection As String, _
    ByVal strCommand As String, ByVal CommandType As CommandType, _
    Optional ByVal ParamNum As Integer = 0) As Boolean
        Dim objCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim i As Integer
        Try
            With objCommand
                .Connection = objConnection(strConnection)
                .CommandText = strCommand
                .CommandType = CommandType
                .CommandTimeout = 0
                If CommandType = CommandType.StoredProcedure Then
                    For i = 1 To ParamNum
                        .Parameters.Add(CollectParameters(i - 1))
                    Next
                End If
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MessageBox.Show(FormatErrorMessage(ex.Message, strCommand, "ExecuteCommand"))
            'objCommand.ResetCommandTimeout()
            'objCommand.Cancel()
            myConnection.Dispose()
            Return False
        End Try
        'objCommand.ResetCommandTimeout()
        'objCommand.Cancel()
        'myConnection.Dispose()
        objCommand.Connection.Dispose()

        Return True
    End Function

    Public Function GetSingleResult(ByVal strConnection As String, _
        ByVal strCommand As String, ByVal CommandType As CommandType, _
        Optional ByVal ParamNum As Integer = 0) As Decimal
        Dim objCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim i As Integer
        Dim mySingleResult As Decimal
        Try
            With objCommand
                .Connection = objConnection(strConnection)
                .CommandText = strCommand
                .CommandType = CommandType
                .CommandTimeout = 0
                If CommandType = CommandType.StoredProcedure Then
                    For i = 1 To ParamNum
                        .Parameters.Add(CollectParameters(i - 1))
                    Next
                End If
                mySingleResult = CDec(.ExecuteScalar())
            End With
        Catch ex As Exception
            MessageBox.Show(FormatErrorMessage(ex.Message, strCommand, "GetSingleResult"))
            myConnection.Close()
            Exit Function
        End Try
        myConnection.Close()
        objCommand.Connection.Dispose()
        Return mySingleResult
    End Function

    Public Function GetResultSet(ByVal strConnection As String, _
        ByVal strCommand As String, ByVal CommandType As CommandType, _
        Optional ByVal ParamNum As Integer = 0) As SqlDataReader
        Dim objCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim i As Integer
        Dim myResultSet As SqlDataReader

        Try
            With objCommand
                .Connection = objConnection(strConnection)
                .CommandText = strCommand
                .CommandType = CommandType
                .CommandTimeout = 0
                If CommandType = CommandType.StoredProcedure Then
                    For i = 1 To ParamNum
                        .Parameters.Add(CollectParameters(i - 1))
                    Next
                End If
                myResultSet = .ExecuteReader()
            End With
        Catch ex As Exception
            MessageBox.Show(FormatErrorMessage(ex.Message, strCommand, "GetResultSet"))
            myConnection.Close()
            Exit Function
        End Try
        myConnection.Close()
        Return myResultSet
    End Function

    Private Function CollectParameters(ByVal StartAt As Integer) As SqlParameter
        Dim myParameters As New SqlParameter
        Dim myValue As Object
        With myParameters
            .ParameterName = CStr(myParamArray(StartAt, 0))
            .SqlDbType = CType(myParamArray(StartAt, 1), SqlDbType)
            .Size = CInt(myParamArray(StartAt, 2))
            .Direction = CType(myParamArray(StartAt, 3), ParameterDirection)
            Select Case CStr(myParamArray(StartAt, 4))
                Case "String"
                    .Value = CStr(myParamArray(StartAt, 5))
                Case "Date"
                    .Value = IIf(CStr(myParamArray(StartAt, 5)) = String.Empty, "", CDate(myParamArray(StartAt, 5)))
                Case "Integer"
                    .Value = CInt(myParamArray(StartAt, 5))
            End Select
        End With
        Return myParameters
    End Function

    Public Function GetDataTable(ByVal strConnection As String, _
        ByVal strCommand As String, ByVal CommandType As CommandType, _
        Optional ByVal ParamNum As Integer = 0) As DataTable
        Dim objCommand As New SqlCommand
        Dim i As Integer
        Dim myResultSet As New DataTable
        Dim myDataAdapter As New SqlDataAdapter

        Try
            With objCommand
                .Connection = objConnection(strConnection)
                .CommandText = strCommand
                .CommandType = CommandType
                If CommandType = CommandType.StoredProcedure Then
                    For i = 1 To ParamNum
                        .Parameters.Add(CollectParameters(i - 1))
                    Next
                End If
            End With
            myDataAdapter.SelectCommand = objCommand
            myDataAdapter.Fill(myResultSet)
        Catch ex As Exception
            MessageBox.Show(FormatErrorMessage(ex.Message, strCommand, "GetDataTable"))
            Exit Function
        End Try
        Return myResultSet
    End Function

    Public Function ExecuteCommand_WithOutPut(ByVal strConnection As String, _
    ByVal strCommand As String, ByVal CommandType As CommandType, _
    Optional ByVal ParamNum As Integer = 0) As Object
        Dim myObject As Object
        Dim objCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim i As Integer
        Try
            With objCommand
                .Connection = objConnection(strConnection)
                .CommandText = strCommand
                .CommandType = CommandType
                If CommandType = CommandType.StoredProcedure Then
                    For i = 1 To ParamNum
                        .Parameters.Add(CollectParameters(i - 1))
                    Next
                End If
                .ExecuteNonQuery()
                'find the output parameter
                Dim myparam As SqlParameter
                For Each myparam In objCommand.Parameters
                    If myparam.Direction = ParameterDirection.Output Then
                        myObject = myparam.Value
                    End If
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(FormatErrorMessage(ex.Message, strCommand, "ExecuteCommand_WithOutPut"))
            myConnection.Close()
            Exit Function
        End Try
        myConnection.Close()
        objCommand.Connection.Dispose()
        Return myObject
    End Function

    Public Sub Process_TextFile(ByVal myParameters As Collection)
        Dim myParameter As SqlParameter
        For Each myParameter In myParameters
            MessageBox.Show(myParameter.ParameterName)
        Next
    End Sub

    'Step# 1
    Public Sub Receive_TextString_ForNewFieldLength(ByVal myString As String)
        Dim myArray() As String
        Dim delimeterChar As String = Chr(10)
        Dim delimeter As Char() = delimeterChar.ToCharArray
        Dim i As Integer
        Dim line As String = ""

        myArray = myString.Split(delimeter)
        Dim myCommand As New SqlCommand
        With myCommand
            .CommandText = "Insert_TextFile_ForNewFieldLength"
            .CommandType = CommandType.StoredProcedure
        End With
        'append the parameters
        Dim comp As New SqlParameter("@comp", SqlDbType.VarChar, 4) : myCommand.Parameters.Add(comp)
        Dim bran As New SqlParameter("@bran", SqlDbType.VarChar, 4) : myCommand.Parameters.Add(bran)
        Dim bnam As New SqlParameter("@bnam", SqlDbType.VarChar, 24) : myCommand.Parameters.Add(bnam)
        Dim cusno As New SqlParameter("@cusno", SqlDbType.VarChar, 10) : myCommand.Parameters.Add(cusno)
        Dim cnam As New SqlParameter("@cnam", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(cnam)
        Dim cad1 As New SqlParameter("@cad1", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(cad1)
        Dim cad2 As New SqlParameter("@cad2", SqlDbType.VarChar, 50) : cad2.Value = Mid(line, 136, 50)
        : myCommand.Parameters.Add(cad2)
        Dim dyer As New SqlParameter("@dyer", SqlDbType.Char, 10) : myCommand.Parameters.Add(dyer)
        Dim docno As New SqlParameter("@docno", SqlDbType.VarChar, 10) : myCommand.Parameters.Add(docno)
        Dim rfcd As New SqlParameter("@rfcd", SqlDbType.VarChar, 4) : myCommand.Parameters.Add(rfcd)
        Dim prod As New SqlParameter("@prod", SqlDbType.VarChar, 20) : myCommand.Parameters.Add(prod)
        Dim pdes As New SqlParameter("@pdes", SqlDbType.VarChar, 20) : myCommand.Parameters.Add(pdes)
        Dim whse As New SqlParameter("@whse", SqlDbType.VarChar, 4) : myCommand.Parameters.Add(whse)
        Dim clas As New SqlParameter("@clas", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(clas)
        Dim qtso As New SqlParameter("@qtso", SqlDbType.Int) : myCommand.Parameters.Add(qtso)
        Dim qtfr As New SqlParameter("@qtfr", SqlDbType.Int) : myCommand.Parameters.Add(qtfr)
        Dim vlam As New SqlParameter("@vlam", SqlDbType.Money) : myCommand.Parameters.Add(vlam)
        Dim dsct As New SqlParameter("@dsct", SqlDbType.Int) : myCommand.Parameters.Add(dsct)
        Dim pdsc As New SqlParameter("@pdsc", SqlDbType.Money) : myCommand.Parameters.Add(pdsc)
        Dim cvat As New SqlParameter("@cvat", SqlDbType.Char, 16) : myCommand.Parameters.Add(cvat)
        Dim rout As New SqlParameter("@rout", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(rout)
        Dim taxs As New SqlParameter("@taxs", SqlDbType.Money, 13) : myCommand.Parameters.Add(taxs)
        Dim fret As New SqlParameter("@fret", SqlDbType.Money, 13) : myCommand.Parameters.Add(fret)
        Dim adtl As New SqlParameter("@adtl", SqlDbType.Char, 19) : myCommand.Parameters.Add(adtl)
        Dim pnet As New SqlParameter("@pnet", SqlDbType.Money, 13) : myCommand.Parameters.Add(pnet)
        Dim uprc As New SqlParameter("@uprc", SqlDbType.Money, 13) : myCommand.Parameters.Add(uprc)
        Dim ref1 As New SqlParameter("@ref1", SqlDbType.VarChar, 10) : myCommand.Parameters.Add(ref1)
        Dim cmcd As New SqlParameter("@cmcd", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(cmcd)
        Dim ref2 As New SqlParameter("@ref2", SqlDbType.VarChar, 10) : myCommand.Parameters.Add(ref2)
        Dim sodt As New SqlParameter("@sodt", SqlDbType.Char, 10) : myCommand.Parameters.Add(sodt)
        Dim term As New SqlParameter("@term", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(term)
        Dim edte As New SqlParameter("@edte", SqlDbType.Char, 10) : myCommand.Parameters.Add(edte)
        Dim lotno As New SqlParameter("@lotno", SqlDbType.VarChar, 15) : myCommand.Parameters.Add(lotno)
        Dim slmno As New SqlParameter("@slmno", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(slmno)
        Dim slnm As New SqlParameter("@slnm", SqlDbType.VarChar, 24) : myCommand.Parameters.Add(slnm)
        Dim shipto As New SqlParameter("@shipto", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(shipto)
        Dim sad1 As New SqlParameter("@sad1", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(sad1)
        Dim sad2 As New SqlParameter("@sad2", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(sad2)
        Dim zipc As New SqlParameter("@zipc", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(zipc)
        Dim terno As New SqlParameter("@terno", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(terno)
        Dim area As New SqlParameter("@area", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(area)
        Dim ccls As New SqlParameter("@ccls", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(ccls)
        Dim clsn As New SqlParameter("@clsn", SqlDbType.VarChar, 24) : myCommand.Parameters.Add(clsn)
        Dim prin As New SqlParameter("@prin", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(prin)
        Dim sprn As New SqlParameter("@sprn", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(sprn)
        Dim prdc As New SqlParameter("@prdc", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(prdc)
        Dim swek As New SqlParameter("@swek", SqlDbType.VarChar, 1) : myCommand.Parameters.Add(swek)
        'Start  JF 9/11/20103
        'Adding new parameters for fields not included from flat file
        Dim zcda As New SqlParameter("@zcda", SqlDbType.VarChar, 10) : myCommand.Parameters.Add(zcda)
        Dim zinip As New SqlParameter("@zinip", SqlDbType.Money, 13) : myCommand.Parameters.Add(zinip)
        Dim indpac As New SqlParameter("@indpac", SqlDbType.VarChar, 15) : myCommand.Parameters.Add(indpac)
        Dim indseq As New SqlParameter("@indseq", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(indseq)
        'End    JF 9/11/20103

        'Start  JF 9/11/20103
        'Adjusting field position(s) to accomodate new field lengths
        myCommand.Connection = objConnection(ServerPath2)
        Dim StartPosition As Integer = 1
        Dim sw As StreamWriter
        For i = 0 To (myArray.GetUpperBound(0)) - 1
            line = myArray(i)
            comp.Value = Mid(line, StartPosition, 4) : StartPosition += 4
            bran.Value = Mid(line, StartPosition, 4) : StartPosition += 4
            bnam.Value = Mid(line, StartPosition, 24) : StartPosition += 24
            cusno.Value = Mid(line, StartPosition, 10) : StartPosition += 10
            cnam.Value = Mid(line, StartPosition, 50) : StartPosition += 50
            cad1.Value = Mid(line, StartPosition, 50) : StartPosition += 50
            cad2.Value = Mid(line, StartPosition, 50) : StartPosition += 50
            dyer.Value = Mid(line, StartPosition, 8) : StartPosition += 8
            docno.Value = Mid(line, StartPosition, 10) : StartPosition += 10
            rfcd.Value = Mid(line, StartPosition, 4) : StartPosition += 4
            prod.Value = Mid(line, StartPosition, 20) : StartPosition += 20
            pdes.Value = Mid(line, StartPosition, 20) : StartPosition += 20
            whse.Value = Mid(line, StartPosition, 4) : StartPosition += 4
            clas.Value = Mid(line, StartPosition, 3) : StartPosition += 3
            qtso.Value = Mid(line, StartPosition, 9) : StartPosition += 9
            qtfr.Value = Mid(line, StartPosition, 9) : StartPosition += 9
            vlam.Value = Mid(line, StartPosition, 13) : StartPosition += 13
            dsct.Value = Mid(line, StartPosition, 7) : StartPosition += 7
            pdsc.Value = Mid(line, StartPosition, 13) : StartPosition += 13
            cvat.Value = Mid(line, StartPosition, 1) : StartPosition += 1
            rout.Value = Mid(line, StartPosition, 6) : StartPosition += 6
            taxs.Value = Mid(line, StartPosition, 13) : StartPosition += 13
            fret.Value = Mid(line, StartPosition, 13) : StartPosition += 13
            adtl.Value = Mid(line, StartPosition, 13) : StartPosition += 13
            pnet.Value = Mid(line, StartPosition, 13) : StartPosition += 13
            uprc.Value = Mid(line, StartPosition, 9) : StartPosition += 9
            ref1.Value = Mid(line, StartPosition, 10) : StartPosition += 10
            cmcd.Value = Mid(line, StartPosition, 3) : StartPosition += 3
            ref2.Value = Mid(line, StartPosition, 10) : StartPosition += 10
            sodt.Value = Mid(line, StartPosition, 8) : StartPosition += 8
            term.Value = Mid(line, StartPosition, 6) : StartPosition += 6
            edte.Value = Mid(line, StartPosition, 8) : StartPosition += 8
            lotno.Value = Mid(line, StartPosition, 15) : StartPosition += 15
            slmno.Value = Mid(line, StartPosition, 4) : StartPosition += 4
            slnm.Value = Mid(line, StartPosition, 24) : StartPosition += 24
            shipto.Value = Mid(line, StartPosition, 50) : StartPosition += 50
            sad1.Value = Mid(line, StartPosition, 50) : StartPosition += 50
            sad2.Value = Mid(line, StartPosition, 50) : StartPosition += 50
            zipc.Value = Mid(line, StartPosition, 6) : StartPosition += 6
            terno.Value = Mid(line, StartPosition, 3) : StartPosition += 3
            area.Value = Mid(line, StartPosition, 3) : StartPosition += 3
            ccls.Value = Mid(line, StartPosition, 3) : StartPosition += 3
            clsn.Value = Mid(line, StartPosition, 24) : StartPosition += 24
            prin.Value = Mid(line, StartPosition, 6) : StartPosition += 6
            sprn.Value = Mid(line, StartPosition, 6) : StartPosition += 6
            prdc.Value = Mid(line, StartPosition, 3) : StartPosition += 3
            swek.Value = Mid(line, StartPosition, 1) : StartPosition += 1
            zcda.Value = Mid(line, StartPosition, 10) : StartPosition += 10
            zinip.Value = Mid(line, StartPosition, 9) : StartPosition += 9
            indpac.Value = Mid(line, StartPosition, 15) : StartPosition += 15
            indseq.Value = Mid(line, StartPosition, 6)

            Try
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                'MessageBox.Show(ex.Message.ToString(), "Receive_TextString_ForNewFieldLength()", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If File.Exists(Application.StartupPath & "\" & "ScoresDotNet_Log.txt") Then
                    sw = File.AppendText(Application.StartupPath & "\" & "ScoresDotNet_Log.txt")
                Else
                    sw = New StreamWriter(Application.StartupPath & "\" & "ScoresDotNet_Log.txt")
                End If

                With sw
                    Dim myStringBuilder As New StringBuilder
                    With myStringBuilder
                        .Append(Now.ToString())
                        .Append(ControlChars.NewLine & "Error Inserting to Table(MetroDrugSale) at Row : " & (i + 1).ToString())
                        .Append(ControlChars.NewLine & "Customer : " & CStr(cusno.Value))
                        .Append(ControlChars.NewLine & "Ref 1: " & CStr(ref1.Value))
                        .Append(ControlChars.NewLine & "Ref 2: " & CStr(ref2.Value))
                        .Append(ControlChars.NewLine & "IndSeq : " & CStr(indseq.Value))
                    End With
                    .WriteLine(myStringBuilder.ToString())
                End With
                sw.Close()

            End Try
            StartPosition = 1
            'End    JF 9/11/20103

            'Check here if there's existing data already. Provide info to user if found.
            'If Check_ExistingRecord(CStr(ref1.Value), CStr(ref2.Value), CStr(prod.Value), CStr(indseq.Value)) = True Then

            '    Dim RowData As New StringBuilder
            '    With RowData
            '        .Append("Company            : " & CStr(ExistingMDSTransaction(0)) & vbCrLf)
            '        .Append("Branch Code        : " & CStr(ExistingMDSTransaction(1)) & vbCrLf)
            '        .Append("Branch Name        : " & CStr(ExistingMDSTransaction(2)) & vbCrLf)
            '        .Append("Customer #         : " & CStr(ExistingMDSTransaction(3)) & vbCrLf)
            '        .Append("Customer Name      : " & CStr(ExistingMDSTransaction(4)) & vbCrLf)
            '        .Append("Transaction Date   : " & CStr(ExistingMDSTransaction(5)) & vbCrLf)
            '        .Append("Invoice Number     : " & CStr(ExistingMDSTransaction(6)) & vbCrLf)
            '        .Append("Transaction Type   : " & CStr(ExistingMDSTransaction(7)) & vbCrLf)
            '        .Append("Product            : " & CStr(ExistingMDSTransaction(8)) & vbCrLf)
            '        .Append("Net Amount         : " & CStr(ExistingMDSTransaction(9)) & vbCrLf)
            '        .Append("Invoice Ref Number : " & CStr(ExistingMDSTransaction(10)) & vbCrLf)
            '        .Append("Sales Order Number : " & CStr(ExistingMDSTransaction(11)) & vbCrLf)
            '        .Append("Rowid              : " & CStr(ExistingMDSTransaction(12)))
            '    End With
            '    If MessageBox.Show(RowData.ToString(), "Duplicate transaction(s) found from file : " & _
            '    CStr(ExistingMDSTransaction(13)) & "!" & _
            '    " Proceed to overwrite?", MessageBoxButtons.YesNo, _
            '    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.No Then
            '        StartPosition = 1
            '        GoTo Skip
            '    Else
            '        Delete_ExistingRecord(CInt(ExistingMDSTransaction(12)))
            '    End If
            '    StartPosition = 1
            'End If

        Next
        If File.Exists(Application.StartupPath & "\" & "ScoresDotNet_Log.txt") Then
            sw = File.AppendText(Application.StartupPath & "\" & "ScoresDotNet_Log.txt")
        Else
            sw = New StreamWriter(Application.StartupPath & "\" & "ScoresDotNet_Log.txt")
        End If
        sw.WriteLine("***********************************************************")
        sw.WriteLine("Text File processing completed at (" & Now.ToString() & ")")
        sw.WriteLine("***********************************************************")
        sw.Close()
    End Sub

    Private Sub Delete_ExistingRecord(ByVal Rowid As Integer)

        Dim StrCommand As String = "DELETE FROM MetroDrugSale WHERE Rowid = " & Rowid
        DataMaintenance.ExecuteCommand(ServerPath2, StrCommand, CommandType.Text)

    End Sub


    Private Function Check_ExistingRecord(ByVal Ref1 As String, ByVal Ref2 As String, ByVal Prod As String, ByVal IndSeq As String) As Boolean
        Dim Rows As SqlDataReader
        Dim Params(1) As Object
        DataMaintenance.myParamArray(0, 0) = "@Ref1"
        DataMaintenance.myParamArray(0, 1) = SqlDbType.VarChar
        DataMaintenance.myParamArray(0, 2) = 10
        DataMaintenance.myParamArray(0, 3) = ParameterDirection.Input
        DataMaintenance.myParamArray(0, 4) = "String"
        DataMaintenance.myParamArray(0, 5) = Ref1

        DataMaintenance.myParamArray(1, 0) = "@Ref2"
        DataMaintenance.myParamArray(1, 1) = SqlDbType.VarChar
        DataMaintenance.myParamArray(1, 2) = 10
        DataMaintenance.myParamArray(1, 3) = ParameterDirection.Input
        DataMaintenance.myParamArray(1, 4) = "String"
        DataMaintenance.myParamArray(1, 5) = Ref2

        DataMaintenance.myParamArray(2, 0) = "@Prod"
        DataMaintenance.myParamArray(2, 1) = SqlDbType.VarChar
        DataMaintenance.myParamArray(2, 2) = 20
        DataMaintenance.myParamArray(2, 3) = ParameterDirection.Input
        DataMaintenance.myParamArray(2, 4) = "String"
        DataMaintenance.myParamArray(2, 5) = Prod

        DataMaintenance.myParamArray(3, 0) = "@IndSeq"
        DataMaintenance.myParamArray(3, 1) = SqlDbType.VarChar
        DataMaintenance.myParamArray(3, 2) = 6
        DataMaintenance.myParamArray(3, 3) = ParameterDirection.Input
        DataMaintenance.myParamArray(3, 4) = "String"
        DataMaintenance.myParamArray(3, 5) = IndSeq

        Rows = DataMaintenance.GetResultSet(ServerPath2, "CheckExistingMetroDrugSaleTransaction", CommandType.StoredProcedure, 4)
        Dim intResult As Integer
        'Refresh the contents of the ArrayList
        If ExistingMDSTransaction.Count > 0 Then ExistingMDSTransaction.Clear()
        While Rows.Read
            With ExistingMDSTransaction
                intResult = .Add(CStr(Rows("Comp")))
                intResult = .Add(CStr(Rows("Bran")))
                intResult = .Add(CStr(Rows("Bnam")))
                intResult = .Add(CStr(Rows("Cus#")))
                intResult = .Add(CStr(Rows("Cnam")))
                intResult = .Add(CStr(Rows("Dyer")))
                intResult = .Add(CStr(Rows("Doc#")))
                intResult = .Add(CStr(Rows("Rfcd")))
                intResult = .Add(CStr(Rows("Prod")))
                intResult = .Add(CStr(Rows("Pnet")))
                intResult = .Add(CStr(Rows("Ref1")))
                intResult = .Add(CStr(Rows("Ref2")))
                intResult = .Add(CStr(Rows("Rowid")))
                intResult = .Add(CStr(Rows("FromFile")))
            End With
        End While
        Return CBool(IIf(Rows.HasRows, True, False))

    End Function

    Public Sub Receive_TextString(ByVal myString As String)
        Dim myArray() As String
        Dim delimeterChar As String = Chr(10)
        Dim delimeter As Char() = delimeterChar.ToCharArray
        Dim i As Integer
        Dim line As String = ""

        myArray = myString.Split(delimeter)
        Dim myCommand As New SqlCommand
        With myCommand
            .CommandText = "Insert_TextFile"
            .CommandType = CommandType.StoredProcedure
        End With
        'append the parameters
        Dim comp As New SqlParameter("@comp", SqlDbType.VarChar, 2) : myCommand.Parameters.Add(comp)
        Dim bran As New SqlParameter("@bran", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(bran)
        Dim bnam As New SqlParameter("@bnam", SqlDbType.VarChar, 24) : myCommand.Parameters.Add(bnam)
        Dim cusno As New SqlParameter("@cusno", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(cusno)
        Dim cnam As New SqlParameter("@cnam", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(cnam)
        Dim cad1 As New SqlParameter("@cad1", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(cad1)
        Dim cad2 As New SqlParameter("@cad2", SqlDbType.VarChar, 50) : cad2.Value = Mid(line, 136, 50) : myCommand.Parameters.Add(cad2)
        Dim dyer As New SqlParameter("@dyer", SqlDbType.Char, 10) : myCommand.Parameters.Add(dyer)
        Dim docno As New SqlParameter("@docno", SqlDbType.VarChar, 8) : myCommand.Parameters.Add(docno)
        Dim rfcd As New SqlParameter("@rfcd", SqlDbType.VarChar, 2) : myCommand.Parameters.Add(rfcd)
        Dim prod As New SqlParameter("@prod", SqlDbType.VarChar, 20) : myCommand.Parameters.Add(prod)
        Dim pdes As New SqlParameter("@pdes", SqlDbType.VarChar, 20) : myCommand.Parameters.Add(pdes)
        Dim whse As New SqlParameter("@whse", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(whse)
        Dim clas As New SqlParameter("@clas", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(clas)
        Dim qtso As New SqlParameter("@qtso", SqlDbType.Int) : myCommand.Parameters.Add(qtso)
        Dim qtfr As New SqlParameter("@qtfr", SqlDbType.Int) : myCommand.Parameters.Add(qtfr)
        Dim vlam As New SqlParameter("@vlam", SqlDbType.Money) : myCommand.Parameters.Add(vlam)
        Dim dsct As New SqlParameter("@dsct", SqlDbType.Int) : myCommand.Parameters.Add(dsct)
        Dim pdsc As New SqlParameter("@pdsc", SqlDbType.Money) : myCommand.Parameters.Add(pdsc)
        Dim cvat As New SqlParameter("@cvat", SqlDbType.Char, 1) : myCommand.Parameters.Add(cvat)
        Dim rout As New SqlParameter("@rout", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(rout)
        Dim taxs As New SqlParameter("@taxs", SqlDbType.Money, 13) : myCommand.Parameters.Add(taxs)
        Dim fret As New SqlParameter("@fret", SqlDbType.Money, 13) : myCommand.Parameters.Add(fret)
        Dim adtl As New SqlParameter("@adtl", SqlDbType.Char, 19) : myCommand.Parameters.Add(adtl)
        Dim pnet As New SqlParameter("@pnet", SqlDbType.Money, 13) : myCommand.Parameters.Add(pnet)
        Dim uprc As New SqlParameter("@uprc", SqlDbType.Money, 9) : myCommand.Parameters.Add(uprc)
        Dim ref1 As New SqlParameter("@ref1", SqlDbType.VarChar, 8) : myCommand.Parameters.Add(ref1)
        Dim cmcd As New SqlParameter("@cmcd", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(cmcd)
        Dim ref2 As New SqlParameter("@ref2", SqlDbType.VarChar, 8) : myCommand.Parameters.Add(ref2)
        Dim sodt As New SqlParameter("@sodt", SqlDbType.Char, 10) : myCommand.Parameters.Add(sodt)
        Dim term As New SqlParameter("@term", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(term)
        Dim edte As New SqlParameter("@edte", SqlDbType.Char, 10) : myCommand.Parameters.Add(edte)
        Dim lotno As New SqlParameter("@lotno", SqlDbType.VarChar, 15) : myCommand.Parameters.Add(lotno)
        Dim slmno As New SqlParameter("@slmno", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(slmno)
        Dim slnm As New SqlParameter("@slnm", SqlDbType.VarChar, 24) : myCommand.Parameters.Add(slnm)
        Dim shipto As New SqlParameter("@shipto", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(shipto)
        Dim sad1 As New SqlParameter("@sad1", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(sad1)
        Dim sad2 As New SqlParameter("@sad2", SqlDbType.VarChar, 50) : myCommand.Parameters.Add(sad2)
        Dim zipc As New SqlParameter("@zipc", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(zipc)
        Dim terno As New SqlParameter("@terno", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(terno)
        Dim area As New SqlParameter("@area", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(area)
        Dim ccls As New SqlParameter("@ccls", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(ccls)
        Dim clsn As New SqlParameter("@clsn", SqlDbType.VarChar, 24) : myCommand.Parameters.Add(clsn)
        Dim prin As New SqlParameter("@prin", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(prin)
        Dim sprn As New SqlParameter("@sprn", SqlDbType.VarChar, 6) : myCommand.Parameters.Add(sprn)
        Dim prdc As New SqlParameter("@prdc", SqlDbType.VarChar, 3) : myCommand.Parameters.Add(prdc)
        Dim swek As New SqlParameter("@swek", SqlDbType.VarChar, 1) : myCommand.Parameters.Add(swek)
        myCommand.Connection = objConnection(ServerPath2)
        For i = 0 To (myArray.GetUpperBound(0)) - 1
            line = myArray(i)
            comp.Value = Mid(line, 1, 2)
            bran.Value = Mid(line, 3, 3)
            bnam.Value = Mid(line, 6, 24)
            cusno.Value = Mid(line, 30, 6)
            cnam.Value = Mid(line, 36, 50)
            cad1.Value = Mid(line, 86, 50)
            cad2.Value = Mid(line, 136, 50)
            dyer.Value = Mid(line, 186, 8)
            docno.Value = Mid(line, 194, 8)
            rfcd.Value = Mid(line, 202, 2)
            prod.Value = Mid(line, 204, 20)
            pdes.Value = Mid(line, 224, 20)
            whse.Value = Mid(line, 244, 3)
            clas.Value = Mid(line, 247, 3)
            qtso.Value = Mid(line, 250, 9)
            qtfr.Value = Mid(line, 259, 9)
            vlam.Value = Mid(line, 268, 11)
            dsct.Value = Mid(line, 281, 7)
            pdsc.Value = Mid(line, 288, 13)
            cvat.Value = Mid(line, 301, 1)
            rout.Value = Mid(line, 302, 6)
            taxs.Value = Mid(line, 308, 13)
            fret.Value = Mid(line, 321, 13)
            adtl.Value = Mid(line, 334, 13)
            pnet.Value = Mid(line, 347, 13)
            uprc.Value = Mid(line, 360, 9)
            ref1.Value = Mid(line, 369, 8)
            cmcd.Value = Mid(line, 377, 3)
            ref2.Value = Mid(line, 380, 8)
            sodt.Value = Mid(line, 388, 8)
            term.Value = Mid(line, 396, 6)
            edte.Value = Mid(line, 402, 8)
            lotno.Value = Mid(line, 410, 15)
            slmno.Value = Mid(line, 425, 3)
            slnm.Value = Mid(line, 428, 24)
            shipto.Value = Mid(line, 452, 50)
            sad1.Value = Mid(line, 502, 50)
            sad2.Value = Mid(line, 552, 50)
            zipc.Value = Mid(line, 602, 6)
            terno.Value = Mid(line, 608, 3)
            area.Value = Mid(line, 611, 3)
            ccls.Value = Mid(line, 614, 3)
            clsn.Value = Mid(line, 617, 24)
            prin.Value = Mid(line, 641, 3)
            sprn.Value = Mid(line, 644, 6)
            prdc.Value = Mid(line, 650, 3)
            swek.Value = Mid(line, 653, 1)
            Try
                myCommand.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Insert_TextFile Module")
            End Try
        Next
    End Sub

    Public Sub ExecuteNonQuery(ByVal Params() As SqlParameter, ByVal StoredProcedure As String)

        Dim myCommand As New SqlCommand
        With myCommand
            .Connection = objConnection(ServerPath2)
            .CommandText = StoredProcedure
            .CommandType = CommandType.StoredProcedure
            Dim i As Integer
            For i = 0 To Params.GetUpperBound(0)
                .Parameters.Add(Params(i))
            Next
            .ExecuteNonQuery()
        End With
        myCommand.Connection.Dispose()

    End Sub

    Private Function FormatErrorMessage(ByVal errorMessage As String, ByVal stringCommand As String, ByVal CodeBlock As String) As String
        Dim myStringBuilder As New StringBuilder
        With myStringBuilder
            .Append("Error in Execution : " & errorMessage)
            .Append(ControlChars.NewLine & "From Command : " & stringCommand)
            .Append(ControlChars.NewLine & "In Code Block : " & CodeBlock)
        End With
        Return myStringBuilder.ToString()
    End Function
End Module
