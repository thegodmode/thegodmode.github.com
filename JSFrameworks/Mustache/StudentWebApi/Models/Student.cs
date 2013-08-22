using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWebApi.Models
{
    public class Student
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Grade { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
        public Student(string fname, string lname, int grade, IEnumerable<Mark> marks)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.Grade = grade;
            this.Marks = marks;
        }
    }
}