Imports MySql.Data.MySqlClient
Public Class cls_mask
    Dim dt As New DataTable

    Public Sub getMask(ByVal uid As String)
        Dim myrow As DataRow
        Dim count As Integer = 0

        If SQLconnection.State = ConnectionState.Closed Then
            Try
                query = String.Format("select * from tbltemplates where code='{0}'", uid)
                SQLconnection.Open()
                command = New MySqlCommand(query, SQLconnection)

                With sqlAdapter
                    .SelectCommand = command
                    .Fill(dt)
                End With

                For Each myrow In dt.Rows
                    count = count + myrow(3)
                Next

                frmHand.EnrollmentControl.EnrolledFingerMask = count

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                SQLconnection.Close()
            End Try
        End If
    End Sub
End Class
