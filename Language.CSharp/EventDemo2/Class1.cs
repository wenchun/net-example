using System;
using System.ComponentModel;

namespace EventDemo
{
	internal class MyEventArgs : EventArgs
	{
		private int m_Num;

		public MyEventArgs(int num)
		{
			m_Num = num;
		}

		public int Num
		{
			get 
			{
				return m_Num;
			}
		}
	}

	internal class MyPublisher
	{
		private EventHandlerList m_Events;
		
		public MyPublisher()
		{
			m_Events = new EventHandlerList();
		}

		public event EventHandler NumberChanged
		{
			add
			{
				m_Events.AddHandler("NumberChanged", value);
			}
			remove 
			{
				m_Events.RemoveHandler("NumberChanged", value);
			}
		}

		public void FireEvent(object sender, EventArgs ea)
		{
			EventHandler handler = (EventHandler) m_Events["NumberChanged"];
			if (handler!= null)
				handler(sender, ea);
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
			MyPublisher pub = new MyPublisher();
			pub.NumberChanged += new EventHandler(NumberChangedHandler);	

			// Fire the event!
			MyEventArgs ea = new MyEventArgs(10);
			pub.FireEvent(null, ea);
		}

		private static void NumberChangedHandler(object sender, EventArgs e)
		{
			MyEventArgs args = (MyEventArgs) e;
			Console.WriteLine("NumberChanged: " + args.Num.ToString());
		}
	}
}
