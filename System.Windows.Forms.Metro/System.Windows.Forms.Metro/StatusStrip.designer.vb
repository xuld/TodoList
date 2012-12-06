﻿Namespace System.Windows.Forms.Metro

    <ToolboxBitmap(GetType(System.Windows.Forms.StatusStrip))> _
    Partial Class StatusStrip
        Inherits System.Windows.Forms.StatusStrip

        <System.Diagnostics.DebuggerNonUserCode()> _
        Public Sub New(ByVal container As System.ComponentModel.IContainer)
            MyClass.New()

            'Requerido para la compatibilidad con el Diseñador de composiciones de clases Windows.Forms
            If (container IsNot Nothing) Then
                container.Add(Me)
            End If

        End Sub

        <System.Diagnostics.DebuggerNonUserCode()> _
        Public Sub New()
            MyBase.New()

            'El Diseñador de componentes requiere esta llamada.
            InitializeComponent()

        End Sub

        'Component reemplaza a Dispose para limpiar la lista de componentes.
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

        'Requerido por el Diseñador de componentes
        Private components As System.ComponentModel.IContainer

        'NOTA: el Diseñador de componentes requiere el siguiente procedimiento
        'Se puede modificar usando el Diseñador de componentes.
        'No lo modifique con el editor de código.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'StatusBar
            '
            Me.SizingGrip = False
            Me.ResumeLayout(False)

        End Sub

    End Class

End Namespace