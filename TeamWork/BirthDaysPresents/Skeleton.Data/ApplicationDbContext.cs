namespace Skeleton.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Skeleton.Models;
    using System.Data.Entity;
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public IDbSet<Presentt> Presentts { get; set; }

        public IDbSet<Offer> Offers { get; set; }

        public IDbSet<Vote> Votes { get; set; }
    }
}