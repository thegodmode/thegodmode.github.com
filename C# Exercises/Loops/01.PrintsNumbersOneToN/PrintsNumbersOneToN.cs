using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PrintsNumbersOneToN
{
    static void Main(string[] args)
    {
        int numbers = Int32.Parse(Console.ReadLine());
        for (int i = 1; i <= numbers; i++)
        {
            Console.WriteLine(i);
        }
    }
}

