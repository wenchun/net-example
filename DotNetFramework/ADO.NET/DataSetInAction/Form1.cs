using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DataSetInAction
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnAddRow;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Button btnClearLog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbxLog;
		private System.Windows.Forms.Button btnAcceptChanges;
		private System.Windows.Forms.Button btnCheckRowErorr;
		private System.Windows.Forms.Button btnCloneDataSet;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDeleteRow;
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
			this.btnLoadData = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnAddRow = new System.Windows.Forms.Button();
			this.lbxLog = new System.Windows.Forms.ListBox();
			this.btnClearLog = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAcceptChanges = new System.Windows.Forms.Button();
			this.btnCheckRowErorr = new System.Windows.Forms.Button();
			this.btnCloneDataSet = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDeleteRow = new System.Windows.Forms.Button();
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
			// btnLoadData
			// 
			this.btnLoadData.Location = new System.Drawing.Point(16, 16);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(104, 40);
			this.btnLoadData.TabIndex = 0;
			this.btnLoadData.Text = "載入資料";
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 152);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(424, 264);
			this.dataGrid1.TabIndex = 1;
			// 
			// btnAddRow
			// 
			this.btnAddRow.Location = new System.Drawing.Point(128, 16);
			this.btnAddRow.Name = "btnAddRow";
			this.btnAddRow.Size = new System.Drawing.Size(96, 40);
			this.btnAddRow.TabIndex = 2;
			this.btnAddRow.Text = "Add Row";
			this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
			// 
			// lbxLog
			// 
			this.lbxLog.ItemHeight = 15;
			this.lbxLog.Location = new System.Drawing.Point(512, 168);
			this.lbxLog.Name = "lbxLog";
			this.lbxLog.Size = new System.Drawing.Size(152, 244);
			this.lbxLog.TabIndex = 3;
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(592, 128);
			this.btnClearLog.Name = "btnClearLog";
			this.btnClearLog.Size = new System.Drawing.Size(64, 32);
			this.btnClearLog.TabIndex = 4;
			this.btnClearLog.Text = "清除";
			this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(520, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Event log:";
			// 
			// btnAcceptChanges
			// 
			this.btnAcceptChanges.Location = new System.Drawing.Point(344, 16);
			this.btnAcceptChanges.Name = "btnAcceptChanges";
			this.btnAcceptChanges.Size = new System.Drawing.Size(104, 40);
			this.btnAcceptChanges.TabIndex = 6;
			this.btnAcceptChanges.Text = "AcceptChanges";
			this.btnAcceptChanges.Click += new System.EventHandler(this.btnAcceptChanges_Click);
			// 
			// btnCheckRowErorr
			// 
			this.btnCheckRowErorr.Location = new System.Drawing.Point(16, 72);
			this.btnCheckRowErorr.Name = "btnCheckRowErorr";
			this.btnCheckRowErorr.Size = new System.Drawing.Size(104, 40);
			this.btnCheckRowErorr.TabIndex = 7;
			this.btnCheckRowErorr.Text = "檢查 RowError";
			this.btnCheckRowErorr.Click += new System.EventHandler(this.btnCheckRowErorr_Click);
			// 
			// btnCloneDataSet
			// 
			this.btnCloneDataSet.Location = new System.Drawing.Point(128, 72);
			this.btnCloneDataSet.Name = "btnCloneDataSet";
			this.btnCloneDataSet.Size = new System.Drawing.Size(96, 40);
			this.btnCloneDataSet.TabIndex = 8;
			this.btnCloneDataSet.Text = "複製資料集";
			this.btnCloneDataSet.Click += new System.EventHandler(this.btnCloneDataSet_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(456, 16);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(104, 40);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDeleteRow
			// 
			this.btnDeleteRow.Location = new System.Drawing.Point(232, 16);
			this.btnDeleteRow.Name = "btnDeleteRow";
			this.btnDeleteRow.Size = new System.Drawing.Size(96, 40);
			this.btnDeleteRow.TabIndex = 10;
			this.btnDeleteRow.Text = "Delete Row";
			this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 439);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																												  this.statusBarPanel1,
																												  this.statusBarPanel2,
																												  this.statusBarPanel3});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(696, 22);
			this.statusBar1.TabIndex = 11;
			this.statusBar1.Text = "statusBar1";
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statusBarPanel1.Text = "statusBarPanel1";
			// 
			// statusBarPanel2
			// 
			this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel2.Text = "statusBarPanel2";
			this.statusBarPanel2.Width = 290;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel3.Text = "statusBarPanel3";
			this.statusBarPanel3.Width = 290;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(696, 461);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.btnDeleteRow);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCloneDataSet);
			this.Controls.Add(this.btnCheckRowErorr);
			this.Controls.Add(this.btnAcceptChanges);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnClearLog);
			this.Controls.Add(this.lbxLog);
			this.Controls.Add(this.btnAddRow);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.btnLoadData);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "ADO.NET 範例: Working with DataSet";
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

		SqlConnection cn;
		SqlDataAdapter da;
		DataSet ds;
		DataTable tbl;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			cn = new SqlConnection("server=.;database=Northwind;uid=sa");
			da = new SqlDataAdapter("select * from Customers", cn);
			ds = new DataSet();

			// 自行建立一個 DataTable 物件，以便訂閱其事件。
			tbl = new DataTable("Customers");
			ds.Tables.Add(tbl);

			// 訂閱事件
			tbl.RowChanged += new DataRowChangeEventHandler(tbl_RowChanged);
		}

		// 資料表的 Row 有變動時觸發的事件
		private void tbl_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			lbxLog.Items.Add(e.Action.ToString());

			// 必須避開已標記為刪除的記錄，否則存取欄位值時會出現例外:
			// RowNotInTableException。
			if (e.Row.RowState != DataRowState.Detached) 
			{
				if ((string) e.Row["CompanyName"] == "AAA") 
				{
					e.Row.RowError = "測試";
				}
			}
		}

		private void btnLoadData_Click(object sender, System.EventArgs e)
		{
			/*
			 * 先把 DataTable 的資料列全部清除，以免
			 * 每次按此鈕時，一直附加重複的資料。
			 */
			tbl.Rows.Clear();

			/* 
			 * 將選擇的資料填入 DataSet。注意：由於之前已經事先建立了
			 * 一個名為 "Customers" 的 DataTable 物件，因此在 Fill 時，
			 * 會直接用 "Customers" DataTable 物件，而不會建立新的。
			 */			
			da.Fill(ds, "Customers");
			
			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = "Customers";

			ShowRecordCount();
		}

		public void ShowRecordCount() 
		{
			statusBar1.Panels[0].Text = "共 " + tbl.Rows.Count + " 筆";
		}

		private void btnClearLog_Click(object sender, System.EventArgs e)
		{
			lbxLog.Items.Clear();
		}

		// 新增一筆記錄
		private void btnAddRow_Click(object sender, System.EventArgs e)
		{
			/*
			 * 根據 DataTable 中的欄位定義建立一個 DataRow 物件。
			 * 注意不可用 new DataRow()，因為 DataRow 沒有預設建構子。
			 */
			DataRow aRow = tbl.NewRow();

			// 設定這筆記錄的各欄位值
			aRow["CustomerID"] = Guid.NewGuid().ToString().Substring(0, 5);
			aRow["CompanyName"] = Guid.NewGuid().ToString().Substring(0, 6);
			
			// 記得最後要把 DataRow 物件加入 DataTable 的 Rows 集合

			// 可以用 DataTable.Rows.Add 方法：
			//tbl.Rows.Add(aRow);

			// 也可以用 InsertAt，指定要新增到那個位置（但不會反映在 DataGrid 上）。
			tbl.Rows.InsertAt(aRow, 0);

			MessageBox.Show("已經新增到第 0 筆。\n" +
				"如果希望新增的記錄的所在位置立刻反應在 DataGrid 上面，請執行 AcceptChanges 或 Save。",
				"資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);		

			ShowRecordCount();
		}

		// 刪除一筆記錄
		private void btnDeleteRow_Click(object sender, System.EventArgs e)
		{
			int rowIdx = dataGrid1.CurrentRowIndex;
			tbl.Rows[rowIdx].Delete();			

			MessageBox.Show("已將記錄加上刪除標記，必須執行 Save 才會真的異動到資料庫!");

			ShowRecordCount();
		}
		private void btnAcceptChanges_Click(object sender, System.EventArgs e)
		{
			ds.AcceptChanges();

			/*
			 * AcceptChanges 會把所有記錄的 Current 值 assign 給 Original 值，
			 * 亦即記錄的目前版本和原始版本是一樣的，通常這代表了資料已經成功
			 * 更新到資料庫了。
			 * AcceptChanges 還會清除每一筆 DataRow 的 RowError 屬性，並且將
			 * 每一筆記錄的 HasErrors 設定為 false。
			 */
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (!ds.HasChanges()) 
			{
				MessageBox.Show("沒有尚未儲存的資料!");
				return;
			}

			SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
			try 
			{
				da.Update(ds, "Customers");
				ds.AcceptChanges();
				MessageBox.Show("儲存成功", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (SqlException sqlex) 
			{
				MessageBox.Show("儲存失敗!\n" + sqlex.Message + "\n錯誤碼: " + sqlex.Number,
					"錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void btnCheckRowErorr_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnCloneDataSet_Click(object sender, System.EventArgs e)
		{	
			DataSet aDataSet = ds.Clone();
			aDataSet.Merge(ds);

			Form2 aForm = new Form2();
			aForm.DataBind(aDataSet, aDataSet.Tables[0].TableName);
			aForm.ShowDialog();
		}




	}
}
