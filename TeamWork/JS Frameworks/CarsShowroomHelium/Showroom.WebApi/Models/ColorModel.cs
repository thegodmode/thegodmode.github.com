namespace Showroom.WebApi.Models
{
    using Showroom.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    [DataContract]
    public class ColorModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public static Expression<Func<Color, ColorModel>> FromColor
        {
            get
            {
                return x => new ColorModel
                {
                    Id = x.Id,
                    Name = x.Name
                };
            }
        }
    }
}