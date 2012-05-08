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

	/// <summary>
	/// �ܽd C# 1.0 ���e���g�k.
	/// </summary>
	public class DelegateDemoVer1
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = new Predicate(FindMango); // �B�J 3: �إߩe������

			string s = fruits.Find(p);

			//s = fruits.Find(FindMango);	// C# 2.0 �i�H�o�˼g.

			Console.WriteLine(s);
		}

		// �B�J 2: ���g�ŦX�e�����O�ҫŧi���e����k�C
		bool FindMango(string s)
		{
			return s.EndsWith("go");
		}
	}

	/// <summary>
	/// �ܽd C# 2.0 ���e���g�k.
	/// </summary>
	public class DelegateDemoVer2
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = delegate(string s)   // �B�J 3: �إߩe������]�ϥ� C# 2.0 ���ΦW��k�^
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

			Predicate p = (string s) => { return s.EndsWith("go"); };  // �B�J 3: �إߩe������]�ϥ� Lambda ��ܦ��^
			Console.WriteLine(fruits.Find(p));
		}
	}

	public class DelegateDemoVer3_Shorter
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = (string s) => s.EndsWith("go");  // �B�J 3: �إߩe������]²�ƪ� Lambda ��ܦ��^
			Console.WriteLine(fruits.Find(p));
		}
	}

	public class DelegateDemoVer3_Final
	{
		public void Run()
		{
			StringList fruits = new StringList();

			Predicate p = s => s.EndsWith("go");  // �B�J 3: �إߩe������]��²�ƪ� Lambda ��ܦ��^
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
