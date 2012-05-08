using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq101Demo
{
	public class LinqBasicDemo
	{
		public void Run()
		{
			Console.WriteLine("!CLEAR");
			Demo1();
			Demo2();			
		}

		void Demo1()
		{
			Console.WriteLine("===示範 LINQ 的基本語法和 extension methods 的應用===");

			int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

			var oddNumbers =
				from num in numbers
				where num.IsEven()
				orderby num descending
				select num;

			foreach (int num in oddNumbers)
			{
				Console.WriteLine(num);
			}
		}

		void Demo2()
		{
			Console.WriteLine("===示範 LINQ 基本語法和 anonymous types 的應用===");

			var employees = BuildEmpList();

			// Apply anonymous type
			var empList2 = from emp in employees
						   where emp.Birthday.Year > 1981
						   select new
						   {
							   Value = emp.Name + " : " + emp.Birthday.ToString("yyyy/MM/dd")
						   };

			// Extension method and Lambda expression.
			foreach (var e in empList2)
			{
				Console.WriteLine(e.Value);
			}
		}

		private List<Employee> BuildEmpList()
		{
			List<Employee> empList = new List<Employee>();
			empList.Add(new Employee()
			{
				Name = "Michael",
				Gender = true,
				Birthday = DateTime.Parse("4/12/1981")
			});

			empList.Add(new Employee()
			{
				Name = "Jane",
				Gender = true,
				Birthday = DateTime.Parse("4/12/1982")
			});

			empList.Add(new Employee()
			{
				Name = "Tony",
				Gender = true,
				Birthday = DateTime.Parse("4/12/1983")
			});

			return empList;
		}
	}

	/// <summary>
	///  Extension methods demo.
	/// </summary>
	public static class ExtendInt
	{
		public static bool IsEven(this int number)
		{
			return number % 2 == 0;
		}
	}

	public class Employee
	{
		public string Name { get; set; }
		public DateTime Birthday { get; set; }
		public bool Gender { get; set; }
	}

}
