using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace AsyncDemo_UpdateUI2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.CheckBox ctxCheckInvokeRequired;
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
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.ctxCheckInvokeRequired = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(56, 56);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(264, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 112);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 24);
			this.label1.Name = "label1";
			this.label1.TabIndex = 2;
			this.label1.Text = "label1";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(160, 112);
			this.button2.Name = "button2";
			this.button2.TabIndex = 3;
			this.button2.Text = "button2";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(56, 160);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(288, 23);
			this.label.TabIndex = 4;
			this.label.Text = "label2";
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(64, 208);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(352, 208);
			this.listBox1.TabIndex = 5;
			// 
			// ctxCheckInvokeRequired
			// 
			this.ctxCheckInvokeRequired.Location = new System.Drawing.Point(280, 112);
			this.ctxCheckInvokeRequired.Name = "ctxCheckInvokeRequired";
			this.ctxCheckInvokeRequired.Size = new System.Drawing.Size(144, 24);
			this.ctxCheckInvokeRequired.TabIndex = 6;
			this.ctxCheckInvokeRequired.Text = "Check InvokeRequired";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(592, 450);
			this.Controls.Add(this.ctxCheckInvokeRequired);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.label);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.progressBar1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion


		private void OnWorkCompleted(IAsyncResult arIntf)
		{
			UpdateUI();
		}

		public void UpdateUI()
		{
			for (int i = 100; i > 0; i--) 
			{
				this.progressBar1.Value = i;
				this.label1.Text = Thread.CurrentThread.GetHashCode() + ": " + i.ToString();
				Thread.Sleep(10);
			}			
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Text = Thread.CurrentThread.GetHashCode().ToString();

			Thread t1 = new Thread(new ThreadStart(this.UpdateUI));
			t1.Start();

			Worker peter = new Worker();
			AsyncCallback cb = new AsyncCallback(this.OnWorkCompleted);
			IAsyncResult ar = peter.BeginWork(cb, null);
			progressBar1.Value = 30;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Thread.CurrentThread.Name = "UI thread";
			listBox1.Items.Clear();
			Thread t = new Thread(new ThreadStart(ChangeLabel));
			t.Name = "Worker thread";
			t.Start();

			Random r = new Random(10);
			for (int i = 0; i <= 100; ++i)
			{
//				SetLabelText(i);
//				Thread.Sleep(200);
			}
		}

		private void ChangeLabel()
		{
			for (int i = 0; i < 10; ++i)
			{
				SetLabelText(i);
				Thread.Sleep(200);
			}
		}

		private delegate void SetLabelTextDelegate(int number);

		private void Test(int number)
		{
			listBox1.Items.Add(Thread.CurrentThread.Name + " : " + number.ToString());
		}


		private void SetLabelText(int number)
		{
			//label.Text = number.ToString();
			// Do NOT do this, as we are on a different thread.

			if (ctxCheckInvokeRequired.Checked) 
				this.BeginInvoke(new SetLabelTextDelegate(Test), 
					new object[] {number});
			else
				Test(number);
/*

			if (ctxCheckInvokeRequired.Checked) 
			{
				// Check if we need to call BeginInvoke.
				if (this.InvokeRequired)
				{
					// Pass the same function to BeginInvoke,
					// but the call would come on the correct
					// thread and InvokeRequired will be false.
					this.BeginInvoke(new SetLabelTextDelegate(SetLabelText), 
						new object[] {number});

					return;
				}
			}

			label.Text = number.ToString();
			progressBar1.Value = number;
			listBox1.Items.Add(Thread.CurrentThread.Name + " : " + number.ToString());
*/			
		}
	}
}
