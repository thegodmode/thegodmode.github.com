namespace Showroom.WebApi.Models
{
    using Showroom.Data;
    using System;    
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;    

    public class ShowroomDbContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new ShowroomContext();
        }
    }
}