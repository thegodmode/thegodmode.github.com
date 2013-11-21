using System;
using System.Linq;
using System.Web.Mvc;
using HotLikes.Data;
using Microsoft.AspNet.Identity;
using HotLikes.Controllers.Helpers;

namespace HotLikes.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public UserController(IUowData data) : base(data)
        {
        }
       
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var userViewModel = UserUtils.GetUserViewModelById(userId, this.Data);
           
            return View(userViewModel);
        }
    }
}