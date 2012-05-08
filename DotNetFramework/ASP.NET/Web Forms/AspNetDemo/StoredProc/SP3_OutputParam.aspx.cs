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
	/// Summary description for SP3_OutputParam.
	/// </summary>
	public class SP3_OutputParam : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnOutputParam;
		protected System.Web.UI.WebControls.TextBox txtCustomerID;
		protected System.Web.UI.WebControls.Label Label1;
	
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
			this.btnOutputParam.Click += new System.EventHandler(this.btnOutputParam_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/* �I�s�@�ӻݭn�ǤJ�Ѽƪ��w�x�{��: OrdersCount
		 * ALTER PROCEDURE dbo.OrdersCount
		 * (
		 *		@CustomerID nchar(5),
		 * 	@ItemCount int OUTPUT
		 * )
		 * AS
		 * 	select @ItemCount=COUNT(OrderID)
		 * 	from Orders
		 * 	where CustomerID=@CustomerID
		 * RETURN 
		 */	
		private void btnOutputParam_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection("server=.;database=Northwind;uid=sa");

			// �إ� Command ����
			SqlCommand cmd = new SqlCommand("[OrdersCount]", conn);
			cmd.CommandType = CommandType.StoredProcedure;

			// �إ� input �Ѽƪ���
			SqlParameter inParam = new SqlParameter();
			inParam.ParameterName = "@CustomerID";
			inParam.Direction = ParameterDirection.Input;
			inParam.SqlDbType = SqlDbType.NChar;
			inParam.Value = txtCustomerID.Text;

			// �إ� output �Ѽƪ���
			SqlParameter outParam = new SqlParameter();
			outParam.ParameterName = "@ItemCount";
			outParam.Direction = ParameterDirection.Output;
			outParam.SqlDbType = SqlDbType.Int;

			// �N�Ѽƪ���[�J Command �� Parameters ���X
			cmd.Parameters.Add(inParam);
			cmd.Parameters.Add(outParam);

			// �I�s�w�x�{��
			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();

			// ���o��X�Ѽƪ���
			int itemCount = (int) outParam.Value;
			Label2.Text = itemCount.ToString();
		}
	}
}
