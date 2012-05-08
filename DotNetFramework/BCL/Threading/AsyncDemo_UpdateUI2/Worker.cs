using System;
using System.Threading;

namespace AsyncDemo_UpdateUI2
{

	public delegate void WorkCompletedEventHandler();

	/// <summary>
	/// Summary description for Worker.
	/// </summary>
	public class Worker
	{
		private WorkCompletedEventHandler WorkCompleted;

		public Worker()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Work()
		{
		//	Thread.Sleep(2000);
		}

		public IAsyncResult BeginWork(AsyncCallback cb, object userData)
		{
			WorkCompleted = new WorkCompletedEventHandler(this.Work);
			return WorkCompleted.BeginInvoke(cb, null);
		}

		public void EndWork(IAsyncResult arIntf)
		{
			WorkCompleted.EndInvoke(arIntf);
		}
	}
}
