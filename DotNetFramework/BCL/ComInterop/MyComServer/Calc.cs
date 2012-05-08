using System;
using System.Runtime.InteropServices;

namespace ComServer
{

	[ClassInterface(ClassInterfaceType.AutoDual)]
	[GuidAttribute("36769EE1-E3A2-4a93-8C07-631BAF635BE7")]

	public class Calc
	{
		public Calc()
		{
		}

		public int Add(int num1, int num2) 
		{
			return num1 + num2;
		}
	}
}
