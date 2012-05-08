using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoNetDemo1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnLoadConnStr;
		private System.Windows.Forms.Button btnGetData;
		private System.Windows.Forms.TextBox txtConnStr;

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
			this.btnGetData = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.txtConnStr = new System.Windows.Forms.TextBox();
			this.btnLoadConnStr = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnGetData
			// 
			this.btnGetData.Enabled = false;
			this.btnGetData.Location = new System.Drawing.Point(16, 72);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(120, 32);
			this.btnGetData.TabIndex = 0;
			this.btnGetData.Text = "查詢資料";
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(24, 128);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(344, 259);
			this.listBox1.TabIndex = 1;
			// 
			// txtConnStr
			// 
			this.txtConnStr.Location = new System.Drawing.Point(144, 16);
			this.txtConnStr.Multiline = true;
			this.txtConnStr.Name = "txtConnStr";
			this.txtConnStr.Size = new System.Drawing.Size(224, 96);
			this.txtConnStr.TabIndex = 2;
			this.txtConnStr.Text = "";
			// 
			// btnLoadConnStr
			// 
			this.btnLoadConnStr.Location = new System.Drawing.Point(16, 16);
			this.btnLoadConnStr.Name = "btnLoadConnStr";
			this.btnLoadConnStr.Size = new System.Drawing.Size(120, 40);
			this.btnLoadConnStr.TabIndex = 3;
			this.btnLoadConnStr.Text = "載入連線字串";
			this.btnLoadConnStr.Click += new System.EventHandler(this.btnLoadConnStr_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(424, 450);
			this.Controls.Add(this.btnLoadConnStr);
			this.Controls.Add(this.txtConnStr);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.btnGetData);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "ADO.NET Demo 1";
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

		private void btnLoadConnStr_Click(object sender, System.EventArgs e)
		{
			txtConnStr.Text = ConfigurationSettings.AppSettings["connStr"];

			btnGetData.Enabled = true;		
		}

		void PopulateListBox(DataSet ds) 
		{
			listBox1.Items.Clear();
			foreach (DataRow row in ds.Tables[0].Rows) 
			{
				string item = row["ContactTitle"] + ", " + row["ContactName"];
				listBox1.Items.Add(item);
			}
		}

		private void btnGetData_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection(txtConnStr.Text);				
			DataSet ds = new DataSet();
			SqlDataAdapter adapter = new SqlDataAdapter("select * from Customers", conn);
			adapter.Fill(ds);

			MessageBox.Show("Connection is " + conn.State.ToString());

			PopulateListBox(ds);			
		}
	}
}
