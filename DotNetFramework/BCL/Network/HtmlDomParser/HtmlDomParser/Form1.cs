using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace HtmlDomParser
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 56);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Do Request";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(24, 96);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(552, 200);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "執行此範例時，防火牆可能要暫時關閉。";
			// 
			// txtUrl
			// 
			this.txtUrl.Location = new System.Drawing.Point(24, 24);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(528, 22);
			this.txtUrl.TabIndex = 2;
			this.txtUrl.Text = "http://egw20.fdc.gov.tw/bgq/BGQ006N.JSP?code0=1&code1=12868245";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 320);
			this.label1.Name = "label1";
			this.label1.TabIndex = 3;
			this.label1.Text = "剖析後的結果";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(24, 352);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(552, 200);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(616, 570);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUrl);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "HtmlDomParser Demo by Huan-Lin Tsai";
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			string url = txtUrl.Text;
			HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url); 
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); 
			StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default); 
			textBox1.Text = sr.ReadToEnd().Trim();
			resp.Close(); 
			sr.Close(); 		

			
			HtmlWeb hw = new HtmlWeb();
			HtmlDocument doc = hw.Load(url);
			HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(".//td");
			string fieldName = "";
			string fieldValue = "";
			int cnt = 0;

			foreach (HtmlNode node in nodes) 
			{				
				cnt++;
				if (cnt % 2 == 1) 
				{
					fieldName = node.InnerText;
				}
				else 
				{
					fieldValue = node.InnerText;
					textBox2.Text = textBox2.Text + fieldName + fieldValue + "\r\n";
				}
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
