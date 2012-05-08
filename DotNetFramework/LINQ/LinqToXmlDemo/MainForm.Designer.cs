namespace LinqToXmlDemo
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
			this.btnQueryXmlData = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(16, 222);
			this.txtOutput.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.txtOutput.Size = new System.Drawing.Size(399, 208);
			// 
			// btnClearOutput
			// 
			this.btnClearOutput.Location = new System.Drawing.Point(16, 450);
			// 
			// btnQueryXmlData
			// 
			this.btnQueryXmlData.Location = new System.Drawing.Point(436, 12);
			this.btnQueryXmlData.Name = "btnQueryXmlData";
			this.btnQueryXmlData.Size = new System.Drawing.Size(138, 41);
			this.btnQueryXmlData.TabIndex = 5;
			this.btnQueryXmlData.Text = "Query XML Data";
			this.btnQueryXmlData.UseVisualStyleBackColor = true;
			this.btnQueryXmlData.Click += new System.EventHandler(this.btnQueryXmlData_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(16, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(399, 178);
			this.dataGridView1.TabIndex = 6;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(646, 531);
			this.Controls.Add(this.btnQueryXmlData);
			this.Controls.Add(this.dataGridView1);
			this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.Name = "MainForm";
			this.Text = "LINQ to XML Demo";
			this.Controls.SetChildIndex(this.dataGridView1, 0);
			this.Controls.SetChildIndex(this.btnQueryXmlData, 0);
			this.Controls.SetChildIndex(this.btnClearOutput, 0);
			this.Controls.SetChildIndex(this.txtOutput, 0);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnQueryXmlData;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}

