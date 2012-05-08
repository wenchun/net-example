using System;

namespace EventDemo1
{
	public delegate void NumberChangedEventHandler(int num);

	class MyPublisher
	{
		public NumberChangedEventHandler NumberChanged;

		public void FireEvent()
		{
			NumberChanged(20);
		}
	}

	class MySubscriber
	{
		public void OnNumberChanged(int num)
		{
			Console.WriteLine("Number is " + num);
		}

		public void TestEvent1()
		{
			// �ϥΩe������²��Φ��G�إߤ@�өe������A�өe�����󤺧t�@�� callback ��k�Ѧ�
			NumberChangedEventHandler handler = new NumberChangedEventHandler(this.OnNumberChanged);
			handler(10);  // Ĳ�o�ƥ��
		}

		public void TestEvent2()
		{
			MyPublisher publisher = new MyPublisher();
			publisher.NumberChanged += new NumberChangedEventHandler(this.OnNumberChanged);
			publisher.FireEvent();
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
			MySubscriber subscriber = new MySubscriber();
			subscriber.TestEvent1();
			subscriber.TestEvent2();
		}
	}
}
