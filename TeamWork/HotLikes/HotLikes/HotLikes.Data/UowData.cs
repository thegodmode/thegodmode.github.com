namespace HotLikes.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HotLikes.Models;
    
    public class UowData : IUowData
    {
        private readonly HotLikesContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UowData() : this(new HotLikesContext())
        {
        }

        public UowData(HotLikesContext context)
        {
            this.context = context;
        }
       
        public IRepository<ExtendedUser> Users
        {
            get
            {
                return this.GetRepository<ExtendedUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}