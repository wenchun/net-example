using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousTypes2
{
	public class EmpInfo
	{
		private string name;
		private DateTime birthday;

		public EmpInfo(string aName, DateTime aBirthday)
		{
			name = aName;
			birthday = aBirthday;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public DateTime Birthday
		{
			get { return birthday; }
			set { birthday = value; }
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("示範 projection initializers 的匿名型別寫法。");

			EmpInfo emp = new EmpInfo("Michael", new DateTime(1971, 1, 1));

			var emp1 = new { emp.Name, emp.Birthday };

			string name = "John";
			int age = 20;

			var emp2 = new { name, age };

			Console.WriteLine("emp1.Name = " + emp1.Name);
			Console.WriteLine("emp2.name = " + emp2.name);

			Console.WriteLine("emp1 的實際型別: " + emp1.GetType());
			Console.WriteLine("emp2 的實際型別: " + emp2.GetType());
		}
	}
}
