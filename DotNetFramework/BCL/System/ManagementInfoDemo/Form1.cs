using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Management;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
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
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(16, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(544, 439);
			this.listBox1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(592, 482);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.Name = "Form1";
			this.Text = "System Management Information Demo by Huan-Lin Tsai.";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		void GetMyDNSDomain()

		{
			try
			{
				ManagementObjectSearcher query = new ManagementObjectSearcher(
					"SELECT * from Win32_NetworkAdapterConfiguration WHERE IPEnabled=true");
				ManagementObjectCollection queryCollection = query.Get();

				// If the following loop produces more than one then it is decision time. 
				// If it produces none then it is "ask the user" time.
				foreach (ManagementObject mo in queryCollection)
				{
					foreach (PropertyData pd in mo.Properties)
					{
						listBox1.Items.Add(pd.Name + " = " + pd.Value);
						if (pd.Value is String[]) 
						{
							String[] values = pd.Value as String[];
							String s = "";
							for (int i = 0; i < values.Length; i++)
							{
								listBox1.Items.Add("    " + values[i]);
							}
						}
					}
				} 		
			}
			catch (Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			GetMyDNSDomain();
		}
	}
}
