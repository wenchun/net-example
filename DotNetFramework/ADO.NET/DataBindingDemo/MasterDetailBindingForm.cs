using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DataBindingDemo
{
	/// <summary>
	/// Summary description for MasterDetailBindingForm.
	/// </summary>
	public class MasterDetailBindingForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid grdCustomers;
		private System.Windows.Forms.DataGrid grdOrders;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MasterDetailBindingForm()
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
			this.grdCustomers = new System.Windows.Forms.DataGrid();
			this.grdOrders = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
			this.SuspendLayout();
			// 
			// grdCustomers
			// 
			this.grdCustomers.DataMember = "";
			this.grdCustomers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdCustomers.Location = new System.Drawing.Point(24, 8);
			this.grdCustomers.Name = "grdCustomers";
			this.grdCustomers.Size = new System.Drawing.Size(480, 176);
			this.grdCustomers.TabIndex = 0;
			// 
			// grdOrders
			// 
			this.grdOrders.DataMember = "";
			this.grdOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdOrders.Location = new System.Drawing.Point(24, 208);
			this.grdOrders.Name = "grdOrders";
			this.grdOrders.Size = new System.Drawing.Size(480, 200);
			this.grdOrders.TabIndex = 1;
			// 
			// MasterDetailBindingForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(528, 437);
			this.Controls.Add(this.grdOrders);
			this.Controls.Add(this.grdCustomers);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "MasterDetailBindingForm";
			this.Text = "MasterDetailBindingForm";
			this.Load += new System.EventHandler(this.MasterDetailBindingForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdCustomers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void MasterDetailBindingForm_Load(object sender, System.EventArgs e)
		{
			SqlConnection cn = new SqlConnection("server=.;database=Northwind;uid=sa");

			DataSet ds = new DataSet();

			SqlDataAdapter daCustomers = new SqlDataAdapter("select * from Customers", cn);
			daCustomers.Fill(ds, "Customers");

			SqlDataAdapter daOrders = new SqlDataAdapter("select * from Orders", cn);
			daOrders.Fill(ds, "Orders");

			// 建立關聯
			DataColumn parentCol = ds.Tables["Customers"].Columns["CustomerID"];
			DataColumn childCol = ds.Tables["Orders"].Columns["CustomerID"];
			DataRelation rel = new DataRelation("CustOrdersRelation", parentCol, childCol);
			ds.Relations.Add(rel);

			// 資料繫結
			grdCustomers.AllowNavigation = false;
			grdCustomers.DataSource = ds;
			grdCustomers.DataMember = "Customers";
			grdOrders.DataSource = ds;
			grdOrders.DataMember = "Customers.CustOrdersRelation";
		}
	}
}
