Imports System.Runtime.InteropServices
Imports System.ComponentModel

Namespace System.Windows.Forms.Metro

    <ProvideProperty("HasCue", GetType(System.Windows.Forms.Control))> _
    <ProvideProperty("CueText", GetType(System.Windows.Forms.Control))> _
    <ToolboxBitmap(GetType(TextBox))> _
    Public Class CueProvider
        Implements IExtenderProvider

        Private m_properties As New Hashtable
        Protected m_activecontrol As System.Windows.Forms.Control

        Private Class Properties
            Public Property HasCue As Boolean
            Public Property CueText As String
        End Class

        Private Function EnsurePropertiesExists(key As Object) As Properties
            Dim p As Properties = DirectCast(m_properties(key), Properties)

            If p Is Nothing Then
                p = New Properties()
                m_properties(key) = p
            End If

            Return p
        End Function

        Public Function CanExtend(extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
            If TypeOf extendee Is TextBox Then 'Or TypeOf extendee Is ComboBox Then 'Or TypeOf extendee Is Controls.DynamicControl
                m_activecontrol = extendee
                Return True
            Else
                m_activecontrol = Nothing
                Return False
            End If
        End Function

        <DefaultValue(False)> _
        Public Function GetHasCue(b As Control) As Boolean
            Return EnsurePropertiesExists(b).HasCue
        End Function
        Public Sub SetHasCue(b As Control, value As Boolean)

            EnsurePropertiesExists(b).HasCue = value

            If value Then
                CueProviderActions.SetCue(b, EnsurePropertiesExists(b).CueText)
                '    'AddHandler b.GotFocus, AddressOf Control_GotFocus
                '    'AddHandler b.LostFocus, AddressOf Control_LostFocus
            Else
                CueProviderActions.ClearCue(b)
                '    'RemoveHandler b.GotFocus, AddressOf Control_GotFocus
                '    'RemoveHandler b.LostFocus, AddressOf Control_LostFocus
            End If

            b.Invalidate()
        End Sub

        <DefaultValue("CueText")> _
        Public Function GetCueText(b As Control) As String
            Return EnsurePropertiesExists(b).CueText
        End Function
        Public Sub SetCueText(b As Control, value As String)

            EnsurePropertiesExists(b).CueText = value
            If EnsurePropertiesExists(b).HasCue Then
                CueProviderActions.SetCue(b, value)
            Else
                CueProviderActions.ClearCue(b)
            End If

            b.Invalidate()

        End Sub

        'Private Sub Control_GotFocus(sender As Object, e As EventArgs)
        '    If sender.Text = sender.Tag Then
        '        sender.Text = Nothing
        '        sender.Font = New System.Drawing.Font(CType(sender, Control).Font.FontFamily, sender.Font.Size, System.Drawing.FontStyle.Regular)
        '        sender.ForeColor = System.Drawing.SystemColors.WindowText
        '    End If

        '    m_activecontrol = CType(sender, System.Windows.Forms.ContextMenuStrip).SourceControl
        'End Sub

        'Private Sub Control_LostFocus(sender As Object, e As EventArgs)
        '    If sender.Text.Trim = sender.Tag Or sender.Text.Trim = "" Then
        '        sender.Text = sender.Tag
        '        sender.Font = New System.Drawing.Font(CType(sender, Control).Font.FontFamily, sender.Font.Size, System.Drawing.FontStyle.Italic)
        '        sender.ForeColor = System.Drawing.SystemColors.ScrollBar
        '    End If
        'End Sub

    End Class

    <HideModuleName()> _
    Public Module CueProviderActions

        Private Const EM_SETCUEBANNER As Integer = &H1501

        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Private Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> lParam As String) As Int32
        End Function

        ''' <summary>
        ''' Sets a text box's cue text.
        ''' </summary>
        ''' <param name="textBox">The text box.</param>
        ''' <param name="cue">The cue text.</param>
        Public Sub SetCue(textBox As TextBox, cue As String)
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, cue)
        End Sub

        ''' <summary>
        ''' Clears a text box's cue text.
        ''' </summary>
        ''' <param name="textBox">The text box</param>
        Public Sub ClearCue(textBox As TextBox)
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, String.Empty)
        End Sub

    End Module

End Namespace