using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.IO;
using System.Text;

namespace UseIPID
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.Button button1;
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
			this.txtIP = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(40, 72);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(176, 22);
			this.txtIP.TabIndex = 0;
			this.txtIP.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Access IPID Lite";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(376, 210);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtIP);
			this.Name = "Form1";
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
			string url = "http://ipid.shat.net/iponly"; 
			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url); 
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); 
			StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.ASCII); 
			txtIP.Text = sr.ReadToEnd(); 
			resp.Close(); 
			sr.Close(); 
		}
	}
}
