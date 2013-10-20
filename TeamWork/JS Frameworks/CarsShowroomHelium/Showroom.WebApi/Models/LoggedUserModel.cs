namespace Showroom.WebApi.Models
{
    using System;   
    using System.Linq;
    using System.Runtime.Serialization;
    
    [DataContract]
    public class LoggedUserModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        
        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        [DataMember(Name = "isAdmin")]
        public bool IsAdmin { get; set; }
    }
}