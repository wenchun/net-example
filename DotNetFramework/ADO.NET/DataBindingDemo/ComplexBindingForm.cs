using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DataBindingDemo
{
	/// <summary>
	/// Summary description for ComplexBindingForm.
	/// </summary>
	public class ComplexBindingForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBindToComboBox;
		private System.Windows.Forms.Button btnBindToDepartments;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnShowEmpDeptID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ComplexBindingForm()
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.btnBindToDepartments = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBindToComboBox = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnShowEmpDeptID = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(64, 24);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 23);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.Text = "comboBox1";
			// 
			// btnBindToDepartments
			// 
			this.btnBindToDepartments.Location = new System.Drawing.Point(200, 24);
			this.btnBindToDepartments.Name = "btnBindToDepartments";
			this.btnBindToDepartments.Size = new System.Drawing.Size(168, 32);
			this.btnBindToDepartments.TabIndex = 1;
			this.btnBindToDepartments.Text = "么挡场戈";
			this.btnBindToDepartments.Click += new System.EventHandler(this.btnBindToDepartments_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(64, 128);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 25);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "textBox1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "场";
			// 
			// btnBindToComboBox
			// 
			this.btnBindToComboBox.Location = new System.Drawing.Point(192, 128);
			this.btnBindToComboBox.Name = "btnBindToComboBox";
			this.btnBindToComboBox.Size = new System.Drawing.Size(208, 32);
			this.btnBindToComboBox.TabIndex = 4;
			this.btnBindToComboBox.Text = "么挡 comboBox1  Value";
			this.btnBindToComboBox.Click += new System.EventHandler(this.btnBindToComboBox_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "絪腹";
			// 
			// btnShowEmpDeptID
			// 
			this.btnShowEmpDeptID.Location = new System.Drawing.Point(16, 72);
			this.btnShowEmpDeptID.Name = "btnShowEmpDeptID";
			this.btnShowEmpDeptID.Size = new System.Drawing.Size(200, 32);
			this.btnShowEmpDeptID.TabIndex = 6;
			this.btnShowEmpDeptID.Text = "陪ボ场絪腹";
			this.btnShowEmpDeptID.Click += new System.EventHandler(this.btnShowEmpDeptID_Click);
			// 
			// ComplexBindingForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(408, 205);
			this.Controls.Add(this.btnShowEmpDeptID);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnBindToComboBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnBindToDepartments);
			this.Controls.Add(this.comboBox1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "ComplexBindingForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ComplexBindingForm";
			this.Load += new System.EventHandler(this.ComplexBindingForm_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private Dept[] departments;
		private Emp[] employees;

		private void ComplexBindingForm_Load(object sender, System.EventArgs e)
		{
			departments = new Dept[3] { 
				new Dept("A01", "穨叭场"), 
				new Dept("A02", "祇场"), 
				new Dept("A03", "ㄆ场") 
			};

			employees = new Emp[3] {
				new Emp("Michael"),
				new Emp("Huanlin"),
				new Emp("Will")
			};
		}

		private void btnBindToDepartments_Click(object sender, System.EventArgs e)
		{
			comboBox1.DataSource = departments;
			comboBox1.DisplayMember = "DeptName";
			comboBox1.ValueMember = "DeptID";

			// 么挡戈 DeptID 妮┦.
			comboBox1.DataBindings.Add("SelectedValue", employees, "DeptID");
		}

		private void btnBindToComboBox_Click(object sender, System.EventArgs e)
		{
			textBox1.DataBindings.Add("Text", comboBox1, "SelectedValue");
		}

		private void btnShowEmpDeptID_Click(object sender, System.EventArgs e)
		{
			BindingManagerBase bmb = this.BindingContext[employees];
			Emp emp = (Emp) bmb.Current;
			MessageBox.Show(emp.DeptID);
		}
	}

	class Emp 
	{
		private string name;
		private string deptID;

		public Emp(string aName) 
		{
			name = aName;
		}

		public string Name 
		{
			get { return name; }
			set { name = value; }
		}
		public string DeptID
		{
			get { return deptID; }
			set { deptID = value; }
		}
	}

	class Dept 
	{
		private string deptID;
		private string deptName;

		public Dept(string id, string name) 
		{
			deptID = id;
			deptName = name;
		}


		public string DeptID 
		{
			get { return deptID; }
			set { deptID = value; }
		}

		public string DeptName 
		{
			get { return deptName; }
			set { deptName = value; }
		}
	}
}
