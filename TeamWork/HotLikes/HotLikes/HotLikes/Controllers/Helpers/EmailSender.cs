using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotLikes.Controllers.Helpers
{
    public class EmailSender
    {
        public static void SendEmail(string to, string name, string key, string userId)
        {
            dynamic email = new Email("Verification");
            email.To = to;
            email.FullName = name;
            email.VerificationKey = key;
            email.UserId = userId;
            email.Send();
            
        }
    }
}