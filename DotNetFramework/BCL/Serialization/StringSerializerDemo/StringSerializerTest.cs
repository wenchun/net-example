using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoCAD.CommonUtilities;

namespace StringSerializerDemo
{
    class StringSerializerTest
    {
        public void Run(object data)
        {
            Console.WriteLine("\n======== StringSerializerTest ========");

            string s = Serialize(data);
            Deserialize(s);
        }

        string Serialize(object data)
        {            
            StringSerializer ss = new StringSerializer();
            string s = ss.Serialize(data);
            Console.WriteLine("Serialize: " + s);
            Console.WriteLine("Totally {0} bytes.", s.Length);

            return s;
        }

        void Deserialize(string s)
        {
            StringSerializer ss = new StringSerializer();
            object newObj = ss.Deserialize(s);
            SharedClasses.Student stu = (SharedClasses.Student)newObj;
            Console.WriteLine("\nDeserialized: " + stu.Addr.City);
        }

    }
}
