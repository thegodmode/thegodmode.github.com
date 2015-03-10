using System;
using System.Linq;

namespace People.Common
{
    public class Student:Human
    {
        private int grade;

        public Student(string fName, string lName, int grade) : base(fName, lName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return grade;
            }
            set
            {
                if (value<2 || value >6)
                {
                    throw new ArgumentException();
                }
                grade = value;
            }
        }
    }
}
