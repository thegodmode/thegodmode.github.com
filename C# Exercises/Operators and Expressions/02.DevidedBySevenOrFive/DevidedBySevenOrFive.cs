using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class DevidedBySevenOrFive
{
    static void Main(string[] args)
    {
        int number = 49;
        if (number % 5 == 0 && number % 7 == 0)
        {
            Console.WriteLine("The number can be devided by 7 and 5");
        }
        else
        {
            Console.WriteLine("The number can't be devided by 7 and 5");
        }


    }
}

