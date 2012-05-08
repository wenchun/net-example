using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyService.MyServiceClient svc = new MyService.MyServiceClient();
            string time = svc.GetTime();
            Console.WriteLine(time);
        }
    }
}
