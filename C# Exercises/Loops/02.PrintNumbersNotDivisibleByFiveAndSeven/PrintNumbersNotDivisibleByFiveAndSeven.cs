using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PrintNumbersNotDivisibleByFiveAndSeven
{
    static void Main(string[] args)
    {
        int numbers = Int32.Parse(Console.ReadLine());
        for (int i = 1; i <= numbers; i++)
        {
            if (i%3!=0 && i%7!=0)
            {
                Console.WriteLine(i);
            }
          
        }
    }
}

