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
	/// Summary description for DemoSP3_ReturnValue.
	/// </summary>
	public class SP3_ReturnValue : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		// �ܽd�I�s���Ǧ^�Ȫ��w�x�{�ǡA�H�Φp����o�Ǧ^��
		private void Button1_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection("server=.;database=Northwind;uid=sa");

			// �إ� Command ����
			SqlCommand cmd = new SqlCommand("[AddTen]", conn);
			cmd.CommandType = CommandType.StoredProcedure;

			// �إ� input �Ѽƪ���
			SqlParameter inParam = new SqlParameter();
			inParam.ParameterName = "@Number";
			inParam.Direction = ParameterDirection.Input;
			inParam.SqlDbType = SqlDbType.Int;
			inParam.Value = 10;

			// �إ� return value �Ѽƪ���
			SqlParameter retParam = new SqlParameter();
			retParam.ParameterName = "@ReturnValue";  // �W�٥i�ۭq
			retParam.Direction = ParameterDirection.ReturnValue;
			retParam.SqlDbType = SqlDbType.Int;

			// �N�Ѽƪ���[�J Command �� Parameters ���X
			cmd.Parameters.Add(inParam);
			cmd.Parameters.Add(retParam);
			
			// �I�s�w�x�{��
			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();

			// ���o��X�Ѽƪ���
			int retValue = (int) retParam.Value;
			Label1.Text = retValue.ToString();	
		}
	}
}
