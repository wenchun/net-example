using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch01_NoDI
{
    public class HeavyDuty
    {
        private ConsoleLogger logger;

        public HeavyDuty()
        {
            // 在建構式裡面就先建立好欲使用的記錄器.
            logger = new ConsoleLogger();
        }

        public void Run()
        {
            logger.WriteEntry("HeavyDuty is running...");
        }
    }
}
