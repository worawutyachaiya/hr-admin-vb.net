Public Class frmResetPassword
    Private strQ As String = ""

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If MsgBox("คูณต้องการที่จะรีเซตรหัสผ่านของ " & Trim(txtEmpCode.Text) & " ใช่หรือไม่", vbYesNo, "ยืนยัน") = vbYes Then

            If Me.txtEmpCode.Text = "" Or Me.txtPassword.Text = "" Then
                MsgBox("The data uncomplete please insert again.")
                Exit Sub
            End If

            SetAllConnectionDB()
            ClsUpdateData = New Cls_UpdateData
            ClsEncodMD5 = New Cls_FcnEncodMD5
            strQ = ""
            strQ = strQ & "  update  member set empPass ='" & ClsEncodMD5.EncodePasswordMD5((Trim(Me.txtPassword.Text))) & "'"
            strQ = strQ & "  where  empCode  ='" & UCase(Trim(Me.txtEmpCode.Text)) & "'"
            ClsUpdateData.Update(Connection, strQ)

            SetAllConnectionDB_Smart()
            ClsUpdateData.Update(Connection, strQ)

            MsgBox("ทำการรีเซตรหัสผ่านเรียบร้อย รหัสผ่านเปลี่ยนเป็น " & UCase(Trim(txtPassword.Text)))
            Me.txtEmpCode.Text = ""
            Me.txtPassword.Text = ""
        End If
    End Sub
End Class