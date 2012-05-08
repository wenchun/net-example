using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethodDemo
{
	public static class StringExtension
	{
		// 字串反轉
		public static string Reverse(this string s)
		{
			if (String.IsNullOrEmpty(s))
				return "";
			char[] charArray = new char[s.Length];
			int len = s.Length - 1;
			for (int i = 0; i <= len; i++)
			{
				charArray[i] = s[len - i];
			}
			return new string(charArray);
		}
	}

	public static class DateTimeExt
	{
		// 將日期格式化成
		public static string ToRocDate(this DateTime date, char separator)
		{
			int year = (date.Year - 1911);
			return year.ToString() + separator + date.Month + separator + date.Day;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			string s = "123456789";
			Console.WriteLine(StringExtension.Reverse(s));	// 一般的靜態方法呼叫.
			Console.WriteLine(s.Reverse());					// 擴充方法呼叫.
			Console.WriteLine(DateTime.Now.ToRocDate('.'));
			
		}
	}
}
