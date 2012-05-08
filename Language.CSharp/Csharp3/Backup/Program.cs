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

    class Program
    {
        static void Main(string[] args)
        {
            StringList fruits = new StringList();

            Predicate p = new Predicate(FindMango); // 步驟 3: 建立委派物件

            string s = fruits.Find(p);

            Console.WriteLine(s);

            Predicate p2 = delegate(string s2)   // 使用 C# 2.0 的匿名方法
            {
                return s2.EndsWith("go");
            };
            Console.WriteLine(fruits.Find(p2));

        }

        // 步驟 2: 撰寫符合委派型別所宣告的委派方法。
        static bool FindMango(string s) 
        {
            return s.EndsWith("go");
        }
    }
}
