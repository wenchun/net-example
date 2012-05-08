using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace LogToEmailDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			LogEntry log = new LogEntry();
			log.Message = "測試 log 訊息!";
			log.Severity = System.Diagnostics.TraceEventType.Information;
			log.TimeStamp = DateTime.Now;

			Logger.Write(log);
		}
	}
}
