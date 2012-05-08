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
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(40, 24)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 160)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Ok"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(40, 64)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = ""
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(40, 104)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = ""
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(352, 226)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ValidateForm()
        Dim aControl As Control
        Dim aTextBox
        Dim aTabIndex = 9999
        Dim aToFocusControl As Control = Nothing

        For Each aControl In Me.Controls
            If TypeOf (aControl) Is TextBox Then
                aTextBox = CType(aControl, TextBox)
                If aTextBox.Text = "" Then
                    ErrorProvider1.SetError(aTextBox, aTextBox.Name + " 欄位必需輸入")
                    If aControl.TabIndex < aTabIndex Then
                        aToFocusControl = aControl
                        aTabIndex = aControl.TabIndex
                    End If
                Else
                    ErrorProvider1.SetError(aTextBox, "")
                End If

            End If
        Next

        If aToFocusControl Is Nothing Then
            MsgBox("所有欄位檢查 ok!")
        Else
            aToFocusControl.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ValidateForm()
    End Sub

    Private Sub TextBox1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        If TextBox1.Text = "" Then
            ErrorProvider1.SetError(TextBox1, TextBox1.Name + " 欄位必需輸入")
            'TextBox1.Focus()
            e.Cancel = True
        Else
            ErrorProvider1.SetError(TextBox1, "")
        End If
    End Sub
End Class
