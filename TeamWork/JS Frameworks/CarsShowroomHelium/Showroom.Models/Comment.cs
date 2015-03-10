namespace Showroom.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual User User { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
