Imports MySql.Data.MySqlClient
Module mod_loadData

    Public Sub loadData(ByVal sform As String)
        Dim myrow As DataRow
        Dim dt As New DataTable
        Dim count As Integer = 0

        If sform = "frmAccounts" Then

            'clear listbox items 1st
            frmAccounts.listAccounts.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = "select * from tbluser order by accountname ASC"
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

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmStudents" Then
            'clear listbox items 1st
            frmStudents.listStudents.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = "select * from tblstudents order by name ASC"
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

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmFinder" Then
            'clear listbox first
            frmFinder.lstStudents.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = "select sid,name,course from tblstudents order by name ASC"
                    command = New MySqlCommand(query, SQLconnection)

                    With sqlAdapter
                        .SelectCommand = command
                        .Fill(dt)
                    End With

                    For Each myrow In dt.Rows
                        frmFinder.lstStudents.Items.Add(myrow.Item(0))
                        frmFinder.lstStudents.Items(frmFinder.lstStudents.Items.Count - 1).SubItems.Add(myrow.Item(1))
                        frmFinder.lstStudents.Items(frmFinder.lstStudents.Items.Count - 1).SubItems.Add(myrow.Item(2))
                    Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "Participation" Then
            'clear listbox first
            frmFinder.lstStudents.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = "select code,activityname from tblevent order by activityname ASC"
                    command = New MySqlCommand(query, SQLconnection)

                    With sqlAdapter
                        .SelectCommand = command
                        .Fill(dt)
                    End With

                    For Each myrow In dt.Rows
                        frmFinder.lstStudents.Items.Add(myrow.Item(0))
                        frmFinder.lstStudents.Items(frmFinder.lstStudents.Items.Count - 1).SubItems.Add(myrow.Item(1))
                    Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "tblCourse" Then
            'clear listbox first
            frmFinder.lstStudents.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = "select coursename,coursedescription from tblcourse order by coursename ASC"
                    command = New MySqlCommand(query, SQLconnection)

                    With sqlAdapter
                        .SelectCommand = command
                        .Fill(dt)
                    End With

                    For Each myrow In dt.Rows
                        frmFinder.lstStudents.Items.Add(myrow.Item(0))
                        frmFinder.lstStudents.Items(frmFinder.lstStudents.Items.Count - 1).SubItems.Add(myrow.Item(1))
                    Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmEvents" Then
            'clear listbox first
            frmEvents.listEvent.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = "select * from tblevent order by date desc"
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
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    SQLconnection.Close()
                End Try
            End If
        ElseIf sform = "frmCourse" Then
            'clear listbox first
            frmCourse.listCourse.Items.Clear()

            If SQLconnection.State = ConnectionState.Closed Then
                Try
                    SQLconnection.Open()
                    query = "select * from tblcourse order by coursedescription asc"
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
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    SQLconnection.Close()
                End Try
            End If
        End If
    End Sub

    Public Function getTotalEvent(ByVal courseid As String) As Integer
        Dim myrow As DataRow
        Dim dt As New DataTable
        Dim count As Integer = 0

        If SQLconnection.State = ConnectionState.Closed Then
            Try
                SQLconnection.Open()
                query = String.Format("select code from tblevent where courseid='{0}'", courseid)
                command = New MySqlCommand(query, SQLconnection)

                With sqlAdapter
                    .SelectCommand = command
                    .Fill(dt)
                End With

                For Each myrow In dt.Rows
                    count = count + 1
                Next
            Catch ex As Exception
            Finally
                SQLconnection.Close()
            End Try
        End If

        Return count
    End Function

    Public Function getStatus(ByVal studid As String) As String
        Dim myrow As DataRow
        Dim dt As New DataTable
        Dim count As Integer = 0

        If SQLconnection.State = ConnectionState.Closed Then
            Try
                SQLconnection.Open()
                query = String.Format("select studid from tblstatus where studid='{0}' and year='{1}'", studid, Date.Today.Year)
                command = New MySqlCommand(query, SQLconnection)

                With sqlAdapter
                    .SelectCommand = command
                    .Fill(dt)
                End With

                For Each myrow In dt.Rows
                    count = count + 1
                Next
            Catch ex As Exception
            Finally
                SQLconnection.Close()
            End Try
        End If

        If count > 0 Then
            Return "PAID"
        Else
            Return "NOT PAID"
        End If
    End Function
End Module
