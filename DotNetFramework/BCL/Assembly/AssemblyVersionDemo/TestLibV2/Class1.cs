using System;
using System.Reflection;
using System.Windows.Forms;

namespace TestLib
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Class1
	{
		public Class1()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void ShowVersion() 
		{
			MessageBox.Show("組件版本為: " + Assembly.GetExecutingAssembly().GetName().Version);
		}
	}
}
