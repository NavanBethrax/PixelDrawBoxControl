Imports System.Drawing
Imports System.ComponentModel


<Serializable()>
Public Class PixelObject


    Public Property PX As Integer
    Public Property PY As Integer
    Public Property Rectangle As Rectangle
    Public Property Color As Color

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Private Parent As PixelDrawBox

    Public Sub New(ByVal parent As PixelDrawBox)
        Me.Parent = parent
    End Sub

    Public Sub UpdateSize()
        Rectangle = New Drawing.Rectangle(PX * Parent.Size.Width / Parent.PixelsWidth, PY * Parent.Size.Height / Parent.PixelsHeight, Parent.Size.Width / Parent.PixelsWidth, Parent.Size.Height / Parent.PixelsHeight)
    End Sub

End Class
