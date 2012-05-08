using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace AsyncDemo1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSync;
		private System.Windows.Forms.Button btnAsync;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblState;
		private System.Windows.Forms.Button button1;
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
			this.btnSync = new System.Windows.Forms.Button();
			this.btnAsync = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblState = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSync
			// 
			this.btnSync.Location = new System.Drawing.Point(40, 24);
			this.btnSync.Name = "btnSync";
			this.btnSync.Size = new System.Drawing.Size(136, 40);
			this.btnSync.TabIndex = 0;
			this.btnSync.Text = "�P�B�I�s";
			this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
			// 
			// btnAsync
			// 
			this.btnAsync.Location = new System.Drawing.Point(200, 24);
			this.btnAsync.Name = "btnAsync";
			this.btnAsync.Size = new System.Drawing.Size(136, 40);
			this.btnAsync.TabIndex = 1;
			this.btnAsync.Text = "�D�P�B�I�s";
			this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(112, 184);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(128, 120);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(40, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "���U���s��A�ݬݯण�ಾ�ʵ���";
			// 
			// lblState
			// 
			this.lblState.ForeColor = System.Drawing.Color.Green;
			this.lblState.Location = new System.Drawing.Point(48, 128);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(272, 32);
			this.lblState.TabIndex = 4;
			this.lblState.Text = "���檬�A";
			this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(280, 192);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(136, 40);
			this.button1.TabIndex = 5;
			this.button1.Text = "�D�P�B�I�s2";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(9, 24);
			this.ClientSize = new System.Drawing.Size(456, 330);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lblState);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnAsync);
			this.Controls.Add(this.btnSync);
			this.Font = new System.Drawing.Font("PMingLiU", 15F);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AsyncDemo1";
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

		private void btnSync_Click(object sender, System.EventArgs e)
		{
			Worker peter = new Worker();
			lblState.Text = "���b�ǰe�ɮ�....";
			lblState.ForeColor = Color.Red;
			Application.DoEvents();
			peter.Work();
			lblState.Text = "�ɮ׶ǰe�����C";
			lblState.ForeColor = Color.Green;
		}

		private void btnAsync_Click(object sender, System.EventArgs e)
		{
			lblState.Text = "(2) ���b�ǰe�ɮ�....";
			lblState.ForeColor = Color.Red;

			Worker peter = new Worker();
			WorkEventHandler working = null;
			working += new WorkEventHandler(peter.Work);
			AsyncCallback cb = new AsyncCallback(this.WorkComplete);
			working.BeginInvoke(cb, null);
		}

		private void WorkComplete(IAsyncResult ar) 
		{
			// �����Ӧb�D�P�B��k�� completion callback method �̭���s UI
			// �o�̥u�O�i�ܥΡAshould be fine.
			lblState.Text = "�ɮ׶ǰe�����C";
			lblState.ForeColor = Color.Green;
		}

		private void UpdateUI()
		{
			// �����Ӧb�D�P�B��k�� completion callback method �̭���s UI
			// �o�̥u�O�i�ܥΡAshould be fine.
			lblState.Text = "(2) �ɮ׶ǰe�����C";
			lblState.ForeColor = Color.Green;
		}

		private void WorkComplete2(IAsyncResult ar) 
		{
			MethodInvoker mi = new MethodInvoker(this.UpdateUI);
			this.BeginInvoke(mi);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			lblState.Text = "���b�ǰe�ɮ�....";
			lblState.ForeColor = Color.Red;

			Worker peter = new Worker();
			AsyncCallback cb = new AsyncCallback(this.WorkComplete);
			peter.BeginWork(cb, null);
		}
	}

	public delegate void WorkEventHandler();

	class Worker 
	{
		public void Work() 
		{
			Thread.Sleep(7000);
		}

		public void BeginWork(AsyncCallback cb, object userData) 
		{
			WorkEventHandler working = null;
			working += new WorkEventHandler(this.Work);
			working.BeginInvoke(cb, userData);
		}

		public void EndWork(IAsyncResult ar)
		{
			AsyncResult arObj = (AsyncResult) ar;
			WorkEventHandler working = (WorkEventHandler) arObj.AsyncDelegate;
			working.EndInvoke(ar);
		}
	}

}
