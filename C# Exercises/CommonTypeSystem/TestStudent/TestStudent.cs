using System;
using Student.Common;

namespace TestStudent
{
    class TestStudent
    {
        
        static void Main()
        {
            Students std = new Students("Bojidar", "Boqnov", "Penchev", 544, "Mlasdost-5", "32131", "das@abv.bg", Specialties.Economy, University.Unwe, Faculty.Economy);
            Students std1 = new Students("Bojidar", "Boqnov", "Penchev", 1134, "Mlasdost-5", "32131", "das@abv.bg", Specialties.Economy, University.Unwe, Faculty.Economy);
            Students std3 = new Students("Bojidar", "Boqnov", "Penchev", 1034, "Mlasdost-5", "32131", "das@abv.bg", Specialties.Economy, University.Unwe, Faculty.Economy);
            //  Console.WriteLine(std != std1);
            // Console.WriteLine(std);
            //Students std4 = (Students)std.Clone();
            //  Console.WriteLine(std4);

            Students[] arr = {std1,std,std3};
            Array.Sort(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}