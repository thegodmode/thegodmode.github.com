using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        int radius = 0;
        Console.WriteLine("Enter radius of the circle");
        if (Int32.TryParse(Console.ReadLine(), out radius))
        {
            Console.WriteLine("Perimeter of the curcle is:{0:0.00}",2*Math.PI*radius*radius);

        }
    }
}

