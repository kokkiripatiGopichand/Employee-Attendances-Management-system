Imports MySql.Data.MySqlClient
Public Class frmDTR
    Private Sub frmDTR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim events As New events

        events.getEvent()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Location = New Point(0, 0)
        Me.Size = SystemInformation.PrimaryMonitorSize
        btnToggles.Focus()

        Try
            logobox.Image = System.Drawing.Image.FromFile(Application.StartupPath & "\wvsu.png")
        Catch ex As Exception
            logobox.BorderStyle = BorderStyle.Fixed3D
            logobox.Image = Nothing
        End Try

        Me.KeyPreview = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblday.Text = Now.ToString("ddd")
        lbltime.Text = Now.ToShortTimeString()
        lbldate.Text = Now.ToString("MMMM dd, yyyy")
    End Sub

    Private Sub btnToggles_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnToggles.KeyDown
        If e.KeyCode.ToString = "I" Then
            lblout.BackColor = Color.SeaGreen
            lblin.BackColor = Color.Red

        ElseIf e.KeyCode.ToString = "O" Then
            lblin.BackColor = Color.SeaGreen
            lblout.BackColor = Color.Red
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Interval = 6000
        If lblname.Text <> "" Then
            lblname.Text = ""
            lblid.Text = ""
            lblwelcome.Text = ""
            panelinfo.BackColor = Color.White
            lblCourse.Text = ""
            picbox.Image = Nothing
            Timer2.Stop()
        Else
            lblwelcome.Text = ""
            panelinfo.BackColor = Color.White
            Timer2.Stop()
        End If
    End Sub

    Private Sub VerificationControl_OnComplete(ByVal pTemplate As Object, ByVal FeatureSet As DPFP.FeatureSet, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles VerificationControl.OnComplete
        Dim validator As New validate
        Dim eHandler As New events
        Dim result As String = validator.validatefinger(FeatureSet, EventHandlerStatus)
        Dim stime As String = eHandler.getEventtime("starttime", lblcode.Text)
        Dim etime As String = eHandler.getEventtime("endttime", lblcode.Text)
        Dim dec As Decimal
        Dim timeval As TimeSpan

        If result = "FAILED" Then
            EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure

            If lblin.BackColor = Color.SeaGreen And lblout.BackColor = Color.SeaGreen Then
                panelinfo.BackColor = Color.Sienna
                lblwelcome.Text = "Toggle IN/OUT first!"
                Timer2.Start()
            Else
                If lblcode.Text = "NONE" Then
                    panelinfo.BackColor = Color.Sienna
                    lblwelcome.Text = "Sorry! No Event Today!"
                    Timer2.Start()
                Else
                    panelinfo.BackColor = Color.Red
                    lblname.Text = ""
                    lblwelcome.Text = ""
                    lblid.Text = ""
                    picbox.Image = Nothing
                    lblwelcome.Text = "Not Found!"
                    Timer2.Start()
                End If
            End If
        Else
            EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success
            If lblin.BackColor = Color.SeaGreen And lblout.BackColor = Color.SeaGreen Then
                panelinfo.BackColor = Color.Sienna
                lblwelcome.Text = "Toggle IN/OUT first!"
                Timer2.Start()
            Else
                If lblcode.Text = "NONE" Then
                    panelinfo.BackColor = Color.Sienna
                    lblwelcome.Text = "Sorry! No Event Today!"
                    Timer2.Start()
                Else
                    lblid.Text = result
                    lblname.Text = validator.getName(result)
                    lblCourse.Text = validator.getCourse(result)

                    If lblin.BackColor = Color.Red Then
                        If checkstate(lblid.Text, Now.ToString("MM/dd/yyyy")) > 0 Then
                            panelinfo.BackColor = Color.Orange
                            lblwelcome.Text = "Already Timed IN!"
                            Timer2.Start()
                        Else
                            timeval = CDate(lbltime.Text) - CDate(stime)
                            dec = Convert.ToDecimal(TimeSpan.Parse(timeval.ToString).TotalHours)
                            panelinfo.BackColor = Color.SeaGreen
                            lblwelcome.Text = "Welcome!"
                            Timer2.Start()

                            eHandler.logTime(lblid.Text, lblCourse.Text, lblcode.Text, lbltime.Text, "", dec, "0", Now.ToString("MM/dd/yyyy"), "Insert")
                        End If
                    End If

                    If lblout.BackColor = Color.Red Then
                        If checkstateout(lblid.Text, Now.ToString("MM/dd/yyyy")) > 0 Then
                            panelinfo.BackColor = Color.Orange
                            lblwelcome.Text = "Already timed OUT!!"
                            Timer2.Start()
                        Else
                            timeval = CDate(etime) - CDate(lbltime.Text)
                            dec = Convert.ToDecimal(TimeSpan.Parse(timeval.ToString).TotalHours)

                            panelinfo.BackColor = Color.Red
                            lblwelcome.Text = "Goodbye!!"
                            Timer2.Start()

                            eHandler.logTime(lblid.Text, lblCourse.Text, lblcode.Text, "", lbltime.Text, "0", dec, Now.ToString("MM/dd/yyyy"), "Update")
                        End If
                    End If

                    'retrieve profile pic at the end for fast processing
                    validator.getProfile(result)
                End If
            End If
        End If
    End Sub
End Class
