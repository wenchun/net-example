using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApplication1
{
	// 士兵（提供服務的元件）
	class Soldier
	{
		// 執行任務。傳回值: 任務成功/失敗的訊息。
		// missionName: 任務名稱
		public string DoMission(String missionName) 
		{
			Thread.Sleep(2000); // 假設任務需要花這些時間執行。
			Random r = new Random((int)DateTime.Now.Ticks);
			if (r.Next() % 2 == 0)
				return "成功";
			else
				return "失敗";
		}
	}

	/// 以下是 client code 的部份 -------------------------------

	// 為了以非同步的方式令士兵執行任務，必須宣告一個委派型別（因為士兵本身未提供非同步執行方法）。
	public delegate string MissionCompletedEventHandler(String missionName);

	// 排長
	class Captain
	{
		// Completion callback
		private static void OnComplete(IAsyncResult arIntf)
		{
			AsyncResult ar = (AsyncResult) arIntf;
			MissionCompletedEventHandler handler = (MissionCompletedEventHandler) ar.AsyncDelegate;
			string result = handler.EndInvoke(ar);
			Console.WriteLine("Mission C " + result);
		}

		[STAThread]
		static void Main(string[] args)
		{
			MissionCompletedEventHandler MissionCompleted = null;

			Soldier soldier = new Soldier();
			String result;
		
			// 同步呼叫。
			Console.WriteLine("Mission A begins synchronously...");
			result = soldier.DoMission("A");
			Console.WriteLine("Mission A " + result);
			
			// 非同步呼叫，使用 EndInvoke 取得執行結果。
			Console.WriteLine("Mission B begins asynchrously....");
			MissionCompleted = new MissionCompletedEventHandler(soldier.DoMission);
			IAsyncResult ar = MissionCompleted.BeginInvoke("B", null, null);
			Console.WriteLine("Now captain can do his work....");
			Thread.Sleep(3000);
			result = MissionCompleted.EndInvoke(ar);
			Console.WriteLine("Mission B " + result);

			// 非同步呼叫，使用 completion callback 得知結果。						
			AsyncCallback cb = new AsyncCallback(Captain.OnComplete);
			MissionCompleted = new MissionCompletedEventHandler(soldier.DoMission);
			Console.WriteLine("Mission C begins asynchrously, with completion callback....");
			MissionCompleted.BeginInvoke("C", cb, null);
			Console.WriteLine("Now captain can fire and forget, until he get a callback....");
			Thread.Sleep(3000);			
		}
	}
}
