Imports PluginIntf

Public Class MainForm
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(456, 329)
        Me.Controls.Add(Me.Button1)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aPlugin As IPlugin
        Dim aForm As Form
        Dim aFileName As String
        Dim aClassName As String
        Dim aParam As InitParam = New InitParam

        aParam.StrValue = "Hello, 這是主程式傳入的初始化參數"
        aParam("UserName") = "Michael Tsai"

        aFileName = "Plugins\Customer.dll"
        aClassName = "CustomerForm"
        aPlugin = PluginFactory.CreatePlugin(aFileName, aClassName, Me, aParam)
        aForm = DirectCast(aPlugin, Form)  ' 從介面參考轉成 TForm 物件參考
        Try
            'aPlugin.RetValue := '由主程式設定的預設傳回值';
            If aForm.ShowDialog() = DialogResult.OK Then
                MessageBox.Show("傳回值是: " + DirectCast(aPlugin.RetValue, String))
            End If
        Finally

        End Try
    End Sub
End Class
