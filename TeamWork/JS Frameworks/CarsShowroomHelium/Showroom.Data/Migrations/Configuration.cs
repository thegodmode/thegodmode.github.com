namespace Showroom.Data.Migrations
{
    using Showroom.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Showroom.Data.ShowroomContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Showroom.Data.ShowroomContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var admin = new User
            //{
            //    Username = "admin",
            //    AuthCode = "cd5ea73cd58f827fa78eef7197b8ee606c99b2e6",
            //    IsAdmin = true                
            //};

            //context.Users.AddOrUpdate(usr => usr.Username, admin);
        }
    }
}
