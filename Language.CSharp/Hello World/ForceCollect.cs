/* 
  檔名: DisposeDemo.cs
  編譯: csc ForceCollect.cs

  示範如何強制執行資源回收
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