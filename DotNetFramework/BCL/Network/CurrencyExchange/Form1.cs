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

namespace CurrencyExchange
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
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
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(48, 72);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(48, 376);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(552, 176);
			this.textBox2.TabIndex = 7;
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(48, 344);
			this.label1.Name = "label1";
			this.label1.TabIndex = 6;
			this.label1.Text = "剖析後的結果";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(48, 120);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(552, 200);
			this.textBox1.TabIndex = 5;
			this.textBox1.Text = "執行此範例時，防火牆可能要暫時關閉。";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.label2.Location = new System.Drawing.Point(48, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(544, 40);
			this.label2.TabIndex = 8;
			this.label2.Text = "示範利用 HttpWebRequest 搭配 HttpAgilityPack 元件模擬瀏覽器發出 request，取出財政部關稅總局網站的貨幣匯率查詢結果";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(664, 557);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
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
			string url = "http://web.customs.gov.tw/currency/currency/currency.asp?qry=1&language=c";

			ASCIIEncoding encoding = new ASCIIEncoding();
			StringBuilder postData = new StringBuilder();
			postData.Append("counter=TWD&");
			postData.Append("year=95&");
			postData.Append("month=4&");
			postData.Append("day=0&");
			postData.Append("B1=d");

			byte[]  data = encoding.GetBytes(postData.ToString());

			HttpWebRequest req = (HttpWebRequest) HttpWebRequest.Create(url); 
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";
			req.ContentLength = data.Length;

			Stream strm = req.GetRequestStream();
			strm.Write(data, 0, data.Length);
			strm.Close();

			HttpWebResponse resp = (HttpWebResponse)req.GetResponse(); 
			StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.Default); 
			string html = sr.ReadToEnd().Trim();	// 傳回的結果保存在一個字串變數裡
			textBox1.Text = html;
			resp.Close(); 
			sr.Close(); 		

			// 利用 HtmlAgilityPack 取出傳回的網頁中我們想要的部份
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);
			HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(".//table[2]/tr");
			if (nodes == null) 
			{
				throw new Exception("傳回的結果不是預期的格式!");
			}

			HtmlNode aNode = nodes[0];
			string content = aNode.ChildNodes[4].InnerText;
			ParseContent(content);
		}

		/// <summary>
		/// 從字串剖析並逐一取出貨幣匯率查詢結果的每個欄位值
		/// </summary>
		/// <param name="content"></param>
		public void ParseContent(string content)
		{
			StringBuilder sb = new StringBuilder(content);
			// 把所有 \n 字元轉成空白
			sb.Replace("\n", " ");

			char[] sep = new char[] {' '};
			string[] values = sb.ToString().Split(sep, 65536);

			int cnt = 0;
			foreach (string s in values) 
			{
				if (s.Trim() == "")
					continue;

				textBox2.Text += s + ", ";
				cnt++;
				if (cnt >= 7) 
				{
					textBox2.Text += "\r\n";
					cnt = 0;
				}
			}
		}


	}
}
