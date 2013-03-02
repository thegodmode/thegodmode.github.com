using System;
using System.Linq;
using ClassLibrary;

namespace _05.OrderStudents
{
    class OrderStudents
    {
        static void Main(string[] args)
        {
            // Lambda
            var arr = new[]{
                new Student { Fname = "Petar", Lname = "Petrov" },new Student { Fname = "Ivo", Lname = "Andonov" },
                new Student { Fname = "Petar", Lname = "Zeshev" },new Student { Fname = "Zahari", Lname = "Baxarov" }
            };

            var sorted = arr.OrderByDescending(a => a.Fname).ThenByDescending(b => b.Lname);
            foreach (var item in sorted)
            {
                Console.WriteLine("{0} {1}", item.Fname, item.Lname);
            }

            Console.WriteLine("---------------------------------------------------");
            // Linq
            var linqSorted =
                            from name in arr
                            orderby name.Fname, name.Lname
                            select name;

            foreach (var item in sorted)
            {
                Console.WriteLine("{0} {1}", item.Fname, item.Lname);
            }
        }
    }
}