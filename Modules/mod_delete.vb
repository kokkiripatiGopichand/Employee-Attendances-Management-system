Imports MySql.Data.MySqlClient
Module mod_delete
    Public Sub delthis(ByVal id As String, ByVal sform As String)
        If sform = "frmAccounts" Then
            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("delete from tbluser where id={0}", id)
                    command = New MySqlCommand(query, SQLconnection)
                    reader = command.ExecuteReader

                    SQLconnection.Close()
                    MessageBox.Show("Acccount Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmStudents" Then
            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("delete from tblstudents where sid='{0}'", id)
                    command = New MySqlCommand(query, SQLconnection)
                    reader = command.ExecuteReader

                    SQLconnection.Close()
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmEvents" Then
            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("delete from tblevent where id={0}", id)
                    command = New MySqlCommand(query, SQLconnection)
                    reader = command.ExecuteReader

                    SQLconnection.Close()
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmCourse" Then
            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("delete from tblcourse where id={0}", id)
                    command = New MySqlCommand(query, SQLconnection)
                    reader = command.ExecuteReader

                    SQLconnection.Close()
                    MessageBox.Show("Record Deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmpic" Then
            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("delete from tblpic where code='{0}'", id)
                    command = New MySqlCommand(query, SQLconnection)
                    reader = command.ExecuteReader

                    SQLconnection.Close()
                Catch ex As Exception
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmtemplate" Then
            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("delete from tbltemplates where code='{0}'", id)
                    command = New MySqlCommand(query, SQLconnection)
                    reader = command.ExecuteReader

                    SQLconnection.Close()
                Catch ex As Exception
                    SQLconnection.Close()
                End Try
            End If
        End If
    End Sub
End Module
