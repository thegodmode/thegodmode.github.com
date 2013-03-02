using System;
using System.Linq;

class StundentMethod
{
    static void Main(string[] args)
    {
        var arr = new[]{
            new { Fname = "Petar", Lname = "Petrov" },new { Fname = "Zahari", Lname = "Baxarov" },
            new { Fname = "Ivo", Lname = "Andonov" },new { Fname = "Rosen", Lname = "Petrov" }
        };

        var sortedArr = from name in arr
                        where name.Fname.CompareTo(name.Lname)<0
                        select name;

        foreach (var item in sortedArr)
        {
            Console.WriteLine(item);
        }
    }
}