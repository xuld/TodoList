Namespace System.Windows.Forms.Metro

    Public Class StatusStrip

        Protected Overrides Sub OnPaint(e As PaintEventArgs)

            If TypeOf Me.FindForm Is Metro.Form Then
                With CType(Me.FindForm, Metro.Form)
                    Me.BackColor = .DominantColor

                    For Each item As ToolStripItem In Me.Items
                        item.ForeColor = IIf(Me.BackColor.GetBrightness >= 0.5, Me.ForeColor, System.Drawing.Color.White)
                    Next

                    .PictureBoxSizingGrip.BackColor = Me.BackColor
                    .PictureBoxSizingGrip.Image = IIf(Me.BackColor.GetBrightness >= 0.5, My.Resources.resize_d, My.Resources.resize_l)

                    Me.SendToBack()

                End With

            End If

            MyBase.OnPaint(e)

        End Sub

    End Class

End Namespace