Public Class Form1
    Inherits System.Windows.Forms.Form

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
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents Button2 As System.Windows.Forms.Button
	Friend WithEvents Button3 As System.Windows.Forms.Button
	Friend WithEvents Button4 As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Button1 = New System.Windows.Forms.Button
		Me.Button2 = New System.Windows.Forms.Button
		Me.Button3 = New System.Windows.Forms.Button
		Me.Button4 = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(32, 32)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(112, 32)
		Me.Button1.TabIndex = 0
		Me.Button1.Text = "Button1"
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(176, 32)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(112, 32)
		Me.Button2.TabIndex = 1
		Me.Button2.Text = "Button2"
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(32, 88)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(112, 32)
		Me.Button3.TabIndex = 2
		Me.Button3.Text = "Button3"
		'
		'Button4
		'
		Me.Button4.Location = New System.Drawing.Point(176, 88)
		Me.Button4.Name = "Button4"
		Me.Button4.Size = New System.Drawing.Size(112, 32)
		Me.Button4.TabIndex = 3
		Me.Button4.Text = "Button4"
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(6, 18)
		Me.ClientSize = New System.Drawing.Size(344, 165)
		Me.Controls.Add(Me.Button4)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Font = New System.Drawing.Font("PMingLiU", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
		Me.Name = "Form1"
		Me.Text = "將多個按鈕事件導向至同一個事件處理程序"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'逐一將各按鈕的事件導向到同一個事件處理程序
		AddHandler Button1.Click, AddressOf UniversalClickHandler
		AddHandler Button2.Click, AddressOf UniversalClickHandler
		AddHandler Button3.Click, AddressOf UniversalClickHandler
		AddHandler Button4.Click, AddressOf UniversalClickHandler

		'或者也可以用迴圈的方式一次設定所有的按鈕
		'For Each aControl As Control In Me.Controls
		'	If TypeOf aControl Is Button Then
		'		Dim btn As Button = DirectCast(aControl, Button)
		'		AddHandler btn.Click, AddressOf UniversalClickHandler
		'	End If
		'Next
	End Sub

	Private Sub UniversalClickHandler(ByVal sender As Object, ByVal e As EventArgs)
		Dim btn As Button = DirectCast(sender, Button)
		MessageBox.Show("您按下的按鈕是: " & btn.Name)
	End Sub

End Class
