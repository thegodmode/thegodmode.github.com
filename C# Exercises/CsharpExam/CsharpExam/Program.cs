using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = Int32.Parse(Console.ReadLine());
            int month = Int32.Parse(Console.ReadLine());
            int year = Int32.Parse(Console.ReadLine());
            string format = "d.M.yyyy";   
            DateTime date = new DateTime(year,month,day);
            Console.WriteLine(date.AddDays(1).ToString(format));
        }
    }
}
