Public Class frmChangePassword

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        If AllEntriesAreValid() Then
            SaveUserPassword(gUserID, txtNewPassword.Text)
            MsgBox("User password has been changed successfully!")
        End If
    End Sub

    Private Function AllEntriesAreValid() As Boolean
        Dim retval As Boolean = False
        Try
            If (GetUserPassword(gUserID).Trim = txtOldPassword.Text.ToString.Trim) Then
                If txtNewPassword.Text.Trim = txtConfirmNewPassword.Text.Trim Then
                    retval = True
                Else
                    MsgBox("New password does not match with confirm new password!")
                End If
            Else
                MsgBox("Incorrect Password!")
            End If
        Catch ex As Exception
            retval = False
        End Try
        Return retval
    End Function
End Class