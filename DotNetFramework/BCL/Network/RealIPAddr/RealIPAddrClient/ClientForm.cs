using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace RealIPAddrClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ClientForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ClientForm()
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
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.button1.Location = new System.Drawing.Point(40, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(184, 56);
			this.button1.TabIndex = 0;
			this.button1.Text = "向伺服器發出訊息";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ClientForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(320, 162);
			this.Controls.Add(this.button1);
			this.Name = "ClientForm";
			this.Text = "用戶端程式";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ClientForm());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
/*
			IPAddress ipAddr = IPAddress.Parse("192.168.0.130"); 
			IPEndPoint endPoint = new IPEndPoint(ipAddr, 8080); 
			System.Net.Sockets.TcpClient tcpClient = new TcpClient(endPoint);
*/
			System.Net.Sockets.TcpClient tcpClient = new TcpClient();			
			try 
			{
				tcpClient.Connect("huanlin.dyndns.org", 80);
				tcpClient.Close();
			}
			catch (SocketException ex) 
			{
				MessageBox.Show(ex.Message + "\r\n錯誤碼=" + ex.ErrorCode);
			}
		}
	}
}
