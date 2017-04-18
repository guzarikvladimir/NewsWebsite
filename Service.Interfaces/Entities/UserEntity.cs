namespace Service.Interfaces.Entities
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }


        public string Role { get; set; }
    }
}