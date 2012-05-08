using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DataBindingDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnBindToArray;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnBindToControl;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnBindToObjArray;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.TextBox txtEmpBirthday;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnFormatParse;
		private System.Windows.Forms.Button btnComplexBiding;
		private System.Windows.Forms.Button btnAdoNetBinding;
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
			this.btnBindToArray = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnBindToControl = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtEmpName = new System.Windows.Forms.TextBox();
			this.btnBindToObjArray = new System.Windows.Forms.Button();
			this.txtEmpBirthday = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnFormatParse = new System.Windows.Forms.Button();
			this.btnComplexBiding = new System.Windows.Forms.Button();
			this.btnAdoNetBinding = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnBindToArray
			// 
			this.btnBindToArray.Location = new System.Drawing.Point(152, 16);
			this.btnBindToArray.Name = "btnBindToArray";
			this.btnBindToArray.Size = new System.Drawing.Size(184, 32);
			this.btnBindToArray.TabIndex = 0;
			this.btnBindToArray.Text = "繫結到陣列";
			this.btnBindToArray.Click += new System.EventHandler(this.btnBindToArray_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 25);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			// 
			// btnBindToControl
			// 
			this.btnBindToControl.Location = new System.Drawing.Point(152, 72);
			this.btnBindToControl.Name = "btnBindToControl";
			this.btnBindToControl.Size = new System.Drawing.Size(184, 32);
			this.btnBindToControl.TabIndex = 2;
			this.btnBindToControl.Text = "繫結到另一個控制項";
			this.btnBindToControl.Click += new System.EventHandler(this.btnBindToControl_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
																		 "Michael",
																		 "Huanlin",
																		 "Will"});
			this.comboBox1.Location = new System.Drawing.Point(8, 72);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 23);
			this.comboBox1.TabIndex = 3;
			this.comboBox1.Text = "comboBox1";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.btnBindToControl);
			this.panel1.Controls.Add(this.btnBindToArray);
			this.panel1.Location = new System.Drawing.Point(16, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(360, 120);
			this.panel1.TabIndex = 4;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.btnFormatParse);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.txtEmpBirthday);
			this.panel2.Controls.Add(this.txtEmpName);
			this.panel2.Controls.Add(this.btnBindToObjArray);
			this.panel2.Location = new System.Drawing.Point(16, 168);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(368, 200);
			this.panel2.TabIndex = 5;
			// 
			// txtEmpName
			// 
			this.txtEmpName.Location = new System.Drawing.Point(80, 16);
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(160, 25);
			this.txtEmpName.TabIndex = 3;
			this.txtEmpName.Text = "";
			// 
			// btnBindToObjArray
			// 
			this.btnBindToObjArray.Location = new System.Drawing.Point(16, 96);
			this.btnBindToObjArray.Name = "btnBindToObjArray";
			this.btnBindToObjArray.Size = new System.Drawing.Size(184, 32);
			this.btnBindToObjArray.TabIndex = 2;
			this.btnBindToObjArray.Text = "繫結到物件陣列";
			this.btnBindToObjArray.Click += new System.EventHandler(this.btnBindToObjArray_Click);
			// 
			// txtEmpBirthday
			// 
			this.txtEmpBirthday.Location = new System.Drawing.Point(80, 56);
			this.txtEmpBirthday.Name = "txtEmpBirthday";
			this.txtEmpBirthday.Size = new System.Drawing.Size(160, 25);
			this.txtEmpBirthday.TabIndex = 4;
			this.txtEmpBirthday.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "姓名";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "生日";
			// 
			// btnFormatParse
			// 
			this.btnFormatParse.Location = new System.Drawing.Point(16, 144);
			this.btnFormatParse.Name = "btnFormatParse";
			this.btnFormatParse.Size = new System.Drawing.Size(184, 32);
			this.btnFormatParse.TabIndex = 7;
			this.btnFormatParse.Text = "Format 與 Parse 事件";
			this.btnFormatParse.Click += new System.EventHandler(this.btnFormatParse_Click);
			// 
			// btnComplexBiding
			// 
			this.btnComplexBiding.Location = new System.Drawing.Point(16, 392);
			this.btnComplexBiding.Name = "btnComplexBiding";
			this.btnComplexBiding.Size = new System.Drawing.Size(128, 40);
			this.btnComplexBiding.TabIndex = 6;
			this.btnComplexBiding.Text = "複雜繫結";
			this.btnComplexBiding.Click += new System.EventHandler(this.btnComplexBiding_Click);
			// 
			// btnAdoNetBinding
			// 
			this.btnAdoNetBinding.Location = new System.Drawing.Point(160, 392);
			this.btnAdoNetBinding.Name = "btnAdoNetBinding";
			this.btnAdoNetBinding.Size = new System.Drawing.Size(168, 40);
			this.btnAdoNetBinding.TabIndex = 7;
			this.btnAdoNetBinding.Text = "ADO.NET 資料繫結";
			this.btnAdoNetBinding.Click += new System.EventHandler(this.btnAdoNetBinding_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(440, 453);
			this.Controls.Add(this.btnAdoNetBinding);
			this.Controls.Add(this.btnComplexBiding);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Data Binding 範例";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
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

		private void btnBindToArray_Click(object sender, System.EventArgs e)
		{
			Color[] arr = new Color[] {Color.Red, Color.Yellow, Color.Blue};

			Binding aBinding = new Binding("BackColor", arr, "");
			textBox1.DataBindings.Add(aBinding);

			BindingManagerBase bmb = this.BindingContext[arr];
			bmb.Position++; // textBox1 的背景色會是: Yellow.

			MessageBox.Show("Binding manager 的型別是: " + bmb.GetType().Name);
		}

		private void btnBindToControl_Click(object sender, System.EventArgs e)
		{
			textBox1.DataBindings.Add("Text", comboBox1, "Text");

			BindingManagerBase bmb = this.BindingContext[comboBox1];
			MessageBox.Show("Binding manager 的型別是: " + bmb.GetType().Name);
		}


		class Emp 
		{
			private string name;
			private DateTime birthday;

			public string Name 
			{
				get { return name; }
				set { name = value; }
			}
			public DateTime Birthday 
			{
				get { return birthday; }
				set { birthday = value; }
			}
		}


		private void btnBindToObjArray_Click(object sender, System.EventArgs e)
		{	
			// 先檢查控制項的屬性是否已經有繫結了，有的話直接返回.
			Binding aBinding = txtEmpBirthday.DataBindings["Text"];
			if (aBinding != null) 
			{
				return;
			}

			Emp[] empArray = new Emp[2] { new Emp(), new Emp() };						
			empArray[0].Name = "John";
			empArray[0].Birthday = new DateTime(1980, 2, 14);
			empArray[1].Name = "Mary";
			empArray[1].Birthday = new DateTime(1986, 6, 6);

			// 將 txtEmpName 的 Text 屬性繫結到員工陣列，資料成員為 "Name"
			txtEmpName.DataBindings.Add("Text", empArray, "Name");

			// 將 txtEmpBirthday 的 Text 屬性繫結到員工陣列，資料成員為 "Birthday"
			txtEmpBirthday.DataBindings.Add("Text", empArray, "Birthday");

			// 移動到第二筆記錄
			BindingManagerBase bmb = this.BindingContext[empArray];
			bmb.Position++;
		}

		private void btnFormatParse_Click(object sender, System.EventArgs e)
		{
			// 先從控制項取得 Binding 物件
			Binding aBinding = txtEmpBirthday.DataBindings["Text"];

			// 再從 Binding 物件取得其關聯的 BindingManagerBase 物件
			BindingManagerBase bmb = aBinding.BindingManagerBase;

			// 先暫停繫結，以便完成 Format 事件訂閱後，恢復繫結以觸發 Format 事件
			bmb.SuspendBinding();

			// 訂閱事件
			aBinding.Format += new ConvertEventHandler(EmpBirthday_Format);
			aBinding.Parse += new ConvertEventHandler(EmpBirthday_Parse);

			// 恢復繫結
			bmb.ResumeBinding();
		}

		private void EmpBirthday_Format(object sender, ConvertEventArgs e)
		{
			e.Value = String.Format("{0:yyyy-MM-dd}", e.Value);
		}

		private void EmpBirthday_Parse(object sender, ConvertEventArgs e)
		{
			e.Value = Convert.ToDateTime(e.Value);
		}

		private void btnComplexBiding_Click(object sender, System.EventArgs e)
		{
			ComplexBindingForm aForm = new ComplexBindingForm();
			aForm.ShowDialog();
		}

		private void btnAdoNetBinding_Click(object sender, System.EventArgs e)
		{
			AdoNetBindingForm aForm = new AdoNetBindingForm();
			aForm.ShowDialog();
		}
	}
}
