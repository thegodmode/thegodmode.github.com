namespace Skeleton.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDay { get; set; }

        public string Name { get; set; }
    }
}