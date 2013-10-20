namespace Showroom.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Car
    {
        public Car()
        {
            this.Features = new HashSet<Feature>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public DateTime Year { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Model Model { get; set; }

        public virtual Gearbox GearboxType { get; set; }
        
        public virtual Engine EngineType { get; set; }
        
        public virtual Color Color { get; set; }

        public virtual ICollection<Feature> Features { get; set; }
    }
}
