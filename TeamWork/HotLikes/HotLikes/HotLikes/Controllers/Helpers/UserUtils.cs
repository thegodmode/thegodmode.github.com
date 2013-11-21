using HotLikes.Data;
using HotLikes.Models;
using HotLikes.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotLikes.Controllers.Helpers
{
    public class UserUtils 
    {
        public static ExtendedUser GetUserById(string id, IUowData data)
        {
            var user = data.Users
                           .All()
                           .Where(u => u.Id == id)
                           .FirstOrDefault();

            return user;
        }

        public static ExtendedUser GetUserByEmail(string email, IUowData data)
        {
            var user = data.Users
                           .All()
                           .Where(u => u.UserName == email)
                           .FirstOrDefault();

            return user;
        }

        public static SingleUserViewModel GetUserViewModelById(string id, IUowData data)
        {
             var user = data.Users
                           .All()
                           .Where(u => u.Id == id)
                           .Select(SingleUserViewModel.FromUser)
                           .FirstOrDefault();

             return user;
        }


    }
}