namespace Seminar_2_5.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsSend { get; set; }
        public int UserTo { get; set; }
        public int UserFrom { get; set; }

    }
}
