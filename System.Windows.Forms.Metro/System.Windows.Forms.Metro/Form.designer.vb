Namespace System.Windows.Forms.Metro

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Form
        Inherits System.Windows.Forms.Form

        'Form reemplaza a Dispose para limpiar la lista de componentes.
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

        'Requerido por el Diseñador de Windows Forms
        Private components As System.ComponentModel.IContainer

        'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        'Se puede modificar usando el Diseñador de Windows Forms.  
        'No lo modifique con el editor de código.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.PictureBoxSizingGrip = New System.Windows.Forms.PictureBox()
            Me.ButtonMinimize = New System.Windows.Forms.Button()
            Me.ButtonMaximizeRestore = New System.Windows.Forms.Button()
            Me.ButtonClose = New System.Windows.Forms.Button()
            Me.PictureBoxIcon = New System.Windows.Forms.PictureBox()
            Me.ContextMenuStripForm = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.ToolStripMenuItemRestore = New System.Windows.Forms.ToolStripMenuItem()
            Me.MoverToolStripMenuItemMove = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSize = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemMinimize = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemMaximize = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparatorOptions = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolStripMenuItemClose = New System.Windows.Forms.ToolStripMenuItem()
            Me.LabelTitle = New System.Windows.Forms.Label()
            Me.ToolTipMetro = New ToolTip()
            CType(Me.PictureBoxSizingGrip, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBoxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ContextMenuStripForm.SuspendLayout()
            Me.SuspendLayout()
            '
            'PictureBoxSizingGrip
            '
            Me.PictureBoxSizingGrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PictureBoxSizingGrip.Cursor = System.Windows.Forms.Cursors.SizeNWSE
            Me.PictureBoxSizingGrip.Image = Global.My.Resources.resize_d
            Me.PictureBoxSizingGrip.Location = New System.Drawing.Point(629, 469)
            Me.PictureBoxSizingGrip.Margin = New System.Windows.Forms.Padding(0)
            Me.PictureBoxSizingGrip.Name = "PictureBoxSizingGrip"
            Me.PictureBoxSizingGrip.Size = New System.Drawing.Size(8, 8)
            Me.PictureBoxSizingGrip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.PictureBoxSizingGrip.TabIndex = 8
            Me.PictureBoxSizingGrip.TabStop = False
            '
            'ButtonMinimize
            '
            Me.ButtonMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonMinimize.FlatAppearance.BorderSize = 0
            Me.ButtonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.ButtonMinimize.Image = Global.My.Resources.minimize_d
            Me.ButtonMinimize.Location = New System.Drawing.Point(535, 3)
            Me.ButtonMinimize.Margin = New System.Windows.Forms.Padding(0)
            Me.ButtonMinimize.Name = "ButtonMinimize"
            Me.ButtonMinimize.Size = New System.Drawing.Size(34, 26)
            Me.ButtonMinimize.TabIndex = 1
            Me.ButtonMinimize.TabStop = False
            Me.ToolTipMetro.SetToolTip(Me.ButtonMinimize, "Minimizar")
            Me.ButtonMinimize.UseVisualStyleBackColor = True
            '
            'ButtonMaximizeRestore
            '
            Me.ButtonMaximizeRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonMaximizeRestore.FlatAppearance.BorderSize = 0
            Me.ButtonMaximizeRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.ButtonMaximizeRestore.Image = Global.My.Resources.maximize_d
            Me.ButtonMaximizeRestore.Location = New System.Drawing.Point(569, 3)
            Me.ButtonMaximizeRestore.Margin = New System.Windows.Forms.Padding(0)
            Me.ButtonMaximizeRestore.Name = "ButtonMaximizeRestore"
            Me.ButtonMaximizeRestore.Size = New System.Drawing.Size(34, 26)
            Me.ButtonMaximizeRestore.TabIndex = 2
            Me.ButtonMaximizeRestore.TabStop = False
            Me.ToolTipMetro.SetToolTip(Me.ButtonMaximizeRestore, "Maximizar")
            Me.ButtonMaximizeRestore.UseVisualStyleBackColor = True
            '
            'ButtonClose
            '
            Me.ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonClose.FlatAppearance.BorderSize = 0
            Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.ButtonClose.Image = Global.My.Resources.close_d
            Me.ButtonClose.Location = New System.Drawing.Point(603, 3)
            Me.ButtonClose.Margin = New System.Windows.Forms.Padding(0)
            Me.ButtonClose.Name = "ButtonClose"
            Me.ButtonClose.Size = New System.Drawing.Size(34, 26)
            Me.ButtonClose.TabIndex = 3
            Me.ButtonClose.TabStop = False
            Me.ToolTipMetro.SetToolTip(Me.ButtonClose, "Cerrar")
            Me.ButtonClose.UseVisualStyleBackColor = True
            '
            'PictureBoxIcon
            '
            Me.PictureBoxIcon.ContextMenuStrip = Me.ContextMenuStripForm
            Me.PictureBoxIcon.Location = New System.Drawing.Point(12, 9)
            Me.PictureBoxIcon.Margin = New System.Windows.Forms.Padding(0)
            Me.PictureBoxIcon.Name = "PictureBoxIcon"
            Me.PictureBoxIcon.Size = New System.Drawing.Size(24, 24)
            Me.PictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.PictureBoxIcon.TabIndex = 9
            Me.PictureBoxIcon.TabStop = False
            '
            'ContextMenuStripForm
            '
            Me.ContextMenuStripForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemRestore, Me.MoverToolStripMenuItemMove, Me.ToolStripMenuItemSize, Me.ToolStripMenuItemMinimize, Me.ToolStripMenuItemMaximize, Me.ToolStripSeparatorOptions, Me.ToolStripMenuItemClose})
            Me.ContextMenuStripForm.Name = "ContextMenuStripForm"
            Me.ContextMenuStripForm.Size = New System.Drawing.Size(149, 142)
            '
            'ToolStripMenuItemRestore
            '
            Me.ToolStripMenuItemRestore.Enabled = False
            Me.ToolStripMenuItemRestore.Image = Global.My.Resources.restore_d
            Me.ToolStripMenuItemRestore.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.ToolStripMenuItemRestore.Name = "ToolStripMenuItemRestore"
            Me.ToolStripMenuItemRestore.Size = New System.Drawing.Size(148, 22)
            Me.ToolStripMenuItemRestore.Text = "&Restaurar"
            '
            'MoverToolStripMenuItemMove
            '
            Me.MoverToolStripMenuItemMove.Enabled = False
            Me.MoverToolStripMenuItemMove.Name = "MoverToolStripMenuItemMove"
            Me.MoverToolStripMenuItemMove.Size = New System.Drawing.Size(148, 22)
            Me.MoverToolStripMenuItemMove.Text = "&Mover"
            '
            'ToolStripMenuItemSize
            '
            Me.ToolStripMenuItemSize.Enabled = False
            Me.ToolStripMenuItemSize.Name = "ToolStripMenuItemSize"
            Me.ToolStripMenuItemSize.Size = New System.Drawing.Size(148, 22)
            Me.ToolStripMenuItemSize.Text = "&Tamaño"
            '
            'ToolStripMenuItemMinimize
            '
            Me.ToolStripMenuItemMinimize.Image = Global.My.Resources.minimize_d
            Me.ToolStripMenuItemMinimize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.ToolStripMenuItemMinimize.Name = "ToolStripMenuItemMinimize"
            Me.ToolStripMenuItemMinimize.Size = New System.Drawing.Size(148, 22)
            Me.ToolStripMenuItemMinimize.Text = "Mi&nimizar"
            '
            'ToolStripMenuItemMaximize
            '
            Me.ToolStripMenuItemMaximize.Image = Global.My.Resources.maximize_d
            Me.ToolStripMenuItemMaximize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.ToolStripMenuItemMaximize.Name = "ToolStripMenuItemMaximize"
            Me.ToolStripMenuItemMaximize.Size = New System.Drawing.Size(148, 22)
            Me.ToolStripMenuItemMaximize.Text = "Ma&ximizar"
            '
            'ToolStripSeparatorOptions
            '
            Me.ToolStripSeparatorOptions.Name = "ToolStripSeparatorOptions"
            Me.ToolStripSeparatorOptions.Size = New System.Drawing.Size(145, 6)
            '
            'ToolStripMenuItemClose
            '
            Me.ToolStripMenuItemClose.Image = Global.My.Resources.close_d
            Me.ToolStripMenuItemClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.ToolStripMenuItemClose.Name = "ToolStripMenuItemClose"
            Me.ToolStripMenuItemClose.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
            Me.ToolStripMenuItemClose.Size = New System.Drawing.Size(148, 22)
            Me.ToolStripMenuItemClose.Text = "&Cerrar"
            '
            'LabelTitle
            '
            Me.LabelTitle.AutoSize = True
            Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTitle.Location = New System.Drawing.Point(37, 11)
            Me.LabelTitle.Margin = New System.Windows.Forms.Padding(0)
            Me.LabelTitle.Name = "LabelTitle"
            Me.LabelTitle.Size = New System.Drawing.Size(47, 21)
            Me.LabelTitle.TabIndex = 0
            Me.LabelTitle.Text = "Form"
            Me.LabelTitle.UseMnemonic = False
            '
            'ToolTipMetro
            '
            Me.ToolTipMetro.AutoPopDelay = 2000
            Me.ToolTipMetro.BackColor = System.Drawing.Color.Black
            Me.ToolTipMetro.ForeColor = System.Drawing.Color.White
            Me.ToolTipMetro.InitialDelay = 500
            Me.ToolTipMetro.OwnerDraw = True
            Me.ToolTipMetro.ReshowDelay = 100
            '
            'Form
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(640, 480)
            Me.Controls.Add(Me.PictureBoxIcon)
            Me.Controls.Add(Me.PictureBoxSizingGrip)
            Me.Controls.Add(Me.ButtonMinimize)
            Me.Controls.Add(Me.ButtonMaximizeRestore)
            Me.Controls.Add(Me.ButtonClose)
            Me.Controls.Add(Me.LabelTitle)
            Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.MinimumSize = New System.Drawing.Size(320, 240)
            Me.Name = "Form"
            Me.Padding = New System.Windows.Forms.Padding(1)
            CType(Me.PictureBoxSizingGrip, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBoxIcon, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ContextMenuStripForm.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Private WithEvents ButtonMinimize As System.Windows.Forms.Button
        Private WithEvents ButtonMaximizeRestore As System.Windows.Forms.Button
        Private WithEvents ButtonClose As System.Windows.Forms.Button
        Private WithEvents PictureBoxIcon As System.Windows.Forms.PictureBox
        Private WithEvents ContextMenuStripForm As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents ToolStripMenuItemRestore As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemMinimize As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemMaximize As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripSeparatorOptions As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents ToolStripMenuItemClose As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents MoverToolStripMenuItemMove As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSize As System.Windows.Forms.ToolStripMenuItem
        Protected Friend WithEvents PictureBoxSizingGrip As System.Windows.Forms.PictureBox
        Friend WithEvents LabelTitle As System.Windows.Forms.Label
        Public WithEvents ToolTipMetro As ToolTip

    End Class

End Namespace