using System;

namespace StrFormatDemo
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// �榡�Ƥ���ɶ�
			string codes = "FfGgsuURDdYMTt";
			DateTime now = DateTime.Now;
			for (int i = 0; i < codes.Length; i++)
			{
				string fmt = "Format: " + codes[i] + " ==> {0:" + codes[i] + "}";
				Console.WriteLine(fmt, now);                
			}
			Console.WriteLine("{0:yyyy/MM/dd}", now);
			Console.WriteLine("{0:hh:mm:ss:ms}", now);
		}
	}
}
