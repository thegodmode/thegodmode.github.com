namespace Showroom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public class User
    {
        public User()
        {
            this.Offers = new HashSet<Offer>();
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        public string AuthCode { get; set; }

        public string SessionKey { get; set; }
        
        public bool IsAdmin { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
