using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using DemoTools;

namespace LinqToXmlDemo
{
	public partial class MainForm : DemoFormBase
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnQueryXmlData_Click(object sender, EventArgs e)
		{
			// 載入 XML 文件.
			string xmlFileName = Path.GetDirectoryName(Application.ExecutablePath) + @"\Data.xml";		
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(xmlFileName);

			// 將 XML 文件轉換成 LINQ 的 XDocument
			XDocument xdoc = XDocument.Parse(xmlDoc.OuterXml);

			var items =
				from item in xdoc.Descendants("Customer")
				select new
				{
					ID = item.Element("ID").Value,
					Name = item.Element("Name").Value
				};

			dataGridView1.DataSource = items.ToList();

			foreach (var item in items)
			{
				Console.WriteLine("{0} : {1}", item.ID, item.Name);
			}
		}
	}
}
