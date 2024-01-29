namespace WebApiLibrary.DataStore.Models
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public Guid SenderEmail { get; set; }
        public Guid RecipientEmail { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
    }
}
