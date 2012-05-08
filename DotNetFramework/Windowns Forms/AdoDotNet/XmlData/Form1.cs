using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Text;

namespace XmlData
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnReadXmlFragment;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
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
			this.btnReadXmlFragment = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnReadXmlFragment
			// 
			this.btnReadXmlFragment.Location = new System.Drawing.Point(24, 16);
			this.btnReadXmlFragment.Name = "btnReadXmlFragment";
			this.btnReadXmlFragment.Size = new System.Drawing.Size(176, 40);
			this.btnReadXmlFragment.TabIndex = 0;
			this.btnReadXmlFragment.Text = "讀取 XML Fragment";
			this.btnReadXmlFragment.Click += new System.EventHandler(this.btnReadXmlFragment_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 72);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(552, 184);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "textBox1";
			this.textBox1.WordWrap = false;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 272);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(552, 200);
			this.dataGrid1.TabIndex = 3;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(584, 493);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnReadXmlFragment);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "XML 與 DataSet";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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

		private void btnReadXmlFragment_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection("server=.;database=Northwind;uid=sa");
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = conn;
			cmd.CommandText = "select CustomerID, CompanyName from Customers FOR XML AUTO, XMLDATA";	

			conn.Open();
			XmlReader xr = cmd.ExecuteXmlReader();

			StringBuilder sb = new StringBuilder();
			while (xr.Read()) 
			{
				sb.Append(xr.ReadOuterXml() + "\r\n");
			}
			xr.Close();

			textBox1.Text = sb.ToString();

			// 也可以讀入 DataSet
			xr = cmd.ExecuteXmlReader(); 
			DataSet ds = new DataSet();
			ds.ReadXml(xr, XmlReadMode.Fragment);
			dataGrid1.DataSource = ds.Tables[0];

			conn.Close();
		}
	}
}
