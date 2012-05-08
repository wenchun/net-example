using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

/*
 * 此範例展示當元件本身未提供非同步呼叫方法 Begin<Operation> 與 End<Operation> 時，
 * 用戶端如何利用委派來實現非同步呼叫。
 * 
 * Written by Huan-Lin Tsai. Jun-23-2005.
 */
namespace AsyncDemo_BossWorker
{
	// 員工（提供服務的元件）
	class Worker
	{
		// 執行工作。傳回值: 花費的工時（hours）。
		//taskName: 工作名稱。
		public int Work(String taskName) 
		{
			Console.WriteLine("Worker: I'm busy working...");
			Thread.Sleep(3000); // 假設任務需要花這些時間執行。
			Console.WriteLine("Worker: I'm done.");
			Random r = new Random((int)DateTime.Now.Ticks);
			return (r.Next() % 20 + 1);
		}
	}

	/// 以下是 client code 的部份 -------------------------------

	// 為了以非同步的方式令員工執行任務，必須宣告一個委派型別（因為員工本身未提供非同步執行方法）。
	public delegate int WorkCompletedEventHandler(String taskName);

	// 老闆
	class Boss
	{
		public WorkCompletedEventHandler WorkCompleted = null;

		// 同步呼叫。
		public void RunSync()
		{
			Worker peter = new Worker();
			Console.WriteLine("Boss  : Run task A synchronously...");
			int hours = peter.Work("A");
			Console.WriteLine("Boss  : Ok! Task A is completed in {0} hours.\n", hours);
		}

		// 非同步呼叫，使用 EndInvoke 取得執行結果。
		public void RunAsync()
		{
			Worker peter = new Worker();
			Console.WriteLine("Boss  : Run task B asynchrously....");
			WorkCompleted = new WorkCompletedEventHandler(peter.Work);
			IAsyncResult ar = WorkCompleted.BeginInvoke("B", null, null);
			Console.WriteLine("Boss  : Now I can take a nap....");
			Thread.Sleep(4000);
			int hours = WorkCompleted.EndInvoke(ar);
			Console.WriteLine("Boss  : Ok! Task B is completed in {0} hours.\n", hours);
		}

		// 非同步呼叫，使用 completion callback 得知結果。						
		public void RunAsyncWithCallback()
		{
			Worker peter = new Worker();
			AsyncCallback cb = new AsyncCallback(this.OnComplete);
			WorkCompleted = new WorkCompletedEventHandler(peter.Work);
			Console.WriteLine("Boss  : Run task C asynchrously, with completion callback....");
			WorkCompleted.BeginInvoke("C", cb, null);
			Console.WriteLine("Boss  : Now I can fire and forget, until peter notify me....");
			Thread.Sleep(4000);			
		}

		// Completion callback
		private void OnComplete(IAsyncResult arIntf)
		{
			AsyncResult ar = (AsyncResult) arIntf;
			WorkCompletedEventHandler handler = (WorkCompletedEventHandler) ar.AsyncDelegate;
			int hours = handler.EndInvoke(ar);
			Console.WriteLine("Boss  : Got it! It takes you {0} hours to complete task C.", hours);
		}
	}

	class Universe
	{
		[STAThread]
		static void Main(string[] args)
		{
			Boss boss = new Boss();
			boss.RunSync();
			boss.RunAsync();
			boss.RunAsyncWithCallback();
		}
	}
}
