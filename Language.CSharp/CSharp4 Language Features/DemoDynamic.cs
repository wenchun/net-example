using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp4Demo
{
    class DemoDynamic
    {
        public static void Run()
        {
            Foo aFoo = new Foo();
            // 下面這行程式碼顯然無法編譯.
            //aFoo.TestInt(1, 3);

            dynamic dynamicFoo = new Foo();
            // 下面這行卻可以編譯，等到執行時才會出錯.
            //dynamicFoo.TestInt(1, 3);

            // 否則動態型別的物件的運算結果依然是動態型別（除非指定給明確宣告型別的變數）.
            dynamic d = 1;
            var sum = d + 2;    // 觀察「區域變數」或「監看」視窗裡的變數型別, sum 會是 dynamic.
            Console.WriteLine("sum = " + sum);

            int i = sum;        // i 的型別當然是 int，而不是 dynamic.

            // 注意下面這行：由於是傳入的參數是 dynamic 型別，所以還是可以通過編譯，但執行時會出錯。
            //aFoo.TestStr(d);

            // 下面這行就無法通過編譯，因為編譯器能夠檢查出參數型別不符。
            //aFoo.TestStr(10);

            // 如前面示範過的，使用動態型別的物件時，無論呼叫的方法傳入甚麼參數，都能通過編譯。
            //dynamicFoo.TestStr(10);
        }
    }


    class Foo
    {
        public Foo()
        {
        }

        public void TestInt(int i)
        {
        }

        public void TestStr(string s)
        {
        }
    }
}
