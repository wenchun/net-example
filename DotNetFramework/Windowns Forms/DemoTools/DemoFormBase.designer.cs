namespace DemoTools
{
	partial class DemoFormBase
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
			this.btnClearOutput = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnClearOutput
			// 
			this.btnClearOutput.Location = new System.Drawing.Point(16, 355);
			this.btnClearOutput.Margin = new System.Windows.Forms.Padding(4);
			this.btnClearOutput.Name = "btnClearOutput";
			this.btnClearOutput.Size = new System.Drawing.Size(107, 45);
			this.btnClearOutput.TabIndex = 4;
			this.btnClearOutput.Text = "清除訊息";
			this.btnClearOutput.UseVisualStyleBackColor = true;
			this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(16, 11);
			this.txtOutput.Margin = new System.Windows.Forms.Padding(4);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutput.Size = new System.Drawing.Size(399, 336);
			this.txtOutput.TabIndex = 3;
			// 
			// DemoFormBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(672, 479);
			this.Controls.Add(this.btnClearOutput);
			this.Controls.Add(this.txtOutput);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DemoFormBase";
			this.Text = "DemoFormBase";
			this.Load += new System.EventHandler(this.DemoFormBase_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DemoFormBase_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		protected System.Windows.Forms.TextBox txtOutput;
		protected System.Windows.Forms.Button btnClearOutput;
	}
}