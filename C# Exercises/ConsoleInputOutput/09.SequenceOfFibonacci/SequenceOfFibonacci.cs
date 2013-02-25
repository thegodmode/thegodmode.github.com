using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class SequenceOfFibonacci
{
    static void Main(string[] args)
    {
        decimal[] fibonaciNumbers = new decimal[100];
        fibonaciNumbers[0] = 0;
        fibonaciNumbers[1] = 1;
        fibonaciNumbers[2] = 1;
        for (int index = 3; index < 100; index++)
        {
            fibonaciNumbers[index] = fibonaciNumbers[index - 1] + fibonaciNumbers[index - 2];
        }
        for (int index = 0; index < 100; index++)
        {
            Console.WriteLine(fibonaciNumbers[index]);
        }
    }
}

