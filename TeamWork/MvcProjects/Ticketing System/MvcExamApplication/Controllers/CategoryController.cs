using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using MvcExamApplication.Controllers;
using MvcExam.Data;
using MvcExamApplication.ViewModels.Categories;

namespace MvcExamApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : BaseController
    {
        public CategoryController(IUowData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllCategories([DataSourceRequest]
                                           DataSourceRequest request)
        {
            var result = this.Data.Categories.All()
                             .Select(CategoryShortViewModel.FromCategory);

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest]
                                         DataSourceRequest request, CategoryShortViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                this.Data.Categories.Update(category.CreateCategory());
                this.Data.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest]
                                         DataSourceRequest request,
            CategoryShortViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                this.Data.Categories.Add(category.CreateCategory());
                this.Data.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory([DataSourceRequest]
                                         DataSourceRequest request,
            CategoryShortViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var ticktes = this.Data.Tickets.All()
                                  .Where(t => t.CategoryId == category.Id)
                                  .ToList();

                foreach (var item in ticktes)
                {
                    var comments = this.Data.Comments.All()
                                       .Where(t => t.Ticket.Title == item.Title)
                                       .ToList();

                    foreach (var comment in comments)
                    {
                        this.Data.Comments.Delete(comment);
                    }

                    this.Data.Tickets.Delete(item);
                }

                this.Data.Categories.Delete(category.CreateCategory());
                this.Data.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
    }
}