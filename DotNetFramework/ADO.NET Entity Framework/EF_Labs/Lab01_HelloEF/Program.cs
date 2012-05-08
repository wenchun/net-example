using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.EntityClient;

namespace Lab01_HelloEF
{
	class Program
	{
		static void Main(string[] args)
		{
			QueryWithObjectServices();

			QueryWithObjectServicesAndLinq();
		}

		static void QueryWithObjectServices() 
		{
			Console.WriteLine("===Query with Object Services===");
			using (AdventureWorksEntities awContext = new AdventureWorksEntities())
			{
				ObjectQuery<Customer> customers = awContext.Customers;
					//awContext.Customers.Where("it.CompanyName like 'A%'").OrderBy("it.CustomerID");

				foreach (Customer cust in customers)
				{
					Console.WriteLine("{0}, {1}", cust.CustomerID, cust.CompanyName);
				}
			}
		}

		static void QueryWithLinqToEntities()
		{
			Console.WriteLine("===Query with Object Services and LINQ to entities===");
			using (AdventureWorksEntities awContext = new AdventureWorksEntities())
			{
				IEnumerable<Customer> customers = from cust in awContext.Customers
												  where cust.CompanyName.StartsWith("C")
												  orderby cust.CustomerID
												  select cust;
				foreach (Customer cust in customers)
				{
					Console.WriteLine("{0}, {1}", cust.CustomerID, cust.CompanyName);
				}

			}
		}

		static void QueryWithEntityClient()
		{
			EntityConnection cn = new EntityConnection();
			cn.Open();
			EntityCommand cmd = cn.CreateCommand();
			cmd.ExecuteReader(
		}
	}
}
