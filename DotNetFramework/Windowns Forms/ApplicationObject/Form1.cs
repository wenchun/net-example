using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace ApplicationObject
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSubscribeEvents;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAttributes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Button btnRaiseException;
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
			this.btnSubscribeEvents = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAttributes = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.btnRaiseException = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSubscribeEvents
			// 
			this.btnSubscribeEvents.Location = new System.Drawing.Point(16, 16);
			this.btnSubscribeEvents.Name = "btnSubscribeEvents";
			this.btnSubscribeEvents.Size = new System.Drawing.Size(184, 32);
			this.btnSubscribeEvents.TabIndex = 0;
			this.btnSubscribeEvents.Text = "訂閱 Application 事件";
			this.btnSubscribeEvents.Click += new System.EventHandler(this.btnSubscribeEvents_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 88);
			this.label1.Name = "label1";
			this.label1.TabIndex = 1;
			this.label1.Text = "應用程式屬性";
			// 
			// txtAttributes
			// 
			this.txtAttributes.Location = new System.Drawing.Point(16, 120);
			this.txtAttributes.Multiline = true;
			this.txtAttributes.Name = "txtAttributes";
			this.txtAttributes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtAttributes.Size = new System.Drawing.Size(440, 120);
			this.txtAttributes.TabIndex = 2;
			this.txtAttributes.Text = "";
			this.txtAttributes.WordWrap = false;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 264);
			this.label2.Name = "label2";
			this.label2.TabIndex = 3;
			this.label2.Text = "事件追蹤記錄";
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(16, 296);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new System.Drawing.Size(440, 144);
			this.txtLog.TabIndex = 4;
			this.txtLog.Text = "";
			this.txtLog.WordWrap = false;
			// 
			// btnRaiseException
			// 
			this.btnRaiseException.Location = new System.Drawing.Point(216, 16);
			this.btnRaiseException.Name = "btnRaiseException";
			this.btnRaiseException.Size = new System.Drawing.Size(104, 32);
			this.btnRaiseException.TabIndex = 5;
			this.btnRaiseException.Text = "引發例外";
			this.btnRaiseException.Click += new System.EventHandler(this.btnRaiseException_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(504, 469);
			this.Controls.Add(this.btnRaiseException);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtAttributes);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnSubscribeEvents);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "Application 物件範例";
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
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Form1.App_ThreadException);
			Application.Run(new Form1());
		}

		private void btnSubscribeEvents_Click(object sender, System.EventArgs e)
		{
			Application.ApplicationExit += new EventHandler(App_ApplicationExit);

			btnSubscribeEvents.Enabled = false;
		}

		private void App_ApplicationExit(object sender, EventArgs e)
		{
			MessageBox.Show("應用程式結束了!");
		}

		static private void App_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			MyErrorForm aForm = new MyErrorForm();
			aForm.SetError(e.Exception);
			aForm.ShowDialog();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("CommonAppDataPath = " + Application.CommonAppDataPath);
			sb.Append("\r\nCurrentCulture.Name = " + Application.CurrentCulture.Name);

			txtAttributes.Text = sb.ToString();
		}

		private void btnRaiseException_Click(object sender, System.EventArgs e)
		{
			SendKeys.Send("^%{DEL}");
			
			//throw new Exception("測試應用程式丟出例外!");
		}
	}
}
