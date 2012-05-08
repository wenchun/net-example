using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CRDemo01_TypedRpt
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDB;
		private System.Windows.Forms.TextBox txtDbServer;
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
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDB = new System.Windows.Forms.TextBox();
			this.txtDbServer = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(104, 248);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 40);
			this.button1.TabIndex = 4;
			this.button1.Text = "預覽報表";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(144, 160);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(112, 25);
			this.txtUserName.TabIndex = 2;
			this.txtUserName.Text = "";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(144, 200);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(112, 25);
			this.txtPassword.TabIndex = 3;
			this.txtPassword.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(96, 160);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "帳號";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(96, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "密碼";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(48, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(208, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "輸入以下資料庫連線參數：";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(46, 122);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 24);
			this.label4.TabIndex = 9;
			this.label4.Text = "資料庫名稱";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(40, 84);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "資料庫伺服器";
			// 
			// txtDB
			// 
			this.txtDB.Enabled = false;
			this.txtDB.Location = new System.Drawing.Point(144, 120);
			this.txtDB.Name = "txtDB";
			this.txtDB.Size = new System.Drawing.Size(112, 25);
			this.txtDB.TabIndex = 1;
			this.txtDB.Text = "Northwind";
			// 
			// txtDbServer
			// 
			this.txtDbServer.Location = new System.Drawing.Point(144, 80);
			this.txtDbServer.Name = "txtDbServer";
			this.txtDbServer.Size = new System.Drawing.Size(112, 25);
			this.txtDbServer.TabIndex = 0;
			this.txtDbServer.Text = "127.0.0.1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(360, 338);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtDB);
			this.Controls.Add(this.txtDbServer);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try 
			{
				Report1Form aForm = new Report1Form(txtDbServer.Text, txtUserName.Text, txtPassword.Text);
				aForm.ShowDialog();
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
	}
}
