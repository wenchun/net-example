using System;

namespace StrRefEqualDemo
{

	class Class1
	{

		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Test string reference equality.");

			string s1 = "hello";
			string s2 = "hello";
			bool isEqual = Object.ReferenceEquals(s1, s2);
			Console.WriteLine("1: {0}", isEqual);

			s2 = "hell" + s1.Substring(4);
			isEqual = Object.ReferenceEquals(s1, s2);
			Console.WriteLine("2: {0}", isEqual);

			s2 = s1.ToString();
			isEqual = Object.ReferenceEquals(s1, s2);
			Console.WriteLine("3: {0}", isEqual);

			s2 = (string)s1.Clone();
			isEqual = Object.ReferenceEquals(s1, s2);
			Console.WriteLine("4: {0}", isEqual);

			s2 = String.Copy(s1);
			isEqual = Object.ReferenceEquals(s1, s2);
			Console.WriteLine("5: {0} ", isEqual);

			s2 = null;
			isEqual = (s2 == "");
			Console.WriteLine("6: {0} ", isEqual);

		}
	}
}
