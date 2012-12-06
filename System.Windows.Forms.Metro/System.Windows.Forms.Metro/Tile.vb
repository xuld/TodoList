Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design

Namespace System.Windows.Forms.Metro

    <DefaultEvent("Click")> _
    <Serializable()> _
    Public Class Tile

        Public Enum Styles As Integer
            [Single]
            [Double]
        End Enum

        Private _Style As Styles = Styles.Single
        <DefaultValue(Styles.Single)> _
        Public Property Style As Styles
            Get
                Return _Style
            End Get
            Set(value As Styles)
                If _Style <> value Then
                    _Style = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _Checked As Boolean = False
        <DefaultValue(False)> _
        Public Property Checked As Boolean
            Get
                Return _Checked
            End Get
            Set(value As Boolean)
                If _Checked <> value Then
                    _Checked = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _CheckedBorderColor As System.Drawing.Color = System.Drawing.Color.FromArgb(45, 137, 239)
        Public Property CheckedBorderColor As System.Drawing.Color
            Get
                Return _CheckedBorderColor
            End Get
            Set(value As System.Drawing.Color)
                If _CheckedBorderColor <> value Then
                    _CheckedBorderColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _BrandColor As System.Drawing.Color = System.Drawing.Color.Transparent
        Public Property BrandColor As System.Drawing.Color
            Get
                Return _BrandColor
            End Get
            Set(value As System.Drawing.Color)
                If _BrandColor <> value Then
                    _BrandColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _AllowCheck As Boolean = False
        <DefaultValue(False)> _
        Public Property AllowCheck As Boolean
            Get
                Return _AllowCheck
            End Get
            Set(value As Boolean)
                If _AllowCheck <> value Then
                    _AllowCheck = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _Title As String = "Tile"
        <Browsable(True)> _
        <DefaultValue("Tile")> _
        <Editor(GetType(MultilineStringEditor), GetType(UITypeEditor))> _
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

        Protected Overrides Sub OnPaint(e As PaintEventArgs)

            Select Case Me.Style
                Case Styles.Single
                    Me.Size = New System.Drawing.Size(150, 150)
                    e.Graphics.DrawString(Me.Title, _
                                 New System.Drawing.Font("Segoe UI", 9), _
                                 Brushes.White, _
                                 New System.Drawing.Point(15, Me.Height - 25))

                    If Me.Image IsNot Nothing Then
                        e.Graphics.DrawImage(Me.Image, CInt((Me.Width / 2) - 32), CInt((Me.Height / 2) - 32), 64, 64)
                    End If

                Case Else
                    Me.Size = New System.Drawing.Size(310, 150)

                    If Me.BackgroundImage Is Nothing Then

                        Dim _source As String() = Split(Me.Title, vbCrLf)
                        Dim _line1 As String = Nothing
                        Dim _line2 As String = Nothing
                        If _source.Length > 0 Then _line1 = _source(0)
                        If _source.Length > 1 Then _line2 = Me.Title.Replace(_line1 & vbCrLf, "")

                        e.Graphics.DrawString(_line1, _
                                    New System.Drawing.Font("Segoe UI", 20), _
                                    Brushes.White, _
                                    New System.Drawing.Point(15, 10))

                        e.Graphics.DrawString(_line2, _
                                   New System.Drawing.Font("Segoe UI", 9), _
                                   Brushes.White, _
                                   New System.Drawing.Point(15, e.Graphics.MeasureString(_line1, New System.Drawing.Font("Segoe UI", 20)).Height + 10)) '+6

                    Else

                        If Me.BrandColor <> System.Drawing.Color.Transparent Then
                            Dim _brand As New System.Drawing.Rectangle(0, Me.Height - 46, Me.Width, 46)
                            e.Graphics.FillRectangle(New System.Drawing.SolidBrush(Me.BrandColor), _brand)
                        End If

                        e.Graphics.DrawString(Me.Title, _
                                                        New System.Drawing.Font("Segoe UI", 9), _
                                                        Brushes.White, _
                                                        New System.Drawing.Point(32 + 20, Me.Height - 46 + 5))
                    End If

                    If Me.Image IsNot Nothing Then
                        e.Graphics.DrawImage(Me.Image, 10, Me.Height - 46 + 5, 32, 32)
                    End If

            End Select

            If Me.ShowBadge Then
                Dim _mb As System.Drawing.SizeF = e.Graphics.MeasureString(Me.Badge, New System.Drawing.Font("Segoe UI", 11))
                e.Graphics.DrawString(Me.Badge, _
                                      New System.Drawing.Font("Segoe UI", 11), _
                                      Brushes.White, _
                                      New System.Drawing.Point(Me.Width - _mb.Width - 20 + (e.Graphics.MeasureString(Me.Badge, New System.Drawing.Font("Segoe UI", 11)).Width / 2), Me.Height - 28))
            End If

            If Me.AllowCheck And Me.Checked Then
                Dim _rect As New System.Drawing.Rectangle(2, 2, Me.Width - 4, Me.Height - 4)
                e.Graphics.DrawRectangle(New System.Drawing.Pen(Me.CheckedBorderColor, 4), _rect)

                Dim _corn As New List(Of System.Drawing.Point)
                _corn.Add(New System.Drawing.Point(Me.Width - 50, 0))
                _corn.Add(New System.Drawing.Point(Me.Width, 0))
                _corn.Add(New System.Drawing.Point(Me.Width, 50))

                e.Graphics.FillPolygon(New System.Drawing.SolidBrush(Me.CheckedBorderColor), _corn.ToArray)

                e.Graphics.DrawString("✔", New System.Drawing.Font("Segoe UI", 12), _
                                      Brushes.White, _
                                      CInt(Me.Width - e.Graphics.MeasureString("✔", New System.Drawing.Font("Segoe UI", 12)).Width - 5), 5)
            End If

        End Sub
        Protected Overrides Sub OnClick(e As EventArgs)

            If Me.AllowCheck Then
                Me.Checked = Not Me.Checked
            End If

            MyBase.OnClick(e)
        End Sub

        Private Sub Tile_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
            Me.InvokeGotFocus(Me, New EventArgs)
        End Sub

        Private Sub Tile_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            Me.Left += 1
            Me.Top += 1
        End Sub
        Private Sub Tile_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            Me.Left -= 1
            Me.Top -= 1
        End Sub

        Private Sub Tile_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter, Me.GotFocus
            Dim _rect As New Rectangle(0, 0, Me.Width, Me.Height)
            Me.CreateGraphics.DrawRectangle(New System.Drawing.Pen(Me.CheckedBorderColor, 4), _rect)
        End Sub

        Private Sub Tile_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave, Me.LostFocus
            Me.Invalidate()
        End Sub
       

    End Class

End Namespace