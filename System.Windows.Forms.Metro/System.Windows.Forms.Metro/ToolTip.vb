Imports System.ComponentModel

Namespace System.Windows.Forms.Metro

    <ToolboxBitmap(GetType(System.Windows.Forms.ToolTip))> _
    Public Class ToolTip
        Inherits System.Windows.Forms.ToolTip

        Public Sub New()
            Me.InitialDelay = 1000
            Me.BackColor = System.Drawing.Color.Black
            Me.ForeColor = Color.White
            Me.UseFading = True
            Me.UseAnimation = True
            Me.OwnerDraw = True
            Me.AutomaticDelay = 500
            Me.AutoPopDelay = 2000
        End Sub

        Private Sub ToolTip_Draw(sender As Object, e As DrawToolTipEventArgs) Handles Me.Draw
            e.DrawBackground()
            e.DrawText() 'TextFormatFlags.WordBreak)
        End Sub

        Private Sub ToolTip_Popup(sender As Object, e As PopupEventArgs) Handles Me.Popup
            If Me.BackColor.GetBrightness >= 0.5 Then Me.ForeColor = Color.White
        End Sub

    End Class

End Namespace