using System;
using System.IO;
using System.Security;

namespace ConsoleApplication3
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
			try 
			{
				FileStream fs = new FileStream(@"c:\log.txt", FileMode.Create, FileAccess.ReadWrite);
				Console.WriteLine("Ok!");
			}
			catch (SecurityException ex) 
			{
				//Console.WriteLine(ex.PermissionType.FullName);
				throw ex;
			}
		}
	}
}
