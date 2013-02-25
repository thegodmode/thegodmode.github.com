using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int year = Int32.Parse(Console.ReadLine());
        Console.WriteLine(DateTime.IsLeapYear(year));
    }
}