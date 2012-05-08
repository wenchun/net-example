using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginInterface;

namespace MyLib
{
	public class MyClass : IPlugin
	{
		public void Execute()
		{
			System.Windows.Forms.MessageBox.Show("Hello from MyLib.dll");
		}
	}
}
