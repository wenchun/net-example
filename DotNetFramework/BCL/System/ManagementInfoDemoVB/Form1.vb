Imports System.Management

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
	Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Button1 = New System.Windows.Forms.Button
		Me.ListBox1 = New System.Windows.Forms.ListBox
		Me.SuspendLayout()
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(24, 24)
		Me.Button1.Name = "Button1"
		Me.Button1.TabIndex = 0
		Me.Button1.Text = "Button1"
		'
		'ListBox1
		'
		Me.ListBox1.ItemHeight = 12
		Me.ListBox1.Location = New System.Drawing.Point(24, 64)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(408, 328)
		Me.ListBox1.TabIndex = 1
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
		Me.ClientSize = New System.Drawing.Size(472, 413)
		Me.Controls.Add(Me.ListBox1)
		Me.Controls.Add(Me.Button1)
		Me.Name = "Form1"
		Me.Text = "WMI example by Will Tsai"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
		GetMyDNSDomain()
	End Sub

	Private Sub GetMyDNSDomain()

		Dim query As ManagementObjectSearcher = _
		 New ManagementObjectSearcher("SELECT * from Win32_NetworkAdapterConfiguration WHERE IPEnabled=true")
		Dim queryCollection As ManagementObjectCollection = query.Get()

		' If the following loop produces more than one then it is decision time. 
		' If it produces none then it is "ask the user" time.
		Dim mo As ManagementObject
		For Each mo In queryCollection
			Dim pd As PropertyData
			For Each pd In mo.Properties
				If Not IsNothing(pd.Value) Then
					MessageBox.Show(pd.Value.GetType().Name)
					Select Case (pd.Value.GetType().Name)
						Case "Array", "String[]"
							Dim values() As Object = CType(pd.Value, Object())
							Dim s As String = ""
							Dim i As Integer
							For i = 0 To values.Length - 1 Step i + 1
								ListBox1.Items.Add("    " & values(i).ToString())
							Next
						Case "Boolean", "String", "UInt16", "Uint32"
							ListBox1.Items.Add(pd.Name & " = " & pd.Value)
					End Select
				End If
			Next
		Next
	End Sub

End Class
