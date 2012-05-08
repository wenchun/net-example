Public Class CustomerForm
    Inherits PluginIntf.PluginForm

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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.TextBox1 = New System.Windows.Forms.TextBox
		Me.SuspendLayout()
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(20, 64)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(252, 25)
		Me.TextBox1.TabIndex = 1
		Me.TextBox1.Text = "TextBox1"
		'
		'CustomerForm
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(8, 18)
		Me.ClientSize = New System.Drawing.Size(380, 289)
		Me.Controls.Add(Me.TextBox1)
		Me.Name = "CustomerForm"
		Me.Text = "CustomerForm"
		Me.Controls.SetChildIndex(Me.TextBox1, 0)
		Me.ResumeLayout(False)

	End Sub

#End Region

End Class
