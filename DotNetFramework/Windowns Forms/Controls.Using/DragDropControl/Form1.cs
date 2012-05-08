using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DragDropControl
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 15;
			this.listBox1.Items.AddRange(new object[] {
																		"Apple",
																		"Banana",
																		"Watermelon"});
			this.listBox1.Location = new System.Drawing.Point(24, 80);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(128, 169);
			this.listBox1.TabIndex = 0;
			this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
			// 
			// listBox2
			// 
			this.listBox2.AllowDrop = true;
			this.listBox2.ItemHeight = 15;
			this.listBox2.Location = new System.Drawing.Point(184, 80);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(136, 169);
			this.listBox2.TabIndex = 1;
			this.listBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox2_DragDrop);
			this.listBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox2_DragEnter);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "把左邊的清單盒項目拖曳到右邊，可使用 Ctrl  鍵進行複製。";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(344, 269);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("PMingLiU", 11F);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "範例：控制項的拖曳";
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

		private void listBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{	
			int idx = listBox1.SelectedIndex;
			if (idx < 0)
				return;
			string s = (string) listBox1.Items[idx];			

			// 執行拖曳.
			DragDropEffects effect = listBox1.DoDragDrop(s,			// 拖曳過去的物件.
					DragDropEffects.Move | DragDropEffects.Copy);	// 允許哪些拖曳效果.

			// 等到完成拖曳動作時會返回到這裡.
			if (effect == DragDropEffects.Move) 
			{
				listBox1.Items.RemoveAt(idx);
			}
		}

		private void listBox2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{	
			e.Effect = DragDropEffects.None;

			// 確保拖曳進來的物件型別是 string.
			if (e.Data.GetDataPresent(typeof(string)))
			{
				if (e.KeyState == 9)	// 9 代表滑鼠左鍵(1) 和 Ctrl 鍵(8) 同時按下.
				{ 
					e.Effect = DragDropEffects.Copy;
				}
				else 
				{
					e.Effect = DragDropEffects.Move;
				}
			}
		}

		private void listBox2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string s = (string) e.Data.GetData(typeof(string));
			listBox2.Items.Add(s);
		}
	}
}
