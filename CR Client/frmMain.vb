Imports System.Runtime.InteropServices
Imports System.Xml
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Threading.Thread

Public Class frmMain
    Dim CRCLOSED As Boolean
    Dim FOCUSPANE As Byte
    Dim changeflag As Boolean = False
    Dim TRAYLOGIN As Boolean

    Dim ipRgx As New Regex("\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b")
    Dim portRgx As New Regex("^(6553[0-5]|655[0-2]\d|65[0-4]\d\d|6[0-4]\d{3}|[1-5]\d{4}|[1-9]\d{0,3}|0)$")

    'Property to trace if Ctrl key is pressed.
    <DllImport("user32.dll")> _
    Private Shared Function GetAsyncKeyState(ByVal vKey As Keys) As Short
    End Function

    Private ReadOnly Property CtrlPressed As Boolean
        Get
            Dim isPressed As Short = GetAsyncKeyState(Keys.ControlKey)
            Return (isPressed & &H8000) <> 0
        End Get
    End Property

    'Create Drop Shadow
    Private Const CS_DROPSHADOW As Int32 = &H20000

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim parameters As CreateParams = MyBase.CreateParams
            parameters.ClassStyle += CS_DROPSHADOW
            Return parameters
        End Get
    End Property


    Private Sub FocusTab1()
        If FOCUSPANE <> 0 Then
            pnlMain.Visible = True
            pnlOptions.Visible = False
            txtUserName.Text = USERNAME
            txtPassword.Text = PASSWORD
            lblMain.ForeColor = Color.Black
            lblOptions.ForeColor = Color.Gray
            FOCUSPANE = 0
        End If
        IPADDR = txtIPAddr.Text
        PORTNO = txtPort.Text
        AUTOLOG = chkAutoLogin.Checked
        AUTOLOGDUR = txtLoginDuration.Text
        AUTOSTART = chkAutoStart.Checked
        NOTIF = chkNotify.Checked
        MINTOTRAY = chkMinTray.Checked
        ASKEXIT = chkAskExit.Checked
    End Sub

    Private Sub FocusTab2()
        If FOCUSPANE <> 1 Then
            pnlMain.Visible = False
            pnlOptions.Visible = True

            txtIPAddr.Text = IPADDR
            txtPort.Text = PORTNO
            chkAutoLogin.Checked = AUTOLOG
            txtLoginDuration.Text = AUTOLOGDUR
            chkAutoStart.Checked = AUTOSTART
            chkNotify.Checked = NOTIF
            chkMinTray.Checked = MINTOTRAY
            chkAskExit.Checked = ASKEXIT

            lblOptions.ForeColor = Color.Black
            lblMain.ForeColor = Color.Gray
            FOCUSPANE = 1
        End If
        'Initialize Main Pane values
        USERNAME = txtUserName.Text.Trim
        PASSWORD = txtPassword.Text.Trim
    End Sub

    Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not SettingsExist() Then
            changeflag = True
            WriteDefaultSettings()
        End If
        InitValues()
        tmLogout.Interval = AUTOLOGDUR * 60000
        Me.Top = ReadSetting("Software\CR Client\Settings", "WinTopPos")
        Me.Left = ReadSetting("Software\CR Client\Settings", "WinLeftPos")

        txtUserName.Text = USERNAME
        txtPassword.Text = PASSWORD
        ntfNotify.Checked = NOTIF
        FOCUSPANE = 0

        Me.DoubleBuffered = True
        Me.SetStyle(
         ControlStyles.AllPaintingInWmPaint Or _
         ControlStyles.UserPaint Or _
         ControlStyles.OptimizedDoubleBuffer, True)

        If AUTOSTART Then
            Me.Opacity = 0
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
            tmAutoHide.Enabled = True
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If CtrlPressed And e.KeyCode = Keys.Tab Then
            If FOCUSPANE = 0 Then
                FocusTab2()
            ElseIf FOCUSPANE = 1 Then
                FocusTab1()
            End If
        End If
        If FOCUSPANE = 0 And e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If
    End Sub

    Private Sub lblTitleBar_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblTitleBar.MouseMove
        Static xx As Integer, yy As Integer
        Select Case e.Button
            Case Windows.Forms.MouseButtons.None
                xx = e.X
                yy = e.Y
            Case Windows.Forms.MouseButtons.Left
                Me.Left = Me.Left + (e.X - xx)
                Me.Top = Me.Top + (e.Y - yy)
        End Select
    End Sub

    Private Sub lblBar_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblBar.MouseMove
        lblTitleBar_MouseMove(sender, e)
    End Sub

    Private Sub lblMain_MouseEnter(sender As Object, e As System.EventArgs) Handles lblMain.MouseEnter
        If FOCUSPANE = 1 Then
            lblMain.ForeColor = Color.Black
        End If
    End Sub

    Private Sub lblMain_MouseLeave(sender As Object, e As System.EventArgs) Handles lblMain.MouseLeave
        If FOCUSPANE = 1 Then
            lblMain.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub lblMain_Click(sender As System.Object, e As System.EventArgs) Handles lblMain.Click
        FocusTab1()
    End Sub

    Private Sub lblOptions_MouseEnter(sender As Object, e As System.EventArgs) Handles lblOptions.MouseEnter
        If FOCUSPANE = 0 Then
            lblOptions.ForeColor = Color.Black
        End If
    End Sub

    Private Sub lblOptions_MouseLeave(sender As Object, e As System.EventArgs) Handles lblOptions.MouseLeave
        If FOCUSPANE = 0 Then
            lblOptions.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub lblOptions_Click(sender As System.Object, e As System.EventArgs) Handles lblOptions.Click
        FocusTab2()
    End Sub

    Private Sub lblAbout_MouseEnter(sender As Object, e As System.EventArgs) Handles lblAbout.MouseEnter
        lblAbout.ForeColor = Color.Black
    End Sub

    Private Sub lblAbout_MouseLeave(sender As Object, e As System.EventArgs) Handles lblAbout.MouseLeave
        lblAbout.ForeColor = Color.Gray
    End Sub

    Private Sub lblAbout_Click(sender As System.Object, e As System.EventArgs) Handles lblAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub lblClose_MouseEnter(sender As Object, e As System.EventArgs) Handles lblClose.MouseEnter
        lblClose.Image = ControlImages.Images.Item(1)
        ToolTip.SetToolTip(lblClose, "Exit")
    End Sub

    Private Sub lblClose_MouseLeave(sender As Object, e As System.EventArgs) Handles lblClose.MouseLeave
        If Not CRCLOSED Then
            lblClose.Image = ControlImages.Images.Item(0)
        End If
    End Sub

    Private Sub lblClose_Click(sender As System.Object, e As System.EventArgs) Handles lblClose.Click
        If MINTOTRAY Then
            Me.Hide()
            NotifyIcon.Visible = True
        Else
            If ASKEXIT Then
                Dim resp
                resp = MsgBox("Are you sure you want to exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CR Client")
                If resp = MsgBoxResult.Yes Then
                    CRCLOSED = True
                    Me.Close()
                End If
            Else
                CRCLOSED = True
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        If USERNAME <> txtUserName.Text Or PASSWORD <> txtPassword.Text Then
            changeflag = True
        End If
        USERNAME = txtUserName.Text.Trim
        PASSWORDSALT = USERNAME
        PASSWORD = txtPassword.Text

        Select Case btnLogin.Text.ToLower
            Case "login"
                If USERNAME.Trim = "" Or PASSWORD.Trim = "" Then
                    ShowMsg("User Name or Password cannot be empty!", 2)
                    txtUserName.Focus()
                Else
                    'Login Method
                    If Login() Then

                        TRAYLOGIN = True
                        btnLogin.Text = "Logout"
                        ntfLogin.Text = "Logout"
                        'Lock Fields to Prevent changes
                        txtUserName.ReadOnly = True
                        txtPassword.ReadOnly = True
                        txtIPAddr.ReadOnly = True
                        txtPort.ReadOnly = True
                        txtLoginDuration.ReadOnly = True
                        btnCheck.Enabled = False

                    End If
                End If
            Case "logout"
                If Logoff() Then
                    btnLogin.Text = "Login"
                    ntfLogin.Text = "Login"
                    'Unlock Fields to allow changes
                    txtUserName.ReadOnly = False
                    txtPassword.ReadOnly = False
                    txtIPAddr.ReadOnly = False
                    txtPort.ReadOnly = False
                    txtLoginDuration.ReadOnly = False
                    btnCheck.Enabled = True

                End If
        End Select

    End Sub

    Private Sub txtUserName_TextChanged(sender As Object, e As System.EventArgs) Handles txtUserName.TextChanged
        ShowMsg("", 1)
        'USERNAME = txtUserName.Text
        '       changeflag = True
    End Sub

    Private Sub txtUserName_LostFocus(sender As Object, e As System.EventArgs) Handles txtUserName.LostFocus
        'USERNAME = txtUserName.Text
        'PASSWORDSALT = USERNAME
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As System.EventArgs) Handles txtPassword.TextChanged
        ShowMsg("", 1)
        'PASSWORD = txtPassword.Text
        'changeflag = True
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As System.EventArgs) Handles txtPassword.LostFocus
        'PASSWORD = txtPassword.Text
    End Sub

    Private Sub txtIPAddr_TextChanged(sender As Object, e As System.EventArgs) Handles txtIPAddr.TextChanged
        IPADDR = txtIPAddr.Text.Trim
    End Sub

    Private Sub txtIPAddr_LostFocus(sender As Object, e As System.EventArgs) Handles txtIPAddr.LostFocus
        If ipRgx.IsMatch(txtIPAddr.Text.Trim) Then
            IPADDR = txtIPAddr.Text
        Else
            Dim resp = MsgBox("Invalid IP Address!", MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel, "CR Client")
            If resp = MsgBoxResult.Retry Then
                txtIPAddr.Text = ""
                txtIPAddr.Focus()
            Else
                txtIPAddr.Focus()
            End If
        End If
    End Sub

    Private Sub txtPort_TextChanged(sender As Object, e As System.EventArgs) Handles txtPort.TextChanged
        PORTNO = txtPort.Text.Trim
    End Sub

    Private Sub txtPort_LostFocus(sender As Object, e As System.EventArgs) Handles txtPort.LostFocus
        If portRgx.IsMatch(txtPort.Text.Trim) Then
            PORTNO = txtPort.Text
        Else
            Dim resp = MsgBox("Invalid IP Address!", MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel, "CR Client")
            If resp = MsgBoxResult.Retry Then
                txtPort.Text = ""
                txtPort.Focus()
            Else
                txtPort.Focus()
            End If
        End If
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As System.EventArgs) Handles btnCheck.Click
        Dim serverresp As String
        Dim webcl As New Net.WebClient
        Try
            serverresp = webcl.DownloadString("http://" & IPADDR & ":" & PORTNO & "/")
            If serverresp.ToString().ToLower().Contains("cyberoam") Then
                MsgBox("Cyberoam Server found", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CR Client")
            Else
                MsgBox("Cyberoam Server not found!" & vbCrLf & "make sure IP Address and Port Number are valid.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CR Client")
                txtIPAddr.Focus()
            End If
        Catch ex As WebException
            MsgBox(ex.Message & vbCrLf & "make sure IP Address and Port Number are valid.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CR Client")
        End Try
    End Sub

    Private Sub chkAutoLogin_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkAutoLogin.CheckedChanged
        AUTOLOG = chkAutoLogin.Checked
        If AUTOLOG Then
            txtLoginDuration.Enabled = True
            Label5.Enabled = True
        Else
            txtLoginDuration.Enabled = False
            Label5.Enabled = False
        End If
    End Sub

    Private Sub txtLoginDuration_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoginDuration.KeyPress
        If Not ((Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 58) Or Asc(e.KeyChar) = 8) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtLoginDuration_LostFocus(sender As Object, e As System.EventArgs) Handles txtLoginDuration.LostFocus
        AUTOLOGDUR = CInt(txtLoginDuration.Text)
    End Sub

    Private Sub chkAutoStart_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkAutoStart.CheckedChanged
        AUTOSTART = chkAutoStart.Checked
        AutoStartWindows(AUTOSTART)
    End Sub

    Private Sub chkMinTray_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkMinTray.CheckedChanged
        MINTOTRAY = chkMinTray.Checked
    End Sub

    Private Sub chkNotify_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkNotify.CheckedChanged
        NOTIF = chkNotify.Checked
    End Sub

    Private Sub chkAskExit_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkAskExit.CheckedChanged
        ASKEXIT = chkAskExit.Checked
    End Sub


    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        WriteSetting("Software\CR Client\Vault", "UserName", USERNAME)
        'Hash the password before storing
        Dim encpass As String
        encpass = Encrypt(PASSWORD, PASSWORDSALT)
        WriteSetting("Software\CR Client\Vault", "Password", encpass)

        WriteSetting("Software\CR Client\Settings", "IPAddr", IPADDR)
        WriteSetting("Software\CR Client\Settings", "PortNo", PORTNO)
        WriteSetting("Software\CR Client\Settings", "AutoLogin", AUTOLOG)
        WriteSetting("Software\CR Client\Settings", "AutoLoginDur", AUTOLOGDUR)
        WriteSetting("Software\CR Client\Settings", "AutoStart", AUTOSTART)
        WriteSetting("Software\CR Client\Settings", "Notify", NOTIF)
        WriteSetting("Software\CR Client\Settings", "MinToTray", MINTOTRAY)
        WriteSetting("Software\CR Client\Settings", "AskExit", ASKEXIT)

        WriteSetting("Software\CR Client\Settings", "WinTopPos", Me.Top)
        WriteSetting("Software\CR Client\Settings", "WinLeftPos", Me.Left)

        If CONNECTEDFLAG Then
            Logoff()
        End If

    End Sub

    Private Sub tmLogout_Tick(sender As Object, e As System.EventArgs) Handles tmLogout.Tick
        If tmLogout.Interval / 60000 <> AUTOLOGDUR Then
            tmLogout.Interval = AUTOLOGDUR * 60000
        End If
        If AUTOLOG = True Then
            Login()
        Else
            Logoff()
            btnLogin.Enabled = True
            tmLogout.Enabled = False
        End If
    End Sub

    Private Sub NotifyIcon_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseClick
        If e.Button = MouseButtons.Right Then
            trayContextMenu.Show()
        Else
            NotifyIcon.Visible = False
            Me.Visible = True
            Me.Show()
        End If
    End Sub

    Private Sub ntfLogin_Click(sender As System.Object, e As System.EventArgs) Handles ntfLogin.Click
        btnLogin_Click(sender, e)
        'If txtUserName.Text.Trim <> "" And txtPassword.Text.Trim <> "" Then
        '    If LOGINSTATE = 1 Then
        '        ShowNotif("CR Client", "You've Successfully Logged-in!", 1)
        '        ntfLogin.Text = "Logout"
        '    ElseIf LOGINSTATE = 0 Then
        '        ShowNotif("Error", "Cannot log you in!" & vbCrLf & "Make sure you're connected with the network.", 2)
        '    End If
        'Else
        '    ShowNotif("CR Client", "You've Successfully Logged-out!", 1)
        '    ntfLogin.Text = "Login"
        'End If
        '    Else
        '        ShowNotif("Error", "User Name and Password cannot be empty!", 2)
        '    End If
        Select Case LOGINSTATE
            Case 0
                ShowNotif("Error", "Cannot log you in!" & vbCrLf & "Make sure you're connected with the network.", 2)
            Case 1
                ShowNotif("CR Client", "You've Successfully Logged-in!", 1)
                ntfLogin.Text = "Logout"
            Case 2
                ShowNotif("Error", "Problem occurred while logging you in.", 2)
            Case 3
                ShowNotif("CR Client", "You've Successfully Logged-out!", 1)
                ntfLogin.Text = "Login"
            Case 4
                ShowNotif("Error", "Problem occurred while logging you out.", 2)
        End Select
    End Sub

    Private Sub ntfNotify_CheckedChanged(sender As Object, e As System.EventArgs) Handles ntfNotify.CheckedChanged
        NOTIF = ntfNotify.Checked
    End Sub

    Private Sub ntfExit_Click(sender As System.Object, e As System.EventArgs) Handles ntfExit.Click
        If ASKEXIT Then
            Dim resp
            resp = MsgBox("Are you sure you want to exit?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CR Client")
            If resp = MsgBoxResult.Yes Then
                CRCLOSED = True
                Me.Close()
            End If
        Else
            CRCLOSED = True
            Me.Close()
        End If
    End Sub

    Private Sub tmAutoHide_Tick(sender As System.Object, e As System.EventArgs) Handles tmAutoHide.Tick
        Me.Opacity = 1
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        Me.Hide()
        tmAutoHide.Stop()
        NotifyIcon.Visible = True
        ntfLogin_Click(sender, e)
    End Sub
End Class
