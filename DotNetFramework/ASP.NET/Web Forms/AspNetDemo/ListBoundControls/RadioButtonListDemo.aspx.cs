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
	/// Summary description for RadioButtonListDemo.
	/// </summary>
	public class RadioButtonListDemo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;

		private const string CONN_STR = "server=.;database=Northwind;uid=sa";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				BindList();
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindList()
		{
			SqlConnection conn = new SqlConnection(CONN_STR);
			SqlCommand cmd = new SqlCommand("select SupplierID, CompanyName from Suppliers", conn);
			SqlDataReader dr = null;

			try 
			{
				conn.Open();
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				RadioButtonList1.DataSource = dr;

				// ���w�nô�������.
				RadioButtonList1.DataTextField = "CompanyName";
				RadioButtonList1.DataValueField = "SupplierID";

				// �i��ô��.
				RadioButtonList1.DataBind();
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

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if (RadioButtonList1.SelectedIndex < 0) 
			{
				Response.Write("�ФĿ�!");
			}
			else 
			{
				Response.Write("�A��ܪ����جO: " + RadioButtonList1.SelectedItem.Text + 
					" = " + RadioButtonList1.SelectedValue + "<BR>");
			}
		}

	}
}
