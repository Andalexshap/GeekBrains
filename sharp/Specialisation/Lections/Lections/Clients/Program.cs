using System.Net;
using Clients;

internal class Program
{
    private static void Main(string[] args)
    {
        //TCPClient.Start();
        //ClientMulIp.Start();
        var endPoint1 = new IPEndPoint(IPAddress.Any, 2234);
        var endPoint2 = new IPEndPoint(IPAddress.Any, 2235);
        (new Thread(() => UdpClient.Start(endPoint1,1))).Start();
        (new Thread(() => UdpClient.Start(endPoint2,2))).Start();

        Console.ReadKey();
    }
}