using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Skeleton.ViewModels.Present;

namespace Skeleton.ViewModels.Offer
{
    public class OfferViewModel
    {
        public int OfferId { get; set; }

        public string CreatorId { get; set; }

        [Required]
        public string CelebratorId { get; set; }

        [Required]
        public ICollection<int> Presents { get; set; }

        [Required]
        public int Year { get; set; }

        public ICollection<PresentShortViewModel> PresentsData { get; set; }

        public string CreatorName { get; set; }

        public string Celebrator { get; set; }

        public bool IsUserCanVote { get; set; }

        public static Expression<Func<Skeleton.Models.Offer, OfferViewModel>> FromOffer
        {
            get
            {
                return o => new OfferViewModel
                {
                    OfferId = o.Id,
                    CreatorName = o.Creator.Name,
                    Celebrator = o.Celebrator.Name,
                    Year = o.Year,
                    PresentsData = o.Presents
                                    .AsQueryable()
                                    .Select(PresentShortViewModel.FromPresent)
                                    .ToList()
                };
            }
        }

        public Skeleton.Models.Offer Create()
        {
            var vote = new Skeleton.Models.Offer()
            {
                CelebratorId = this.CelebratorId,
                Year = this.Year,
                IsActive = true,
            };

            return vote;
        }
    }
}