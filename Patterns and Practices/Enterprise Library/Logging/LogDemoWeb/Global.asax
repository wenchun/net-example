<%@ Application Language="C#" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Logging" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        // 取得 exception 物件
        Exception ex = Server.GetLastError().GetBaseException();
        
        if (Logger.IsLoggingEnabled())
		{               
			LogEntry log = new LogEntry();
            log.Severity = System.Diagnostics.TraceEventType.Critical;
            log.Message = ex.Message;
            log.TimeStamp = DateTime.Now;
            log.Title = "網站發生未處理的錯誤!";

			Logger.Write(log);
		}
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
