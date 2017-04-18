using System;
using System.Collections.Generic;

namespace Service.Interfaces.Entities
{
    public class NewsEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan CreationTime { get; set; }
        public int CategoryId { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }


        public List<CommentEntity> Comments { get; set; }
        public string Category { get; set; }
    }
}