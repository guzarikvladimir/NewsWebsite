using System;

namespace Service.Interfaces.Entities
{
    public class CommentEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan CreationTime { get; set; }
        public int UserId { get; set; }
        public int NewId { get; set; }
        public string UserName { get; set; }
    }
}