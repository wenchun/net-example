Public Class PluginForm
    Inherits System.Windows.Forms.Form
    Implements IPlugin


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This label is in PluginForm."
        '
        'PluginForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 18)
        Me.ClientSize = New System.Drawing.Size(380, 289)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("MingLiU", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "PluginForm"
        Me.Text = "PluginForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Initialize(ByVal sender As Object, ByVal param As Object) Implements IPlugin.Initialize
        MsgBox(param)
    End Sub
End Class
