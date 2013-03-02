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
                if (discipline == null)
                {
                    throw new ArgumentNullException("Disciplines can not be empty");
                }
                discipline = value;
            }
        }

        public Teacher(string name, List<Discipline> discipline, string optionalComments = "Empty")
            : base(name, optionalComments)
        {
            this.discipline = discipline;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(string.Format("  -Name: {0}\n",this.Name));
            foreach (var d in discipline)
            {
                str.Append(string.Format("   -{0}\n", d.ToString()));
               
            }
            return str.ToString();
        }
    }
}