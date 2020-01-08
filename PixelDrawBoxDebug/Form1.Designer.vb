<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PixelDrawBox1 = New PixelDrawBox.PixelDrawBox()
        CType(Me.PixelDrawBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PixelDrawBox1
        '
        Me.PixelDrawBox1.DrawMode = PixelDrawBox.DrawMode.Drawable
        Me.PixelDrawBox1.Location = New System.Drawing.Point(12, 12)
        Me.PixelDrawBox1.Name = "PixelDrawBox1"
        Me.PixelDrawBox1.PixelsHeight = 32
        Me.PixelDrawBox1.PixelsWidth = 32
        Me.PixelDrawBox1.SelectedColor = System.Drawing.Color.Black
        Me.PixelDrawBox1.Size = New System.Drawing.Size(320, 320)
        Me.PixelDrawBox1.TabIndex = 0
        Me.PixelDrawBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 352)
        Me.Controls.Add(Me.PixelDrawBox1)
        Me.Name = "Form1"
        Me.Text = "PixelDrawBoxDebug"
        CType(Me.PixelDrawBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PixelDrawBox1 As PixelDrawBox.PixelDrawBox
End Class
