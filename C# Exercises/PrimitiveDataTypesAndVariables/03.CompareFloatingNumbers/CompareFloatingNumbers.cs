using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CompareFloatingNumbers
{
    static void Main(string[] args)
    {
        decimal number_1 = 5.4m;
        decimal number_2 = 5.4m;
        if ((decimal)Math.Round(number_1, 6) >= (decimal)Math.Round(number_2, 6))
        {
            Console.WriteLine("True"); ;

        }
        else
        {
            Console.WriteLine("False");
        }
    }
}

