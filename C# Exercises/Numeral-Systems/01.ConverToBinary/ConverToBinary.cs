using System;
using System.Collections.Generic;
using System.Linq;

class ConverToBinary
{
    static void Main(string[] args)
    {
        int number = 324;
        List<int> remainders = new List<int>();
        while (number > 0)
        {
            remainders.Add(number % 2);
            number /= 2;
        }
        remainders.Reverse();

        foreach (var remainder in remainders)
        {
            Console.Write(remainder);
        }
        Console.WriteLine();
    }
}