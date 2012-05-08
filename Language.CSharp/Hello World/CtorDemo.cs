/*
  ���d�ұ��i�ܡG
  
    - �غc���P�Ѻc�����I�s����
    - �p��I�s�����O������

  Written by Huanlin Tsai.  Sep-26-2002.
*/
using System;

class CtorDemo
{
  class Test1
  {        
    public Test1()  // �غc��.
    {
      Console.WriteLine("Test1 constructor");
    }
    
    ~Test1()  // �Ѻc��.
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
    public Test2(string s)  // �o�̤��ަ��S���g ": base()"�A���N�غc�����|�Q�I
    {                       // �s�A�ӥB�Y�Ϧ��g�A���N�غc���٬O�u�|�Q�I�s�@��.
      Console.WriteLine("Test2 constructor with parameter: " + s);
    }
    ~Test2()
    {
      Console.WriteLine("Test2 destructor");
    }
    public override void Hello()
    {
      base.Hello(); // �I�s���N���O�� Hello ��k.
      Console.WriteLine("Test2.Hello");
    }
  } 
  
  public static void Main()
  {
    Test2 t = new Test2("Michael");
    t.Hello();
  }
}