using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyLib;

namespace MyApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyConfig myConfig = new MyConfig();
            Console.WriteLine(myConfig.UserName);
        }
    }
}