using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;

namespace FileInfoDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private SortedList _FileList = new SortedList();

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btnSelectFiles;
		private System.Windows.Forms.TextBox txtContent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.TextBox txtFileSize;
		private System.Windows.Forms.TextBox txtLastModified;
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
			this.btnSelectFiles = new System.Windows.Forms.Button();
			this.txtContent = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.txtFileSize = new System.Windows.Forms.TextBox();
			this.txtLastModified = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(184, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(304, 124);
			this.listBox1.TabIndex = 1;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// btnSelectFiles
			// 
			this.btnSelectFiles.Location = new System.Drawing.Point(16, 24);
			this.btnSelectFiles.Name = "btnSelectFiles";
			this.btnSelectFiles.Size = new System.Drawing.Size(144, 40);
			this.btnSelectFiles.TabIndex = 2;
			this.btnSelectFiles.Text = "選擇檔案(可多選)";
			this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
			// 
			// txtContent
			// 
			this.txtContent.Location = new System.Drawing.Point(16, 248);
			this.txtContent.Multiline = true;
			this.txtContent.Name = "txtContent";
			this.txtContent.Size = new System.Drawing.Size(512, 264);
			this.txtContent.TabIndex = 3;
			this.txtContent.Text = "這裡用來顯示選擇的檔案的內容";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 208);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "最近修改時間";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(304, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "檔案長度";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "檔案名稱";
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(88, 165);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.ReadOnly = true;
			this.txtFileName.Size = new System.Drawing.Size(208, 25);
			this.txtFileName.TabIndex = 7;
			this.txtFileName.Text = "";
			// 
			// txtFileSize
			// 
			this.txtFileSize.Location = new System.Drawing.Point(376, 168);
			this.txtFileSize.Name = "txtFileSize";
			this.txtFileSize.ReadOnly = true;
			this.txtFileSize.Size = new System.Drawing.Size(112, 25);
			this.txtFileSize.TabIndex = 8;
			this.txtFileSize.Text = "";
			// 
			// txtLastModified
			// 
			this.txtLastModified.Location = new System.Drawing.Point(120, 204);
			this.txtLastModified.Name = "txtLastModified";
			this.txtLastModified.ReadOnly = true;
			this.txtLastModified.Size = new System.Drawing.Size(368, 25);
			this.txtLastModified.TabIndex = 9;
			this.txtLastModified.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(632, 530);
			this.Controls.Add(this.txtLastModified);
			this.Controls.Add(this.txtFileSize);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtContent);
			this.Controls.Add(this.btnSelectFiles);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "FileInfoDemo by Huan-Lin Tsai. Jul-22-2005.";
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

		private void btnSelectFiles_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.Filter = "純文字檔(*.txt)|*.txt";
			openFileDialog1.FilterIndex = 0;
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.Multiselect = true;
			if (openFileDialog1.ShowDialog() == DialogResult.OK) 
			{
				listBox1.Items.AddRange(openFileDialog1.FileNames);
				
				// 把所有檔案的 FileInfo 物件儲存在內部的 SortedList 物件裡.
				_FileList.Clear();
				foreach (string fname in listBox1.Items) 
				{
					FileInfo fi = new FileInfo(fname);
					_FileList.Add(fname, fi);
				}
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string fname = (string) listBox1.SelectedItem;
			
			FileInfo fi = (FileInfo) _FileList[fname];

			txtFileName.Text = fi.Name;
			txtFileSize.Text = fi.Length.ToString();
			txtLastModified.Text = fi.LastWriteTime.ToLongDateString() + " " + fi.LastWriteTime.ToShortTimeString();

			// 讀取檔案內容.
			StreamReader sr = new StreamReader(fi.FullName, Encoding.Default, true);
			txtContent.Text = sr.ReadToEnd();

			// p.s. 如果你用 FileInfo.OpenText() 來取得 StreamReader 物件，
			// 就無法控制要用哪一種 Encoding，中文字會變亂碼。
		}
	}
}
