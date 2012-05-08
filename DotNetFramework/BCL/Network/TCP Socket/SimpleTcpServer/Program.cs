using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace SimpleTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTcpServer svr = new MyTcpServer();
        }
    }
}
