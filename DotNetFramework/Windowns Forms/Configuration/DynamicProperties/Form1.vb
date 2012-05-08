Imports System.Configuration

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
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents Button2 As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
		Me.TextBox1 = New System.Windows.Forms.TextBox
		Me.Button1 = New System.Windows.Forms.Button
		Me.Button2 = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(32, 184)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.Size = New System.Drawing.Size(288, 25)
		Me.TextBox1.TabIndex = 0
		Me.TextBox1.Text = "TextBox1"
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(24, 32)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(240, 40)
		Me.Button1.TabIndex = 1
		Me.Button1.Text = CType(configurationAppSettings.GetValue("Button1.Text", GetType(System.String)), String)
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(32, 136)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(208, 32)
		Me.Button2.TabIndex = 2
		Me.Button2.Text = "手動載入組態設定"
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(6, 18)
		Me.ClientSize = New System.Drawing.Size(384, 261)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.TextBox1)
		Me.Font = New System.Drawing.Font("PMingLiU", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
		Me.Name = "Form1"
		Me.ShowInTaskbar = CType(configurationAppSettings.GetValue("Form1.ShowInTaskbar", GetType(System.Boolean)), Boolean)
		Me.Text = CType(configurationAppSettings.GetValue("Form1.Text", GetType(System.String)), String)
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
		TextBox1.Text = ConfigurationSettings.AppSettings.Get("Form1.Text")
	End Sub
End Class
