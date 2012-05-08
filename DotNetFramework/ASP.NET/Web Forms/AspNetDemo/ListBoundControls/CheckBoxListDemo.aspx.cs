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
using System.Text;

namespace AspNetDemo.ListBoundControls
{
	/// <summary>
	/// Summary description for CheckBoxListDemo.
	/// </summary>
	public class CheckBoxListDemo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CheckBoxList CheckBoxList1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtRepeatColumns;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.RadioButton rdoRepeatVertical;
		protected System.Web.UI.WebControls.RadioButton rdoRepeatHorizontal;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RadioButton rdoFlowLayout;
		protected System.Web.UI.WebControls.RadioButton rdoTableLayout;
		protected System.Web.UI.WebControls.Label Label4;
	
		private const string CONN_STR = "server=.;database=Northwind;uid=sa";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				txtRepeatColumns.Text = "3";
				rdoRepeatVertical.Checked = true;
				rdoTableLayout.Checked = true;

				BindList();
			}
			
			// 設定 CheckBoxList 的屬性
			CheckBoxList1.RepeatColumns = Convert.ToInt32(txtRepeatColumns.Text);
			CheckBoxList1.RepeatDirection = RepeatDirection.Vertical;
			if (rdoRepeatHorizontal.Checked) 
			{
				CheckBoxList1.RepeatDirection = RepeatDirection.Horizontal;
			}
			CheckBoxList1.RepeatLayout = RepeatLayout.Table;
			if (rdoFlowLayout.Checked) 
			{
				CheckBoxList1.RepeatLayout = RepeatLayout.Flow;
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
				CheckBoxList1.DataSource = dr;

				// 指定要繫結的欄位.
				CheckBoxList1.DataTextField = "CompanyName";
				CheckBoxList1.DataValueField = "SupplierID";

				// 進行繫結.
				CheckBoxList1.DataBind();
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
			int cnt = 0;
			StringBuilder sb = new StringBuilder();
			
			foreach (ListItem item in CheckBoxList1.Items) 
			{
				if (item.Selected) 
				{
					sb.Append(item.Text + " = " + item.Value + "<BR>");
					cnt++;
				}
			}	
			if (cnt == 0) 
			{
				Response.Write("請勾選!");
			}
			else 
			{
				Response.Write("你選擇了以下項目:<BR>" + sb.ToString());		
			}
		}


	}
}
