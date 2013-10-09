namespace MvcExamApplication.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using MvcExam.Data;
    using MvcExam.Models;
    using System.Collections.Generic;
    using MvcExamApplication.ViewModels.Ticket;
    using Microsoft.AspNet.Identity;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using MvcExamApplication.ViewModels.Comments;

    [Authorize]
    public class TicketController : BaseController
    {
        public TicketController(IUowData data) : base(data)
        {
        }

        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTicketViewModel ticket)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var ticketEntity = ticket.CreateTicket();
                var category = this.Data.Categories.All()
                                   .Where(c => c.Name == ticket.CategoryName)
                                   .FirstOrDefault();

                ticketEntity.AuthorId = userId;
                ticketEntity.Category = category;

                var user = this.Data.Users.All().Where(u => u.Id == userId).FirstOrDefault();
                user.Points = user.Points + 1;

                this.Data.Tickets.Add(ticketEntity);
                this.Data.SaveChanges();

                return RedirectToAction("Details", "Home", new { ticketEntity.Id });
            }
         
            var categories = this.Data.Categories.All().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name
            });

            IEnumerable<Priority> values = Enum.GetValues(typeof(Priority))
                                               .Cast<Priority>();

            IEnumerable<SelectListItem> items =
                                               from value in values
                                               select new SelectListItem
                                               {
                                                   Text = value.ToString(),
                                                   Value = value.ToString(),
                                                   Selected = (value.Equals(Priority.Medium))
                                               };
            
            ViewBag.Priority = items;
            ViewBag.Categories = categories;

            return View("AddTicket");
        }
        
        public ActionResult AddTicket()
        {
            var categories = this.Data.Categories.All().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Name
            });

            IEnumerable<Priority> values = Enum.GetValues(typeof(Priority))
                                               .Cast<Priority>();

            IEnumerable<SelectListItem> items =
                                               from value in values
                                               select new SelectListItem
                                               {
                                                   Text = value.ToString(),
                                                   Value = value.ToString(),
                                                   Selected = (value.Equals(Priority.Medium))
                                               };
            
            ViewBag.Priority = items;
            ViewBag.Categories = categories;
            return View();
        }

        public ActionResult AllTickets()
        {
            return View();
        }
        
        [Authorize]
        public JsonResult All([DataSourceRequest]
                              DataSourceRequest request)
        {
            var ticktes = this.Data.Tickets.All()
                              .Select(TicketListViewModel.FromTicket);

            return Json(ticktes.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllCategories()
        {
            var categories = this.Data.Categories.All()
                                 .Select(l => new { Name = l.Name });

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string categorysearch)
        {
            if (categorysearch.ToLower() == "Select category".ToLower())
            {
                return RedirectToAction("AllTickets");
            }
            else
            { 
                var result = this.Data.Tickets.All()
                                 .Where(t => t.Category.Name == categorysearch)
                                 .Select(TicketShortViewModel.FromTicket).ToList();
                
                return View("Index", result.ToList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentShortViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var entity = comment.CreateComment();
                entity.AuthorId = User.Identity.GetUserId();

                var ticket = this.Data.Tickets.All()
                                 .Where(t => t.Id == comment.TicketId)
                                 .FirstOrDefault();

                entity.Ticket = ticket;

                this.Data.Comments.Add(entity);
                this.Data.SaveChanges();
                comment.Author = User.Identity.GetUserName();

                return PartialView("_CommentPartial", comment);
            }
            else
            {
                var error = ModelState.Values.First().Errors.First().ErrorMessage.ToString();
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest,
                    error);
            }
        }
    }
}