using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;


namespace MyApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDllFileName;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnSelectFile;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDllFileName = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnSelectFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.button1.Location = new System.Drawing.Point(16, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(224, 48);
			this.button1.TabIndex = 0;
			this.button1.Text = "���J MyLib.dll �éI�s method";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "DLL �ɦW:";
			// 
			// txtDllFileName
			// 
			this.txtDllFileName.Location = new System.Drawing.Point(104, 32);
			this.txtDllFileName.Name = "txtDllFileName";
			this.txtDllFileName.Size = new System.Drawing.Size(168, 25);
			this.txtDllFileName.TabIndex = 2;
			this.txtDllFileName.Text = "MyLib.dll";
			// 
			// btnSelectFile
			// 
			this.btnSelectFile.Location = new System.Drawing.Point(280, 32);
			this.btnSelectFile.Name = "btnSelectFile";
			this.btnSelectFile.Size = new System.Drawing.Size(24, 23);
			this.btnSelectFile.TabIndex = 3;
			this.btnSelectFile.Text = "...";
			this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(416, 149);
			this.Controls.Add(this.btnSelectFile);
			this.Controls.Add(this.txtDllFileName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "�ʺA���J DLL �ΩI�s method ���d��";
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Assembly anAsm; 
			Type aType; 
			Type aPluginType; 
			object anObj; 

			// ���J DLL
			anAsm = Assembly.LoadFrom(txtDllFileName.Text); 

			// ���o���O����
			string className = "MyLib.Class1"; // �`�N�G�����g���O���W!
			aType = anAsm.GetType(className, false, true); 

			if ((aType == null)) 
			{ 
				throw new Exception("�L�k�إߪ���! �L�����O: " + className); 
			} 

			// �إߪ������
			anObj = Activator.CreateInstance(aType);

			// �I�s���� method
			string methodName = "Hello";	// ��k�W��
			object[] methodParams = new object[] {"Will Tsai"};  // �Ѽư}�C
			object retValue;  // �Ǧ^��
			
			retValue = aType.InvokeMember(methodName, BindingFlags.InvokeMethod, null, anObj, methodParams);

			MessageBox.Show(retValue.ToString());
				
		}

		private void btnSelectFile_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK) 
			{
				txtDllFileName.Text = openFileDialog1.FileName;
			}
		}
	}
}
