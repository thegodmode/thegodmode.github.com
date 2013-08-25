using StudentsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentsWebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private List<Student> list = new List<Student>()
        {
            new Student(1,"Doncho",5,new List<Mark>()
            {
                new Mark(1,"CSS",5),
                new Mark(2,"Javascript",5),
                new Mark(3,"OOP",5),
            }),
            new Student(2,"Posho",5,new List<Mark>()
            {
                new Mark(4,"CSS",2),
                new Mark(5,"Javascript",3),
                new Mark(6,"OOP",4),
            }),
            new Student(3,"Kero",5,new List<Mark>()
            {
                new Mark(7,"CSS",5),
                new Mark(8,"Javascript",6),
                new Mark(9,"OOP",3),
            }),
            new Student(4,"Fala",5,new List<Mark>()
            {
                new Mark(10,"CSS",2),
                new Mark(11,"Javascript",2),
                new Mark(12,"OOP",2),
            }),
        };

        // GET api/values
        public IEnumerable<Student> Get()
        {
            return this.list;
        }

        [HttpGet]
        [ActionName("marks")]
        public IEnumerable<Mark> Get(int studentId )
        {
            if (studentId >= this.list.Count || studentId < 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            return this.list.Where(st=>st.Id==studentId).Select(t=>t.Marks).FirstOrDefault();
        }
    }
}