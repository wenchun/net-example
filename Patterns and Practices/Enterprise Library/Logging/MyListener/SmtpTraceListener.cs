using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;

namespace MyListener
{
	[ConfigurationElementType(typeof(CustomTraceListenerData))]
	public class SmtpTraceListener : CustomTraceListener
	{
		public SmtpTraceListener()
		{			
		}

		public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
		{
			if (data is LogEntry && this.Formatter != null)
			{
				Write(this.Formatter.Format(data as LogEntry));
			}
			else
			{
				Write(data.ToString());
			}
		}

		public override void Write(string message)
		{
			SendMail(message);
		}

		public override void WriteLine(string message)
		{
			SendMail(message);
		}

		public void SendMail(string message)
		{
			string smtpServer = this.Attributes["SmtpServer"];
			int smtpPort = Convert.ToInt32(this.Attributes["SmtpPort"]);

			MailMessage msg = new MailMessage();
			SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
			msg.From = new MailAddress("huanlin@scu.edu.tw");
			msg.To.Add("huanlin@scu.edu.tw");
			msg.IsBodyHtml = false;
			msg.Body = message;
			msg.Subject = "My Email Trace Listener Log 訊息" ;

			smtp.UseDefaultCredentials = false;
			smtp.EnableSsl = true;
			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			NetworkCredential userCred = new NetworkCredential("scu3408", "acer1234");
			smtp.Credentials = userCred;

			smtp.Send(msg);
		}
	}
}