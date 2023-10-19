Imports MySql.Data.MySqlClient
Public Class events
    Public Sub getEvent()
        Dim dtime As String = Format(Now, "MM/dd/yyy").ToString
        Dim dt As New DataTable
        Dim myrow As DataRow
        Dim hours As Integer = DateTime.Now.Hour
        Dim daydream As Boolean = False

        If hours < 12 Then
            daydream = True
        Else
            daydream = False
        End If

        Try
            query = String.Format("select * from tblevent where date='{0}'", dtime)
            command = New MySqlCommand(query, SQLconnection)

            With sqlAdapter
                .SelectCommand = command
                .Fill(dt)
            End With

            If dt.Rows.Count > 0 Then
                For Each myrow In dt.Rows
                    If daydream = True Then
                        If CDate(myrow.Item(4)) < CDate("12:00") Then
                            frmDTR.lblcode.Text = myrow.Item(1)
                            frmDTR.lblactivityname.Text = myrow.Item(2)
                            Exit For
                        Else
                            frmDTR.lblcode.Text = "NONE"
                            frmDTR.lblactivityname.Text = "No Event Scheduled this Morning! Please comeback again!"
                        End If
                    Else
                        If CDate(myrow.Item(4)) > CDate("12:00") Then
                            frmDTR.lblcode.Text = myrow.Item(1)
                            frmDTR.lblactivityname.Text = myrow.Item(2)
                            Exit For
                        Else
                            frmDTR.lblcode.Text = "NONE"
                            frmDTR.lblactivityname.Text = "No Event Scheduled this Afternoon! Please comeback again!"
                        End If
                    End If

                Next
            Else
                frmDTR.lblcode.Text = "NONE"
                frmDTR.lblactivityname.Text = "No Event Scheduled Today! Please comeback again!"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub logTime(ByVal sid As String, ByVal courseid As String, ByVal activityid As String, ByVal timein As String, ByVal timeout As String, ByVal late As Decimal, ByVal under As Decimal, ByVal tdate As String, ByVal type As String)
        Try
            If type = "Insert" Then
                query = String.Format("insert into tblattendance values(default,'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", sid, courseid, activityid, timein, timeout, late, under, tdate)
            Else
                query = String.Format("update tblattendance set timeout='{0}', undertime='{1}' where studid='{2}' and activityid='{3}' and datelog='{4}'", timeout, under, sid, activityid, tdate)
            End If

            command = New MySqlCommand(query, SQLconnection)

            reader = command.ExecuteReader
            'MessageBox.Show("Event Updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function getEventtime(ByVal whatime As String, ByVal code As String) As String
        Dim dt As New DataTable
        Dim myrow As DataRow
        Dim timeas As String = ""

        Try
            query = String.Format("select * from tblevent where code='{0}'", code)
            command = New MySqlCommand(query, SQLconnection)

            With sqlAdapter
                .SelectCommand = command
                .Fill(dt)
            End With

            For Each myrow In dt.Rows
                If whatime = "starttime" Then
                    timeas = myrow.Item(4)
                Else
                    timeas = myrow.Item(5)
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return timeas
    End Function
End Class
