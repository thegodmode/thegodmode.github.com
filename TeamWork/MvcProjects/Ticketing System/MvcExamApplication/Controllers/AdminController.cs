namespace MvcExamApplication.Controllers
{
    using System.Web.Mvc;
    using MvcExam.Data;
    using System;
    using System.Linq;

    [Authorize(Roles="admin")]
    public class AdminController : BaseController
    {
        public AdminController(IUowData data) : base(data)
        {
            
        }
    }
}