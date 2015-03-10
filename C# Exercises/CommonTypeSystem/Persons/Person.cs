using System;
using System.Text;

namespace Persons.Common
{
    public class Person
    {
        private string name;
        private int? age;
       
        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.age = age;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(string.Format("Name:{0}", this.Name));
            if (age.HasValue)
            {
                str.Append(string.Format(" Age:{0}", this.Age));
            }
            else
            {
                str.Append(" Age:Not specified!");
            }
            return str.ToString();
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int? Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
}