using HotLikes.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HotLikes.ViewModels.User
{
    public class SingleUserViewModel
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public static Expression<Func<ExtendedUser, SingleUserViewModel>> FromUser
        {
            get
            {
                return user => new SingleUserViewModel
                {
                    UserId = user.Id,
                    FullName = user.FirstName + " " + user.LastName
                };
            }
        }
    }
}