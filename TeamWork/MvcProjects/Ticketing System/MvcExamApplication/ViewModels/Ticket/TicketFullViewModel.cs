using System;
using System.Collections.Generic;
using System.Linq;
using MvcExam.Models;
using System.Linq.Expressions;
using MvcExamApplication.ViewModels.Comments;
using System.ComponentModel.DataAnnotations;

namespace MvcExamApplication.ViewModels.Ticket
{
    public class TicketFullViewModel
    {
        public int Id { get; set; }

        [Required]

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public ICollection<CommentShortViewModel> Comments { get; set; }

        public static Expression<Func<MvcExam.Models.Ticket, TicketFullViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketFullViewModel
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    AuthorName = ticket.Author.UserName,
                    CategoryName = ticket.Category.Name,
                    Priority = ticket.Priority,
                    ScreenshotUrl = ticket.ScreenshotUrl,
                    Description = ticket.Description,
                    Comments = ticket.Comments
                                     .AsQueryable()
                                     .Select(CommentShortViewModel.FromComment)
                                     .ToList()
                };
            }
        }
    }
}