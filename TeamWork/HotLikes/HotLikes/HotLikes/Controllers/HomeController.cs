using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HotLikes.Data;


namespace HotLikes.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUowData data) : base(data)
        {
        }
        
        public ActionResult Index()
        {
            if (TempData["errors"] != null)
            {
                ModelState.Merge((ModelStateDictionary)TempData["errors"]);
            }

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View("Index");
            }
        }
    }
}