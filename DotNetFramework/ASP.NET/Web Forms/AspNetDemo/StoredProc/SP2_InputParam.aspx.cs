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
	/// Summary description for DemoSP2_WithParam.
	/// </summary>
	public class SP2_WithParam : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCustomerID;
		protected System.Web.UI.WebControls.Button btnInputParam;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnInputParam.Click += new System.EventHandler(this.btnInputParam_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		// ㊣惠璶肚把计箇纗祘: CustOrderHist
		private void btnInputParam_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection("server=.;database=Northwind;uid=sa");

			// ミ Command ン
			SqlCommand cmd = new SqlCommand("[CustOrderHist]", conn);
			cmd.CommandType = CommandType.StoredProcedure;

			// ミ把计ン
			SqlParameter param = new SqlParameter();
			param.ParameterName = "@CustomerID";
			param.Direction = ParameterDirection.Input;
			param.SqlDbType = SqlDbType.NChar;
			param.Value = txtCustomerID.Text;

			// 盢把计ン Command  Parameters 栋
			cmd.Parameters.Add(param);

			// 磅︽㊣笆
			conn.Open();
			SqlDataReader dr = cmd.ExecuteReader();
			
			// 戈么挡
			DataGrid1.DataSource = dr;
			DataGrid1.DataBind();
			
			dr.Close();
			conn.Close();		
		}

	}
}
