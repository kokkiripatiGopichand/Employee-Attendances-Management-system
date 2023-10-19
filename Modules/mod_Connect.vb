Imports MySql.Data.MySqlClient
Module mod_Connect
    'Public serverString As String = "Server=localhost;User Id=root;Password=123456789;Database=dbams"
    Public SQLconnection As MySqlConnection = New MySqlConnection
    Public command As New MySqlCommand
    Public reader As MySqlDataReader
    Public sqlAdapter As New MySqlDataAdapter
    Public query As String
    Public query2 As String
    Public query3 As String

    Public Sub connectDB()
        Dim ini As New IniFile("C:\Windows\ams.ini")
        Dim res = ini.ReadValue("connect", "server")
        Dim serverString As String = String.Format("Server={0};User Id=root;Password=;Database=db_ssc", res)
        SQLconnection.ConnectionString = serverString
    End Sub
End Module
