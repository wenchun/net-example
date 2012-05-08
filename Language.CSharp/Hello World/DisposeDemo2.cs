/*
  此範例展示了 Dispose 的正確用法。

  Written by Huanlin Tsai.  Oct-15-2002.
*/
using System;

class Foo : IDisposable
{      
  private bool disposed = false;
  
  ~Foo() 
  {
    Dispose();
  }
  
  public void Dispose()
  {
    if (disposed)
      return;
    Console.WriteLine("Disposing");  
    //
    // 在這裡撰寫釋放資源的程式碼.
    //     
    GC.SuppressFinalize(this); // 令 GC 不要再處理後續的收尾動作.
    
    disposed = true;
  }    
}

class DisposeDemo2
{
  // 通用工具函式，用來釋放物件資源，並清除物件參考
  public static void DisposeObject(object obj)
  {
    if (obj is IDisposable)
      (obj as IDisposable).Dispose();
    obj = null;
  }

  public static void Main()
  {
    Foo foo1, foo2;
    
    foo1 = new Foo();
    foo2 = foo1;  // 現在有兩個變數參考到同一個 Foo 物件.    
    try 
    {
    }
    finally
    {
      DisposeObject(foo1);
      DisposeObject(foo2);  // 這次的 Dispose 應該會直接返回
    }  
  }
}