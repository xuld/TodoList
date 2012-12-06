Namespace System.Windows.Forms.Metro.Extensions

    <HideModuleName()> _
    Public Module Commons

        <Runtime.CompilerServices.Extension()> _
        Public Function GetDarkColor(c As System.Drawing.Color, ByVal d As Byte) As System.Drawing.Color
            Dim r As Byte = 0
            Dim g As Byte = 0
            Dim b As Byte = 0

            If (c.R > d) Then r = (c.R - d)
            If (c.G > d) Then g = (c.G - d)
            If (c.B > d) Then b = (c.B - d)

            Dim c1 As System.Drawing.Color = System.Drawing.Color.FromArgb(r, g, b)
            Return c1
        End Function
        <Runtime.CompilerServices.Extension()> _
        Public Function GetLightColor(c As System.Drawing.Color, ByVal d As Byte) As System.Drawing.Color
            Dim r As Byte = 255
            Dim g As Byte = 255
            Dim b As Byte = 255

            If (CInt(c.R) + CInt(d) <= 255) Then r = (c.R + d)
            If (CInt(c.G) + CInt(d) <= 255) Then g = (c.G + d)
            If (CInt(c.B) + CInt(d) <= 255) Then b = (c.B + d)

            Dim c2 As System.Drawing.Color = System.Drawing.Color.FromArgb(r, g, b)
            Return c2
        End Function



    End Module

End Namespace