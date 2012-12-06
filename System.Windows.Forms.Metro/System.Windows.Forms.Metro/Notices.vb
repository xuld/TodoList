Imports System.ComponentModel

Namespace System.Windows.Forms.Metro

    Public Class Notices

        Private _Title As String = "Title"
        Private _Message As String = "Message"
        Private _BackColor As System.Drawing.Color = Color.Green
        Private _Time As Integer = 10000

        Public Sub Show(title As String, message As String, Optional backcolor As System.Drawing.Color = Nothing, Optional time As Integer = 10000)
            Me._Title = title
            Me._Message = message
            If backcolor = Nothing Then _BackColor = Color.Green
            Me._BackColor = backcolor
            Me._Time = time
            Me.Show()
        End Sub

        Public Sub Show()
            Dim _notice As New System.Windows.Forms.Form
            With _notice

                Dim LabelTitle = New System.Windows.Forms.Label()
                Dim LabelMessage = New System.Windows.Forms.Label()
                Dim ButtonClose = New System.Windows.Forms.Button()
                Dim TimerClose As New System.Windows.Forms.Timer
                .SuspendLayout()
                '
                'LabelTitle
                '
                LabelTitle.AutoSize = True
                LabelTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                LabelTitle.Location = New System.Drawing.Point(18, 15)
                LabelTitle.Size = New System.Drawing.Size(48, 25)
                LabelTitle.Text = _Title
                '
                'LabelMessage
                '
                LabelMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                 Or System.Windows.Forms.AnchorStyles.Left) _
                 Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                LabelMessage.Location = New System.Drawing.Point(18, 40)
                LabelMessage.Size = New System.Drawing.Size(344, 45)
                LabelMessage.Text = _Message
                '
                'ButtonClose
                '
                ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
                ButtonClose.FlatAppearance.BorderSize = 0
                ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                ButtonClose.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                ButtonClose.Location = New System.Drawing.Point(350, 6)
                ButtonClose.Size = New System.Drawing.Size(24, 24)
                ButtonClose.TabStop = False
                ButtonClose.Text = "X"
                ButtonClose.UseVisualStyleBackColor = True
                '
                'TimerClose
                '
                TimerClose.Enabled = _Time <> 0
                TimerClose.Interval = _Time
                '
                'Test
                '
                .AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
                .AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
                .BackColor = _BackColor
                .ClientSize = New System.Drawing.Size(380, 100)
                .StartPosition = FormStartPosition.Manual
                .Location = New System.Drawing.Point(My.Computer.Screen.WorkingArea.Width - .Width + 16, 16)
                .Controls.Add(ButtonClose)
                .Controls.Add(LabelMessage)
                .Controls.Add(LabelTitle)
                .Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                .ForeColor = System.Drawing.Color.White
                .FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                .Padding = New System.Windows.Forms.Padding(15)
                .ShowInTaskbar = False
                .ResumeLayout(False)
                .PerformLayout()

                AddHandler ButtonClose.Click, Sub(sender As Object, e As EventArgs)
                                                  CType(sender, Control).FindForm.Close()
                                                  TimerClose.Enabled = False
                                                  TimerClose.Dispose()
                                              End Sub

                AddHandler TimerClose.Tick, Sub(_sender As Object, _e As EventArgs)
                                                ButtonClose.PerformClick()
                                            End Sub

                AddHandler .MouseEnter, Sub(_sender As Object, _e As EventArgs)
                                            If TimerClose.Interval <> 0 Then
                                                TimerClose.Enabled = False
                                            End If
                                        End Sub
                AddHandler .MouseLeave, Sub(_sender As Object, _e As EventArgs)
                                            If TimerClose.Interval <> 0 Then
                                                TimerClose.Enabled = True
                                            End If
                                        End Sub



                .Show()
            End With

        End Sub

    End Class

End Namespace