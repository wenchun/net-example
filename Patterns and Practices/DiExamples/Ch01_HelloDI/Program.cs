using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch01_HelloDI
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            HeavyDuty aTask = new HeavyDuty(logger);
            aTask.Run();
        }
    }
}
