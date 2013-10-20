namespace Showroom.WebApi.Models
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;    
    using System.Runtime.Serialization;

    [DataContract]
    public class FullUserModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }


        [DataMember(Name = "offers")]
        public ICollection<OfferModel> Offers { get; set; }
    }
}