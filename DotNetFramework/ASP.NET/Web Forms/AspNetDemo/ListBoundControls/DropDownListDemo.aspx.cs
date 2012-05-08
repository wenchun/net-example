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


namespace AspNetDemo.ListBoundControls
{
	/// <summary>
	/// Summary description for DropDownListDemo.
	/// </summary>
	public class DropDownListDemo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnGetOrders;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DropDownList ddlCustomers;
		protected System.Web.UI.WebControls.Label Label1;

		private const string CONN_STR = "server=.;database=Northwind;uid=sa";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				BindList();
			}
		}

		private void BindList()
		{
			SqlConnection conn = new SqlConnection(CONN_STR);
			SqlCommand cmd = new SqlCommand("select CustomerID, CompanyName from Customers", conn);
			SqlDataReader dr = null;

			try 
			{
				conn.Open();
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				ddlCustomers.DataSource = dr;

				// 指定要繫結的欄位.
				ddlCustomers.DataTextField = "CompanyName";
				ddlCustomers.DataValueField = "CustomerID";

				// 進行繫結.
				ddlCustomers.DataBind();
			}
			catch (Exception ex) 
			{
				Response.Write(ex.ToString());
			}
			finally 
			{
				if (dr != null) 
				{
					dr.Close();
				}
				// 加入第 0 個項目
				ddlCustomers.Items.Insert(0, "請選擇");
				ddlCustomers.SelectedIndex = 0;
			}
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
			this.btnGetOrders.Click += new System.EventHandler(this.btnGetOrders_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnGetOrders_Click(object sender, System.EventArgs e)
		{
			if (ddlCustomers.SelectedIndex <= 0)
				return;

			string custID = ddlCustomers.SelectedValue;

			SqlConnection conn = new SqlConnection(CONN_STR);
			SqlCommand cmd = new SqlCommand("select * from Orders where CustomerID=@CustomerID", conn);
			cmd.Parameters.Add("@CustomerID", custID);
			SqlDataReader dr = null;

			try 
			{
				conn.Open();
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				DataGrid1.DataSource = dr;
				DataGrid1.DataBind();
			}
			catch (Exception ex) 
			{
				Response.Write(ex.ToString());
			}
			finally 
			{
				if (dr != null)
				{
					dr.Close();
				}
			}
		}
	}
}
