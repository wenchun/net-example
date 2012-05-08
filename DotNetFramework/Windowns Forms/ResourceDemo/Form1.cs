using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.IO;
using System.Resources;

namespace ResourceDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btnChangeBg;
		private System.Windows.Forms.Button btnReadResX;
		private System.Windows.Forms.Button btnReadResXUsingRM;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.ComponentModel.IContainer components;

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btnChangeBg = new System.Windows.Forms.Button();
			this.btnReadResX = new System.Windows.Forms.Button();
			this.btnReadResXUsingRM = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(24, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(312, 109);
			this.listBox1.TabIndex = 0;
			// 
			// btnChangeBg
			// 
			this.btnChangeBg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnChangeBg.Location = new System.Drawing.Point(24, 152);
			this.btnChangeBg.Name = "btnChangeBg";
			this.btnChangeBg.Size = new System.Drawing.Size(104, 32);
			this.btnChangeBg.TabIndex = 1;
			this.btnChangeBg.Text = "切換背景圖";
			this.btnChangeBg.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnReadResX
			// 
			this.btnReadResX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnReadResX.Location = new System.Drawing.Point(24, 200);
			this.btnReadResX.Name = "btnReadResX";
			this.btnReadResX.Size = new System.Drawing.Size(152, 32);
			this.btnReadResX.TabIndex = 2;
			this.btnReadResX.Text = "讀取 .resx 資源";
			this.btnReadResX.Click += new System.EventHandler(this.btnReadResX_Click);
			// 
			// btnReadResXUsingRM
			// 
			this.btnReadResXUsingRM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnReadResXUsingRM.Location = new System.Drawing.Point(24, 248);
			this.btnReadResXUsingRM.Name = "btnReadResXUsingRM";
			this.btnReadResXUsingRM.Size = new System.Drawing.Size(272, 32);
			this.btnReadResXUsingRM.TabIndex = 3;
			this.btnReadResXUsingRM.Text = "讀取 .resx 資源，使用 ResourceManager";
			this.btnReadResXUsingRM.Click += new System.EventHandler(this.btnReadResXUsingRM_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.pictureBox1.Location = new System.Drawing.Point(432, 48);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(136, 128);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(648, 354);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnReadResXUsingRM);
			this.Controls.Add(this.btnReadResX);
			this.Controls.Add(this.btnChangeBg);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Form1_HelpRequested);
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

		private void Form1_HelpRequested(object sender, System.Windows.Forms.HelpEventArgs hlpevent)
		{
			MessageBox.Show("aaa");
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Assembly asm = Assembly.GetAssembly(this.GetType());
			foreach (string resName in asm.GetManifestResourceNames()) 
			{
				if (resName.ToUpper().EndsWith(".JPG")) 
				{
					listBox1.Items.Add(resName);
				}
			}
			listBox1.SelectedIndex = 0;

			// 預設的背景圖
			this.BackgroundImage = new Bitmap(this.GetType(), "image.拳四郎.GIF");
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Assembly asm = this.GetType().Assembly;
			string resName = (string) listBox1.SelectedItem;
			Stream stream = asm.GetManifestResourceStream(resName);
			this.BackgroundImage = new Bitmap(stream);
		}

		private void btnReadResX_Click(object sender, System.EventArgs e)
		{
			Assembly asm = this.GetType().Assembly;
			using (Stream stream = asm.GetManifestResourceStream(this.GetType(), "Resource1.resources")) 
			{
				using (ResourceReader reader = new ResourceReader(stream)) 
				{
					foreach (DictionaryEntry entry in reader) 
					{
						if (entry.Key.ToString() == "Message") 
						{
							MessageBox.Show((string) entry.Value);
						}
					}
				}
			}
		}

		private void btnReadResXUsingRM_Click(object sender, System.EventArgs e)
		{
			// 使用 ResourceManager 的 code 簡潔多了！而且可以隨機存取。
			Assembly asm = Assembly.GetExecutingAssembly();
			ResourceManager rm = new ResourceManager("ResourceDemo.Resource1", asm);
			string s = rm.GetString("Message");
			MessageBox.Show(s);
		}
	}
}
