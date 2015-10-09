Module ListHelper
    Public Function GetCodes(lst As ListBox) As String
        Dim retval As String = ""
        Try
            For l_index As Integer = 0 To lst.Items.Count - 1
                Dim l_text As String = CStr(lst.Items(l_index))
                Dim nstart = l_text.IndexOf(":")
                l_text = l_text.Substring(0, nstart).Trim()
                If (l_index = 0) Then
                    retval = "'" + l_text + "'"
                Else
                    retval = retval + ",'" + l_text + "'"
                End If

            Next
        Catch ex As Exception

        End Try
        Return retval
    End Function

    Public Function ItemLookUp() As DataSet
        Dim dstemp As New DataSet
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            dstemp.Tables.Add("Table1")
            BusinessObject.Sub_Show(ServerPath2, "ItemLookUp", CommandType.StoredProcedure, dstemp, "Table1")
        Catch ex As Exception
            MsgBox("Error : " + ex.Message)
        End Try
        Return dstemp
    End Function

    Public Function SegmentLookUp() As DataSet
        Dim dstemp As New DataSet
        Try
            Dim BusinessObject As New BusinessLayer.clsFileMaintenance
            dstemp.Tables.Add("Table1")
            BusinessObject.Sub_Show(ServerPath2, "SegmentLookUp", CommandType.StoredProcedure, dstemp, "Table1")
        Catch ex As Exception
            MsgBox("Error : " + ex.Message)
        End Try
        Return dstemp
    End Function
End Module
