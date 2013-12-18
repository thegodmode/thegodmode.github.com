using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skeleton.ViewModels.Vote;

namespace Skeleton.ViewModels.Offer
{
    public class VotedOffersViewModel
    {
        public string Celebrator { get; set; }

        public int Year { get; set; }

        public string Author { get; set; }

        public IEnumerable<GroupVotesViewModel> Votes { get; set; }
    }
}