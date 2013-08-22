using StudentWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentWebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private List<Student> list = new List<Student>()
        {
            new Student("Doncho","Minkov",5,new List<Mark>()
            {
                new Mark("CSS",5),
                new Mark("Javascript",5),
                new Mark("OOP",5),
            }),
            new Student("Posho","Minkov",5,new List<Mark>()
            {
                new Mark("CSS",2),
                new Mark("Javascript",3),
                new Mark("OOP",4),
            }),
            new Student("Kero","Minkov",5,new List<Mark>()
            {
                new Mark("CSS",5),
                new Mark("Javascript",6),
                new Mark("OOP",3),
            }),
            new Student("Fala","Debata",5,new List<Mark>()
            {
                new Mark("CSS",2),
                new Mark("Javascript",2),
                new Mark("OOP",2),
            }),
        };

        // GET api/values
        public IEnumerable<Student> Get()
        {
            return this.list;
        }

        public IEnumerable<Mark> Get(int id)
        {
            if (id >= this.list.Count || id < 0)
            {
                throw new ArgumentException("Invalid Id");
            }
            return this.list[id].Marks;
        }
    }
}