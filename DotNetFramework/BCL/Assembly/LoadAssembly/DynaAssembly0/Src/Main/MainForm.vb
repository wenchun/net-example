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
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(32, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(36, 68)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(316, 116)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "���d�Ҥ��� work!  �u�O�ΨӮi�ܡG��@�����O�P�ɥ[�J��ӱM�׮ɡA�q�@�ӱM�פ��ǻ������O���A�������t�@�ӱM�פ��A�|�o�͵L�k�૬�����D�C"
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 18)
        Me.ClientSize = New System.Drawing.Size(388, 221)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("PMingLiU", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
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
        Dim aInitParam As InitParam

        aInitParam = New InitParam
        aInitParam.StrParam = "Hello, �o�O�D�{���ǤJ����l�ưѼ�"

        aFileName = "Plugins\Plugin1.dll"
        aClassName = "CustomerForm"
        aPlugin = PluginFactory.CreatePlugin(aFileName, aClassName, Me, aInitParam)
        aForm = DirectCast(aPlugin, Form)  ' �q�����Ѧ��ন TForm ����Ѧ�
        Try
            'aPlugin.RetValue := '�ѥD�{���]�w���w�]�Ǧ^��';
            If aForm.ShowDialog() = DialogResult.OK Then
                'MessageBox.Show("�Ǧ^�ȬO: " + DirectCast(aPlugin.RetValue, String));
            End If
        Finally

        End Try
    End Sub

End Class
