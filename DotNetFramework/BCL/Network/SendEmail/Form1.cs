using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Indy.Sockets;

namespace SendEmail
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtFrom;
		private System.Windows.Forms.TextBox txtTo;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtBody;
		private System.Windows.Forms.TextBox txtSubject;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSmtpServer;
		private System.Windows.Forms.Label label5;
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
			this.txtFrom = new System.Windows.Forms.TextBox();
			this.txtTo = new System.Windows.Forms.TextBox();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.txtBody = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSmtpServer = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtFrom
			// 
			this.txtFrom.Location = new System.Drawing.Point(96, 24);
			this.txtFrom.Name = "txtFrom";
			this.txtFrom.Size = new System.Drawing.Size(408, 25);
			this.txtFrom.TabIndex = 0;
			this.txtFrom.Text = "huanlin.tsai@msa.hinet.net";
			// 
			// txtTo
			// 
			this.txtTo.Location = new System.Drawing.Point(96, 56);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(408, 25);
			this.txtTo.TabIndex = 1;
			this.txtTo.Text = "";
			// 
			// txtSubject
			// 
			this.txtSubject.Location = new System.Drawing.Point(96, 88);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(408, 25);
			this.txtSubject.TabIndex = 2;
			this.txtSubject.Text = "";
			// 
			// txtBody
			// 
			this.txtBody.Location = new System.Drawing.Point(8, 152);
			this.txtBody.Multiline = true;
			this.txtBody.Name = "txtBody";
			this.txtBody.Size = new System.Drawing.Size(504, 200);
			this.txtBody.TabIndex = 3;
			this.txtBody.Text = "";
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(416, 416);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(96, 32);
			this.btnSend.TabIndex = 5;
			this.btnSend.Text = "寄出";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "寄件人";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "收件人";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "主旨";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 416);
			this.label4.Name = "label4";
			this.label4.TabIndex = 8;
			this.label4.Text = "SMTP 伺服器:";
			// 
			// txtSmtpServer
			// 
			this.txtSmtpServer.Location = new System.Drawing.Point(112, 416);
			this.txtSmtpServer.Name = "txtSmtpServer";
			this.txtSmtpServer.Size = new System.Drawing.Size(248, 25);
			this.txtSmtpServer.TabIndex = 4;
			this.txtSmtpServer.Text = "msa.hinet.net";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "內文";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(544, 469);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtSmtpServer);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtBody);
			this.Controls.Add(this.txtSubject);
			this.Controls.Add(this.txtTo);
			this.Controls.Add(this.txtFrom);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "使用 Indy.NTE 寄送 E-mail";
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

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			Indy.Sockets.Message msg = new Indy.Sockets.Message();
			msg.From.Text = txtFrom.Text;
			
			EMailAddressItem recipient = msg.Recipients.Add();
			recipient.Address = txtTo.Text;
			
			msg.Subject = txtSubject.Text;
			msg.Body.Text = txtBody.Text;

			SMTP smtp = new SMTP();
			smtp.Host = txtSmtpServer.Text;
			smtp.Connect();
			try 
			{
				smtp.Send(msg);
			}
			finally
			{
				smtp.Disconnect();
			}
		}
	}
}
