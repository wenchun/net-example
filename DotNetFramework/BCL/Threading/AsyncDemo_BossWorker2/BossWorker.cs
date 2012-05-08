using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

/*
 * ���d�ҬO�e�@�Ӫ�������}���A�� Worker ���󥻨����ثD�P�B��k�A�Y
 * �ĥ� Begin<Operation> �P End<Operation> �� pattern �өR�W�C
 * Note: �����ت����g�k�����P�A�H�ι�Τ�ݦ�����v�T�C
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
		public int Work(string taskName) 
		{
			Console.WriteLine("Worker: I'm busy working...");
			Thread.Sleep(3000); // ���]���Ȼݭn��o�Ǯɶ�����C
			Console.WriteLine("Worker: I'm done.");
			Random r = new Random((int)DateTime.Now.Ticks);
			return (r.Next() % 20 + 1);
		}

		public IAsyncResult BeginWork(string taskName, AsyncCallback cb, object userData)
		{
			WorkCompletedEventHandler handler = new WorkCompletedEventHandler(this.Work);
			return handler.BeginInvoke(taskName, cb, userData);
		}

		public int EndWork(IAsyncResult arIntf)
		{
			AsyncResult ar = (AsyncResult) arIntf;
			WorkCompletedEventHandler handler = (WorkCompletedEventHandler) ar.AsyncDelegate;
			int	hours = handler.EndInvoke(arIntf);
			return hours;
		}
	}

	/// �H�U�O client code ������ -------------------------------

	// ���F�H�D�P�B���覡�O���u������ȡA�����ŧi�@�өe�����O�]�]�����u���������ѫD�P�B�����k�^�C
	public delegate int WorkCompletedEventHandler(string taskName);

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
			Console.WriteLine("Boss  : Run task B2 asynchrously, using Begin<Opr> and End<Opr> pattern....");
			IAsyncResult ar = peter.BeginWork("B", null, null);
			Console.WriteLine("Boss  : Now I can take a nap....");
			Thread.Sleep(4000);
			int hours = peter.EndWork(ar);
			Console.WriteLine("Boss  : Ok! Task B is completed in {0} hours.\n", hours);
		}

		// �D�P�B�I�s�A�ϥ� completion callback �o�����G�C						
		public void RunAsyncWithCallback()
		{
			Worker peter = new Worker();
			AsyncCallback cb = new AsyncCallback(this.OnComplete);			
			Console.WriteLine("Boss  : Run task C asynchrously, with completion callback....");
			IAsyncResult ar = peter.BeginWork("C", cb, null);
			Console.WriteLine("Boss  : Now I can fire and forget, until peter notify me....");
			Thread.Sleep(4000);			
		}

		// Completion callback
		private void OnComplete(IAsyncResult arIntf)
		{
			// �`�N: �o�̥i�H�Χ������P������Ө��o���e�I�s���Ǧ^��!!
			Worker peter = new Worker();
			int hours = peter.EndWork(arIntf);	
			Console.WriteLine("Boss  : Got it! It takes you {0} hours to complete task C.\n", hours);
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
