using MoviesRoom.Data;
using System.Web.Mvc;

namespace MoviesRoom.Controllers
{
     public class BaseController : Controller
    {
        public BaseController(IUowData data)
        {
            this.Data = data;
        }

        protected IUowData Data { get; set; }
    }
}