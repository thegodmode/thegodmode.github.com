using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Skeleton.Data;
using Skeleton.ViewModels.Offer;
using Skeleton.ViewModels.Vote;
using System.Data.Entity;

namespace Skeleton.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IUowData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();

            var canVoteOffers = this.Data.Offers.All()
                                    .Include(o => o.Creator)
                                    .Include(o => o.Presents)
                                    .Where(v => v.CelebratorId != currentUserId && ! v.Votes.Any(t => t.UserId == currentUserId) &&
                                                v.IsActive == true)
                                    .Select(OfferViewModel.FromOffer)
                                    .ToList();

            var stopedOffers = this.Data.Offers.All()
                                   .Include(o => o.Votes)
                                   .Include(o => o.Creator)
                                   .Where(o => o.IsActive == false && o.CelebratorId != currentUserId)
                                   .Select(o => new VotedOffersViewModel
                                          {
                                              Celebrator = o.Celebrator.Name,
                                              Year = o.Year,
                                              Author = o.Creator.Name,
                                              Votes = o.Votes
                                                       .GroupBy(v => v.Present.Name)
                                                       .Select(group => new GroupVotesViewModel
                                                              {
                                                                  PresentName = group.Key,
                                                                  Count = group.Count(),
                                                                  Names = group.Select(g => g.User.Name).ToList()
                                                              })
                                          })
                                   .ToList();

            ViewBag.VotedOffers = stopedOffers;

            return View(canVoteOffers);
        }
    }
}