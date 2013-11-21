using MoviesRoom.Controllers;
using MoviesRoom.Data;
using System.Web.Mvc;

namespace MoviesRoom.Areas.Administration.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : BaseController
    {
        public AdminController()
            : base(new UowData())
        {
        }

        public AdminController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            this.ViewData.Add("categories", this.Data.Categories.All());

            return View();
        }

    }
}