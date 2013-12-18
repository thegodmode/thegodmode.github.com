using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skeleton.Data;
using Skeleton.ViewModels.User;
using Microsoft.AspNet.Identity;
using Skeleton.ViewModels.Offer;
using System.Data.Entity;

namespace Skeleton.Controllers
{
    [Authorize]
    public class OfferController : BaseController
    {
        public OfferController(IUowData data) : base(data)
        {
        }

        //
        // GET: /CreateVote/
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var allUsers = this.Data.Users.All()
                               .Where(u => u.Id != currentUserId)
                               .Select(ShortUserViewModel.FromUser)
                               .ToList();

            return View(allUsers);
        }

        public ActionResult CreateNewOffer(string userId)
        {
            var user = this.Data.Users.All()
                           .Where(u => u.Id == userId)
                           .Select(FullUserViewModel.FromUser)
                           .FirstOrDefault();

            var usedYears = this.Data.Offers.All()
                                .Where(u => u.CelebratorId == userId)
                                .Select(v => v.Year)
                                .ToList();

            if (user != null)
            {
                user.CalculatePossibleYears(usedYears);
                ViewBag.Presents = this.Data.Presentts.All()
                                       .ToList();
                return View(user);
            }
            
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Invalid user Id");
        }

        public ActionResult RegisterNewOffer(OfferViewModel vote)
        {
            if (ModelState.IsValid)
            {
                var invalidYear = this.Data.Offers.All()
                                      .Where(u => u.CelebratorId == vote.CelebratorId)
                                      .Any(u => u.Year == vote.Year);
                if (!invalidYear)
                {
                    var currentUserId = User.Identity.GetUserId();

                    var entityOffer = vote.Create();
                    entityOffer.CreatorId = currentUserId;

                    var presenetsEntities = this.Data.Presentts.All()
                                                .Where(p => vote.Presents.Contains(p.Id));

                    foreach (var item in presenetsEntities)
                    {
                        entityOffer.Presents.Add(item);
                    }

                    this.Data.Offers.Add(entityOffer);
                    this.Data.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("CreateNewVote");
                }
            }
            else
            {
                return View("CreateNewVote");
            }
        }

        public ActionResult ShowUserOfferts()
        {
            var currentUserId = User.Identity.GetUserId();

            var offerts = this.Data.Offers.All()
                              .Include(o => o.Presents)
                              .Include(o=>o.Celebrator)
                              .Include(o=>o.Creator)
                              .Where(o => o.CreatorId == currentUserId && o.IsActive == true)
                              .Select(OfferViewModel.FromOffer)
                              .ToList();

            return View(offerts);
        }
    }
}