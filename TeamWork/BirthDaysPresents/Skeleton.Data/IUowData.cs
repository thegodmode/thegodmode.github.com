namespace Skeleton.Data
{
    using System;
    using System.Linq;
    using Skeleton.Models;
    
    public interface IUowData : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Presentt> Presentts { get; }

        IRepository<Offer> Offers { get; }

        IRepository<Vote> Votes { get; }
      
        int SaveChanges();
    }
}