using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.StudentsAge
{
    class StudentsAge
    {
        static void Main(string[] args)
        {
            var arr = new[]{
                new { Fname = "Petar", Lname = "Petrov", Age = 23 },new { Fname = "Zahari", Lname = "Baxarov", Age = 24 },
                new { Fname = "Ivo", Lname = "Andonov", Age = 27 },new { Fname = "Rosen", Lname = "Petrov", Age = 18 }
            };

            var sortedArr = from name in arr
                            where name.Age >= 18 && name.Age <= 24
                            select name;

            foreach (var item in sortedArr)
            {
                Console.WriteLine(item);
            }
        }

       

   
    }
}