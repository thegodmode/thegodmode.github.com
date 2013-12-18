using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Skeleton.ViewModels.Vote
{
    public class GroupVotesViewModel
    {
        public string PresentName { get; set; }

        public int Count { get; set; }

        public ICollection<string> Names { get; set; }
    }
}