using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;
using DemoTools;

namespace LinqToDataSetDemo
{
	public partial class MainForm : DemoFormBase
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnQueryTypedDataSet_Click(object sender, EventArgs e)
		{
			NorthwindDataSet ds = new NorthwindDataSet();

			NorthwindDataSetTableAdapters.ProductsTableAdapter productsAdapter = new LinqToDataSetDemo.NorthwindDataSetTableAdapters.ProductsTableAdapter();

			NorthwindDataSetTableAdapters.CategoriesTableAdapter categoriesAdapter = new LinqToDataSetDemo.NorthwindDataSetTableAdapters.CategoriesTableAdapter();

			categoriesAdapter.Fill(ds.Categories);
			productsAdapter.Fill(ds.Products);

			// LINQ 查詢

			var products =
				from p in ds.Products
				where p.CategoryID == 1
				orderby p.ProductID
				select new
				{
					ProductName = p.ProductName,
					UnitPrice = p.UnitPrice,
					CategoryName = p.CategoriesRow.CategoryName
				};

			dataGridView1.DataSource = products.ToList();

			foreach (var p in products)
			{
				Console.WriteLine(p.ProductName);
			}
		}

		private void btnQueryUntypedDataSet_Click(object sender, EventArgs e)
		{
			// Fill DataSet

			var ds = new DataSet();
			using (var adapter = new SqlDataAdapter(
				"select * from Customers", Properties.Settings.Default.NorthwindConnectionString)) 
			{
				adapter.Fill(ds, "Customers");
			}

			// LINQ 查詢 to DataTable

			DataTable tbl = ds.Tables["Customers"];

			// NOTE: 由於 DataTable 未實作 IEnumerable，所以要先用 DataTable 的擴充方法 AsEnumerable 轉換資料型態
			var customers = from c in tbl.AsEnumerable()	
							where c.Field<string>("Country") == "USA"
							select new
							{
								CustomerID = c.Field<string>("CustomerID"),
								CustomerName = c.Field<string>("ContactName")
							};

			dataGridView1.DataSource = customers.ToList();
		}
	}
}
