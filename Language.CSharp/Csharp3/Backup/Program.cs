using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BasicDelegateDemo
{
    public delegate bool Predicate(string s);  // �B�J 1: �w�q�e�����O.

    public class StringList
    {
        // �ڪ��D�� ArrayList �ݰ_�ӫ����C�ڷQ�٬O�O�Ϊx�������d���ܱo������C
        private ArrayList strings;  

        public StringList()
        {
            // �b�غc���̭��N��n�r�ꤺ�e...�]�����A��ڤW��M���|�o�˼g!
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
                bool isMatch = p(s);  // �B�J 4: ����e������. ���P�� p.Invoke(s)
                if (isMatch)    // �ثe���r��ŦX�I�s�ݪ�������H
                {
                    return s; 
                }
            }
            return "";  // �䤣��A�Ǧ^�Ŧr��
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StringList fruits = new StringList();

            Predicate p = new Predicate(FindMango); // �B�J 3: �إߩe������

            string s = fruits.Find(p);

            Console.WriteLine(s);

            Predicate p2 = delegate(string s2)   // �ϥ� C# 2.0 ���ΦW��k
            {
                return s2.EndsWith("go");
            };
            Console.WriteLine(fruits.Find(p2));

        }

        // �B�J 2: ���g�ŦX�e�����O�ҫŧi���e����k�C
        static bool FindMango(string s) 
        {
            return s.EndsWith("go");
        }
    }
}
