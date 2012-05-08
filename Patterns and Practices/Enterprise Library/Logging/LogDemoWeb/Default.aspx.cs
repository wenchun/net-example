using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Logging;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		LogEntry log = new LogEntry();
		log.Message = "不重要的 log 訊息";
		log.Severity = System.Diagnostics.TraceEventType.Information;
		Logger.Write(log);
    }

	protected void Button1_Click(object sender, EventArgs e)
	{
		throw new Exception("Bad things happened!");
	}
}
