namespace Linq101Demo
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnLinqBasic = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnLinqBasic
			// 
			this.btnLinqBasic.Location = new System.Drawing.Point(437, 23);
			this.btnLinqBasic.Margin = new System.Windows.Forms.Padding(4);
			this.btnLinqBasic.Name = "btnLinqBasic";
			this.btnLinqBasic.Size = new System.Drawing.Size(234, 46);
			this.btnLinqBasic.TabIndex = 0;
			this.btnLinqBasic.Text = "LINQ 基本語法範例";
			this.btnLinqBasic.UseVisualStyleBackColor = true;
			this.btnLinqBasic.Click += new System.EventHandler(this.btnLinqBasic_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(437, 77);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(234, 46);
			this.button1.TabIndex = 3;
			this.button1.Text = "觀察 LINQ 的延遲查詢機制";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(734, 409);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnLinqBasic);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Controls.SetChildIndex(this.btnLinqBasic, 0);
			this.Controls.SetChildIndex(this.button1, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnLinqBasic;
		private System.Windows.Forms.Button button1;
	}
}