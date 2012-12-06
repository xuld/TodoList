Public Class FormMain

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Me.PropertyLinkerProvider1.SetSourceProperty(Me.Label3, "Value")
    End Sub

    Private Sub _GotFocus(sender As Object, e As EventArgs) Handles ScrollRangeBar1.GotFocus, Switch1.GotFocus, SearchControl1.GotFocus, Me.Click
        Me.PropertyGrid1.SelectedObject = sender
    End Sub

End Class