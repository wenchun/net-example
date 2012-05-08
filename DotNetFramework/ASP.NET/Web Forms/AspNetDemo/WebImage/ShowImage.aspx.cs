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

namespace AspNetDemo.WebImage
{
	/// <summary>
	/// Summary description for ShowImage.
	/// </summary>
	public class ShowImage : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (Request["src"] == "file") 
			{
				Bitmap bmp = new Bitmap(Server.MapPath("amily.jpg"));
				bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
				Response.ContentType = "image/jpg";
				Response.End();
			}
			else if (Request["src"] == "db")
			{
				SqlConnection cn = new SqlConnection("server=.;database=pubs;uid=sa");
				SqlDataAdapter da = new SqlDataAdapter("select logo from pub_info", cn);
				DataSet ds = new DataSet();
				da.Fill(ds, "pub_info");
				DataRow row = ds.Tables["pub_info"].Rows[0];			
				byte[] img = (byte[]) row["logo"];
				Response.ContentType = "image/bmp";
				Response.BinaryWrite(img);
				Response.End();
				cn.Close();

				// 也可以用 SqlDataReader:
				/*
				SqlCommand cmd = new SqlCommand("select logo from pub_info", cn);
				SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
				if (dr.Read()) 
				{
					byte[] imgBuf = (byte[]) dr["logo"];
					Response.ContentType = "image/bmp";
					Response.BinaryWrite(imgBuf);
					Response.End();				
				}
				dr.Close();
				cn.Close();
				*/
			}
			else 
			{
				Response.Write("請由 ImagePage.aspx 執行，或者指定查詢字串: ?src=file 或 ?src=db");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
