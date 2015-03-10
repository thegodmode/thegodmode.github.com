using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CalculateTheSum
{
    static void Main(string[] args)
    {
        double sum = 1;
        for (int index = 2; index<=1000; index = index + 2)
        {
            
            sum = sum + 1.0 / index;
            sum = sum - 1.0 / (index + 1);
        }
        Console.WriteLine(sum);
    }
}

