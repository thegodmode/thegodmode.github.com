using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Skeleton.Data;
using System.Web.Mvc;
using Skeleton.ViewModels.Vote;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Skeleton.Controllers
{
    public class VoteController : BaseController
    {
        public VoteController(IUowData data) : base(data)
        {
        }

        public ActionResult VoteForPresent(VoteForPresentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var voteEntity = model.Create();
                voteEntity.UserId = userId;

                this.Data.Votes.Add(voteEntity);
                this.Data.SaveChanges();
                return Content("Your Vote Was Recorded");
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Invalid model");
        }

        public ActionResult StopVoting(int offerId)
        {
            var offert = this.Data.Offers.GetById(offerId);

            if (offert != null)
            {
                offert.IsActive = false;
                this.Data.SaveChanges();

                var allVotes = this.Data.Votes.All()
                                   .Include(v => v.Present)
                                   .Include(v=>v.User)
                                   .Where(v => v.OfferId == offerId)
                                   .GroupBy(v => v.Present.Name)
                                   .Select(group => new GroupVotesViewModel
                                          {
                                              PresentName = group.Key,
                                              Count = group.Count(),
                                              Names = group.Select(g => g.User.Name).ToList()
                                          }).ToList();
                
                return PartialView("_VoteForPresentPartial", allVotes);
            }
           
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Invalid offert");
        }
    }
}