namespace HotLikes.Data
{
    using System;
    using System.Linq;
    using HotLikes.Models;
   
    
    public interface IUowData : IDisposable
    {
        IRepository<ExtendedUser> Users { get; }
      
        int SaveChanges();
    }
}