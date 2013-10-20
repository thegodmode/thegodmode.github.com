namespace Showroom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;    

    public class Offer
    {
        public Offer()
        {
            this.Comments = new HashSet<Comment>();           
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }        

        [Required]
        public string Location { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        
        public string PictureUrl { get; set; }

        public virtual Car Car { get; set; }
        
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }        
    }
}
