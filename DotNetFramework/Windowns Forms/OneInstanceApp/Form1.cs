using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;

namespace OneInstanceApp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.Text = "OneInstanceApp";

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			if (Form1.HasInstance()) 
			{
				// 以視窗標題來尋找視窗.
				IntPtr hwnd = FindWindow(null, "OneInstanceApp");
				if (hwnd == IntPtr.Zero)
					throw new Exception("找不到視窗!");
				
				// 有找到就把視窗設定為前景視窗.
				SetForegroundWindow(hwnd);

				// 然後結束自己.
				return;
			}
			Application.Run(new Form1());
		}


		/*
		 *  宣告要使用的 Win32 API 函式
		 */

		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		/*
		 * 檢查應用程式是否已經存在的 code（利用戶斥器）.
		 */ 

		static Mutex mutex;  
		static string AppID = "DemoOneInstanceApp";  // 用來識別應用程式的唯一字串.

		static bool HasInstance()
		{
			bool isNew;
			mutex = new Mutex(false, AppID, out isNew);
			if (isNew)	// 如果是新建立的戶斥器，代表應用程式是第一次執行.
				return false;
			
			return true;
		}
	}
}
