using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataViewSort
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboSortFields;
		private System.Windows.Forms.Button btnSort;
		private System.Windows.Forms.CheckBox chkAscend;
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.cboSortFields = new System.Windows.Forms.ComboBox();
			this.btnSort = new System.Windows.Forms.Button();
			this.chkAscend = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																																  new System.Data.Common.DataTableMapping("Table", "Order Details", new System.Data.Common.DataColumnMapping[] {
																																																																						new System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"),
																																																																						new System.Data.Common.DataColumnMapping("Quantity", "Quantity"),
																																																																						new System.Data.Common.DataColumnMapping("OrderID", "OrderID"),
																																																																						new System.Data.Common.DataColumnMapping("ProductID", "ProductID")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM [Order Details] WHERE (OrderID = @Original_OrderID) AND (ProductID = " +
				"@Original_ProductID) AND (Quantity = @Original_Quantity) AND (UnitPrice = @Origi" +
				"nal_UnitPrice)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Quantity", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UnitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"MICHAEL-I\";packet size=4096;user id=sa;data source=\"127.0.0.1\";pe" +
				"rsist security info=False;initial catalog=Northwind";
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO [Order Details] (UnitPrice, Quantity, OrderID, ProductID) VALUES (@Un" +
				"itPrice, @Quantity, @OrderID, @ProductID); SELECT UnitPrice, Quantity, OrderID, " +
				"ProductID FROM [Order Details] WHERE (OrderID = @OrderID) AND (ProductID = @Prod" +
				"uctID)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.SmallInt, 2, "Quantity"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT ProductID, OrderID, UnitPrice, Quantity FROM [Order Details]";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE [Order Details] SET UnitPrice = @UnitPrice, Quantity = @Quantity, OrderID = @OrderID, ProductID = @ProductID WHERE (OrderID = @Original_OrderID) AND (ProductID = @Original_ProductID) AND (Quantity = @Original_Quantity) AND (UnitPrice = @Original_UnitPrice); SELECT UnitPrice, Quantity, OrderID, ProductID FROM [Order Details] WHERE (OrderID = @OrderID) AND (ProductID = @ProductID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.SmallInt, 2, "Quantity"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Quantity", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UnitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(24, 64);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(448, 248);
			this.dataGrid1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Sort by";
			// 
			// cboSortFields
			// 
			this.cboSortFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSortFields.Items.AddRange(new object[] {
																			  "ProductID",
																			  "OrderID",
																			  "UnitPrice",
																			  "Quantity"});
			this.cboSortFields.Location = new System.Drawing.Point(88, 16);
			this.cboSortFields.Name = "cboSortFields";
			this.cboSortFields.Size = new System.Drawing.Size(121, 23);
			this.cboSortFields.TabIndex = 2;
			// 
			// btnSort
			// 
			this.btnSort.Location = new System.Drawing.Point(336, 16);
			this.btnSort.Name = "btnSort";
			this.btnSort.TabIndex = 3;
			this.btnSort.Text = "Sort";
			this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
			// 
			// chkAscend
			// 
			this.chkAscend.Location = new System.Drawing.Point(224, 16);
			this.chkAscend.Name = "chkAscend";
			this.chkAscend.TabIndex = 4;
			this.chkAscend.Text = "遞增排序";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(496, 333);
			this.Controls.Add(this.chkAscend);
			this.Controls.Add(this.btnSort);
			this.Controls.Add(this.cboSortFields);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGrid1);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.Name = "Form1";
			this.Text = "示範利用 DataView 對資料進行排序";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private DataSet ds;
		private DataView dv;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			// 建立 DataSet 物件
			this.ds = new DataSet();
			
			// 將查詢結果填入 DataSet 物件
			sqlDataAdapter1.Fill(ds, "Orders");

			// 建立 DataView 物件，並指定 Table
			this.dv = new DataView();
			this.dv.Table = this.ds.Tables["Orders"];

			// 以 DataView 物件做為 DataGrid 的資料來源
			dataGrid1.DataSource = dv;
		}

		private void btnSort_Click(object sender, System.EventArgs e)
		{
			string s = " ASC";

			if (chkAscend.Checked == false) 
			{
				s = " DESC";
			}

			// 每當更改 DataView 的 Sort 屬性，DataGrid 就會立即反應新的排序結果
			this.dv.Sort = cboSortFields.Text + s;
		}
	}
}
