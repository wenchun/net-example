using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CSharp4Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string menu = File.ReadAllText("Menu.txt");

            bool done = false;

            while (true)
            {
                Console.Clear();
                Console.Write(menu);

                string key = Console.ReadLine();
                switch (key.ToUpper())
                {
                    case "A":
                        DemoOptionalAndNamedParam.Run();        
                        break;
                    case "B":
                        DemoDynamic.Run();
                        break;
                    case "C":
                        DemoComInterop.Run();
                        break;
                    case "X":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("無效的選擇!");
                        break;
                }

                if (done)
                {
                    break;
                }
                Console.Write("按任意鍵繼續...");
                Console.ReadKey();
            }            
            //Covariance.CovarianceDemo.DemoUnsafeArray();
            //Covariance.CovarianceDemo.DemoGenericList();
        }
    }
}
