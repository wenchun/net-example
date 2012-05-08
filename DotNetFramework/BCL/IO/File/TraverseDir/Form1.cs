using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace TraverseDir
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btnGetFiles;
		private System.Windows.Forms.TextBox textBox1;
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btnGetFiles = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(16, 72);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(440, 328);
			this.listBox1.TabIndex = 0;
			// 
			// btnGetFiles
			// 
			this.btnGetFiles.Location = new System.Drawing.Point(272, 24);
			this.btnGetFiles.Name = "btnGetFiles";
			this.btnGetFiles.Size = new System.Drawing.Size(88, 24);
			this.btnGetFiles.TabIndex = 1;
			this.btnGetFiles.Text = "Go";
			this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(232, 22);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "C:\\1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(480, 429);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnGetFiles);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "Traverse Directory";
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


		public void GetFiles(string dirName) 
		{
			DirectoryInfo d = new DirectoryInfo(dirName);

			// 取出此目錄下的所有檔案
			FileInfo[] files = d.GetFiles();
			foreach (FileInfo fi in files) 
			{
				listBox1.Items.Add(fi.FullName);
			}

			// 取出此目錄下的所有子目錄
			DirectoryInfo[] subdirs = d.GetDirectories();		

			foreach (DirectoryInfo dd in subdirs) 
			{
				listBox1.Items.Add(dd.FullName);
				if (dd.Attributes == FileAttributes.Directory) 
				{
					GetFiles(dd.FullName);
				}
			}
		}

		private void btnGetFiles_Click(object sender, System.EventArgs e)
		{
			GetFiles(textBox1.Text);
		}
	}
}
