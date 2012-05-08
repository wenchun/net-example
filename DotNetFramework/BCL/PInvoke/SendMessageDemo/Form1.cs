using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace SendMessageDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtWindowText;
		private System.Windows.Forms.Button btnFindWindowAdnClose;
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtWindowText = new System.Windows.Forms.TextBox();
			this.btnFindWindowAdnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 48);
			this.button1.TabIndex = 0;
			this.button1.Text = "Send WM_CLOSE";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "視窗標題";
			// 
			// txtWindowText
			// 
			this.txtWindowText.Location = new System.Drawing.Point(96, 112);
			this.txtWindowText.Name = "txtWindowText";
			this.txtWindowText.Size = new System.Drawing.Size(184, 25);
			this.txtWindowText.TabIndex = 2;
			this.txtWindowText.Text = "未命名 - 記事本";
			// 
			// btnFindWindowAdnClose
			// 
			this.btnFindWindowAdnClose.Location = new System.Drawing.Point(24, 160);
			this.btnFindWindowAdnClose.Name = "btnFindWindowAdnClose";
			this.btnFindWindowAdnClose.Size = new System.Drawing.Size(152, 48);
			this.btnFindWindowAdnClose.TabIndex = 3;
			this.btnFindWindowAdnClose.Text = "尋找視窗並關閉";
			this.btnFindWindowAdnClose.Click += new System.EventHandler(this.btnFindWindowAdnClose_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.btnFindWindowAdnClose);
			this.Controls.Add(this.txtWindowText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "SendMessage demo";
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

		[DllImport("User32.dll", EntryPoint="SendMessageW")]
		static extern int SendMessage(IntPtr hwnd, int wMsg, int wparam, int lparam);

		const int WM_CLOSE = 16;

		private void button1_Click(object sender, System.EventArgs e)
		{
			SendMessage(this.Handle, WM_CLOSE, 0, 0);
		}

		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		private void btnFindWindowAdnClose_Click(object sender, System.EventArgs e)
		{
			IntPtr handle = FindWindow(null, txtWindowText.Text);
			if (handle != IntPtr.Zero) 
			{
				SendMessage(handle, WM_CLOSE, 0, 0);
			}
		}



	}
}
