using System;
using System.Threading;
using System.Windows.Forms;

namespace EventDemoAsync1
{
	public delegate int WorkCompletedEventHandler(string workerName);

	/// <summary>
	/// ��� Windows Forms Programming in C# by Chris Sells ������ B ���Ҥl
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
			Thread.Sleep(1000); // �G�N���� 1 ��A�����t�������u�@ or ����εۤF�C
			Console.WriteLine("Async work completed by : " + workerName);			
			return 2;
		}

		// �P�B�I�s�C
		public void TestEventNormal(string workerName)
		{
			// �ϥΩe������²��Φ��G�إߤ@�өe������A�өe�����󤺧t�@�� callback ��k�Ѧ�
			WorkCompletedEventHandler handler = new WorkCompletedEventHandler(this.OnWorkCompleted);
			handler(workerName);  // Ĳ�o�ƥ�
		}

		// �D�P�B�I�s�A���b�G�Ǧ^�ȡC
		public void TestEventAsync(string workerName)
		{
			WorkCompletedEventHandler handler = new WorkCompletedEventHandler(this.OnWorkCompletedAsync);
			// ��U���o��������ѡA�|�y������ɥX�{ System.ArgumentException�A�]���D�P�B�I�s�u���\�@�� target�C
			handler += new WorkCompletedEventHandler(this.OnWorkCompletedAsync);
			handler.BeginInvoke(workerName, null, null);
		}

		// �D�P�B�I�s�A�n���o�Ǧ^�ȡC
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

			int retValue = boss.TestEventAsyncResult("1"); // �ѩ�|���o�Ǧ^�ȡA�|�S���D�P�B���@�ΡC

			boss.TestEventAsync("2"); // �D�P�B����A�|�̫�@�Ӱ��槹�C

			boss.TestEventNormal("3");

			Thread.Sleep(3000); // ����X�����A�H���ݫD�P�B��k���槹���C			

			Console.WriteLine("\nAsync result of (1) is: " + retValue); // �̫�~�L�X (1) ���Ǧ^�ȡC
		}
	}
}
