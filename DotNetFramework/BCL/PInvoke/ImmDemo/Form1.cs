using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace ImmDemo
{

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

		[DllImport("Imm32.dll", CharSet=CharSet.Ansi, SetLastError=true)]
      public static extern int ImmGetConversionList(IntPtr hKL, IntPtr hImc, string lpSrc, IntPtr lpDst, int dwBufLen, int uFlag);

		[DllImport("Imm32.dll", CharSet=CharSet.Ansi, SetLastError=true)]
			public static extern IntPtr ImmGetContext(IntPtr hWnd);

		[DllImport("Imm32.dll", CharSet=CharSet.Ansi, SetLastError=true)]
			public static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hImc);
		
		[DllImport("user32.dll", CharSet=CharSet.Ansi, SetLastError=true)]
			public static extern IntPtr GetKeyboardLayout(int dwLayout);

		const int GCL_REVERSECONVERSION = 0x0002;
		[StructLayout(LayoutKind.Sequential)]
			public class CANDIDATELIST
		{
			public int  dwSize;
			public int  dwStyle;
			public int  dwCount;
			public int  dwSelection;
			public int  dwPageStart;
			public int  dwPageSize;
			public int  dwOffset;
		}



		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;


		public string[] GetReverseConversion(IntPtr AHwnd, string AText)
		{
			string[] strList = null;
			IntPtr hIMC = ImmGetContext(AHwnd);
			IntPtr hKL = GetKeyboardLayout(0);
			if ((hIMC != IntPtr.Zero)&&(hKL != IntPtr.Zero))
			{
				CANDIDATELIST list = new CANDIDATELIST();
				int dwSize = ImmGetConversionList(hKL,hIMC,AText,IntPtr.Zero,0,GCL_REVERSECONVERSION);
				if (dwSize > 0)
				{
					IntPtr BufList = Marshal.AllocHGlobal(dwSize);
					ImmGetConversionList(hKL,hIMC,AText,BufList,dwSize,GCL_REVERSECONVERSION);
					Marshal.PtrToStructure(BufList,list);
					byte[] buf = new byte[dwSize];
					Marshal.Copy(BufList,buf,0,dwSize);
					Marshal.FreeHGlobal(BufList);
					int offset = list.dwOffset;
					string str = System.Text.Encoding.Default.GetString(buf, offset, buf.Length-offset);

					str = Regex.Replace(str,@"\0+$","");
					char[] par = "\0".ToCharArray();
					strList = str.Split(par);
					ImmReleaseContext(this.Handle,hIMC);
				}
			}
			return strList;
		}


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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(248, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "取得注音碼";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(144, 25);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "測試";
			// 
			// listBox1
			// 
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(16, 152);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(248, 94);
			this.listBox1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 120);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "注音碼：";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.TabIndex = 4;
			this.label2.Text = "輸入中文字：";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
			this.ClientSize = new System.Drawing.Size(288, 269);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("PMingLiU", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(136)));
			this.Name = "Form1";
			this.Text = "IMM API Demo by Huan-Lin Tsai";
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
			string[] strList = GetReverseConversion(textBox1.Handle, textBox1.Text);
			listBox1.Items.Clear();
			listBox1.Items.Add(strList[0]);
		}
	}
}
