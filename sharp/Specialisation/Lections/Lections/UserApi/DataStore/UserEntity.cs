namespace UserApi.DataStore
{
    public class UserEntity
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SurName { get; set; }
        public DateTime Registered { get; set; } = DateTime.UtcNow;
        public bool Active { get; set; }
    }
}
