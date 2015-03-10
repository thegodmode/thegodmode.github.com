namespace Showroom.WebApi.Models
{
    using Showroom.Models;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    [DataContract]
    public class ModelsModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public static Expression<Func<Model, ModelsModel>> FromModel
        {
            get
            {
                return x => new ModelsModel
                {
                    Id = x.Id,
                    Name = x.Name
                };
            }
        }
    }
}