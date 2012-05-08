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
				// �H�������D�ӴM�����.
				IntPtr hwnd = FindWindow(null, "OneInstanceApp");
				if (hwnd == IntPtr.Zero)
					throw new Exception("�䤣�����!");
				
				// �����N������]�w���e������.
				SetForegroundWindow(hwnd);

				// �M�ᵲ���ۤv.
				return;
			}
			Application.Run(new Form1());
		}


		/*
		 *  �ŧi�n�ϥΪ� Win32 API �禡
		 */

		[DllImport("user32.dll", SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		/*
		 * �ˬd���ε{���O�_�w�g�s�b�� code�]�Q�Τ᥸���^.
		 */ 

		static Mutex mutex;  
		static string AppID = "DemoOneInstanceApp";  // �Ψ��ѧO���ε{�����ߤ@�r��.

		static bool HasInstance()
		{
			bool isNew;
			mutex = new Mutex(false, AppID, out isNew);
			if (isNew)	// �p�G�O�s�إߪ��᥸���A�N�����ε{���O�Ĥ@������.
				return false;
			
			return true;
		}
	}
}
