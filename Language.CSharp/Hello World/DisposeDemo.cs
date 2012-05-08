/*
  檔名: DisposeDemo.cs
  編譯: csc DisposeDemo.cs  
  
  Written by Huanlin Tsai.  Oct-11-2002.
*/
using System;

class Foo : IDisposable
{      
  private string name;
  
  public Foo(string aName) 
  { 
    name = aName; 
    Console.WriteLine("Creating " + name);
  }
  
  ~Foo()
  {
    Console.WriteLine("Finalizing " + name);
    Dispose();
  }
  
  public void Dispose()
  {
    Console.WriteLine("Disposing " + name);
    //
    // 在這裡撰寫釋放資源的程式碼
    //     
    GC.SuppressFinalize(this); // 令 GC 不要再處理後續的收尾動作
  }      
}


class DisposeDemo
{
  public static void Main()
  {
    Foo foo1 = new Foo("foo1");
    Foo foo2 = new Foo("foo2");
    foo2.Dispose();
  }
}