using System;
using System.Linq;
using System.Web.Mvc;
using HotLikes.Data;
using HotLikes.ViewModels.User;
using Microsoft.AspNet.Identity;
using HotLikes.Controllers.Helpers;

namespace HotLikes.Controllers
{
    public class FriendController : BaseController
    {
        public FriendController(IUowData data) : base(data)
        {
        }

        public ActionResult All()
        {
            var userId = User.Identity.GetUserId();
            var user = UserUtils.GetUserViewModelById(userId, this.Data);
            ViewBag.UserModel = user;

            var allUsers = this.Data.Users
                               .All()
                               .Select(AddUserViewModel.FromUser)
                               .ToList();

            return View(allUsers);
        }
    }
}