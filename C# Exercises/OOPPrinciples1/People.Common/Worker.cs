using System;
using System.Linq;

namespace People.Common
{
    public class Worker : Human
    {
        private int weekSalary;
        private int workHoursPerDay;
      
        public Worker(string fName, string lName, int weekSalary, int workHoursPerDay) : base(fName, lName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public int WorkHoursPerDay
        {
            get
            {
                return workHoursPerDay;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException();
                }
                workHoursPerDay = value;
            }
        }

        public int WeekSalary
        {
            get
            {
                return weekSalary;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                weekSalary = value;
            }
        }

        public double MoneyPerHour()
        {
            return this.weekSalary / (this.WorkHoursPerDay * 5);
        }
    }
}