using System;


public class Foo
{
  ~Foo()
  {
    Console.WriteLine("Finalizing Foo");
    //ObjResurrection.obj = this;
  }
  
  public void Hello()
  {
    Console.WriteLine("Hello");
  }
}

public class ObjResurrection
{
  public static object obj = null;
   
  public static void Main()
  {
    Foo foo = new Foo();
    obj = foo;
    foo = null;
    GC.Collect();
    GC.WaitForPendingFinalizers();
    ((Foo)obj).Hello();
  }
}