using System;
using System.Collections.Generic;
using System.Text;

namespace School.Common
{
    public class Teacher : People
    {
        private List<Discipline> discipline;

        public List<Discipline> Discipline
        {
            get
            {
                return discipline;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Disciplines can not be empty");
                }
                discipline = value;
            }
        }

        public Teacher(string name, List<Discipline> discipline) : base(name)
        {
            this.Discipline = discipline;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(string.Format("  -Name:{0}\n", this.Name));
            foreach (var d in discipline)
            {
                str.Append(string.Format("{0}\n", d.ToString()));
            }
            str.Append("  -TeacherComments:");
            foreach (var item in this.OptionalComments1)
            {
                str.Append(item);
            }
            return str.ToString();
        }
    }
}