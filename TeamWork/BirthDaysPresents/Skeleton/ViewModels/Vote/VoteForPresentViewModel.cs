using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Skeleton.ViewModels.Vote
{
    public class VoteForPresentViewModel
    {
        [Required]
        public int OfferId { get; set; }

        [Required]
        public int PresentId { get; set; }

        public string VoterId { get; set; }

        public Skeleton.Models.Vote Create()
        {
            var vote = new Skeleton.Models.Vote()
            {
                OfferId = this.OfferId,
                PresentId = this.PresentId
            };

            return vote;
        }
    }
}