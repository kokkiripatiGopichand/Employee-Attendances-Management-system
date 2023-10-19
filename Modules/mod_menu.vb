Module mod_menu
    Public Sub menudefault(ByVal sform As String)
        If sform = "frmAccounts" Then
            With frmAccounts
                .btnadd.Enabled = True
                .btncancel.Enabled = False
                .btndelete.Enabled = False
                .btnedit.Enabled = False
                .btnsave.Enabled = False
                .btnsearch.Enabled = True
                .txtname.Enabled = False
                .txtname.Text = ""
                .txtpass.Enabled = False
                .txtpass.Text = ""
                .txtuname.Enabled = False
                .txtuname.Text = ""
                .txtpass.Enabled = False
                .txtpass.Text = ""
                .cbotype.SelectedIndex = 0
                .cbotype.Enabled = False
            End With
        ElseIf sform = "frmStudents" Then
            With frmStudents
                .btnadd.Enabled = True
                .btncancel.Enabled = False
                .btndelete.Enabled = False
                .btnedit.Enabled = False
                .btnsave.Enabled = False
                .btnsearch.Enabled = True
                .btnfinder.Enabled = False
                .txtid.Enabled = False
                .txtid.Text = ""
                .txtTmp.Text = ""
                .txtname.Enabled = False
                .txtname.Text = ""
                .txtcontact.Enabled = False
                .txtcontact.Text = ""
                .txtAddress.Enabled = False
                .txtAddress.Text = ""
                .txtCourse.Enabled = False
                .txtCourse.Text = ""
                .cbogender.Enabled = False
                .cbogender.Text = ""
                .cbosection.Enabled = False
                .cbosection.Text = ""
                .cboyear.Enabled = False
                .cboyear.Text = ""
                .txtmname.Enabled = False
                .txtmname.Text = ""
                .txtlname.Enabled = False
                .txtlname.Text = ""
            End With
        ElseIf sform = "frmEvents" Then
            With frmEvents
                .btnadd.Enabled = True
                .btncancel.Enabled = False
                .btndelete.Enabled = False
                .btnedit.Enabled = False
                .btnsave.Enabled = False
                .btnsearch.Enabled = True
                .txtcode.Enabled = False
                .txtcode.Text = ""
                .txtname.Enabled = False
                .txtname.Text = ""
                .edate.Enabled = False
                .estime.Enabled = False
                .estime.Text = ""
                .etime.Enabled = False
                .etime.Text = ""
                .txtCourse.Enabled = False
                .txtCourse.Text = ""
            End With
        ElseIf sform = "frmCourse" Then
            With frmCourse
                .btnadd.Enabled = True
                .btncancel.Enabled = False
                .btndelete.Enabled = False
                .btnedit.Enabled = False
                .btnsave.Enabled = False
                .btnsearch.Enabled = True
                .txtCode.Enabled = False
                .txtDesc.Enabled = False
                .txtCode.Text = ""
                .txtDesc.Text = ""
            End With
        End If
    End Sub

    Public Sub menubtnadd(ByVal sform As String)
        If sform = "frmAccounts" Then
            With frmAccounts
                .btnadd.Enabled = False
                .btncancel.Enabled = True
                .btndelete.Enabled = False
                .btnedit.Enabled = False
                .btnsave.Enabled = True
                .btnsearch.Enabled = True
                .txtname.Enabled = True
                .txtpass.Enabled = True
                .txtuname.Enabled = True
                .txtpass.Enabled = True
                .cbotype.Enabled = True
                .txtname.Focus()
            End With
        ElseIf sform = "frmStudents" Then
            With frmStudents
                .btnadd.Enabled = False
                .btncancel.Enabled = True
                .btndelete.Enabled = False
                .btnedit.Enabled = False
                .btnsave.Enabled = True
                .btnsearch.Enabled = True
                .btnfinder.Enabled = True
                .txtid.Enabled = True
                .txtname.Enabled = True
                .txtcontact.Enabled = True
                .txtAddress.Enabled = True
                .txtCourse.Enabled = True
                .cbogender.Enabled = True
                .cbosection.Enabled = True
                .cboyear.Enabled = True
                .txtmname.Enabled = True
                .txtlname.Enabled = True
                .txtid.Focus()
            End With
        ElseIf sform = "frmEvents" Then
            With frmEvents
                .btnadd.Enabled = False
                .btncancel.Enabled = True
                .btndelete.Enabled = False
                .btnedit.Enabled = False
                .btnsave.Enabled = True
                .btnsearch.Enabled = True
                .txtcode.Enabled = True
                .txtname.Enabled = True
                .txtCourse.Enabled = True
                .edate.Enabled = True
                .estime.Enabled = True
                .etime.Enabled = True
                .txtcode.Focus()
            End With
        ElseIf sform = "frmCourse" Then
            With frmCourse
                .btnadd.Enabled = False
                .btncancel.Enabled = True
                .btndelete.Enabled = False
                .btnedit.Enabled = False
                .btnsave.Enabled = True
                .btnsearch.Enabled = True
                .txtCode.Enabled = True
                .txtDesc.Enabled = True
                .txtCode.Focus()
            End With
        End If
    End Sub

    Public Sub restrictUser(ByVal type As String)
        If type = "admin" Then
        Else
            mainForm.menu_user.Enabled = False
            mainForm.menu_students.Enabled = False
            mainForm.menuProfile.Enabled = False
            mainForm.menu_events.Enabled = False
            mainForm.menu_backup.Enabled = False
            mainForm.menu_restore.Enabled = False
            mainForm.menu_course.Enabled = False
            mainForm.menu_barcodes.Enabled = False
            mainForm.BarButtonItem2.Enabled = False
        End If
    End Sub
End Module
