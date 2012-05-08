using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InfoCAD.CommonUtilities;

namespace StringSerializerDemo
{
    class Program
    {
        static void Main(string[] args)
        {                       
            var obj = SharedClasses.TestData.CreateStudent();

            StringSerializerTest sst = new StringSerializerTest();
            sst.Run(obj);

            BsonTest bsonTest = new BsonTest();
            bsonTest.Run(obj);

            ZippedJsonTest zjsonTest = new ZippedJsonTest();
            zjsonTest.Run();

        }

    }
}
