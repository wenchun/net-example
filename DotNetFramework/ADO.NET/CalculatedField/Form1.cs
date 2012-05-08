using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CalculatedFieldDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private WindowsApplication1.OrderDataSet orderDataSet1;
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
			this.button1 = new System.Windows.Forms.Button();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.orderDataSet1 = new WindowsApplication1.OrderDataSet();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.orderDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "select dbo.[Order Details].* from dbo.[Order Details]";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"MICHAEL-I\";packet size=4096;user id=sa;data source=\".\";persist se" +
				"curity info=False;initial catalog=Northwind";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			// 
			// orderDataSet1
			// 
			this.orderDataSet1.DataSetName = "OrderDataSet";
			this.orderDataSet1.Locale = new System.Globalization.CultureInfo("zh-TW");
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "Table";
			this.dataGrid1.DataSource = this.orderDataSet1;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 80);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(608, 256);
			this.dataGrid1.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(744, 389);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.orderDataSet1)).EndInit();
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

		private void button1_Click(object sender, System.EventArgs e)
		{
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			DataColumn col = new DataColumn("羆基", typeof(double));
			DataTable tbl = orderDataSet1.Tables[0];
			tbl.Columns.Add(col);
			tbl.RowChanged +=new DataRowChangeEventHandler(tbl_RowChanged);
			tbl.ColumnChanged += new DataColumnChangeEventHandler(tbl_ColumnChanged);

			sqlDataAdapter1.Fill(orderDataSet1);

		}

		private void tbl_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			if (e.Row["羆基"] == DBNull.Value)
			{
				e.Row["羆基"] = Convert.ToDouble(e.Row["UnitPrice"]) * Convert.ToDouble(e.Row["Quantity"]);
			}
		}

		private void tbl_ColumnChanged(object sender, DataColumnChangeEventArgs e)
		{
			string colName = e.Column.ColumnName;
			if (colName == "Quantity" || colName == "UnitPrice") 
			{
				e.Row["羆基"] = Convert.ToDouble(e.Row["UnitPrice"]) * Convert.ToDouble(e.Row["Quantity"]);
			}		
		}

	}
}
