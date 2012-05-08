using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp4Demo
{
    class DemoOptionalAndNamedParam
    {
        public static void Run()
        {
            OptionalParameters();
            OptionalParameters(10);
            OptionalParameters(name: "Michael");    // 欲忽略第一個參數，就必須使用具名參數的呼叫方式.
            OptionalParameters(name: "Mary", count: 2); // 使用具名參數可不用理會參數宣告時的順序.

            OverloadedTest(4);  // 若發現一個以上的函式符合，編譯器會選擇沒有可選參數的函式.
        }

        private static void OptionalParameters(int count = 5, string name = "John")
        {
            Console.WriteLine("========================");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(i + ": Hello, " + name);
            }
        }

        private static void OverloadedTest(int count)
        {
            Console.WriteLine("編譯器選擇了沒有 optional 參數的版本!");
        }

        private static void OverloadedTest(int count, string name = "John") 
        {
            OptionalParameters(count, name);
        }
    }
}
