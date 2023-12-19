using System.Net.Sockets;
using System.Net;
using _server = Network.Server.Server;
using _client = Network.Client.Client;

namespace Network.Client.Test
{
    public class Tests
    {
        [Test()]
        public void TestCase()
        {
            // Setup Listener
            int port = 14580;
            IPEndPoint locep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            // Server (Listener)
            var com = new _server(1);
            com.Start();
            Task.Delay(1000).Wait();
            // Set up sender
            var sender = new _client("127.0.0.1","test");
            // Dummy Data
            var data = new string[] {"server", "text" };
            sender.SendMessage(data);
            Thread.Sleep(1000);
            Assert.AreEqual(true, com.receiveFlag);
        }
    }
}