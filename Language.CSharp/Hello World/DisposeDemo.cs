/*
  �ɦW: DisposeDemo.cs
  �sĶ: csc DisposeDemo.cs  
  
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
    // �b�o�̼��g����귽���{���X
    //     
    GC.SuppressFinalize(this); // �O GC ���n�A�B�z���򪺦����ʧ@
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