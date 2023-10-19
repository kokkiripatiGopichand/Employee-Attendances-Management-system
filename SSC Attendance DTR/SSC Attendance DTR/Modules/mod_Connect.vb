Imports MySql.Data.MySqlClient
Module mod_Connect
    'Public serverString As String = "Server=localhost;User Id=root;Password=123456789;Database=dbams"
    Public SQLconnection As MySqlConnection = New MySqlConnection
    Public command As New MySqlCommand
    Public reader As MySqlDataReader
    Public sqlAdapter As New MySqlDataAdapter
    Public query As String

    Public Sub connectDB()
        Dim serverString As String = String.Format("Server={0};User Id=root;Password=;Database=db_ssc", My.Settings.server)
        SQLconnection.ConnectionString = serverString
    End Sub
End Module
