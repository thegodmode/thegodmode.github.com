using Skeleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Skeleton.ViewModels.User
{
    public class FullUserViewModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public IList<int> PossibleYears { get; set; }

        public static Expression<Func<ApplicationUser, FullUserViewModel>> FromUser
        {
            get
            {
                return user => new FullUserViewModel
                {
                    UserId = user.Id,
                    Name = user.Name,
                    BirthDay = user.BirthDay
                };
            }
        }

        public void CalculatePossibleYears(IList<int> usedYears)
        {
            this.PossibleYears = new List<int>();

            if (this.BirthDay.Month < DateTime.Now.Month ||
                (this.BirthDay.Month == DateTime.Now.Month && this.BirthDay.Day < DateTime.Now.Day))
            {
                for (int i = DateTime.Now.Year + 1; i <= this.BirthDay.Year + 100; i++)
                {
                    if (!usedYears.Contains(i))
                    {
                        PossibleYears.Add(i);
                    }
                }
            }
            else
            {
                for (int i = DateTime.Now.Year; i <= this.BirthDay.Year + 100; i++)
                {
                    if (!usedYears.Contains(i))
                    {
                        PossibleYears.Add(i);
                    }
                }
            }
        }
    }
}