using System;
using System.Threading;
using System.Windows.Forms;

namespace EventDemoAsync1
{
	public delegate int WorkCompletedEventHandler(string workerName);

	/// <summary>
	/// 仿照 Windows Forms Programming in C# by Chris Sells 的附錄 B 的例子
	/// </summary>
	class Boss
	{
		public int OnWorkCompleted(string workerName)
		{			
			Console.WriteLine("Work completed by       : " + workerName);
			return 1; // grade
		}

		public int OnWorkCompletedAsync(string workerName)
		{			
			Thread.Sleep(1000); // 故意延遲 1 秒，模擬負載重的工作 or 老闆睡著了。
			Console.WriteLine("Async work completed by : " + workerName);			
			return 2;
		}

		// 同步呼叫。
		public void TestEventNormal(string workerName)
		{
			// 使用委派的最簡單形式：建立一個委派物件，該委派物件內含一個 callback 方法參考
			WorkCompletedEventHandler handler = new WorkCompletedEventHandler(this.OnWorkCompleted);
			handler(workerName);  // 觸發事件
		}

		// 非同步呼叫，不在乎傳回值。
		public void TestEventAsync(string workerName)
		{
			WorkCompletedEventHandler handler = new WorkCompletedEventHandler(this.OnWorkCompletedAsync);
			// 把下面這行取消註解，會造成執行時出現 System.ArgumentException，因為非同步呼叫只允許一個 target。
			handler += new WorkCompletedEventHandler(this.OnWorkCompletedAsync);
			handler.BeginInvoke(workerName, null, null);
		}

		// 非同步呼叫，要取得傳回值。
		public int TestEventAsyncResult(string workerName)
		{
			WorkCompletedEventHandler handler = new WorkCompletedEventHandler(this.OnWorkCompletedAsync);
			IAsyncResult asyncResult = handler.BeginInvoke(workerName, null, null);
			return handler.EndInvoke(asyncResult);
		}

	}


	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{			
			Boss boss = new Boss();

			int retValue = boss.TestEventAsyncResult("1"); // 由於會取得傳回值，會沒有非同步的作用。

			boss.TestEventAsync("2"); // 非同步執行，會最後一個執行完。

			boss.TestEventNormal("3");

			Thread.Sleep(3000); // 延遲幾秒鐘，以等待非同步方法執行完畢。			

			Console.WriteLine("\nAsync result of (1) is: " + retValue); // 最後才印出 (1) 的傳回值。
		}
	}
}
