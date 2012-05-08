using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CRDemo02_DataSet
{
	/// <summary>
	/// Summary description for Report1Form.
	/// </summary>
	public class Report1Form : System.Windows.Forms.Form
	{
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private CRDemo02_DataSet.Report1 report11;
		private CRDemo02_DataSet.CustomerDataSet customerDataSet1;
		private System.ComponentModel.IContainer components;

		public Report1Form()
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
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Report1Form));
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.report11 = new CRDemo02_DataSet.Report1();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.customerDataSet1 = new CRDemo02_DataSet.CustomerDataSet();
			((System.ComponentModel.ISupportInitialize)(this.customerDataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.DisplayGroupTree = false;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer1.EnableDrillDown = false;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = this.report11;
			this.crystalReportViewer1.Size = new System.Drawing.Size(728, 466);
			this.crystalReportViewer1.TabIndex = 0;
			// 
			// report11
			// 
			this.report11.FileName = "";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																															new System.Data.Common.DataTableMapping("Table", "Customers", new System.Data.Common.DataColumnMapping[] {
																																																																																																				 new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
																																																																																																				 new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
																																																																																																				 new System.Data.Common.DataColumnMapping("ContactName", "ContactName"),
																																																																																																				 new System.Data.Common.DataColumnMapping("ContactTitle", "ContactTitle"),
																																																																																																				 new System.Data.Common.DataColumnMapping("Address", "Address"),
																																																																																																				 new System.Data.Common.DataColumnMapping("City", "City"),
																																																																																																				 new System.Data.Common.DataColumnMapping("Region", "Region"),
																																																																																																				 new System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"),
																																																																																																				 new System.Data.Common.DataColumnMapping("Country", "Country"),
																																																																																																				 new System.Data.Common.DataColumnMapping("Phone", "Phone"),
																																																																																																				 new System.Data.Common.DataColumnMapping("Fax", "Fax")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region," +
				" PostalCode, Country, Phone, Fax FROM Customers WHERE (CustomerID LIKE \'F%\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"MICHAEL-WIN2K\";packet size=4096;integrated security=SSPI;initial " +
				"catalog=Northwind;persist security info=False";
			// 
			// customerDataSet1
			// 
			this.customerDataSet1.DataSetName = "CustomerDataSet";
			this.customerDataSet1.Locale = new System.Globalization.CultureInfo("zh-TW");
			// 
			// Report1Form
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(728, 466);
			this.Controls.Add(this.crystalReportViewer1);
			this.Name = "Report1Form";
			this.Text = "Report1Form";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Report1Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.customerDataSet1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Report1Form_Load(object sender, System.EventArgs e)
		{
			//this.report11.DetailSection1.SectionFormat.BackgroundColor = Color.Indigo;
//			this.report11.SetDatabaseLogon("sa", "08171505", "127.0.0.1", "Northwind", false);
			this.sqlDataAdapter1.Fill(this.customerDataSet1);
			this.report11.SetDataSource(this.customerDataSet1);						
		}
	}
}
