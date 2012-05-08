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
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnModify;
		private System.Windows.Forms.Button btnUpdate;

		private DataSet dataset;
		private const string SelectSql = "select * from Customers";

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			dataset = new DataSet();
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
			this.btnInsert = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnGetData
			// 
			this.btnGetData.Enabled = false;
			this.btnGetData.Location = new System.Drawing.Point(16, 72);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(120, 32);
			this.btnGetData.TabIndex = 0;
			this.btnGetData.Text = "�d�߸��";
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(24, 128);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(344, 199);
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
			this.btnLoadConnStr.Text = "���J�s�u�r��";
			this.btnLoadConnStr.Click += new System.EventHandler(this.btnLoadConnStr_Click);
			// 
			// btnInsert
			// 
			this.btnInsert.Enabled = false;
			this.btnInsert.Location = new System.Drawing.Point(24, 344);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(72, 32);
			this.btnInsert.TabIndex = 4;
			this.btnInsert.Text = "�s�W";
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Enabled = false;
			this.btnDelete.Location = new System.Drawing.Point(104, 344);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(72, 32);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "�R��";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(8, 392);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(392, 24);
			this.label1.TabIndex = 6;
			this.label1.Text = "���G�H�W���W�R�ﳣ�O���u�@�~�A���|�u���s�J��Ʈw�C";
			// 
			// btnModify
			// 
			this.btnModify.Enabled = false;
			this.btnModify.Location = new System.Drawing.Point(184, 344);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(72, 32);
			this.btnModify.TabIndex = 7;
			this.btnModify.Text = "�ק�";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Enabled = false;
			this.btnUpdate.Location = new System.Drawing.Point(24, 440);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(232, 32);
			this.btnUpdate.TabIndex = 8;
			this.btnUpdate.Text = "�u�����ʨ��Ʈw";
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(424, 506);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnModify);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnInsert);
			this.Controls.Add(this.btnLoadConnStr);
			this.Controls.Add(this.txtConnStr);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.btnGetData);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "ADO.NET Demo 2";
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
			btnInsert.Enabled = true;
			btnDelete.Enabled = true;
			btnModify.Enabled = true;
			btnUpdate.Enabled = true;
		}

		void PopulateListBox() 
		{
			listBox1.Items.Clear();
			foreach (DataRow row in dataset.Tables[0].Rows) 
			{
				string item = row["ContactTitle"] + ", " + row["ContactName"];
				listBox1.Items.Add(item);
			}
		}

		private void btnGetData_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection(txtConnStr.Text);				
			
			SqlDataAdapter adapter = new SqlDataAdapter(SelectSql, conn);
			adapter.Fill(dataset);

			PopulateListBox();
			listBox1.SelectedIndex = 0;
		}

		private void btnInsert_Click(object sender, System.EventArgs e)
		{
			DataRow row = dataset.Tables[0].NewRow();

			// ������ƶ�J�s�إߪ� row�C
			row["CUstomerID"] = "���o��";
			row["CompanyName"] = "�@���o�ѥ��������q";
			row["ContactName"] = "���w��";
			row["ContactTItle"] = "�޳N�`��";

			dataset.Tables[0].Rows.Add(row);

			PopulateListBox();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			int index = listBox1.SelectedIndex;
			if (index < 0)
				return;
			
			// Get row from data set.
			DataRow row = dataset.Tables[0].Rows[index];

			// Delete one row.
			//dataset.Tables[0].Rows.Remove(row);  

			// �u�O�N���C�аO��"�w�R��"�A���S���u���q�O���餤�����C
			// �Y�ĥΦ��k�A�h PopulateListBox �n�ק�A��аO���w�R���� row ���L�A�_�h�|�X�{���~�C
			// row.Delete();

			PopulateListBox();
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			int index = listBox1.SelectedIndex;
			if (index < 0)
				return;
			
			// Get row from data set.
			DataRow row = dataset.Tables[0].Rows[index];

			row["ContactTitle"] = "�M��u";

			PopulateListBox();		
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("�T�w�n���ʨ��Ʈw�H", "�߰�", MessageBoxButtons.OKCancel) != DialogResult.OK)
				return;

			SqlConnection conn = new SqlConnection(txtConnStr.Text);
			SqlDataAdapter adapter = new SqlDataAdapter(SelectSql, conn);

			// �� command builder ���ڭ̫إ߷s�W�B�R���B�ק諸�R�O�C
			new SqlCommandBuilder(adapter);

			// Commit changes back to the data provider.
			try 
			{
				adapter.Update(dataset);				

				MessageBox.Show("���ʦ��\!");
			}
			catch (SqlException ex) 
			{
				MessageBox.Show(ex.Message, "���ʥ���!");
			}
		}
	}
}
