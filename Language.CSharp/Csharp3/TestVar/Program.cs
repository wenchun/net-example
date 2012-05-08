using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var i = 10;
			string s = "hello" + i;

			Console.WriteLine(s);

			var numbers = new[] { 10, 20, 30, 40 };

			foreach (var x in numbers) 
			{
				Console.WriteLine(x);
			}

			var k = default(int);
			Console.WriteLine(k);
		}
	}


}
