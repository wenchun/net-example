using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SimpleTcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcp = new TcpClient();
            tcp.Connect("127.0.0.1", 3000);
            NetworkStream stream = tcp.GetStream();
            stream.WriteByte(0x41);
            stream.WriteByte(0x00);
            stream.Close();
            tcp.Close();
        }
    }
}
