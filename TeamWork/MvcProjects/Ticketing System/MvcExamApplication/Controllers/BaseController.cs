namespace MvcExamApplication.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using MvcExam.Data;

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