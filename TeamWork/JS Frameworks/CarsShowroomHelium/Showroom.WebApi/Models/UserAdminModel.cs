namespace Showroom.WebApi.Models
{
    using Showroom.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    
    [DataContract]
    public class UserAdminModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "isAdmin")]
        public bool IsAdmin { get; set; }

        [DataMember(Name = "offersTitles")]
        public IQueryable<OfferModel> OffersTitles { get; set; }

        public static Expression<Func<User, UserAdminModel>> FromUser
        {
            get
            {
                return x => new UserAdminModel
                {
                    Username = x.Username,
                    IsAdmin = x.IsAdmin,
                    OffersTitles = x.Offers.AsQueryable().Select(OfferModel.FromOffer)
                };
            }
        }
    }
}