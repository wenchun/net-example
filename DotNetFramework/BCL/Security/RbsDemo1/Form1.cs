using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Security.Principal;
using System.Security.Policy;
using System.Threading;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblUserID;
		private System.Windows.Forms.Label lblUserID2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCheckRole;
		private System.Windows.Forms.Button btnGetIdentityV1;
		private System.Windows.Forms.Button btnGetIdentityV2;
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
			this.btnGetIdentityV1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblUserID = new System.Windows.Forms.Label();
			this.btnGetIdentityV2 = new System.Windows.Forms.Button();
			this.lblUserID2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCheckRole = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnGetIdentityV1
			// 
			this.btnGetIdentityV1.Location = new System.Drawing.Point(16, 96);
			this.btnGetIdentityV1.Name = "btnGetIdentityV1";
			this.btnGetIdentityV1.Size = new System.Drawing.Size(176, 32);
			this.btnGetIdentityV1.TabIndex = 0;
			this.btnGetIdentityV1.Text = "取得使用者帳號 v1";
			this.btnGetIdentityV1.Click += new System.EventHandler(this.btnGetIdentityV1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "登入的使用者名稱：";
			// 
			// lblUserID
			// 
			this.lblUserID.Location = new System.Drawing.Point(160, 16);
			this.lblUserID.Name = "lblUserID";
			this.lblUserID.Size = new System.Drawing.Size(328, 23);
			this.lblUserID.TabIndex = 2;
			this.lblUserID.Text = "lblUserID";
			// 
			// btnGetIdentityV2
			// 
			this.btnGetIdentityV2.Location = new System.Drawing.Point(208, 96);
			this.btnGetIdentityV2.Name = "btnGetIdentityV2";
			this.btnGetIdentityV2.Size = new System.Drawing.Size(176, 32);
			this.btnGetIdentityV2.TabIndex = 3;
			this.btnGetIdentityV2.Text = "取得使用者帳號 v2";
			this.btnGetIdentityV2.Click += new System.EventHandler(this.btnGetIdentityV2_Click);
			// 
			// lblUserID2
			// 
			this.lblUserID2.Location = new System.Drawing.Point(160, 48);
			this.lblUserID2.Name = "lblUserID2";
			this.lblUserID2.Size = new System.Drawing.Size(328, 23);
			this.lblUserID2.TabIndex = 5;
			this.lblUserID2.Text = "lblUserID2";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "登入的使用者名稱：";
			// 
			// btnCheckRole
			// 
			this.btnCheckRole.Location = new System.Drawing.Point(16, 152);
			this.btnCheckRole.Name = "btnCheckRole";
			this.btnCheckRole.Size = new System.Drawing.Size(176, 32);
			this.btnCheckRole.TabIndex = 6;
			this.btnCheckRole.Text = "檢查使用者角色";
			this.btnCheckRole.Click += new System.EventHandler(this.btnCheckRole_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(552, 270);
			this.Controls.Add(this.btnCheckRole);
			this.Controls.Add(this.lblUserID2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnGetIdentityV2);
			this.Controls.Add(this.lblUserID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnGetIdentityV1);
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

		private void aa()
		{
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);			
			IPrincipal aPrcIntf = Thread.CurrentPrincipal;
			lblUserID.Text = aPrcIntf.Identity.Name;
		}

		private void btnGetIdentityV1_Click(object sender, System.EventArgs e)
		{
			// Note: SetPrincipalPolicy 一定要先呼叫，否則 
			// Thread.CurrentPrincipal 無法取得目前登入的使用者身份。
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);			
			IPrincipal aPrcIntf = Thread.CurrentPrincipal;
			lblUserID.Text = aPrcIntf.Identity.Name;
		}

		private void btnGetIdentityV2_Click(object sender, System.EventArgs e)
		{
			WindowsIdentity aIdt = WindowsIdentity.GetCurrent();
			lblUserID2.Text = aIdt.Name;

			// WindowsPrincipal aPrc = new WindowsPrincipal(aIdt);
		}

		private void btnCheckRole_Click(object sender, System.EventArgs e)
		{
			btnGetIdentityV1_Click(this, EventArgs.Empty);
			WindowsPrincipal aPrc = (WindowsPrincipal) Thread.CurrentPrincipal;
			if (!aPrc.IsInRole(WindowsBuiltInRole.Administrator))  
			{
				MessageBox.Show("必須有系統管理員身分才能執行此功能!");
			}	
			else
			{
				MessageBox.Show("您是系統管理員。");
			}
		}
	}
}
