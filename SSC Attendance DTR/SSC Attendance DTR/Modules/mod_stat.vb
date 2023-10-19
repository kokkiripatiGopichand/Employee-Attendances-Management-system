Imports MySql.Data.MySqlClient
Module mod_stat
    Public Function checkstate(ByVal sid As String, ByVal tdate As String) As Integer
        Dim dt As New DataTable
        Dim myrow As DataRow
        Dim timeas As String = ""

        Try
            query = String.Format("select timein from tblattendance where studid='{0}' and datelog='{1}'", sid, tdate)
            command = New MySqlCommand(query, SQLconnection)

            With sqlAdapter
                .SelectCommand = command
                .Fill(dt)
            End With

            For Each myrow In dt.Rows
                timeas = myrow.Item(0)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If timeas <> "" Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function checkstateout(ByVal sid As String, ByVal tdate As String) As Integer
        Dim dt As New DataTable
        Dim myrow As DataRow
        Dim timeas As String = ""

        Try
            query = String.Format("select timeout from tblattendance where studid='{0}' and datelog='{1}'", sid, tdate)
            command = New MySqlCommand(query, SQLconnection)

            With sqlAdapter
                .SelectCommand = command
                .Fill(dt)
            End With

            For Each myrow In dt.Rows
                timeas = myrow.Item(0)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If timeas <> "" Then
            Return 1
        Else
            Return 0
        End If
    End Function
End Module
