using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace CRDemo01_TypedRpt
{
	/// <summary>
	/// Summary description for Report1Form.
	/// </summary>
	public class Report1Form : System.Windows.Forms.Form
	{
		private string serverName;
		private string userName;
		private string password;

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.ComponentModel.IContainer components;

		public Report1Form()
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
				if(components != null)
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
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.DisplayGroupTree = false;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer1.EnableDrillDown = false;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = null;
			this.crystalReportViewer1.Size = new System.Drawing.Size(728, 466);
			this.crystalReportViewer1.TabIndex = 0;
			// 
			// Report1Form
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(728, 466);
			this.Controls.Add(this.crystalReportViewer1);
			this.Name = "Report1Form";
			this.Text = "Report1Form";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Report1Form_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void Report1Form_Load(object sender, System.EventArgs e)
		{
			string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			ReportDocument report1 = new ReportDocument();
			report1.Load(dir + @"\Report1.rpt");
			report1.SetDatabaseLogon(this.userName, this.password, this.serverName, "Northwind");
			crystalReportViewer1.ReportSource = report1;
		}

		public Report1Form(string serverName, string userName, string password) : this()
		{
			this.serverName = serverName;
			this.userName = userName;
			this.password = password;
		}
	}
}
