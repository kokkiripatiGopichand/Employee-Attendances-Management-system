Option Strict Off
Public Class frmSplash

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim toload() As String = {"Plugins", "Modules", "Objects", "Resources", "Database", "Logos", "Controls", "Buttons", "Labels", "UI", "Models", "Effects", "Services", "Assets", "Handlers", "Schema's", "Starting Up", "Starting Up.", "Starting Up. .", "Starting Up. . ."}

        lblLoad.Text = toload(1).ToString

        Try
            lblLoad.Text = toload(Timer1.Tag)
            Timer1.Tag = Timer1.Tag + 1
        Catch ex As Exception
            If SQLconnection.State = ConnectionState.Closed Then
                SQLconnection.Open()
                frmDTR.Show()
                Timer1.Stop()
                Me.Close()
            End If
        End Try
    End Sub

    Private Sub frmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label5.Parent = PictureBox1
        Label6.Parent = PictureBox1
        lblLoad.Parent = PictureBox1
        Label8.Parent = PictureBox1
        comname.Parent = PictureBox1
        Label5.BackColor = Color.Transparent
        comname.BackColor = Color.Transparent
        Label6.BackColor = Color.Transparent
        lblLoad.BackColor = Color.Transparent
        Label8.BackColor = Color.Transparent

        'set licensed name
        comname.Text = Environment.MachineName
        Timer1.Start()

        'Connect to database
        connectDB()
    End Sub
End Class