using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace AspNetDemo.StoredProc
{
	/// <summary>
	/// Summary description for DemoSP1_Select.
	/// </summary>
	public class SP1_NoParam : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnGetValue;
		protected System.Web.UI.WebControls.Button btnExecuteNonQuery;
		protected System.Web.UI.WebControls.Button btnGetRecords;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnGetRecords.Click += new System.EventHandler(this.btnGetRecords_Click);
			this.btnGetValue.Click += new System.EventHandler(this.btnGetValue_Click);
			this.btnExecuteNonQuery.Click += new System.EventHandler(this.btnExecuteNonQuery_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		// 呼叫 SP 以傳回一堆記錄
		private void btnGetRecords_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection("server=.;database=Northwind;uid=sa");
			SqlCommand cmd = new SqlCommand("[Ten Most Expensive Products]", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			conn.Open();

			SqlDataReader dr = cmd.ExecuteReader();
			
			DataGrid1.DataSource = dr;
			DataGrid1.DataBind();

			dr.Close();
			conn.Close();
		}


		// 呼叫 SP 以傳回一個值
		private void btnGetValue_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection("server=.;database=Northwind;uid=sa");
			SqlCommand cmd = new SqlCommand("GetCustomerCount", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			conn.Open();

			int cnt = (int) cmd.ExecuteScalar();
			TextBox1.Text = cnt.ToString();

			conn.Close();
		}

		// 呼叫 SP 以執行一項不須傳回值的工作
		private void btnExecuteNonQuery_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection("server=.;database=Northwind;uid=sa");
			SqlCommand cmd = new SqlCommand("ChangeCustomerCountry", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			conn.Open();
			cmd.ExecuteScalar();
			conn.Close();

			Response.Write("預儲程序執行完畢!");
		}

	}
}
