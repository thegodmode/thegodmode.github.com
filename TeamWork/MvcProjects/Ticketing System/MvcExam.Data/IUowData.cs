namespace MvcExam.Data
{
    using System;
    using System.Linq;
    using MvcExam.Models;

    public interface IUowData : IDisposable
    {
        IRepository<ExtendedUser> Users { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();
    }
}