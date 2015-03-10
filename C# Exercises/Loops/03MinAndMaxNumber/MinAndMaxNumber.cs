using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class MinAndMaxNumber
{
    static void Main(string[] args)
    {
        int numbers = Int32.Parse(Console.ReadLine());
        int minNumber = Int32.MaxValue;
        int maxNumber = Int32.MinValue;
        for (int i = 1; i <= numbers; i++)
        {
            if (i>maxNumber)
            {
                maxNumber = i;

            }
            if (i<minNumber)
            {
                minNumber = i;
            }
        }
        Console.WriteLine(maxNumber);
        Console.WriteLine(minNumber);
    }
}

