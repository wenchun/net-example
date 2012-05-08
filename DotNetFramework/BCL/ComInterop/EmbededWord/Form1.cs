using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace EmbededWord
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private AxSHDocVw.AxWebBrowser axWebBrowser1;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Panel panel1;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.axWebBrowser1 = new AxSHDocVw.AxWebBrowser();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOpen = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// axWebBrowser1
			// 
			this.axWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.axWebBrowser1.Enabled = true;
			this.axWebBrowser1.Location = new System.Drawing.Point(0, 0);
			this.axWebBrowser1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWebBrowser1.OcxState")));
			this.axWebBrowser1.Size = new System.Drawing.Size(656, 501);
			this.axWebBrowser1.TabIndex = 0;
			this.axWebBrowser1.DocumentComplete += new AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEventHandler(this.axWebBrowser1_DocumentComplete);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(360, 16);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(24, 24);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "...";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(64, 16);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(296, 25);
			this.txtFileName.TabIndex = 2;
			this.txtFileName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "FileName";
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(392, 16);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.TabIndex = 4;
			this.btnOpen.Text = "Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnBrowse);
			this.panel1.Controls.Add(this.txtFileName);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnOpen);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(656, 56);
			this.panel1.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(656, 501);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.axWebBrowser1);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.Form1_Closed);
			((System.ComponentModel.ISupportInitialize)(this.axWebBrowser1)).EndInit();
			this.panel1.ResumeLayout(false);
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

		Word.Application word;
		bool docLoaded = false;

		private void Form1_Load(object sender, System.EventArgs e)
		{
			word = new Word.Application();

			openFileDialog1.Filter = "Office Documents(*.doc, *.xls, *.ppt)|*.doc;*.xls;*.ppt" ;
			openFileDialog1.FilterIndex = 1;
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.FileName = "";
			if (openFileDialog1.ShowDialog() == DialogResult.OK) 
			{
				txtFileName.Text = openFileDialog1.FileName;
			}
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			if (txtFileName.Text != "")
			{
				this.docLoaded = false;

				Object missing = System.Type.Missing;
				axWebBrowser1.Navigate(txtFileName.Text, ref missing , ref missing , ref missing , ref missing);

				// 確保文件已經載入完畢，才繼續進行後續的控制處理.
				while (docLoaded == false) 
				{
					Application.DoEvents();
				}
				this.Text = "DocumentCompleted event: 文件載入完畢";

				Test(false);
			}
		}

		// 測試建立 200 個文字方塊.
		private void Test(bool disableRefresh) 
		{
			object missing = System.Type.Missing;
			int x = 10;
			int y = 10;

			word.ScreenUpdating = !disableRefresh;
		
			DateTime beginTime = DateTime.Now;

			for (int i = 0; i < 200; i++) 
			{
				Word.Shape txtBox = word.ActiveDocument.Shapes.AddTextbox(Office.MsoTextOrientation.msoTextOrientationHorizontal, x, y, 40, 30, ref missing);
				txtBox.TextFrame.TextRange.Font.Size = 10.0f;   //---字型大小
				txtBox.Line.Visible = Office.MsoTriState.msoFalse;     //---文字方塊外框
				txtBox.Fill.Transparency = 1.0f;                //---文字方塊透明度(0.0 ~ 1.0)
				txtBox.TextFrame.TextRange.Text = "測試文字方塊 " + i.ToString();

				x += 50;
				if (x > 500) 
				{
					x = 10;
					y += 40;
				}
			}

			// 恢復螢幕更新.
			word.ScreenUpdating = true;

			TimeSpan diffTime = new TimeSpan(DateTime.Now.Ticks - beginTime.Ticks);
			word.Selection.TypeText("共花費時間: " + diffTime.ToString());

		}

		private void axWebBrowser1_DocumentComplete(object sender, AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent e)
		{
			docLoaded = true;			
		}

		private void Form1_Closed(object sender, System.EventArgs e)
		{
			axWebBrowser1.Dispose();

			object missing = System.Type.Missing;
			if (word != null) 
			{
				word.Quit(ref missing, ref missing, ref missing);
				word = null;
			}
		
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}
