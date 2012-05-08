using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace TraceDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lblTraceLevel;
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
			this.button2 = new System.Windows.Forms.Button();
			this.lblTraceLevel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(104, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "TraceListener";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(24, 120);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 40);
			this.button2.TabIndex = 1;
			this.button2.Text = "TraceSwitch";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lblTraceLevel
			// 
			this.lblTraceLevel.Location = new System.Drawing.Point(24, 16);
			this.lblTraceLevel.Name = "lblTraceLevel";
			this.lblTraceLevel.TabIndex = 2;
			this.lblTraceLevel.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.lblTraceLevel);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.Text = "Form1";
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

		static TraceSwitch mySwitch = new TraceSwitch("mySwitch", "我的追蹤開關");

		private void button1_Click(object sender, System.EventArgs e)
		{
			//Trace.Listeners.Add(new EventLogTraceListener("TraceDemo"));
            
			Trace.Listeners.Add(new TextWriterTraceListener(@"c:\test.log"));
            
			Trace.WriteLineIf(mySwitch.TraceWarning, "Warning...");
			Trace.WriteLineIf(mySwitch.TraceError, "Error....");
			Trace.WriteLineIf(mySwitch.TraceInfo, "Info....");
            
			Trace.Flush();
			Trace.Close();
			Trace.Listeners.Clear();

			// 以上的 Trace 物件也都可以用 Debug 物件，只是 Release Build 就沒作用了。
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Trace.WriteLineIf(mySwitch.TraceError, "Error message");
			Trace.WriteLineIf(mySwitch.TraceWarning, "Warning message");
			Trace.WriteLineIf(mySwitch.TraceInfo, "Info message");
			Trace.WriteLineIf(mySwitch.TraceVerbose, "Verbose message...");

			// Release build 不會輸出 debug 訊息（編譯時就略過了）
			Debug.WriteLineIf(mySwitch.TraceError, "Debug error msg");
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			lblTraceLevel.Text = mySwitch.Level.ToString();
		}
	}
}
