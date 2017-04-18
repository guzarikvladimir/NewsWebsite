namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }

        public TimeSpan CreationTime { get; set; }

        public int UserId { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public virtual User User { get; set; }
    }
}
