using System.Runtime.Serialization;
using System;
using System.Linq;
using Blog.Model;

namespace ForumWebApi.Models.Users
{
    [DataContract]
    public class UserLogginModel
    {
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "displayName")]
        public string NickName { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }

        public User CreateUser()
        {
            return new User
            {
                Displayname = this.NickName,
                Username = this.UserName,
                Authcode = this.AuthCode
            };
        }
    }
}