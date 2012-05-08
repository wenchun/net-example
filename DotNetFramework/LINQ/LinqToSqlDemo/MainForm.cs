using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DemoTools;

namespace LinqToSqlDemo
{
	public partial class MainForm : DemoFormBase
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnQuerySqlDatabase_Click(object sender, EventArgs e)
		{
			Console.WriteLine("!CLEAR");

			NorthwindDataContext db = new NorthwindDataContext();

			var products =
				from product in db.Products
				where product.UnitPrice > 5
				orderby product.CategoryID, product.ProductName
				select product;

			dataGridView1.DataSource = products;

			// 從查詢的結果再進一步篩選
			var products2 =
				from p in products
				where p.CategoryID == 1
				select p;

			foreach (var p in products2)
			{
				Console.WriteLine(p.CategoryID + " - " + p.ProductName);
			}
		}

		private void btnCallProc_Click(object sender, EventArgs e)
		{
			Console.WriteLine("!CLEAR");

			NorthwindDataContext db = new NorthwindDataContext();
			var results = db.CustOrderHist("CACTU");

			Console.WriteLine("NorthwindDataContext.CustOrderHist() 傳回值的型別為: " + results.GetType().Name);

			dataGridView1.DataSource = results;
		}

		private void btnAddCustomer_Click(object sender, EventArgs e)
		{
			NorthwindDataContext db = new NorthwindDataContext();

			Customer aCustomer = new Customer();
			aCustomer.CustomerID = "AAA";
			aCustomer.CompanyName = "AAA 公司";

			db.Customers.InsertOnSubmit(aCustomer);

			try
			{
				db.SubmitChanges();

				// 查詢剛剛新增的客戶

				var theCustomer = from c in db.Customers
								  where c.CustomerID.Contains("AAA")
								  select c;

				dataGridView1.DataSource = theCustomer;
			}
			catch (Exception ex)
			{
				MessageBox.Show("新增失敗: " + ex.Message);
			}
		}

		private void btnDeleteCustomer_Click(object sender, EventArgs e)
		{
			NorthwindDataContext db = new NorthwindDataContext();

			Customer aCustomer = db.Customers.SingleOrDefault (c => c.CustomerID == "AAA");

			if (aCustomer == null)
			{
				MessageBox.Show("查無客戶 'AAA'");
				return;
			}
			db.Customers.DeleteOnSubmit(aCustomer);

/* 或者用
			var customers = from c in db.Customers
							where c.CustomerID.Contains("AAA")
							select c;

			if (customer.Count() < 1)
			{
				MessageBox.Show("查無客戶 'AAA'");
				return;
			}
			db.Customers.DeleteAllOnSubmit(customers);
*/

			db.SubmitChanges();

			Console.WriteLine("刪除成功!");

			// 查詢剛剛刪除的客戶

			var theCustomer = from c in db.Customers
							  where c.CustomerID.Contains("AAA")
							  select c;

			dataGridView1.DataSource = theCustomer;
		}
	}
}
