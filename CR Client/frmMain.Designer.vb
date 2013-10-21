<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblBar = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTitleBar = New System.Windows.Forms.Label()
        Me.ControlImages = New System.Windows.Forms.ImageList(Me.components)
        Me.lblMain = New System.Windows.Forms.Label()
        Me.lblOptions = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.chkMinTray = New System.Windows.Forms.CheckBox()
        Me.chkNotify = New System.Windows.Forms.CheckBox()
        Me.chkAutoStart = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLoginDuration = New System.Windows.Forms.TextBox()
        Me.chkAutoLogin = New System.Windows.Forms.CheckBox()
        Me.chkAskExit = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtIPAddr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblAbout = New System.Windows.Forms.Label()
        Me.NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.trayContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ntfLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntfNotify = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntfExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblClose = New System.Windows.Forms.Label()
        Me.tmLogout = New System.Windows.Forms.Timer(Me.components)
        Me.tmAutoHide = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMain.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.trayContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBar
        '
        Me.lblBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblBar.Location = New System.Drawing.Point(12, 0)
        Me.lblBar.Name = "lblBar"
        Me.lblBar.Size = New System.Drawing.Size(10, 51)
        Me.lblBar.TabIndex = 11
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(28, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(137, 41)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "CR Client"
        '
        'lblTitleBar
        '
        Me.lblTitleBar.BackColor = System.Drawing.Color.Transparent
        Me.lblTitleBar.Location = New System.Drawing.Point(2, 2)
        Me.lblTitleBar.Name = "lblTitleBar"
        Me.lblTitleBar.Size = New System.Drawing.Size(473, 31)
        Me.lblTitleBar.TabIndex = 10
        '
        'ControlImages
        '
        Me.ControlImages.ImageStream = CType(resources.GetObject("ControlImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ControlImages.TransparentColor = System.Drawing.Color.Transparent
        Me.ControlImages.Images.SetKeyName(0, "close.png")
        Me.ControlImages.Images.SetKeyName(1, "close_hover.png")
        '
        'lblMain
        '
        Me.lblMain.BackColor = System.Drawing.Color.Transparent
        Me.lblMain.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMain.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMain.ForeColor = System.Drawing.Color.Black
        Me.lblMain.Location = New System.Drawing.Point(29, 58)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(71, 34)
        Me.lblMain.TabIndex = 13
        Me.lblMain.Text = "main"
        '
        'lblOptions
        '
        Me.lblOptions.BackColor = System.Drawing.Color.Transparent
        Me.lblOptions.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblOptions.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptions.ForeColor = System.Drawing.Color.Gray
        Me.lblOptions.Location = New System.Drawing.Point(106, 58)
        Me.lblOptions.Name = "lblOptions"
        Me.lblOptions.Size = New System.Drawing.Size(97, 34)
        Me.lblOptions.TabIndex = 14
        Me.lblOptions.Text = "options"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.Transparent
        Me.pnlMain.Controls.Add(Me.lblMsg)
        Me.pnlMain.Controls.Add(Me.btnLogin)
        Me.pnlMain.Controls.Add(Me.txtPassword)
        Me.pnlMain.Controls.Add(Me.txtUserName)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Location = New System.Drawing.Point(12, 95)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(499, 278)
        Me.pnlMain.TabIndex = 15
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.BackColor = System.Drawing.Color.Transparent
        Me.lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMsg.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMsg.Location = New System.Drawing.Point(252, 149)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(0, 21)
        Me.lblMsg.TabIndex = 19
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLogin
        '
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Location = New System.Drawing.Point(178, 187)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(151, 42)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Location = New System.Drawing.Point(178, 105)
        Me.txtPassword.MaxLength = 60
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.Size = New System.Drawing.Size(248, 26)
        Me.txtPassword.TabIndex = 1
        '
        'txtUserName
        '
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUserName.Location = New System.Drawing.Point(178, 50)
        Me.txtUserName.MaxLength = 60
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(248, 26)
        Me.txtUserName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(67, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 28)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(67, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 28)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "User Name"
        '
        'pnlOptions
        '
        Me.pnlOptions.BackColor = System.Drawing.Color.Transparent
        Me.pnlOptions.Controls.Add(Me.btnCheck)
        Me.pnlOptions.Controls.Add(Me.chkMinTray)
        Me.pnlOptions.Controls.Add(Me.chkNotify)
        Me.pnlOptions.Controls.Add(Me.chkAutoStart)
        Me.pnlOptions.Controls.Add(Me.Label5)
        Me.pnlOptions.Controls.Add(Me.txtLoginDuration)
        Me.pnlOptions.Controls.Add(Me.chkAutoLogin)
        Me.pnlOptions.Controls.Add(Me.chkAskExit)
        Me.pnlOptions.Controls.Add(Me.Label4)
        Me.pnlOptions.Controls.Add(Me.txtPort)
        Me.pnlOptions.Controls.Add(Me.txtIPAddr)
        Me.pnlOptions.Controls.Add(Me.Label3)
        Me.pnlOptions.Location = New System.Drawing.Point(12, 95)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(499, 278)
        Me.pnlOptions.TabIndex = 16
        Me.pnlOptions.Visible = False
        '
        'btnCheck
        '
        Me.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheck.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheck.Location = New System.Drawing.Point(391, 20)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(75, 28)
        Me.btnCheck.TabIndex = 12
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'chkMinTray
        '
        Me.chkMinTray.AutoSize = True
        Me.chkMinTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMinTray.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkMinTray.Location = New System.Drawing.Point(23, 192)
        Me.chkMinTray.Name = "chkMinTray"
        Me.chkMinTray.Size = New System.Drawing.Size(231, 29)
        Me.chkMinTray.TabIndex = 17
        Me.chkMinTray.Text = "Minimize to Tray on exit"
        Me.chkMinTray.UseVisualStyleBackColor = True
        '
        'chkNotify
        '
        Me.chkNotify.AutoSize = True
        Me.chkNotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNotify.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkNotify.Location = New System.Drawing.Point(23, 150)
        Me.chkNotify.Name = "chkNotify"
        Me.chkNotify.Size = New System.Drawing.Size(254, 29)
        Me.chkNotify.TabIndex = 16
        Me.chkNotify.Text = "Show desktop notifications"
        Me.chkNotify.UseVisualStyleBackColor = True
        '
        'chkAutoStart
        '
        Me.chkAutoStart.AutoSize = True
        Me.chkAutoStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAutoStart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkAutoStart.Location = New System.Drawing.Point(23, 106)
        Me.chkAutoStart.Name = "chkAutoStart"
        Me.chkAutoStart.Size = New System.Drawing.Size(229, 29)
        Me.chkAutoStart.TabIndex = 15
        Me.chkAutoStart.Text = "Autostart with Windows"
        Me.chkAutoStart.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Enabled = False
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(298, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 28)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Minutes"
        '
        'txtLoginDuration
        '
        Me.txtLoginDuration.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLoginDuration.Enabled = False
        Me.txtLoginDuration.Location = New System.Drawing.Point(218, 64)
        Me.txtLoginDuration.MaxLength = 4
        Me.txtLoginDuration.Name = "txtLoginDuration"
        Me.txtLoginDuration.Size = New System.Drawing.Size(69, 26)
        Me.txtLoginDuration.TabIndex = 14
        '
        'chkAutoLogin
        '
        Me.chkAutoLogin.AutoSize = True
        Me.chkAutoLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAutoLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkAutoLogin.Location = New System.Drawing.Point(23, 62)
        Me.chkAutoLogin.Name = "chkAutoLogin"
        Me.chkAutoLogin.Size = New System.Drawing.Size(170, 29)
        Me.chkAutoLogin.TabIndex = 13
        Me.chkAutoLogin.Text = "Auto Login Every"
        Me.chkAutoLogin.UseVisualStyleBackColor = True
        '
        'chkAskExit
        '
        Me.chkAskExit.AutoSize = True
        Me.chkAskExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAskExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkAskExit.Location = New System.Drawing.Point(23, 232)
        Me.chkAskExit.Name = "chkAskExit"
        Me.chkAskExit.Size = New System.Drawing.Size(119, 29)
        Me.chkAskExit.TabIndex = 18
        Me.chkAskExit.Text = "Ask on Exit"
        Me.chkAskExit.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(282, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 28)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = ":"
        '
        'txtPort
        '
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPort.Location = New System.Drawing.Point(303, 20)
        Me.txtPort.MaxLength = 5
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(69, 26)
        Me.txtPort.TabIndex = 11
        Me.txtPort.Text = "8090"
        '
        'txtIPAddr
        '
        Me.txtIPAddr.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIPAddr.Location = New System.Drawing.Point(144, 20)
        Me.txtIPAddr.MaxLength = 15
        Me.txtIPAddr.Name = "txtIPAddr"
        Me.txtIPAddr.Size = New System.Drawing.Size(133, 26)
        Me.txtIPAddr.TabIndex = 10
        Me.txtIPAddr.Text = "10.100.56.55"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(18, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 28)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "IP / Port"
        '
        'lblAbout
        '
        Me.lblAbout.BackColor = System.Drawing.Color.Transparent
        Me.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblAbout.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbout.ForeColor = System.Drawing.Color.Gray
        Me.lblAbout.Location = New System.Drawing.Point(209, 58)
        Me.lblAbout.Name = "lblAbout"
        Me.lblAbout.Size = New System.Drawing.Size(77, 34)
        Me.lblAbout.TabIndex = 17
        Me.lblAbout.Text = "about"
        '
        'NotifyIcon
        '
        Me.NotifyIcon.ContextMenuStrip = Me.trayContextMenu
        Me.NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), System.Drawing.Icon)
        Me.NotifyIcon.Text = "CR Client"
        '
        'trayContextMenu
        '
        Me.trayContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ntfLogin, Me.ntfNotify, Me.ntfExit})
        Me.trayContextMenu.Name = "trayContextMenu"
        Me.trayContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.trayContextMenu.Size = New System.Drawing.Size(175, 92)
        '
        'ntfLogin
        '
        Me.ntfLogin.Name = "ntfLogin"
        Me.ntfLogin.Size = New System.Drawing.Size(174, 22)
        Me.ntfLogin.Text = "Login"
        '
        'ntfNotify
        '
        Me.ntfNotify.CheckOnClick = True
        Me.ntfNotify.Name = "ntfNotify"
        Me.ntfNotify.Size = New System.Drawing.Size(174, 22)
        Me.ntfNotify.Text = "Show Notifications"
        Me.ntfNotify.ToolTipText = "Show Desktop Notifications"
        '
        'ntfExit
        '
        Me.ntfExit.Name = "ntfExit"
        Me.ntfExit.Size = New System.Drawing.Size(174, 22)
        Me.ntfExit.Text = "Exit"
        '
        'lblClose
        '
        Me.lblClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClose.ImageKey = "close.png"
        Me.lblClose.ImageList = Me.ControlImages
        Me.lblClose.Location = New System.Drawing.Point(475, -17)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(62, 64)
        Me.lblClose.TabIndex = 18
        '
        'tmLogout
        '
        Me.tmLogout.Interval = 7200000
        '
        'tmAutoHide
        '
        Me.tmAutoHide.Interval = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(522, 385)
        Me.Controls.Add(Me.lblAbout)
        Me.Controls.Add(Me.lblOptions)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.lblMain)
        Me.Controls.Add(Me.lblBar)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.lblTitleBar)
        Me.Controls.Add(Me.pnlOptions)
        Me.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmMain"
        Me.Text = "CR Client"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlOptions.ResumeLayout(False)
        Me.pnlOptions.PerformLayout()
        Me.trayContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblBar As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTitleBar As System.Windows.Forms.Label
    Friend WithEvents ControlImages As System.Windows.Forms.ImageList
    Friend WithEvents lblMain As System.Windows.Forms.Label
    Friend WithEvents lblOptions As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents txtIPAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents chkNotify As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoStart As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLoginDuration As System.Windows.Forms.TextBox
    Friend WithEvents chkAutoLogin As System.Windows.Forms.CheckBox
    Friend WithEvents chkAskExit As System.Windows.Forms.CheckBox
    Friend WithEvents chkMinTray As System.Windows.Forms.CheckBox
    Friend WithEvents btnCheck As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblAbout As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents trayContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ntfLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntfExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntfNotify As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblClose As System.Windows.Forms.Label
    Friend WithEvents tmLogout As System.Windows.Forms.Timer
    Friend WithEvents tmAutoHide As System.Windows.Forms.Timer

End Class
