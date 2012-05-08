using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp4Demo
{
    class Foo
    {
        public void Hello()
        {
            Console.WriteLine("Hello World!");
        }
    }

    class DynamicDemo
    {
        public void Run()
        {
            dynamic foo = new Foo();
            foo.Hello();
            foo.HelloFailed();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DynamicDemo demo = new DynamicDemo();
            demo.Run();
        }
    }
}
