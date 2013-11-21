namespace HotLikes.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Linq;
  
    public class ExtendedUser : User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public string VerificationKey { get; set; }

        public bool IsVerified { get; set; }

        public string ImageUrl { get; set; }
        
    }
}