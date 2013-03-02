using System;
using System.Collections.Generic;
using System.Text;

namespace School.Common
{
    public class Class : OptionalComments
    {
        List<Student> students;
        List<Teacher> teachers;
        string uniqieIndetifier;

        public Class(List<Student> students, List<Teacher> teachers, string uniqieIndetifier, string optionalComments = "Empty")
            : base(optionalComments)
        {
            this.students = students;
            this.teachers = teachers;
            this.uniqieIndetifier = uniqieIndetifier;
        }
        
        public string UniqieIndetifier
        {
            get
            {
                return uniqieIndetifier;
            }
            set
            {
                if (uniqieIndetifier == null)
                {
                    throw new ArgumentNullException("UniqieIndetifier can not be null");
                }
                uniqieIndetifier = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return teachers;
            }
            set
            {
                if (teachers == null)
                {
                    throw new ArgumentNullException("Teachers can not be null");
                }
                teachers = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                if (students == null)
                {
                    throw new ArgumentNullException("Students can not be null");
                }
                students = value;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(string.Format("Class:{0}\n", uniqieIndetifier));
            str.Append(string.Format(" -Students:\n"));
            foreach (var student in students)
            {
                str.Append(student.ToString());
                str.Append("\n");
            }
            str.Append(string.Format(" -Teachers:\n"));
            foreach (var teacher in teachers)
            {
                str.Append(teacher.ToString());
            }
            return str.ToString();
        }
    }
}