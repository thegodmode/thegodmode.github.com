using System;

namespace School.Common
{
    public class Student : People
    {
        int classNumber;

        public Student(string name, int classNumber, string optionalComments = "Empty")
            : base(name, optionalComments)
        {
            this.classNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return classNumber;
            }
            set
            {
                if (classNumber <= 0)
                {
                    throw new ArgumentOutOfRangeException("ClassNumber can not be less then zero or zero");
                }
                classNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("  -Name:{0}, ClassNumber: {1}, Comments:{2}", this.Name, classNumber, this.OptionalComments1);
        }
    }
}