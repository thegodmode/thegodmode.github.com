using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace MoviesRoom.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
      
        public string Author { get; set; }

        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }

        public int FilmId { get; set; }

        public bool IsAdmin { get; set; }

        public static Expression<Func<MoviesRoom.Models.Comment, CommentViewModel>> FromComment
        {
            get
            {
                return cat => new CommentViewModel
                {
                    Id = cat.Id,
                    Author = cat.User.UserName,
                    Text = cat.Text,
                    IsAdmin = cat.IsAdmin
                    
                };
            }
        }

        public MoviesRoom.Models.Comment CreateComment()
        {
            return new MoviesRoom.Models.Comment
            {
                FilmId = this.FilmId,
                Text = this.Text
            };
        }

       
    }
}