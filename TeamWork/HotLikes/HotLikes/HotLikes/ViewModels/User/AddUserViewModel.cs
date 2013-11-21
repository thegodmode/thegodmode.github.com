using HotLikes.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HotLikes.ViewModels.User
{
    public class AddUserViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        public Gender Gender { get; set; }

        public static Expression<Func<ExtendedUser, AddUserViewModel>> FromUser
        {
            get
            {
                return user => new AddUserViewModel
                {
                    Id = user.Id,
                    FullName = user.FirstName + " " + user.LastName,
                    ImageUrl = user.ImageUrl,
                    Gender = user.Gender
                };
            }
        }
    }
}