using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;

namespace DragDropForm
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form, IMessageFilter
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		// DllImprt �ŧi.
		[DllImport("shell32")]
		static extern int DragQueryFile(
			IntPtr hDrop,
			int iFile,
			StringBuilder lpszFile,
			int cch);

		[DllImport("shell32.dll")]
		static extern void DragAcceptFiles(IntPtr hwnd, bool fAccept);


		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Application.AddMessageFilter(this);
			DragAcceptFiles(this.Handle, true);
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
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(24, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(480, 88);
			this.listBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.label1.Location = new System.Drawing.Point(32, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(296, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "�q�ɮ��`�ީ즲�@�өΦh���ɮר� Form �W";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(536, 229);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "�ܽd�p���� Form �����q�O�����ε{���즲�ɮ׹L��";
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
		
		public bool PreFilterMessage(ref Message m)
		{
			const int WM_DROPFILES = 563;

			if (m.Msg == WM_DROPFILES) 
			{	
				// �����o�즲�L�Ӫ��ɮ׼ƶq.
				int numFiles = DragQueryFile(m.WParam, -1, null, 0);

				// �A�v�@���o�C���ɦW��
				for (int i = 0; i < numFiles; i++)
				{
					// �`�N: StringBuilder �@�w�n�w���t�m�Ŷ��A�_�h�|�o�� overflow.
					StringBuilder sb = new StringBuilder(1024); 
					DragQueryFile(m.WParam, i, sb, 1024);
					listBox1.Items.Add(sb.ToString());
				}
			}
			return false;
		}

		
	}
}
