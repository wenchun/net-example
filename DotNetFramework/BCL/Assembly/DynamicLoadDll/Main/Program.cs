using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Main
{
	class Program
	{
		static void Main(string[] args)
		{
			Assembly asmb = Assembly.LoadFrom("MyLib.dll");
            dynamic obj = asmb.CreateInstance("MyLib.MyClass");
			obj.Execute();
		}
	}
}
