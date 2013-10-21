Module UIMethods
    'Fills frm with Specified Linear Gradient from sColor to eColor with possible gradModes 0,1,2 or 3
    Public Sub LinearGradiant(frm As Form, sColor As Color, eColor As Color, ByVal e As System.Windows.Forms.PaintEventArgs, gradMode As Integer)
        Dim oRAngle As Rectangle = New Rectangle(0, 0, frm.Width, frm.Height)
        If gradMode = 0 Then
            Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, sColor, eColor, Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal)
            e.Graphics.FillRectangle(oGradientBrush, oRAngle)
        ElseIf gradMode = 1 Then
            Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, sColor, eColor, Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal)
            e.Graphics.FillRectangle(oGradientBrush, oRAngle)
        ElseIf gradMode = 2 Then
            Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, sColor, eColor, Drawing.Drawing2D.LinearGradientMode.Horizontal)
            e.Graphics.FillRectangle(oGradientBrush, oRAngle)
        ElseIf gradMode = 3 Then
            Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(oRAngle, sColor, eColor, Drawing.Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(oGradientBrush, oRAngle)
        End If
    End Sub

    Public Sub FormFadeIn(ByVal formObj As Form)
        For FadeIn = 0.0 To 1.1 Step 0.1
            formObj.Opacity = FadeIn
            formObj.Refresh()
            Threading.Thread.Sleep(100)
        Next
    End Sub

    Public Sub FormFadeOut(ByVal formObj As Form)
        For FadeOut = 90 To 10 Step -10
            formObj.Opacity = FadeOut / 100
            formObj.Refresh()
            Threading.Thread.Sleep(50)
        Next
    End Sub
End Module
