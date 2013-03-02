using System;
using System.Collections.Generic;
using School.Common;

namespace TestSchool
{
    class Program
    {
        static void Main(string[] args)
        {
           
           
            List<Discipline> disciplines = new List<Discipline>(){

                new Discipline("Mathematics",2,2),
                new Discipline("MMPFG",3,4)

            };
           
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Petar",disciplines),
                new Teacher("Lybih",disciplines),

            };

            List<Student> students = new List<Student>(){

                new Student("Ivo",2),
                new Student("Ganu",6),
                new Student("Geri",12)

            };
            
            Class A4 = new Class(students, teachers, "A4");
            A4.AddComment("This is Class A4");
            Console.Write(A4.ToString());
            
        }
    }
}
