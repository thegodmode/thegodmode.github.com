using System;
using System.Collections.Generic;
using People.Common;
using System.Linq;
namespace TestHumans
{
    class Program
    {
        static void Main()
        {
            
            List<Student> students = new List<Student>(){

                new Student("Pesho","Peshev",2),
                new Student("Hristo","Armadob",3),
                new Student("Dido","Goshev",4),
                new Student("Naiden","Kirov",5),
                new Student("Yuordan","Banov",4),
                new Student("Ivan","Dejbeeb",2),
                new Student("Dragan","Sharamov",6),
                new Student("Drogba","Gucata",6),
                new Student("Petka","Peavlov",2),
                new Student("Drislu","Daragalve",2),
                new Student("Fostata","Germadem",3),

            };

            var ordered = students.OrderBy(student => student.Grade);
            foreach (var item in ordered)
            {
                Console.WriteLine("{0},{1},{2}",item.FName,item.LName,item.Grade);
            }

            List<Worker> workers = new List<Worker>(){

                new Worker("Danu","Peshev",1200,8),
                new Worker("Banu","Armadob",1200,8),
                new Worker("Dido","Goshev",1200,8),
                new Worker("Vikor","Kirov",5000,8),
                new Worker("Yuordan","Ivanov",2000,8),
                new Worker("Ivan","Dejbeeb",2100,8),
                new Worker("Dragan","Sharamov",2100,8),
                new Worker("Kiril","Gucata",4200,8),
                new Worker("Petka","Peavlov",2000,8),
                new Worker("Drislu","Daragalve",2000,8),
                new Worker("Darik","Germadem",2000,8),

            };
            Console.WriteLine();
            var sortedWorker = workers.OrderBy(worker => worker.MoneyPerHour());
            foreach (var item in sortedWorker)
            {
                Console.WriteLine("{0},{1}", item.FName, item.LName);
            }
            Console.WriteLine();
            var mergedList = students.Cast<Human>().Union(workers.Cast<Human>());
            var sortedMergedList = mergedList.OrderBy(human => human.FName).ThenBy(human=>human.LName);
            foreach (var item in sortedMergedList)
            {
                Console.WriteLine("{0},{1}", item.FName, item.LName);
            }
        }
    }
}
