namespace LinqToSqlDemo
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
			this.btnQuerySqlDatabase = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnCallProc = new System.Windows.Forms.Button();
			this.btnAddCustomer = new System.Windows.Forms.Button();
			this.btnDeleteCustomer = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(13, 350);
			this.txtOutput.Size = new System.Drawing.Size(570, 123);
			// 
			// btnClearOutput
			// 
			this.btnClearOutput.Location = new System.Drawing.Point(598, 428);
			// 
			// btnQuerySqlDatabase
			// 
			this.btnQuerySqlDatabase.Location = new System.Drawing.Point(13, 12);
			this.btnQuerySqlDatabase.Name = "btnQuerySqlDatabase";
			this.btnQuerySqlDatabase.Size = new System.Drawing.Size(165, 46);
			this.btnQuerySqlDatabase.TabIndex = 5;
			this.btnQuerySqlDatabase.Text = "Query SQL Database";
			this.btnQuerySqlDatabase.UseVisualStyleBackColor = true;
			this.btnQuerySqlDatabase.Click += new System.EventHandler(this.btnQuerySqlDatabase_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(13, 64);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(682, 264);
			this.dataGridView1.TabIndex = 6;
			// 
			// btnCallProc
			// 
			this.btnCallProc.Location = new System.Drawing.Point(184, 12);
			this.btnCallProc.Name = "btnCallProc";
			this.btnCallProc.Size = new System.Drawing.Size(163, 46);
			this.btnCallProc.TabIndex = 7;
			this.btnCallProc.Text = "呼叫 stored procedure";
			this.btnCallProc.UseVisualStyleBackColor = true;
			this.btnCallProc.Click += new System.EventHandler(this.btnCallProc_Click);
			// 
			// btnAddCustomer
			// 
			this.btnAddCustomer.Location = new System.Drawing.Point(353, 12);
			this.btnAddCustomer.Name = "btnAddCustomer";
			this.btnAddCustomer.Size = new System.Drawing.Size(163, 46);
			this.btnAddCustomer.TabIndex = 8;
			this.btnAddCustomer.Text = "新增一筆客戶資料";
			this.btnAddCustomer.UseVisualStyleBackColor = true;
			this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
			// 
			// btnDeleteCustomer
			// 
			this.btnDeleteCustomer.Location = new System.Drawing.Point(522, 12);
			this.btnDeleteCustomer.Name = "btnDeleteCustomer";
			this.btnDeleteCustomer.Size = new System.Drawing.Size(163, 46);
			this.btnDeleteCustomer.TabIndex = 9;
			this.btnDeleteCustomer.Text = "刪除該筆客戶資料";
			this.btnDeleteCustomer.UseVisualStyleBackColor = true;
			this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(728, 486);
			this.Controls.Add(this.btnDeleteCustomer);
			this.Controls.Add(this.btnAddCustomer);
			this.Controls.Add(this.btnCallProc);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnQuerySqlDatabase);
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "MainForm";
			this.Text = "LINQ To SQL Demo";
			this.Controls.SetChildIndex(this.txtOutput, 0);
			this.Controls.SetChildIndex(this.btnClearOutput, 0);
			this.Controls.SetChildIndex(this.btnQuerySqlDatabase, 0);
			this.Controls.SetChildIndex(this.dataGridView1, 0);
			this.Controls.SetChildIndex(this.btnCallProc, 0);
			this.Controls.SetChildIndex(this.btnAddCustomer, 0);
			this.Controls.SetChildIndex(this.btnDeleteCustomer, 0);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnQuerySqlDatabase;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnCallProc;
		private System.Windows.Forms.Button btnAddCustomer;
		private System.Windows.Forms.Button btnDeleteCustomer;
	}
}

