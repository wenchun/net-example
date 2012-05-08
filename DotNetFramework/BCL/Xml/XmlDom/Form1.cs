using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;

namespace XmlDom
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnWriteXml;
		private System.Windows.Forms.Button btnReadXml;
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
			this.btnWriteXml = new System.Windows.Forms.Button();
			this.btnReadXml = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnWriteXml
			// 
			this.btnWriteXml.Location = new System.Drawing.Point(40, 32);
			this.btnWriteXml.Name = "btnWriteXml";
			this.btnWriteXml.Size = new System.Drawing.Size(184, 40);
			this.btnWriteXml.TabIndex = 0;
			this.btnWriteXml.Text = "建立 XML 文件";
			this.btnWriteXml.Click += new System.EventHandler(this.btnWriteXml_Click);
			// 
			// btnReadXml
			// 
			this.btnReadXml.Location = new System.Drawing.Point(40, 88);
			this.btnReadXml.Name = "btnReadXml";
			this.btnReadXml.Size = new System.Drawing.Size(184, 40);
			this.btnReadXml.TabIndex = 1;
			this.btnReadXml.Text = "讀取 XML 文件";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.btnReadXml);
			this.Controls.Add(this.btnWriteXml);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "XML DOM Demo";
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

		private void btnWriteXml_Click(object sender, System.EventArgs e)
		{
			XmlDocument doc = new XmlDocument();
			try 
			{
				// Write down the XML declaration
				XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null); 
				doc.InsertBefore(xmlDeclaration, doc.DocumentElement);

				// 建立根節點
				XmlElement rootNode = doc.CreateElement("Employees");
				doc.AppendChild(rootNode);

				// 建立一個子節點
				XmlElement node = doc.CreateElement("Emp");
				node.SetAttribute("ID", "Michael");
				node.SetAttribute("Age", "20");
				rootNode.AppendChild(node);

				// 建立 Emp 底下的巢狀子節點
				XmlElement childNode = doc.CreateElement("Depart");
				node.AppendChild(childNode);

				// 存檔
				doc.Save("test.xml");			

				MessageBox.Show("Ok!");
			}
			catch (Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}
			
		}
	}
}
