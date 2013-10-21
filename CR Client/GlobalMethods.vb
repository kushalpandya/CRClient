Module GlobalMethods
    'Global Flags and Values
    Public IPADDR As String
    Public PORTNO As String
    Public AUTOLOG As Boolean
    Public AUTOLOGDUR As Integer
    Public AUTOSTART As Boolean
    Public NOTIF As Boolean
    Public MINTOTRAY As Boolean
    Public ASKEXIT As Boolean
    Public CONNECTEDFLAG As Boolean
    Public USERNAME As String
    Public PASSWORD As String
    Public PASSWORDSALT As String

    'Method to show message on main panel with type 1 for Information, 2 for Error
    Public Sub ShowMsg(msgstr As String, msgtype As Byte)
        frmMain.lblMsg.Text = msgstr
        If msgtype = 1 Then
            frmMain.lblMsg.ForeColor = Color.FromArgb(64, 64, 64)
        ElseIf msgtype = 2 Then
            frmMain.lblMsg.ForeColor = Color.Red
        End If
        frmMain.lblMsg.Left = frmMain.ClientSize.Width \ 2 - frmMain.lblMsg.Width \ 2
    End Sub

    Public Sub ShowNotif(msgtitle As String, msgstr As String, msgtype As Byte)
        If NOTIF Then
            If msgtype = 0 Then
                frmMain.NotifyIcon.BalloonTipIcon = ToolTipIcon.None
            ElseIf msgtype = 1 Then
                frmMain.NotifyIcon.BalloonTipIcon = ToolTipIcon.Info
            ElseIf msgtype = 2 Then
                frmMain.NotifyIcon.BalloonTipIcon = ToolTipIcon.Warning
            ElseIf msgtype = 3 Then
                frmMain.NotifyIcon.BalloonTipIcon = ToolTipIcon.Error
            End If
            With frmMain.NotifyIcon
                .BalloonTipTitle = msgtitle
                .BalloonTipText = msgstr
                .ShowBalloonTip(20)
            End With
        End If
    End Sub

    Function Encrypt(ByVal passwrd, ByVal saltval)
        Dim strBuff, i, c
        strBuff = ""
        For i = 1 To Len(passwrd)
            c = Asc(Mid(passwrd, i, 1))
            c = c + Asc(Mid(saltval, (i Mod Len(saltval)) + 1, 1))
            strBuff = strBuff & Chr(c And &HFF)
        Next
        Encrypt = strBuff
    End Function

    Function Decrypt(ByVal encpassword, ByVal saltval)
        Dim strBuff, i, c
        strBuff = ""
        For i = 1 To Len(encpassword)
            c = Asc(Mid(encpassword, i, 1))
            c = c - Asc(Mid(saltval, (i Mod Len(saltval)) + 1, 1))
            strBuff = strBuff & Chr(c And &HFF)
        Next
        Decrypt = strBuff
    End Function

    Public Function SettingsExist() As Boolean
        Dim defval As Byte = 0
        defval += ReadSetting("Software\CR Client\Settings", "Default")
        defval += ReadSetting("Software\CR Client\Vault", "Default")
        If defval = 2 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub AutoStartWindows(flag As Boolean)
        If flag Then
            WriteSetting("Software\Microsoft\Windows\CurrentVersion\Run", Application.ProductName, Application.ExecutablePath)
        Else
            DeleteKey(Application.ProductName)
        End If
    End Sub

    Public Sub InitValues()
        USERNAME = ReadSetting("Software\CR Client\Vault", "UserName")
        PASSWORDSALT = USERNAME
        Dim encpass As String
        encpass = ReadSetting("Software\CR Client\Vault", "Password")
        PASSWORD = Decrypt(encpass, PASSWORDSALT)
        IPADDR = ReadSetting("Software\CR Client\Settings", "IPAddr")
        PORTNO = ReadSetting("Software\CR Client\Settings", "PortNo")
        AUTOLOG = ReadSetting("Software\CR Client\Settings", "AutoLogin")
        AUTOLOGDUR = ReadSetting("Software\CR Client\Settings", "AutoLoginDur")
        AUTOSTART = ReadSetting("Software\CR Client\Settings", "AutoStart")
        NOTIF = ReadSetting("Software\CR Client\Settings", "Notify")
        MINTOTRAY = ReadSetting("Software\CR Client\Settings", "MinToTray")
        ASKEXIT = ReadSetting("Software\CR Client\Settings", "AskExit")
    End Sub

    Public Sub WriteDefaultSettings()
        WriteKey("Software", "CR Client")
        WriteKey("Software\CR Client", "Settings")
        Dim Parent As String
        Parent = "Software\CR Client\Settings"
        WriteSetting(Parent, "Default", 1)
        WriteSetting(Parent, "IPAddr", "10.100.56.55")
        WriteSetting(Parent, "PortNo", "8090")
        WriteSetting(Parent, "AutoLogin", True)
        WriteSetting(Parent, "AutoLoginDur", "120")
        WriteSetting(Parent, "AutoStart", False)
        WriteSetting(Parent, "Notify", True)
        WriteSetting(Parent, "MinToTray", True)
        WriteSetting(Parent, "AskExit", True)
        WriteSetting(Parent, "WinTopPos", 100)
        WriteSetting(Parent, "WinLeftPos", 100)

        WriteKey("Software\CR Client", "Vault")
        Parent = "Software\CR Client\Vault"
        WriteSetting(Parent, "Default", 1)
        WriteSetting(Parent, "UserName", "")
        WriteSetting(Parent, "Password", "")
    End Sub
End Module