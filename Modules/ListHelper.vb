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
End Module
