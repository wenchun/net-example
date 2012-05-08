using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Diagnostics;

namespace AsyncDemo_UpdateUI
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.RadioButton rdoInvoke;
		private System.Windows.Forms.RadioButton rdoBeginInvoke;
		private System.Windows.Forms.CheckBox chkAsyncUpdateUI;
		private System.Windows.Forms.Label label1;
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.chkAsyncUpdateUI = new System.Windows.Forms.CheckBox();
			this.rdoInvoke = new System.Windows.Forms.RadioButton();
			this.rdoBeginInvoke = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(32, 128);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "Go";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(224, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(240, 229);
			this.listBox1.TabIndex = 5;
			// 
			// chkAsyncUpdateUI
			// 
			this.chkAsyncUpdateUI.Location = new System.Drawing.Point(32, 24);
			this.chkAsyncUpdateUI.Name = "chkAsyncUpdateUI";
			this.chkAsyncUpdateUI.Size = new System.Drawing.Size(144, 24);
			this.chkAsyncUpdateUI.TabIndex = 6;
			this.chkAsyncUpdateUI.Text = "非同步更新 UI";
			this.chkAsyncUpdateUI.CheckedChanged += new System.EventHandler(this.chkAsyncUpdateUI_CheckedChanged);
			// 
			// rdoInvoke
			// 
			this.rdoInvoke.Checked = true;
			this.rdoInvoke.Enabled = false;
			this.rdoInvoke.Location = new System.Drawing.Point(72, 56);
			this.rdoInvoke.Name = "rdoInvoke";
			this.rdoInvoke.TabIndex = 7;
			this.rdoInvoke.TabStop = true;
			this.rdoInvoke.Text = "Invoke()";
			// 
			// rdoBeginInvoke
			// 
			this.rdoBeginInvoke.Enabled = false;
			this.rdoBeginInvoke.Location = new System.Drawing.Point(72, 88);
			this.rdoBeginInvoke.Name = "rdoBeginInvoke";
			this.rdoBeginInvoke.TabIndex = 8;
			this.rdoBeginInvoke.Text = "BeginInvoke";
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(24, 176);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 72);
			this.label1.TabIndex = 9;
			this.label1.Text = "注意切換 \"非同步更新UI\" 選項時，ListBox 內顯示的執行緒名稱。";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(512, 282);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.rdoBeginInvoke);
			this.Controls.Add(this.rdoInvoke);
			this.Controls.Add(this.chkAsyncUpdateUI);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.Name = "Form1";
			this.Text = "Asynchronous update UI example by Huan-Lin Tsai";
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (!"UI thread".Equals(Thread.CurrentThread.Name))
			{
				Thread.CurrentThread.Name = "UI thread";
			}
			listBox1.Items.Clear();
			Thread t1 = new Thread(new ThreadStart(ThreadMethod));
			t1.Name = "Worker thread";
			t1.Start();

			// 下面這行會導致 t1 執行緒裡面的 this.Invoke() 與
			// 主執行緒相互等待，即 deadlock，程式會當掉。
			t1.Join();
		}

		private void ThreadMethod()
		{
			for (int i = 0; i < 10; ++i)
			{
				AddListBoxItem(i);
				Thread.Sleep(200);
			}
		}

		private delegate void AddListBoxItemDelegate(int number);

		private void UpdateUI(int number)
		{
			listBox1.Items.Add(Thread.CurrentThread.Name + " : " + number.ToString());
		}


		private void AddListBoxItem(int number)
		{
			if (chkAsyncUpdateUI.Checked) 
			{
				Debug.Assert(InvokeRequired == true, "InvokeRequired is not true!");

				if (rdoInvoke.Checked) 
				{
					this.Invoke(new AddListBoxItemDelegate(UpdateUI), new object[] {number});
				}
				else
				{
					this.BeginInvoke(new AddListBoxItemDelegate(UpdateUI), new object[] {number});
				}
			}
			else // 以同步方式呼叫 UpdateUI
			{
				UpdateUI(number); // Do NOT do this, as we are on a different thread.
			}
		}

		private void chkAsyncUpdateUI_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkAsyncUpdateUI.Checked) 
			{
				rdoInvoke.Enabled = true;
				rdoBeginInvoke.Enabled = true;
			}
			else
			{
				rdoInvoke.Enabled = false;
				rdoBeginInvoke.Enabled = false;
			}
		}
	}
}
