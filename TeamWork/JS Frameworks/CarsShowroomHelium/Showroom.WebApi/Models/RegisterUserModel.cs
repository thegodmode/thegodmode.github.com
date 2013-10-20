namespace Showroom.WebApi.Models
{
    using System;    
    using System.Linq;
    using System.Runtime.Serialization;    

    [DataContract]
    public class RegisterUserModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }

    }
}