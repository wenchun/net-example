using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch01_NoDI
{
    public class ConsoleLogger
    {
        public void WriteEntry(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
