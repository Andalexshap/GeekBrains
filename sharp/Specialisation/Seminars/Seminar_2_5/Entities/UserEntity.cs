namespace Seminar_2_5.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<MessageEntity> Messages { get; set; }
    }
}
