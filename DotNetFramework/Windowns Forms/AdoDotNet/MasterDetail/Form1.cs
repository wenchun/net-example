using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace MasterDetail
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.DataGrid grdOrders;
		private System.Windows.Forms.DataGrid grdOrderDetails;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkTransaction;
		private System.Windows.Forms.Button btnRefresh;

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
			this.grdOrders = new System.Windows.Forms.DataGrid();
			this.grdOrderDetails = new System.Windows.Forms.DataGrid();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chkTransaction = new System.Windows.Forms.CheckBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdOrderDetails)).BeginInit();
			this.SuspendLayout();
			// 
			// grdOrders
			// 
			this.grdOrders.AllowNavigation = false;
			this.grdOrders.DataMember = "";
			this.grdOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdOrders.Location = new System.Drawing.Point(24, 80);
			this.grdOrders.Name = "grdOrders";
			this.grdOrders.Size = new System.Drawing.Size(648, 176);
			this.grdOrders.TabIndex = 0;
			// 
			// grdOrderDetails
			// 
			this.grdOrderDetails.DataMember = "";
			this.grdOrderDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdOrderDetails.Location = new System.Drawing.Point(24, 296);
			this.grdOrderDetails.Name = "grdOrderDetails";
			this.grdOrderDetails.Size = new System.Drawing.Size(648, 232);
			this.grdOrderDetails.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(424, 40);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 32);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "����";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(360, 40);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(56, 32);
			this.btnUpdate.TabIndex = 6;
			this.btnUpdate.Text = "�x�s";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Crimson;
			this.label1.Location = new System.Drawing.Point(24, 272);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "�q����ӡG";
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.Crimson;
			this.label2.Location = new System.Drawing.Point(24, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(392, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "p.s.: �x�s�ɷ|�s�P master �P detail ��Ƥ@�ֲ��ʦܸ�Ʈw�C";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.label3.ForeColor = System.Drawing.Color.Crimson;
			this.label3.Location = new System.Drawing.Point(512, 536);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 23);
			this.label3.TabIndex = 10;
			this.label3.Text = "http://huanlin.dyndns.org/cs";
			// 
			// chkTransaction
			// 
			this.chkTransaction.Checked = true;
			this.chkTransaction.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTransaction.Location = new System.Drawing.Point(24, 48);
			this.chkTransaction.Name = "chkTransaction";
			this.chkTransaction.Size = new System.Drawing.Size(320, 24);
			this.chkTransaction.TabIndex = 11;
			this.chkTransaction.Text = "�N master �P detail ����ƥ]�b�A�P�@�ӥ��";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(488, 40);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(80, 32);
			this.btnRefresh.TabIndex = 12;
			this.btnRefresh.Text = "���s��z";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(688, 565);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.chkTransaction);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.grdOrderDetails);
			this.Controls.Add(this.grdOrders);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "Master-Detail �d��";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdOrderDetails)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		SqlConnection conn;
		SqlDataAdapter ordersDA;
		SqlDataAdapter orderDetailsDA;
		DataSet ordersDS;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			conn = new SqlConnection("Server=.;Database=Northwind;uid=sa");

			// �]�w master ��ƪ� DataAdapter
			string sql = "select OrderID, CustomerID, EmployeeID, OrderDate, ShipName from Orders";
			ordersDA = new SqlDataAdapter(sql, conn);

			// �]�w detail��ƪ� DataAdapter
			sql = "select * from [Order Details]";
			orderDetailsDA = new SqlDataAdapter(sql, conn);

			// �إ� DataSet ����
			ordersDS = new DataSet();

			// �N��Ƹ��J DataSet ����
			LoadData();

			// bind to grid
			grdOrders.DataSource = ordersDS;
			grdOrders.DataMember = "Orders";
	
			// �ƥ�q�\
			grdOrders.CurrentCellChanged += new EventHandler(grdOrders_CurrentCellChanged);

			// ���Ĳ�o�ƥ�A�� detail ��ƥi�H��ܥX�ӡC
			grdOrders_CurrentCellChanged(grdOrders, EventArgs.Empty);
		}

		// ���J��Ʀ� DataSet�A����k�i���ƩI�s�A�H�K���s���J��ơC
		public void LoadData()
		{
			ordersDS.Clear();	// ���i�H�� Tables.Clear()�A�_�h DataGrid ���| refresh!
			ordersDS.Relations.Clear();

			ordersDA.Fill(ordersDS, "Orders");
			orderDetailsDA.Fill(ordersDS, "OrderDetails");

			DataColumn parentCol = ordersDS.Tables["Orders"].Columns["OrderID"];
			DataColumn childCol = ordersDS.Tables["OrderDetails"].Columns["OrderID"];
			DataRelation rel = new DataRelation("relOrderDetails", parentCol, childCol);
			ordersDS.Relations.Add(rel);

			SqlCommandBuilder ordersCB = new SqlCommandBuilder(ordersDA);
			ordersDA.InsertCommand = ordersCB.GetInsertCommand();
			ordersDA.UpdateCommand = ordersCB.GetUpdateCommand();
			ordersDA.DeleteCommand = ordersCB.GetDeleteCommand();

			SqlCommandBuilder orderDetailsCB = new SqlCommandBuilder(orderDetailsDA);
			// �ѩ� table name �]�t�ťզr���A�]�������ƥ��]�w QuotePrefix �M QuoteSuffix�C
			orderDetailsCB.QuotePrefix = "[";
			orderDetailsCB.QuoteSuffix = "]";
			orderDetailsDA.InsertCommand = orderDetailsCB.GetInsertCommand();
			orderDetailsDA.UpdateCommand = orderDetailsCB.GetUpdateCommand();
			orderDetailsDA.DeleteCommand = orderDetailsCB.GetDeleteCommand();
		}

		/*
		 * �C�� master grid ���ʰO���ɡA���s�z�� detail �O���C
		 */
		private void grdOrders_CurrentCellChanged(object sender, EventArgs e)
		{
			int idx = grdOrders.CurrentRowIndex;

			if (idx >= ordersDS.Tables["Orders"].Rows.Count)
				return;

			DataView parentView = new DataView(ordersDS.Tables["Orders"]);
			DataRowView parentRowView = parentView[idx];
			DataView childView = parentRowView.CreateChildView("relOrderDetails");
			grdOrderDetails.DataSource = childView;
		}

		/*
		 * �x�s�C
		 */
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			DataTable tblOrders = ordersDS.Tables["Orders"];
			DataTable tblOrderDetails = ordersDS.Tables["OrderDetails"];

			// �`�N: master-detail �����ʶ��ǥ����̷ӤU�C�B�J!


			// 0. �إߥ��
			SqlTransaction trx = null;
			if (chkTransaction.Checked) 
			{
				conn.Open();
				trx = conn.BeginTransaction();

				ordersDA.InsertCommand.Transaction = trx;
				ordersDA.UpdateCommand.Transaction = trx;
				ordersDA.DeleteCommand.Transaction = trx;
				orderDetailsDA.InsertCommand.Transaction = trx;
				orderDetailsDA.UpdateCommand.Transaction = trx;
				orderDetailsDA.DeleteCommand.Transaction = trx;
			}

			// 1. ���o master table ���U�ز��ʸ��
			DataTable tblAdded = tblOrders.GetChanges(DataRowState.Added);
			DataTable tblModified = tblOrders.GetChanges(DataRowState.Modified);
			DataTable tblDeleted = tblOrders.GetChanges(DataRowState.Deleted);
			
			// 2. ���ʷs�W�P�ק諸 master �O��
			try 
			{
				if (tblAdded != null) 
				{
					ordersDA.Update(tblAdded);
				}
				if (tblModified != null) 
				{
					ordersDA.Update(tblModified);
				}

				// 3. ���� detal �O��
				orderDetailsDA.Update(tblOrderDetails);

				// 4. ���ʧR���� master �O���]���B�J�n���̫�^
				if (tblDeleted != null) 
				{
					ordersDA.Update(tblDeleted);
				}

				if (trx != null) 
				{
					trx.Commit();
				}
				conn.Close();

				MessageBox.Show("�x�s���\!");
			}
			catch (SqlException sqlEx) 
			{
				if (trx != null) 
				{
					trx.Rollback();
				}
				conn.Close();
				MessageBox.Show("���ʥ���!\n" + sqlEx.Message);
			}
		}

		/*
		 * �����Ҧ����ק�]��_���Ĥ@�����J�ΤW�@���x�s�ɪ���ơ^�C
		 */
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			ordersDS.Tables["OrderDetails"].RejectChanges();
			ordersDS.Tables["Orders"].RejectChanges();			

			ClearErrors();
		}

		// �M���Ҧ����~
		private void ClearErrors()
		{
			DataTable tblOrders = ordersDS.Tables["Orders"];
			DataTable tblOrderDetails = ordersDS.Tables["OrderDetails"];
			if (tblOrders.HasErrors) 
			{
				DataRow[] rows = tblOrders.GetErrors();
				foreach (DataRow row in rows) 
				{
					row.ClearErrors();
				}
			}
			if (tblOrderDetails.HasErrors) 
			{
				DataRow[] rows = tblOrderDetails.GetErrors();
				foreach (DataRow row in rows) 
				{
					row.ClearErrors();
				}
			}
		}

		/*
		 * ���s��z�C
		 */
		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			LoadData();
		}
	}
}
