using MvcExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcExamApplication.ViewModels.Ticket
{
    public class TicketListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string NameOfCategory { get; set; }

        public string NameOfAuthor { get; set; }

        public Priority Priority { get; set; }

        public string PriorityAsString
        {
            get
            {
                return this.Priority.ToString();
            }
        }

        public static Expression<Func<MvcExam.Models.Ticket, TicketListViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketListViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    NameOfAuthor = ticket.Author.UserName,
                    NameOfCategory = ticket.Category.Name,
                    Priority = ticket.Priority
                };
            }
        }
    }
}