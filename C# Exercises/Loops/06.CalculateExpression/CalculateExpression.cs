using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CalculateExpression
{
    static void Main(string[] args)
    {
        decimal N = Decimal.Parse(Console.ReadLine());
        decimal X = Decimal.Parse(Console.ReadLine());
        decimal factoriel = 1;
        decimal result = 0;
        for (decimal i = 1; i <= N; i++)
        {
            factoriel = 1;
            for (decimal k = i; k>=1; k--)
            {
                factoriel *= k;
               
            }
            result = result + factoriel / (decimal)Math.Pow((double)X, (double)i); 
        }
        Console.WriteLine(result+1);
    }
}

