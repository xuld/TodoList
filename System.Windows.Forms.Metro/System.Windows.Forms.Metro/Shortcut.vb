Imports System.ComponentModel

Namespace System.Windows.Forms.Metro

    Public Class Shortcut
        Inherits System.Windows.Forms.Control

        Private _Image As System.Drawing.Image
        Public Property Image As System.Drawing.Image
            Get
                Return _Image
            End Get
            Set(value As System.Drawing.Image)
                If _Image IsNot value Then
                    _Image = value
                    Me.Invalidate()
                End If
            End Set
        End Property
        Public Property HoverColor As System.Drawing.Color = Color.DarkRed
        Private _Title As String = "Title"
        <DefaultValue("Title")> _
        Public Property Title As String
            Get
                Return _Title
            End Get
            Set(value As String)
                If _Title <> value Then
                    _Title = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _Badge As String = "0"
        <DefaultValue("0")> _
        Public Property Badge As String
            Get
                Return _Badge
            End Get
            Set(value As String)
                If _Badge <> value Then
                    _Badge = value
                    Me.Invalidate()
                End If
            End Set
        End Property
        Private _ShowBadge As Boolean = True
        <DefaultValue(True)> _
        Public Property ShowBadge As Boolean
            Get
                Return _ShowBadge
            End Get
            Set(value As Boolean)
                If _ShowBadge <> value Then
                    _ShowBadge = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _BadgeColor As System.Drawing.Color
        Public Property BadgeColor As System.Drawing.Color
            Get
                Return _BadgeColor
            End Get
            Set(value As System.Drawing.Color)
                If _BadgeColor <> value Then
                    _BadgeColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Protected Overrides Sub OnPaint(e As PaintEventArgs)

            Dim _m As SizeF = e.Graphics.MeasureString(Me.Title, New System.Drawing.Font("Segoe UI", 9))
            e.Graphics.DrawString(Me.Title, New System.Drawing.Font("Segoe UI", 9), _
                                  New System.Drawing.SolidBrush(Me.ForeColor), _
                                  New System.Drawing.Point((Me.Width - _m.Width) / 2, ((Me.Height + _m.Height + 45) / 2) - 6))

            If Me.Image IsNot Nothing Then
                e.Graphics.DrawImage(Me.Image, CInt((Me.Width - 45) / 2), CInt((Me.Height - 45) / 2) - (_m.Height / 2), 45, 45)
            End If

            If Me.ShowBadge Then
                Dim _badgerect As New System.Drawing.Rectangle(Me.Width - 20, 0, 20, 20)
                e.Graphics.FillRectangle(New System.Drawing.SolidBrush(Me.BadgeColor), _badgerect)

                Dim _BadgeTemp As String = Me.Badge
                If _BadgeTemp.Length > 2 Then _BadgeTemp = _BadgeTemp.Substring(0, 2)

                Dim _mb As SizeF = e.Graphics.MeasureString(_BadgeTemp, New System.Drawing.Font("Segoe UI", 9))
                e.Graphics.DrawString(_BadgeTemp, New System.Drawing.Font("Segoe UI", 9), _
                               New System.Drawing.SolidBrush(Color.White), _
                               New System.Drawing.Point(Me.Width - ((_m.Width - _mb.Width) / 2) - _mb.Width + 3, 1))
            End If

        End Sub

        Sub New()

            Me.Size = New System.Drawing.Size(92, 92)
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))

        End Sub

        Private Sub Shortcut_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
            Me.InvokeGotFocus(Me, New EventArgs)
        End Sub

        Private Sub Shortcut_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            Me.Left += 1
            Me.Top += 1
        End Sub
        Private Sub Shortcut_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            Me.Left -= 1
            Me.Top -= 1           
        End Sub

        Private Sub Shortcut_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
            Me.CreateGraphics.DrawLine(New System.Drawing.Pen(Me.HoverColor, 2), 0, Me.Height - 2, Me.Width, Me.Height - 2)
        End Sub

        Private Sub Shortcut_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
            Me.Invalidate()
        End Sub

      
    End Class

End Namespace