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
    Friend WithEvents txtKeyValue As System.Windows.Forms.TextBox
    Friend WithEvents txtStrValue As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRetValue As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtKeyValue = New System.Windows.Forms.TextBox
        Me.txtStrValue = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRetValue = New System.Windows.Forms.TextBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtKeyValue
        '
        Me.txtKeyValue.Location = New System.Drawing.Point(136, 116)
        Me.txtKeyValue.Name = "txtKeyValue"
        Me.txtKeyValue.Size = New System.Drawing.Size(312, 25)
        Me.txtKeyValue.TabIndex = 1
        Me.txtKeyValue.Text = ""
        '
        'txtStrValue
        '
        Me.txtStrValue.Location = New System.Drawing.Point(136, 80)
        Me.txtStrValue.Name = "txtStrValue"
        Me.txtStrValue.Size = New System.Drawing.Size(312, 25)
        Me.txtStrValue.TabIndex = 2
        Me.txtStrValue.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "StrValue"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "KeyValue"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "RetValue"
        '
        'txtRetValue
        '
        Me.txtRetValue.Location = New System.Drawing.Point(136, 164)
        Me.txtRetValue.Name = "txtRetValue"
        Me.txtRetValue.Size = New System.Drawing.Size(312, 25)
        Me.txtRetValue.TabIndex = 6
        Me.txtRetValue.Text = ""
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(356, 204)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(92, 32)
        Me.btnOk.TabIndex = 7
        Me.btnOk.Text = "OK"
        '
        'CustomerForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 18)
        Me.ClientSize = New System.Drawing.Size(524, 257)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtRetValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStrValue)
        Me.Controls.Add(Me.txtKeyValue)
        Me.Name = "CustomerForm"
        Me.Text = "CustomerForm"
        Me.Controls.SetChildIndex(Me.txtKeyValue, 0)
        Me.Controls.SetChildIndex(Me.txtStrValue, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtRetValue, 0)
        Me.Controls.SetChildIndex(Me.btnOk, 0)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CustomerForm_Init(ByVal sender As Object, ByVal param As PluginIntf.InitParam) Handles MyBase.Init
        txtStrValue.Text = param.StrValue
        txtKeyValue.Text = param("UserName")  '也可以寫成 param.Value("UserName")
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        RetValue = txtRetValue.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class
