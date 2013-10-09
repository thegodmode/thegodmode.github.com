namespace MvcExam.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using MvcExam.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MvcExam.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MvcExam.Data.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role { Name = "admin" },
                new Role { Name = "user" });

            if (context.Categories.Count() != 0)
            {
                return;
            }

            Random rnd = new Random();

            var user = new ExtendedUser()
            {
                UserName = "TestUser",
                Points = 10
            };

            for (int i = 0; i < 5; i++)
            {
                var category = new Category
                {
                    Name = "Category" + i
                };

                for (int j = 0; j < rnd.Next(5, 10); j++)
                {
                    var ticket = new Ticket()
                    {
                        Priority = Priority.Medium,
                        Title = "Sample123" + j,
                        Author = user,
                        Description = "Sample Description........",
                        CategoryId = category.Id,
                        ScreenshotUrl = "http://laptop.bg/system/images/26207/thumb/toshiba_satellite_l8501v8.jpg"
                    };
                    for (int p = 0; p < rnd.Next(5, 10); p++)
                    {
                        var comment = new Comment
                        {
                            Content = "Important Problem Fix it Now !!!" + p,
                            Author = user,
                            Ticket = ticket
                        };
                        ticket.Comments.Add(comment);
                    }
                     category.Tickets.Add(ticket);
                }

                context.Categories.Add(category);
            }

            context.SaveChanges();
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
        }
    }
}