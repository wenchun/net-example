using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace ConsoleApplication1
{
	// �h�L�]���ѪA�Ȫ�����^
	class Soldier
	{
		// ������ȡC�Ǧ^��: ���Ȧ��\/���Ѫ��T���C
		// missionName: ���ȦW��
		public string DoMission(String missionName) 
		{
			Thread.Sleep(2000); // ���]���Ȼݭn��o�Ǯɶ�����C
			Random r = new Random((int)DateTime.Now.Ticks);
			if (r.Next() % 2 == 0)
				return "���\";
			else
				return "����";
		}
	}

	/// �H�U�O client code ������ -------------------------------

	// ���F�H�D�P�B���覡�O�h�L������ȡA�����ŧi�@�өe�����O�]�]���h�L���������ѫD�P�B�����k�^�C
	public delegate string MissionCompletedEventHandler(String missionName);

	// �ƪ�
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
		
			// �P�B�I�s�C
			Console.WriteLine("Mission A begins synchronously...");
			result = soldier.DoMission("A");
			Console.WriteLine("Mission A " + result);
			
			// �D�P�B�I�s�A�ϥ� EndInvoke ���o���浲�G�C
			Console.WriteLine("Mission B begins asynchrously....");
			MissionCompleted = new MissionCompletedEventHandler(soldier.DoMission);
			IAsyncResult ar = MissionCompleted.BeginInvoke("B", null, null);
			Console.WriteLine("Now captain can do his work....");
			Thread.Sleep(3000);
			result = MissionCompleted.EndInvoke(ar);
			Console.WriteLine("Mission B " + result);

			// �D�P�B�I�s�A�ϥ� completion callback �o�����G�C						
			AsyncCallback cb = new AsyncCallback(Captain.OnComplete);
			MissionCompleted = new MissionCompletedEventHandler(soldier.DoMission);
			Console.WriteLine("Mission C begins asynchrously, with completion callback....");
			MissionCompleted.BeginInvoke("C", cb, null);
			Console.WriteLine("Now captain can fire and forget, until he get a callback....");
			Thread.Sleep(3000);			
		}
	}
}
