using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace XmlReaderDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnXmlTextReader;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnXPath;
		private System.Windows.Forms.Button btnXmlDom;
		private System.Windows.Forms.TextBox txtXml;
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
			this.btnXmlTextReader = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnXPath = new System.Windows.Forms.Button();
			this.btnXmlDom = new System.Windows.Forms.Button();
			this.txtXml = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnXmlTextReader
			// 
			this.btnXmlTextReader.Location = new System.Drawing.Point(352, 24);
			this.btnXmlTextReader.Name = "btnXmlTextReader";
			this.btnXmlTextReader.Size = new System.Drawing.Size(184, 32);
			this.btnXmlTextReader.TabIndex = 0;
			this.btnXmlTextReader.Text = "XmlTextReader";
			this.btnXmlTextReader.Click += new System.EventHandler(this.btnXmlTextReader_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(352, 184);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(256, 144);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "結果";
			// 
			// btnXPath
			// 
			this.btnXPath.Location = new System.Drawing.Point(352, 72);
			this.btnXPath.Name = "btnXPath";
			this.btnXPath.Size = new System.Drawing.Size(184, 32);
			this.btnXPath.TabIndex = 2;
			this.btnXPath.Text = "XPath";
			this.btnXPath.Click += new System.EventHandler(this.btnXPath_Click);
			// 
			// btnXmlDom
			// 
			this.btnXmlDom.Location = new System.Drawing.Point(352, 120);
			this.btnXmlDom.Name = "btnXmlDom";
			this.btnXmlDom.Size = new System.Drawing.Size(184, 32);
			this.btnXmlDom.TabIndex = 3;
			this.btnXmlDom.Text = "XML DOM";
			this.btnXmlDom.Click += new System.EventHandler(this.btnXmlDom_Click);
			// 
			// txtXml
			// 
			this.txtXml.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtXml.Location = new System.Drawing.Point(16, 16);
			this.txtXml.Multiline = true;
			this.txtXml.Name = "txtXml";
			this.txtXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtXml.Size = new System.Drawing.Size(312, 312);
			this.txtXml.TabIndex = 4;
			this.txtXml.Text = "XML 文件";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(624, 349);
			this.Controls.Add(this.txtXml);
			this.Controls.Add(this.btnXmlDom);
			this.Controls.Add(this.btnXPath);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnXmlTextReader);
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
			txtXml.Text = 
				"<store>\r\n" +
				"  <product>\r\n" +
				"    <id>001</id>\r\n" + 
				"    <name>果汁</name>\r\n" + 
				"  </product>\r\n" +
				"  <product>\r\n" +
				"    <id>002</id>\r\n" + 
				"    <name>牛奶</name>\r\n" +
				"  </product>\r\n" +
				"</store>\r\n";
		}

		private void btnXmlTextReader_Click(object sender, System.EventArgs e)
		{
			StringReader sr = new StringReader(txtXml.Text);
			XmlTextReader xmlRdr = new XmlTextReader(sr);
			textBox1.Text = "";
			while (xmlRdr.Read()) 
			{
				if (xmlRdr.IsStartElement("id")) 
				{
					textBox1.Text += "id = " + xmlRdr.ReadString() + "\r\n";
				}
				if (xmlRdr.IsStartElement("name")) 
				{
					textBox1.Text += "name = " + xmlRdr.ReadString() + "\r\n";
				}
			}

			sr.Close();
			xmlRdr.Close();
		}

		private void btnXPath_Click(object sender, System.EventArgs e)
		{
			textBox1.Text = "";
			StringReader rdr = new StringReader(txtXml.Text);

			// 1.建立 XPathDocument.
			XPathDocument doc = new XPathDocument(rdr);

			// 2.透過 XPathDocument 建立 XPathNavigator.
			XPathNavigator nav = doc.CreateNavigator();

			// 3.利用 XPathNavigator 直接定位到指定的節點樣式，並取得迭代器.
			XPathNodeIterator itor = nav.Select("*/product");

			// 4.利用迭代器取出所有子節點的內容.
			while (itor.MoveNext()) 
			{
				nav = itor.Current;
				nav.MoveToFirstChild();				
				string id = nav.Value;
				nav.MoveToNext();
				string name = nav.Value;
				textBox1.Text += "id = " + id + ", " + "name = " + name + "\r\n";
			}

			rdr.Close();			
		}

		private void btnXmlDom_Click(object sender, System.EventArgs e)
		{
			textBox1.Text = "";

			// 1.建立 XmlDocument.
			XmlDocument doc = new XmlDocument();

			// 2.載入 XML 文件.
			doc.LoadXml(txtXml.Text);

			// 3.取出某個 XPath 路徑下的節點清單.
			XmlNodeList nodes = doc.SelectNodes("*/product");

			// 4.從節點清單中逐一讀取各個子節點的內容.
			foreach (XmlNode node in nodes) 
			{
				XmlNode tmpNode;

				tmpNode = node.FirstChild;
				string id = tmpNode.InnerText;

				tmpNode = tmpNode.NextSibling;
				string name = tmpNode.InnerText;

				textBox1.Text += "id = " + id + ", " + "name = " + name + "\r\n";
			}
		}

	}
}
