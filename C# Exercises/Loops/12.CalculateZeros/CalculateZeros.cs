using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CalculateZeros
{
    static void Main(string[] args)
    {
        int number = Int32.Parse(Console.ReadLine());
        Console.WriteLine("The number of Zeros present at the end of {0}! is {1}",number,number/5);
    }
}

