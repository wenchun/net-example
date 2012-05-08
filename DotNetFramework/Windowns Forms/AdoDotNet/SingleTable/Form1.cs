using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SingleTable
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnRefresh;
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
			this.btnInsert = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnInsert
			// 
			this.btnInsert.Location = new System.Drawing.Point(24, 16);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(56, 32);
			this.btnInsert.TabIndex = 0;
			this.btnInsert.Text = "�s�W";
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(24, 64);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(528, 208);
			this.dataGrid1.TabIndex = 1;
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(88, 16);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(56, 32);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "�ק�";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(152, 16);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(56, 32);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "�R��";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(216, 16);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(56, 32);
			this.btnUpdate.TabIndex = 4;
			this.btnUpdate.Text = "�x�s";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(280, 16);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(56, 32);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "����";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(352, 16);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(88, 32);
			this.btnRefresh.TabIndex = 6;
			this.btnRefresh.Text = "���s��z";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(576, 309);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.btnInsert);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "���ɸ�ƺ��@�d�� by Huan-Lin Tsai";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


		SqlConnection conn;
		SqlDataAdapter customerDA;
		DataSet customerDS;
		

		private void Form1_Load(object sender, System.EventArgs e)
		{
			conn = new SqlConnection("Server=.;Database=Northwind;uid=sa");

			string sql = "select CustomerID, CompanyName, ContactName from Customers";
			customerDA = new SqlDataAdapter(sql, conn);
			customerDS = new DataSet();

			// �d�߫Ȥ��ơA�öǦ^ DataSet
			LoadCustomers();

			// ���Ͳ��� SQL �R�O
			SqlCommandBuilder cb = new SqlCommandBuilder(customerDA);
			customerDA.InsertCommand = cb.GetInsertCommand();
			customerDA.UpdateCommand = cb.GetUpdateCommand();
			customerDA.DeleteCommand = cb.GetDeleteCommand();


			// ���ô��
			dataGrid1.DataSource = customerDS;
			dataGrid1.DataMember = "Customers";
		}

		private void LoadCustomers()
		{
			customerDS.Clear();	// ���i�H�� Tables.Clear()�A�_�h DataGrid ���| refresh!
			customerDA.Fill(customerDS, "Customers");
		}

		/*
		 * �s�W�@��O���C
		 */
		private void btnInsert_Click(object sender, System.EventArgs e)
		{
			EditForm aForm = new EditForm();
			if (aForm.ShowDialog() == DialogResult.OK) 
			{
				DataTable tbl = customerDS.Tables["Customers"];
				DataRow row = tbl.NewRow();

				row["CustomerID"] = aForm.GetValue("CustomerID");
				row["CompanyName"] = aForm.GetValue("CompanyName");
				row["ContactName"] = aForm.GetValue("ContactName");

				tbl.Rows.Add(row);
			}
		}

		/*
		 * �ק�C
		 */
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			EditForm aForm = new EditForm();
			
			int idx = dataGrid1.CurrentRowIndex;
			DataTable tbl = customerDS.Tables["Customers"];
			DataRow row = tbl.Rows[idx];
			aForm.SetValue("CustomerID", row["CustomerID"].ToString());
			aForm.SetValue("CompanyName", row["CompanyName"].ToString());
			aForm.SetValue("ContactName", row["ContactName"].ToString());

			if (aForm.ShowDialog() == DialogResult.OK) 
			{			
				row.BeginEdit();
				row["CustomerID"] = aForm.GetValue("CustomerID");
				row["CompanyName"] = aForm.GetValue("CompanyName");
				row["ContactName"] = aForm.GetValue("ContactName");
				row.EndEdit();
			}					
		}

		/*
		 * �R���C
		 */
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("�T�w�n�R���o���O��?", "�߰�", 
				MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) 
			{
				int idx = dataGrid1.CurrentRowIndex;
				customerDS.Tables["Customers"].DefaultView.Delete(idx);
				btnUpdate_Click(btnUpdate, EventArgs.Empty);
			}
		}

		/*
		 * �x�s�C
		 */
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			customerDA.Update(customerDS, "Customers");
			customerDS.AcceptChanges();
		}

		/*
		 * �����Ҧ����ܡC
		 */
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			customerDS.Tables["Customers"].RejectChanges();
		}

		/*
		 * ���s��z�C
		 */
		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			LoadCustomers();
		}
	}
}
