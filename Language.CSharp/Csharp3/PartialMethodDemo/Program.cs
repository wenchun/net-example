using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartialMethodDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			PrintService svc = new PrintService();
			svc.Print();
		}
	}

	public partial class PrintService
	{
		partial void DoPrint();
		partial void DoPrint2();

		// partial methods 隱含是 private，所以要加一個公開方法來測試.
		public void Print()
		{
			DoPrint();
			DoPrint2();	// 此方法沒有實作，編譯器會移除此呼叫.
		}
	}

	public partial class PrintService
	{
		partial void  DoPrint()
		{
			Console.WriteLine("Printed from InternalPrint.");
		}
	}
}
