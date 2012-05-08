using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch01_HelloDI
{
    public class ConsoleLogger : ILogger
    {
        public void WriteEntry(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
