using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;

namespace RealIPAddress
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ServerForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ServerForm()
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
			this.txtIP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(128, 48);
			this.txtIP.Multiline = true;
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(200, 24);
			this.txtIP.TabIndex = 0;
			this.txtIP.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "用戶端 IP 位址:";
			// 
			// ServerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(376, 130);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtIP);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "ServerForm";
			this.Text = "伺服器端程式";
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
			Application.Run(new ServerForm());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Thread thd = new Thread(new ThreadStart(ThreadTask));
			thd.IsBackground = true;	// 如果不寫這行，視窗關閉時，程式仍然不會結束
			thd.Start();
		}

		public void ThreadTask()
		{
			System.Net.IPAddress ipAddr = System.Net.IPAddress.Parse("192.168.0.130");
			TcpListener tcpListener = new TcpListener(ipAddr, 80);
			tcpListener.Start(); 

			TcpClient tcpClient;
			NetworkStream netStream;
			
			while (true) 
			{
				tcpClient = tcpListener.AcceptTcpClient();
				
				netStream = tcpClient.GetStream(); 

				// 使用 Reflection 機制取得 protected 屬性。
				Type streamType = netStream.GetType();
				PropertyInfo pi = streamType.GetProperty("Socket", BindingFlags.NonPublic | BindingFlags.Instance);
				Socket sckt = (Socket)pi.GetValue(netStream, null);
				EndPoint endp = sckt.RemoteEndPoint;
				String clientIP = endp.ToString();
				txtIP.Text = clientIP;	

				netStream.Close();
				tcpClient.Close();
			}
		}
	}
}
