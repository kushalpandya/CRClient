Public Class frmAbout
    Dim ABTCLOSED As Boolean

    Private Const CS_DROPSHADOW As Int32 = &H20000

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim parameters As CreateParams = MyBase.CreateParams
            parameters.ClassStyle += CS_DROPSHADOW
            Return parameters
        End Get
    End Property

    Private Sub frmAbout_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ABTCLOSED = False
        Me.DoubleBuffered = True
        Me.SetStyle(
         ControlStyles.AllPaintingInWmPaint Or _
         ControlStyles.UserPaint Or _
         ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Private Sub frmAbout_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim c1 As Color
        Dim c2 As Color
        c1 = Color.Silver
        c2 = Color.FromArgb(245, 245, 245)
        LinearGradiant(Me, c1, c2, e, 1)
    End Sub

    Private Sub lblClose_MouseEnter(sender As Object, e As System.EventArgs) Handles lblClose.MouseEnter
        lblClose.Image = ControlImages.Images.Item(1)
    End Sub

    Private Sub lblClose_MouseLeave(sender As Object, e As System.EventArgs) Handles lblClose.MouseLeave
        If Not ABTCLOSED Then
            lblClose.Image = ControlImages.Images.Item(0)
        End If
    End Sub

    Private Sub lblClose_Click(sender As System.Object, e As System.EventArgs) Handles lblClose.Click
        ABTCLOSED = True
        lblClose.Image = ControlImages.Images.Item(0)
        Me.Close()
    End Sub
End Class