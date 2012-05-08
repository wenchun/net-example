using System;
using System.Collections.Generic;
using System.Text;

namespace TestBase36
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string s = DateTime.Now.ToString("MMddHHmmssffffff");
            long num = Convert.ToInt64(s);
            Console.WriteLine(Base36.Encode(num));
            long value = Base36.Decode("ZZZZZZZZZZ");
            Console.WriteLine("3656158440062975 = " + value.ToString());
        }
    }

    public static class Base36
    {
        private const string CharList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Encode the given number into a Base36 string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String Encode(long input)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException("input", input, "input cannot be negative!");
            }

            char[] clistarr = CharList.ToCharArray();
            var result = new Stack<char>();
            while (input != 0)
            {
                result.Push(clistarr[input % 36]);
                input /= 36;
            }
            return new string(result.ToArray());
        }

        /// <summary>
        /// Decode the Base36 Encoded string into a number.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Int64 Decode(string input)
        {
            var reversed = input.TrimStart('0').ToUpper().Reverse();
            long result = 0;
            int pos = 0;
            foreach (char c in reversed)
            {
                result += CharList.IndexOf(c) * (long)Math.Pow(36, pos);
                pos++;
            }
            return result;
        }
    }
}