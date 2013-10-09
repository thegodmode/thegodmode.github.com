using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcExamApplication.ViewModels.Categories
{
    public class CategoryShortViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<MvcExam.Models.Category, CategoryShortViewModel>> FromCategory
        {
            get
            {
                return category => new CategoryShortViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }

        internal MvcExam.Models.Category CreateCategory()
        {
            return new MvcExam.Models.Category
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}