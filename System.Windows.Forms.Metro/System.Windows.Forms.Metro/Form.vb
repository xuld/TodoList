Imports System.ComponentModel

Namespace System.Windows.Forms.Metro

    Public Class Form

        Sub New()

            ' Llamada necesaria para el diseñador.
            InitializeComponent()

            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.DoubleBuffered = True

        End Sub

#Region " Properties "

        Private _DominantColor As System.Drawing.Color = Nothing
        Public Property DominantColor As System.Drawing.Color
            Get
                Return _DominantColor
            End Get
            Set(value As System.Drawing.Color)
                If _DominantColor <> value Then
                    _DominantColor = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _BorderWidth As Integer = 1
        <DefaultValue(1)> _
        Public Property BorderWidth As Integer
            Get
                Return _BorderWidth
            End Get
            Set(value As Integer)
                If _BorderWidth <> value Then
                    _BorderWidth = value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Private _SizingGrip As Boolean = True
        <DefaultValue(True)> _
        Public Property SizingGrip As Boolean
            Get
                Return _SizingGrip
            End Get
            Set(value As Boolean)
                If _SizingGrip <> value Then
                    _SizingGrip = value
                    Me.Invalidate()
                End If
            End Set
        End Property

#End Region

#Region " Form moving "

        Private Const WM_SYSCOMMAND As Integer = &H112&
        Private Const MOUSE_MOVE As Integer = &HF012&

        <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="ReleaseCapture")> _
        Private Shared Sub ReleaseCapture()
        End Sub

        <System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint:="SendMessage")> _
        Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
        End Sub

        Private Sub MoveForm()
            ReleaseCapture()
            SendMessage(Me.Handle, WM_SYSCOMMAND, MOUSE_MOVE, 0)
        End Sub

        Private m_Size As System.Drawing.Size

        Private Sub Form_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, LabelTitle.MouseMove
            If e.Button = Windows.Forms.MouseButtons.Left Then

                If m_Size <> Nothing Then
                    Me.Size = m_Size
                    m_Size = Nothing
                End If

                MoveForm()

                If Me.MaximizeBox Then

                    If Me.Left <= 0 Then
                        If Me.Size <> New System.Drawing.Size((My.Computer.Screen.WorkingArea.Width / 2), My.Computer.Screen.WorkingArea.Height) And _
                            Me.Location <> New System.Drawing.Point(0, 0) Then

                            m_Size = Me.Size
                            Me.Size = New System.Drawing.Size((My.Computer.Screen.WorkingArea.Width / 2), My.Computer.Screen.WorkingArea.Height)
                            Me.Location = New System.Drawing.Point(0, 0)


                        End If
                    ElseIf Me.Left >= (My.Computer.Screen.WorkingArea.Width - e.Location.X) - 1 Then
                        If Me.Size <> New System.Drawing.Size(My.Computer.Screen.WorkingArea.Width / 2, My.Computer.Screen.WorkingArea.Height) And _
                          Me.Location <> New System.Drawing.Point((My.Computer.Screen.WorkingArea.Width - Me.Width), 0) Then

                            m_Size = Me.Size
                            Me.Size = New System.Drawing.Size((My.Computer.Screen.WorkingArea.Width / 2), My.Computer.Screen.WorkingArea.Height)
                            Me.Location = New System.Drawing.Point((My.Computer.Screen.WorkingArea.Width - Me.Width), 0)

                        End If

                    ElseIf Me.Top <= 0 Then
                        Me.ButtonMaximizeRestore.PerformClick()

                    End If

                End If
            End If
        End Sub

