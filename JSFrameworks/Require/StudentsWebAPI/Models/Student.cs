using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsWebApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Grade { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
        public Student(int id, string name, short grade, IEnumerable<Mark> marks)
        {
            this.Id = id;
            this.Name = name;
            this.Grade = grade;
            this.Marks = marks;
        }
    }
}