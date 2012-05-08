using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.DirectoryServices;
using ActiveDs;

namespace UserPassword
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button uxGetUserInfoBtn;
		private System.Windows.Forms.TextBox uxUserInfo;
		private System.Windows.Forms.TextBox uxUserName;
		private System.Windows.Forms.Button uxChgPwdBtn;
		private System.Windows.Forms.TextBox uxOldPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox uxNewPassword;
		private System.Windows.Forms.Label label4;
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
			this.label1 = new System.Windows.Forms.Label();
			this.uxUserInfo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.uxUserName = new System.Windows.Forms.TextBox();
			this.uxGetUserInfoBtn = new System.Windows.Forms.Button();
			this.uxChgPwdBtn = new System.Windows.Forms.Button();
			this.uxOldPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.uxNewPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 56);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "User Info:";
			// 
			// uxUserInfo
			// 
			this.uxUserInfo.Location = new System.Drawing.Point(12, 84);
			this.uxUserInfo.Multiline = true;
			this.uxUserInfo.Name = "uxUserInfo";
			this.uxUserInfo.Size = new System.Drawing.Size(360, 144);
			this.uxUserInfo.TabIndex = 1;
			this.uxUserInfo.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "User Name:";
			// 
			// uxUserName
			// 
			this.uxUserName.Location = new System.Drawing.Point(100, 20);
			this.uxUserName.Name = "uxUserName";
			this.uxUserName.Size = new System.Drawing.Size(160, 25);
			this.uxUserName.TabIndex = 3;
			this.uxUserName.Text = "";
			// 
			// uxGetUserInfoBtn
			// 
			this.uxGetUserInfoBtn.Location = new System.Drawing.Point(268, 20);
			this.uxGetUserInfoBtn.Name = "uxGetUserInfoBtn";
			this.uxGetUserInfoBtn.Size = new System.Drawing.Size(104, 28);
			this.uxGetUserInfoBtn.TabIndex = 4;
			this.uxGetUserInfoBtn.Text = "Get User Info";
			this.uxGetUserInfoBtn.Click += new System.EventHandler(this.uxGetUserInfoBtn_Click);
			// 
			// uxChgPwdBtn
			// 
			this.uxChgPwdBtn.Location = new System.Drawing.Point(252, 296);
			this.uxChgPwdBtn.Name = "uxChgPwdBtn";
			this.uxChgPwdBtn.Size = new System.Drawing.Size(112, 28);
			this.uxChgPwdBtn.TabIndex = 7;
			this.uxChgPwdBtn.Text = "變更密碼";
			this.uxChgPwdBtn.Click += new System.EventHandler(this.uxChgPwdBtn_Click);
			// 
			// uxOldPassword
			// 
			this.uxOldPassword.Location = new System.Drawing.Point(80, 264);
			this.uxOldPassword.Name = "uxOldPassword";
			this.uxOldPassword.Size = new System.Drawing.Size(148, 25);
			this.uxOldPassword.TabIndex = 6;
			this.uxOldPassword.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 264);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "舊密碼:";
			// 
			// uxNewPassword
			// 
			this.uxNewPassword.Location = new System.Drawing.Point(80, 296);
			this.uxNewPassword.Name = "uxNewPassword";
			this.uxNewPassword.Size = new System.Drawing.Size(148, 25);
			this.uxNewPassword.TabIndex = 9;
			this.uxNewPassword.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 296);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "新密碼:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(484, 401);
			this.Controls.Add(this.uxNewPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.uxChgPwdBtn);
			this.Controls.Add(this.uxOldPassword);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.uxGetUserInfoBtn);
			this.Controls.Add(this.uxUserName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.uxUserInfo);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private void uxGetUserInfoBtn_Click(object sender, System.EventArgs e)
		{
			string adsPath = "WinNT://" + Environment.MachineName + "/" + uxUserName.Text + ",user";
			DirectoryEntry entry = new DirectoryEntry(adsPath);
			IADsUser user = (IADsUser) entry.NativeObject;

			uxUserInfo.Text = 
				"ADS path: " + adsPath + 
				"\r\nFullname: " + user.FullName +
				"\r\nLast login: " + user.LastLogin +
				"\r\nDescription: " + user.Description;
		}

		private void uxChgPwdBtn_Click(object sender, System.EventArgs e)
		{
			string adsPath = "WinNT://" + Environment.MachineName + "/" + uxUserName.Text + ",user";
			DirectoryEntry entry = new DirectoryEntry(adsPath);
			IADsUser user = (IADsUser) entry.NativeObject;
			try
			{
				user.ChangePassword(uxOldPassword.Text, uxNewPassword.Text);
				MessageBox.Show("密碼變更成功。");
			}
			catch (Exception ex)
			{
				MessageBox.Show("變更密碼失敗: " + ex.Message);
			}
		}
	}
}
