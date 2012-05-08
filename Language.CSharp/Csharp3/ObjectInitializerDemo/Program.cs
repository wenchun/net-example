using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectInitializerDemo
{
	public class Employee
	{
		public string Name	// 這是一個 auto-implementation property.
		{
			get;
			set;
		}

		public int Age		// 這也是個 auto-implementation property.
		{
			get;
			set;	// 若改為 private set（即 read only），object initializer 也無法設定此屬性.
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			// 示範 object initializer 寫法
			Employee emp = new Employee
			{	
				Name = "Michael",
				Age = 20
			};
		}
	}
}
