using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataViewFilter
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboCmpOpr;
		private System.Windows.Forms.TextBox txtFieldValue;
		private System.Windows.Forms.ComboBox cboFields;
		private System.Windows.Forms.Button btnRowFilter;
		private System.Windows.Forms.Button btnRowStateFilter;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboRowStates;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel statusBarPanel3;
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnRowFilter = new System.Windows.Forms.Button();
			this.cboFields = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cboCmpOpr = new System.Windows.Forms.ComboBox();
			this.txtFieldValue = new System.Windows.Forms.TextBox();
			this.btnRowStateFilter = new System.Windows.Forms.Button();
			this.cboRowStates = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			this.SuspendLayout();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=\"MICHAEL-I\";packet size=4096;user id=sa;data source=\"127.0.0.1\";pe" +
				"rsist security info=False;initial catalog=Northwind";
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
			this.dataGrid1.Location = new System.Drawing.Point(16, 104);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(504, 248);
			this.dataGrid1.TabIndex = 1;
			// 
			// btnRowFilter
			// 
			this.btnRowFilter.Location = new System.Drawing.Point(520, 16);
			this.btnRowFilter.Name = "btnRowFilter";
			this.btnRowFilter.Size = new System.Drawing.Size(152, 32);
			this.btnRowFilter.TabIndex = 7;
			this.btnRowFilter.Text = "Apply RowFilter";
			this.btnRowFilter.Click += new System.EventHandler(this.btnRowFilter_Click);
			// 
			// cboFields
			// 
			this.cboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFields.Items.AddRange(new object[] {
																		 "(不篩選)",
																		 "ProductID",
																		 "OrderID",
																		 "UnitPrice",
																		 "Quantity"});
			this.cboFields.Location = new System.Drawing.Point(128, 16);
			this.cboFields.Name = "cboFields";
			this.cboFields.Size = new System.Drawing.Size(120, 23);
			this.cboFields.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "資料篩選條件:";
			// 
			// cboCmpOpr
			// 
			this.cboCmpOpr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCmpOpr.Items.AddRange(new object[] {
																		 ">",
																		 "<",
																		 "=",
																		 ">=",
																		 "<=",
																		 "<>",
																		 "like"});
			this.cboCmpOpr.Location = new System.Drawing.Point(264, 16);
			this.cboCmpOpr.Name = "cboCmpOpr";
			this.cboCmpOpr.Size = new System.Drawing.Size(80, 23);
			this.cboCmpOpr.TabIndex = 8;
			// 
			// txtFieldValue
			// 
			this.txtFieldValue.Location = new System.Drawing.Point(352, 16);
			this.txtFieldValue.Name = "txtFieldValue";
			this.txtFieldValue.Size = new System.Drawing.Size(152, 25);
			this.txtFieldValue.TabIndex = 9;
			this.txtFieldValue.Text = "(篩選條件的欄位值)";
			// 
			// btnRowStateFilter
			// 
			this.btnRowStateFilter.Location = new System.Drawing.Point(520, 56);
			this.btnRowStateFilter.Name = "btnRowStateFilter";
			this.btnRowStateFilter.Size = new System.Drawing.Size(152, 32);
			this.btnRowStateFilter.TabIndex = 10;
			this.btnRowStateFilter.Text = "Apply RowStateFilter";
			this.btnRowStateFilter.Click += new System.EventHandler(this.btnRowStateFilter_Click);
			// 
			// cboRowStates
			// 
			this.cboRowStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboRowStates.Items.AddRange(new object[] {
																			 "CurrentRows",
																			 "OriginalRows",
																			 "Unchanged",
																			 "Added",
																			 "Deleted",
																			 "ModifiedCurrent",
																			 "ModifiedOriginal",
																			 "None",
																			 "Added, Deleted, ModifiedCurrent"});
			this.cboRowStates.Location = new System.Drawing.Point(128, 56);
			this.cboRowStates.Name = "cboRowStates";
			this.cboRowStates.Size = new System.Drawing.Size(376, 23);
			this.cboRowStates.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "狀態篩選條件:";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 391);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																												  this.statusBarPanel1,
																												  this.statusBarPanel2,
																												  this.statusBarPanel3});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(696, 22);
			this.statusBar1.TabIndex = 13;
			this.statusBar1.Text = "提示訊息";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel1.Text = "狀態篩選條件";
			this.statusBarPanel1.Width = 120;
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel2.Text = "statusBarPanel2";
			this.statusBarPanel2.Width = 440;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel3.Text = "statusBarPanel3";
			this.statusBarPanel3.Width = 120;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(696, 413);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.cboRowStates);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnRowStateFilter);
			this.Controls.Add(this.txtFieldValue);
			this.Controls.Add(this.cboCmpOpr);
			this.Controls.Add(this.btnRowFilter);
			this.Controls.Add(this.cboFields);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGrid1);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.Name = "Form1";
			this.Text = "示範透過 DataView  篩選資料及狀態";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
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

			// 預先設定一個篩選條件作為範例
			cboFields.SelectedIndex = cboFields.Items.IndexOf("UnitPrice");
			cboCmpOpr.SelectedIndex = cboCmpOpr.Items.IndexOf(">");
			txtFieldValue.Text = "40";

			// 設定預設的 RowStateFilter
			cboRowStates.SelectedIndex = cboRowStates.Items.IndexOf(dv.RowStateFilter.ToString());

		}

		private void btnRowFilter_Click(object sender, System.EventArgs e)
		{
			if (cboFields.SelectedIndex == 0) 
			{
				dv.RowFilter = "";
			}
			else 
			{
				dv.RowFilter = cboFields.Text + cboCmpOpr.Text + txtFieldValue.Text;
			}
			statusBar1.Panels[1].Text = String.Format("共 {0} 筆", dv.Count);
		}

		private void btnRowStateFilter_Click(object sender, System.EventArgs e)
		{
			switch (cboRowStates.Text) 
			{
				case "CurrentRows":
					dv.RowStateFilter = DataViewRowState.CurrentRows;
					statusBar1.Panels[1].Text = "目前的記錄（包括未修改的、新增的、以及修改過的記錄）";
					break;
				case "Added":
					dv.RowStateFilter = DataViewRowState.Added;
					statusBar1.Panels[1].Text = "新增的記錄";
					break;
				case "Deleted":
					dv.RowStateFilter = DataViewRowState.Deleted;
					statusBar1.Panels[1].Text = "刪除的記錄";
  					break;
				case "ModifiedCurrent":
					dv.RowStateFilter = DataViewRowState.ModifiedCurrent;
					statusBar1.Panels[1].Text = "修改過的記錄";
					break;
				case "ModifiedOriginal":
					dv.RowStateFilter = DataViewRowState.ModifiedOriginal;
					statusBar1.Panels[1].Text = "修改過的記錄的原始值";
					break;
				case "OriginalRows":
					dv.RowStateFilter = DataViewRowState.OriginalRows;
					statusBar1.Panels[1].Text = "原始記錄（包括未修改的，以及刪除的記錄）";
					break;
				case "Unchanged":
					dv.RowStateFilter = DataViewRowState.Unchanged;
					statusBar1.Panels[1].Text = "未修改過的記錄";
					break;
				case "None":
					dv.RowStateFilter = DataViewRowState.None;
					statusBar1.Panels[1].Text = "無";
					break;
				case "Added, Deleted, ModifiedCurrent":
					statusBar1.Panels[1].Text = "新增、刪除、或修改過的記錄";
					dv.RowStateFilter = DataViewRowState.Added | DataViewRowState.Deleted | 
						DataViewRowState.ModifiedCurrent;
					break;
			}
			statusBar1.Panels[2].Text = String.Format("共 {0} 筆", dv.Count);
		}
	}
}
