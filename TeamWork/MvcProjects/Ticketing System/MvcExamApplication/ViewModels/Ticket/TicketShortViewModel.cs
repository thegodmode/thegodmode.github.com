using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcExamApplication.ViewModels.Ticket
{
    public class TicketShortViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string NameOfCategory { get; set; }

        public string NameOfAuthor { get; set; }

        public int NumberOfComments { get; set; }

        public static Expression<Func<MvcExam.Models.Ticket, TicketShortViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketShortViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    NameOfAuthor = ticket.Author.UserName,
                    NameOfCategory = ticket.Category.Name,
                    NumberOfComments = ticket.Comments.Count()
                };
            }
        }
    }
}