Option Strict Off
Imports MySql.Data.MySqlClient

Public Class validate
    Public Function validatefinger(ByVal FeatureSet As DPFP.FeatureSet, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) As String
        Dim vr As New DPFP.Verification.Verification
        Dim rs As New DPFP.Verification.Verification.Result
        Dim ucode As String = ""
        Dim result As String = ""

        Try
            query = "select * from tbltemplates"
            command = New MySqlCommand(query, SQLconnection)
            Dim rdr As MySqlDataReader = command.ExecuteReader()
            Dim MemStream As IO.MemoryStream
            Dim fpBytes As Byte()
            While rdr.Read()
                fpBytes = rdr("template")
                ucode = rdr("code")
                MemStream = New IO.MemoryStream(fpBytes)
                Dim template As New DPFP.Template(MemStream)
                If Not template Is Nothing Then
                    vr.Verify(FeatureSet, template, rs)

                    If rs.Verified Then
                        result = ucode
                        Exit While
                    ElseIf Not rs.Verified Then
                        result = "FAILED"
                    End If
                End If
            End While
            'close reader first
            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return result
    End Function

    Public Function getName(ByVal code As String) As String
        Dim result As String = ""

        Try
            query = String.Format("select * from tblstudents where sid='{0}'", code)
            command = New MySqlCommand(query, SQLconnection)
            Dim rdr As MySqlDataReader = command.ExecuteReader()

            While rdr.Read()
                result = rdr("name")
            End While

            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return result
    End Function

    Public Function getCourse(ByVal code As String) As String
        Dim result As String = ""

        Try
            query = String.Format("select * from tblstudents where sid='{0}'", code)
            command = New MySqlCommand(query, SQLconnection)
            Dim rdr As MySqlDataReader = command.ExecuteReader()

            While rdr.Read()
                result = rdr("course")
            End While

            rdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return result
    End Function

    Public Sub AutosizeImage(ByVal lbs() As Byte, ByVal picBox As PictureBox, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Dim lstr As New System.IO.MemoryStream(lbs)
        Try
            picBox.Image = Nothing
            picBox.SizeMode = pSizeMode
            If Not lbs Is Nothing Then
                Dim imgOrg As Bitmap
                Dim imgShow As Bitmap
                Dim g As Graphics
                Dim divideBy, divideByH, divideByW As Double
                imgOrg = DirectCast(Bitmap.FromStream(lstr), Bitmap)

                divideByW = imgOrg.Width / picBox.Width
                divideByH = imgOrg.Height / picBox.Height
                If divideByW > 1 Or divideByH > 1 Then
                    If divideByW > divideByH Then
                        divideBy = divideByW
                    Else
                        divideBy = divideByH
                    End If

                    imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                Else
                    imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                End If
                imgOrg.Dispose()

                picBox.Image = imgShow
            Else
                picBox.Image = Nothing
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub getProfile(ByVal code As String)
        Try
            Dim Data = New DataTable

            query = String.Format("SELECT * FROM tblpic WHERE code='{0}'", code)
            command = New MySqlCommand(query, SQLconnection)
            With sqlAdapter
                .SelectCommand = command
                .Fill(Data)
            End With

            Dim lb() As Byte = Data.Rows(0).Item("profile")
            Dim lstr As New System.IO.MemoryStream(lb)

            If lb.Length < 1 Then
                Dim imgCon As New ImageConverter()
                lb = DirectCast(imgCon.ConvertTo(System.Drawing.Image.FromFile(Application.StartupPath & "\default.jpg"), GetType(Byte())), Byte())
                AutosizeImage(lb, frmDTR.picbox)
            Else
                AutosizeImage(lb, frmDTR.picbox)
            End If
            lstr.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class
