using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SumOfFibonacciNumbers
{
    static void Main(string[] args)
    {
        int N = Int32.Parse(Console.ReadLine());
        decimal[] fibonaciNumbers = new decimal[100];
        decimal sum = 2;
        fibonaciNumbers[0] = 0;
        fibonaciNumbers[1] = 1;
        fibonaciNumbers[2] = 1;
        if (N==1||N==0)
        {
             Console.WriteLine(0);
             return;
        }
        if (N==2)
        {
            Console.WriteLine(1);
            return;
        }
        for (int index = 3; index < N; index++)
        {
            fibonaciNumbers[index] = fibonaciNumbers[index - 1] + fibonaciNumbers[index - 2];
            sum = sum + fibonaciNumbers[index];
        }

        Console.WriteLine(sum);

    }
}

