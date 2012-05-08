using System;
using System.Configuration;

namespace FluentConfigDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyLogger.Write("測試 log 輸出。", "Qoo");
            Console.WriteLine(ConfigurationManager.AppSettings["test"]);
        }
    }
}