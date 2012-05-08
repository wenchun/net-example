Public Class QueryForm
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
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
	Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents btnOk As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Panel1 = New System.Windows.Forms.Panel
		Me.TextBox2 = New System.Windows.Forms.TextBox
		Me.TextBox1 = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.TextBox3 = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
		Me.TextBox4 = New System.Windows.Forms.TextBox
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.btnOk = New System.Windows.Forms.Button
		Me.btnCancel = New System.Windows.Forms.Button
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.DarkCyan
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Panel1.Controls.Add(Me.TextBox2)
		Me.Panel1.Controls.Add(Me.TextBox1)
		Me.Panel1.Controls.Add(Me.Label3)
		Me.Panel1.Controls.Add(Me.TextBox3)
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Controls.Add(Me.DateTimePicker1)
		Me.Panel1.Controls.Add(Me.TextBox4)
		Me.Panel1.Controls.Add(Me.Label5)
		Me.Panel1.Controls.Add(Me.Label4)
		Me.Panel1.Controls.Add(Me.Label2)
		Me.Panel1.Location = New System.Drawing.Point(16, 16)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(640, 104)
		Me.Panel1.TabIndex = 14
		'
		'TextBox2
		'
		Me.TextBox2.Location = New System.Drawing.Point(296, 16)
		Me.TextBox2.Name = "TextBox2"
		Me.TextBox2.Size = New System.Drawing.Size(104, 25)
		Me.TextBox2.TabIndex = 4
		Me.TextBox2.Text = ""
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(88, 16)
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.TabIndex = 2
		Me.TextBox1.Text = ""
		'
		'Label3
		'
		Me.Label3.ForeColor = System.Drawing.Color.White
		Me.Label3.Location = New System.Drawing.Point(432, 16)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(72, 23)
		Me.Label3.TabIndex = 7
		Me.Label3.Text = "First Name"
		'
		'TextBox3
		'
		Me.TextBox3.Location = New System.Drawing.Point(512, 16)
		Me.TextBox3.Name = "TextBox3"
		Me.TextBox3.Size = New System.Drawing.Size(104, 25)
		Me.TextBox3.TabIndex = 6
		Me.TextBox3.Text = ""
		'
		'Label1
		'
		Me.Label1.ForeColor = System.Drawing.Color.White
		Me.Label1.Location = New System.Drawing.Point(8, 16)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(72, 23)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "員工編號"
		'
		'DateTimePicker1
		'
		Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
		Me.DateTimePicker1.Location = New System.Drawing.Point(296, 56)
		Me.DateTimePicker1.Name = "DateTimePicker1"
		Me.DateTimePicker1.Size = New System.Drawing.Size(104, 25)
		Me.DateTimePicker1.TabIndex = 12
		'
		'TextBox4
		'
		Me.TextBox4.Location = New System.Drawing.Point(88, 56)
		Me.TextBox4.Name = "TextBox4"
		Me.TextBox4.TabIndex = 8
		Me.TextBox4.Text = ""
		'
		'Label5
		'
		Me.Label5.ForeColor = System.Drawing.Color.White
		Me.Label5.Location = New System.Drawing.Point(216, 56)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(72, 23)
		Me.Label5.TabIndex = 11
		Me.Label5.Text = "出生日期"
		'
		'Label4
		'
		Me.Label4.ForeColor = System.Drawing.Color.White
		Me.Label4.Location = New System.Drawing.Point(8, 56)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(72, 23)
		Me.Label4.TabIndex = 9
		Me.Label4.Text = "職稱"
		'
		'Label2
		'
		Me.Label2.ForeColor = System.Drawing.Color.White
		Me.Label2.Location = New System.Drawing.Point(216, 16)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(72, 23)
		Me.Label2.TabIndex = 5
		Me.Label2.Text = "Last Name"
		'
		'btnOk
		'
		Me.btnOk.Location = New System.Drawing.Point(432, 144)
		Me.btnOk.Name = "btnOk"
		Me.btnOk.Size = New System.Drawing.Size(104, 32)
		Me.btnOk.TabIndex = 15
		Me.btnOk.Text = "確定"
		'
		'btnCancel
		'
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(544, 144)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(104, 32)
		Me.btnCancel.TabIndex = 16
		Me.btnCancel.Text = "取消"
		'
		'QueryForm
		'
		Me.AcceptButton = Me.btnOk
		Me.AutoScaleBaseSize = New System.Drawing.Size(6, 18)
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(674, 189)
		Me.Controls.Add(Me.btnCancel)
		Me.Controls.Add(Me.btnOk)
		Me.Controls.Add(Me.Panel1)
		Me.Font = New System.Drawing.Font("PMingLiU", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "QueryForm"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "輸入查詢條件"
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

End Class
