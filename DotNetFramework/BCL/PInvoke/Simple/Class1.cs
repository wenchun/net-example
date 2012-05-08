using System;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvoke
{
	class Class1
	{
		[DllImport("user32", EntryPoint="MessageBox", SetLastError=true)]
			public static extern uint MessageBox(int hWnd, string text, string caption, uint type);
		[DllImport("kernel32.dll")]
      public static extern uint GetTempPath(uint bufLen, [Out] StringBuilder buf);
		
		// 註：GetTempPath 的函式原型為：
		// DWORD GetTempPath(DWORD nBufferLength, LPTSTR lpBuffer);

    /// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			MessageBox(0, "Hello, world!", "PInvoke 測試", 0);
			int errCode = Marshal.GetLastWin32Error();
			errCode = Marshal.GetLastWin32Error();
			Console.WriteLine("Error code: " + errCode);

			StringBuilder sb = new StringBuilder();
			GetTempPath(255, sb);
			Console.WriteLine("Temp path is: " + sb.ToString());
		}
	}
}
