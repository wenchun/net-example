using System;
using System.Threading;
using System.Diagnostics;

namespace WaitHandleDemo
{
	public class WaitHandleDemo
	{
		private ManualResetEvent m_Event;
		private Thread m_Thread;
		private bool m_ExitThread = false;

		public WaitHandleDemo()
		{
			// �إ߮ɴN���w�䪬�A�� unsignaled�]���L������I�s WaitXxx �ɷ|�Q blocked�^�C
			m_Event = new ManualResetEvent(false); 

			ThreadStart threadStart = new ThreadStart(DoWork);
			m_Thread = new Thread(threadStart);
			m_Thread.Start();
		}

		public void DoWork()
		{
			int counter = 0;
			while (!m_ExitThread) 
			{
				counter++;
				Console.WriteLine("Iteration #" + counter);

				m_Event.WaitOne();
			}
		}

		public void GoThread()
		{
			m_Event.Set();
			Console.WriteLine("Go Thread!");
		}

		public void StopThread()
		{
			m_Event.Reset();
			Console.WriteLine("Stop Thread!");
		}

		public void Dispose()
		{
			Kill();
		}

		public void Kill()
		{
			if (m_Thread == null)
				return;
			m_ExitThread = true;
			m_Event.Set(); // �`�N�G�n�b�����e�I�s Set()�A�_�h������i��|�û� block ��C
			m_Event.Close();
			m_Thread.Join();
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
			WaitHandleDemo demo = new WaitHandleDemo();
			demo.GoThread();
			Thread.Sleep(1);
			demo.StopThread();
			Thread.Sleep(1);
			demo.GoThread();
			Thread.Sleep(1);
			demo.StopThread();
			Thread.Sleep(1000);
			demo.Dispose();
		}
	}
}
