Imports MySql.Data.MySqlClient
Module mod_Search
    Public Sub searchData(ByVal sform As String, ByVal skey As String)
        Dim count As Integer
        Dim dt As New DataTable
        Dim myrow As DataRow

        If sform = "frmAccounts" Then
            'clear listbox items 1st
            frmAccounts.listAccounts.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("select * from tbluser where accountname like '%{0}%'", skey)
                    command = New MySqlCommand(query, SQLconnection)

                    With sqlAdapter
                        .SelectCommand = command
                        .Fill(dt)
                    End With

                    For Each myrow In dt.Rows
                        frmAccounts.listAccounts.Items.Add(myrow.Item(0))
                        frmAccounts.listAccounts.Items(frmAccounts.listAccounts.Items.Count - 1).SubItems.Add(myrow.Item(1))
                        frmAccounts.listAccounts.Items(frmAccounts.listAccounts.Items.Count - 1).SubItems.Add(myrow.Item(2))
                        frmAccounts.listAccounts.Items(frmAccounts.listAccounts.Items.Count - 1).SubItems.Add(myrow.Item(4))
                        count = count + 1
                    Next

                    frmAccounts.totalcount.Caption = count
                    SQLconnection.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmStudents" Then
            'clear listbox items 1st
            frmStudents.listStudents.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("select * from tblstudents where name like '%{0}%' order by name asc", skey)
                    command = New MySqlCommand(query, SQLconnection)

                    With sqlAdapter
                        .SelectCommand = command
                        .Fill(dt)
                    End With

                    For Each myrow In dt.Rows
                        frmStudents.listStudents.Items.Add(myrow.Item(0))
                        frmStudents.listStudents.Items(frmStudents.listStudents.Items.Count - 1).SubItems.Add(myrow.Item(1))
                        frmStudents.listStudents.Items(frmStudents.listStudents.Items.Count - 1).SubItems.Add(myrow.Item(2))
                        frmStudents.listStudents.Items(frmStudents.listStudents.Items.Count - 1).SubItems.Add(myrow.Item(3))
                        frmStudents.listStudents.Items(frmStudents.listStudents.Items.Count - 1).SubItems.Add(myrow.Item(4))
                        frmStudents.listStudents.Items(frmStudents.listStudents.Items.Count - 1).SubItems.Add(myrow.Item(5))
                        frmStudents.listStudents.Items(frmStudents.listStudents.Items.Count - 1).SubItems.Add(myrow.Item(6))
                        frmStudents.listStudents.Items(frmStudents.listStudents.Items.Count - 1).SubItems.Add(myrow.Item(7))
                        count = count + 1
                    Next

                    frmStudents.totalcount.Caption = count
                    SQLconnection.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmEvents" Then
            'clear listbox first
            frmEvents.listEvent.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("select * from tblevent where activityname like '%{0}%'", skey)
                    command = New MySqlCommand(query, SQLconnection)

                    With sqlAdapter
                        .SelectCommand = command
                        .Fill(dt)
                    End With

                    For Each myrow In dt.Rows
                        frmEvents.listEvent.Items.Add(myrow.Item(0))
                        frmEvents.listEvent.Items(frmEvents.listEvent.Items.Count - 1).SubItems.Add(myrow.Item(1))
                        frmEvents.listEvent.Items(frmEvents.listEvent.Items.Count - 1).SubItems.Add(myrow.Item(2))
                        frmEvents.listEvent.Items(frmEvents.listEvent.Items.Count - 1).SubItems.Add(myrow.Item(3))
                        frmEvents.listEvent.Items(frmEvents.listEvent.Items.Count - 1).SubItems.Add(myrow.Item(4))
                        frmEvents.listEvent.Items(frmEvents.listEvent.Items.Count - 1).SubItems.Add(myrow.Item(5))
                        frmEvents.listEvent.Items(frmEvents.listEvent.Items.Count - 1).SubItems.Add(myrow.Item(6))
                        count = count + 1
                    Next

                    frmEvents.totalcount.Caption = count
                    SQLconnection.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmCourse" Then
            'clear listbox first
            frmCourse.listCourse.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = String.Format("select * from tblcourse where coursename like '%{0}%'", skey)
                    command = New MySqlCommand(query, SQLconnection)

                    With sqlAdapter
                        .SelectCommand = command
                        .Fill(dt)
                    End With

                    For Each myrow In dt.Rows
                        frmCourse.listCourse.Items.Add(myrow.Item(0))
                        frmCourse.listCourse.Items(frmCourse.listCourse.Items.Count - 1).SubItems.Add(myrow.Item(1))
                        frmCourse.listCourse.Items(frmCourse.listCourse.Items.Count - 1).SubItems.Add(myrow.Item(2))
                        count = count + 1
                    Next

                    frmCourse.totalcount.Caption = count
                    SQLconnection.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SQLconnection.Close()
                End Try

            End If
        End If
    End Sub
End Module
