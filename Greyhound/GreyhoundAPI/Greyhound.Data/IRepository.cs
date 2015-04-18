using System;
using System.Linq;

public interface IRepository<T> : IDisposable where T : class
{
   T All();
}
