using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch01_HelloDI
{
    public class HeavyDuty
    {
        private ILogger logger;

        public HeavyDuty(ILogger aLogger)
        {
            logger = aLogger;
        }

        public void Run()
        {
            logger.WriteEntry("HeavyDuty is running...");
        }
    }
}
