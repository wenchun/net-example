namespace LinqToDataSetDemo
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
			this.btnQueryTypedDataSet = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnQueryUntypedDataSet = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(13, 304);
			this.txtOutput.Size = new System.Drawing.Size(510, 162);
			// 
			// btnClearOutput
			// 
			this.btnClearOutput.Location = new System.Drawing.Point(531, 421);
			// 
			// btnQueryTypedDataSet
			// 
			this.btnQueryTypedDataSet.Location = new System.Drawing.Point(13, 21);
			this.btnQueryTypedDataSet.Name = "btnQueryTypedDataSet";
			this.btnQueryTypedDataSet.Size = new System.Drawing.Size(148, 45);
			this.btnQueryTypedDataSet.TabIndex = 5;
			this.btnQueryTypedDataSet.Text = "Query Typed DataSet";
			this.btnQueryTypedDataSet.UseVisualStyleBackColor = true;
			this.btnQueryTypedDataSet.Click += new System.EventHandler(this.btnQueryTypedDataSet_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(13, 83);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(637, 201);
			this.dataGridView1.TabIndex = 6;
			// 
			// btnQueryUntypedDataSet
			// 
			this.btnQueryUntypedDataSet.Location = new System.Drawing.Point(167, 21);
			this.btnQueryUntypedDataSet.Name = "btnQueryUntypedDataSet";
			this.btnQueryUntypedDataSet.Size = new System.Drawing.Size(170, 45);
			this.btnQueryUntypedDataSet.TabIndex = 7;
			this.btnQueryUntypedDataSet.Text = "Query Untyped DataSet";
			this.btnQueryUntypedDataSet.UseVisualStyleBackColor = true;
			this.btnQueryUntypedDataSet.Click += new System.EventHandler(this.btnQueryUntypedDataSet_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(672, 479);
			this.Controls.Add(this.btnQueryUntypedDataSet);
			this.Controls.Add(this.btnQueryTypedDataSet);
			this.Controls.Add(this.dataGridView1);
			this.Name = "MainForm";
			this.Text = "LINQ to DataSet Demo";
			this.Controls.SetChildIndex(this.dataGridView1, 0);
			this.Controls.SetChildIndex(this.btnQueryTypedDataSet, 0);
			this.Controls.SetChildIndex(this.txtOutput, 0);
			this.Controls.SetChildIndex(this.btnClearOutput, 0);
			this.Controls.SetChildIndex(this.btnQueryUntypedDataSet, 0);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnQueryTypedDataSet;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnQueryUntypedDataSet;
	}
}

