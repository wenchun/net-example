using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using PluginInterface;

namespace MainApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCustomer;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
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
			this.btnCustomer = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCustomer
			// 
			this.btnCustomer.Location = new System.Drawing.Point(56, 62);
			this.btnCustomer.Name = "btnCustomer";
			this.btnCustomer.Size = new System.Drawing.Size(136, 35);
			this.btnCustomer.TabIndex = 0;
			this.btnCustomer.Text = "客戶基本資料維護";
			this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 288);
			this.Controls.Add(this.btnCustomer);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void OpenPluginForm(string dllName, string className, object param) 
		{
			// 裡用類別工廠載入 DLL，並建立 plugin form 物件。
			IPlugin plugin = PluginFactory.CreatePlugin(dllName, className);

			// 呼叫 plugin form 實作的 Initialize 方法以傳遞初始化參數。
			plugin.Initialize(this, param); 
			((Form)plugin).ShowDialog(); // 顯示 plugin form。
		}

		private void btnCustomer_Click(object sender, System.EventArgs e)
		{
			OpenPluginForm("Customer.dll", "CustomerForm", "Hello");
		}
	}
}
