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
					// �]�w DataList ���ثe������C 
					DataList1.SelectedIndex = e.Item.ItemIndex;

					// �O�o�n���s�� data-binding
					BindList();

					lblStatus.Text = "�A��ܪ��Ȥ�s���O�G" + e.CommandArgument;
					break;
				case "edit": 
					// �]�w DataList ���ثe������C 
					DataList1.SelectedIndex = e.Item.ItemIndex;
					// �]�w DataList �ثe�s�誺�C
					DataList1.EditItemIndex = e.Item.ItemIndex;
					BindList();
					break;
				case "save":
					DataList1.EditItemIndex = -1;
					BindList();
					lblStatus.Text = "�x�s�\��|����@!";
					break;
				case "cancel":
					DataList1.EditItemIndex = -1;
					BindList();
					lblStatus.Text = "�����s�説�A!";
					break;
			}
		}

		private void DataList1_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			lblStatus.Text = "�i�J�s��Ҧ��A�ק諸�Ȥ�s����: " + e.CommandArgument;
		}

	}
}
