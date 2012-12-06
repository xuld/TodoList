<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Metro.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.StatusStrip = New System.Windows.Forms.Metro.StatusStrip(Me.components)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ScrollRangeBar1 = New System.Windows.Forms.Metro.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Switch1 = New System.Windows.Forms.Metro.ToggleSwitch()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PropertyLinker = New System.Windows.Forms.PropertyLinker(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SearchControl1 = New System.Windows.Forms.Metro.SearchControl()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        CType(Me.PictureBoxSizingGrip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBoxSizingGrip
        '
        Me.PictureBoxSizingGrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PropertyLinker.SetDestinationProperty(Me.PictureBoxSizingGrip, Nothing)
        Me.PictureBoxSizingGrip.Image = CType(resources.GetObject("PictureBoxSizingGrip.Image"), System.Drawing.Image)
        Me.PropertyLinker.SetSourceControl(Me.PictureBoxSizingGrip, Nothing)
        Me.PropertyLinker.SetSourceProperty(Me.PictureBoxSizingGrip, Nothing)
        '
        'ToolTipMetro
        '
        Me.ToolTipMetro.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PropertyLinker.SetDestinationProperty(Me.StatusStrip, Nothing)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip.Location = New System.Drawing.Point(1, 457)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(638, 22)
        Me.StatusStrip.SizingGrip = False
        Me.PropertyLinker.SetSourceControl(Me.StatusStrip, Nothing)
        Me.PropertyLinker.SetSourceProperty(Me.StatusStrip, Nothing)
        Me.StatusStrip.TabIndex = 10
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(134, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ScrollRangeBar1
        '
        Me.ScrollRangeBar1.ActiveColor = System.Drawing.Color.Empty
        Me.ScrollRangeBar1.BackColor = System.Drawing.Color.Transparent
        Me.PropertyLinker.SetDestinationProperty(Me.ScrollRangeBar1, "ActiveColor")
        Me.ScrollRangeBar1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScrollRangeBar1.InactiveColor = System.Drawing.SystemColors.ScrollBar
        Me.ScrollRangeBar1.Location = New System.Drawing.Point(12, 57)
        Me.ScrollRangeBar1.Name = "ScrollRangeBar1"
        Me.ScrollRangeBar1.Padding = New System.Windows.Forms.Padding(3)
        Me.ScrollRangeBar1.Size = New System.Drawing.Size(168, 26)
        Me.PropertyLinker.SetSourceControl(Me.ScrollRangeBar1, Me)
        Me.PropertyLinker.SetSourceProperty(Me.ScrollRangeBar1, "DominantColor")
        Me.ScrollRangeBar1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.PropertyLinker.SetDestinationProperty(Me.Label1, Nothing)
        Me.Label1.Location = New System.Drawing.Point(9, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.PropertyLinker.SetSourceControl(Me.Label1, Nothing)
        Me.PropertyLinker.SetSourceProperty(Me.Label1, Nothing)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "TrackBar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.PropertyLinker.SetDestinationProperty(Me.Label2, Nothing)
        Me.Label2.Location = New System.Drawing.Point(9, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.PropertyLinker.SetSourceControl(Me.Label2, Nothing)
        Me.PropertyLinker.SetSourceProperty(Me.Label2, Nothing)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "ToggleSwitch"
        '
        'Switch1
        '
        Me.Switch1.ActiveColor = System.Drawing.Color.Empty
        Me.Switch1.BackColor = System.Drawing.Color.Transparent
        Me.PropertyLinker.SetDestinationProperty(Me.Switch1, "ActiveColor")
        Me.Switch1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Switch1.InactiveColor = System.Drawing.SystemColors.ScrollBar
        Me.Switch1.Location = New System.Drawing.Point(12, 102)
        Me.Switch1.MinimumSize = New System.Drawing.Size(74, 26)
        Me.Switch1.Name = "Switch1"
        Me.Switch1.Padding = New System.Windows.Forms.Padding(3)
        Me.Switch1.Size = New System.Drawing.Size(74, 26)
        Me.PropertyLinker.SetSourceControl(Me.Switch1, Me)
        Me.PropertyLinker.SetSourceProperty(Me.Switch1, "DominantColor")
        Me.Switch1.TabIndex = 13
        '
        'Label3
        '
        Me.PropertyLinker.SetDestinationProperty(Me.Label3, "Text")
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(186, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 26)
        Me.PropertyLinker.SetSourceControl(Me.Label3, Me.ScrollRangeBar1)
        Me.PropertyLinker.SetSourceProperty(Me.Label3, "Value")
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "0"
        '
        'Label4
        '
        Me.PropertyLinker.SetDestinationProperty(Me.Label4, "Text")
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(186, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 26)
        Me.PropertyLinker.SetSourceControl(Me.Label4, Me.Switch1)
        Me.PropertyLinker.SetSourceProperty(Me.Label4, "Value")
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "False"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.PropertyLinker.SetDestinationProperty(Me.Label5, Nothing)
        Me.Label5.Location = New System.Drawing.Point(9, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.PropertyLinker.SetSourceControl(Me.Label5, Nothing)
        Me.PropertyLinker.SetSourceProperty(Me.Label5, Nothing)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "SearchControl"
        '
        'SearchControl1
        '
        Me.SearchControl1.BackColor = System.Drawing.Color.White
        Me.SearchControl1.BackgroundWorkerSearch = Nothing
        Me.SearchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PropertyLinker.SetDestinationProperty(Me.SearchControl1, Nothing)
        Me.SearchControl1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchControl1.Location = New System.Drawing.Point(12, 147)
        Me.SearchControl1.Name = "SearchControl1"
        Me.SearchControl1.ProgressBarColor = System.Drawing.Color.LightGreen
        Me.SearchControl1.Size = New System.Drawing.Size(168, 28)
        Me.PropertyLinker.SetSourceControl(Me.SearchControl1, Nothing)
        Me.PropertyLinker.SetSourceProperty(Me.SearchControl1, Nothing)
        Me.SearchControl1.TabIndex = 15
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PropertyLinker.SetDestinationProperty(Me.PropertyGrid1, Nothing)
        Me.PropertyGrid1.Location = New System.Drawing.Point(386, 41)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(232, 392)
        Me.PropertyLinker.SetSourceControl(Me.PropertyGrid1, Nothing)
        Me.PropertyLinker.SetSourceProperty(Me.PropertyGrid1, Nothing)
        Me.PropertyGrid1.TabIndex = 16
        Me.PropertyGrid1.TabStop = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.SearchControl1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Switch1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ScrollRangeBar1)
        Me.Controls.Add(Me.StatusStrip)
        Me.PropertyLinker.SetDestinationProperty(Me, Nothing)
        Me.DominantColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Name = "FormMain"
        Me.PropertyLinker.SetSourceControl(Me, Nothing)
        Me.PropertyLinker.SetSourceProperty(Me, Nothing)
        Me.Text = "FormMain"
        Me.Controls.SetChildIndex(Me.StatusStrip, 0)
        Me.Controls.SetChildIndex(Me.PictureBoxSizingGrip, 0)
        Me.Controls.SetChildIndex(Me.ScrollRangeBar1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Switch1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.SearchControl1, 0)
        Me.Controls.SetChildIndex(Me.PropertyGrid1, 0)
        CType(Me.PictureBoxSizingGrip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.Metro.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ScrollRangeBar1 As System.Windows.Forms.Metro.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Switch1 As System.Windows.Forms.Metro.ToggleSwitch
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PropertyLinker As PropertyLinker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SearchControl1 As System.Windows.Forms.Metro.SearchControl
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
End Class
