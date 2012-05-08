using System;
using System.Threading;
using System.Windows.Forms;

namespace DemoBossWorker1
{
	/// <summary>
	/// ��� Windows Forms Programming in C# by Chris Sells ������ B ���Ҥl
	/// </summary>

	public delegate int WorkCompletedEventHandler();

	class Worker
	{
		public event WorkCompletedEventHandler WorkCompleted;

		public void DoWork() 
		{
			Console.WriteLine("�u�H�G�}�l�u�@�F�C");
			if (WorkCompleted != null) 
			{
				// �D�P�B�I�s�ɡ]�Y�I�s BeginInvoke() �ɡ^�A�u�঳�@�� target call back method�C
				// �� Main() �̭��[�J�F��� callback method�A�]���U���o��|�ɭP System.ArgumentException�C
				// WorkCompleted.BeginInvoke(null, null);

				// �D�P�B�I�s�A���h�� callback method �ɪ��зǧ@�k�G
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
			Console.WriteLine("���󦬨�u�H���q���G�u�@�w�g�����F�C");
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
			Console.WriteLine("Universe ����u�H���q���G�u�@�w�g�����F�C");
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

			Console.WriteLine("Main: �D������w�B�z�����A�������ε{�������C");
			Console.ReadLine();
		}
	}
}
