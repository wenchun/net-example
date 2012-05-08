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

namespace Demo2310CS.Mod09
{
	/// <summary>
	/// Summary description for DataListSorting.
	/// </summary>
	public class DataListSorting : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList DataList1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				BindList("");
			}
		}

		// 繫結時，由外部傳入欲排序的欄位
		void BindList(string sort) 
		{
			const string CONN_STR = "server=.;database=Northwind;uid=sa";
			string sql = "select * from Customers ";

			if (sort != "") 
			{
				sql += " order by " + sort;
			}

			SqlConnection conn = new SqlConnection(CONN_STR);
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader dr = null;
			conn.Open();
			try 
			{
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				DataList1.DataSource = dr;
				DataList1.DataBind();
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
			this.DataList1.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataList1_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			if (e.CommandName == "sort") 
			{
				BindList((string) e.CommandArgument);
			}
	}
	}
}
