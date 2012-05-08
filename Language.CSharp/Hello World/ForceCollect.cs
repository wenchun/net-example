/* 
  �ɦW: DisposeDemo.cs
  �sĶ: csc ForceCollect.cs

  �ܽd�p��j�����귽�^��
*/
using System;

class HugeObject
{
  ~HugeObject()
  {
    Console.WriteLine("Finalizing HugeObject");  
  } 
}

class ForceCollect
{
  public static void Main()
  {
    HugeObject obj = new HugeObject();
    obj = null;
    GC.Collect();
    GC.WaitForPendingFinalizers();    

    Console.WriteLine("Press any key...");
    Console.ReadLine();     
  }
}