namespace CourseManager
{
	partial class CourseViewer
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
			this.departmentList = new System.Windows.Forms.ComboBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.courseGridView = new System.Windows.Forms.DataGridView();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.loadDataButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.courseGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// departmentList
			// 
			this.departmentList.FormattingEnabled = true;
			this.departmentList.Location = new System.Drawing.Point(484, 13);
			this.departmentList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.departmentList.Name = "departmentList";
			this.departmentList.Size = new System.Drawing.Size(190, 23);
			this.departmentList.TabIndex = 0;
			this.departmentList.SelectedIndexChanged += new System.EventHandler(this.departmentList_SelectedIndexChanged);
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(564, 114);
			this.closeButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(100, 29);
			this.closeButton.TabIndex = 1;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// courseGridView
			// 
			this.courseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.courseGridView.Location = new System.Drawing.Point(12, 188);
			this.courseGridView.Name = "courseGridView";
			this.courseGridView.RowTemplate.Height = 24;
			this.courseGridView.Size = new System.Drawing.Size(662, 137);
			this.courseGridView.TabIndex = 2;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(445, 170);
			this.dataGridView1.TabIndex = 3;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(12, 331);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(662, 200);
			this.textBox1.TabIndex = 4;
			// 
			// loadDataButton
			// 
			this.loadDataButton.Location = new System.Drawing.Point(484, 54);
			this.loadDataButton.Name = "loadDataButton";
			this.loadDataButton.Size = new System.Drawing.Size(107, 37);
			this.loadDataButton.TabIndex = 5;
			this.loadDataButton.Text = "Load Data";
			this.loadDataButton.UseVisualStyleBackColor = true;
			this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
			// 
			// CourseViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(714, 543);
			this.Controls.Add(this.loadDataButton);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.courseGridView);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.departmentList);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "CourseViewer";
			this.Text = "Course Viewer";
			this.Load += new System.EventHandler(this.CourseViewer_Load);
			((System.ComponentModel.ISupportInitialize)(this.courseGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox departmentList;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.DataGridView courseGridView;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button loadDataButton;
	}
}

