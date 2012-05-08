using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch01_NoDI
{
    class Program
    {
        static void Main(string[] args)
        {
            HeavyDuty aTask = new HeavyDuty();
            aTask.Run();
        }
    }
}
