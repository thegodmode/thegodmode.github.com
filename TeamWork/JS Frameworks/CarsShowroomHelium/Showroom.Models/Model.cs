namespace Showroom.Models
{
    using System;    
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public virtual Brand Brand { get; set; }
    }
}
