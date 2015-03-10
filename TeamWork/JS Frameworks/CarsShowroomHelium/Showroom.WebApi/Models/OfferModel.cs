namespace Showroom.WebApi.Models
{
    using Showroom.Models;
    using System;    
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    
    [DataContract]
    public class OfferModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }        

        public static Expression<Func<Offer, OfferModel>> FromOffer
        {
            get
            {
                return x => new OfferModel
                {
                    Id = x.Id,
                    Title = x.Title
                };
            }
        }
    }
}