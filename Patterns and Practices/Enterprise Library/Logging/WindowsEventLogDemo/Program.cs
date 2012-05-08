using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace WindowsEventLogDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			LogEntry log = new LogEntry();
			log.Severity = System.Diagnostics.TraceEventType.Information;
			log.Message = "測試 log 訊息，嚴重層級：Information。";
			Logger.Write(log);

			log.Severity = System.Diagnostics.TraceEventType.Error;
			log.Message = "測試 log 訊息，嚴重層級：Error。";
			Logger.Write(log);
		}
	}
}
