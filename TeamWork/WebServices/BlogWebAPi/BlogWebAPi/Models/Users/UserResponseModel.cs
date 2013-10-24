using System;
using System.Linq;
using System.Runtime.Serialization;

namespace BlogWebAPi.Models.Users
{
    [DataContract]
    public class UserResponseModel
    {
        [DataMember(Name = "displayName")]
        public string NickName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}