#End Region


        Private _TextReducted As Boolean = False

        Protected Overrides Sub OnPaint(e As PaintEventArgs)

            If Me.Width <= (Me.LabelTitle.Left + Me.LabelTitle.Width + (Me.ButtonMinimize.Width * 3)) Then
                Do While Me.Width <= (Me.LabelTitle.Left + Me.LabelTitle.Width + (Me.ButtonMinimize.Width * 3))
                    Me.LabelTitle.Text = Me.LabelTitle.Text.Substring(0, Me.LabelTitle.Text.Length - (3 + IIf(Me.LabelTitle.Text.EndsWith("..."), 3, 0))) & "..."
                Loop
                _TextReducted = True
            Else
                If _TextReducted = False Then
                    Me.LabelTitle.Text = Me.Text
                Else
                    _TextReducted = False
                End If

            End If

            If Me.WindowState = FormWindowState.Normal Then
                Dim _p As New System.Drawing.Pen(DominantColor, 1)
                e.Graphics.DrawRectangle(_p, 0, 0, Me.Width - Me.BorderWidth, Me.Height - Me.BorderWidth)
            End If

            Me.ButtonMinimize.Visible = Me.MinimizeBox And Me.ControlBox
            Me.ToolStripMenuItemMinimize.Enabled = Me.ButtonMinimize.Visible
            Me.ButtonMaximizeRestore.Visible = Me.MaximizeBox And Me.ControlBox
            Me.ToolStripMenuItemMaximize.Enabled = Me.ButtonMaximizeRestore.Visible And WindowState <> FormWindowState.Maximized
            Me.ToolStripMenuItemRestore.Enabled = Me.ButtonMaximizeRestore.Visible And WindowState = FormWindowState.Maximized
            Me.ButtonClose.Visible = Me.ControlBox
            Me.ToolStripMenuItemClose.Enabled = Me.ButtonClose.Visible

            Me.PictureBoxIcon.Image = Me.Icon.ToBitmap
            Me.PictureBoxIcon.Visible = Me.ShowIcon

            Me.ButtonMinimize.FlatAppearance.MouseDownBackColor = Me.DominantColor
            Me.ButtonMaximizeRestore.FlatAppearance.MouseDownBackColor = Me.DominantColor
            Me.ButtonClose.FlatAppearance.MouseDownBackColor = Me.DominantColor

            Me.PictureBoxSizingGrip.Visible = Me.SizingGrip And Me.WindowState = FormWindowState.Normal

            Me.ToolTipMetro.BackColor = Me.DominantColor

            Me.LabelTitle.Left = IIf(Me.ShowIcon, Me.PictureBoxIcon.Left + Me.PictureBoxIcon.Width, Me.PictureBoxIcon.Left)

            Select Case Me.DominantColor.GetBrightness * 100
                Case Is >= 50
                    Me.ToolTipMetro.ForeColor = Me.ForeColor
                Case Else
                    Me.ToolTipMetro.ForeColor = System.Drawing.Color.White
            End Select

            Select Case Me.BackColor.GetBrightness * 100
                Case Is >= 50
                    Me.ButtonMinimize.Image = My.Resources.minimize_d
                    Me.ButtonMaximizeRestore.Image = IIf(Me.WindowState = FormWindowState.Normal, My.Resources.maximize_d, My.Resources.restore_d)
                    Me.ButtonClose.Image = My.Resources.close_d
                    Me.PictureBoxSizingGrip.Image = My.Resources.resize_d
                    'Me.ForeColor = System.Drawing.Color.White

                Case Else
                    Me.ButtonMinimize.Image = My.Resources.minimize_l
                    Me.ButtonMaximizeRestore.Image = IIf(Me.WindowState = FormWindowState.Normal, My.Resources.maximize_l, My.Resources.restore_l)
                    Me.ButtonClose.Image = My.Resources.close_l
                    Me.PictureBoxSizingGrip.Image = My.Resources.resize_l
                    'Me.ForeColor = System.Drawing.Color.Black


            End Select

        End Sub

        Public Event CloseClick As EventHandler
        Public Event MaximizeClick As EventHandler
        Public Event RestoreClick As EventHandler
        Public Event MinimizeClick As EventHandler

        Friend Overridable Sub OnMinimize_Click(sender As Object, e As EventArgs) Handles ButtonMinimize.Click, ToolStripMenuItemMinimize.Click
            Me.WindowState = FormWindowState.Minimized
            RaiseEvent MinimizeClick(Me, e)
        End Sub
        Friend Overridable Sub OnMaximizeClick(sender As Object, e As EventArgs) Handles ButtonMaximizeRestore.Click, ToolStripMenuItemMaximize.Click
            If Me.WindowState = FormWindowState.Normal Then
                Me.WindowState = FormWindowState.Maximized
                RaiseEvent MaximizeClick(Me, e)
            Else
                Me.WindowState = FormWindowState.Normal
                RaiseEvent RestoreClick(Me, e)
            End If
        End Sub
        Friend Overridable Sub OnRestoreClick(sender As Object, e As EventArgs) Handles ToolStripMenuItemRestore.Click 'Handles ButtonMaximizeRestore.Click
            OnMaximizeClick(sender, e)
        End Sub
        Friend Overridable Sub OnCloseClick(sender As Object, e As EventArgs) Handles ButtonClose.Click, ToolStripMenuItemClose.Click
            RaiseEvent CloseClick(Me, e)
            Me.Close()
        End Sub

        Private Sub Form_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            Me.Invalidate()
        End Sub

        Private Sub Form_Click(sender As Object, e As MouseEventArgs) Handles PictureBoxIcon.MouseClick, Me.MouseClick, LabelTitle.MouseClick
            If sender Is PictureBoxIcon Then
                If e.Button = Windows.Forms.MouseButtons.Left Then _
                PictureBoxIcon.ContextMenuStrip.Show(PictureBoxIcon, PictureBoxIcon.Location)
            Else
                If e.Button = Windows.Forms.MouseButtons.Right Then
                    Dim _rect As New System.Drawing.Rectangle(0, 0, Me.Width, Me.PictureBoxIcon.Height + Me.PictureBoxIcon.Top)
                    If _rect.Contains(e.X, e.Y) Then
                        PictureBoxIcon.ContextMenuStrip.Show(sender, e.Location)
                    End If
                End If
            End If
        End Sub

        Private Sub Form_DoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick, LabelTitle.MouseDoubleClick
            Dim _rect As New System.Drawing.Rectangle(0, 0, Me.Width, Me.PictureBoxIcon.Height + Me.PictureBoxIcon.Top)
            If _rect.Contains(e.X, e.Y) Then
                Me.ButtonMaximizeRestore.PerformClick()
            End If

        End Sub

        Private Sub Resize_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBoxSizingGrip.MouseMove
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Me.Size = New System.Drawing.Size(Me.Size.Width + e.X, Me.Size.Height + e.Y)
            End If
        End Sub

        'Private Sub Form_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
        '    Me.SuspendLayout()
        'End Sub

        'Private Sub Form_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        '    Me.ResumeLayout()
        'End Sub

    End Class

End Namespace