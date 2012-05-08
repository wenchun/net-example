/*
  此範例欲展示：
  
    - 建構元與解構元的呼叫順序
    - 如何呼叫父類別的成員

  Written by Huanlin Tsai.  Sep-26-2002.
*/
using System;

class CtorDemo
{
  class Test1
  {        
    public Test1()  // 建構元.
    {
      Console.WriteLine("Test1 constructor");
    }
    
    ~Test1()  // 解構元.
    {
      Console.WriteLine("Test1 destructor");
    }
    
    public virtual void Hello()
    {
      Console.WriteLine("Test1.Hello");
    }    
  } 
  
  class Test2 : Test1
  {
    public Test2(string s)  // 這裡不管有沒有寫 ": base()"，父代建構元都會被呼
    {                       // 叫，而且即使有寫，父代建構元還是只會被呼叫一次.
      Console.WriteLine("Test2 constructor with parameter: " + s);
    }
    ~Test2()
    {
      Console.WriteLine("Test2 destructor");
    }
    public override void Hello()
    {
      base.Hello(); // 呼叫父代類別的 Hello 方法.
      Console.WriteLine("Test2.Hello");
    }
  } 
  
  public static void Main()
  {
    Test2 t = new Test2("Michael");
    t.Hello();
  }
}