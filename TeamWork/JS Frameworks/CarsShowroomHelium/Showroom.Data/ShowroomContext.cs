namespace Showroom.Data
{
    using System;    
    using System.Data.Entity;
    using System.Linq;
    using Showroom.Models;

    public class ShowroomContext : DbContext
    {
        public ShowroomContext()
            : base("ShowroomDb")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Gearbox> Gearboxes { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Color> Colors { get; set; }
    }
}
