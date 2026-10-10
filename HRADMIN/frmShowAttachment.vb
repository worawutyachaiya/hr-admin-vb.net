Public Class frmShowAttachment

    Private Sub frmShowAttachment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WebBrowerAttachment.Navigate(iPahtAttachment & FilesNameAttachment)
    End Sub


End Class