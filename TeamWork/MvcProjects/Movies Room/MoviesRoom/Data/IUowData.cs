using MoviesRoom.Models;
using System;

namespace MoviesRoom.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Film> Films { get; }

        IRepository<Category> Categories { get; }

        IRepository<ExtendedUser> Users { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}