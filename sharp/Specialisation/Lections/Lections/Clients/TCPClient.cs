using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Clients
{
    public class TCPClient
    {
        public static void Start()
        {
            using (Socket client = new Socket(
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
                Console.WriteLine("Connecting...");
                
                try
                {
                    client.Connect(remoteEndPoint);
                    Console.WriteLine("Connected!");

                    byte[] data = Encoding.UTF8.GetBytes("Привет");
                    int count = client.Send(data);
                    if (count == data.Length)
                        Console.WriteLine($"Отправленно сообщение {Encoding.UTF8.GetString(data)}");
                    else
                        Console.WriteLine("Что то пошло не так");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка подключения." + ex.Message);
                }
                finally { client.Close(); }

                #region Свойства
                var a = client.Connected; //статус подключения
                var b = client.DontFragment; //определяет желание сокета получать фрагментированные пакеты данных (датаграммы)
                var c = client.DualMode; //если сокет работает в двойном режиме адресации (Ip v4 and Ip v6)
                var d = client.EnableBroadcast; // задает возможность сокета посылать широковещательные пакеты
                var e = client.Handle; // дескриптор сокета, который можно использовать на уровне ОС
                var f = client.IsBound; //Показывает привязан ли сокет к какому нибудь порту
                var j = client.LingerState; // хранит объект одноименного класса; Отвечает за то сколько времени будет продолжаться отправка данных после вызова Close клиента
                var h = client.NoDelay; // отправка сообщений без задержки
                var i = client.ProtocolType; // типо протокола
                var k = client.LocalEndPoint; // хранит реквизиты локального endPoint
                var l = client.ReceiveBufferSize; // размер буфера сообщений
                var m = client.ReceiveTimeout; //таймайт в методе ресейв, по умолчанию 0 ( бесконечно)
                var n = client.SendTimeout; //таймаут для отправки сообщения

                #endregion
            }
        }
    }
}
