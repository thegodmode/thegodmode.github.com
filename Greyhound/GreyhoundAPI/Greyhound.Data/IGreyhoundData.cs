using Greyhound.Model;
using System;
using System.Linq;


namespace Greyhound.Data
{
    public interface IGreyhoundData
    {
         IRepository<UpcomingEvents> UpcomingEvents { get; }
    }
}
