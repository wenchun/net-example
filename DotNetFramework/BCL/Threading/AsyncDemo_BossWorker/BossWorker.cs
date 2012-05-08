using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

/*
 * ���d�Үi�ܷ��󥻨������ѫD�P�B�I�s��k Begin<Operation> �P End<Operation> �ɡA
 * �Τ�ݦp��Q�Ωe���ӹ�{�D�P�B�I�s�C
 * 
 * Written by Huan-Lin Tsai. Jun-23-2005.
 */
namespace AsyncDemo_BossWorker
{
	// ���u�]���ѪA�Ȫ�����^
	class Worker
	{
		// ����u�@�C�Ǧ^��: ��O���u�ɡ]hours�^�C
		//taskName: �u�@�W�١C
		public int Work(String taskName) 
		{
			Console.WriteLine("Worker: I'm busy working...");
			Thread.Sleep(3000); // ���]���Ȼݭn��o�Ǯɶ�����C
			Console.WriteLine("Worker: I'm done.");
			Random r = new Random((int)DateTime.Now.Ticks);
			return (r.Next() % 20 + 1);
		}
	}

	/// �H�U�O client code ������ -------------------------------

	// ���F�H�D�P�B���覡�O���u������ȡA�����ŧi�@�өe�����O�]�]�����u���������ѫD�P�B�����k�^�C
	public delegate int WorkCompletedEventHandler(String taskName);

	// ����
	class Boss
	{
		public WorkCompletedEventHandler WorkCompleted = null;

		// �P�B�I�s�C
		public void RunSync()
		{
			Worker peter = new Worker();
			Console.WriteLine("Boss  : Run task A synchronously...");
			int hours = peter.Work("A");
			Console.WriteLine("Boss  : Ok! Task A is completed in {0} hours.\n", hours);
		}

		// �D�P�B�I�s�A�ϥ� EndInvoke ���o���浲�G�C
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

		// �D�P�B�I�s�A�ϥ� completion callback �o�����G�C						
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
