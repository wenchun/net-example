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
			// 使用委派的最簡單形式：建立一個委派物件，該委派物件內含一個 callback 方法參考
			NumberChangedEventHandler handler = new NumberChangedEventHandler(this.OnNumberChanged);
			handler(10);  // 觸發事件件
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
