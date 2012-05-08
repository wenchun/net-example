using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Customer
{
	public class CustomerForm : PluginInterface.PluginForm
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.ComponentModel.IContainer components = null;

		public CustomerForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(40, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(40, 64);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 1;
			this.textBox2.Text = "textBox2";
			// 
			// CustomerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Name = "CustomerForm";
			this.Text = "客戶資料維護作業";
			this.ResumeLayout(false);

		}
		#endregion
	
		public override void Initialize(object sender, object param)
		{
			base.Initialize (sender, param);
			MessageBox.Show("CustomerForm.Initialize() is called!");
		}
	}
}

