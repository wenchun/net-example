using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson; 

namespace StringSerializerDemo
{
    class BsonTest
    {
        public void Run(object data)
        {
            Console.WriteLine("\n======== BsonTest ========");

            byte[] buf = Serialize(data);
            Deserialize(buf);
        }

        byte[] Serialize(object data)
        {
            MemoryStream ms = new MemoryStream();
            JsonSerializer serializer = new JsonSerializer();

            // serialize product to BSON
            BsonWriter writer = new BsonWriter(ms);
            serializer.Serialize(writer, data);

            byte[] byteArray = ms.ToArray();
            Console.WriteLine(BitConverter.ToString(byteArray));
            Console.WriteLine("\nTotally {0} bytes.", ms.Length);

            return byteArray;
        }

        void Deserialize(byte[] data)
        {

        }
    }
}
