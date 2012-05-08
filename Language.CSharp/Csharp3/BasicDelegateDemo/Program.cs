using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BasicDelegateDemo
{
    public delegate bool Predicate(string s);  // 步驟 1: 定義委派型別.

    public class StringList
    {
        // 我知道用 ArrayList 看起來很蠢。我想還是別用泛型讓此範例變得更複雜。
        private ArrayList strings;  

        public StringList()
        {
            // 在建構元裡面就填好字串內容...也很蠢，實際上當然不會這樣寫!
            strings = new ArrayList();
            strings.Add("Banana");
            strings.Add("Apple");
            strings.Add("Mango");
        }

        public string Find(Predicate p)
        {
            for (int i = 0; i < strings.Count; i++)
            {
                string s = (string) strings[i];
                bool isMatch = p(s);  // 步驟 4: 執行委派任務. 等同於 p.Invoke(s)
                if (isMatch)    // 目前的字串符合呼叫端的比對條件？
                {
                    return s; 
                }
            }
            return "";  // 找不到，傳回空字串
        }
    }

	/// <summary>
	/// 示範 C# 1.0 的委派寫法.
	/// </summary>
	public class DelegateDemoVer1
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = new Predicate(FindMango); // 步驟 3: 建立委派物件

			string s = fruits.Find(p);

			//s = fruits.Find(FindMango);	// C# 2.0 可以這樣寫.

			Console.WriteLine(s);
		}

		// 步驟 2: 撰寫符合委派型別所宣告的委派方法。
		bool FindMango(string s)
		{
			return s.EndsWith("go");
		}
	}

	/// <summary>
	/// 示範 C# 2.0 的委派寫法.
	/// </summary>
	public class DelegateDemoVer2
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = delegate(string s)   // 步驟 3: 建立委派物件（使用 C# 2.0 的匿名方法）
			{
				return s.EndsWith("go");
			};
			Console.WriteLine(fruits.Find(p));
		}
	}

	public class DelegateDemoVer3
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = (string s) => { return s.EndsWith("go"); };  // 步驟 3: 建立委派物件（使用 Lambda 表示式）
			Console.WriteLine(fruits.Find(p));
		}
	}

	public class DelegateDemoVer3_Shorter
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = (string s) => s.EndsWith("go");  // 步驟 3: 建立委派物件（簡化的 Lambda 表示式）
			Console.WriteLine(fruits.Find(p));
		}
	}

	public class DelegateDemoVer3_Final
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = s => s.EndsWith("go");  // 步驟 3: 建立委派物件（最簡化的 Lambda 表示式）
			Console.WriteLine(fruits.Find(p));
		}
	}


    class Program
    {
        static void Main(string[] args)
        {
			DelegateDemoVer1 demo1 = new DelegateDemoVer1();
			demo1.Run();

			DelegateDemoVer2 demo2 = new DelegateDemoVer2();
			demo2.Run();

			DelegateDemoVer3 demo3 = new DelegateDemoVer3();
			demo3.Run();

			DelegateDemoVer3_Shorter demo3s = new DelegateDemoVer3_Shorter();
			demo3s.Run();

			DelegateDemoVer3_Final demo3f = new DelegateDemoVer3_Final();
			demo3f.Run();
	
		}
    }
}
