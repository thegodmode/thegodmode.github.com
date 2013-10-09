using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcExam.Models;
using System.ComponentModel.DataAnnotations;
using MvcExamApplication.CustomAttributes;

namespace MvcExamApplication.ViewModels.Ticket
{
    public class CreateTicketViewModel
    {
        [Required(ErrorMessage = "Required!")]
        [ShouldNotContainBugAttribute(ErrorMessage = "The word bug should not be used in title!")]
        [StringLength(20, ErrorMessage = "Max Title length is 20")]
        public string Title { get; set; }

       // [Required]
        public Priority Priority { get; set; }

       // [Required]
        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public MvcExam.Models.Ticket CreateTicket()
        {
            return new MvcExam.Models.Ticket
            {
                Title = this.Title,
                Priority = this.Priority,
                ScreenshotUrl = this.ImageUrl,
                Description = this.Description
            };
        }
    }
}