using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq101Demo
{
	public class DelayedExecutionDemo
	{
		public void Run()
		{
			Console.WriteLine("!CLEAR");
			Console.WriteLine("===展示 LINQ 的延遲查詢===");

			Console.WriteLine("\r\n結果 1:");
			int[] numbers = {3, 5, 6, 7, 8, 2};

			int i = 0;

			var r = from num in numbers
					select ++i;
	
			foreach (var n in r)
			{
				Console.WriteLine("n={0}, i={1}", n, i);
			}

			Console.WriteLine("\r\n結果 2:");
			i = 0;
			r = r.ToList();	// 注意這行所造成的差異!!

			foreach (var n in r)
			{
				Console.WriteLine("n={0}, i={1}", n, i);
			}
		}
	}
}
