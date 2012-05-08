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

namespace AspNetDemo.WebImage
{
	/// <summary>
	/// Summary description for WebImageDemo.
	/// </summary>
	public class ImagePage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButton rdoFromDb;
		protected System.Web.UI.WebControls.Button btnOk;
		protected System.Web.UI.WebControls.RadioButton rdoFromFile;
		protected System.Web.UI.WebControls.Image Image1;
	
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
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			string imgSrc = "file";
			if (rdoFromDb.Checked) 
			{
				imgSrc = "db";
			}
			Image1.ImageUrl = "ShowImage.aspx?src=" + imgSrc;
		}
	}
}
