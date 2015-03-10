namespace Showroom.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    
    [DataContract]
    public class CarModel
    {            
        [DataMember(Name = "power")]
        public int Power { get; set; }

        [DataMember(Name = "mileage")]
        public int Mileage { get; set; }

        [DataMember(Name = "year")]
        public DateTime Year { get; set; }

        [DataMember(Name = "brand")]
        public string Brand { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "gearbox")]
        public string Gearbox { get; set; }

        [DataMember(Name = "engineType")]
        public string Engine { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "features")]
        public ICollection<string> Features { get; set; }
    }
}