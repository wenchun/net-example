using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace FileSystemWatcherDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.IO.FileSystemWatcher fileSystemWatcher1;
		private System.Windows.Forms.Button btnWatch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btnBrowseFolder;
		private System.Windows.Forms.TextBox txtFolder;
		private System.Windows.Forms.TextBox txtLog;
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
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.btnWatch = new System.Windows.Forms.Button();
			this.txtFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.btnBrowseFolder = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
			this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
			this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
			this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
			// 
			// btnWatch
			// 
			this.btnWatch.Location = new System.Drawing.Point(24, 80);
			this.btnWatch.Name = "btnWatch";
			this.btnWatch.Size = new System.Drawing.Size(104, 32);
			this.btnWatch.TabIndex = 0;
			this.btnWatch.Text = "開始監視";
			this.btnWatch.Click += new System.EventHandler(this.btnWatch_Click);
			// 
			// txtFolder
			// 
			this.txtFolder.Location = new System.Drawing.Point(120, 32);
			this.txtFolder.Name = "txtFolder";
			this.txtFolder.Size = new System.Drawing.Size(256, 25);
			this.txtFolder.TabIndex = 1;
			this.txtFolder.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 40);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "欲監視的目錄";
			// 
			// btnBrowseFolder
			// 
			this.btnBrowseFolder.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBrowseFolder.Location = new System.Drawing.Point(384, 32);
			this.btnBrowseFolder.Name = "btnBrowseFolder";
			this.btnBrowseFolder.Size = new System.Drawing.Size(32, 24);
			this.btnBrowseFolder.TabIndex = 3;
			this.btnBrowseFolder.Text = "...";
			this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(24, 136);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(408, 240);
			this.txtLog.TabIndex = 4;
			this.txtLog.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(464, 402);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.btnBrowseFolder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtFolder);
			this.Controls.Add(this.btnWatch);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "FileSystemWatcherDemo";
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
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

		private void btnBrowseFolder_Click(object sender, System.EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK) 
			{
				txtFolder.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void btnWatch_Click(object sender, System.EventArgs e)
		{
			if ((string)btnWatch.Tag != "OFF")
			{
				fileSystemWatcher1.Path = txtFolder.Text;
				fileSystemWatcher1.EnableRaisingEvents = true;
				btnWatch.Text = "停止監視";
				btnWatch.Tag = "OFF";
			}
			else 
			{
				fileSystemWatcher1.EnableRaisingEvents = false;
				btnWatch.Text = "開始監視";
				btnWatch.Tag = "ON";
			}
		}

		private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
		{
			string s = "";
			switch (e.ChangeType) 
			{
				case WatcherChangeTypes.Changed:
					s = String.Format("{0} 有變動\n", e.FullPath);
					break;
				case WatcherChangeTypes.Created:
					s = String.Format("{0} 已建立\n", e.FullPath);
					break;
				case WatcherChangeTypes.Deleted:
					s = String.Format("{0} 已刪除\n", e.FullPath);
					break;
			}
			txtLog.AppendText(s);
		}

		private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
		{
			String s = String.Format("檔案重新命名: 從 {0} 到 {1}\n", e.OldFullPath, e.FullPath);
			txtLog.AppendText(s);
		}
	}
}
