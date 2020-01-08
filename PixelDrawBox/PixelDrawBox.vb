Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel


Public Enum DrawMode
    Drawable
    Locked
End Enum


Public Class PixelDrawBox : Inherits PictureBox

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Pixels As List(Of PixelObject)

    Private pHeight As Integer
    Private pWidth As Integer

    Public Property SelectedColor As Color
    Public Property DrawMode As DrawMode

    Public Property PixelsWidth As Integer
        Get
            Return pWidth
        End Get
        Set(value As Integer)
            pWidth = value
            Initialize()
        End Set
    End Property

    Public Property PixelsHeight As Integer
        Get
            Return pHeight
        End Get
        Set(value As Integer)
            pHeight = value
            Initialize()
        End Set
    End Property


    Public Sub New()
        Pixels = New List(Of PixelObject)

        Initialize()
    End Sub

    Private Sub Initialize()

        Pixels.Clear()

        For xi As Integer = 0 To PixelsWidth - 1
            For yi As Integer = 0 To PixelsHeight - 1

                Dim pixel As New PixelObject(Me) With {
                    .Rectangle = New Drawing.Rectangle(xi * Size.Width / PixelsWidth, yi * Size.Height / PixelsHeight, Size.Width / PixelsWidth, Size.Height / PixelsHeight),
                    .Color = Drawing.Color.Transparent,
                    .PX = xi,
                    .PY = yi}

                Pixels.Add(pixel)

            Next
        Next

    End Sub


    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        If e.Button = MouseButtons.Left Then
            If DrawMode = DrawMode.Drawable Then
                Try
                    Pixel(New Point(e.Location.X, e.Location.Y)).Color = SelectedColor
                    Me.Refresh()
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Select Case e.Button
            Case MouseButtons.Left
                If DrawMode = DrawMode.Drawable Then
                    Try
                        Pixel(New Point(e.Location.X, e.Location.Y)).Color = SelectedColor
                        Me.Refresh()
                    Catch ex As Exception

                    End Try
                End If
            Case MouseButtons.Right
                Dim cp As New ColorDialog

                If cp.ShowDialog = DialogResult.OK Then
                    SelectedColor = cp.Color
                End If
        End Select


    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        For Each p As PixelObject In Pixels
            p.UpdateSize()
        Next

    End Sub


    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        MyBase.OnPaint(pe)

        Dim g As Graphics = pe.Graphics
        Dim p As New Pen(Brushes.Black)


        For Each c As PixelObject In Pixels
            If Not c.Color = Color.Transparent Then
                g.FillRectangle(New SolidBrush(c.Color), c.Rectangle)
            End If

            g.DrawRectangle(p, c.Rectangle)
        Next
    End Sub



    Private Function Pixel(ByVal p As Point) As PixelObject

        Dim mouse As New Rectangle(p.X, p.Y, 1, 1)

        Return Pixels.Find(Function(pix) pix.Rectangle.IntersectsWith(mouse) = True)
    End Function
End Class
