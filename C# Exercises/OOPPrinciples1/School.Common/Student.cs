using System;
using System.Text;

namespace School.Common
{
    public class Student : People
    {
        int classNumber;

        public int ClassNumber
        {
            get
            {
                return classNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ClassNumber can not be less then zero or zero");
                }
                classNumber = value;
            }
        }

        public Student(string name, int classNumber) : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(string.Format("  -Name:{0}\n  -ClassNumber:{1}\n", this.Name, classNumber));
            str.Append("  -StudentComments:");
            foreach (var item in this.OptionalComments1)
            {
                str.Append(item);
                
            }
            return str.ToString();
        }
    }
}