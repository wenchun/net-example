using System;

namespace RealIPAddress
{
	/// <summary>
	/// Summary description for MyNetworkStream.
	/// </summary>
	public class MyNetworkStream : System.Net.Sockets.NetworkStream
	{
		public MyNetworkStream(System.Net.Sockets.Socket sckt) : base(sckt)
		{
		}
	
		public System.Net.Sockets.Socket get_MySocket() 
		{
			return base.Socket;
		}

		public String get_IPAddress() 
		{
			System.Net.Sockets.Socket sckt = base.Socket;
			System.Net.EndPoint endpt = sckt.RemoteEndPoint;
			return endpt.ToString();
		}
	}
}
