namespace Showroom.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Engine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
