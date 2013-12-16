namespace Skeleton.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Skeleton.Models;
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
    }
}