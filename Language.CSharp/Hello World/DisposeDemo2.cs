/*
  ���d�Үi�ܤF Dispose �����T�Ϊk�C

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
    // �b�o�̼��g����귽���{���X.
    //     
    GC.SuppressFinalize(this); // �O GC ���n�A�B�z���򪺦����ʧ@.
    
    disposed = true;
  }    
}

class DisposeDemo2
{
  // �q�Τu��禡�A�Ψ����񪫥�귽�A�òM������Ѧ�
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
    foo2 = foo1;  // �{�b������ܼưѦҨ�P�@�� Foo ����.    
    try 
    {
    }
    finally
    {
      DisposeObject(foo1);
      DisposeObject(foo2);  // �o���� Dispose ���ӷ|������^
    }  
  }
}