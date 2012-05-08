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
			this.btnLoadData.Text = "���J���";
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
			this.btnClearLog.Text = "�M��";
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
			this.btnCheckRowErorr.Text = "�ˬd RowError";
			this.btnCheckRowErorr.Click += new System.EventHandler(this.btnCheckRowErorr_Click);
			// 
			// btnCloneDataSet
			// 
			this.btnCloneDataSet.Location = new System.Drawing.Point(128, 72);
			this.btnCloneDataSet.Name = "btnCloneDataSet";
			this.btnCloneDataSet.Size = new System.Drawing.Size(96, 40);
			this.btnCloneDataSet.TabIndex = 8;
			this.btnCloneDataSet.Text = "�ƻs��ƶ�";
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
			this.Text = "ADO.NET �d��: Working with DataSet";
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

			// �ۦ�إߤ@�� DataTable ����A�H�K�q�\��ƥ�C
			tbl = new DataTable("Customers");
			ds.Tables.Add(tbl);

			// �q�\�ƥ�
			tbl.RowChanged += new DataRowChangeEventHandler(tbl_RowChanged);
		}

		// ��ƪ� Row ���ܰʮ�Ĳ�o���ƥ�
		private void tbl_RowChanged(object sender, DataRowChangeEventArgs e)
		{
			lbxLog.Items.Add(e.Action.ToString());

			// �����׶}�w�аO���R�����O���A�_�h�s�����Ȯɷ|�X�{�ҥ~:
			// RowNotInTableException�C
			if (e.Row.RowState != DataRowState.Detached) 
			{
				if ((string) e.Row["CompanyName"] == "AAA") 
				{
					e.Row.RowError = "����";
				}
			}
		}

		private void btnLoadData_Click(object sender, System.EventArgs e)
		{
			/*
			 * ���� DataTable ����ƦC�����M���A�H�K
			 * �C�������s�ɡA�@�����[���ƪ���ơC
			 */
			tbl.Rows.Clear();

			/* 
			 * �N��ܪ���ƶ�J DataSet�C�`�N�G�ѩ󤧫e�w�g�ƥ��إߤF
			 * �@�ӦW�� "Customers" �� DataTable ����A�]���b Fill �ɡA
			 * �|������ "Customers" DataTable ����A�Ӥ��|�إ߷s���C
			 */			
			da.Fill(ds, "Customers");
			
			dataGrid1.DataSource = ds;
			dataGrid1.DataMember = "Customers";

			ShowRecordCount();
		}

		public void ShowRecordCount() 
		{
			statusBar1.Panels[0].Text = "�@ " + tbl.Rows.Count + " ��";
		}

		private void btnClearLog_Click(object sender, System.EventArgs e)
		{
			lbxLog.Items.Clear();
		}

		// �s�W�@���O��
		private void btnAddRow_Click(object sender, System.EventArgs e)
		{
			/*
			 * �ھ� DataTable �������w�q�إߤ@�� DataRow ����C
			 * �`�N���i�� new DataRow()�A�]�� DataRow �S���w�]�غc�l�C
			 */
			DataRow aRow = tbl.NewRow();

			// �]�w�o���O�����U����
			aRow["CustomerID"] = Guid.NewGuid().ToString().Substring(0, 5);
			aRow["CompanyName"] = Guid.NewGuid().ToString().Substring(0, 6);
			
			// �O�o�̫�n�� DataRow ����[�J DataTable �� Rows ���X

			// �i�H�� DataTable.Rows.Add ��k�G
			//tbl.Rows.Add(aRow);

			// �]�i�H�� InsertAt�A���w�n�s�W�쨺�Ӧ�m�]�����|�ϬM�b DataGrid �W�^�C
			tbl.Rows.InsertAt(aRow, 0);

			MessageBox.Show("�w�g�s�W��� 0 ���C\n" +
				"�p�G�Ʊ�s�W���O�����Ҧb��m�ߨ�����b DataGrid �W���A�а��� AcceptChanges �� Save�C",
				"��T", MessageBoxButtons.OK, MessageBoxIcon.Information);		

			ShowRecordCount();
		}

		// �R���@���O��
		private void btnDeleteRow_Click(object sender, System.EventArgs e)
		{
			int rowIdx = dataGrid1.CurrentRowIndex;
			tbl.Rows[rowIdx].Delete();			

			MessageBox.Show("�w�N�O���[�W�R���аO�A�������� Save �~�|�u�����ʨ��Ʈw!");

			ShowRecordCount();
		}
		private void btnAcceptChanges_Click(object sender, System.EventArgs e)
		{
			ds.AcceptChanges();

			/*
			 * AcceptChanges �|��Ҧ��O���� Current �� assign �� Original �ȡA
			 * ��Y�O�����ثe�����M��l�����O�@�˪��A�q�`�o�N��F��Ƥw�g���\
			 * ��s���Ʈw�F�C
			 * AcceptChanges �ٷ|�M���C�@�� DataRow �� RowError �ݩʡA�åB�N
			 * �C�@���O���� HasErrors �]�w�� false�C
			 */
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (!ds.HasChanges()) 
			{
				MessageBox.Show("�S���|���x�s�����!");
				return;
			}

			SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
			try 
			{
				da.Update(ds, "Customers");
				ds.AcceptChanges();
				MessageBox.Show("�x�s���\", "��T", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (SqlException sqlex) 
			{
				MessageBox.Show("�x�s����!\n" + sqlex.Message + "\n���~�X: " + sqlex.Number,
					"���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
