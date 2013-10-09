namespace MvcExamApplication.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using MvcExam.Data;
    using MvcExamApplication.ViewModels.Ticket;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    
    public class HomeController : BaseController
    {
        public HomeController(IUowData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["TopTickets"] == null)
            {
                var result = this.Data.Tickets
                                 .All()
                                 .OrderByDescending(t => t.Comments.Count())
                                 .Select(TicketShortViewModel.FromTicket)
                                 .Take(6)
                                 .ToList();

                this.HttpContext.Cache.Add("TopTickets", result,
                    null, DateTime.Now.AddHours(1),
                    TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            return View(this.HttpContext.Cache["TopTickets"]);
        }

        public ActionResult Details(int id)
        {
            var ticket = this.Data.Tickets.All()
                             .Where(l => l.Id == id)
                             .Select(TicketFullViewModel.FromTicket)
                             .FirstOrDefault();
            
            if (ticket == null)
            {
                return new HttpNotFoundResult();
            }

            var userId = this.User.Identity.GetUserId();
            //ticket.UserCanVote = !this.Data.Votes.All().Any(v => v.UserId == userId && v.LaptopId == id);
            return View(ticket);
        }
    }
}