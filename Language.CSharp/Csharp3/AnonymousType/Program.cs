using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousType
{
	class Program
	{
		static void Main(string[] args)
		{
			var emp1 = new { Name = "Michael", Birthday = new DateTime(1971, 1, 1) };
			var emp2 = new { Name = "Michael", Birth = "1981/12/31" };

			//var mixedAry = new[] { 10, "abc" };   // Error! 編譯器無法決定該採用什麼型別.

			Console.WriteLine("Employee name: " + emp1.Name);
			Console.WriteLine("Birthday: " + emp1.Birthday.ToString());

			Console.WriteLine("emp1 的實際型別是: " + emp1.GetType());
			Console.WriteLine("emp2 的實際型別是: " + emp2.GetType());
		}
	}
}
