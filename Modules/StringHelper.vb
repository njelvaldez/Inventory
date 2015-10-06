Module StringHelper
    Public Function GetWordByIndex(ByVal words As String, ByVal index As Integer) As String
        Dim retval As String = ""
        Try
            Dim WordArray() As String = Split(words)
            retval = WordArray(index)
        Catch ex As Exception

        End Try
        Return retval
    End Function

    Public Function Get50Chars(ByVal words As String) As String
        Dim retval As String = words
        Try
            words = words.Trim
            If words.Length >= 50 Then
                words = words.Substring(0, 49)
                retval = words
            End If
        Catch ex As Exception

        End Try
        Return retval
    End Function
    Public Function GetCheckDigits(ByVal words As String) As Integer
        Dim retval As Integer
        'MOD(((LEFT(words,1) + (RIGHT(LEFT(words,3),1)) + (RIGHT(LEFT(words,5),1)) + (RIGHT(LEFT(words,7),1))) * 3) + ((RIGHT(LEFT(words,2),1)) + (RIGHT(LEFT(words,4),1)) + (RIGHT(LEFT(words,6),1)) + (RIGHT(LEFT(words,8),1))),10)
        retval = (((Convert.ToInt16(Left(words, 1)) + (Convert.ToInt16(Right(Left(words, 3), 1))) + (Convert.ToInt16(Right(Left(words, 5), 1))) + (Convert.ToInt16(Right(Left(words, 7), 1)))) * 3) + ((Convert.ToInt16(Right(Left(words, 2), 1))) + (Convert.ToInt16(Right(Left(words, 4), 1))) + (Convert.ToInt16(Right(Left(words, 6), 1))) + (Convert.ToInt16(Right(Left(words, 8), 1))))) Mod 10
        Return retval
    End Function

    Public Function StringToDecimal(strpar As String) As Decimal
        Dim retval As Decimal = 0
        Try
            retval = Convert.ToDecimal(strpar)
        Catch ex As Exception
            retval = 0
        End Try
        Return retval
    End Function

    Public Function CountIfGreaterZero(strpar As String) As Decimal
        Dim retval As Decimal = 0
        Try
            retval = Convert.ToDecimal(strpar)
        Catch ex As Exception
            retval = 0
        End Try
        Return IIf(retval > 0, 1, 0)
    End Function
End Module
