using System.Text.Json;

namespace Seminar2._1
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string NickNameFrom { get; set; }
        public string NickNameTo { get; set; }

        public string SerializeMessageToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message? DeserializeJsonToMessage(string mess)
        {
            return JsonSerializer.Deserialize<Message>(mess);
        }

        public override string ToString()
        {
            return $"Полученно сообщение {Text} от {NickNameFrom}, Время {Time}";
        }
    }
}
