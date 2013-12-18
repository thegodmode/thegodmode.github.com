using Skeleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Skeleton.ViewModels.User
{
    public class ShortUserViewModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public static Expression<Func<ApplicationUser, ShortUserViewModel>> FromUser
        {
            get
            {
                return user => new ShortUserViewModel
                {
                    UserId = user.Id,
                    Name = user.Name,
                };
            }
        }
    }
}