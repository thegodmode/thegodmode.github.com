namespace Skeleton.Controllers
{
    using Skeleton.Data;
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        private readonly IUowData data;

        public BaseController(IUowData data)
        {
            this.data = data;
        }

        public IUowData Data
        {
            get
            {
                return this.data;
            }
        }
    }
}