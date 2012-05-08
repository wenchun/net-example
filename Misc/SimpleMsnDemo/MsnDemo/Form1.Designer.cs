namespace MsnDemo
{
	partial class Form1
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
			this.btnConnect = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnSendMsg = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMsg = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtContact = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAccount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(32, 77);
			this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(145, 37);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "Login MSN server";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 386);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip1.Size = new System.Drawing.Size(626, 28);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.AutoSize = false;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(400, 23);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSendMsg
			// 
			this.btnSendMsg.Location = new System.Drawing.Point(345, 187);
			this.btnSendMsg.Margin = new System.Windows.Forms.Padding(4);
			this.btnSendMsg.Name = "btnSendMsg";
			this.btnSendMsg.Size = new System.Drawing.Size(91, 31);
			this.btnSendMsg.TabIndex = 2;
			this.btnSendMsg.Text = "傳送!";
			this.btnSendMsg.UseVisualStyleBackColor = true;
			this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(233, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(366, 37);
			this.label1.TabIndex = 3;
			this.label1.Text = "注意：交談的雙方必須彼此互為連絡人，且訊息接收端狀態不可為離線，否則訊息將無法傳遞。";
			// 
			// txtMsg
			// 
			this.txtMsg.Location = new System.Drawing.Point(30, 261);
			this.txtMsg.Multiline = true;
			this.txtMsg.Name = "txtMsg";
			this.txtMsg.Size = new System.Drawing.Size(347, 107);
			this.txtMsg.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 163);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 15);
			this.label2.TabIndex = 5;
			this.label2.Text = "發送給：";
			// 
			// txtContact
			// 
			this.txtContact.Location = new System.Drawing.Point(100, 155);
			this.txtContact.Name = "txtContact";
			this.txtContact.Size = new System.Drawing.Size(225, 25);
			this.txtContact.TabIndex = 6;
			this.txtContact.Text = "someone@hotmail.com";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(29, 34);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(145, 15);
			this.label3.TabIndex = 7;
			this.label3.Text = "你的 MSN email 帳號:";
			// 
			// txtAccount
			// 
			this.txtAccount.Location = new System.Drawing.Point(180, 31);
			this.txtAccount.Name = "txtAccount";
			this.txtAccount.Size = new System.Drawing.Size(182, 25);
			this.txtAccount.TabIndex = 8;
			this.txtAccount.Text = "me@hotmail.com";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(385, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 15);
			this.label4.TabIndex = 9;
			this.label4.Text = "密碼:";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(432, 31);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(100, 25);
			this.txtPassword.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(29, 195);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 15);
			this.label5.TabIndex = 11;
			this.label5.Text = "訊息：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(100, 192);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(225, 25);
			this.textBox1.TabIndex = 12;
			this.textBox1.Text = "Testing MSN robot!";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(29, 243);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 15);
			this.label6.TabIndex = 13;
			this.label6.Text = "Log:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(626, 414);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtAccount);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtContact);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtMsg);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSendMsg);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnConnect);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "SimpleMsnMessenger Demo by Huan-Lin Tsai. Dec-10-2008";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Button btnSendMsg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMsg;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtContact;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtAccount;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label6;
	}
}

