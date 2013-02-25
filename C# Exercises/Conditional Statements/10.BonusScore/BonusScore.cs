using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class BonusScore
{
    static void Main(string[] args)
    {
        int number = Int32.Parse(Console.ReadLine());
        switch (number)
        {
            case 1:
            case 2:
            case 3: Console.WriteLine(number * 10); break;
            case 4:
            case 5:
            case 6: Console.WriteLine(number * 100); break;
            case 7:
            case 8:
            case 9: Console.WriteLine(number * 1000); break;
            default: Console.WriteLine("The number must be digit and different from ZERO!"); break;
        }
    }
}

