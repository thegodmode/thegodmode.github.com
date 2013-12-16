namespace Skeleton.Data
{
    using System;
    using System.Linq;
    using Skeleton.Models;
    
    public interface IUowData : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }
      
        int SaveChanges();
    }
}