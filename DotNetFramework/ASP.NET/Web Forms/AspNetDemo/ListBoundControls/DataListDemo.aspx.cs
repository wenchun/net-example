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
	/// Summary description for DataListDemo.
	/// </summary>
	public class DataListDemo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblStatus;
		protected System.Web.UI.WebControls.DataList DataList1;
	
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
			this.DataList1.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_ItemCommand);
			this.DataList1.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_EditCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		

		void BindList() 
		{
			const string CONN_STR = "server=.;database=Northwind;uid=sa";

			SqlConnection conn = new SqlConnection(CONN_STR);
			SqlCommand cmd = new SqlCommand("select * from Customers", conn);
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

		private void DataList1_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{			
			switch (e.CommandName)
			{
				case "select": 
					// 設定 DataList 的目前的選取列 
					DataList1.SelectedIndex = e.Item.ItemIndex;

					// 記得要重新做 data-binding
					BindList();

					lblStatus.Text = "你選擇的客戶編號是：" + e.CommandArgument;
					break;
				case "edit": 
					// 設定 DataList 的目前的選取列 
					DataList1.SelectedIndex = e.Item.ItemIndex;
					// 設定 DataList 目前編輯的列
					DataList1.EditItemIndex = e.Item.ItemIndex;
					BindList();
					break;
				case "save":
					DataList1.EditItemIndex = -1;
					BindList();
					lblStatus.Text = "儲存功能尚未實作!";
					break;
				case "cancel":
					DataList1.EditItemIndex = -1;
					BindList();
					lblStatus.Text = "取消編輯狀態!";
					break;
			}
		}

		private void DataList1_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			lblStatus.Text = "進入編輯模式，修改的客戶編號為: " + e.CommandArgument;
		}

	}
}
