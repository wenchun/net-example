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
using System.Text;

namespace AspNetDemo.ListBoundControls
{
	/// <summary>
	/// Summary description for ListBoxDemo.
	/// </summary>
	public class ListBoxDemo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox ListBox1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.CheckBox chkMultipleSelection;
		protected System.Web.UI.WebControls.Label Label1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack) 
			{
				chkMultipleSelection.Checked = false;
				BindList();
			}

			ListBox1.SelectionMode = ListSelectionMode.Single;
			if (chkMultipleSelection.Checked) 
			{
				ListBox1.SelectionMode = ListSelectionMode.Multiple;
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
			string[] items = new string[] {"Apple", "Orange", "Banana"};

			// �`�N: �u�n�O����@ ICollection �����O���i�H��@���ô�����ӷ�
			ListBox1.DataSource = items;
			ListBox1.DataBind();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			int cnt = 0;
			StringBuilder sb = new StringBuilder();
			
			foreach (ListItem item in ListBox1.Items) 
			{
				if (item.Selected) 
				{
					sb.Append(item.Text + " = " + item.Value + "<BR>");
					cnt++;
				}
			}	
			if (cnt == 0) 
			{
				Response.Write("�п��!");
			}
			else 
			{
				Response.Write("�A��ܤF�H�U����:<BR>" + sb.ToString());		
			}
		}
	}
}
