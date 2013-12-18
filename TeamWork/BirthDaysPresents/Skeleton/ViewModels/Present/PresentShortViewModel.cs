using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Skeleton.ViewModels.Present
{
    public class PresentShortViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Skeleton.Models.Presentt, PresentShortViewModel>> FromPresent
        {
            get
            {
                return p => new PresentShortViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                };
            }
        }
    }
}