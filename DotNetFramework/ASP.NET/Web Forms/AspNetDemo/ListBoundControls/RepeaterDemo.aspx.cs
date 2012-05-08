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
	/// Summary description for RepeaterDemo.
	/// </summary>
	public class RepeaterDemo : System.Web.UI.Page
	{
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				BindRepeater();
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
			this.Repeater1.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.Repeater1_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;


		private const string CONN_STR = "server=.;database=Northwind;uid=sa";

		void BindRepeater() 
		{
			SqlConnection conn = new SqlConnection(CONN_STR);
			SqlCommand cmd = new SqlCommand("select * from Customers", conn);
			SqlDataReader dr = null;
			conn.Open();
			try 
			{
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				Repeater1.DataSource = dr;
				Repeater1.DataBind();
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

		// 當使用者按下 Repeater 控制項中的按鈕時會觸發此事件
		private void Repeater1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "select") 
			{
				Response.Write("你選擇的客戶編號是：" + e.CommandArgument);
			}
		}
	}
}
