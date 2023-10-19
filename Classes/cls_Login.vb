Imports MySql.Data.MySqlClient
Public Class cls_Login
    Public Sub checkLogin(ByVal uname As String, ByVal pass As String)
        Dim count As Integer = 0

        If SQLconnection.State = ConnectionState.Closed Then
            Try
                SQLconnection.Open()
                query = String.Format("select * from tbluser where username='{0}' and password='{1}'", uname, pass)
                command = New MySqlCommand(query, SQLconnection)
                reader = command.ExecuteReader

                While reader.Read
                    count = count + 1
                End While

                If count = 1 Then
                    mainForm.btnname.Caption = reader("accountname")
                    mainForm.btnuname.Caption = frmLogin.txtuser.Text
                    mainForm.btnid.Caption = reader("id")
                    mainForm.utype.Caption = reader("category")
                    mainForm.Show()
                    frmLogin.Close()
                Else
                    MsgBox("Invalid Credentials!!", MsgBoxStyle.Critical, "Login Failed!")
                    With frmLogin
                        .txtpass.Text = ""
                        .txtuser.Text = ""
                        .txtuser.Focus()
                    End With
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                SQLconnection.Close()
            End Try
        End If
    End Sub
End Class
