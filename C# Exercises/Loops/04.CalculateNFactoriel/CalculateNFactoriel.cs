using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CalculateNFactoriel
{
    static void Main(string[] args)
    {
        decimal N = Decimal.Parse(Console.ReadLine());
        decimal K = Decimal.Parse(Console.ReadLine());
        decimal product = 1;
        for (decimal i = K+1; i <= N; i++)
        {
            product *= i;
        }
        Console.WriteLine("The result is:{0}",1/product);
    }
}

