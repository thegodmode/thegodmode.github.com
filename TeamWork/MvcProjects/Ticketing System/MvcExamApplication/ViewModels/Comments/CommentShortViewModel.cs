using MvcExam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcExamApplication.ViewModels.Comments
{
    public class CommentShortViewModel
    {
        public string Author { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Max Message Length is 1000")]
        public string Content { get; set; }

        public int TicketId { get; set; }

        public static Expression<Func<MvcExam.Models.Comment, CommentShortViewModel>> FromComment
        {
            get
            {
                return comment => new CommentShortViewModel
                {
                    Author = comment.Author.UserName,
                    Content = comment.Content
                };
            }
        }

        public Comment CreateComment()
        {
            return new Comment
            {
                Content = this.Content,
            };
        }
    }
}