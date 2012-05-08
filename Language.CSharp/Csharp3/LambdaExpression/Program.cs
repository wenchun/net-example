using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExpression
{
	class Employee
	{
		// 自動實作屬性.
		public string Name { get; set; }
		public int Age { get; set; }
	}

	class LambdaDemo
	{
		public void Run()
		{
			var empList = new List<Employee>()	// 隱含型別 
			{	// Object initializers（串列和 Employee 物件都有）.
				new Employee { Name = "Michael Tsai", Age = 20 },	
				new Employee { Name = "Douglas Joe", Age = 25 },
				new Employee { Name = "Jenifer Chen", Age = 14 }
			};

			// 各種寫法（逐漸簡化）
			Predicate<Employee> p1 = delegate(Employee e)    { return e.Name.StartsWith("J"); };
			Predicate<Employee> p2 =                  (e) => { return e.Name.StartsWith("J"); };
			Predicate<Employee> p3 =                   e  => { return e.Name.StartsWith("J"); };
			Predicate<Employee> p4 =                   e  =>          e.Name.StartsWith("J")   ;

			Predicate<Employee> p = e => e.Name.StartsWith("J");	// Lambda expression
			Employee emp = empList.Find(p);
			Console.WriteLine(emp.Name);
		}
	}

	class LambdaDemo2
	{
		public void Run()
		{
			var empList = new List<Employee>()	
			{	
				new Employee { Name = "Michael", Age = 20 },	
				new Employee { Name = "Douglas", Age = 25 },
				new Employee { Name = "Jenifer", Age = 14 }
			};

			var names = empList.Where<Employee>(e => e.Name.Contains("i"))
							   .OrderBy<Employee, int>(e => e.Age)
							   .Select<Employee, string>(e => e.Name);
			
			foreach (string s in names)
			{
				Console.WriteLine(s);
			}
		}
	}

	class LinqDemo
	{
		public void Run()
		{
			var empList = new List<Employee>()	
			{	
				new Employee { Name = "Michael", Age = 20 },	
				new Employee { Name = "Douglas", Age = 25 },
				new Employee { Name = "Jenifer", Age = 14 }
			};
		
			var names = 
				from e in empList
				where e.Name.Contains("i")
				orderby e.Age
				select e.Name;

			foreach (string s in names)
			{
				Console.WriteLine(s);
			}
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			LambdaDemo demo = new LambdaDemo();
			demo.Run();

			LambdaDemo2 demo2 = new LambdaDemo2();
			demo2.Run();

			LinqDemo linq = new LinqDemo();
			linq.Run();
		}
	}
}
