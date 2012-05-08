using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowOrders : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        GridView1.EnableDynamicData(typeof(NorthwindModel.Order));
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}