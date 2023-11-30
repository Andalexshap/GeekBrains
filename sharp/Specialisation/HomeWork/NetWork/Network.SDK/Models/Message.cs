namespace Network.SDK.Models
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public User NickNameFrom { get; set; }
        public User NickNameTo { get; set; }

        public Message(string text, User nickNameFrom, User nickNameTo)
        {
            Text = text;
            DateTime = DateTime.Now;
            NickNameFrom = nickNameFrom;
            NickNameTo = nickNameTo;
        }


    }
}