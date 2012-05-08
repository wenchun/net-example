using System;
using System.Threading;
using System.Windows.Forms;

namespace DemoBossWorker1
{
	/// <summary>
	/// 仿照 Windows Forms Programming in C# by Chris Sells 的附錄 B 的例子
	/// </summary>

	public delegate int WorkCompletedEventHandler();

	class Worker
	{
		public event WorkCompletedEventHandler WorkCompleted;

		public void DoWork() 
		{
			Console.WriteLine("工人：開始工作了。");
			if (WorkCompleted != null) 
			{
				// 非同步呼叫時（即呼叫 BeginInvoke() 時），只能有一個 target call back method。
				// 而 Main() 裡面加入了兩個 callback method，因此下面這行會導致 System.ArgumentException。
				// WorkCompleted.BeginInvoke(null, null);

				// 非同步呼叫，有多個 callback method 時的標準作法：
				foreach (WorkCompletedEventHandler wceh in WorkCompleted.GetInvocationList()) 
				{
					wceh.BeginInvoke(null, null);
				}
			}
		}
	}

	class Boss
	{
		public int OnWorkCompleted()
		{			
			System.Threading.Thread.Sleep(3000);
			Console.WriteLine("老闆收到工人的通知：工作已經完成了。");
			return 6; // grade
		}
	}


	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Universe
	{
		public static int OnWorkCompleted() 
		{
			System.Threading.Thread.Sleep(4000);
			Console.WriteLine("Universe 收到工人的通知：工作已經完成了。");
			return 7;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{			
			Worker michael = new Worker();
			Boss boss = new Boss();

			michael.WorkCompleted += new WorkCompletedEventHandler(boss.OnWorkCompleted);
			michael.WorkCompleted += new WorkCompletedEventHandler(OnWorkCompleted);
			michael.DoWork();

			Console.WriteLine("Main: 主執行緒已處理完畢，等待應用程式結束。");
			Console.ReadLine();
		}
	}
}
