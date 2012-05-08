using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DataBindingDemo
{
	/// <summary>
	/// Summary description for AdoNetBindingForm.
	/// </summary>
	public class AdoNetBindingForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnFirst;
		private System.Windows.Forms.Button btnPrior;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnLast;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private DataBindingDemo.EmpDataSet empDataSet1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEmpID;
		private System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.Button btnMasterDetail;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AdoNetBindingForm()
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
			this.btnFirst = new System.Windows.Forms.Button();
			this.btnPrior = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnLast = new System.Windows.Forms.Button();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.empDataSet1 = new DataBindingDemo.EmpDataSet();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEmpID = new System.Windows.Forms.TextBox();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.btnMasterDetail = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.empDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnFirst
			// 
			this.btnFirst.Location = new System.Drawing.Point(56, 272);
			this.btnFirst.Name = "btnFirst";
			this.btnFirst.Size = new System.Drawing.Size(80, 40);
			this.btnFirst.TabIndex = 8;
			this.btnFirst.Text = "<<";
			this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
			// 
			// btnPrior
			// 
			this.btnPrior.Location = new System.Drawing.Point(144, 272);
			this.btnPrior.Name = "btnPrior";
			this.btnPrior.Size = new System.Drawing.Size(80, 40);
			this.btnPrior.TabIndex = 9;
			this.btnPrior.Text = "<";
			this.btnPrior.Click += new System.EventHandler(this.btnPrior_Click);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(232, 272);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(80, 40);
			this.btnNext.TabIndex = 10;
			this.btnNext.Text = ">";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnLast
			// 
			this.btnLast.Location = new System.Drawing.Point(320, 272);
			this.btnLast.Name = "btnLast";
			this.btnLast.Size = new System.Drawing.Size(80, 40);
			this.btnLast.TabIndex = 11;
			this.btnLast.Text = ">>";
			this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "select dbo.[Employees].[EmployeeID], dbo.[Employees].[LastName], dbo.[Employees]." +
				"[FirstName], dbo.[Employees].[Title] from dbo.[Employees]";
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
			// empDataSet1
			// 
			this.empDataSet1.DataSetName = "EmpDataSet";
			this.empDataSet1.Locale = new System.Globalization.CultureInfo("zh-TW");
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 16);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(456, 160);
			this.dataGrid1.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 192);
			this.label1.Name = "label1";
			this.label1.TabIndex = 13;
			this.label1.Text = "員工編號";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(312, 192);
			this.label2.Name = "label2";
			this.label2.TabIndex = 14;
			this.label2.Text = "First Name";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(128, 192);
			this.label3.Name = "label3";
			this.label3.TabIndex = 15;
			this.label3.Text = "Last Name";
			// 
			// txtEmpID
			// 
			this.txtEmpID.Location = new System.Drawing.Point(16, 216);
			this.txtEmpID.Name = "txtEmpID";
			this.txtEmpID.TabIndex = 16;
			this.txtEmpID.Text = "";
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(304, 216);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(160, 25);
			this.txtFirstName.TabIndex = 17;
			this.txtFirstName.Text = "";
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(128, 216);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(152, 25);
			this.txtLastName.TabIndex = 18;
			this.txtLastName.Text = "";
			// 
			// btnMasterDetail
			// 
			this.btnMasterDetail.Location = new System.Drawing.Point(120, 336);
			this.btnMasterDetail.Name = "btnMasterDetail";
			this.btnMasterDetail.Size = new System.Drawing.Size(208, 40);
			this.btnMasterDetail.TabIndex = 19;
			this.btnMasterDetail.Text = "Master-Detail 繫結";
			this.btnMasterDetail.Click += new System.EventHandler(this.btnMasterDetail_Click);
			// 
			// AdoNetBindingForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(504, 389);
			this.Controls.Add(this.btnMasterDetail);
			this.Controls.Add(this.txtLastName);
			this.Controls.Add(this.txtFirstName);
			this.Controls.Add(this.txtEmpID);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.btnLast);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnPrior);
			this.Controls.Add(this.btnFirst);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "AdoNetBindingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AdoNetBindingForm";
			this.Load += new System.EventHandler(this.AdoNetBindingForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.empDataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		BindingManagerBase bmb;

		private void AdoNetBindingForm_Load(object sender, System.EventArgs e)
		{
			sqlDataAdapter1.Fill(empDataSet1, "Employees");

			// 繫結至 DataGrid
			dataGrid1.DataSource = empDataSet1;
			dataGrid1.DataMember = "Employees";

			// 繫結各個欄位至 TextBox
			txtEmpID.DataBindings.Add("Text", empDataSet1, "Employees.EmployeeID");
			txtFirstName.DataBindings.Add("Text", empDataSet1, "Employees.FirstName");
			txtLastName.DataBindings.Add("Text", empDataSet1, "Employees.LastName");

			// 取得 BindingManagerBase 物件
			bmb = this.BindingContext[empDataSet1, "Employees"];
		}

		private void btnFirst_Click(object sender, System.EventArgs e)
		{
			bmb.Position = 0;
		}

		private void btnLast_Click(object sender, System.EventArgs e)
		{
			bmb.Position = bmb.Count - 1;
		}

		private void btnPrior_Click(object sender, System.EventArgs e)
		{
			if (bmb.Position > 0) 
			{
				bmb.Position--;
			}
		}

		private void btnNext_Click(object sender, System.EventArgs e)
		{
			if (bmb.Position < bmb.Count-1) 
			{
				bmb.Position++;
			}
		}

		private void btnMasterDetail_Click(object sender, System.EventArgs e)
		{
			MasterDetailBindingForm aForm = new MasterDetailBindingForm();
			aForm.ShowDialog();
		}
	}
}
